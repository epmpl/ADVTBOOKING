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

public partial class agencysave : System.Web.UI.Page
{

    string mrv = "";
    string qbcuserid = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = -1;
        string compcode, userid, message;
        if (Session["compcode"] != null)
        {
            compcode = Session["compcode"].ToString();
            userid = Session["userid"].ToString();
        }
        else
        {
            Response.Write("<script>window.parent.location=\"login.aspx\";</script>");
            return;
        }
        compcode = Session["compcode"].ToString();
        if (Session["commdetail"] == null)
        {
            Response.Write("commnull");
            return;
        }
        if (Session["paymodeagency"] == null)
        {
            Response.Write("paymodenull");
            return;
        }
        //string agentcategory = Request.QueryString["agentcategory"].ToString();
        //string agentcategory2 = Request.QueryString["agentcategory2"].ToString();
        //string agencytype = Request.QueryString["agencytype"].ToString();
        //string agentcode = Request.QueryString["agentcode"].ToString();
        //string agentname = Request.QueryString["agentname"].ToString();
        //if (agentname.IndexOf('~') > 0)
        //{
        //    agentname = agentname.Replace('~', '&');
        //}
        //string alias = Request.QueryString["alias"].ToString();
        //if (alias.IndexOf('~') > 0)
        //{
        //    alias = alias.Replace('~', '&');
        //}
        //string agencyho = Request.QueryString["agencyho"].ToString();
        //string address = Request.QueryString["address"].ToString();
        //if (address.IndexOf('~') > 0)
        //{
        //    address = address.Replace('~', '&');
        //}
        //string street = Request.QueryString["street"].ToString();
        //string city = Request.QueryString["city"].ToString();
        //string taluka = Request.QueryString["taluka"].ToString();
        //string district = Request.QueryString["district"].ToString();
        //string state = Request.QueryString["state"].ToString();
        //string country = Request.QueryString["country"].ToString();
        //string phone = Request.QueryString["phone"].ToString();
        //string fax = Request.QueryString["fax"].ToString();
        //string mail = Request.QueryString["mail"].ToString();
        //string url = Request.QueryString["url"].ToString();
        //string bussinessstartdate = Request.QueryString["bussinessstartdate"].ToString();
        //string enrolldate = Request.QueryString["enrolldate"].ToString();
        //string mrerefferenceno = Request.QueryString["mrerefferenceno"].ToString();
        //string novts = Request.QueryString["novts"].ToString();
        //string credit = Request.QueryString["credit"].ToString();
        //string pan = Request.QueryString["pan"].ToString();
        //string tan = Request.QueryString["tan"].ToString();
        //string stacno = Request.QueryString["stacno"].ToString();
        //string status = Request.QueryString["status"].ToString();
        //string remarks = Request.QueryString["remarks"].ToString();
        //string subagencyho = Request.QueryString["subagencyho"].ToString();
        //string agencycode = Request.QueryString["agencycode"].ToString();
        //string billto = Request.QueryString["billto"].ToString();
        //string alert = Request.QueryString["alert"].ToString();
        //string creditlimit = Request.QueryString["creditlimit"].ToString();
        //string code = Request.QueryString["code"].ToString();
        //string representative = Request.QueryString["representative"].ToString();
        //string mrvregion = Request.QueryString["mrvregion"].ToString();
        //string pin = Request.QueryString["pin"].ToString();
        //string creditdays = Request.QueryString["creditdays"].ToString();
        //string creditlimitdays = Request.QueryString["creditlimitdays"].ToString();
        //string recoverylimit = Request.QueryString["recoverylimit"].ToString();
        //string kyc = Request.QueryString["kyc_attach"].ToString();
        //string intrestcalculation = Request.QueryString["intrestcalculation"].ToString();
        //mrv = Request.QueryString["mrv"].ToString();
        //string region = Request.QueryString["region"].ToString();
        //string type = Request.QueryString["type"].ToString();
        //string zone = Request.QueryString["zone"].ToString();
        //string address1 = Request.QueryString["address1"].ToString();
        //if (address1.IndexOf('~') > 0)
        //{
        //    address1 = address1.Replace('~', '&');
        //}
        //string address2 = Request.QueryString["address2"].ToString();
        //if (address2.IndexOf('~') > 0)
        //{
        //    address2 = address2.Replace('~', '&');
        //}
        //string curtype = Request.QueryString["curtype"].ToString();
        //string acagen = Request.QueryString["acagen"].ToString();
        //string fax2 = Request.QueryString["fax2"].ToString();
        //string rategrp = Request.QueryString["rategrp"].ToString();
        //string paymode = Request.QueryString["paymode"].ToString();
        //string qbcuserid = Request.QueryString["qbcuserid"].ToString();
        //string branchcode = Request.QueryString["branchcode"].ToString();
        //string hdstatecode = Request.QueryString["hdstatecode"].ToString();
        //string hddistcode = Request.QueryString["hddistcode"].ToString();
        //string billf = Request.QueryString["billfreq"].ToString();
        //string oldagency = Request.QueryString["oldagen"].ToString();
        //string booktype = Request.QueryString["bktype"].ToString();
        //string vat = Request.QueryString["vat"].ToString();
        //string raterevise = Request.QueryString["raterevise"].ToString();
        //string editionwise = Request.QueryString["editionwise"].ToString();
        //string dateformat = Session["dateformat"].ToString();
        //string executive = Request.QueryString["executive"].ToString();
        //string bill = Request.QueryString["email"].ToString();
        //string age_desig = Request.QueryString["age_desig"].ToString();
        //string bilflag = Request.QueryString["bilflag"].ToString();
        //string subsubcd1 = Request.QueryString["subsubcd2"].ToString();
        //string emailidcc = Request.QueryString["mailidcc"].ToString();
        //string sapcode = Request.QueryString["sapcode"].ToString();
        //string security = Request.QueryString["security"].ToString();
        //string gstaus = Request.QueryString["gstust"].ToString();
        //string gstdt = Request.QueryString["gstdat"].ToString();
        //string gstin = Request.QueryString["gstina"].ToString();
        //string retainersa = Request.QueryString["Retainer"].ToString();
        //string blcheque = Request.QueryString["blncheque"].ToString();
        //string scuritybond = Request.QueryString["sctybond"].ToString();
        //string kycapp = Request.QueryString["kycappli"].ToString();
        //string addproof = Request.QueryString["addproof"].ToString();

