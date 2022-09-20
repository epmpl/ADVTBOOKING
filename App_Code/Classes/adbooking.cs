using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

/// <summary>
/// Summary description for adbooking
/// </summary>
/// 

namespace NewAdbooking.Classes
{
    public class adbooking : connection
    {
        public adbooking()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataSet getCouAmount(string compcode, string center, string coutype)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getCouAmount", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlDataAdapter = new SqlDataAdapter();
                objSqlCommand.Parameters.Add("@COMPCODE_P", SqlDbType.VarChar);
                objSqlCommand.Parameters["@COMPCODE_P"].Value = compcode;

                objSqlCommand.Parameters.Add("@CENTER_P", SqlDbType.VarChar);
                objSqlCommand.Parameters["@CENTER_P"].Value = center;

                objSqlCommand.Parameters.Add("@COU_TYPE_P", SqlDbType.VarChar);
                objSqlCommand.Parameters["@COU_TYPE_P"].Value = coutype;




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
                CloseConnection(ref objSqlConnection);
            }
        }
        public DataSet chkCoupan(string compcode, string center, string cpnno)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("chkCoupan", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlDataAdapter = new SqlDataAdapter();
                objSqlCommand.Parameters.Add("@COMPCODE_P", SqlDbType.VarChar);
                objSqlCommand.Parameters["@COMPCODE_P"].Value = compcode;

                objSqlCommand.Parameters.Add("@CENTER_P", SqlDbType.VarChar);
                objSqlCommand.Parameters["@CENTER_P"].Value = center;

                objSqlCommand.Parameters.Add("@CPNNO_P", SqlDbType.VarChar);
                objSqlCommand.Parameters["@CPNNO_P"].Value = cpnno;

                objSqlCommand.Parameters.Add("@EXTRA2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@EXTRA2"].Value = System.DBNull.Value;


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
                CloseConnection(ref objSqlConnection);
            }
        }
        public DataSet bindcoupan(string compcode, string center)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("GETCOUPAN", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlDataAdapter = new SqlDataAdapter();
                objSqlCommand.Parameters.Add("@COMPCODE_P", SqlDbType.VarChar);
                objSqlCommand.Parameters["@COMPCODE_P"].Value = compcode;

                objSqlCommand.Parameters.Add("@CENTER_P", SqlDbType.VarChar);
                objSqlCommand.Parameters["@CENTER_P"].Value = center;

                objSqlCommand.Parameters.Add("@EXTRA1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@EXTRA1"].Value = System.DBNull.Value;

                objSqlCommand.Parameters.Add("@EXTRA2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@EXTRA2"].Value = System.DBNull.Value;


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
                CloseConnection(ref objSqlConnection);
            }
        }
        public DataSet bindDesignBox_Classified(string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("bindDesignBox_Classified", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlDataAdapter = new SqlDataAdapter();
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
                CloseConnection(ref objSqlConnection);
            }
        }
        public DataSet bindLogoPrem_Classified(string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("bindLogoPrem_Classified", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlDataAdapter = new SqlDataAdapter();
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
                CloseConnection(ref objSqlConnection);
            }
        }
        public DataSet getCenterCode(string editioncode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getCenterCode", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlDataAdapter = new SqlDataAdapter();
                objSqlCommand.Parameters.Add("@editioncode_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@editioncode_p"].Value = editioncode;


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
                CloseConnection(ref objSqlConnection);
            }
        }
        public DataSet autogenratedbox(string compcode, string auto, string no, string center1, string agncodesubcode, string branch)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Getautocodeboxforprev", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlDataAdapter = new SqlDataAdapter();
                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@auto1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@auto1"].Value = auto;

                objSqlCommand.Parameters.Add("@no1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@no1"].Value = no;

                objSqlCommand.Parameters.Add("@center1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@center1"].Value = center1;

                objSqlCommand.Parameters.Add("@agency_codescode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agency_codescode"].Value = agncodesubcode;

                objSqlCommand.Parameters.Add("@branch", SqlDbType.VarChar);
                objSqlCommand.Parameters["@branch"].Value = branch;

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
                CloseConnection(ref objSqlConnection);
            }
        }
        public DataSet bindtranslation(string compcode, string adtype)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {

                objSqlConnection.Open();
                objSqlCommand = GetCommand("bindtranslation", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@adtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adtype"].Value = adtype;

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
                CloseConnection(ref objSqlConnection);
            }


        }

        public DataSet gettraprem(string compcode, string translation)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {

                objSqlConnection.Open();
                objSqlCommand = GetCommand("gettranslationper", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@translation", SqlDbType.VarChar);
                objSqlCommand.Parameters["@translation"].Value = translation;

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
                CloseConnection(ref objSqlConnection);
            }


        }
        public DataSet fetchdataforexe1(string ciobid, string compcode)
        {
            string zonename = "";
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getdataforexecute1", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@ciobid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ciobid"].Value = ciobid;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                //if (objDataSet.Tables[0].Rows.Count > 0)
                //{
                //    zonename = objDataSet.Tables[0].Rows[0].ItemArray[0].ToString();
                //}
                return objDataSet;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }

        }


        public DataSet rono1(string compcode, string userid, string agencycode, string rono)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("chkrono", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@agency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agency"].Value = agencycode;

                objSqlCommand.Parameters.Add("@p_rono", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_rono"].Value = rono;

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
                CloseConnection(ref objSqlConnection);
            }
        }
        public DataSet getmailheader(string compcode, string userid, string dealno)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("mailrateheaderforbooking", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcompcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@puserid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@puserid"].Value = userid;

                objSqlCommand.Parameters.Add("@pbookingid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pbookingid"].Value = dealno;

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
                CloseConnection(ref objSqlConnection);
            }

        }
        public DataSet getmaildetail(string compcode, string userid, string dealno)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("mailbooking", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcompcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@puserid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@puserid"].Value = userid;

                objSqlCommand.Parameters.Add("@pbookingid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pbookingid"].Value = dealno;

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
                CloseConnection(ref objSqlConnection);
            }

        }



        public DataSet fetbindtootipsubcat1(string code, string compcode)
        {
            string zonename = "";
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getsubCategory", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@catid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@catid"].Value = code;

                objSqlCommand.Parameters.Add("@comp_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@comp_code"].Value = compcode;

                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                //if (objDataSet.Tables[0].Rows.Count > 0)
                //{
                //    zonename = objDataSet.Tables[0].Rows[0].ItemArray[0].ToString();
                //}
                return objDataSet;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }

        }

        public DataSet executivecraditlimit(string compcode, string userid, string execname, string ciobookid, string grossamt, string billamt, string paymode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("chkexecutivecreditlimit", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcompcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@puserid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@puserid"].Value = userid;

                objSqlCommand.Parameters.Add("@pexecname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pexecname"].Value = execname;

                objSqlCommand.Parameters.Add("@pciobookid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pciobookid"].Value = ciobookid;

                objSqlCommand.Parameters.Add("@pgrossamt", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pgrossamt"].Value = grossamt;

                objSqlCommand.Parameters.Add("@pbillamt", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pbillamt"].Value = billamt;


                objSqlCommand.Parameters.Add("@ppaymode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ppaymode"].Value = paymode;

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
                CloseConnection(ref objSqlConnection);
            }
        }
        public DataSet logopremimage(string logoprem)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("logopremimage", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("@logoprem", SqlDbType.VarChar);
                objSqlCommand.Parameters["@logoprem"].Value = logoprem;



                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (SqlException objException)
            {
                throw (objException);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }

        }
        public DataSet billupdatedata(string compcode, string ciobookid, string supplementbilldate, string supplementbillno, string userid, string dateformat, string flag)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {

                objSqlConnection.Open();
                if (flag == "1")
                    objSqlCommand = GetCommand("billdet_for_bill_update_data", ref objSqlConnection);
                else
                    objSqlCommand = GetCommand("bill_update_data", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcompcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@porderno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@porderno"].Value = ciobookid;

                objSqlCommand.Parameters.Add("@pbill_date", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pbill_date"].Value = supplementbilldate;

                objSqlCommand.Parameters.Add("@pbill_no", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pbill_no"].Value = supplementbillno;

                objSqlCommand.Parameters.Add("@puserid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@puserid"].Value = userid;

                objSqlCommand.Parameters.Add("@pdateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdateformat"].Value = dateformat;

                objSqlCommand.Parameters.Add("@pextra1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra1"].Value = System.DBNull.Value;

                objSqlCommand.Parameters.Add("@pextra2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra2"].Value = System.DBNull.Value;

                objSqlCommand.Parameters.Add("@pextra3", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra3"].Value = System.DBNull.Value;

                objSqlCommand.Parameters.Add("@pextra4", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra4"].Value = System.DBNull.Value;

                objSqlCommand.Parameters.Add("@pextra5", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra5"].Value = System.DBNull.Value;

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
                CloseConnection(ref objSqlConnection);
            }


        }
        public DataSet adbillsmodificationvalidate(string compcode, string ciobookid, string supplementbilldate, string supplementbillno, string userid, string dateformat, string branch)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {

                objSqlConnection.Open();
                objSqlCommand = GetCommand("ad_bills_modification_validate", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcompcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@pcentcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcentcode"].Value = System.DBNull.Value;

                objSqlCommand.Parameters.Add("@pbrancode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pbrancode"].Value = branch;

                objSqlCommand.Parameters.Add("@pbilldt", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pbilldt"].Value = supplementbilldate;

                objSqlCommand.Parameters.Add("@pbillno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pbillno"].Value = supplementbillno;

                objSqlCommand.Parameters.Add("@puserid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@puserid"].Value = userid;

                objSqlCommand.Parameters.Add("@pdateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdateformat"].Value = dateformat;

                objSqlCommand.Parameters.Add("@pextra1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra1"].Value = System.DBNull.Value;

                objSqlCommand.Parameters.Add("@pextra2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra2"].Value = System.DBNull.Value;

                objSqlCommand.Parameters.Add("@pextra3", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra3"].Value = System.DBNull.Value;

                objSqlCommand.Parameters.Add("@pextra4", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra4"].Value = System.DBNull.Value;

                objSqlCommand.Parameters.Add("@pextra5", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra5"].Value = System.DBNull.Value;

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
                CloseConnection(ref objSqlConnection);
            }


        }
        public DataSet CHECKBOOKINGCREDITLIMIT(string compcode, string agcodeforcreadit, string outstand, string billamt, string datecheck, string dateformat, string cioid, string modflag)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("CHECKBOOKINGCREDITLIMIT", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@agcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agcode"].Value = agcodeforcreadit;

                objSqlCommand.Parameters.Add("@outstandamt", SqlDbType.VarChar);
                objSqlCommand.Parameters["@outstandamt"].Value = outstand;

                objSqlCommand.Parameters.Add("@billamt", SqlDbType.VarChar);
                objSqlCommand.Parameters["@billamt"].Value = billamt;

                objSqlCommand.Parameters.Add("@datecheck", SqlDbType.VarChar);
                if (datecheck == "" || datecheck == null)
                    objSqlCommand.Parameters["@datecheck"].Value = System.DBNull.Value;
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {

                        if (datecheck.IndexOf('-') < 0)
                        {
                            string[] arr = datecheck.Split('/');
                            string dd = arr[0];
                            string mm = arr[1];
                            string yy = arr[2];
                            datecheck = mm + "/" + dd + "/" + yy;

                        }

                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = datecheck.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        datecheck = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@datecheck"].Value = datecheck;
                }


                objSqlCommand.Parameters.Add("@cioid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cioid"].Value = cioid;

                objSqlCommand.Parameters.Add("@modflag", SqlDbType.VarChar);
                objSqlCommand.Parameters["@modflag"].Value = modflag;

                objSqlCommand.Parameters.Add("@extra2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@extra2"].Value = System.DBNull.Value;

                objSqlCommand.Parameters.Add("@extra3", SqlDbType.VarChar);
                objSqlCommand.Parameters["@extra3"].Value = System.DBNull.Value;

                objSqlCommand.Parameters.Add("@extra4", SqlDbType.VarChar);
                objSqlCommand.Parameters["@extra4"].Value = System.DBNull.Value;

                objSqlCommand.Parameters.Add("@extra5", SqlDbType.VarChar);
                objSqlCommand.Parameters["@extra5"].Value = System.DBNull.Value;

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
                CloseConnection(ref objSqlConnection);
            }
        }
        public DataSet getExecZoneName(string execcode, string compcode, string agencycodesubcode)
        {
            string zonename = "";
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_getExecZoneNameforprintbooking", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("@exexcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@exexcode"].Value = execcode;
                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@pagency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pagency"].Value = agencycodesubcode;
                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                //if (objDataSet.Tables[0].Rows.Count > 0)
                //{
                //    zonename = objDataSet.Tables[0].Rows[0].ItemArray[0].ToString();
                //}
                return objDataSet;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }

        }
        public DataSet validationCoupan(string compcode, string center, string cpnno, string cpntype, string agcode, string execcode, string dtime, string dateformat)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("validationCoupan", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlDataAdapter = new SqlDataAdapter();
                objSqlCommand.Parameters.Add("@COMPCODE_P", SqlDbType.VarChar);
                objSqlCommand.Parameters["@COMPCODE_P"].Value = compcode;

                objSqlCommand.Parameters.Add("@CENTER_P", SqlDbType.VarChar);
                objSqlCommand.Parameters["@CENTER_P"].Value = center;

                objSqlCommand.Parameters.Add("@CPNNO_P", SqlDbType.VarChar);
                objSqlCommand.Parameters["@CPNNO_P"].Value = cpnno;

                objSqlCommand.Parameters.Add("@CPNTYPE", SqlDbType.VarChar);
                objSqlCommand.Parameters["@CPNTYPE"].Value = cpntype;

                objSqlCommand.Parameters.Add("@AGCODE_P", SqlDbType.VarChar);
                objSqlCommand.Parameters["@AGCODE_P"].Value = agcode;

                objSqlCommand.Parameters.Add("@EXECCODE_P", SqlDbType.VarChar);
                objSqlCommand.Parameters["@EXECCODE_P"].Value = execcode;

                objSqlCommand.Parameters.Add("@DATE_P", SqlDbType.DateTime);
                if (dateformat == "dd/mm/yyyy")
                {
                    string[] arr = dtime.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    dtime = mm + "/" + dd + "/" + yy;
                }
                else if (dateformat == "yyyy/mm/dd")
                {
                    string[] arr = dtime.Split('/');
                    string dd = arr[2];
                    string mm = arr[1];
                    string yy = arr[0];
                    dtime = mm + "/" + dd + "/" + yy;
                }
                objSqlCommand.Parameters["@DATE_P"].Value = dtime;

                objSqlCommand.Parameters.Add("@EXTRA2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@EXTRA2"].Value = System.DBNull.Value;


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
                CloseConnection(ref objSqlConnection);
            }
        }
        public DataSet getpageadinfo(string compcode, string pageprem, string editionname, string pageno, string date_p, string userid, string cioid, string extera1, string extera2, string extera3, string extera4, string extera5)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getpageadinfo", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlDataAdapter = new SqlDataAdapter();

                objSqlCommand.Parameters.Add("@compcode_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode_p"].Value = compcode;

                objSqlCommand.Parameters.Add("@pageprem_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pageprem_p"].Value = pageprem;

                objSqlCommand.Parameters.Add("@editionname_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@editionname_p"].Value = editionname;

                objSqlCommand.Parameters.Add("@pageno_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pageno_p"].Value = pageno;

                objSqlCommand.Parameters.Add("@date_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@date_p"].Value = date_p;

                objSqlCommand.Parameters.Add("@userid_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid_p"].Value = userid;

                objSqlCommand.Parameters.Add("@cioid_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cioid_p"].Value = cioid;

                objSqlCommand.Parameters.Add("@extera1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@extera1"].Value = extera1;

                objSqlCommand.Parameters.Add("@extera2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@extera2"].Value = extera2;

                objSqlCommand.Parameters.Add("@extera3", SqlDbType.VarChar);
                objSqlCommand.Parameters["@extera3"].Value = extera3;

                objSqlCommand.Parameters.Add("@extera4", SqlDbType.VarChar);
                objSqlCommand.Parameters["@extera4"].Value = extera4;

                objSqlCommand.Parameters.Add("@extera5", SqlDbType.VarChar);
                objSqlCommand.Parameters["@extera5"].Value = extera5;

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
                CloseConnection(ref objSqlConnection);
            }
        }
        public DataSet getmailagency(string compcod, string userid, string cioid, string agencycode)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("get_agency_mailid", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcompcode"].Value = compcod;

                objSqlCommand.Parameters.Add("@puserid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@puserid"].Value = userid;

                objSqlCommand.Parameters.Add("@pbookingid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pbookingid"].Value = cioid;

                objSqlCommand.Parameters.Add("@pagencycode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pagencycode"].Value = agencycode;

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
                CloseConnection(ref objSqlConnection);
            }

        }
        public DataSet adretain_billbase_outstanding(string compcode, string agencycodesubcode, string retain_code, string datetime, string dateformat, string agencytype)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("adretain_billbase_outstanding", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlDataAdapter = new SqlDataAdapter();
                objSqlCommand.Parameters.Add("@pcomp_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcomp_code"].Value = compcode;

                objSqlCommand.Parameters.Add("@punit", SqlDbType.VarChar);
                objSqlCommand.Parameters["@punit"].Value = System.DBNull.Value;

                objSqlCommand.Parameters.Add("@ppubcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ppubcode"].Value = System.DBNull.Value;

                objSqlCommand.Parameters.Add("@pagency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pagency"].Value = agencycodesubcode;

                objSqlCommand.Parameters.Add("@pretcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pretcode"].Value = retain_code;

                objSqlCommand.Parameters.Add("@pason_dt", SqlDbType.VarChar);
                if (dateformat == "dd/mm/yyyy")
                {
                    string[] arr = datetime.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    datetime = mm + "/" + dd + "/" + yy;
                }
                else if (dateformat == "yyyy/mm/dd")
                {
                    string[] arr = datetime.Split('/');
                    string dd = arr[2];
                    string mm = arr[1];
                    string yy = arr[0];
                    datetime = mm + "/" + dd + "/" + yy;
                }
                objSqlCommand.Parameters["@pason_dt"].Value = datetime;

                objSqlCommand.Parameters.Add("@pdateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdateformat"].Value = dateformat;

                objSqlCommand.Parameters.Add("@pagtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pagtype"].Value = agencytype;


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
                CloseConnection(ref objSqlConnection);
            }
        }
        public DataSet adexec_billbase_outstanding(string compcode, string agencycodesubcode, string pexecode, string datetime, string dateformat, string agencytype)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("adexec_billbase_outstanding", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlDataAdapter = new SqlDataAdapter();
                objSqlCommand.Parameters.Add("@pcomp_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcomp_code"].Value = compcode;

                objSqlCommand.Parameters.Add("@punit", SqlDbType.VarChar);
                objSqlCommand.Parameters["@punit"].Value = System.DBNull.Value;

                objSqlCommand.Parameters.Add("@ppubcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ppubcode"].Value = System.DBNull.Value;

                objSqlCommand.Parameters.Add("@pagency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pagency"].Value = agencycodesubcode;

                objSqlCommand.Parameters.Add("@pexecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pexecode"].Value = pexecode;

                objSqlCommand.Parameters.Add("@pason_dt", SqlDbType.VarChar);
                if (dateformat == "dd/mm/yyyy")
                {
                    string[] arr = datetime.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    datetime = mm + "/" + dd + "/" + yy;
                }
                else if (dateformat == "yyyy/mm/dd")
                {
                    string[] arr = datetime.Split('/');
                    string dd = arr[2];
                    string mm = arr[1];
                    string yy = arr[0];
                    datetime = mm + "/" + dd + "/" + yy;
                }
                objSqlCommand.Parameters["@pason_dt"].Value = datetime;

                objSqlCommand.Parameters.Add("@pdateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdateformat"].Value = dateformat;

                objSqlCommand.Parameters.Add("@pagtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pagtype"].Value = agencytype;


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
                CloseConnection(ref objSqlConnection);
            }
        }



        public DataSet discount_count(string compcode, string adtype, string edition_count)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_getautodiscountrate", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlDataAdapter = new SqlDataAdapter();
                objSqlCommand.Parameters.Add("@pcomcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcomcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@pedition", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pedition"].Value = edition_count;

                objSqlCommand.Parameters.Add("@padtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@padtype"].Value = adtype;

                objSqlCommand.Parameters.Add("@pextra1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra1"].Value = System.DBNull.Value;

                objSqlCommand.Parameters.Add("@pextra2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra2"].Value = System.DBNull.Value;

                objSqlCommand.Parameters.Add("@pextra3", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra3"].Value = System.DBNull.Value;


                objSqlCommand.Parameters.Add("@pextra4", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra4"].Value = System.DBNull.Value;

                objSqlCommand.Parameters.Add("@pextra5", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra5"].Value = System.DBNull.Value;


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
                CloseConnection(ref objSqlConnection);
            }
        }
        public DataSet multi_billing(string compcode, string client_code, string client_name, string client_address, string width, string height, string gross_amt, string comm, string bill_amt, string bill_no, string bill_dt, string userid, string flag, string extra1, string extra2, string extra3, string extra4, string extra5)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("MULTIBILLING_RO", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlDataAdapter = new SqlDataAdapter();

                objSqlCommand.Parameters.Add("@PCOMP_CODE", SqlDbType.VarChar);
                objSqlCommand.Parameters["@PCOMP_CODE"].Value = compcode;

                objSqlCommand.Parameters.Add("@PCLIENT_NAME", SqlDbType.VarChar);
                objSqlCommand.Parameters["@PCLIENT_NAME"].Value = client_name;

                objSqlCommand.Parameters.Add("@PCLIENT_CODE", SqlDbType.VarChar);
                objSqlCommand.Parameters["@PCLIENT_CODE"].Value = client_code;

                objSqlCommand.Parameters.Add("@PCLEINT_ADDRESS", SqlDbType.VarChar);
                objSqlCommand.Parameters["@PCLEINT_ADDRESS"].Value = client_address;

                objSqlCommand.Parameters.Add("@PWIDTH", SqlDbType.VarChar);
                objSqlCommand.Parameters["@PWIDTH"].Value = width;

                objSqlCommand.Parameters.Add("@PHEIGHT", SqlDbType.VarChar);
                objSqlCommand.Parameters["@PHEIGHT"].Value = height;

                objSqlCommand.Parameters.Add("@PGROSS_AMT", SqlDbType.VarChar);
                objSqlCommand.Parameters["@PGROSS_AMT"].Value = gross_amt;

                objSqlCommand.Parameters.Add("@PCOMM", SqlDbType.VarChar);
                if (comm == "null" || comm == null)
                {
                    objSqlCommand.Parameters["@PCOMM"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@PCOMM"].Value = comm;
                }


                objSqlCommand.Parameters.Add("@PBILL_AMT", SqlDbType.VarChar);
                if (bill_amt == "null" || bill_amt == null)
                {
                    objSqlCommand.Parameters["@PBILL_AMT"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@PBILL_AMT"].Value = bill_amt;
                }

                objSqlCommand.Parameters.Add("@PBILL_NO", SqlDbType.VarChar);
                if (bill_no == "null" || bill_no == null)
                {
                    objSqlCommand.Parameters["@PBILL_NO"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@PBILL_NO"].Value = bill_no;
                }

                objSqlCommand.Parameters.Add("@PBILL_DATE", SqlDbType.VarChar);
                if (bill_dt == "null" || bill_dt == null)
                {
                    objSqlCommand.Parameters["@PBILL_DATE"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@PBILL_DATE"].Value = bill_dt;
                }


                objSqlCommand.Parameters.Add("@PUSER_ID", SqlDbType.VarChar);
                objSqlCommand.Parameters["@PUSER_ID"].Value = userid;

                objSqlCommand.Parameters.Add("@PFLAG", SqlDbType.VarChar);
                objSqlCommand.Parameters["@PFLAG"].Value = flag;

                objSqlCommand.Parameters.Add("@PEXTRA1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@PEXTRA1"].Value = extra1;

                objSqlCommand.Parameters.Add("@PEXTRA2", SqlDbType.VarChar);
                if (extra2 == "null" || extra2 == null)
                {
                    objSqlCommand.Parameters["@PEXTRA2"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@PEXTRA2"].Value = extra2;
                }

                objSqlCommand.Parameters.Add("@PEXTRA3", SqlDbType.VarChar);
                objSqlCommand.Parameters["@PEXTRA3"].Value = extra3;

                objSqlCommand.Parameters.Add("@PEXTRA4", SqlDbType.VarChar);
                objSqlCommand.Parameters["@PEXTRA4"].Value = extra4;

                objSqlCommand.Parameters.Add("@PEXTRA5", SqlDbType.VarChar);
                objSqlCommand.Parameters["@PEXTRA5"].Value = extra5;

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
                CloseConnection(ref objSqlConnection);
            }
        }
        public DataSet executebooking_bill(string compcode, string ciobookid, string docno, string keyno, string rono, string agencycode, string client, string booking, string dateformat, string revenue)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("executebooking_bill", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@ciobookid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ciobookid"].Value = ciobookid;

                objSqlCommand.Parameters.Add("@docno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@docno"].Value = docno;

                objSqlCommand.Parameters.Add("@keyno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@keyno"].Value = keyno;

                objSqlCommand.Parameters.Add("@rono", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rono"].Value = rono;

                objSqlCommand.Parameters.Add("@agencycode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencycode"].Value = agencycode;

                objSqlCommand.Parameters.Add("@client", SqlDbType.VarChar);
                objSqlCommand.Parameters["@client"].Value = client;

                objSqlCommand.Parameters.Add("@booking", SqlDbType.VarChar);
                objSqlCommand.Parameters["@booking"].Value = booking;

                objSqlCommand.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dateformat"].Value = dateformat;

                objSqlCommand.Parameters.Add("@revenue", SqlDbType.VarChar);
                objSqlCommand.Parameters["@revenue"].Value = revenue;


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
                CloseConnection(ref objSqlConnection);
            }
        }
        public DataSet fetchdataforexe_bill(string ciobid, string compcode)
        {
            string zonename = "";
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getdataforexecute_bill", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@ciobid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ciobid"].Value = ciobid;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                //if (objDataSet.Tables[0].Rows.Count > 0)
                //{
                //    zonename = objDataSet.Tables[0].Rows[0].ItemArray[0].ToString();
                //}
                return objDataSet;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }
        }
        public DataSet getPackageInsert_bill(string pckcode, string cioid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getPackageInsert_suppbill", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("@packagecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@packagecode"].Value = pckcode;

                objSqlCommand.Parameters.Add("@cioid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cioid"].Value = cioid;

                objSqlDataAdapter = new SqlDataAdapter();
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
                CloseConnection(ref objSqlConnection);
            }
        }
        public DataSet updatebooking_bill(string adsizetype, string branch, string booked_by, string prevbook, string date_time, string ciobookid, string approvedby, string audit, string rono, string rodate, string caption, string billstatus, string rostatus, string agency, string client, string agencyaddress, string clientaddresses, string agencycode, string dockitno, string execname, string execzone, string product, string brand, string keyno, string billremark, string printremark, string package, string insertion, string startdate, string repeatdate, string adtype, string adcategory, string subcategory, string color, string uom, string pageposition, string pagetype, string pageno, string adsizheight, string adsizwidth, string ratecode, string scheme, string currency, string agreedrate, string agreedamt, string spedisc, string spacedisx, string compcode, string userid, string specialcharges, string agencytype, string agencystatus, string paymode, string agencredit, string cardrate, string cardamount, string discount, string discountper, string billaddress, string totarea, string billcycle, string revenuecenter, string billpay, string billheight, string billwidth, string billto, string invoices, string vts, string tradedisc, string agencyout, string boxcode, string boxno, string boxaddress, string boxagency, string boxclient, string bookingtype, string tfn, string coupan, string campaign, string bill_amt, string pageprem, string pageamt, string premper, string grossamt, string adsizcolumn, string billcolumn, Decimal billarea, string specdiscper, string spacediscper, string paidins, string dealrate, string deviation, string varient, string contractname, string dealtype, string cardname, string cardtype, string cardmonth, string cardyear, string cardno, string receiptno, string adscat3, string adscat4, string adscat5, string bgcolor, string bulletcode, string bulletprm, string material, string region, string varient_name, string coltype, string logo_h, string logo_w, string logo_col, string logo_uom, string status, string dateformat, string retainer, string addagencyrate, string mobileno, string addlamt, string retamt, string retper, string cashrecieved, string ciragency, string cirrate, string ciredition, string cirpublication, string ciragencysubcode, string bartertype, string cashdiscount, string cashdiscper, string attach1, string attach2, string drpdiscprem, string doctype, string chktradeval, string sharepub, string fmginsert, string chkno, string chkdate, string chkamt, string chkbankname, string ourbank, string dealerpanel, string dealerh, string dealerw, string dealertype, string multicode, string agreedrate_active, string agreedamt_active, string grossamtlocal_p, string billamtlocal_p, string chkadon, string refid, string rcpt_currency, string cur_convrate, string revisedate, string clienttype, string translation, string translationcharge, string fmgreasons, string canclecharge, string modifyrateaudit, string ip, string transdisc, string pospremdisc, string billhold, string designbox, string logoprem, string online_ad, string style, string fixed_booking, string vat_code, string cou_code, string cou_name, string state, string clientcatdisc, string clientcatamt, string clientcatdistype, string flatfreqdisc, string flatfreqamt, string flatfreqdisctype, string catdisc, string catamt, string catdisctype)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {

                objSqlConnection.Open();
                objSqlCommand = GetCommand("updatebooking_suppbill", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@date_time", SqlDbType.DateTime);
                if (date_time == "" || date_time == null)
                {
                    objSqlCommand.Parameters["@date_time"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = date_time.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        date_time = mm + "/" + dd + "/" + yy;


                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = date_time.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        date_time = mm + "/" + dd + "/" + yy;


                    }
                    objSqlCommand.Parameters["@date_time"].Value = date_time;
                }

                objSqlCommand.Parameters.Add("@adsizetype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adsizetype"].Value = adsizetype;

                objSqlCommand.Parameters.Add("@branch", SqlDbType.VarChar);
                objSqlCommand.Parameters["@branch"].Value = branch;

                objSqlCommand.Parameters.Add("@booked_by", SqlDbType.VarChar);
                objSqlCommand.Parameters["@booked_by"].Value = booked_by;

                objSqlCommand.Parameters.Add("@prevbook", SqlDbType.VarChar);
                objSqlCommand.Parameters["@prevbook"].Value = prevbook;

                objSqlCommand.Parameters.Add("@approvedby", SqlDbType.VarChar);
                objSqlCommand.Parameters["@approvedby"].Value = approvedby;

                objSqlCommand.Parameters.Add("@ciobookid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ciobookid"].Value = ciobookid;

                objSqlCommand.Parameters.Add("@audit", SqlDbType.VarChar);
                objSqlCommand.Parameters["@audit"].Value = audit;

                objSqlCommand.Parameters.Add("@rono", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rono"].Value = rono;

                objSqlCommand.Parameters.Add("@rodate", SqlDbType.DateTime);
                if (rodate == "" || rodate == null)
                {
                    objSqlCommand.Parameters["@rodate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = rodate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        rodate = mm + "/" + dd + "/" + yy;


                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = rodate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        rodate = mm + "/" + dd + "/" + yy;


                    }
                    objSqlCommand.Parameters["@rodate"].Value = rodate;
                }

                objSqlCommand.Parameters.Add("@caption", SqlDbType.VarChar);
                objSqlCommand.Parameters["@caption"].Value = caption;

                objSqlCommand.Parameters.Add("@billstatus", SqlDbType.VarChar);
                objSqlCommand.Parameters["@billstatus"].Value = billstatus;

                objSqlCommand.Parameters.Add("@rostatus", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rostatus"].Value = rostatus;

                objSqlCommand.Parameters.Add("@agency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agency"].Value = agency;

                objSqlCommand.Parameters.Add("@client", SqlDbType.VarChar);
                objSqlCommand.Parameters["@client"].Value = client;

                objSqlCommand.Parameters.Add("@agencyaddress", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencyaddress"].Value = agencyaddress;

                objSqlCommand.Parameters.Add("@clientaddresses", SqlDbType.VarChar);
                objSqlCommand.Parameters["@clientaddresses"].Value = clientaddresses;

                objSqlCommand.Parameters.Add("@agencycode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencycode"].Value = agencycode;

                objSqlCommand.Parameters.Add("@dockitno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dockitno"].Value = dockitno;

                objSqlCommand.Parameters.Add("@execname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@execname"].Value = execname;

                objSqlCommand.Parameters.Add("@execzone", SqlDbType.VarChar);
                objSqlCommand.Parameters["@execzone"].Value = execzone;

                objSqlCommand.Parameters.Add("@product", SqlDbType.VarChar);
                objSqlCommand.Parameters["@product"].Value = product;

                objSqlCommand.Parameters.Add("@brand", SqlDbType.VarChar);
                objSqlCommand.Parameters["@brand"].Value = brand;

                objSqlCommand.Parameters.Add("@keyno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@keyno"].Value = keyno;

                objSqlCommand.Parameters.Add("@billremark", SqlDbType.VarChar);
                objSqlCommand.Parameters["@billremark"].Value = billremark;

                objSqlCommand.Parameters.Add("@printremark", SqlDbType.VarChar);
                objSqlCommand.Parameters["@printremark"].Value = printremark;

                objSqlCommand.Parameters.Add("@package", SqlDbType.VarChar);
                objSqlCommand.Parameters["@package"].Value = package;

                objSqlCommand.Parameters.Add("@insertion", SqlDbType.Int);
                if (insertion == "" || insertion == null)
                {
                    objSqlCommand.Parameters["@insertion"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@insertion"].Value = Convert.ToInt32(insertion);
                }

                objSqlCommand.Parameters.Add("@startdate", SqlDbType.DateTime);
                if (startdate == "" || startdate == null)
                {
                    objSqlCommand.Parameters["@startdate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = startdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        startdate = mm + "/" + dd + "/" + yy;


                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = startdate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        startdate = mm + "/" + dd + "/" + yy;


                    }
                    objSqlCommand.Parameters["@startdate"].Value = startdate;
                }

                objSqlCommand.Parameters.Add("@repeatdate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@repeatdate"].Value = repeatdate;

                objSqlCommand.Parameters.Add("@adtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adtype"].Value = adtype;

                objSqlCommand.Parameters.Add("@adcategory", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adcategory"].Value = adcategory;

                objSqlCommand.Parameters.Add("@subcategory", SqlDbType.VarChar);
                objSqlCommand.Parameters["@subcategory"].Value = subcategory;

                objSqlCommand.Parameters.Add("@color", SqlDbType.VarChar);
                objSqlCommand.Parameters["@color"].Value = color;

                objSqlCommand.Parameters.Add("@uom", SqlDbType.VarChar);
                objSqlCommand.Parameters["@uom"].Value = uom;

                objSqlCommand.Parameters.Add("@pageposition", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pageposition"].Value = pageposition;

                objSqlCommand.Parameters.Add("@pagetype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pagetype"].Value = pagetype;

                objSqlCommand.Parameters.Add("@pageno", SqlDbType.Int);
                if (pageno == "" || pageno == null)
                {
                    objSqlCommand.Parameters["@pageno"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pageno"].Value = Convert.ToInt32(pageno);
                }

                objSqlCommand.Parameters.Add("@adsizheight", SqlDbType.Decimal);
                if (adsizheight == "" || adsizheight == null)
                {
                    objSqlCommand.Parameters["@adsizheight"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@adsizheight"].Value = Convert.ToDecimal(adsizheight);
                }

                objSqlCommand.Parameters.Add("@adsizwidth", SqlDbType.Decimal);
                if (adsizwidth == "" || adsizwidth == null)
                {
                    objSqlCommand.Parameters["@adsizwidth"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@adsizwidth"].Value = Convert.ToDecimal(adsizwidth);
                }

                objSqlCommand.Parameters.Add("@ratecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ratecode"].Value = ratecode;

                objSqlCommand.Parameters.Add("@scheme", SqlDbType.VarChar);
                objSqlCommand.Parameters["@scheme"].Value = scheme;

                objSqlCommand.Parameters.Add("@currency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@currency"].Value = currency;

                objSqlCommand.Parameters.Add("@agreedrate", SqlDbType.Decimal);
                if (agreedrate == "" || agreedrate == null)
                {
                    objSqlCommand.Parameters["@agreedrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@agreedrate"].Value = Convert.ToDecimal(agreedrate);
                }
                //    , , ,Session["compcode"].ToString(),Session["userid"].ToString()
                objSqlCommand.Parameters.Add("@agreedamt", SqlDbType.Decimal);
                if (agreedamt == "" || agreedamt == null)
                {
                    objSqlCommand.Parameters["@agreedamt"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@agreedamt"].Value = Convert.ToDecimal(agreedamt);
                }

                objSqlCommand.Parameters.Add("@spedisc", SqlDbType.Decimal);
                if (spedisc == "" || spedisc == null)
                {
                    objSqlCommand.Parameters["@spedisc"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@spedisc"].Value = Convert.ToDecimal(spedisc);
                }

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@spacedisx", SqlDbType.Decimal);
                if (spacedisx == "" || spacedisx == null)
                {
                    objSqlCommand.Parameters["@spacedisx"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@spacedisx"].Value = Convert.ToDecimal(spacedisx);
                }

                objSqlCommand.Parameters.Add("@specialcharges", SqlDbType.Decimal);
                if (specialcharges == "" || specialcharges == null)
                {
                    objSqlCommand.Parameters["@specialcharges"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@specialcharges"].Value = Convert.ToDecimal(specialcharges);
                }

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@agencytype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencytype"].Value = agencytype;

                objSqlCommand.Parameters.Add("@agencystatus", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencystatus"].Value = agencystatus;

                objSqlCommand.Parameters.Add("@paymode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@paymode"].Value = paymode;

                objSqlCommand.Parameters.Add("@agencredit", SqlDbType.Int);
                if (agencredit == "" || agencredit == null)
                {
                    objSqlCommand.Parameters["@agencredit"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@agencredit"].Value = Convert.ToInt32(agencredit);
                }

                objSqlCommand.Parameters.Add("@cardrate", SqlDbType.Decimal);
                if (cardrate == "" || cardrate == null)
                {
                    objSqlCommand.Parameters["@cardrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@cardrate"].Value = Convert.ToDecimal(cardrate);
                }

                objSqlCommand.Parameters.Add("@cardamount", SqlDbType.Decimal);
                if (cardamount == "" || cardamount == null)
                {
                    objSqlCommand.Parameters["@cardamount"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@cardamount"].Value = Convert.ToDecimal(cardamount);
                }

                objSqlCommand.Parameters.Add("@discount", SqlDbType.Decimal);
                if (discount == "" || discount == null)
                {
                    objSqlCommand.Parameters["@discount"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@discount"].Value = Convert.ToDecimal(discount);
                }


                objSqlCommand.Parameters.Add("@discountper", SqlDbType.Decimal);
                if (discountper == "" || discountper == null)
                {
                    objSqlCommand.Parameters["@discountper"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@discountper"].Value = Convert.ToDecimal(discountper);
                }

                objSqlCommand.Parameters.Add("@billaddress", SqlDbType.VarChar);
                objSqlCommand.Parameters["@billaddress"].Value = billaddress;

                objSqlCommand.Parameters.Add("@totarea", SqlDbType.Decimal);
                if (totarea == "" || totarea == null)
                {
                    objSqlCommand.Parameters["@totarea"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@totarea"].Value = Convert.ToDecimal(totarea);
                }


                objSqlCommand.Parameters.Add("@billcycle", SqlDbType.VarChar);
                objSqlCommand.Parameters["@billcycle"].Value = billcycle;

                objSqlCommand.Parameters.Add("@revenuecenter", SqlDbType.VarChar);
                objSqlCommand.Parameters["@revenuecenter"].Value = revenuecenter;

                objSqlCommand.Parameters.Add("@billpay", SqlDbType.VarChar);
                objSqlCommand.Parameters["@billpay"].Value = billpay;

                objSqlCommand.Parameters.Add("@billheight", SqlDbType.Decimal);
                if (billheight == "" || billheight == null)
                {
                    objSqlCommand.Parameters["@billheight"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@billheight"].Value = Convert.ToDecimal(billheight);
                }

                objSqlCommand.Parameters.Add("@billwidth", SqlDbType.Decimal);
                if (billwidth == "" || billwidth == null)
                {
                    objSqlCommand.Parameters["@billwidth"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@billwidth"].Value = Convert.ToDecimal(billwidth);
                }

                //////, , , , , , , , , , , , , , , , , , , 

                objSqlCommand.Parameters.Add("@billto", SqlDbType.VarChar);
                objSqlCommand.Parameters["@billto"].Value = billto;

                objSqlCommand.Parameters.Add("@invoices", SqlDbType.Int);
                if (invoices == "" || invoices == null)
                {
                    objSqlCommand.Parameters["@invoices"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@invoices"].Value = Convert.ToInt32(invoices);
                }

                objSqlCommand.Parameters.Add("@vts", SqlDbType.Int);
                if (vts == "" || vts == null)
                {
                    objSqlCommand.Parameters["@vts"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@vts"].Value = Convert.ToInt32(vts);
                }

                objSqlCommand.Parameters.Add("@tradedisc", SqlDbType.Decimal);
                if (tradedisc == "" || tradedisc == null)
                {
                    objSqlCommand.Parameters["@tradedisc"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@tradedisc"].Value = Convert.ToDecimal(tradedisc);
                }

                objSqlCommand.Parameters.Add("@agencyout", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencyout"].Value = agencyout;

                objSqlCommand.Parameters.Add("@boxcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@boxcode"].Value = boxcode;

                objSqlCommand.Parameters.Add("@boxno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@boxno"].Value = boxno;

                objSqlCommand.Parameters.Add("@boxaddress", SqlDbType.VarChar);
                objSqlCommand.Parameters["@boxaddress"].Value = boxaddress;

                objSqlCommand.Parameters.Add("@boxagency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@boxagency"].Value = boxagency;

                objSqlCommand.Parameters.Add("@boxclient", SqlDbType.VarChar);
                objSqlCommand.Parameters["@boxclient"].Value = boxclient;

                objSqlCommand.Parameters.Add("@bookingtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@bookingtype"].Value = bookingtype;

                objSqlCommand.Parameters.Add("@tfn", SqlDbType.VarChar);
                objSqlCommand.Parameters["@tfn"].Value = tfn;

                objSqlCommand.Parameters.Add("@coupan", SqlDbType.VarChar);
                objSqlCommand.Parameters["@coupan"].Value = coupan;

                objSqlCommand.Parameters.Add("@campaign", SqlDbType.VarChar);
                objSqlCommand.Parameters["@campaign"].Value = campaign;


                objSqlCommand.Parameters.Add("@bill_amt", SqlDbType.Decimal);
                if (bill_amt == "" || bill_amt == null)
                {
                    objSqlCommand.Parameters["@bill_amt"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@bill_amt"].Value = Convert.ToDecimal(bill_amt);
                }

                objSqlCommand.Parameters.Add("@pageprem", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pageprem"].Value = pageprem;


                objSqlCommand.Parameters.Add("@pageamt", SqlDbType.Decimal);
                if (pageamt == "" || pageamt == null)
                {
                    objSqlCommand.Parameters["@pageamt"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pageamt"].Value = Convert.ToDecimal(pageamt);
                }

                objSqlCommand.Parameters.Add("@premper", SqlDbType.Decimal);
                if (premper == "" || premper == null)
                {
                    objSqlCommand.Parameters["@premper"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@premper"].Value = Convert.ToDecimal(premper);
                }

                objSqlCommand.Parameters.Add("@grossamt", SqlDbType.Decimal);
                if (grossamt == "" || grossamt == null)
                {
                    objSqlCommand.Parameters["@grossamt"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@grossamt"].Value = Convert.ToDecimal(grossamt);
                }

                objSqlCommand.Parameters.Add("@adsizcolumn", SqlDbType.Decimal);
                if (adsizcolumn == "" || adsizcolumn == null)
                {
                    objSqlCommand.Parameters["@adsizcolumn"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@adsizcolumn"].Value = Convert.ToDecimal(adsizcolumn);
                }

                objSqlCommand.Parameters.Add("@billcolumn", SqlDbType.Decimal);
                if (billcolumn == "" || billcolumn == null)
                {
                    objSqlCommand.Parameters["@billcolumn"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@billcolumn"].Value = Convert.ToDecimal(billcolumn);
                }

                objSqlCommand.Parameters.Add("@billarea", SqlDbType.Decimal);

                objSqlCommand.Parameters["@billarea"].Value = Convert.ToDecimal(billarea);


                objSqlCommand.Parameters.Add("@specdiscper", SqlDbType.Decimal);
                if (specdiscper == "" || specdiscper == null)
                {
                    objSqlCommand.Parameters["@specdiscper"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@specdiscper"].Value = Convert.ToDecimal(specdiscper);
                }

                objSqlCommand.Parameters.Add("@spacediscper", SqlDbType.Decimal);
                if (spacediscper == "" || spacediscper == null)
                {
                    objSqlCommand.Parameters["@spacediscper"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@spacediscper"].Value = Convert.ToDecimal(spacediscper);
                }

                objSqlCommand.Parameters.Add("@paidins", SqlDbType.Int);
                if (paidins == "" || paidins == null)
                {
                    objSqlCommand.Parameters["@paidins"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@paidins"].Value = Convert.ToInt32(paidins);
                }

                objSqlCommand.Parameters.Add("@dealrate", SqlDbType.Decimal);
                if (dealrate == "" || dealrate == null)
                {
                    objSqlCommand.Parameters["@dealrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@dealrate"].Value = Convert.ToDecimal(dealrate);
                }

                objSqlCommand.Parameters.Add("@deviation", SqlDbType.Decimal);
                if (deviation == "" || deviation == null)
                {
                    objSqlCommand.Parameters["@deviation"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@deviation"].Value = Convert.ToDecimal(deviation);
                }

                objSqlCommand.Parameters.Add("@varient", SqlDbType.VarChar);
                objSqlCommand.Parameters["@varient"].Value = varient;

                objSqlCommand.Parameters.Add("@contractname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@contractname"].Value = contractname;


                objSqlCommand.Parameters.Add("@dealtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dealtype"].Value = dealtype;

                objSqlCommand.Parameters.Add("@cardname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cardname"].Value = cardname;

                objSqlCommand.Parameters.Add("@cardtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cardtype"].Value = cardtype;

                objSqlCommand.Parameters.Add("@cardmonth", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cardmonth"].Value = cardmonth;

                objSqlCommand.Parameters.Add("@cardyear", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cardyear"].Value = cardyear;

                objSqlCommand.Parameters.Add("@cardno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cardno"].Value = cardno;

                objSqlCommand.Parameters.Add("@receiptno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@receiptno"].Value = receiptno;

                objSqlCommand.Parameters.Add("@adscat3", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adscat3"].Value = adscat3;

                objSqlCommand.Parameters.Add("@adscat4", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adscat4"].Value = adscat4;

                objSqlCommand.Parameters.Add("@adscat5", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adscat5"].Value = adscat5;

                objSqlCommand.Parameters.Add("@bgcolor", SqlDbType.VarChar);
                objSqlCommand.Parameters["@bgcolor"].Value = bgcolor;

                objSqlCommand.Parameters.Add("@bulletcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@bulletcode"].Value = bulletcode;

                objSqlCommand.Parameters.Add("@bulletprm", SqlDbType.Decimal);
                if (bulletprm == "" || bulletprm == null)
                {
                    objSqlCommand.Parameters["@bulletprm"].Value = System.DBNull.Value;
                }
                else
                {
                    bulletprm = bulletprm.Replace("%", "");
                    objSqlCommand.Parameters["@bulletprm"].Value = Convert.ToDecimal(bulletprm);
                }

                objSqlCommand.Parameters.Add("@material", SqlDbType.VarChar);
                objSqlCommand.Parameters["@material"].Value = material;

                objSqlCommand.Parameters.Add("@region", SqlDbType.VarChar);
                objSqlCommand.Parameters["@region"].Value = region;

                objSqlCommand.Parameters.Add("@varient_name", SqlDbType.VarChar);
                objSqlCommand.Parameters["@varient_name"].Value = varient_name;
                /*new change ankur 9 feb*/
                objSqlCommand.Parameters.Add("@coltype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@coltype"].Value = coltype;
                //////////////////////////////

                objSqlCommand.Parameters.Add("@logo_h", SqlDbType.VarChar);
                objSqlCommand.Parameters["@logo_h"].Value = logo_h;

                objSqlCommand.Parameters.Add("@logo_w", SqlDbType.VarChar);
                objSqlCommand.Parameters["@logo_w"].Value = logo_w;

                objSqlCommand.Parameters.Add("@logo_col", SqlDbType.VarChar);
                objSqlCommand.Parameters["@logo_col"].Value = logo_col;

                objSqlCommand.Parameters.Add("@logo_uom", SqlDbType.VarChar);
                objSqlCommand.Parameters["@logo_uom"].Value = logo_uom;

                objSqlCommand.Parameters.Add("@status", SqlDbType.VarChar);
                objSqlCommand.Parameters["@status"].Value = status;

                objSqlCommand.Parameters.Add("@retainer1", SqlDbType.VarChar);
                if (retainer.IndexOf("(") >= 0)
                {
                    retainer = retainer.Substring(retainer.IndexOf("(") + 1, retainer.Length - retainer.IndexOf("(") - 2);
                }
                objSqlCommand.Parameters["@retainer1"].Value = retainer;

                objSqlCommand.Parameters.Add("@addagencyrate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@addagencyrate"].Value = addagencyrate;

                objSqlCommand.Parameters.Add("@mobileno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@mobileno"].Value = mobileno;

                objSqlCommand.Parameters.Add("@addlamt", SqlDbType.VarChar);
                objSqlCommand.Parameters["@addlamt"].Value = addlamt;

                objSqlCommand.Parameters.Add("@retamt", SqlDbType.VarChar);
                objSqlCommand.Parameters["@retamt"].Value = retamt;

                objSqlCommand.Parameters.Add("@retper", SqlDbType.VarChar);
                objSqlCommand.Parameters["@retper"].Value = retper;

                objSqlCommand.Parameters.Add("@cashrecieved", SqlDbType.VarChar);
                if (cashrecieved == "" || cashrecieved == null)
                {
                    objSqlCommand.Parameters["@cashrecieved"].Value = System.DBNull.Value;
                }
                else
                {

                    objSqlCommand.Parameters["@cashrecieved"].Value = Convert.ToDecimal(cashrecieved);
                }
                objSqlCommand.Parameters.Add("@CIRAGENCY", SqlDbType.VarChar);
                objSqlCommand.Parameters["@CIRAGENCY"].Value = ciragency;

                objSqlCommand.Parameters.Add("@CIRRATE", SqlDbType.VarChar);
                objSqlCommand.Parameters["@CIRRATE"].Value = cirrate;

                objSqlCommand.Parameters.Add("@CIREDITION", SqlDbType.VarChar);
                objSqlCommand.Parameters["@CIREDITION"].Value = ciredition;

                objSqlCommand.Parameters.Add("@CIRPUBLICATION", SqlDbType.VarChar);
                objSqlCommand.Parameters["@CIRPUBLICATION"].Value = cirpublication;

                objSqlCommand.Parameters.Add("@CIRAGENCYSUBCODE", SqlDbType.VarChar);
                objSqlCommand.Parameters["@CIRAGENCYSUBCODE"].Value = ciragencysubcode;

                objSqlCommand.Parameters.Add("@BARTERTYPE", SqlDbType.VarChar);
                objSqlCommand.Parameters["@BARTERTYPE"].Value = bartertype;

                objSqlCommand.Parameters.Add("@CASHDISCOUNT_V", SqlDbType.VarChar);
                if (cashdiscount == "")
                    objSqlCommand.Parameters["@CASHDISCOUNT_V"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@CASHDISCOUNT_V"].Value = cashdiscount;

                objSqlCommand.Parameters.Add("@CASHDISCOUNTPER_V", SqlDbType.VarChar);
                objSqlCommand.Parameters["@CASHDISCOUNTPER_V"].Value = cashdiscper;

                objSqlCommand.Parameters.Add("@attach1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@attach1"].Value = attach1;

                objSqlCommand.Parameters.Add("@attach2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@attach2"].Value = attach2;

                objSqlCommand.Parameters.Add("@drpdiscprem", SqlDbType.VarChar);
                objSqlCommand.Parameters["@drpdiscprem"].Value = drpdiscprem;
                objSqlCommand.Parameters.Add("@doctype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@doctype"].Value = doctype;

                objSqlCommand.Parameters.Add("@CHKTRADE", SqlDbType.VarChar);
                objSqlCommand.Parameters["@CHKTRADE"].Value = chktradeval;
                objSqlCommand.Parameters.Add("@sharepub_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@sharepub_p"].Value = sharepub;

                objSqlCommand.Parameters.Add("@fmginsert", SqlDbType.VarChar);
                objSqlCommand.Parameters["@fmginsert"].Value = fmginsert;

                objSqlCommand.Parameters.Add("@chkno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@chkno"].Value = chkno;

                objSqlCommand.Parameters.Add("@chkdate", SqlDbType.DateTime);
                if (chkdate == "" || chkdate == null)
                {
                    objSqlCommand.Parameters["@chkdate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = chkdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        chkdate = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = chkdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        chkdate = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@chkdate"].Value = chkdate;
                }


                objSqlCommand.Parameters.Add("@chkamt", SqlDbType.VarChar);
                objSqlCommand.Parameters["@chkamt"].Value = chkamt;

                objSqlCommand.Parameters.Add("@chkbankname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@chkbankname"].Value = chkbankname;
                objSqlCommand.Parameters.Add("@ourbank", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ourbank"].Value = ourbank;

                objSqlCommand.Parameters.Add("@DEALERPANEL_P", SqlDbType.VarChar);
                if (dealerpanel == "")
                    objSqlCommand.Parameters["@DEALERPANEL_P"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@DEALERPANEL_P"].Value = dealerpanel;

                objSqlCommand.Parameters.Add("@DEALERH_P", SqlDbType.VarChar);
                if (dealerh == "")
                    objSqlCommand.Parameters["@DEALERH_P"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@DEALERH_P"].Value = dealerh;

                objSqlCommand.Parameters.Add("@DEALERW_P", SqlDbType.VarChar);
                if (dealerw == "")
                    objSqlCommand.Parameters["@DEALERW_P"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@DEALERW_P"].Value = dealerw;

                objSqlCommand.Parameters.Add("@DEALERTYPE_P", SqlDbType.VarChar);
                if (dealertype == "")
                    objSqlCommand.Parameters["@DEALERTYPE_P"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@DEALERTYPE_P"].Value = dealertype;

                objSqlCommand.Parameters.Add("@multiselect", SqlDbType.VarChar);
                objSqlCommand.Parameters["@multiselect"].Value = multicode;

                objSqlCommand.Parameters.Add("@AGREEDRATE_ACTIVE", SqlDbType.VarChar);
                if (agreedrate_active == "")
                    objSqlCommand.Parameters["@AGREEDRATE_ACTIVE"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@AGREEDRATE_ACTIVE"].Value = agreedrate_active;

                objSqlCommand.Parameters.Add("@AGREEDAMT_ACTIVE", SqlDbType.VarChar);
                if (agreedamt_active == "")
                    objSqlCommand.Parameters["@AGREEDAMT_ACTIVE"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@AGREEDAMT_ACTIVE"].Value = agreedamt_active;

                objSqlCommand.Parameters.Add("@grossamtlocal_p", SqlDbType.VarChar);
                if (grossamtlocal_p == "")
                    objSqlCommand.Parameters["@grossamtlocal_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@grossamtlocal_p"].Value = grossamtlocal_p;


                objSqlCommand.Parameters.Add("@billamtlocal_p", SqlDbType.VarChar);
                if (billamtlocal_p == "")
                    objSqlCommand.Parameters["@billamtlocal_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@billamtlocal_p"].Value = billamtlocal_p;



                objSqlCommand.Parameters.Add("@chkadon_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@chkadon_p"].Value = chkadon;

                objSqlCommand.Parameters.Add("@refid_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@refid_p"].Value = refid;


                objSqlCommand.Parameters.Add("@rcpt_currency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rcpt_currency"].Value = rcpt_currency;

                objSqlCommand.Parameters.Add("@cur_convrate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cur_convrate"].Value = cur_convrate;

                objSqlCommand.Parameters.Add("@p_revisedate", SqlDbType.VarChar);
                if (revisedate == "" || revisedate == null)
                {
                    objSqlCommand.Parameters["@p_revisedate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = revisedate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        revisedate = mm + "/" + dd + "/" + yy;


                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = revisedate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        revisedate = mm + "/" + dd + "/" + yy;


                    }
                    objSqlCommand.Parameters["@p_revisedate"].Value = revisedate;
                }

                objSqlCommand.Parameters.Add("@clienttype", SqlDbType.VarChar);
                if (clienttype == "0")
                    objSqlCommand.Parameters["@clienttype"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@clienttype"].Value = clienttype;

                objSqlCommand.Parameters.Add("@translation", SqlDbType.VarChar);
                if (translation == "0")
                    objSqlCommand.Parameters["@translation"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@translation"].Value = translation;

                objSqlCommand.Parameters.Add("@translationcharge", SqlDbType.Decimal);
                if (translationcharge == "" || translationcharge == null)
                {
                    objSqlCommand.Parameters["@translationcharge"].Value = System.DBNull.Value;
                }
                else
                {
                    translationcharge = translationcharge.Replace("%", "");
                    objSqlCommand.Parameters["@translationcharge"].Value = Convert.ToDecimal(translationcharge);
                }
                objSqlCommand.Parameters.Add("@fmgreasons", SqlDbType.VarChar);
                objSqlCommand.Parameters["@fmgreasons"].Value = fmgreasons;

                objSqlCommand.Parameters.Add("@canclecharge", SqlDbType.VarChar);
                objSqlCommand.Parameters["@canclecharge"].Value = canclecharge;

                objSqlCommand.Parameters.Add("@P_ip", SqlDbType.VarChar);
                objSqlCommand.Parameters["@P_ip"].Value = ip;

                objSqlCommand.Parameters.Add("@P_RATE_AUDIT_FLAG", SqlDbType.VarChar);
                objSqlCommand.Parameters["@P_RATE_AUDIT_FLAG"].Value = modifyrateaudit;

                objSqlCommand.Parameters.Add("@transdisc_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@transdisc_p"].Value = transdisc;

                objSqlCommand.Parameters.Add("@pospremdisc_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pospremdisc_p"].Value = pospremdisc;

                objSqlCommand.Parameters.Add("@billhold", SqlDbType.VarChar);
                objSqlCommand.Parameters["@billhold"].Value = billhold;

                objSqlCommand.Parameters.Add("@designbox", SqlDbType.VarChar);
                objSqlCommand.Parameters["@designbox"].Value = designbox;


                objSqlCommand.Parameters.Add("@logoprem", SqlDbType.VarChar);
                objSqlCommand.Parameters["@logoprem"].Value = logoprem;

                objSqlCommand.Parameters.Add("@online_ad_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@online_ad_p"].Value = online_ad;


                objSqlCommand.Parameters.Add("@style", SqlDbType.VarChar);
                objSqlCommand.Parameters["@style"].Value = style;


                objSqlCommand.Parameters.Add("@fixed_booking", SqlDbType.VarChar);
                objSqlCommand.Parameters["@fixed_booking"].Value = fixed_booking;


                objSqlCommand.Parameters.Add("@vat_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@vat_code"].Value = vat_code;

                objSqlCommand.Parameters.Add("@CPN_CODE_P", SqlDbType.VarChar);
                objSqlCommand.Parameters["@CPN_CODE_P"].Value = cou_code;

                objSqlCommand.Parameters.Add("@CPN_NAME_P", SqlDbType.VarChar);
                objSqlCommand.Parameters["@CPN_NAME_P"].Value = cou_name;

                objSqlCommand.Parameters.Add("@STATE_P", SqlDbType.VarChar);
                objSqlCommand.Parameters["@STATE_P"].Value = state;

                objSqlCommand.Parameters.Add("@clientcatdisc", SqlDbType.Decimal);
                if (clientcatdisc == "" || clientcatdisc == "0" || clientcatdisc == "null")
                {
                    objSqlCommand.Parameters["@clientcatdisc"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@clientcatdisc"].Value = clientcatdisc;
                }

                objSqlCommand.Parameters.Add("@clientcatamt", SqlDbType.Decimal);
                if (clientcatamt == "" || clientcatamt == "0" || clientcatamt == "null")
                {
                    objSqlCommand.Parameters["@clientcatamt"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@clientcatamt"].Value = clientcatamt;
                }

                objSqlCommand.Parameters.Add("@clientcatdistype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@clientcatdistype"].Value = clientcatdistype;


                objSqlCommand.Parameters.Add("@flatfreqdisc", SqlDbType.Decimal);
                if (flatfreqdisc == "" || flatfreqdisc == "0" || flatfreqdisc == "null")
                {
                    objSqlCommand.Parameters["@flatfreqdisc"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@flatfreqdisc"].Value = flatfreqdisc;
                }


                objSqlCommand.Parameters.Add("@flatfreqamt", SqlDbType.Decimal);
                if (flatfreqamt == "" || flatfreqamt == "0" || flatfreqamt == "null")
                {
                    objSqlCommand.Parameters["@flatfreqamt"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@flatfreqamt"].Value = flatfreqamt;
                }



                objSqlCommand.Parameters.Add("@flatfreqdisctype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@flatfreqdisctype"].Value = flatfreqdisctype;

                objSqlCommand.Parameters.Add("@catdisc", SqlDbType.Decimal);
                if (catdisc == "" || catdisc == "0" || catdisc == "null")
                {
                    objSqlCommand.Parameters["@catdisc"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@catdisc"].Value = catdisc;
                }

                objSqlCommand.Parameters.Add("@catamt", SqlDbType.Decimal);
                if (catamt == "" || catamt == "0" || catamt == "null")
                {
                    objSqlCommand.Parameters["@catamt"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@catamt"].Value = catamt;
                }

                objSqlCommand.Parameters.Add("@catdisctype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@catdisctype"].Value = catdisctype;

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
                CloseConnection(ref objSqlConnection);
            }
        }
        public DataSet insertbook_ins_display_bill(string insertdate, string edition, string premium1, string premium2, string premallow, string adcategory, string latestdate, string material, string cardrate, string matfilename, string discrate, string insertstatus, string billstatus, string adsubcat, string compcode, string userid, string cioid, string height, string width, string totalsize, string pagepost, string premper1, string premper2, string colid, string repeat, string insertno, string paid, string agrrate, string solorate, string grossrate, string insert_pageno, string insert_remarks, string page_code, string page_per, string noofcol, string billamt, string billrate, string logo_h, string logo_w, string logo_name, string insert_id, string dateformat, string adcat3, string adcat4, string adcat5, string pkgcode, string gridins, string pkgalias, string cirvts, string cirpub, string ciredi, string cirrate, string cirdate, string ciragency, string ciragencysubcode, string center, string branch, string splboldsizevalue, string vatrate, string boxcharge, string vat_inc_p, string grossamtlocal_p, string billamtlocal_p, string sectioncode_p, string resourceno_p, string caption_inserts, string dealerheight, string dealerwidth, string subedidata, string disc_, string modifyrateaudit, string ip, string agncyamnt, string adlgncyamnt, string spldisc, string cashdisc, string roundoffamt, string pdfheight, string cpnamt, string clientcatamt, string flatfreqamt, string catamt)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("insertintobookchild_display_bill", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@insertdate", SqlDbType.DateTime);
                if (insertdate == "" || insertdate == null || insertdate == "null")
                {
                    objSqlCommand.Parameters["@insertdate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = insertdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        insertdate = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = insertdate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        insertdate = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@insertdate"].Value = Convert.ToDateTime(insertdate);
                }

                objSqlCommand.Parameters.Add("@edition", SqlDbType.VarChar);
                objSqlCommand.Parameters["@edition"].Value = edition;

                objSqlCommand.Parameters.Add("@premium1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@premium1"].Value = premium1;

                objSqlCommand.Parameters.Add("@premium2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@premium2"].Value = premium2;

                objSqlCommand.Parameters.Add("@premallow", SqlDbType.VarChar);
                objSqlCommand.Parameters["@premallow"].Value = premallow;

                objSqlCommand.Parameters.Add("@adcategory", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adcategory"].Value = adcategory;

                objSqlCommand.Parameters.Add("@latestdate", SqlDbType.DateTime);
                if (latestdate == "" || latestdate == null || latestdate == "null")
                {
                    objSqlCommand.Parameters["@latestdate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = latestdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        latestdate = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = latestdate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        latestdate = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@latestdate"].Value = Convert.ToDateTime(latestdate);
                }
                //,,,,,,,,,,,,,

                objSqlCommand.Parameters.Add("@material", SqlDbType.VarChar);
                objSqlCommand.Parameters["@material"].Value = material;

                objSqlCommand.Parameters.Add("@cardrate", SqlDbType.Decimal);
                if (cardrate == "" || cardrate == null || cardrate == "null")
                {
                    objSqlCommand.Parameters["@cardrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@cardrate"].Value = Convert.ToDecimal(cardrate);
                }

                objSqlCommand.Parameters.Add("@matfilename", SqlDbType.VarChar);
                objSqlCommand.Parameters["@matfilename"].Value = matfilename;

                objSqlCommand.Parameters.Add("@discrate", SqlDbType.Decimal);
                if (discrate == "" || discrate == null || discrate == "null")
                {
                    objSqlCommand.Parameters["@discrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@discrate"].Value = Convert.ToDecimal(discrate);
                }

                objSqlCommand.Parameters.Add("@insertstatus", SqlDbType.VarChar);
                objSqlCommand.Parameters["@insertstatus"].Value = insertstatus;

                objSqlCommand.Parameters.Add("@billstatus", SqlDbType.VarChar);
                objSqlCommand.Parameters["@billstatus"].Value = billstatus;

                objSqlCommand.Parameters.Add("@adsubcat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adsubcat"].Value = adsubcat;





                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;


                objSqlCommand.Parameters.Add("@cioid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cioid"].Value = cioid;

                //

                objSqlCommand.Parameters.Add("@height", SqlDbType.Decimal);
                if (height == "" || height == null || height == "null")
                {
                    objSqlCommand.Parameters["@height"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@height"].Value = Convert.ToDecimal(height);
                }

                objSqlCommand.Parameters.Add("@width", SqlDbType.Decimal);
                if (width == "" || width == null || width == "null")
                {
                    objSqlCommand.Parameters["@width"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@width"].Value = Convert.ToDecimal(width);
                }

                objSqlCommand.Parameters.Add("@totalsize", SqlDbType.Decimal);
                if (totalsize == "" || totalsize == null || totalsize == "null")
                {
                    objSqlCommand.Parameters["@totalsize"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@totalsize"].Value = Convert.ToDecimal(totalsize);
                }

                objSqlCommand.Parameters.Add("@pagepost", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pagepost"].Value = pagepost;

                objSqlCommand.Parameters.Add("@premper1", SqlDbType.Decimal);
                if (premper1 == "" || premper1 == null || premper1 == "null")
                {
                    objSqlCommand.Parameters["@premper1"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@premper1"].Value = Convert.ToDecimal(premper1);
                }

                objSqlCommand.Parameters.Add("@premper2", SqlDbType.Decimal);
                if (premper2 == "" || premper2 == null || premper2 == "null")
                {
                    objSqlCommand.Parameters["@premper2"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@premper2"].Value = Convert.ToDecimal(premper2);
                }

                objSqlCommand.Parameters.Add("@colid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@colid"].Value = colid;

                objSqlCommand.Parameters.Add("@repeat", SqlDbType.DateTime);
                if (repeat == "" || repeat == null || repeat == "null")
                {
                    objSqlCommand.Parameters["@repeat"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = repeat.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        repeat = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = repeat.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        repeat = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@repeat"].Value = Convert.ToDateTime(repeat);
                }




                objSqlCommand.Parameters.Add("@insertno", SqlDbType.Int);
                if (insertno == "" || insertno == null || insertno == "null")
                {
                    objSqlCommand.Parameters["@insertno"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@insertno"].Value = Convert.ToInt32(insertno);
                }

                objSqlCommand.Parameters.Add("@paid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@paid"].Value = paid;

                objSqlCommand.Parameters.Add("@agrrate", SqlDbType.Decimal);
                if (agrrate == "" || agrrate == null || agrrate == "null")
                {
                    objSqlCommand.Parameters["@agrrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@agrrate"].Value = Convert.ToDecimal(agrrate);
                }

                objSqlCommand.Parameters.Add("@solorate", SqlDbType.Decimal);
                if (solorate == "" || solorate == null || solorate == "null")
                {
                    objSqlCommand.Parameters["@solorate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@solorate"].Value = Convert.ToDecimal(solorate);
                }

                objSqlCommand.Parameters.Add("@grossrate", SqlDbType.Decimal);
                if (grossrate == "" || grossrate == null || grossrate == "null")
                {
                    objSqlCommand.Parameters["@grossrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@grossrate"].Value = Convert.ToDecimal(grossrate);
                }

                objSqlCommand.Parameters.Add("@insert_remarks", SqlDbType.VarChar);
                objSqlCommand.Parameters["@insert_remarks"].Value = insert_remarks;

                objSqlCommand.Parameters.Add("@insert_pageno", SqlDbType.Int);
                if (insert_pageno == "" || insert_pageno == null || insert_pageno == "null")
                {
                    objSqlCommand.Parameters["@insert_pageno"].Value = Convert.ToInt32("0");
                }
                else
                {
                    objSqlCommand.Parameters["@insert_pageno"].Value = Convert.ToInt32(insert_pageno);
                }

                objSqlCommand.Parameters.Add("@page_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@page_code"].Value = page_code;

                objSqlCommand.Parameters.Add("@page_per", SqlDbType.Decimal);
                if (page_per == "" || page_per == null || page_per == "null")
                {
                    objSqlCommand.Parameters["@page_per"].Value = Convert.ToDecimal("0");
                }
                else
                {
                    objSqlCommand.Parameters["@page_per"].Value = Convert.ToDecimal(page_per);
                }

                objSqlCommand.Parameters.Add("@noofcol", SqlDbType.Decimal);
                if (noofcol == "" || noofcol == null || noofcol == "null")
                {
                    objSqlCommand.Parameters["@noofcol"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@noofcol"].Value = Convert.ToDecimal(noofcol);
                }

                objSqlCommand.Parameters.Add("@billamt", SqlDbType.Decimal);
                if (billamt == "" || billamt == null || billamt == "null")
                {
                    objSqlCommand.Parameters["@billamt"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@billamt"].Value = Convert.ToDecimal(billamt);
                }


                objSqlCommand.Parameters.Add("@billrate", SqlDbType.Decimal);
                if (billrate == "" || billrate == null || billrate == "null")
                {
                    objSqlCommand.Parameters["@billrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@billrate"].Value = Convert.ToDecimal(billrate);
                }

                objSqlCommand.Parameters.Add("@logo_h", SqlDbType.VarChar);
                objSqlCommand.Parameters["@logo_h"].Value = logo_h;

                objSqlCommand.Parameters.Add("@logo_w", SqlDbType.VarChar);
                objSqlCommand.Parameters["@logo_w"].Value = logo_w;

                objSqlCommand.Parameters.Add("@logo_name", SqlDbType.VarChar);
                objSqlCommand.Parameters["@logo_name"].Value = logo_name;

                objSqlCommand.Parameters.Add("@insertid", SqlDbType.Int);
                if (insert_id == "")
                    insert_id = "0";
                objSqlCommand.Parameters["@insertid"].Value = insert_id;

                objSqlCommand.Parameters.Add("@ad_cat_3", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ad_cat_3"].Value = adcat3;

                objSqlCommand.Parameters.Add("@ad_cat_4", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ad_cat_4"].Value = adcat4;

                objSqlCommand.Parameters.Add("@ad_cat_5", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ad_cat_5"].Value = adcat5;

                objSqlCommand.Parameters.Add("@pkgcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pkgcode"].Value = pkgcode;

                objSqlCommand.Parameters.Add("@gridins", SqlDbType.Int);
                objSqlCommand.Parameters["@gridins"].Value = gridins;

                objSqlCommand.Parameters.Add("@pkgalias", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pkgalias"].Value = pkgalias;

                objSqlCommand.Parameters.Add("@cirvts", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cirvts"].Value = cirvts;

                objSqlCommand.Parameters.Add("@cirpub", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cirpub"].Value = cirpub;

                objSqlCommand.Parameters.Add("@ciredi", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ciredi"].Value = ciredi;

                objSqlCommand.Parameters.Add("@cirrate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cirrate"].Value = cirrate;

                objSqlCommand.Parameters.Add("@cirdate", SqlDbType.VarChar);
                if (cirdate == "" || cirdate == null || cirdate == "null")
                {
                    objSqlCommand.Parameters["@cirdate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = cirdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        cirdate = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = cirdate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        cirdate = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@cirdate"].Value = Convert.ToDateTime(cirdate);
                }



                objSqlCommand.Parameters.Add("@ciragency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ciragency"].Value = ciragency;

                objSqlCommand.Parameters.Add("@ciragencysubcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ciragencysubcode"].Value = ciragencysubcode;

                objSqlCommand.Parameters.Add("@center", SqlDbType.VarChar);
                objSqlCommand.Parameters["@center"].Value = center;

                objSqlCommand.Parameters.Add("@branch", SqlDbType.VarChar);
                objSqlCommand.Parameters["@branch"].Value = branch;
                objSqlCommand.Parameters.Add("@splboldsizevalue", SqlDbType.VarChar);
                objSqlCommand.Parameters["@splboldsizevalue"].Value = splboldsizevalue;

                objSqlCommand.Parameters.Add("@vatrate_p", SqlDbType.Float);
                if (vatrate == "" || vatrate == "null" || vatrate == null)
                    objSqlCommand.Parameters["@vatrate_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@vatrate_p"].Value = Convert.ToDecimal(vatrate);
                objSqlCommand.Parameters.Add("@boxcharge_p", SqlDbType.Float);
                if (boxcharge == "" || boxcharge == "null" || boxcharge == null || boxcharge == "0")
                    objSqlCommand.Parameters["@boxcharge_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@boxcharge_p"].Value = Convert.ToDecimal(boxcharge);

                objSqlCommand.Parameters.Add("@vat_inc_p", SqlDbType.Float);
                if (vat_inc_p == "" || vat_inc_p == "null" || vat_inc_p == null)
                    objSqlCommand.Parameters["@vat_inc_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@vat_inc_p"].Value = vat_inc_p;

                objSqlCommand.Parameters.Add("@grossamtlocal_p", SqlDbType.Float);
                if (grossamtlocal_p == "" || grossamtlocal_p == "null" || grossamtlocal_p == null)
                    objSqlCommand.Parameters["@grossamtlocal_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@grossamtlocal_p"].Value = grossamtlocal_p;


                objSqlCommand.Parameters.Add("@billamtlocal_p", SqlDbType.Float);
                if (billamtlocal_p == "" || billamtlocal_p == "null" || billamtlocal_p == null)
                    objSqlCommand.Parameters["@billamtlocal_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@billamtlocal_p"].Value = billamtlocal_p;

                objSqlCommand.Parameters.Add("@sectioncode_p", SqlDbType.VarChar);
                if (sectioncode_p == "" || sectioncode_p == "null" || sectioncode_p == null)
                    objSqlCommand.Parameters["@sectioncode_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@sectioncode_p"].Value = sectioncode_p;

                objSqlCommand.Parameters.Add("@resourceno_p", SqlDbType.VarChar);
                if (resourceno_p == "" || resourceno_p == "null" || resourceno_p == null)
                    objSqlCommand.Parameters["@resourceno_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@resourceno_p"].Value = resourceno_p;

                objSqlCommand.Parameters.Add("@caption_inserts_p", SqlDbType.VarChar);
                if (caption_inserts == "" || caption_inserts == "null" || caption_inserts == null)
                    objSqlCommand.Parameters["@caption_inserts_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@caption_inserts_p"].Value = caption_inserts;



                objSqlCommand.Parameters.Add("@subedidata", SqlDbType.VarChar);
                objSqlCommand.Parameters["@subedidata"].Value = subedidata;

                objSqlCommand.Parameters.Add("@disc_p", SqlDbType.Float);
                if (disc_ == "" || disc_ == "null" || disc_ == null)
                    objSqlCommand.Parameters["@disc_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@disc_p"].Value = disc_;

                objSqlCommand.Parameters.Add("@P_ip", SqlDbType.VarChar);
                objSqlCommand.Parameters["@P_ip"].Value = ip;


                objSqlCommand.Parameters.Add("@P_RATE_AUDIT_FLAG", SqlDbType.VarChar);
                objSqlCommand.Parameters["@P_RATE_AUDIT_FLAG"].Value = modifyrateaudit;


                objSqlCommand.Parameters.Add("@dealerheight_p", SqlDbType.Decimal);
                if (dealerheight == "" || dealerheight == "null" || dealerheight == null || dealerheight == "default")
                    objSqlCommand.Parameters["@dealerheight_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@dealerheight_p"].Value = dealerheight;

                objSqlCommand.Parameters.Add("@dealerwidth_inserts_p", SqlDbType.Decimal);
                if (dealerwidth == "" || dealerwidth == "null" || dealerwidth == null || dealerwidth == "default")
                    objSqlCommand.Parameters["@dealerwidth_inserts_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@dealerwidth_inserts_p"].Value = dealerwidth;

                objSqlCommand.Parameters.Add("@agncyamnt", SqlDbType.VarChar);
                if (agncyamnt == "" || agncyamnt == "null" || agncyamnt == null)
                    objSqlCommand.Parameters["@agncyamnt"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@agncyamnt"].Value = agncyamnt;

                objSqlCommand.Parameters.Add("@adlgncyamnt", SqlDbType.VarChar);
                if (adlgncyamnt == "" || adlgncyamnt == "null" || adlgncyamnt == null)
                    objSqlCommand.Parameters["@adlgncyamnt"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@adlgncyamnt"].Value = adlgncyamnt;



                objSqlCommand.Parameters.Add("@spldiscamt", SqlDbType.VarChar);
                if (spldisc == "" || spldisc == "null" || spldisc == null)
                    objSqlCommand.Parameters["@spldiscamt"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@spldiscamt"].Value = spldisc;

                objSqlCommand.Parameters.Add("@cashdamnt", SqlDbType.VarChar);
                if (cashdisc == "" || cashdisc == "null" || cashdisc == null)
                    objSqlCommand.Parameters["@cashdamnt"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@cashdamnt"].Value = cashdisc;

                objSqlCommand.Parameters.Add("@ROUNDOFF", SqlDbType.VarChar);
                if (roundoffamt == "" || roundoffamt == "null" || roundoffamt == null)
                    objSqlCommand.Parameters["@ROUNDOFF"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@ROUNDOFF"].Value = roundoffamt;

                objSqlCommand.Parameters.Add("@PDFHEIGHT", SqlDbType.VarChar);
                if (pdfheight == "" || pdfheight == "null" || pdfheight == null)
                    objSqlCommand.Parameters["@PDFHEIGHT"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@PDFHEIGHT"].Value = pdfheight;

                objSqlCommand.Parameters.Add("@CPNAMT", SqlDbType.VarChar);
                if (cpnamt == "" || cpnamt == "null" || cpnamt == null)
                    objSqlCommand.Parameters["@CPNAMT"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@CPNAMT"].Value = cpnamt;

                objSqlCommand.Parameters.Add("@clientcatamt", SqlDbType.Decimal);
                if (clientcatamt == "" || clientcatamt == "0" || clientcatamt == "null")
                {
                    objSqlCommand.Parameters["@clientcatamt"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@clientcatamt"].Value = clientcatamt;
                }

                objSqlCommand.Parameters.Add("@flatfreqamt", SqlDbType.Decimal);
                if (flatfreqamt == "" || flatfreqamt == "0" || flatfreqamt == "null")
                {
                    objSqlCommand.Parameters["@flatfreqamt"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@flatfreqamt"].Value = flatfreqamt;
                }

                objSqlCommand.Parameters.Add("@catamt", SqlDbType.Decimal);
                if (catamt == "" || catamt == "0" || catamt == "null")
                {
                    objSqlCommand.Parameters["@catamt"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@catamt"].Value = catamt;
                }

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
                CloseConnection(ref objSqlConnection);
            }
        }
        public DataSet billupdatedatatemptable(string compcode, string ciobookid, string supplementbilldate, string supplementbillno, string userid, string dateformat, string supcioid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {

                objSqlConnection.Open();
                objSqlCommand = GetCommand("receiptsave_booking_bill", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcompcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@puserid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@puserid"].Value = userid;

                objSqlCommand.Parameters.Add("@pcioid1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcioid1"].Value = ciobookid;

                objSqlCommand.Parameters.Add("@poldbill_no", SqlDbType.VarChar);
                objSqlCommand.Parameters["@poldbill_no"].Value = supplementbillno;

                objSqlCommand.Parameters.Add("@pcioid2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcioid2"].Value = supcioid;

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
                CloseConnection(ref objSqlConnection);
            }


        }
        public DataSet colexec_bind(string compcode, string colexec)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("repbind", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlDataAdapter = new SqlDataAdapter();
                objSqlCommand.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcompcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@pextra1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra1"].Value = colexec;

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
                CloseConnection(ref objSqlConnection);
            }
        }
        public DataSet insertbook_ins(string insertdate, string edition, string premium1, string premium2, string premallow, string adcategory, string latestdate, string material, string cardrate, string matfilename, string discrate, string insertstatus, string billstatus, string adsubcat, string compcode, string userid, string cioid, string height, string width, string totalsize, string pagepost, string premper1, string premper2, string colid, string repeat, string insertno, string paid, string agrrate, string solorate, string grossrate, string insert_pageno, string insert_remarks, string page_code, string page_per, string noofcol, string billamt, string billrate, string logo_h, string logo_w, string logo_name, string dateformat, string adcat3, string adcat4, string adcat5, string pkgcode, string gridins, string pkgalias, string cirvts, string cirpub, string ciredi, string cirrate, string cirdate, string ciragency, string ciragencysubcode, string center, string branch, string splitdata, string subedidata, string splboldsizevalue, string vatrate, string boxcharge, string vat_inc_p, string grossamtlocal_p, string billamtlocal_p, string sectioncode_p, string resourceno_p, string caption_inserts, string dealerheight, string dealerwidth, string disc_, string agncyamnt, string adlgncyamnt, string spldisc, string cashdisc, string roundoffamt, string pdfheight, string cpnamt, string clientcatamt, string flatfreqamt, string catamt, string premamtval, string gstamount, string gstgrid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("insertintobookchild", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@insertdate", SqlDbType.DateTime);
                if (insertdate == "" || insertdate == null || insertdate == "null")
                {
                    objSqlCommand.Parameters["@insertdate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = insertdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        insertdate = mm + "/" + dd + "/" + yy;


                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = insertdate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        insertdate = mm + "/" + dd + "/" + yy;


                    }
                    objSqlCommand.Parameters["@insertdate"].Value = Convert.ToDateTime(insertdate);
                }

                objSqlCommand.Parameters.Add("@edition", SqlDbType.VarChar);
                objSqlCommand.Parameters["@edition"].Value = edition;

                objSqlCommand.Parameters.Add("@premium1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@premium1"].Value = premium1;

                objSqlCommand.Parameters.Add("@premium2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@premium2"].Value = premium2;

                objSqlCommand.Parameters.Add("@premallow", SqlDbType.VarChar);
                objSqlCommand.Parameters["@premallow"].Value = premallow;

                objSqlCommand.Parameters.Add("@adcategory", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adcategory"].Value = adcategory;

                objSqlCommand.Parameters.Add("@latestdate", SqlDbType.DateTime);
                if (latestdate == "" || latestdate == null || latestdate == "null")
                {
                    objSqlCommand.Parameters["@latestdate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = latestdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        latestdate = mm + "/" + dd + "/" + yy;


                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = latestdate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        latestdate = mm + "/" + dd + "/" + yy;


                    }
                    objSqlCommand.Parameters["@latestdate"].Value = Convert.ToDateTime(latestdate);
                }
                //,,,,,,,,,,,,,

                objSqlCommand.Parameters.Add("@material", SqlDbType.VarChar);
                objSqlCommand.Parameters["@material"].Value = material;

                objSqlCommand.Parameters.Add("@cardrate", SqlDbType.Decimal);
                if (cardrate == "" || cardrate == null || cardrate == "null")
                {
                    objSqlCommand.Parameters["@cardrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@cardrate"].Value = Convert.ToDecimal(cardrate);
                }

                objSqlCommand.Parameters.Add("@matfilename", SqlDbType.VarChar);
                objSqlCommand.Parameters["@matfilename"].Value = matfilename;

                objSqlCommand.Parameters.Add("@discrate", SqlDbType.Decimal);
                if (discrate == "" || discrate == null || discrate == "null")
                {
                    objSqlCommand.Parameters["@discrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@discrate"].Value = Convert.ToDecimal(discrate);
                }

                objSqlCommand.Parameters.Add("@insertstatus", SqlDbType.VarChar);
                objSqlCommand.Parameters["@insertstatus"].Value = insertstatus;

                objSqlCommand.Parameters.Add("@billstatus", SqlDbType.VarChar);
                objSqlCommand.Parameters["@billstatus"].Value = billstatus;

                objSqlCommand.Parameters.Add("@adsubcat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adsubcat"].Value = adsubcat;





                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;


                objSqlCommand.Parameters.Add("@cioid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cioid"].Value = cioid;

                //

                objSqlCommand.Parameters.Add("@height", SqlDbType.Decimal);
                if (height == "" || height == null || height == "null")
                {
                    objSqlCommand.Parameters["@height"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@height"].Value = Convert.ToDecimal(height);
                }

                objSqlCommand.Parameters.Add("@width", SqlDbType.Decimal);
                if (width == "" || width == null || width == "null")
                {
                    objSqlCommand.Parameters["@width"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@width"].Value = Convert.ToDecimal(width);
                }

                objSqlCommand.Parameters.Add("@totalsize", SqlDbType.Decimal);
                if (totalsize == "" || totalsize == null || totalsize == "null")
                {
                    objSqlCommand.Parameters["@totalsize"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@totalsize"].Value = Convert.ToDecimal(totalsize);
                }

                objSqlCommand.Parameters.Add("@pagepost", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pagepost"].Value = pagepost;

                objSqlCommand.Parameters.Add("@premper1", SqlDbType.Decimal);
                if (premper1 == "" || premper1 == null || premper1 == "null")
                {
                    objSqlCommand.Parameters["@premper1"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@premper1"].Value = Convert.ToDecimal(premper1);
                }

                objSqlCommand.Parameters.Add("@premper2", SqlDbType.Decimal);
                if (premper2 == "" || premper2 == null || premper2 == "null")
                {
                    objSqlCommand.Parameters["@premper2"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@premper2"].Value = Convert.ToDecimal(premper2);
                }

                objSqlCommand.Parameters.Add("@colid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@colid"].Value = colid;

                objSqlCommand.Parameters.Add("@repeat", SqlDbType.DateTime);
                if (repeat == "" || repeat == null || repeat == "null")
                {
                    objSqlCommand.Parameters["@repeat"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = repeat.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        repeat = mm + "/" + dd + "/" + yy;


                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = repeat.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        repeat = mm + "/" + dd + "/" + yy;


                    }
                    objSqlCommand.Parameters["@repeat"].Value = Convert.ToDateTime(repeat);
                }




                objSqlCommand.Parameters.Add("@insertno", SqlDbType.Int);
                if (insertno == "" || insertno == null || insertno == "null")
                {
                    objSqlCommand.Parameters["@insertno"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@insertno"].Value = Convert.ToInt32(insertno);
                }

                objSqlCommand.Parameters.Add("@paid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@paid"].Value = paid;

                objSqlCommand.Parameters.Add("@agrrate", SqlDbType.Decimal);
                if (agrrate == "" || agrrate == null || agrrate == "null")
                {
                    objSqlCommand.Parameters["@agrrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@agrrate"].Value = Convert.ToDecimal(agrrate);
                }

                objSqlCommand.Parameters.Add("@solorate", SqlDbType.Decimal);
                if (solorate == "" || solorate == null || solorate == "null")
                {
                    objSqlCommand.Parameters["@solorate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@solorate"].Value = Convert.ToDecimal(solorate);
                }

                objSqlCommand.Parameters.Add("@grossrate", SqlDbType.Decimal);
                if (grossrate == "" || grossrate == null || grossrate == "null")
                {
                    objSqlCommand.Parameters["@grossrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@grossrate"].Value = Convert.ToDecimal(grossrate);
                }

                objSqlCommand.Parameters.Add("@insert_remarks", SqlDbType.VarChar);
                objSqlCommand.Parameters["@insert_remarks"].Value = insert_remarks;

                objSqlCommand.Parameters.Add("@insert_pageno", SqlDbType.Int);
                if (insert_pageno == "" || insert_pageno == null || insert_pageno == "null")
                {
                    objSqlCommand.Parameters["@insert_pageno"].Value = Convert.ToInt32("0");
                }
                else
                {
                    objSqlCommand.Parameters["@insert_pageno"].Value = Convert.ToInt32(insert_pageno);
                }

                objSqlCommand.Parameters.Add("@page_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@page_code"].Value = page_code;

                objSqlCommand.Parameters.Add("@page_per", SqlDbType.Decimal);
                if (page_per == "" || page_per == null || page_per == "null")
                {
                    objSqlCommand.Parameters["@page_per"].Value = Convert.ToDecimal("0");
                }
                else
                {
                    objSqlCommand.Parameters["@page_per"].Value = Convert.ToDecimal(page_per);
                }

                objSqlCommand.Parameters.Add("@noofcol", SqlDbType.Decimal);
                if (noofcol == "" || noofcol == null || noofcol == "null")
                {
                    objSqlCommand.Parameters["@noofcol"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@noofcol"].Value = Convert.ToDecimal(noofcol);
                }

                objSqlCommand.Parameters.Add("@billamt", SqlDbType.Decimal);
                if (billamt == "" || billamt == null || billamt == "null")
                {
                    objSqlCommand.Parameters["@billamt"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@billamt"].Value = Convert.ToDecimal(billamt);
                }


                objSqlCommand.Parameters.Add("@billrate", SqlDbType.Decimal);
                if (billrate == "" || billrate == null || billrate == "null")
                {
                    objSqlCommand.Parameters["@billrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@billrate"].Value = Convert.ToDecimal(billrate);
                }

                objSqlCommand.Parameters.Add("@logo_h", SqlDbType.VarChar);
                objSqlCommand.Parameters["@logo_h"].Value = logo_h;

                objSqlCommand.Parameters.Add("@logo_w", SqlDbType.VarChar);
                objSqlCommand.Parameters["@logo_w"].Value = logo_w;

                objSqlCommand.Parameters.Add("@logo_name", SqlDbType.VarChar);
                objSqlCommand.Parameters["@logo_name"].Value = logo_name;

                objSqlCommand.Parameters.Add("@ad_cat_3", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ad_cat_3"].Value = adcat3;

                objSqlCommand.Parameters.Add("@ad_cat_4", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ad_cat_4"].Value = adcat4;

                objSqlCommand.Parameters.Add("@ad_cat_5", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ad_cat_5"].Value = adcat5;

                objSqlCommand.Parameters.Add("@pkgcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pkgcode"].Value = pkgcode;

                objSqlCommand.Parameters.Add("@gridins", SqlDbType.Int);
                if (gridins == "" || gridins == null || gridins == "null")
                {
                    objSqlCommand.Parameters["@gridins"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@gridins"].Value = gridins;
                }

                objSqlCommand.Parameters.Add("@pkgalias", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pkgalias"].Value = pkgalias;

                objSqlCommand.Parameters.Add("@cirvts", SqlDbType.VarChar);
                if (cirvts == "null" || cirvts == null)
                    objSqlCommand.Parameters["@cirvts"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@cirvts"].Value = cirvts;


                objSqlCommand.Parameters.Add("@cirpub", SqlDbType.VarChar);
                if (cirpub == "null" || cirpub == null)
                    objSqlCommand.Parameters["@cirpub"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@cirpub"].Value = cirpub;


                objSqlCommand.Parameters.Add("@ciredi", SqlDbType.VarChar);
                if (ciredi == "null" || ciredi == null)
                    objSqlCommand.Parameters["@ciredi"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@ciredi"].Value = ciredi;


                objSqlCommand.Parameters.Add("@cirrate", SqlDbType.VarChar);
                if (cirrate == "null" && cirrate == null)
                    objSqlCommand.Parameters["@cirrate"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@cirrate"].Value = cirrate;

                objSqlCommand.Parameters.Add("@cirdate", SqlDbType.VarChar);
                if (cirdate == "" || cirdate == null || cirdate == "null")
                {
                    objSqlCommand.Parameters["@cirdate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = cirdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        cirdate = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = cirdate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        cirdate = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@cirdate"].Value = Convert.ToDateTime(cirdate);
                }



                objSqlCommand.Parameters.Add("@ciragency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ciragency"].Value = ciragency;

                objSqlCommand.Parameters.Add("@ciragencysubcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ciragencysubcode"].Value = ciragencysubcode;

                objSqlCommand.Parameters.Add("@center", SqlDbType.VarChar);
                objSqlCommand.Parameters["@center"].Value = center;

                objSqlCommand.Parameters.Add("@branch", SqlDbType.VarChar);
                objSqlCommand.Parameters["@branch"].Value = branch;

                objSqlCommand.Parameters.Add("@splitdata_v", SqlDbType.VarChar);
                objSqlCommand.Parameters["@splitdata_v"].Value = splitdata;

                objSqlCommand.Parameters.Add("@subedidata", SqlDbType.VarChar);
                objSqlCommand.Parameters["@subedidata"].Value = subedidata;

                objSqlCommand.Parameters.Add("@splboldsizevalue", SqlDbType.VarChar);
                objSqlCommand.Parameters["@splboldsizevalue"].Value = splboldsizevalue;

                objSqlCommand.Parameters.Add("@vatrate_p", SqlDbType.Float);
                if (vatrate == "" || vatrate == "null" || vatrate == null)
                    objSqlCommand.Parameters["@vatrate_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@vatrate_p"].Value = Convert.ToDecimal(vatrate);

                objSqlCommand.Parameters.Add("@boxcharge_p", SqlDbType.Float);
                if (boxcharge == "" || boxcharge == "null" || boxcharge == null || boxcharge == "0")
                    objSqlCommand.Parameters["@boxcharge_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@boxcharge_p"].Value = Convert.ToDecimal(boxcharge);

                objSqlCommand.Parameters.Add("@vat_inc_p", SqlDbType.Float);
                if (vat_inc_p == "" || vat_inc_p == "null" || vat_inc_p == null)
                    objSqlCommand.Parameters["@vat_inc_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@vat_inc_p"].Value = vat_inc_p;

                objSqlCommand.Parameters.Add("@grossamtlocal_p", SqlDbType.Float);
                if (grossamtlocal_p == "" || grossamtlocal_p == "null" || grossamtlocal_p == null)
                    objSqlCommand.Parameters["@grossamtlocal_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@grossamtlocal_p"].Value = grossamtlocal_p;


                objSqlCommand.Parameters.Add("@billamtlocal_p", SqlDbType.Float);
                if (billamtlocal_p == "" || billamtlocal_p == "null" || billamtlocal_p == null)
                    objSqlCommand.Parameters["@billamtlocal_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@billamtlocal_p"].Value = billamtlocal_p;

                objSqlCommand.Parameters.Add("@sectioncode_p", SqlDbType.VarChar);
                if (sectioncode_p == "" || sectioncode_p == "null" || sectioncode_p == null)
                    objSqlCommand.Parameters["@sectioncode_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@sectioncode_p"].Value = sectioncode_p;


                objSqlCommand.Parameters.Add("@resourceno_p", SqlDbType.VarChar);
                if (resourceno_p == "" || resourceno_p == "null" || resourceno_p == null)
                    objSqlCommand.Parameters["@resourceno_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@resourceno_p"].Value = resourceno_p;

                objSqlCommand.Parameters.Add("@caption_inserts_p", SqlDbType.VarChar);
                if (caption_inserts == "" || caption_inserts == "null" || caption_inserts == null)
                    objSqlCommand.Parameters["@caption_inserts_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@caption_inserts_p"].Value = caption_inserts;

                objSqlCommand.Parameters.Add("@dealerheight", SqlDbType.Decimal);
                if (dealerheight == "" || dealerheight == "null" || dealerheight == null)
                    objSqlCommand.Parameters["@dealerheight"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@resourceno_p"].Value = dealerheight;

                objSqlCommand.Parameters.Add("@dealerwidth", SqlDbType.Decimal);
                if (dealerwidth == "" || dealerwidth == "null" || dealerwidth == null)
                    objSqlCommand.Parameters["@dealerwidth"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@dealerwidth"].Value = dealerwidth;

                objSqlCommand.Parameters.Add("@disc_p", SqlDbType.Float);
                if (disc_ == "" || disc_ == "null" || disc_ == null)
                    objSqlCommand.Parameters["@disc_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@disc_p"].Value = disc_;

                objSqlCommand.Parameters.Add("@agncyamnt", SqlDbType.VarChar);
                if (agncyamnt == "" || agncyamnt == "null" || disc_ == null)
                    objSqlCommand.Parameters["@agncyamnt"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@agncyamnt"].Value = agncyamnt;

                objSqlCommand.Parameters.Add("@adlgncyamnt", SqlDbType.VarChar);
                if (adlgncyamnt == "" || adlgncyamnt == "null" || disc_ == null)
                    objSqlCommand.Parameters["@adlgncyamnt"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@adlgncyamnt"].Value = adlgncyamnt;

                objSqlCommand.Parameters.Add("@spldiscamt", SqlDbType.VarChar);
                if (spldisc == "" || spldisc == "null" || spldisc == null)
                    objSqlCommand.Parameters["@spldiscamt"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@spldiscamt"].Value = spldisc;

                objSqlCommand.Parameters.Add("@cashdamnt", SqlDbType.VarChar);
                if (cashdisc == "" || cashdisc == "null" || cashdisc == null)
                    objSqlCommand.Parameters["@cashdamnt"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@cashdamnt"].Value = cashdisc;

                objSqlCommand.Parameters.Add("@ROUNDOFF", SqlDbType.VarChar);
                if (roundoffamt == "" || roundoffamt == "null" || roundoffamt == null)
                    objSqlCommand.Parameters["@ROUNDOFF"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@ROUNDOFF"].Value = roundoffamt;

                objSqlCommand.Parameters.Add("@PDFHEIGHT", SqlDbType.VarChar);
                if (pdfheight == "" || pdfheight == "null" || pdfheight == null)
                    objSqlCommand.Parameters["@PDFHEIGHT"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@PDFHEIGHT"].Value = pdfheight;

                objSqlCommand.Parameters.Add("@CPNAMT", SqlDbType.VarChar);
                if (cpnamt == "" || cpnamt == "null" || cpnamt == null)
                    objSqlCommand.Parameters["@CPNAMT"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@CPNAMT"].Value = cpnamt;

                objSqlCommand.Parameters.Add("@clientcatamt", SqlDbType.Decimal);
                if (clientcatamt == "" || clientcatamt == "0" || clientcatamt == "null")
                {
                    objSqlCommand.Parameters["@clientcatamt"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@clientcatamt"].Value = clientcatamt;
                }

                objSqlCommand.Parameters.Add("@flatfreqamt", SqlDbType.Decimal);
                if (flatfreqamt == "" || flatfreqamt == "0" || flatfreqamt == "null")
                {
                    objSqlCommand.Parameters["@flatfreqamt"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@flatfreqamt"].Value = flatfreqamt;
                }

                objSqlCommand.Parameters.Add("@catamt", SqlDbType.Decimal);
                if (catamt == "" || catamt == "0" || catamt == "null")
                {
                    objSqlCommand.Parameters["@catamt"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@catamt"].Value = catamt;
                }

                objSqlCommand.Parameters.Add("@premamtval", SqlDbType.Decimal);
                if (premamtval == "" || premamtval == "0" || premamtval == "null")
                {
                    objSqlCommand.Parameters["@premamtval"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@premamtval"].Value = premamtval;
                }

                objSqlCommand.Parameters.Add("@pgstamt", SqlDbType.Decimal);
                if (gstamount == "" || gstamount == "0" || gstamount == "null")
                {
                    objSqlCommand.Parameters["@pgstamt"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pgstamt"].Value = gstamount;
                }

                objSqlCommand.Parameters.Add("@pgstgd", SqlDbType.VarChar);
                if (gstgrid == "" || gstgrid == "0" || gstgrid == "null")
                {
                    objSqlCommand.Parameters["@pgstgd"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pgstgd"].Value = gstgrid;
                }

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
                CloseConnection(ref objSqlConnection);
            }
        }
        public DataSet insertbook_ins_display(string insertdate, string edition, string premium1, string premium2, string premallow, string adcategory, string latestdate, string material, string cardrate, string matfilename, string discrate, string insertstatus, string billstatus, string adsubcat, string compcode, string userid, string cioid, string height, string width, string totalsize, string pagepost, string premper1, string premper2, string colid, string repeat, string insertno, string paid, string agrrate, string solorate, string grossrate, string insert_pageno, string insert_remarks, string page_code, string page_per, string noofcol, string billamt, string billrate, string logo_h, string logo_w, string logo_name, string insert_id, string dateformat, string adcat3, string adcat4, string adcat5, string pkgcode, string gridins, string pkgalias, string cirvts, string cirpub, string ciredi, string cirrate, string cirdate, string ciragency, string ciragencysubcode, string center, string branch, string splboldsizevalue, string vatrate, string boxcharge, string vat_inc_p, string grossamtlocal_p, string billamtlocal_p, string sectioncode_p, string resourceno_p, string caption_inserts, string dealerheight, string dealerwidth, string subedidata, string disc_, string modifyrateaudit, string ip, string agncyamnt, string adlgncyamnt, string spldisc, string cashdisc, string roundoffamt, string pdfheight, string cpnamt, string clientcatamt, string flatfreqamt, string catamt, string premamtval, string gstamount, string gstgrid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("insertintobookchild_display", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@insertdate", SqlDbType.DateTime);
                if (insertdate == "" || insertdate == null || insertdate == "null")
                {
                    objSqlCommand.Parameters["@insertdate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = insertdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        insertdate = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = insertdate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        insertdate = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@insertdate"].Value = Convert.ToDateTime(insertdate);
                }

                objSqlCommand.Parameters.Add("@edition", SqlDbType.VarChar);
                objSqlCommand.Parameters["@edition"].Value = edition;

                objSqlCommand.Parameters.Add("@premium1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@premium1"].Value = premium1;

                objSqlCommand.Parameters.Add("@premium2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@premium2"].Value = premium2;

                objSqlCommand.Parameters.Add("@premallow", SqlDbType.VarChar);
                objSqlCommand.Parameters["@premallow"].Value = premallow;

                objSqlCommand.Parameters.Add("@adcategory", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adcategory"].Value = adcategory;

                objSqlCommand.Parameters.Add("@latestdate", SqlDbType.DateTime);
                if (latestdate == "" || latestdate == null || latestdate == "null")
                {
                    objSqlCommand.Parameters["@latestdate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = latestdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        latestdate = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = latestdate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        latestdate = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@latestdate"].Value = Convert.ToDateTime(latestdate);
                }
                //,,,,,,,,,,,,,

                objSqlCommand.Parameters.Add("@material", SqlDbType.VarChar);
                objSqlCommand.Parameters["@material"].Value = material;

                objSqlCommand.Parameters.Add("@cardrate", SqlDbType.Decimal);
                if (cardrate == "" || cardrate == null || cardrate == "null")
                {
                    objSqlCommand.Parameters["@cardrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@cardrate"].Value = Convert.ToDecimal(cardrate);
                }

                objSqlCommand.Parameters.Add("@matfilename", SqlDbType.VarChar);
                objSqlCommand.Parameters["@matfilename"].Value = matfilename;

                objSqlCommand.Parameters.Add("@discrate", SqlDbType.Decimal);
                if (discrate == "" || discrate == null || discrate == "null")
                {
                    objSqlCommand.Parameters["@discrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@discrate"].Value = Convert.ToDecimal(discrate);
                }

                objSqlCommand.Parameters.Add("@insertstatus", SqlDbType.VarChar);
                objSqlCommand.Parameters["@insertstatus"].Value = insertstatus;

                objSqlCommand.Parameters.Add("@billstatus", SqlDbType.VarChar);
                objSqlCommand.Parameters["@billstatus"].Value = billstatus;

                objSqlCommand.Parameters.Add("@adsubcat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adsubcat"].Value = adsubcat;





                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;


                objSqlCommand.Parameters.Add("@cioid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cioid"].Value = cioid;

                //

                objSqlCommand.Parameters.Add("@height", SqlDbType.Decimal);
                if (height == "" || height == null || height == "null")
                {
                    objSqlCommand.Parameters["@height"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@height"].Value = Convert.ToDecimal(height);
                }

                objSqlCommand.Parameters.Add("@width", SqlDbType.Decimal);
                if (width == "" || width == null || width == "null")
                {
                    objSqlCommand.Parameters["@width"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@width"].Value = Convert.ToDecimal(width);
                }

                objSqlCommand.Parameters.Add("@totalsize", SqlDbType.Decimal);
                if (totalsize == "" || totalsize == null || totalsize == "null")
                {
                    objSqlCommand.Parameters["@totalsize"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@totalsize"].Value = Convert.ToDecimal(totalsize);
                }

                objSqlCommand.Parameters.Add("@pagepost", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pagepost"].Value = pagepost;

                objSqlCommand.Parameters.Add("@premper1", SqlDbType.Decimal);
                if (premper1 == "" || premper1 == null || premper1 == "null")
                {
                    objSqlCommand.Parameters["@premper1"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@premper1"].Value = Convert.ToDecimal(premper1);
                }

                objSqlCommand.Parameters.Add("@premper2", SqlDbType.Decimal);
                if (premper2 == "" || premper2 == null || premper2 == "null")
                {
                    objSqlCommand.Parameters["@premper2"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@premper2"].Value = Convert.ToDecimal(premper2);
                }

                objSqlCommand.Parameters.Add("@colid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@colid"].Value = colid;

                objSqlCommand.Parameters.Add("@repeat", SqlDbType.DateTime);
                if (repeat == "" || repeat == null || repeat == "null")
                {
                    objSqlCommand.Parameters["@repeat"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = repeat.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        repeat = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = repeat.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        repeat = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@repeat"].Value = Convert.ToDateTime(repeat);
                }




                objSqlCommand.Parameters.Add("@insertno", SqlDbType.Int);
                if (insertno == "" || insertno == null || insertno == "null")
                {
                    objSqlCommand.Parameters["@insertno"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@insertno"].Value = Convert.ToInt32(insertno);
                }

                objSqlCommand.Parameters.Add("@paid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@paid"].Value = paid;

                objSqlCommand.Parameters.Add("@agrrate", SqlDbType.Decimal);
                if (agrrate == "" || agrrate == null || agrrate == "null")
                {
                    objSqlCommand.Parameters["@agrrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@agrrate"].Value = Convert.ToDecimal(agrrate);
                }

                objSqlCommand.Parameters.Add("@solorate", SqlDbType.Decimal);
                if (solorate == "" || solorate == null || solorate == "null")
                {
                    objSqlCommand.Parameters["@solorate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@solorate"].Value = Convert.ToDecimal(solorate);
                }

                objSqlCommand.Parameters.Add("@grossrate", SqlDbType.Decimal);
                if (grossrate == "" || grossrate == null || grossrate == "null")
                {
                    objSqlCommand.Parameters["@grossrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@grossrate"].Value = Convert.ToDecimal(grossrate);
                }

                objSqlCommand.Parameters.Add("@insert_remarks", SqlDbType.VarChar);
                objSqlCommand.Parameters["@insert_remarks"].Value = insert_remarks;

                objSqlCommand.Parameters.Add("@insert_pageno", SqlDbType.Int);
                if (insert_pageno == "" || insert_pageno == null || insert_pageno == "null")
                {
                    objSqlCommand.Parameters["@insert_pageno"].Value = Convert.ToInt32("0");
                }
                else
                {
                    objSqlCommand.Parameters["@insert_pageno"].Value = Convert.ToInt32(insert_pageno);
                }

                objSqlCommand.Parameters.Add("@page_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@page_code"].Value = page_code;

                objSqlCommand.Parameters.Add("@page_per", SqlDbType.Decimal);
                if (page_per == "" || page_per == null || page_per == "null")
                {
                    objSqlCommand.Parameters["@page_per"].Value = Convert.ToDecimal("0");
                }
                else
                {
                    objSqlCommand.Parameters["@page_per"].Value = Convert.ToDecimal(page_per);
                }

                objSqlCommand.Parameters.Add("@noofcol", SqlDbType.Decimal);
                if (noofcol == "" || noofcol == null || noofcol == "null")
                {
                    objSqlCommand.Parameters["@noofcol"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@noofcol"].Value = Convert.ToDecimal(noofcol);
                }

                objSqlCommand.Parameters.Add("@billamt", SqlDbType.Decimal);
                if (billamt == "" || billamt == null || billamt == "null")
                {
                    objSqlCommand.Parameters["@billamt"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@billamt"].Value = Convert.ToDecimal(billamt);
                }


                objSqlCommand.Parameters.Add("@billrate", SqlDbType.Decimal);
                if (billrate == "" || billrate == null || billrate == "null")
                {
                    objSqlCommand.Parameters["@billrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@billrate"].Value = Convert.ToDecimal(billrate);
                }

                objSqlCommand.Parameters.Add("@logo_h", SqlDbType.VarChar);
                objSqlCommand.Parameters["@logo_h"].Value = logo_h;

                objSqlCommand.Parameters.Add("@logo_w", SqlDbType.VarChar);
                objSqlCommand.Parameters["@logo_w"].Value = logo_w;

                objSqlCommand.Parameters.Add("@logo_name", SqlDbType.VarChar);
                objSqlCommand.Parameters["@logo_name"].Value = logo_name;

                objSqlCommand.Parameters.Add("@insertid", SqlDbType.Int);
                if (insert_id == "")
                    insert_id = "0";
                objSqlCommand.Parameters["@insertid"].Value = insert_id;

                objSqlCommand.Parameters.Add("@ad_cat_3", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ad_cat_3"].Value = adcat3;

                objSqlCommand.Parameters.Add("@ad_cat_4", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ad_cat_4"].Value = adcat4;

                objSqlCommand.Parameters.Add("@ad_cat_5", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ad_cat_5"].Value = adcat5;

                objSqlCommand.Parameters.Add("@pkgcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pkgcode"].Value = pkgcode;

                objSqlCommand.Parameters.Add("@gridins", SqlDbType.Int);
                objSqlCommand.Parameters["@gridins"].Value = gridins;

                objSqlCommand.Parameters.Add("@pkgalias", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pkgalias"].Value = pkgalias;

                objSqlCommand.Parameters.Add("@cirvts", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cirvts"].Value = cirvts;

                objSqlCommand.Parameters.Add("@cirpub", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cirpub"].Value = cirpub;

                objSqlCommand.Parameters.Add("@ciredi", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ciredi"].Value = ciredi;

                objSqlCommand.Parameters.Add("@cirrate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cirrate"].Value = cirrate;

                objSqlCommand.Parameters.Add("@cirdate", SqlDbType.VarChar);
                if (cirdate == "" || cirdate == null || cirdate == "null")
                {
                    objSqlCommand.Parameters["@cirdate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = cirdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        cirdate = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = cirdate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        cirdate = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@cirdate"].Value = Convert.ToDateTime(cirdate);
                }



                objSqlCommand.Parameters.Add("@ciragency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ciragency"].Value = ciragency;

                objSqlCommand.Parameters.Add("@ciragencysubcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ciragencysubcode"].Value = ciragencysubcode;

                objSqlCommand.Parameters.Add("@center", SqlDbType.VarChar);
                objSqlCommand.Parameters["@center"].Value = center;

                objSqlCommand.Parameters.Add("@branch", SqlDbType.VarChar);
                objSqlCommand.Parameters["@branch"].Value = branch;
                objSqlCommand.Parameters.Add("@splboldsizevalue", SqlDbType.VarChar);
                objSqlCommand.Parameters["@splboldsizevalue"].Value = splboldsizevalue;

                objSqlCommand.Parameters.Add("@vatrate_p", SqlDbType.Float);
                if (vatrate == "" || vatrate == "null" || vatrate == null)
                    objSqlCommand.Parameters["@vatrate_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@vatrate_p"].Value = Convert.ToDecimal(vatrate);
                objSqlCommand.Parameters.Add("@boxcharge_p", SqlDbType.Float);
                if (boxcharge == "" || boxcharge == "null" || boxcharge == null || boxcharge == "0")
                    objSqlCommand.Parameters["@boxcharge_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@boxcharge_p"].Value = Convert.ToDecimal(boxcharge);

                objSqlCommand.Parameters.Add("@vat_inc_p", SqlDbType.Float);
                if (vat_inc_p == "" || vat_inc_p == "null" || vat_inc_p == null)
                    objSqlCommand.Parameters["@vat_inc_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@vat_inc_p"].Value = vat_inc_p;

                objSqlCommand.Parameters.Add("@grossamtlocal_p", SqlDbType.Float);
                if (grossamtlocal_p == "" || grossamtlocal_p == "null" || grossamtlocal_p == null)
                    objSqlCommand.Parameters["@grossamtlocal_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@grossamtlocal_p"].Value = grossamtlocal_p;


                objSqlCommand.Parameters.Add("@billamtlocal_p", SqlDbType.Float);
                if (billamtlocal_p == "" || billamtlocal_p == "null" || billamtlocal_p == null)
                    objSqlCommand.Parameters["@billamtlocal_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@billamtlocal_p"].Value = billamtlocal_p;

                objSqlCommand.Parameters.Add("@sectioncode_p", SqlDbType.VarChar);
                if (sectioncode_p == "" || sectioncode_p == "null" || sectioncode_p == null)
                    objSqlCommand.Parameters["@sectioncode_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@sectioncode_p"].Value = sectioncode_p;

                objSqlCommand.Parameters.Add("@resourceno_p", SqlDbType.VarChar);
                if (resourceno_p == "" || resourceno_p == "null" || resourceno_p == null)
                    objSqlCommand.Parameters["@resourceno_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@resourceno_p"].Value = resourceno_p;

                objSqlCommand.Parameters.Add("@caption_inserts_p", SqlDbType.VarChar);
                if (caption_inserts == "" || caption_inserts == "null" || caption_inserts == null)
                    objSqlCommand.Parameters["@caption_inserts_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@caption_inserts_p"].Value = caption_inserts;



                objSqlCommand.Parameters.Add("@subedidata", SqlDbType.VarChar);
                objSqlCommand.Parameters["@subedidata"].Value = subedidata;

                objSqlCommand.Parameters.Add("@disc_p", SqlDbType.Float);
                if (disc_ == "" || disc_ == "null" || disc_ == null)
                    objSqlCommand.Parameters["@disc_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@disc_p"].Value = disc_;

                objSqlCommand.Parameters.Add("@P_ip", SqlDbType.VarChar);
                objSqlCommand.Parameters["@P_ip"].Value = ip;


                objSqlCommand.Parameters.Add("@P_RATE_AUDIT_FLAG", SqlDbType.VarChar);
                objSqlCommand.Parameters["@P_RATE_AUDIT_FLAG"].Value = modifyrateaudit;


                objSqlCommand.Parameters.Add("@dealerheight_p", SqlDbType.Decimal);
                if (dealerheight == "" || dealerheight == "null" || dealerheight == null || dealerheight == "default")
                    objSqlCommand.Parameters["@dealerheight_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@dealerheight_p"].Value = dealerheight;

                objSqlCommand.Parameters.Add("@dealerwidth_inserts_p", SqlDbType.Decimal);
                if (dealerwidth == "" || dealerwidth == "null" || dealerwidth == null || dealerwidth == "default")
                    objSqlCommand.Parameters["@dealerwidth_inserts_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@dealerwidth_inserts_p"].Value = dealerwidth;

                objSqlCommand.Parameters.Add("@agncyamnt", SqlDbType.VarChar);
                if (agncyamnt == "" || agncyamnt == "null" || agncyamnt == null)
                    objSqlCommand.Parameters["@agncyamnt"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@agncyamnt"].Value = agncyamnt;

                objSqlCommand.Parameters.Add("@adlgncyamnt", SqlDbType.VarChar);
                if (adlgncyamnt == "" || adlgncyamnt == "null" || adlgncyamnt == null)
                    objSqlCommand.Parameters["@adlgncyamnt"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@adlgncyamnt"].Value = adlgncyamnt;



                objSqlCommand.Parameters.Add("@spldiscamt", SqlDbType.VarChar);
                if (spldisc == "" || spldisc == "null" || spldisc == null)
                    objSqlCommand.Parameters["@spldiscamt"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@spldiscamt"].Value = spldisc;

                objSqlCommand.Parameters.Add("@cashdamnt", SqlDbType.VarChar);
                if (cashdisc == "" || cashdisc == "null" || cashdisc == null)
                    objSqlCommand.Parameters["@cashdamnt"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@cashdamnt"].Value = cashdisc;

                objSqlCommand.Parameters.Add("@ROUNDOFF", SqlDbType.VarChar);
                if (roundoffamt == "" || roundoffamt == "null" || roundoffamt == null)
                    objSqlCommand.Parameters["@ROUNDOFF"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@ROUNDOFF"].Value = roundoffamt;

                objSqlCommand.Parameters.Add("@PDFHEIGHT", SqlDbType.VarChar);
                if (pdfheight == "" || pdfheight == "null" || pdfheight == null)
                    objSqlCommand.Parameters["@PDFHEIGHT"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@PDFHEIGHT"].Value = pdfheight;

                objSqlCommand.Parameters.Add("@CPNAMT", SqlDbType.VarChar);
                if (cpnamt == "" || cpnamt == "null" || cpnamt == null)
                    objSqlCommand.Parameters["@CPNAMT"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@CPNAMT"].Value = cpnamt;

                objSqlCommand.Parameters.Add("@clientcatamt", SqlDbType.Decimal);
                if (clientcatamt == "" || clientcatamt == "0" || clientcatamt == "null")
                {
                    objSqlCommand.Parameters["@clientcatamt"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@clientcatamt"].Value = clientcatamt;
                }

                objSqlCommand.Parameters.Add("@flatfreqamt", SqlDbType.Decimal);
                if (flatfreqamt == "" || flatfreqamt == "0" || flatfreqamt == "null")
                {
                    objSqlCommand.Parameters["@flatfreqamt"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@flatfreqamt"].Value = flatfreqamt;
                }

                objSqlCommand.Parameters.Add("@catamt", SqlDbType.Decimal);
                if (catamt == "" || catamt == "0" || catamt == "null")
                {
                    objSqlCommand.Parameters["@catamt"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@catamt"].Value = catamt;
                }

                objSqlCommand.Parameters.Add("@premamtval", SqlDbType.Decimal);
                if (premamtval == "" || premamtval == "0" || premamtval == "null")
                {
                    objSqlCommand.Parameters["@premamtval"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@premamtval"].Value = premamtval;
                }
                objSqlCommand.Parameters.Add("@pgstamt", SqlDbType.Decimal);
                if (gstamount == "" || gstamount == "0" || gstamount == "null")
                {
                    objSqlCommand.Parameters["@pgstamt"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pgstamt"].Value = gstamount;
                }

                objSqlCommand.Parameters.Add("@pgstgd", SqlDbType.VarChar);
                if (gstgrid == "" || gstgrid == "0" || gstgrid == "null")
                {
                    objSqlCommand.Parameters["@pgstgd"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pgstgd"].Value = gstgrid;
                }

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
                CloseConnection(ref objSqlConnection);
            }
        }
        public DataSet alert1(string compcode, string agcode, string uom, string cat)
        {
            string zonename = "";
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("UOM_CAT_P", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("@comcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@comcode"].Value = compcode;
                objSqlCommand.Parameters.Add("@agency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agency"].Value = agcode;

                objSqlCommand.Parameters.Add("@category1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@category1"].Value = cat;

                objSqlCommand.Parameters.Add("@uom", SqlDbType.VarChar);
                objSqlCommand.Parameters["@uom"].Value = uom;

                objSqlDataAdapter = new SqlDataAdapter();
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
                CloseConnection(ref objSqlConnection);
            }

        }
        public DataSet bindbrand(string compcode, string brand, string extra1, string extra2, string extra3, string extra4, string extra5)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("BINDBRAND", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@COMPCODE1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@COMPCODE1"].Value = compcode;

                objSqlCommand.Parameters.Add("@BRAND", SqlDbType.VarChar);
                objSqlCommand.Parameters["@BRAND"].Value = brand;

                objSqlCommand.Parameters.Add("@EXTRA1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@EXTRA1"].Value = extra1;

                objSqlCommand.Parameters.Add("@EXTRA2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@EXTRA2"].Value = extra2;

                objSqlCommand.Parameters.Add("@EXTRA3", SqlDbType.VarChar);
                objSqlCommand.Parameters["@EXTRA3"].Value = extra3;

                objSqlCommand.Parameters.Add("@EXTRA4", SqlDbType.VarChar);
                objSqlCommand.Parameters["@EXTRA4"].Value = extra4;

                objSqlCommand.Parameters.Add("@EXTRA5", SqlDbType.VarChar);
                objSqlCommand.Parameters["@EXTRA5"].Value = extra5;

                objSqlDataAdapter = new SqlDataAdapter();
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
                CloseConnection(ref objSqlConnection);
            }
        }
        public DataSet bindbrandproduct(string compcode, string brand, string extra1, string extra2, string extra3, string extra4, string extra5)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("BINDBRANDPRODUCT", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@COMPCODE1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@COMPCODE1"].Value = compcode;

                objSqlCommand.Parameters.Add("@BRAND", SqlDbType.VarChar);
                objSqlCommand.Parameters["@BRAND"].Value = brand;

                objSqlCommand.Parameters.Add("@EXTRA1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@EXTRA1"].Value = extra1;

                objSqlCommand.Parameters.Add("@EXTRA2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@EXTRA2"].Value = extra2;

                objSqlCommand.Parameters.Add("@EXTRA3", SqlDbType.VarChar);
                objSqlCommand.Parameters["@EXTRA3"].Value = extra3;

                objSqlCommand.Parameters.Add("@EXTRA4", SqlDbType.VarChar);
                objSqlCommand.Parameters["@EXTRA4"].Value = extra4;

                objSqlCommand.Parameters.Add("@EXTRA5", SqlDbType.VarChar);
                objSqlCommand.Parameters["@EXTRA5"].Value = extra5;

                objSqlDataAdapter = new SqlDataAdapter();
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
                CloseConnection(ref objSqlConnection);
            }
        }
        public DataSet ratebindcenterwise(string adcat, string compcode, string branch, string bookingdate, string dateformat, string uom)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("bindratecodecenterwise_disp", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcompcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@padcat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@padcat"].Value = adcat;

                objSqlCommand.Parameters.Add("@pbranch", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pbranch"].Value = branch;

                objSqlCommand.Parameters.Add("@pextra1", SqlDbType.VarChar);
                if (bookingdate == "")
                {
                    objSqlCommand.Parameters["@pextra1"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = bookingdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        bookingdate = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = bookingdate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        bookingdate = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@pextra1"].Value = bookingdate;
                }

                //objSqlCommand.Parameters.Add("@pextra1", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@pextra1"].Value = System.DBNull.Value;


                objSqlCommand.Parameters.Add("@pextra2", SqlDbType.VarChar);
                if (uom == "0")
                    objSqlCommand.Parameters["@pextra2"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@pextra2"].Value = uom;


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
                CloseConnection(ref objSqlConnection);
            }
        }
        public DataSet branchbind(string compcode, string useid, string centercd, string extra1, string extra2, string extra3, string extra4, string extra5)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("bind_branchwithemail", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@p_comp_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_comp_code"].Value = compcode;


                objSqlCommand.Parameters.Add("@p_userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_userid"].Value = useid;

                objSqlCommand.Parameters.Add("@p_centercd", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_centercd"].Value = centercd;

                objSqlCommand.Parameters.Add("@p_extra1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_extra1"].Value = extra1;

                objSqlCommand.Parameters.Add("@p_extra2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_extra2"].Value = extra2;

                objSqlCommand.Parameters.Add("@p_extra3", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_extra3"].Value = extra3;

                objSqlCommand.Parameters.Add("@p_extra4", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_extra4"].Value = extra4;

                objSqlCommand.Parameters.Add("@p_extra5", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_extra5"].Value = extra5;


                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);

                return objDataSet;


            }
            catch (SqlException objException)
            {
                throw (objException);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }

        }
        public DataSet mailsave(string cioid, string compcode, string mailcenter, string mailbranch, string mailid, string userid, string extra1, string extra2, string extra3, string extra4, string extra5)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("savebookingmaildetails", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@pcioid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcioid"].Value = cioid;

                objSqlCommand.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcompcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@pmailcenter", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pmailcenter"].Value = mailcenter;

                objSqlCommand.Parameters.Add("@pmailbranch", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pmailbranch"].Value = mailbranch;

                objSqlCommand.Parameters.Add("@pmailid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pmailid"].Value = mailid;

                objSqlCommand.Parameters.Add("@puserid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@puserid"].Value = userid;

                objSqlCommand.Parameters.Add("@pextra1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra1"].Value = extra1;

                objSqlCommand.Parameters.Add("@pextra2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra2"].Value = extra2;

                objSqlCommand.Parameters.Add("@pextra3", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra3"].Value = extra3;

                objSqlCommand.Parameters.Add("@pextra4", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra4"].Value = extra4;

                objSqlCommand.Parameters.Add("@pextra5", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra5"].Value = extra5;

                objSqlDataAdapter = new SqlDataAdapter();
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
                CloseConnection(ref objSqlConnection);
            }
        }
        public DataSet getretaineragechek(string retainercode, string compcode, string agencycodesubcode)
        {
            string zonename = "";
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_retaineragencycheck", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("@retainercode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@retainercode"].Value = retainercode;
                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@pagency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pagency"].Value = agencycodesubcode;
                objSqlDataAdapter = new SqlDataAdapter();
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
                CloseConnection(ref objSqlConnection);
            }

        }
        public DataSet insertbooking(string adsizetype, string branch, string booked_by, string prevbook, string date_time, string ciobookid, string approvedby, string audit, string rono, string rodate, string caption, string billstatus, string rostatus, string agency, string client, string agencyaddress, string clientaddresses, string agencycode, string dockitno, string execname, string execzone, string product, string brand, string keyno, string billremark, string printremark, string package, string insertion, string startdate, string repeatdate, string adtype, string adcategory, string subcategory, string color, string uom, string pageposition, string pagetype, string pageno, string adsizheight, string adsizwidth, string ratecode, string scheme, string currency, string agreedrate, string agreedamt, string spedisc, string spacedisx, string compcode, string userid, string specialcharges, string agencytype, string agencystatus, string paymode, string agencredit, string cardrate, string cardamount, string discount, string discountper, string billaddress, string totarea, string billcycle, string revenuecenter, string billpay, string billheight, string billwidth, string billto, string invoices, string vts, string tradedisc, string agencyout, string boxcode, string boxno, string boxaddress, string boxagency, string boxclient, string bookingtype, string tfn, string coupan, string campaign, string bill_amt, string pageprem, string pageamt, string premper, string grossamt, string adsizcolumn, string billcolumn, Decimal billarea, string specdiscper, string spacediscper, string paidins, string dealrate, string deviation, string varient, string contractname, string dealtype, string cardname, string cardtype, string cardmonth, string cardyear, string cardno, string receiptno, string adscat3, string adscat4, string adscat5, string bgcolor, string bulletcode, string bulletprm, string material, string receiptdate, string prevcioid, string prevreceipt, Decimal prev_ga, string region, string varient_name, string coltype, string logo_h, string logo_w, string logo_col, string logo_uom, string dateformat, string retainer, string addagencyrate, string mobileno, string addlamt, string retamt, string retper, string cashrecieved, string ciragency, string cirrate, string ciredition, string cirpublication, string ciragencysubcode, string bartertype, string attach1, string attach2, string cashdiscount, string cashdiscountper, string drpdiscprem, string doctype, string chktradeval, string sharepub, string fmginsert, string chkno, string chkdate, string chkamt, string chkbankname, string ourbank, string dealerpanel, string dealerh, string dealerw, string dealertype, string multiselect, string agreedrate_active, string agreedamt_active, string grossamtlocal_p, string billamtlocal_p, string chkadon, string refid, string rcpt_currency, string cur_convrate, string revisedate, string clienttype, string translation, string translationcharge, string fmgreasons, string canclecharge, string transdisc, string pospremdisc, string billhold, string designbox, string logoprem, string online_ad, string style, string fixed_booking, string vat_code, string cou_code, string cou_name, string state, string clientcatdisc, string clientcatamt, string clientcatdistype, string flatfreqdisc, string flatfreqamt, string flatfreqdisctype, string catdisc, string catamt, string catdisctype, string representative, string teamcode, string industry, string productcat, string chkgstinc, string publ_rev_cent, string contractperson, string emailid, string quotationno)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {

                objSqlConnection.Open();
                objSqlCommand = GetCommand("insertintobooking", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@date_time", SqlDbType.DateTime);
                if (date_time == "" || date_time == null)
                {
                    objSqlCommand.Parameters["@date_time"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = date_time.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        date_time = mm + "/" + dd + "/" + yy;


                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = date_time.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        date_time = mm + "/" + dd + "/" + yy;


                    }
                    objSqlCommand.Parameters["@date_time"].Value = date_time;
                }

                objSqlCommand.Parameters.Add("@adsizetype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adsizetype"].Value = adsizetype;

                objSqlCommand.Parameters.Add("@branch", SqlDbType.VarChar);
                objSqlCommand.Parameters["@branch"].Value = branch;

                objSqlCommand.Parameters.Add("@booked_by", SqlDbType.VarChar);
                objSqlCommand.Parameters["@booked_by"].Value = booked_by;

                objSqlCommand.Parameters.Add("@prevbook", SqlDbType.VarChar);
                objSqlCommand.Parameters["@prevbook"].Value = prevbook;

                objSqlCommand.Parameters.Add("@approvedby", SqlDbType.VarChar);
                objSqlCommand.Parameters["@approvedby"].Value = approvedby;

                objSqlCommand.Parameters.Add("@ciobookid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ciobookid"].Value = ciobookid;

                objSqlCommand.Parameters.Add("@audit", SqlDbType.VarChar);
                objSqlCommand.Parameters["@audit"].Value = audit;

                objSqlCommand.Parameters.Add("@rono", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rono"].Value = rono;

                objSqlCommand.Parameters.Add("@rodate", SqlDbType.DateTime);
                if (rodate == "" || rodate == null)
                {
                    objSqlCommand.Parameters["@rodate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = rodate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        rodate = mm + "/" + dd + "/" + yy;


                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = rodate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        rodate = mm + "/" + dd + "/" + yy;


                    }
                    objSqlCommand.Parameters["@rodate"].Value = rodate;
                }

                objSqlCommand.Parameters.Add("@caption", SqlDbType.VarChar);
                objSqlCommand.Parameters["@caption"].Value = caption;

                objSqlCommand.Parameters.Add("@billstatus", SqlDbType.VarChar);
                objSqlCommand.Parameters["@billstatus"].Value = billstatus;

                objSqlCommand.Parameters.Add("@rostatus", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rostatus"].Value = rostatus;

                objSqlCommand.Parameters.Add("@agency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agency"].Value = agency;

                objSqlCommand.Parameters.Add("@client", SqlDbType.VarChar);
                objSqlCommand.Parameters["@client"].Value = client;

                objSqlCommand.Parameters.Add("@agencyaddress", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencyaddress"].Value = agencyaddress;

                objSqlCommand.Parameters.Add("@clientaddresses", SqlDbType.VarChar);
                objSqlCommand.Parameters["@clientaddresses"].Value = clientaddresses;

                objSqlCommand.Parameters.Add("@agencycode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencycode"].Value = agencycode;

                objSqlCommand.Parameters.Add("@dockitno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dockitno"].Value = dockitno;

                objSqlCommand.Parameters.Add("@execname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@execname"].Value = execname;

                objSqlCommand.Parameters.Add("@execzone", SqlDbType.VarChar);
                objSqlCommand.Parameters["@execzone"].Value = execzone;

                objSqlCommand.Parameters.Add("@product", SqlDbType.VarChar);
                objSqlCommand.Parameters["@product"].Value = product;

                objSqlCommand.Parameters.Add("@brand", SqlDbType.VarChar);
                objSqlCommand.Parameters["@brand"].Value = brand;

                objSqlCommand.Parameters.Add("@keyno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@keyno"].Value = keyno;

                objSqlCommand.Parameters.Add("@billremark", SqlDbType.VarChar);
                objSqlCommand.Parameters["@billremark"].Value = billremark;

                objSqlCommand.Parameters.Add("@printremark", SqlDbType.VarChar);
                objSqlCommand.Parameters["@printremark"].Value = printremark;

                objSqlCommand.Parameters.Add("@package", SqlDbType.VarChar);
                objSqlCommand.Parameters["@package"].Value = package;

                objSqlCommand.Parameters.Add("@insertion", SqlDbType.Int);
                if (insertion == "" || insertion == null)
                {
                    objSqlCommand.Parameters["@insertion"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@insertion"].Value = Convert.ToInt32(insertion);
                }

                objSqlCommand.Parameters.Add("@startdate", SqlDbType.DateTime);
                if (startdate == "" || startdate == null)
                {
                    objSqlCommand.Parameters["@startdate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = startdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        startdate = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = startdate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        startdate = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@startdate"].Value = startdate;
                }

                objSqlCommand.Parameters.Add("@repeatdate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@repeatdate"].Value = repeatdate;

                objSqlCommand.Parameters.Add("@adtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adtype"].Value = adtype;

                objSqlCommand.Parameters.Add("@adcategory", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adcategory"].Value = adcategory;

                objSqlCommand.Parameters.Add("@subcategory", SqlDbType.VarChar);
                objSqlCommand.Parameters["@subcategory"].Value = subcategory;

                objSqlCommand.Parameters.Add("@color", SqlDbType.VarChar);
                objSqlCommand.Parameters["@color"].Value = color;

                objSqlCommand.Parameters.Add("@uom", SqlDbType.VarChar);
                objSqlCommand.Parameters["@uom"].Value = uom;

                objSqlCommand.Parameters.Add("@pageposition", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pageposition"].Value = pageposition;

                objSqlCommand.Parameters.Add("@pagetype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pagetype"].Value = pagetype;

                objSqlCommand.Parameters.Add("@pageno", SqlDbType.Int);
                if (pageno == "" || pageno == null)
                {
                    objSqlCommand.Parameters["@pageno"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pageno"].Value = Convert.ToInt32(pageno);
                }

                objSqlCommand.Parameters.Add("@adsizheight", SqlDbType.Decimal);
                if (adsizheight == "" || adsizheight == null)
                {
                    objSqlCommand.Parameters["@adsizheight"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@adsizheight"].Value = Convert.ToDecimal(adsizheight);
                }

                objSqlCommand.Parameters.Add("@adsizwidth", SqlDbType.Decimal);
                if (adsizwidth == "" || adsizwidth == null)
                {
                    objSqlCommand.Parameters["@adsizwidth"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@adsizwidth"].Value = Convert.ToDecimal(adsizwidth);
                }

                objSqlCommand.Parameters.Add("@ratecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ratecode"].Value = ratecode;

                objSqlCommand.Parameters.Add("@scheme", SqlDbType.VarChar);
                objSqlCommand.Parameters["@scheme"].Value = scheme;

                objSqlCommand.Parameters.Add("@currency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@currency"].Value = currency;

                objSqlCommand.Parameters.Add("@agreedrate", SqlDbType.Decimal);
                if (agreedrate == "" || agreedrate == null)
                {
                    objSqlCommand.Parameters["@agreedrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@agreedrate"].Value = Convert.ToDecimal(agreedrate);
                }
                //    , , ,Session["compcode"].ToString(),Session["userid"].ToString()
                objSqlCommand.Parameters.Add("@agreedamt", SqlDbType.Decimal);
                if (agreedamt == "" || agreedamt == null)
                {
                    objSqlCommand.Parameters["@agreedamt"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@agreedamt"].Value = Convert.ToDecimal(agreedamt);
                }

                objSqlCommand.Parameters.Add("@spedisc", SqlDbType.Decimal);
                if (spedisc == "" || spedisc == null)
                {
                    objSqlCommand.Parameters["@spedisc"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@spedisc"].Value = Convert.ToDecimal(spedisc);
                }

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@spacedisx", SqlDbType.Decimal);
                if (spacedisx == "" || spacedisx == null)
                {
                    objSqlCommand.Parameters["@spacedisx"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@spacedisx"].Value = Convert.ToDecimal(spacedisx);
                }

                objSqlCommand.Parameters.Add("@specialcharges", SqlDbType.Decimal);
                if (specialcharges == "" || specialcharges == null)
                {
                    objSqlCommand.Parameters["@specialcharges"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@specialcharges"].Value = Convert.ToDecimal(specialcharges);
                }

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@agencytype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencytype"].Value = agencytype;

                objSqlCommand.Parameters.Add("@agencystatus", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencystatus"].Value = agencystatus;

                objSqlCommand.Parameters.Add("@paymode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@paymode"].Value = paymode;

                objSqlCommand.Parameters.Add("@agencredit", SqlDbType.Int);
                if (agencredit == "" || agencredit == null)
                {
                    objSqlCommand.Parameters["@agencredit"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@agencredit"].Value = Convert.ToInt32(agencredit);
                }

                objSqlCommand.Parameters.Add("@cardrate", SqlDbType.Decimal);
                if (cardrate == "" || cardrate == null)
                {
                    objSqlCommand.Parameters["@cardrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@cardrate"].Value = Convert.ToDecimal(cardrate);
                }

                objSqlCommand.Parameters.Add("@cardamount", SqlDbType.Decimal);
                if (cardamount == "" || cardamount == null)
                {
                    objSqlCommand.Parameters["@cardamount"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@cardamount"].Value = Convert.ToDecimal(cardamount);
                }

                objSqlCommand.Parameters.Add("@discount", SqlDbType.Decimal);
                if (discount == "" || discount == null)
                {
                    objSqlCommand.Parameters["@discount"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@discount"].Value = Convert.ToDecimal(discount);
                }


                objSqlCommand.Parameters.Add("@discountper", SqlDbType.Decimal);
                if (discountper == "" || discountper == null)
                {
                    objSqlCommand.Parameters["@discountper"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@discountper"].Value = Convert.ToDecimal(discountper);
                }

                objSqlCommand.Parameters.Add("@billaddress", SqlDbType.VarChar);
                objSqlCommand.Parameters["@billaddress"].Value = billaddress;

                objSqlCommand.Parameters.Add("@totarea", SqlDbType.Decimal);
                if (totarea == "" || totarea == null)
                {
                    objSqlCommand.Parameters["@totarea"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@totarea"].Value = Convert.ToDecimal(totarea);
                }


                objSqlCommand.Parameters.Add("@billcycle", SqlDbType.VarChar);
                objSqlCommand.Parameters["@billcycle"].Value = billcycle;

                objSqlCommand.Parameters.Add("@revenuecenter", SqlDbType.VarChar);
                objSqlCommand.Parameters["@revenuecenter"].Value = revenuecenter;

                objSqlCommand.Parameters.Add("@billpay", SqlDbType.VarChar);
                objSqlCommand.Parameters["@billpay"].Value = billpay;

                objSqlCommand.Parameters.Add("@billheight", SqlDbType.Decimal);
                if (billheight == "" || billheight == null)
                {
                    objSqlCommand.Parameters["@billheight"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@billheight"].Value = Convert.ToDecimal(billheight);
                }

                objSqlCommand.Parameters.Add("@billwidth", SqlDbType.Decimal);
                if (billwidth == "" || billwidth == null)
                {
                    objSqlCommand.Parameters["@billwidth"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@billwidth"].Value = Convert.ToDecimal(billwidth);
                }

                //////, , , , , , , , , , , , , , , , , , , 

                objSqlCommand.Parameters.Add("@billto", SqlDbType.VarChar);
                objSqlCommand.Parameters["@billto"].Value = billto;

                objSqlCommand.Parameters.Add("@invoices", SqlDbType.Int);
                if (invoices == "" || invoices == null)
                {
                    objSqlCommand.Parameters["@invoices"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@invoices"].Value = Convert.ToInt32(invoices);
                }

                objSqlCommand.Parameters.Add("@vts", SqlDbType.Int);
                if (vts == "" || vts == null)
                {
                    objSqlCommand.Parameters["@vts"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@vts"].Value = Convert.ToInt32(vts);
                }

                objSqlCommand.Parameters.Add("@tradedisc", SqlDbType.Decimal);
                if (tradedisc == "" || tradedisc == null)
                {
                    objSqlCommand.Parameters["@tradedisc"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@tradedisc"].Value = Convert.ToDecimal(tradedisc);
                }

                objSqlCommand.Parameters.Add("@agencyout", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencyout"].Value = agencyout;

                objSqlCommand.Parameters.Add("@boxcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@boxcode"].Value = boxcode;

                objSqlCommand.Parameters.Add("@boxno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@boxno"].Value = boxno;

                objSqlCommand.Parameters.Add("@boxaddress", SqlDbType.VarChar);
                objSqlCommand.Parameters["@boxaddress"].Value = boxaddress;

                objSqlCommand.Parameters.Add("@boxagency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@boxagency"].Value = boxagency;

                objSqlCommand.Parameters.Add("@boxclient", SqlDbType.VarChar);
                objSqlCommand.Parameters["@boxclient"].Value = boxclient;

                objSqlCommand.Parameters.Add("@bookingtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@bookingtype"].Value = bookingtype;

                objSqlCommand.Parameters.Add("@tfn", SqlDbType.VarChar);
                objSqlCommand.Parameters["@tfn"].Value = tfn;

                objSqlCommand.Parameters.Add("@coupan", SqlDbType.VarChar);
                objSqlCommand.Parameters["@coupan"].Value = coupan;

                objSqlCommand.Parameters.Add("@campaign", SqlDbType.VarChar);
                objSqlCommand.Parameters["@campaign"].Value = campaign;


                objSqlCommand.Parameters.Add("@bill_amt", SqlDbType.Decimal);
                if (bill_amt == "" || bill_amt == null)
                {
                    objSqlCommand.Parameters["@bill_amt"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@bill_amt"].Value = Convert.ToDecimal(bill_amt);
                }

                objSqlCommand.Parameters.Add("@pageprem", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pageprem"].Value = pageprem;


                objSqlCommand.Parameters.Add("@pageamt", SqlDbType.Decimal);
                if (pageamt == "" || pageamt == null)
                {
                    objSqlCommand.Parameters["@pageamt"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pageamt"].Value = Convert.ToDecimal(pageamt);
                }

                objSqlCommand.Parameters.Add("@premper", SqlDbType.Decimal);
                if (premper == "" || premper == null)
                {
                    objSqlCommand.Parameters["@premper"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@premper"].Value = Convert.ToDecimal(premper);
                }

                objSqlCommand.Parameters.Add("@grossamt", SqlDbType.Decimal);
                if (grossamt == "" || grossamt == null)
                {
                    objSqlCommand.Parameters["@grossamt"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@grossamt"].Value = Convert.ToDecimal(grossamt);
                }

                objSqlCommand.Parameters.Add("@adsizcolumn", SqlDbType.Decimal);
                if (adsizcolumn == "" || adsizcolumn == null)
                {
                    objSqlCommand.Parameters["@adsizcolumn"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@adsizcolumn"].Value = Convert.ToDecimal(adsizcolumn);
                }

                objSqlCommand.Parameters.Add("@billcolumn", SqlDbType.Decimal);
                if (billcolumn == "" || billcolumn == null)
                {
                    objSqlCommand.Parameters["@billcolumn"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@billcolumn"].Value = Convert.ToDecimal(billcolumn);
                }

                objSqlCommand.Parameters.Add("@billarea", SqlDbType.Decimal);

                objSqlCommand.Parameters["@billarea"].Value = Convert.ToDecimal(billarea);

                objSqlCommand.Parameters.Add("@specdiscper", SqlDbType.Decimal);
                if (specdiscper == "" || specdiscper == null)
                {
                    objSqlCommand.Parameters["@specdiscper"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@specdiscper"].Value = Convert.ToDecimal(specdiscper);
                }

                objSqlCommand.Parameters.Add("@spacediscper", SqlDbType.Decimal);
                if (spacediscper == "" || spacediscper == null)
                {
                    objSqlCommand.Parameters["@spacediscper"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@spacediscper"].Value = Convert.ToDecimal(spacediscper);
                }

                objSqlCommand.Parameters.Add("@paidins", SqlDbType.Int);
                if (paidins == "" || paidins == null)
                {
                    objSqlCommand.Parameters["@paidins"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@paidins"].Value = Convert.ToInt32(paidins);
                }

                objSqlCommand.Parameters.Add("@dealrate", SqlDbType.Decimal);
                if (dealrate == "" || dealrate == null)
                {
                    objSqlCommand.Parameters["@dealrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@dealrate"].Value = Convert.ToDecimal(dealrate);
                }

                objSqlCommand.Parameters.Add("@deviation", SqlDbType.Decimal);
                if (deviation == "" || deviation == null)
                {
                    objSqlCommand.Parameters["@deviation"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@deviation"].Value = Convert.ToDecimal(deviation);
                }

                objSqlCommand.Parameters.Add("@varient", SqlDbType.VarChar);
                objSqlCommand.Parameters["@varient"].Value = varient;

                objSqlCommand.Parameters.Add("@contractname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@contractname"].Value = contractname;

                objSqlCommand.Parameters.Add("@dealtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dealtype"].Value = dealtype;


                ////////////////
                objSqlCommand.Parameters.Add("@cardname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cardname"].Value = cardname;

                objSqlCommand.Parameters.Add("@cardtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cardtype"].Value = cardtype;

                objSqlCommand.Parameters.Add("@cardmonth", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cardmonth"].Value = cardmonth;

                objSqlCommand.Parameters.Add("@cardyear", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cardyear"].Value = cardyear;

                objSqlCommand.Parameters.Add("@cardno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cardno"].Value = cardno;

                objSqlCommand.Parameters.Add("@receiptno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@receiptno"].Value = receiptno;

                objSqlCommand.Parameters.Add("@adscat3", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adscat3"].Value = adscat3;

                objSqlCommand.Parameters.Add("@adscat4", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adscat4"].Value = adscat4;

                objSqlCommand.Parameters.Add("@adscat5", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adscat5"].Value = adscat5;

                objSqlCommand.Parameters.Add("@bgcolor", SqlDbType.VarChar);
                objSqlCommand.Parameters["@bgcolor"].Value = bgcolor;

                objSqlCommand.Parameters.Add("@bulletcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@bulletcode"].Value = bulletcode;

                objSqlCommand.Parameters.Add("@bulletprm", SqlDbType.Decimal);
                if (bulletprm == "" || bulletprm == null)
                {
                    objSqlCommand.Parameters["@bulletprm"].Value = System.DBNull.Value;
                }
                else
                {
                    bulletprm = bulletprm.Replace("%", "");
                    objSqlCommand.Parameters["@bulletprm"].Value = Convert.ToDecimal(bulletprm);
                }

                objSqlCommand.Parameters.Add("@material", SqlDbType.VarChar);
                objSqlCommand.Parameters["@material"].Value = material;


                objSqlCommand.Parameters.Add("@receiptdate", SqlDbType.DateTime);
                if (receiptdate == "" || receiptdate == null)
                {
                    objSqlCommand.Parameters["@receiptdate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = receiptdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        receiptdate = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = receiptdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        receiptdate = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@receiptdate"].Value = receiptdate;
                }


                objSqlCommand.Parameters.Add("@prevcioid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@prevcioid"].Value = prevcioid;

                objSqlCommand.Parameters.Add("@prevreceipt", SqlDbType.VarChar);
                objSqlCommand.Parameters["@prevreceipt"].Value = prevreceipt;

                objSqlCommand.Parameters.Add("@prev_ga", SqlDbType.Decimal);

                objSqlCommand.Parameters["@prev_ga"].Value = prev_ga;


                objSqlCommand.Parameters.Add("@region", SqlDbType.VarChar);
                objSqlCommand.Parameters["@region"].Value = region;

                objSqlCommand.Parameters.Add("@varient_name", SqlDbType.VarChar);
                objSqlCommand.Parameters["@varient_name"].Value = varient_name;

                ////changes
                objSqlCommand.Parameters.Add("@coltype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@coltype"].Value = coltype;

                objSqlCommand.Parameters.Add("@logo_h", SqlDbType.VarChar);
                objSqlCommand.Parameters["@logo_h"].Value = logo_h;

                objSqlCommand.Parameters.Add("@logo_w", SqlDbType.VarChar);
                objSqlCommand.Parameters["@logo_w"].Value = logo_w;

                objSqlCommand.Parameters.Add("@logo_col", SqlDbType.VarChar);
                objSqlCommand.Parameters["@logo_col"].Value = logo_col;

                objSqlCommand.Parameters.Add("@logo_uom", SqlDbType.VarChar);
                objSqlCommand.Parameters["@logo_uom"].Value = logo_uom;


                objSqlCommand.Parameters.Add("@retainer1", SqlDbType.VarChar);
                if (retainer.IndexOf("(") >= 0)
                {
                    retainer = retainer.Substring(retainer.LastIndexOf("(") + 1, retainer.Length - retainer.LastIndexOf("(") - 2);
                }
                if (retainer == "0")
                    retainer = "";
                objSqlCommand.Parameters["@retainer1"].Value = retainer;

                objSqlCommand.Parameters.Add("@addagencyrate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@addagencyrate"].Value = addagencyrate;

                objSqlCommand.Parameters.Add("@mobileno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@mobileno"].Value = mobileno;

                objSqlCommand.Parameters.Add("@addlamt", SqlDbType.VarChar);
                objSqlCommand.Parameters["@addlamt"].Value = addlamt;

                objSqlCommand.Parameters.Add("@retamt", SqlDbType.VarChar);
                objSqlCommand.Parameters["@retamt"].Value = retamt;

                objSqlCommand.Parameters.Add("@retper", SqlDbType.VarChar);
                objSqlCommand.Parameters["@retper"].Value = retper;


                objSqlCommand.Parameters.Add("@cashrecieved", SqlDbType.VarChar);
                if (cashrecieved == "" || cashrecieved == null)
                {
                    objSqlCommand.Parameters["@cashrecieved"].Value = System.DBNull.Value;
                }
                else
                {

                    objSqlCommand.Parameters["@cashrecieved"].Value = Convert.ToDecimal(cashrecieved);
                }

                objSqlCommand.Parameters.Add("@CIRAGENCY", SqlDbType.VarChar);
                objSqlCommand.Parameters["@CIRAGENCY"].Value = ciragency;

                objSqlCommand.Parameters.Add("@CIRRATE", SqlDbType.VarChar);
                objSqlCommand.Parameters["@CIRRATE"].Value = cirrate;

                objSqlCommand.Parameters.Add("@CIREDITION", SqlDbType.VarChar);
                objSqlCommand.Parameters["@CIREDITION"].Value = ciredition;

                objSqlCommand.Parameters.Add("@CIRPUBLICATION", SqlDbType.VarChar);
                objSqlCommand.Parameters["@CIRPUBLICATION"].Value = cirpublication;


                objSqlCommand.Parameters.Add("@CIRAGENCYSUBCODE", SqlDbType.VarChar);
                objSqlCommand.Parameters["@CIRAGENCYSUBCODE"].Value = ciragencysubcode;

                objSqlCommand.Parameters.Add("@BARTERTYPE", SqlDbType.VarChar);
                objSqlCommand.Parameters["@BARTERTYPE"].Value = bartertype;

                objSqlCommand.Parameters.Add("@CASHDISCOUNT_V", SqlDbType.VarChar);
                if (cashdiscount == "" || cashdiscount == "null" || cashdiscount == null)
                    objSqlCommand.Parameters["@CASHDISCOUNT_V"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@CASHDISCOUNT_V"].Value = cashdiscount;

                objSqlCommand.Parameters.Add("@CASHDISCOUNTPER_V", SqlDbType.VarChar);
                objSqlCommand.Parameters["@CASHDISCOUNTPER_V"].Value = cashdiscountper;

                objSqlCommand.Parameters.Add("@attach1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@attach1"].Value = attach1;

                objSqlCommand.Parameters.Add("@attach2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@attach2"].Value = attach2;

                objSqlCommand.Parameters.Add("@drpdiscprem", SqlDbType.VarChar);
                objSqlCommand.Parameters["@drpdiscprem"].Value = drpdiscprem;
                objSqlCommand.Parameters.Add("@doctype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@doctype"].Value = doctype;

                objSqlCommand.Parameters.Add("@CHKTRADE", SqlDbType.VarChar);
                objSqlCommand.Parameters["@CHKTRADE"].Value = chktradeval;

                objSqlCommand.Parameters.Add("@sharepub_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@sharepub_p"].Value = sharepub;
                objSqlCommand.Parameters.Add("@fmginsert", SqlDbType.VarChar);
                objSqlCommand.Parameters["@fmginsert"].Value = fmginsert;

                objSqlCommand.Parameters.Add("@chkno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@chkno"].Value = chkno;

                objSqlCommand.Parameters.Add("@chkdate", SqlDbType.DateTime);
                if (chkdate == "" || chkdate == null)
                {
                    objSqlCommand.Parameters["@chkdate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = chkdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        chkdate = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = chkdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        chkdate = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@chkdate"].Value = chkdate;
                }


                objSqlCommand.Parameters.Add("@chkamt", SqlDbType.VarChar);
                objSqlCommand.Parameters["@chkamt"].Value = chkamt;

                objSqlCommand.Parameters.Add("@chkbankname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@chkbankname"].Value = chkbankname;
                objSqlCommand.Parameters.Add("@ourbank", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ourbank"].Value = ourbank;
                objSqlCommand.Parameters.Add("@DEALERPANEL_P", SqlDbType.VarChar);
                if (dealerpanel == "")
                    objSqlCommand.Parameters["@DEALERPANEL_P"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@DEALERPANEL_P"].Value = dealerpanel;

                objSqlCommand.Parameters.Add("@DEALERH_P", SqlDbType.VarChar);
                if (dealerh == "")
                    objSqlCommand.Parameters["@DEALERH_P"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@DEALERH_P"].Value = dealerh;

                objSqlCommand.Parameters.Add("@DEALERW_P", SqlDbType.VarChar);
                if (dealerw == "")
                    objSqlCommand.Parameters["@DEALERW_P"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@DEALERW_P"].Value = dealerw;

                objSqlCommand.Parameters.Add("@DEALERTYPE_P", SqlDbType.VarChar);
                if (dealertype == "")
                    objSqlCommand.Parameters["@DEALERTYPE_P"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@DEALERTYPE_P"].Value = dealertype;

                objSqlCommand.Parameters.Add("@multiselect", SqlDbType.VarChar);
                objSqlCommand.Parameters["@multiselect"].Value = multiselect;

                objSqlCommand.Parameters.Add("@AGREEDRATE_ACTIVE", SqlDbType.VarChar);
                if (agreedrate_active == "")
                    objSqlCommand.Parameters["@AGREEDRATE_ACTIVE"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@AGREEDRATE_ACTIVE"].Value = agreedrate_active;

                objSqlCommand.Parameters.Add("@AGREEDAMT_ACTIVE", SqlDbType.VarChar);
                if (agreedamt_active == "")
                    objSqlCommand.Parameters["@AGREEDAMT_ACTIVE"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@AGREEDAMT_ACTIVE"].Value = agreedamt_active;


                objSqlCommand.Parameters.Add("@grossamtlocal_p", SqlDbType.Float);
                if (grossamtlocal_p == "" || grossamtlocal_p == "null" || grossamtlocal_p == null)
                    objSqlCommand.Parameters["@grossamtlocal_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@grossamtlocal_p"].Value = grossamtlocal_p;


                objSqlCommand.Parameters.Add("@billamtlocal_p", SqlDbType.Float);
                if (billamtlocal_p == "" || billamtlocal_p == "null" || billamtlocal_p == null)
                    objSqlCommand.Parameters["@billamtlocal_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@billamtlocal_p"].Value = billamtlocal_p;

                objSqlCommand.Parameters.Add("@chkadon_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@chkadon_p"].Value = chkadon;

                objSqlCommand.Parameters.Add("@refid_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@refid_p"].Value = refid;

                objSqlCommand.Parameters.Add("@rcpt_currency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rcpt_currency"].Value = rcpt_currency;

                objSqlCommand.Parameters.Add("@cur_convrate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cur_convrate"].Value = cur_convrate;

                objSqlCommand.Parameters.Add("@p_revisedate", SqlDbType.VarChar);
                if (revisedate == "" || revisedate == null)
                {
                    objSqlCommand.Parameters["@p_revisedate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = revisedate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        revisedate = mm + "/" + dd + "/" + yy;


                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = revisedate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        revisedate = mm + "/" + dd + "/" + yy;


                    }
                    objSqlCommand.Parameters["@p_revisedate"].Value = revisedate;
                }

                objSqlCommand.Parameters.Add("@clienttype", SqlDbType.VarChar);
                if (clienttype == "0")
                    objSqlCommand.Parameters["@clienttype"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@clienttype"].Value = clienttype;

                objSqlCommand.Parameters.Add("@translation", SqlDbType.VarChar);
                if (translation == "0")
                    objSqlCommand.Parameters["@translation"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@translation"].Value = translation;


                objSqlCommand.Parameters.Add("@translationcharge", SqlDbType.Decimal);
                if (translationcharge == "" || translationcharge == null)
                {
                    objSqlCommand.Parameters["@translationcharge"].Value = System.DBNull.Value;
                }
                else
                {
                    translationcharge = translationcharge.Replace("%", "");
                    objSqlCommand.Parameters["@translationcharge"].Value = Convert.ToDecimal(translationcharge);
                }
                objSqlCommand.Parameters.Add("@fmgreasons", SqlDbType.VarChar);
                objSqlCommand.Parameters["@fmgreasons"].Value = fmgreasons;
                objSqlCommand.Parameters.Add("@canclecharge", SqlDbType.VarChar);
                objSqlCommand.Parameters["@canclecharge"].Value = canclecharge;

                objSqlCommand.Parameters.Add("@transdisc_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@transdisc_p"].Value = transdisc;

                objSqlCommand.Parameters.Add("@pospremdisc_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pospremdisc_p"].Value = pospremdisc;

                objSqlCommand.Parameters.Add("@billhold", SqlDbType.VarChar);
                objSqlCommand.Parameters["@billhold"].Value = billhold;

                objSqlCommand.Parameters.Add("@designbox", SqlDbType.VarChar);
                objSqlCommand.Parameters["@designbox"].Value = designbox;

                objSqlCommand.Parameters.Add("@logoprem", SqlDbType.VarChar);
                objSqlCommand.Parameters["@logoprem"].Value = logoprem;

                objSqlCommand.Parameters.Add("@online_ad_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@online_ad_p"].Value = online_ad;


                objSqlCommand.Parameters.Add("@style", SqlDbType.VarChar);
                objSqlCommand.Parameters["@style"].Value = style;


                objSqlCommand.Parameters.Add("@fixed_booking", SqlDbType.VarChar);
                objSqlCommand.Parameters["@fixed_booking"].Value = fixed_booking;



                objSqlCommand.Parameters.Add("@VAT_CODE", SqlDbType.VarChar);
                objSqlCommand.Parameters["@VAT_CODE"].Value = vat_code;

                objSqlCommand.Parameters.Add("@CPN_CODE_P", SqlDbType.VarChar);
                objSqlCommand.Parameters["@CPN_CODE_P"].Value = cou_code;

                objSqlCommand.Parameters.Add("@CPN_NAME_P", SqlDbType.VarChar);
                objSqlCommand.Parameters["@CPN_NAME_P"].Value = cou_name;

                objSqlCommand.Parameters.Add("@STATE_P", SqlDbType.VarChar);
                objSqlCommand.Parameters["@STATE_P"].Value = state;

                ////////

                objSqlCommand.Parameters.Add("@clientcatdisc", SqlDbType.Decimal);
                if (clientcatdisc == "" || clientcatdisc == "0" || clientcatdisc == "null")
                {
                    objSqlCommand.Parameters["@clientcatdisc"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@clientcatdisc"].Value = clientcatdisc;
                }

                objSqlCommand.Parameters.Add("@clientcatamt", SqlDbType.Decimal);
                if (clientcatamt == "" || clientcatamt == "0" || clientcatamt == "null")
                {
                    objSqlCommand.Parameters["@clientcatamt"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@clientcatamt"].Value = clientcatamt;
                }

                objSqlCommand.Parameters.Add("@clientcatdistype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@clientcatdistype"].Value = clientcatdistype;


                objSqlCommand.Parameters.Add("@flatfreqdisc", SqlDbType.Decimal);
                if (flatfreqdisc == "" || flatfreqdisc == "0" || flatfreqdisc == "null")
                {
                    objSqlCommand.Parameters["@flatfreqdisc"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@flatfreqdisc"].Value = flatfreqdisc;
                }


                objSqlCommand.Parameters.Add("@flatfreqamt", SqlDbType.Decimal);
                if (flatfreqamt == "" || flatfreqamt == "0" || flatfreqamt == "null")
                {
                    objSqlCommand.Parameters["@flatfreqamt"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@flatfreqamt"].Value = flatfreqamt;
                }



                objSqlCommand.Parameters.Add("@flatfreqdisctype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@flatfreqdisctype"].Value = flatfreqdisctype;

                objSqlCommand.Parameters.Add("@catdisc", SqlDbType.Decimal);
                if (catdisc == "" || catdisc == "0" || catdisc == "null")
                {
                    objSqlCommand.Parameters["@catdisc"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@catdisc"].Value = catdisc;
                }

                objSqlCommand.Parameters.Add("@catamt", SqlDbType.Decimal);
                if (catamt == "" || catamt == "0" || catamt == "null")
                {
                    objSqlCommand.Parameters["@catamt"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@catamt"].Value = catamt;
                }

                objSqlCommand.Parameters.Add("@catdisctype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@catdisctype"].Value = catdisctype;

                objSqlCommand.Parameters.Add("@representative_p", SqlDbType.VarChar);
                if (representative == "" || representative == "0" || representative == "null")
                {
                    objSqlCommand.Parameters["@representative_p"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@representative_p"].Value = representative;
                }

                objSqlCommand.Parameters.Add("@teamcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@teamcode"].Value = teamcode;


                objSqlCommand.Parameters.Add("@pindustry", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pindustry"].Value = industry;

                objSqlCommand.Parameters.Add("@pproductcat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pproductcat"].Value = productcat;

                objSqlCommand.Parameters.Add("@chkgstinc", SqlDbType.VarChar);
                objSqlCommand.Parameters["@chkgstinc"].Value = chkgstinc;

                objSqlCommand.Parameters.Add("@ppubl_rev_cent", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ppubl_rev_cent"].Value = publ_rev_cent;

                objSqlCommand.Parameters.Add("@pcontractperson", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcontractperson"].Value = contractperson;

                objSqlCommand.Parameters.Add("@pemailid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pemailid"].Value = emailid;

                objSqlCommand.Parameters.Add("@pquotation_id", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pquotation_id"].Value = quotationno;
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
                CloseConnection(ref objSqlConnection);
            }
        }
        public DataSet updatebooking(string adsizetype, string branch, string booked_by, string prevbook, string date_time, string ciobookid, string approvedby, string audit, string rono, string rodate, string caption, string billstatus, string rostatus, string agency, string client, string agencyaddress, string clientaddresses, string agencycode, string dockitno, string execname, string execzone, string product, string brand, string keyno, string billremark, string printremark, string package, string insertion, string startdate, string repeatdate, string adtype, string adcategory, string subcategory, string color, string uom, string pageposition, string pagetype, string pageno, string adsizheight, string adsizwidth, string ratecode, string scheme, string currency, string agreedrate, string agreedamt, string spedisc, string spacedisx, string compcode, string userid, string specialcharges, string agencytype, string agencystatus, string paymode, string agencredit, string cardrate, string cardamount, string discount, string discountper, string billaddress, string totarea, string billcycle, string revenuecenter, string billpay, string billheight, string billwidth, string billto, string invoices, string vts, string tradedisc, string agencyout, string boxcode, string boxno, string boxaddress, string boxagency, string boxclient, string bookingtype, string tfn, string coupan, string campaign, string bill_amt, string pageprem, string pageamt, string premper, string grossamt, string adsizcolumn, string billcolumn, Decimal billarea, string specdiscper, string spacediscper, string paidins, string dealrate, string deviation, string varient, string contractname, string dealtype, string cardname, string cardtype, string cardmonth, string cardyear, string cardno, string receiptno, string adscat3, string adscat4, string adscat5, string bgcolor, string bulletcode, string bulletprm, string material, string region, string varient_name, string coltype, string logo_h, string logo_w, string logo_col, string logo_uom, string status, string dateformat, string retainer, string addagencyrate, string mobileno, string addlamt, string retamt, string retper, string cashrecieved, string ciragency, string cirrate, string ciredition, string cirpublication, string ciragencysubcode, string bartertype, string cashdiscount, string cashdiscper, string attach1, string attach2, string drpdiscprem, string doctype, string chktradeval, string sharepub, string fmginsert, string chkno, string chkdate, string chkamt, string chkbankname, string ourbank, string dealerpanel, string dealerh, string dealerw, string dealertype, string multicode, string agreedrate_active, string agreedamt_active, string grossamtlocal_p, string billamtlocal_p, string chkadon, string refid, string rcpt_currency, string cur_convrate, string revisedate, string clienttype, string translation, string translationcharge, string fmgreasons, string canclecharge, string modifyrateaudit, string ip, string transdisc, string pospremdisc, string billhold, string designbox, string logoprem, string online_ad, string style, string fixed_booking, string vat_code, string cou_code, string cou_name, string state, string clientcatdisc, string clientcatamt, string clientcatdistype, string flatfreqdisc, string flatfreqamt, string flatfreqdisctype, string catdisc, string catamt, string catdisctype, string representative, string teamcode, string industry, string productcat, string chkgstinc)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {

                objSqlConnection.Open();
                objSqlCommand = GetCommand("updatebooking", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@date_time", SqlDbType.DateTime);
                if (date_time == "" || date_time == null)
                {
                    objSqlCommand.Parameters["@date_time"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = date_time.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        date_time = mm + "/" + dd + "/" + yy;


                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = date_time.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        date_time = mm + "/" + dd + "/" + yy;


                    }
                    objSqlCommand.Parameters["@date_time"].Value = date_time;
                }

                objSqlCommand.Parameters.Add("@adsizetype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adsizetype"].Value = adsizetype;

                objSqlCommand.Parameters.Add("@branch", SqlDbType.VarChar);
                objSqlCommand.Parameters["@branch"].Value = branch;

                objSqlCommand.Parameters.Add("@booked_by", SqlDbType.VarChar);
                objSqlCommand.Parameters["@booked_by"].Value = booked_by;

                objSqlCommand.Parameters.Add("@prevbook", SqlDbType.VarChar);
                objSqlCommand.Parameters["@prevbook"].Value = prevbook;

                objSqlCommand.Parameters.Add("@approvedby", SqlDbType.VarChar);
                objSqlCommand.Parameters["@approvedby"].Value = approvedby;

                objSqlCommand.Parameters.Add("@ciobookid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ciobookid"].Value = ciobookid;

                objSqlCommand.Parameters.Add("@audit", SqlDbType.VarChar);
                objSqlCommand.Parameters["@audit"].Value = audit;

                objSqlCommand.Parameters.Add("@rono", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rono"].Value = rono;

                objSqlCommand.Parameters.Add("@rodate", SqlDbType.DateTime);
                if (rodate == "" || rodate == null)
                {
                    objSqlCommand.Parameters["@rodate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = rodate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        rodate = mm + "/" + dd + "/" + yy;


                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = rodate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        rodate = mm + "/" + dd + "/" + yy;


                    }
                    objSqlCommand.Parameters["@rodate"].Value = rodate;
                }

                objSqlCommand.Parameters.Add("@caption", SqlDbType.VarChar);
                objSqlCommand.Parameters["@caption"].Value = caption;

                objSqlCommand.Parameters.Add("@billstatus", SqlDbType.VarChar);
                objSqlCommand.Parameters["@billstatus"].Value = billstatus;

                objSqlCommand.Parameters.Add("@rostatus", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rostatus"].Value = rostatus;

                objSqlCommand.Parameters.Add("@agency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agency"].Value = agency;

                objSqlCommand.Parameters.Add("@client", SqlDbType.VarChar);
                objSqlCommand.Parameters["@client"].Value = client;

                objSqlCommand.Parameters.Add("@agencyaddress", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencyaddress"].Value = agencyaddress;

                objSqlCommand.Parameters.Add("@clientaddresses", SqlDbType.VarChar);
                objSqlCommand.Parameters["@clientaddresses"].Value = clientaddresses;

                objSqlCommand.Parameters.Add("@agencycode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencycode"].Value = agencycode;

                objSqlCommand.Parameters.Add("@dockitno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dockitno"].Value = dockitno;

                objSqlCommand.Parameters.Add("@execname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@execname"].Value = execname;

                objSqlCommand.Parameters.Add("@execzone", SqlDbType.VarChar);
                objSqlCommand.Parameters["@execzone"].Value = execzone;

                objSqlCommand.Parameters.Add("@product", SqlDbType.VarChar);
                objSqlCommand.Parameters["@product"].Value = product;

                objSqlCommand.Parameters.Add("@brand", SqlDbType.VarChar);
                objSqlCommand.Parameters["@brand"].Value = brand;

                objSqlCommand.Parameters.Add("@keyno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@keyno"].Value = keyno;

                objSqlCommand.Parameters.Add("@billremark", SqlDbType.VarChar);
                objSqlCommand.Parameters["@billremark"].Value = billremark;

                objSqlCommand.Parameters.Add("@printremark", SqlDbType.VarChar);
                objSqlCommand.Parameters["@printremark"].Value = printremark;

                objSqlCommand.Parameters.Add("@package", SqlDbType.VarChar);
                objSqlCommand.Parameters["@package"].Value = package;

                objSqlCommand.Parameters.Add("@insertion", SqlDbType.Int);
                if (insertion == "" || insertion == null)
                {
                    objSqlCommand.Parameters["@insertion"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@insertion"].Value = Convert.ToInt32(insertion);
                }

                objSqlCommand.Parameters.Add("@startdate", SqlDbType.DateTime);
                if (startdate == "" || startdate == null)
                {
                    objSqlCommand.Parameters["@startdate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = startdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        startdate = mm + "/" + dd + "/" + yy;


                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = startdate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        startdate = mm + "/" + dd + "/" + yy;


                    }
                    objSqlCommand.Parameters["@startdate"].Value = startdate;
                }

                objSqlCommand.Parameters.Add("@repeatdate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@repeatdate"].Value = repeatdate;

                objSqlCommand.Parameters.Add("@adtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adtype"].Value = adtype;

                objSqlCommand.Parameters.Add("@adcategory", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adcategory"].Value = adcategory;

                objSqlCommand.Parameters.Add("@subcategory", SqlDbType.VarChar);
                objSqlCommand.Parameters["@subcategory"].Value = subcategory;

                objSqlCommand.Parameters.Add("@color", SqlDbType.VarChar);
                objSqlCommand.Parameters["@color"].Value = color;

                objSqlCommand.Parameters.Add("@uom", SqlDbType.VarChar);
                objSqlCommand.Parameters["@uom"].Value = uom;

                objSqlCommand.Parameters.Add("@pageposition", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pageposition"].Value = pageposition;

                objSqlCommand.Parameters.Add("@pagetype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pagetype"].Value = pagetype;

                objSqlCommand.Parameters.Add("@pageno", SqlDbType.Int);
                if (pageno == "" || pageno == null)
                {
                    objSqlCommand.Parameters["@pageno"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pageno"].Value = Convert.ToInt32(pageno);
                }

                objSqlCommand.Parameters.Add("@adsizheight", SqlDbType.Decimal);
                if (adsizheight == "" || adsizheight == null)
                {
                    objSqlCommand.Parameters["@adsizheight"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@adsizheight"].Value = Convert.ToDecimal(adsizheight);
                }

                objSqlCommand.Parameters.Add("@adsizwidth", SqlDbType.Decimal);
                if (adsizwidth == "" || adsizwidth == null)
                {
                    objSqlCommand.Parameters["@adsizwidth"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@adsizwidth"].Value = Convert.ToDecimal(adsizwidth);
                }

                objSqlCommand.Parameters.Add("@ratecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ratecode"].Value = ratecode;

                objSqlCommand.Parameters.Add("@scheme", SqlDbType.VarChar);
                objSqlCommand.Parameters["@scheme"].Value = scheme;

                objSqlCommand.Parameters.Add("@currency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@currency"].Value = currency;

                objSqlCommand.Parameters.Add("@agreedrate", SqlDbType.Decimal);
                if (agreedrate == "" || agreedrate == null)
                {
                    objSqlCommand.Parameters["@agreedrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@agreedrate"].Value = Convert.ToDecimal(agreedrate);
                }
                //    , , ,Session["compcode"].ToString(),Session["userid"].ToString()
                objSqlCommand.Parameters.Add("@agreedamt", SqlDbType.Decimal);
                if (agreedamt == "" || agreedamt == null)
                {
                    objSqlCommand.Parameters["@agreedamt"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@agreedamt"].Value = Convert.ToDecimal(agreedamt);
                }

                objSqlCommand.Parameters.Add("@spedisc", SqlDbType.Decimal);
                if (spedisc == "" || spedisc == null)
                {
                    objSqlCommand.Parameters["@spedisc"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@spedisc"].Value = Convert.ToDecimal(spedisc);
                }

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@spacedisx", SqlDbType.Decimal);
                if (spacedisx == "" || spacedisx == null)
                {
                    objSqlCommand.Parameters["@spacedisx"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@spacedisx"].Value = Convert.ToDecimal(spacedisx);
                }

                objSqlCommand.Parameters.Add("@specialcharges", SqlDbType.Decimal);
                if (specialcharges == "" || specialcharges == null)
                {
                    objSqlCommand.Parameters["@specialcharges"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@specialcharges"].Value = Convert.ToDecimal(specialcharges);
                }

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@agencytype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencytype"].Value = agencytype;

                objSqlCommand.Parameters.Add("@agencystatus", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencystatus"].Value = agencystatus;

                objSqlCommand.Parameters.Add("@paymode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@paymode"].Value = paymode;

                objSqlCommand.Parameters.Add("@agencredit", SqlDbType.Int);
                if (agencredit == "" || agencredit == null)
                {
                    objSqlCommand.Parameters["@agencredit"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@agencredit"].Value = Convert.ToInt32(agencredit);
                }

                objSqlCommand.Parameters.Add("@cardrate", SqlDbType.Decimal);
                if (cardrate == "" || cardrate == null)
                {
                    objSqlCommand.Parameters["@cardrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@cardrate"].Value = Convert.ToDecimal(cardrate);
                }

                objSqlCommand.Parameters.Add("@cardamount", SqlDbType.Decimal);
                if (cardamount == "" || cardamount == null)
                {
                    objSqlCommand.Parameters["@cardamount"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@cardamount"].Value = Convert.ToDecimal(cardamount);
                }

                objSqlCommand.Parameters.Add("@discount", SqlDbType.Decimal);
                if (discount == "" || discount == null)
                {
                    objSqlCommand.Parameters["@discount"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@discount"].Value = Convert.ToDecimal(discount);
                }


                objSqlCommand.Parameters.Add("@discountper", SqlDbType.Decimal);
                if (discountper == "" || discountper == null)
                {
                    objSqlCommand.Parameters["@discountper"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@discountper"].Value = Convert.ToDecimal(discountper);
                }

                objSqlCommand.Parameters.Add("@billaddress", SqlDbType.VarChar);
                objSqlCommand.Parameters["@billaddress"].Value = billaddress;

                objSqlCommand.Parameters.Add("@totarea", SqlDbType.Decimal);
                if (totarea == "" || totarea == null)
                {
                    objSqlCommand.Parameters["@totarea"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@totarea"].Value = Convert.ToDecimal(totarea);
                }


                objSqlCommand.Parameters.Add("@billcycle", SqlDbType.VarChar);
                objSqlCommand.Parameters["@billcycle"].Value = billcycle;

                objSqlCommand.Parameters.Add("@revenuecenter", SqlDbType.VarChar);
                objSqlCommand.Parameters["@revenuecenter"].Value = revenuecenter;

                objSqlCommand.Parameters.Add("@billpay", SqlDbType.VarChar);
                objSqlCommand.Parameters["@billpay"].Value = billpay;

                objSqlCommand.Parameters.Add("@billheight", SqlDbType.Decimal);
                if (billheight == "" || billheight == null)
                {
                    objSqlCommand.Parameters["@billheight"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@billheight"].Value = Convert.ToDecimal(billheight);
                }

                objSqlCommand.Parameters.Add("@billwidth", SqlDbType.Decimal);
                if (billwidth == "" || billwidth == null)
                {
                    objSqlCommand.Parameters["@billwidth"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@billwidth"].Value = Convert.ToDecimal(billwidth);
                }

                //////, , , , , , , , , , , , , , , , , , , 

                objSqlCommand.Parameters.Add("@billto", SqlDbType.VarChar);
                objSqlCommand.Parameters["@billto"].Value = billto;

                objSqlCommand.Parameters.Add("@invoices", SqlDbType.Int);
                if (invoices == "" || invoices == null)
                {
                    objSqlCommand.Parameters["@invoices"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@invoices"].Value = Convert.ToInt32(invoices);
                }

                objSqlCommand.Parameters.Add("@vts", SqlDbType.Int);
                if (vts == "" || vts == null)
                {
                    objSqlCommand.Parameters["@vts"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@vts"].Value = Convert.ToInt32(vts);
                }

                objSqlCommand.Parameters.Add("@tradedisc", SqlDbType.Decimal);
                if (tradedisc == "" || tradedisc == null)
                {
                    objSqlCommand.Parameters["@tradedisc"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@tradedisc"].Value = Convert.ToDecimal(tradedisc);
                }

                objSqlCommand.Parameters.Add("@agencyout", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencyout"].Value = agencyout;

                objSqlCommand.Parameters.Add("@boxcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@boxcode"].Value = boxcode;

                objSqlCommand.Parameters.Add("@boxno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@boxno"].Value = boxno;

                objSqlCommand.Parameters.Add("@boxaddress", SqlDbType.VarChar);
                objSqlCommand.Parameters["@boxaddress"].Value = boxaddress;

                objSqlCommand.Parameters.Add("@boxagency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@boxagency"].Value = boxagency;

                objSqlCommand.Parameters.Add("@boxclient", SqlDbType.VarChar);
                objSqlCommand.Parameters["@boxclient"].Value = boxclient;

                objSqlCommand.Parameters.Add("@bookingtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@bookingtype"].Value = bookingtype;

                objSqlCommand.Parameters.Add("@tfn", SqlDbType.VarChar);
                objSqlCommand.Parameters["@tfn"].Value = tfn;

                objSqlCommand.Parameters.Add("@coupan", SqlDbType.VarChar);
                objSqlCommand.Parameters["@coupan"].Value = coupan;

                objSqlCommand.Parameters.Add("@campaign", SqlDbType.VarChar);
                objSqlCommand.Parameters["@campaign"].Value = campaign;


                objSqlCommand.Parameters.Add("@bill_amt", SqlDbType.Decimal);
                if (bill_amt == "" || bill_amt == null)
                {
                    objSqlCommand.Parameters["@bill_amt"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@bill_amt"].Value = Convert.ToDecimal(bill_amt);
                }

                objSqlCommand.Parameters.Add("@pageprem", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pageprem"].Value = pageprem;


                objSqlCommand.Parameters.Add("@pageamt", SqlDbType.Decimal);
                if (pageamt == "" || pageamt == null)
                {
                    objSqlCommand.Parameters["@pageamt"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pageamt"].Value = Convert.ToDecimal(pageamt);
                }

                objSqlCommand.Parameters.Add("@premper", SqlDbType.Decimal);
                if (premper == "" || premper == null)
                {
                    objSqlCommand.Parameters["@premper"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@premper"].Value = Convert.ToDecimal(premper);
                }

                objSqlCommand.Parameters.Add("@grossamt", SqlDbType.Decimal);
                if (grossamt == "" || grossamt == null)
                {
                    objSqlCommand.Parameters["@grossamt"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@grossamt"].Value = Convert.ToDecimal(grossamt);
                }

                objSqlCommand.Parameters.Add("@adsizcolumn", SqlDbType.Decimal);
                if (adsizcolumn == "" || adsizcolumn == null)
                {
                    objSqlCommand.Parameters["@adsizcolumn"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@adsizcolumn"].Value = Convert.ToDecimal(adsizcolumn);
                }

                objSqlCommand.Parameters.Add("@billcolumn", SqlDbType.Decimal);
                if (billcolumn == "" || billcolumn == null)
                {
                    objSqlCommand.Parameters["@billcolumn"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@billcolumn"].Value = Convert.ToDecimal(billcolumn);
                }

                objSqlCommand.Parameters.Add("@billarea", SqlDbType.Decimal);

                objSqlCommand.Parameters["@billarea"].Value = Convert.ToDecimal(billarea);


                objSqlCommand.Parameters.Add("@specdiscper", SqlDbType.Decimal);
                if (specdiscper == "" || specdiscper == null)
                {
                    objSqlCommand.Parameters["@specdiscper"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@specdiscper"].Value = Convert.ToDecimal(specdiscper);
                }

                objSqlCommand.Parameters.Add("@spacediscper", SqlDbType.Decimal);
                if (spacediscper == "" || spacediscper == null)
                {
                    objSqlCommand.Parameters["@spacediscper"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@spacediscper"].Value = Convert.ToDecimal(spacediscper);
                }

                objSqlCommand.Parameters.Add("@paidins", SqlDbType.Int);
                if (paidins == "" || paidins == null)
                {
                    objSqlCommand.Parameters["@paidins"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@paidins"].Value = Convert.ToInt32(paidins);
                }

                objSqlCommand.Parameters.Add("@dealrate", SqlDbType.Decimal);
                if (dealrate == "" || dealrate == null)
                {
                    objSqlCommand.Parameters["@dealrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@dealrate"].Value = Convert.ToDecimal(dealrate);
                }

                objSqlCommand.Parameters.Add("@deviation", SqlDbType.Decimal);
                if (deviation == "" || deviation == null)
                {
                    objSqlCommand.Parameters["@deviation"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@deviation"].Value = Convert.ToDecimal(deviation);
                }

                objSqlCommand.Parameters.Add("@varient", SqlDbType.VarChar);
                objSqlCommand.Parameters["@varient"].Value = varient;

                objSqlCommand.Parameters.Add("@contractname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@contractname"].Value = contractname;


                objSqlCommand.Parameters.Add("@dealtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dealtype"].Value = dealtype;

                objSqlCommand.Parameters.Add("@cardname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cardname"].Value = cardname;

                objSqlCommand.Parameters.Add("@cardtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cardtype"].Value = cardtype;

                objSqlCommand.Parameters.Add("@cardmonth", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cardmonth"].Value = cardmonth;

                objSqlCommand.Parameters.Add("@cardyear", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cardyear"].Value = cardyear;

                objSqlCommand.Parameters.Add("@cardno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cardno"].Value = cardno;

                objSqlCommand.Parameters.Add("@receiptno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@receiptno"].Value = receiptno;

                objSqlCommand.Parameters.Add("@adscat3", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adscat3"].Value = adscat3;

                objSqlCommand.Parameters.Add("@adscat4", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adscat4"].Value = adscat4;

                objSqlCommand.Parameters.Add("@adscat5", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adscat5"].Value = adscat5;

                objSqlCommand.Parameters.Add("@bgcolor", SqlDbType.VarChar);
                objSqlCommand.Parameters["@bgcolor"].Value = bgcolor;

                objSqlCommand.Parameters.Add("@bulletcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@bulletcode"].Value = bulletcode;

                objSqlCommand.Parameters.Add("@bulletprm", SqlDbType.Decimal);
                if (bulletprm == "" || bulletprm == null)
                {
                    objSqlCommand.Parameters["@bulletprm"].Value = System.DBNull.Value;
                }
                else
                {
                    bulletprm = bulletprm.Replace("%", "");
                    objSqlCommand.Parameters["@bulletprm"].Value = Convert.ToDecimal(bulletprm);
                }

                objSqlCommand.Parameters.Add("@material", SqlDbType.VarChar);
                objSqlCommand.Parameters["@material"].Value = material;

                objSqlCommand.Parameters.Add("@region", SqlDbType.VarChar);
                objSqlCommand.Parameters["@region"].Value = region;

                objSqlCommand.Parameters.Add("@varient_name", SqlDbType.VarChar);
                objSqlCommand.Parameters["@varient_name"].Value = varient_name;
                /*new change ankur 9 feb*/
                objSqlCommand.Parameters.Add("@coltype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@coltype"].Value = coltype;
                //////////////////////////////

                objSqlCommand.Parameters.Add("@logo_h", SqlDbType.VarChar);
                objSqlCommand.Parameters["@logo_h"].Value = logo_h;

                objSqlCommand.Parameters.Add("@logo_w", SqlDbType.VarChar);
                objSqlCommand.Parameters["@logo_w"].Value = logo_w;

                objSqlCommand.Parameters.Add("@logo_col", SqlDbType.VarChar);
                objSqlCommand.Parameters["@logo_col"].Value = logo_col;

                objSqlCommand.Parameters.Add("@logo_uom", SqlDbType.VarChar);
                objSqlCommand.Parameters["@logo_uom"].Value = logo_uom;

                objSqlCommand.Parameters.Add("@status", SqlDbType.VarChar);
                objSqlCommand.Parameters["@status"].Value = status;

                objSqlCommand.Parameters.Add("@retainer1", SqlDbType.VarChar);
                if (retainer.IndexOf("(") >= 0)
                {
                    retainer = retainer.Substring(retainer.IndexOf("(") + 1, retainer.Length - retainer.IndexOf("(") - 2);
                }
                objSqlCommand.Parameters["@retainer1"].Value = retainer;

                objSqlCommand.Parameters.Add("@addagencyrate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@addagencyrate"].Value = addagencyrate;

                objSqlCommand.Parameters.Add("@mobileno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@mobileno"].Value = mobileno;

                objSqlCommand.Parameters.Add("@addlamt", SqlDbType.VarChar);
                objSqlCommand.Parameters["@addlamt"].Value = addlamt;

                objSqlCommand.Parameters.Add("@retamt", SqlDbType.VarChar);
                objSqlCommand.Parameters["@retamt"].Value = retamt;

                objSqlCommand.Parameters.Add("@retper", SqlDbType.VarChar);
                objSqlCommand.Parameters["@retper"].Value = retper;

                objSqlCommand.Parameters.Add("@cashrecieved", SqlDbType.VarChar);
                if (cashrecieved == "" || cashrecieved == null)
                {
                    objSqlCommand.Parameters["@cashrecieved"].Value = System.DBNull.Value;
                }
                else
                {

                    objSqlCommand.Parameters["@cashrecieved"].Value = Convert.ToDecimal(cashrecieved);
                }
                objSqlCommand.Parameters.Add("@CIRAGENCY", SqlDbType.VarChar);
                objSqlCommand.Parameters["@CIRAGENCY"].Value = ciragency;

                objSqlCommand.Parameters.Add("@CIRRATE", SqlDbType.VarChar);
                objSqlCommand.Parameters["@CIRRATE"].Value = cirrate;

                objSqlCommand.Parameters.Add("@CIREDITION", SqlDbType.VarChar);
                objSqlCommand.Parameters["@CIREDITION"].Value = ciredition;

                objSqlCommand.Parameters.Add("@CIRPUBLICATION", SqlDbType.VarChar);
                objSqlCommand.Parameters["@CIRPUBLICATION"].Value = cirpublication;

                objSqlCommand.Parameters.Add("@CIRAGENCYSUBCODE", SqlDbType.VarChar);
                objSqlCommand.Parameters["@CIRAGENCYSUBCODE"].Value = ciragencysubcode;

                objSqlCommand.Parameters.Add("@BARTERTYPE", SqlDbType.VarChar);
                objSqlCommand.Parameters["@BARTERTYPE"].Value = bartertype;

                objSqlCommand.Parameters.Add("@CASHDISCOUNT_V", SqlDbType.VarChar);
                if (cashdiscount == "")
                    objSqlCommand.Parameters["@CASHDISCOUNT_V"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@CASHDISCOUNT_V"].Value = cashdiscount;

                objSqlCommand.Parameters.Add("@CASHDISCOUNTPER_V", SqlDbType.VarChar);
                objSqlCommand.Parameters["@CASHDISCOUNTPER_V"].Value = cashdiscper;

                objSqlCommand.Parameters.Add("@attach1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@attach1"].Value = attach1;

                objSqlCommand.Parameters.Add("@attach2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@attach2"].Value = attach2;

                objSqlCommand.Parameters.Add("@drpdiscprem", SqlDbType.VarChar);
                objSqlCommand.Parameters["@drpdiscprem"].Value = drpdiscprem;
                objSqlCommand.Parameters.Add("@doctype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@doctype"].Value = doctype;

                objSqlCommand.Parameters.Add("@CHKTRADE", SqlDbType.VarChar);
                objSqlCommand.Parameters["@CHKTRADE"].Value = chktradeval;
                objSqlCommand.Parameters.Add("@sharepub_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@sharepub_p"].Value = sharepub;

                objSqlCommand.Parameters.Add("@fmginsert", SqlDbType.VarChar);
                objSqlCommand.Parameters["@fmginsert"].Value = fmginsert;

                objSqlCommand.Parameters.Add("@chkno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@chkno"].Value = chkno;

                objSqlCommand.Parameters.Add("@chkdate", SqlDbType.DateTime);
                if (chkdate == "" || chkdate == null)
                {
                    objSqlCommand.Parameters["@chkdate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = chkdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        chkdate = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = chkdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        chkdate = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@chkdate"].Value = chkdate;
                }


                objSqlCommand.Parameters.Add("@chkamt", SqlDbType.VarChar);
                objSqlCommand.Parameters["@chkamt"].Value = chkamt;

                objSqlCommand.Parameters.Add("@chkbankname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@chkbankname"].Value = chkbankname;
                objSqlCommand.Parameters.Add("@ourbank", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ourbank"].Value = ourbank;

                objSqlCommand.Parameters.Add("@DEALERPANEL_P", SqlDbType.VarChar);
                if (dealerpanel == "")
                    objSqlCommand.Parameters["@DEALERPANEL_P"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@DEALERPANEL_P"].Value = dealerpanel;

                objSqlCommand.Parameters.Add("@DEALERH_P", SqlDbType.VarChar);
                if (dealerh == "")
                    objSqlCommand.Parameters["@DEALERH_P"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@DEALERH_P"].Value = dealerh;

                objSqlCommand.Parameters.Add("@DEALERW_P", SqlDbType.VarChar);
                if (dealerw == "")
                    objSqlCommand.Parameters["@DEALERW_P"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@DEALERW_P"].Value = dealerw;

                objSqlCommand.Parameters.Add("@DEALERTYPE_P", SqlDbType.VarChar);
                if (dealertype == "")
                    objSqlCommand.Parameters["@DEALERTYPE_P"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@DEALERTYPE_P"].Value = dealertype;

                objSqlCommand.Parameters.Add("@multiselect", SqlDbType.VarChar);
                objSqlCommand.Parameters["@multiselect"].Value = multicode;

                objSqlCommand.Parameters.Add("@AGREEDRATE_ACTIVE", SqlDbType.VarChar);
                if (agreedrate_active == "")
                    objSqlCommand.Parameters["@AGREEDRATE_ACTIVE"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@AGREEDRATE_ACTIVE"].Value = agreedrate_active;

                objSqlCommand.Parameters.Add("@AGREEDAMT_ACTIVE", SqlDbType.VarChar);
                if (agreedamt_active == "")
                    objSqlCommand.Parameters["@AGREEDAMT_ACTIVE"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@AGREEDAMT_ACTIVE"].Value = agreedamt_active;

                objSqlCommand.Parameters.Add("@grossamtlocal_p", SqlDbType.VarChar);
                if (grossamtlocal_p == "")
                    objSqlCommand.Parameters["@grossamtlocal_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@grossamtlocal_p"].Value = grossamtlocal_p;


                objSqlCommand.Parameters.Add("@billamtlocal_p", SqlDbType.VarChar);
                if (billamtlocal_p == "")
                    objSqlCommand.Parameters["@billamtlocal_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@billamtlocal_p"].Value = billamtlocal_p;



                objSqlCommand.Parameters.Add("@chkadon_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@chkadon_p"].Value = chkadon;

                objSqlCommand.Parameters.Add("@refid_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@refid_p"].Value = refid;


                objSqlCommand.Parameters.Add("@rcpt_currency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rcpt_currency"].Value = rcpt_currency;

                objSqlCommand.Parameters.Add("@cur_convrate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cur_convrate"].Value = cur_convrate;

                objSqlCommand.Parameters.Add("@p_revisedate", SqlDbType.VarChar);
                if (revisedate == "" || revisedate == null)
                {
                    objSqlCommand.Parameters["@p_revisedate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = revisedate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        revisedate = mm + "/" + dd + "/" + yy;


                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = revisedate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        revisedate = mm + "/" + dd + "/" + yy;


                    }
                    objSqlCommand.Parameters["@p_revisedate"].Value = revisedate;
                }

                objSqlCommand.Parameters.Add("@clienttype", SqlDbType.VarChar);
                if (clienttype == "0")
                    objSqlCommand.Parameters["@clienttype"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@clienttype"].Value = clienttype;

                objSqlCommand.Parameters.Add("@translation", SqlDbType.VarChar);
                if (translation == "0")
                    objSqlCommand.Parameters["@translation"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@translation"].Value = translation;

                objSqlCommand.Parameters.Add("@translationcharge", SqlDbType.Decimal);
                if (translationcharge == "" || translationcharge == null)
                {
                    objSqlCommand.Parameters["@translationcharge"].Value = System.DBNull.Value;
                }
                else
                {
                    translationcharge = translationcharge.Replace("%", "");
                    objSqlCommand.Parameters["@translationcharge"].Value = Convert.ToDecimal(translationcharge);
                }
                objSqlCommand.Parameters.Add("@fmgreasons", SqlDbType.VarChar);
                objSqlCommand.Parameters["@fmgreasons"].Value = fmgreasons;

                objSqlCommand.Parameters.Add("@canclecharge", SqlDbType.VarChar);
                objSqlCommand.Parameters["@canclecharge"].Value = canclecharge;

                objSqlCommand.Parameters.Add("@P_ip", SqlDbType.VarChar);
                objSqlCommand.Parameters["@P_ip"].Value = ip;

                objSqlCommand.Parameters.Add("@P_RATE_AUDIT_FLAG", SqlDbType.VarChar);
                objSqlCommand.Parameters["@P_RATE_AUDIT_FLAG"].Value = modifyrateaudit;

                objSqlCommand.Parameters.Add("@transdisc_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@transdisc_p"].Value = transdisc;

                objSqlCommand.Parameters.Add("@pospremdisc_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pospremdisc_p"].Value = pospremdisc;

                objSqlCommand.Parameters.Add("@billhold", SqlDbType.VarChar);
                objSqlCommand.Parameters["@billhold"].Value = billhold;

                objSqlCommand.Parameters.Add("@designbox", SqlDbType.VarChar);
                objSqlCommand.Parameters["@designbox"].Value = designbox;


                objSqlCommand.Parameters.Add("@logoprem", SqlDbType.VarChar);
                objSqlCommand.Parameters["@logoprem"].Value = logoprem;

                objSqlCommand.Parameters.Add("@online_ad_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@online_ad_p"].Value = online_ad;


                objSqlCommand.Parameters.Add("@style", SqlDbType.VarChar);
                objSqlCommand.Parameters["@style"].Value = style;


                objSqlCommand.Parameters.Add("@fixed_booking", SqlDbType.VarChar);
                objSqlCommand.Parameters["@fixed_booking"].Value = fixed_booking;


                objSqlCommand.Parameters.Add("@vat_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@vat_code"].Value = vat_code;

                objSqlCommand.Parameters.Add("@CPN_CODE_P", SqlDbType.VarChar);
                objSqlCommand.Parameters["@CPN_CODE_P"].Value = cou_code;

                objSqlCommand.Parameters.Add("@CPN_NAME_P", SqlDbType.VarChar);
                objSqlCommand.Parameters["@CPN_NAME_P"].Value = cou_name;

                objSqlCommand.Parameters.Add("@STATE_P", SqlDbType.VarChar);
                objSqlCommand.Parameters["@STATE_P"].Value = state;

                objSqlCommand.Parameters.Add("@clientcatdisc", SqlDbType.Decimal);
                if (clientcatdisc == "" || clientcatdisc == "0" || clientcatdisc == "null")
                {
                    objSqlCommand.Parameters["@clientcatdisc"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@clientcatdisc"].Value = clientcatdisc;
                }

                objSqlCommand.Parameters.Add("@clientcatamt", SqlDbType.Decimal);
                if (clientcatamt == "" || clientcatamt == "0" || clientcatamt == "null")
                {
                    objSqlCommand.Parameters["@clientcatamt"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@clientcatamt"].Value = clientcatamt;
                }

                objSqlCommand.Parameters.Add("@clientcatdistype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@clientcatdistype"].Value = clientcatdistype;


                objSqlCommand.Parameters.Add("@flatfreqdisc", SqlDbType.Decimal);
                if (flatfreqdisc == "" || flatfreqdisc == "0" || flatfreqdisc == "null")
                {
                    objSqlCommand.Parameters["@flatfreqdisc"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@flatfreqdisc"].Value = flatfreqdisc;
                }


                objSqlCommand.Parameters.Add("@flatfreqamt", SqlDbType.Decimal);
                if (flatfreqamt == "" || flatfreqamt == "0" || flatfreqamt == "null")
                {
                    objSqlCommand.Parameters["@flatfreqamt"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@flatfreqamt"].Value = flatfreqamt;
                }



                objSqlCommand.Parameters.Add("@flatfreqdisctype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@flatfreqdisctype"].Value = flatfreqdisctype;

                objSqlCommand.Parameters.Add("@catdisc", SqlDbType.Decimal);
                if (catdisc == "" || catdisc == "0" || catdisc == "null")
                {
                    objSqlCommand.Parameters["@catdisc"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@catdisc"].Value = catdisc;
                }

                objSqlCommand.Parameters.Add("@catamt", SqlDbType.Decimal);
                if (catamt == "" || catamt == "0" || catamt == "null")
                {
                    objSqlCommand.Parameters["@catamt"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@catamt"].Value = catamt;
                }

                objSqlCommand.Parameters.Add("@catdisctype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@catdisctype"].Value = catdisctype;

                objSqlCommand.Parameters.Add("@representative_p", SqlDbType.VarChar);
                if (representative == "" || representative == "0" || representative == "null")
                {
                    objSqlCommand.Parameters["@representative_p"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@representative_p"].Value = representative;
                }


                objSqlCommand.Parameters.Add("@teamcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@teamcode"].Value = teamcode;

                objSqlCommand.Parameters.Add("@pindustry", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pindustry"].Value = industry;

                objSqlCommand.Parameters.Add("@pproductcat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pproductcat"].Value = productcat;

                objSqlCommand.Parameters.Add("@chkgstinc", SqlDbType.VarChar);
                objSqlCommand.Parameters["@chkgstinc"].Value = chkgstinc;

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
                CloseConnection(ref objSqlConnection);
            }
        }
        ///////////////////////Merg code///////////////////////////////////////////
        public DataSet prevbooking(string compcode, string userid, string formname, string quotation)
        {
            string zonename = "";
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("gettheprevbooking", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;
                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;
                objSqlCommand.Parameters.Add("@formname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@formname"].Value = formname;
                objSqlCommand.Parameters.Add("@pbooking_quot", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pbooking_quot"].Value = quotation;
                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                //if (objDataSet.Tables[0].Rows.Count > 0)
                //{
                //    zonename = objDataSet.Tables[0].Rows[0].ItemArray[0].ToString();
                //}
                return objDataSet;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }

        }
        public DataSet executebooking(string compcode, string ciobookid, string docno, string keyno, string rono, string agencycode, string client, string booking, string dateformat, string revenue)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("executebooking_q", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@ciobookid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ciobookid"].Value = ciobookid;

                objSqlCommand.Parameters.Add("@docno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@docno"].Value = docno;

                objSqlCommand.Parameters.Add("@keyno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@keyno"].Value = keyno;

                objSqlCommand.Parameters.Add("@rono", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rono"].Value = rono;

                objSqlCommand.Parameters.Add("@agencycode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencycode"].Value = agencycode;

                objSqlCommand.Parameters.Add("@client", SqlDbType.VarChar);
                objSqlCommand.Parameters["@client"].Value = client;

                objSqlCommand.Parameters.Add("@booking", SqlDbType.VarChar);
                objSqlCommand.Parameters["@booking"].Value = booking;

                objSqlCommand.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dateformat"].Value = dateformat;

                objSqlCommand.Parameters.Add("@revenue", SqlDbType.VarChar);
                objSqlCommand.Parameters["@revenue"].Value = revenue;


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
                CloseConnection(ref objSqlConnection);
            }
        }
        public DataSet getPackageInsert(string pckcode, string cioid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Getpackageinsert_q", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("@packagecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@packagecode"].Value = pckcode;

                objSqlCommand.Parameters.Add("@cioid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cioid"].Value = cioid;

                objSqlDataAdapter = new SqlDataAdapter();
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
                CloseConnection(ref objSqlConnection);
            }
        }
        public DataSet fetchdataforexe1_q(string ciobid, string compcode)
        {
            string zonename = "";
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getdataforexecute1_q", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@ciobid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ciobid"].Value = ciobid;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                //if (objDataSet.Tables[0].Rows.Count > 0)
                //{
                //    zonename = objDataSet.Tables[0].Rows[0].ItemArray[0].ToString();
                //}
                return objDataSet;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }

        }
        public DataSet fetchdataforexe(string ciobid, string compcode)
        {
            string zonename = "";
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getdataforexecute_q", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@ciobid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ciobid"].Value = ciobid;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                //if (objDataSet.Tables[0].Rows.Count > 0)
                //{
                //    zonename = objDataSet.Tables[0].Rows[0].ItemArray[0].ToString();
                //}
                return objDataSet;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }

        }
        public string commitT(int count, string cioid, string pcompcode, string pcentname, string puserid, string pbkid_gentype, string pbk_type, string quotation, string clientcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            string error = "";
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("committransaction", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlDataAdapter = new SqlDataAdapter();

                objSqlCommand.Parameters.Add("@pcioid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcioid"].Value = cioid;

                objSqlCommand.Parameters.Add("@totalcount", SqlDbType.Int);
                objSqlCommand.Parameters["@totalcount"].Value = count;

                objSqlCommand.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcompcode"].Value = pcompcode;

                objSqlCommand.Parameters.Add("@pcentname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcentname"].Value = pcentname;

                objSqlCommand.Parameters.Add("@puserid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@puserid"].Value = puserid;

                objSqlCommand.Parameters.Add("@pbkid_gentype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pbkid_gentype"].Value = pbkid_gentype;

                objSqlCommand.Parameters.Add("@pbk_type", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pbk_type"].Value = pbk_type;

                objSqlCommand.Parameters.Add("@pquotation", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pquotation"].Value = quotation;
                objSqlCommand.Parameters.Add("@clientcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@clientcode"].Value = clientcode;


                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);

                return error = "AA" + "$~$" + objDataSet.Tables[0].Rows[0][0].ToString();

                //objSqlDataAdapter.SelectCommand = objSqlCommand;
                //objSqlCommand.ExecuteNonQuery();
                // objSqlDataAdapter.Fill(objDataSet);


            }
            catch (Exception ex)
            {
                error = ex.Message;
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }
            return error;
        }
    }
}