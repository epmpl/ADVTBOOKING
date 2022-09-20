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

public partial class cyop : System.Web.UI.Page
{
    string checkboxname, compcode;
    string valuee = "";
    int j = 0;
    int z = 0;
    protected void Page_Load(object sender, EventArgs e)
    {

        Response.Expires = -1;
        if (Session["compcode"] == null)
        {
            Response.Write("<script>alert(\"Your Session  Been Expired\");window.close();</script>");
            return;

        }
        compcode = Session["compcode"].ToString();
        DataSet objDataSet = new DataSet();
        // Read in the XML file
        objDataSet.ReadXml(Server.MapPath("XML/Contractmaster.xml"));
        btnsubmit.Text = objDataSet.Tables[0].Rows[0].ItemArray[13].ToString();
        lbediname.Text = objDataSet.Tables[0].Rows[0].ItemArray[14].ToString();
        btnclose.Text = objDataSet.Tables[0].Rows[0].ItemArray[15].ToString();
        if (!Page.IsPostBack)
        {
            bindcheckbox();
            btnoptionbutton.Items[0].Selected = true;
            addatagrid(valuee);
            btnsubmit.Attributes.Add("onclick", "javascript:return selectall();");
            btnclose.Attributes.Add("onclick", "javascript:return closecyop();");
        }

    }

    public void addatagrid(string valuee)
    {
        DataSet da = new DataSet();
        if(ConfigurationSettings.AppSettings ["ConnectionType"].ToString ()=="sql")
        {
        NewAdbooking.Classes.Contract datagridbind = new NewAdbooking.Classes.Contract();
      
        da = datagridbind.bindgridContract(Session["compcode"].ToString(), Session["userid"].ToString(), valuee, "0");

        DataGrid1.DataSource = da;
        DataGrid1.DataBind();
        }

        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {

                NewAdbooking.classesoracle.Contract datagridbind = new NewAdbooking.classesoracle.Contract();

                da = datagridbind.bindgridContract(Session["compcode"].ToString(), Session["userid"].ToString(), valuee, "0");

                DataGrid1.DataSource = da;
                DataGrid1.DataBind();
            }
        else
        {
            NewAdbooking.classmysql.Contract datagridbind = new NewAdbooking.classmysql.Contract();
         
            da = datagridbind.bindgridContract(Session["compcode"].ToString(), Session["userid"].ToString(), valuee, "0");

            DataGrid1.DataSource = da;
            DataGrid1.DataBind();

        }





    }

    public void bindcheckbox()
    {
        DataSet da = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            NewAdbooking.Classes.CombinationMaster bindcheck = new NewAdbooking.Classes.CombinationMaster();

            da = bindcheck.checkboxbind();
        }

        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.CombinationMaster bindcheck = new NewAdbooking.classesoracle.CombinationMaster();

