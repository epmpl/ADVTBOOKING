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


public partial class ContractDetail : System.Web.UI.Page
{
    public static int numberDiv;
     int i = 0;
    string dealno, message, dealfordelete,compcode,userid,advtype,datefrom,dateto;
    static int saveormodify=0;
    string adtype;
    string con_agency, con_client, con_prod;
    static string nextadcategory, nextpublication, nextsupp, nextbooked, nextcolor, nextcardrate, nextdealrate, nextpremiumcode, nextcardprmum, nextdealpre, nextvolumebilled, nextvoldisc, nextvalfrom, nextvalto, nextuom, nexteditrion, nextconvertrate, nextcurrency, nexteditionaldisc, nextapproved, nextquantity, nextweight, nextdiscount, nextdeal_start, nextcomm_allow, nextdeal_incentive;
    /////this is for the temporary table
  
    //NewAdbooking.Classes.Contract insert = new NewAdbooking.Classes.Contract();
    DataSet dz = new DataSet();
   
    static  DataSet dk = new DataSet();
    static DataSet dk1 = new DataSet();
    string modify;

   
     DataRow my_row;
    object sender1;
    EventArgs e3;

    //Session["valueinsert"] =null;
   

    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = -1;
        if (Session["compcode"] == null)
        {
            Response.Write("<script>alert(\"Your Session  Been Expired\");window.close();</script>");
            return;

        }
        //////////////////////////////////////////////
     
        /////////////////////////////////`1`````````````````````///////
        hiddenofpop.Value = Request.QueryString["hiddenforpop"].ToString();
        hiddencompcode.Value = Session["compcode"].ToString();
        hiddenuserid.Value = Session["userid"].ToString();
        string value = Request.QueryString["txtdealvalue"].ToString();
        string volume = Request.QueryString["txtdealvol"].ToString();
        hiddenvalue.Value = Request.QueryString["txtdealvalue"].ToString();
        hiddenvolume.Value = Request.QueryString["txtdealvol"].ToString();
        dealno = Request.QueryString["dealno"].ToString();
        hiddendealcode.Value = Request.QueryString["dealno"].ToString();
        hiddencompcode.Value = Session["compcode"].ToString();
        hiddenuserid.Value = Session["userid"].ToString();
        hiddencurrency.Value = Session["currency"].ToString();
        hidecurr.Value = Request.QueryString["currsess"].ToString();
        modify = Request.QueryString["modifydet"].ToString();
        advtype = hiddenadtype.Value = adtype = Request.QueryString["adtype"].ToString();
        datefrom=hiddenfromdate.Value = Request.QueryString["fromdate"].ToString();
        dateto=hiddentodate.Value = Request.QueryString["todate"].ToString();
        hiddenagency.Value=con_agency = Request.QueryString["agency"].ToString();
        hiddenclient.Value=con_client = Request.QueryString["client"].ToString();
        hiddenproduct.Value=con_prod = Request.QueryString["prod"].ToString();
        hiddendateformat.Value = Session["dateformat"].ToString();
        compcode = Session["compcode"].ToString();
        userid = Session["userid"].ToString();
        if (hiddensavemod.Value == "1")
        {
            hiddensavemod.Value = "1";
        }
        else
        {
            hiddensavemod.Value = "0";
        }

        dealfordelete = hiddendeal.Value;

        Ajax.Utility.RegisterTypeForAjax(typeof(ContractDetail));

        //This code reads the label name from the xml file
        DataSet objDataSetbu = new DataSet();
        // Read in the XML file
        objDataSetbu.ReadXml(Server.MapPath("XML/Contractdetail.xml"));
        agencycategory.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[0].ToString();
        publication.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[1].ToString();
        suppliment.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[2].ToString();
        bookedfor.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[3].ToString();
        Color.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[4].ToString();
        CardRate.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[5].ToString();
        DealRate.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[6].ToString();
        PremiumCode.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[7].ToString();
        CardPremium.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[8].ToString();
        DealPremium.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[9].ToString();
        VolumeBilled.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[10].ToString();
        Volumedisc.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[11].ToString();
        Volumefrom.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[12].ToString();
        Volumeto.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[13].ToString();
        volumeunit.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[14].ToString();
        packagecode.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[15].ToString();
        edition.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[16].ToString();
        lbcurr.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[17].ToString();
        lbtotal.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[18].ToString();
        editionaldisc.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[19].ToString();
        approved.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[20].ToString();
        lbquantity.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[21].ToString();
        lbweight.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[22].ToString();
        lbdisc.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[23].ToString();
        CYOP.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[24].ToString();
        lbdeviation.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[25].ToString();
        lblincentive.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[26].ToString();
        lbadtype.Text = objDataSetbu.Tables[0].Rows[0].ItemArray[27].ToString();
        ////////////////////////////////////////////////////////////////////
        // for electronics
        agencycategory_elec.Text = objDataSetbu.Tables[1].Rows[0].ItemArray[0].ToString();
        publication_elec.Text = objDataSetbu.Tables[1].Rows[0].ItemArray[1].ToString();
        suppliment_elec.Text = objDataSetbu.Tables[1].Rows[0].ItemArray[2].ToString();
        bookedfor_elec.Text = objDataSetbu.Tables[1].Rows[0].ItemArray[3].ToString();
        //  Color_elec.Text = objDataSetbu.Tables[1].Rows[0].ItemArray[4].ToString();
        CardRate_elec.Text = objDataSetbu.Tables[1].Rows[0].ItemArray[5].ToString();
        DealRate_elec.Text = objDataSetbu.Tables[1].Rows[0].ItemArray[6].ToString();
        PremiumCode_elec.Text = objDataSetbu.Tables[1].Rows[0].ItemArray[7].ToString();
        CardPremium_elec.Text = objDataSetbu.Tables[1].Rows[0].ItemArray[8].ToString();
        DealPremium_elec.Text = objDataSetbu.Tables[1].Rows[0].ItemArray[9].ToString();
        VolumeBilled_elec.Text = objDataSetbu.Tables[1].Rows[0].ItemArray[10].ToString();
        Volumedisc_elec.Text = objDataSetbu.Tables[1].Rows[0].ItemArray[11].ToString();
        Volumefrom_elec.Text = objDataSetbu.Tables[1].Rows[0].ItemArray[12].ToString();
        Volumeto_elec.Text = objDataSetbu.Tables[1].Rows[0].ItemArray[13].ToString();
        volumeunit_elec.Text = objDataSetbu.Tables[1].Rows[0].ItemArray[14].ToString();
        packagecode_elec.Text = objDataSetbu.Tables[1].Rows[0].ItemArray[15].ToString();
        edition_elec.Text = objDataSetbu.Tables[1].Rows[0].ItemArray[16].ToString();
        lbcurr_elec.Text = objDataSetbu.Tables[1].Rows[0].ItemArray[17].ToString();
        lbtotal_elec.Text = objDataSetbu.Tables[1].Rows[0].ItemArray[18].ToString();
        editionaldisc_elec.Text = objDataSetbu.Tables[1].Rows[0].ItemArray[19].ToString();
        approved_elec.Text = objDataSetbu.Tables[1].Rows[0].ItemArray[20].ToString();
        lbquantity_elec.Text = objDataSetbu.Tables[1].Rows[0].ItemArray[21].ToString();
        lbweight_elec.Text = objDataSetbu.Tables[1].Rows[0].ItemArray[22].ToString();
        lbdisc_elec.Text = objDataSetbu.Tables[1].Rows[0].ItemArray[23].ToString();
        CYOP_elec.Text = objDataSetbu.Tables[1].Rows[0].ItemArray[24].ToString();
        lbdeviation_elec.Text = objDataSetbu.Tables[1].Rows[0].ItemArray[25].ToString();

        lblchannel.Text = objDataSetbu.Tables[1].Rows[0].ItemArray[27].ToString();
        lbllocation.Text = objDataSetbu.Tables[1].Rows[0].ItemArray[28].ToString();
        lblpaidbonus.Text = objDataSetbu.Tables[1].Rows[0].ItemArray[29].ToString();
        lblbtb.Text = objDataSetbu.Tables[1].Rows[0].ItemArray[30].ToString();
        lblros.Text = objDataSetbu.Tables[1].Rows[0].ItemArray[31].ToString();
        lblprogramcode.Text = objDataSetbu.Tables[1].Rows[0].ItemArray[32].ToString();
        lblconsumed.Text = objDataSetbu.Tables[1].Rows[0].ItemArray[33].ToString();
        lblbalance.Text = objDataSetbu.Tables[1].Rows[0].ItemArray[34].ToString();
        lblvalidfrom.Text = objDataSetbu.Tables[1].Rows[0].ItemArray[35].ToString();
        lbltilldate.Text = objDataSetbu.Tables[1].Rows[0].ItemArray[36].ToString();
        lblprogtype.Text = objDataSetbu.Tables[1].Rows[0].ItemArray[37].ToString();
        lblincentive_elec.Text = objDataSetbu.Tables[1].Rows[0].ItemArray[26].ToString();

