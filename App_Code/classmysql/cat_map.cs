using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using MySql.Data;
using MySql.Data.MySqlClient;
namespace NewAdbooking.classmysql
{

    /// <summary>
    /// Summary description for cat_map
    /// </summary>
    public class cat_map : connection
    {
        public cat_map()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataSet mappingchk(string compcode, string sourceregion, string sourcevariable, string sourcecat1, string sourcecat2, string sourcecat3, string sourcecat4, string sourcecat5, string destedit, string destreg, string destvar, string destcat1, string destcat2, string destcat3, string destcat4, string destcat5)
        {

            MySqlConnection con;
            MySqlCommand com;
            con = GetConnection();
            MySqlDataAdapter da = new MySqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("websp_chkmapping", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("compcode", MySqlDbType.VarChar);
                com.Parameters["compcode"].Value = compcode;


                com.Parameters.Add("sourceregion", MySqlDbType.VarChar);
                com.Parameters["sourceregion"].Value = sourceregion;


                com.Parameters.Add("sourcevariable", MySqlDbType.VarChar);
                com.Parameters["sourcevariable"].Value = sourcevariable;


                com.Parameters.Add("sourcecat1", MySqlDbType.VarChar);
                com.Parameters["sourcecat1"].Value = sourcecat1;


                com.Parameters.Add("sourcecat2", MySqlDbType.VarChar);
                com.Parameters["sourcecat2"].Value = sourcecat2;


                com.Parameters.Add("sourcecat3", MySqlDbType.VarChar);
                com.Parameters["sourcecat3"].Value = sourcecat3;
                //,,,,,,,,,);

                com.Parameters.Add("sourcecat4", MySqlDbType.VarChar);
                com.Parameters["sourcecat4"].Value = sourcecat4;


                com.Parameters.Add("sourcecat5", MySqlDbType.VarChar);
                com.Parameters["sourcecat5"].Value = sourcecat5;


                com.Parameters.Add("destedit", MySqlDbType.VarChar);
                com.Parameters["destedit"].Value = destedit;


                com.Parameters.Add("destreg", MySqlDbType.VarChar);
                com.Parameters["destreg"].Value = destreg;


                com.Parameters.Add("destvar", MySqlDbType.VarChar);
                com.Parameters["destvar"].Value = destvar;


                com.Parameters.Add("destcat1", MySqlDbType.VarChar);
                com.Parameters["destcat1"].Value = destcat1;


                com.Parameters.Add("destcat2", MySqlDbType.VarChar);
                com.Parameters["destcat2"].Value = destcat2;


                com.Parameters.Add("destcat3", MySqlDbType.VarChar);
                com.Parameters["destcat3"].Value = destcat3;


                com.Parameters.Add("destcat4", MySqlDbType.VarChar);
                com.Parameters["destcat4"].Value = destcat4;

                com.Parameters.Add("destcat5", MySqlDbType.VarChar);
                com.Parameters["destcat5"].Value = destcat5;

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


        public DataSet mappingsave(string compcode, string sourceregion, string sourcevariable, string sourcecat1, string sourcecat2, string sourcecat3, string sourcecat4, string sourcecat5, string destedit, string destreg, string destvar, string destcat1, string destcat2, string destcat3, string destcat4, string destcat5)
        {
            MySqlConnection con;
            MySqlCommand com;
            con = GetConnection();
            MySqlDataAdapter da = new MySqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("websp_savemapping", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("compcode", MySqlDbType.VarChar);
                com.Parameters["compcode"].Value = compcode;


                com.Parameters.Add("sourceregion", MySqlDbType.VarChar);
                com.Parameters["sourceregion"].Value = sourceregion;


                com.Parameters.Add("sourcevariable", MySqlDbType.VarChar);
                com.Parameters["sourcevariable"].Value = sourcevariable;


                com.Parameters.Add("sourcecat1", MySqlDbType.VarChar);
                com.Parameters["sourcecat1"].Value = sourcecat1;


                com.Parameters.Add("sourcecat2", MySqlDbType.VarChar);
                if (sourcecat2 == "")
                {
                    sourcecat2 = "0";
                }
                com.Parameters["sourcecat2"].Value = sourcecat2;


                com.Parameters.Add("sourcecat3", MySqlDbType.VarChar);
                if (sourcecat3 == "")
                {
                    sourcecat3 = "0";
                }
                com.Parameters["sourcecat3"].Value = sourcecat3;
                //,,,,,,,,,);

                com.Parameters.Add("sourcecat4", MySqlDbType.VarChar);
                if (sourcecat4 == "")
                {
                    sourcecat4 = "0";
                }
                com.Parameters["sourcecat4"].Value = sourcecat4;


                com.Parameters.Add("sourcecat5", MySqlDbType.VarChar);
                if (sourcecat5 == "")
                {
                    sourcecat5 = "0";
                }
                com.Parameters["sourcecat5"].Value = sourcecat5;


                com.Parameters.Add("destedit", MySqlDbType.VarChar);
                com.Parameters["destedit"].Value = destedit;


                com.Parameters.Add("destreg", MySqlDbType.VarChar);
                com.Parameters["destreg"].Value = destreg;


                com.Parameters.Add("destvar", MySqlDbType.VarChar);
                com.Parameters["destvar"].Value = destvar;


                com.Parameters.Add("destcat1", MySqlDbType.VarChar);
                com.Parameters["destcat1"].Value = destcat1;
                if (destcat1 == "")
                {
                    destcat1 = "0";
                }


                com.Parameters.Add("destcat2", MySqlDbType.VarChar);
                if (destcat2 == "")
                {
                    destcat2 = "0";
                }
                com.Parameters["destcat2"].Value = destcat2;


                com.Parameters.Add("destcat3", MySqlDbType.VarChar);
                if (destcat3 == "")
                {
                    destcat3 = "0";
                }
                com.Parameters["destcat3"].Value = destcat3;


                com.Parameters.Add("destcat4", MySqlDbType.VarChar);
                if (destcat4 == "")
                {
                    destcat4 = "0";
                }
                com.Parameters["destcat4"].Value = destcat4;

                com.Parameters.Add("destcat5", MySqlDbType.VarChar);
                if (destcat5 == "")
                {
                    destcat5 = "0";
                }
                com.Parameters["destcat5"].Value = destcat5;

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


        public DataSet modifychk(string compcode, string sourceregion, string sourcevariable, string sourcecat1, string sourcecat2, string sourcecat3, string sourcecat4, string sourcecat5, string destedit, string destreg, string destvar, string destcat1, string destcat2, string destcat3, string destcat4, string destcat5, string primary)
        {
            MySqlConnection con;
            MySqlCommand com;
            con = GetConnection();
            MySqlDataAdapter da = new MySqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("websp_modifychk", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("compcode", MySqlDbType.VarChar);
                com.Parameters["compcode"].Value = compcode;


                com.Parameters.Add("sourceregion", MySqlDbType.VarChar);
                com.Parameters["sourceregion"].Value = sourceregion;


                com.Parameters.Add("sourcevariable", MySqlDbType.VarChar);
                com.Parameters["sourcevariable"].Value = sourcevariable;


                com.Parameters.Add("sourcecat1", MySqlDbType.VarChar);
                com.Parameters["sourcecat1"].Value = sourcecat1;


                com.Parameters.Add("sourcecat2", MySqlDbType.VarChar);
                com.Parameters["sourcecat2"].Value = sourcecat2;


                com.Parameters.Add("sourcecat3", MySqlDbType.VarChar);
                com.Parameters["sourcecat3"].Value = sourcecat3;
                //,,,,,,,,,);

                com.Parameters.Add("sourcecat4", MySqlDbType.VarChar);
                com.Parameters["sourcecat4"].Value = sourcecat4;


                com.Parameters.Add("sourcecat5", MySqlDbType.VarChar);
                com.Parameters["sourcecat5"].Value = sourcecat5;


                com.Parameters.Add("destedit", MySqlDbType.VarChar);
                com.Parameters["destedit"].Value = destedit;


                com.Parameters.Add("destreg", MySqlDbType.VarChar);
                com.Parameters["destreg"].Value = destreg;


                com.Parameters.Add("destvar", MySqlDbType.VarChar);
                com.Parameters["destvar"].Value = destvar;


                com.Parameters.Add("destcat1", MySqlDbType.VarChar);
                com.Parameters["destcat1"].Value = destcat1;


                com.Parameters.Add("destcat2", MySqlDbType.VarChar);
                com.Parameters["destcat2"].Value = destcat2;


                com.Parameters.Add("destcat3", MySqlDbType.VarChar);
                com.Parameters["destcat3"].Value = destcat3;


                com.Parameters.Add("destcat4", MySqlDbType.VarChar);
                com.Parameters["destcat4"].Value = destcat4;

                com.Parameters.Add("destcat5", MySqlDbType.VarChar);
                com.Parameters["destcat5"].Value = destcat5;

                com.Parameters.Add("primary", MySqlDbType.VarChar);
                com.Parameters["primary"].Value = primary;

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

        public DataSet mappingmodify(string compcode, string sourceregion, string sourcevariable, string sourcecat1, string sourcecat2, string sourcecat3, string sourcecat4, string sourcecat5, string destedit, string destreg, string destvar, string destcat1, string destcat2, string destcat3, string destcat4, string destcat5, string primary)
        {
            MySqlConnection con;
            MySqlCommand com;
            con = GetConnection();
            MySqlDataAdapter da = new MySqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("websp_modifymapping", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("compcode", MySqlDbType.VarChar);
                com.Parameters["compcode"].Value = compcode;


                com.Parameters.Add("sourceregion", MySqlDbType.VarChar);
                com.Parameters["sourceregion"].Value = sourceregion;


                com.Parameters.Add("sourcevariable", MySqlDbType.VarChar);
                com.Parameters["sourcevariable"].Value = sourcevariable;


                com.Parameters.Add("sourcecat1", MySqlDbType.VarChar);
                com.Parameters["sourcecat1"].Value = sourcecat1;


                com.Parameters.Add("sourcecat2", MySqlDbType.VarChar);
                if (sourcecat2 == "")
                {
                    sourcecat2 = "0";
                }
                com.Parameters["sourcecat2"].Value = sourcecat2;


                com.Parameters.Add("sourcecat3", MySqlDbType.VarChar);
                if (sourcecat3 == "")
                {
                    sourcecat3 = "0";
                }
                com.Parameters["sourcecat3"].Value = sourcecat3;


                com.Parameters.Add("sourcecat4", MySqlDbType.VarChar);
                if (sourcecat4 == "")
                {
                    sourcecat4 = "0";
                }
                com.Parameters["sourcecat4"].Value = sourcecat4;


                com.Parameters.Add("sourcecat5", MySqlDbType.VarChar);
                if (sourcecat5 == "")
                {
                    sourcecat5 = "0";
                }
                com.Parameters["sourcecat5"].Value = sourcecat5;


                com.Parameters.Add("destedit", MySqlDbType.VarChar);
                com.Parameters["destedit"].Value = destedit;


                com.Parameters.Add("destreg", MySqlDbType.VarChar);
                com.Parameters["destreg"].Value = destreg;


                com.Parameters.Add("destvar", MySqlDbType.VarChar);
                com.Parameters["destvar"].Value = destvar;


                com.Parameters.Add("destcat1", MySqlDbType.VarChar);
                if (destcat1 == "")
                {
                    destcat1 = "0";
                }
                com.Parameters["destcat1"].Value = destcat1;


                com.Parameters.Add("destcat2", MySqlDbType.VarChar);
                if (destcat2 == "")
                {
                    destcat2 = "0";
                }
                com.Parameters["destcat2"].Value = destcat2;


                com.Parameters.Add("destcat3", MySqlDbType.VarChar);
                if (destcat3 == "")
                {
                    destcat3 = "0";
                }
                com.Parameters["destcat3"].Value = destcat3;


                com.Parameters.Add("destcat4", MySqlDbType.VarChar);
                if (destcat4 == "")
                {

                    destcat4 = "0";
                }
                com.Parameters["destcat4"].Value = destcat4;

                com.Parameters.Add("destcat5", MySqlDbType.VarChar);
                if (destcat5 == "")
                {
                    destcat5 = "0";
                }
                com.Parameters["destcat5"].Value = destcat5;


                com.Parameters.Add("primary", MySqlDbType.VarChar);
                com.Parameters["primary"].Value = primary;

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

        public DataSet execute(string compcode, string sourceregion, string sourcevariable, string sourcecat1, string sourcecat2, string sourcecat3, string sourcecat4, string sourcecat5, string destedit, string destreg, string destvar, string destcat1, string destcat2, string destcat3, string destcat4, string destcat5)
        {
            MySqlConnection con;
            MySqlCommand com;
            con = GetConnection();
            MySqlDataAdapter da = new MySqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("websp_executecatmap", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("compcode", MySqlDbType.VarChar);
                com.Parameters["compcode"].Value = compcode;


                com.Parameters.Add("sourceregion", MySqlDbType.VarChar);
                com.Parameters["sourceregion"].Value = sourceregion;


                com.Parameters.Add("sourcevariable", MySqlDbType.VarChar);
                com.Parameters["sourcevariable"].Value = sourcevariable;


                com.Parameters.Add("sourcecat1", MySqlDbType.VarChar);
                com.Parameters["sourcecat1"].Value = sourcecat1;


                com.Parameters.Add("sourcecat2", MySqlDbType.VarChar);
                com.Parameters["sourcecat2"].Value = sourcecat2;


                com.Parameters.Add("sourcecat3", MySqlDbType.VarChar);
                com.Parameters["sourcecat3"].Value = sourcecat3;
                //,,,,,,,,,);

                com.Parameters.Add("sourcecat4", MySqlDbType.VarChar);
                com.Parameters["sourcecat4"].Value = sourcecat4;


                com.Parameters.Add("sourcecat5", MySqlDbType.VarChar);
                com.Parameters["sourcecat5"].Value = sourcecat5;


                com.Parameters.Add("destedit", MySqlDbType.VarChar);
                com.Parameters["destedit"].Value = destedit;


                com.Parameters.Add("destreg", MySqlDbType.VarChar);
                com.Parameters["destreg"].Value = destreg;


                com.Parameters.Add("destvar", MySqlDbType.VarChar);
                com.Parameters["destvar"].Value = destvar;


                com.Parameters.Add("destcat1", MySqlDbType.VarChar);
                com.Parameters["destcat1"].Value = destcat1;


                com.Parameters.Add("destcat2", MySqlDbType.VarChar);
                com.Parameters["destcat2"].Value = destcat2;


                com.Parameters.Add("destcat3", MySqlDbType.VarChar);
                com.Parameters["destcat3"].Value = destcat3;


                com.Parameters.Add("destcat4", MySqlDbType.VarChar);
                com.Parameters["destcat4"].Value = destcat4;

                com.Parameters.Add("destcat5", MySqlDbType.VarChar);
                com.Parameters["destcat5"].Value = destcat5;


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

        public DataSet deletcatmap(string primary, string compcode)
        {
            MySqlConnection con;
            MySqlCommand com;
            con = GetConnection();
            MySqlDataAdapter da = new MySqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("websp_deletecatmap", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("compcode", MySqlDbType.VarChar);
                com.Parameters["compcode"].Value = compcode;


                com.Parameters.Add("primary", MySqlDbType.VarChar);
                com.Parameters["primary"].Value = primary;





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