        string agentcategory = Session["agentcategory1"].ToString();// Request.QueryString["agentcategory"].ToString();
        string agentcategory2 = Session["agentcategory2"].ToString();//Request.QueryString["agentcategory2"].ToString();
        string agencytype = Session["agencytype"].ToString();// Request.QueryString["agencytype"].ToString();
        string agentcode = Session["agentcode"].ToString();//Request.QueryString["agentcode"].ToString();
        string agentname = Session["agentname"].ToString();//Request.QueryString["agentname"].ToString();
        if (agentname.IndexOf('~') > 0)
        {
            agentname = agentname.Replace('~', '&');
        }
        string alias = Session["alias"].ToString();// Request.QueryString["alias"].ToString();
        if (alias.IndexOf('~') > 0)
        {
            alias = alias.Replace('~', '&');
        }
        string agencyho = Session["agencyho"].ToString();// Request.QueryString["agencyho"].ToString();
        string address = Session["address"].ToString();//Request.QueryString["address"].ToString();
        if (address.IndexOf('~') > 0)
        {
            address = address.Replace('~', '&');
        }
        string street = Session["street"].ToString();//Request.QueryString["street"].ToString();
        string city = Session["city"].ToString();// Request.QueryString["city"].ToString();
        string taluka = Session["taluka"].ToString();//Request.QueryString["taluka"].ToString();
        string district = Session["district"].ToString();//Request.QueryString["district"].ToString();
        string state = Session["state"].ToString();//Request.QueryString["state"].ToString();
        string country = Session["country"].ToString();//Request.QueryString["country"].ToString();
        string phone = Session["phone"].ToString();//Request.QueryString["phone"].ToString();
        string fax = Session["fax"].ToString();//Request.QueryString["fax"].ToString();
        string mail = Session["mail"].ToString();//Request.QueryString["mail"].ToString();
        string url = Session["url"].ToString();//Request.QueryString["url"].ToString();
        string bussinessstartdate = Session["bussinessstartdate"].ToString();//Request.QueryString["bussinessstartdate"].ToString();
        string enrolldate = Session["enrolldate"].ToString();// Request.QueryString["enrolldate"].ToString();
        string mrerefferenceno = Session["mrerefferenceno"].ToString();// Request.QueryString["mrerefferenceno"].ToString();
        string novts = Session["novts"].ToString();//Request.QueryString["novts"].ToString();
        string credit = Session["credit"].ToString();//Request.QueryString["credit"].ToString();
        string pan = Session["pan"].ToString();// Request.QueryString["pan"].ToString();
        string tan = Session["tan"].ToString();// Request.QueryString["tan"].ToString();
        string stacno = Session["stacno"].ToString();//Request.QueryString["stacno"].ToString();
        string status = Session["status"].ToString();// Request.QueryString["status"].ToString();
        string remarks = Session["remarks"].ToString();//Request.QueryString["remarks"].ToString();
        string subagencyho = Session["subagencyho"].ToString();// Request.QueryString["subagencyho"].ToString();
        string agencycode = Session["agencycode"].ToString();//Request.QueryString["agencycode"].ToString();
        string billto = Session["billto"].ToString();//Request.QueryString["billto"].ToString();
        string alert = Session["alert"].ToString();//Request.QueryString["alert"].ToString();
        string creditlimit = Session["creditlimit"].ToString();// Request.QueryString["creditlimit"].ToString();
        string code = Session["code"].ToString();//Request.QueryString["code"].ToString();
        string representative = Session["representative"].ToString();// Request.QueryString["representative"].ToString();
        string mrvregion = Session["mrvregion"].ToString();//Request.QueryString["mrvregion"].ToString();
        string pin = Session["pin"].ToString();//Request.QueryString["pin"].ToString();
        string creditdays = Session["creditdays"].ToString();//Request.QueryString["creditdays"].ToString();
        string creditlimitdays = Session["creditlimitdays"].ToString();//Request.QueryString["creditlimitdays"].ToString();
        string recoverylimit = Session["recoverylimit"].ToString();// Request.QueryString["recoverylimit"].ToString();
        string kyc = Session["kyc_attach"].ToString();//Request.QueryString["kyc_attach"].ToString();
        string intrestcalculation = Session["intrestcalculation"].ToString();//Request.QueryString["intrestcalculation"].ToString();
        mrv = Session["mrv"].ToString();//Request.QueryString["mrv"].ToString();
        string region = Session["region"].ToString();// Request.QueryString["region"].ToString();
        string type = Session["type"].ToString();// Request.QueryString["type"].ToString();
        string zone = Session["zone"].ToString();//Request.QueryString["zone"].ToString();
        string address1 = Session["address1"].ToString();//Request.QueryString["address1"].ToString();
        if (address1.IndexOf('~') > 0)
        {
            address1 = address1.Replace('~', '&');
        }
        string address2 = Session["address2"].ToString();//Request.QueryString["address2"].ToString();
        if (address2.IndexOf('~') > 0)
        {
            address2 = address2.Replace('~', '&');
        }

