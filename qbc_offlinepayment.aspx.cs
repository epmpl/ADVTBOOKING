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
using System.IO;
public partial class qbc_offlinepayment : System.Web.UI.Page
{
    [Ajax.AjaxMethod]
    public DataSet saveData(string receiptno, string chqno, string chqdate, string amount, string chqmode, string bankname, string bankbranch, string filename,string dateformat)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster paystatus = new NewAdbooking.Classes.BookingMaster();
            ds = paystatus.insertpaymentdetail(receiptno, chqno,  chqdate,  amount,  chqmode,  bankname,  bankbranch,  filename,dateformat);
        }

        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.BookingMaster paystatus = new NewAdbooking.classesoracle.BookingMaster();
            ds = paystatus.insertpaymentdetail( receiptno,  chqno,  chqdate,  amount,  chqmode,  bankname,  bankbranch,  filename,dateformat);
        }
      
        return ds;
    }
    private void filldata(string receipt)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.BookingMaster paystatus = new NewAdbooking.Classes.BookingMaster();
            ds = paystatus.getpaymentdetail(receipt);
        }

        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.BookingMaster paystatus = new NewAdbooking.classesoracle.BookingMaster();
            ds = paystatus.getpaymentdetail(receipt);
        }
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
           // CHQNO,CHQDATE,AMOUNT,CHQMODE,BANKNAME,BANKBRANCH,FILENAME
            if (ds.Tables[0].Rows[0].ItemArray[0] != null)
            {
                txtchqno.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
            }
            if (ds.Tables[0].Rows[0].ItemArray[1] != null && ds.Tables[0].Rows[0].ItemArray[1].ToString() != "")
            {
                if (hiddendateformat.Value == "mm/dd/yyyy")
                    txtchqdate.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
                else if (hiddendateformat.Value == "dd/mm/yyyy")
                {
                    string[] arr = ds.Tables[0].Rows[0].ItemArray[1].ToString().Split("/".ToCharArray());
                    txtchqdate.Text = arr[1].ToString() + "/" + arr[0].ToString() + "/" + arr[2].ToString();
                }
                else if (hiddendateformat.Value == "yyyy/mm/dd")
                {
                    string[] arr = ds.Tables[0].Rows[0].ItemArray[1].ToString().Split("/".ToCharArray());
                    txtchqdate.Text = arr[2].ToString() + "/" + arr[0].ToString() + "/" + arr[1].ToString();
                }
            }
            if(ds.Tables[0].Rows[0].ItemArray[2]!=null)
                txtamount.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
            if(ds.Tables[0].Rows[0].ItemArray[3]!=null)
                drpchqmode.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
            if(ds.Tables[0].Rows[0].ItemArray[4]!=null)
                txtbankname.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
            if(ds.Tables[0].Rows[0].ItemArray[5]!=null)
                txtbankbranch.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();
            if(ds.Tables[0].Rows[0].ItemArray[6]!=null)
                lblfilename.Text = ds.Tables[0].Rows[0].ItemArray[6].ToString();
            hiddenfilename.Value = lblfilename.Text;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        Ajax.Utility.RegisterTypeForAjax(typeof(qbc_offlinepayment));
        if (!Page.IsPostBack)
        {
           
            btnsave.Attributes.Add("OnClick", "javascript:return savedata();");
            txtreceiptno.Text=Request.QueryString["receiptno"].ToString();
            txtchqdate.Attributes.Add("OnChange", "javascript:return checkdate(this);  ");
            hiddendateformat.Value = Request.QueryString["dateformat"].ToString();
            if (Request.QueryString["chkbtnStatus"] == "modify")
            {
                txtamount.Enabled = true;
                txtchqno.Enabled = true;
                txtchqdate.Enabled = true;
                drpchqmode.Enabled = true;
                txtbankname.Enabled = true;
                txtbankbranch.Enabled = true;
                FileUpload1.Enabled = true;
                btnsave.Enabled = true;
                Button1.Enabled = true;
                txtchqno.Focus();
            }
            else
            {
                txtamount.Enabled = false;
                txtchqno.Enabled = false;
                txtchqdate.Enabled = false;
                drpchqmode.Enabled = false;
                txtbankname.Enabled = false;
                txtbankbranch.Enabled = false;
                FileUpload1.Enabled = false;
                btnsave.Enabled = false;
                Button1.Enabled = false;
               
            }
          
            DataSet objDataSet = new DataSet();

            objDataSet.ReadXml(Server.MapPath("XML/offlinepaymentmode.xml"));
            ListItem li1;
            li1 = new ListItem();
            li1.Text = "-Select Mode-";
            li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
            li1.Selected = true;
            drpchqmode.Items.Add(li1);
            for (int i = 0; i < objDataSet.Tables[0].Columns.Count; )
            {
                ListItem li;
                li = new ListItem();
                li.Text = objDataSet.Tables[0].Rows[0].ItemArray[i].ToString();
                li.Value = objDataSet.Tables[0].Rows[0].ItemArray[i+1].ToString();
                drpchqmode.Items.Add(li);
                i = i + 2;
            }
            filldata(txtreceiptno.Text);
        }


    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string strFileName = FileUpload1.PostedFile.FileName;
        hiddenfilename.Value = strFileName;
        if (strFileName == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alert('You have not Browse the File.');", true);
            return;
        }
        string serverpath = Server.MapPath("paymentattachment/");
        string fname = System.IO.Path.GetFileName(strFileName);
        
        FileUpload1.PostedFile.SaveAs(Path.Combine(serverpath, fname));
        hiddenfilename.Value = fname;
        lblfilename.Text = fname;
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alert('File Attached Successfully.');", true);
        return;
    }
}
