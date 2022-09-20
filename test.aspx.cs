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

public partial class test : System.Web.UI.Page
{
     string valuee = "";
    int j,z;
    public string newdiv;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["__EVENTTARGET"] != null)
        {
            string strEventTarget = Request["__EVENTTARGET"].ToString().ToLower();
            if (strEventTarget.IndexOf("datagrid1") == -1)
            {
                //Expanded what ever the user had expanded by Setting Mode
                //which will be used in ItemDataBound method.
                ViewState["Mode"] = "ShowDetails";
                //Not caused by datagrid
                //We need to rebind data and generate scripts.

            }
            else
            {
                ViewState["Mode"] = null;
            }
        }


       string  compcode = Session["compcode"].ToString();
       string  userid = Session["userid"].ToString();
      
        addatagrid();
    }


    public void addatagrid()
    {
        NewAdbooking.Classes.CombinationMaster datagridbind = new NewAdbooking.Classes.CombinationMaster();
        DataSet da = new DataSet();
        da = datagridbind.bindgrid(Session["compcode"].ToString(), Session["userid"].ToString(), valuee,"fi0","0","0");

        DataGrid1.DataSource = da;
        DataGrid1.DataBind();



    }
    protected void NewDg_ItemDataBound1(object sender, DataGridItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            string str = "1" + z;
            if (e.Item.Cells[1].Text == "Y")
            {
                e.Item.Cells[1].Text = "<input type='checkbox' enabled width='5px' id=" + str + "  value=" + e.Item.Cells[0].Text + "  />";
            }
            else
            {
                e.Item.Cells[1].Text = "<input type='checkbox' disabled width='5px' id=" + str + "  value=" + e.Item.Cells[0].Text + "  />";
            }

            string str1 = "1a" + z;
            if (e.Item.Cells[2].Text == "Y")
            {
                e.Item.Cells[2].Text = "<input type='checkbox' enabled width='5px' id=" + str1 + "  value=" + e.Item.Cells[0].Text + "  />";
            }
            else
            {
                e.Item.Cells[2].Text = "<input type='checkbox' disabled width='5px' id=" + str1 + "  value=" + e.Item.Cells[0].Text + "  />";
            }

            string str2 = "1b" + z;
            if (e.Item.Cells[3].Text == "Y")
            {
                e.Item.Cells[3].Text = "<input type='checkbox' enabled width='5px' id=" + str2 + "  value=" + e.Item.Cells[0].Text + "  />";
            }
            else
            {
                e.Item.Cells[3].Text = "<input type='checkbox' disabled width='5px' id=" + str2 + "  value=" + e.Item.Cells[0].Text + "  />";
            }

            string str3 = "1c" + z;
            if (e.Item.Cells[4].Text == "Y")
            {
                e.Item.Cells[4].Text = "<input type='checkbox' enabled width='5px' id=" + str3 + "  value=" + e.Item.Cells[0].Text + "  />";
            }
            else
            {
                e.Item.Cells[4].Text = "<input type='checkbox' disabled width='5px' id=" + str3 + "  value=" + e.Item.Cells[0].Text + "  />";
            }

            string str4 = "1d" + z;
            if (e.Item.Cells[5].Text == "Y")
            {
                e.Item.Cells[5].Text = "<input type='checkbox' enabled width='5px' id=" + str4 + "  value=" + e.Item.Cells[0].Text + "  />";
            }
            else
            {
                e.Item.Cells[5].Text = "<input type='checkbox' disabled width='5px' id=" + str4 + "  value=" + e.Item.Cells[0].Text + "  />";
            }

            string str5 = "1e" + z;
            if (e.Item.Cells[6].Text == "Y")
            {
                e.Item.Cells[6].Text = "<input type='checkbox' enabled width='5px' id=" + str5 + "  value=" + e.Item.Cells[0].Text + "  />";
            }
            else
            {
                e.Item.Cells[6].Text = "<input type='checkbox' disabled width='5px' id=" + str5 + "  value=" + e.Item.Cells[0].Text + "  />";
            }

            string str6 = "1f" + z;
            if (e.Item.Cells[7].Text == "Y")
            {
                e.Item.Cells[7].Text = "<input type='checkbox' enabled width='5px' id=" + str6 + "  value=" + e.Item.Cells[0].Text + "  />";
            }
            else
            {
                e.Item.Cells[7].Text = "<input type='checkbox' disabled width='5px' id=" + str6 + "  value=" + e.Item.Cells[0].Text + "  />";
            }


            string str7 = "1g" + z;

            e.Item.Cells[8].Text = "<input type='checkbox' enabled width='5px' id=" + str7 + "  value=" + e.Item.Cells[0].Text + "  />";


            string str8 = "1h" + z;
            e.Item.Cells[9].Text = "<input type='checkbox' enabled width='5px' id=" + str8 + "  value=" + e.Item.Cells[0].Text + "  />";


            string str9 = "1i" + z;
            e.Item.Cells[10].Text = "<input type='checkbox' enabled width='5px' id=" + str9 + "  value=" + e.Item.Cells[0].Text + "  />";

            z++;
        }
    }
    protected void  DataGrid1_ItemDataBound1(object sender, DataGridItemEventArgs e)
    {
    if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
    {
      
        string edition = e.Item.Cells[1].Text;
        System.IO.StringWriter sw1 = new System.IO.StringWriter();

        System.Web.UI.HtmlTextWriter htw1 = new System.Web.UI.HtmlTextWriter(sw1);
        //1111111
        
        
        
        
        
        
      
        
        NewAdbooking.Classes.CombinationMaster insert = new NewAdbooking.Classes.CombinationMaster();

        string radioval = "";
        //or better performance, and you not use a grid and bind labels, textbox's, etc...
        DataSet ds = new DataSet();
        ds = insert.getedition(edition, radioval);
        DataGrid NewDg = new DataGrid();
        NewDg.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(NewDg_ItemDataBound1);
        NewDg.AutoGenerateColumns = true;
        NewDg.Width = Unit.Percentage(100.00);
        NewDg.DataSource = ds;
        NewDg.DataBind();
        SetProps(NewDg);
        System.IO.StringWriter sw = new System.IO.StringWriter();
        
        System.Web.UI.HtmlTextWriter htw = new System.Web.UI.HtmlTextWriter(sw);

        NewDg.RenderControl(htw);
      
        string DivStart = "<DIV id='uniquename" + e.Item.ItemIndex.ToString() + "' style='DISPLAY: none; HEIGHT: 1px;'>";
        string DivBody = sw.ToString();
        //edittext(DivBody);
        
        string DivEnd = "</DIV>";
        string FullDIV = DivStart + DivBody + DivEnd;

        int LastCellPosition = e.Item.Cells.Count - 1;
        int NewCellPosition = e.Item.Cells.Count - 2;

        e.Item.Cells[0].ID = "CellInfo" + e.Item.ItemIndex.ToString();

        if (ViewState["Mode"] != null && ViewState["Mode"].ToString() == "ShowDetails")
        {
            if (this.txtExpandedFields.Text.IndexOf(e.Item.Cells[0].ClientID) != -1)
            {
                //make it expand.
                FullDIV = FullDIV.Replace("DISPLAY: none", "DISPLAY: block");
                e.Item.Cells[0].Text = "<A>-</A>";
            }
        }

        //match color
        if (e.Item.ItemType == ListItemType.Item)
        {
            e.Item.Cells[LastCellPosition].Text = e.Item.Cells[LastCellPosition].Text + "</td><tr><td bgcolor='f5f5f5'></td><td colspan='" + NewCellPosition + "'>" + FullDIV;
        }
        else
        {
            e.Item.Cells[LastCellPosition].Text = e.Item.Cells[LastCellPosition].Text + "</td><tr><td bgcolor='d3d3d3'></td><td colspan='" + NewCellPosition + "'>" + FullDIV;
        }
        e.Item.Cells[0].Attributes["onclick"] = "HideShowPanel('uniquename" + e.Item.ItemIndex.ToString() + "'); ChangeHLText('" + e.Item.Cells[0].ClientID + "'); SetExpanded('" + e.Item.Cells[0].ClientID + "','" + txtExpandedFields.ClientID + "');";
        e.Item.Cells[0].Attributes["onmouseover"] = "this.style.cursor='hand'";
        e.Item.Cells[0].Attributes["onmouseout"] = "this.style.cursor='hand'";


        string str = "DataGrid1__ctl_CheckBox1" + j;
        if (e.Item.Cells[14].Text == "Y")
        {
            e.Item.Cells[2].Text = "<input type='checkbox' enabled width='5px' id=" + str + "  value=" + e.Item.Cells[12].Text + "  />";
        }
        else
        {
            e.Item.Cells[2].Text = "<input type='checkbox' disabled width='5px' id=" + str + "  value=" + e.Item.Cells[12].Text + "  />";
        }



        string str1 = "DataGrid1__ctl_CheckBox1a" + j;


        if (e.Item.Cells[15].Text == "Y")
        {
            e.Item.Cells[3].Text = "<input type='checkbox' enabled width='5px' id=" + str1 + "  value=" + e.Item.Cells[12].Text + "  />";
        }
        else
        {
            e.Item.Cells[3].Text = "<input type='checkbox' disabled width='5px' id=" + str1 + "  value=" + e.Item.Cells[12].Text + "  />";
        }




        string str2 = "DataGrid1__ctl_CheckBox1b" + j;
        if (e.Item.Cells[16].Text == "Y")
        {
            e.Item.Cells[4].Text = "<input type='checkbox'  enabled width='5px' id=" + str2 + "  value=" + e.Item.Cells[12].Text + "  />";

        }
        else
        {
            e.Item.Cells[4].Text = "<input type='checkbox' disabled  width='5px' id=" + str2 + "  value=" + e.Item.Cells[12].Text + "  />";
        }


        string str3 = "DataGrid1__ctl_CheckBox1c" + j;

        if (e.Item.Cells[17].Text == "Y")
        {
            e.Item.Cells[5].Text = "<input type='checkbox' enabled width='5px' id=" + str3 + "  value=" + e.Item.Cells[12].Text + "  />";
        }
        else
        {
            e.Item.Cells[5].Text = "<input type='checkbox' disabled  width='5px' id=" + str3 + "  value=" + e.Item.Cells[12].Text + "  />";
        }


        string str4 = "DataGrid1__ctl_CheckBox1d" + j;
        if (e.Item.Cells[18].Text == "Y")
        {
            e.Item.Cells[6].Text = "<input type='checkbox' enabled width='5px' id=" + str4 + "  value=" + e.Item.Cells[12].Text + "  />";

        }
        else
        {
            e.Item.Cells[6].Text = "<input type='checkbox' disabled width='5px' id=" + str4 + "  value=" + e.Item.Cells[12].Text + "  />";
        }
        string str5 = "DataGrid1__ctl_CheckBox1e" + j;
        if (e.Item.Cells[19].Text == "Y")
        {
            e.Item.Cells[7].Text = "<input type='checkbox' enabled width='5px' id=" + str5 + "  value=" + e.Item.Cells[12].Text + "  />";

        }
        else
        {
            e.Item.Cells[7].Text = "<input type='checkbox' disabled width='5px' id=" + str5 + "  value=" + e.Item.Cells[12].Text + "  />";
        }



        string str6 = "DataGrid1__ctl_CheckBox1f" + j;
        if (e.Item.Cells[20].Text == "Y")
        {
            e.Item.Cells[8].Text = "<input type='checkbox' enabled width='5px' id=" + str6 + "  value=" + e.Item.Cells[12].Text + "  />";

        }
        else
        {
            e.Item.Cells[8].Text = "<input type='checkbox' disabled width='5px' id=" + str6 + "  value=" + e.Item.Cells[12].Text + "  />";
        }



        string str7 = "DataGrid1__ctl_CheckBox1g" + j;
        e.Item.Cells[9].Text = "<input type='checkbox'  width='5px' id=" + str7 + "  value=" + e.Item.Cells[12].Text + "  />";


        string str8 = "DataGrid1__ctl_CheckBox1h" + j;

        e.Item.Cells[10].Text = "<input type='checkbox'  width='5px' id=" + str8 + "  value=" + e.Item.Cells[12].Text + "  />";

        string data = "uniquename" + e.Item.ItemIndex.ToString();
        string imgname = "img" + j;
        string path="Images/TripleStateCheckBox/UnChecked.gif";
        e.Item.Cells[22].Text = "<img src='Images/TripleStateCheckBox/UnChecked.gif' id='" + imgname + "' onClick=\"changeimage('" + data + "','" + imgname + "','"+path+"')\" />";



        string str9 = "DataGrid1__ctl_CheckBox1k" + j;
        e.Item.Cells[11].Text = "<input type='checkbox'   width='5px' id=" + str9 + "  value=" + e.Item.Cells[12].Text + " onclick='javascript:return selectall(\"" + str9 + "\",\"" + j + "\");' />";
        //				string pub=e.Item.Cells[11].Text;
        //				string city=e.Item.Cells[12].Text;

        j++;
        }
        }
    
        public void SetProps(System.Web.UI.WebControls.DataGrid DG)
        {
            /****************************************************************************/
            DG.Font.Size = 8;
            DG.Font.Bold = false;
            DG.Font.Name = "tahoma";

            /*******************************Professional 2**********************************/
            //Border Props 
            DG.GridLines = GridLines.Both;
            DG.CellPadding = 3;
            DG.CellSpacing = 0;
            DG.BorderColor = System.Drawing.Color.FromName("#CCCCCC");
            DG.BorderWidth = System.Web.UI.WebControls.Unit.Pixel(1);


            //Header Props
            DG.HeaderStyle.BackColor = System.Drawing.Color.FromName("#7daae3");
            DG.HeaderStyle.ForeColor = System.Drawing.Color.White;
            DG.HeaderStyle.Font.Bold = true;
            DG.HeaderStyle.Font.Size = 8;
            DG.HeaderStyle.Font.Name = "tahoma";

            DG.ItemStyle.BackColor = System.Drawing.Color.FromName("#ffffff");

        }


    
}