                da = bindcheck.checkboxbind();

            }
        else
        {
            NewAdbooking.classmysql.CombinationMaster bindcheck = new NewAdbooking.classmysql.CombinationMaster();

            da = bindcheck.checkboxbind();
        }


        int i;
        for (i = 0; i < da.Tables[0].Rows.Count; i++)
        {

            ListItem li;
            li = new ListItem();
            li.Value = da.Tables[0].Rows[i].ItemArray[1].ToString();
            li.Text = da.Tables[0].Rows[i].ItemArray[0].ToString();
            btnoptionbutton.Items.Add(li);
        }




    }
    protected void btnoptionbutton_SelectedIndexChanged_1(object sender, EventArgs e)
    {
       
        //saveormodify = "0";
        for (int j = 0; j < btnoptionbutton.Items.Count; j++)
        {
            if (btnoptionbutton.Items[j].Selected == true)
            {
                checkboxname = btnoptionbutton.SelectedValue.ToString();
            }


        }
        addatagrid(checkboxname);
    }
    protected void DataGrid1_ItemDataBound1(object sender, DataGridItemEventArgs e)
    {
        // j = 0;
        e.Item.Cells[2].Width = 72;
        e.Item.Cells[1].Width = 2;
        e.Item.Cells[3].Width = 22;
        e.Item.Cells[6].Width = 1;
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {


            string data = "uniquename" + e.Item.ItemIndex.ToString();

            //string radioval = "";
            string edition = e.Item.Cells[2].Text;
            string adcat = "0";
            DataSet ds = new DataSet();
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {

                NewAdbooking.Classes.CombinationMaster insert = new NewAdbooking.Classes.CombinationMaster();


             
                if (adcat == "0")
                {
                    ds = insert.geteditionforcontract(edition, checkboxname);
                }
                else
                {
                    ds = insert.geteditionbycat(edition, adcat, compcode, btnoptionbutton.SelectedValue);
                }
            }

            else
                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                {
                     NewAdbooking.classesoracle .CombinationMaster insert = new NewAdbooking.classesoracle.CombinationMaster();


             
                if (adcat == "0")
                {
                    ds = insert.geteditionforcontract(edition, checkboxname);
                }
                else
                {
                    ds = insert.geteditionbycat(edition, adcat, compcode, btnoptionbutton.SelectedValue);
                }
                }
            else
            {
                NewAdbooking.classmysql.CombinationMaster insert = new NewAdbooking.classmysql.CombinationMaster();


               
                if (adcat == "0")
                {
                    ds = insert.geteditionforcontract(edition, checkboxname);
                }
                else
                {
                    ds = insert.geteditionbycat(edition, adcat, compcode, btnoptionbutton.SelectedValue);
                }


            }

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

            e.Item.Cells[1].ID = "CellInfo" + e.Item.ItemIndex.ToString();

            if (ViewState["Mode"] != null && ViewState["Mode"].ToString() == "ShowDetails")
            {
                if (this.txtExpandedFields.Value.IndexOf(e.Item.Cells[1].ClientID) != -1)
                {
                    //make it expand.
                    FullDIV = FullDIV.Replace("DISPLAY: none", "DISPLAY: block");
                    //e.Item.Cells[0].Text = "<A>-</A>";
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
            //e.Item.Cells[0].Attributes["onclick"] = "HideShowPanel('uniquename" + e.Item.ItemIndex.ToString() + "'); ChangeHLText('" + e.Item.Cells[0].ClientID + "'); SetExpanded('" + e.Item.Cells[0].ClientID + "','" + txtExpandedFields.ClientID + "');";
            //e.Item.Cells[0].Attributes["onmouseover"] = "this.style.cursor='hand'";
            //e.Item.Cells[0].Attributes["onmouseout"] = "this.style.cursor='hand'";


            string imgname = "img" + j;
            e.Item.Cells[1].Text = "<img src='Images/plus.gif' id='" + imgname + "'  onClick=\"openGridcont('" + data + "','" + imgname + "')\"/>";


            string str = "DataGrid1__ctl_CheckBox1" + j;
            e.Item.Cells[3].Text = "<input type='checkbox' enabled width='5px' id=" + str + " onClick=\"javascript:return columncheck('1','" + j + "','" + str + "');\" value=" + e.Item.Cells[2].Text + "  />";


            
            string imgnametrip = "imgtri" + j;
            string path = "Images/TripleStateCheckBox/UnChecked.gif";
            e.Item.Cells[0].Text = "<img src='Images/TripleStateCheckBox/UnChecked.gif' id='" + imgnametrip + "' value=" + e.Item.Cells[2].Text + "  onClick=\"changeimage('" + imgnametrip + "','" + path + "','" + j + "')\" />";

            z = 0;
            j++;
        }

    }

    public void SetProps(System.Web.UI.WebControls.DataGrid DG)
    {
        // DG.Columns[4].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
        DG.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
        DG.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
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

    protected void NewDg_ItemDataBound1(object sender, DataGridItemEventArgs e)
    {
        e.Item.Cells[0].Width = 90;
        e.Item.Cells[1].Width = 22;

        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {


            //string imgnametrip =j+ "imgtrichild" + z;
            //string path = "Images/TripleStateCheckBox/UnChecked.gif";
            //e.Item.Cells[0].Text = "<img src='Images/TripleStateCheckBox/UnChecked.gif' id='" + imgnametrip + "' onClick=\"childchangeimage('" + imgnametrip + "','" + path + "')\" />";

            //e.Item.Cells[9].Visible = false;
           
            string str = j + "1" + z;
            //if (e.Item.Cells[1].Text == "Y")
            //{
            e.Item.Cells[1].Text = "<input type='checkbox' enabled width='5px' id=" + str + "  onclick=\"javascript:return unchk('" + str + "','1','" + j + "')\"  value=" + e.Item.Cells[0].Text + "   />";
           
            z++;
        }
    }
}
