using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqTo
{
    public class FileTest
    {
        public FileTest() { }

        //To linq
        public string[] GetFiles(string cheminDossier, string partialName)
        {
            string[] tab = Directory.GetFiles(cheminDossier);
            string[] result = tab.Where(x => x.Contains("m")).ToArray();
            return result;
        }

        //To sql
        public List<string> GetFilesNames(string cheminDossier, string partialName)
        {
            var filesNames = Directory.GetFiles(cheminDossier);

            var listNames = from file in filesNames
                            where file.ToUpper().Contains(partialName.ToUpper())
                            select file;
            return listNames.ToList();
        }
    }
}
