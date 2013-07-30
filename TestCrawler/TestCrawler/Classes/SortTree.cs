using System;
using System.IO;
using System.Collections;
using System.Web.UI.WebControls;

namespace TestCrawler
{
	/// <summary>
	/// Summary description for SortTree.
	/// </summary>
	public class SortTree
	{
		public SortTreeNode Root;
		public int Count;
		public bool Modified;

		public SortTree()
		{
		}
		public void Clear()
		{
			Root = null;
			Count = 0;
			Modified = false;
		}
	

		public SortTreeNode Add(ref string str)
		{
			SortTreeNode node;
			if(Root == null)
			{
				Root = new SortTreeNode();
				node = Root;
			}
			else	
			{
				node = Root;
				while(true)
				{
					if(node.Text == str)
					{
						node.Count++;
						return node;
					}
					if(String.Compare(node.Text, str, StringComparison.Ordinal) > 0)
					{	// add the node at the small branch
						if(node.Small == null)
						{
							node.Small = new SortTreeNode();
							node.Small.Parent = node;
							node = node.Small;
							break;
						}
						node = node.Small;
					}
					else
					{	// add the node at the great branch
						if(node.Great == null)
						{
							node.Great = new SortTreeNode {Parent = node};
						    node = node.Great;
							break;
						}
						node = node.Great;
					}
				}	
			}
			node.Text = str;
			node.ID = this.Count++;
			node.Count++;
			Modified = true;
			
			return node;
		}
	
	}
	public class SortTreeNode
	{
		public SortTreeNode Parent;
		public SortTreeNode Small;
		public SortTreeNode Great;
		public string Text;
		public int Count;
		public int ID;

		public object Tag;
	}

	
}
