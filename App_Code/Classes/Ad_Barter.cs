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
/// Summary description for Ad_Barter
/// </summary>
namespace NewAdbooking.Classes
{

    public class Ad_Barter : connection
    {
        public Ad_Barter()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataSet uombind(string compcode, string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("uomadsize", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;


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

        public DataSet getPubCenter(string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();

            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("publication_proc", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

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

        public DataSet getQBC(string pubcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();

            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_QBC", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("@pubcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pubcode"].Value = pubcode;
              
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


        public DataSet bindagency(string compcode, string agency)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();

            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("bindagencyforxls", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@agency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agency"].Value = agency;

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

        public DataSet savebarter(string compcode, string userid, string unitcode, string branchcode, string agencycode, string subagencycode, string bartercode, string barterdesc, string barterstdt, string barterendt, string ProdAmt, string barterAmt, string barterArea, string Remarks, string dateformat, string productdesc, string barteruom, string barterkilldate, string strbook, string client)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();

            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Adbarter_save", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@unitcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@unitcode"].Value = unitcode;

                objSqlCommand.Parameters.Add("@branchcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@branchcode"].Value = branchcode;

                objSqlCommand.Parameters.Add("@agencode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencode"].Value = agencycode;

                objSqlCommand.Parameters.Add("@subagencode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@subagencode"].Value = subagencycode;

                objSqlCommand.Parameters.Add("@bartercode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@bartercode"].Value = bartercode;

                objSqlCommand.Parameters.Add("@barterdesc", SqlDbType.VarChar);
                objSqlCommand.Parameters["@barterdesc"].Value = barterdesc;

                objSqlCommand.Parameters.Add("@barterstdt", SqlDbType.VarChar);
                if (barterstdt == "" || barterstdt == null)
                {
                   objSqlCommand.Parameters["@barterstdt"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = barterstdt.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        barterstdt = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = barterstdt.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        barterstdt = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@barterstdt"].Value = barterstdt;
                }



                objSqlCommand.Parameters.Add("@barterendt", SqlDbType.VarChar);
                if (barterendt == "" || barterendt == null)
                {
                    objSqlCommand.Parameters["@barterendt"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = barterendt.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        barterendt = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = barterendt.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        barterendt = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@barterendt"].Value = barterendt;
                }


                objSqlCommand.Parameters.Add("@barterkilldate", SqlDbType.VarChar);
                if (barterkilldate == "" || barterkilldate == null)
                {
                    objSqlCommand.Parameters["@barterkilldate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = barterkilldate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        barterkilldate = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = barterkilldate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        barterkilldate = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@barterkilldate"].Value = barterkilldate;
                }
              

                objSqlCommand.Parameters.Add("@prodamt", SqlDbType.VarChar);
                objSqlCommand.Parameters["@prodamt"].Value = ProdAmt;

                objSqlCommand.Parameters.Add("@barteramt", SqlDbType.VarChar);
                objSqlCommand.Parameters["@barteramt"].Value = barterAmt;

                objSqlCommand.Parameters.Add("@barterarea", SqlDbType.VarChar);
                objSqlCommand.Parameters["@barterarea"].Value = barterArea;

                objSqlCommand.Parameters.Add("@remarks", SqlDbType.VarChar);
                objSqlCommand.Parameters["@remarks"].Value = Remarks;

                objSqlCommand.Parameters.Add("@productdesc", SqlDbType.VarChar);
                objSqlCommand.Parameters["@productdesc"].Value = productdesc;

                objSqlCommand.Parameters.Add("@barteruom", SqlDbType.VarChar);
                objSqlCommand.Parameters["@barteruom"].Value = barteruom;

                objSqlCommand.Parameters.Add("@strbook", SqlDbType.VarChar);
                objSqlCommand.Parameters["@strbook"].Value = strbook;

                objSqlCommand.Parameters.Add("@client", SqlDbType.VarChar);
                objSqlCommand.Parameters["@client"].Value = client;

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


        public DataSet updatebarter(string compcode, string userid, string unitcode, string branchcode, string agencycode, string subagencycode, string bartercode, string barterdesc, string barterstdt, string barterendt, string ProdAmt, string barterAmt, string barterArea, string Remarks, string dateformat, string productdesc, string barteruom, string barterkilldate, string strbook, string client)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();

            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Adbarter_modify", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@unitcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@unitcode"].Value = unitcode;

                objSqlCommand.Parameters.Add("@branchcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@branchcode"].Value = branchcode;

                objSqlCommand.Parameters.Add("@agencode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencode"].Value = agencycode;

                objSqlCommand.Parameters.Add("@subagencode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@subagencode"].Value = subagencycode;

                objSqlCommand.Parameters.Add("@bartercode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@bartercode"].Value = bartercode;

                objSqlCommand.Parameters.Add("@barterdesc", SqlDbType.VarChar);
                objSqlCommand.Parameters["@barterdesc"].Value = barterdesc;

                objSqlCommand.Parameters.Add("@barterstdt", SqlDbType.VarChar);
                if (barterstdt == "" || barterstdt == null)
                {
                    objSqlCommand.Parameters["@barterstdt"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = barterstdt.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        barterstdt = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = barterstdt.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        barterstdt = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@barterstdt"].Value = barterstdt;
                }



                objSqlCommand.Parameters.Add("@barterendt", SqlDbType.VarChar);
                if (barterendt == "" || barterendt == null)
                {
                    objSqlCommand.Parameters["@barterendt"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = barterendt.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        barterendt = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = barterendt.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        barterendt = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@barterendt"].Value = barterendt;
                }


                objSqlCommand.Parameters.Add("@barterkilldate", SqlDbType.VarChar);
                if (barterkilldate == "" || barterkilldate == null)
                {
                    objSqlCommand.Parameters["@barterkilldate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = barterkilldate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        barterkilldate = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = barterkilldate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        barterkilldate = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@barterkilldate"].Value = barterkilldate;
                }
                
                objSqlCommand.Parameters.Add("@prodamt", SqlDbType.VarChar);
                objSqlCommand.Parameters["@prodamt"].Value = ProdAmt;

                objSqlCommand.Parameters.Add("@barteramt", SqlDbType.VarChar);
                objSqlCommand.Parameters["@barteramt"].Value = barterAmt;

                objSqlCommand.Parameters.Add("@barterarea", SqlDbType.VarChar);
                objSqlCommand.Parameters["@barterarea"].Value = barterArea;

                objSqlCommand.Parameters.Add("@remarks", SqlDbType.VarChar);
                objSqlCommand.Parameters["@remarks"].Value = Remarks;

                objSqlCommand.Parameters.Add("@productdesc", SqlDbType.VarChar);
                objSqlCommand.Parameters["@productdesc"].Value = productdesc;

                objSqlCommand.Parameters.Add("@barteruom", SqlDbType.VarChar);
                objSqlCommand.Parameters["@barteruom"].Value = barteruom;

                objSqlCommand.Parameters.Add("@strbook", SqlDbType.VarChar);
                objSqlCommand.Parameters["@strbook"].Value = strbook;

                objSqlCommand.Parameters.Add("@client", SqlDbType.VarChar);
                objSqlCommand.Parameters["@client"].Value = client;

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

        public DataSet checkdupbarter(string compcode, string unitcode, string branchcode, string bartercode, string barterdesc, string agencycode, string subagencycode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();

            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Adbarter_checkduplicacy", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@bartercode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@bartercode"].Value = bartercode;

                objSqlCommand.Parameters.Add("@unitcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@unitcode"].Value = unitcode;

                objSqlCommand.Parameters.Add("@branchcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@branchcode"].Value = branchcode;


                objSqlCommand.Parameters.Add("@barterdesc", SqlDbType.VarChar);
                objSqlCommand.Parameters["@barterdesc"].Value = barterdesc;

                objSqlCommand.Parameters.Add("@agencycode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencycode"].Value = agencycode;

                objSqlCommand.Parameters.Add("@agencysubcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencysubcode"].Value = subagencycode;

              
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

        public DataSet barterexecute(string compcode, string unitcode, string branchcode, string bartercode, string barterdesc, string barterstdt, string barterendt, string barterkilldate, string productdesc, string agencycode, string subagencycode, string strbook, string client)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();

            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("AdBarter_Exe", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@bartercode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@bartercode"].Value = bartercode;

                objSqlCommand.Parameters.Add("@unitcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@unitcode"].Value = unitcode;

                objSqlCommand.Parameters.Add("@branchcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@branchcode"].Value = branchcode;


                objSqlCommand.Parameters.Add("@barterdesc", SqlDbType.VarChar);
                objSqlCommand.Parameters["@barterdesc"].Value = barterdesc;


                objSqlCommand.Parameters.Add("@productdesc", SqlDbType.VarChar);
                objSqlCommand.Parameters["@productdesc"].Value = productdesc;

                objSqlCommand.Parameters.Add("@barterstdt", SqlDbType.VarChar);
                objSqlCommand.Parameters["@barterstdt"].Value = barterstdt;

                objSqlCommand.Parameters.Add("@barterendt", SqlDbType.VarChar);
                objSqlCommand.Parameters["@barterendt"].Value = barterendt;

                objSqlCommand.Parameters.Add("@barterkilldate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@barterkilldate"].Value = barterkilldate;


                objSqlCommand.Parameters.Add("@agencycode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencycode"].Value = agencycode;


                objSqlCommand.Parameters.Add("@subagencycode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@subagencycode"].Value = subagencycode;

                objSqlCommand.Parameters.Add("@strbook", SqlDbType.VarChar);
                objSqlCommand.Parameters["@strbook"].Value = strbook;

                objSqlCommand.Parameters.Add("@client", SqlDbType.VarChar);
                objSqlCommand.Parameters["@client"].Value = client;

                              
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


        public void barterdelete(string bartercode, string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Adbarter_delete", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@bartercode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@bartercode"].Value = bartercode;

                objSqlCommand.ExecuteNonQuery();

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


        //--------------autogenerate-------------------//
        public DataSet barterautocode(string str, string compcode, string unitcode, string branchcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();

            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("autoabartercode", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@str", SqlDbType.VarChar);
                objSqlCommand.Parameters["@str"].Value = str;

                objSqlCommand.Parameters.Add("@cod", SqlDbType.VarChar);
                if (str.Length > 2)
                {
                    objSqlCommand.Parameters["@cod"].Value = str.Substring(0, 2);
                }
                else
                {
                    objSqlCommand.Parameters["@cod"].Value = str;
                }
                

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@unitcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@unitcode"].Value = unitcode;

                objSqlCommand.Parameters.Add("@branchcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@branchcode"].Value = branchcode;


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