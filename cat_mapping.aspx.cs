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

public partial class cat_mapping : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["compcode"] == null)
        {
            Response.Write("<script>alert(\"Your session has been expired\");window.close();</script>");
            return;

        }
        //////////this is to bind the buttons with xml*/

        DataSet objDataSetbu = new DataSet();
        // Read in the XML file
        objDataSetbu.ReadXml(Server.MapPath("XML/button.xml"));
        btnNew.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[0].ToString();
        btnSave.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[1].ToString();
        btnModify.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[2].ToString();
        btnQuery.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[3].ToString();
        btnExecute.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[4].ToString();
        btnCancel.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[5].ToString();
        btnfirst.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[6].ToString();
        btnprevious.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[7].ToString();
        btnnext.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[8].ToString();
        btnlast.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[9].ToString();
        btnDelete.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[10].ToString();
        btnExit.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[11].ToString();

        ///////////////////////////////////////////////////////////////

        btnNew.Enabled = true;

        ////////////this is for the label

        DataSet objDataSet = new DataSet();
        // Read in the XML file
        objDataSet.ReadXml(Server.MapPath("XML/cat_map.xml"));

        lb1.Text = objDataSet.Tables[0].Rows[0].ItemArray[11].ToString();
        lb2.Text = objDataSet.Tables[0].Rows[0].ItemArray[12].ToString();
        lb3.Text = objDataSet.Tables[0].Rows[0].ItemArray[0].ToString();
        lb4.Text = objDataSet.Tables[0].Rows[0].ItemArray[1].ToString();
        lb5.Text = objDataSet.Tables[0].Rows[0].ItemArray[2].ToString();
        lb6.Text = objDataSet.Tables[0].Rows[0].ItemArray[3].ToString();
        lb7.Text = objDataSet.Tables[0].Rows[0].ItemArray[4].ToString();
        lb8.Text = objDataSet.Tables[0].Rows[0].ItemArray[10].ToString();
        lb9.Text = objDataSet.Tables[0].Rows[0].ItemArray[13].ToString();
        lb10.Text = objDataSet.Tables[0].Rows[0].ItemArray[14].ToString();
        lb11.Text = objDataSet.Tables[0].Rows[0].ItemArray[5].ToString();
        lb12.Text = objDataSet.Tables[0].Rows[0].ItemArray[6].ToString();
        lb13.Text = objDataSet.Tables[0].Rows[0].ItemArray[7].ToString();
        lb14.Text = objDataSet.Tables[0].Rows[0].ItemArray[8].ToString();
        lb15.Text = objDataSet.Tables[0].Rows[0].ItemArray[9].ToString();

        Ajax.Utility.RegisterTypeForAjax(typeof(cat_mapping));
        hiddencompcode.Value = Session["compcode"].ToString();

        if (!Page.IsPostBack)
        {
            bindregion();
            bindvariable();
            bindcategory();
            bindedition();
            drpsoucat1.Attributes.Add("onchange", "javascript:return fillcat2('drpsoucat1');");
            drpdescat1.Attributes.Add("onchange", "javascript:return fillcat2('drpdescat1');");
            drpsoucat2.Attributes.Add("onchange", "javascript:return fillcat3('drpsoucat2');");
            drpdescat2.Attributes.Add("onchange", "javascript:return fillcat3('drpdescat2');");
            drpsoucat3.Attributes.Add("onchange", "javascript:return fillcat4('drpsoucat3');");
            drpdescat3.Attributes.Add("onchange", "javascript:return fillcat4('drpdescat3');");
            drpsoucat4.Attributes.Add("onchange", "javascript:return fillcat5('drpsoucat4');");
            drpdescat4.Attributes.Add("onchange", "javascript:return fillcat5('drpdescat4');");
            btnNew.Attributes.Add("onclick", "javascript:return newcatmap();");
            btnSave.Attributes.Add("onclick", "javascript:return savecatmap();");
            btnCancel.Attributes.Add("onclick", "javascript:return cancelcatmap('cat_mapping');");
            btnModify.Attributes.Add("onclick", "javascript:return modifycatmap();");
            btnQuery.Attributes.Add("onclick", "javascript:return querycatmap();");
            btnExecute.Attributes.Add("onclick", "javascript:return executecatmap();");
            btnlast.Attributes.Add("onclick", "javascript:return lastcatmap();");
            btnfirst.Attributes.Add("onclick", "javascript:return firstcatmap();");
            btnnext.Attributes.Add("onclick", "javascript:return nextcatmap();");
            btnprevious.Attributes.Add("onclick", "javascript:return prevcatmap();");
            btnDelete.Attributes.Add("onclick", "javascript:return deletecatmap();");
            btnExit.Attributes.Add("onclick", "javascript:return exitcatmap();");

        }










    }

    public void bindedition()
    {
        DataSet ds = new DataSet();
        if(ConfigurationSettings.AppSettings ["ConnectionType"].ToString ()=="sql")
        {
        NewAdbooking.Classes.Adsize bindedition = new NewAdbooking.Classes.Adsize();       
        ds = bindedition.editionbind(Session["compcode"].ToString(), Session["userid"].ToString());
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.Adsize bindedition = new NewAdbooking.classesoracle.Adsize();
                ds = bindedition.editionbind(Session["compcode"].ToString(), Session["userid"].ToString());

            }
            else
            {
                NewAdbooking.classmysql.Adsize bindedition = new NewAdbooking.classmysql.Adsize();
                ds = bindedition.editionbind(Session["compcode"].ToString(), Session["userid"].ToString());

            }

        ListItem li1;
        li1 = new ListItem();
        li1.Text = "--Select Edition--";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        drpdesedition.Items.Add(li1);
        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {

            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            drpdesedition.Items.Add(li);


        }

    }

    public void bindcategory()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster bind = new NewAdbooking.Classes.BookingMaster();
            ds = bind.advdatacategory(Session["compcode"].ToString(), "CL0");
        }

            else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.BookingMaster bind = new NewAdbooking.classesoracle.BookingMaster();
                ds = bind.advdatacategory(Session["compcode"].ToString(), "CL0");

            }
            else
            {
                NewAdbooking.classmysql.BookingMaster bind = new NewAdbooking.classmysql.BookingMaster();
                ds = bind.advdatacategory(Session["compcode"].ToString(), "CL0");
            }



        int i;
        ListItem li1;
        li1 = new ListItem();
        drpsoucat1.Items.Clear();
        drpdescat1.Items.Clear();
        li1.Text = "Select Ad Category";
        li1.Value = "0";
        li1.Selected = true;
        drpsoucat1.Items.Add(li1);
        drpdescat1.Items.Add(li1);

        if (ds.Tables.Count > 0)
        {
            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ListItem li;
                li = new ListItem();
                li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                //drpadcategory.Items.Add(li);
                drpsoucat1.Items.Add(li);
                drpdescat1.Items.Add(li);

            }
        }



    }

    public void bindvariable()
    {
        DataSet dset = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster variablename = new NewAdbooking.Classes.BookingMaster();

            dset = variablename.variable_name(Session["compcode"].ToString());
        }

        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.BookingMaster variablename = new NewAdbooking.classesoracle.BookingMaster();

                dset = variablename.variable_name(Session["compcode"].ToString());

            }
        else
        {
            NewAdbooking.classmysql.BookingMaster RegionName = new NewAdbooking.classmysql.BookingMaster();

            dset = RegionName.variable_name(Session["compcode"].ToString());
        }
        drpsouvariable.Items.Clear();
        drpdesvariable.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "-Select Variable-";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        drpsouvariable.Items.Add(li1);
        drpdesvariable.Items.Add(li1);

        if (dset.Tables[0].Rows.Count > 0)
        {
            for (i = 0; i < dset.Tables[0].Rows.Count; i++)
            {
                ListItem li;
                li = new ListItem();
                li.Text = dset.Tables[0].Rows[i].ItemArray[1].ToString();
                li.Value = dset.Tables[0].Rows[i].ItemArray[0].ToString();
                //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                //drpvarient.Items.Add(li);
                drpsouvariable.Items.Add(li);
                drpdesvariable.Items.Add(li);
            }

        }

    }

    public void bindregion()
    {

        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            NewAdbooking.Classes.CityMaster RegionName = new NewAdbooking.Classes.CityMaster();

            ds = RegionName.region(Session["compcode"].ToString(), Session["userid"].ToString());
        }
       

        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.CityMaster RegionName = new NewAdbooking.classesoracle.CityMaster();

            ds = RegionName.region(Session["compcode"].ToString(), Session["userid"].ToString());
        }
        else
        {
            NewAdbooking.classmysql.CityMaster RegionName = new NewAdbooking.classmysql.CityMaster();

            ds = RegionName.region(Session["compcode"].ToString(), Session["userid"].ToString());

        }
            
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "-Select Region-";
        li1.Value = "0";
        li1.Selected = true;
        drpsouregion.Items.Add(li1);
        drpdesregion.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            drpsouregion.Items.Add(li);
            drpdesregion.Items.Add(li);
        }


    }


    [Ajax.AjaxMethod]
    public DataSet getadsubcat(string compcode, string adcat)
    {

        DataSet da = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.CombinationMaster cls_comb = new NewAdbooking.Classes.CombinationMaster();
            da = cls_comb.advdatasubcatcat(compcode, adcat);
            
        }

        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.CombinationMaster cls_comb = new NewAdbooking.classesoracle.CombinationMaster();
                da = cls_comb.advdatasubcatcat(compcode, adcat);

            }
        else
        {
            NewAdbooking.classmysql.CombinationMaster cls_comb = new NewAdbooking.classmysql.CombinationMaster();

            da = cls_comb.advdatasubcatcat(compcode, adcat);
            
        }

        return da;
    }

    [Ajax.AjaxMethod]
    public DataSet bindadcat3(string adcat3, string compcode, string value)
    {
        DataSet dacat = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster getadcat3 = new NewAdbooking.Classes.BookingMaster();

            dacat = getadcat3.getvalfromadcat3(adcat3, compcode, value);
            
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.BookingMaster getadcat3 = new NewAdbooking.classesoracle.BookingMaster();

                dacat = getadcat3.getvalfromadcat3(adcat3, compcode, value);
            }
        else
        {
            NewAdbooking.classmysql.BookingMaster getadcat3 = new NewAdbooking.classmysql.BookingMaster();

            dacat = getadcat3.getvalfromadcat3(adcat3, compcode, value);
            

        }

        return dacat;

    }

    [Ajax.AjaxMethod]
    public DataSet chkcombination(string compcode,string sourceregion,string sourcevariable,string sourcecat1,string sourcecat2,string sourcecat3,string sourcecat4,string sourcecat5,string destedit,string destreg,string destvar,string destcat1, string destcat2,string destcat3,string destcat4,string destcat5)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {


            NewAdbooking.Classes.cat_map chkmap = new NewAdbooking.Classes.cat_map();
            ds = chkmap.mappingchk(compcode, sourceregion, sourcevariable, sourcecat1, sourcecat2, sourcecat3, sourcecat4, sourcecat5, destedit, destreg, destvar, destcat1, destcat2, destcat3, destcat4, destcat5);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.cat_map chkmap = new NewAdbooking.classesoracle.cat_map();
                ds = chkmap.mappingchk(compcode, sourceregion, sourcevariable, sourcecat1, sourcecat2, sourcecat3, sourcecat4, sourcecat5, destedit, destreg, destvar, destcat1, destcat2, destcat3, destcat4, destcat5);

            }
            else
            {
                NewAdbooking.classmysql.cat_map chkmap = new NewAdbooking.classmysql.cat_map();
                ds = chkmap.mappingchk(compcode, sourceregion, sourcevariable, sourcecat1, sourcecat2, sourcecat3, sourcecat4, sourcecat5, destedit, destreg, destvar, destcat1, destcat2, destcat3, destcat4, destcat5);

            }

        return ds;

    }

    [Ajax.AjaxMethod]
    public DataSet savemapping(string compcode, string sourceregion, string sourcevariable, string sourcecat1, string sourcecat2, string sourcecat3, string sourcecat4, string sourcecat5, string destedit, string destreg, string destvar, string destcat1, string destcat2, string destcat3, string destcat4, string destcat5)
    {
        DataSet ds = new DataSet();
        if(ConfigurationSettings .AppSettings ["ConnectionType"].ToString ()=="sql")
        {
        NewAdbooking.Classes.cat_map savemap = new NewAdbooking.Classes.cat_map();
        ds = savemap.mappingsave(compcode, sourceregion, sourcevariable, sourcecat1, sourcecat2, sourcecat3, sourcecat4, sourcecat5, destedit, destreg, destvar, destcat1, destcat2, destcat3, destcat4, destcat5);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.cat_map savemap = new NewAdbooking.classesoracle.cat_map();
                ds = savemap.mappingsave(compcode, sourceregion, sourcevariable, sourcecat1, sourcecat2, sourcecat3, sourcecat4, sourcecat5, destedit, destreg, destvar, destcat1, destcat2, destcat3, destcat4, destcat5);

            }
        else
            {
                NewAdbooking.classmysql.cat_map savemap = new NewAdbooking.classmysql.cat_map();
                ds = savemap.mappingsave(compcode, sourceregion, sourcevariable, sourcecat1, sourcecat2, sourcecat3, sourcecat4, sourcecat5, destedit, destreg, destvar, destcat1, destcat2, destcat3, destcat4, destcat5);

                
            }


        return ds;

    }

    [Ajax.AjaxMethod]
    public DataSet chkmapmodify(string compcode, string sourceregion, string sourcevariable, string sourcecat1, string sourcecat2, string sourcecat3, string sourcecat4, string sourcecat5, string destedit, string destreg, string destvar, string destcat1, string destcat2, string destcat3, string destcat4, string destcat5,string primary)
    {
        DataSet ds = new DataSet();
        if(ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
        NewAdbooking.Classes.cat_map chkmod = new NewAdbooking.Classes.cat_map();
        ds = chkmod.modifychk(compcode, sourceregion, sourcevariable, sourcecat1, sourcecat2, sourcecat3, sourcecat4, sourcecat5, destedit, destreg, destvar, destcat1, destcat2, destcat3, destcat4, destcat5,primary);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.cat_map chkmod = new NewAdbooking.classesoracle.cat_map();
                ds = chkmod.modifychk(compcode, sourceregion, sourcevariable, sourcecat1, sourcecat2, sourcecat3, sourcecat4, sourcecat5, destedit, destreg, destvar, destcat1, destcat2, destcat3, destcat4, destcat5, primary);

            }
        else
            {

                NewAdbooking.classmysql.cat_map chkmod = new NewAdbooking.classmysql.cat_map();
                ds = chkmod.modifychk(compcode, sourceregion, sourcevariable, sourcecat1, sourcecat2, sourcecat3, sourcecat4, sourcecat5, destedit, destreg, destvar, destcat1, destcat2, destcat3, destcat4, destcat5, primary);

                }

        return ds;

    }

    [Ajax.AjaxMethod]
    public DataSet modifymapping(string compcode, string sourceregion, string sourcevariable, string sourcecat1, string sourcecat2, string sourcecat3, string sourcecat4, string sourcecat5, string destedit, string destreg, string destvar, string destcat1, string destcat2, string destcat3, string destcat4, string destcat5,string primary)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.cat_map modifymap = new NewAdbooking.Classes.cat_map();
            ds = modifymap.mappingmodify(compcode, sourceregion, sourcevariable, sourcecat1, sourcecat2, sourcecat3, sourcecat4, sourcecat5, destedit, destreg, destvar, destcat1, destcat2, destcat3, destcat4, destcat5, primary);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                            NewAdbooking.classesoracle .cat_map modifymap = new NewAdbooking.classesoracle.cat_map();
            ds = modifymap.mappingmodify(compcode, sourceregion, sourcevariable, sourcecat1, sourcecat2, sourcecat3, sourcecat4, sourcecat5, destedit, destreg, destvar, destcat1, destcat2, destcat3, destcat4, destcat5, primary);

            }
            else
            {
                NewAdbooking.classmysql.cat_map modifymap = new NewAdbooking.classmysql.cat_map();
                ds = modifymap.mappingmodify(compcode, sourceregion, sourcevariable, sourcecat1, sourcecat2, sourcecat3, sourcecat4, sourcecat5, destedit, destreg, destvar, destcat1, destcat2, destcat3, destcat4, destcat5, primary);


            }

        return ds;

    }

    [Ajax.AjaxMethod]
    public DataSet executemapping(string compcode, string sourceregion, string sourcevariable, string sourcecat1, string sourcecat2, string sourcecat3, string sourcecat4, string sourcecat5, string destedit, string destreg, string destvar, string destcat1, string destcat2, string destcat3, string destcat4, string destcat5)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.cat_map chkexe = new NewAdbooking.Classes.cat_map();
            ds = chkexe.execute(compcode, sourceregion, sourcevariable, sourcecat1, sourcecat2, sourcecat3, sourcecat4, sourcecat5, destedit, destreg, destvar, destcat1, destcat2, destcat3, destcat4, destcat5);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                            NewAdbooking.classesoracle .cat_map chkexe = new NewAdbooking.classesoracle.cat_map();
            ds = chkexe.execute(compcode, sourceregion, sourcevariable, sourcecat1, sourcecat2, sourcecat3, sourcecat4, sourcecat5, destedit, destreg, destvar, destcat1, destcat2, destcat3, destcat4, destcat5);

            }
            else
            {
                NewAdbooking.classmysql.cat_map chkexe = new NewAdbooking.classmysql.cat_map();
                ds = chkexe.execute(compcode, sourceregion, sourcevariable, sourcecat1, sourcecat2, sourcecat3, sourcecat4, sourcecat5, destedit, destreg, destvar, destcat1, destcat2, destcat3, destcat4, destcat5);

            }

        return ds;

    }

    [Ajax.AjaxMethod]
    public DataSet deletecatmap(string primary, string compcode)
    {
        DataSet ds = new DataSet();
        if(ConfigurationSettings.AppSettings ["ConnectionType"].ToString ()=="sql")
        {
        

        NewAdbooking.Classes.cat_map chkdel = new NewAdbooking.Classes.cat_map();
        ds = chkdel.deletcatmap(primary, compcode);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.cat_map chkdel = new NewAdbooking.classesoracle.cat_map();
        ds = chkdel.deletcatmap(primary, compcode);

            }
            else
            {
                NewAdbooking.classmysql.cat_map chkdel = new NewAdbooking.classmysql.cat_map();
        ds = chkdel.deletcatmap(primary, compcode);

            }

        return ds;

    }


}
