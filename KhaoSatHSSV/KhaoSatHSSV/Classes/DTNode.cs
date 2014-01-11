using System;
using System.Collections.Generic;
using System.Text;

namespace KhaoSatHSSV.Classes
{
    public class DTNode
    {
        private int id;
        private static int countID = 0;
        private string name;
        private bool isAttribute;//true if this node is Attribute Node
                                //false if this node is Value Node
        private bool leaf;
        private List<Example> lslExample;//empty if this is Value Node
                                        //store all trainning examples in this group if this is Attribute Node
        private int parentID;
        private int nChild;
        private int level;

        private int start;
        private int end;
        private bool isSetStartEnd;

        public DTNode()
        {
            id = countID++;
            name = "";
            isAttribute = false;
            parentID = -1;
            nChild = 0;
            leaf = false;
            lslExample = new List<Example>();
            level = 0;
            start = 0;
            end = 0;
            isSetStartEnd = false;
        }

        public DTNode(string _name, bool _isAttr, int _parentID, int _level, bool _leaf)
        {
            id = countID++;
            name = _name;
            isAttribute = _isAttr;
            parentID = _parentID;
            nChild = 0;
            leaf = _leaf;
            lslExample = new List<Example>();
            level = _level;
            start = 0;
            end = 0;
            isSetStartEnd = false;
        }

        public bool AllChildInOneClass()
        {
            if (lslExample.Count == 0 || lslExample.Count == 1)
                return true;
            else
            {
                for (int i = 1; i < lslExample.Count; i++)
                {
                    if (lslExample[i].GetLastValue() != lslExample[i - 1].GetLastValue())
                        return false;
                }
                return true;
            }
        }

        public void SetStartEnd(int _stat, int _end)
        {
            start = _stat;
            end = _end;
            isSetStartEnd = true;
        }

        public bool IsSetStartEnd
        {
            get{return isSetStartEnd;}
        }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public bool Leaf
        {
            get { return leaf; }
            set { leaf = value; }
        }

        public bool Attribute
        {
            get { return isAttribute; }
            set { isAttribute = value; }
        }

        public int ParentID
        {
            get{return parentID;}
            set
            {
                parentID = value; 
            }
        }

        public int NChild
        {
            get { return nChild; }
            set { nChild = value; }
        }

        public int Level
        {
            get { return level; }
            set { level = value; }
        }

        public int Start
        {
            get { return start; }
            set { start = value; }
        }

        public int End
        {
            get { return end; }
            set { end = value; }
        }

        public List<Example> Examples
        {
            get { return lslExample; }
            set { lslExample = value; }
        }

        public static int CountID
        {
            get { return countID; }
            set { countID = value; }
        }
    }
}
