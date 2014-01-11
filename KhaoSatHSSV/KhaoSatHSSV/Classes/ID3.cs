using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KhaoSatHSSV.Classes
{
    public class ID3
    {
        List<string> description = new List<string>();
        public DecisionTree glDtID3Alg = new DecisionTree();
        public List<string> staticAtt = new List<string>();
        public List<Example> trainingExamples = new List<Example>();
        public List<string> attributes = new List<string>();

        public void ID3Alg(List<Example> te, List<string> att, int parentID)
        {
            //checking to end this function
            if (te.Count == 0)
                return;
            if (att.Count == 2)//first column and last column: ID & reslt column
                return;

            //choose the best decision attribute
            //int best = ChooseBestAttribute(te, staticAtt);
            string bestAtt = staticAtt[ChooseBestAttribute(te, staticAtt)];

            //update description
            description[description.Count - 1] += "--->Chọn: " + bestAtt + "\n\n";

            //searching parent's level
            int level = 0;
            for (int i = 0; i < glDtID3Alg.Nodes.Count; i++)
                if (glDtID3Alg.Nodes[i].ID == parentID)
                    level = glDtID3Alg.Nodes[i].Level;

            //create nodes
            //first, we create parent node
            DTNode parentNode = new DTNode(bestAtt, true, parentID, level + 1, false);
            parentNode.Examples = te;

            //counting N the number values of attribute
            //to create N child nodes of node above
            int positionAtt = staticAtt.IndexOf(bestAtt);//get index of att in attributes list
            List<string> values = new List<string>();
            foreach (Example exp in te)
                if (!values.Contains(exp.GetValue(positionAtt)))
                    values.Add(exp.GetValue(positionAtt));

            //add new child nodes of this attribute
            DTNode[] childNode = new DTNode[values.Count];
            for (int i = 0; i < values.Count; i++)
            {
                childNode[i] = new DTNode(values[i], false, parentNode.ID, parentNode.Level + 1, false);
            }
            //level++;

            //separate te into childNodes
            foreach (Example exam in te)
            {
                for (int i = 0; i < values.Count; i++)
                    if (childNode[i].Name == exam.GetValue(staticAtt.IndexOf(bestAtt)))
                        childNode[i].Examples.Add(exam);
            }

            //add nodes to decision tree
            glDtID3Alg.AddNode(parentNode);
            for (int i = 0; i < values.Count; i++)
                glDtID3Alg.AddNode(childNode[i]);

            //we remove the best decision attribute before this function is recalled
            att.Remove(bestAtt);

            List<string> tmpatt = new List<string>();
            for (int i = 0; i < att.Count; i++)
                tmpatt.Add(att[i]);
            for (int i = 0; i < values.Count; i++)
                if (childNode[i].AllChildInOneClass() != true)
                    ID3Alg(childNode[i].Examples, tmpatt, childNode[i].ID);
                else
                {
                    //add new node Yes or No to this tree
                    DTNode tmpNode = new DTNode(childNode[i].Examples[0].GetLastValue(), false, childNode[i].ID, childNode[i].Level + 1, true);
                    glDtID3Alg.AddNode(tmpNode);
                }
        }

        private double Entropy(List<Example> te)
        {
            //te: training examples

            //count the number of status of result's training examples
            Dictionary<string, int> results = new Dictionary<string, int>();
            foreach (Example exam in te)
            {
                string key = exam.GetResultTraining();
                if (results.ContainsKey(key) == false)
                {
                    //adding new key to dictionary
                    results.Add(key, 1);
                }
                else
                {
                    //increasing key's value
                    int value = results[key] + 1;
                    results.Remove(key);
                    results.Add(key, value);
                }
            }

            //evaluate Entropy
            double entropy = 0;
            double probability;
            ICollection<string> ss = results.Keys;
            foreach (string s in ss)
            {
                int k = results[s];
                probability = (double)results[s] / te.Count;
                entropy -= probability * Math.Log(probability, 2);
            }
            return entropy;
        }

        private double GainInformation(List<Example> te, int positionAtt, double entropy)
        {
            //te: training examples
            //att: attribute
            //ent: entropy

            //counting the number values of attribute
            //int positionAtt = staticAtt.IndexOf(att);//get index of att in attributes list
            if (positionAtt < 0)
                return 0;

            List<string> values = new List<string>();
            foreach (Example exp in te)
            {
                if (!values.Contains(exp.GetValue(positionAtt)))
                    values.Add(exp.GetValue(positionAtt));
            }

            //separate to N sub examples
            List<Example>[] subTe = new List<Example>[values.Count];
            for (int i = 0; i < values.Count; i++)
                subTe[i] = new List<Example>();
            foreach (Example exam in te)
            {
                for (int i = 0; i < values.Count; i++)
                {
                    if (exam.GetValue(positionAtt) == values[i])
                    {
                        subTe[i].Add(exam);
                        break;
                    }
                }
            }

            //evaluate entropy of sub training examples
            double[] entropyAtt = new double[values.Count];
            for (int i = 0; i < values.Count; i++)
                entropyAtt[i] = Entropy(subTe[i]);

            //evaluate gain information
            //double gainInfo = Entropy(te);
            for (int i = 0; i < subTe.Length; i++)
                entropy -= (double)subTe[i].Count / te.Count * entropyAtt[i];
            return entropy;
        }

        private int MaxGain(double[] gain, List<string> att)
        {
            //we will ignore first and last column
            int max = 1;
            for (int i = 2; i < gain.Length - 1; i++)
                if (gain[max] < gain[i])
                    max = i;
            return max;
        }
        private int ChooseBestAttribute(List<Example> te, List<string> att)
        {
            if (te.Count == 0 || att.Count == 0)
                return -1;
            double entropyTe = Entropy(te);
            double[] gainTe = new double[att.Count];
            for (int i = 0; i < att.Count; i++)
                gainTe[i] = GainInformation(te, i, entropyTe);

            //get string
            string tmp = "";
            tmp += "Entropy([";
            for (int i = 0; i < te.Count; i++)
                tmp += te[i].GetNameExample() + ",";
            tmp = tmp.Remove(tmp.Length - 1);
            tmp += "]) = " + entropyTe.ToString() + "\n";
            for (int i = 1; i < att.Count - 1; i++)
                tmp += "Gain(" + att[i] + ") = " + gainTe[i].ToString() + "\n";
            description.Add(tmp);

            return MaxGain(gainTe, att);
        }
    }
}