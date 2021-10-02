namespace HKS.Core.Huion
{
    public class HuionKeyReport
    {
        public HuionKeyReport(
            bool a0,
            bool a1,
            bool a2,
            bool a3,
            bool a4,
            bool a5,
            bool a6,
            bool a7,
            bool b0,
            bool b1,
            bool b2,
            bool b3,
            bool b4,
            bool b5,
            bool b6,
            bool b7,
            bool c0,
            bool c1,
            bool c2
            )
        {
            A0 = a0;
            A1 = a1;
            A2 = a2;
            A3 = a3;
            A4 = a4;
            A5 = a5;
            A6 = a6;
            A7 = a7;

            B0 = b0;
            B1 = b1;
            B2 = b2;
            B3 = b3;
            B4 = b4;
            B5 = b5;
            B6 = b6;
            B7 = b7;

            C0 = c0;
            C1 = c1;
            C2 = c2;
        }

        public bool A0 { get; }
        public bool A1 { get; }
        public bool A2 { get; }
        public bool A3 { get; }
        public bool A4 { get; }
        public bool A5 { get; }
        public bool A6 { get; }
        public bool A7 { get; }

        public bool B0 { get; }
        public bool B1 { get; }
        public bool B2 { get; }
        public bool B3 { get; }
        public bool B4 { get; }
        public bool B5 { get; }
        public bool B6 { get; }
        public bool B7 { get; }

        public bool C0 { get; }
        public bool C1 { get; }
        public bool C2 { get; }
    }
}
