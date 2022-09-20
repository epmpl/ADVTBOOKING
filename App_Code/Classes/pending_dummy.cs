using System;
using System.Data;
using System.Configuration;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using System.Data.SqlClient;

/// <summary>
/// Summary description for pending_dummy
/// </summary>
/// 
namespace NewAdbooking.Classes
{
    public class pending_dummy : connection
    {
        public pending_dummy()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        //public DataSet packagebind_NEW(string compcode, string userid)
        //{
        //    SqlConnection con;
        //    SqlCommand com;
        //    con = GetConnection();
        //    SqlDataAdapter da = new SqlDataAdapter();
        //    DataSet ds = new DataSet();
        //    try
        //    {


        //        con.Open();
        //        com = GetCommand("Bindpackage_new", ref con);
        //        com.CommandType = CommandType.StoredProcedure;

        //        com.Parameters.Add("@compcode", SqlDbType.VarChar);
        //        com.Parameters["@compcode"].Value = compcode;

        //        com.Parameters.Add("@userid", SqlDbType.VarChar);
        //        com.Parameters["@userid"].Value = userid;



        //        da.SelectCommand = com;
        //        da.Fill(ds);
        //        return ds;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //    finally
        //    {
        //        CloseConnection(ref con);
        //    }
        //}


        public DataSet adtypbind(string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {

                objSqlConnection.Open();
                objSqlCommand = GetCommand("advtypbind", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

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





        public DataSet bindgrid(string compcode, string pubcenter, string adtype, string pubfrdate, string pubtodate, string publcode, string edtncode, string suplcode, string reason, string dateformat, string userid)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("pending_for_dummy", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                com.Parameters["@pcompcode"].Value = compcode;


                com.Parameters.Add("@ppubcenter", SqlDbType.VarChar);
                if (pubcenter != "All" && pubcenter != "")
                {
                    com.Parameters["@ppubcenter"].Value = pubcenter;
                }
                else
                {
                    com.Parameters["@ppubcenter"].Value = System.DBNull.Value;
                }

                com.Parameters.Add("@padtype", SqlDbType.VarChar);
                if (adtype != "0"&& adtype != "")
                {
                    com.Parameters["@padtype"].Value = adtype;
                }
                else
                {
                    com.Parameters["@padtype"].Value = System.DBNull.Value;
                }


                com.Parameters.Add("@ppubfrdate", SqlDbType.VarChar);

                if (pubfrdate == "" || pubfrdate == null)
                {
                    com.Parameters["@ppubdate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = pubfrdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        pubfrdate = mm + "/" + dd + "/" + yy;
                    }

                    com.Parameters["@ppubfrdate"].Value = pubfrdate;
                }

                com.Parameters.Add("@ppubtodate", SqlDbType.VarChar);


                if (pubtodate == "" || pubtodate == null)
                {
                    com.Parameters["@ppubtodate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = pubtodate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        pubtodate = mm + "/" + dd + "/" + yy;
                    }

                    com.Parameters["@ppubtodate"].Value = pubtodate;
                }
              

                com.Parameters.Add("@ppublcode", SqlDbType.VarChar);
                if (publcode != "0" && publcode != "")
                {
                    com.Parameters["@ppublcode"].Value = publcode;
                }
                else
                {
                    com.Parameters["@ppublcode"].Value = System.DBNull.Value;
                }


                com.Parameters.Add("@pedtncode", SqlDbType.VarChar);
                if (edtncode != "0" && edtncode != "")
                {
                    com.Parameters["@pedtncode"].Value = edtncode;
                }
                else
                {
                    com.Parameters["@pedtncode"].Value = System.DBNull.Value;
                }


                com.Parameters.Add("@psuplcode", SqlDbType.VarChar);
                if (suplcode != "0"&& suplcode != "")
                {
                    com.Parameters["@psuplcode"].Value = suplcode;
                }
                else
                {
                    com.Parameters["@psuplcode"].Value = System.DBNull.Value;
                }



                com.Parameters.Add("@preason", SqlDbType.VarChar);
                if (reason != "0" && reason != "")
                {
                    com.Parameters["@preason"].Value = reason;
                }
                else
                {
                    com.Parameters["@preason"].Value = System.DBNull.Value;
                }


                com.Parameters.Add("@pdateformat", SqlDbType.VarChar);
                if (dateformat != "0" && dateformat != "")
                {
                    com.Parameters["@pdateformat"].Value = dateformat;
                }
                else
                {
                    com.Parameters["@pdateformat"].Value = System.DBNull.Value;
                }


                com.Parameters.Add("@puserid", SqlDbType.VarChar);
                if (userid != "0" && userid != "")
                {
                    com.Parameters["@puserid"].Value = userid;
                }
                else
                {
                    com.Parameters["@puserid"].Value = System.DBNull.Value;
                }

                com.Parameters.Add("@pextra1", SqlDbType.VarChar);
                com.Parameters["@pextra1"].Value = System.DBNull.Value;

                com.Parameters.Add("@pextra2", SqlDbType.VarChar);
                com.Parameters["@pextra2"].Value = System.DBNull.Value;

                com.Parameters.Add("@pextra3", SqlDbType.VarChar);
                com.Parameters["@pextra3"].Value = System.DBNull.Value;

                com.Parameters.Add("@pextra4", SqlDbType.VarChar);
                com.Parameters["@pextra4"].Value = System.DBNull.Value;

                com.Parameters.Add("@pextra5", SqlDbType.VarChar);
                com.Parameters["@pextra5"].Value = System.DBNull.Value;


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
