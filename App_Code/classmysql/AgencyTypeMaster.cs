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
{
    /// <summary>
    /// Summary description for AgencyTypeMaster
    /// </summary>
    public class AgencyTypeMaster:connection
    {
        public AgencyTypeMaster()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataSet atmsave(string companycode, string code, string name, string alias, string UserId, string txtefffrom, string txtefftill, string commrate, string commapply, string creditdays, string adcat, string uniqueid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("atm_Save_atm_Save_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = companycode;

                objmysqlcommand.Parameters.Add("atc", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["atc"].Value = code;

                objmysqlcommand.Parameters.Add("atn", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["atn"].Value = name;

                objmysqlcommand.Parameters.Add("ata", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["ata"].Value = alias;

                objmysqlcommand.Parameters.Add("USERID1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["USERID1"].Value = UserId;

                objmysqlcommand.Parameters.Add("effectivefrom", MySqlDbType.DateTime);

                if (txtefffrom == null || txtefffrom == "" || txtefffrom == "undefined/undefined/")
                {
                    objmysqlcommand.Parameters["effectivefrom"].Value = System.DBNull.Value;

                }
                else
                {
                    objmysqlcommand.Parameters["effectivefrom"].Value = txtefffrom;// Convert.ToDateTime(txtefffrom);
                }

                objmysqlcommand.Parameters.Add("effectivetill", MySqlDbType.DateTime);
                if (txtefftill == null || txtefftill == "" || txtefftill == "undefined/undefined/")
                {
                    objmysqlcommand.Parameters["effectivetill"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["effectivetill"].Value = txtefftill;// Convert.ToDateTime(txtefftill);

                }


                objmysqlcommand.Parameters.Add("commrate", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["commrate"].Value = commrate;

                objmysqlcommand.Parameters.Add("commapply", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["commapply"].Value = commapply;

                objmysqlcommand.Parameters.Add("creditdays", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["creditdays"].Value = creditdays;

                objmysqlcommand.Parameters.Add("adcat", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adcat"].Value = adcat;

                objmysqlcommand.Parameters.Add("uniqueid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["uniqueid"].Value = uniqueid;


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

        public DataSet atmmodify(string companycode, string agcode, string name, string alias, string UserId, string txtefffrom, string txtefftill, string commrate, string commdetail, string creditdays, string adcat, string uniqueid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("atm_Modify_atm_Modify_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = companycode;

                objmysqlcommand.Parameters.Add("atc", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["atc"].Value = agcode;

                objmysqlcommand.Parameters.Add("atn", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["atn"].Value = name;

                objmysqlcommand.Parameters.Add("ata", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["ata"].Value = alias;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = UserId;

                objmysqlcommand.Parameters.Add("effectivefrom", MySqlDbType.DateTime);

                if (txtefffrom == null || txtefffrom == "" || txtefffrom == "undefined/undefined/")
                {
                    objmysqlcommand.Parameters["effectivefrom"].Value = System.DBNull.Value;

                }
                else
                {
                    objmysqlcommand.Parameters["effectivefrom"].Value = txtefffrom;// Convert.ToDateTime(txtefffrom).ToString("yyyy-MM-dd");
                }

                objmysqlcommand.Parameters.Add("effectivetill", MySqlDbType.DateTime);
                if (txtefftill == null || txtefftill == "" || txtefftill == "undefined/undefined/")
                {
                    objmysqlcommand.Parameters["effectivetill"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["effectivetill"].Value = txtefftill;//Convert.ToDateTime(txtefftill).ToString("yyyy-MM-dd");

                }

                objmysqlcommand.Parameters.Add("commrate", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["commrate"].Value = commrate;

                objmysqlcommand.Parameters.Add("commapply", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["commapply"].Value = commdetail;

                objmysqlcommand.Parameters.Add("creditdays", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["creditdays"].Value = creditdays;

                objmysqlcommand.Parameters.Add("adcat", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adcat"].Value = adcat;

                objmysqlcommand.Parameters.Add("uniqueid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["uniqueid"].Value = uniqueid;


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

        public DataSet atmdelete(string companycode, string code, string name, string alias, string UserId, string id)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("atm_Delete_atm_Delete_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = companycode;

                objmysqlcommand.Parameters.Add("atc", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["atc"].Value = code;

                objmysqlcommand.Parameters.Add("atn", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["atn"].Value = name;

                objmysqlcommand.Parameters.Add("ata", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["ata"].Value = alias;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = UserId;


                objmysqlcommand.Parameters.Add("id", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["id"].Value = id;

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

        public DataSet atmexecute(string companycode, string code, string name, string alias, string UserId)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("atm_Execute_atm_Execute_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = companycode;

                objmysqlcommand.Parameters.Add("atc", MySqlDbType.VarChar);
                if (code != "" && code != null)
                {
                    objmysqlcommand.Parameters["atc"].Value = code;
                }
                else
                {
                    objmysqlcommand.Parameters["atc"].Value = "%%";
                }

                objmysqlcommand.Parameters.Add("atn", MySqlDbType.VarChar);
                if (name != "" && name != null)
                {
                    objmysqlcommand.Parameters["atn"].Value = name;
                }
                else
                {
                    objmysqlcommand.Parameters["atn"].Value = "%%";
                }

                objmysqlcommand.Parameters.Add("ata", MySqlDbType.VarChar);
                if (alias != "" && alias != null)
                {
                    objmysqlcommand.Parameters["ata"].Value = alias;
                }
                else
                {
                    objmysqlcommand.Parameters["ata"].Value = "%%";
                }
                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = UserId;

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

        public DataSet atmexecute1(string companycode, string code, string name, string alias, string UserId)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("atm_Execute_atm_Execute_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = companycode;

                objmysqlcommand.Parameters.Add("atc", MySqlDbType.VarChar);
                if (code != "" && code != null)
                {
                    objmysqlcommand.Parameters["atc"].Value = code;
                }
                else
                {
                    objmysqlcommand.Parameters["atc"].Value = "%%";
                }

                objmysqlcommand.Parameters.Add("atn", MySqlDbType.VarChar);
                if (name != "" && name != null)
                {
                    objmysqlcommand.Parameters["atn"].Value = name;
                }
                else
                {
                    objmysqlcommand.Parameters["atn"].Value = "%%";
                }

                objmysqlcommand.Parameters.Add("ata", MySqlDbType.VarChar);
                if (alias != "" && alias != null)
                {
                    objmysqlcommand.Parameters["ata"].Value = alias;
                }
                else
                {
                    objmysqlcommand.Parameters["ata"].Value = "%%";
                }
                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = UserId;

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

   /*    public DataSet atmfpnl()
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("atmfpnl", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

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
        }*/

        public DataSet chkatmcode(string companycode, string UserId, string agcode, string adname)
           {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("atmcheck_atmcheck_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = companycode;

                objmysqlcommand.Parameters.Add("atc", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["atc"].Value = agcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = UserId;

                objmysqlcommand.Parameters.Add("adname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adname"].Value = adname;

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



        public DataSet agtypecode(string str)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("autoagtypecode_autoagtypecode_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("str", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["str"].Value = str;

                objmysqlcommand.Parameters.Add("cod", MySqlDbType.VarChar);
                if (str.Length > 2)
                {
                    objmysqlcommand.Parameters["cod"].Value = str.Substring(0, 2);
                }
                else
                {
                    objmysqlcommand.Parameters["cod"].Value = str;
                }


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
        public DataSet saveagencytype_UPDATE(string compcode, string agency_type, string comm_type, string comm_rate, string from_days, string till_days, string valid_from, string valid_to, string userid, string extra1, string extra2, string extra3, string extra4, string extra5)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("websp_agency_type_slab_UPDATE", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                // objmysqlcommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                //com.Parameters["@compcode"].Value = compcode;

                 objmysqlcommand.Parameters.Add("P_AGENCY_TYPE", MySqlDbType.VarChar);
                 objmysqlcommand.Parameters["P_AGENCY_TYPE"].Value = agency_type;

                 objmysqlcommand.Parameters.Add("P_COMM_TYPE", MySqlDbType.VarChar);
                 objmysqlcommand.Parameters["P_COMM_TYPE"].Value = comm_type;


                 objmysqlcommand.Parameters.Add("P_COMM_RATE", MySqlDbType.VarChar);

                 objmysqlcommand.Parameters["P_COMM_RATE"].Value = comm_rate;



                 objmysqlcommand.Parameters.Add("P_FROM_DAYS", MySqlDbType.VarChar);
                 objmysqlcommand.Parameters["P_FROM_DAYS"].Value = from_days;

                 objmysqlcommand.Parameters.Add("P_TILL_DAYS", MySqlDbType.VarChar);
                 objmysqlcommand.Parameters["P_TILL_DAYS"].Value = till_days;



                 objmysqlcommand.Parameters.Add("P_VALID_FROM", MySqlDbType.VarChar);
                 objmysqlcommand.Parameters["P_VALID_FROM"].Value = valid_from;




                 objmysqlcommand.Parameters.Add("P_VALID_TO", MySqlDbType.VarChar);
                 objmysqlcommand.Parameters["P_VALID_TO"].Value = valid_to;




                 objmysqlcommand.Parameters.Add("P_USERID", MySqlDbType.VarChar);
                 objmysqlcommand.Parameters["P_USERID"].Value = userid;



                 objmysqlcommand.Parameters.Add("P_EXTRA1", MySqlDbType.VarChar);
                 objmysqlcommand.Parameters["P_EXTRA1"].Value = extra1;




                 objmysqlcommand.Parameters.Add("P_EXTRA2", MySqlDbType.VarChar);
                 objmysqlcommand.Parameters["P_EXTRA2"].Value = extra2;





                 objmysqlcommand.Parameters.Add("P_EXTRA3", MySqlDbType.VarChar);
                 objmysqlcommand.Parameters["P_EXTRA3"].Value = extra3;



                 objmysqlcommand.Parameters.Add("P_EXTRA4", MySqlDbType.VarChar);
                 objmysqlcommand.Parameters["P_EXTRA4"].Value = extra4;



                 objmysqlcommand.Parameters.Add("P_EXTRA5", MySqlDbType.VarChar);
                 objmysqlcommand.Parameters["P_EXTRA5"].Value = extra5;


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

        public DataSet cheakduplicacy(string compcode, string cotype, string corate, string fromdays, string todays, string validfrom, string validto)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("WEBSP_AG_TYPE_SLAB_DUPLI", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("p_compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["p_compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("p_commtype", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["p_commtype"].Value = cotype;

                objmysqlcommand.Parameters.Add("p_commrate", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["p_commrate"].Value = corate;

                objmysqlcommand.Parameters.Add("p_fromdays", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["p_fromdays"].Value = fromdays;

                objmysqlcommand.Parameters.Add("p_todays", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["p_todays"].Value = todays;

                objmysqlcommand.Parameters.Add("p_validfrom", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["p_validfrom"].Value = validfrom;

                objmysqlcommand.Parameters.Add("p_validto", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["p_validto"].Value = validto;


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

        public DataSet saveagencytype(string compcode, string agency_type, string comm_type, string comm_rate, string from_days, string till_days, string valid_from, string valid_to, string userid, string extra1, string extra2, string extra3, string extra4, string extra5, string dateformat)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {

                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("websp_agency_type_slab", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;


                objmysqlcommand.Parameters.Add("P_COMPCODE", SqlDbType.VarChar);
                objmysqlcommand.Parameters["P_COMPCODE"].Value = compcode;

                objmysqlcommand.Parameters.Add("P_AGENCY_TYPE", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["P_AGENCY_TYPE"].Value = agency_type;

                objmysqlcommand.Parameters.Add("P_COMM_TYPE", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["P_COMM_TYPE"].Value = comm_type;


                objmysqlcommand.Parameters.Add("P_COMM_RATE", MySqlDbType.VarChar);

                if (comm_rate == "")
                {
                    objmysqlcommand.Parameters["P_COMM_RATE"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["P_COMM_RATE"].Value = comm_rate;
                }


                objmysqlcommand.Parameters.Add("P_FROM_DAYS", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["P_FROM_DAYS"].Value = from_days;

                objmysqlcommand.Parameters.Add("P_TILL_DAYS", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["P_TILL_DAYS"].Value = till_days;

                objmysqlcommand.Parameters.Add("P_VALID_FROM", MySqlDbType.VarChar); 
                if (valid_from == "" || valid_from == null)
                {
                    objmysqlcommand.Parameters["P_VALID_FROM"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "mm/dd/yyyy")
                    {
                        string[] arr = valid_from.Split('/');
                        string mm = arr[0];
                        string dd = arr[1];
                        string yy = arr[2];
                        valid_from = yy + "/" + mm + "/" + dd;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = valid_from.Split('/');
                        string yy = arr[0];
                        string mm = arr[1];
                        string dd = arr[2];
                        valid_from = mm + "/" + dd + "/" + yy;
                    }
                    valid_from = valid_from.Replace("/", "-") + " 00:00:00";
                    objmysqlcommand.Parameters["@P_VALID_FROM"].Value = valid_from;
                }


                
                objmysqlcommand.Parameters.Add("P_VALID_TO", MySqlDbType.VarChar); 
                if (valid_to == "" || valid_to == null)
                {
                    objmysqlcommand.Parameters["P_VALID_TO"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "mm/dd/yyyy")
                    {
                        string[] arr = valid_to.Split('/');
                        string mm = arr[0];
                        string dd = arr[1];
                        string yy = arr[2];
                        valid_to = yy + "/" + mm + "/" + dd;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = valid_to.Split('/');
                        string yy = arr[0];
                        string mm = arr[1];
                        string dd = arr[2];
                        valid_to = mm + "/" + dd + "/" + yy;
                    }
                    valid_to = valid_to.Replace("/", "-")+" 00:00:00";
                    //objmysqlcommand.Parameters["P_VALID_TO"].Value = Convert.ToDateTime(valid_to);
                    objmysqlcommand.Parameters["P_VALID_TO"].Value = valid_to;
                }


                objmysqlcommand.Parameters.Add("P_USERID", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["P_USERID"].Value = userid;



                objmysqlcommand.Parameters.Add("P_EXTRA1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["P_EXTRA1"].Value = extra1;




                objmysqlcommand.Parameters.Add("P_EXTRA2", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["P_EXTRA2"].Value = extra2;





                objmysqlcommand.Parameters.Add("P_EXTRA3", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["P_EXTRA3"].Value = extra3;



                objmysqlcommand.Parameters.Add("P_EXTRA4", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["P_EXTRA4"].Value = extra4;



                objmysqlcommand.Parameters.Add("P_EXTRA5", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["P_EXTRA5"].Value = extra5;


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
        //public DataSet test_agency(string spname, string tbname, string[] recParVal, string[] recParNam)
        //{
        //    MySqlConnection objmysqlconnection;
        //    MySqlCommand objmysqlcommand;
        //    objmysqlconnection = GetConnection();
        //    MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
        //    DataSet objDataSet = new DataSet();

        //    objmysqlcommand.Connection = objmysqlcommand;
        //    objmysqlcommand.CommandType = CommandType.StoredProcedure;
        //    objmysqlcommand.CommandText = spname;
        //    if (objmysqlcommand.Parameters.Count > 0)
        //    {
        //        objmysqlcommand.Parameters.Clear();
        //    }
        //    for (int i = 0; i < recParVal.count(); i++)
        //    {
        //        objmysqlcommand.Parameters.AddWithValue(recParNam[i], recParVal[i]);
        //        objmysqlcommand.Parameters[recParNam[i]].Direction = ParameterDirection.Input;
        //    }
        //    objmysqlDataAdapter = new MySqlDataAdapter(objmysqlcommand);
        //    if (tbname == null)
        //        objmysqlDataAdapter.Fill(objDataSet);
        //    else
        //        objmysqlDataAdapter.Fill(objDataSet, tbname);
        //}


        

    }
}