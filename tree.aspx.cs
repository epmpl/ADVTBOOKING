using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Drawing;
public partial class tree : System.Web.UI.Page
{
    public void GenrateTreeView()
    {

       // DataSet myDataSet = GetData();

      //  foreach (DataRow parentRow in myDataSet.Tables["department"].Rows)
       // {

           // TreeNode parentNode = new TreeNode((string)parentRow["dname"]);
         if (!Page.IsPostBack)
         {
            // tree1
            TreeNode parentNode = new TreeNode((string)"IT Department");
            parentNode.ShowCheckBox = true;
           

            parentNode.Target = "frameContent";
            //parentNode.NavigateUrl = "http://www.ezinemart.com";
             
            tree1.Nodes.Add(parentNode);
             
            //foreach (DataRow childRow in parentRow.GetChildRows("Child"))
           // {

                //TreeNode childNode = new TreeNode((string)childRow["ename"]);
            TreeNode childNode = new TreeNode((string)"Project Manager");

                parentNode.ChildNodes.Add(childNode);
                TreeNode childNode1 = new TreeNode((string)"Lata Madan");
                childNode.ChildNodes.Add(childNode1);
    }

            //}

       // }

    }
    protected void Page_Load(object sender, EventArgs e)
    {

        GenrateTreeView();

    }
}