        string curtype = Session["curtype"].ToString();//Request.QueryString["curtype"].ToString();
        string acagen = Session["acagen"].ToString();//Request.QueryString["acagen"].ToString();
        string fax2 = Session["fax2"].ToString();//Request.QueryString["fax2"].ToString();
        string rategrp = Session["rategrp"].ToString();// Request.QueryString["rategrp"].ToString();
        string paymode = Session["paymode"].ToString();//Request.QueryString["paymode"].ToString();
        if (Session["qbcuserid"] == null)
        {
            qbcuserid = "";
        }
        else
        {
            qbcuserid = Session["userid12"].ToString();// Request.QueryString["qbcuserid"].ToString();
        }
        string branchcode = Session["branchcode"].ToString();// Request.QueryString["branchcode"].ToString();
        string hdstatecode = Session["hdstatecode"].ToString();// Request.QueryString["hdstatecode"].ToString();
        string hddistcode = Session["hddistcode"].ToString();//Request.QueryString["hddistcode"].ToString();
        string billf = Session["billfreq"].ToString();//Request.QueryString["billfreq"].ToString();
        string oldagency = Session["oldagen"].ToString();//Request.QueryString["oldagen"].ToString();
        string booktype = Session["booktype"].ToString();//Request.QueryString["bktype"].ToString();
        string vat = Session["vat"].ToString();//Request.QueryString["vat"].ToString();
        string raterevise = Session["raterevise"].ToString();// Request.QueryString["raterevise"].ToString();
        string editionwise = Session["editionwisebilling"].ToString();// Request.QueryString["editionwise"].ToString();
        string dateformat = Session["dateformat"].ToString();
        string executive = Session["Libexecutive"].ToString();//Request.QueryString["executive"].ToString();
        string bill = Session["email"].ToString();//Request.QueryString["email"].ToString();
        string age_desig = Session["age_desig"].ToString();//Request.QueryString["age_desig"].ToString();
        string bilflag = Session["bilflag"].ToString(); ;//Request.QueryString["bilflag"].ToString();
        string subsubcd1 = Session["subsubcd"].ToString();//Request.QueryString["subsubcd2"].ToString();
        string emailidcc = Session["mailidcc"].ToString();//Request.QueryString["mailidcc"].ToString();
        string sapcode = Session["sapcode"].ToString();//Request.QueryString["sapcode"].ToString();
        string security = Session["security"].ToString();// Request.QueryString["security"].ToString();
        string gstaus = Session["gstus"].ToString();//Request.QueryString["gstust"].ToString();
        string gstdt = Session["gstdt"].ToString();//Request.QueryString["gstdat"].ToString();
        string gstin = Session["gstin"].ToString();//Request.QueryString["gstina"].ToString();
        string blcheque = Session["blankcheque"].ToString();//Request.QueryString["blncheque"].ToString();
        string retainersa = Session["Retain"].ToString();// Request.QueryString["Retainer"].ToString();

