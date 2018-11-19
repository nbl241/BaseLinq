using System;
using System.Collections.Generic;
using System.Linq;
using LinqToSQL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestSample
{
    [TestClass]
    public class UnitTestWord
    {
        //Le service à tester
        private Word _wordClass = new Word();
        private IEqualityComparer<Word> _equalityComparerWord = new EqualityComparerWord();

        //Données Mock (de tests)
        private Word[] _wordArray = {
            new Word(1, "MotIndex0"),
            new Word(2, "MotIndex1"),
            new Word(3, "MotIndex2"),
            new Word(4, "MotIndex3"),
            new Word(5, "MotIndex4")
        };

        /// <summary>
        /// Verifier|Tester que :
        /// l'index 3 de mon tableau retourne le mot "MotIndex2"
        /// </summary>
        [TestMethod]
        public void TestFindWord()
        {
            //rechercher un mot par l'index 3
            var result = _wordClass.FindWord(_wordArray, 3);

            //Assert(s'assurer que le mot retrouvé correspond à "MotIndex2"
            Assert.AreEqual("MotIndex3", result);
        }

        /// <summary>
        /// Verifier|Tester la conversion d'une phrase en tableau Word
        /// </summary>
        [TestMethod]
        public void TestConvertToWordsArray()
        {
            //1- creer une variable (mock) de type string (phrase)
            string sentence = "MotIndex0 MotIndex1 MotIndex2 MotIndex3 MotIndex4";

            //2- utiliser la méthode ConvertToWordsArray (en input la phrase)
            var resultArray = _wordClass.ConvertToWordsArray(sentence);

            //3- vérifier que le tableau retourné est identique au tableau prévu
            var condition = resultArray.All(r => _wordArray
                            .Single(w => w.Id == r.Id).Id == r.Id)
                            &&
                            resultArray.All(r => _wordArray
                            .Single(w => w.Id == r.Id).Value == r.Value);

            var condition2 = resultArray.All(r => _equalityComparerWord.Equals(_wordArray.Single(w => w.Id == r.Id) == r));

            Assert.IsTrue(condition);
        }
    }
}
