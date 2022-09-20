using System;
using System.Data;
using System.Data.SqlClient ;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace NewAdbooking.Classes
{
    public class AdBookingIssue1 : connection
    {
        public AdBookingIssue1()
        {
            //
            // TODO: Add constructor logic here
            //
        }
//*********************************************************************************************************
        // *************This function is used to bind publication *****************//

        public DataSet Adpub(string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Bind_PubName", ref objSqlConnection);
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
//********************************************************************************************************
  
        public DataSet pubcenter()
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Bind_PubCentName", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                //objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@compcode"].Value = compcode;

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
 //**********************************************************************************************************


        public DataSet pubedition(string pubname,string pubcenter)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Bind_EdiName", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@edit", SqlDbType.VarChar);
                objSqlCommand.Parameters["@edit"].Value = pubname;

                objSqlCommand.Parameters.Add("@center", SqlDbType.VarChar);
                objSqlCommand.Parameters["@center"].Value = pubcenter;

                //objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@compcode"].Value = compcode;

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

//**********************************************************************************************************       

        public DataSet pubsupply(string pubname, string pubedit)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("bindsuppliment", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = pubname;

                objSqlCommand.Parameters.Add("@editioncode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@editioncode"].Value = pubedit;

                //objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@compcode"].Value = compcode;

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
//***********************************************************************************************************
   


//**********************************************************************************************************
        //This code is used for insert data into database

        public DataSet insertad(string adpub, string adcenter, string adedition, string adsuplement, int adbook, int adpages, string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("insertadbookissue", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@pubname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pubname"].Value = adpub;

                objSqlCommand.Parameters.Add("@pubcenter ", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pubcenter "].Value = adcenter;


                objSqlCommand.Parameters.Add("@edition ", SqlDbType.VarChar);
                objSqlCommand.Parameters["@edition "].Value = adedition;

                objSqlCommand.Parameters.Add("@suplement ", SqlDbType.VarChar);
                objSqlCommand.Parameters["@suplement "].Value = adsuplement;

                objSqlCommand.Parameters.Add("@bookvolume", SqlDbType.Int);
                objSqlCommand.Parameters["@bookvolume"].Value = adbook;

                objSqlCommand.Parameters.Add("@noofpages", SqlDbType.Int);
                objSqlCommand.Parameters["@noofpages"].Value = adpages;

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
//*********************************************************************************************************

        public DataSet executead(string adpub, string adcenter, string adedition, string adsup,string compcode,string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("executeadbookissue", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@pubname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pubname"].Value = adpub;


                objSqlCommand.Parameters.Add("@pubcenter", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pubcenter"].Value =adcenter;


                objSqlCommand.Parameters.Add("@edition", SqlDbType.VarChar);
                objSqlCommand.Parameters["@edition"].Value = adedition;


                objSqlCommand.Parameters.Add("@supplement", SqlDbType.VarChar);
                objSqlCommand.Parameters["@supplement"].Value =adsup;


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
//**********************************************************************************************************
     //this code is used for check duplicate case;

        public DataSet duplicate(string adpub, string adcenter, string adedition, string adsuplement, string compcode,string userid)
        {
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            con = GetConnection();
            SqlDataAdapter sda = new SqlDataAdapter();
            DataSet ds = new DataSet();

            try
            {
                con.Open();
                cmd = GetCommand("adduplicate", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@publication", SqlDbType.VarChar);
                cmd.Parameters["@publication"].Value = adpub;

                cmd.Parameters.Add("@center", SqlDbType.VarChar);
                cmd.Parameters["@center"].Value = adcenter;

                cmd.Parameters.Add("@edition", SqlDbType.VarChar);
                cmd.Parameters["@edition"].Value = adedition;

                cmd.Parameters.Add("@supplement", SqlDbType.VarChar);
                cmd.Parameters["@supplement"].Value = adsuplement;

                cmd.Parameters.Add("@compcode", SqlDbType.VarChar);
                cmd.Parameters["@compcode"].Value = compcode;

                cmd.Parameters.Add("@userid", SqlDbType.VarChar);
                if (userid == "")
                {
                    cmd.Parameters["@userid"].Value = System.DBNull.Value;
                }
                else
                {
                    cmd.Parameters["@userid"].Value = userid;
                }

                sda.SelectCommand = cmd;
                sda.Fill(ds);
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
//*******************************************************************************************************

 //*******************************************************************************************************

        public DataSet deletead(string adpub, string adcenter, string adedition, string adsup, string compcode,string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("deleteadbooking", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@pubname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pubname"].Value = adpub;

                objSqlCommand.Parameters.Add("@pubcenter", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pubcenter"].Value = adcenter;

                objSqlCommand.Parameters.Add("@pubedition", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pubedition"].Value = adedition;

                objSqlCommand.Parameters.Add("@pubsup", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pubsup"].Value = adsup;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;


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
//*********************************************************************************************************
        public DataSet updatead(string adpub, string adcenter, string adedition, string adsup,string adbook,string adpages, string compcode,string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("updateadbooking", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@pubname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pubname"].Value = adpub;

                objSqlCommand.Parameters.Add("@pubcenter", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pubcenter"].Value = adcenter;

                objSqlCommand.Parameters.Add("@pubedition", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pubedition"].Value = adedition;

                objSqlCommand.Parameters.Add("@pubsup", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pubsup"].Value = adsup;

                objSqlCommand.Parameters.Add("@pubbook", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pubbook"].Value = adbook;

                objSqlCommand.Parameters.Add("@pubpages", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pubpages"].Value = adpages;



                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;


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
//********************************************************************************************************
    }
}
