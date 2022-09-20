using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Drawing;
using System.Data.OracleClient;

public partial class editiormast_pop : System.Web.UI.Page
{
    string type;
    string selectstate;
    string selectdist;
    string selectcity;
    int j = 0;
    DataRow my_row;
    static string gbcircno, gbreaderno, gbstate, dbdistrict, dbcity, dbseqno, dbeditionno;
    static DataSet dk1 = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {       
        if (Session["compcode"] != null)
        {
            hiddencompcode.Value = Session["compcode"].ToString();
            hiddenuserid.Value = Session["userid"].ToString();
        }
        else 
        {
            Response.Write("<script>window.parent.location=\"login.aspx\";</script>");
            return;
        }
        type= Request.QueryString["type"].ToString();
        edicod.Value = Request.QueryString["editioncode"].ToString();
        cityname.Value = Request.QueryString["cityname"].ToString();
        //drpCity.Value = Request.QueryString["cityname"].ToString(); ;
        Ajax.Utility.RegisterTypeForAjax(typeof(editiormast_pop));
        DataSet objDataSetbu = new DataSet();
        // Read in the XML file
        objDataSetbu.ReadXml(Server.MapPath("XML/editiormast_pop.xml"));
        lblcrcu.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[0].ToString();
        lblrder.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[1].ToString();
        lblstate.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[2].ToString();
        lbldstrct.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[3].ToString();
        lblcity.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[4].ToString();
        btnsubmit.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[5].ToString();
        btnupdate.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[6].ToString();
        btnclose.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[7].ToString();
        if (!Page.IsPostBack)
        {            
            if (type == "new")
            {               
                btnsubmit.Enabled = true;
                btnupdate.Enabled = true;
                btnclose.Enabled = true;
                //btnupdate.BackColor = Color.DimGray;
                //btnclose.BackColor = Color.DimGray;
             }
            else if (type == "query")
            {
                //queryinfo();
                btnsubmit.Enabled = true;
                btnupdate.Enabled = true;
                btnclose.Enabled = true;
                bindgrid(hiddencompcode.Value, edicod.Value);
            }
            
            //drpState.Attributes.Add("OnChange", "javascript:return filldistrict();");
            //drpdistrct.Attributes.Add("OnChange", "javascript:return fillcity();");
            btnsubmit.Attributes.Add("OnClick", "javascript:return btnsave();");
            btnupdate.Attributes.Add("OnClick", "javascript:return btnmodify();");
            btnclose.Attributes.Add("OnClick", "javascript:return btndelete();");
        }
        else
        {
            //queryinfo();
            bindgrid(hiddencompcode.Value, edicod.Value);
        }
        State();
        city();
      
    }
    public void bindgrid(string comcode, string editioncode)
        {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.editionmast_circulation supost = new NewAdbooking.Classes.editionmast_circulation();
            ds = supost.gridbind(comcode, editioncode);
           
        }
        else if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "query_edtiongrid_temp";
            string[] parameterValueArray = { comcode, editioncode };
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);

        }
        else
        {
            NewAdbooking.classesoracle.ContractDetails_pop voucherent = new NewAdbooking.classesoracle.ContractDetails_pop();
            ds = voucherent.gridbind(comcode, editioncode);
        }
        DataView dv = new DataView();
        dv = ds.Tables[0].DefaultView;
        contactgrid.DataSource = dv;
        contactgrid.DataBind();
     }
    

    public void State()
    {
        drpState.Items.Clear();
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.CityMaster StateName = new NewAdbooking.Classes.CityMaster();
            ds = StateName.state(Session["compcode"].ToString(), Session["userid"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.CityMaster StateName = new NewAdbooking.classesoracle.CityMaster();
            ds = StateName.state(Session["compcode"].ToString(), Session["userid"].ToString());
        }
        else if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "CityMst_State_CityMst_State_p";
            string[] parameterValueArray = { Session["compcode"].ToString(), Session["userid"].ToString() };
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);

        }

        ListItem li1;
        li1 = new ListItem();
        li1.Text = "---Select State---";
        li1.Value = "0";
        drpState.Items.Add(li1);
        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            if (selectstate == li.Value)
            {
                li.Selected = true;
                hidnstate.Value = selectstate;
            }
            drpState.Items.Add(li);
        }
        if(type== "query" && selectcity != null )
        {
        district(selectstate,hiddencompcode.Value,hiddenuserid.Value);
        }
    }

    public void district(string code1, string compcode, string userid)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.CityMaster bind = new NewAdbooking.Classes.CityMaster();
            ds = bind.binddistrict(code1, compcode, userid);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Classes.CityMaster bind = new NewAdbooking.Classes.CityMaster();
            ds = bind.binddistrict(code1, compcode, userid);
        }
        else if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "BINDDISTRICT_BINDDISTRICT_P";
            string[] parameterValueArray = { Session["compcode"].ToString(), Session["userid"].ToString(), code1 };
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);

        }
        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            if (selectdist == li.Value)
            {
                li.Selected = true;
                hidndist.Value= selectdist;
            }
            drpdistrct.Items.Add(li);
        }
        if(type== "query" && selectdist != null )
        {
        city(selectdist, selectstate, hiddencompcode.Value, hiddenuserid.Value);
        }
    }

    public void city(string dstcode, string code1, string compcode, string userid)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.editionmast_circulation bind = new NewAdbooking.Classes.editionmast_circulation();
            ds = bind.bindCity(dstcode, code1, compcode, userid);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Classes.editionmast_circulation bind = new NewAdbooking.Classes.editionmast_circulation();
            ds = bind.bindCity(dstcode, code1, compcode, userid);
        }
        else if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "bindcity_edition";
            string[] parameterValueArray = { Session["compcode"].ToString(), code1, dstcode, userid };
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);

        }
        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            if (selectcity == li.Value)
            {
                li.Selected = true;
                hidncity.Value = selectcity;
            }
            drpCity.Items.Add(li);
        }

    }

    [Ajax.AjaxMethod]
    public DataSet filldistrict(string code1, string compcode, string userid)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.CityMaster bind = new NewAdbooking.Classes.CityMaster();
            ds = bind.binddistrict(code1, compcode, userid);
            return ds;
        }
        else
        {
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.CityMaster bind = new NewAdbooking.classesoracle.CityMaster();
                ds = bind.binddistrict(code1, compcode, userid);
                return ds;
            }
            else if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "mysql")
            {
                string procedureName = "binddistrict_binddistrict_p";
                string[] parameterValueArray = { code1, compcode, userid };
                NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
                return ds;
            }
            return ds;
        }       
    }
    [Ajax.AjaxMethod]
    public DataSet fillcity(string dstcode, string code1, string compcode, string userid)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.editionmast_circulation bind = new NewAdbooking.Classes.editionmast_circulation();
            ds = bind.bindCity(dstcode, code1, compcode, userid);
            return ds;
        }
        else
        {
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.CityMaster bind = new NewAdbooking.classesoracle.CityMaster();
                ds = bind.bindCity(dstcode, code1, compcode, userid);
                return ds;
            }
            else if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "mysql")
            {
                string procedureName = "BINDCITY_EDITION";
                string[] parameterValueArray = { compcode, code1, dstcode, userid };
                NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
                return ds;
            }
            return ds;
        }
    }
    [Ajax.AjaxMethod]
    public DataSet fillgridtxt(string comcode, string seqn)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.editionmast_circulation supost = new NewAdbooking.Classes.editionmast_circulation();
            ds = supost.gridtxt(comcode, seqn);
        }
        else if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "fill_grid_txt_edition";
            string[] parameterValueArray = { comcode, seqn };
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
            return ds;
        }
        else
        {
            NewAdbooking.classesoracle.ContractDetails_pop voucherent = new NewAdbooking.classesoracle.ContractDetails_pop();
            ds = voucherent.gridtxt(comcode, seqn);
        }
        return ds;
    }
    [Ajax.AjaxMethod]
    public string getseq()
    {
        try
        {
            string NExt_seq = "";
            DataSet ds = new DataSet();
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                OracleConnection con = new OracleConnection();
                con.ConnectionString = ConfigurationSettings.AppSettings["orclconnectionstring"].ToString();
                con.Open();
                OracleCommand cmd = new OracleCommand();
                string str = "SELECT contact_info_SEQ.NEXTVAL FROM DUAL";
                cmd.CommandText = str;
                cmd.Connection = con;
                OracleDataAdapter da = new OracleDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
                NExt_seq = ds.Tables[0].Rows[0].ItemArray[0].ToString();
                con.Close();
                con.Dispose();
            }
            else if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "mysql")
            {
                string procedureName = "nextval";
                string[] parameterValueArray = { "contact_info_SEQ" };
                NewAdbooking.classmysql.Master obj = new NewAdbooking.classmysql.Master();
                ds = obj.BindCommanFunction(procedureName, parameterValueArray);
                NExt_seq = ds.Tables[0].Rows[0].ItemArray[0].ToString();    
            }
            else
            {
                NewAdbooking.Classes.editionmast_circulation name = new NewAdbooking.Classes.editionmast_circulation();
                ds = name.contactseq();
                NExt_seq = ds.Tables[0].Rows[0].ItemArray[0].ToString();
            }
            return NExt_seq;
        }
        catch (Exception ex)
        {
            return ex.Message.ToString();
        }
    }

    [Ajax.AjaxMethod]
    public DataSet saveinfo(string seq, string comcode, string crcno, string rdrno, string state, string distct, string city, string editioncode)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.editionmast_circulation supost = new NewAdbooking.Classes.editionmast_circulation();
            ds = supost.saveinfo(seq, comcode, crcno, rdrno, state, distct, city, editioncode);
        }
        else if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "SAVE_CICU_TEMP";
            string[] parameterValueArray = { comcode, crcno, rdrno, state, distct, city, seq, editioncode };
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
            return ds;
        }
        else
        {
            NewAdbooking.classesoracle.EditorMaster voucherent = new NewAdbooking.classesoracle.EditorMaster();
            ds = voucherent.saveinfo(seq, comcode, crcno, rdrno, state, distct, city, editioncode);
        }
        return ds;
    }
    [Ajax.AjaxMethod]
    public DataSet mainsaveinfo(string seq, string comcode, string crcuno, string rdrno, string state, string dist, string city, string editioncode)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.editionmast_circulation supost = new NewAdbooking.Classes.editionmast_circulation();
            ds = supost.saveinfomain(seq, comcode, crcuno, rdrno, state, dist, city, editioncode);
        }
        else if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "save_cicu_main";
            string[] parameterValueArray = { comcode, crcuno, rdrno, state, dist, city, seq, editioncode };
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
            return ds;
        }
        else
        {
            NewAdbooking.classesoracle.EditorMaster voucherent = new NewAdbooking.classesoracle.EditorMaster();
            ds = voucherent.saveinfomain(seq, comcode, crcuno, rdrno, state, dist, city, editioncode);
        }
        return ds;
    }
    public void queryinfo()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.editionmast_circulation supost = new NewAdbooking.Classes.editionmast_circulation();
            ds = supost.qryinfo(Session["compcode"].ToString(), edicod.Value);
        }
        else if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "QUERY_CIRC_MAIN";
            string[] parameterValueArray = { Session["compcode"].ToString(), edicod.Value };
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
            
        }

        else
        {
            NewAdbooking.classesoracle.EditorMaster voucherent = new NewAdbooking.classesoracle.EditorMaster();
            ds = voucherent.qryinfo(Session["compcode"].ToString(), edicod.Value);
        }
        if (ds.Tables[0].Rows.Count > 0)
        {
            hidseq.Value = ds.Tables[0].Rows[0].ItemArray[0].ToString();
            txtcrcu.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
            txtno.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
            selectstate = ds.Tables[0].Rows[0].ItemArray[4].ToString();
            selectdist = ds.Tables[0].Rows[0].ItemArray[5].ToString();
            selectcity = ds.Tables[0].Rows[0].ItemArray[6].ToString();
        }
        //else
        //{
        //    Response.Write("<script>alert(\"Search Criteria Does not Exist\");window.close();</script>");
        //    return;
        //}

    }

    [Ajax.AjaxMethod]
    public DataSet mainupdateinfo(string seq, string comcode, string crcno, string rdrno, string state, string distct, string city)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.editionmast_circulation supost = new NewAdbooking.Classes.editionmast_circulation();
            ds = supost.updateinfo(seq, comcode, crcno, rdrno, state, distct, city);
        }
        else if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "UPDATE_CIRCU_MAIN";
            string[] parameterValueArray = { comcode, crcno, rdrno, state, distct, city, seq };
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);

        }
        else
        {
            NewAdbooking.classesoracle.EditorMaster voucherent = new NewAdbooking.classesoracle.EditorMaster();
            ds = voucherent.updateinfo(seq, comcode, crcno, rdrno, state, distct, city);
        }
        return ds;
    }
    [Ajax.AjaxMethod]
    public DataSet tempupdateinfo(string seq, string comcode, string crcno, string rdrno, string state, string distct, string city)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.editionmast_circulation supost = new NewAdbooking.Classes.editionmast_circulation();
            ds = supost.updateinfotemp(seq, comcode, crcno, rdrno, state, distct, city);
        }
        else if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "UPDATE_CIRCU_TEMP";
            string[] parameterValueArray = { comcode, crcno, rdrno, state, distct, city, seq };
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);

        }
        else
        {
            NewAdbooking.classesoracle.EditorMaster voucherent = new NewAdbooking.classesoracle.EditorMaster();
            ds = voucherent.updateinfotemp(seq, comcode, crcno, rdrno, state, distct, city);
        }
        return ds;
    }

    [Ajax.AjaxMethod]
    public DataSet maindeleteinfo(string seq, string comcode)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.editionmast_circulation supost = new NewAdbooking.Classes.editionmast_circulation();
            ds = supost.deleteinfo(seq, comcode);
        }
        else if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "DELETE_CIRC_MAIN";
            string[] parameterValueArray = { comcode, seq };
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);

        }
        else
        {
            NewAdbooking.classesoracle.EditorMaster voucherent = new NewAdbooking.classesoracle.EditorMaster();
            ds = voucherent.deleteinfo(seq, comcode);
        }
        return ds;
    }
    [Ajax.AjaxMethod]
    public DataSet tempdeleteinfo(string seq, string comcode)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.editionmast_circulation supost = new NewAdbooking.Classes.editionmast_circulation();
            ds = supost.deleteinfotemp(seq, comcode);
        }
        else if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "DELETE_CIRC_TEMP";
            string[] parameterValueArray = { comcode, seq };
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);

        }
        else
        {
            NewAdbooking.classesoracle.EditorMaster voucherent = new NewAdbooking.classesoracle.EditorMaster();
            ds = voucherent.deleteinfotemp(seq, comcode);
        }
        return ds;
    }
    protected void DataGrid_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        DataView dv = new DataView();
        dv = (DataView)contactgrid.DataSource;
        DataColumnCollection dc = dv.Table.Columns;

        if (e.Item.ItemType != ListItemType.Header)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                string str = "DataGrid1__ctl_CheckBox1" + j;
                e.Item.Cells[0].Text = "<input type='checkbox' id=" + str + " OnClick=\"javascript:return selected('" + str + "');\"  value=" + e.Item.Cells[6].Text + "  />";
                j++;
            }
        }
    }
    public void city()
    {
        drpCity.Items.Clear();
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.editionmast_circulation CityName = new NewAdbooking.Classes.editionmast_circulation();
            ds = CityName.cityname(Session["compcode"].ToString(), cityname.Value);
        }
        else if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "FILL_CITY_DIST_STATE";
            string[] parameterValueArray = { Session["compcode"].ToString(), cityname.Value };
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);

        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.EditorMaster StateName = new NewAdbooking.classesoracle.EditorMaster();
            ds = StateName.cityname(Session["compcode"].ToString(), cityname.Value);
        }
        //else
        //{
        //    NewAdbooking.classmysql.CityMaster StateName = new NewAdbooking.classmysql.CityMaster();
        //    ds = StateName.state(Session["compcode"].ToString(), Session["userid"].ToString());
        //}
        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            li.Selected = true;
            hidncity.Value = li.Value;
            drpCity.Items.Add(li);
        }
         filldist_state();
    }
    public void filldist_state()
    {
        drpState.Items.Clear();
        drpdistrct.Items.Clear();
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.editionmast_circulation Dist_State = new NewAdbooking.Classes.editionmast_circulation();
            ds = Dist_State.Dist_State(Session["compcode"].ToString(), hidncity.Value);
        }
        else if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "FILL_DIST";
            string[] parameterValueArray = { Session["compcode"].ToString(), hidncity.Value };
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);

        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.EditorMaster StateName = new NewAdbooking.classesoracle.EditorMaster();
            ds = StateName.Dist_State(Session["compcode"].ToString(), hidncity.Value);
        }
        //else
        //{
        //    NewAdbooking.classmysql.CityMaster StateName = new NewAdbooking.classmysql.CityMaster();
        //    ds = StateName.state(Session["compcode"].ToString(), Session["userid"].ToString());
        //}
        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            li.Selected = true;
            drpdistrct.Items.Add(li);
            ListItem li1;
            li1 = new ListItem();
            li1.Value = ds.Tables[0].Rows[i].ItemArray[2].ToString();
            li1.Text = ds.Tables[0].Rows[i].ItemArray[3].ToString();
            li1.Selected = true;
            drpState.Items.Add(li1);
        }
        
    }

  }
