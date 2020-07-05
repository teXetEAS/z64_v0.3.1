using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    class Record
    {
        List<Param> @params = new List<Param>();
        List<Legal> legals = new List<Legal>();
        
        public int sumPrice { get; set; }
        public string enterLegalName { get; set; }

        string adresTotal = "total.txt";
        string adresReport = "report.txt";
        string part = Environment.CurrentDirectory;

        public void GetListParam(string type, string price)
        {
            @params.Add(new Param(type, price));
        }

        public void GetListLegal(string legalType, string legalName)
        {
            legals.Add(new Legal(legalType));

            enterLegalName = legalName;
        }

        public void RecordParam()
        {
            using (StreamWriter sw1 = new StreamWriter(part + adresReport, true, Encoding.UTF8))
            {
                foreach (var i in @params)
                {
                    sw1.WriteLine(i.enterType + "/" + i.enterPrice);
                }
            }
            RecSubTotal();
            @params.Clear();
        }

        public void RecodLegal()
        {            
            using (StreamWriter swLegal = new StreamWriter(part + adresReport, true, Encoding.UTF8))
            {
                swLegal.WriteLine("\n" + enterLegalName);
                foreach(var i in legals)
                {
                    swLegal.WriteLine(i.enterLegalType + "\n");
                }
            }
            legals.Clear();
        }
                        
        public void ZeroPrice()
        {
            int subTotal = int.Parse(File.ReadLines(part + adresTotal).Last());
            using (StreamWriter sw2 = new StreamWriter(part + adresReport, true, Encoding.UTF8))
            {
                sw2.WriteLine("Касса обнулилась на " + subTotal);
            }
            MessageBox.Show("Касса обнулилась на " + subTotal);
            sumPrice = 0;

            File.Delete(part + adresTotal);

            int a = 0;
            using (StreamWriter addTotal = new StreamWriter(part + adresTotal, false, Encoding.UTF8))
            {
                addTotal.WriteLine(a);
            }
        }
               

        public void RecSubTotal()
        {
            if (!File.Exists(part + adresTotal))
            {
                File.Create(part + adresTotal).Dispose();
                using (TextWriter tw = new StreamWriter(part + adresTotal))
                {
                    tw.WriteLine(0);
                    tw.Close();
                }
            }

            int totalPer = int.Parse(File.ReadLines(part + adresTotal).Last());
            int sumPrice = @params.Sum(n => n.enterPrice);
            int subTotal = totalPer + sumPrice;
            using (StreamWriter sTotal = new StreamWriter(part + adresTotal, true, Encoding.UTF8))
            {
                sTotal.WriteLine(subTotal);
            }
        }

        public void Total()
        {
            int subTotal = int.Parse(File.ReadLines(part + adresTotal).Last());
            using (StreamWriter sw = new StreamWriter(part + adresReport, true, Encoding.UTF8))
            {
                sw.WriteLine("Итог = " + subTotal + "\n");
            }
            Mail mail = new Mail();            
            mail.SetMail();
            File.Delete(part + adresReport);
        }
    }
}
