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

namespace NewAdbooking.Classes
{
    public class getReferenceFile : connection
    {
        public getReferenceFile()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataSet clsReferenceFile(string compcode, string pubdate, string pubcode, string centercode, string editioncode, string suppcode, string dateformat, string center,string auditad,string includeuom,string excludeuom,string includecat,string excludecat)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_getReferencefile", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@pubdate", SqlDbType.VarChar);
                if (dateformat == "dd/mm/yyyy")
                {

                    if (pubdate.IndexOf('-') < 0)
                    {
                        string[] arr = pubdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        pubdate = mm + "/" + dd + "/" + yy;

                    }

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

                objSqlCommand.Parameters.Add("@pubcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pubcode"].Value = pubcode;

                objSqlCommand.Parameters.Add("@centercode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@centercode"].Value = centercode;

                objSqlCommand.Parameters.Add("@editioncode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@editioncode"].Value = editioncode;

                objSqlCommand.Parameters.Add("@suppcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@suppcode"].Value = suppcode;

                objSqlCommand.Parameters.Add("@logincenter", SqlDbType.VarChar);
                objSqlCommand.Parameters["@logincenter"].Value = center;

                objSqlCommand.Parameters.Add("@auditad", SqlDbType.VarChar);
                objSqlCommand.Parameters["@auditad"].Value = auditad;

                objSqlCommand.Parameters.Add("@includeuom", SqlDbType.VarChar);
                objSqlCommand.Parameters["@includeuom"].Value = includeuom;

                objSqlCommand.Parameters.Add("@excludeuom", SqlDbType.VarChar);
                objSqlCommand.Parameters["@excludeuom"].Value = excludeuom;

                objSqlCommand.Parameters.Add("@includeadcat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@includeadcat"].Value = includecat;

                objSqlCommand.Parameters.Add("@excludeadcat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@excludeadcat"].Value = excludecat;

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
        public DataSet clsReferenceFileDict(string compcode, string pubdate, string pubcode, string centercode, string editioncode, string suppcode, string dateformat, string center)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();    
                objSqlCommand = GetCommand("websp_getReferencefile", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@pubdate", SqlDbType.VarChar);
                if (dateformat == "dd/mm/yyyy")
                {

                    if (pubdate.IndexOf('-') < 0)
                    {
                        string[] arr = pubdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        pubdate = mm + "/" + dd + "/" + yy;

                    }

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

                objSqlCommand.Parameters.Add("@pubcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pubcode"].Value = pubcode;

                objSqlCommand.Parameters.Add("@centercode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@centercode"].Value = centercode;

                objSqlCommand.Parameters.Add("@editioncode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@editioncode"].Value = editioncode;

                objSqlCommand.Parameters.Add("@suppcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@suppcode"].Value = suppcode;

                objSqlCommand.Parameters.Add("@logincenter", SqlDbType.VarChar);
                objSqlCommand.Parameters["@logincenter"].Value = center;
                
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

        //updateclassified(updatestatus);
        public DataSet updateclassified(string cioid, string insertion, string edition)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_getReferenceupdate", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@cioid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cioid"].Value = cioid;

                objSqlCommand.Parameters.Add("@insertion_no", SqlDbType.VarChar);
                objSqlCommand.Parameters["@insertion_no"].Value = insertion;

                objSqlCommand.Parameters.Add("@edition", SqlDbType.VarChar);
                objSqlCommand.Parameters["@edition"].Value = edition;


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

        public DataSet clsReferenceFilepackage(string compcode, string pubdate, string dateformat, string center, string auditad, string includeuom, string excludeuom, string includecat, string excludecat, string package)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_getReferencefile_pkg", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@pubdate", SqlDbType.VarChar);
                if (dateformat == "dd/mm/yyyy")
                {

                    if (pubdate.IndexOf('-') < 0)
                    {
                        string[] arr = pubdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        pubdate = mm + "/" + dd + "/" + yy;

                    }

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


                objSqlCommand.Parameters.Add("@p_package", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_package"].Value = package;

                objSqlCommand.Parameters.Add("@logincenter", SqlDbType.VarChar);
                objSqlCommand.Parameters["@logincenter"].Value = center;

                objSqlCommand.Parameters.Add("@auditad", SqlDbType.VarChar);
                objSqlCommand.Parameters["@auditad"].Value = auditad;

                objSqlCommand.Parameters.Add("@includeuom", SqlDbType.VarChar);
                objSqlCommand.Parameters["@includeuom"].Value = includeuom;

                objSqlCommand.Parameters.Add("@excludeuom", SqlDbType.VarChar);
                objSqlCommand.Parameters["@excludeuom"].Value = excludeuom;

                objSqlCommand.Parameters.Add("@includeadcat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@includeadcat"].Value = includecat;

                objSqlCommand.Parameters.Add("@excludeadcat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@excludeadcat"].Value = excludecat;

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

        //public DataSet bindEdition_ref(string pub)
        //{
        //    SqlConnection objSqlConnection;
        //    SqlCommand objSqlCommand;
        //    objSqlConnection = GetConnection();
        //    SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
        //    DataSet objDataSet = new DataSet();
        //    try
        //    {
        //        objSqlConnection.Open();
        //        objSqlCommand = GetCommand("bindEdition_ref", ref objSqlConnection);
        //        objSqlCommand.CommandType = CommandType.StoredProcedure;

        //        objSqlCommand.Parameters.Add("@pub", SqlDbType.VarChar);
        //        objSqlCommand.Parameters["@pub"].Value = pub;

          

        //        objSqlDataAdapter.SelectCommand = objSqlCommand;
        //        objSqlDataAdapter.Fill(objDataSet);

        //        return objDataSet;

        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //    finally
        //    {
        //        CloseConnection(ref objSqlConnection);
        //    }
        //}

    }
}