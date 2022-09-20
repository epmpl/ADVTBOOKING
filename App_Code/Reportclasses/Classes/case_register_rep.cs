using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;



namespace NewAdbooking.Report.Classes
{
    public class case_register_rep:connection
    {
        public DataSet advtype(string adtype, string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("RA_bindadcategory_r", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@advtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@advtype"].Value = adtype;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;


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


        public DataSet adname(string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("RA_adbindcategory_r", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;


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

        public DataSet getSubCategory(string compcode, string catcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("advsubcattyp", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@catcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@catcode"].Value = catcode;

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

        public DataSet advpub(string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Bind_PubName", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;


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

        public DataSet adbranch(string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("branchbind_adv", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

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

        public DataSet pub_cent_NEW(string compcode, string chk_access, string useid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Bind_PubCentName_r", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@puserid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@puserid"].Value = useid;
                objSqlCommand.Parameters.Add("@chk_access", SqlDbType.VarChar);
                objSqlCommand.Parameters["@chk_access"].Value = chk_access;
                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

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

        public DataSet edition(string pubcode, string centercode, string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("edition_proc", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("@pubcode ", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pubcode "].Value = pubcode;
                objSqlCommand.Parameters.Add("@centercode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@centercode"].Value = centercode;
                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;
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

        public DataSet pub_centbind(string compcode, string useid, string chk_acc)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("pubcent_proc", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("@chk_access", SqlDbType.VarChar);
                objSqlCommand.Parameters["@chk_access"].Value = chk_acc;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@puserid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@puserid"].Value = useid;

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

        public DataSet onscreen_rep(string compcode, string branch, string printcent, string adtype, string adcategory, string adsubcat, string fromdate, string todate, string publication, string pubcenter, string edition, string basedon, string userid, string extra1, string extra2, string extra3, string extra4, string dateformat)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("ad_case_register_report", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@pcomp_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcomp_code"].Value = compcode;

                objSqlCommand.Parameters.Add("@pbranch", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pbranch"].Value = branch;

                objSqlCommand.Parameters.Add("@pcenter", SqlDbType.VarChar);

                if (printcent == "0")
                {
                    objSqlCommand.Parameters["@pcenter"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pcenter"].Value = printcent;
                }
                objSqlCommand.Parameters.Add("@padtype", SqlDbType.VarChar);
                if (adtype == "0")
                {

                    objSqlCommand.Parameters["@padtype"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@padtype"].Value = adtype;
                }
                objSqlCommand.Parameters.Add("@padcat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@padcat"].Value = adcategory;

                objSqlCommand.Parameters.Add("@padsubcat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@padsubcat"].Value = adsubcat;

                objSqlCommand.Parameters.Add("@pfromdate", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@pfromdate"].Value = fromdate;


                if (fromdate == "dd/mm/yyyy")
                {

                    string[] arr = fromdate.Split('/');
                    string mm = arr[1];
                    string dd = arr[0];
                    string yy = arr[2];
                    fromdate = mm + "/" + dd + "/" + yy;
                    objSqlCommand.Parameters["@pfromdate"].Value = fromdate;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = fromdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        fromdate = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@pfromdate"].Value = fromdate;

                }


                objSqlCommand.Parameters.Add("@ptodate", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@ptodate"].Value = todate;\

                if (fromdate == "dd/mm/yyyy")
                {

                    string[] arr = todate.Split('/');
                    string mm = arr[1];
                    string dd = arr[0];
                    string yy = arr[2];
                    todate = mm + "/" + dd + "/" + yy;
                    objSqlCommand.Parameters["@ptodate"].Value = todate;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = todate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        todate = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@ptodate"].Value = todate;

                }




                objSqlCommand.Parameters.Add("@ppub", SqlDbType.VarChar);
                if (publication == "0")
                {
                    objSqlCommand.Parameters["@ppub"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@ppub"].Value = publication;
                }
                objSqlCommand.Parameters.Add("@ppubcenter", SqlDbType.VarChar);
                if (pubcenter == "0")
                {
                    objSqlCommand.Parameters["@ppubcenter"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@ppubcenter"].Value = pubcenter;
                }
                objSqlCommand.Parameters.Add("@pedition", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pedition"].Value = edition;

                objSqlCommand.Parameters.Add("@basedon", SqlDbType.VarChar);
                objSqlCommand.Parameters["@basedon"].Value = basedon;

                objSqlCommand.Parameters.Add("@puserid", SqlDbType.VarChar);
                if (userid == "0")
                {
                    objSqlCommand.Parameters["@puserid"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@puserid"].Value = userid;
                }
                objSqlCommand.Parameters.Add("@extra1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@extra1"].Value = extra1;

                objSqlCommand.Parameters.Add("@extra2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@extra2"].Value = extra2;

                objSqlCommand.Parameters.Add("@extra3", SqlDbType.VarChar);
                objSqlCommand.Parameters["@extra3"].Value = extra3;

                objSqlCommand.Parameters.Add("@extra4", SqlDbType.VarChar);
                objSqlCommand.Parameters["@extra4"].Value = extra4;

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



    }
}