        if (!Page.IsPostBack)
        {
            if (dk.Tables.Count > 0)
            {
                dk1.Clear();
                dk1.Dispose();
                dk1 = new DataSet();

                //dk.Clear();
                //dk.Dispose();
                dk = new DataSet();
            }
            pop_industry();
            bindadvcategory();
            //bindpublication();
            bindadtype();
            //bindcity();
            bindChannel(Session["compcode"].ToString());
            bindLocation(Session["compcode"].ToString());
            bindProgramType(Session["compcode"].ToString(),"");
            bindpackage();
            bindcolor();
            bindpremium();
            binduom(Request.QueryString["adtype"].ToString());
            bindcurrency();
            bindratecode();
            if (Session["valueinsert"] == null && hiddenofpop.Value!="0")
            {
                Datagrid1.Visible = false;
                firgri.Visible = true;
                secgri.Visible = false;
                GridView1.Visible = true;
                bindgridview("Advcategory");
            }
            else
            {
                firgri.Visible = false;
                secgri.Visible = true;
                GridView1.Visible = false;
                Datagrid1.Visible = true;
                bindgridview1();
            }
            drpindustry.Attributes.Add("OnChange", "javascript:return bindIndusProduct();");
            drpadtype.Attributes.Add("OnChange", "javascript:return bindFields();");
            lstcommon.Attributes.Add("onclick", "javascript:return insertagency();");
            lstbtb.Attributes.Add("onclick", "javascript:return insertagency();");
            lstros.Attributes.Add("onclick", "javascript:return insertagency();");

            drpedition.Attributes.Add("OnChange", "javascript:return edition_change();");
            drppublication.Attributes.Add("OnChange", "javascript:return publication_change();");
            drppackagecode.Attributes.Add("OnChange", "javascript:return color_change();");
            drpuom.Attributes.Add("OnChange","javascript:return color_change();");
            drpcolor.Attributes.Add("OnChange", "javascript:return color_change();");
            chbcyop.Attributes.Add("onclick", "javascript:return cyop();");
            btnclear.Attributes.Add("OnClick", "javascript:return clearcontractdetail();");
            btnclick.Attributes.Add("OnClick", "javascript:return deletecontact();");
            txtvoldisc.Attributes.Add("OnChange", "javascript:return chkuom(this);");
            txtvalfrom.Attributes.Add("OnChange", "javascript:return chkuomfrom(this);");
            txtvalto.Attributes.Add("OnChange", "javascript:return chkcurrencyval(this);");
            txtvolbilled.Attributes.Add("OnChange", "javascript:return chkcurrencybill(this);");
            txtvoldisc.Attributes.Add("onkeyup", "javascript:return chkvolume();");
            txtvolbilled.Attributes.Add("onkeyup", "javascript:return chkvolume();");
            txtvalfrom.Attributes.Add("onkeyup", "javascript:return chkvalue();");
            txtvalto.Attributes.Add("onkeyup", "javascript:return chkvalue();");
            //txtvalto.Attributes.Add("onkeyup", "javascript:return chkvalue();");
            //btnselect.Attributes.Add("onclick", "javascript:return submitted();");
            btnselect.Attributes.Add("onclick", "javascript:return submitted();");
            drpcurr.Attributes.Add("onclick", "javascript:return chkcurrency();");
            //drpuom.Attributes.Add("onchange", "javascript:return checkuom();");
          //  drpuom.Attributes.Add("onchange", "javascript:return getpkgrate();");
           // txtedidisc.Attributes.Add("onchange", "javascript:return chkpercent();");
            btnclose.Attributes.Add("onclick", "javascript:return closewindow1();");
            ckbapproved.Attributes.Add("onclick", "javascript:return chkdisc();");
            txtdealrate.Attributes.Add("onchange", "javascript:return deviation(this);");
            txtquantity.Attributes.Add("onchange", "javascript:return getweight();");
            
            //ckbapproved.Attributes.Add("onkeypress", "javascript:return chkenabled();");

          
            drpcurr.SelectedValue = hidecurr.Value;

            ///////////////////////////////////////////////this is for xml

            
            ////////////////////////////////////////////////
            if (hiddenvolume.Value != "")
            {
                txtvalfrom.Enabled = false;
                txtvalfrom.BackColor = System.Drawing.Color.Gray;
                txtvalto.Enabled = false;
                txtvalto.BackColor = System.Drawing.Color.Gray;
                txtquantity.Enabled = false;
                txtquantity.BackColor = System.Drawing.Color.Gray;
                txtweight.Enabled = false;
                txtweight.BackColor = System.Drawing.Color.Gray;
                txtvolbilled.Enabled = true;
                txtvolbilled.BackColor = System.Drawing.Color.White;
                txtvoldisc.Enabled = true;
                txtvoldisc.BackColor = System.Drawing.Color.White;
                txtsizeto.Enabled = false;
                txtsizeto.BackColor = System.Drawing.Color.Gray;
                txtsizefrom.Enabled = false;
                txtsizefrom.BackColor = System.Drawing.Color.Gray;
            }
            else if (hiddenvalue.Value != "")
            {
                txtvalfrom.Enabled = true;
                txtvalfrom.BackColor = System.Drawing.Color.White;
                txtvalto.Enabled = true;
                txtvalto.BackColor = System.Drawing.Color.White;
                txtquantity.Enabled = false;
                txtquantity.BackColor = System.Drawing.Color.Gray;
                txtweight.Enabled = false;
                txtweight.BackColor = System.Drawing.Color.Gray;
                txtvolbilled.Enabled = false;
                txtvolbilled.BackColor = System.Drawing.Color.Gray;
                txtvoldisc.Enabled = false;
                txtvoldisc.BackColor = System.Drawing.Color.Gray;
                txtsizeto.Enabled = false;
                txtsizeto.BackColor = System.Drawing.Color.Gray;
                txtsizefrom.Enabled = false;
                txtsizefrom.BackColor = System.Drawing.Color.Gray;

            }
            else if (hiddenvalue.Value == "" && hiddenvolume.Value == "")
            {
                txtvalfrom.Enabled = false;
                txtvalfrom.BackColor = System.Drawing.Color.Gray;
                txtvalto.Enabled = false;
                txtvalto.BackColor = System.Drawing.Color.Gray;
                txtquantity.Enabled = true;
                txtquantity.BackColor = System.Drawing.Color.White;
                txtweight.Enabled = true;
                txtweight.BackColor = System.Drawing.Color.White;
                txtvolbilled.Enabled = false;
                txtvolbilled.BackColor = System.Drawing.Color.Gray;
                txtvoldisc.Enabled = false;
                txtvoldisc.BackColor = System.Drawing.Color.Gray;
                txtsizeto.Enabled = true;
                txtsizeto.BackColor = System.Drawing.Color.White;
                txtsizefrom.Enabled = true;
                txtsizefrom.BackColor = System.Drawing.Color.White;
            }
            
            if (modify == "0" || modify == "1")
            {
                btnselect.Enabled = true;

                drpadvcat.Enabled = true;
                drpadtype.Enabled = true;
                txtremark.Enabled = true;
                txtsizefrom.Enabled = true;
                txtsizeto.Enabled = true;
                drpdisctype.Enabled = true;
                txtdiscamount.Enabled = true;
                txtinsertion.Enabled = true;
                drppublication.Enabled = true;
                drpsuppliment.Enabled = true;
                drpedition.Enabled = true;
                drpbooked.Enabled = false;
                drppackagecode.Enabled = true;
                drpcolor.Enabled = true;
                txtcardrate.Enabled = false;
                txtdealrate.Enabled = true;
                drppremium.Enabled = true;
                txtcardpremium.Enabled = true;
                txtdealpremium.Enabled = true;
                txtvolbilled.Enabled = true;
                txtvoldisc.Enabled = true;
                txtvalfrom.Enabled = true;
                txtvalto.Enabled = true;
                drpuom.Enabled = true;
                txtquantity.Enabled = true;
                txtweight.Enabled = true;
                drpdisc.Enabled = true;
                txttotal.Enabled = false;
                //hiddencyop.Enabled = true;
                txtdeviation.Enabled = false;
                drpratecode.Enabled = true;
                ckbapproved.Enabled = true;
                drpday.Enabled = true;
            }
            else
            {
                txtsizefrom.Enabled = false;
                txtsizeto.Enabled = false;
                drpdisctype.Enabled = false;
                txtdiscamount.Enabled = false;
                txtinsertion.Enabled = false;

                btnselect.Enabled = false;
                txtremark.Enabled = false;
                ckbapproved.Enabled = false;
                drpadtype.Enabled = false;
                drpadvcat.Enabled = false;
                drppublication.Enabled = false;
                drpsuppliment.Enabled = false;
                drpedition.Enabled = false;
                drpbooked.Enabled = false;
                drppackagecode.Enabled = false;
                drpcolor.Enabled = false;
                txtcardrate.Enabled = false;
                txtdealrate.Enabled = false;
                drppremium.Enabled = false;
                txtcardpremium.Enabled = false;
                txtdealpremium.Enabled = false;
                txtvolbilled.Enabled = false;
                txtvoldisc.Enabled = false;
                txtvalfrom.Enabled = false;
                txtvalto.Enabled = false;
                drpuom.Enabled = false;
                txtquantity.Enabled = false;
                txtweight.Enabled = false;
                drpdisc.Enabled = false;
                txttotal.Enabled = false;
                //hiddencyop.Enabled = false;
                txtdeviation.Enabled = false;
                drpratecode.Enabled = false;
                drpday.Enabled = false;
            }
           

           

        }
       

    }

    private void bindgridview1()
    {
        GridView1.Visible = false;       
        DataSet ds_tbl = new DataSet();

        /////////////////////////////////////
        DataColumn mycolumn;
        DataTable mydatatable = new DataTable();
        // DataRow myrow;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "Advcategory";
        mydatatable.Columns.Add(mycolumn);

        // //DataColumn mycolumn;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "publication";
        mydatatable.Columns.Add(mycolumn);

        ////DataColumn mycolumn;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "suppliment";
        mydatatable.Columns.Add(mycolumn);

        // //DataColumn mycolumn;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "Bookedfor";
        mydatatable.Columns.Add(mycolumn);

        ////DataColumn mycolumn;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "color";
        mydatatable.Columns.Add(mycolumn);

        // //DataColumn mycolumn;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "cardrate";
        mydatatable.Columns.Add(mycolumn);

        ////DataColumn mycolumn;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "Dealarte";
        mydatatable.Columns.Add(mycolumn);

        //DataColumn mycolumn;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "premiumcode";
        mydatatable.Columns.Add(mycolumn);

        //DataColumn mycolumn;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "cardpremium";
        mydatatable.Columns.Add(mycolumn);

        //DataColumn mycolumn;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "dealpremium";
        mydatatable.Columns.Add(mycolumn);

        //DataColumn mycolumn;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "volumebilled";
        mydatatable.Columns.Add(mycolumn);

        //DataColumn mycolumn;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "volumedisc";
        mydatatable.Columns.Add(mycolumn);

        //DataColumn mycolumn;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "valuefrom";
        mydatatable.Columns.Add(mycolumn);

        //DataColumn mycolumn;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "valueto";
        mydatatable.Columns.Add(mycolumn);

        //DataColumn mycolumn;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "Uom";
        mydatatable.Columns.Add(mycolumn);

        //DataColumn mycolumn;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "packagecode";
        mydatatable.Columns.Add(mycolumn);

        //DataColumn mycolumn;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "deal_code";
        mydatatable.Columns.Add(mycolumn);

        //DataColumn mycolumn;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "comp_code";
        mydatatable.Columns.Add(mycolumn);

        //DataColumn mycolumn;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "userid";
        mydatatable.Columns.Add(mycolumn);

        //DataColumn mycolumn;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "edition";
        mydatatable.Columns.Add(mycolumn);

        //DataColumn mycolumn;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "convertrate";
        mydatatable.Columns.Add(mycolumn);

        //DataColumn mycolumn;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "currency";
        mydatatable.Columns.Add(mycolumn);

        //DataColumn mycolumn;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "Rate_code";
        mydatatable.Columns.Add(mycolumn);

        //DataColumn mycolumn;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "approved";
        mydatatable.Columns.Add(mycolumn);

        //DataColumn mycolumn;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "quantity";
        mydatatable.Columns.Add(mycolumn);

        //DataColumn mycolumn;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "weight";
        mydatatable.Columns.Add(mycolumn);

        //DataColumn mycolumn;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "discounted";
        mydatatable.Columns.Add(mycolumn);

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "ContractCode";
        mydatatable.Columns.Add(mycolumn);

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "Cyop";
        mydatatable.Columns.Add(mycolumn);

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "deviation";
        mydatatable.Columns.Add(mycolumn);

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "REMARKS";
        mydatatable.Columns.Add(mycolumn);

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "SIZEFROM";
        mydatatable.Columns.Add(mycolumn);

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "SIZETO";
        mydatatable.Columns.Add(mycolumn);

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "DISCTYPE";
        mydatatable.Columns.Add(mycolumn);

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "DISCPER";
        mydatatable.Columns.Add(mycolumn);

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "INSERTION";
        mydatatable.Columns.Add(mycolumn);

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "DAYNAME";
        mydatatable.Columns.Add(mycolumn);

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "COMMITION_ALLOW";
        mydatatable.Columns.Add(mycolumn);

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "DEAL_START";
        mydatatable.Columns.Add(mycolumn);

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "INCENTIVE";
        mydatatable.Columns.Add(mycolumn);
        //////////////////////////////////////////////////////////////

        int l;
        dk1 = (DataSet)Session["valueinsert"];
    //    for (l = 0; l <= dk1.Tables.Count - 1; l++)
      //  {

     //   }
       // ds_tbl.Tables.Add(mydatatable);
        //ViewState["SortExpression"] = sortfield;
        //ViewState["order"] = "ASC";
        //DataView dv = new DataView();
        //dv = ds_tbl.Tables[--d].DefaultView;
        ////dv = bind_grid.Defau;
        //dv.Sort = sortfield;
        if (Session["valueinsert"] == null)
        {
            ds_tbl.Tables.Add(mydatatable);
            Datagrid1.DataSource = ds_tbl.Tables[0];
            Datagrid1.DataBind();
        }
        else
        {
            int d;
            int g;
            if (dk1.Tables.Count > 1)
            {
                g = 1;
            }
            else
            {
                g = 0;
            }

            for (d = 0; d <= dk1.Tables.Count - 1; d++)
            {
                //if (g == 0)
                //{my_row = dk1.Tables[d].Rows[0]my_row = dk1.Tables[d].Rows[0]
                    my_row = dk1.Tables[d].Rows[0];
                //}
                //else
                //{
                //     my_row = dk.Tables[dk.Tables.Count - 1].Rows[0];
                //}
               
                mydatatable.ImportRow(my_row);
            }

            ds_tbl.Tables.Add(mydatatable);
            ViewState["SortExpression"] = "Advcategory";
            ViewState["order"] = "ASC";
            DataView dv = new DataView();
            //if (g == 0)
            //{
                dv = ds_tbl.Tables[0].DefaultView;
            //}
            //else
            //{
            //    dv = ds_tbl.Tables[--d].DefaultView;
            //}
            //dv = bind_grid.Defau;
            //dv.Sort = "Advcategory";


            Datagrid1.DataSource = dv;
            Datagrid1.DataBind();
            d = 0;
            //dk1.Clear();
            
        }
    }

    private void bindgridview(string sortfield)
    {

        DataSet ds = new DataSet();
        if(ConfigurationSettings.AppSettings ["ConnectionType"].ToString ()=="sql")
        {

         NewAdbooking.Classes.Contract bindgridforcontract = new NewAdbooking.Classes.Contract();
        
            ds = bindgridforcontract.bindgrid(Session["compcode"].ToString(), Session["userid"].ToString(), dealno, "0");
        }

        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
              NewAdbooking.classesoracle .Contract bindgridforcontract = new NewAdbooking.classesoracle.Contract();
        
            ds = bindgridforcontract.bindgrid(Session["compcode"].ToString(), Session["userid"].ToString(), dealno, "0");

            }
        else
        {
            NewAdbooking.classmysql.Contract bindgridforcontract = new NewAdbooking.classmysql.Contract();

            ds = bindgridforcontract.bindgrid(Session["compcode"].ToString(), Session["userid"].ToString(), dealno, "0");


        }

            ViewState["SortExpression"] = sortfield;
            ViewState["order"] = "ASC";
            DataView dv = new DataView();
            dv = ds.Tables[0].DefaultView;
            dv.Sort = sortfield;


            GridView1.DataSource = dv;
            GridView1.DataBind();
        
       
    }
    [Ajax.AjaxMethod]
    public DataSet bindProduct_A(string compcode, string industry)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Contract binduom = new NewAdbooking.Classes.Contract();
            ds = binduom.bindProduct(compcode, industry);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.Contract binduom = new NewAdbooking.classesoracle.Contract();
                ds = binduom.bindProduct(compcode, industry);
            }
            else
            {
              //  NewAdbooking.classmysql.Contract binduom = new NewAdbooking.classmysql.Contract();
               // ds = binduom.uombind(compcode, userid);

            }
        return ds;
    }
    [Ajax.AjaxMethod]
    public DataSet binduom_A(string compcode, string adType, string userid)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Contract binduom = new NewAdbooking.Classes.Contract();
            ds = binduom.uombind(compcode, adType);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.Contract binduom = new NewAdbooking.classesoracle.Contract();
                ds = binduom.uombind(compcode, userid, adType);
            }
            else
            {
                NewAdbooking.classmysql.Contract binduom = new NewAdbooking.classmysql.Contract();
                ds = binduom.uombind(compcode, userid);

            }
        return ds;
    }
    public void binduom(string adType)
    {
        DataSet ds = new DataSet();
        if(ConfigurationSettings.AppSettings ["ConnectionType"].ToString ()=="sql")
        {
            NewAdbooking.Classes.Contract binduom = new NewAdbooking.Classes.Contract();        
            ds = binduom.uombind(Session["compcode"].ToString(), "EL0");
        }
        else
           if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
           {
                 NewAdbooking.classesoracle.Contract binduom = new NewAdbooking.classesoracle.Contract();
                 ds = binduom.uombind(Session["compcode"].ToString(), Session["userid"].ToString(), "EL0");
           }
           else
           {
                NewAdbooking.classmysql .Contract binduom = new NewAdbooking.classmysql.Contract();
                ds = binduom.uombind(Session["compcode"].ToString(), Session["userid"].ToString());

            }
        drpuom_elec.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "-Select UOM-";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        drpuom_elec.Items.Add(li1);

        if (ds.Tables[0].Rows.Count > 0)
        {
            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ListItem li;
                li = new ListItem();
                li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                drpuom_elec.Items.Add(li);
            }

        }

    }
    public void bindratecode()
    {

        DataSet dx = new DataSet();
        
        string contract = "contract";

                if(ConfigurationSettings.AppSettings ["ConnectionType"].ToString ()=="sql")
                {

        NewAdbooking.Classes.BookingMaster bindrate = new NewAdbooking.Classes.BookingMaster();
        
        dx = bindrate.ratebind(contract,Session["compcode"].ToString());
                }
                else
                    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                    {
                        NewAdbooking.classesoracle.BookingMaster bindrate = new NewAdbooking.classesoracle.BookingMaster();

                        dx = bindrate.ratebind(contract, Session["compcode"].ToString());

                    }
                else
                {
            NewAdbooking.classmysql.BookingMaster bindrate = new NewAdbooking.classmysql.BookingMaster();
        
        dx = bindrate.ratebind(contract,Session["compcode"].ToString());
 

                }

        drpratecode.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "-Select Rate Code-";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        drpratecode.Items.Add(li1);

        if (dx.Tables[0].Rows.Count > 0)
        {
            for (i = 0; i < dx.Tables[0].Rows.Count; i++)
            {
                ListItem li;
                li = new ListItem();
                li.Text = dx.Tables[0].Rows[i].ItemArray[0].ToString();
                li.Value = dx.Tables[0].Rows[i].ItemArray[0].ToString();
                //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                drpratecode.Items.Add(li);
            }

        }

    }
    [Ajax.AjaxMethod]
    public DataSet bindpremium_A(string compcode, string adtype)
    {
        DataSet ds1 = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.RateMaster bindrate = new NewAdbooking.Classes.RateMaster();
            ds1 = bindrate.premiumbind(compcode,adtype);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.RateMaster bindrate = new NewAdbooking.classesoracle.RateMaster();
            ds1 = bindrate.premiumbind(compcode, adtype);
        }
        else
        {
            NewAdbooking.classmysql.RateMaster bindrate = new NewAdbooking.classmysql.RateMaster();
            ds1 = bindrate.premiumbind(compcode, adtype);
        }
        return ds1;
    }
    public void bindpremium()
    {

        //  DataSet ds = new DataSet();
        //        if(ConfigurationSettings.AppSettings ["ConnectionType"].ToString ()=="sql")
        //        {

        //NewAdbooking.Classes.Contract bindpremium = new NewAdbooking.Classes.Contract();
      
        //ds = bindpremium.premiumbind(Session["compcode"].ToString(), Session["userid"].ToString());
        //        }

        //        else
        //            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        //            {
        //                NewAdbooking.classesoracle.Contract bindpremium = new NewAdbooking.classesoracle.Contract();

        //                ds = bindpremium.premiumbind(Session["compcode"].ToString(), Session["userid"].ToString());

        //            }
        //        else

        //        {
        //NewAdbooking.classmysql.Contract bindpremium = new NewAdbooking.classmysql.Contract();      
        //ds = bindpremium.premiumbind(Session["compcode"].ToString(), Session["userid"].ToString());
        //        }
        //drppremium.Items.Clear();
        //int i;
        //ListItem li1;
        //li1 = new ListItem();
        //li1.Text = "-Select Premium-";
        //li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        //li1.Selected = true;
        //drppremium.Items.Add(li1);

        //if (ds.Tables[0].Rows.Count > 0)
        //{
        //    for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        //    {
        //        ListItem li;
        //        li = new ListItem();
        //        li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
        //        li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
        //        //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
        //        drppremium.Items.Add(li);
        //    }

        //}
        DataSet ds1 = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.RateMaster bindrate = new NewAdbooking.Classes.RateMaster();
            ds1 = bindrate.premiumbind(Session["compcode"].ToString(), "EL0");
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.RateMaster bindrate = new NewAdbooking.classesoracle.RateMaster();
            ds1 = bindrate.premiumbind(Session["compcode"].ToString(), "EL0");
        }
        else
        {
            NewAdbooking.classmysql.RateMaster bindrate = new NewAdbooking.classmysql.RateMaster();
            ds1 = bindrate.premiumbind(Session["compcode"].ToString(), "EL0");
        }

        drppremium_elec.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "-Select Premium-";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        drppremium_elec.Items.Add(li1);

        if (ds1.Tables[0].Rows.Count > 0)
        {
            for (i = 0; i < ds1.Tables[0].Rows.Count; i++)
            {
                ListItem li;
                li = new ListItem();
                li.Text = ds1.Tables[0].Rows[i].ItemArray[0].ToString();
                li.Value = ds1.Tables[0].Rows[i].ItemArray[1].ToString();
                //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                drppremium_elec.Items.Add(li);
            }

        }

    }

    public void bindcolor()
    {
        DataSet ds = new DataSet();
        if(ConfigurationSettings.AppSettings ["ConnectionType"].ToString ()=="sql")
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
             else
             {
                  NewAdbooking.classmysql.Contract bindcolor = new NewAdbooking.classmysql.Contract();
        
                  ds = bindcolor.colorbind(Session["compcode"].ToString(), Session["userid"].ToString());
  
             }
        drpcolor.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "-Select Color-";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        drpcolor.Items.Add(li1);

        if (ds.Tables[0].Rows.Count > 0)
        {
            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ListItem li;
                li = new ListItem();
                li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                drpcolor.Items.Add(li);
            }

        }


    }
    [Ajax.AjaxMethod]
    public DataSet bindpackage_A(string compcode, string adtype)
    {

        DataSet ds = new DataSet();

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {


            NewAdbooking.Classes.Contract bindopackage = new NewAdbooking.Classes.Contract();

            ds = bindopackage.packagebind(compcode, adtype);
        }

        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.Contract bindopackage = new NewAdbooking.classesoracle.Contract();

                ds = bindopackage.packagebind(compcode,adtype);

            }
            else
            {
                NewAdbooking.classmysql.Contract bindopackage = new NewAdbooking.classmysql.Contract();

                ds = bindopackage.packagebind(compcode,adtype);


            }
        return ds;
    }
    public void bindpackage()
    {

          DataSet ds = new DataSet();

                if(ConfigurationSettings.AppSettings ["ConnectionType"].ToString ()=="sql")
                {


        NewAdbooking.Classes.Contract bindopackage = new NewAdbooking.Classes.Contract();

        ds = bindopackage.packagebind(Session["compcode"].ToString(), "EL0");
                }

                else
                    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                    {
                        NewAdbooking.classesoracle.Contract bindopackage = new NewAdbooking.classesoracle.Contract();

                        ds = bindopackage.packagebind(Session["compcode"].ToString(), "EL0");

                    }
                else
                {
         NewAdbooking.classmysql.Contract bindopackage = new NewAdbooking.classmysql.Contract();
      
        ds = bindopackage.packagebind(Session["compcode"].ToString(), Session["userid"].ToString());
 

                }
        drppackagecode_elec.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "-Select Package Code-";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        drppackagecode_elec.Items.Add(li1);

        //ListItem li12;
        //li12 = new ListItem();
        //li12.Text = "-CYOP-";
        //li12.Value = "cyop";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        ////li1.Selected = true;
        //drppackagecode.Items.Add(li12);

        if (ds.Tables[1].Rows.Count > 0)
        {
            for (i = 0; i < ds.Tables[1].Rows.Count; i++)
            {
                ListItem li;
                li = new ListItem();
                li.Text = ds.Tables[1].Rows[i].ItemArray[1].ToString();
                li.Value = ds.Tables[1].Rows[i].ItemArray[0].ToString();
                //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                drppackagecode_elec.Items.Add(li);
            }

        }


    }

    [Ajax.AjaxMethod]
    public DataSet bindadvcategory_A(string adtypeval, string compcode)
    {
        DataSet ds = new DataSet();

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            NewAdbooking.Classes.Contract bindadvcate = new NewAdbooking.Classes.Contract();

            ds = bindadvcate.bindadvcategory(compcode, adtypeval);
        }

        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.Contract bindadvcate = new NewAdbooking.classesoracle.Contract();

                ds = bindadvcate.bindadvcategory(compcode, adtypeval);

            }
            else
            {
                NewAdbooking.classmysql.Contract bindadvcate = new NewAdbooking.classmysql.Contract();
                ds = bindadvcate.bindadvcategory(compcode, adtypeval);
            }
        return ds;
    }
    
    public void bindadvcategory()
    {
        DataSet ds = new DataSet();

                if(ConfigurationSettings.AppSettings ["ConnectionType"].ToString ()=="sql")
                {

        NewAdbooking.Classes.Contract bindadvcate = new NewAdbooking.Classes.Contract();
        
        ds = bindadvcate.bindadvcategory(Session["compcode"].ToString(),"EL0");
                }

                else
                    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                    {
                        NewAdbooking.classesoracle.Contract bindadvcate = new NewAdbooking.classesoracle.Contract();

                        ds = bindadvcate.bindadvcategory(Session["compcode"].ToString(), "EL0");
  
                    }
        else
                {
     NewAdbooking.classmysql.Contract bindadvcate = new NewAdbooking.classmysql.Contract();        
        ds = bindadvcate.bindadvcategory(Session["compcode"].ToString(),"EL0");
                }
        drpadvcat_elec.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "-Select Ad Category-";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        drpadvcat_elec.Items.Add(li1);

        if (ds.Tables[0].Rows.Count > 0)
        {
            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ListItem li;
                li = new ListItem();
                li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                drpadvcat_elec.Items.Add(li);
            }

        }


    }

    public void bindpublication()
    {

         DataSet ds = new DataSet();
                if(ConfigurationSettings.AppSettings ["ConnectionType"].ToString ()=="sql")
                {

        NewAdbooking.Classes.Contract bindpublication = new NewAdbooking.Classes.Contract();
       
        ds = bindpublication.publication(Session["compcode"].ToString());
                }

                else
                    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                    {
                        NewAdbooking.classesoracle.Contract bindpublication = new NewAdbooking.classesoracle.Contract();

                        ds = bindpublication.publication(Session["compcode"].ToString());

                    }
                else
                {
                            NewAdbooking.classmysql.Contract bindpublication = new NewAdbooking.classmysql.Contract();
       
        ds = bindpublication.publication(Session["compcode"].ToString());
    

                }
        drppublication.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "-Select Publication-";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        drppublication.Items.Add(li1);

        if (ds.Tables[0].Rows.Count > 0)
        {
            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ListItem li;
                li = new ListItem();
                li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                drppublication.Items.Add(li);
            }

        }


    }
   

    protected void AspNetMessageBox(string strMessage)
    {
        //strMessage = adminResource.GetStringFromResource(strMessage);
        string strAlert = "";
        strAlert = "alert('" + strMessage + "')";
        ScriptManager.RegisterClientScriptBlock(this, typeof(ContractDetail), "ShowAlert", strAlert, true);
    }

   
   
    #region Web Form Designer generated code
    override protected void OnInit(EventArgs e)
    {
        //
        // CODEGEN: This call is required by the ASP.NET Web Form Designer.
        //
        InitializeComponent();
        base.OnInit(e);
    }

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        //this.hiddencomcode.ServerChange += new System.EventHandler(this.hiddencomcode_ServerChange);
        //this.Load += new System.EventHandler(this.Page_Load);

    }
    #endregion
    protected void GridView1_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        /////////////////////////////
         DataSet dl = new DataSet();
         if(ConfigurationSettings.AppSettings ["ConnectionType"].ToString ()=="sql")
                {
        NewAdbooking.Classes.Contract chkcontractdetail = new NewAdbooking.Classes.Contract();
       
        dl = chkcontractdetail.chkincontractdetail(dealno, Session["compcode"].ToString(), Session["userid"].ToString());
         }

         else
             if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
             {
                 NewAdbooking.classesoracle.Contract chkcontractdetail = new NewAdbooking.classesoracle.Contract();

                 dl = chkcontractdetail.chkincontractdetail(dealno, Session["compcode"].ToString(), Session["userid"].ToString());

             }
         else
         {
                     NewAdbooking.classmysql.Contract chkcontractdetail = new NewAdbooking.classmysql.Contract();
       
        dl = chkcontractdetail.chkincontractdetail(dealno, Session["compcode"].ToString(), Session["userid"].ToString());


         }
