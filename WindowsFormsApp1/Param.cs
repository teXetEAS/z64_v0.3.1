using System;

namespace WindowsFormsApp1
{
    class Param
    {
        public string enterType { get; set; }
        public int enterPrice { get; set; }

        public Param(string type, string price)
        {
            enterType = type;
            enterPrice = int.Parse(price);
        }
    }

    class Legal
    {
        public string enterLegalType { get; set; }

        public Legal(string legalType)
        {
            enterLegalType = legalType;
        }
    }
}
