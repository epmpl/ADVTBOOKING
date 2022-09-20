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

/// <summary>
/// Summary description for EditionWise_RatioEntry
/// </summary>
/// 
namespace NewAdbooking.Classes
{

    public class EditionWise_RatioEntry : connection
    {
        public EditionWise_RatioEntry()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataSet bindedition(string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();

            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("BindMainEdition", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcompcode"].Value = compcode;

              
                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objSqlConnection.Close();

            }

        }

        public DataSet GetSubEdition(string compcode, string schemecode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();

            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("GetSubEdition", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcompcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@peditionname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@peditionname"].Value = schemecode;  


                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objSqlConnection.Close();

            }

        }

        public DataSet exemainditionratio(string editioncode, string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();

            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("executemainedition_ratioentry", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcompcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@peditioncode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@peditioncode"].Value = editioncode;


                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objSqlConnection.Close();

            }

        }

        public DataSet executeeditionwiseratio(string editioncode, string compcode, string dateformat)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();

            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("executeeditionwise_ratioentry", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcompcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@peditioncode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@peditioncode"].Value = editioncode;

                objSqlCommand.Parameters.Add("@Pdateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Pdateformat"].Value = dateformat;


                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objSqlConnection.Close();

            }

        }

        public DataSet saveeditionratio(string compcode, string userid, string maineditioncode, string subeditionname, string pubcode, string subeditioncode, string percentage, string effectivedate, string dateformat)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();

            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("saveeditionwise_ratioentry", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcompcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@puserid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@puserid"].Value = userid;

                objSqlCommand.Parameters.Add("@ppubcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ppubcode"].Value = pubcode;

                objSqlCommand.Parameters.Add("@pmaineditioncode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pmaineditioncode"].Value = maineditioncode;

                objSqlCommand.Parameters.Add("@psubeditionname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@psubeditionname"].Value = subeditionname;

                objSqlCommand.Parameters.Add("@psubeditioncode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@psubeditioncode"].Value = subeditioncode;

                objSqlCommand.Parameters.Add("@ppercentage", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ppercentage"].Value = percentage;

                //objSqlCommand.Parameters.Add("@peffectivedate", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@peffectivedate"].Value = effectivedate;

                objSqlCommand.Parameters.Add("@peffectivedate", SqlDbType.VarChar);
                if (effectivedate == "" || effectivedate == null)
                {
                    objSqlCommand.Parameters["@peffectivedate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = effectivedate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        effectivedate = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = effectivedate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        effectivedate = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@peffectivedate"].Value = effectivedate;
                }



               

                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objSqlConnection.Close();

            }

        }

        public DataSet updateeditionratio(string compcode, string userid, string subeditioncode, string maineditioncode, string percentage, string effectivedate, string dateformat)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();

            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("modifyeditionwise_ratioentry", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcompcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@puserid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@puserid"].Value = userid;

                objSqlCommand.Parameters.Add("@psubeditioncode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@psubeditioncode"].Value = subeditioncode;

                objSqlCommand.Parameters.Add("@pmaineditioncode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pmaineditioncode"].Value = maineditioncode;

                objSqlCommand.Parameters.Add("@ppercentage1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ppercentage1"].Value = percentage;


                objSqlCommand.Parameters.Add("@peffectivedate", SqlDbType.VarChar);
                if (effectivedate == "" || effectivedate == null)
                {
                    objSqlCommand.Parameters["@peffectivedate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = effectivedate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        effectivedate = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = effectivedate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        effectivedate = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@peffectivedate"].Value = effectivedate;
                }



                
                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objSqlConnection.Close();

            }

        }

        public DataSet editiondelete(string editioncode, string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();

            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("deleteeditionwise_ratioentry", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcompcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@pmaineditioncode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pmaineditioncode"].Value = editioncode;


                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objSqlConnection.Close();

            }

        }

        public DataSet chkduplicacy(string editioncode, string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();

            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("checkduplicayforEWRE", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcompcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@peditioncode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@peditioncode"].Value = editioncode;


                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objSqlConnection.Close();

            }

        }
    }
}
