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
    /// <summary>
    /// Summary description for CD_Upload
    /// </summary>
    public class CD_Upload : connection
    {
        public CD_Upload()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataSet secpubcodes(string compcode, string userid, string editioncode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
               
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Websp_Addsecpubs", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlDataAdapter = new SqlDataAdapter();



                objSqlCommand.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcompcode"].Value = compcode;

               


                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;





                objSqlCommand.Parameters.Add("@editioncode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@editioncode"].Value = editioncode;


              


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


         public DataSet secpubcode(string compcode, string userid)
        {
          


            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Websp_Addsecpub_P", ref objSqlConnection);
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






         public DataSet clsViewBooking_CD(string compcode, string pubdate, string pubcode, string centercode, string editioncode, string suppcode, string dateformat, string pageno)
         {
             
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                

                 objSqlConnection.Open();
                 objSqlCommand = GetCommand("websp_GetAdMaterial_CD", ref objSqlConnection);
                 objSqlCommand.CommandType = CommandType.StoredProcedure;
                 objSqlDataAdapter = new SqlDataAdapter();

                 objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                 objSqlCommand.Parameters["@compcode"].Value = compcode;

               

               


                 objSqlCommand.Parameters.Add("@pubdate", SqlDbType.VarChar);
                 if (pubdate == "" || pubdate == null)
                 {
                     objSqlCommand.Parameters["@pubdate"].Value = System.DBNull.Value;
                 }
                 else
                 {
                     if (dateformat == "dd/mm/yyyy")
                     {
                         string[] arr = pubdate.Split('/');
                         string dd = arr[0];
                         string mm = arr[1];
                         string yy = arr[2];
                         pubdate = mm + "/" + dd + "/" + yy;
                     }
                     else if (dateformat == "yyyy/mm/dd")
                     {
                         string[] arr = pubdate.Split('/');
                         string dd = arr[2];
                         string mm = arr[1];
                         string yy = arr[0];
                         pubdate = mm + "/" + dd + "/" + yy;
                     }
                     objSqlCommand.Parameters["@pubdate"].Value = pubdate;
                 }


                


                 objSqlCommand.Parameters.Add("@pubcode", SqlDbType.VarChar);
                 objSqlCommand.Parameters["@pubcode"].Value = pubcode;



              




                 objSqlCommand.Parameters.Add("@centercode", SqlDbType.VarChar);
                 objSqlCommand.Parameters["@centercode"].Value = centercode;

               


                 objSqlCommand.Parameters.Add("@editioncode", SqlDbType.VarChar);
                 objSqlCommand.Parameters["@editioncode"].Value = editioncode;


       




                 objSqlCommand.Parameters.Add("@suppcode", SqlDbType.VarChar);
                 objSqlCommand.Parameters["@suppcode"].Value = suppcode;






                 //OracleParameter prm7 = new OracleParameter("pageno", OracleType.VarChar, 50);
                 //prm7.Direction = ParameterDirection.Input;
                 //if (pageno == "")
                 //    prm7.Value = System.DBNull.Value;
                 //else
                 //    prm7.Value = pageno;
                 //objOraclecommand.Parameters.Add(prm7);

               


                 objSqlCommand.Parameters.Add("@pageno", SqlDbType.VarChar);
                 if ( pageno == "")
                     objSqlCommand.Parameters["@pageno"].Value = System.DBNull.Value;
                 else
                     objSqlCommand.Parameters["@pageno"].Value = pageno;


             

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




         public DataSet UpdateFilename_CD(string compcode, string fname, string idnum, string insnum, string insertid, string editioncode, string dateformat)
         {
             SqlConnection objSqlConnection;
             SqlCommand objSqlCommand;
             objSqlConnection = GetConnection();
             SqlDataAdapter objSqlDataAdapter;
             DataSet objDataSet = new DataSet();
             try
             {
                
                


                 objSqlConnection.Open();
                 objSqlCommand = GetCommand("websp_updatefilename_CD", ref objSqlConnection);
                 objSqlCommand.CommandType = CommandType.StoredProcedure;
                 objSqlDataAdapter = new SqlDataAdapter();

                 


                 objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                 objSqlCommand.Parameters["@compcode"].Value = compcode;





                 objSqlCommand.Parameters.Add("@fname", SqlDbType.VarChar);
                 objSqlCommand.Parameters["@fname"].Value = fname;


              



                 objSqlCommand.Parameters.Add("@idnum", SqlDbType.VarChar);
                 objSqlCommand.Parameters["@idnum"].Value = idnum;



               



                 objSqlCommand.Parameters.Add("@insnum", SqlDbType.VarChar);
                 objSqlCommand.Parameters["@insnum"].Value = insnum;







                 objSqlCommand.Parameters.Add("@insertid", SqlDbType.VarChar);
                 objSqlCommand.Parameters["@insertid"].Value = insertid;



                 objSqlCommand.Parameters.Add("@peditioncode", SqlDbType.VarChar);
                 objSqlCommand.Parameters["@peditioncode"].Value = editioncode;




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


         public DataSet editioncodes(string centercode, string userid, string pubcode)
         {
             SqlConnection objSqlConnection;
             SqlCommand objSqlCommand;
             objSqlConnection = GetConnection();
             SqlDataAdapter objSqlDataAdapter;
             DataSet objDataSet = new DataSet();
             try
             {
                
                
                 objSqlConnection.Open();
                 objSqlCommand = GetCommand("websp_addeditions", ref objSqlConnection);
                 objSqlCommand.CommandType = CommandType.StoredProcedure;
                 objSqlDataAdapter = new SqlDataAdapter();





                 objSqlCommand.Parameters.Add("@centercode", SqlDbType.VarChar);
                 objSqlCommand.Parameters["@centercode"].Value = centercode;


                 objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                 objSqlCommand.Parameters["@userid"].Value = userid;

                 objSqlCommand.Parameters.Add("@pubcode", SqlDbType.VarChar);
                 objSqlCommand.Parameters["@pubcode"].Value = pubcode;




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