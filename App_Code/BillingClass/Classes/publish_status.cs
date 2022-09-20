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
/// Summary description for publish_status
/// </summary>
 namespace NewAdbooking.BillingClass.Classes
{
/// <summary>
/// 
/// </summary>
public class publish_status : NewAdbooking.Classes.connection
{
	public publish_status()
	{
		//
		// TODO: Add constructor logic here
		//
	}
 /*  public DataSet updatestatusnew(string bookingid, string insertion, string edition)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("updatestausnew_sambad.updatestausnew_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm4 = new OracleParameter("ciobookid", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = bookingid;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm7 = new OracleParameter("insertion", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = insertion;
                objOraclecommand.Parameters.Add(prm7);


                OracleParameter prm6 = new OracleParameter("edition", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = edition;
                objOraclecommand.Parameters.Add(prm6);



                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                objOracleConnection.Close();
            }

        }
    */
    public DataSet bindrevenuecenter(string compcode)
    {
        SqlConnection objSqlConnection;
        SqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        SqlDataAdapter objSqlDataAdapter;
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("Bindrevenuecenter", ref objSqlConnection);
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

    public DataSet updatestatusnew(string bookingid, string insertion, string edition)
    {
        SqlConnection objSqlConnection;
        SqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        SqlDataAdapter objSqlDataAdapter;
        DataSet objDataSet = new DataSet();

        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("updatestausnew_sambad", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            objSqlCommand.Parameters.Add("@ciobookid", SqlDbType.VarChar);
            objSqlCommand.Parameters["@ciobookid"].Value = bookingid;

            objSqlCommand.Parameters.Add("@insertion", SqlDbType.VarChar);
            objSqlCommand.Parameters["@insertion"].Value = insertion;

            objSqlCommand.Parameters.Add("@edition", SqlDbType.VarChar);
            objSqlCommand.Parameters["@edition"].Value = edition; 
            

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
  /*  public DataSet websp_updatestatus(string dateformat, string tilldate, string fromdate, string Adtype, string rev)
    {
        OracleConnection con;
        OracleCommand com;
        DataSet objDataSet = new DataSet();
        con = GetConnection();
        OracleDataAdapter da = new OracleDataAdapter();
        try
        {

            con.Open();


            com = GetCommand("Websp_updatestatus_sambad", ref con);
            com.CommandType = CommandType.StoredProcedure;



            OracleParameter prm11 = new OracleParameter("todate", OracleType.VarChar);
            prm11.Direction = ParameterDirection.Input;
          {
           if (tilldate == "" || tilldate == null)
   {
    prm11.Value = system.DBNull.Value;
            
            else
            {
                if (dateformat == "dd/mm/yyyy")
                {
                    string[] arr = tilldate.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    tilldate = mm + "/" + dd + "/" + yy;


                }
                prm11.Value = Convert.ToDateTime(tilldate).ToString("dd-MMMM-yyyy");


            }
            com.Parameters.Add(prm11);


            OracleParameter prm12 = new OracleParameter("fromdate", OracleType.VarChar);
            prm12.Direction = ParameterDirection.Input;
            if (fromdate == "" || fromdate == null)
            {
                prm12.Value = System.DBNull.Value;

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
                prm12.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");

            }
            com.Parameters.Add(prm12);

            OracleParameter prm31 = new OracleParameter("Adtype", OracleType.VarChar);
            prm31.Direction = ParameterDirection.Input;
            if (Adtype != "0")
            {
                prm31.Value = Adtype;
            }
            else
            {
                prm31.Value = System.DBNull.Value;
            }
            com.Parameters.Add(prm31);
            OracleParameter prm131 = new OracleParameter("rev", OracleType.VarChar);
            prm131.Direction = ParameterDirection.Input;
            if (rev != "0")
            {
                prm131.Value = rev;
            }
            else
            {
                prm131.Value = System.DBNull.Value;
            }
            com.Parameters.Add(prm131);


            com.Parameters.Add("p_recordset", OracleType.Cursor);
            com.Parameters["p_recordset"].Direction = ParameterDirection.Output;



            da.SelectCommand = com;
            da.Fill(objDataSet);
            return objDataSet;
        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            CloseConnection(ref con);
        }
    }

    public DataSet websp_updatestatus(string dateformat, string tilldate, string fromdate, string Adtype, string rev)
    {
        SqlConnection objsqlcon = new SqlConnection();
        SqlCommand objsqlcom;
        objsqlcon = GetConnection();
        SqlDataAdapter objsqldap = new SqlDataAdapter();
        DataSet objdataset = new DataSet();

        try
        {

            objsqlcon.Open();
            objsqlcom = GetCommand("Websp_Updatestatus_s", ref objsqlcon);
            objsqlcom.CommandType = CommandType.StoredProcedure;

            objsqlcom.Parameters.Add("@todate", SqlDbType.VarChar);
            if (tilldate == "" || tilldate == null)
            {
                objsqlcom.Parameters["@todate"].Value = System.DBNull.Value; ;
            }

            else
            {
                if (dateformat == "dd/mm/yyyy")
                {
                    string[] arr = tilldate.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    tilldate = mm + "/" + dd + "/" + yy;


                }
                objsqlcom.Parameters["@todate"].Value = Convert.ToDateTime(tilldate).ToString("dd-MMMM-yyyy");


            }


            objsqlcom.Parameters.Add("@fromdate", SqlDbType.VarChar);
            if (fromdate == "" || fromdate == null)
            {
                objsqlcom.Parameters["@fromdate"].Value = System.DBNull.Value;

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
                objsqlcom.Parameters["@fromdate"].Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");

            }
            objsqlcom.Parameters.Add("@Adtype", SqlDbType.VarChar);
            if (Adtype != "0")
            {
                objsqlcom.Parameters["@Adtype"].Value = Adtype;
            }
            else
            {
                objsqlcom.Parameters["@Adtype"].Value = System.DBNull.Value;
            }

            objsqlcom.Parameters.Add("@rev", SqlDbType.VarChar);
            if (rev != "0")
            {
                objsqlcom.Parameters["@rev"].Value = rev;
            }
            else
            {
                objsqlcom.Parameters["@rev"].Value = System.DBNull.Value;
            }


            return objdataset;



        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            CloseConnection(ref objsqlcon);
        }
    }
*/


              public DataSet websp_updatestatus(string dateformat, string tilldate, string fromdate, string Adtype, string rev)

          {
              SqlConnection con;
              SqlCommand com;
              con = GetConnection();
              SqlDataAdapter da = new SqlDataAdapter();
              DataSet ds = new DataSet();
              try
              {



                  con.Open();
                  com = GetCommand("test", ref con);
                  com.CommandType = CommandType.StoredProcedure;



                 com.Parameters.Add("@todate", SqlDbType.VarChar);
                if (tilldate == "" || tilldate == null)
                {
                    com.Parameters["@todate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = tilldate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        tilldate = mm + "/" + dd + "/" + yy;
                    }

                    com.Parameters["@todate"].Value = tilldate;
                }


                com.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (fromdate == "" || fromdate == null)
                {
                    com.Parameters["@fromdate"].Value = System.DBNull.Value;
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

                    com.Parameters["@fromdate"].Value = fromdate;
                }


               



                com.Parameters.Add("@Adtype", SqlDbType.VarChar);
                if (Adtype != "0")
                {
                    com.Parameters["@Adtype"].Value = Adtype;
                }
                else
                {
                    com.Parameters["@Adtype"].Value = System .DBNull .Value;
                }


                com.Parameters.Add("@rev", SqlDbType.VarChar);
                if (rev != "0")
                {
                    com.Parameters["@rev"].Value = rev;
                }
                else
                {
                    com.Parameters["@rev"].Value = System .DBNull .Value;
                }




                  da.SelectCommand = com;
                  da.Fill(ds);
                  return ds;
              }
              catch (Exception ex)
              {
                  throw (ex);
              }
              finally
              {
                  CloseConnection(ref con);
              }
          }
  





    }
}
 

