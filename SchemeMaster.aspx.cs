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

public partial class SchemeMaster : System.Web.UI.Page
{
    public partial class Migrated_SchemeMaster : SchemeMaster
    {
        string compcode, userid, dateformat, username;

        protected void Page_Load(object sender, System.EventArgs e)
        {

            Response.Expires = -1;
            Response.Buffer = true;
            Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);
            Response.Expires = -1500;
            Response.CacheControl = "no-cache";
            if (Session["compcode"] == null)
            {
                //Response.Redirect("login.aspx");
                Response.Write("<script>window.parent.location=\"login.aspx\";</script>");
                return;
            }
            Ajax.Utility.RegisterTypeForAjax(typeof(SchemeMaster));
            //Ajax.Utility.RegisterTypeForAjax(typeof(ClientMaster));
            //Ajax.Utility.RegisterTypeForAjax(typeof(multi_discount));

            compcode = Session["compcode"].ToString();
            hiddencompcode.Value = compcode;

            userid = Session["userid"].ToString();
            hiddenuserid.Value = userid;

            hiddenusername.Value = Session["username"].ToString();

            dateformat = Session["dateformat"].ToString();
            hiddendateformat.Value = dateformat;
            hiddenusername.Value = Session["Username"].ToString();



            advtyp(compcode, userid);
            advcat(compcode, userid);
            advcomb(compcode, userid);
            schemetype(compcode, userid);
            color(compcode, userid);
            pageloadbtn();

            if (!Page.IsPostBack)
            {
                drpCombName.Attributes.Add("OnChange", "javascript:return combpkg();");
                btnNew.Attributes.Add("OnClick", "javascript:return NewClick1();");
                btnModify.Attributes.Add("OnClick", "javascript:return ModifyClick1();");
                btnQuery.Attributes.Add("OnClick", "javascript:return QueryClick1();");
                btnExecute.Attributes.Add("OnClick", "javascript:return ExecuteClick1();");
                btnCancel.Attributes.Add("OnClick", "javascript:return CancelClick1('SchemeMaster');");
                btnSave.Attributes.Add("OnClick", "javascript:return SaveClick1();");
                btnfirst.Attributes.Add("OnClick", "javascript:return FirstClick1();");
                btnlast.Attributes.Add("OnClick", "javascript:return LastClick1();");
                btnprevious.Attributes.Add("OnClick", "javascript:return PreviousClick1();");
                btnnext.Attributes.Add("OnClick", "javascript:return NextClick1();");
                btnExit.Attributes.Add("OnClick", "javascript:return exitclick1();");
                btnDelete.Attributes.Add("OnClick", "javascript:return deletedoc();");
                txtSchemeCode.Attributes.Add("OnBlur", "javascript:return UpperCase('txtSchemeCode');");
                txtRemarks.Attributes.Add("OnBlur", "javascript:return UpperCase('txtRemarks');");
                lbschemedetail.Attributes.Add("OnClick", "javascript:return schemedetailpopup();");
                CheckBox8.Attributes.Add("OnClick", "javascript:return checkedunchecked('CheckBox8');");
            }
            // Put user code to initialize the page here
        }

