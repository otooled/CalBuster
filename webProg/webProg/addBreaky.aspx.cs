using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace webProg
{
    public partial class addBreaky : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TreeView1.ExpandDepth = 0;
            TreeView1.RootNodeStyle.ImageUrl = "images/cuts.jpg";
            if (!Page.IsPostBack)
            {
                TreeView1.Nodes.Add(new TreeNode("Breakfast"));
                
                TreeView1.Nodes.Add(new TreeNode("Lunch"));
                TreeView1.Nodes.Add(new TreeNode("Dinner"));
                TreeView1.Nodes.Add(new TreeNode("Snacks"));

                TreeView1.Nodes[0].ChildNodes.Add(new TreeNode("Cereals"));
                TreeView1.Nodes[0].ChildNodes.Add(new TreeNode("fries"));
                TreeView1.Nodes[0].ChildNodes.Add(new TreeNode("eggs"));

                TreeView1.Nodes[0].ChildNodes[0].ChildNodes.Add(new TreeNode("grandChildNode1"));
                TreeView1.Nodes[0].ChildNodes[0].ChildNodes.Add(new TreeNode("grandChildNode1"));
                TreeView1.Nodes[0].ChildNodes[0].ChildNodes.Add(new TreeNode("grandChildNode1"));

                TreeView1.Nodes[0].ChildNodes[1].ChildNodes.Add(new TreeNode("grandChildNode2"));
                TreeView1.Nodes[0].ChildNodes[1].ChildNodes.Add(new TreeNode("grandChildNode2"));
                TreeView1.Nodes[0].ChildNodes[1].ChildNodes.Add(new TreeNode("grandChildNode2"));

                TreeView1.Nodes[0].ChildNodes[2].ChildNodes.Add(new TreeNode("grandChildNode3"));
                TreeView1.Nodes[0].ChildNodes[2].ChildNodes.Add(new TreeNode("grandChildNode3"));
                TreeView1.Nodes[0].ChildNodes[2].ChildNodes.Add(new TreeNode("grandChildNode3"));

                TreeView1.Nodes[1].ChildNodes.Add(new TreeNode("sandwiches"));
                TreeView1.Nodes[1].ChildNodes.Add(new TreeNode("hot food"));
                TreeView1.Nodes[1].ChildNodes.Add(new TreeNode("chipper"));

                TreeView1.Nodes[1].ChildNodes[0].ChildNodes.Add(new TreeNode("grandChildNode1"));
                TreeView1.Nodes[1].ChildNodes[0].ChildNodes.Add(new TreeNode("grandChildNode1"));
                TreeView1.Nodes[1].ChildNodes[0].ChildNodes.Add(new TreeNode("grandChildNode1"));

                TreeView1.Nodes[2].ChildNodes.Add(new TreeNode("sandwiches"));
                TreeView1.Nodes[2].ChildNodes.Add(new TreeNode("hot food"));
                TreeView1.Nodes[2].ChildNodes.Add(new TreeNode("chipper"));

                TreeView1.Nodes[2].ChildNodes[0].ChildNodes.Add(new TreeNode("grandChildNode1"));
                TreeView1.Nodes[2].ChildNodes[0].ChildNodes.Add(new TreeNode("grandChildNode1"));
                TreeView1.Nodes[2].ChildNodes[0].ChildNodes.Add(new TreeNode("grandChildNode1"));

                TreeView1.Nodes[3].ChildNodes.Add(new TreeNode("sandwiches"));
                TreeView1.Nodes[3].ChildNodes.Add(new TreeNode("hot food"));
                TreeView1.Nodes[3].ChildNodes.Add(new TreeNode("chipper"));

                TreeView1.Nodes[3].ChildNodes[0].ChildNodes.Add(new TreeNode("grandChildNode1"));
                TreeView1.Nodes[3].ChildNodes[0].ChildNodes.Add(new TreeNode("grandChildNode1"));
                TreeView1.Nodes[3].ChildNodes[0].ChildNodes.Add(new TreeNode("grandChildNode1"));
            }

        }
    }
}