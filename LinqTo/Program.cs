using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LinqTo
{
    class Program
    {
        static void Main(string[] args)
        {
            //string cheminDossier = @"C:\DossierTest";

            //ToLinq
            //
            //FileTest fileTest = new FileTest();
            //fileTest.GetFiles(cheminDossier).ToList().ForEach(x => Console.WriteLine(x.ToString()));
            //Console.ReadKey();

            //ToSql
            //
            //var fileTest = new FileTest();
            //var names = fileTest.GetFiles(cheminDossier, "ex");
            //foreach (var name in names)
            //    Console.WriteLine(string.Format("Nom: {0}", name));
            //Console.ReadKey();


            //ToXML
            //
            string cheminFichier = @"C:\DossierXml\linqxml.xml";

            FileXml fileXml = new FileXml(cheminFichier);

            List<XElement> female = fileXml.GetFemalesEmployees(cheminFichier);

            Console.WriteLine("Le nombre d'employés femme est : {0}", female.Count);
            Console.WriteLine("----------------------------------");
            female.ForEach(f => Console.WriteLine("-{0}", f.Element("Name").Value));
            Console.WriteLine();

            List<XElement> altaEmployees = fileXml.GetAltaEmployees(cheminFichier);

            Console.WriteLine("Le nombre d'employés habitant Alta est : {0}", altaEmployees.Count);
            Console.WriteLine("------------------------------------------");
            altaEmployees.ForEach(e => Console.WriteLine("-{0}", e.Element("Name").Value));
            Console.WriteLine();

            List<string> empl = fileXml.GetListeNameEmployees(cheminFichier);
            fileXml.AddEmployees(cheminFichier);

            Console.WriteLine("Le nombre d'employés est : {0}", empl.Count);
            Console.WriteLine("-----------------------------");
            empl.ForEach(e => Console.WriteLine("-{0}", e));

            Console.ReadKey();
        }
    }
}
