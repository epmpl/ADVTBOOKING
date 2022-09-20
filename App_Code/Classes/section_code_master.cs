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
/// Summary description for section_code_master
/// </summary>
namespace NewAdbooking.Classes
{

    public class section_code_master : connection
    {
        public section_code_master()
        {
            //
            // TODO: Add constructor logic here
            //
        }



        public DataSet sectionsave(string code, string name)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("insertinto_sectioncode", ref con);
                com.CommandType = CommandType.StoredProcedure;


                com.Parameters.Add("@pSection_code", SqlDbType.VarChar);
                com.Parameters["@pSection_code"].Value = code;

                com.Parameters.Add("@pSection_name", SqlDbType.VarChar);
                com.Parameters["@pSection_name"].Value = name;

                


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

        public DataSet atmmodify(string code, string name)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("section_Modify", ref con);
                com.CommandType = CommandType.StoredProcedure;


                com.Parameters.Add("@pSection_code", SqlDbType.VarChar);
                com.Parameters["@pSection_code"].Value = code;

                com.Parameters.Add("@pSection_name", SqlDbType.VarChar);
                com.Parameters["@pSection_name"].Value = name;



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


        public DataSet atmdelete(string code, string name)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("sectioncode_Delete_p", ref con);
                com.CommandType = CommandType.StoredProcedure;


                com.Parameters.Add("@pSection_code", SqlDbType.VarChar);
                com.Parameters["@pSection_code"].Value = code;

                com.Parameters.Add("@pSection_name", SqlDbType.VarChar);
                com.Parameters["@pSection_name"].Value = name;



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

        public DataSet sectioncodeexcute( string code, string name)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("Section_code_execute_p", ref con);
                com.CommandType = CommandType.StoredProcedure;


                com.Parameters.Add("@pSection_code", SqlDbType.VarChar);
                com.Parameters["@pSection_code"].Value = code;

                com.Parameters.Add("@pSection_name", SqlDbType.VarChar);
                com.Parameters["@pSection_name"].Value = name;



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

        public DataSet sectioncodeexcute1(string code, string name)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("Section_code_execute_p", ref con);
                com.CommandType = CommandType.StoredProcedure;


                com.Parameters.Add("@pSection_code", SqlDbType.VarChar);
                com.Parameters["@pSection_code"].Value = code;

                com.Parameters.Add("@pSection_name", SqlDbType.VarChar);
                com.Parameters["@pSection_name"].Value = name;




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

        public DataSet atmfpnl()
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("atmfpnl", ref con);
                com.CommandType = CommandType.StoredProcedure;

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



        public DataSet chkatmcode(string seccode, string secname)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("sectioncheck_p1", ref con);
                com.CommandType = CommandType.StoredProcedure;


                com.Parameters.Add("@pSection_code", SqlDbType.VarChar);
                com.Parameters["@pSection_code"].Value = seccode;

                com.Parameters.Add("@pSection_name", SqlDbType.VarChar);
                com.Parameters["@pSection_name"].Value = secname;




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