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
/// Summary description for BgColor
/// </summary>
/// 
namespace NewAdbooking.Classes
{
    public class BgColor : connection
    {
        public BgColor()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataSet bgSave(string bgid, string bgname, string bgalias, string pub, string edit, string cat, string cat2, string cat3, string cat4, string cat5, string coltyp, string comcode,string bgtype,string bgamt)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("Bg_Save", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@bgid", SqlDbType.VarChar);
                com.Parameters["@bgid"].Value = bgid;

                com.Parameters.Add("@bgname", SqlDbType.VarChar);
                com.Parameters["@bgname"].Value = bgname;

                com.Parameters.Add("@bgalias", SqlDbType.VarChar);
                com.Parameters["@bgalias"].Value = bgalias;

                com.Parameters.Add("@pub", SqlDbType.VarChar);
                com.Parameters["@pub"].Value = pub;

                com.Parameters.Add("@edit", SqlDbType.VarChar);
                com.Parameters["@edit"].Value = edit;

                com.Parameters.Add("@cat", SqlDbType.VarChar);
                com.Parameters["@cat"].Value = cat;

                com.Parameters.Add("@cat2", SqlDbType.VarChar);
                com.Parameters["@cat2"].Value = cat2;

                com.Parameters.Add("@cat3", SqlDbType.VarChar);
                com.Parameters["@cat3"].Value = cat3;

                com.Parameters.Add("@cat4", SqlDbType.VarChar);
                com.Parameters["@cat4"].Value = cat4;

                com.Parameters.Add("@cat5", SqlDbType.VarChar);
                com.Parameters["@cat5"].Value = cat5;

                com.Parameters.Add("@coltyp", SqlDbType.VarChar);
                com.Parameters["@coltyp"].Value = coltyp;

                com.Parameters.Add("@comcode", SqlDbType.VarChar);
                com.Parameters["@comcode"].Value = comcode;

                com.Parameters.Add("@bgtype", SqlDbType.VarChar);
                com.Parameters["@bgtype"].Value = bgtype;

                com.Parameters.Add("@bgamt", SqlDbType.VarChar);
                if (bgamt == "" || bgamt == null)
                {
                    com.Parameters["@bgamt"].Value = System.DBNull.Value;
                }
                else
                {
                    com.Parameters["@bgamt"].Value = Convert.ToInt32(bgamt);
                }

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
        public DataSet chkbgid(string bgid, string pub, string edit, string cat,  string coltyp, string bgname)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("BGCHK", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@bgid", SqlDbType.VarChar);
                com.Parameters["@bgid"].Value = bgid;

                /*new change ankur*/
                com.Parameters.Add("@pub", SqlDbType.VarChar);
                com.Parameters["@pub"].Value = pub;


                com.Parameters.Add("@edit", SqlDbType.VarChar);
                com.Parameters["@edit"].Value = edit;


                com.Parameters.Add("@cat", SqlDbType.VarChar);
                com.Parameters["@cat"].Value = cat;


                com.Parameters.Add("@coltyp", SqlDbType.VarChar);
                com.Parameters["@coltyp"].Value = coltyp;


                com.Parameters.Add("@bgname", SqlDbType.VarChar);
                com.Parameters["@bgname"].Value = bgname;
                //////////////////
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
        public DataSet bgmodify(string bgid, string bgname, string bgalias, string pub, string edit, string cat, string cat2, string cat3, string cat4, string cat5, string coltyp, string compcode,string bgtype,string bgamt)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("BG_MODIFy", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@bgid", SqlDbType.VarChar);
                com.Parameters["@bgid"].Value = bgid;

                com.Parameters.Add("@bgname", SqlDbType.VarChar);
                com.Parameters["@bgname"].Value = bgname;

                com.Parameters.Add("@bgalias", SqlDbType.VarChar);
                com.Parameters["@bgalias"].Value = bgalias;


                com.Parameters.Add("@pub", SqlDbType.VarChar);
                com.Parameters["@pub"].Value = pub;

                com.Parameters.Add("@edit", SqlDbType.VarChar);
                com.Parameters["@edit"].Value = edit;


                com.Parameters.Add("@cat", SqlDbType.VarChar);
                com.Parameters["@cat"].Value = cat;

                com.Parameters.Add("@cat2", SqlDbType.VarChar);
                com.Parameters["@cat2"].Value = cat2;

                com.Parameters.Add("@cat3", SqlDbType.VarChar);
                com.Parameters["@cat3"].Value = cat3;

                com.Parameters.Add("@cat4", SqlDbType.VarChar);
                com.Parameters["@cat4"].Value = cat4;

                com.Parameters.Add("@cat5", SqlDbType.VarChar);
                com.Parameters["@cat5"].Value = cat5;

                com.Parameters.Add("@coltyp", SqlDbType.VarChar);
                com.Parameters["@coltyp"].Value = coltyp;

                com.Parameters.Add("@compcode", SqlDbType.VarChar);
                com.Parameters["@compcode"].Value = compcode;

                com.Parameters.Add("@bgtype", SqlDbType.VarChar);
                com.Parameters["@bgtype"].Value = bgtype;

                com.Parameters.Add("@bgamt", SqlDbType.VarChar);
                if (bgamt == "" || bgamt == null)
                {
                    com.Parameters["@bgamt"].Value = System.DBNull.Value;
                }
                else
                {
                    com.Parameters["@bgamt"].Value =Convert.ToInt32(bgamt);
                }

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
        public DataSet bgexecute1(string bgid, string bgname, string bgalias, string compcode)
        {
            SqlConnection con = new SqlConnection();
            SqlCommand com = new SqlCommand();
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("BG_EXE", ref con);
                com.CommandType = CommandType.StoredProcedure;

                //com.Parameters.Add("@Comp_Code", SqlDbType.VarChar);
                //com.Parameters["@Comp_Code"].Value = companycode;

                com.Parameters.Add("@bgid", SqlDbType.VarChar);

                com.Parameters["@bgid"].Value = bgid;


                com.Parameters.Add("@bgname", SqlDbType.VarChar);

                com.Parameters["@bgname"].Value = bgname;


                com.Parameters.Add("@bgalias", SqlDbType.VarChar);

                com.Parameters["@bgalias"].Value = bgalias;

                com.Parameters.Add("@compcode", SqlDbType.VarChar);

                com.Parameters["@compcode"].Value = compcode;


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

        public DataSet bgfpnl()
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("BGFPNL", ref con);
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
        public DataSet bgdelete(string bgid)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("BG_DELETE", ref con);
                com.CommandType = CommandType.StoredProcedure;

                 com.Parameters.Add("@bgid", SqlDbType.VarChar);
                com.Parameters["@bgid"].Value = bgid;
                                                
                
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
        /*new change ankur 9 feb*/
        public DataSet bgdauto(string str,string pub,string edit,string cat,string coltype)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("BG_AUTO", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@str", SqlDbType.VarChar);
                objSqlCommand.Parameters["@str"].Value = str;

                objSqlCommand.Parameters.Add("@cod", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cod"].Value = str;
                /*new change ankur 9 feb*/
                objSqlCommand.Parameters.Add("@pub", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pub"].Value = pub;

                objSqlCommand.Parameters.Add("@edit", SqlDbType.VarChar);
                objSqlCommand.Parameters["@edit"].Value = edit;

                objSqlCommand.Parameters.Add("@cat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cat"].Value = cat;

                objSqlCommand.Parameters.Add("@coltype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@coltype"].Value = coltype;


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

        public DataSet bgexecute2(string bgid, string bgname, string bgalias)
        {
            SqlConnection con = new SqlConnection();
            SqlCommand com = new SqlCommand();
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("BG_EXE1", ref con);
                com.CommandType = CommandType.StoredProcedure;



                com.Parameters.Add("@bgid", SqlDbType.VarChar);

                com.Parameters["@bgid"].Value = bgid;

                com.Parameters.Add("@bgname", SqlDbType.VarChar);

                com.Parameters["@bgname"].Value = bgname;


                com.Parameters.Add("@bgalias", SqlDbType.VarChar);

                com.Parameters["@bgalias"].Value = bgalias;

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

        /*new change ankur*/
        public DataSet bindcolortyp(string compcode)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("bindcolortype", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@compcode", SqlDbType.VarChar);
                com.Parameters["@compcode"].Value = compcode;

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

        //public DataSet addcategoryname3(string adsubcategory)
        //{
        //    SqlConnection con;
        //    SqlCommand com;
        //    con = GetConnection();
        //    SqlDataAdapter da = new SqlDataAdapter();
        //    DataSet ds = new DataSet();
        //    try
        //    {
        //        con.Open();
        //        com = GetCommand("advsubsubcategory", ref con);
        //        com.CommandType = CommandType.StoredProcedure;

        //        com.Parameters.Add("@adsubcategory", SqlDbType.VarChar);
        //        com.Parameters["@adsubcategory"].Value = adsubcategory;

        //        da.SelectCommand = com;
        //        da.Fill(ds);
        //        return ds;
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

        public DataSet addcategoryname2(string adcat, string compcode)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("advsubcategory", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@adcategory", SqlDbType.VarChar);
                com.Parameters["@adcategory"].Value = adcat;

                com.Parameters.Add("@compcode", SqlDbType.VarChar);
                com.Parameters["@compcode"].Value = compcode;

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

        public DataSet addcategoryname3(string adsubcategory)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("advsubsubcategory", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@adsubcategory", SqlDbType.VarChar);
                com.Parameters["@adsubcategory"].Value = adsubcategory;

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

        //--------------for adcat4-----------------
        public DataSet bindscategory4(string adscat4, string value, string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Rate_bindadcat4", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@adscat4", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adscat4"].Value = adscat4;

                objSqlCommand.Parameters.Add("@value", SqlDbType.VarChar);
                objSqlCommand.Parameters["@value"].Value = value;



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
        //--------------for adca5----------------
        public DataSet bindscategory5(string adscat5, string value, string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Rate_bindadcat4", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@adscat4", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adscat4"].Value = adscat5;

                objSqlCommand.Parameters.Add("@value", SqlDbType.VarChar);
                objSqlCommand.Parameters["@value"].Value = value;



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
    
  
        
        
