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



    public partial class badwordnew : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Ajax.Utility.RegisterTypeForAjax(typeof(badwordnew));
        }
        [Ajax.AjaxMethod]
        public string chk2badword(string str)
        {
            DataSet ds = new DataSet();

            NewAdbooking.Classes.badwordnew log = new NewAdbooking.Classes.badwordnew();
            
            
            ds = log.chkbadword1(str);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return "True";
            }
            else
            {
                return "False";

            }

        }
    }
