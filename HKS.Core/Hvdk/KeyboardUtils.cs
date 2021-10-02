using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKS.Core.Hvdk
{
    public partial class KeyboardUtils
    {
        public static string GetKeysHelpXmlString()
        {
            var sb = new StringBuilder();

            sb.AppendLine();
            sb.AppendLine("<!--");

            sb.AppendLine();

            sb.AppendLine("Modifiers: ");
            sb.AppendLine();
            var modiferKeys = ModifierKeys.GetKeys();

            foreach(var modifier in modiferKeys)
            {
                sb.AppendLine(modifier);
            }

            sb.AppendLine();
            sb.AppendLine("Keys: ");
            sb.AppendLine();
            var keys = Keys.GetKeys();

            foreach (var key in keys)
            {
                sb.AppendLine(key);
            }

            sb.AppendLine();

            sb.AppendLine("-->");

            

            return sb.ToString();
        }
    }
}
