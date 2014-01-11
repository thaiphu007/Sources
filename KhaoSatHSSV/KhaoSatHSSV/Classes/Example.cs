using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KhaoSatHSSV.Classes
{
    public class Example
    {
        public List<string> lslValue;

        public Example()
        {
            lslValue = new List<string>();
        }

        public Example(List<string> _lslValue)
        {
            lslValue = new List<string>();
            foreach (string s in _lslValue)
            {
                lslValue.Add(s);
            }
        }

        public void AddValue(string s)
        {
            lslValue.Add(s);
        }

        public string GetValue(int index)
        {
            if (index >= lslValue.Count)
                return null;
            return lslValue[index];
        }

        public string GetNameExample()
        {
            return lslValue[0];
        }

        public string GetLastValue()
        {
            return lslValue[lslValue.Count - 1];
        }

        public string GetResultTraining()
        {
            return lslValue[lslValue.Count - 1];
        }

        public int Length()
        {
            return lslValue.Count;
        }

        public void RemoveAt(int index)
        {
            if (index < lslValue.Count)
                lslValue.RemoveAt(index);
        }

        public List<string> ValueList
        {
            get { return lslValue; }
        }
    }
}