using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LinqTo
{
    public class FileXml
    {
        private List<XElement> employees;

        public List<XElement> Employees { get => employees; set => employees = value; }

        /// <summary>
        /// Charge la liste des employés
        /// </summary>
        /// <param name="cheminFichier"></param>
        public FileXml(string cheminFichier)
        {
            employees = XElement.Load(cheminFichier).Elements("Employee").ToList();
        }

        /// <summary>
        /// Liste les employés de sex Female
        /// </summary>
        /// <param name="cheminFichier"></param>
        /// <returns></returns>
        public List<XElement> GetFemalesEmployees(string cheminFichier)
        {
            return employees.Where(e => e.Element("Sex").Value == "Female").ToList();
        }

        /// <summary>
        /// Liste les employés habitant Alta
        /// </summary>
        /// <param name="cheminFichier"></param>
        /// <returns></returns>
        public List<XElement> GetAltaEmployees(string cheminFichier)
        {
            return employees.Where(e => e.Element("Address").Element("City").Value == "Alta").ToList();
        }

        /// <summary>
        /// Permet d'ajouter un employé
        /// </summary>
        /// <param name="cheminFichier"></param>
        /// <returns></returns>
        public XElement AddEmployees(string cheminFichier)
        {
            XElement employee = XElement.Load(cheminFichier);

            employee.Add(
                new XElement("Employee",
                new XElement("EmpId", "5"),
                new XElement("NAme", "John"),
                new XElement("Sex", "Male"),
                new XElement("Phone", "425-555-0785",
                    new XAttribute("Type", "Home")),
                new XElement("Phone", "425-555-587",
                    new XAttribute("Type", "Work")),
                new XElement("Address",
                    new XElement("Street", "Capucines"),
                    new XElement("City", "Rouen"),
                    new XElement("State", "CA"),
                    new XElement("Zip", "76000"),
                    new XElement("Country", "France"))));
            employee.Save(cheminFichier);
            return employee;
        }

        public List<string> GetListeNameEmployees(string cheminFichier)
        {
            return employees.Select(e => e.Element("Name").Value).ToList();
        }
    }
}
