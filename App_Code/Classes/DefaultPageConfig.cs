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

    public class DefaultPageConfig:connection
    {
        public DefaultPageConfig()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        //Get Category code
        public DataSet clsCategory(string compcode, string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Websp_Category", ref objSqlConnection);
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

        //Get Center code
        public DataSet centercode(string compcode, string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("pubcent_proc", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@puserid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@puserid"].Value = userid;

                objSqlCommand.Parameters.Add("@chk_access", SqlDbType.VarChar);
                objSqlCommand.Parameters["@chk_access"].Value = 0;

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

        public DataSet editioncodes(string centercode, string compcode, string pubcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("edition_proc", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@centercode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@centercode"].Value = centercode;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

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

        public DataSet secpubcodes(string compcode, string userid, string editioncode, string flag)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Websp_Defaddsecpub", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@editioncode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@editioncode"].Value = editioncode;

                objSqlCommand.Parameters.Add("@flag", SqlDbType.VarChar);
                objSqlCommand.Parameters["@flag"].Value = flag;

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

        //**********************************************************

        public DataSet clsSavenewRecord(string compcode, string userid, string ddlpubcode, string ddlcentercode, string ddleditioncode, string ddlsuppcode, string ddlpgno, string ddlladder, string ddlIssuePage, string txtadctg, string txtadsubctg, string ddlpgheading, string ddlpgcolor, string txtpgheight, string txtpgwidth, string txtstrow, string txtstcol, string txtpgvolume, string txtsharepgstatus, string txtsharepgno, string txtmaxadallow, string txtvalidfromdate, string txtvalidtodate, string dateformat, string ddlPremiumRequired, string ddlHouseAdRequired)  //,string ddlpubname,string ddlcentername,string ddleditionname,string ddlsuppname)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_SaveDefPageconfig", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@ddlpubcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ddlpubcode"].Value = ddlpubcode;

                objSqlCommand.Parameters.Add("@ddlcentercode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ddlcentercode"].Value = ddlcentercode;

                objSqlCommand.Parameters.Add("@ddleditioncode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ddleditioncode"].Value = ddleditioncode;

                objSqlCommand.Parameters.Add("@ddlsuppcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ddlsuppcode"].Value = ddlsuppcode;

                objSqlCommand.Parameters.Add("@ddlpgno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ddlpgno"].Value = ddlpgno;

                objSqlCommand.Parameters.Add("@ddlladder", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ddlladder"].Value = ddlladder;

                objSqlCommand.Parameters.Add("@ddlIssuePage", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ddlIssuePage"].Value = ddlIssuePage;

                objSqlCommand.Parameters.Add("@txtadctg", SqlDbType.VarChar);
                objSqlCommand.Parameters["@txtadctg"].Value = txtadctg;

                objSqlCommand.Parameters.Add("@txtadsubctg", SqlDbType.VarChar);
                objSqlCommand.Parameters["@txtadsubctg"].Value = txtadsubctg;

                objSqlCommand.Parameters.Add("@ddlpgheading", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ddlpgheading"].Value = ddlpgheading;

                objSqlCommand.Parameters.Add("@ddlpgcolor", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ddlpgcolor"].Value = ddlpgcolor;

                objSqlCommand.Parameters.Add("@txtpgheight", SqlDbType.VarChar);
                objSqlCommand.Parameters["@txtpgheight"].Value = txtpgheight;

                objSqlCommand.Parameters.Add("@txtpgwidth", SqlDbType.VarChar);
                objSqlCommand.Parameters["@txtpgwidth"].Value = txtpgwidth;

                objSqlCommand.Parameters.Add("@txtstrow", SqlDbType.VarChar);
                objSqlCommand.Parameters["@txtstrow"].Value = txtstrow;

                objSqlCommand.Parameters.Add("@txtstcol", SqlDbType.VarChar);
                objSqlCommand.Parameters["@txtstcol"].Value = txtstcol;

                objSqlCommand.Parameters.Add("@txtpgvolume", SqlDbType.VarChar);
                objSqlCommand.Parameters["@txtpgvolume"].Value = txtpgvolume;

                objSqlCommand.Parameters.Add("@txtsharepgstatus", SqlDbType.VarChar);
                objSqlCommand.Parameters["@txtsharepgstatus"].Value = txtsharepgstatus;

                objSqlCommand.Parameters.Add("@txtsharepgno", SqlDbType.VarChar);
                if (txtsharepgno == "")
                    objSqlCommand.Parameters["@txtsharepgno"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@txtsharepgno"].Value = txtsharepgno;

                objSqlCommand.Parameters.Add("@txtmaxadallow", SqlDbType.VarChar);
                if (txtmaxadallow == "")
                    objSqlCommand.Parameters["@txtmaxadallow"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@txtmaxadallow"].Value = txtmaxadallow;

                objSqlCommand.Parameters.Add("@txtvalidtodate", SqlDbType.VarChar);

                if (txtvalidtodate == "" || txtvalidtodate == null)
                {
                    objSqlCommand.Parameters["@txtvalidtodate"].Value = System.DBNull.Value;
                }
                else
                {
                 if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = txtvalidtodate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        txtvalidtodate = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = txtvalidtodate.Split('/');
                        string mm = arr[0];
                        string dd = arr[1];
                        string yy = arr[2];
                        txtvalidtodate = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@txtvalidtodate"].Value = txtvalidtodate;
                }
                
                objSqlCommand.Parameters.Add("@txtvalidfromdate", SqlDbType.VarChar);
                if (txtvalidfromdate == "" || txtvalidfromdate == null)
                {
                    objSqlCommand.Parameters["@txtvalidfromdate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = txtvalidfromdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        txtvalidfromdate = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = txtvalidfromdate.Split('/');
                        string mm = arr[0];
                        string dd = arr[1];
                        string yy = arr[2];
                        txtvalidfromdate = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@txtvalidfromdate"].Value = txtvalidfromdate;
                }
                objSqlCommand.Parameters.Add("@ddlPremiumRequired", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ddlPremiumRequired"].Value = ddlPremiumRequired;

                objSqlCommand.Parameters.Add("@ddlHouseAdRequired", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ddlHouseAdRequired"].Value = ddlHouseAdRequired;

                //objSqlCommand.Parameters.Add("@ddleditionname", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@ddleditionname"].Value = ddleditionname;

                //objSqlCommand.Parameters.Add("@ddlsuppname", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@ddlsuppname"].Value = ddlsuppname;


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



        public DataSet clsExecuteRecord(string compcode, string pubcode, string centercode, string editioncode, string suppcode, string pageno, string noofpages, string ddlpgcolor, string flag, string dateformat)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Websp_DefExecuteRecord", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@pubcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pubcode"].Value = pubcode;

                objSqlCommand.Parameters.Add("@centercode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@centercode"].Value = centercode;

                objSqlCommand.Parameters.Add("@editioncode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@editioncode"].Value = editioncode;

                objSqlCommand.Parameters.Add("@suppcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@suppcode"].Value = suppcode;

                objSqlCommand.Parameters.Add("@pageno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pageno"].Value = pageno;

                objSqlCommand.Parameters.Add("@noofpages", SqlDbType.VarChar);
                objSqlCommand.Parameters["@noofpages"].Value = noofpages;

                objSqlCommand.Parameters.Add("@ddlpgcolor", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ddlpgcolor"].Value = ddlpgcolor;

                objSqlCommand.Parameters.Add("@flag", SqlDbType.VarChar);
                objSqlCommand.Parameters["@flag"].Value = flag;

                objSqlCommand.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dateformat"].Value = dateformat;


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

        // Modify Page configuration's record
        public DataSet clsModifyRecord(string compcode, string pubcode, string centercode, string editioncode, string suppcode, string ladder, string pageno, string category, string subcategory, string noofpages, string ddlpgcolor, string pageheading, string pageheight, string pagewidth, string maxad, string strow, string stcol, string dt_from, string dt_to, string pagevolume,string dateformat,  string ddlPremiumRequired)

        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_ModifyDefPageconfig", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@ddlpubcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ddlpubcode"].Value = pubcode;

                objSqlCommand.Parameters.Add("@ddlcentercode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ddlcentercode"].Value = centercode;

                objSqlCommand.Parameters.Add("@ddleditioncode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ddleditioncode"].Value = editioncode;

                objSqlCommand.Parameters.Add("@ddlsuppcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ddlsuppcode"].Value = suppcode;

                objSqlCommand.Parameters.Add("@ddlladder", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ddlladder"].Value = ladder;

                objSqlCommand.Parameters.Add("@ddlpgno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ddlpgno"].Value = pageno;

                objSqlCommand.Parameters.Add("@txtadctg", SqlDbType.VarChar);
                objSqlCommand.Parameters["@txtadctg"].Value = category;

                objSqlCommand.Parameters.Add("@txtadsubctg", SqlDbType.VarChar);
                objSqlCommand.Parameters["@txtadsubctg"].Value = subcategory;

                objSqlCommand.Parameters.Add("@ddlIssuePage", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ddlIssuePage"].Value = noofpages;

                objSqlCommand.Parameters.Add("@ddlpgcolor", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ddlpgcolor"].Value = ddlpgcolor;

                objSqlCommand.Parameters.Add("@ddlpgheading", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ddlpgheading"].Value = pageheading;

                objSqlCommand.Parameters.Add("@txtpgheight", SqlDbType.VarChar);
                objSqlCommand.Parameters["@txtpgheight"].Value = pageheight;

                objSqlCommand.Parameters.Add("@txtpgwidth", SqlDbType.VarChar);
                objSqlCommand.Parameters["@txtpgwidth"].Value = pagewidth;

                objSqlCommand.Parameters.Add("@txtmaxadallow", SqlDbType.VarChar);
                objSqlCommand.Parameters["@txtmaxadallow"].Value = maxad;

                objSqlCommand.Parameters.Add("@txtstrow", SqlDbType.VarChar);
                objSqlCommand.Parameters["@txtstrow"].Value = strow;

                objSqlCommand.Parameters.Add("@txtstcol", SqlDbType.VarChar);
                objSqlCommand.Parameters["@txtstcol"].Value = stcol;

                objSqlCommand.Parameters.Add("@txtvalidfromdate", SqlDbType.VarChar);
                if (dt_from == "" || dt_from == null)
                {
                    objSqlCommand.Parameters["@pubdate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = dt_from.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        dt_from = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = dt_from.Split('/');
                        string mm = arr[0];
                        string dd = arr[1];
                        string yy = arr[2];
                        dt_from = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@txtvalidfromdate"].Value = dt_from;
                }


                objSqlCommand.Parameters.Add("@txtvalidtodate", SqlDbType.VarChar);
                if (dt_to == "" || dt_to == null)
                {
                    objSqlCommand.Parameters["@pubdate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = dt_to.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        dt_to = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = dt_to.Split('/');
                        string mm = arr[0];
                        string dd = arr[1];
                        string yy = arr[2];
                        dt_to = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@txtvalidtodate"].Value = dt_to;
                }

                objSqlCommand.Parameters.Add("@txtpgvolume", SqlDbType.VarChar);
                objSqlCommand.Parameters["@txtpgvolume"].Value = pagevolume;

                objSqlCommand.Parameters.Add("@ddlPremiumRequired", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ddlPremiumRequired"].Value = ddlPremiumRequired;

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

        // Delete Page configuration's record
        public DataSet clsDeleteRecord(string compcode, string pubcode, string centercode, string editioncode, string suppcode, string pageno)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Websp_DefDeleteRecord", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@pubcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pubcode"].Value = pubcode;

                objSqlCommand.Parameters.Add("@centercode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@centercode"].Value = centercode;

                objSqlCommand.Parameters.Add("@editioncode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@editioncode"].Value = editioncode;

                objSqlCommand.Parameters.Add("@suppcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@suppcode"].Value = suppcode;

                objSqlCommand.Parameters.Add("@pageno", SqlDbType.VarChar);
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

        public DataSet clscheckentry(string compcode, string pubcode, string centercode, string editioncode, string suppcode, string pageno, string noofpages)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Defchkpagecode", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                //objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@pubcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pubcode"].Value = pubcode;

                objSqlCommand.Parameters.Add("@centercode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@centercode"].Value = centercode;

                objSqlCommand.Parameters.Add("@editioncode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@editioncode"].Value = editioncode;

                objSqlCommand.Parameters.Add("@suppcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@suppcode"].Value = suppcode;

                objSqlCommand.Parameters.Add("@pageno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pageno"].Value = pageno;

                objSqlCommand.Parameters.Add("@noofpages", SqlDbType.VarChar);
                objSqlCommand.Parameters["@noofpages"].Value = noofpages;


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