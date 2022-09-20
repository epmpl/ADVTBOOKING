using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.Sql;
using System.Data.SqlClient;

/// <summary>
/// Summary description for RateMaster
/// </summary>
namespace NewAdbooking.Classes
{
    public class RateMaster:connection
    {
        public RateMaster()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataSet fetch_priority_rate(string rateid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("fetchPriorityRate", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@rateidm", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rateidm"].Value = rateid;

              

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
        public void insert_priority_rate(string rateuniqueid, string data, string status)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("insert_priorityrate_details", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@rateidm", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rateidm"].Value = rateuniqueid;

                objSqlCommand.Parameters.Add("@p_str", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_str"].Value = data;

                objSqlCommand.Parameters.Add("@STATUS", SqlDbType.VarChar);
                objSqlCommand.Parameters["@STATUS"].Value = status;

                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);

               

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
        public DataSet getEditionDetail(string pkgdesc)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getEditionDetail_pri", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@pkgdesc", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pkgdesc"].Value = pkgdesc;

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
        public DataSet autogenrated(string compcode,string auto)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getautocoderate", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@auto", SqlDbType.VarChar);
                objSqlCommand.Parameters["@auto"].Value = auto;


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


        public DataSet bindscheme(string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("schemebind", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

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


        public DataSet getpremiumval(string compcode, string premium)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("gatvalpremium", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@premium", SqlDbType.VarChar);
                objSqlCommand.Parameters["@premium"].Value = premium;


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
        /*new change ankur 28 feb*/
        public DataSet ratecodecheck(string compcode, string ratecode, string adtype, string adcategory, string adsubcategory, string color, string package, string currency, string fromdate, string todate, string uom, string adscat4, string adscat5, string adscat6, string premium, string sizefrom, string sizeto, string frominsert, string toinsert, string clientcat, string minadarea, string agencycode, string dateformat, string pubcenter)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("chkratecode", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@uom", SqlDbType.VarChar);
                objSqlCommand.Parameters["@uom"].Value = uom;

                objSqlCommand.Parameters.Add("@ratecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ratecode"].Value = ratecode;

                objSqlCommand.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (dateformat == "dd/mm/yyyy")
                {
                    string[] arr = fromdate.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    fromdate = mm + "/" + dd + "/" + yy;
                }
                else if (dateformat == "yyyy/mm/dd")
                {
                    string[] arr = fromdate.Split('/');
                    string dd = arr[2];
                    string mm = arr[1];
                    string yy = arr[0];
                    fromdate = mm + "/" + dd + "/" + yy;
                }
                objSqlCommand.Parameters["@fromdate"].Value = fromdate;

                objSqlCommand.Parameters.Add("@todate", SqlDbType.VarChar);
                if (dateformat == "dd/mm/yyyy")
                {
                    string[] arr = todate.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    todate = mm + "/" + dd + "/" + yy;
                }
                else if (dateformat == "yyyy/mm/dd")
                {
                    string[] arr = todate.Split('/');
                    string dd = arr[2];
                    string mm = arr[1];
                    string yy = arr[0];
                    todate = mm + "/" + dd + "/" + yy;
                }
                objSqlCommand.Parameters["@todate"].Value = todate;

                objSqlCommand.Parameters.Add("@adtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adtype"].Value = adtype;

                objSqlCommand.Parameters.Add("@adcategory", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adcategory"].Value = adcategory;


                objSqlCommand.Parameters.Add("@adsubcategory", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adsubcategory"].Value = adsubcategory;

                objSqlCommand.Parameters.Add("@color", SqlDbType.VarChar);
                objSqlCommand.Parameters["@color"].Value = color;

                objSqlCommand.Parameters.Add("@package", SqlDbType.VarChar);
                objSqlCommand.Parameters["@package"].Value = package;

                objSqlCommand.Parameters.Add("@currency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@currency"].Value = currency;


                objSqlCommand.Parameters.Add("@adscat6", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adscat6"].Value = adscat6;

                objSqlCommand.Parameters.Add("@adscat5", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adscat5"].Value = adscat5;

                objSqlCommand.Parameters.Add("@adscat4", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adscat4"].Value = adscat4;

                objSqlCommand.Parameters.Add("@premium", SqlDbType.VarChar);
                objSqlCommand.Parameters["@premium"].Value = premium;

                objSqlCommand.Parameters.Add("@sizefrom", SqlDbType.VarChar);
                objSqlCommand.Parameters["@sizefrom"].Value = sizefrom;

                objSqlCommand.Parameters.Add("@sizeto", SqlDbType.VarChar);
                objSqlCommand.Parameters["@sizeto"].Value = sizeto;

                objSqlCommand.Parameters.Add("@frominsert", SqlDbType.VarChar);
                objSqlCommand.Parameters["@frominsert"].Value = frominsert;

                objSqlCommand.Parameters.Add("@toinsert", SqlDbType.VarChar);
                objSqlCommand.Parameters["@toinsert"].Value = toinsert;

                objSqlCommand.Parameters.Add("@clientcat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@clientcat"].Value = clientcat;

                objSqlCommand.Parameters.Add("@minadarea", SqlDbType.VarChar);
                if (minadarea == "")
                {
                    objSqlCommand.Parameters["@minadarea"].Value = "0";
                }
                else
                {

                    objSqlCommand.Parameters["@minadarea"].Value = minadarea;
                }


                objSqlCommand.Parameters.Add("@type", SqlDbType.VarChar);
                objSqlCommand.Parameters["@type"].Value = "";

                objSqlCommand.Parameters.Add("@agencycode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencycode"].Value = agencycode;

                objSqlCommand.Parameters.Add("@pubcenter", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pubcenter"].Value = pubcenter;
                

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

        public DataSet soloratechk(string compcode, string ratecode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("chksolocode", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@ratecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ratecode"].Value = ratecode;

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

        /*new change ankur for agency*/
        public DataSet soloratebind(string compcode, string ratecode,string type)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("bindsolorate", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@ratecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ratecode"].Value = ratecode;
                /*new change ankur for agency8*/


                objSqlCommand.Parameters.Add("@type", SqlDbType.VarChar);
                objSqlCommand.Parameters["@type"].Value = type;
                 





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
        /*new change ankur for agency*/
        public DataSet chkpkgrate(string compcode, string ratecode, string adtype, string adcategory, string adsubcategory, string color, string package, string currency, string fromdate, string todate, string uom,string adscat4,string adscat5,string adscat6,string premium,string sizefrom,string sizeto,string frominsert,string toinsert,string clientcat,string minadarea,string type,string agencycode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("chksolopackage", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@ratecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ratecode"].Value = ratecode;

                objSqlCommand.Parameters.Add("@fromdate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@fromdate"].Value = fromdate;

                objSqlCommand.Parameters.Add("@todate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@todate"].Value = todate;

                objSqlCommand.Parameters.Add("@adtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adtype"].Value = adtype;

                objSqlCommand.Parameters.Add("@adcategory", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adcategory"].Value = adcategory;


                objSqlCommand.Parameters.Add("@adsubcategory", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adsubcategory"].Value = adsubcategory;

                objSqlCommand.Parameters.Add("@color", SqlDbType.VarChar);
                objSqlCommand.Parameters["@color"].Value = color;

                objSqlCommand.Parameters.Add("@package", SqlDbType.VarChar);
                objSqlCommand.Parameters["@package"].Value = package;

                objSqlCommand.Parameters.Add("@currency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@currency"].Value = currency;

                objSqlCommand.Parameters.Add("@uom", SqlDbType.VarChar);
                objSqlCommand.Parameters["@uom"].Value = uom;

                objSqlCommand.Parameters.Add("@adscat6", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adscat6"].Value = adscat6;

                objSqlCommand.Parameters.Add("@adscat5", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adscat5"].Value = adscat5;

                objSqlCommand.Parameters.Add("@adscat4", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adscat4"].Value = adscat4;

                objSqlCommand.Parameters.Add("@premium", SqlDbType.VarChar);
                objSqlCommand.Parameters["@premium"].Value = premium;

                objSqlCommand.Parameters.Add("@sizefrom", SqlDbType.VarChar);
                objSqlCommand.Parameters["@sizefrom"].Value = sizefrom;

                objSqlCommand.Parameters.Add("@sizeto", SqlDbType.VarChar);
                objSqlCommand.Parameters["@sizeto"].Value = sizeto;

                objSqlCommand.Parameters.Add("@frominsert", SqlDbType.VarChar);
                objSqlCommand.Parameters["@frominsert"].Value = frominsert;


                objSqlCommand.Parameters.Add("@toinsert", SqlDbType.VarChar);
                objSqlCommand.Parameters["@toinsert"].Value = toinsert;


                objSqlCommand.Parameters.Add("@clientcat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@clientcat"].Value = clientcat;



                objSqlCommand.Parameters.Add("@minadarea", SqlDbType.VarChar);
                if (minadarea == "")
                {
                    objSqlCommand.Parameters["@minadarea"].Value = "0";
                }
                else
                {
                    objSqlCommand.Parameters["@minadarea"].Value = minadarea;
                }

                /*new change ankur for agency*/

                objSqlCommand.Parameters.Add("@type", SqlDbType.VarChar);
                objSqlCommand.Parameters["@type"].Value = type;


                objSqlCommand.Parameters.Add("@agencycode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencycode"].Value = agencycode;

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

        /*new change ankur 17 feb*/
        /*new change ankur for agency*/
        public DataSet insertratecode(string compcode, string userid, string ratecode, string adtype, string rategroupcode, string adcategory, string currency, string adsubcategory, string package, string packagedesc, string uom, string sizefrom, string sizeto, string consumption, string color, string colorchrty, string weekdrate, string weeminrate, string extweerate, string focusdarate, string focminrate, string focexrate, string validfromdate, string validtill, string remarks, string premium, string premiumval, string rateuniqueid, string weekendrate, string weekendmin, string weekendextra, string combination, string insertsolo, string minadarea, string editionfrom, string editionto, string flramount, string flrdiscount, string scheme, string adscat4, string adscat5, string adscat6, string frominsert, string toinsert, string agtype, string clientcat, string max_area,string type,string agencycode)
         {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                string datefrom = validfromdate;
                string dateto = validtill;
                objSqlConnection.Open();
                objSqlCommand = GetCommand("insertratecode", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@rateuniqueid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rateuniqueid"].Value = rateuniqueid;


                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@datefrom", SqlDbType.VarChar);
                objSqlCommand.Parameters["@datefrom"].Value = datefrom;


                objSqlCommand.Parameters.Add("@dateto", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dateto"].Value = dateto;


                objSqlCommand.Parameters.Add("@ratecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ratecode"].Value = ratecode;

                objSqlCommand.Parameters.Add("@adtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adtype"].Value = adtype;


                objSqlCommand.Parameters.Add("@rategroupcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rategroupcode"].Value = rategroupcode;

                objSqlCommand.Parameters.Add("@adcategory", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adcategory"].Value = adcategory;


                objSqlCommand.Parameters.Add("@currency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@currency"].Value = currency;

                objSqlCommand.Parameters.Add("@adsubcategory", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adsubcategory"].Value = adsubcategory;
                

                objSqlCommand.Parameters.Add("@package", SqlDbType.VarChar);
                objSqlCommand.Parameters["@package"].Value = package;

                objSqlCommand.Parameters.Add("@premium", SqlDbType.VarChar);
                objSqlCommand.Parameters["@premium"].Value = premium;


                objSqlCommand.Parameters.Add("@premiumval", SqlDbType.VarChar);
                objSqlCommand.Parameters["@premiumval"].Value = premiumval;

               

                objSqlCommand.Parameters.Add("@packagedesc", SqlDbType.VarChar);
                objSqlCommand.Parameters["@packagedesc"].Value = packagedesc;

                objSqlCommand.Parameters.Add("@uom", SqlDbType.VarChar);
                objSqlCommand.Parameters["@uom"].Value = uom;


                objSqlCommand.Parameters.Add("@sizefrom", SqlDbType.Int);
                if (sizefrom == "" || sizefrom == null)
                {
                    objSqlCommand.Parameters["@sizefrom"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@sizefrom"].Value = sizefrom;
                }

                objSqlCommand.Parameters.Add("@sizeto", SqlDbType.Int);
                if (sizeto == "" || sizeto == null)
                {
                    objSqlCommand.Parameters["@sizeto"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@sizeto"].Value = sizeto;
                }


                objSqlCommand.Parameters.Add("@consumption", SqlDbType.Int);
                if (consumption == "" || consumption == null)
                {
                    objSqlCommand.Parameters["@consumption"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@consumption"].Value = consumption;
                }

                objSqlCommand.Parameters.Add("@color", SqlDbType.VarChar);
                objSqlCommand.Parameters["@color"].Value = color;


                objSqlCommand.Parameters.Add("@flramount", SqlDbType.Decimal);
                if (flramount == "" || flramount == null)
                {
                    objSqlCommand.Parameters["@flramount"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@flramount"].Value = Convert.ToDecimal(flramount);
                }

                objSqlCommand.Parameters.Add("@flrdiscount", SqlDbType.Decimal);
                if (flrdiscount == "" || flrdiscount == null)
                {
                    objSqlCommand.Parameters["@flrdiscount"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@flrdiscount"].Value = Convert.ToDecimal(flrdiscount);
                }

                objSqlCommand.Parameters.Add("@remarks", SqlDbType.VarChar);
                objSqlCommand.Parameters["@remarks"].Value = remarks;


                objSqlCommand.Parameters.Add("@colorchrty", SqlDbType.VarChar);
                objSqlCommand.Parameters["@colorchrty"].Value = colorchrty;

                objSqlCommand.Parameters.Add("@weekdrate", SqlDbType.Decimal);
                if (weekdrate == "" || weekdrate == null)
                {
                    objSqlCommand.Parameters["@weekdrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@weekdrate"].Value = Convert.ToDecimal(weekdrate);
                }



                objSqlCommand.Parameters.Add("@weeminrate", SqlDbType.Decimal);
                if (weeminrate == "" || weeminrate == null)
                {
                    objSqlCommand.Parameters["@weeminrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@weeminrate"].Value = Convert.ToDecimal(weeminrate);
                }


                objSqlCommand.Parameters.Add("@extweerate", SqlDbType.Decimal);
                if (extweerate == "" || extweerate == null)
                {
                    objSqlCommand.Parameters["@extweerate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@extweerate"].Value = Convert.ToDecimal(extweerate);
                }

                objSqlCommand.Parameters.Add("@focusdarate", SqlDbType.Decimal);
                if (focusdarate == "" || focusdarate == null)
                {
                    objSqlCommand.Parameters["@focusdarate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@focusdarate"].Value = Convert.ToDecimal(focusdarate);
                }


                objSqlCommand.Parameters.Add("@focminrate", SqlDbType.Decimal);
                if (focminrate == "" || focminrate == null)
                {
                    objSqlCommand.Parameters["@focminrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@focminrate"].Value = Convert.ToDecimal(focminrate);
                }

                objSqlCommand.Parameters.Add("@focexrate", SqlDbType.Decimal);
                if (focexrate == "" || focexrate == null)
                {
                    objSqlCommand.Parameters["@focexrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@focexrate"].Value = Convert.ToDecimal(focexrate);
                }

                objSqlCommand.Parameters.Add("@validfromdate", SqlDbType.DateTime);
                if (validfromdate == "" || validfromdate == null)
                {
                    objSqlCommand.Parameters["@validfromdate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@validfromdate"].Value = validfromdate;
                }

                objSqlCommand.Parameters.Add("@validtill", SqlDbType.DateTime);
                if (validtill == "" || validtill == null)
                {
                    objSqlCommand.Parameters["@validtill"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@validtill"].Value = validtill;
                }


                //Convert.ToDateTime();
                objSqlCommand.Parameters.Add("@weekendrate", SqlDbType.Decimal);
                if (weekendrate == "" || weekendrate == null)
                {
                    objSqlCommand.Parameters["@weekendrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@weekendrate"].Value = Convert.ToDecimal(weekendrate);
                }


                objSqlCommand.Parameters.Add("@weekendmin", SqlDbType.Decimal);
                if (weekendmin == "" || weekendmin == null)
                {
                    objSqlCommand.Parameters["@weekendmin"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@weekendmin"].Value = Convert.ToDecimal(weekendmin);
                }

                objSqlCommand.Parameters.Add("@weekendextra", SqlDbType.Decimal);
                if (weekendextra == "" || weekendextra == null)
                {
                    objSqlCommand.Parameters["@weekendextra"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@weekendextra"].Value = Convert.ToDecimal(weekendextra);
                }

               
                objSqlCommand.Parameters.Add("@combination", SqlDbType.VarChar);
                objSqlCommand.Parameters["@combination"].Value = combination;

                objSqlCommand.Parameters.Add("@insertsolo", SqlDbType.VarChar);
                objSqlCommand.Parameters["@insertsolo"].Value = insertsolo;

                objSqlCommand.Parameters.Add("@minadarea", SqlDbType.Decimal);
                if (minadarea == "" || minadarea == null)
                {
                    objSqlCommand.Parameters["@minadarea"].Value = Convert.ToDecimal("0");
                }
                else
                {
                    objSqlCommand.Parameters["@minadarea"].Value = Convert.ToDecimal(minadarea);
                }

                objSqlCommand.Parameters.Add("@editionfrom", SqlDbType.Int);
                if (editionfrom == "" || editionfrom == null)
                {
                    objSqlCommand.Parameters["@editionfrom"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@editionfrom"].Value = Convert.ToInt32(editionfrom);
                }

                objSqlCommand.Parameters.Add("@editionto", SqlDbType.Int);
                if (editionto == "" || editionto == null)
                {
                    objSqlCommand.Parameters["@editionto"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@editionto"].Value = Convert.ToInt32(editionto);
                }


                objSqlCommand.Parameters.Add("@scheme", SqlDbType.VarChar);
                objSqlCommand.Parameters["@scheme"].Value = scheme;

                objSqlCommand.Parameters.Add("@adscat6", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adscat6"].Value = adscat6;


                objSqlCommand.Parameters.Add("@adscat5", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adscat5"].Value = adscat5;


                objSqlCommand.Parameters.Add("@adscat4", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adscat4"].Value = adscat4;

                objSqlCommand.Parameters.Add("@frominsert", SqlDbType.Int);
                if (frominsert == "" || frominsert == null)
                {
                    objSqlCommand.Parameters["@frominsert"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@frominsert"].Value = frominsert;
                }

                objSqlCommand.Parameters.Add("@toinsert", SqlDbType.Int);
                if (toinsert == "" || toinsert == null)
                {
                    objSqlCommand.Parameters["@toinsert"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@toinsert"].Value = toinsert;
                }

                objSqlCommand.Parameters.Add("@agtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agtype"].Value = agtype;

                objSqlCommand.Parameters.Add("@clientcat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@clientcat"].Value = clientcat;

                objSqlCommand.Parameters.Add("@max_area", SqlDbType.VarChar);
                objSqlCommand.Parameters["@max_area"].Value = max_area;
                /*new change ankur for agency*/


                objSqlCommand.Parameters.Add("@type", SqlDbType.VarChar);
                objSqlCommand.Parameters["@type"].Value = type;

                objSqlCommand.Parameters.Add("@agencycode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencycode"].Value = agencycode;


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
        /*new change ankur for agency*/

        public DataSet soloinsert(string compcode, string userid, string ratecode, string adtype, string rategroupcode, string adcategory, string currency, string adsubcategory, string package, string packagedesc, string uom, string sizefrom, string sizeto, string consumption, string color, string colorchrty, string weekdrate, string weeminrate, string extweerate, string focusdarate, string focminrate, string focexrate, string validfromdate, string validtill, string remarks, string premium, string premiumval, string rateuniqueid, string weekendrate, string weekendmin, string weekendextra, string combination, string insertsolo,string flag,string adscat4,string adscat5,string adscat6,string frominsert,string toinsert,string agtype,string clientcat,string minadarea,string type,string agencycode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                string datefrom = validfromdate;
                string dateto = validtill;
                objSqlConnection.Open();
                objSqlCommand = GetCommand("insertsolorate", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@rateuniqueid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rateuniqueid"].Value = rateuniqueid;


                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@datefrom", SqlDbType.VarChar);
                objSqlCommand.Parameters["@datefrom"].Value = datefrom;


                objSqlCommand.Parameters.Add("@dateto", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dateto"].Value = dateto;


                objSqlCommand.Parameters.Add("@ratecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ratecode"].Value = ratecode;

                objSqlCommand.Parameters.Add("@adtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adtype"].Value = adtype;


                objSqlCommand.Parameters.Add("@rategroupcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rategroupcode"].Value = rategroupcode;

                objSqlCommand.Parameters.Add("@adcategory", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adcategory"].Value = adcategory;


                objSqlCommand.Parameters.Add("@currency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@currency"].Value = currency;

                objSqlCommand.Parameters.Add("@adsubcategory", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adsubcategory"].Value = adsubcategory;


                objSqlCommand.Parameters.Add("@package", SqlDbType.VarChar);
                objSqlCommand.Parameters["@package"].Value = package;

                objSqlCommand.Parameters.Add("@premium", SqlDbType.VarChar);
                objSqlCommand.Parameters["@premium"].Value = premium;


                objSqlCommand.Parameters.Add("@premiumval", SqlDbType.VarChar);
                objSqlCommand.Parameters["@premiumval"].Value = premiumval;



                objSqlCommand.Parameters.Add("@packagedesc", SqlDbType.VarChar);
                objSqlCommand.Parameters["@packagedesc"].Value = packagedesc;

                objSqlCommand.Parameters.Add("@uom", SqlDbType.VarChar);
                objSqlCommand.Parameters["@uom"].Value = uom;


                objSqlCommand.Parameters.Add("@sizefrom", SqlDbType.Int);
                if (sizefrom == "" || sizefrom == null)
                {
                    objSqlCommand.Parameters["@sizefrom"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@sizefrom"].Value = sizefrom;
                }

                objSqlCommand.Parameters.Add("@sizeto", SqlDbType.Int);
                if (sizeto == "" || sizeto == null)
                {
                    objSqlCommand.Parameters["@sizeto"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@sizeto"].Value = sizeto;
                }


                objSqlCommand.Parameters.Add("@consumption", SqlDbType.Int);
                if (consumption == "" || consumption == null)
                {
                    objSqlCommand.Parameters["@consumption"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@consumption"].Value = consumption;
                }

                objSqlCommand.Parameters.Add("@color", SqlDbType.VarChar);
                objSqlCommand.Parameters["@color"].Value = color;

                objSqlCommand.Parameters.Add("@remarks", SqlDbType.VarChar);
                objSqlCommand.Parameters["@remarks"].Value = remarks;


                objSqlCommand.Parameters.Add("@colorchrty", SqlDbType.VarChar);
                objSqlCommand.Parameters["@colorchrty"].Value = colorchrty;

                objSqlCommand.Parameters.Add("@weekdrate", SqlDbType.Decimal);
                if (weekdrate == "" || weekdrate == null)
                {
                    objSqlCommand.Parameters["@weekdrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@weekdrate"].Value = Convert.ToDecimal(weekdrate);
                }



                objSqlCommand.Parameters.Add("@weeminrate", SqlDbType.Decimal);
                if (weeminrate == "" || weeminrate == null)
                {
                    objSqlCommand.Parameters["@weeminrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@weeminrate"].Value = Convert.ToDecimal(weeminrate);
                }


                objSqlCommand.Parameters.Add("@extweerate", SqlDbType.Decimal);
                if (extweerate == "" || extweerate == null)
                {
                    objSqlCommand.Parameters["@extweerate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@extweerate"].Value = Convert.ToDecimal(extweerate);
                }

                objSqlCommand.Parameters.Add("@focusdarate", SqlDbType.Decimal);
                if (focusdarate == "" || focusdarate == null)
                {
                    objSqlCommand.Parameters["@focusdarate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@focusdarate"].Value = Convert.ToDecimal(focusdarate);
                }


                objSqlCommand.Parameters.Add("@focminrate", SqlDbType.Decimal);
                if (focminrate == "" || focminrate == null)
                {
                    objSqlCommand.Parameters["@focminrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@focminrate"].Value = Convert.ToDecimal(focminrate);
                }

                objSqlCommand.Parameters.Add("@focexrate", SqlDbType.Decimal);
                if (focexrate == "" || focexrate == null)
                {
                    objSqlCommand.Parameters["@focexrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@focexrate"].Value = Convert.ToDecimal(focexrate);
                }

                objSqlCommand.Parameters.Add("@validfromdate", SqlDbType.DateTime);
                if (validfromdate == "" || validfromdate == null)
                {
                    objSqlCommand.Parameters["@validfromdate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@validfromdate"].Value = validfromdate;
                }

                objSqlCommand.Parameters.Add("@validtill", SqlDbType.DateTime);
                if (validtill == "" || validtill == null)
                {
                    objSqlCommand.Parameters["@validtill"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@validtill"].Value = validtill;
                }


                //Convert.ToDateTime();
                objSqlCommand.Parameters.Add("@weekendrate", SqlDbType.Decimal);
                if (weekendrate == "" || weekendrate == null)
                {
                    objSqlCommand.Parameters["@weekendrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@weekendrate"].Value = Convert.ToDecimal(weekendrate);
                }


                objSqlCommand.Parameters.Add("@weekendmin", SqlDbType.Decimal);
                if (weekendmin == "" || weekendmin == null)
                {
                    objSqlCommand.Parameters["@weekendmin"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@weekendmin"].Value = Convert.ToDecimal(weekendmin);
                }

                objSqlCommand.Parameters.Add("@weekendextra", SqlDbType.Decimal);
                if (weekendextra == "" || weekendextra == null)
                {
                    objSqlCommand.Parameters["@weekendextra"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@weekendextra"].Value = Convert.ToDecimal(weekendextra);
                }


                objSqlCommand.Parameters.Add("@combination", SqlDbType.VarChar);
                objSqlCommand.Parameters["@combination"].Value = combination;

                objSqlCommand.Parameters.Add("@insertsolo", SqlDbType.VarChar);
                objSqlCommand.Parameters["@insertsolo"].Value = insertsolo;

                objSqlCommand.Parameters.Add("@flag", SqlDbType.VarChar);
                objSqlCommand.Parameters["@flag"].Value = flag;

                objSqlCommand.Parameters.Add("@adscat6", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adscat6"].Value = adscat6;

                objSqlCommand.Parameters.Add("@adscat5", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adscat5"].Value = adscat5;

                objSqlCommand.Parameters.Add("@adscat4", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adscat4"].Value = adscat4;

                objSqlCommand.Parameters.Add("@frominsert", SqlDbType.Int);
                if (frominsert == "" || frominsert == null)
                {
                    objSqlCommand.Parameters["@frominsert"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@frominsert"].Value = frominsert;
                }

                objSqlCommand.Parameters.Add("@toinsert", SqlDbType.Int);
                if (toinsert == "" || toinsert == null)
                {
                    objSqlCommand.Parameters["@toinsert"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@toinsert"].Value = toinsert;
                }

                objSqlCommand.Parameters.Add("@agtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agtype"].Value = agtype;

                objSqlCommand.Parameters.Add("@clientcat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@clientcat"].Value = clientcat;


                objSqlCommand.Parameters.Add("@minadarea", SqlDbType.VarChar);
                if (minadarea == "")
                {
                    objSqlCommand.Parameters["@minadarea"].Value = "0";
                }
                else
                {
                    objSqlCommand.Parameters["@minadarea"].Value = minadarea;
                }
                /*new change ankur for agency*/
                objSqlCommand.Parameters.Add("@type", SqlDbType.VarChar);
                objSqlCommand.Parameters["@type"].Value = type;

                objSqlCommand.Parameters.Add("@agencycode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencycode"].Value = agencycode;
                

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

        /*new change ankur for agency*/
        public DataSet solorateget(string compcode, string userid, string ratecode, string adtype, string rategroupcode, string adcategory, string currency, string adsubcategory, string package, string packagedesc, string uom, string sizefrom, string sizeto, string consumption, string color, string colorchrty, string weekdrate, string weeminrate, string extweerate, string focusdarate, string focminrate, string focexrate, string validfromdate, string validtill, string remarks, string premium, string premiumval, string rateuniqueid, string weekendrate, string weekendmin, string weekendextra, string combination, string insertsolo,string clientcat,string minadarea,string type,string agencycode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                string datefrom = validfromdate;
                string dateto = validtill;
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getsolorate", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@rateuniqueid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rateuniqueid"].Value = rateuniqueid;


                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@datefrom", SqlDbType.VarChar);
                objSqlCommand.Parameters["@datefrom"].Value = datefrom;


                objSqlCommand.Parameters.Add("@dateto", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dateto"].Value = dateto;


                objSqlCommand.Parameters.Add("@ratecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ratecode"].Value = ratecode;

                objSqlCommand.Parameters.Add("@adtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adtype"].Value = adtype;


                objSqlCommand.Parameters.Add("@rategroupcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rategroupcode"].Value = rategroupcode;

                objSqlCommand.Parameters.Add("@adcategory", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adcategory"].Value = adcategory;


                objSqlCommand.Parameters.Add("@currency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@currency"].Value = currency;

                objSqlCommand.Parameters.Add("@adsubcategory", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adsubcategory"].Value = adsubcategory;


                objSqlCommand.Parameters.Add("@package", SqlDbType.VarChar);
                objSqlCommand.Parameters["@package"].Value = package;

                objSqlCommand.Parameters.Add("@premium", SqlDbType.VarChar);
                objSqlCommand.Parameters["@premium"].Value = premium;


                objSqlCommand.Parameters.Add("@premiumval", SqlDbType.VarChar);
                objSqlCommand.Parameters["@premiumval"].Value = premiumval;



                objSqlCommand.Parameters.Add("@packagedesc", SqlDbType.VarChar);
                objSqlCommand.Parameters["@packagedesc"].Value = packagedesc;

                objSqlCommand.Parameters.Add("@uom", SqlDbType.VarChar);
                objSqlCommand.Parameters["@uom"].Value = uom;


                objSqlCommand.Parameters.Add("@sizefrom", SqlDbType.Int);
                if (sizefrom == "" || sizefrom == null)
                {
                    objSqlCommand.Parameters["@sizefrom"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@sizefrom"].Value = sizefrom;
                }

                objSqlCommand.Parameters.Add("@sizeto", SqlDbType.Int);
                if (sizeto == "" || sizeto == null)
                {
                    objSqlCommand.Parameters["@sizeto"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@sizeto"].Value = sizeto;
                }


                objSqlCommand.Parameters.Add("@consumption", SqlDbType.Int);
                if (consumption == "" || consumption == null)
                {
                    objSqlCommand.Parameters["@consumption"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@consumption"].Value = consumption;
                }

                objSqlCommand.Parameters.Add("@color", SqlDbType.VarChar);
                objSqlCommand.Parameters["@color"].Value = color;

                objSqlCommand.Parameters.Add("@remarks", SqlDbType.VarChar);
                objSqlCommand.Parameters["@remarks"].Value = remarks;


                objSqlCommand.Parameters.Add("@colorchrty", SqlDbType.VarChar);
                objSqlCommand.Parameters["@colorchrty"].Value = colorchrty;

                objSqlCommand.Parameters.Add("@weekdrate", SqlDbType.Decimal);
                if (weekdrate == "" || weekdrate == null)
                {
                    objSqlCommand.Parameters["@weekdrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@weekdrate"].Value = Convert.ToDecimal(weekdrate);
                }



                objSqlCommand.Parameters.Add("@weeminrate", SqlDbType.Decimal);
                if (weeminrate == "" || weeminrate == null)
                {
                    objSqlCommand.Parameters["@weeminrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@weeminrate"].Value = Convert.ToDecimal(weeminrate);
                }


                objSqlCommand.Parameters.Add("@extweerate", SqlDbType.Decimal);
                if (extweerate == "" || extweerate == null)
                {
                    objSqlCommand.Parameters["@extweerate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@extweerate"].Value = Convert.ToDecimal(extweerate);
                }

                objSqlCommand.Parameters.Add("@focusdarate", SqlDbType.Decimal);
                if (focusdarate == "" || focusdarate == null)
                {
                    objSqlCommand.Parameters["@focusdarate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@focusdarate"].Value = Convert.ToDecimal(focusdarate);
                }


                objSqlCommand.Parameters.Add("@focminrate", SqlDbType.Decimal);
                if (focminrate == "" || focminrate == null)
                {
                    objSqlCommand.Parameters["@focminrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@focminrate"].Value = Convert.ToDecimal(focminrate);
                }

                objSqlCommand.Parameters.Add("@focexrate", SqlDbType.Decimal);
                if (focexrate == "" || focexrate == null)
                {
                    objSqlCommand.Parameters["@focexrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@focexrate"].Value = Convert.ToDecimal(focexrate);
                }

                objSqlCommand.Parameters.Add("@validfromdate", SqlDbType.DateTime);
                if (validfromdate == "" || validfromdate == null)
                {
                    objSqlCommand.Parameters["@validfromdate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@validfromdate"].Value = validfromdate;
                }

                objSqlCommand.Parameters.Add("@validtill", SqlDbType.DateTime);
                if (validtill == "" || validtill == null)
                {
                    objSqlCommand.Parameters["@validtill"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@validtill"].Value = validtill;
                }


                //Convert.ToDateTime();
                objSqlCommand.Parameters.Add("@weekendrate", SqlDbType.Decimal);
                if (weekendrate == "" || weekendrate == null)
                {
                    objSqlCommand.Parameters["@weekendrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@weekendrate"].Value = Convert.ToDecimal(weekendrate);
                }


                objSqlCommand.Parameters.Add("@weekendmin", SqlDbType.Decimal);
                if (weekendmin == "" || weekendmin == null)
                {
                    objSqlCommand.Parameters["@weekendmin"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@weekendmin"].Value = Convert.ToDecimal(weekendmin);
                }

                objSqlCommand.Parameters.Add("@weekendextra", SqlDbType.Decimal);
                if (weekendextra == "" || weekendextra == null)
                {
                    objSqlCommand.Parameters["@weekendextra"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@weekendextra"].Value = Convert.ToDecimal(weekendextra);
                }


                objSqlCommand.Parameters.Add("@combination", SqlDbType.VarChar);
                objSqlCommand.Parameters["@combination"].Value = combination;

                objSqlCommand.Parameters.Add("@insertsolo", SqlDbType.VarChar);
                objSqlCommand.Parameters["@insertsolo"].Value = insertsolo;

                objSqlCommand.Parameters.Add("@clientcat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@clientcat"].Value = clientcat;

                objSqlCommand.Parameters.Add("@minadarea", SqlDbType.VarChar);
                if (minadarea == "")
                {
                    objSqlCommand.Parameters["@minadarea"].Value = "0";
                }
                else
                {
                    objSqlCommand.Parameters["@minadarea"].Value = minadarea;
                }


                objSqlCommand.Parameters.Add("@type", SqlDbType.VarChar);
                objSqlCommand.Parameters["@type"].Value = type;

                objSqlCommand.Parameters.Add("@agencycode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencycode"].Value = agencycode;

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
        /*new change ankur 17 feb*/
        /*new change ankur for agency*/
        public DataSet insertintorate(string compcode, string userid, string ratecode, string adtype, string rategroupcode, string adcategory, string currency, string adsubcategory, string package, string packagedesc, string uom, string sizefrom, string sizeto, string consumption, string color, string colorchrty, string weekdrate, string weeminrate, string extweerate, string focusdarate, string focminrate, string focexrate, string validfromdate, string validtill, string remarks, string premium, string premiumval, string rateuniqueid, string weekendrate, string weekendmin, string weekendextra, string minadarea, string editionfrom, string editionto, string flramount, string flrdiscount, string scheme, string adscat4, string adscat5, string adscat6, string frominsert, string toinsert, string agtype, string clientcat, string max_area, string type, string agencycode, string dateformat, string pubcenter, string rate_sun, string rate_mon, string rate_tue, string rate_wed, string rate_thu, string rate_fri, string rate_sat, string rate_sun_extra, string rate_mon_extra, string rate_tue_extra, string rate_wed_extra, string rate_thu_extra, string rate_fri_extra, string rate_sat_extra, string width_max, string priority, string vat, string Adon, string refrence, string cancellation, string positionprem)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                //string datefrom = validfromdate;
                //string dateto = validtill;
                objSqlConnection.Open();
                objSqlCommand = GetCommand("insertratemast", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@rateuniqueid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rateuniqueid"].Value = rateuniqueid;


                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                //objSqlCommand.Parameters.Add("@datefrom", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@datefrom"].Value = datefrom;


                //objSqlCommand.Parameters.Add("@dateto", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@dateto"].Value = dateto;


                objSqlCommand.Parameters.Add("@ratecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ratecode"].Value = ratecode;

                objSqlCommand.Parameters.Add("@adtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adtype"].Value = adtype;


                objSqlCommand.Parameters.Add("@rategroupcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rategroupcode"].Value = rategroupcode;

                objSqlCommand.Parameters.Add("@adcategory", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adcategory"].Value = adcategory;


                objSqlCommand.Parameters.Add("@currency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@currency"].Value = currency;

                objSqlCommand.Parameters.Add("@adsubcategory", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adsubcategory"].Value = adsubcategory;


                objSqlCommand.Parameters.Add("@package", SqlDbType.VarChar);
                objSqlCommand.Parameters["@package"].Value = package;

                objSqlCommand.Parameters.Add("@premium", SqlDbType.VarChar);
                objSqlCommand.Parameters["@premium"].Value = premium;


                objSqlCommand.Parameters.Add("@premiumval", SqlDbType.VarChar);
                objSqlCommand.Parameters["@premiumval"].Value = premiumval;



                objSqlCommand.Parameters.Add("@packagedesc", SqlDbType.VarChar);
                objSqlCommand.Parameters["@packagedesc"].Value = packagedesc;

                objSqlCommand.Parameters.Add("@uom", SqlDbType.VarChar);
                objSqlCommand.Parameters["@uom"].Value = uom;


                objSqlCommand.Parameters.Add("@sizefrom", SqlDbType.Float);
                if (sizefrom == "" || sizefrom == null)
                {
                    objSqlCommand.Parameters["@sizefrom"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@sizefrom"].Value = sizefrom;
                }

                objSqlCommand.Parameters.Add("@sizeto", SqlDbType.Float);
                if (sizeto == "" || sizeto == null)
                {
                    objSqlCommand.Parameters["@sizeto"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@sizeto"].Value = sizeto;
                }


                objSqlCommand.Parameters.Add("@consumption", SqlDbType.Int);
                if (consumption == "" || consumption == null)
                {
                    objSqlCommand.Parameters["@consumption"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@consumption"].Value = consumption;
                }

                objSqlCommand.Parameters.Add("@color", SqlDbType.VarChar);
                objSqlCommand.Parameters["@color"].Value = color;

                objSqlCommand.Parameters.Add("@remarks", SqlDbType.VarChar);
                objSqlCommand.Parameters["@remarks"].Value = remarks;


                objSqlCommand.Parameters.Add("@colorchrty", SqlDbType.VarChar);
                objSqlCommand.Parameters["@colorchrty"].Value = colorchrty;

                objSqlCommand.Parameters.Add("@weekdrate", SqlDbType.Decimal);
                if (weekdrate == "" || weekdrate == null)
                {
                    objSqlCommand.Parameters["@weekdrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@weekdrate"].Value = Convert.ToDecimal(weekdrate);
                }



                objSqlCommand.Parameters.Add("@weeminrate", SqlDbType.Decimal);
                if (weeminrate == "" || weeminrate == null)
                {
                    objSqlCommand.Parameters["@weeminrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@weeminrate"].Value = Convert.ToDecimal(weeminrate);
                }


                objSqlCommand.Parameters.Add("@extweerate", SqlDbType.Decimal);
                if (extweerate == "" || extweerate == null)
                {
                    objSqlCommand.Parameters["@extweerate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@extweerate"].Value = Convert.ToDecimal(extweerate);
                }

                objSqlCommand.Parameters.Add("@focusdarate", SqlDbType.Decimal);
                if (focusdarate == "" || focusdarate == null)
                {
                    objSqlCommand.Parameters["@focusdarate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@focusdarate"].Value = Convert.ToDecimal(focusdarate);
                }


                objSqlCommand.Parameters.Add("@focminrate", SqlDbType.Decimal);
                if (focminrate == "" || focminrate == null)
                {
                    objSqlCommand.Parameters["@focminrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@focminrate"].Value = Convert.ToDecimal(focminrate);
                }

                objSqlCommand.Parameters.Add("@focexrate", SqlDbType.Decimal);
                if (focexrate == "" || focexrate == null)
                {
                    objSqlCommand.Parameters["@focexrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@focexrate"].Value = Convert.ToDecimal(focexrate);
                }

                objSqlCommand.Parameters.Add("@validfromdate", SqlDbType.DateTime);
                if (validfromdate == "" || validfromdate == null)
                {
                    objSqlCommand.Parameters["@validfromdate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = validfromdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        validfromdate = mm + "/" + dd + "/" + yy;


                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = validfromdate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        validfromdate = mm + "/" + dd + "/" + yy;


                    }
                    objSqlCommand.Parameters["@validfromdate"].Value = validfromdate;
                }

                objSqlCommand.Parameters.Add("@validtill", SqlDbType.DateTime);
                if (validtill == "" || validtill == null)
                {
                    objSqlCommand.Parameters["@validtill"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = validtill.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        validtill = mm + "/" + dd + "/" + yy;


                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = validtill.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        validtill = mm + "/" + dd + "/" + yy;


                    }
                    objSqlCommand.Parameters["@validtill"].Value = validtill;
                }


                //Convert.ToDateTime();
                objSqlCommand.Parameters.Add("@weekendrate", SqlDbType.Decimal);
                if (weekendrate == "" || weekendrate == null)
                {
                    objSqlCommand.Parameters["@weekendrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@weekendrate"].Value = Convert.ToDecimal(weekendrate);
                }


                objSqlCommand.Parameters.Add("@weekendmin", SqlDbType.Decimal);
                if (weekendmin == "" || weekendmin == null)
                {
                    objSqlCommand.Parameters["@weekendmin"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@weekendmin"].Value = Convert.ToDecimal(weekendmin);
                }

                objSqlCommand.Parameters.Add("@weekendextra", SqlDbType.Decimal);
                if (weekendextra == "" || weekendextra == null)
                {
                    objSqlCommand.Parameters["@weekendextra"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@weekendextra"].Value = Convert.ToDecimal(weekendextra);
                }

                objSqlCommand.Parameters.Add("@minadarea", SqlDbType.Decimal);
                if (minadarea == "" || minadarea == null)
                {
                    objSqlCommand.Parameters["@minadarea"].Value = Convert.ToDecimal("0"); ;
                }
                else
                {
                    objSqlCommand.Parameters["@minadarea"].Value = Convert.ToDecimal(minadarea);
                }

                objSqlCommand.Parameters.Add("@editionfrom", SqlDbType.Int);
                if (editionfrom == "" || editionfrom == null)
                {
                    objSqlCommand.Parameters["@editionfrom"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@editionfrom"].Value = Convert.ToInt32(editionfrom);
                }

                objSqlCommand.Parameters.Add("@editionto", SqlDbType.Int);
                if (editionto == "" || editionto == null)
                {
                    objSqlCommand.Parameters["@editionto"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@editionto"].Value = Convert.ToInt32(editionto);
                }

                objSqlCommand.Parameters.Add("@flramount", SqlDbType.Decimal);
                if (flramount == "" || flramount == null)
                {
                    objSqlCommand.Parameters["@flramount"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@flramount"].Value = Convert.ToDecimal(flramount);
                }


                objSqlCommand.Parameters.Add("@flrdiscount", SqlDbType.Decimal);
                if (flrdiscount == "" || flrdiscount == null)
                {
                    objSqlCommand.Parameters["@flrdiscount"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@flrdiscount"].Value = Convert.ToDecimal(flrdiscount);
                }

                objSqlCommand.Parameters.Add("@scheme", SqlDbType.VarChar);
                objSqlCommand.Parameters["@scheme"].Value = scheme;

                objSqlCommand.Parameters.Add("@adscat6", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adscat6"].Value = adscat6;


                objSqlCommand.Parameters.Add("@adscat5", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adscat5"].Value = adscat5;


                objSqlCommand.Parameters.Add("@adscat4", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adscat4"].Value = adscat4;

                objSqlCommand.Parameters.Add("@frominsert", SqlDbType.Int);
                if (frominsert == "" || frominsert == null)
                {
                    objSqlCommand.Parameters["@frominsert"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@frominsert"].Value = frominsert;
                }


                objSqlCommand.Parameters.Add("@toinsert", SqlDbType.Int);
                if (toinsert == "" || toinsert == null)
                {
                    objSqlCommand.Parameters["@toinsert"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@toinsert"].Value = toinsert;
                }

                objSqlCommand.Parameters.Add("@agtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agtype"].Value = agtype;

                objSqlCommand.Parameters.Add("@clientcat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@clientcat"].Value = clientcat;

                objSqlCommand.Parameters.Add("@max_area", SqlDbType.VarChar);
                objSqlCommand.Parameters["@max_area"].Value = max_area;
                /*new change ankur for agency*/

                objSqlCommand.Parameters.Add("@type", SqlDbType.VarChar);
                objSqlCommand.Parameters["@type"].Value = type;

                objSqlCommand.Parameters.Add("@agencycode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencycode"].Value = agencycode;


                objSqlCommand.Parameters.Add("@pubcenter", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pubcenter"].Value = pubcenter;

                objSqlCommand.Parameters.Add("@rate_sun", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rate_sun"].Value = rate_sun;

                objSqlCommand.Parameters.Add("@rate_mon", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rate_mon"].Value = rate_mon;
                objSqlCommand.Parameters.Add("@rate_tue", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rate_tue"].Value = rate_tue;
                objSqlCommand.Parameters.Add("@rate_wed", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rate_wed"].Value = rate_wed;
                objSqlCommand.Parameters.Add("@rate_thu", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rate_thu"].Value = rate_thu;

                objSqlCommand.Parameters.Add("@rate_fri", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rate_fri"].Value = rate_fri;

                objSqlCommand.Parameters.Add("@rate_sat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rate_sat"].Value = rate_sat;

                objSqlCommand.Parameters.Add("@rate_sun_extra", SqlDbType.VarChar);
                if (rate_sun_extra == "")
                    objSqlCommand.Parameters["@rate_sun_extra"].Value = "0";
                else
                    objSqlCommand.Parameters["@rate_sun_extra"].Value = rate_sun_extra;

                objSqlCommand.Parameters.Add("@rate_mon_extra", SqlDbType.VarChar);
                if (rate_mon_extra == "")
                    objSqlCommand.Parameters["@rate_mon_extra"].Value = "0";
                else
                    objSqlCommand.Parameters["@rate_mon_extra"].Value = rate_mon_extra;

                objSqlCommand.Parameters.Add("@rate_tue_extra", SqlDbType.VarChar);
                if (rate_tue_extra == "")
                    objSqlCommand.Parameters["@rate_tue_extra"].Value = "0";
                else
                    objSqlCommand.Parameters["@rate_tue_extra"].Value = rate_tue_extra;


                objSqlCommand.Parameters.Add("@rate_wed_extra", SqlDbType.VarChar);
                if (rate_wed_extra == "")
                    objSqlCommand.Parameters["@rate_wed_extra"].Value = "0";
                else
                    objSqlCommand.Parameters["@rate_wed_extra"].Value = rate_wed_extra;


                objSqlCommand.Parameters.Add("@rate_thu_extra", SqlDbType.VarChar);
                if (rate_thu_extra == "")
                    objSqlCommand.Parameters["@rate_thu_extra"].Value = "0";
                else
                    objSqlCommand.Parameters["@rate_thu_extra"].Value = rate_thu_extra;


                objSqlCommand.Parameters.Add("@rate_fri_extra", SqlDbType.VarChar);
                if (rate_fri_extra == "")
                    objSqlCommand.Parameters["@rate_fri_extra"].Value = "0";
                else
                    objSqlCommand.Parameters["@rate_fri_extra"].Value = rate_fri_extra;

                objSqlCommand.Parameters.Add("@rate_sat_extra", SqlDbType.VarChar);
                if (rate_sat_extra == "")
                    objSqlCommand.Parameters["@rate_sat_extra"].Value = "0";
                else
                    objSqlCommand.Parameters["@rate_sat_extra"].Value = rate_sat_extra;


                objSqlCommand.Parameters.Add("@width_max", SqlDbType.VarChar);
                objSqlCommand.Parameters["@width_max"].Value = width_max;

                objSqlCommand.Parameters.Add("@priority_m", SqlDbType.VarChar);
                if (priority == "")
                    objSqlCommand.Parameters["@priority_m"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@priority_m"].Value = priority;
                
                objSqlCommand.Parameters.Add("@vat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@vat"].Value = vat;

                objSqlCommand.Parameters.Add("@Adon", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Adon"].Value = Adon;


                objSqlCommand.Parameters.Add("@refrence", SqlDbType.VarChar);
                objSqlCommand.Parameters["@refrence"].Value = refrence;

                objSqlCommand.Parameters.Add("@p_cancellation", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_cancellation"].Value = cancellation;

                objSqlCommand.Parameters.Add("@p_Positionprem", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_Positionprem"].Value = positionprem;
                

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

        /*new change ankur for agency*/
        public DataSet executedate(string compcode, string ratecode, string adtype, string currency, string rategroup, string colorcode, string uomcode, string packagecode, string pubcenter, string adcat, string positionprem,string validfrom,string dateformat,string subcat)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("executeratecode", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@ratecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ratecode"].Value = ratecode;

                //objSqlCommand.Parameters.Add("@uom", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@uom"].Value = uom;

                objSqlCommand.Parameters.Add("@adtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adtype"].Value = adtype;

                objSqlCommand.Parameters.Add("@currency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@currency"].Value = currency;

                objSqlCommand.Parameters.Add("@rategroup", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rategroup"].Value = rategroup;

                objSqlCommand.Parameters.Add("@colorcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@colorcode"].Value = colorcode;

                objSqlCommand.Parameters.Add("@uomcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@uomcode"].Value = uomcode;

                objSqlCommand.Parameters.Add("@packagecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@packagecode"].Value = packagecode;
                /*new change ankur for agency*/


                objSqlCommand.Parameters.Add("@pubcenter", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pubcenter"].Value = pubcenter;


                objSqlCommand.Parameters.Add("@adcat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adcat"].Value = adcat;

                objSqlCommand.Parameters.Add("@p_Positionprem", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_Positionprem"].Value = positionprem;


                objSqlCommand.Parameters.Add("@pvalid_fromdt", SqlDbType.VarChar);
                if (validfrom == "")
                {
                    objSqlCommand.Parameters["@pvalid_fromdt"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = validfrom.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        validfrom = mm + "/" + dd + "/" + yy;


                    }




                    objSqlCommand.Parameters["@pvalid_fromdt"].Value = Convert.ToDateTime(validfrom).ToString("dd-MMMM-yyyy"); 
                }

           

                objSqlCommand.Parameters.Add("@p_adsubcat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_adsubcat"].Value = subcat;


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
        public DataSet premiumbindcatwise(string compcode, string CATCODE)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("bindpremiumcatwise", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@advcatcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@advcatcode"].Value = CATCODE;





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

        public DataSet premiumbind(string compcode,string adtype)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("bindpremiumforrate", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@adtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adtype"].Value = adtype;





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

        public DataSet paccolochk(string package,string color,string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("chkpackagecolor", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@package", SqlDbType.VarChar);
                objSqlCommand.Parameters["@package"].Value = package;

                objSqlCommand.Parameters.Add("@color", SqlDbType.VarChar);
                objSqlCommand.Parameters["@color"].Value = color;







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

        /*new change ankur 17 feb*/
        /*new change ankur for agency*/
        public DataSet modifyrate(string compcode, string userid, string ratecode, string adtype, string rategroupcode, string adcategory, string currency, string adsubcategory, string package, string packagedesc, string uom, string sizefrom, string sizeto, string consumption, string color, string colorchrty, string weekdrate, string weeminrate, string extweerate, string focusdarate, string focminrate, string focexrate, string validfromdate, string validtill, string remarks, string premium, string premiumval, string rateuniqueid, string weekendrate, string weekendmin, string weekendextra, string minadarea, string editionfrom, string editionto, string flramount, string flrdiscount, string scheme, string adscat4, string adscat5, string adscat6, string frominsert, string toinsert, string agtype, string clientcat, string max_area, string type, string agencycode, string dateformat, string rate_sun, string rate_mon, string rate_tue, string rate_wed, string rate_thu, string rate_fri, string rate_sat, string rate_sun_extra, string rate_mon_extra, string rate_tue_extra, string rate_wed_extra, string rate_thu_extra, string rate_fri_extra, string rate_sat_extra, string width_max, string priority, string vat, string Adon, string refrence, string cancellation, string positionprem)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("modifyratecode", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@rateuniqueid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rateuniqueid"].Value = rateuniqueid;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@ratecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ratecode"].Value = ratecode;

                objSqlCommand.Parameters.Add("@adtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adtype"].Value = adtype;


                objSqlCommand.Parameters.Add("@rategroupcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rategroupcode"].Value = rategroupcode;

                objSqlCommand.Parameters.Add("@adcategory", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adcategory"].Value = adcategory;


                objSqlCommand.Parameters.Add("@currency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@currency"].Value = currency;

                objSqlCommand.Parameters.Add("@adsubcategory", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adsubcategory"].Value = adsubcategory;


                objSqlCommand.Parameters.Add("@package", SqlDbType.VarChar);
                objSqlCommand.Parameters["@package"].Value = package;

                objSqlCommand.Parameters.Add("@premium", SqlDbType.VarChar);
                objSqlCommand.Parameters["@premium"].Value = premium;


                objSqlCommand.Parameters.Add("@premiumval", SqlDbType.VarChar);
                objSqlCommand.Parameters["@premiumval"].Value = premiumval;



                objSqlCommand.Parameters.Add("@packagedesc", SqlDbType.VarChar);
                objSqlCommand.Parameters["@packagedesc"].Value = packagedesc;

                objSqlCommand.Parameters.Add("@uom", SqlDbType.VarChar);
                objSqlCommand.Parameters["@uom"].Value = uom;


                objSqlCommand.Parameters.Add("@sizefrom", SqlDbType.Float);
                if (sizefrom == "" || sizefrom == null)
                {
                    objSqlCommand.Parameters["@sizefrom"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@sizefrom"].Value = sizefrom;
                }

                objSqlCommand.Parameters.Add("@sizeto", SqlDbType.Float);
                if (sizeto == "" || sizeto == null)
                {
                    objSqlCommand.Parameters["@sizeto"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@sizeto"].Value = sizeto;
                }


                objSqlCommand.Parameters.Add("@consumption", SqlDbType.Int);
                if (consumption == "" || consumption == null)
                {
                    objSqlCommand.Parameters["@consumption"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@consumption"].Value = Convert.ToInt32(consumption);
                }

                objSqlCommand.Parameters.Add("@color", SqlDbType.VarChar);
                objSqlCommand.Parameters["@color"].Value = color;

                objSqlCommand.Parameters.Add("@remarks", SqlDbType.VarChar);
                objSqlCommand.Parameters["@remarks"].Value = remarks;


                objSqlCommand.Parameters.Add("@colorchrty", SqlDbType.VarChar);
                objSqlCommand.Parameters["@colorchrty"].Value = colorchrty;

                objSqlCommand.Parameters.Add("@weekdrate", SqlDbType.Decimal);
                if (weekdrate == "" || weekdrate == null)
                {
                    objSqlCommand.Parameters["@weekdrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@weekdrate"].Value = Convert.ToDecimal(weekdrate);
                }



                objSqlCommand.Parameters.Add("@weeminrate", SqlDbType.Decimal);
                if (weeminrate == "" || weeminrate == null)
                {
                    objSqlCommand.Parameters["@weeminrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@weeminrate"].Value = Convert.ToDecimal(weeminrate);
                }


                objSqlCommand.Parameters.Add("@extweerate", SqlDbType.Decimal);
                if (extweerate == "" || extweerate == null)
                {
                    objSqlCommand.Parameters["@extweerate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@extweerate"].Value = Convert.ToDecimal(extweerate);
                }

                objSqlCommand.Parameters.Add("@focusdarate", SqlDbType.Decimal);
                if (focusdarate == "" || focusdarate == null)
                {
                    objSqlCommand.Parameters["@focusdarate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@focusdarate"].Value = Convert.ToDecimal(focusdarate);
                }


                objSqlCommand.Parameters.Add("@focminrate", SqlDbType.Decimal);
                if (focminrate == "" || focminrate == null)
                {
                    objSqlCommand.Parameters["@focminrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@focminrate"].Value = Convert.ToDecimal(focminrate);
                }

                objSqlCommand.Parameters.Add("@focexrate", SqlDbType.Decimal);
                if (focexrate == "" || focexrate == null)
                {
                    objSqlCommand.Parameters["@focexrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@focexrate"].Value = Convert.ToDecimal(focexrate);
                }

                objSqlCommand.Parameters.Add("@validfromdate", SqlDbType.DateTime);
                if (validfromdate == "" || validfromdate == null)
                {
                    objSqlCommand.Parameters["@validfromdate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = validfromdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        validfromdate = mm + "/" + dd + "/" + yy;


                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = validfromdate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        validfromdate = mm + "/" + dd + "/" + yy;


                    }
                    objSqlCommand.Parameters["@validfromdate"].Value = validfromdate;
                }

                objSqlCommand.Parameters.Add("@validtill", SqlDbType.DateTime);
                if (validtill == "" || validtill == null)
                {
                    objSqlCommand.Parameters["@validtill"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = validtill.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        validtill = mm + "/" + dd + "/" + yy;


                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = validtill.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        validtill = mm + "/" + dd + "/" + yy;


                    }
                    objSqlCommand.Parameters["@validtill"].Value = validtill;
                }

                objSqlCommand.Parameters.Add("@weekendrate", SqlDbType.Decimal);
                if (weekendrate == "" || weekendrate == null)
                {
                    objSqlCommand.Parameters["@weekendrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@weekendrate"].Value = Convert.ToDecimal(weekendrate);
                }


                objSqlCommand.Parameters.Add("@weekendmin", SqlDbType.Decimal);
                if (weekendmin == "" || weekendmin == null)
                {
                    objSqlCommand.Parameters["@weekendmin"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@weekendmin"].Value = Convert.ToDecimal(weekendmin);
                }

                objSqlCommand.Parameters.Add("@weekendextra", SqlDbType.Decimal);
                if (weekendextra == "" || weekendextra == null)
                {
                    objSqlCommand.Parameters["@weekendextra"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@weekendextra"].Value = Convert.ToDecimal(weekendextra);
                }

                objSqlCommand.Parameters.Add("@minadarea", SqlDbType.Decimal);
                if (minadarea == "" || minadarea == null)
                {
                    objSqlCommand.Parameters["@minadarea"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@minadarea"].Value = Convert.ToDecimal(minadarea);
                }

                objSqlCommand.Parameters.Add("@editionto", SqlDbType.Int);
                if (editionto == "" || editionto == null)
                {
                    objSqlCommand.Parameters["@editionto"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@editionto"].Value = Convert.ToInt32(editionto);
                }

                objSqlCommand.Parameters.Add("@editionfrom", SqlDbType.Int);
                if (editionfrom == "" || editionfrom == null)
                {
                    objSqlCommand.Parameters["@editionfrom"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@editionfrom"].Value = Convert.ToInt32(editionfrom);
                }

                objSqlCommand.Parameters.Add("@flramount", SqlDbType.Decimal);
                if (flramount == "" || flramount == null)
                {
                    objSqlCommand.Parameters["@flramount"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@flramount"].Value = Convert.ToDecimal(flramount);
                }


                objSqlCommand.Parameters.Add("@flrdiscount", SqlDbType.Decimal);
                if (flrdiscount == "" || flrdiscount == null)
                {
                    objSqlCommand.Parameters["@flrdiscount"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@flrdiscount"].Value = Convert.ToDecimal(flrdiscount);
                }

                objSqlCommand.Parameters.Add("@scheme", SqlDbType.VarChar);
                objSqlCommand.Parameters["@scheme"].Value = scheme;

                objSqlCommand.Parameters.Add("@adscat6", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adscat6"].Value = adscat6;


                objSqlCommand.Parameters.Add("@adscat5", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adscat5"].Value = adscat5;


                objSqlCommand.Parameters.Add("@adscat4", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adscat4"].Value = adscat4;

                objSqlCommand.Parameters.Add("@frominsert", SqlDbType.Int);
                if (frominsert == "" || frominsert == null)
                {
                    objSqlCommand.Parameters["@frominsert"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@frominsert"].Value = Convert.ToInt32(frominsert);
                }

                objSqlCommand.Parameters.Add("@toinsert", SqlDbType.Int);
                if (toinsert == "" || toinsert == null)
                {
                    objSqlCommand.Parameters["@toinsert"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@toinsert"].Value = Convert.ToInt32(toinsert);
                }


                objSqlCommand.Parameters.Add("@agtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agtype"].Value = agtype;

                objSqlCommand.Parameters.Add("@clientcat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@clientcat"].Value = clientcat;


                objSqlCommand.Parameters.Add("@max_area", SqlDbType.VarChar);
                objSqlCommand.Parameters["@max_area"].Value = max_area;

                /*new change ankur for agency*/

                objSqlCommand.Parameters.Add("@type", SqlDbType.VarChar);
                objSqlCommand.Parameters["@type"].Value = type;


                objSqlCommand.Parameters.Add("@agencycode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencycode"].Value = agencycode;

                objSqlCommand.Parameters.Add("@rate_sun", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rate_sun"].Value = rate_sun;

                objSqlCommand.Parameters.Add("@rate_mon", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rate_mon"].Value = rate_mon;


                objSqlCommand.Parameters.Add("@rate_tue", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rate_tue"].Value = rate_tue;

                objSqlCommand.Parameters.Add("@rate_wed", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rate_wed"].Value = rate_wed;

                objSqlCommand.Parameters.Add("@rate_thu", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rate_thu"].Value = rate_thu;

                objSqlCommand.Parameters.Add("@rate_fri", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rate_fri"].Value = rate_fri;

                objSqlCommand.Parameters.Add("@rate_sat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rate_sat"].Value = rate_sat;

                objSqlCommand.Parameters.Add("@rate_sun_extra", SqlDbType.VarChar);
                if (rate_sun_extra == "")
                    objSqlCommand.Parameters["@rate_sun_extra"].Value = "0";
                else
                    objSqlCommand.Parameters["@rate_sun_extra"].Value = rate_sun_extra;

                objSqlCommand.Parameters.Add("@rate_mon_extra", SqlDbType.VarChar);
                if (rate_mon_extra == "")
                    objSqlCommand.Parameters["@rate_mon_extra"].Value = "0";
                else
                    objSqlCommand.Parameters["@rate_mon_extra"].Value = rate_mon_extra;

                objSqlCommand.Parameters.Add("@rate_tue_extra", SqlDbType.VarChar);
                if (rate_tue_extra == "")
                    objSqlCommand.Parameters["@rate_tue_extra"].Value = "0";
                else
                    objSqlCommand.Parameters["@rate_tue_extra"].Value = rate_tue_extra;

                objSqlCommand.Parameters.Add("@rate_wed_extra", SqlDbType.VarChar);
                if (rate_wed_extra == "")
                    objSqlCommand.Parameters["@rate_wed_extra"].Value = "0";
                else
                    objSqlCommand.Parameters["@rate_wed_extra"].Value = rate_wed_extra;


                objSqlCommand.Parameters.Add("@rate_thu_extra", SqlDbType.VarChar);
                if (rate_thu_extra == "")
                    objSqlCommand.Parameters["@rate_thu_extra"].Value = "0";
                else
                    objSqlCommand.Parameters["@rate_thu_extra"].Value = rate_thu_extra;


                objSqlCommand.Parameters.Add("@rate_fri_extra", SqlDbType.VarChar);
                if (rate_fri_extra == "")
                    objSqlCommand.Parameters["@rate_fri_extra"].Value = "0";
                else
                    objSqlCommand.Parameters["@rate_fri_extra"].Value = rate_fri_extra;

                objSqlCommand.Parameters.Add("@rate_sat_extra", SqlDbType.VarChar);
                if (rate_sat_extra == "")
                    objSqlCommand.Parameters["@rate_sat_extra"].Value = "0";
                else
                    objSqlCommand.Parameters["@rate_sat_extra"].Value = rate_sat_extra;


                objSqlCommand.Parameters.Add("@width_max", SqlDbType.VarChar);
                objSqlCommand.Parameters["@width_max"].Value = width_max;

                objSqlCommand.Parameters.Add("@priority_m", SqlDbType.VarChar);
                if (priority == "")
                    objSqlCommand.Parameters["@priority_m"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@priority_m"].Value = priority;

                objSqlCommand.Parameters.Add("@vat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@vat"].Value = vat;

                objSqlCommand.Parameters.Add("@Adon", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Adon"].Value = Adon;


                objSqlCommand.Parameters.Add("@refrence", SqlDbType.VarChar);
                objSqlCommand.Parameters["@refrence"].Value = refrence;


                objSqlCommand.Parameters.Add("@p_cancellation", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_cancellation"].Value = cancellation;

                objSqlCommand.Parameters.Add("@p_Positionprem", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_Positionprem"].Value = positionprem;

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
        public DataSet description(string compcode, string rateuniqueid)
        {
                SqlConnection objSqlConnection;
                SqlCommand objSqlCommand;
                objSqlConnection = GetConnection();
                SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
                DataSet objDataSet = new DataSet();
                try
                {
                    objSqlConnection.Open();
                    objSqlCommand = GetCommand("binddescription", ref objSqlConnection);
                    objSqlCommand.CommandType = CommandType.StoredProcedure;

                    objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                    objSqlCommand.Parameters["@compcode"].Value = compcode;

                    objSqlCommand.Parameters.Add("@rateid", SqlDbType.VarChar);
                    objSqlCommand.Parameters["@rateid"].Value = rateuniqueid;
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
        /*new change ankur for agency*/
        //public DataSet description(string packagecode, string compcode, string txtratecode, string drpadtype, string drpadcategory, string drpsubcategory, string drpcolor, string drpcurrency, string validfromdate1, string validtill1, string uom, string adscat4, string adscat5, string adscat6, string premium, string sizefrom, string sizeto, string frominsert, string toinsert, string decimalvalue,string clientcat,string minadarea,string type,string agencycode)
        //{

        //    SqlConnection objSqlConnection;
        //    SqlCommand objSqlCommand;
        //    objSqlConnection = GetConnection();
        //    SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
        //    DataSet objDataSet = new DataSet();
        //    try
        //    {
        //        objSqlConnection.Open();
        //        objSqlCommand = GetCommand("binddescription", ref objSqlConnection);
        //        objSqlCommand.CommandType = CommandType.StoredProcedure;

        //        objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
        //        objSqlCommand.Parameters["@compcode"].Value = compcode;

        //        objSqlCommand.Parameters.Add("@packagecode", SqlDbType.VarChar);
        //        objSqlCommand.Parameters["@packagecode"].Value = packagecode;

        //        objSqlCommand.Parameters.Add("@txtratecode", SqlDbType.VarChar);
        //        objSqlCommand.Parameters["@txtratecode"].Value = txtratecode;

        //        objSqlCommand.Parameters.Add("@drpadtype", SqlDbType.VarChar);
        //        objSqlCommand.Parameters["@drpadtype"].Value = drpadtype;

        //        objSqlCommand.Parameters.Add("@drpadcategory", SqlDbType.VarChar);
        //        objSqlCommand.Parameters["@drpadcategory"].Value = drpadcategory;

        //        objSqlCommand.Parameters.Add("@drpsubcategory", SqlDbType.VarChar);
        //        objSqlCommand.Parameters["@drpsubcategory"].Value = drpsubcategory;

        //        objSqlCommand.Parameters.Add("@drpcolor", SqlDbType.VarChar);
        //        objSqlCommand.Parameters["@drpcolor"].Value = drpcolor;

        //        objSqlCommand.Parameters.Add("@drpcurrency", SqlDbType.VarChar);
        //        objSqlCommand.Parameters["@drpcurrency"].Value = drpcurrency;


        //        objSqlCommand.Parameters.Add("@validfromdate1", SqlDbType.VarChar);
        //        objSqlCommand.Parameters["@validfromdate1"].Value = validfromdate1;

        //        objSqlCommand.Parameters.Add("@validtill1", SqlDbType.VarChar);
        //        objSqlCommand.Parameters["@validtill1"].Value = validtill1;

        //        objSqlCommand.Parameters.Add("@uom", SqlDbType.VarChar);
        //        objSqlCommand.Parameters["@uom"].Value = uom;

        //        objSqlCommand.Parameters.Add("@adscat6", SqlDbType.VarChar);
        //        objSqlCommand.Parameters["@adscat6"].Value = adscat6;

        //        objSqlCommand.Parameters.Add("@adscat5", SqlDbType.VarChar);
        //        objSqlCommand.Parameters["@adscat5"].Value = adscat5;

        //        objSqlCommand.Parameters.Add("@adscat4", SqlDbType.VarChar);
        //        objSqlCommand.Parameters["@adscat4"].Value = adscat4;

        //        objSqlCommand.Parameters.Add("@premium", SqlDbType.VarChar);
        //        objSqlCommand.Parameters["@premium"].Value = premium;


        //        objSqlCommand.Parameters.Add("@sizefrom", SqlDbType.VarChar);
        //        objSqlCommand.Parameters["@sizefrom"].Value = sizefrom;

        //        objSqlCommand.Parameters.Add("@sizeto", SqlDbType.VarChar);
        //        objSqlCommand.Parameters["@sizeto"].Value = sizeto;

        //        objSqlCommand.Parameters.Add("@frominsert", SqlDbType.VarChar);
        //        objSqlCommand.Parameters["@frominsert"].Value = frominsert;

        //        objSqlCommand.Parameters.Add("@toinsert", SqlDbType.VarChar);
        //        objSqlCommand.Parameters["@toinsert"].Value = toinsert;

        //        objSqlCommand.Parameters.Add("@decimalvalue", SqlDbType.VarChar);
        //        objSqlCommand.Parameters["@decimalvalue"].Value = decimalvalue;

        //        objSqlCommand.Parameters.Add("@clientcat", SqlDbType.VarChar);
        //        objSqlCommand.Parameters["@clientcat"].Value = clientcat;


        //        objSqlCommand.Parameters.Add("@minadarea", SqlDbType.VarChar);
        //        if (minadarea == "")
        //        {
        //            objSqlCommand.Parameters["@minadarea"].Value = "0";
        //        }
        //        else
        //        {
        //            objSqlCommand.Parameters["@minadarea"].Value = minadarea;
        //        }

        //        objSqlCommand.Parameters.Add("@type", SqlDbType.VarChar);
        //        objSqlCommand.Parameters["@type"].Value = type;

        //        objSqlCommand.Parameters.Add("@agencycode", SqlDbType.VarChar);
        //        objSqlCommand.Parameters["@agencycode"].Value = agencycode;
                
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

        public DataSet descriptionforchange(string packagecode, string compcode, string center,string adtype)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("binddescriptionforchange", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@packagecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@packagecode"].Value = packagecode;

                objSqlCommand.Parameters.Add("@pubcenter", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pubcenter"].Value = center;


                objSqlCommand.Parameters.Add("@drpadtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@drpadtype"].Value = adtype;




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


        public DataSet getdescription(string packagecode, string compcode)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("binddescription12", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@packagecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@packagecode"].Value = packagecode;







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

        /*new change ankur for agency*/
        public DataSet deleterate(string ratecode,  string compcode,string type)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("deleterate", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@ratecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ratecode"].Value = ratecode;

                objSqlCommand.Parameters.Add("@type", SqlDbType.VarChar);
                objSqlCommand.Parameters["@type"].Value = type;

                
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
        /*new change ankur for agency*/
        public DataSet chkcolor(string colorcode, string compcode, string value,string packagecode, string txtratecode, string drpadtype, string drpadcategory, string drpsubcategory, string drpcolor, string drpcurrency, string validfromdate1, string validtill1,string bwcode, string uom,string adscat4,string adscat5,string adscat6,string premium,string sizefrom,string sizeto,string frominsert,string toinsert,string clientcat,string minadarea,string type,string agencycode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("chkopenorreff", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@colorcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@colorcode"].Value = colorcode;

                objSqlCommand.Parameters.Add("@value", SqlDbType.VarChar);
                objSqlCommand.Parameters["@value"].Value = value;

                objSqlCommand.Parameters.Add("@packagecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@packagecode"].Value = packagecode;

                objSqlCommand.Parameters.Add("@txtratecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@txtratecode"].Value = txtratecode;

                objSqlCommand.Parameters.Add("@drpadtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@drpadtype"].Value = drpadtype;

                objSqlCommand.Parameters.Add("@drpadcategory", SqlDbType.VarChar);
                objSqlCommand.Parameters["@drpadcategory"].Value = drpadcategory;

                objSqlCommand.Parameters.Add("@drpsubcategory", SqlDbType.VarChar);
                objSqlCommand.Parameters["@drpsubcategory"].Value = drpsubcategory;

                objSqlCommand.Parameters.Add("@drpcolor", SqlDbType.VarChar);
                objSqlCommand.Parameters["@drpcolor"].Value = drpcolor;

                objSqlCommand.Parameters.Add("@drpcurrency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@drpcurrency"].Value = drpcurrency;


                objSqlCommand.Parameters.Add("@validfromdate1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@validfromdate1"].Value = validfromdate1;

                objSqlCommand.Parameters.Add("@validtill1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@validtill1"].Value = validtill1;

                objSqlCommand.Parameters.Add("@bwcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@bwcode"].Value = bwcode;

                objSqlCommand.Parameters.Add("@uom", SqlDbType.VarChar);
                objSqlCommand.Parameters["@uom"].Value = uom;

                objSqlCommand.Parameters.Add("@adscat6", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adscat6"].Value = adscat6;

                objSqlCommand.Parameters.Add("@adscat5", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adscat5"].Value = adscat5;

                objSqlCommand.Parameters.Add("@adscat4", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adscat4"].Value = adscat4;

                objSqlCommand.Parameters.Add("@premium", SqlDbType.VarChar);
                objSqlCommand.Parameters["@premium"].Value = premium;

                objSqlCommand.Parameters.Add("@sizefrom", SqlDbType.VarChar);
                objSqlCommand.Parameters["@sizefrom"].Value = sizefrom;

                objSqlCommand.Parameters.Add("@sizeto", SqlDbType.VarChar);
                objSqlCommand.Parameters["@sizeto"].Value = sizeto;

                objSqlCommand.Parameters.Add("@frominsert", SqlDbType.VarChar);
                objSqlCommand.Parameters["@frominsert"].Value = frominsert;

                objSqlCommand.Parameters.Add("@toinsert", SqlDbType.VarChar);
                objSqlCommand.Parameters["@toinsert"].Value = toinsert;


                objSqlCommand.Parameters.Add("@clientcat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@clientcat"].Value = clientcat;



                objSqlCommand.Parameters.Add("@minadarea", SqlDbType.VarChar);
                if (minadarea == "")
                {
                    objSqlCommand.Parameters["@minadarea"].Value = "0";
                }
                else
                {
                    objSqlCommand.Parameters["@minadarea"].Value = minadarea;
                }

                /*new change ankur for agency*/

                objSqlCommand.Parameters.Add("@type", SqlDbType.VarChar);
                objSqlCommand.Parameters["@type"].Value = type;


                objSqlCommand.Parameters.Add("@agencycode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencycode"].Value = agencycode;

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
        /*new change ankur for agency*/
        public DataSet getpremiumbaserate(string colorcode, string compcode, string value, string packagecode, string txtratecode, string drpadtype, string drpadcategory, string drpsubcategory, string drpcolor, string drpcurrency, string validfromdate1, string validtill1, string bwcode, string uom, string adscat4, string adscat5, string adscat6, string premium, string sizefrom, string sizeto, string frominsert, string toinsert, string clientcat, string minadarea,string type,string agencycode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getpremiumbaserate", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@colorcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@colorcode"].Value = colorcode;

                objSqlCommand.Parameters.Add("@value", SqlDbType.VarChar);
                objSqlCommand.Parameters["@value"].Value = value;

                objSqlCommand.Parameters.Add("@packagecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@packagecode"].Value = packagecode;

                objSqlCommand.Parameters.Add("@txtratecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@txtratecode"].Value = txtratecode;

                objSqlCommand.Parameters.Add("@drpadtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@drpadtype"].Value = drpadtype;

                objSqlCommand.Parameters.Add("@drpadcategory", SqlDbType.VarChar);
                objSqlCommand.Parameters["@drpadcategory"].Value = drpadcategory;

                objSqlCommand.Parameters.Add("@drpsubcategory", SqlDbType.VarChar);
                objSqlCommand.Parameters["@drpsubcategory"].Value = drpsubcategory;

                objSqlCommand.Parameters.Add("@drpcolor", SqlDbType.VarChar);
                objSqlCommand.Parameters["@drpcolor"].Value = drpcolor;

                objSqlCommand.Parameters.Add("@drpcurrency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@drpcurrency"].Value = drpcurrency;


                objSqlCommand.Parameters.Add("@validfromdate1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@validfromdate1"].Value = validfromdate1;

                objSqlCommand.Parameters.Add("@validtill1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@validtill1"].Value = validtill1;

                objSqlCommand.Parameters.Add("@bwcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@bwcode"].Value = bwcode;

                objSqlCommand.Parameters.Add("@uom", SqlDbType.VarChar);
                objSqlCommand.Parameters["@uom"].Value = uom;

                objSqlCommand.Parameters.Add("@adscat6", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adscat6"].Value = adscat6;

                objSqlCommand.Parameters.Add("@adscat5", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adscat5"].Value = adscat5;

                objSqlCommand.Parameters.Add("@adscat4", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adscat4"].Value = adscat4;

                objSqlCommand.Parameters.Add("@premium", SqlDbType.VarChar);
                objSqlCommand.Parameters["@premium"].Value = premium;

                objSqlCommand.Parameters.Add("@sizefrom", SqlDbType.VarChar);
                objSqlCommand.Parameters["@sizefrom"].Value = sizefrom;

                objSqlCommand.Parameters.Add("@sizeto", SqlDbType.VarChar);
                objSqlCommand.Parameters["@sizeto"].Value = sizeto;

                objSqlCommand.Parameters.Add("@frominsert", SqlDbType.VarChar);
                objSqlCommand.Parameters["@frominsert"].Value = frominsert;

                objSqlCommand.Parameters.Add("@toinsert", SqlDbType.VarChar);
                objSqlCommand.Parameters["@toinsert"].Value = toinsert;


                objSqlCommand.Parameters.Add("@clientcat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@clientcat"].Value = clientcat;



                objSqlCommand.Parameters.Add("@minadarea", SqlDbType.VarChar);
                if (minadarea == "")
                {
                    objSqlCommand.Parameters["@minadarea"].Value = "0";
                }
                else
                {
                    objSqlCommand.Parameters["@minadarea"].Value = minadarea;
                }

                /*new change ankur for change*/

                objSqlCommand.Parameters.Add("@type", SqlDbType.VarChar);
                objSqlCommand.Parameters["@type"].Value = type;


                objSqlCommand.Parameters.Add("@agencycode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencycode"].Value = agencycode;

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

        /*new change ankur for agency*/
        public DataSet checkpackage(string packagecode, string compcode, string value, string txtratecode, string drpadtype, string drpadcategory, string drpsubcategory, string drpcolor, string drpcurrency, string validfromdate1, string validtill1, string uom,string adscat4,string adscat5,string adscat6,string premium,string sizefrom,string sizeto,string frominsert,string toinsert,string clientcat,string minadarea,string type,string agencycode,string dateformat,string pubcenter)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("chkpackagecode", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@packagecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@packagecode"].Value = packagecode;

                objSqlCommand.Parameters.Add("@value", SqlDbType.VarChar);
                objSqlCommand.Parameters["@value"].Value = value;

                objSqlCommand.Parameters.Add("@txtratecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@txtratecode"].Value = txtratecode;

                objSqlCommand.Parameters.Add("@drpadtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@drpadtype"].Value = drpadtype;

                objSqlCommand.Parameters.Add("@drpadcategory", SqlDbType.VarChar);
                objSqlCommand.Parameters["@drpadcategory"].Value = drpadcategory;

                objSqlCommand.Parameters.Add("@drpsubcategory", SqlDbType.VarChar);
                objSqlCommand.Parameters["@drpsubcategory"].Value = drpsubcategory;

                objSqlCommand.Parameters.Add("@drpcolor", SqlDbType.VarChar);
                objSqlCommand.Parameters["@drpcolor"].Value = drpcolor;

                objSqlCommand.Parameters.Add("@drpcurrency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@drpcurrency"].Value = drpcurrency;


                objSqlCommand.Parameters.Add("@validfromdate1", SqlDbType.VarChar);
                if (validfromdate1 == "")
                    objSqlCommand.Parameters["@validfromdate1"].Value = System.DBNull.Value;
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = validfromdate1.Split("/".ToCharArray());
                        validfromdate1 = arr[1] + "/" + arr[0] + "/" + arr[2];

                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = validfromdate1.Split("/".ToCharArray());
                        validfromdate1 = arr[1] + "/" + arr[2] + "/" + arr[0];

                    }
                    objSqlCommand.Parameters["@validfromdate1"].Value = validfromdate1;
                }

                objSqlCommand.Parameters.Add("@validtill1", SqlDbType.VarChar);
                if (validtill1 == "")
                    objSqlCommand.Parameters["@validtill1"].Value = System.DBNull.Value;
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = validtill1.Split("/".ToCharArray());
                        validtill1 = arr[1] + "/" + arr[0] + "/" + arr[2];

                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = validtill1.Split("/".ToCharArray());
                        validtill1 = arr[1] + "/" + arr[2] + "/" + arr[0];

                    }
                    objSqlCommand.Parameters["@validtill1"].Value = validtill1;
                }
                objSqlCommand.Parameters.Add("@uom", SqlDbType.VarChar);
                objSqlCommand.Parameters["@uom"].Value = uom;

                objSqlCommand.Parameters.Add("@adscat6", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adscat6"].Value = adscat6;

                objSqlCommand.Parameters.Add("@adscat5", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adscat5"].Value = adscat5;

                objSqlCommand.Parameters.Add("@adscat4", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adscat4"].Value = adscat4;

                objSqlCommand.Parameters.Add("@premium", SqlDbType.VarChar);
                objSqlCommand.Parameters["@premium"].Value = premium;

                objSqlCommand.Parameters.Add("@sizefrom", SqlDbType.VarChar);
                objSqlCommand.Parameters["@sizefrom"].Value = sizefrom;

                objSqlCommand.Parameters.Add("@sizeto", SqlDbType.VarChar);
                objSqlCommand.Parameters["@sizeto"].Value = sizeto;

                objSqlCommand.Parameters.Add("@frominsert", SqlDbType.VarChar);
                objSqlCommand.Parameters["@frominsert"].Value = frominsert;


                objSqlCommand.Parameters.Add("@toinsert", SqlDbType.VarChar);
                objSqlCommand.Parameters["@toinsert"].Value = toinsert;

                objSqlCommand.Parameters.Add("@clientcat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@clientcat"].Value = clientcat;


                objSqlCommand.Parameters.Add("@minadarea", SqlDbType.VarChar);
                if (minadarea == "")
                {
                    objSqlCommand.Parameters["@minadarea"].Value = "0";
                }
                else
                {
                    objSqlCommand.Parameters["@minadarea"].Value = minadarea;
                }

                /*new change ankur for agency*/


                objSqlCommand.Parameters.Add("@type", SqlDbType.VarChar);
                objSqlCommand.Parameters["@type"].Value = type;

                objSqlCommand.Parameters.Add("@agencycode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencycode"].Value = agencycode;

                objSqlCommand.Parameters.Add("@pubcenter", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pubcenter"].Value = pubcenter;

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

        // not used anywhere

        public DataSet editionforrate(string packagecode, string compcode,  string txtratecode, string drpadtype, string drpadcategory, string drpsubcategory, string drpcolor, string drpcurrency, string validfromdate1, string validtill1)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("chkeditionforrate", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@packagecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@packagecode"].Value = packagecode;

                objSqlCommand.Parameters.Add("@txtratecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@txtratecode"].Value = txtratecode;

                objSqlCommand.Parameters.Add("@drpadtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@drpadtype"].Value = drpadtype;

                objSqlCommand.Parameters.Add("@drpadcategory", SqlDbType.VarChar);
                objSqlCommand.Parameters["@drpadcategory"].Value = drpadcategory;

                objSqlCommand.Parameters.Add("@drpsubcategory", SqlDbType.VarChar);
                objSqlCommand.Parameters["@drpsubcategory"].Value = drpsubcategory;

                objSqlCommand.Parameters.Add("@drpcolor", SqlDbType.VarChar);
                objSqlCommand.Parameters["@drpcolor"].Value = drpcolor;

                objSqlCommand.Parameters.Add("@drpcurrency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@drpcurrency"].Value = drpcurrency;


                objSqlCommand.Parameters.Add("@validfromdate1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@validfromdate1"].Value = validfromdate1;

                objSqlCommand.Parameters.Add("@validtill1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@validtill1"].Value = validtill1;



                

                







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
        /*new change ankur for agency*/
        public DataSet chkratecode(string compcode, string ratecode,string type)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("chkratedetail", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@ratecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ratecode"].Value = ratecode;

                objSqlCommand.Parameters.Add("@type", SqlDbType.VarChar);
                objSqlCommand.Parameters["@type"].Value = type;


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

        public DataSet chkratecodemast(string compcode, string ratecode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("chkratedetailmast", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@ratecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ratecode"].Value = ratecode;


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
        /*new change ankur for agency*/
        public DataSet ratedetailsinsert(string rate, string focusrate, string ratecode, string compcode, string userid, string edition, string uniquerate,string weekrate,string solofocusrate,string weekendrate,string soloweekrate,string type, string weekextra, string focusextra, string weekendextra, string rate_sun, string rate_mon, string rate_tue, string rate_wed, string rate_thu, string rate_fri, string rate_sat, string rate_sun_extra, string rate_mon_extra, string rate_tue_extra, string rate_wed_extra, string rate_thu_extra, string rate_fri_extra, string rate_sat_extra, string adtype1, string pubcenter)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("insertratedetail", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@uniquerate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@uniquerate"].Value = uniquerate;


                objSqlCommand.Parameters.Add("@ratecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ratecode"].Value = ratecode;

                objSqlCommand.Parameters.Add("@edition", SqlDbType.VarChar);
                objSqlCommand.Parameters["@edition"].Value = edition;




                objSqlCommand.Parameters.Add("@rate", SqlDbType.Decimal);
                if (rate.Trim() == "" || rate.Trim() == null)
                {
                    objSqlCommand.Parameters["@rate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@rate"].Value = Convert.ToDecimal(rate);
                }





                objSqlCommand.Parameters.Add("@weekrate", SqlDbType.Decimal);
                if (weekrate.Trim() == "" || weekrate == null)
                {
                    objSqlCommand.Parameters["@weekrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@weekrate"].Value = Convert.ToDecimal(weekrate);
                }

                objSqlCommand.Parameters.Add("@solofocusrate", SqlDbType.Decimal);
                if (solofocusrate.Trim() == "" || solofocusrate.Trim() == null)
                {
                    objSqlCommand.Parameters["@solofocusrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@solofocusrate"].Value = Convert.ToDecimal(solofocusrate);
                }





                objSqlCommand.Parameters.Add("@focusrate", SqlDbType.Decimal);
                if (focusrate.Trim() == "" || focusrate == null)
                {
                    objSqlCommand.Parameters["@focusrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@focusrate"].Value = Convert.ToDecimal(focusrate);
                }

                objSqlCommand.Parameters.Add("@weekendrate", SqlDbType.Decimal);
                if (weekendrate.Trim() == "" || weekendrate == null)
                {
                    objSqlCommand.Parameters["@weekendrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@weekendrate"].Value = Convert.ToDecimal(weekendrate);
                }

                objSqlCommand.Parameters.Add("@soloweekrate", SqlDbType.Decimal);
                if (soloweekrate.Trim() == "" || soloweekrate == null)
                {
                    objSqlCommand.Parameters["@soloweekrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@soloweekrate"].Value = Convert.ToDecimal(soloweekrate);
                }

                /*new change ankur fr agency*/
                objSqlCommand.Parameters.Add("@type", SqlDbType.VarChar);
                objSqlCommand.Parameters["@type"].Value = type;


                objSqlCommand.Parameters.Add("@weekextra", SqlDbType.VarChar);
                if (weekextra == "")
                    objSqlCommand.Parameters["@weekextra"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@weekextra"].Value = weekextra;

                objSqlCommand.Parameters.Add("@focusextra", SqlDbType.VarChar);
                if (focusextra == "")
                    objSqlCommand.Parameters["@focusextra"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@focusextra"].Value = focusextra;

                objSqlCommand.Parameters.Add("@weekendextra", SqlDbType.VarChar);
                if (weekendextra == "")
                    objSqlCommand.Parameters["@weekendextra"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@weekendextra"].Value = weekendextra;

                objSqlCommand.Parameters.Add("@adtype1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adtype1"].Value = adtype1;

                objSqlCommand.Parameters.Add("@rate_sun", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rate_sun"].Value = rate_sun;

                objSqlCommand.Parameters.Add("@rate_mon", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rate_mon"].Value = rate_mon;

                objSqlCommand.Parameters.Add("@rate_tue", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rate_tue"].Value = rate_tue;

                objSqlCommand.Parameters.Add("@rate_wed", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rate_wed"].Value = rate_wed;

                objSqlCommand.Parameters.Add("@rate_thu", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rate_thu"].Value = rate_thu;

                objSqlCommand.Parameters.Add("@rate_fri", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rate_fri"].Value = rate_fri;

                objSqlCommand.Parameters.Add("@rate_sat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rate_sat"].Value = rate_sat;

                objSqlCommand.Parameters.Add("@rate_sun_extra", SqlDbType.VarChar);
                if (rate_sun_extra == "")
                    objSqlCommand.Parameters["@rate_sun_extra"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@rate_sun_extra"].Value = rate_sun_extra;

                objSqlCommand.Parameters.Add("@rate_mon_extra", SqlDbType.VarChar);
                if (rate_mon_extra == "")
                    objSqlCommand.Parameters["@rate_mon_extra"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@rate_mon_extra"].Value = rate_mon_extra;

                objSqlCommand.Parameters.Add("@rate_tue_extra", SqlDbType.VarChar);
                if (rate_tue_extra == "")
                    objSqlCommand.Parameters["@rate_tue_extra"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@rate_tue_extra"].Value = rate_tue_extra;

                objSqlCommand.Parameters.Add("@rate_wed_extra", SqlDbType.VarChar);
                if (rate_wed_extra == "")
                    objSqlCommand.Parameters["@rate_wed_extra"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@rate_wed_extra"].Value = rate_wed_extra;

                objSqlCommand.Parameters.Add("@rate_thu_extra", SqlDbType.VarChar);
                if (rate_thu_extra == "")
                    objSqlCommand.Parameters["@rate_thu_extra"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@rate_thu_extra"].Value = rate_thu_extra;

                objSqlCommand.Parameters.Add("@rate_fri_extra", SqlDbType.VarChar);
                if (rate_fri_extra == "")
                    objSqlCommand.Parameters["@rate_fri_extra"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@rate_fri_extra"].Value = rate_fri_extra;

                objSqlCommand.Parameters.Add("@rate_sat_extra", SqlDbType.VarChar);
                if (rate_sat_extra == "")
                    objSqlCommand.Parameters["@rate_sat_extra"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@rate_sat_extra"].Value = rate_sat_extra;

                objSqlCommand.Parameters.Add("@pubcenter", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pubcenter"].Value = pubcenter;

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

        public DataSet rateget(string packagecode, string compcode)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("binddescription12", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@packagecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@packagecode"].Value = packagecode;







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
        /*new change ankur for agency*/
        public DataSet ratedetailsupdate(string rate, string focusrate, string ratecode, string compcode, string userid, string edition, string rateuniqueid, string weekendrate, string type, string weekextra, string focusextra, string weekendextra, string rate_sun, string rate_mon, string rate_tue, string rate_wed, string rate_thu, string rate_fri, string rate_sat, string rate_sun_extra, string rate_mon_extra, string rate_tue_extra, string rate_wed_extra, string rate_thu_extra, string rate_fri_extra, string rate_sat_extra, string adtype1, string pubcenter)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("updateratedetail", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@rateuniqueid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rateuniqueid"].Value = rateuniqueid;


                objSqlCommand.Parameters.Add("@ratecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ratecode"].Value = ratecode;

                objSqlCommand.Parameters.Add("@edition", SqlDbType.VarChar);
                objSqlCommand.Parameters["@edition"].Value = edition;




                objSqlCommand.Parameters.Add("@rate", SqlDbType.Decimal);
                if (rate.Trim() == "" || rate.Trim() == null)
                {
                    objSqlCommand.Parameters["@rate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@rate"].Value = Convert.ToDecimal(rate);
                }





                objSqlCommand.Parameters.Add("@focusrate", SqlDbType.Decimal);
                if (focusrate.Trim() == "" || focusrate == null)
                {
                    objSqlCommand.Parameters["@focusrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@focusrate"].Value = Convert.ToDecimal(focusrate);
                }

                objSqlCommand.Parameters.Add("@weekendrate", SqlDbType.Decimal);
                if (weekendrate.Trim() == "" || weekendrate == null)
                {
                    objSqlCommand.Parameters["@weekendrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@weekendrate"].Value = Convert.ToDecimal(weekendrate);
                }

                /*new change ankur for agency*/

                objSqlCommand.Parameters.Add("@type", SqlDbType.VarChar);
                objSqlCommand.Parameters["@type"].Value = type;


                objSqlCommand.Parameters.Add("@weekextra", SqlDbType.VarChar);

                if (weekextra.Trim() == "" || weekextra.Trim() == null)
                {
                    objSqlCommand.Parameters["@weekextra"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@weekextra"].Value = Convert.ToDouble(weekextra);
                }


                objSqlCommand.Parameters.Add("@focusextra", SqlDbType.VarChar);

                if (focusextra.Trim() == "" || focusextra.Trim() == null)
                {
                    objSqlCommand.Parameters["@focusextra"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@focusextra"].Value = Convert.ToDouble(focusextra);
                }

                objSqlCommand.Parameters.Add("@weekendextra", SqlDbType.VarChar);

                if (weekendrate.Trim() == "" || weekendrate.Trim() == null)
                {
                    objSqlCommand.Parameters["@weekendextra"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@weekendextra"].Value = Convert.ToDouble(weekendrate);
                }

                objSqlCommand.Parameters.Add("@rate_sun", SqlDbType.VarChar);

                if (rate_sun.Trim() == "" || rate_sun.Trim() == null)
                {
                    objSqlCommand.Parameters["@rate_sun"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@rate_sun"].Value = Convert.ToDouble(rate_sun);
                }


                objSqlCommand.Parameters.Add("@rate_mon", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rate_mon"].Value = Convert.ToDouble(rate_mon);

                objSqlCommand.Parameters.Add("@rate_tue", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rate_tue"].Value = Convert.ToDouble(rate_tue);

                objSqlCommand.Parameters.Add("@rate_wed", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rate_wed"].Value = Convert.ToDouble(rate_wed);

                objSqlCommand.Parameters.Add("@rate_thu", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rate_thu"].Value = Convert.ToDouble(rate_thu);

                objSqlCommand.Parameters.Add("@rate_fri", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rate_fri"].Value = Convert.ToDouble(rate_fri);

                objSqlCommand.Parameters.Add("@rate_sat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rate_sat"].Value = Convert.ToDouble(rate_sat);

                objSqlCommand.Parameters.Add("@rate_sun_extra", SqlDbType.VarChar);
                if (rate_sun_extra != "" && rate_sun_extra != null)
                    objSqlCommand.Parameters["@rate_sun_extra"].Value = Convert.ToDouble(rate_sun_extra);
                else
                    objSqlCommand.Parameters["@rate_sun_extra"].Value = "0";


                objSqlCommand.Parameters.Add("@rate_mon_extra", SqlDbType.VarChar);
                if (rate_mon_extra != "" && rate_mon_extra != null)
                    objSqlCommand.Parameters["@rate_mon_extra"].Value = Convert.ToDouble(rate_mon_extra);
                else
                    objSqlCommand.Parameters["@rate_mon_extra"].Value = "0";

                objSqlCommand.Parameters.Add("@rate_tue_extra", SqlDbType.VarChar);
                if (rate_tue_extra != "" && rate_tue_extra != null)
                    objSqlCommand.Parameters["@rate_tue_extra"].Value = Convert.ToDouble(rate_tue_extra);
                else
                    objSqlCommand.Parameters["@rate_tue_extra"].Value = "0";

                objSqlCommand.Parameters.Add("@rate_wed_extra", SqlDbType.VarChar);
                if (rate_wed_extra != "" && rate_wed_extra != null)
                    objSqlCommand.Parameters["@rate_wed_extra"].Value = Convert.ToDouble(rate_wed_extra);
                else
                    objSqlCommand.Parameters["@rate_wed_extra"].Value = "0";


                objSqlCommand.Parameters.Add("@rate_thu_extra", SqlDbType.VarChar);
                if (rate_thu_extra != "" && rate_thu_extra != null)
                    objSqlCommand.Parameters["@rate_thu_extra"].Value = Convert.ToDouble(rate_thu_extra);
                else
                    objSqlCommand.Parameters["@rate_thu_extra"].Value = "0";

                objSqlCommand.Parameters.Add("@rate_fri_extra", SqlDbType.VarChar);
                if (rate_fri_extra != "" && rate_fri_extra != null)
                    objSqlCommand.Parameters["@rate_fri_extra"].Value = Convert.ToDouble(rate_fri_extra);
                else
                    objSqlCommand.Parameters["@rate_fri_extra"].Value = "0";


                objSqlCommand.Parameters.Add("@rate_sat_extra", SqlDbType.VarChar);
                if (rate_sat_extra != "" && rate_sat_extra != null)
                    objSqlCommand.Parameters["@rate_sat_extra"].Value = Convert.ToDouble(rate_sat_extra);
                else
                    objSqlCommand.Parameters["@rate_sat_extra"].Value = "0";

                objSqlCommand.Parameters.Add("@adtype1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adtype1"].Value = adtype1;

                objSqlCommand.Parameters.Add("@pubcenter", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pubcenter"].Value = pubcenter;
              
              


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

        /*new change ankur for agency*/
        public DataSet soloratedetailsupdate(string rate, string focusrate, string ratecode, string compcode, string userid, string edition, string rateuniqueid, string weekendrate,string type)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("updatesoloratedetail", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@rateuniqueid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rateuniqueid"].Value = rateuniqueid;


                objSqlCommand.Parameters.Add("@ratecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ratecode"].Value = ratecode;

                objSqlCommand.Parameters.Add("@edition", SqlDbType.VarChar);
                objSqlCommand.Parameters["@edition"].Value = edition;



                objSqlCommand.Parameters.Add("@rate", SqlDbType.Decimal);
                if (rate.Trim() == "" || rate.Trim() == null)
                {
                    objSqlCommand.Parameters["@rate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@rate"].Value = Convert.ToDecimal(rate);
                }





                objSqlCommand.Parameters.Add("@focusrate", SqlDbType.Decimal);
                if (focusrate.Trim() == "" || focusrate == null)
                {
                    objSqlCommand.Parameters["@focusrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@focusrate"].Value = Convert.ToDecimal(focusrate);
                }

                objSqlCommand.Parameters.Add("@weekendrate", SqlDbType.Decimal);
                if (weekendrate.Trim() == "" || weekendrate == null)
                {
                    objSqlCommand.Parameters["@weekendrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@weekendrate"].Value = Convert.ToDecimal(weekendrate);
                }


                /*new change ankur for agency*/

                objSqlCommand.Parameters.Add("@type", SqlDbType.VarChar);
                objSqlCommand.Parameters["@type"].Value = type;






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
        /*new change ankur for agency*/
        public DataSet bindgridfromdetail(string ratecode, string compcode,string type)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("bindratedetails", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@ratecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ratecode"].Value = ratecode;
                /*new change ankur for agency*/

                objSqlCommand.Parameters.Add("@type", SqlDbType.VarChar);
                objSqlCommand.Parameters["@type"].Value = type;






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
        /*new change ankur for agency*/
        public DataSet modifygrid(string compcode, string packagecode, string weekrate, string focusrate, string txtratecode, string drpadtype, string drpadcategory, string drpsubcategory, string drpcolor, string drpcurrency, string validfromdate1, string validtill1, string weekendrate, string decimalvalue, string uom, string adscat4, string adscat5, string adscat6, string premium, string sizefrom, string sizeto, string frominsert, string toinsert, string clientcat, string minadarea, string type, string agencycode, string dateformat, string pubcenter, string rate_sun, string rate_mon, string rate_tue, string rate_wed, string rate_thu, string rate_fri, string rate_sat, string rate_sun_extra, string rate_mon_extra, string rate_tue_extra, string rate_wed_extra, string rate_thu_extra, string rate_fri_extra, string rate_sat_extra, string extrarate)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("ratemodifygrid", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@packagecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@packagecode"].Value = packagecode;


                objSqlCommand.Parameters.Add("@txtratecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@txtratecode"].Value = txtratecode;

                objSqlCommand.Parameters.Add("@drpadtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@drpadtype"].Value = drpadtype;

                objSqlCommand.Parameters.Add("@drpadcategory", SqlDbType.VarChar);
                objSqlCommand.Parameters["@drpadcategory"].Value = drpadcategory;

                objSqlCommand.Parameters.Add("@drpsubcategory", SqlDbType.VarChar);
                objSqlCommand.Parameters["@drpsubcategory"].Value = drpsubcategory;

                objSqlCommand.Parameters.Add("@drpcolor", SqlDbType.VarChar);
                objSqlCommand.Parameters["@drpcolor"].Value = drpcolor;

                objSqlCommand.Parameters.Add("@drpcurrency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@drpcurrency"].Value = drpcurrency;


                objSqlCommand.Parameters.Add("@validfromdate1", SqlDbType.VarChar);
                if (dateformat == "dd/mm/yyyy")
                {
                    string[] arr = validfromdate1.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    validfromdate1 = mm + "/" + dd + "/" + yy;
                }
                else if (dateformat == "yyyy/mm/dd")
                {
                    string[] arr = validfromdate1.Split('/');
                    string dd = arr[2];
                    string mm = arr[1];
                    string yy = arr[0];
                    validfromdate1 = mm + "/" + dd + "/" + yy;
                }
                objSqlCommand.Parameters["@validfromdate1"].Value = validfromdate1;

                objSqlCommand.Parameters.Add("@validtill1", SqlDbType.VarChar);
                if (dateformat == "dd/mm/yyyy")
                {
                    string[] arr = validtill1.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    validtill1 = mm + "/" + dd + "/" + yy;
                }
                else if (dateformat == "yyyy/mm/dd")
                {
                    string[] arr = validtill1.Split('/');
                    string dd = arr[2];
                    string mm = arr[1];
                    string yy = arr[0];
                    validtill1 = mm + "/" + dd + "/" + yy;
                }
                objSqlCommand.Parameters["@validtill1"].Value = validtill1;

                

                objSqlCommand.Parameters.Add("@weekrate", SqlDbType.Decimal);
                if (weekrate == "" || weekrate == null)
                {
                    objSqlCommand.Parameters["@weekrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@weekrate"].Value = Convert.ToDecimal(weekrate);
                }

                objSqlCommand.Parameters.Add("@focusrate", SqlDbType.Decimal);
                if (focusrate == "" || focusrate == null)
                {
                    objSqlCommand.Parameters["@focusrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@focusrate"].Value = Convert.ToDecimal(focusrate);
                }

                objSqlCommand.Parameters.Add("@weekendrate", SqlDbType.Decimal);
                if (weekendrate == "" || weekendrate == null)
                {
                    objSqlCommand.Parameters["@weekendrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@weekendrate"].Value = Convert.ToDecimal(weekendrate);
                }

                objSqlCommand.Parameters.Add("@decimalvalue", SqlDbType.Int);
                if (decimalvalue == "" || decimalvalue == null)
                {
                    objSqlCommand.Parameters["@decimalvalue"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@decimalvalue"].Value = Convert.ToInt32(decimalvalue);
                }


                objSqlCommand.Parameters.Add("@uom", SqlDbType.VarChar);
                objSqlCommand.Parameters["@uom"].Value = uom;

                objSqlCommand.Parameters.Add("@adscat6", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adscat6"].Value = adscat6;

                objSqlCommand.Parameters.Add("@adscat5", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adscat5"].Value = adscat5;

                objSqlCommand.Parameters.Add("@adscat4", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adscat4"].Value = adscat4;

                objSqlCommand.Parameters.Add("@premium", SqlDbType.VarChar);
                objSqlCommand.Parameters["@premium"].Value = premium;

                objSqlCommand.Parameters.Add("@sizefrom", SqlDbType.VarChar);
                objSqlCommand.Parameters["@sizefrom"].Value = sizefrom;


                objSqlCommand.Parameters.Add("@sizeto", SqlDbType.VarChar);
                objSqlCommand.Parameters["@sizeto"].Value = sizeto;

                objSqlCommand.Parameters.Add("@frominsert", SqlDbType.VarChar);
                
                    objSqlCommand.Parameters["@frominsert"].Value = frominsert;


                    objSqlCommand.Parameters.Add("@toinsert", SqlDbType.VarChar);
              
                    objSqlCommand.Parameters["@toinsert"].Value = toinsert;


                    objSqlCommand.Parameters.Add("@clientcat", SqlDbType.VarChar);

                    objSqlCommand.Parameters["@clientcat"].Value = clientcat;



                    objSqlCommand.Parameters.Add("@minadarea", SqlDbType.VarChar);
                    if (minadarea == "")
                    {
                        objSqlCommand.Parameters["@minadarea"].Value = "0";
                    }
                    else
                    {
                        objSqlCommand.Parameters["@minadarea"].Value = minadarea;
                    }

                /*new change ankur for agency*/
                    objSqlCommand.Parameters.Add("@type", SqlDbType.VarChar);
                    objSqlCommand.Parameters["@type"].Value = type;


                    objSqlCommand.Parameters.Add("@agencycode", SqlDbType.VarChar);
                    objSqlCommand.Parameters["@agencycode"].Value = agencycode;

                    objSqlCommand.Parameters.Add("@pubcenter", SqlDbType.VarChar);
                    objSqlCommand.Parameters["@pubcenter"].Value = pubcenter;

                    objSqlCommand.Parameters.Add("@pkg_sun_rate", SqlDbType.Decimal);
                    if (rate_sun == "")
                        objSqlCommand.Parameters["@pkg_sun_rate"].Value = System.DBNull.Value;
                    else
                        objSqlCommand.Parameters["@pkg_sun_rate"].Value = Convert.ToDecimal(rate_sun);

                    objSqlCommand.Parameters.Add("@pkg_mon_rate", SqlDbType.Decimal);
                    if (rate_mon == "")
                        objSqlCommand.Parameters["@pkg_mon_rate"].Value = System.DBNull.Value;
                    else
                        objSqlCommand.Parameters["@pkg_mon_rate"].Value = Convert.ToDecimal(rate_mon);

                    objSqlCommand.Parameters.Add("@pkg_tue_rate", SqlDbType.Decimal);
                    if (rate_tue == "")
                        objSqlCommand.Parameters["@pkg_tue_rate"].Value = System.DBNull.Value;
                    else
                        objSqlCommand.Parameters["@pkg_tue_rate"].Value = Convert.ToDecimal(rate_tue);

                    objSqlCommand.Parameters.Add("@pkg_wed_rate", SqlDbType.Decimal);
                    if (rate_wed == "")
                        objSqlCommand.Parameters["@pkg_wed_rate"].Value = System.DBNull.Value;
                    else
                        objSqlCommand.Parameters["@pkg_wed_rate"].Value = Convert.ToDecimal(rate_wed);

                    objSqlCommand.Parameters.Add("@pkg_thu_rate", SqlDbType.Decimal);
                    if (rate_thu == "")
                        objSqlCommand.Parameters["@pkg_thu_rate"].Value = System.DBNull.Value;
                    else
                        objSqlCommand.Parameters["@pkg_thu_rate"].Value = Convert.ToDecimal(rate_thu);
                

                    objSqlCommand.Parameters.Add("@pkg_fri_rate", SqlDbType.Decimal);
                    if (rate_fri == "")
                        objSqlCommand.Parameters["@pkg_fri_rate"].Value = System.DBNull.Value;
                    else
                        objSqlCommand.Parameters["@pkg_fri_rate"].Value = Convert.ToDecimal(rate_fri);

                    objSqlCommand.Parameters.Add("@pkg_sat_rate", SqlDbType.Decimal);
                    if (rate_sat == "")
                        objSqlCommand.Parameters["@pkg_sat_rate"].Value = System.DBNull.Value;
                    else
                        objSqlCommand.Parameters["@pkg_sat_rate"].Value = Convert.ToDecimal(rate_sat);


                    /////////////////////////////////////////////////////////
                    objSqlCommand.Parameters.Add("@pkg_sun_rate_ex", SqlDbType.Decimal);
                    if (rate_sun_extra == "")
                        objSqlCommand.Parameters["@pkg_sun_rate_ex"].Value = System.DBNull.Value;
                    else
                        objSqlCommand.Parameters["@pkg_sun_rate_ex"].Value = Convert.ToDecimal(rate_sun_extra);

                    objSqlCommand.Parameters.Add("@pkg_mon_rate_ex", SqlDbType.Decimal);
                    if (rate_mon_extra == "")
                        objSqlCommand.Parameters["@pkg_mon_rate_ex"].Value = System.DBNull.Value;
                    else
                        objSqlCommand.Parameters["@pkg_mon_rate_ex"].Value = Convert.ToDecimal(rate_mon_extra);

                    objSqlCommand.Parameters.Add("@pkg_tue_rate_ex", SqlDbType.Decimal);
                    if (rate_tue_extra == "")
                        objSqlCommand.Parameters["@pkg_tue_rate_ex"].Value = System.DBNull.Value;
                    else
                        objSqlCommand.Parameters["@pkg_tue_rate_ex"].Value = Convert.ToDecimal(rate_tue_extra);

                    objSqlCommand.Parameters.Add("@pkg_wed_rate_ex", SqlDbType.Decimal);
                    if (rate_wed_extra == "")
                        objSqlCommand.Parameters["@pkg_wed_rate_ex"].Value = System.DBNull.Value;
                    else
                        objSqlCommand.Parameters["@pkg_wed_rate_ex"].Value = Convert.ToDecimal(rate_wed_extra);

                    objSqlCommand.Parameters.Add("@pkg_thu_rate_ex", SqlDbType.Decimal);
                    if (rate_thu_extra == "")
                        objSqlCommand.Parameters["@pkg_thu_rate_ex"].Value = System.DBNull.Value;
                    else
                        objSqlCommand.Parameters["@pkg_thu_rate_ex"].Value = Convert.ToDecimal(rate_thu_extra);


                    objSqlCommand.Parameters.Add("@pkg_fri_rate_ex", SqlDbType.Decimal);
                if(rate_fri_extra=="")
                    objSqlCommand.Parameters["@pkg_fri_rate_ex"].Value =System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@pkg_fri_rate_ex"].Value = Convert.ToDecimal(rate_fri_extra);

                    objSqlCommand.Parameters.Add("@pkg_sat_rate_ex", SqlDbType.Decimal);
                    if (rate_sat_extra == "")
                        objSqlCommand.Parameters["@pkg_sat_rate_ex"].Value = System.DBNull.Value;
                    else
                        objSqlCommand.Parameters["@pkg_sat_rate_ex"].Value = Convert.ToDecimal(rate_sat_extra);

                    objSqlCommand.Parameters.Add("@extrarate", SqlDbType.Decimal);
                    if (extrarate == "")
                        objSqlCommand.Parameters["@extrarate"].Value = System.DBNull.Value;
                    else
                        objSqlCommand.Parameters["@extrarate"].Value = Convert.ToDecimal(extrarate);



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

        public DataSet sizecheck(string sizefrom,string sizeto,string adtype, string adcategory, string adsubcategory,string compcode,string uom)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("checksizeforrate", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@uom", SqlDbType.VarChar);
                objSqlCommand.Parameters["@uom"].Value = uom;

                objSqlCommand.Parameters.Add("@sizefrom", SqlDbType.VarChar);
               
                    objSqlCommand.Parameters["@sizefrom"].Value = sizefrom;
                

                objSqlCommand.Parameters.Add("@sizeto", SqlDbType.VarChar);
               
                    objSqlCommand.Parameters["@sizeto"].Value = sizeto;
                

                objSqlCommand.Parameters.Add("@adtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adtype"].Value = adtype;

                objSqlCommand.Parameters.Add("@adcategory", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adcategory"].Value = adcategory;

                objSqlCommand.Parameters.Add("@adsubcategory", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adsubcategory"].Value = adsubcategory;










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
        /*new change ankur for agency*/
        public DataSet showgrid(string compcode, string packagecode, string txtratecode, string drpadtype, string drpadcategory, string drpsubcategory, string drpcolor, string drpcurrency, string validfromdate1, string validtill1, string uom,string adscat4,string adscat5,string adscat6,string premium,string sizefrom,string sizeto,string frominsert,string toinsert,string clientcat,string minadarea,string type,string agencycode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("bindgridforexe", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@packagecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@packagecode"].Value = packagecode;


                objSqlCommand.Parameters.Add("@txtratecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@txtratecode"].Value = txtratecode;

                objSqlCommand.Parameters.Add("@drpadtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@drpadtype"].Value = drpadtype;

                objSqlCommand.Parameters.Add("@drpadcategory", SqlDbType.VarChar);
                objSqlCommand.Parameters["@drpadcategory"].Value = drpadcategory;

                objSqlCommand.Parameters.Add("@drpsubcategory", SqlDbType.VarChar);
                objSqlCommand.Parameters["@drpsubcategory"].Value = drpsubcategory;

                objSqlCommand.Parameters.Add("@drpcolor", SqlDbType.VarChar);
                objSqlCommand.Parameters["@drpcolor"].Value = drpcolor;

                objSqlCommand.Parameters.Add("@drpcurrency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@drpcurrency"].Value = drpcurrency;


                objSqlCommand.Parameters.Add("@validfromdate1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@validfromdate1"].Value = validfromdate1;

                objSqlCommand.Parameters.Add("@validtill1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@validtill1"].Value = validtill1;

                objSqlCommand.Parameters.Add("@uom", SqlDbType.VarChar);
                objSqlCommand.Parameters["@uom"].Value = uom;

                objSqlCommand.Parameters.Add("@adscat6", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adscat6"].Value = adscat6;

                objSqlCommand.Parameters.Add("@adscat5", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adscat5"].Value = adscat5;

                objSqlCommand.Parameters.Add("@adscat4", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adscat4"].Value = adscat4;

                objSqlCommand.Parameters.Add("@premium", SqlDbType.VarChar);
                objSqlCommand.Parameters["@premium"].Value = premium;

                objSqlCommand.Parameters.Add("@sizefrom", SqlDbType.VarChar);
                objSqlCommand.Parameters["@sizefrom"].Value = sizefrom;

                objSqlCommand.Parameters.Add("@sizeto", SqlDbType.VarChar);
                objSqlCommand.Parameters["@sizeto"].Value = sizeto;

                objSqlCommand.Parameters.Add("@frominsert", SqlDbType.VarChar);
                objSqlCommand.Parameters["@frominsert"].Value = frominsert;


                objSqlCommand.Parameters.Add("@toinsert", SqlDbType.VarChar);
                objSqlCommand.Parameters["@toinsert"].Value = toinsert;


                objSqlCommand.Parameters.Add("@clientcat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@clientcat"].Value = clientcat;

                objSqlCommand.Parameters.Add("@minadarea", SqlDbType.VarChar);
                if (minadarea == "")
                {
                    objSqlCommand.Parameters["@minadarea"].Value = "0";
                }
                else
                {
                    objSqlCommand.Parameters["@minadarea"].Value = minadarea;
                }
                /*new change ankur for agency*/


                objSqlCommand.Parameters.Add("@type", SqlDbType.VarChar);
                objSqlCommand.Parameters["@type"].Value = type;


                objSqlCommand.Parameters.Add("@agencycode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencycode"].Value = agencycode;

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



        public DataSet updatesizechk(string sizefrom, string sizeto, string adtype, string adcategory, string adsubcategory, string compcode,string ratecode,string uom,string adscat4,string adscat5,string adscat6)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("updatechecksizeforrate", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@uom", SqlDbType.VarChar);
                objSqlCommand.Parameters["@uom"].Value = uom;

                objSqlCommand.Parameters.Add("@sizefrom", SqlDbType.VarChar);
               
                objSqlCommand.Parameters["@sizefrom"].Value = sizefrom;
               

                objSqlCommand.Parameters.Add("@sizeto", SqlDbType.VarChar);
                
                objSqlCommand.Parameters["@sizeto"].Value = sizeto;
                
                objSqlCommand.Parameters.Add("@adtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adtype"].Value = adtype;

                objSqlCommand.Parameters.Add("@adcategory", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adcategory"].Value = adcategory;

                objSqlCommand.Parameters.Add("@adsubcategory", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adsubcategory"].Value = adsubcategory;

                objSqlCommand.Parameters.Add("@ratecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ratecode"].Value = ratecode;

             

                objSqlCommand.Parameters.Add("@adscat6", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adscat6"].Value = adscat6;

                objSqlCommand.Parameters.Add("@adscat5", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adscat5"].Value = adscat5;

                objSqlCommand.Parameters.Add("@adscat4", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adscat4"].Value = adscat4;
                
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

        // not used anywhere

        public DataSet modsolpack(string compcode, string ratecode, string adtype, string adcategory, string adsubcategory, string color, string package, string currency, string fromdate, string todate)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("checksolopackage", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@ratecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ratecode"].Value = ratecode;

                objSqlCommand.Parameters.Add("@fromdate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@fromdate"].Value = fromdate;

                objSqlCommand.Parameters.Add("@todate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@todate"].Value = todate;

                objSqlCommand.Parameters.Add("@adtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adtype"].Value = adtype;

                objSqlCommand.Parameters.Add("@adcategory", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adcategory"].Value = adcategory;


                objSqlCommand.Parameters.Add("@adsubcategory", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adsubcategory"].Value = adsubcategory;

                objSqlCommand.Parameters.Add("@color", SqlDbType.VarChar);
                objSqlCommand.Parameters["@color"].Value = color;

                objSqlCommand.Parameters.Add("@package", SqlDbType.VarChar);
                objSqlCommand.Parameters["@package"].Value = package;

                objSqlCommand.Parameters.Add("@currency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@currency"].Value = currency;



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
        /*new change ankur for agency*/
        public DataSet soloratemodify(string compcode, string ratecode, string adtype, string adcategory, string adsubcategory, string color, string package, string currency, string fromdate, string todate, string rateuniqueid,string pkgdesc,string weekrate,string focusrate,string weekendrate, string uom,string adscat4,string adscat5,string adscat6,string premium,string sizefrom,string sizeto,string frominsert,string toinsert,string clientcat,string minadarea,string type,string agencycode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("soloratemodify", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@ratecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ratecode"].Value = ratecode;

                objSqlCommand.Parameters.Add("@fromdate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@fromdate"].Value = fromdate;

                objSqlCommand.Parameters.Add("@todate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@todate"].Value = todate;

                objSqlCommand.Parameters.Add("@adtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adtype"].Value = adtype;

                objSqlCommand.Parameters.Add("@adcategory", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adcategory"].Value = adcategory;


                objSqlCommand.Parameters.Add("@adsubcategory", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adsubcategory"].Value = adsubcategory;

                objSqlCommand.Parameters.Add("@color", SqlDbType.VarChar);
                objSqlCommand.Parameters["@color"].Value = color;

                objSqlCommand.Parameters.Add("@package", SqlDbType.VarChar);
                objSqlCommand.Parameters["@package"].Value = package;

                objSqlCommand.Parameters.Add("@currency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@currency"].Value = currency;

                objSqlCommand.Parameters.Add("@rateuniqueid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rateuniqueid"].Value = rateuniqueid;

                objSqlCommand.Parameters.Add("@pkgdesc", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pkgdesc"].Value = pkgdesc;

                objSqlCommand.Parameters.Add("@weekrate", SqlDbType.Decimal);
                if (weekrate == "" || weekrate == null)
                {
                    objSqlCommand.Parameters["@weekrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@weekrate"].Value = Convert.ToDecimal(weekrate);
                }

                objSqlCommand.Parameters.Add("@focusrate", SqlDbType.Decimal);
                if (focusrate == "" || focusrate == null)
                {
                    objSqlCommand.Parameters["@focusrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@focusrate"].Value = Convert.ToDecimal(focusrate);
                }

                objSqlCommand.Parameters.Add("@weekendrate", SqlDbType.Decimal);
                if (weekendrate == "" || weekendrate == null)
                {
                    objSqlCommand.Parameters["@weekendrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@weekendrate"].Value = Convert.ToDecimal(weekendrate);
                }


                objSqlCommand.Parameters.Add("@uom", SqlDbType.VarChar);
                objSqlCommand.Parameters["@uom"].Value = uom;

                objSqlCommand.Parameters.Add("@adscat6", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adscat6"].Value = adscat6;

                objSqlCommand.Parameters.Add("@adscat5", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adscat5"].Value = adscat5;

                objSqlCommand.Parameters.Add("@adscat4", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adscat4"].Value = adscat4;

                objSqlCommand.Parameters.Add("@premium", SqlDbType.VarChar);
                objSqlCommand.Parameters["@premium"].Value = premium;


                objSqlCommand.Parameters.Add("@sizefrom", SqlDbType.VarChar);
                objSqlCommand.Parameters["@sizefrom"].Value = sizefrom;


                objSqlCommand.Parameters.Add("@sizeto", SqlDbType.VarChar);
                objSqlCommand.Parameters["@sizeto"].Value = sizeto;

                objSqlCommand.Parameters.Add("@frominsert", SqlDbType.VarChar);
                objSqlCommand.Parameters["@frominsert"].Value = frominsert;

                objSqlCommand.Parameters.Add("@toinsert", SqlDbType.VarChar);
                objSqlCommand.Parameters["@toinsert"].Value = toinsert;

                objSqlCommand.Parameters.Add("@clientcat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@clientcat"].Value = clientcat;


                objSqlCommand.Parameters.Add("@minadarea", SqlDbType.VarChar);
                objSqlCommand.Parameters["@minadarea"].Value = minadarea;

                /*new change ankur for agency*/

                objSqlCommand.Parameters.Add("@type", SqlDbType.VarChar);
                objSqlCommand.Parameters["@type"].Value = type;


                objSqlCommand.Parameters.Add("@agencycode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencycode"].Value = agencycode;

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
        /*new change ankur for agency*/
        public DataSet editionmodify(string compcode, string ratecode, string adtype, string adcategory, string adsubcategory, string color, string package, string currency, string fromdate, string todate, string rateuniqueid, string pkgdesc, string weekrate, string focusrate, string weekendrate, string uom,string type)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("editionmodifyrate", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@ratecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ratecode"].Value = ratecode;

                objSqlCommand.Parameters.Add("@fromdate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@fromdate"].Value = fromdate;

                objSqlCommand.Parameters.Add("@todate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@todate"].Value = todate;

                objSqlCommand.Parameters.Add("@adtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adtype"].Value = adtype;

                objSqlCommand.Parameters.Add("@adcategory", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adcategory"].Value = adcategory;


                objSqlCommand.Parameters.Add("@adsubcategory", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adsubcategory"].Value = adsubcategory;

                objSqlCommand.Parameters.Add("@color", SqlDbType.VarChar);
                objSqlCommand.Parameters["@color"].Value = color;

                objSqlCommand.Parameters.Add("@package", SqlDbType.VarChar);
                objSqlCommand.Parameters["@package"].Value = package;

                objSqlCommand.Parameters.Add("@currency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@currency"].Value = currency;

                objSqlCommand.Parameters.Add("@rateuniqueid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rateuniqueid"].Value = rateuniqueid;

                objSqlCommand.Parameters.Add("@pkgdesc", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pkgdesc"].Value = pkgdesc;

                objSqlCommand.Parameters.Add("@weekrate", SqlDbType.Decimal);
                if (weekrate == "" || weekrate == null)
                {
                    objSqlCommand.Parameters["@weekrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@weekrate"].Value = Convert.ToDecimal(weekrate);
                }

                objSqlCommand.Parameters.Add("@focusrate", SqlDbType.Decimal);
                if (focusrate == "" || focusrate == null)
                {
                    objSqlCommand.Parameters["@focusrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@focusrate"].Value = Convert.ToDecimal(focusrate);
                }

                objSqlCommand.Parameters.Add("@weekendrate", SqlDbType.Decimal);
                if (weekendrate == "" || weekendrate == null)
                {
                    objSqlCommand.Parameters["@weekendrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@weekendrate"].Value = Convert.ToDecimal(weekendrate);
                }

                objSqlCommand.Parameters.Add("@uom", SqlDbType.VarChar);
                objSqlCommand.Parameters["@uom"].Value = uom;


                objSqlCommand.Parameters.Add("@type", SqlDbType.VarChar);
                objSqlCommand.Parameters["@type"].Value = type;


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




        /*new change ankur 17 feb*/
        /*new change ankur for agency*/
        public DataSet modifycirculation(string compcode, string userid, string ratecode, string adtype, string rategroupcode, string adcategory, string currency, string adsubcategory, string package, string packagedesc, string uom, string sizefrom, string sizeto, string consumption, string color, string colorchrty, string weekdrate, string weeminrate, string extweerate, string focusdarate, string focminrate, string focexrate, string validfromdate, string validtill, string remarks, string premium, string premiumval, string rateuniqueid, string weekendrate, string weekendmin, string weekendextra, string combination, string insertsolo, string flag, string minadarea, string editionfrom, string editionto, string flramount, string flrdiscount, string scheme,string adscat4,string adscat5,string adscat6,string frominsert,string toinsert,string agetype,string clientcat,string max_area,string type,string agencycode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                string datefrom = validfromdate;
                string dateto = validtill;
                objSqlConnection.Open();
                objSqlCommand = GetCommand("modifycirculation", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@rateuniqueid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rateuniqueid"].Value = rateuniqueid;


                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@datefrom", SqlDbType.VarChar);
                objSqlCommand.Parameters["@datefrom"].Value = datefrom;


                objSqlCommand.Parameters.Add("@dateto", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dateto"].Value = dateto;


                objSqlCommand.Parameters.Add("@ratecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ratecode"].Value = ratecode;

                objSqlCommand.Parameters.Add("@adtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adtype"].Value = adtype;


                objSqlCommand.Parameters.Add("@rategroupcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rategroupcode"].Value = rategroupcode;

                objSqlCommand.Parameters.Add("@adcategory", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adcategory"].Value = adcategory;


                objSqlCommand.Parameters.Add("@currency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@currency"].Value = currency;

                objSqlCommand.Parameters.Add("@adsubcategory", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adsubcategory"].Value = adsubcategory;


                objSqlCommand.Parameters.Add("@package", SqlDbType.VarChar);
                objSqlCommand.Parameters["@package"].Value = package;

                objSqlCommand.Parameters.Add("@premium", SqlDbType.VarChar);
                objSqlCommand.Parameters["@premium"].Value = premium;


                objSqlCommand.Parameters.Add("@premiumval", SqlDbType.VarChar);
                objSqlCommand.Parameters["@premiumval"].Value = premiumval;



                objSqlCommand.Parameters.Add("@packagedesc", SqlDbType.VarChar);
                objSqlCommand.Parameters["@packagedesc"].Value = packagedesc;

                objSqlCommand.Parameters.Add("@uom", SqlDbType.VarChar);
                objSqlCommand.Parameters["@uom"].Value = uom;


                objSqlCommand.Parameters.Add("@sizefrom", SqlDbType.Int);
                if (sizefrom == "" || sizefrom == null)
                {
                    objSqlCommand.Parameters["@sizefrom"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@sizefrom"].Value = sizefrom;
                }

                objSqlCommand.Parameters.Add("@sizeto", SqlDbType.Int);
                if (sizeto == "" || sizeto == null)
                {
                    objSqlCommand.Parameters["@sizeto"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@sizeto"].Value = sizeto;
                }


                objSqlCommand.Parameters.Add("@consumption", SqlDbType.Int);
                if (consumption == "" || consumption == null)
                {
                    objSqlCommand.Parameters["@consumption"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@consumption"].Value = consumption;
                }

                objSqlCommand.Parameters.Add("@color", SqlDbType.VarChar);
                objSqlCommand.Parameters["@color"].Value = color;

                objSqlCommand.Parameters.Add("@remarks", SqlDbType.VarChar);
                objSqlCommand.Parameters["@remarks"].Value = remarks;


                objSqlCommand.Parameters.Add("@colorchrty", SqlDbType.VarChar);
                objSqlCommand.Parameters["@colorchrty"].Value = colorchrty;

                objSqlCommand.Parameters.Add("@weekdrate", SqlDbType.Decimal);
                if (weekdrate == "" || weekdrate == null)
                {
                    objSqlCommand.Parameters["@weekdrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@weekdrate"].Value = Convert.ToDecimal(weekdrate);
                }



                objSqlCommand.Parameters.Add("@weeminrate", SqlDbType.Decimal);
                if (weeminrate == "" || weeminrate == null)
                {
                    objSqlCommand.Parameters["@weeminrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@weeminrate"].Value = Convert.ToDecimal(weeminrate);
                }


                objSqlCommand.Parameters.Add("@extweerate", SqlDbType.Decimal);
                if (extweerate == "" || extweerate == null)
                {
                    objSqlCommand.Parameters["@extweerate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@extweerate"].Value = Convert.ToDecimal(extweerate);
                }

                objSqlCommand.Parameters.Add("@focusdarate", SqlDbType.Decimal);
                if (focusdarate == "" || focusdarate == null)
                {
                    objSqlCommand.Parameters["@focusdarate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@focusdarate"].Value = Convert.ToDecimal(focusdarate);
                }


                objSqlCommand.Parameters.Add("@focminrate", SqlDbType.Decimal);
                if (focminrate == "" || focminrate == null)
                {
                    objSqlCommand.Parameters["@focminrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@focminrate"].Value = Convert.ToDecimal(focminrate);
                }

                objSqlCommand.Parameters.Add("@focexrate", SqlDbType.Decimal);
                if (focexrate == "" || focexrate == null)
                {
                    objSqlCommand.Parameters["@focexrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@focexrate"].Value = Convert.ToDecimal(focexrate);
                }

                objSqlCommand.Parameters.Add("@validfromdate", SqlDbType.DateTime);
                if (validfromdate == "" || validfromdate == null)
                {
                    objSqlCommand.Parameters["@validfromdate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@validfromdate"].Value = validfromdate;
                }

                objSqlCommand.Parameters.Add("@validtill", SqlDbType.DateTime);
                if (validtill == "" || validtill == null)
                {
                    objSqlCommand.Parameters["@validtill"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@validtill"].Value = validtill;
                }


                //Convert.ToDateTime();
                objSqlCommand.Parameters.Add("@weekendrate", SqlDbType.Decimal);
                if (weekendrate == "" || weekendrate == null)
                {
                    objSqlCommand.Parameters["@weekendrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@weekendrate"].Value = Convert.ToDecimal(weekendrate);
                }


                objSqlCommand.Parameters.Add("@weekendmin", SqlDbType.Decimal);
                if (weekendmin == "" || weekendmin == null)
                {
                    objSqlCommand.Parameters["@weekendmin"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@weekendmin"].Value = Convert.ToDecimal(weekendmin);
                }

                objSqlCommand.Parameters.Add("@weekendextra", SqlDbType.Decimal);
                if (weekendextra == "" || weekendextra == null)
                {
                    objSqlCommand.Parameters["@weekendextra"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@weekendextra"].Value = Convert.ToDecimal(weekendextra);
                }


                objSqlCommand.Parameters.Add("@combination", SqlDbType.VarChar);
                objSqlCommand.Parameters["@combination"].Value = combination;

                objSqlCommand.Parameters.Add("@insertsolo", SqlDbType.VarChar);
                objSqlCommand.Parameters["@insertsolo"].Value = insertsolo;

                objSqlCommand.Parameters.Add("@flag", SqlDbType.VarChar);
                objSqlCommand.Parameters["@flag"].Value = flag;

                objSqlCommand.Parameters.Add("@minadarea", SqlDbType.Decimal);
                if (minadarea == "" || minadarea == null)
                {
                    objSqlCommand.Parameters["@minadarea"].Value = Convert.ToDecimal("0");
                }
                else
                {
                    objSqlCommand.Parameters["@minadarea"].Value = Convert.ToDecimal(minadarea);
                }


                objSqlCommand.Parameters.Add("@editionfrom", SqlDbType.Int);
                if (editionfrom == "" || editionfrom == null)
                {
                    objSqlCommand.Parameters["@editionfrom"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@editionfrom"].Value = Convert.ToInt32(editionfrom);
                }



                objSqlCommand.Parameters.Add("@editionto", SqlDbType.Int);
                if (editionto == "" || editionto == null)
                {
                    objSqlCommand.Parameters["@editionto"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@editionto"].Value = Convert.ToInt32(editionto);
                }

                objSqlCommand.Parameters.Add("@flramount", SqlDbType.Decimal);
                if (flramount == "" || flramount == null)
                {
                    objSqlCommand.Parameters["@flramount"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@flramount"].Value = Convert.ToDecimal(flramount);
                }

                objSqlCommand.Parameters.Add("@flrdiscount", SqlDbType.Decimal);
                if (flrdiscount == "" || flrdiscount == null)
                {
                    objSqlCommand.Parameters["@flrdiscount"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@flrdiscount"].Value = Convert.ToDecimal(flrdiscount);
                }

                objSqlCommand.Parameters.Add("@scheme", SqlDbType.VarChar);
                objSqlCommand.Parameters["@scheme"].Value = scheme;

                objSqlCommand.Parameters.Add("@adscat6", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adscat6"].Value = adscat6;


                objSqlCommand.Parameters.Add("@adscat5", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adscat5"].Value = adscat5;


                objSqlCommand.Parameters.Add("@adscat4", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adscat4"].Value = adscat4;

                objSqlCommand.Parameters.Add("@frominsert", SqlDbType.Int);
                if (frominsert == "" || frominsert == null)
                {
                    objSqlCommand.Parameters["@frominsert"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@frominsert"].Value = frominsert;
                }

                objSqlCommand.Parameters.Add("@toinsert", SqlDbType.Int);
                if (toinsert == "" || toinsert == null)
                {
                    objSqlCommand.Parameters["@toinsert"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@toinsert"].Value = toinsert;
                }

                objSqlCommand.Parameters.Add("@agetype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agetype"].Value = agetype;


                objSqlCommand.Parameters.Add("@clientcat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@clientcat"].Value = clientcat;

                objSqlCommand.Parameters.Add("@max_area", SqlDbType.VarChar);
                objSqlCommand.Parameters["@max_area"].Value = max_area;

                /*new change ankur for agency*/

                objSqlCommand.Parameters.Add("@type", SqlDbType.VarChar);
                objSqlCommand.Parameters["@type"].Value = type;

                objSqlCommand.Parameters.Add("@agencycode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencycode"].Value = agencycode;

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

        public DataSet uombind(string compcode, string userid,string value)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("binduomforrate", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

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
        /*new change ankur for agency*/
        public DataSet descriptioncirculation(string compcode, string packagecode, string weekrate, string focusrate, string txtratecode, string drpadtype, string drpadcategory, string drpsubcategory, string drpcolor, string drpcurrency, string validfromdate1, string validtill1, string weekendrate, string decimalvalue, string uom,string adscat4,string adscat5,string adscat6,string premium,string sizefrom,string sizeto,string frominsert,string toinsert,string decimalvalue11,string clientcat,string minadarea,string type,string agencycode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("binddescriptionforcirculation", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@packagecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@packagecode"].Value = packagecode;


                objSqlCommand.Parameters.Add("@txtratecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@txtratecode"].Value = txtratecode;

                objSqlCommand.Parameters.Add("@drpadtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@drpadtype"].Value = drpadtype;

                objSqlCommand.Parameters.Add("@drpadcategory", SqlDbType.VarChar);
                objSqlCommand.Parameters["@drpadcategory"].Value = drpadcategory;

                objSqlCommand.Parameters.Add("@drpsubcategory", SqlDbType.VarChar);
                objSqlCommand.Parameters["@drpsubcategory"].Value = drpsubcategory;

                objSqlCommand.Parameters.Add("@drpcolor", SqlDbType.VarChar);
                objSqlCommand.Parameters["@drpcolor"].Value = drpcolor;

                objSqlCommand.Parameters.Add("@drpcurrency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@drpcurrency"].Value = drpcurrency;


                objSqlCommand.Parameters.Add("@validfromdate1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@validfromdate1"].Value = validfromdate1;

                objSqlCommand.Parameters.Add("@validtill1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@validtill1"].Value = validtill1;



                objSqlCommand.Parameters.Add("@weekrate", SqlDbType.Decimal);
                if (weekrate == "" || weekrate == null)
                {
                    objSqlCommand.Parameters["@weekrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@weekrate"].Value = Convert.ToDecimal(weekrate);
                }

                objSqlCommand.Parameters.Add("@focusrate", SqlDbType.Decimal);
                if (focusrate == "" || focusrate == null)
                {
                    objSqlCommand.Parameters["@focusrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@focusrate"].Value = Convert.ToDecimal(focusrate);
                }

                objSqlCommand.Parameters.Add("@weekendrate", SqlDbType.Decimal);
                if (weekendrate == "" || weekendrate == null)
                {
                    objSqlCommand.Parameters["@weekendrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@weekendrate"].Value = Convert.ToDecimal(weekendrate);
                }

                objSqlCommand.Parameters.Add("@decimalvalue", SqlDbType.Int);
                if (decimalvalue == "" || decimalvalue == null)
                {
                    objSqlCommand.Parameters["@decimalvalue"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@decimalvalue"].Value = Convert.ToInt32(decimalvalue);
                }


                objSqlCommand.Parameters.Add("@uom", SqlDbType.VarChar);
                objSqlCommand.Parameters["@uom"].Value = uom;

                objSqlCommand.Parameters.Add("@adscat6", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adscat6"].Value = adscat6;

                objSqlCommand.Parameters.Add("@adscat5", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adscat5"].Value = adscat5;

                objSqlCommand.Parameters.Add("@adscat4", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adscat4"].Value = adscat4;

                objSqlCommand.Parameters.Add("@premium", SqlDbType.VarChar);
                objSqlCommand.Parameters["@premium"].Value = premium;

                objSqlCommand.Parameters.Add("@sizefrom", SqlDbType.VarChar);
                objSqlCommand.Parameters["@sizefrom"].Value = sizefrom;

                objSqlCommand.Parameters.Add("@sizeto", SqlDbType.VarChar);
                objSqlCommand.Parameters["@sizeto"].Value = sizeto;


                objSqlCommand.Parameters.Add("@frominsert", SqlDbType.VarChar);
                objSqlCommand.Parameters["@frominsert"].Value = frominsert;


                objSqlCommand.Parameters.Add("@toinsert", SqlDbType.VarChar);
                objSqlCommand.Parameters["@toinsert"].Value = toinsert;

                objSqlCommand.Parameters.Add("@decimalvalue11", SqlDbType.VarChar);
                objSqlCommand.Parameters["@decimalvalue11"].Value = decimalvalue11;


                objSqlCommand.Parameters.Add("@clientcat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@clientcat"].Value = clientcat;


                objSqlCommand.Parameters.Add("@minadarea", SqlDbType.VarChar);
                if (minadarea == "")
                {
                    objSqlCommand.Parameters["@minadarea"].Value = "0";
                }
                else
                {
                    objSqlCommand.Parameters["@minadarea"].Value = minadarea;
                }

                /*new change ankur for agency*/

                objSqlCommand.Parameters.Add("@type", SqlDbType.VarChar);
                objSqlCommand.Parameters["@type"].Value = type;


                objSqlCommand.Parameters.Add("@agencycode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencycode"].Value = agencycode;
                ////////////////////////////////

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

        public DataSet bindscategory4(string compcode, string adscat4, string value)
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

        public DataSet bindclientcat(string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Rate_bindclientcat", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

              



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

        public DataSet bindpckforadtype(string typecode, string compcode, string adcat,string adscat)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {

                objSqlConnection.Open();
                objSqlCommand = GetCommand("rate_bindpkg", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@typecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@typecode"].Value = typecode;

                objSqlCommand.Parameters.Add("@adcat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adcat"].Value = adcat;

                objSqlCommand.Parameters.Add("@adscat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adscat"].Value = adscat;




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

        public DataSet bindrateforgrid(string packagecode, string compcode,string dateformat)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("rate_bindgrid", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@packagecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@packagecode"].Value = packagecode;

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

        /*new change ankur 16 feb*/
        public DataSet getuom_desc(string compcode,string value)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getuomdesc", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

               

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




        public DataSet chkinsanddate(string compcode, string rateuniqueid, string type, string sizefrom, string sizeto, string fromins, string toins, string datefrom, string dateto, string tosave, string ratecode, string adtype, string adcategory, string adsubcategory, string color, string package, string currency, string uom, string adscat4, string adscat5, string adscat6, string premium, string clientcat, string minadarea, string agencycode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("rate_chkdateins", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@rateuniqueid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rateuniqueid"].Value = rateuniqueid;

                objSqlCommand.Parameters.Add("@type", SqlDbType.VarChar);
                objSqlCommand.Parameters["@type"].Value = type;

                objSqlCommand.Parameters.Add("@sizefrom", SqlDbType.VarChar);
                objSqlCommand.Parameters["@sizefrom"].Value = sizefrom;

                objSqlCommand.Parameters.Add("@sizeto", SqlDbType.VarChar);
                objSqlCommand.Parameters["@sizeto"].Value = sizeto;

                objSqlCommand.Parameters.Add("@fromins", SqlDbType.VarChar);
                objSqlCommand.Parameters["@fromins"].Value = fromins;

                objSqlCommand.Parameters.Add("@toins", SqlDbType.VarChar);
                objSqlCommand.Parameters["@toins"].Value = toins;

                objSqlCommand.Parameters.Add("@datefrom", SqlDbType.VarChar);
                objSqlCommand.Parameters["@datefrom"].Value = datefrom;

                objSqlCommand.Parameters.Add("@dateto", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dateto"].Value = dateto;

                objSqlCommand.Parameters.Add("@tosave", SqlDbType.VarChar);
                objSqlCommand.Parameters["@tosave"].Value = tosave;

                objSqlCommand.Parameters.Add("@ratecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ratecode"].Value = ratecode;

                objSqlCommand.Parameters.Add("@adtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adtype"].Value = adtype;

                objSqlCommand.Parameters.Add("@adcategory", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adcategory"].Value = adcategory;

                objSqlCommand.Parameters.Add("@adsubcategory", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adsubcategory"].Value = adsubcategory;

                objSqlCommand.Parameters.Add("@color", SqlDbType.VarChar);
                objSqlCommand.Parameters["@color"].Value = color;

                objSqlCommand.Parameters.Add("@package", SqlDbType.VarChar);
                objSqlCommand.Parameters["@package"].Value = package;

                objSqlCommand.Parameters.Add("@currency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@currency"].Value = currency;

                objSqlCommand.Parameters.Add("@uom", SqlDbType.VarChar);
                objSqlCommand.Parameters["@uom"].Value = uom;

                objSqlCommand.Parameters.Add("@adscat4", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adscat4"].Value = adscat4;

                objSqlCommand.Parameters.Add("@adscat5", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adscat5"].Value = adscat5;

                objSqlCommand.Parameters.Add("@adscat6", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adscat6"].Value = adscat6;

                objSqlCommand.Parameters.Add("@premium", SqlDbType.VarChar);
                objSqlCommand.Parameters["@premium"].Value = premium;

                objSqlCommand.Parameters.Add("@clientcat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@clientcat"].Value = clientcat;

                objSqlCommand.Parameters.Add("@minadarea", SqlDbType.VarChar);
                objSqlCommand.Parameters["@minadarea"].Value = minadarea;

                objSqlCommand.Parameters.Add("@agencycode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencycode"].Value = agencycode;


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
        //=======*****************To get Password of User*********************************//       
        public DataSet fetchPassword(string compcode, string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("fetchPassword", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlDataAdapter = new SqlDataAdapter();
                objSqlCommand.Parameters.Add("@compcode_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode_p"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid_p"].Value = userid;




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


        public DataSet bindPagePosition(string compcode, string bookingdate, string dateformat)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("WEBSP_GETPAGEPOSITION_DATEWISE", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@bookingdate", SqlDbType.VarChar);
                if (bookingdate == "")
                {
                    objSqlCommand.Parameters["@bookingdate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = bookingdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        bookingdate = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = bookingdate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        bookingdate = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@bookingdate"].Value = bookingdate;
                }

                objSqlDataAdapter = new SqlDataAdapter();
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
        public DataSet bindratecode(string compcode, string ratecode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("binndratecode", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@p_compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@p_ratecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_ratecode"].Value = ratecode;




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
