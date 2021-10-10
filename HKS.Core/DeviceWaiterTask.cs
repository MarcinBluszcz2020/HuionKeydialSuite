using HidLibrary;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HKS.Core
{
    public class DeviceWaiterTask : IDisposable
    {
        private Task _Task;
        private CancellationTokenSource _cts;
        private object _lockObject;
        private readonly Func<HidDevice> _deviceAccessor;
        private TimeSpan _loopPause;
        private readonly Action<HidDevice> _deviceFoundCallback;

        public DeviceWaiterTask(Func<HidDevice> deviceAccessor, TimeSpan loopPause, Action<HidDevice> deviceFoundCallback)
        {
            _lockObject = new object();
            _deviceAccessor = deviceAccessor;
            _loopPause = loopPause;
            _deviceFoundCallback = deviceFoundCallback;
        }

        public void WaitForDevice()
        {
            lock (_lockObject)
            {
                if (_cts != null)
                {
                    return;
                }

                _cts = new CancellationTokenSource();
                _Task = Task.Factory.StartNew(() => TaskLoop(_cts.Token), TaskCreationOptions.LongRunning);
            }
        }

        private void Stop(bool waitForTask)
        {
            lock (_lockObject)
            {
                if (_cts == null)
                {
                    return;
                }

                _cts.Cancel();

                if (waitForTask)
                {
                    try
                    {
                        _Task.Wait();
                    }
                    catch
                    {
                    }
                }

                _cts = null;
                _Task = null;
            }
        }

        private void TaskLoop(CancellationToken cancellationToken)
        {
            while (cancellationToken.IsCancellationRequested == false)
            {
                var device = _deviceAccessor();

                if (device != null)
                {
                    NotifyDeviceFound(device);
                    Stop(false);
                }

                cancellationToken.WaitHandle.WaitOne(_loopPause);
            }
        }

        private void NotifyDeviceFound(HidDevice device)
        {
            Task.Run(() => _deviceFoundCallback(device));
        }

        public void Dispose()
        {
            Stop(true);
        }
    }
}
