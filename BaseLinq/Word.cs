using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLinq
{
    public class Word
    {
        private int ID;
        private string Value;

        public Word() { }

        public Word(int id, string value)
        {
            ID = id;
            Value = value;
        }

        public int id { get => ID; set => ID = id; }

        public string val { get => Value; set => Value = val; }

        //public override string ToString()
        //{
        //    return string.Format("{0}; {1}", ID, Value);
        //}

        public Word[] ConvertToArray(string sentence)
        {
            string[] tab = sentence.Split(' ');

            Word[] words = new Word[tab.Length];

            int i = 0;

            foreach (var word in words)
            {
                Word w = new Word(i + 1, tab[i]);
                words[i] = w;
                i++;
            }

            //for (int i = 0; i <= tab.Length - 1; i++)
            //{
            //    Word w = new Word(i + 1, tab[i]);
            //    words[i] = w;
            //}

            return words;
        }

        public Word[] Trier(Word[] words)
        {
            var tableTrier = (from Word in words
                             orderby Word.Value ascending
                             select Word).ToArray();
            return tableTrier;
        }
    }
}