        #region Web Form Designer generated code
        protected void OnInit(EventArgs e)
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

        }
        #endregion


        //		public void pageloadbtn()
        public void pageloadbtn()
        {
            btnNew.Enabled = true;
            btnSave.Enabled = false;
            btnModify.Enabled = false;
            btnDelete.Enabled = false;
            btnQuery.Enabled = true;
            btnExecute.Enabled = false;
            btnCancel.Enabled = true;
            btnfirst.Enabled = false;
            btnprevious.Enabled = false;
            btnnext.Enabled = false;
            btnlast.Enabled = false;
            btnExit.Enabled = true;



            drpAdvType.Enabled = false;
            drpAdvCat.Enabled = false;
            drpCombName.Enabled = false;
            drpSchemeType.Enabled = false;
            drpPackName.Enabled = false;
            drpColour.Enabled = false;
            txtRemarks.Enabled = false;
            txtSchemeCode.Enabled = false;

        }

        //		public void advtyp(string compcode,string userid)
        public void advtyp(string compcode, string userid)
        {
            NewAdbooking.Classes.SchemeMaster bind = new NewAdbooking.Classes.SchemeMaster();
            DataSet ds = new DataSet();
            ds = bind.advdata(compcode, userid);

            int i;
            ListItem li1;
            li1 = new ListItem();
            li1.Text = "-Select Adv-";
            li1.Value = "0";
            li1.Selected = true;
            drpAdvType.Items.Add(li1);

            if (ds.Tables.Count > 0)
            {
                for (i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    ListItem li;
                    li = new ListItem();
                    li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                    li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                    drpAdvType.Items.Add(li);

                }
            }


        }



        //		public void advcat(string compcode,string userid)
        public void advcat(string compcode, string userid)
        {
            NewAdbooking.Classes.SchemeMaster bind = new NewAdbooking.Classes.SchemeMaster();
            DataSet ds = new DataSet();
            ds = bind.advdata(compcode, userid);

            int i;
            ListItem li1;
            li1 = new ListItem();
            li1.Text = "-Select Adv Category-";
            li1.Value = "0";
            li1.Selected = true;
            drpAdvCat.Items.Add(li1);

            if (ds.Tables.Count > 0)
            {
                for (i = 0; i < ds.Tables[1].Rows.Count; i++)
                {
                    ListItem li;
                    li = new ListItem();
                    li.Value = ds.Tables[1].Rows[i].ItemArray[0].ToString();
                    li.Text = ds.Tables[1].Rows[i].ItemArray[1].ToString();
                    drpAdvCat.Items.Add(li);

                }
            }


        }


        //		public void advcomb(string compcode,string userid)
        public void advcomb(string compcode, string userid)
        {
            NewAdbooking.Classes.SchemeMaster bind = new NewAdbooking.Classes.SchemeMaster();
            DataSet ds = new DataSet();
            ds = bind.advdata(compcode, userid);

            int i;
            ListItem li1;
            li1 = new ListItem();
            li1.Text = "- Select Comb./Edi.-";
            li1.Value = "0";
            li1.Selected = true;
            drpCombName.Items.Add(li1);

            if (ds.Tables.Count > 0)
            {
                for (i = 0; i < ds.Tables[2].Rows.Count; i++)
                {
                    ListItem li;
                    li = new ListItem();
                    li.Value = ds.Tables[2].Rows[i].ItemArray[0].ToString();
                    li.Text = ds.Tables[2].Rows[i].ItemArray[0].ToString();
                    drpCombName.Items.Add(li);

                }
            }


        }


        //		public void schemetype(string compcode,string userid)
        public void schemetype(string compcode, string userid)
        {
            NewAdbooking.Classes.SchemeMaster bind = new NewAdbooking.Classes.SchemeMaster();
            DataSet ds = new DataSet();
            ds = bind.colscheme(compcode, userid);

            int i;
            ListItem li1;
            li1 = new ListItem();
            li1.Text = "-Select Scheme Type-";
            li1.Value = "0";
            li1.Selected = true;
            drpSchemeType.Items.Add(li1);

            if (ds.Tables.Count > 0)
            {
                for (i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    ListItem li;
                    li = new ListItem();
                    li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                    li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                    drpSchemeType.Items.Add(li);

                }
            }


        }

        //		public void color(string compcode,string userid)
        public void color(string compcode, string userid)
        {
            NewAdbooking.Classes.SchemeMaster bind = new NewAdbooking.Classes.SchemeMaster();
            DataSet ds = new DataSet();
            ds = bind.colscheme(compcode, userid);

            int i;
            ListItem li1;
            li1 = new ListItem();
            li1.Text = "-Select Color-";
            li1.Value = "0";
            li1.Selected = true;
            drpColour.Items.Add(li1);

            if (ds.Tables.Count > 0)
            {
                for (i = 0; i < ds.Tables[1].Rows.Count; i++)
                {
                    ListItem li;
                    li = new ListItem();
                    li.Value = ds.Tables[1].Rows[i].ItemArray[0].ToString();
                    li.Text = ds.Tables[1].Rows[i].ItemArray[1].ToString();
                    drpColour.Items.Add(li);

                }
            }


        }


        [Ajax.AjaxMethod]
        //		public DataSet filpkg(string comb,string compcode,string userid)
        public DataSet filpkg(string comb, string compcode, string userid)
        {
            NewAdbooking.Classes.SchemeMaster fill = new NewAdbooking.Classes.SchemeMaster();
            DataSet ds = new DataSet();
            ds = fill.advdata1(comb, compcode, userid);

            return ds;
        }


        [Ajax.AjaxMethod]
        //		public DataSet insert(string AdvType,string AdvCat,string SchemeCode,string SchemeType,string CombName,string PackName,string Color,string Remarks,string compcode,string userid)
        public DataSet insert(string AdvType, string AdvCat, string SchemeCode, string SchemeType, string CombName, string PackName, string Color, string Remarks, string compcode, string userid)
        {
            NewAdbooking.Classes.SchemeMaster fill = new NewAdbooking.Classes.SchemeMaster();
            DataSet ds = new DataSet();
            ds = fill.schinsert(AdvType, AdvCat, SchemeCode, SchemeType, CombName, PackName, Color, Remarks, compcode, userid);

            return ds;
        }

        [Ajax.AjaxMethod]
        //		public DataSet chkschemecode(string SchemeCode,string compcode,string userid)
        public DataSet chkschemecode(string SchemeCode, string compcode, string userid)
        {
            NewAdbooking.Classes.SchemeMaster fill = new NewAdbooking.Classes.SchemeMaster();
            DataSet ds = new DataSet();
            ds = fill.chkinsert(SchemeCode, compcode, userid);

            return ds;
        }

        [Ajax.AjaxMethod]
        //		public DataSet modify(string AdvType,string AdvCat,string SchemeCode,string SchemeType,string CombName,string PackName,string Color,string Remarks,string compcode,string userid)
        public DataSet modify(string AdvType, string AdvCat, string SchemeCode, string SchemeType, string CombName, string PackName, string Color, string Remarks, string compcode, string userid)
        {
            NewAdbooking.Classes.SchemeMaster fill = new NewAdbooking.Classes.SchemeMaster();
            DataSet ds = new DataSet();
            ds = fill.schmodify(AdvType, AdvCat, SchemeCode, SchemeType, CombName, PackName, Color, Remarks, compcode, userid);

            return ds;
        }

        [Ajax.AjaxMethod]
        //		public DataSet checkedtioncode1(string compcode,string SchemeCode,string userid)
        public DataSet checkedtioncode1(string compcode, string SchemeCode, string userid)
        {
            NewAdbooking.Classes.SchemeMaster fill = new NewAdbooking.Classes.SchemeMaster();
            DataSet ds = new DataSet();
            ds = fill.checkcode(compcode, SchemeCode, userid);

            return ds;
        }

        [Ajax.AjaxMethod]
        //		public DataSet edtiondaymodify1(string compcode,string SchemeCode,string CheckBox1,string CheckBox2,string CheckBox3,string CheckBox4,string CheckBox5,string CheckBox6,string CheckBox7,string CheckBox8,string userid)
        public DataSet edtiondaymodify1(string compcode, string SchemeCode, string CheckBox1, string CheckBox2, string CheckBox3, string CheckBox4, string CheckBox5, string CheckBox6, string CheckBox7, string CheckBox8, string userid)
        {
            NewAdbooking.Classes.SchemeMaster pmst = new NewAdbooking.Classes.SchemeMaster();
            DataSet ds = new DataSet();
            ds = pmst.selectpubdaymodify(compcode, SchemeCode, CheckBox1, CheckBox2, CheckBox3, CheckBox4, CheckBox5, CheckBox6, CheckBox7, CheckBox8, userid);
            return ds;

        }


        [Ajax.AjaxMethod]
        //		public DataSet editionpubdaysave1(string compcode,string SchemeCode,string CheckBox1,string CheckBox2,string CheckBox3,string CheckBox4,string CheckBox5,string CheckBox6,string CheckBox7,string CheckBox8,string userid)
        public DataSet editionpubdaysave1(string compcode, string SchemeCode, string CheckBox1, string CheckBox2, string CheckBox3, string CheckBox4, string CheckBox5, string CheckBox6, string CheckBox7, string CheckBox8, string userid)
        {
            NewAdbooking.Classes.SchemeMaster pmst = new NewAdbooking.Classes.SchemeMaster();
            DataSet ds = new DataSet();
            ds = pmst.selectpubdaysave(compcode, SchemeCode, CheckBox1, CheckBox2, CheckBox3, CheckBox4, CheckBox5, CheckBox6, CheckBox7, CheckBox8, userid);
            return ds;

        }


        [Ajax.AjaxMethod]
        //		public DataSet select(string AdvType,string AdvCat,string SchemeCode,string SchemeType,string CombName,string PackName,string Color,string compcode,string userid)
        public DataSet select(string AdvType, string AdvCat, string SchemeCode, string SchemeType, string CombName, string PackName, string Color, string compcode, string userid)
        {
            NewAdbooking.Classes.SchemeMaster pmst = new NewAdbooking.Classes.SchemeMaster();
            DataSet ds = new DataSet();
            ds = pmst.schexe(AdvType, AdvCat, SchemeCode, SchemeType, CombName, PackName, Color, compcode, userid);
            return ds;

        }

        [Ajax.AjaxMethod]
        //		public DataSet checkpubcode1(string compcode,string SchemeCode,string userid)
        public DataSet checkpubcode1(string compcode, string SchemeCode, string userid)
        {
            NewAdbooking.Classes.SchemeMaster pmst = new NewAdbooking.Classes.SchemeMaster();
            DataSet ds = new DataSet();
            ds = pmst.checkpubcode(compcode, SchemeCode, userid);
            return ds;

        }

        [Ajax.AjaxMethod]
        //		public DataSet Selectfnpl(string compcode,string SchemeCode,string userid)
        public DataSet Selectfnpl(string compcode, string SchemeCode, string userid)
        {
            NewAdbooking.Classes.SchemeMaster pmst = new NewAdbooking.Classes.SchemeMaster();
            DataSet ds = new DataSet();
            ds = pmst.secfnpl(compcode, SchemeCode, userid);
            return ds;

        }

        [Ajax.AjaxMethod]
        //		public DataSet del(string compcode,string SchemeCode,string userid)
        public DataSet del(string compcode, string SchemeCode, string userid)
        {
            NewAdbooking.Classes.SchemeMaster pmst = new NewAdbooking.Classes.SchemeMaster();
            DataSet ds = new DataSet();
            ds = pmst.secdel(compcode, SchemeCode, userid);
            return ds;

        }



    }
}