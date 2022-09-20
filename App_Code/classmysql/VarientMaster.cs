using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using MySql.Data ;
using MySql.Data .MySqlClient ;
namespace NewAdbooking.classmysql
{
    /// <summary>
    /// Summary description for VarientMaster
    /// </summary>
    public class VarientMaster:connection
    {
        public VarientMaster()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataSet productdes(string compcode)
        {
            MySqlConnection con;
            MySqlCommand cmd;
            con = GetConnection();
            DataSet ds = new DataSet();
            MySqlDataAdapter da = new MySqlDataAdapter();

            try
            {
                con.Open();
                cmd = GetCommand("drpbrand_drpbrand_p", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("compcode", MySqlDbType.VarChar);
                cmd.Parameters["compcode"].Value = compcode;


                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection(ref con);
            }
        }
        //Check code
        public DataSet chkcode(string code, string compcode)
        {
            MySqlConnection con;
            MySqlCommand cmd;
            con = GetConnection();
            DataSet ds = new DataSet();
            MySqlDataAdapter da = new MySqlDataAdapter();
            try
            {
                con.Open();
                cmd = GetCommand("chkvarientcode_chkvarientcode_p", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("compcode", MySqlDbType.VarChar);
                cmd.Parameters["compcode"].Value = compcode;

                cmd.Parameters.Add("code", MySqlDbType.VarChar);
                cmd.Parameters["code"].Value = code;


                da.SelectCommand = cmd;
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

        //Insert the value
        public DataSet insertedvalue(string drpbrand, string varientcode, string varientname, string varientalias, string compcode, string userid)
        {
            MySqlConnection con;
            MySqlCommand cmd;
            con = GetConnection();
            DataSet ds = new DataSet();
            MySqlDataAdapter da = new MySqlDataAdapter();
            try
            {
                con.Open();
                cmd = GetCommand("varientinsert_varientinsert_p", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("compcode", MySqlDbType.VarChar);
                cmd.Parameters["compcode"].Value = compcode;

                cmd.Parameters.Add("varientcode", MySqlDbType.VarChar);
                cmd.Parameters["varientcode"].Value = varientcode;

                cmd.Parameters.Add("varientname", MySqlDbType.VarChar);
                cmd.Parameters["varientname"].Value = varientname;

                cmd.Parameters.Add("varientalias", MySqlDbType.VarChar);
                cmd.Parameters["varientalias"].Value = varientalias;

                cmd.Parameters.Add("userid", MySqlDbType.VarChar);
                cmd.Parameters["userid"].Value = userid;

                cmd.Parameters.Add("drpbrand", MySqlDbType.VarChar);
                cmd.Parameters["drpbrand"].Value = drpbrand;


                da.SelectCommand = cmd;
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
        //Auto generated code
        public DataSet autocode(string str, string brand)
        {
            MySqlConnection con;
            MySqlCommand cmd;
            con = GetConnection();
            DataSet ds = new DataSet();
            MySqlDataAdapter da = new MySqlDataAdapter();

            try
            {
                con.Open();
                cmd = GetCommand("varientautocode_varientautocode_p", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                //cmd.Parameters.Add("compcode", MySqlDbType.VarChar);
                //cmd.Parameters["compcode"].Value = compcode;

                cmd.Parameters.Add("str", MySqlDbType.VarChar);
                cmd.Parameters["str"].Value = str;

                cmd.Parameters.Add("cod", MySqlDbType.VarChar);
                if (str.Length > 2)
                {
                    cmd.Parameters["cod"].Value = str.Substring(0, 2);
                }
                else
                {
                    cmd.Parameters["cod"].Value = str;

                }

               // cmd.Parameters.Add("brand1", MySqlDbType.VarChar);
                //cmd.Parameters["brand1"].Value = brand;
                
                da.SelectCommand = cmd;
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
        //Execute Value
        public DataSet prosubexecute(string drpprodes, string varientcode, string varientname, string varientalias, string compcode)
        {
            MySqlConnection con;
            MySqlCommand cmd;
            con = GetConnection();
            DataSet ds = new DataSet();
            MySqlDataAdapter da = new MySqlDataAdapter();

            try
            {
                con.Open();
                cmd = GetCommand("varientexe_varientexe_p", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("drpbrand", MySqlDbType.VarChar);
                cmd.Parameters["drpbrand"].Value = drpprodes;

                cmd.Parameters.Add("varientcode", MySqlDbType.VarChar);
                cmd.Parameters["varientcode"].Value = varientcode;

                cmd.Parameters.Add("varientname", MySqlDbType.VarChar);
                cmd.Parameters["varientname"].Value = varientname;

                cmd.Parameters.Add("varientalias", MySqlDbType.VarChar);
                cmd.Parameters["varientalias"].Value = varientalias;

                cmd.Parameters.Add("compcode", MySqlDbType.VarChar);
                cmd.Parameters["compcode"].Value = compcode;

                da.SelectCommand = cmd;
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
        //Delete The Value
        public DataSet deleteproduct(string varientcode, string compcode)
        {
            MySqlConnection con;
            MySqlCommand cmd;
            con = GetConnection();
            DataSet ds = new DataSet();
            MySqlDataAdapter da = new MySqlDataAdapter();

            try
            {
                con.Open();
                cmd = GetCommand("varientdel_varientdel_p", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("varientcode", MySqlDbType.VarChar);
                cmd.Parameters["varientcode"].Value = varientcode;

                cmd.Parameters.Add("compcode", MySqlDbType.VarChar);
                cmd.Parameters["compcode"].Value = compcode;

                da.SelectCommand = cmd;
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
        //Modify The Value
        public DataSet updatepro(string drpprodes, string varientcode, string varientname, string varientalias, string compcode)
        {

            MySqlConnection con;
            MySqlCommand cmd;
            con = GetConnection();
            DataSet ds = new DataSet();
            MySqlDataAdapter da = new MySqlDataAdapter();

            try
            {
                con.Open();
                cmd = GetCommand("varientmodify_varientmodify_p", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("drpbrand", MySqlDbType.VarChar);
                cmd.Parameters["drpbrand"].Value = drpprodes;

                cmd.Parameters.Add("varientcode", MySqlDbType.VarChar);
                cmd.Parameters["varientcode"].Value = varientcode;

                cmd.Parameters.Add("varientname", MySqlDbType.VarChar);
                cmd.Parameters["varientname"].Value = varientname;

                cmd.Parameters.Add("varientalias", MySqlDbType.VarChar);
                cmd.Parameters["varientalias"].Value = varientalias;

                cmd.Parameters.Add("compcode", MySqlDbType.VarChar);
                cmd.Parameters["compcode"].Value = compcode;


                da.SelectCommand = cmd;
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