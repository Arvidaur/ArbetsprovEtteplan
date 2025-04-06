using System.Xml.Linq;


namespace ArbetsprovEtteplan
{
    public class Program
    {
        public static void Main(string[] args)
        {       
                // xmlPath är hårdkodad för specefikt min dator. Du behöver kopiera fullpath på gentext.xml som finns i solution explorer
                var xmlPath = "C:\\Users\\Arvid\\source\\repos\\ArbetsprovEtteplan\\ArbetsprovEtteplan\\gentext.xml";
                var doc = XDocument.Load(xmlPath);

                var transUnits = doc.Descendants("trans-unit");

                var text = transUnits
                    .Where(t => t.Attribute("id")?.Value == "42014")
                    .Select(t => t.Element("target")?.Value)
                    .FirstOrDefault();

                File.WriteAllText("output.txt", text);
                Console.WriteLine(text);            
        }
    }
}
