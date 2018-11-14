using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqTo
{
    class Program
    {
        static void Main(string[] args)
        {
            string cheminDossier = @"C:\DossierTest";

            //FileTest fileTest = new FileTest();

            //fileTest.GetFiles(cheminDossier).ToList().ForEach(x => Console.WriteLine(x.ToString()));

            //Console.ReadKey();

            var fileTest = new FileTest();
            var names = fileTest.GetFiles(cheminDossier, "ex");
            foreach (var name in names)
                Console.WriteLine(string.Format("Nom: {0}", name));
            Console.ReadKey();

        }
    }
}
