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
    /// Summary description for BarterMaster
    /// </summary>
    public class BarterMaster:connection
    {
        public BarterMaster()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataSet save(string compcode, string name, string code, string accode, string userid)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("BarterMaster_Save", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@Comp_Code", SqlDbType.VarChar);
                com.Parameters["@Comp_Code"].Value = compcode;

                com.Parameters.Add("@Bat_Name", SqlDbType.VarChar);
                com.Parameters["@Bat_Name"].Value = name;

                com.Parameters.Add("@Bat_Code", SqlDbType.VarChar);
                com.Parameters["@Bat_Code"].Value = code;

                com.Parameters.Add("@Bat_Ac_Code", SqlDbType.VarChar);
                com.Parameters["@Bat_Ac_Code"].Value = accode;

                 com.Parameters.Add("@userId", SqlDbType.VarChar);
                com.Parameters["@userId"].Value = userid;

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


        public DataSet modify(string compcode, string name, string code, string accode, string userid)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("BarterMaster_Modify", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@Comp_Code", SqlDbType.VarChar);
                com.Parameters["@Comp_Code"].Value = compcode;

                com.Parameters.Add("@Bat_Name", SqlDbType.VarChar);
                com.Parameters["@Bat_Name"].Value = name;

                com.Parameters.Add("@Bat_Code", SqlDbType.VarChar);
                com.Parameters["@Bat_Code"].Value = code;

                com.Parameters.Add("@Bat_Ac_Code", SqlDbType.VarChar);
                com.Parameters["@Bat_Ac_Code"].Value = accode;

                com.Parameters.Add("@userId", SqlDbType.VarChar);
                com.Parameters["@userId"].Value = userid;

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

        public DataSet fpnl()
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("BarterMaster_FPNL", ref con);
                com.CommandType = CommandType.StoredProcedure;

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

        public DataSet batdelete(string code)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("BarterMaster_Delete", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@Bat_Code", SqlDbType.VarChar);
                com.Parameters["@Bat_Code"].Value = code;

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
        public DataSet Auto(string str)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("BarterMaster_Auto", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@str", SqlDbType.VarChar);
                com.Parameters["@str"].Value = str;

                com.Parameters.Add("code", SqlDbType.VarChar);
                com.Parameters["code"].Value = str;

                //com.Parameters.Add("@Comp_Code", SqlDbType.VarChar);
                //com.Parameters.Add["@Comp_Code"].value = compcode;
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

        public DataSet execute(string compcode, string name, string code, string accode, string userid)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com=GetCommand("BarterMaster_Exe",ref con);
                com.CommandType = CommandType.StoredProcedure;

               com.Parameters.Add("@Comp_Code", SqlDbType.VarChar);
                com.Parameters["@Comp_Code"].Value = compcode;

                com.Parameters.Add("@Bat_Name", SqlDbType.VarChar);
                com.Parameters["@Bat_Name"].Value = name;

                com.Parameters.Add("@Bat_Code", SqlDbType.VarChar);
                com.Parameters["@Bat_Code"].Value = code;

                com.Parameters.Add("@Bat_Ac_Code", SqlDbType.VarChar);
                com.Parameters["@Bat_Ac_Code"].Value = accode;

                com.Parameters.Add("@userId", SqlDbType.VarChar);
                com.Parameters["@userId"].Value = userid;

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
        public DataSet chkcode(string code)
        {
            {
                SqlConnection con;
                SqlCommand com;
                con = GetConnection();
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();
                try
                {
                    con.Open();
                    com = GetCommand("BarterMaster_Chk", ref con);
                    com.CommandType = CommandType.StoredProcedure;

                    com.Parameters.Add("@Bat_Code", SqlDbType.VarChar);
                    com.Parameters["@Bat_Code"].Value = code;

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
        //public DataSet execute1(string compcode, string name, string code, string accode, string userid)
        //{
        //    SqlConnection con;
        //    SqlCommand com;
        //    con = GetConnection();
        //    SqlDataAdapter da = new SqlDataAdapter();
        //    DataSet ds = new DataSet();
        //    try
        //    {
        //        con.Open();
        //        com = GetCommand("BarterMaster_Exe1", ref con);
        //        com.CommandType = CommandType.StoredProcedure;

        //        com.Parameters.Add("@Comp_Code", SqlDbType.VarChar);
        //        com.Parameters["@Comp_Code"].Value = compcode;

        //        com.Parameters.Add("@Bat_Name", SqlDbType.VarChar);
        //        com.Parameters["@Bat_Name"].Value = name;

        //        com.Parameters.Add("@Bat_Code", SqlDbType.VarChar);
        //        com.Parameters["@Bat_Code"].Value = code;

        //        com.Parameters.Add("@Bat_Ac_Code", SqlDbType.VarChar);
        //        com.Parameters["@Bat_Ac_Code"].Value = accode;

        //        com.Parameters.Add("@userId", SqlDbType.VarChar);
        //        com.Parameters["@userId"].Value = userid;

        //        da.SelectCommand = com;
        //        da.Fill(ds);
        //        return (ds);
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
            
        }

    }
