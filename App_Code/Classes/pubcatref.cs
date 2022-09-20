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
/// Summary description for pubcatref
/// </summary>
/// 
namespace NewAdbooking.Classes
{
    public class pubcatref:connection
    {
        public pubcatref()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataSet chkpubcatname(string compcode, string pubname, string catname, string subcatname, string refname)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {

                objSqlConnection.Open();
                objSqlCommand = GetCommand("chkpubcatname", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode1"].Value = compcode;


                objSqlCommand.Parameters.Add("@pubname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pubname"].Value = pubname;


                objSqlCommand.Parameters.Add("@catname1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@catname1"].Value = catname;

                objSqlCommand.Parameters.Add("@subcatname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@subcatname"].Value = subcatname;

                objSqlCommand.Parameters.Add("@refname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@refname"].Value = refname;



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



        public DataSet savedata(string compcode, string pubname, string catname, string subcatname, string refname)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {

                objSqlConnection.Open();
                objSqlCommand = GetCommand("savepubcatref", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode1"].Value = compcode;


                objSqlCommand.Parameters.Add("@pubname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pubname"].Value = pubname;


                objSqlCommand.Parameters.Add("@catname1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@catname1"].Value = catname;

                objSqlCommand.Parameters.Add("@subcatname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@subcatname"].Value = subcatname;

                objSqlCommand.Parameters.Add("@refname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@refname"].Value = refname;



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


        public DataSet pubcatexecute(string compcode, string pubname, string catname, string subcatname, string refname)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {

                objSqlConnection.Open();
                objSqlCommand = GetCommand("exepubcatref", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode1"].Value = compcode;


                objSqlCommand.Parameters.Add("@pubname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pubname"].Value = pubname;


                objSqlCommand.Parameters.Add("@catname1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@catname1"].Value = catname;

                objSqlCommand.Parameters.Add("@subcatname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@subcatname"].Value = System.DBNull.Value;

                objSqlCommand.Parameters.Add("@refname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@refname"].Value = System.DBNull.Value;



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


        public DataSet pubcatdelete(string compcode, string pubname, string catname, string subcatname)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {

                objSqlConnection.Open();
                objSqlCommand = GetCommand("delpubcatref", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode1"].Value = compcode;


                objSqlCommand.Parameters.Add("@pubname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pubname"].Value = pubname;


                objSqlCommand.Parameters.Add("@catname1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@catname1"].Value = catname;

                objSqlCommand.Parameters.Add("@subcatname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@subcatname"].Value = subcatname;

                //objSqlCommand.Parameters.Add("@refname", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@refname"].Value = refname;



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




        public DataSet updatepubcat(string compcode, string pubname, string catname, string subcatname, string refname)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {

                objSqlConnection.Open();
                objSqlCommand = GetCommand("updatepubcatref", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode1"].Value = compcode;


                objSqlCommand.Parameters.Add("@pubname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pubname"].Value = pubname;


                objSqlCommand.Parameters.Add("@catname1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@catname1"].Value = catname;

                objSqlCommand.Parameters.Add("@subcatname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@subcatname"].Value = subcatname;

                objSqlCommand.Parameters.Add("@refname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@refname"].Value = refname;



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

        //===================================*********** Funcion to Insert, Update , Delete Caption ***********=====================//




        public DataSet CAPTION_INS_UPD_DELF(string compcode, string padtype, string caption, string trxtype, string puserid, string PCAPTION_CODE)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {

                objSqlConnection.Open();
                objSqlCommand = GetCommand("ADCAPTION_INS_UPD_DEL", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

              

               

                objSqlCommand.Parameters.Add("@PCOMP_CODE", SqlDbType.VarChar);
                objSqlCommand.Parameters["@PCOMP_CODE"].Value = compcode;


         

                objSqlCommand.Parameters.Add("@PADTYPE_CODE", SqlDbType.VarChar);


                if (padtype == "" || padtype=="0")
                {
                    objSqlCommand.Parameters["@PADTYPE_CODE"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@PADTYPE_CODE"].Value = padtype;

                }

             

                objSqlCommand.Parameters.Add("@PCAPTION", SqlDbType.VarChar);
                 objSqlCommand.Parameters["@PCAPTION"].Value = caption;

                objSqlCommand.Parameters.Add("@PUSERID", SqlDbType.VarChar);
                objSqlCommand.Parameters["@PUSERID"].Value = puserid;

                objSqlCommand.Parameters.Add("@PTRN_TYPE", SqlDbType.VarChar);
                objSqlCommand.Parameters["@PTRN_TYPE"].Value = trxtype;


                objSqlCommand.Parameters.Add("@PCAPTION_CODE", SqlDbType.VarChar);
                objSqlCommand.Parameters["@PCAPTION_CODE"].Value = PCAPTION_CODE;

                objSqlCommand.Parameters.Add("@PEXTRA1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@PEXTRA1"].Value = System.DBNull.Value;

                objSqlCommand.Parameters.Add("@PEXTRA2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@PEXTRA2"].Value = System.DBNull.Value;

                objSqlCommand.Parameters.Add("@PEXTRA3", SqlDbType.VarChar);
                objSqlCommand.Parameters["@PEXTRA3"].Value = System.DBNull.Value;

                objSqlCommand.Parameters.Add("@PEXTRA4", SqlDbType.VarChar);
                objSqlCommand.Parameters["@PEXTRA4"].Value = System.DBNull.Value;




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

        public DataSet capexecute(string compcode, string adtype, string capcode, string capname, string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {

                objSqlConnection.Open();
                objSqlCommand = GetCommand("AD_CAPTION_EXEC", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;





                objSqlCommand.Parameters.Add("@PCOMP_CODE", SqlDbType.VarChar);
                objSqlCommand.Parameters["@PCOMP_CODE"].Value = compcode;




                objSqlCommand.Parameters.Add("@PAD_TYPE", SqlDbType.VarChar);


                if (adtype == "" || adtype == "0")
                {
                    objSqlCommand.Parameters["@PAD_TYPE"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@PAD_TYPE"].Value = adtype;

                }



                objSqlCommand.Parameters.Add("@PCAPTION_CODE", SqlDbType.VarChar);
                if (capcode == "" || capcode == "0")
                {
                    objSqlCommand.Parameters["@PCAPTION_CODE"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@PCAPTION_CODE"].Value = capname;

                }
          

                objSqlCommand.Parameters.Add("@PCAPTION_NAME", SqlDbType.VarChar);
                if (capname == "" || capname == "0")
                {
                    objSqlCommand.Parameters["@PCAPTION_NAME"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@PCAPTION_NAME"].Value = capname;

                }


                objSqlCommand.Parameters.Add("@PUSERID", SqlDbType.VarChar);
                objSqlCommand.Parameters["@PUSERID"].Value = userid;


              



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





    }
}