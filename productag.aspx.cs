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

public partial class productag : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string code = Request.QueryString["code"].ToString();
       

                                         //bind list box

                                        //NewAdbooking.Classes.pop productlistbox = new NewAdbooking.Classes.pop();
                                        //DataSet dz = new DataSet();
                                        //dz = productlistbox.productbind(Session["compcode"].ToString(),Session["userid"].ToString());
                                       

                                        //ListBox1.Items.Clear();
                                        //ListItem li1;
                                        //ListItem li2;
                                        //li1 = new ListItem();
                                        //li1.Text = "--Select --";
                                        //li1.Value = "0";
                                        //li1.Selected = true;

                                        //ListBox1.Items.Add(li1);

                                        //int i;
                                        //for (i = 0; i < dz.Tables[0].Rows.Count; i++)
                                        //{

                                        //    ListItem li;
                                        //    li = new ListItem();
                                        //    li.Value = dz.Tables[0].Rows[i].ItemArray[0].ToString();
                                        //    li.Text = dz.Tables[0].Rows[i].ItemArray[1].ToString();
                                        //    ListBox1.Items.Add(li);


                                        //}

                                        /////////////////////////////////



                                        //    NewAdbooking.Classes.pop productlistboxbutton = new NewAdbooking.Classes.pop();
                                        //    DataSet ds = new DataSet();
                                        //    ds = productlistboxbutton.buttonbind(Session["compcode"].ToString(), Session["userid"].ToString(), code);
                                        //    string listcode = ds.Tables[0].Rows[0].ItemArray[0].ToString();
                                        //    int z;
                                        //    char[] splitter = { ',' };



                                        //    string[] myarray = listcode.Split(splitter);

                                        //    for (z = 0; z <= myarray.Length - 1; z++)
                                        //    {
                                        //        if (myarray[z] != "")
                                        //        {
                                        //            if (myarray[z] != "0")
                                        //            {

                                        //                ListBox1.Items.FindByValue(myarray[z]).Selected = true;
                                        //                ListBox1.Items.FindByValue("0").Selected = false;

                                        //            }
                                        //        }
                                        //    }

       

    }
}
