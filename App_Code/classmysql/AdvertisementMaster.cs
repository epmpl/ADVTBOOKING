using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using MySql.Data;
using MySql.Data.MySqlClient;
namespace NewAdbooking.classmysql
{    /// <summary>
    /// Summary description for AdvertisementMaster
    /// </summary>
    public class AdvertisementMaster : connection
    {
        public AdvertisementMaster()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataSet AdvTeamDetailSave(string Comp_Code, string Team_Code, string Team_Name, string zone, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("AdvTeamDetailSave_AdvTeamDetailSave_p", ref objmysqlconnection);
               objmysqlcommand.CommandType = CommandType.StoredProcedure;

               objmysqlcommand.Parameters.Add("Comp_Code", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["Comp_Code"].Value = Comp_Code;

               objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["userid"].Value = userid;

               objmysqlcommand.Parameters.Add("Team_Code", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["Team_Code"].Value = Team_Code;

               objmysqlcommand.Parameters.Add("Team_Name", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["Team_Name"].Value = Team_Name;

               objmysqlcommand.Parameters.Add("zone", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["zone"].Value = zone;

               objmysqlcommand.Parameters.Add("attachment", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["attachment"].Value = "";

                objmysqlcommand.Parameters.Add("signature", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["signature"].Value = "";
                
               objmysqlDataAdapter.SelectCommand = objmysqlcommand;
               objmysqlDataAdapter.Fill(objDataSet);
               return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }

        }




        public DataSet AdvExecDetail(string Comp_Code, string Team_Code, string Team_Name, string zone, int Flag, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("AdvTeamDetail_AdvTeamDetail_p", ref objmysqlconnection);
               objmysqlcommand.CommandType = CommandType.StoredProcedure;
               objmysqlcommand.Parameters.Add("Comp_Code1", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["Comp_Code1"].Value = Comp_Code;

               objmysqlcommand.Parameters.Add("userid1", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["userid1"].Value = userid;

               objmysqlcommand.Parameters.Add("Team_Code1", MySqlDbType.VarChar);
                
               objmysqlcommand.Parameters["Team_Code1"].Value = Team_Code;
               
               objmysqlcommand.Parameters.Add("Team_Name1", MySqlDbType.VarChar);
               
               objmysqlcommand.Parameters["Team_Name1"].Value = Team_Name;
                
               objmysqlcommand.Parameters.Add("zone", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["zone"].Value = zone;

               objmysqlcommand.Parameters.Add("Flag", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["Flag"].Value = Flag;
               
               objmysqlDataAdapter.SelectCommand = objmysqlcommand;
               objmysqlDataAdapter.Fill(objDataSet);
               return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }

        }


        public DataSet chkAdv(string Comp_Code, string Team_Code, string userid,string tname,string bname)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {

                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("chkAdv_chkAdv_p", ref objmysqlconnection);
               objmysqlcommand.CommandType = CommandType.StoredProcedure;

               objmysqlcommand.Parameters.Add("pComp_Code", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["pComp_Code"].Value = Comp_Code;

               objmysqlcommand.Parameters.Add("puserid", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["puserid"].Value = userid;

               objmysqlcommand.Parameters.Add("pTeam_Code", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["pTeam_Code"].Value = Team_Code;

               objmysqlcommand.Parameters.Add("ptname", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["ptname"].Value = tname;

               objmysqlcommand.Parameters.Add("pbname", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["pbname"].Value = bname;

               objmysqlDataAdapter.SelectCommand = objmysqlcommand;
               objmysqlDataAdapter.Fill(objDataSet);
               return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }

        }

        //public DataSet detailinserted(string exename, string designation, string address, string street, string city, string district, string state, string country, string pin, string phone, string status, string compcode, string userid, string teamcode, string report,string taluka, string repname, string adtype,string branchcode)
        public DataSet detailinserted(string exename, string teamcode, string designation, string address, string street, string city, string district, string state, string country, string pin, string phone, string status, string compcode, string userid, string report, string taluka, string repname, string adtype, string branchcode, string craditlimit, string mobile, string email, string mailto, string empcode, string attachment, string oldcode, string pextra1, string pextra2, string pextra3)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("execcontactinsert_execcontactinsert_p", ref objmysqlconnection);
               objmysqlcommand.CommandType = CommandType.StoredProcedure;

               objmysqlcommand.Parameters.Add("exename", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["exename"].Value = exename;

               objmysqlcommand.Parameters.Add("teamcode", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["teamcode"].Value = teamcode;

               objmysqlcommand.Parameters.Add("designation", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["designation"].Value = designation;

               objmysqlcommand.Parameters.Add("address", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["address"].Value = address;

               objmysqlcommand.Parameters.Add("street", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["street"].Value = street;

               objmysqlcommand.Parameters.Add("city", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["city"].Value = city;

               objmysqlcommand.Parameters.Add("district", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["district"].Value = district;

               objmysqlcommand.Parameters.Add("state", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["state"].Value = state;

               objmysqlcommand.Parameters.Add("country", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["country"].Value = country;

               objmysqlcommand.Parameters.Add("pin", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["pin"].Value = pin;

               objmysqlcommand.Parameters.Add("phone", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["phone"].Value = phone;

               objmysqlcommand.Parameters.Add("status", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["status"].Value = status;

               objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["compcode"].Value = compcode;

               objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["userid"].Value = userid;

               objmysqlcommand.Parameters.Add("report", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["report"].Value = report;

               objmysqlcommand.Parameters.Add("taluka1", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["taluka1"].Value = taluka;

               objmysqlcommand.Parameters.Add("repname", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["repname"].Value = repname;

               objmysqlcommand.Parameters.Add("adtype1", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["adtype1"].Value = adtype;

               objmysqlcommand.Parameters.Add("branchcode", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["branchcode"].Value = branchcode;

               objmysqlcommand.Parameters.Add("craditlimit", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["craditlimit"].Value = craditlimit;

               objmysqlcommand.Parameters.Add("mobile", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["mobile"].Value = mobile;

               objmysqlcommand.Parameters.Add("email", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["email"].Value = email;

               objmysqlcommand.Parameters.Add("mailto", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["mailto"].Value = mailto;

               objmysqlcommand.Parameters.Add("p_empcode", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["p_empcode"].Value = empcode;

               objmysqlcommand.Parameters.Add("attachment", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["attachment"].Value = attachment;

               objmysqlcommand.Parameters.Add("poldcode", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["poldcode"].Value = oldcode;

               objmysqlcommand.Parameters.Add("pextra1", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["pextra1"].Value = pextra1;

               objmysqlcommand.Parameters.Add("pextra2", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["pextra2"].Value = pextra2;

               objmysqlcommand.Parameters.Add("pextra3", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["pextra3"].Value = pextra3;

               objmysqlDataAdapter.SelectCommand = objmysqlcommand;
               objmysqlDataAdapter.Fill(objDataSet);
               return objDataSet;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }

        }


        public DataSet exebind(string compcode, string userid, string teamcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();

                //sqlcom = GetCommand("execcontactbind",ref sqlcon);
                objmysqlcommand = GetCommand("execcontactbind_grid", ref objmysqlconnection);
               objmysqlcommand.CommandType = CommandType.StoredProcedure;

               objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["compcode"].Value = compcode;

               objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["userid"].Value = userid;

               objmysqlcommand.Parameters.Add("teamcode", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["teamcode"].Value = teamcode;

               objmysqlDataAdapter.SelectCommand = objmysqlcommand;
               objmysqlDataAdapter.Fill(objDataSet);
               return objDataSet;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }

        }

        public DataSet detailinsertedexec(string compcode, string userid, string code)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("execselectbind_execselectbind_p", ref objmysqlconnection);
               objmysqlcommand.CommandType = CommandType.StoredProcedure;

               objmysqlcommand.Parameters.Add("pcompcode", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["pcompcode"].Value = compcode;

               objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["userid"].Value = userid;

               objmysqlcommand.Parameters.Add("code1", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["code1"].Value = code;

               objmysqlDataAdapter.SelectCommand = objmysqlcommand;
               objmysqlDataAdapter.Fill(objDataSet);
               return objDataSet;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }
        }

        public DataSet detailupdate(string exename, string designation, string address, string street, string city, string district, string state, string country, string pin, string phone, string status, string compcode, string userid, string teamcode, string code, string report, string taluka, string repname, string adtype, string brancgname1, string craditlimit, string email, string mobile, string empcode, string mailto, string attachment, string oldcode, string pextra1)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("execcontactupdate_execcontactupdate_p", ref objmysqlconnection);
               objmysqlcommand.CommandType = CommandType.StoredProcedure;

               objmysqlcommand.Parameters.Add("p_exename", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["p_exename"].Value = exename;

               objmysqlcommand.Parameters.Add("p_designation", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["p_designation"].Value = designation;

               objmysqlcommand.Parameters.Add("p_address", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["p_address"].Value = address;

               objmysqlcommand.Parameters.Add("p_street", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["p_street"].Value = street;

               objmysqlcommand.Parameters.Add("p_city", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["p_city"].Value = city;

               objmysqlcommand.Parameters.Add("p_district", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["p_district"].Value = district;

               objmysqlcommand.Parameters.Add("p_state", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["p_state"].Value = state;

               objmysqlcommand.Parameters.Add("p_country", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["p_country"].Value = country;

               objmysqlcommand.Parameters.Add("p_pin", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["p_pin"].Value = pin;

               objmysqlcommand.Parameters.Add("p_phone", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["p_phone"].Value = phone;

               objmysqlcommand.Parameters.Add("p_status", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["p_status"].Value = status;

               objmysqlcommand.Parameters.Add("p_compcode", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["p_compcode"].Value = compcode;

               objmysqlcommand.Parameters.Add("p_userid", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["p_userid"].Value = userid;

               objmysqlcommand.Parameters.Add("p_teamcode", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["p_teamcode"].Value = teamcode;

               objmysqlcommand.Parameters.Add("p_code", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["p_code"].Value = code;

               objmysqlcommand.Parameters.Add("p_report", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["p_report"].Value = report;

               objmysqlcommand.Parameters.Add("p_TALUKA1", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["p_TALUKA1"].Value = taluka;

               objmysqlcommand.Parameters.Add("p_repname", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["p_repname"].Value = repname;

               objmysqlcommand.Parameters.Add("p_adtype1", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["p_adtype1"].Value = adtype;
                
               objmysqlcommand.Parameters.Add("p_branchcode", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["p_branchcode"].Value = brancgname1;

               objmysqlcommand.Parameters.Add("p_craditlimit", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["p_craditlimit"].Value = craditlimit;

               objmysqlcommand.Parameters.Add("p_mobile", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["p_mobile"].Value = mobile;

               objmysqlcommand.Parameters.Add("p_email", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["p_email"].Value = email;

               objmysqlcommand.Parameters.Add("p_mailto", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["p_mailto"].Value = mailto;

               objmysqlcommand.Parameters.Add("p_empcode", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["p_empcode"].Value = empcode;

               objmysqlcommand.Parameters.Add("pattachment", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["pattachment"].Value = attachment;

               objmysqlcommand.Parameters.Add("poldcode", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["poldcode"].Value = oldcode;

               objmysqlcommand.Parameters.Add("pextra1", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["pextra1"].Value = pextra1;

               objmysqlDataAdapter.SelectCommand = objmysqlcommand;
               objmysqlDataAdapter.Fill(objDataSet);
               return objDataSet;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }

        } 



        public DataSet deleteexecdetail(string compcode, string userid, string code)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("execdelete_execdelete_p", ref objmysqlconnection);
               objmysqlcommand.CommandType = CommandType.StoredProcedure;

               objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["compcode"].Value = compcode;

               objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["userid"].Value = userid;

               objmysqlcommand.Parameters.Add("code1", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["code1"].Value = code;

               objmysqlDataAdapter.SelectCommand = objmysqlcommand;
               objmysqlDataAdapter.Fill(objDataSet);
               return objDataSet;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }
}



        public DataSet chkpopup(string teamcode, string compcode, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("chkpopteam_chkpopteam_p", ref objmysqlconnection);
               objmysqlcommand.CommandType = CommandType.StoredProcedure;

               objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["compcode"].Value = compcode;

               objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["userid"].Value = userid;

               objmysqlcommand.Parameters.Add("teamcode", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["teamcode"].Value = teamcode;

               objmysqlDataAdapter.SelectCommand = objmysqlcommand;
               objmysqlDataAdapter.Fill(objDataSet);
               return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }
        }


        public DataSet addpickdistname(string citycode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("FILLSTAEDISTCOUNTRY_FILLSTAEDISTCOUNTRY_P", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("citycode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["citycode"].Value = citycode;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }

        }

        public DataSet report(string compcode, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("bindreportto_bindreportto_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }

        }

        public DataSet valueofcount(string countcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("getcountryname", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("countcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["countcode"].Value = countcode;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }

        }



        public DataSet chkexeccode1(string str, string region)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("chkadvexename_chkadvexename_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("str", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["str"].Value = str;

                objmysqlcommand.Parameters.Add("cod", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["cod"].Value = str;

                objmysqlcommand.Parameters.Add("region1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["region1"].Value = region;


                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }
        }


        public DataSet chkexecname1(string Comp_Code, string exename, string userid, string teamcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {

                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("chkexecname_chkexecname_p", ref objmysqlconnection);
               objmysqlcommand.CommandType = CommandType.StoredProcedure;

               objmysqlcommand.Parameters.Add("Comp_Code", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["Comp_Code"].Value = Comp_Code;

               objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["userid"].Value = userid;

               objmysqlcommand.Parameters.Add("execname", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["execname"].Value = exename;

               objmysqlcommand.Parameters.Add("teamcode1", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["teamcode1"].Value = teamcode;

               objmysqlDataAdapter.SelectCommand = objmysqlcommand;
               objmysqlDataAdapter.Fill(objDataSet);
               return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }

        }





        public DataSet bindteam1()
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("addpubname_addpubname_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                //				objmysqlcommand.Parameters.Add("dist", MySqlDbType.VarChar);
                //				objmysqlcommand.Parameters["dist"].Value =dist;
                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }


        }











        public DataSet adcategory1()
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("adcat", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                //				objmysqlcommand.Parameters.Add("dist", MySqlDbType.VarChar);
                //				objmysqlcommand.Parameters["dist"].Value =dist;
                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }


        }

        public DataSet addesignation(string compcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("addesignation_addesignation_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;
                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }


        }

        public DataSet adzone(string userid, string compcode)
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();

                objmysqlcommand = GetCommand("branchbind_adv_branchbind_adv_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }

        }





        public DataSet countczone(string pub)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("fillzone_fillzone_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("pub", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pub"].Value = pub;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }


        }


//-----------------------------ad new function ================================================================================//
        public void insertedExecAdetail(string compcode, string userid, string teamcode, string adcategory, string flag, string execode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("execcontactinsertadcat", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("flag", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["flag"].Value = flag;

                objmysqlcommand.Parameters.Add("adcategory", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adcategory"].Value = adcategory;

                objmysqlcommand.Parameters.Add("execode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["execode"].Value = execode;

                objmysqlcommand.Parameters.Add("teamcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["teamcode"].Value = teamcode;


                objmysqlcommand.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }
        }

        public DataSet addrepname(string compcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("getrepname", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;



                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }
        }

        public DataSet typebind(string compcode, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("adtype", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }
        }

        public DataSet addadvcat(string adtypcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("addadvcatpage", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("adtypcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adtypcode"].Value = adtypcode;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }
        }


        public void deleteExecAdetail(string compcode, string code)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("execcontactdeleteadcat", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("execode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["execode"].Value = code;



                objmysqlcommand.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }


        }


        public DataSet team(string compcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("BIND_TEAM", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }
        }

    /*   public void insertedExecAdetail(string compcode, string userid, string teamcode, string adcategory, string flag, string execode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("execcontactinsertadcat", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;



                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("flag", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["flag"].Value = flag;

                objmysqlcommand.Parameters.Add("adcategory", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adcategory"].Value = adcategory;

                objmysqlcommand.Parameters.Add("execode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["execode"].Value = execode;

                objmysqlcommand.Parameters.Add("teamcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["teamcode"].Value = teamcode;


                objmysqlcommand.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }
        }*/

    }
}