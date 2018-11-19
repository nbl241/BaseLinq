using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace LinqToSQL
{
    public class Word
    {
        public int Id { get; set; }
        public string Value { get; set; }

        public Word(int id, string value)
        {
            Id = id;
            Value = value;
        }

        public Word()
        {
        }

        /// <summary>
        /// Convertir une chaine de char en tableau d'objets Word en utilisant LINQ
        /// </summary>
        /// <param name="sentence"></param>
        /// <returns></returns>
        public Word[] ConvertToWordsArray(string sentence)
        {
            var sentenceArray = sentence.Split(' ');


            //********traitement en utilisant foreach Array**********\\
            //var wordsArray = new Word[sentenceArray.Length];
            //var index = 1;
            //foreach (var word in sentenceArray)
            //{
            //    wordsArray[index-1] = new Word(index++, word);
            //}
            //return wordsArray;

            //********traitement en utilisant foreach List**********\\
            //var wordsList = new List<Word>();
            //var listIndex = 1;
            //foreach (var word in sentenceArray)
            //{
            //    wordsList.Add(new Word(listIndex++, word));
            //}
            //return wordsList.ToArray();

            //********traitement en utilisant LINQ**********\\
            var linqIndex = 1;
            var wordList = from word in sentenceArray
                           select new Word(linqIndex++, word);
            return wordList.ToArray();
        }

        /// <summary>
        /// Trier un tableau et le retourner en utilisant LINQ
        /// </summary>
        /// <param name="wordArray"></param>
        /// <returns></returns>
        public Word[] SortArray(Word[] wordArray)
        {
            var wordList = from word in wordArray
                           orderby word.Value ascending
                           select word;

            return wordList.ToArray();
        }

        /// <summary>
        /// Retrouver les mots correspondants à l'id et retourner un Type anonyme (ID, "MotA MotB"). 
        /// </summary>
        /// <returns></returns>
        public object FindWords(Word[] tableauA, Word[] tableauB, int id)
        {
            var typeAnonyme = (from wordA in tableauA
                               join wordB in tableauB on wordA.Id equals wordB.Id
                               where wordA.Id == id
                               select new { Id = id, Name = string.Format("{0} {1}", wordA.Value, wordB.Value) }).First();


            Console.WriteLine("Mot trouvé, Id:" + typeAnonyme.Id + " Mot:" + typeAnonyme.Name);
            return typeAnonyme;
        }

        /// <summary>
        /// trouver un mot par son index
        /// </summary>
        /// <param name="wordArray"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public string FindWord(Word[] wordArray, int index)
        {
            var word = "";
            word = wordArray[index].Value;
            return word;
        }

        public object ThrowException()
        {
            try
            {
                //traitement qui ne marche pas et qui renvoi une exception
                throw new OutOfMemoryException("C'est une exception");
            }
            catch (Exception e)
            {
                throw new OutOfMemoryException("C'est une exception");
            }
        }
    }

    #region Word comparer
    public class EqualityComparerWord : IEqualityComparer<Word>
    {
        public bool Equals(Word x, Word y)
        {
            if (x == null && y == null)
                return true;

            if (x == null || y == null)
                return false;

            return x.Id == y.Id && x.Value == y.Value;
        }

        public int GetHashCode(Word obj)
        {
            return obj.Id.GetHashCode();
        }
    }
    #endregion

}


















//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace BaseLinq
//{
//    public class Word
//    {
//        private int ID;
//        private string Value;

//        public Word() { }

//        public Word(int id, string value)
//        {
//            ID = id;
//            Value = value;
//        }

//        public int id { get => ID; set => ID = id; }

//        public string val { get => Value; set => Value = val; }

//        //public override string ToString()
//        //{
//        //    return string.Format("{0}; {1}", ID, Value);
//        //}

//        public Word[] ConvertToArray(string sentence)
//        {
//            string[] tab = sentence.Split(' ');

//            Word[] words = new Word[tab.Length];

//            int i = 0;

//            foreach (var word in words)
//            {
//                Word w = new Word(i + 1, tab[i]);
//                words[i] = w;
//                i++;
//            }

//            //for (int i = 0; i <= tab.Length - 1; i++)
//            //{
//            //    Word w = new Word(i + 1, tab[i]);
//            //    words[i] = w;
//            //}

//            return words;
//        }

//        public Word[] Trier(Word[] words)
//        {
//            var t = words
//                .OrderBy(w => w.Value)
//                .ToArray();

//            //var tableTrier = (from word in words
//            //                  orderby word.Value
//            //                  select word).ToArray();

//            return t;
//        }

//        public Word[] FindWords(Word[] words)
//        {
//            // A faire
//        }
//    }
//}
