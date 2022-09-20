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
/// Summary description for PublisherMaster
/// </summary>

namespace NewAdbooking.Classes
{

    public class PublisherMaster : connection
    {
        public PublisherMaster()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataSet pagedes(string compcode)
        {
            SqlConnection con;
            SqlCommand cmd;
            con = GetConnection();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();
                cmd = GetCommand("drpcty", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@compcode", SqlDbType.VarChar);
                cmd.Parameters["@compcode"].Value = compcode;


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


        public DataSet pubcity(string country)
        {
            SqlConnection con;
            SqlCommand cmd;
            con = GetConnection();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();
                cmd = GetCommand("drpcity", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@country", SqlDbType.VarChar);
                cmd.Parameters["@country"].Value = country;


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

        public DataSet pubregion(string city)
        {
            SqlConnection con;
            SqlCommand cmd;
            con = GetConnection();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();
                cmd = GetCommand("drpregion", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@city", SqlDbType.VarChar);
                cmd.Parameters["@city"].Value = city;


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


        public DataSet pubzone(string city)
        {
            SqlConnection con;
            SqlCommand cmd;
            con = GetConnection();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();
                cmd = GetCommand("drpzone", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@city", SqlDbType.VarChar);
                cmd.Parameters["@city"].Value = city;


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

        public DataSet pubstate(string city)
        {
            SqlConnection con;
            SqlCommand cmd;
            con = GetConnection();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();
                cmd = GetCommand("drpstate", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@city", SqlDbType.VarChar);
                cmd.Parameters["@city"].Value = city;


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

        public DataSet autocodeDUP(string str)
        {
            SqlConnection con;
            SqlCommand cmd;
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            con = GetConnection();

            try
            {
                con.Open();
                cmd = GetCommand("publisherautocodeDup", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                //cmd.Parameters.Add("@compcode", SqlDbType.VarChar);
                //cmd.Parameters["@compcode"].Value = compcode;

                cmd.Parameters.Add("@str", SqlDbType.VarChar);
                cmd.Parameters["@str"].Value = str;

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

        public DataSet autocode(string str)
        {
            SqlConnection con;
            SqlCommand cmd;
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            con = GetConnection();

            try
            {
                con.Open();
                cmd = GetCommand("publisherautocode", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                //cmd.Parameters.Add("@compcode", SqlDbType.VarChar);
                //cmd.Parameters["@compcode"].Value = compcode;

                cmd.Parameters.Add("@str", SqlDbType.VarChar);
                cmd.Parameters["@str"].Value = str;

                cmd.Parameters.Add("@cod", SqlDbType.VarChar);
                cmd.Parameters["@cod"].Value = str;

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
        
        public DataSet pmexecute(string pubcode, string pubname, string pubalias,string address, string country, string state, string city, string district, string zone, string region, string pubtype, string sharing, string compcode)
        {
            SqlConnection con;
            SqlCommand cmd;
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            con = GetConnection();

            try
            {
                con.Open();
                cmd = GetCommand("pmexe", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@pubcode", SqlDbType.VarChar);
                cmd.Parameters["@pubcode"].Value = pubcode;

                cmd.Parameters.Add("@pubname", SqlDbType.VarChar);
                cmd.Parameters["@pubname"].Value = pubname;

                cmd.Parameters.Add("@pubalias", SqlDbType.VarChar);
                cmd.Parameters["@pubalias"].Value = pubalias;

                cmd.Parameters.Add("@address", SqlDbType.VarChar);
                cmd.Parameters["@address"].Value = address;

                cmd.Parameters.Add("@country", SqlDbType.VarChar);
                cmd.Parameters["@country"].Value = country;

                cmd.Parameters.Add("@state", SqlDbType.VarChar);
                cmd.Parameters["@state"].Value = state;

                cmd.Parameters.Add("@city", SqlDbType.VarChar);
                cmd.Parameters["@city"].Value = city;

                cmd.Parameters.Add("@district", SqlDbType.VarChar);
                cmd.Parameters["@district"].Value = district;

                cmd.Parameters.Add("@zone", SqlDbType.VarChar);
                cmd.Parameters["@zone"].Value = zone;

                cmd.Parameters.Add("@region", SqlDbType.VarChar);
                cmd.Parameters["@region"].Value = region;

                cmd.Parameters.Add("@pubtype", SqlDbType.VarChar);
                cmd.Parameters["@pubtype"].Value = pubtype;

                cmd.Parameters.Add("@sharing", SqlDbType.VarChar);
                cmd.Parameters["@sharing"].Value = sharing;

                cmd.Parameters.Add("@compcode", SqlDbType.VarChar);
                cmd.Parameters["@compcode"].Value = compcode;

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

        public DataSet pmdelete(string pubcode, string compcode)
        {
            SqlConnection con;
            SqlCommand cmd;
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            con = GetConnection();
            try
            {
                con.Open();
                cmd = GetCommand("pmdel", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@pubcode", SqlDbType.VarChar);
                cmd.Parameters["@pubcode"].Value = pubcode;

                cmd.Parameters.Add("@compcode", SqlDbType.VarChar);
                cmd.Parameters["@compcode"].Value = compcode;

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


        public DataSet chkcode(string pubcode,string pubname, string compcode)
        {
            SqlConnection con;
            SqlCommand cmd;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                cmd = GetCommand("pmchkcode", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@compcode", SqlDbType.VarChar);
                cmd.Parameters["@compcode"].Value = compcode;

                cmd.Parameters.Add("@pubname", SqlDbType.VarChar);
                cmd.Parameters["@pubname"].Value = pubname;


                cmd.Parameters.Add("@pubcode", SqlDbType.VarChar);
                cmd.Parameters["@pubcode"].Value = pubcode;

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

        public DataSet pmupdate(string pubcode, string pubname, string pubalias, string address, string country, string state, string city, string district, string zone, string region, string pubtype, string sharing, string compcode)
         {
             SqlConnection con;
             SqlCommand cmd;
             con = GetConnection();
             SqlDataAdapter da = new SqlDataAdapter();
             DataSet ds = new DataSet();

             try
             {
                 con.Open();
                 cmd = GetCommand("pmmodify", ref con);
                 cmd.CommandType = CommandType.StoredProcedure;

                 cmd.Parameters.Add("@pubcode", SqlDbType.VarChar);
                 cmd.Parameters["@pubcode"].Value = pubcode;

                 cmd.Parameters.Add("@pubname", SqlDbType.VarChar);
                 cmd.Parameters["@pubname"].Value = pubname;

                 cmd.Parameters.Add("@pubalias", SqlDbType.VarChar);
                 cmd.Parameters["@pubalias"].Value = pubalias;

                 cmd.Parameters.Add("@address", SqlDbType.VarChar);
                 cmd.Parameters["@address"].Value = address;

                 cmd.Parameters.Add("@country", SqlDbType.VarChar);
                 cmd.Parameters["@country"].Value = country;

                 cmd.Parameters.Add("@state", SqlDbType.VarChar);
                 cmd.Parameters["@state"].Value = state;

                 cmd.Parameters.Add("@city", SqlDbType.VarChar);
                 cmd.Parameters["@city"].Value = city;

                 cmd.Parameters.Add("@district", SqlDbType.VarChar);
                 cmd.Parameters["@district"].Value = district;

                 cmd.Parameters.Add("@zone", SqlDbType.VarChar);
                 cmd.Parameters["@zone"].Value = zone;

                 cmd.Parameters.Add("@region", SqlDbType.VarChar);
                 cmd.Parameters["@region"].Value = region;

                 cmd.Parameters.Add("@pubtype", SqlDbType.VarChar);
                 cmd.Parameters["@pubtype"].Value = pubtype;

                 cmd.Parameters.Add("@sharing", SqlDbType.VarChar);
                 cmd.Parameters["@sharing"].Value = sharing;

                 cmd.Parameters.Add("@compcode", SqlDbType.VarChar);
                 cmd.Parameters["@compcode"].Value = compcode;



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

        public DataSet insertedvalue(string pubcode,string pubname,string pubalias,string address,string country,string state,string city,string district,string zone,string region,string pubtype,string sharing,string userid,string compcode)
        {
            SqlConnection con;
            SqlCommand cmd;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                cmd = GetCommand("pminsert", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@pubcode", SqlDbType.VarChar);
                cmd.Parameters["@pubcode"].Value = pubcode;

                cmd.Parameters.Add("@pubname", SqlDbType.VarChar);
                cmd.Parameters["@pubname"].Value = pubname;

                cmd.Parameters.Add("@pubalias", SqlDbType.VarChar);
                cmd.Parameters["@pubalias"].Value = pubalias;

                cmd.Parameters.Add("@address", SqlDbType.VarChar);
                cmd.Parameters["@address"].Value = address;

                cmd.Parameters.Add("@country", SqlDbType.VarChar);
                cmd.Parameters["@country"].Value = country;

                cmd.Parameters.Add("@state", SqlDbType.VarChar);
                cmd.Parameters["@state"].Value = state;

                cmd.Parameters.Add("@city", SqlDbType.VarChar);
                cmd.Parameters["@city"].Value = city;

                cmd.Parameters.Add("@district", SqlDbType.VarChar);
                cmd.Parameters["@district"].Value = district;

                cmd.Parameters.Add("@zone", SqlDbType.VarChar);
                cmd.Parameters["@zone"].Value = zone;

                cmd.Parameters.Add("@region", SqlDbType.VarChar);
                cmd.Parameters["@region"].Value = region;

                cmd.Parameters.Add("@pubtype", SqlDbType.VarChar);
                cmd.Parameters["@pubtype"].Value = pubtype;

                cmd.Parameters.Add("@sharing", SqlDbType.VarChar);
                cmd.Parameters["@sharing"].Value = sharing;

                cmd.Parameters.Add("@compcode", SqlDbType.VarChar);
                cmd.Parameters["@compcode"].Value = compcode;

                cmd.Parameters.Add("@userid", SqlDbType.VarChar);
                cmd.Parameters["@userid"].Value = userid;

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