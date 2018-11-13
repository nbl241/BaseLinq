using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLinq
{
    class Word
    {
        private int ID;
        private string Value;

        public Word(int id, string value)
        {
            ID = id;
            Value = value;
        }

        public int id { get => ID; set => ID = id; }
        public string val { get => Value; set => Value = val; }

        public override string ToString()
        {
            return string.Format("{0}; {1}", ID, Value);
        }

        public Word[] ConvertToArray(string sentence)
        {

        }
    }
}
