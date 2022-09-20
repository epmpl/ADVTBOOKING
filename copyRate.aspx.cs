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
using System.Data.SqlClient;
using System.Data.OracleClient;

public partial class copyRate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //drpcat.Attributes.Add("onchange", "javascript:return filladsubcatmain();");
        
        if (!Page.IsPostBack)
        {
            if (Session["dateformat"] != null)
            {
                hiddendateformat.Value = Session["dateformat"].ToString();
            }
            else
            {
                hiddendateformat.Value = "mm/dd/yyyy";
            }
            Ajax.Utility.RegisterTypeForAjax(typeof(copyRate));
            btngo.Attributes.Add("OnClick", "javascript:return check();");


            txtfromdate.Attributes.Add("onChange", "javascript:return checkdate(this);  ");
            txttodate.Attributes.Add("onChange", "javascript:return checkdate(this);  ");

           // DataSet objDataSet = new DataSet();
            //objDataSet.ReadXml(Server.MapPath("XML/copyrate.xml"));
            // from1.Text = objDataSet.Tables[0].Rows[0].ItemArray[0].ToString();

            string str = "";
            str += "<table><tr><td>From Date</td><td style='color:red;'>*</td></tr></table>";
            from1.InnerHtml += str;
            string str1="";
                     str1 += "<table><tr><td>To Date</td><td style='color:red;' >*</td></tr></table>";

                     to1.InnerHtml += str1;



         
            
            adtypedata();
            bindcolor();
            ratecode(Session["compcode"].ToString());
           // binduom();
        }
    }
    public void adtypedata()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.CombinationMaster bind = new NewAdbooking.Classes.CombinationMaster();
            ds = bind.adtypbind(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.CombinationMaster bind = new NewAdbooking.classesoracle.CombinationMaster();
            ds = bind.adtypbind(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "advtypbind_advtypbind_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { Session["compcode"].ToString() };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
            int i;
            ListItem li1;
            li1 = new ListItem();
            drpadtype.Items.Clear();
            li1.Text = "-Select Ad Type-";
            li1.Value = "0";
            li1.Selected = true;
            drpadtype.Items.Add(li1);

            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ListItem li;
                li = new ListItem();
                li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                drpadtype.Items.Add(li);
            }
    }
    public void bindcolor()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Contract bindcolor = new NewAdbooking.Classes.Contract();

            ds = bindcolor.colorbind(Session["compcode"].ToString(), Session["userid"].ToString());
        }

        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.Contract bindcolor = new NewAdbooking.classesoracle.Contract();

                ds = bindcolor.colorbind(Session["compcode"].ToString(), Session["userid"].ToString());
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
            {
                string procedureName = "bindcolor_bindcolor_p";
                NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                string[] parameterValueArray = { Session["compcode"].ToString(), Session["userid"].ToString() };
                ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
            }
        int i;
        ListItem li;
        li = new ListItem();
        drpcat.Items.Clear();
        drpsubcat.Items.Clear();
        drpsubsubcat.Items.Clear();
        drpcatdest.Items.Clear();
        li.Text = "-- Select --";
        li.Value = "0";
        li.Selected = true;
        drpcolor.Items.Add(li);
        drpcolorcop.Items.Add(li);

        if (ds.Tables.Count > 0)
        {
            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ListItem li1;
                li1 = new ListItem();
                li1.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                li1.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                drpcolor.Items.Add(li1);
                drpcolorcop.Items.Add(li1);
            }
        }
        drpcolor.Enabled = true;
        drpcolorcop.Enabled = true;
    }
    private DataSet advcategory(string compcode, string adtype)
    {
        SqlConnection objSqlConnection;
        SqlCommand objSqlCommand;
        NewAdbooking.Classes.connection clscon = new NewAdbooking.Classes.connection();
        objSqlConnection = clscon.GetConnection();
        SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = clscon.GetCommand("adcategory", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            objSqlCommand.Parameters.Add("@adtype", SqlDbType.VarChar);
            objSqlCommand.Parameters["@adtype"].Value = adtype;

            objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@compcode"].Value = compcode;

            objSqlDataAdapter.SelectCommand = objSqlCommand;
            objSqlDataAdapter.Fill(objDataSet);
            return objDataSet;
        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            clscon.CloseConnection(ref objSqlConnection);
        }
    }
    private DataSet ratecodebind(string compcode)
    {
        SqlConnection objSqlConnection;
        SqlCommand objSqlCommand;
        NewAdbooking.Classes.connection clscon = new NewAdbooking.Classes.connection();
        objSqlConnection = clscon.GetConnection();
        SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = clscon.GetCommand("add_bind_ratecode", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;


            objSqlCommand.Parameters.Add("@pcompcode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@pcompcode"].Value = compcode;

            objSqlDataAdapter.SelectCommand = objSqlCommand;
            objSqlDataAdapter.Fill(objDataSet);
            return objDataSet;
        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            clscon.CloseConnection(ref objSqlConnection);
        }
    }

    public void ratecode(string compcode)
    {
        DataSet dsrate = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            dsrate = ratecodebind(compcode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "add_bind_ratecode";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { compcode };
            dsrate = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        else
        {
            dsrate = ratecodebind1(compcode);
        }
        int i;
        ListItem li;
        li = new ListItem();
        drpratecode.Items.Clear();
       
        li.Text = "-- Select --";
        li.Value = "0";
        li.Selected = true;
        drpratecode.Items.Add(li);


        if (dsrate.Tables.Count > 0)
        {
            for (i = 0; i < dsrate.Tables[0].Rows.Count; i++)
            {
                ListItem li1;
                li1 = new ListItem();
                li1.Value = dsrate.Tables[0].Rows[i].ItemArray[0].ToString();
                li1.Text = dsrate.Tables[0].Rows[i].ItemArray[0].ToString();
             
                drpratecode.Items.Add(li1);
                txtRatecode.Items.Add(li1);
            }
        }
        drpratecode.Enabled = true;
        txtRatecode.Enabled = true;
    }


    public void advcat(string compcode,string adtype)
    {
        DataSet dsCat = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            dsCat = advcategory(compcode,adtype);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "adcategory_adcategory_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { compcode,adtype };
            dsCat = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        else
        {
            dsCat = advcategory1(compcode, adtype);
        }
        int i;
        ListItem li;
        li = new ListItem();
        drpcat.Items.Clear();
        drpsubcat.Items.Clear();
        drpsubsubcat.Items.Clear();
        drpcatdest.Items.Clear();
        li.Text = "-- Select --";
        li.Value = "0";
        li.Selected = true;
        drpcat.Items.Add(li);
        drpcatdest.Items.Add(li);

        if (dsCat.Tables.Count > 0)
        {
            for (i = 0; i < dsCat.Tables[0].Rows.Count; i++)
            {
                ListItem li1;
                li1 = new ListItem();
                li1.Value = dsCat.Tables[0].Rows[i].ItemArray[0].ToString();
                li1.Text = dsCat.Tables[0].Rows[i].ItemArray[1].ToString();
                drpcat.Items.Add(li1);
                drpcatdest.Items.Add(li1);
            }
        }
        drpcatdest.Enabled = true;
        drpcat.Enabled = true;

    }
    public DataSet advsubcategory(string compcode, string adcategory)
    {
        SqlConnection objSqlConnection;
        SqlCommand objSqlCommand;
        NewAdbooking.Classes.connection clscon = new NewAdbooking.Classes.connection();
        objSqlConnection = clscon.GetConnection();
        SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = clscon.GetCommand("advsubcategory", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;
            objSqlCommand.Parameters.Add("@adcategory", SqlDbType.VarChar);
            objSqlCommand.Parameters["@adcategory"].Value = adcategory;
            objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@compcode"].Value = compcode;

            objSqlDataAdapter.SelectCommand = objSqlCommand;
            objSqlDataAdapter.Fill(objDataSet);
            return objDataSet;
        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            clscon.CloseConnection(ref objSqlConnection);
        }
    }

    protected void drpcat_SelectedIndexChanged(object sender, EventArgs e)
    {
        string category = drpcat.SelectedValue;
        DataSet ds;
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            ds = advsubcategory(Session["compcode"].ToString(), category);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "advsubcategory_advsubcategory_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { Session["compcode"].ToString(), category};
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        else
        {
            ds = advsubcategory1(Session["compcode"].ToString(), category);
        }
        if (category != "0")
        {

        
            int i;
            ListItem li;
            li = new ListItem();
            drpsubcat.Items.Clear();
            li.Text = "--  Select Sub Category --";
            li.Value = "0";
            li.Selected = true;
            drpsubcat.Items.Add(li);


            if (ds.Tables.Count > 0)
            {
                for (i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    ListItem li1;
                    li1 = new ListItem();
                    li1.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                    li1.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                    drpsubcat.Items.Add(li1);
                }
            }






        }
        else
        {
            ListItem li1;
            li1 = new ListItem();
            drpsubcat.Items.Clear();
            li1.Text = "--  Select Sub Category --";
            li1.Value = "0";
            li1.Selected = true;
            drpsubcat.Items.Add(li1);

        }
        if (drpsubcat.Items.Count > 0)
            drpsubcat.Enabled = true;
        else
            drpsubcat.Enabled = false;

    }
    protected void drpcatdest_SelectedIndexChanged(object sender, EventArgs e)
    {
        string category = drpcatdest.SelectedValue;
        DataSet ds;
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            ds = advsubcategory(Session["compcode"].ToString(), category);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "advsubcategory_advsubcategory_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { Session["compcode"].ToString(), category };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        else
        {
            ds = advsubcategory1(Session["compcode"].ToString(), category);
        }

        if (category != "0")
        {


            int i;
            ListItem li;
            li = new ListItem();
            drpsubcatdest.Items.Clear();
            li.Text = "--  Select Sub Category --";
            li.Value = "0";
            li.Selected = true;
            drpsubcatdest.Items.Add(li);


            if (ds.Tables.Count > 0)
            {
                for (i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    ListItem li1;
                    li1 = new ListItem();
                    li1.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                    li1.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                    drpsubcatdest.Items.Add(li1);
                }
            }






        }
        else
        {
            ListItem li1;
            li1 = new ListItem();
            drpsubcatdest.Items.Clear();
            li1.Text = "--  Select Sub Category --";
            li1.Value = "0";
            li1.Selected = true;
            drpsubcatdest.Items.Add(li1);

        }
        if (drpsubcatdest.Items.Count > 0)
            drpsubcatdest.Enabled = true;
        else
            drpsubcatdest.Enabled = false;
    }
    private DataSet advsubsubcategory(string adsubcategory)
    {
        SqlConnection objSqlConnection;
        SqlCommand objSqlCommand;
        NewAdbooking.Classes.connection clscon = new NewAdbooking.Classes.connection();
        objSqlConnection = clscon.GetConnection();
        SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = clscon.GetCommand("advsubsubcategory", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;
            objSqlCommand.Parameters.Add("@adsubcategory", SqlDbType.VarChar);
            objSqlCommand.Parameters["@adsubcategory"].Value = adsubcategory;

            objSqlDataAdapter.SelectCommand = objSqlCommand;
            objSqlDataAdapter.Fill(objDataSet);
            return objDataSet;
        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            clscon.CloseConnection(ref objSqlConnection);
        }
    }

    protected void drpsubcat_SelectedIndexChanged(object sender, EventArgs e)
    {
        string subcategory = drpsubcat.SelectedValue;
        DataSet ds;
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            ds = advsubsubcategory(subcategory);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "advsubsubcategory_advsubsubcategory_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { subcategory };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        else
        {
            ds = advsubsubcategory1(subcategory);
        }

        if (subcategory != "0")
        {
            int i;
            ListItem li;
            li = new ListItem();
            drpsubsubcat.Items.Clear();
            li.Text = "--  Select Sub Sub Category --";
            li.Value = "0";
            li.Selected = true;
            drpsubsubcat.Items.Add(li);


            if (ds.Tables.Count > 0)
            {
                for (i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    ListItem li1;
                    li1 = new ListItem();
                    li1.Value = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                    li1.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                    drpsubsubcat.Items.Add(li1);
                }
            }







        }
        else
        {
            ListItem li1;
            li1 = new ListItem();
            drpsubsubcat.Items.Clear();
            li1.Text = "--  Select Sub Sub Category --";
            li1.Value = "0";
            li1.Selected = true;
            drpsubsubcat.Items.Add(li1);

        }
        if (drpsubsubcat.Items.Count > 0)
            drpsubsubcat.Enabled = true;
        else
            drpsubsubcat.Enabled = false;
    }
    protected void drpsubcatdest_SelectedIndexChanged(object sender, EventArgs e)
    {
        string subcategory = drpsubcatdest.SelectedValue;
        DataSet ds;
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            ds = advsubsubcategory(subcategory);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "advsubsubcategory_advsubsubcategory_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { subcategory };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        else
        {
            ds = advsubsubcategory1(subcategory);
        }


        if (subcategory != "0")
        {
            int i;
            ListItem li;
            li = new ListItem();
            drpsubsubcatdest.Items.Clear();
            li.Text = "--  Select Sub Sub Category --";
            li.Value = "0";
            li.Selected = true;
            drpsubsubcatdest.Items.Add(li);


            if (ds.Tables.Count > 0)
            {
                for (i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    ListItem li1;
                    li1 = new ListItem();
                    li1.Value = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                    li1.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                    drpsubsubcatdest.Items.Add(li1);
                }
            }







        }
        else
        {
            ListItem li1;
            li1 = new ListItem();
            drpsubsubcatdest.Items.Clear();
            li1.Text = "--  Select Sub Sub Category --";
            li1.Value = "0";
            li1.Selected = true;
            drpsubsubcatdest.Items.Add(li1);

        }
        if (drpsubsubcatdest.Items.Count > 0)
            drpsubsubcatdest.Enabled = true;
        else
            drpsubsubcatdest.Enabled = false;
    }
    protected void btngo_Click(object sender, EventArgs e)
    {
       // DataSet objDataSet = new DataSet();
        string package = "";
        for (int x = 0; x < ListBox1.Items.Count; x++)
        {
            if (ListBox1.Items[x].Selected == true)
            {
                if (package == "")
                    package = ListBox1.Items[x].Value;
                else
                    package = package + "," + ListBox1.Items[x].Value;
            }
        }

        for (int i = 0; i < drpcatdest.Items.Count; i++)
        {
            if (drpcatdest.Items[i].Selected== true)
            {
                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                {
                    SqlConnection objSqlConnection;
                    SqlCommand objSqlCommand;
                    NewAdbooking.Classes.connection clscon = new NewAdbooking.Classes.connection();
                    objSqlConnection = clscon.GetConnection();
                    SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();

                    /* try
                     {
                         objSqlConnection.Open();
                         objSqlCommand = clscon.GetCommand("websp_copyRate", ref objSqlConnection);
                         objSqlCommand.CommandType = CommandType.StoredProcedure;
                         objSqlCommand.Parameters.Add("@cat", SqlDbType.VarChar);
                         objSqlCommand.Parameters["@cat"].Value = drpcat.SelectedValue;

                         objSqlCommand.Parameters.Add("@subcat", SqlDbType.VarChar);
                         objSqlCommand.Parameters["@subcat"].Value = drpsubcat.SelectedValue;

                         objSqlCommand.Parameters.Add("@subsubcat", SqlDbType.VarChar);
                         objSqlCommand.Parameters["@subsubcat"].Value = drpsubsubcat.SelectedValue;

                         objSqlCommand.Parameters.Add("@catdest", SqlDbType.VarChar);
                         objSqlCommand.Parameters["@catdest"].Value = drpcatdest.SelectedValue;

                         objSqlCommand.Parameters.Add("@subcatdest", SqlDbType.VarChar);
                         objSqlCommand.Parameters["@subcatdest"].Value = drpsubcatdest.SelectedValue;

                         objSqlCommand.Parameters.Add("@subsubcatdest", SqlDbType.VarChar);
                         objSqlCommand.Parameters["@subsubcatdest"].Value = drpsubsubcatdest.SelectedValue;

                         objSqlCommand.Parameters.Add("@fromdate", SqlDbType.VarChar);
                         objSqlCommand.Parameters["@fromdate"].Value = txtfromdate.Text;

                         objSqlCommand.Parameters.Add("@todate", SqlDbType.VarChar);
                         objSqlCommand.Parameters["@todate"].Value = txttodate.Text;

                         objSqlCommand.Parameters.Add("@dateformat", SqlDbType.VarChar);
                         objSqlCommand.Parameters["@dateformat"].Value = hiddendateformat.Value;

                         objSqlCommand.Parameters.Add("@uom", SqlDbType.VarChar);
                         objSqlCommand.Parameters["@uom"].Value = drpuom.SelectedValue;

                         objSqlCommand.Parameters.Add("@uomdest", SqlDbType.VarChar);
                         objSqlCommand.Parameters["@uomdest"].Value = drpdestuom.SelectedValue;

                         objSqlCommand.ExecuteNonQuery();
                         ScriptManager.RegisterClientScriptBlock(this, typeof(copyRate), "aa", "msg();", true);
                         //Response.Write("<script language=javascript>alert('Rate Copied Successfully.');</script>");
                         //objSqlDataAdapter.SelectCommand = objSqlCommand;
                         //objSqlDataAdapter.Fill(objDataSet);
                         //return objDataSet;
                     }
                     catch (Exception ex)
                     {
                         throw (ex);
                     }
                     finally
                     {
                         clscon.CloseConnection(ref objSqlConnection);
                     }*/
                    try
                    {
                        objSqlConnection.Open();
                        objSqlCommand = clscon.GetCommand("websp_copyratenew", ref objSqlConnection);
                        objSqlCommand.CommandType = CommandType.StoredProcedure;

                        objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                        objSqlCommand.Parameters["@compcode"].Value = Session["compcode"].ToString();


                        objSqlCommand.Parameters.Add("@adtyp", SqlDbType.VarChar);
                        objSqlCommand.Parameters["@adtyp"].Value = drpadtype.SelectedValue;



                        objSqlCommand.Parameters.Add("@fromdate", SqlDbType.VarChar);
                        if (txtfromdate.Text == "" || txtfromdate.Text == null)
                        {
                            objSqlCommand.Parameters["@fromdate"].Value = System.DBNull.Value;
                        }
                        else
                        {
                            string from_dat = txtfromdate.Text;
                            if (hiddendateformat.Value == "dd/mm/yyyy")
                            {
                                string[] arr = from_dat.Split('/');
                                string dd = arr[0];
                                string mm = arr[1];
                                string yy = arr[2];
                                from_dat = mm + "/" + dd + "/" + yy;
                            }
                            else if (hiddendateformat.Value == "yyyy/mm/dd")
                            {
                                string[] arr = from_dat.Split('/');
                                string dd = arr[2];
                                string mm = arr[1];
                                string yy = arr[0];
                                from_dat = mm + "/" + dd + "/" + yy;
                            }
                            objSqlCommand.Parameters["@fromdate"].Value = from_dat;
                        }

                        objSqlCommand.Parameters.Add("@todate", SqlDbType.VarChar);
                        if (txttodate.Text == "" || txttodate.Text == null)
                        {
                            objSqlCommand.Parameters["@todate"].Value = System.DBNull.Value;
                        }
                        else
                        {
                            string to_dat = txttodate.Text;
                            if (hiddendateformat.Value == "dd/mm/yyyy")
                            {
                                string[] arr = to_dat.Split('/');
                                string dd = arr[0];
                                string mm = arr[1];
                                string yy = arr[2];
                                to_dat = mm + "/" + dd + "/" + yy;
                            }
                            else if (hiddendateformat.Value == "yyyy/mm/dd")
                            {
                                string[] arr = to_dat.Split('/');
                                string dd = arr[2];
                                string mm = arr[1];
                                string yy = arr[0];
                                to_dat = mm + "/" + dd + "/" + yy;
                            }
                            objSqlCommand.Parameters["@todate"].Value = to_dat;
                        }

                        objSqlCommand.Parameters.Add("@dateformat", SqlDbType.VarChar);
                        objSqlCommand.Parameters["@dateformat"].Value = hiddendateformat.Value;

                        objSqlCommand.Parameters.Add("@uomsource", SqlDbType.VarChar);
                        if (drpuom.SelectedValue == "0")
                        {
                            objSqlCommand.Parameters["@uomsource"].Value = drpuom.SelectedValue;
                        }
                        else
                        {
                            objSqlCommand.Parameters["@uomsource"].Value = drpuom.SelectedValue;
                        }

                        objSqlCommand.Parameters.Add("@uomdesc", SqlDbType.VarChar);
                        if (drpdestuom.SelectedValue == "0")
                        {
                            objSqlCommand.Parameters["@uomdesc"].Value =System.DBNull.Value;
                        }
                        else
                        {
                            objSqlCommand.Parameters["@uomdesc"].Value = drpdestuom.SelectedValue;
                        }

                        objSqlCommand.Parameters.Add("@adcatsource", SqlDbType.VarChar);
                        if (drpcat.SelectedValue == "0" || drpcat.SelectedValue=="")
                        {
                            objSqlCommand.Parameters["@adcatsource"].Value =System.DBNull.Value;
                        }
                        else
                        {
                            objSqlCommand.Parameters["@adcatsource"].Value = drpcat.SelectedValue;
                        }

                        objSqlCommand.Parameters.Add("@adcatdesc", SqlDbType.VarChar);
                  
                        objSqlCommand.Parameters["@adcatdesc"].Value = drpcatdest.Items[i].Value;

                        objSqlCommand.Parameters.Add("@color", SqlDbType.VarChar);
                        if (drpcolor.SelectedValue == "0" || drpcolor.SelectedValue == "")
                        {

                            objSqlCommand.Parameters["@color"].Value = System.DBNull.Value;
                        }
                        else
                        {
                            objSqlCommand.Parameters["@color"].Value = drpcolor.SelectedValue;
                        }

                        objSqlCommand.Parameters.Add("@colorcop", SqlDbType.VarChar);

                        if (drpcolorcop.SelectedValue == "0" || drpcolorcop.SelectedValue=="")
                        {
                            objSqlCommand.Parameters["@colorcop"].Value =System.DBNull.Value;
                        }
                        else
                        {
                            objSqlCommand.Parameters["@colorcop"].Value = drpcolorcop.SelectedValue;
                        }

                        objSqlCommand.Parameters.Add("@percentage", SqlDbType.VarChar);
                        if (txtpercentage.Text == "" || txtpercentage.Text == null)
                        {
                            objSqlCommand.Parameters["@percentage"].Value = System.DBNull.Value;
                        }
                        else
                        {
                            objSqlCommand.Parameters["@percentage"].Value = txtpercentage.Text;
                        }



                        objSqlCommand.Parameters.Add("@pratecode", SqlDbType.VarChar);
                        if (txtRatecode.SelectedValue == "" || txtRatecode.SelectedValue == null)
                        {
                            objSqlCommand.Parameters["@pratecode"].Value = System.DBNull.Value;
                        }
                        else
                        {
                            objSqlCommand.Parameters["@pratecode"].Value = txtRatecode.SelectedValue;
                        }


                        objSqlCommand.Parameters.Add("@psourcerate", SqlDbType.VarChar);
                        if (drpratecode.SelectedValue == "" || drpratecode.SelectedValue == null)
                        {
                            objSqlCommand.Parameters["@psourcerate"].Value = System.DBNull.Value;
                        }
                        else
                        {
                            objSqlCommand.Parameters["@psourcerate"].Value = drpratecode.SelectedValue;
                        }



                        objSqlCommand.Parameters.Add("@p_package_source", SqlDbType.VarChar);
                        if (listpackage.SelectedValue == "" || listpackage.SelectedValue == null)
                        {
                            objSqlCommand.Parameters["@p_package_source"].Value = System.DBNull.Value;
                        }
                        else
                        {
                            objSqlCommand.Parameters["@p_package_source"].Value = listpackage.SelectedValue;
                        }




                        objSqlCommand.Parameters.Add("@p_package_dest", SqlDbType.VarChar);
                        if (package == "" || package == null)
                        {
                            objSqlCommand.Parameters["@p_package_dest"].Value = System.DBNull.Value;
                        }
                        else
                        {
                            objSqlCommand.Parameters["@p_package_dest"].Value = package;
                        }

                        objSqlCommand.Parameters.Add("@adsubcatsource", SqlDbType.VarChar);
                        if (drpsubcat.SelectedValue == "0" || drpsubcat.SelectedValue=="")
                        {
                            objSqlCommand.Parameters["@adsubcatsource"].Value = System.DBNull.Value;
                        }
                        else
                        {
                                objSqlCommand.Parameters["@adsubcatsource"].Value = drpsubcat.SelectedValue;
                        }
                          
                    

                        objSqlCommand.Parameters.Add("@adsubsubcatsource", SqlDbType.VarChar);
                        if (drpsubsubcat.SelectedValue == "0" || drpsubsubcat.SelectedValue=="")
                        {
                            objSqlCommand.Parameters["@adsubsubcatsource"].Value = System.DBNull.Value;
                        }
                        else
                        {
                            objSqlCommand.Parameters["@adsubsubcatsource"].Value = drpsubsubcat.SelectedValue;
                        }

                       objSqlCommand.Parameters.Add("@adsubcatdesc", SqlDbType.VarChar);
                       if (drpsubcatdest.SelectedValue == "0" || drpsubcatdest.SelectedValue=="")
                       {
                           objSqlCommand.Parameters["@adsubcatdesc"].Value = System.DBNull.Value;
                       }
                        else
                       {
                           objSqlCommand.Parameters["@adsubcatdesc"].Value = drpsubcatdest.SelectedValue;
                    }


                       objSqlCommand.Parameters.Add("@adsubsubcatdesc", SqlDbType.VarChar);
                       if (drpsubsubcatdest.SelectedValue == "0" || drpsubsubcatdest.SelectedValue=="")
                       {
                           objSqlCommand.Parameters["@adsubsubcatdesc"].Value = System.DBNull.Value;
                       }
                       else
                       {
                           objSqlCommand.Parameters["@adsubsubcatdesc"].Value = drpsubsubcatdest.SelectedValue;
                       }

                        objSqlCommand.ExecuteNonQuery();
                        ScriptManager.RegisterClientScriptBlock(this, typeof(copyRate), "aa", "msg();", true);
                        //Response.Write("<script language=javascript>alert('Rate Copied Successfully.');</script>");
                        //objSqlDataAdapter.SelectCommand = objSqlCommand;
                        //objSqlDataAdapter.Fill(objDataSet);
                        //return objDataSet;
                    }
                    catch (Exception ex)
                    {
                        throw (ex);
                    }
                    finally
                    {
                        clscon.CloseConnection(ref objSqlConnection);
                    }
                }
                else
                {
                    OracleConnection objOracleConnection;
                    OracleCommand objOraclecommand;
                    NewAdbooking.classesoracle.orclconnection clscon = new NewAdbooking.classesoracle.orclconnection();
                    objOracleConnection = clscon.GetConnection();
                    OracleDataAdapter objOrclDataAdapter = new OracleDataAdapter();
                    try
                    {
                        objOracleConnection.Open();
                        objOraclecommand = clscon.GetCommand("websp_copyRateNew", ref objOracleConnection);
                        objOraclecommand.CommandType = CommandType.StoredProcedure;


                        OracleParameter prm0 = new OracleParameter("adtyp", OracleType.VarChar);
                        prm0.Direction = ParameterDirection.Input;
                        prm0.Value = drpadtype.SelectedValue;
                        objOraclecommand.Parameters.Add(prm0);

                        OracleParameter prm1 = new OracleParameter("adcatsource", OracleType.VarChar);
                        prm1.Direction = ParameterDirection.Input;
                        prm1.Value = drpcat.SelectedValue;
                        objOraclecommand.Parameters.Add(prm1);

                        OracleParameter prm2 = new OracleParameter("adcatdesc", OracleType.VarChar);
                        prm2.Direction = ParameterDirection.Input;
                        prm2.Value = drpcatdest.Items[i].Value;
                        objOraclecommand.Parameters.Add(prm2);

                        OracleParameter prm1a = new OracleParameter("adsubcatsource", OracleType.VarChar);
                        prm1a.Direction = ParameterDirection.Input;
                        prm1a.Value = drpsubcat.SelectedValue;
                        objOraclecommand.Parameters.Add(prm1a);

                        OracleParameter prm2a = new OracleParameter("adsubcatdesc", OracleType.VarChar);
                        prm2a.Direction = ParameterDirection.Input;
                        prm2a.Value = drpsubcatdest.SelectedValue;
                        objOraclecommand.Parameters.Add(prm2a);

                        OracleParameter prm1aa = new OracleParameter("adsubsubcatsource", OracleType.VarChar);
                        prm1aa.Direction = ParameterDirection.Input;
                        prm1aa.Value = drpsubsubcat.SelectedValue;
                        objOraclecommand.Parameters.Add(prm1aa);

                        OracleParameter prm2aa = new OracleParameter("adsubsubcatdesc", OracleType.VarChar);
                        prm2aa.Direction = ParameterDirection.Input;
                        prm2aa.Value = drpsubsubcatdest.SelectedValue;
                        objOraclecommand.Parameters.Add(prm2aa);

                        OracleParameter prm3 = new OracleParameter("compcode", OracleType.VarChar);
                        prm3.Direction = ParameterDirection.Input;
                        prm3.Value = Session["compcode"].ToString();
                        objOraclecommand.Parameters.Add(prm3);

                        OracleParameter prm4 = new OracleParameter("fromdate", OracleType.VarChar);
                        prm4.Direction = ParameterDirection.Input;
                        string validfromdate1 = txtfromdate.Text;
                        if (hiddendateformat.Value == "dd/mm/yyyy")
                        {
                            string[] arr = validfromdate1.Split('/');
                            string dd = arr[0];
                            string mm = arr[1];
                            string yy = arr[2];
                            validfromdate1 = mm + "/" + dd + "/" + yy;


                        }
                        else
                            if (hiddendateformat.Value == "mm/dd/yyyy")
                            {
                                string[] arr = validfromdate1.Split('/');
                                string dd = arr[1];
                                string mm = arr[0];
                                string yy = arr[2];
                                validfromdate1 = mm + "/" + dd + "/" + yy;

                            }

                            else
                                if (hiddendateformat.Value == "yyyy/mm/dd")
                                {
                                    string[] arr = validfromdate1.Split('/');
                                    string dd = arr[2];
                                    string mm = arr[1];
                                    string yy = arr[0];
                                    validfromdate1 = mm + "/" + dd + "/" + yy;
                                }
                        prm4.Value = Convert.ToDateTime(validfromdate1).ToString("dd-MMMM-yyyy");
                        objOraclecommand.Parameters.Add(prm4);

                        OracleParameter prm5 = new OracleParameter("todate", OracleType.VarChar);
                        prm5.Direction = ParameterDirection.Input;
                        string validfromtodate1 = txttodate.Text;
                        if (hiddendateformat.Value == "dd/mm/yyyy")
                        {
                            string[] arr = validfromtodate1.Split('/');
                            string dd = arr[0];
                            string mm = arr[1];
                            string yy = arr[2];
                            validfromtodate1 = mm + "/" + dd + "/" + yy;


                        }
                        else
                            if (hiddendateformat.Value == "mm/dd/yyyy")
                            {
                                string[] arr = validfromtodate1.Split('/');
                                string dd = arr[1];
                                string mm = arr[0];
                                string yy = arr[2];
                                validfromtodate1 = mm + "/" + dd + "/" + yy;

                            }

                            else
                                if (hiddendateformat.Value == "yyyy/mm/dd")
                                {
                                    string[] arr = validfromtodate1.Split('/');
                                    string dd = arr[2];
                                    string mm = arr[1];
                                    string yy = arr[0];
                                    validfromtodate1 = mm + "/" + dd + "/" + yy;
                                }
                        prm5.Value = Convert.ToDateTime(validfromtodate1).ToString("dd-MMMM-yyyy");
                        objOraclecommand.Parameters.Add(prm5);

                        OracleParameter prm6 = new OracleParameter("dateformat", OracleType.VarChar);
                        prm6.Direction = ParameterDirection.Input;
                        prm6.Value = hiddendateformat.Value;
                        objOraclecommand.Parameters.Add(prm6);

                        OracleParameter prm6a = new OracleParameter("uomsource", OracleType.VarChar);
                        prm6a.Direction = ParameterDirection.Input;
                        prm6a.Value = drpuom.SelectedValue;
                        objOraclecommand.Parameters.Add(prm6a);


                        OracleParameter prm6b = new OracleParameter("uomdesc", OracleType.VarChar);
                        prm6b.Direction = ParameterDirection.Input;
                        prm6b.Value = drpdestuom.SelectedValue;
                        objOraclecommand.Parameters.Add(prm6b);

                        OracleParameter prm7 = new OracleParameter("color", OracleType.VarChar);
                        prm7.Direction = ParameterDirection.Input;
                        prm7.Value = drpcolor.SelectedValue;
                        objOraclecommand.Parameters.Add(prm7);


                        OracleParameter prm8 = new OracleParameter("colorcop", OracleType.VarChar);
                        prm8.Direction = ParameterDirection.Input;
                        prm8.Value = drpcolorcop.SelectedValue;
                        objOraclecommand.Parameters.Add(prm8);

                        OracleParameter prm9 = new OracleParameter("percentage", OracleType.VarChar);
                        prm9.Direction = ParameterDirection.Input;
                        if (txtpercentage.Text == "" || txtpercentage.Text == null)
                        {
                            prm9.Value = System.DBNull.Value;
                        }
                        prm9.Value = txtpercentage.Text;
                        objOraclecommand.Parameters.Add(prm9);

                        OracleParameter prm10 = new OracleParameter("pratecode", OracleType.VarChar);
                        prm10.Direction = ParameterDirection.Input;
                        if (txtRatecode.SelectedValue == "" || txtRatecode.SelectedValue == null)
                        {
                            prm10.Value = System.DBNull.Value;
                        }
                        else
                        {
                            prm10.Value = txtRatecode.SelectedValue; 
                        }
                        objOraclecommand.Parameters.Add(prm10);

                        OracleParameter prm11 = new OracleParameter("psourcerate", OracleType.VarChar);
                        prm11.Direction = ParameterDirection.Input;
                        if (drpratecode.SelectedValue == "" || drpratecode.SelectedValue == null || drpratecode.SelectedValue == "0")
                        {
                            prm11.Value = System.DBNull.Value;
                        }
                        else
                        {
                            prm11.Value = drpratecode.SelectedValue; 
                        }
                        objOraclecommand.Parameters.Add(prm11);

                        OracleParameter prm12 = new OracleParameter("p_package_source", OracleType.VarChar);
                        prm11.Direction = ParameterDirection.Input;
                        if (listpackage.SelectedValue == "" || listpackage.SelectedValue == null)
                        {
                            prm12.Value = System.DBNull.Value;
                        }
                        else
                        {
                            prm12.Value = listpackage.SelectedValue;
                        }
                        objOraclecommand.Parameters.Add(prm12);

                        OracleParameter prm13 = new OracleParameter("p_package_dest", OracleType.VarChar);
                        prm13.Direction = ParameterDirection.Input;
                        if (package == "" || package == null)
                        {
                            prm13.Value = System.DBNull.Value;
                        }
                        else
                        {
                            prm13.Value = package;
                        }
                        objOraclecommand.Parameters.Add(prm13);



                        //objOraclecommand.Parameters.Add("p_recordsetmis", OracleType.Cursor);
                        //objOraclecommand.Parameters["p_recordsetmis"].Direction = ParameterDirection.Output;
                        objOraclecommand.ExecuteNonQuery();
                        // objOrclDataAdapter.SelectCommand = objOraclecommand;
                        // objOrclDataAdapter.Fill(objDataSet);

                    }
                    catch (Exception ex)
                    {
                        throw (ex);
                    }
                    finally
                    {
                        clscon.CloseConnection(ref objOracleConnection);
                    }
                }
            }
        }
      
        ScriptManager.RegisterClientScriptBlock(this, typeof(copyRate),"zz1", "alert('copied successfully');", true);
    }
    protected void drpadtype_SelectedIndexChanged(object sender, EventArgs e)
    {
        advcat(Session["compcode"].ToString(), drpadtype.SelectedValue);
        binduom(Session["compcode"].ToString(), drpadtype.SelectedValue);
        bindpackage_A_detail(Session["compcode"].ToString(), drpadtype.SelectedValue,"");
    }
    public void binduom(string compcode, string adtype)
    {
        //NewAdbooking.Classes.Contract binduom = new NewAdbooking.Classes.Contract();
        //DataSet ds = new DataSet();
        //ds = binduom.uombind(Session["compcode"].ToString(), Session["userid"].ToString());
        string value = "";
        if (drpadtype.SelectedItem.Text == "CLASSIFIED")
        {
            value = "1";

        }
        else
        {
            value = "0";
        }
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.RateMaster binduom = new NewAdbooking.Classes.RateMaster();
            ds = binduom.uombind(compcode, "", value);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "binduomforrate_binduomforrate_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { compcode, "", value };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        else
        {
            NewAdbooking.classesoracle.RateMaster binduom = new NewAdbooking.classesoracle.RateMaster();
            ds = binduom.uombind(Session["compcode"].ToString(), "", value);
        }
        drpuom.Items.Clear();
        drpdestuom.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "Select UOM";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
       // li1.Selected = true;
        drpuom.Items.Add(li1);
        drpdestuom.Items.Add(li1);
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ListItem li;
                li = new ListItem();
                li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                drpuom.Items.Add(li);
                drpdestuom.Items.Add(li);
            }

        }

    }

  
    public void bindpackage_A_detail(string compcode, string adtype, string channel)
    {

        DataSet ds = new DataSet();

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {


            NewAdbooking.Classes.Contract bindopackage = new NewAdbooking.Classes.Contract();

            ds = bindopackage.TV_packagebind(compcode, adtype, channel);
        }

        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.Contract bindopackage = new NewAdbooking.classesoracle.Contract();

                ds = bindopackage.TV_packagebind(compcode, adtype, channel);

            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
            {
                string procedureName = "TV_packagebind";
                NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                string[] parameterValueArray = { compcode, adtype, channel };
                ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
            }

        listpackage.Items.Clear();
        ListBox1.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "Select Package";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        // li1.Selected = true;
        listpackage.Items.Add(li1);
        ListBox1.Items.Add(li1);
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ListItem li;
                li = new ListItem();
                li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                listpackage.Items.Add(li);
                ListBox1.Items.Add(li);
            }

        }
       
    }

    //------------------------------------- for oracle ----------------------------------------//

    private DataSet advcategory1(string compcode, string adtype)
    {


        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        NewAdbooking.classesoracle.orclconnection clscon = new NewAdbooking.classesoracle.orclconnection();
        objOracleConnection = clscon.GetConnection();
        OracleDataAdapter objOrclDataAdapter = new OracleDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objOracleConnection.Open();
            objOraclecommand = clscon.GetCommand("adcategory.adcategory_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm1 = new OracleParameter("Adtype", OracleType.VarChar);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = adtype;
            objOraclecommand.Parameters.Add(prm1);

            OracleParameter prm2 = new OracleParameter("company_code", OracleType.VarChar);
            prm2.Direction = ParameterDirection.Input;
            prm2.Value = compcode;
            objOraclecommand.Parameters.Add(prm2);

            objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
            objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

            objOrclDataAdapter.SelectCommand = objOraclecommand;
            objOrclDataAdapter.Fill(objDataSet);
            return objDataSet;
        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            clscon.CloseConnection(ref objOracleConnection);
        }
    }

    private DataSet ratecodebind1(string compcode)
    {


        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        NewAdbooking.classesoracle.orclconnection clscon = new NewAdbooking.classesoracle.orclconnection();
        objOracleConnection = clscon.GetConnection();
        OracleDataAdapter objOrclDataAdapter = new OracleDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objOracleConnection.Open();
            objOraclecommand = clscon.GetCommand("add_bind_ratecode", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;



            OracleParameter prm2 = new OracleParameter("pcompcode", OracleType.VarChar);
            prm2.Direction = ParameterDirection.Input;
            prm2.Value = compcode;
            objOraclecommand.Parameters.Add(prm2);

            objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
            objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

            objOrclDataAdapter.SelectCommand = objOraclecommand;
            objOrclDataAdapter.Fill(objDataSet);
            return objDataSet;
        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            clscon.CloseConnection(ref objOracleConnection);
        }
    }

    public DataSet advsubcategory1(string compcode, string adcategory)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        NewAdbooking.classesoracle.orclconnection clscon = new NewAdbooking.classesoracle.orclconnection();
        objOracleConnection = clscon.GetConnection();
        OracleDataAdapter objOrclDataAdapter = new OracleDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objOracleConnection.Open();
            objOraclecommand = clscon.GetCommand("advsubcategory.advsubcategory_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm1 = new OracleParameter("adcategory", OracleType.VarChar);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = adcategory;
            objOraclecommand.Parameters.Add(prm1);

            OracleParameter prm2 = new OracleParameter("company_code", OracleType.VarChar);
            prm2.Direction = ParameterDirection.Input;
            prm2.Value = compcode;
            objOraclecommand.Parameters.Add(prm2);

            objOraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
            objOraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;

            objOrclDataAdapter.SelectCommand = objOraclecommand;
            objOrclDataAdapter.Fill(objDataSet);
            return objDataSet;
        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            clscon.CloseConnection(ref objOracleConnection);
        }
    }


    private DataSet advsubsubcategory1(string adsubcategory)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        NewAdbooking.classesoracle.orclconnection clscon = new NewAdbooking.classesoracle.orclconnection();
        objOracleConnection = clscon.GetConnection();
        OracleDataAdapter objOrclDataAdapter = new OracleDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objOracleConnection.Open();
            objOraclecommand = clscon.GetCommand("advsubsubcategory.advsubsubcategory_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;


            OracleParameter prm1 = new OracleParameter("adsubcategory", OracleType.VarChar);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = adsubcategory;
            objOraclecommand.Parameters.Add(prm1);

            objOraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
            objOraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;

            objOrclDataAdapter.SelectCommand = objOraclecommand;
            objOrclDataAdapter.Fill(objDataSet);
            return objDataSet;
        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            clscon.CloseConnection(ref objOracleConnection);
        }
    }
}
