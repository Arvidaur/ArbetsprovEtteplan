using System.Xml.Linq;  


namespace ArbetsprovEtteplan
{
    public class Program
    {
        public static void Main(string[] args)
        {       
            // xmlPath är hårdkodad för specefikt min dator. Du behöver kopiera fullpath på gentext.xml som finns i solution explorer
            var xmlPath = "C:\\Users\\Arvid\\source\\repos\\ArbetsprovEtteplan\\ArbetsprovEtteplan\\gentext.xml";

            //doc används för att ladda in xml-filen som en XDocument som gör det möjligt att navigera i xml-filen
            var doc = XDocument.Load(xmlPath);

            //Skapar en lista av alla "trans-unit" element i xml-filen för att kuna söka på id
            var transUnits = doc.Descendants("trans-unit");

            //Där id är 42014 så letar vi efter "target" elementet och hämtar dess värde och sparar i variabeln text. FirstOrDefault() säkerställer att vi får det första elementet som matchar sökningen eller null om det inte finns något matchande element
            var text = transUnits
                .Where(t => t.Attribute("id")?.Value == "42014")
                .Select(t => t.Element("target")?.Value)
                .FirstOrDefault();

            //Skriver ut texten i konsolen och sparar den i en fil som heter output.txt samt så skriver den ut i konsolen
            //output.txt skapas i ArbetsprovEtteplan/bin/Debug/net6.0. Varje gång du kör programmet så kommer den att skriva över filen
            File.WriteAllText("output.txt", text);
            Console.WriteLine(text);            
        }
    }
}