        string scuritybond = Session["Securitybond"].ToString();// Request.QueryString["sctybond"].ToString();
        string kycapp = Session["kycapp"].ToString();//Request.QueryString["kycappli"].ToString();
        string addproof = Session["addproof"].ToString();// Request.QueryString["addproof"].ToString();
        string gstatus = Session["gstatus"].ToString();//Request.QueryString["gstust"].ToString();
        string gstcltyp = Session["gstcltyp"].ToString();//Request.QueryString["gstust"].ToString();
        string gstarno = Session["gstarno"].ToString();
        string gstprovid = Session["gstprovid"].ToString();
        age_desig = age_desig.Replace(")", "&");
        age_desig = age_desig.Replace("(", "#");
        DataSet ds = new DataSet();
        string err = "";
        try
        {
           
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {

                NewAdbooking.Classes.Master agentmastersave = new NewAdbooking.Classes.Master();
               // ds = agentmastersave.saveagent(compcode, agencytype, agentcategory, agentcategory2, agentcode, agentname, alias, agencyho, address, street, city, district, state, country, phone, fax, mail, url, bussinessstartdate, enrolldate, mrerefferenceno, novts, credit, pan, tan, stacno, status, remarks, userid, subagencyho, agencycode, billto, alert, creditlimit, code, representative, pin, region, type, zone, address1, address2, curtype, acagen, fax2, rategrp, paymode, qbcuserid, dateformat, taluka, mrvregion, branchcode, hdstatecode, hddistcode, billf, oldagency, booktype, vat, raterevise, editionwise, executive, bill, age_desig, creditdays, creditlimitdays, recoverylimit, emailidcc, kyc, intrestcalculation, bilflag, subsubcd1, sapcode, security, gstaus, gstdt, gstin, retainersa, blcheque, scuritybond, kycapp, addproof,gstatus,gstcltyp,gstarno,gstprovid);
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.Master agentmastersave = new NewAdbooking.classesoracle.Master();
                //ds = agentmastersave.saveagent(compcode, agencytype, agentcategory, agentcategory2, agentcode, agentname, alias, agencyho, address, street, city, district, state, country, phone, fax, mail, url, bussinessstartdate, enrolldate, mrerefferenceno, novts, credit, pan, tan, stacno, status, remarks, userid, subagencyho, agencycode, billto, alert, creditlimit, code, representative, pin, region, type, zone, address1, address2, curtype, acagen, fax2, rategrp, paymode, qbcuserid, dateformat, taluka, branchcode, hdstatecode, hddistcode, billf, oldagency, booktype, vat, raterevise, editionwise, executive, bill, age_desig, mrv, creditdays, creditlimitdays, recoverylimit, emailidcc, kyc, intrestcalculation, bilflag, subsubcd1, sapcode, security, gstaus, gstdt, gstin, retainersa, blcheque, scuritybond, kycapp, addproof, gstatus, gstcltyp, gstarno, gstprovid);
            }
            else if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "mysql")
            {
                string procedureName = "websp_saveagent_websp_saveagent_p";
                //string[] parameterValueArray = { compcode, agencytype, agentcategory, agentcategory2, agentcode, agentname, alias, agencyho, fax, address, street, city, district, state, country, phone, fax, mail, url, bussinessstartdate, enrolldate, novts, credit, pan, tan, stacno, paymode, status, remarks, userid, mrerefferenceno, subagencyho, agencycode, billto, alert, creditlimit, code, representative, pin, region, type, zone, address1, address2, curtype, acagen, rategrp, qbcuserid, taluka, branchcode, hddistcode, hdstatecode, billf, oldagency, booktype, vat, raterevise, editionwise, executive, bill, age_desig, mrv, creditdays, creditlimitdays, recoverylimit, emailidcc, kyc, intrestcalculation, sapcode, bilflag, "", subsubcd1, security, gstaus, gstdt, gstin, retainersa, blcheque, scuritybond, kycapp, addproof, gstatus, gstcltyp };
                string[] parameterValueArray = { compcode, agencytype, agentcategory, agentcategory2, agentcode, agentname, alias, agencyho, fax, address, street, city, district, state, country, phone, fax, mail, url, ConvertToDateTime(bussinessstartdate), ConvertToDateTime(enrolldate), novts, credit, pan, tan, stacno, paymode, status, remarks, userid, mrerefferenceno, subagencyho, agencycode, billto, alert, creditlimit, code, representative, pin, region, type, zone, address1, address2, curtype, acagen, rategrp, qbcuserid, taluka, branchcode, hddistcode, hdstatecode, billf, oldagency, booktype, vat, raterevise, editionwise, executive, bill, age_desig, mrv, creditdays, ConvertToDateTime(creditlimitdays), recoverylimit, emailidcc, kyc, intrestcalculation, sapcode, bilflag, "", subsubcd1, security, gstaus, ConvertToDateTime(gstdt), gstin, retainersa, blcheque, scuritybond, kycapp, addproof, gstatus, gstcltyp, gstarno, gstprovid };
                NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
            }
            //else
            //{
            //    string bstd = getDate(dateformat, bussinessstartdate);
            //    string enrd = getDate(dateformat, enrolldate);
            //    NewAdbooking.classmysql.Master agentmastersave = new NewAdbooking.classmysql.Master();
            //   ds = agentmastersave.saveagent(compcode, agentcategory, agentcategory2, agencytype, agentcode, agentname, alias, agencyho, address, street, city, district, state, country, phone, fax, mail, url, bstd, enrd, mrerefferenceno, novts, credit, pan, tan, stacno, status, remarks, userid, subagencyho, agencycode, billto, alert, creditlimit, code, representative, pin, region, type, zone, address1, address2, curtype, acagen, fax2, rategrp, paymode, qbcuserid, dateformat, taluka, branchcode, hdstatecode, hddistcode, billf);
            //}
        }
        catch (Exception e1)
        {
            err = e1.Message;
        }
        string agen = "AgencySave " + agentcode;
        string ip11 = Request.ServerVariables["REMOTE_ADDR"].ToString();
        clsconnection dconnect = new clsconnection();
        string sqldd = "insert into log_new (DATE1,USERID,PROCESSNAME,ERR_DESCRIPTION,OBJECT_PROCESS_ID,DESCRIPTION,IP) values($date,'" + HttpContext.Current.Session["userid"] + "','Agency','" + err.Replace("'", "''") + "','Agency save','" + agen;
        sqldd = sqldd + "',";
        sqldd = sqldd + "'" + ip11 + "')";
        dconnect.executenonquery1(sqldd);
        Session["agentcategory1"] = null;
        Session["agentcategory2"] = null;
        Session["agencytype"] = null;
        Session["agentcode"] = null;
        Session["agentname"] = null;
        Session["alias"] = null;
        Session["agencyho"] = null;
        Session["address"] = null;
        Session["street"] = null;
        Session["city"] = null;
        Session["district"] = null;
        Session["state"] = null;
        Session["country"] = null;
        Session["phone"] = null;
        Session["fax"] = null;
        Session["mail"] = null;
        Session["url"] = null;
        Session["bussinessstartdate"] = null;
        Session["enrolldate"] = null;
        Session["mrerefferenceno"] = null;
        Session["novts"] = null;
        Session["credit"] = null;
        Session["pan"] = null;
        Session["tan"] = null;
        Session["stacno"] = null;
        Session["status"] = null;
        Session["remarks"] = null;
        Session["subagencyho"] = null;
        Session["agencycode"] = null;
        Session["billto"] = null;
        Session["alert"] = null;
        Session["creditlimit"] = null;
        Session["code"] = null;
        Session["representative"] = null;
        Session["pin"] = null;
        Session["region"] = null;
        Session["type"] = null;
        Session["zone"] = null;
        Session["address1"] = null;
        Session["address2"] = null;
        Session["curtype"] = null;
        Session["acagen"] = null;
        Session["fax2"] = null;
        Session["rategrp"] = null;
        Session["paymode"] = null;
        Session["userid12"] = null;
        Session["taluka"] = null;
        Session["mrvregion"] = null;
        Session["branchcode"] = null;
        Session["hdstatecode"] = null;
        Session["hddistcode"] = null;
        Session["billfreq"] = null;
        Session["oldagen"] = null;
        Session["booktype"] = null;
        Session["vat"] = null;
        Session["raterevise"] = null;
        Session["editionwisebilling"] = null;
        Session["Libexecutive"] = null;
        Session["email"] = null;
        Session["age_desig"] = null;
        Session["mrv"] = null;
        Session["creditdays"] = null;
        Session["creditlimitdays"] = null;
        Session["recoverylimit"] = null;
        Session["mailidcc"] = null;
        Session["kyc_attach"] = null;
        Session["intrestcalculation"] = null;
        Session["bilflag"] = null;
        Session["subsubcd"] = null;
        Session["sapcode"] = null;
        Session["security"] = null;
        Session["gstus"] = null;
        Session["gstdt"] = null;
        Session["gstin"] = null;
        Session["Retain"] = null;
        Session["blankcheque"] = null;
        Session["Securitybond"] = null;
        Session["kycapp"] = null;
        Session["addproof"] = null;
        Session["gstatus"] = null;
        Session["gstarno"] = null;
        Session["gstprovid"] = null;
        Session["gstcltyp"] = null;
        if ((Session["commdetail"] == "") || (Session["commdetail"] == null))
        {

        }
        else
        {
            DataSet db1 = (DataSet)Session["commdetail"];
            int er1 = db1.Tables[0].Rows.Count;
            int gf1 = db1.Tables.Count;
            for (int b = 0; b <= gf1 - 1; b++)
            {
                string txtefffrom = getDate(dateformat, db1.Tables[b].Rows[0].ItemArray[0].ToString());
                string txtefftill = getDate(dateformat, db1.Tables[b].Rows[0].ItemArray[1].ToString());
                string txtcommrate = db1.Tables[b].Rows[0].ItemArray[2].ToString();
                string drpcommdetail = db1.Tables[b].Rows[0].ItemArray[3].ToString();
                string drpadtype = db1.Tables[b].Rows[0].ItemArray[6].ToString();
                string addcomm = db1.Tables[b].Rows[0].ItemArray[7].ToString();
                string uom = db1.Tables[b].Rows[0].ItemArray[8].ToString();
                string agen1 = db1.Tables[b].Rows[0].ItemArray[9].ToString();
                string cash_amt = db1.Tables[b].Rows[0].ItemArray[10].ToString();
                string cash_disc = db1.Tables[b].Rows[0].ItemArray[11].ToString();
                string adcat = db1.Tables[b].Rows[0].ItemArray[12].ToString();
                DataSet ds1 = new DataSet();
                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                {
                    NewAdbooking.Classes.pop comminsert = new NewAdbooking.Classes.pop();
                    ds1 = comminsert.insertcomm(txtefffrom, txtefftill, txtcommrate, drpcommdetail, compcode, userid, agentcode, agencycode, dateformat, drpadtype, addcomm, uom, agen1, cash_disc, cash_amt, adcat);

                }
                else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                {
                    NewAdbooking.classesoracle.pop comminsert = new NewAdbooking.classesoracle.pop();
                    ds1 = comminsert.insertcomm(txtefffrom, txtefftill, txtcommrate, drpcommdetail, compcode, userid, agentcode, agencycode, dateformat, drpadtype, addcomm, uom, agen1, cash_disc, cash_amt, adcat);
                    
                }
                else
                {
                    string procedureName = "websp_insertcomm";
                    string[] parameterValueArray = new string[] { agentcode, txtefffrom, txtefftill, txtcommrate, drpcommdetail, userid, agencycode, compcode, drpadtype, addcomm, uom, agen, cash_disc, cash_amt, adcat };
                    NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                    ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
                    /*
                     *  
                    NewAdbooking.classmysql.pop comminsert = new NewAdbooking.classmysql.pop();
                    ds1 = comminsert.insertcomm(txtefffrom, txtefftill, txtcommrate, drpcommdetail, compcode, userid, agentcode, agencycode, dateformat, drpadtype, addcomm, uom, agen1, cash_disc, cash_amt);
                    */
                }
            }
        }

        if ((Session["statussave"] == "") || (Session["statussave"] == null))
        {
        }
        else
        {
            DataSet db1 = (DataSet)Session["statussave"];
            int er1 = db1.Tables[0].Rows.Count;
            int gf1 = db1.Tables.Count;
            for (int b = 0; b <= gf1 - 1; b++)
            {
                string txtfrom = getDate(dateformat, db1.Tables[b].Rows[0].ItemArray[2].ToString());
                string txtto = getDate(dateformat, db1.Tables[b].Rows[0].ItemArray[3].ToString());
                string circular = db1.Tables[b].Rows[0].ItemArray[4].ToString();
                string drpstatus = db1.Tables[b].Rows[0].ItemArray[1].ToString();
                string txtremark = db1.Tables[b].Rows[0].ItemArray[5].ToString();
                string attachment = db1.Tables[b].Rows[0].ItemArray[7].ToString();
                DataSet ds2 = new DataSet();
                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                {
                    NewAdbooking.Classes.pop statusinsert = new NewAdbooking.Classes.pop();
                    ds2 = statusinsert.insertstatus(drpstatus, txtfrom, txtto, circular, compcode, userid, agentcode, agencycode, txtremark, attachment);
                }
                else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                {
                    NewAdbooking.classesoracle.pop statusinsert = new NewAdbooking.classesoracle.pop();
                    ds2 = statusinsert.insertstatus(drpstatus, txtfrom, txtto, circular, compcode, userid, agentcode, agencycode, txtremark, dateformat, attachment);
                }
                else
                {
                    string procedureName = "websp_insertstatus";
                    string[] parameterValueArray = new string[] { agentcode, status, ConvertToDateTime(txtfrom), ConvertToDateTime(txtto), circular, userid, agencycode, compcode, remarks, attachment };
                    NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                    ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
                    /*
                    NewAdbooking.classmysql.pop statusinsert = new NewAdbooking.classmysql.pop();
                    ds2 = statusinsert.insertstatus(drpstatus, txtfrom, txtto, circular, compcode, userid, agentcode, agencycode, txtremark, dateformat);
                     * */
                }
            }
        }
        if ((Session["bankdetail"] == "") || (Session["bankdetail"] == null))
        {
        }
        else
        {
            DataSet db2 = (DataSet)Session["bankdetail"];
            int er1 = db2.Tables[0].Rows.Count;
            int gf1 = db2.Tables.Count;
            for (int b = 0; b <= gf1 - 1; b++)
            {
                string txtbgno = db2.Tables[b].Rows[0].ItemArray[0].ToString();
                string txtbgdate = getDate(dateformat, db2.Tables[b].Rows[0].ItemArray[1].ToString());
                string txtamount = db2.Tables[b].Rows[0].ItemArray[2].ToString();
                string txtbank = db2.Tables[b].Rows[0].ItemArray[4].ToString();
                string txtvaliditydate = getDate(dateformat, db2.Tables[b].Rows[0].ItemArray[3].ToString());
                string attach = db2.Tables[b].Rows[0].ItemArray[6].ToString();
                DataSet ds2 = new DataSet();
                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                {
                    NewAdbooking.Classes.pop bankinsert = new NewAdbooking.Classes.pop();
                    ds2 = bankinsert.insertbank(txtbgno, txtbgdate, txtamount, txtbank, txtvaliditydate, compcode, userid, agentcode, agencycode, attach);
                }
                else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                {
                    NewAdbooking.classesoracle.pop bankinsert = new NewAdbooking.classesoracle.pop();
                    ds2 = bankinsert.insertbank(txtbgno, txtbgdate, txtamount, txtbank, txtvaliditydate, compcode, userid, agentcode, agencycode, dateformat, attach);
                }
                else if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "mysql")
                {
                    string procedureName = "websp_insertbank";
                    string[] parameterValueArray = { agencycode, txtbgno, ConvertToDateTime(txtbgdate), txtamount, txtbank, ConvertToDateTime(txtvaliditydate), userid, agentcode, compcode, attach };
                    NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                    ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
                }
                //else
                //{
                //    NewAdbooking.classmysql.pop bankinsert = new NewAdbooking.classmysql.pop();
                //    ds2 = bankinsert.insertbank(txtbgno, txtbgdate, txtamount, txtbank, txtvaliditydate, compcode, userid, agentcode, agencycode, dateformat, attach);
                //}
            }
        }
        if ((Session["bankmaster"] == "") || (Session["bankmaster"] == null))
        {
        }
        else
        {
            DataSet db4 = (DataSet)Session["bankmaster"];
            int er1 = db4.Tables[0].Rows.Count;
            int gf1 = db4.Tables.Count;
            for (int b = 0; b <= gf1 - 1; b++)
            {
                string bankname = db4.Tables[b].Rows[0].ItemArray[0].ToString();
                string branch = db4.Tables[b].Rows[0].ItemArray[1].ToString();
                string country1 = db4.Tables[b].Rows[0].ItemArray[2].ToString();
                string city1 = db4.Tables[b].Rows[0].ItemArray[3].ToString();
                string bankno = db4.Tables[b].Rows[0].ItemArray[4].ToString();
                string accountno = db4.Tables[b].Rows[0].ItemArray[5].ToString();
                DataSet ds4 = new DataSet();
                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                {
                    NewAdbooking.Classes.bankmaster ins = new NewAdbooking.Classes.bankmaster();
                    ds4 = ins.insertdata(bankname, branch, country1, city1, bankno, accountno, compcode, userid, agentcode, agencycode);
                }
                else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                {
                    NewAdbooking.classesoracle.bankmaster ins = new NewAdbooking.classesoracle.bankmaster();
                    ds4 = ins.insertdata(bankname, branch, country1, city1, bankno, accountno, compcode, userid, agentcode, agencycode);
                }
                else
                {
                    NewAdbooking.classmysql.bankmaster ins = new NewAdbooking.classmysql.bankmaster();
                    ds4 = ins.insertdata(bankname, branch, country1, city1, bankno, accountno, compcode, userid, agentcode, agencycode);
                    
                }
            }
        }
        if ((Session["contactdetail"] == "") || (Session["contactdetail"] == null))
        {
        }
        else
        {
            string product = Session["pp"].ToString();
            string id = product;
            DataSet db5 = (DataSet)Session["contactdetail"];
            int er1 = db5.Tables[0].Rows.Count;
            int gf1 = db5.Tables.Count;
            for (int b = 0; b <= gf1 - 1; b++)
            {

                string contactperson = db5.Tables[b].Rows[0].ItemArray[0].ToString();
                string txtdesignation = db5.Tables[b].Rows[0].ItemArray[1].ToString();
                string drprole = db5.Tables[b].Rows[0].ItemArray[2].ToString();
                string txtdob = getDate(dateformat, db5.Tables[b].Rows[0].ItemArray[3].ToString());
                string txtphoneno = db5.Tables[b].Rows[0].ItemArray[4].ToString();
                string txtext = db5.Tables[b].Rows[0].ItemArray[5].ToString();
                string txtfaxno = db5.Tables[b].Rows[0].ItemArray[6].ToString();
                string mail1 = db5.Tables[b].Rows[0].ItemArray[7].ToString();
                string mobile = db5.Tables[b].Rows[0].ItemArray[9].ToString();
                DataSet ds6 = new DataSet();
                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                {
                    NewAdbooking.Classes.pop contactinsert = new NewAdbooking.Classes.pop();
                    ds6 = contactinsert.insertcontact(contactperson, txtdesignation, drprole, txtdob, txtphoneno, txtext, txtfaxno, mail1, userid, agentcode, agencycode, compcode, id, mobile);
                }
                else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                {
                    NewAdbooking.classesoracle.pop contactinsert = new NewAdbooking.classesoracle.pop();
                    ds6 = contactinsert.insertcontact(contactperson, txtdesignation, drprole, txtdob, txtphoneno, txtext, txtfaxno, mail1, userid, agentcode, agencycode, compcode, id, dateformat, mobile);
                }
                else
                {
                    string procedureName = "websp_contactdetails";
                    string[] parameterValueArray = { agentcode, contactperson, txtdesignation, drprole, ConvertToDateTime(txtdob), txtphoneno, txtext, fax, mail, userid, agencycode, compcode, id, mobile };
                    NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                    ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
                    /*
                    NewAdbooking.classmysql.pop contactinsert = new NewAdbooking.classmysql.pop();
                    ds6 = contactinsert.insertcontact(contactperson, txtdesignation, drprole, txtdob, txtphoneno, txtext, txtfaxno, mail1, userid, agentcode, agencycode, compcode, id, dateformat, mobile);
                     */
                }
            }
        }
        if ((Session["paymodeagency"] == "") || (Session["paymodeagency"] == null))
        {
        }
        else
        {
           
            DataSet ds7 = new DataSet();
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.pop CustCode = new NewAdbooking.Classes.pop();
                CustCode.insertpay(agentcode, compcode, userid, agencycode, Session["MySelectedValue"].ToString());

            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.pop CustCode = new NewAdbooking.classesoracle.pop();
                CustCode.insertpay(agentcode, compcode, userid, agencycode, Session["MySelectedValue"].ToString());
            }
            else
            {
                NewAdbooking.classmysql.pop CustCode = new NewAdbooking.classmysql.pop();
                CustCode.insertpay(agentcode, compcode, userid, agencycode, Session["MySelectedValue"].ToString());
            }
        }
        Session["bankmaster"] = null;
        Session["bankdetail"] = null;
        Session["commdetail"] = null;
        Session["statussave"] = null;
        Session["contactdetail"] = null;
        Session["paymodeagency"] = null;
        Session["MySelectedValue"] = null;
        message = "Data Saved Successfully"; 
    }
    public string ConvertToDateTime(string strDateTime)
    {
        string dtFinaldate; string sDateTime;
        if (strDateTime != "")
        {
            string hddndateformat = Session["DateFormat"].ToString();
            try
            {
                if (hddndateformat == "dd/mm/yyyy")
                {
                    string[] sDate = strDateTime.Split('/');
                    //sDateTime = sDate[2] + '/' + sDate[0] + '/' + sDate[1];
                    sDateTime = sDate[1] + '/' + sDate[0] + '/' + sDate[2];
                    dtFinaldate = sDateTime;
                }
                else
                {
                    dtFinaldate = Convert.ToDateTime(strDateTime).ToString();
                }
            }
            catch (Exception e)
            {
                string[] sDate = strDateTime.Split('/');
                sDateTime = sDate[2] + '/' + sDate[0] + '/' + sDate[1];
                dtFinaldate = sDateTime;
            }
            return dtFinaldate;
        }
        else
        {
            return null;
        }
    }
    public string getDate(string dateformat, string dateValue)
    {
        string dateReturn = "";
        if (dateValue != "")
        {
            char[] splitterfrom = { '/' };
            string[] myarrayfrom = dateValue.Split(splitterfrom);
            string dd, mm, yyyy;
            if (dateformat == "dd/mm/yyyy")
            {
                dd = myarrayfrom[0];
                mm = myarrayfrom[1];
                yyyy = myarrayfrom[2];
                dateReturn = mm + "/" + dd + "/" + yyyy;
            }            
            else
            {
                dateReturn = dateValue;
            }
        }
        return dateReturn;
    }
}
