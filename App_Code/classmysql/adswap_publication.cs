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
    /// Summary description for adswap_publication
    /// </summary>
    public class adswap_publication : connection
    {
        public adswap_publication()
        {
            //
            // TODO: Add constructor logic here
            //
        }



        public DataSet Pripubcode(string compcode, string userid)
        {
            MySqlConnection objMySqlConnection;
            MySqlCommand objMySqlCommand;
            objMySqlConnection = GetConnection();

            MySqlDataAdapter objMySqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objMySqlConnection.Open();
                objMySqlCommand = GetCommand("Websp_addpubcode", ref objMySqlConnection);
                objMySqlCommand.CommandType = CommandType.StoredProcedure;

                objMySqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objMySqlCommand.Parameters["compcode"].Value = compcode;

                objMySqlCommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objMySqlCommand.Parameters["userid"].Value = userid;

                objMySqlDataAdapter.SelectCommand = objMySqlCommand;
                objMySqlDataAdapter.Fill(objDataSet);

                return objDataSet;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objMySqlConnection);
            }
        }

        public DataSet centercode(string compcode, string userid)
        {
            MySqlConnection objMySqlConnection;
            MySqlCommand objMySqlCommand;
            objMySqlConnection = GetConnection();
            MySqlDataAdapter objMySqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objMySqlConnection.Open();
                objMySqlCommand = GetCommand("Websp_addcenter", ref objMySqlConnection);
                objMySqlCommand.CommandType = CommandType.StoredProcedure;

                objMySqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objMySqlCommand.Parameters["compcode"].Value = compcode;

                objMySqlCommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objMySqlCommand.Parameters["userid"].Value = userid;

                objMySqlDataAdapter.SelectCommand = objMySqlCommand;
                objMySqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objMySqlConnection);
            }
        }

        //Get edition Code from preference
        public DataSet editioncode(string compcode, string userid)/*, string pubcode)*/
        {
            MySqlConnection objMySqlConnection;
            MySqlCommand objMySqlCommand;
            objMySqlConnection = GetConnection();
            MySqlDataAdapter objMySqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objMySqlConnection.Open();
                objMySqlCommand = GetCommand("websp_addedition_p", ref objMySqlConnection);
                objMySqlCommand.CommandType = CommandType.StoredProcedure;

                objMySqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objMySqlCommand.Parameters["compcode"].Value = compcode;

                objMySqlCommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objMySqlCommand.Parameters["userid"].Value = userid;

                objMySqlDataAdapter.SelectCommand = objMySqlCommand;
                objMySqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objMySqlConnection);
            }
        }


        public DataSet secpubcode(string compcode, string userid)
        {
            MySqlConnection objMySqlConnection;
            MySqlCommand objMySqlCommand;
            objMySqlConnection = GetConnection();
            MySqlDataAdapter objMySqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objMySqlConnection.Open();
                objMySqlCommand = GetCommand("Websp_addsecpub", ref objMySqlConnection);
                objMySqlCommand.CommandType = CommandType.StoredProcedure;

                objMySqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objMySqlCommand.Parameters["compcode"].Value = compcode;

                objMySqlCommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objMySqlCommand.Parameters["userid"].Value = userid;

                objMySqlDataAdapter.SelectCommand = objMySqlCommand;
                objMySqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objMySqlConnection);
            }
        }


        public DataSet clsViewBooking(string compcode, string pubdate, string pubcode, string centercode, string editioncode, string suppcode, string dateformat, string pageno, string extra1)
        {
            MySqlConnection objMySqlConnection;
            MySqlCommand objMySqlCommand;
            DataSet objDataSet = new DataSet();
            objMySqlConnection = GetConnection();

            MySqlDataAdapter objorclDataAdapter = new MySqlDataAdapter();
            try
            {
                objMySqlConnection.Open();
                objMySqlCommand = GetCommand("Websp_getadswap_publication", ref objMySqlConnection);
                objMySqlCommand.CommandType = CommandType.StoredProcedure;

                objMySqlCommand.Parameters.Add("pubdate", MySqlDbType.VarChar);
                if (pubdate == "" || pubdate == null)
                {
                    objMySqlCommand.Parameters["pubdate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = pubdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        pubdate = yy + "/" + mm + "/" + dd;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = pubdate.Split('/');
                        string mm = arr[0];
                        string dd = arr[1];
                        string yy = arr[2];
                        pubdate = yy + "/" + mm + "/" + dd;
                    }
                    objMySqlCommand.Parameters["pubdate"].Value = pubdate;
                }
                objMySqlCommand.Parameters.Add("pubcode", MySqlDbType.VarChar);
                objMySqlCommand.Parameters["pubcode"].Value = pubcode;

                objMySqlCommand.Parameters.Add("centercode", MySqlDbType.VarChar);
                objMySqlCommand.Parameters["centercode"].Value = centercode;

                objMySqlCommand.Parameters.Add("editioncode", MySqlDbType.VarChar);
                objMySqlCommand.Parameters["editioncode"].Value = editioncode;

                objMySqlCommand.Parameters.Add("suppcode", MySqlDbType.VarChar);
                objMySqlCommand.Parameters["suppcode"].Value = suppcode;

                objMySqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objMySqlCommand.Parameters["compcode"].Value = compcode;

                objMySqlCommand.Parameters.Add("pageno", MySqlDbType.VarChar);
                if (pageno == "")
                    objMySqlCommand.Parameters["pageno"].Value = "0"; //System.DBNull.Value;
                else
                    objMySqlCommand.Parameters["pageno"].Value = pageno;

                objMySqlCommand.Parameters.Add("pextra1", MySqlDbType.VarChar);
                objMySqlCommand.Parameters["pextra1"].Value = extra1;

                objorclDataAdapter.SelectCommand = objMySqlCommand;
                objorclDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objMySqlConnection.Close();
            }
        }


        public DataSet editioncodes_dt(string pubdate, string centercode, string userid, string pubcode, string dateformat)
        {
            MySqlConnection objMySqlConnection;
            MySqlCommand objMySqlCommand;
            objMySqlConnection = GetConnection();
            MySqlDataAdapter objMySqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objMySqlConnection.Open();
                objMySqlCommand = GetCommand("websp_addeditions_dt", ref objMySqlConnection);
                objMySqlCommand.CommandType = CommandType.StoredProcedure;

                objMySqlCommand.Parameters.Add("centercode", MySqlDbType.VarChar);
                objMySqlCommand.Parameters["centercode"].Value = centercode;

                objMySqlCommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objMySqlCommand.Parameters["userid"].Value = userid;

                objMySqlCommand.Parameters.Add("pubcode", MySqlDbType.VarChar);
                objMySqlCommand.Parameters["pubcode"].Value = pubcode;

                objMySqlCommand.Parameters.Add("pubdate", MySqlDbType.VarChar);
                if (pubdate == "" || pubdate == null)
                {
                    objMySqlCommand.Parameters["pubdate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = pubdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        pubdate = yy + "/" + mm + "/" + dd;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = pubdate.Split('/');
                        string mm = arr[0];
                        string dd = arr[1];
                        string yy = arr[2];
                        pubdate = yy + "/" + mm + "/" + dd;
                    }
                    objMySqlCommand.Parameters["pubdate"].Value = pubdate;
                }

                objMySqlDataAdapter.SelectCommand = objMySqlCommand;
                objMySqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objMySqlConnection);
            }
        }



        public DataSet secpubcodes(string compcode, string userid, string editioncode)
        {
            MySqlConnection objMySqlConnection;
            MySqlCommand objMySqlCommand;
            objMySqlConnection = GetConnection();
            MySqlDataAdapter objMySqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objMySqlConnection.Open();
                objMySqlCommand = GetCommand("Websp_Addsecpubs", ref objMySqlConnection);
                objMySqlCommand.CommandType = CommandType.StoredProcedure;

                objMySqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objMySqlCommand.Parameters["compcode"].Value = compcode;

                objMySqlCommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objMySqlCommand.Parameters["userid"].Value = userid;

                objMySqlCommand.Parameters.Add("editioncode", MySqlDbType.VarChar);
                objMySqlCommand.Parameters["editioncode"].Value = editioncode;

                objMySqlDataAdapter.SelectCommand = objMySqlCommand;
                objMySqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objMySqlConnection);
            }
        }




        public DataSet clsBindCenters(string compcode, string userid, string extra1,string extra2,string extra3)
        {
            MySqlConnection objMySqlConnection;
            MySqlCommand objMySqlCommand;
            objMySqlConnection = GetConnection();
            MySqlDataAdapter objMySqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objMySqlConnection.Open();
                objMySqlCommand = GetCommand("websp_binddata_swap", ref objMySqlConnection);
                objMySqlCommand.CommandType = CommandType.StoredProcedure;

                objMySqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objMySqlCommand.Parameters["compcode"].Value = compcode;

                objMySqlCommand.Parameters.Add("usercode", MySqlDbType.VarChar);
                objMySqlCommand.Parameters["usercode"].Value = userid;

                objMySqlCommand.Parameters.Add("extra1", MySqlDbType.VarChar);
                objMySqlCommand.Parameters["extra1"].Value = extra1;

                objMySqlCommand.Parameters.Add("extra2", MySqlDbType.VarChar);
                objMySqlCommand.Parameters["extra2"].Value = extra2;

                objMySqlCommand.Parameters.Add("extra3", MySqlDbType.VarChar);
                objMySqlCommand.Parameters["extra3"].Value = extra3;

                objMySqlDataAdapter.SelectCommand = objMySqlCommand;
                objMySqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objMySqlConnection);
            }
        }



        public DataSet swaptransferdata(string compcode, string insertdate, string booking_id, string booking_inserid, string pripub, string bkfor, string editionc, string secpubc, string pubtypec, string userid, string bk_allbackup, string PSWAP_TYPE, string extra1, string extra2, string extra3)
        {
            MySqlConnection objMySqlConnection;
            MySqlCommand objMySqlCommand;
            objMySqlConnection = GetConnection();
            MySqlDataAdapter objMySqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objMySqlConnection.Open();
                objMySqlCommand = GetCommand("websp_swaptransferdata", ref objMySqlConnection);
                objMySqlCommand.CommandType = CommandType.StoredProcedure;

                objMySqlCommand.Parameters.Add("pcompcode", MySqlDbType.VarChar);
                objMySqlCommand.Parameters["pcompcode"].Value = compcode;

                objMySqlCommand.Parameters.Add("pinsertdate", MySqlDbType.VarChar);
                objMySqlCommand.Parameters["pinsertdate"].Value = insertdate;

                objMySqlCommand.Parameters.Add("pbooking_id", MySqlDbType.VarChar);
                objMySqlCommand.Parameters["pbooking_id"].Value = booking_id;

                objMySqlCommand.Parameters.Add("pbooking_inserid", MySqlDbType.VarChar);
                objMySqlCommand.Parameters["pbooking_inserid"].Value = booking_inserid;

                objMySqlCommand.Parameters.Add("ppripub", MySqlDbType.VarChar);
                objMySqlCommand.Parameters["ppripub"].Value = pripub;

                objMySqlCommand.Parameters.Add("pbkfor", MySqlDbType.VarChar);
                objMySqlCommand.Parameters["pbkfor"].Value = bkfor;

                objMySqlCommand.Parameters.Add("peditionc", MySqlDbType.VarChar);
                objMySqlCommand.Parameters["peditionc"].Value = editionc;

                objMySqlCommand.Parameters.Add("psecpub", MySqlDbType.VarChar);
                objMySqlCommand.Parameters["psecpub"].Value = secpubc;

                objMySqlCommand.Parameters.Add("pedtn_flag", MySqlDbType.VarChar);
                objMySqlCommand.Parameters["pedtn_flag"].Value = pubtypec;

                objMySqlCommand.Parameters.Add("puserid", MySqlDbType.VarChar);
                objMySqlCommand.Parameters["puserid"].Value = userid;

                objMySqlCommand.Parameters.Add("pbk_allbackup", MySqlDbType.VarChar);
                objMySqlCommand.Parameters["pbk_allbackup"].Value = bk_allbackup;

                objMySqlCommand.Parameters.Add("pswap_type", MySqlDbType.VarChar);
                objMySqlCommand.Parameters["pswap_type"].Value = PSWAP_TYPE;

                objMySqlCommand.Parameters.Add("pextra1", MySqlDbType.VarChar);
                objMySqlCommand.Parameters["pextra1"].Value = extra1;

                objMySqlCommand.Parameters.Add("pextra2", MySqlDbType.VarChar);
                objMySqlCommand.Parameters["pextra2"].Value = extra2;

                objMySqlCommand.Parameters.Add("pextra3", MySqlDbType.VarChar);
                objMySqlCommand.Parameters["pextra3"].Value = extra3;

                objMySqlDataAdapter.SelectCommand = objMySqlCommand;
                objMySqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objMySqlConnection);
            }
        }




    }

}