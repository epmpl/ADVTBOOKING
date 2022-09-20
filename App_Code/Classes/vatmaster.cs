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
    /// <summary>
    /// Summary description for vatmaster
    /// </summary>
    public class vatmaster : connection
    {
        public vatmaster()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataSet vatsave(string compcode, string userid, string description, string vatrate, string fromdate, string todate, string grosstype,string orderno,string publicat,string edit)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();

            try
            {
                con.Open();
                com = GetCommand("vatsave", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@comp_code", SqlDbType.VarChar);
                com.Parameters["@comp_code"].Value = compcode;

                com.Parameters.Add("@userid", SqlDbType.VarChar);
                com.Parameters["@userid"].Value = userid;

                com.Parameters.Add("@vat_description", SqlDbType.VarChar);
                com.Parameters["@vat_description"].Value = description;

                com.Parameters.Add("@vat_rate", SqlDbType.VarChar);
                com.Parameters["@vat_rate"].Value = vatrate;

                com.Parameters.Add("@vat_from_date", SqlDbType.VarChar);
                com.Parameters["@vat_from_date"].Value = fromdate;


                com.Parameters.Add("@vat_to_date", SqlDbType.VarChar);
                com.Parameters["@vat_to_date"].Value = todate;

                com.Parameters.Add("@vat_gross_type", SqlDbType.VarChar);
                com.Parameters["@vat_gross_type"].Value = grosstype;

                //com.Parameters.Add("@vat_code", SqlDbType.VarChar);
                //com.Parameters["@vat_code"].Value = vatcode;


                com.Parameters.Add("@vat_order_no", SqlDbType.VarChar);
                com.Parameters["@vat_order_no"].Value = orderno;

                com.Parameters.Add("@publicat", SqlDbType.VarChar);
                com.Parameters["@publicat"].Value = publicat;

                com.Parameters.Add("@edit", SqlDbType.VarChar);
                com.Parameters["@edit"].Value = edit;

                da.SelectCommand = com;
                da.Fill(ds);
                return (ds);
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
        public DataSet dauto(string str)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("vat_Auto", ref con);
                com.CommandType = CommandType.StoredProcedure;

                
                com.Parameters.Add("@cod", SqlDbType.VarChar);
                com.Parameters["@cod"].Value = str;


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

        public DataSet vatexecute(string compcode, string userid, string description, string vatrate, string fromdate, string todate, string grosstype, string orderno)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();

            try
            {
                con.Open();
                com = GetCommand("Vat_Exe", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@comp_code", SqlDbType.VarChar);
                com.Parameters["@comp_code"].Value = compcode;

                com.Parameters.Add("@userid", SqlDbType.VarChar);
                com.Parameters["@userid"].Value = userid;

                com.Parameters.Add("@vat_description", SqlDbType.VarChar);
                com.Parameters["@vat_description"].Value = description;

                com.Parameters.Add("@vat_rate", SqlDbType.VarChar);
                com.Parameters["@vat_rate"].Value = vatrate;

                com.Parameters.Add("@vat_from_date", SqlDbType.VarChar);
                if (todate == "")
                {
                    com.Parameters["@vat_from_date"].Value = System.DBNull.Value;
                }
                else
                {
                    com.Parameters["@vat_from_date"].Value = Convert.ToDateTime(fromdate).ToString();
                }


                com.Parameters.Add("@vat_to_date", SqlDbType.VarChar);
                if (todate == "")
                {
                    com.Parameters["@vat_to_date"].Value = System.DBNull.Value;
                }
                else
                {
                    com.Parameters["@vat_to_date"].Value = Convert.ToDateTime(todate).ToString();
                }

                com.Parameters.Add("@vat_gross_type", SqlDbType.VarChar);
                com.Parameters["@vat_gross_type"].Value = grosstype;

                //com.Parameters.Add("@vat_code", SqlDbType.VarChar);
                //com.Parameters["@vat_code"].Value = vatcode;


                com.Parameters.Add("@vat_order_no", SqlDbType.VarChar);
                com.Parameters["@vat_order_no"].Value = orderno;

                da.SelectCommand = com;
                da.Fill(ds);
                return (ds);
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
        public DataSet vatchk(string description)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();

            try
            {
                con.Open();
                com = GetCommand("vat_Chk", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@vat_description", SqlDbType.VarChar);
                com.Parameters["@vat_description"].Value = description;

                //com.Parameters.Add("@vat_from_date", SqlDbType.VarChar);
                //com.Parameters["@vat_from_date"].Value = fromdate;


                //com.Parameters.Add("@vat_to_date", SqlDbType.VarChar);
                //com.Parameters["@vat_to_date"].Value = todate;

                //com.Parameters.Add("@vat_order_no", SqlDbType.VarChar);
                //com.Parameters["@vat_order_no"].Value = orderno;

                //com.Parameters.Add("@vat_code", SqlDbType.VarChar);
                //com.Parameters["@vat_code"].Value = vatcode;

                da.SelectCommand = com;
                da.Fill(ds);
                return (ds);
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
        public DataSet vatdelete(string compcode, string description, string fromdate, string todate, string publicat, string edit)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();

            try
            {
                con.Open();
                com = GetCommand("vat_delete", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@comp_code", SqlDbType.VarChar);
                com.Parameters["@comp_code"].Value = compcode;

                com.Parameters.Add("@vat_description", SqlDbType.VarChar);
                com.Parameters["@vat_description"].Value = description;

                com.Parameters.Add("@p_fromdate", SqlDbType.VarChar);
                com.Parameters["@p_fromdate"].Value = fromdate;

                com.Parameters.Add("@p_todate", SqlDbType.VarChar);
                com.Parameters["@p_todate"].Value = todate;

                com.Parameters.Add("@p_publicat", SqlDbType.VarChar);
                com.Parameters["@p_publicat"].Value = publicat;

                com.Parameters.Add("@p_edit", SqlDbType.VarChar);
                com.Parameters["@p_edit"].Value = edit;

                da.SelectCommand = com;
                da.Fill(ds);
                return (ds);
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
        public DataSet vatmodify(string compcode, string userid, string description, string vatrate, string fromdate, string todate, string grosstype, string orderno,string publicat,string edit)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();

            try
            {
                con.Open();
                com = GetCommand("vat_modify", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@comp_code", SqlDbType.VarChar);
                com.Parameters["@comp_code"].Value = compcode;

                com.Parameters.Add("@userid", SqlDbType.VarChar);
                com.Parameters["@userid"].Value = userid;

                com.Parameters.Add("@vat_description", SqlDbType.VarChar);
                com.Parameters["@vat_description"].Value = description;

                com.Parameters.Add("@vat_rate", SqlDbType.VarChar);
                com.Parameters["@vat_rate"].Value = vatrate;

                com.Parameters.Add("@vat_from_date", SqlDbType.VarChar);
                com.Parameters["@vat_from_date"].Value = fromdate;


                com.Parameters.Add("@vat_to_date", SqlDbType.VarChar);
                com.Parameters["@vat_to_date"].Value = todate;

                com.Parameters.Add("@vat_gross_type", SqlDbType.VarChar);
                com.Parameters["@vat_gross_type"].Value = grosstype;

                //com.Parameters.Add("@vat_code", SqlDbType.VarChar);
                //com.Parameters["@vat_code"].Value = vatcode;


                com.Parameters.Add("@vat_order_no", SqlDbType.VarChar);
                com.Parameters["@vat_order_no"].Value = orderno;

                com.Parameters.Add("@publicat", SqlDbType.VarChar);
                com.Parameters["@publicat"].Value = publicat;

                com.Parameters.Add("@edit", SqlDbType.VarChar);
                com.Parameters["@edit"].Value = edit;

                da.SelectCommand = com;
                da.Fill(ds);
                return (ds);
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

        public DataSet grosstype(string compcode)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();

            try
            {
                con.Open();
                com = GetCommand("vat_GrossType", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@comp_code", SqlDbType.VarChar);
                com.Parameters["@comp_code"].Value = compcode;

                //com.Parameters.Add("@userid", SqlDbType.VarChar);
                //com.Parameters["@userid"].Value = userid;


                da.SelectCommand = com;
                da.Fill(ds);
                return (ds);
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
        public DataSet chkdate(string description, string fromdate, string todate,string publicat,string edit)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();

            try
            {
                con.Open();
                com = GetCommand("vat_chkdate", ref con);
                com.CommandType = CommandType.StoredProcedure;

                // com.Parameters.Add("@comp_code", SqlDbType.VarChar);
                //com.Parameters["@comp_code"].Value = compcode;

                //com.Parameters.Add("@userid", SqlDbType.VarChar);
                //com.Parameters["@userid"].Value = userid;

                com.Parameters.Add("@vat_description", SqlDbType.VarChar);
                com.Parameters["@vat_description"].Value = description;

                //com.Parameters.Add("@vat_rate", SqlDbType.VarChar);
                //com.Parameters["@vat_rate"].Value = vatrate;

                com.Parameters.Add("@vat_from_date", SqlDbType.VarChar);
                com.Parameters["@vat_from_date"].Value = fromdate;


                com.Parameters.Add("@vat_to_date", SqlDbType.VarChar);
                com.Parameters["@vat_to_date"].Value = todate;

                com.Parameters.Add("@publicat", SqlDbType.VarChar);
                com.Parameters["@publicat"].Value = publicat;

                com.Parameters.Add("@edit", SqlDbType.VarChar);
                com.Parameters["@edit"].Value = edit;


                //com.Parameters.Add("@vat_order_no", SqlDbType.VarChar);
                //com.Parameters["@vat_order_no"].Value = orderno;

                da.SelectCommand = com;
                da.Fill(ds);
                return (ds);
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