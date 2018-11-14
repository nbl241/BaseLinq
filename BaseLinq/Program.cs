using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            Word word = new Word();

            string sentenceA = "The quick brown fox jumps over the lazy dog";
            string sentenceB = "Portez ce vieux whisky au juge blond qui fume";

            Word[] tabA = word.ConvertToArray(sentenceA);
            Word[] tabB = word.ConvertToArray(sentenceB);

            tabA = word.Trier(tabA);
            tabB = word.Trier(tabB);

            Console.WriteLine("senteneA");
            Console.WriteLine("----------");
            foreach(var tab in tabA)
            {
                Console.WriteLine("{0} | {1}", tab.id, tab.val);
                Console.WriteLine("----------");
            }

            Console.WriteLine();
            Console.WriteLine("sentenceB");
            Console.WriteLine("----------");

            foreach (var tab in tabB)
            {
                Console.WriteLine("{0} | {1}", tab.id, tab.val);
                Console.WriteLine("----------");
            }

            Console.ReadKey();
        }
    }
}