/////////////////////////////////////////////////////////////////////////////////////

       

            DataView dv = new DataView();


            dv = (DataView)GridView1.DataSource;
            DataColumnCollection dc = dv.Table.Columns;
      

        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
           
                e.Item.Cells[0].Visible = true;
                string str = "checkbox" + i;
                string str1 = "checkbox_" + i;
                string abc = e.Item.Cells[19].Text;
                //e.Item.Cells[1].Text = "<input  type='checkbox' id=" + str + " style=\"top:0px\" width='5px' OnClick=\"javascript:return selectforcontract('" + str + "','" + e.Item.Cells[27].Text + "');\"  value=" + e.Item.Cells[27].Text + "   />";
                if (modify == "0" || modify == "1")
                {
                    e.Item.Cells[1].Text = "<input type='checkbox' id=" + str + " style=\"top:0px\" width='5px' OnClick=\"javascript:return selectforcontract('" + str + "','" + e.Item.Cells[28].Text + "');\"  value=" + e.Item.Cells[28].Text + "   />";
                    //e.Item.Cells[0].Text = "<input type='checkbox' id=" + str1 + " style=\"top:0px\" width='5px' OnClick=\"javascript:return insertforcontract('"+str+"');\"  value=" + e.Item.Cells[27].Text + "   />";
                    e.Item.Cells[0].Text = "<input type='checkbox' id=" + str1 + " style=\"top:0px\" width='5px' OnClick=\"javascript:return insertforcontract('" + str1 + "','" + e.Item.Cells[28].Text + "');\"  value=" + e.Item.Cells[28].Text + "   />";
                }
                else
                {
                    e.Item.Cells[1].Text = "<input type='checkbox' disabled id=" + str + " style=\"top:0px\" width='5px' OnClick=\"javascript:return selectforcontract('" + str + "','" + e.Item.Cells[28].Text + "');\"  value=" + e.Item.Cells[28].Text + "   />";
                    //e.Item.Cells[0].Text = "<input type='checkbox' id=" + str1 + " style=\"top:0px\" width='5px' OnClick=\"javascript:return insertforcontract('"+str+"');\"  value=" + e.Item.Cells[27].Text + "   />";
                    e.Item.Cells[0].Text = "<input type='checkbox' disabled id=" + str1 + " style=\"top:0px\" width='5px' OnClick=\"javascript:return insertforcontract('" + str1 + "','" + e.Item.Cells[28].Text + "');\"  value=" + e.Item.Cells[28].Text + "   />";
                }
            i++;

            
            //string str = "checkbox" + i;
            //string abc = e.Item.Cells[19].Text;
            //e.Item.Cells[0].Text = "<input type='checkbox' id=" + str + " style=\"top:0px\" width='5px' OnClick=\"javascript:return selectforcontract('" + str + "','"+e.Item.Cells[25].Text+"');\"  value=" + e.Item.Cells[25].Text + "   />";
            //i++;
        }

        if (e.Item.ItemType == ListItemType.Header)
        {

            ////////////////////for grid size

            //For a = 0 To e.Item.Cells.Count - 1
            for(int a=0;a<=e.Item.Cells.Count - 1;a++)
            {
                e.Item.Cells[a].Attributes.Add("onmousedown", "abc3(this,event)");
                e.Item.Cells[a].Attributes.Add("onmousemove", "abc2(this,event)");
                e.Item.Cells[a].Attributes.Add("onmouseup", "abc1(this,event)");
                e.Item.Cells[a].Width = Unit.Pixel(300);
                e.Item.Cells[a].ID = "d" + Convert.ToString(a);
            }
            //////////////////////////////

            if (ViewState["SortExpression"].ToString() != "")
            {
                string str = "";
                switch (ViewState["SortExpression"].ToString())
                {
                    case "Advcategory":
                        str = "Ad. Category";
                        break;
                    //case "ContractCode":
                    //    str = "Deal No";
                    //    break;

                    case "publication":
                        str = "Publication";
                        break;

                    case "suppliment":
                        str = "Suppliment";
                        break;

                    case "Bookedfor":
                        str = "Package Description";
                        break;

                    case "edition":
                        str = "Edition";
                        break;

                    case "packagecode":
                        str = "Package Name";
                        break;

                    case "color":
                        str = "Hue";
                        break;

                    case "cardrate":
                        str = "Card Rate";
                        break;

                    case "Dealarte":
                        str = "Contract Rate";
                        break;

                    case "premiumcode":
                        str = "Premium Name";
                        break;


                    case "cardpremium":
                        str = "Card Premium";
                        break;


                    case "dealpremium":
                        str = "Contract Premium";
                        break;

                    case "volumebilled":
                        str = "Volume Billed";
                        break;

                    case "volumedisc":
                        str = "Volume disc.";
                        break;

                    case "valuefrom":
                        str = "Value From";
                        break;

                    case "valueto":
                        str = "Value To";
                        break;

                    case "Uom":
                        str = "Uom";
                        break;

                    case "currency":
                        str = "Currency Type";
                        break;

                    case "convertrate":
                        str = "Total Rate";
                        break;

                    case "Rate_code":
                        str = "Rate Code";
                        break;

                    case "approved":
                        str = "Approved";
                        break;

                    case "quantity":
                        str = "Quantity";
                        break;

                    case "weight":
                        str = "Weight";
                        break;

                    case "discounted":
                        str = "Disc. Applied";
                        break;

                    case "Cyop":
                        str = "Cyop";
                        break;

                    case "deviation":
                        str = "Deviation";
                        break;






                };

                string strd = Convert.ToString(dc.IndexOf(dc[ViewState["SortExpression"].ToString()]));
                strd = Convert.ToString(Convert.ToInt32(strd) - 1);
                if (strd.Length < 2)
                    strd = "0" + strd;
                if (ViewState["order"].ToString() == "DESC")
                {
                    //e.Item.Cells[dc.IndexOf(dc[ViewState["SortExpression"].ToString ()])].Text= "<a href=\"javascript:__doPostBack('DataGrid1$_ctl1$_ctl"+dc.IndexOf(dc[ViewState["SortExpression"].ToString ()])+"','')\">"+ str +"<img  src=\"images\\movenext2.gif\" border=0></a>";
                    //e.Item.Cells[dc.IndexOf(dc[ViewState["SortExpression"].ToString ()])].Text= "<a href=\"javascript:__doPostBack('DataGrid1$_ctl1$_ctl"+dc.IndexOf(dc[ViewState["SortExpression"].ToString ()])+"','')\">"+ str +"<img  src=\"images\\movenext2.gif\" border=0></a>";
                    //$ctl01$ctl00
                    //GridView1$ctl01$ctl00
                    e.Item.Cells[dc.IndexOf(dc[ViewState["SortExpression"].ToString()])+1].Text = "<a Class='dtGridHd12' href=\"javascript:__doPostBack('GridView1$ctl01$ctl" + strd + "','')  \">" + str + "<img  src=\"images\\movenext2.gif\" border=0></a>";

                }
                else
                {
                    //e.Item.Cells[dc.IndexOf(dc[ViewState["SortExpression"].ToString ()])].Text= "<a href=\"javascript:__doPostBack('DataGrid1$_ctl1$_ctl"+dc.IndexOf(dc[ViewState["SortExpression"].ToString ()])+"','')\">"+str+"<img  src=\"images\\moveprevious2.gif\" border=0></a>";

                    e.Item.Cells[dc.IndexOf(dc[ViewState["SortExpression"].ToString()])+1].Text = "<a Class='dtGridHd12' href=\"javascript:__doPostBack('GridView1$ctl01$ctl" + strd + "','')   \">" + str + "<img  src=\"images\\moveprevious2.gif\" border=0></a>";


                }




            }
        }

    }
    [Ajax.AjaxMethod]
    public DataSet supplimentbind(string compcode,string editioncode)
    {
        DataSet ds = new DataSet();

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Contract bindsuppl = new NewAdbooking.Classes.Contract();

            ds = bindsuppl.supplimentbind(compcode, editioncode);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.Contract bindsuppl = new NewAdbooking.classesoracle.Contract();

                ds = bindsuppl.supplimentbind(compcode, editioncode);

            }
            else
            {
                NewAdbooking.classmysql.Contract bindsuppl = new NewAdbooking.classmysql.Contract();

                ds = bindsuppl.supplimentbind(compcode, editioncode);


            }
        return ds;
    }
    [Ajax.AjaxMethod]
    public DataSet getthevalue(string compcode,string userid,string code,string dealcode)
    {
          DataSet ds = new DataSet();
         if(ConfigurationSettings.AppSettings ["ConnectionType"].ToString ()=="sql")
                {
        NewAdbooking.Classes.Contract getvalue = new NewAdbooking.Classes.Contract();
      
        ds = getvalue.getfromcontractdetail(compcode, userid, code, dealcode);

        return ds;
         }
         else
             if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
             {
                 NewAdbooking.classesoracle.Contract getvalue = new NewAdbooking.classesoracle.Contract();

                 ds = getvalue.getfromcontractdetail(compcode, userid, code, dealcode);

                 return ds;

             }
         else
         {
                     NewAdbooking.classmysql .Contract getvalue = new NewAdbooking.classmysql.Contract();
      
        ds = getvalue.getfromcontractdetail(compcode, userid, code, dealcode);

        return ds;


         }


    }


    //protected void drppublication_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    string pubcode = drppublication.SelectedItem.Value;
    //    DataSet ds = new DataSet();
    //     if(ConfigurationSettings.AppSettings ["ConnectionType"].ToString ()=="sql")
    //            {

    //    NewAdbooking.Classes.Contract bindeditionfor = new NewAdbooking.Classes.Contract();
        
    //    ds = bindeditionfor.editionbind(Session["compcode"].ToString(), pubcode);
    //     }

    //     else
    //         if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
    //         {
    //             NewAdbooking.classesoracle.Contract bindeditionfor = new NewAdbooking.classesoracle.Contract();

    //             ds = bindeditionfor.editionbind(Session["compcode"].ToString(), pubcode);

    //         }
    //     else
    //     {
    //    NewAdbooking.classmysql.Contract bindeditionfor = new NewAdbooking.classmysql.Contract();
        
    //    ds = bindeditionfor.editionbind(Session["compcode"].ToString(), pubcode);


    //     }
    //    if (ds.Tables[0].Rows.Count >= 0)
    //    {
    //        drpedition.Items.Clear();
    //        int i;
    //        ListItem li1;
    //        li1 = new ListItem();
    //        li1.Text = "-Select Edition-";
    //        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
    //        li1.Selected = true;
    //        drpedition.Items.Add(li1);

    //        if (ds.Tables[0].Rows.Count > 0)
    //        {
    //            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
    //            {
    //                ListItem li;
    //                li = new ListItem();
    //                li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
    //                li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
    //                //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
    //                drpedition.Items.Add(li);
    //            }

    //        }
    //    }
    //    else
    //    {
    //        message = "There is no data for the selected publication";
    //        AspNetMessageBox(message);
    //        return;
    //    }

    //    if (pubcode != "0")
    //    {
    //        drppackagecode.Enabled = false;
    //        drppackagecode.SelectedValue = "0";
    //        drpbooked.Text = "";

    //    }
    //    else
    //    {
    //        drppackagecode.Enabled = true;
    //        drppackagecode.SelectedValue = "0";
    //        //drppackagecode.Text = "";
    //        drpedition.Items.Clear();
    //        drpsuppliment.Items.Clear();
    //        //drpsuppliment.SelectedItem.Text = null;
    //        //drpsuppliment.Text = "";

    //    }





    //}
    //protected void drpedition_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    string editioncode = drpedition.SelectedItem.Value;
    //     DataSet ds = new DataSet();

    //     if(ConfigurationSettings.AppSettings ["ConnectionType"].ToString ()=="sql")
    //            {
    //    NewAdbooking.Classes.Contract bindsuppl = new NewAdbooking.Classes.Contract();
       
    //    ds = bindsuppl.supplimentbind(Session["compcode"].ToString(), editioncode);
    //     }
    //     else
    //         if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
    //         {
    //             NewAdbooking.classesoracle.Contract bindsuppl = new NewAdbooking.classesoracle.Contract();

    //             ds = bindsuppl.supplimentbind(Session["compcode"].ToString(), editioncode);

    //         }
    //     else
    //     {
    //                 NewAdbooking.classmysql.Contract bindsuppl = new NewAdbooking.classmysql.Contract();
       
    //    ds = bindsuppl.supplimentbind(Session["compcode"].ToString(), editioncode);
 

    //     }
    //    if (ds.Tables[0].Rows.Count - 1 >= 0)
    //    {
    //        drpsuppliment.Items.Clear();
    //        int i;
    //        ListItem li1;
    //        li1 = new ListItem();
    //        li1.Text = "-Select Suppliment-";
    //        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
    //        li1.Selected = true;
    //        drpsuppliment.Items.Add(li1);

    //        if (ds.Tables[0].Rows.Count > 0)
    //        {
    //            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
    //            {
    //                ListItem li;
    //                li = new ListItem();
    //                li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
    //                li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
    //                //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
    //                drpsuppliment.Items.Add(li);
    //            }

    //        }
    //    }
    //    else
    //    {
    //        message = "There is no data for selected Edition";
    //        AspNetMessageBox(message);
    //        return;
    //    }

    //}
    //protected void drpsuppliment_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    string suppcode = drpsuppliment.SelectedItem.Value;

    //}
    protected void GridView1_SortCommand(object source, DataGridSortCommandEventArgs e)
    {DataSet ds = new DataSet();

         if(ConfigurationSettings.AppSettings ["ConnectionType"].ToString ()=="sql")
                {
        NewAdbooking.Classes.Contract bindgridforcontract = new NewAdbooking.Classes.Contract();
        
        ds = bindgridforcontract.bindgrid(Session["compcode"].ToString(), Session["userid"].ToString(), dealno,"0");
         }
         else
             if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
             {
                 NewAdbooking.classesoracle.Contract bindgridforcontract = new NewAdbooking.classesoracle.Contract();

                 ds = bindgridforcontract.bindgrid(Session["compcode"].ToString(), Session["userid"].ToString(), dealno, "0");

             }
         else
         {
                     NewAdbooking.classmysql .Contract bindgridforcontract = new NewAdbooking.classmysql.Contract();
        
        ds = bindgridforcontract.bindgrid(Session["compcode"].ToString(), Session["userid"].ToString(), dealno,"0");

         }

        DataView dv = new DataView();
        dv = ds.Tables[0].DefaultView;
        if ((numberDiv % 2) == 0)
        {
            dv.Sort = e.SortExpression + " " + "ASC";
            ViewState["SortExpression"] = e.SortExpression;
            ViewState["order"] = "ASC";
        }
        else
        {
            dv.Sort = e.SortExpression + " " + "DESC";
            ViewState["SortExpression"] = e.SortExpression;
            ViewState["order"] = "DESC";
        }
        numberDiv++;



        GridView1.DataSource = dv;
        GridView1.DataBind();
    }

   
   

    [Ajax.AjaxMethod]

    public void deletethevalue(string compcode,string userid,string dealcode)
    {
        DataSet ds = new DataSet();

         if(ConfigurationSettings.AppSettings ["ConnectionType"].ToString ()=="sql")
                {
        NewAdbooking.Classes.Contract contactcvalue = new NewAdbooking.Classes.Contract();
        
        ds = contactcvalue.contractdelete(compcode, userid, dealcode);
         }
         else
             if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
             {
                 NewAdbooking.classesoracle.Contract contactcvalue = new NewAdbooking.classesoracle.Contract();

                 ds = contactcvalue.contractdelete(compcode, userid, dealcode);

             }
         else
         {
                     NewAdbooking.classmysql.Contract contactcvalue = new NewAdbooking.classmysql.Contract();
        
        ds = contactcvalue.contractdelete(compcode, userid, dealcode);


         }


    }

    public void bindcurrency()
    {

          DataSet ds = new DataSet();
         if(ConfigurationSettings.AppSettings ["ConnectionType"].ToString ()=="sql")
                {
        NewAdbooking.Classes.Contract curr = new NewAdbooking.Classes.Contract();
      
        ds = curr.currencybind(Session["compcode"].ToString(), Session["userid"].ToString());
         }
         else
             if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
             {
                 NewAdbooking.classesoracle.Contract curr = new NewAdbooking.classesoracle.Contract();

                 ds = curr.currencybind(Session["compcode"].ToString(), Session["userid"].ToString());
 
             }
         else
         {
                     NewAdbooking.classmysql.Contract curr = new NewAdbooking.classmysql.Contract();
      
        ds = curr.currencybind(Session["compcode"].ToString(), Session["userid"].ToString());


         }

        drpcurr.Items.Clear();
        drpcurr_elec.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "-Select Currency-";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        drpcurr.Items.Add(li1);
        drpcurr_elec.Items.Add(li1);
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ListItem li;
                li = new ListItem();
                li.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                li.Value = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                drpcurr.Items.Add(li);
                drpcurr_elec.Items.Add(li);
            }

        }

    }

    //protected void drppackagecode_SelectedIndexChanged(object sender, EventArgs e)
    //{
         
    //    string packagecode = drppackagecode.SelectedValue;

    //    DataSet ds = new DataSet();
    //    if(ConfigurationSettings.AppSettings ["ConnectionType"].ToString ()=="sql")
    //            {
    //    NewAdbooking.Classes.Contract binddescrip = new NewAdbooking.Classes.Contract();
        
    //    ds = binddescrip.description(packagecode, Session["compcode"].ToString(), Session["userid"].ToString());
    //    }
    //    else
    //        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
    //        {
    //            NewAdbooking.classesoracle.Contract binddescrip = new NewAdbooking.classesoracle.Contract();

    //            ds = binddescrip.description(packagecode, Session["compcode"].ToString(), Session["userid"].ToString());

    //        }
    //    else
    //    {
    //                NewAdbooking.classmysql .Contract binddescrip = new NewAdbooking.classmysql.Contract();
        
    //    ds = binddescrip.description(packagecode, Session["compcode"].ToString(), Session["userid"].ToString());


    //    }

    //    chbcyop.Enabled = false;
    //    if (packagecode == "0")
    //    {
    //        //drppublication.Enabled = true;
    //        //drpedition.Enabled = true;
    //        //drpsuppliment.Enabled = true;
    //        drpbooked.Text = "";
    //        //chbcyop.Enabled = true;
    //        return;

    //    }

    //    if (packagecode == "cyop")
    //    {
    //        drpbooked.Text = "";
    //        ScriptManager.RegisterStartupScript(this, typeof(ContractDetail), "ss", "cyop();", true);
    //        if (hideopen.Value == "0")
    //        {
    //            drpbooked.Text = hiddencyop.Value;
    //        }
    //        return;

    //    }

    //    if (ds.Tables[0].Rows.Count >= 0)
    //    {
    //        //drpbooked.Items.Clear();
    //        drpbooked.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
    //        ////////////this is to get the package rate if selected
    //        if (drpadvcat.SelectedValue != "0" && drpuom.SelectedValue != "0" && drpcolor.SelectedValue != "0" && drpcurr.SelectedValue != "0")
    //        {
    //            string adcat = drpadvcat.SelectedValue;
    //            string pkgcode = drppackagecode.SelectedValue;
    //            string color = drpcolor.SelectedValue;
    //            string currency = drpcurr.SelectedValue;
    //            string uom = drpuom.SelectedValue;
    //            datesave getdatformat = new datesave();
    //            string validfrom = getdatformat.getDate(Session["dateformat"].ToString(), datefrom);
    //            string validto = getdatformat.getDate(Session["dateformat"].ToString(), dateto);

    //            DataSet dcon = new DataSet();
    //            if(ConfigurationSettings .AppSettings ["ConnectionType"].ToString()=="sql")
    //            {

    //            NewAdbooking.Classes.Contract getpkgrate = new NewAdbooking.Classes.Contract();
                
    //            dcon = getpkgrate.getrateforcontract(adcat, pkgcode, color, currency, uom, advtype, validfrom, validto, Session["compcode"].ToString());
    //            }
    //            else
    //                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
    //                {
    //                    NewAdbooking.classesoracle.Contract getpkgrate = new NewAdbooking.classesoracle.Contract();

    //                    dcon = getpkgrate.getrateforcontract(adcat, pkgcode, color, currency, uom, advtype, validfrom, validto, Session["compcode"].ToString(),Session["dateformat"].ToString());

    //                }

    //            else
    //            {
    //              NewAdbooking.classmysql .Contract getpkgrate = new NewAdbooking.classmysql.Contract();
                
    //            dcon = getpkgrate.getrateforcontract(adcat, pkgcode, color, currency, uom, advtype, validfrom, validto, Session["compcode"].ToString());

    //            }

    //            if (dcon.Tables[0].Rows.Count > 0)
    //            {
    //                txtcardrate.Text = dcon.Tables[0].Rows[0].ItemArray[0].ToString();

    //            }


    //        }
    //    }
    //    else
    //    {
    //        message = "There is no matching data";
    //        AspNetMessageBox(message);
    //        return;
    //    }
        
  
        




    //}
    protected void btnclick_Click(object sender, EventArgs e)
    {

    }
    [Ajax.AjaxMethod]
    public void insertvalue(string dealno, string advcat, string publication, string drpsuppliment, string drpedition, string bookedfor, string color, string cardrate, string dealrate, string premium, string cardprem, string dealprem, string volbilled, string voldisc, string valfrom, string valto, string uom, string package, string compcode, string userid, string totalrate, string currency, string editionaldisc, string flag, string quantity, string weight, string free, string cyoppac, string deviation, string remarks, string sizefrom, string sizeto, string disctype, string discper, string insertion, string dayname, string comm_allow, string deal_start, string incentive)
    {
        //DataSet dz = new DataSet();
        if(ConfigurationSettings.AppSettings ["ConnectionType"].ToString ()=="sql")
        {
            NewAdbooking.Classes.Contract insert = new NewAdbooking.Classes.Contract();
            insert.insertdetail(dealno, advcat, publication, drpsuppliment, drpedition, bookedfor, color, cardrate, dealrate, premium, cardprem, dealprem, volbilled, voldisc, valfrom, valto, uom, package, compcode, userid, totalrate, currency, editionaldisc, flag, quantity, weight, free, cyoppac, deviation, remarks, sizefrom, sizeto, disctype, discper, insertion, dayname, comm_allow, deal_start, incentive);
        }
        else
           if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
           {
                 NewAdbooking.classesoracle.Contract insert = new NewAdbooking.classesoracle.Contract();
                 insert.insertdetail(dealno, advcat, publication, drpsuppliment, drpedition, bookedfor, color, cardrate, dealrate, premium, cardprem, dealprem, volbilled, voldisc, valfrom, valto, uom, package, compcode, userid, totalrate, currency, editionaldisc, flag, quantity, weight, free, cyoppac, deviation, remarks, sizefrom, sizeto, disctype, discper, insertion, dayname, comm_allow, deal_start, incentive);
           }
           else
           {
                NewAdbooking.classmysql .Contract insert = new NewAdbooking.classmysql.Contract();        
                insert.insertdetail(dealno, advcat, publication, drpsuppliment, drpedition, bookedfor, color, cardrate, dealrate, premium, cardprem, dealprem, volbilled, voldisc, valfrom, valto, uom, package, compcode, userid, totalrate, currency, editionaldisc, flag, quantity, weight, free, cyoppac, deviation); 
           }
    }

    [Ajax.AjaxMethod]
    public void updatevalue(string dealno, string advcat, string publication, string drpsuppliment, string drpedition, string bookedfor, string color, string cardrate, string dealrate, string premium, string cardprem, string dealprem, string volbilled, string voldisc, string valfrom, string valto, string uom, string package, string compcode, string userid, string code, string totalrate, string currency, string editdisc, string flag, string quantity, string weight, string free, string cyoppac, string deviation, string remarks, string sizefrom, string sizeto, string disctype, string discper, string insertion, string dayname, string comm_allow, string deal_start, string incentive)
    {DataSet dz = new DataSet();

         if(ConfigurationSettings.AppSettings ["ConnectionType"].ToString ()=="sql")
                {
        NewAdbooking.Classes.Contract update = new NewAdbooking.Classes.Contract();

        dz = update.updatedetail(dealno, advcat, publication, drpsuppliment, drpedition, bookedfor, color, cardrate, dealrate, premium, cardprem, dealprem, volbilled, voldisc, valfrom, valto, uom, package, compcode, userid, code, totalrate, currency, editdisc, flag, quantity, weight, free, cyoppac, deviation, remarks, sizefrom, sizeto, disctype, discper, insertion, dayname, comm_allow, deal_start, incentive);
         }
         else
             if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
             {
                 NewAdbooking.classesoracle.Contract update = new NewAdbooking.classesoracle.Contract();

                 dz = update.updatedetail(dealno, advcat, publication, drpsuppliment, drpedition, bookedfor, color, cardrate, dealrate, premium, cardprem, dealprem, volbilled, voldisc, valfrom, valto, uom, package, compcode, userid, code, totalrate, currency, editdisc, flag, quantity, weight, free, cyoppac, deviation, remarks, sizefrom, sizeto, disctype, discper, insertion, dayname, comm_allow, deal_start, incentive);
 
             }
         else
         {
                     NewAdbooking.classmysql .Contract update = new NewAdbooking.classmysql.Contract();
        
        dz = update.updatedetail(dealno, advcat, publication, drpsuppliment, drpedition, bookedfor, color, cardrate, dealrate, premium, cardprem, dealprem, volbilled, voldisc, valfrom, valto, uom, package, compcode, userid, code, totalrate, currency, editdisc, flag, quantity, weight, free, cyoppac, deviation);


         }


    }
    [Ajax.AjaxMethod]
    public string chkduplicacy(string a_gency,string c_lient,string p_roduct,string c_ompcode,string a_dtype,string ad_cat,string pkg_code,string rate_code,string c_olor,string mod,string mod_detail,string day1)
    {
        string f_lag = "0";
        string up_fl = "0";
        DataSet de = new DataSet();
         if(ConfigurationSettings.AppSettings ["ConnectionType"].ToString ()=="sql")
         {
            NewAdbooking.Classes.Contract chkfrommast = new NewAdbooking.Classes.Contract();        
            de = chkfrommast.chkunique(a_gency, c_lient, p_roduct, c_ompcode,a_dtype, mod);
         }
         else
             if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
             {
                 NewAdbooking.classesoracle.Contract chkfrommast = new NewAdbooking.classesoracle.Contract();
                 de = chkfrommast.chkunique(a_gency, c_lient, p_roduct, c_ompcode, a_dtype, mod);
             }
            else
            {
                NewAdbooking.classmysql.Contract chkfrommast = new NewAdbooking.classmysql.Contract();        
                de = chkfrommast.chkunique(a_gency, c_lient, p_roduct, c_ompcode,a_dtype, mod);
            }

            DataSet da=new DataSet();
            if(ConfigurationSettings.AppSettings ["ConnectionType"].ToString ()=="sql")
            {
                NewAdbooking.Classes.Contract chkfromdet = new NewAdbooking.Classes.Contract();
                da = chkfromdet.chkuniquedetail(ad_cat, pkg_code, rate_code, c_olor, c_ompcode, mod_detail, day1);
            }
            else
              if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
              {
                  NewAdbooking.classesoracle.Contract chkfromdet = new NewAdbooking.classesoracle.Contract();
                  da = chkfromdet.chkuniquedetail(ad_cat, pkg_code, rate_code, c_olor, c_ompcode, mod_detail, day1);
              }
              else
              {
                  NewAdbooking.classmysql.Contract chkfromdet = new NewAdbooking.classmysql.Contract();       
                  da = chkfromdet.chkuniquedetail(ad_cat, pkg_code, rate_code, c_olor, c_ompcode, mod_detail);
              }
              if (de.Tables[0].Rows.Count > 0 && da.Tables[0].Rows.Count > 0)
              {
                    f_lag="1";
              }
              return (f_lag);
    }

    protected void btnselect_Click(object sender, EventArgs e)
    {   
        DataColumn mycolumn;
        DataTable mydatatable = new DataTable();
        DataRow myrow;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "Advcategory";
        mydatatable.Columns.Add(mycolumn);

        // //DataColumn mycolumn;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "publication";
        mydatatable.Columns.Add(mycolumn);

        ////DataColumn mycolumn;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "suppliment";
        mydatatable.Columns.Add(mycolumn);

        // //DataColumn mycolumn;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "Bookedfor";
        mydatatable.Columns.Add(mycolumn);

        ////DataColumn mycolumn;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "color";
        mydatatable.Columns.Add(mycolumn);

        // //DataColumn mycolumn;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "cardrate";
        mydatatable.Columns.Add(mycolumn);

        ////DataColumn mycolumn;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "Dealarte";
        mydatatable.Columns.Add(mycolumn);

        //DataColumn mycolumn;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "premiumcode";
        mydatatable.Columns.Add(mycolumn);

        //DataColumn mycolumn;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "cardpremium";
        mydatatable.Columns.Add(mycolumn);

        //DataColumn mycolumn;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "dealpremium";
        mydatatable.Columns.Add(mycolumn);

        //DataColumn mycolumn;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "volumebilled";
        mydatatable.Columns.Add(mycolumn);

        //DataColumn mycolumn;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "volumedisc";
        mydatatable.Columns.Add(mycolumn);

        //DataColumn mycolumn;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "valuefrom";
        mydatatable.Columns.Add(mycolumn);

        //DataColumn mycolumn;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "valueto";
        mydatatable.Columns.Add(mycolumn);

        //DataColumn mycolumn;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "Uom";
        mydatatable.Columns.Add(mycolumn);

        //DataColumn mycolumn;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "packagecode";
        mydatatable.Columns.Add(mycolumn);

        //DataColumn mycolumn;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "deal_code";
        mydatatable.Columns.Add(mycolumn);

        //DataColumn mycolumn;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "comp_code";
        mydatatable.Columns.Add(mycolumn);

        //DataColumn mycolumn;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "userid";
        mydatatable.Columns.Add(mycolumn);

        //DataColumn mycolumn;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "edition";
        mydatatable.Columns.Add(mycolumn);

        //DataColumn mycolumn;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "convertrate";
        mydatatable.Columns.Add(mycolumn);

        //DataColumn mycolumn;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "currency";
        mydatatable.Columns.Add(mycolumn);

        //DataColumn mycolumn;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "Rate_code";
        mydatatable.Columns.Add(mycolumn);

        //DataColumn mycolumn;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "approved";
        mydatatable.Columns.Add(mycolumn);

        //DataColumn mycolumn;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "quantity";
        mydatatable.Columns.Add(mycolumn);

        //DataColumn mycolumn;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "weight";
        mydatatable.Columns.Add(mycolumn);

        //DataColumn mycolumn;
        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "discounted";
        mydatatable.Columns.Add(mycolumn);

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "ContractCode";
        mydatatable.Columns.Add(mycolumn);

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "Cyop";
        mydatatable.Columns.Add(mycolumn);

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "deviation";
        mydatatable.Columns.Add(mycolumn);

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "REMARKS";
        mydatatable.Columns.Add(mycolumn);

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "SIZEFROM";
        mydatatable.Columns.Add(mycolumn);

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "SIZETO";
        mydatatable.Columns.Add(mycolumn);

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "DISCTYPE";
        mydatatable.Columns.Add(mycolumn);

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "DISCPER";
        mydatatable.Columns.Add(mycolumn);

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "INSERTION";
        mydatatable.Columns.Add(mycolumn);

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "DAYNAME";
        mydatatable.Columns.Add(mycolumn);

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "COMMITION_ALLOW";
        mydatatable.Columns.Add(mycolumn);

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "DEAL_START";
        mydatatable.Columns.Add(mycolumn);

        mycolumn = new DataColumn();
        mycolumn.DataType = System.Type.GetType("System.String");
        mycolumn.ColumnName = "INCENTIVE";
        mydatatable.Columns.Add(mycolumn);

        myrow = mydatatable.NewRow();

        DataSet de = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Contract chkfrommast = new NewAdbooking.Classes.Contract();            
            de = chkfrommast.chkunique(con_agency, con_client, con_prod, Session["compcode"].ToString(), advtype, "save");
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.Contract chkfrommast = new NewAdbooking.classesoracle.Contract();
                de = chkfrommast.chkunique(con_agency, con_client, con_prod, Session["compcode"].ToString(), advtype, "save");
            }
        else
        {
            NewAdbooking.classmysql.Contract chkfrommast = new NewAdbooking.classmysql.Contract();
            de = chkfrommast.chkunique(con_agency, con_client, con_prod, Session["compcode"].ToString(), advtype, "save");
        }

        DataSet da = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            NewAdbooking.Classes.Contract chkfromdet = new NewAdbooking.Classes.Contract();
            da = chkfromdet.chkuniquedetail(drpadvcat_var.Value, drppackagecode_var.Value, drpratecode.SelectedValue, drpcolor.SelectedValue, Session["compcode"].ToString(), "save", drpday.SelectedValue);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.Contract chkfromdet = new NewAdbooking.classesoracle.Contract();
                da = chkfromdet.chkuniquedetail(drpadvcat_var.Value, drppackagecode_var.Value, drpratecode.SelectedValue, drpcolor.SelectedValue, Session["compcode"].ToString(), "save",drpday.SelectedValue);
            }
        else
        {
            NewAdbooking.classmysql.Contract chkfromdet = new NewAdbooking.classmysql.Contract();
            da = chkfromdet.chkuniquedetail(drpadvcat_var.Value, drppackagecode_var.Value, drpratecode.SelectedValue, drpcolor.SelectedValue, Session["compcode"].ToString(), "save");
        }

        if (de.Tables[0].Rows.Count > 0 && da.Tables[0].Rows.Count > 0)
        {
            string ale = "Duplicate contract not allowed";
            AspNetMessageBox(ale);
            return;
        }

        myrow["INCENTIVE"] = txtincentive.Text;
        myrow["COMMITION_ALLOW"] = drpcommallow.SelectedValue;
        myrow["DEAL_START"] = drpdealstrt.SelectedValue;
        myrow["Advcategory"] = drpadvcat_var.Value;
        myrow["publication"] = drppublication.SelectedValue;
        myrow["suppliment"] = drpsuppliment.SelectedValue;
        if (drpbooked.Text == "")
            myrow["Bookedfor"] = hiddenpackagedesc.Value;
        else
            myrow["Bookedfor"] = drpbooked.Text;
        myrow["color"] = drpcolor.SelectedValue;
        if (txtcardrate.Text == "")
            myrow["cardrate"] = hiddencardrate.Value;
        else
            myrow["cardrate"] = txtcardrate.Text;
        myrow["Dealarte"] = txtdealrate.Text;
        myrow["premiumcode"] = drppremium_var.Value;        
        myrow["cardpremium"] = txtcardpremium.Text;
        myrow["dealpremium"] = txtdealpremium.Text;
        myrow["volumebilled"] = txtvolbilled.Text;
        myrow["volumedisc"] = txtvoldisc.Text;
        myrow["valuefrom"] = txtvalfrom.Text;
        myrow["valueto"] = txtvalto.Text;
        myrow["Uom"] = drpuom_var.Value;
        myrow["packagecode"] = drppackagecode_var.Value;
        myrow["deal_code"] = dealno;
        myrow["comp_code"] = Session["compcode"].ToString();
        myrow["userid"] = Session["userid"].ToString();
        myrow["edition"] = drpedition.SelectedValue;
        myrow["convertrate"] = txttotal.Text;
        myrow["currency"] = drpcurr.SelectedValue;
        myrow["Rate_code"] = drpratecode.SelectedValue;
        if (ckbapproved.Checked == true)
        {
            myrow["approved"] = "Y";
        }
        else
        {
            myrow["approved"] = "N";
        }

        myrow["quantity"] = txtquantity.Text;
        myrow["weight"] = txtweight.Text;
        myrow["discounted"] = drpdisc.SelectedValue;
        myrow["ContractCode"] = "1";
        myrow["Cyop"] = hiddencyop.Value;
        if (txtdeviation.Text == "")
            myrow["deviation"] = hiddendeviation.Value;
        else
            myrow["deviation"] = txtdeviation.Text;
        myrow["REMARKS"] = txtremark.Text;
        myrow["SIZEFROM"] = txtsizefrom.Text;
        myrow["SIZETO"] = txtsizeto.Text;
        myrow["DISCTYPE"] = drpdisctype.SelectedValue;
        myrow["DISCPER"] = txtdiscamount.Text;
        myrow["INSERTION"] = txtinsertion.Text;
        myrow["DAYNAME"] = drpday.SelectedValue;

        mydatatable.Rows.Add(myrow);
     
       dk.Tables.Add(mydatatable);

       if (dk.Tables.Count > 1)
       {
           if (dk.Tables.Count > 0 && dk.Tables[0] != null)
           {
               for (int i_ = 1; i_ < dk.Tables.Count; i_++)
               {
                   if (dk.Tables[i_].Rows[0].ItemArray[0].ToString() == dk.Tables[i_ - 1].Rows[0].ItemArray[0].ToString() && dk.Tables[i_].Rows[0].ItemArray[15].ToString() == dk.Tables[i_ - 1].Rows[0].ItemArray[15].ToString() && dk.Tables[i_].Rows[0].ItemArray[22].ToString() == dk.Tables[i_ - 1].Rows[0].ItemArray[22].ToString() && dk.Tables[i_].Rows[0].ItemArray[4].ToString() == dk.Tables[i_-1].Rows[0].ItemArray[4].ToString())
                   {
                       string ale = "Duplicate contract not allowed";
                       AspNetMessageBox(ale);
                      // dk.Tables[i_].Rows[0].Delete();
                       dk.Tables.Remove(mydatatable);
                       return;
                   }
               }

           }
       }
       
        Session["valueinsert"] = dk;
        /////////////////this is used for grid

        DataColumn mycolumn1;
        DataTable mydatatable1 = new DataTable();
        DataRow myrow1;
        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "Advcategory";
        mydatatable1.Columns.Add(mycolumn1);

        // //DataColumn mycolumn1;
        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "publication";
        mydatatable1.Columns.Add(mycolumn1);

        ////DataColumn mycolumn1;
        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "suppliment";
        mydatatable1.Columns.Add(mycolumn1);

        // //DataColumn mycolumn1;
        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "Bookedfor";
        mydatatable1.Columns.Add(mycolumn1);

        ////DataColumn mycolumn1;
        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "color";
        mydatatable1.Columns.Add(mycolumn1);

        // //DataColumn mycolumn1;
        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "cardrate";
        mydatatable1.Columns.Add(mycolumn1);

        ////DataColumn mycolumn1;
        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "Dealarte";
        mydatatable1.Columns.Add(mycolumn1);

        //DataColumn mycolumn1;
        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "premiumcode";
        mydatatable1.Columns.Add(mycolumn1);

        //DataColumn mycolumn1;
        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "cardpremium";
        mydatatable1.Columns.Add(mycolumn1);

        //DataColumn mycolumn1;
        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "dealpremium";
        mydatatable1.Columns.Add(mycolumn1);

        //DataColumn mycolumn1;
        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "volumebilled";
        mydatatable1.Columns.Add(mycolumn1);

        //DataColumn mycolumn1;
        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "volumedisc";
        mydatatable1.Columns.Add(mycolumn1);

        //DataColumn mycolumn1;
        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "valuefrom";
        mydatatable1.Columns.Add(mycolumn1);

        //DataColumn mycolumn1;
        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "valueto";
        mydatatable1.Columns.Add(mycolumn1);

        //DataColumn mycolumn1;
        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "Uom";
        mydatatable1.Columns.Add(mycolumn1);

        //DataColumn mycolumn1;
        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "packagecode";
        mydatatable1.Columns.Add(mycolumn1);

        //DataColumn mycolumn1;
        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "deal_code";
        mydatatable1.Columns.Add(mycolumn1);

        //DataColumn mycolumn1;
        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "comp_code";
        mydatatable1.Columns.Add(mycolumn1);

        //DataColumn mycolumn1;
        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "userid";
        mydatatable1.Columns.Add(mycolumn1);

        //DataColumn mycolumn1;
        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "edition";
        mydatatable1.Columns.Add(mycolumn1);

        //DataColumn mycolumn1;
        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "convertrate";
        mydatatable1.Columns.Add(mycolumn1);

        //DataColumn mycolumn1;
        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "currency";
        mydatatable1.Columns.Add(mycolumn1);

        //DataColumn mycolumn1;
        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "Rate_code";
        mydatatable1.Columns.Add(mycolumn1);

        //DataColumn mycolumn1;
        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "approved";
        mydatatable1.Columns.Add(mycolumn1);

        //DataColumn mycolumn1;
        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "quantity";
        mydatatable1.Columns.Add(mycolumn1);

        //DataColumn mycolumn1;
        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "weight";
        mydatatable1.Columns.Add(mycolumn1);

        //DataColumn mycolumn1;
        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "discounted";
        mydatatable1.Columns.Add(mycolumn1);

        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "ContractCode";
        mydatatable1.Columns.Add(mycolumn1);

        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "Cyop";
        mydatatable1.Columns.Add(mycolumn1);

        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "deviation";
        mydatatable1.Columns.Add(mycolumn1);

        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "REMARKS";
        mydatatable1.Columns.Add(mycolumn1);

        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "SIZEFROM";
        mydatatable1.Columns.Add(mycolumn1);

        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "SIZETO";
        mydatatable1.Columns.Add(mycolumn1);

        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "DISCTYPE";
        mydatatable1.Columns.Add(mycolumn1);

        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "DISCPER";
        mydatatable1.Columns.Add(mycolumn1);

        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "INSERTION";
        mydatatable1.Columns.Add(mycolumn1);

        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "DAYNAME";
        mydatatable1.Columns.Add(mycolumn1);

        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "COMMITION_ALLOW";
        mydatatable1.Columns.Add(mycolumn1);

        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "DEAL_START";
        mydatatable1.Columns.Add(mycolumn1);

        mycolumn1 = new DataColumn();
        mycolumn1.DataType = System.Type.GetType("System.String");
        mycolumn1.ColumnName = "INCENTIVE";
        mydatatable1.Columns.Add(mycolumn1);

        myrow1 = mydatatable1.NewRow();

        myrow1["COMMITION_ALLOW"] = drpcommallow.SelectedValue;
        nextcomm_allow = drpcommallow.SelectedValue;

        myrow1["DEAL_START"] = drpdealstrt.SelectedValue;
        nextdeal_start = drpdealstrt.SelectedValue;

        myrow1["INCENTIVE"] = txtincentive.Text;
        nextdeal_incentive = txtincentive.Text;

        if (drpadvcat_var.Value == "0" || drpadvcat_var.Value == "")
        {
            myrow1["Advcategory"] = drpadvcat_var.Value;
        }
        else
        {
            myrow1["Advcategory"] = drpadvcattext_var.Value;
        }
        nextadcategory = drpadvcat_var.Value;

        if (drppublication.SelectedValue == "0")
        {
            myrow1["publication"] = drppublication.SelectedValue;
        }
        else
        {
            myrow1["publication"] = drppublication.SelectedValue;
        }

        nextpublication = drppublication.SelectedValue;

        if (drpsuppliment.SelectedValue == "" || drpsuppliment.SelectedValue == "0")
        {
            myrow1["suppliment"] = drpsuppliment.SelectedValue;
        }
        else
        {
            myrow1["suppliment"] = drpsuppliment.SelectedValue;
        }
        nextsupp = drpsuppliment.SelectedValue;
        if (drpbooked.Text == "")
            myrow1["Bookedfor"] = hiddenpackagedesc.Value;
        else
            myrow1["Bookedfor"] = drpbooked.Text;
        nextbooked = drpbooked.Text;
        if (drpcolor.SelectedValue == "0")
        {
            myrow1["color"] = drpcolor.SelectedValue;
        }
        else
        {
            myrow1["color"] = drpcolor.SelectedItem.Text;
        }
        nextcolor = drpcolor.SelectedValue;
        if (txtcardrate.Text == "")
            myrow1["cardrate"] = hiddencardrate.Value;
        else
            myrow1["cardrate"] = txtcardrate.Text;
        nextcardrate = txtcardrate.Text;
        myrow1["Dealarte"] = txtdealrate.Text;
        nextdealrate = txtdealrate.Text;
        if (drppremium_var.Value == "0" || drppremium_var.Value == "")
        {
            myrow1["premiumcode"] = drppremium_var.Value;
        }
        else
        {
            myrow1["premiumcode"] = drppremiumtext_var.Value;
        }
        nextpremiumcode = drppremium_var.Value;
        myrow1["cardpremium"] = txtcardpremium.Text;
        nextcardprmum = txtdealpremium.Text;
        myrow1["dealpremium"] = txtdealpremium.Text;
        nextdealpre = txtdealpremium.Text;
        myrow1["volumebilled"] = txtvolbilled.Text;
        nextvolumebilled = txtvolbilled.Text;
        myrow1["volumedisc"] = txtvoldisc.Text;
        nextvoldisc = txtvoldisc.Text;
        myrow1["valuefrom"] = txtvalfrom.Text;
        nextvalfrom = txtvalfrom.Text;
        myrow1["valueto"] = txtvalto.Text;
        nextvalto = txtvalto.Text;
        if (drpuom_var.Value == "0" || drpuom_var.Value == "")
        {
            myrow1["Uom"] = drpuom_var.Value;
        }
        else
        {
            myrow1["Uom"] = drpuomtext_var.Value;
        }
        nextuom = drpuom_var.Value;
        if (drppackagecode_var.Value == "0" || drppackagecode_var.Value == "")
        {
            myrow1["packagecode"] = drppackagecode_var.Value;
        }
        else
        {
            myrow1["packagecode"] = drppackagecodetext_var.Value;
        }
        myrow1["deal_code"] = dealno;
     
        myrow1["comp_code"] = Session["compcode"].ToString();
        myrow1["userid"] = Session["userid"].ToString();
        if (drpedition.SelectedValue == "" || drpedition.SelectedValue == "0")
        {
            myrow1["edition"] = drpedition.SelectedValue;
        }
        else
        {
            myrow1["edition"] = drpedition.SelectedValue;
        }
        nexteditrion = drpedition.SelectedValue;
        myrow1["convertrate"] = txttotal.Text;
        nextconvertrate = txttotal.Text;
        myrow1["currency"] = drpcurr.SelectedItem.Text;
        nextcurrency = drpcurr.SelectedValue;
        myrow1["Rate_code"] = drpratecode.SelectedValue;
        nexteditionaldisc = drpratecode.SelectedValue;
        if (ckbapproved.Checked == true)
        {
            myrow1["approved"] = "Y";
        }
        else
        {
            myrow1["approved"] = "N";
        }
        nextapproved = ckbapproved.Text;
        myrow1["quantity"] = txtquantity.Text;
        nextquantity = txtquantity.Text;
        myrow1["weight"] = txtweight.Text;
        nextweight = txtweight.Text;
        if (drpdisc.SelectedValue == "0")
        {
            myrow1["discounted"] = drpdisc.SelectedValue;
        }
        else
        {
            myrow1["discounted"] = drpdisc.SelectedItem.Text;
        }
        nextdiscount = drpdisc.SelectedValue;
        myrow1["ContractCode"] = "1";
        myrow1["Cyop"]=hiddencyop.Value;
        if (txtdeviation.Text == "")
            myrow1["deviation"] = hiddendeviation.Value;
        else
            myrow1["deviation"] = txtdeviation.Text;

        myrow1["REMARKS"] = txtremark.Text;
        myrow1["SIZEFROM"] = txtsizefrom.Text;
        myrow1["SIZETO"] = txtsizeto.Text;
        myrow1["DISCTYPE"] = drpdisctype.SelectedValue;
        myrow1["DISCPER"] = txtdiscamount.Text;
        myrow1["INSERTION"] = txtinsertion.Text;
        myrow1["DAYNAME"] = drpday.SelectedValue;

        mydatatable1.Rows.Add(myrow1);
        if (dk1 == null)
            dk1 = new DataSet();
        dk1.Tables.Add(mydatatable1);
        //////////////////////////////////////////////////////////////////////


        drpadvcat.SelectedValue="0";
        drppublication.SelectedValue="0";
        drpsuppliment.Items.Clear();
        drpbooked.Text="";
        hiddenpackagedesc.Value = "";
        drpcolor.SelectedValue="0";
        txtcardrate.Text="";
        hiddencardrate.Value = "";
        txtdealrate.Text="";
        drppremium.SelectedValue="0";
        txtdealpremium.Text="";
        txtdealpremium.Text="";
        txtvolbilled.Text="";
        txtvoldisc.Text="";
        txtvalfrom.Text="";
        txtvalto.Text="";
        drpuom.SelectedValue="0";
        drppackagecode.SelectedValue="0";
        txtcardpremium.Text = "";
       // myrow["deal_code"] = dealno;
        //myrow["comp_code"] = Session["compcode"].ToString();
        //myrow["userid"] = Session["userid"].ToString();
        drpedition.Items.Clear();
        txttotal.Text="";
       // myrow["currency"] = drpcurr.SelectedValue;
        drpratecode.SelectedValue="0";
        ckbapproved.Checked = false;
        txtquantity.Text="";
        txtdeviation.Text = "";
        hiddendeviation.Value = "";
        txtweight.Text="";
        drpdisc.SelectedValue="0";
        hiddencyop.Value = "";
        txtremark.Text = "";
        txtsizefrom.Text = "";
        txtsizeto.Text = "";
        txtdiscamount.Text = "";
        drpdisctype.SelectedValue = "0";
        txtinsertion.Text = "";
        txtincentive.Text = "";
        drpday.SelectedValue = "0";
        //bindgridview("Advcategory");
        bindgridview1();
        drppackagecode_var.Value = "";
        drpuom_var.Value = "";
        drpadvcat_var.Value = "";
        drppremium_var.Value = "";
        drppackagecodetext_var.Value = "";
        drpuomtext_var.Value = "";
        drpadvcattext_var.Value = "";
        drppremiumtext_var.Value = "";
    }
    protected void Datagrid1_ItemDataBound(object sender, DataGridItemEventArgs e)
    {

    }
    protected void btnclose_Click(object sender, EventArgs e)
    {
        //dk.Clear();
        
//        dk.Tables.Clear();
        //Session["valueinsert"] = null;
     //   return;
    }
    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    public string chksession()
    {
        string sessioncurrent;
        if (HttpContext.Current.Session["compcode"] == null)
        {
            sessioncurrent = null;
        }
        else
        {
            sessioncurrent = "1";
        }
        return sessioncurrent;


    }


    public void bindadtype()
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
        else
        {
            NewAdbooking.classmysql.CombinationMaster bind = new NewAdbooking.classmysql.CombinationMaster();
            ds = bind.adtypbind(Session["compcode"].ToString());
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
 
    //protected void drpuom_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    ////////////this is to get the package rate if selected
    //    if (drpadvcat.SelectedValue != "0" && drppackagecode.SelectedValue != "0" && drpcolor.SelectedValue != "0" && drpcurr.SelectedValue != "0")
    //    {
    //        string adcat = drpadvcat.SelectedValue;
    //        string pkgcode = drppackagecode.SelectedValue;
    //        string color = drpcolor.SelectedValue;
    //        string currency = drpcurr.SelectedValue;
    //        string uom = drpuom.SelectedValue;
    //        datesave getdatformat=new datesave();
    //        string validfrom = getdatformat.getDate(Session["dateformat"].ToString(), datefrom);
    //        string validto = getdatformat.getDate(Session["dateformat"].ToString(), dateto);

    //        DataSet dcon = new DataSet();
    //        if(ConfigurationSettings .AppSettings ["ConnectionType"].ToString ()=="sql")
    //        {

    //        NewAdbooking.Classes.Contract getpkgrate = new NewAdbooking.Classes.Contract();
         
    //        dcon = getpkgrate.getrateforcontract(adcat, pkgcode, color, currency, uom, advtype, validfrom, validto, Session["compcode"].ToString());
    //        }
    //        else
    //            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
    //            {
    //                NewAdbooking.classesoracle.Contract getpkgrate = new NewAdbooking.classesoracle.Contract();

    //                dcon = getpkgrate.getrateforcontract(adcat, pkgcode, color, currency, uom, advtype, validfrom, validto, Session["compcode"].ToString(),Session["dateformat"].ToString());

    //            }
    //        else
    //        {
    //            NewAdbooking.classmysql.Contract getpkgrate = new NewAdbooking.classmysql.Contract();

    //            dcon = getpkgrate.getrateforcontract(adcat, pkgcode, color, currency, uom, advtype, validfrom, validto, Session["compcode"].ToString());

    //        }

    //        if (dcon.Tables[0].Rows.Count > 0)
    //        {
    //            txtcardrate.Text = dcon.Tables[0].Rows[0].ItemArray[0].ToString();

    //        }
            

    //    }
    //}
    [Ajax.AjaxMethod]
    public DataSet getrateforcontract(string adcat,string  pkgcode,string color,string  currency,string  uom,string  advtype, string validfrom, string validto, string compcode, string dateformat)
    {
        DataSet dcon = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Contract getpkgrate = new NewAdbooking.Classes.Contract();
            dcon = getpkgrate.getrateforcontract(adcat, pkgcode, color, currency, uom, advtype, validfrom, validto, compcode,dateformat,"");
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.Contract getpkgrate = new NewAdbooking.classesoracle.Contract();
                dcon = getpkgrate.getrateforcontract(adcat, pkgcode, color, currency, uom, advtype, validfrom, validto,compcode,dateformat,"");
            }
            else
            {
                NewAdbooking.classmysql.Contract getpkgrate = new NewAdbooking.classmysql.Contract();
                dcon = getpkgrate.getrateforcontract(adcat, pkgcode, color, currency, uom, advtype, validfrom, validto, compcode);
            }
        return dcon;
    }

    [Ajax.AjaxMethod]
    public DataSet editionbind(string compcode,string pubcode)
    {
         DataSet ds = new DataSet();
         if(ConfigurationSettings.AppSettings ["ConnectionType"].ToString ()=="sql")
         {
            NewAdbooking.Classes.Contract bindeditionfor = new NewAdbooking.Classes.Contract();
            ds = bindeditionfor.editionbind(compcode, pubcode);
         }

         else
             if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
             {
                 NewAdbooking.classesoracle.Contract bindeditionfor = new NewAdbooking.classesoracle.Contract();
                 ds = bindeditionfor.editionbind(compcode, pubcode);
             }
         else
         {
            NewAdbooking.classmysql.Contract bindeditionfor = new NewAdbooking.classmysql.Contract();
            ds = bindeditionfor.editionbind(compcode, pubcode);
         }
     return ds;
    }
    public void bindProgramType(string compcode,string channel)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            // NewAdbooking.Classes.Contract binduom = new NewAdbooking.Classes.Contract();
            // ds = binduom.bindChannel_TV(Session["compcode"].ToString());
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.Contract binduom = new NewAdbooking.classesoracle.Contract();
                ds = binduom.bindProgramType_TV(compcode,channel);
            }
            else
            {
                //  NewAdbooking.classmysql.Contract binduom = new NewAdbooking.classmysql.Contract();
                // ds = binduom.uombind(Session["compcode"].ToString(), Session["userid"].ToString());

            }
        drpprogramtype.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "-Select Program Type-";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        drpprogramtype.Items.Add(li1);
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ListItem li;
                li = new ListItem();
                li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                drpprogramtype.Items.Add(li);
            }

        }

    }
    public void bindLocation(string compcode)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            // NewAdbooking.Classes.Contract binduom = new NewAdbooking.Classes.Contract();
            // ds = binduom.bindChannel_TV(Session["compcode"].ToString());
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.Contract binduom = new NewAdbooking.classesoracle.Contract();
                ds = binduom.bindLocation_TV(Session["compcode"].ToString());
            }
            else
            {
                //  NewAdbooking.classmysql.Contract binduom = new NewAdbooking.classmysql.Contract();
                // ds = binduom.uombind(Session["compcode"].ToString(), Session["userid"].ToString());

            }
        drplocation.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "-Select Location-";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        drplocation.Items.Add(li1);
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ListItem li;
                li = new ListItem();
                li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                drplocation.Items.Add(li);
            }

        }

    }
    [Ajax.AjaxMethod]
    public DataSet bindBTB(string compcode,string channel)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            // NewAdbooking.Classes.Contract binduom = new NewAdbooking.Classes.Contract();
            // ds = binduom.bindChannel_TV(Session["compcode"].ToString());
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.Contract binduom = new NewAdbooking.classesoracle.Contract();
                ds = binduom.bindBTB_TV(compcode,channel);
            }
            else
            {
                //  NewAdbooking.classmysql.Contract binduom = new NewAdbooking.classmysql.Contract();
                // ds = binduom.uombind(Session["compcode"].ToString(), Session["userid"].ToString());

            }
        return ds;
    }
    [Ajax.AjaxMethod]
    public DataSet bindRos(string compcode, string btbcode,string channel)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            // NewAdbooking.Classes.Contract binduom = new NewAdbooking.Classes.Contract();
            // ds = binduom.bindChannel_TV(Session["compcode"].ToString());
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.Contract binduom = new NewAdbooking.classesoracle.Contract();
                ds = binduom.bindROS_TV(compcode, btbcode,channel);
            }
            else
            {
                //  NewAdbooking.classmysql.Contract binduom = new NewAdbooking.classmysql.Contract();
                // ds = binduom.uombind(Session["compcode"].ToString(), Session["userid"].ToString());

            }
        return ds;
    }
    [Ajax.AjaxMethod]
    public DataSet bindProgram(string compcode,string programtype,string btbcode,string channel)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            // NewAdbooking.Classes.Contract binduom = new NewAdbooking.Classes.Contract();
            // ds = binduom.bindChannel_TV(Session["compcode"].ToString());
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.Contract binduom = new NewAdbooking.classesoracle.Contract();
                ds = binduom.bindProgram_TV(compcode,programtype,btbcode,channel);
            }
            else
            {
                //  NewAdbooking.classmysql.Contract binduom = new NewAdbooking.classmysql.Contract();
                // ds = binduom.uombind(Session["compcode"].ToString(), Session["userid"].ToString());

            }
        return ds;
    }
    public void bindChannel(string compcode)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            // NewAdbooking.Classes.Contract binduom = new NewAdbooking.Classes.Contract();
            // ds = binduom.bindChannel_TV(Session["compcode"].ToString());
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.Contract binduom = new NewAdbooking.classesoracle.Contract();
                ds = binduom.bindChannel_TV(Session["compcode"].ToString());
            }
            else
            {
                //  NewAdbooking.classmysql.Contract binduom = new NewAdbooking.classmysql.Contract();
                // ds = binduom.uombind(Session["compcode"].ToString(), Session["userid"].ToString());

            }
        drpchannel.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "-Select Channel-";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        drpchannel.Items.Add(li1);
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ListItem li;
                li = new ListItem();
                li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                drpchannel.Items.Add(li);
            }

        }

    }
    public void pop_industry()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.productcategory Ind_Name = new NewAdbooking.Classes.productcategory();
            ds = Ind_Name.bind_industry(Session["compcode"].ToString());

        }

        else

            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.productcategory Ind_Name = new NewAdbooking.classesoracle.productcategory();
                ds = Ind_Name.bind_industry(Session["compcode"].ToString());

            }
            else
            {
                NewAdbooking.classmysql.productcategory Ind_Name = new NewAdbooking.classmysql.productcategory();
                ds = Ind_Name.bind_industry(Session["compcode"].ToString());

            }

        ListItem li1;
        drpindustry.Items.Clear();
        li1 = new ListItem();
        li1.Text = "---Select Industry---";
        li1.Value = "0";
        li1.Selected = true;
        drpindustry.Items.Add(li1);
        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            li.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            drpindustry.Items.Add(li);
        }
    }

    //protected void drpcolor_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    ////////////this is to get the package rate if selected
    //    if (drpadvcat.SelectedValue != "0" && drppackagecode.SelectedValue != "0" && drpuom.SelectedValue != "0" && drpcurr.SelectedValue != "0")
    //    {
    //        string adcat = drpadvcat.SelectedValue;
    //        string pkgcode = drppackagecode.SelectedValue;
    //        string color = drpcolor.SelectedValue;
    //        string currency = drpcurr.SelectedValue;
    //        string uom = drpuom.SelectedValue;
    //        datesave getdatformat = new datesave();
    //        string validfrom = getdatformat.getDate(Session["dateformat"].ToString(), datefrom);
    //        string validto = getdatformat.getDate(Session["dateformat"].ToString(), dateto);
    //         DataSet dcon = new DataSet();
    //         if(ConfigurationSettings.AppSettings ["ConnectionType"].ToString ()=="sql")
    //            {
    //        NewAdbooking.Classes.Contract getpkgrate = new NewAdbooking.Classes.Contract();
           
    //        dcon = getpkgrate.getrateforcontract(adcat, pkgcode, color, currency, uom, advtype, validfrom, validto, Session["compcode"].ToString());
    //         }
    //         else
    //             if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
    //             {
    //                 NewAdbooking.classesoracle.Contract getpkgrate = new NewAdbooking.classesoracle.Contract();

    //                 dcon = getpkgrate.getrateforcontract(adcat, pkgcode, color, currency, uom, advtype, validfrom, validto, Session["compcode"].ToString(),Session["dateformat"].ToString());

    //             }
    //         else
    //         {
    //           NewAdbooking.classmysql .Contract getpkgrate = new NewAdbooking.classmysql.Contract();
           
    //        dcon = getpkgrate.getrateforcontract(adcat, pkgcode, color, currency, uom, advtype, validfrom, validto, Session["compcode"].ToString());

    //         }

    //        if (dcon.Tables[0].Rows.Count > 0)
    //        {
    //            txtcardrate.Text = dcon.Tables[0].Rows[0].ItemArray[0].ToString();

    //        }


    //    }
    //}

    

   
}

