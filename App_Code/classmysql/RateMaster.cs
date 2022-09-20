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
    /// Summary description for RateMaster
    /// </summary>
    public class RateMaster:connection
    {
        public RateMaster()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataSet premiumbindcatwise(string compcode, string CATCODE)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("bindpremiumcatwise", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("advcatcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["advcatcode"].Value = CATCODE;





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

        public DataSet autogenrated(string compcode, string auto)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("getautocoderate", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("auto", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["auto"].Value = auto;


                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }
        }


        public DataSet bindscheme(string compcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("schemebind", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }
        }


        public DataSet getpremiumval(string compcode, string premium)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("gatvalpremium", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("premium", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["premium"].Value = premium;


                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }
        }

        public DataSet ratecodecheck(string compcode, string ratecode, string adtype, string adcategory, string adsubcategory, string color, string package, string currency, string fromdate, string todate, string uom, string adscat4, string adscat5, string adscat6, string premium, string sizefrom, string sizeto, string frominsert, string toinsert, string clientcat, string minadarea)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("chkratecode", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("uom", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["uom"].Value = uom;

                objmysqlcommand.Parameters.Add("ratecode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["ratecode"].Value = ratecode;

                objmysqlcommand.Parameters.Add("fromdate", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["fromdate"].Value = fromdate;

                objmysqlcommand.Parameters.Add("todate", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["todate"].Value = todate;

                objmysqlcommand.Parameters.Add("adtype", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adtype"].Value = adtype;

                objmysqlcommand.Parameters.Add("adcategory", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adcategory"].Value = adcategory;


                objmysqlcommand.Parameters.Add("adsubcategory", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adsubcategory"].Value = adsubcategory;

                objmysqlcommand.Parameters.Add("color", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["color"].Value = color;

                objmysqlcommand.Parameters.Add("package", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["package"].Value = package;

                objmysqlcommand.Parameters.Add("currency", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["currency"].Value = currency;


                objmysqlcommand.Parameters.Add("adscat6", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adscat6"].Value = adscat6;

                objmysqlcommand.Parameters.Add("adscat5", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adscat5"].Value = adscat5;

                objmysqlcommand.Parameters.Add("adscat4", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adscat4"].Value = adscat4;

                objmysqlcommand.Parameters.Add("premium", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["premium"].Value = premium;

                objmysqlcommand.Parameters.Add("sizefrom", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["sizefrom"].Value = sizefrom;

                objmysqlcommand.Parameters.Add("sizeto", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["sizeto"].Value = sizeto;

                objmysqlcommand.Parameters.Add("frominsert", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["frominsert"].Value = frominsert;

                objmysqlcommand.Parameters.Add("toinsert", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["toinsert"].Value = toinsert;

                objmysqlcommand.Parameters.Add("clientcat", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["clientcat"].Value = clientcat;

                objmysqlcommand.Parameters.Add("minadarea", MySqlDbType.VarChar);
                if (minadarea == "")
                {
                    objmysqlcommand.Parameters["minadarea"].Value = "0";
                }
                else
                {

                    objmysqlcommand.Parameters["minadarea"].Value = minadarea;
                }


                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }
        }

        public DataSet soloratechk(string compcode, string ratecode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("chksolocode", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("ratecode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["ratecode"].Value = ratecode;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }
        }


        public DataSet soloratebind(string compcode, string ratecode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("bindsolorate", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("ratecode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["ratecode"].Value = ratecode;





                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }
        }

        public DataSet chkpkgrate(string compcode, string ratecode, string adtype, string adcategory, string adsubcategory, string color, string package, string currency, string fromdate, string todate, string uom, string adscat4, string adscat5, string adscat6, string premium, string sizefrom, string sizeto, string frominsert, string toinsert, string clientcat, string minadarea)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("chksolopackage", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("ratecode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["ratecode"].Value = ratecode;

                objmysqlcommand.Parameters.Add("fromdate", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["fromdate"].Value = fromdate;

                objmysqlcommand.Parameters.Add("todate", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["todate"].Value = todate;

                objmysqlcommand.Parameters.Add("adtype", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adtype"].Value = adtype;

                objmysqlcommand.Parameters.Add("adcategory", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adcategory"].Value = adcategory;


                objmysqlcommand.Parameters.Add("adsubcategory", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adsubcategory"].Value = adsubcategory;

                objmysqlcommand.Parameters.Add("color", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["color"].Value = color;

                objmysqlcommand.Parameters.Add("package", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["package"].Value = package;

                objmysqlcommand.Parameters.Add("currency", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["currency"].Value = currency;

                objmysqlcommand.Parameters.Add("uom", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["uom"].Value = uom;

                objmysqlcommand.Parameters.Add("adscat6", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adscat6"].Value = adscat6;

                objmysqlcommand.Parameters.Add("adscat5", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adscat5"].Value = adscat5;

                objmysqlcommand.Parameters.Add("adscat4", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adscat4"].Value = adscat4;

                objmysqlcommand.Parameters.Add("premium", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["premium"].Value = premium;

                objmysqlcommand.Parameters.Add("sizefrom", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["sizefrom"].Value = sizefrom;

                objmysqlcommand.Parameters.Add("sizeto", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["sizeto"].Value = sizeto;

                objmysqlcommand.Parameters.Add("frominsert", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["frominsert"].Value = frominsert;


                objmysqlcommand.Parameters.Add("toinsert", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["toinsert"].Value = toinsert;


                objmysqlcommand.Parameters.Add("clientcat", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["clientcat"].Value = clientcat;



                objmysqlcommand.Parameters.Add("minadarea", MySqlDbType.VarChar);
                if (minadarea == "")
                {
                    objmysqlcommand.Parameters["minadarea"].Value = "0";
                }
                else
                {
                    objmysqlcommand.Parameters["minadarea"].Value = minadarea;
                }

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }
        }


        public DataSet insertratecode(string compcode, string userid, string ratecode, string adtype, string rategroupcode, string adcategory, string currency, string adsubcategory, string package, string packagedesc, string uom, string sizefrom, string sizeto, string consumption, string color, string colorchrty, string weekdrate, string weeminrate, string extweerate, string focusdarate, string focminrate, string focexrate, string validfromdate, string validtill, string remarks, string premium, string premiumval, string rateuniqueid, string weekendrate, string weekendmin, string weekendextra, string combination, string insertsolo, string minadarea, string editionfrom, string editionto, string flramount, string flrdiscount, string scheme, string adscat4, string adscat5, string adscat6, string frominsert, string toinsert, string agtype, string clientcat)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                string datefrom = validfromdate;
                string dateto = validtill;
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("insertratecode", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("rateuniqueid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["rateuniqueid"].Value = rateuniqueid;


                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("datefrom", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["datefrom"].Value = datefrom;


                objmysqlcommand.Parameters.Add("dateto", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["dateto"].Value = dateto;


                objmysqlcommand.Parameters.Add("ratecode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["ratecode"].Value = ratecode;

                objmysqlcommand.Parameters.Add("adtype", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adtype"].Value = adtype;


                objmysqlcommand.Parameters.Add("rategroupcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["rategroupcode"].Value = rategroupcode;

                objmysqlcommand.Parameters.Add("adcategory", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adcategory"].Value = adcategory;


                objmysqlcommand.Parameters.Add("currency", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["currency"].Value = currency;

                objmysqlcommand.Parameters.Add("adsubcategory", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adsubcategory"].Value = adsubcategory;


                objmysqlcommand.Parameters.Add("package", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["package"].Value = package;

                objmysqlcommand.Parameters.Add("premium", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["premium"].Value = premium;


                objmysqlcommand.Parameters.Add("premiumval", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["premiumval"].Value = premiumval;



                objmysqlcommand.Parameters.Add("packagedesc", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["packagedesc"].Value = packagedesc;

                objmysqlcommand.Parameters.Add("uom", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["uom"].Value = uom;


                objmysqlcommand.Parameters.Add("sizefrom", MySqlDbType.Int32);
                if (sizefrom == "" || sizefrom == null)
                {
                    objmysqlcommand.Parameters["sizefrom"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["sizefrom"].Value = sizefrom;
                }

                objmysqlcommand.Parameters.Add("sizeto", MySqlDbType.Int32);
                if (sizeto == "" || sizeto == null)
                {
                    objmysqlcommand.Parameters["sizeto"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["sizeto"].Value = sizeto;
                }


                objmysqlcommand.Parameters.Add("consumption", MySqlDbType.Int32);
                if (consumption == "" || consumption == null)
                {
                    objmysqlcommand.Parameters["consumption"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["consumption"].Value = consumption;
                }

                objmysqlcommand.Parameters.Add("color", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["color"].Value = color;


                objmysqlcommand.Parameters.Add("flramount", MySqlDbType.Decimal);
                if (flramount == "" || flramount == null)
                {
                    objmysqlcommand.Parameters["flramount"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["flramount"].Value = Convert.ToDecimal(flramount);
                }

                objmysqlcommand.Parameters.Add("flrdiscount", MySqlDbType.Decimal);
                if (flrdiscount == "" || flrdiscount == null)
                {
                    objmysqlcommand.Parameters["flrdiscount"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["flrdiscount"].Value = Convert.ToDecimal(flrdiscount);
                }

                objmysqlcommand.Parameters.Add("remarks", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["remarks"].Value = remarks;


                objmysqlcommand.Parameters.Add("colorchrty", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["colorchrty"].Value = colorchrty;

                objmysqlcommand.Parameters.Add("weekdrate", MySqlDbType.Decimal);
                if (weekdrate == "" || weekdrate == null)
                {
                    objmysqlcommand.Parameters["weekdrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["weekdrate"].Value = Convert.ToDecimal(weekdrate);
                }



                objmysqlcommand.Parameters.Add("weeminrate", MySqlDbType.Decimal);
                if (weeminrate == "" || weeminrate == null)
                {
                    objmysqlcommand.Parameters["weeminrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["weeminrate"].Value = Convert.ToDecimal(weeminrate);
                }


                objmysqlcommand.Parameters.Add("extweerate", MySqlDbType.Decimal);
                if (extweerate == "" || extweerate == null)
                {
                    objmysqlcommand.Parameters["extweerate"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["extweerate"].Value = Convert.ToDecimal(extweerate);
                }

                objmysqlcommand.Parameters.Add("focusdarate", MySqlDbType.Decimal);
                if (focusdarate == "" || focusdarate == null)
                {
                    objmysqlcommand.Parameters["focusdarate"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["focusdarate"].Value = Convert.ToDecimal(focusdarate);
                }


                objmysqlcommand.Parameters.Add("focminrate", MySqlDbType.Decimal);
                if (focminrate == "" || focminrate == null)
                {
                    objmysqlcommand.Parameters["focminrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["focminrate"].Value = Convert.ToDecimal(focminrate);
                }

                objmysqlcommand.Parameters.Add("focexrate", MySqlDbType.Decimal);
                if (focexrate == "" || focexrate == null)
                {
                    objmysqlcommand.Parameters["focexrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["focexrate"].Value = Convert.ToDecimal(focexrate);
                }

                objmysqlcommand.Parameters.Add("validfromdate", MySqlDbType.DateTime);
                if (validfromdate == "" || validfromdate == null)
                {
                    objmysqlcommand.Parameters["validfromdate"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["validfromdate"].Value = validfromdate;
                }

                objmysqlcommand.Parameters.Add("validtill", MySqlDbType.DateTime);
                if (validtill == "" || validtill == null)
                {
                    objmysqlcommand.Parameters["validtill"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["validtill"].Value = validtill;
                }


                //Convert.ToDateTime();
                objmysqlcommand.Parameters.Add("weekendrate", MySqlDbType.Decimal);
                if (weekendrate == "" || weekendrate == null)
                {
                    objmysqlcommand.Parameters["weekendrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["weekendrate"].Value = Convert.ToDecimal(weekendrate);
                }


                objmysqlcommand.Parameters.Add("weekendmin", MySqlDbType.Decimal);
                if (weekendmin == "" || weekendmin == null)
                {
                    objmysqlcommand.Parameters["weekendmin"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["weekendmin"].Value = Convert.ToDecimal(weekendmin);
                }

                objmysqlcommand.Parameters.Add("weekendextra", MySqlDbType.Decimal);
                if (weekendextra == "" || weekendextra == null)
                {
                    objmysqlcommand.Parameters["weekendextra"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["weekendextra"].Value = Convert.ToDecimal(weekendextra);
                }


                objmysqlcommand.Parameters.Add("combination", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["combination"].Value = combination;

                objmysqlcommand.Parameters.Add("insertsolo", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["insertsolo"].Value = insertsolo;

                objmysqlcommand.Parameters.Add("minadarea", MySqlDbType.Decimal);
                if (minadarea == "" || minadarea == null)
                {
                    objmysqlcommand.Parameters["minadarea"].Value = Convert.ToDecimal("0");
                }
                else
                {
                    objmysqlcommand.Parameters["minadarea"].Value = Convert.ToDecimal(minadarea);
                }

                objmysqlcommand.Parameters.Add("editionfrom", MySqlDbType.Int32);
                if (editionfrom == "" || editionfrom == null)
                {
                    objmysqlcommand.Parameters["editionfrom"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["editionfrom"].Value = Convert.ToInt32(editionfrom);
                }

                objmysqlcommand.Parameters.Add("editionto", MySqlDbType.Int32);
                if (editionto == "" || editionto == null)
                {
                    objmysqlcommand.Parameters["editionto"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["editionto"].Value = Convert.ToInt32(editionto);
                }


                objmysqlcommand.Parameters.Add("scheme", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["scheme"].Value = scheme;

                objmysqlcommand.Parameters.Add("adscat6", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adscat6"].Value = adscat6;


                objmysqlcommand.Parameters.Add("adscat5", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adscat5"].Value = adscat5;


                objmysqlcommand.Parameters.Add("adscat4", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adscat4"].Value = adscat4;

                objmysqlcommand.Parameters.Add("frominsert", MySqlDbType.Int32);
                if (frominsert == "" || frominsert == null)
                {
                    objmysqlcommand.Parameters["frominsert"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["frominsert"].Value = frominsert;
                }

                objmysqlcommand.Parameters.Add("toinsert", MySqlDbType.Int32);
                if (toinsert == "" || toinsert == null)
                {
                    objmysqlcommand.Parameters["toinsert"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["toinsert"].Value = toinsert;
                }

                objmysqlcommand.Parameters.Add("agtype", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agtype"].Value = agtype;

                objmysqlcommand.Parameters.Add("clientcat", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["clientcat"].Value = clientcat;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }
        }

        public DataSet soloinsert(string compcode, string userid, string ratecode, string adtype, string rategroupcode, string adcategory, string currency, string adsubcategory, string package, string packagedesc, string uom, string sizefrom, string sizeto, string consumption, string color, string colorchrty, string weekdrate, string weeminrate, string extweerate, string focusdarate, string focminrate, string focexrate, string validfromdate, string validtill, string remarks, string premium, string premiumval, string rateuniqueid, string weekendrate, string weekendmin, string weekendextra, string combination, string insertsolo, string flag, string adscat4, string adscat5, string adscat6, string frominsert, string toinsert, string agtype, string clientcat, string minadarea)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                string datefrom = validfromdate;
                string dateto = validtill;
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("insertsolorate", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("rateuniqueid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["rateuniqueid"].Value = rateuniqueid;


                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("datefrom", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["datefrom"].Value = datefrom;


                objmysqlcommand.Parameters.Add("dateto", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["dateto"].Value = dateto;


                objmysqlcommand.Parameters.Add("ratecode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["ratecode"].Value = ratecode;

                objmysqlcommand.Parameters.Add("adtype", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adtype"].Value = adtype;


                objmysqlcommand.Parameters.Add("rategroupcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["rategroupcode"].Value = rategroupcode;

                objmysqlcommand.Parameters.Add("adcategory", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adcategory"].Value = adcategory;


                objmysqlcommand.Parameters.Add("currency", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["currency"].Value = currency;

                objmysqlcommand.Parameters.Add("adsubcategory", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adsubcategory"].Value = adsubcategory;


                objmysqlcommand.Parameters.Add("package", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["package"].Value = package;

                objmysqlcommand.Parameters.Add("premium", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["premium"].Value = premium;


                objmysqlcommand.Parameters.Add("premiumval", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["premiumval"].Value = premiumval;



                objmysqlcommand.Parameters.Add("packagedesc", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["packagedesc"].Value = packagedesc;

                objmysqlcommand.Parameters.Add("uom", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["uom"].Value = uom;


                objmysqlcommand.Parameters.Add("sizefrom", MySqlDbType.Int32);
                if (sizefrom == "" || sizefrom == null)
                {
                    objmysqlcommand.Parameters["sizefrom"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["sizefrom"].Value = sizefrom;
                }

                objmysqlcommand.Parameters.Add("sizeto", MySqlDbType.Int32);
                if (sizeto == "" || sizeto == null)
                {
                    objmysqlcommand.Parameters["sizeto"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["sizeto"].Value = sizeto;
                }


                objmysqlcommand.Parameters.Add("consumption", MySqlDbType.Int32);
                if (consumption == "" || consumption == null)
                {
                    objmysqlcommand.Parameters["consumption"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["consumption"].Value = consumption;
                }

                objmysqlcommand.Parameters.Add("color", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["color"].Value = color;

                objmysqlcommand.Parameters.Add("remarks", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["remarks"].Value = remarks;


                objmysqlcommand.Parameters.Add("colorchrty", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["colorchrty"].Value = colorchrty;

                objmysqlcommand.Parameters.Add("weekdrate", MySqlDbType.Decimal);
                if (weekdrate == "" || weekdrate == null)
                {
                    objmysqlcommand.Parameters["weekdrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["weekdrate"].Value = Convert.ToDecimal(weekdrate);
                }



                objmysqlcommand.Parameters.Add("weeminrate", MySqlDbType.Decimal);
                if (weeminrate == "" || weeminrate == null)
                {
                    objmysqlcommand.Parameters["weeminrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["weeminrate"].Value = Convert.ToDecimal(weeminrate);
                }


                objmysqlcommand.Parameters.Add("extweerate", MySqlDbType.Decimal);
                if (extweerate == "" || extweerate == null)
                {
                    objmysqlcommand.Parameters["extweerate"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["extweerate"].Value = Convert.ToDecimal(extweerate);
                }

                objmysqlcommand.Parameters.Add("focusdarate", MySqlDbType.Decimal);
                if (focusdarate == "" || focusdarate == null)
                {
                    objmysqlcommand.Parameters["focusdarate"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["focusdarate"].Value = Convert.ToDecimal(focusdarate);
                }


                objmysqlcommand.Parameters.Add("focminrate", MySqlDbType.Decimal);
                if (focminrate == "" || focminrate == null)
                {
                    objmysqlcommand.Parameters["focminrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["focminrate"].Value = Convert.ToDecimal(focminrate);
                }

                objmysqlcommand.Parameters.Add("focexrate", MySqlDbType.Decimal);
                if (focexrate == "" || focexrate == null)
                {
                    objmysqlcommand.Parameters["focexrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["focexrate"].Value = Convert.ToDecimal(focexrate);
                }

                objmysqlcommand.Parameters.Add("validfromdate", MySqlDbType.DateTime);
                if (validfromdate == "" || validfromdate == null)
                {
                    objmysqlcommand.Parameters["validfromdate"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["validfromdate"].Value = validfromdate;
                }

                objmysqlcommand.Parameters.Add("validtill", MySqlDbType.DateTime);
                if (validtill == "" || validtill == null)
                {
                    objmysqlcommand.Parameters["validtill"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["validtill"].Value = validtill;
                }


                //Convert.ToDateTime();
                objmysqlcommand.Parameters.Add("weekendrate", MySqlDbType.Decimal);
                if (weekendrate == "" || weekendrate == null)
                {
                    objmysqlcommand.Parameters["weekendrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["weekendrate"].Value = Convert.ToDecimal(weekendrate);
                }


                objmysqlcommand.Parameters.Add("weekendmin", MySqlDbType.Decimal);
                if (weekendmin == "" || weekendmin == null)
                {
                    objmysqlcommand.Parameters["weekendmin"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["weekendmin"].Value = Convert.ToDecimal(weekendmin);
                }

                objmysqlcommand.Parameters.Add("weekendextra", MySqlDbType.Decimal);
                if (weekendextra == "" || weekendextra == null)
                {
                    objmysqlcommand.Parameters["weekendextra"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["weekendextra"].Value = Convert.ToDecimal(weekendextra);
                }


                objmysqlcommand.Parameters.Add("combination", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["combination"].Value = combination;

                objmysqlcommand.Parameters.Add("insertsolo", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["insertsolo"].Value = insertsolo;

                objmysqlcommand.Parameters.Add("flag", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["flag"].Value = flag;

                objmysqlcommand.Parameters.Add("adscat6", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adscat6"].Value = adscat6;

                objmysqlcommand.Parameters.Add("adscat5", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adscat5"].Value = adscat5;

                objmysqlcommand.Parameters.Add("adscat4", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adscat4"].Value = adscat4;

                objmysqlcommand.Parameters.Add("frominsert", MySqlDbType.Int32);
                if (frominsert == "" || frominsert == null)
                {
                    objmysqlcommand.Parameters["frominsert"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["frominsert"].Value = frominsert;
                }

                objmysqlcommand.Parameters.Add("toinsert", MySqlDbType.Int32);
                if (toinsert == "" || toinsert == null)
                {
                    objmysqlcommand.Parameters["toinsert"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["toinsert"].Value = toinsert;
                }

                objmysqlcommand.Parameters.Add("agtype", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agtype"].Value = agtype;

                objmysqlcommand.Parameters.Add("clientcat", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["clientcat"].Value = clientcat;


                objmysqlcommand.Parameters.Add("minadarea", MySqlDbType.VarChar);
                if (minadarea == "")
                {
                    objmysqlcommand.Parameters["minadarea"].Value = "0";
                }
                else
                {
                    objmysqlcommand.Parameters["minadarea"].Value = minadarea;
                }

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }
        }


        public DataSet solorateget(string compcode, string userid, string ratecode, string adtype, string rategroupcode, string adcategory, string currency, string adsubcategory, string package, string packagedesc, string uom, string sizefrom, string sizeto, string consumption, string color, string colorchrty, string weekdrate, string weeminrate, string extweerate, string focusdarate, string focminrate, string focexrate, string validfromdate, string validtill, string remarks, string premium, string premiumval, string rateuniqueid, string weekendrate, string weekendmin, string weekendextra, string combination, string insertsolo, string clientcat, string minadarea)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                string datefrom = validfromdate;
                string dateto = validtill;
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("getsolorate", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("rateuniqueid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["rateuniqueid"].Value = rateuniqueid;


                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("datefrom", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["datefrom"].Value = datefrom;


                objmysqlcommand.Parameters.Add("dateto", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["dateto"].Value = dateto;


                objmysqlcommand.Parameters.Add("ratecode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["ratecode"].Value = ratecode;

                objmysqlcommand.Parameters.Add("adtype", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adtype"].Value = adtype;


                objmysqlcommand.Parameters.Add("rategroupcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["rategroupcode"].Value = rategroupcode;

                objmysqlcommand.Parameters.Add("adcategory", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adcategory"].Value = adcategory;


                objmysqlcommand.Parameters.Add("currency", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["currency"].Value = currency;

                objmysqlcommand.Parameters.Add("adsubcategory", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adsubcategory"].Value = adsubcategory;


                objmysqlcommand.Parameters.Add("package", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["package"].Value = package;

                objmysqlcommand.Parameters.Add("premium", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["premium"].Value = premium;


                objmysqlcommand.Parameters.Add("premiumval", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["premiumval"].Value = premiumval;



                objmysqlcommand.Parameters.Add("packagedesc", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["packagedesc"].Value = packagedesc;

                objmysqlcommand.Parameters.Add("uom", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["uom"].Value = uom;


                objmysqlcommand.Parameters.Add("sizefrom", MySqlDbType.Int32);
                if (sizefrom == "" || sizefrom == null)
                {
                    objmysqlcommand.Parameters["sizefrom"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["sizefrom"].Value = sizefrom;
                }

                objmysqlcommand.Parameters.Add("sizeto", MySqlDbType.Int32);
                if (sizeto == "" || sizeto == null)
                {
                    objmysqlcommand.Parameters["sizeto"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["sizeto"].Value = sizeto;
                }


                objmysqlcommand.Parameters.Add("consumption", MySqlDbType.Int32);
                if (consumption == "" || consumption == null)
                {
                    objmysqlcommand.Parameters["consumption"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["consumption"].Value = consumption;
                }

                objmysqlcommand.Parameters.Add("color", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["color"].Value = color;

                objmysqlcommand.Parameters.Add("remarks", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["remarks"].Value = remarks;


                objmysqlcommand.Parameters.Add("colorchrty", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["colorchrty"].Value = colorchrty;

                objmysqlcommand.Parameters.Add("weekdrate", MySqlDbType.Decimal);
                if (weekdrate == "" || weekdrate == null)
                {
                    objmysqlcommand.Parameters["weekdrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["weekdrate"].Value = Convert.ToDecimal(weekdrate);
                }



                objmysqlcommand.Parameters.Add("weeminrate", MySqlDbType.Decimal);
                if (weeminrate == "" || weeminrate == null)
                {
                    objmysqlcommand.Parameters["weeminrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["weeminrate"].Value = Convert.ToDecimal(weeminrate);
                }


                objmysqlcommand.Parameters.Add("extweerate", MySqlDbType.Decimal);
                if (extweerate == "" || extweerate == null)
                {
                    objmysqlcommand.Parameters["extweerate"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["extweerate"].Value = Convert.ToDecimal(extweerate);
                }

                objmysqlcommand.Parameters.Add("focusdarate", MySqlDbType.Decimal);
                if (focusdarate == "" || focusdarate == null)
                {
                    objmysqlcommand.Parameters["focusdarate"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["focusdarate"].Value = Convert.ToDecimal(focusdarate);
                }


                objmysqlcommand.Parameters.Add("focminrate", MySqlDbType.Decimal);
                if (focminrate == "" || focminrate == null)
                {
                    objmysqlcommand.Parameters["focminrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["focminrate"].Value = Convert.ToDecimal(focminrate);
                }

                objmysqlcommand.Parameters.Add("focexrate", MySqlDbType.Decimal);
                if (focexrate == "" || focexrate == null)
                {
                    objmysqlcommand.Parameters["focexrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["focexrate"].Value = Convert.ToDecimal(focexrate);
                }

                objmysqlcommand.Parameters.Add("validfromdate", MySqlDbType.DateTime);
                if (validfromdate == "" || validfromdate == null)
                {
                    objmysqlcommand.Parameters["validfromdate"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["validfromdate"].Value = validfromdate;
                }

                objmysqlcommand.Parameters.Add("validtill", MySqlDbType.DateTime);
                if (validtill == "" || validtill == null)
                {
                    objmysqlcommand.Parameters["validtill"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["validtill"].Value = validtill;
                }


                //Convert.ToDateTime();
                objmysqlcommand.Parameters.Add("weekendrate", MySqlDbType.Decimal);
                if (weekendrate == "" || weekendrate == null)
                {
                    objmysqlcommand.Parameters["weekendrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["weekendrate"].Value = Convert.ToDecimal(weekendrate);
                }


                objmysqlcommand.Parameters.Add("weekendmin", MySqlDbType.Decimal);
                if (weekendmin == "" || weekendmin == null)
                {
                    objmysqlcommand.Parameters["weekendmin"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["weekendmin"].Value = Convert.ToDecimal(weekendmin);
                }

                objmysqlcommand.Parameters.Add("weekendextra", MySqlDbType.Decimal);
                if (weekendextra == "" || weekendextra == null)
                {
                    objmysqlcommand.Parameters["weekendextra"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["weekendextra"].Value = Convert.ToDecimal(weekendextra);
                }


                objmysqlcommand.Parameters.Add("combination", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["combination"].Value = combination;

                objmysqlcommand.Parameters.Add("insertsolo", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["insertsolo"].Value = insertsolo;

                objmysqlcommand.Parameters.Add("clientcat", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["clientcat"].Value = clientcat;

                objmysqlcommand.Parameters.Add("minadarea", MySqlDbType.VarChar);
                if (minadarea == "")
                {
                    objmysqlcommand.Parameters["minadarea"].Value = "0";
                }
                else
                {
                    objmysqlcommand.Parameters["minadarea"].Value = minadarea;
                }



                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }
        }

        public DataSet insertintorate(string compcode, string userid, string ratecode, string adtype, string rategroupcode, string adcategory, string currency, string adsubcategory, string package, string packagedesc, string uom, string sizefrom, string sizeto, string consumption, string color, string colorchrty, string weekdrate, string weeminrate, string extweerate, string focusdarate, string focminrate, string focexrate, string validfromdate, string validtill, string remarks, string premium, string premiumval, string rateuniqueid, string weekendrate, string weekendmin, string weekendextra, string minadarea, string editionfrom, string editionto, string flramount, string flrdiscount, string scheme, string adscat4, string adscat5, string adscat6, string frominsert, string toinsert, string agtype, string clientcat, string max_area, string type, string agencycode, string dateformat, string pubcenter, string rate_sun, string rate_mon, string rate_tue, string rate_wed, string rate_thu, string rate_fri, string rate_sat, string rate_sun_extra, string rate_mon_extra, string rate_tue_extra, string rate_wed_extra, string rate_thu_extra, string rate_fri_extra, string rate_sat_extra, string width_max)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                //string datefrom = validfromdate;
                //string dateto = validtill;
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("insertratemast", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("rateuniqueid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["rateuniqueid"].Value = rateuniqueid;


                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                //objmysqlcommand.Parameters.Add("datefrom", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["datefrom"].Value = datefrom;


                //objmysqlcommand.Parameters.Add("dateto", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["dateto"].Value = dateto;


                objmysqlcommand.Parameters.Add("ratecode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["ratecode"].Value = ratecode;

                objmysqlcommand.Parameters.Add("adtype", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adtype"].Value = adtype;


                objmysqlcommand.Parameters.Add("rategroupcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["rategroupcode"].Value = rategroupcode;

                objmysqlcommand.Parameters.Add("adcategory", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adcategory"].Value = adcategory;


                objmysqlcommand.Parameters.Add("currency", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["currency"].Value = currency;

                objmysqlcommand.Parameters.Add("adsubcategory", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adsubcategory"].Value = adsubcategory;


                objmysqlcommand.Parameters.Add("package", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["package"].Value = package;

                objmysqlcommand.Parameters.Add("premium", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["premium"].Value = premium;


                objmysqlcommand.Parameters.Add("premiumval", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["premiumval"].Value = premiumval;



                objmysqlcommand.Parameters.Add("packagedesc", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["packagedesc"].Value = packagedesc;

                objmysqlcommand.Parameters.Add("uom", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["uom"].Value = uom;


                objmysqlcommand.Parameters.Add("sizefrom", MySqlDbType.Int32);
                if (sizefrom == "" || sizefrom == null)
                {
                    objmysqlcommand.Parameters["sizefrom"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["sizefrom"].Value = sizefrom;
                }

                objmysqlcommand.Parameters.Add("sizeto", MySqlDbType.Int32);
                if (sizeto == "" || sizeto == null)
                {
                    objmysqlcommand.Parameters["sizeto"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["sizeto"].Value = sizeto;
                }


                objmysqlcommand.Parameters.Add("consumption", MySqlDbType.Int32);
                if (consumption == "" || consumption == null)
                {
                    objmysqlcommand.Parameters["consumption"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["consumption"].Value = consumption;
                }

                objmysqlcommand.Parameters.Add("color", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["color"].Value = color;

                objmysqlcommand.Parameters.Add("remarks", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["remarks"].Value = remarks;


                objmysqlcommand.Parameters.Add("colorchrty", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["colorchrty"].Value = colorchrty;

                objmysqlcommand.Parameters.Add("weekdrate", MySqlDbType.Decimal);
                if (weekdrate == "" || weekdrate == null)
                {
                    objmysqlcommand.Parameters["weekdrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["weekdrate"].Value = Convert.ToDecimal(weekdrate);
                }



                objmysqlcommand.Parameters.Add("weeminrate", MySqlDbType.Decimal);
                if (weeminrate == "" || weeminrate == null)
                {
                    objmysqlcommand.Parameters["weeminrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["weeminrate"].Value = Convert.ToDecimal(weeminrate);
                }


                objmysqlcommand.Parameters.Add("extweerate", MySqlDbType.Decimal);
                if (extweerate == "" || extweerate == null)
                {
                    objmysqlcommand.Parameters["extweerate"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["extweerate"].Value = Convert.ToDecimal(extweerate);
                }

                objmysqlcommand.Parameters.Add("focusdarate", MySqlDbType.Decimal);
                if (focusdarate == "" || focusdarate == null)
                {
                    objmysqlcommand.Parameters["focusdarate"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["focusdarate"].Value = Convert.ToDecimal(focusdarate);
                }


                objmysqlcommand.Parameters.Add("focminrate", MySqlDbType.Decimal);
                if (focminrate == "" || focminrate == null)
                {
                    objmysqlcommand.Parameters["focminrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["focminrate"].Value = Convert.ToDecimal(focminrate);
                }

                objmysqlcommand.Parameters.Add("focexrate", MySqlDbType.Decimal);
                if (focexrate == "" || focexrate == null)
                {
                    objmysqlcommand.Parameters["focexrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["focexrate"].Value = Convert.ToDecimal(focexrate);
                }

                objmysqlcommand.Parameters.Add("validfromdate", MySqlDbType.DateTime);
                if (validfromdate == "" || validfromdate == null)
                {
                    objmysqlcommand.Parameters["validfromdate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat=="dd/mm/yyyy")
                    {
                        string[] arr = validfromdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        validfromdate = yy + "/" + mm + "/" + dd;
                    }
                    else if(dateformat =="mm/dd/yyyy")
                    {
                        string[] arr = validfromdate.Split('/');
                        string mm = arr[0];
                        string dd = arr[1];
                        string yy = arr[2];
                        validfromdate = yy + "/" + mm + "/" + dd;
                    }
                    objmysqlcommand.Parameters["validfromdate"].Value = validfromdate;
                }

                objmysqlcommand.Parameters.Add("validtill", MySqlDbType.DateTime);
                if (validtill == "" || validtill == null)
                {
                    objmysqlcommand.Parameters["validtill"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["validtill"].Value = validtill;
                }


                //Convert.ToDateTime();
                objmysqlcommand.Parameters.Add("weekendrate", MySqlDbType.Decimal);
                if (weekendrate == "" || weekendrate == null)
                {
                    objmysqlcommand.Parameters["weekendrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["weekendrate"].Value = Convert.ToDecimal(weekendrate);
                }


                objmysqlcommand.Parameters.Add("weekendmin", MySqlDbType.Decimal);
                if (weekendmin == "" || weekendmin == null)
                {
                    objmysqlcommand.Parameters["weekendmin"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["weekendmin"].Value = Convert.ToDecimal(weekendmin);
                }

                objmysqlcommand.Parameters.Add("weekendextra", MySqlDbType.Decimal);
                if (weekendextra == "" || weekendextra == null)
                {
                    objmysqlcommand.Parameters["weekendextra"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["weekendextra"].Value = Convert.ToDecimal(weekendextra);
                }

                objmysqlcommand.Parameters.Add("minadarea", MySqlDbType.Decimal);
                if (minadarea == "" || minadarea == null)
                {
                    objmysqlcommand.Parameters["minadarea"].Value = Convert.ToDecimal("0");
                }
                else
                {
                    objmysqlcommand.Parameters["minadarea"].Value = Convert.ToDecimal(minadarea);
                }

                objmysqlcommand.Parameters.Add("editionfrom", MySqlDbType.Int32);
                if (editionfrom == "" || editionfrom == null)
                {
                    objmysqlcommand.Parameters["editionfrom"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["editionfrom"].Value = Convert.ToInt32(editionfrom);
                }

                objmysqlcommand.Parameters.Add("editionto", MySqlDbType.Int32);
                if (editionto == "" || editionto == null)
                {
                    objmysqlcommand.Parameters["editionto"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["editionto"].Value = Convert.ToInt32(editionto);
                }

                objmysqlcommand.Parameters.Add("flramount", MySqlDbType.Decimal);
                if (flramount == "" || flramount == null)
                {
                    objmysqlcommand.Parameters["flramount"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["flramount"].Value = Convert.ToDecimal(flramount);
                }


                objmysqlcommand.Parameters.Add("flrdiscount", MySqlDbType.Decimal);
                if (flrdiscount == "" || flrdiscount == null)
                {
                    objmysqlcommand.Parameters["flrdiscount"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["flrdiscount"].Value = Convert.ToDecimal(flrdiscount);
                }

                objmysqlcommand.Parameters.Add("scheme1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["scheme1"].Value = scheme;

                objmysqlcommand.Parameters.Add("adscat6", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adscat6"].Value = adscat6;


                objmysqlcommand.Parameters.Add("adscat5", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adscat5"].Value = adscat5;


                objmysqlcommand.Parameters.Add("adscat4", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adscat4"].Value = adscat4;

                objmysqlcommand.Parameters.Add("frominsert", MySqlDbType.Int32);
                if (frominsert == "" || frominsert == null)
                {
                    objmysqlcommand.Parameters["frominsert"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["frominsert"].Value = frominsert;
                }


                objmysqlcommand.Parameters.Add("toinsert", MySqlDbType.Int32);
                if (toinsert == "" || toinsert == null)
                {
                    objmysqlcommand.Parameters["toinsert"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["toinsert"].Value = toinsert;
                }

                objmysqlcommand.Parameters.Add("agtype", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agtype"].Value = agtype;

                objmysqlcommand.Parameters.Add("clientcat", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["clientcat"].Value = clientcat;

                objmysqlcommand.Parameters.Add("maxadarea", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["maxadarea"].Value = max_area;

                objmysqlcommand.Parameters.Add("type1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["type1"].Value = type;

                objmysqlcommand.Parameters.Add("agencycode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agencycode"].Value = agencycode;

                objmysqlcommand.Parameters.Add("dateformat", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["dateformat"].Value = dateformat;

                objmysqlcommand.Parameters.Add("pubcenter", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pubcenter"].Value = pubcenter;

                objmysqlcommand.Parameters.Add("rate_sun", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["rate_sun"].Value =Convert.ToDouble(rate_sun);

                objmysqlcommand.Parameters.Add("rate_mon", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["rate_mon"].Value =Convert.ToDouble(rate_mon);

                objmysqlcommand.Parameters.Add("rate_tue", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["rate_tue"].Value = Convert.ToDouble(rate_tue);

                objmysqlcommand.Parameters.Add("rate_wed", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["rate_wed"].Value =Convert.ToDouble(rate_wed);

                objmysqlcommand.Parameters.Add("rate_thu", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["rate_thu"].Value = Convert.ToDouble(rate_thu);

                objmysqlcommand.Parameters.Add("rate_fri", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["rate_fri"].Value = Convert.ToDouble(rate_fri);

                objmysqlcommand.Parameters.Add("rate_sat", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["rate_sat"].Value = Convert.ToDouble(rate_sat);
 
                objmysqlcommand.Parameters.Add("rate_sun_extra", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["rate_sun_extra"].Value = Convert.ToDouble(rate_sun_extra);

                objmysqlcommand.Parameters.Add("rate_mon_extra", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["rate_mon_extra"].Value =Convert.ToDouble(rate_mon_extra);

                objmysqlcommand.Parameters.Add("rate_tue_extra", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["rate_tue_extra"].Value =Convert.ToDouble(rate_tue_extra);

                objmysqlcommand.Parameters.Add("rate_wed_extra", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["rate_wed_extra"].Value = Convert.ToDouble(rate_wed_extra);

                objmysqlcommand.Parameters.Add("rate_thu_extra", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["rate_thu_extra"].Value = Convert.ToDouble(rate_thu_extra);

                objmysqlcommand.Parameters.Add("rate_fri_extra", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["rate_fri_extra"].Value = Convert.ToDouble(rate_fri_extra);

                objmysqlcommand.Parameters.Add("rate_sat_extra", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["rate_sat_extra"].Value = Convert.ToDouble(rate_sat_extra);

                objmysqlcommand.Parameters.Add("width_max", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["width_max"].Value =Convert.ToDouble(width_max);

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }
        }


        public DataSet RateCheck(string compcode, string userid,string rateuniqueid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("chkduplicaterate", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("rateuniqueid1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["rateuniqueid1"].Value = rateuniqueid;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }
        }

        public DataSet executedate(string compcode, string adtype, string adcat, string uomcode, string editioncode, string schemecode, string dateformat)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("executeratecode", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("adtype", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adtype"].Value = adtype;

                objmysqlcommand.Parameters.Add("adcat", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adcat"].Value = adcat;

                objmysqlcommand.Parameters.Add("uomcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["uomcode"].Value = uomcode;

                objmysqlcommand.Parameters.Add("editioncode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["editioncode"].Value = editioncode;

                objmysqlcommand.Parameters.Add("schemecode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["schemecode"].Value = schemecode;

                objmysqlcommand.Parameters.Add("dateformat", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["dateformat"].Value = dateformat;


                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }
        }


        public void modifyrate(string compcode, string rateuniqueid, string rate, string extrarate, string sizeto)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
           // MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
          //  DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("modifyrate", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("rateuniqueid1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["rateuniqueid1"].Value = rateuniqueid;

                objmysqlcommand.Parameters.Add("rate", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["rate"].Value = rate;

                objmysqlcommand.Parameters.Add("extrarate", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["extrarate"].Value = extrarate;

                objmysqlcommand.Parameters.Add("sizeto", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["sizeto"].Value = sizeto;

                objmysqlcommand.ExecuteNonQuery();
                //objmysqlDataAdapter.SelectCommand = objmysqlcommand;
               // objmysqlDataAdapter.Fill(objDataSet);

               // return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }
        }

        public void deleteratemast(string rateuniqueid, string compcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("deleterate", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("rateuniqueid1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["rateuniqueid1"].Value = rateuniqueid;

                objmysqlcommand.ExecuteNonQuery();
               
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }
        }

        public DataSet premiumbind(string compcode, string adtype)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("bindpremiumforrate", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;


                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("adtype", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adtype"].Value = adtype;





                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }
        }

        public DataSet paccolochk(string package, string color, string compcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("chkpackagecolor", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;


                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("package", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["package"].Value = package;

                objmysqlcommand.Parameters.Add("color", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["color"].Value = color;







                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }
        }


        public DataSet modifyrate(string compcode, string userid, string ratecode, string adtype, string rategroupcode, string adcategory, string currency, string adsubcategory, string package, string packagedesc, string uom, string sizefrom, string sizeto, string consumption, string color, string colorchrty, string weekdrate, string weeminrate, string extweerate, string focusdarate, string focminrate, string focexrate, string validfromdate, string validtill, string remarks, string premium, string premiumval, string rateuniqueid, string weekendrate, string weekendmin, string weekendextra, string minadarea, string editionfrom, string editionto, string flramount, string flrdiscount, string scheme, string adscat4, string adscat5, string adscat6, string frominsert, string toinsert, string agtype, string clientcat)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("modifyratecode", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("rateuniqueid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["rateuniqueid"].Value = rateuniqueid;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("ratecode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["ratecode"].Value = ratecode;

                objmysqlcommand.Parameters.Add("adtype", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adtype"].Value = adtype;


                objmysqlcommand.Parameters.Add("rategroupcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["rategroupcode"].Value = rategroupcode;

                objmysqlcommand.Parameters.Add("adcategory", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adcategory"].Value = adcategory;


                objmysqlcommand.Parameters.Add("currency", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["currency"].Value = currency;

                objmysqlcommand.Parameters.Add("adsubcategory", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adsubcategory"].Value = adsubcategory;


                objmysqlcommand.Parameters.Add("package", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["package"].Value = package;

                objmysqlcommand.Parameters.Add("premium", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["premium"].Value = premium;


                objmysqlcommand.Parameters.Add("premiumval", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["premiumval"].Value = premiumval;



                objmysqlcommand.Parameters.Add("packagedesc", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["packagedesc"].Value = packagedesc;

                objmysqlcommand.Parameters.Add("uom", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["uom"].Value = uom;


                objmysqlcommand.Parameters.Add("sizefrom", MySqlDbType.Int32);
                if (sizefrom == "" || sizefrom == null)
                {
                    objmysqlcommand.Parameters["sizefrom"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["sizefrom"].Value = Convert.ToInt32(sizefrom);
                }

                objmysqlcommand.Parameters.Add("sizeto", MySqlDbType.Int32);
                if (sizeto == "" || sizeto == null)
                {
                    objmysqlcommand.Parameters["sizeto"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["sizeto"].Value = Convert.ToInt32(sizeto);
                }


                objmysqlcommand.Parameters.Add("consumption", MySqlDbType.Int32);
                if (consumption == "" || consumption == null)
                {
                    objmysqlcommand.Parameters["consumption"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["consumption"].Value = Convert.ToInt32(consumption);
                }

                objmysqlcommand.Parameters.Add("color", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["color"].Value = color;

                objmysqlcommand.Parameters.Add("remarks", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["remarks"].Value = remarks;


                objmysqlcommand.Parameters.Add("colorchrty", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["colorchrty"].Value = colorchrty;

                objmysqlcommand.Parameters.Add("weekdrate", MySqlDbType.Decimal);
                if (weekdrate == "" || weekdrate == null)
                {
                    objmysqlcommand.Parameters["weekdrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["weekdrate"].Value = Convert.ToDecimal(weekdrate);
                }



                objmysqlcommand.Parameters.Add("weeminrate", MySqlDbType.Decimal);
                if (weeminrate == "" || weeminrate == null)
                {
                    objmysqlcommand.Parameters["weeminrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["weeminrate"].Value = Convert.ToDecimal(weeminrate);
                }


                objmysqlcommand.Parameters.Add("extweerate", MySqlDbType.Decimal);
                if (extweerate == "" || extweerate == null)
                {
                    objmysqlcommand.Parameters["extweerate"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["extweerate"].Value = Convert.ToDecimal(extweerate);
                }

                objmysqlcommand.Parameters.Add("focusdarate", MySqlDbType.Decimal);
                if (focusdarate == "" || focusdarate == null)
                {
                    objmysqlcommand.Parameters["focusdarate"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["focusdarate"].Value = Convert.ToDecimal(focusdarate);
                }


                objmysqlcommand.Parameters.Add("focminrate", MySqlDbType.Decimal);
                if (focminrate == "" || focminrate == null)
                {
                    objmysqlcommand.Parameters["focminrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["focminrate"].Value = Convert.ToDecimal(focminrate);
                }

                objmysqlcommand.Parameters.Add("focexrate", MySqlDbType.Decimal);
                if (focexrate == "" || focexrate == null)
                {
                    objmysqlcommand.Parameters["focexrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["focexrate"].Value = Convert.ToDecimal(focexrate);
                }

                objmysqlcommand.Parameters.Add("validfromdate", MySqlDbType.DateTime);
                if (validfromdate == "" || validfromdate == null)
                {
                    objmysqlcommand.Parameters["validfromdate"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["validfromdate"].Value = validfromdate;
                }

                objmysqlcommand.Parameters.Add("validtill", MySqlDbType.DateTime);
                if (validtill == "" || validtill == null)
                {
                    objmysqlcommand.Parameters["validtill"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["validtill"].Value = validtill;
                }

                objmysqlcommand.Parameters.Add("weekendrate", MySqlDbType.Decimal);
                if (weekendrate == "" || weekendrate == null)
                {
                    objmysqlcommand.Parameters["weekendrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["weekendrate"].Value = Convert.ToDecimal(weekendrate);
                }


                objmysqlcommand.Parameters.Add("weekendmin", MySqlDbType.Decimal);
                if (weekendmin == "" || weekendmin == null)
                {
                    objmysqlcommand.Parameters["weekendmin"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["weekendmin"].Value = Convert.ToDecimal(weekendmin);
                }

                objmysqlcommand.Parameters.Add("weekendextra", MySqlDbType.Decimal);
                if (weekendextra == "" || weekendextra == null)
                {
                    objmysqlcommand.Parameters["weekendextra"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["weekendextra"].Value = Convert.ToDecimal(weekendextra);
                }

                objmysqlcommand.Parameters.Add("minadarea", MySqlDbType.Decimal);
                if (minadarea == "" || minadarea == null)
                {
                    objmysqlcommand.Parameters["minadarea"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["minadarea"].Value = Convert.ToDecimal(minadarea);
                }

                objmysqlcommand.Parameters.Add("editionto", MySqlDbType.Int32);
                if (editionto == "" || editionto == null)
                {
                    objmysqlcommand.Parameters["editionto"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["editionto"].Value = Convert.ToInt32(editionto);
                }

                objmysqlcommand.Parameters.Add("editionfrom", MySqlDbType.Int32);
                if (editionfrom == "" || editionfrom == null)
                {
                    objmysqlcommand.Parameters["editionfrom"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["editionfrom"].Value = Convert.ToInt32(editionfrom);
                }

                objmysqlcommand.Parameters.Add("flramount", MySqlDbType.Decimal);
                if (flramount == "" || flramount == null)
                {
                    objmysqlcommand.Parameters["flramount"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["flramount"].Value = Convert.ToDecimal(flramount);
                }


                objmysqlcommand.Parameters.Add("flrdiscount", MySqlDbType.Decimal);
                if (flrdiscount == "" || flrdiscount == null)
                {
                    objmysqlcommand.Parameters["flrdiscount"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["flrdiscount"].Value = Convert.ToDecimal(flrdiscount);
                }

                objmysqlcommand.Parameters.Add("scheme", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["scheme"].Value = scheme;

                objmysqlcommand.Parameters.Add("adscat6", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adscat6"].Value = adscat6;


                objmysqlcommand.Parameters.Add("adscat5", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adscat5"].Value = adscat5;


                objmysqlcommand.Parameters.Add("adscat4", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adscat4"].Value = adscat4;

                objmysqlcommand.Parameters.Add("frominsert", MySqlDbType.Int32);
                if (frominsert == "" || frominsert == null)
                {
                    objmysqlcommand.Parameters["frominsert"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["frominsert"].Value = Convert.ToInt32(frominsert);
                }

                objmysqlcommand.Parameters.Add("toinsert", MySqlDbType.Int32);
                if (toinsert == "" || toinsert == null)
                {
                    objmysqlcommand.Parameters["toinsert"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["toinsert"].Value = Convert.ToInt32(toinsert);
                }


                objmysqlcommand.Parameters.Add("agtype", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agtype"].Value = agtype;

                objmysqlcommand.Parameters.Add("clientcat", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["clientcat"].Value = clientcat;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }
        }

        public DataSet description(string packagecode, string compcode, string txtratecode, string drpadtype, string drpadcategory, string drpsubcategory, string drpcolor, string drpcurrency, string validfromdate1, string validtill1, string uom, string adscat4, string adscat5, string adscat6, string premium, string sizefrom, string sizeto, string frominsert, string toinsert, string decimalvalue, string clientcat, string minadarea)
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("binddescription", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("packagecode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["packagecode"].Value = packagecode;

                objmysqlcommand.Parameters.Add("txtratecode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["txtratecode"].Value = txtratecode;

                objmysqlcommand.Parameters.Add("drpadtype", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["drpadtype"].Value = drpadtype;

                objmysqlcommand.Parameters.Add("drpadcategory", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["drpadcategory"].Value = drpadcategory;

                objmysqlcommand.Parameters.Add("drpsubcategory", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["drpsubcategory"].Value = drpsubcategory;

                objmysqlcommand.Parameters.Add("drpcolor", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["drpcolor"].Value = drpcolor;

                objmysqlcommand.Parameters.Add("drpcurrency", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["drpcurrency"].Value = drpcurrency;


                objmysqlcommand.Parameters.Add("validfromdate1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["validfromdate1"].Value = validfromdate1;

                objmysqlcommand.Parameters.Add("validtill1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["validtill1"].Value = validtill1;

                objmysqlcommand.Parameters.Add("uom", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["uom"].Value = uom;

                objmysqlcommand.Parameters.Add("adscat6", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adscat6"].Value = adscat6;

                objmysqlcommand.Parameters.Add("adscat5", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adscat5"].Value = adscat5;

                objmysqlcommand.Parameters.Add("adscat4", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adscat4"].Value = adscat4;

                objmysqlcommand.Parameters.Add("premium", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["premium"].Value = premium;


                objmysqlcommand.Parameters.Add("sizefrom", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["sizefrom"].Value = sizefrom;

                objmysqlcommand.Parameters.Add("sizeto", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["sizeto"].Value = sizeto;

                objmysqlcommand.Parameters.Add("frominsert", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["frominsert"].Value = frominsert;

                objmysqlcommand.Parameters.Add("toinsert", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["toinsert"].Value = toinsert;

                objmysqlcommand.Parameters.Add("decimalvalue", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["decimalvalue"].Value = decimalvalue;

                objmysqlcommand.Parameters.Add("clientcat", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["clientcat"].Value = clientcat;


                objmysqlcommand.Parameters.Add("minadarea", MySqlDbType.VarChar);
                if (minadarea == "")
                {
                    objmysqlcommand.Parameters["minadarea"].Value = "0";
                }
                else
                {
                    objmysqlcommand.Parameters["minadarea"].Value = minadarea;
                }


                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }

        }

        public DataSet descriptionforchange(string packagecode, string compcode)
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("binddescriptionforchange", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("packagecode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["packagecode"].Value = packagecode;









                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }

        }


        public DataSet getdescription(string packagecode, string compcode)
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("binddescription12", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("packagecode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["packagecode"].Value = packagecode;







                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }

        }


       public DataSet deleterate(string ratecode, string compcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("deleterate", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;


                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("ratecode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["ratecode"].Value = ratecode;


                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }
        }

        public DataSet chkcolor(string colorcode, string compcode, string value, string packagecode, string txtratecode, string drpadtype, string drpadcategory, string drpsubcategory, string drpcolor, string drpcurrency, string validfromdate1, string validtill1, string bwcode, string uom, string adscat4, string adscat5, string adscat6, string premium, string sizefrom, string sizeto, string frominsert, string toinsert, string clientcat, string minadarea)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("chkopenorreff", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("colorcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["colorcode"].Value = colorcode;

                objmysqlcommand.Parameters.Add("value", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["value"].Value = value;

                objmysqlcommand.Parameters.Add("packagecode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["packagecode"].Value = packagecode;

                objmysqlcommand.Parameters.Add("txtratecode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["txtratecode"].Value = txtratecode;

                objmysqlcommand.Parameters.Add("drpadtype", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["drpadtype"].Value = drpadtype;

                objmysqlcommand.Parameters.Add("drpadcategory", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["drpadcategory"].Value = drpadcategory;

                objmysqlcommand.Parameters.Add("drpsubcategory", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["drpsubcategory"].Value = drpsubcategory;

                objmysqlcommand.Parameters.Add("drpcolor", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["drpcolor"].Value = drpcolor;

                objmysqlcommand.Parameters.Add("drpcurrency", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["drpcurrency"].Value = drpcurrency;


                objmysqlcommand.Parameters.Add("validfromdate1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["validfromdate1"].Value = validfromdate1;

                objmysqlcommand.Parameters.Add("validtill1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["validtill1"].Value = validtill1;

                objmysqlcommand.Parameters.Add("bwcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["bwcode"].Value = bwcode;

                objmysqlcommand.Parameters.Add("uom", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["uom"].Value = uom;

                objmysqlcommand.Parameters.Add("adscat6", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adscat6"].Value = adscat6;

                objmysqlcommand.Parameters.Add("adscat5", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adscat5"].Value = adscat5;

                objmysqlcommand.Parameters.Add("adscat4", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adscat4"].Value = adscat4;

                objmysqlcommand.Parameters.Add("premium", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["premium"].Value = premium;

                objmysqlcommand.Parameters.Add("sizefrom", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["sizefrom"].Value = sizefrom;

                objmysqlcommand.Parameters.Add("sizeto", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["sizeto"].Value = sizeto;

                objmysqlcommand.Parameters.Add("frominsert", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["frominsert"].Value = frominsert;

                objmysqlcommand.Parameters.Add("toinsert", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["toinsert"].Value = toinsert;


                objmysqlcommand.Parameters.Add("clientcat", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["clientcat"].Value = clientcat;



                objmysqlcommand.Parameters.Add("minadarea", MySqlDbType.VarChar);
                if (minadarea == "")
                {
                    objmysqlcommand.Parameters["minadarea"].Value = "0";
                }
                else
                {
                    objmysqlcommand.Parameters["minadarea"].Value = minadarea;
                }

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }
        }
        /////
        public DataSet getpremiumbaserate(string colorcode, string compcode, string value, string packagecode, string txtratecode, string drpadtype, string drpadcategory, string drpsubcategory, string drpcolor, string drpcurrency, string validfromdate1, string validtill1, string bwcode, string uom, string adscat4, string adscat5, string adscat6, string premium, string sizefrom, string sizeto, string frominsert, string toinsert, string clientcat, string minadarea)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("getpremiumbaserate", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("colorcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["colorcode"].Value = colorcode;

                objmysqlcommand.Parameters.Add("value", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["value"].Value = value;

                objmysqlcommand.Parameters.Add("packagecode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["packagecode"].Value = packagecode;

                objmysqlcommand.Parameters.Add("txtratecode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["txtratecode"].Value = txtratecode;

                objmysqlcommand.Parameters.Add("drpadtype", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["drpadtype"].Value = drpadtype;

                objmysqlcommand.Parameters.Add("drpadcategory", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["drpadcategory"].Value = drpadcategory;

                objmysqlcommand.Parameters.Add("drpsubcategory", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["drpsubcategory"].Value = drpsubcategory;

                objmysqlcommand.Parameters.Add("drpcolor", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["drpcolor"].Value = drpcolor;

                objmysqlcommand.Parameters.Add("drpcurrency", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["drpcurrency"].Value = drpcurrency;


                objmysqlcommand.Parameters.Add("validfromdate1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["validfromdate1"].Value = validfromdate1;

                objmysqlcommand.Parameters.Add("validtill1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["validtill1"].Value = validtill1;

                objmysqlcommand.Parameters.Add("bwcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["bwcode"].Value = bwcode;

                objmysqlcommand.Parameters.Add("uom", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["uom"].Value = uom;

                objmysqlcommand.Parameters.Add("adscat6", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adscat6"].Value = adscat6;

                objmysqlcommand.Parameters.Add("adscat5", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adscat5"].Value = adscat5;

                objmysqlcommand.Parameters.Add("adscat4", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adscat4"].Value = adscat4;

                objmysqlcommand.Parameters.Add("premium", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["premium"].Value = premium;

                objmysqlcommand.Parameters.Add("sizefrom", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["sizefrom"].Value = sizefrom;

                objmysqlcommand.Parameters.Add("sizeto", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["sizeto"].Value = sizeto;

                objmysqlcommand.Parameters.Add("frominsert", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["frominsert"].Value = frominsert;

                objmysqlcommand.Parameters.Add("toinsert", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["toinsert"].Value = toinsert;


                objmysqlcommand.Parameters.Add("clientcat", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["clientcat"].Value = clientcat;



                objmysqlcommand.Parameters.Add("minadarea", MySqlDbType.VarChar);
                if (minadarea == "")
                {
                    objmysqlcommand.Parameters["minadarea"].Value = "0";
                }
                else
                {
                    objmysqlcommand.Parameters["minadarea"].Value = minadarea;
                }

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }
        }


        public DataSet checkpackage(string packagecode, string compcode, string value, string txtratecode, string drpadtype, string drpadcategory, string drpsubcategory, string drpcolor, string drpcurrency, string validfromdate1, string validtill1, string uom, string adscat4, string adscat5, string adscat6, string premium, string sizefrom, string sizeto, string frominsert, string toinsert, string clientcat, string minadarea)
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("chkpackagecode", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("packagecode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["packagecode"].Value = packagecode;

                objmysqlcommand.Parameters.Add("value", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["value"].Value = value;

                objmysqlcommand.Parameters.Add("txtratecode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["txtratecode"].Value = txtratecode;

                objmysqlcommand.Parameters.Add("drpadtype", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["drpadtype"].Value = drpadtype;

                objmysqlcommand.Parameters.Add("drpadcategory", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["drpadcategory"].Value = drpadcategory;

                objmysqlcommand.Parameters.Add("drpsubcategory", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["drpsubcategory"].Value = drpsubcategory;

                objmysqlcommand.Parameters.Add("drpcolor", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["drpcolor"].Value = drpcolor;

                objmysqlcommand.Parameters.Add("drpcurrency", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["drpcurrency"].Value = drpcurrency;


                objmysqlcommand.Parameters.Add("validfromdate1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["validfromdate1"].Value = validfromdate1;

                objmysqlcommand.Parameters.Add("validtill1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["validtill1"].Value = validtill1;

                objmysqlcommand.Parameters.Add("uom", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["uom"].Value = uom;

                objmysqlcommand.Parameters.Add("adscat6", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adscat6"].Value = adscat6;

                objmysqlcommand.Parameters.Add("adscat5", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adscat5"].Value = adscat5;

                objmysqlcommand.Parameters.Add("adscat4", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adscat4"].Value = adscat4;

                objmysqlcommand.Parameters.Add("premium", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["premium"].Value = premium;

                objmysqlcommand.Parameters.Add("sizefrom", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["sizefrom"].Value = sizefrom;

                objmysqlcommand.Parameters.Add("sizeto", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["sizeto"].Value = sizeto;

                objmysqlcommand.Parameters.Add("frominsert", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["frominsert"].Value = frominsert;


                objmysqlcommand.Parameters.Add("toinsert", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["toinsert"].Value = toinsert;

                objmysqlcommand.Parameters.Add("clientcat", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["clientcat"].Value = clientcat;


                objmysqlcommand.Parameters.Add("minadarea", MySqlDbType.VarChar);
                if (minadarea == "")
                {
                    objmysqlcommand.Parameters["minadarea"].Value = "0";
                }
                else
                {
                    objmysqlcommand.Parameters["minadarea"].Value = minadarea;
                }
                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }

        }

        // not used anywhere

        public DataSet editionforrate(string packagecode, string compcode, string txtratecode, string drpadtype, string drpadcategory, string drpsubcategory, string drpcolor, string drpcurrency, string validfromdate1, string validtill1)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("chkeditionforrate", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("packagecode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["packagecode"].Value = packagecode;

                objmysqlcommand.Parameters.Add("txtratecode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["txtratecode"].Value = txtratecode;

                objmysqlcommand.Parameters.Add("drpadtype", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["drpadtype"].Value = drpadtype;

                objmysqlcommand.Parameters.Add("drpadcategory", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["drpadcategory"].Value = drpadcategory;

                objmysqlcommand.Parameters.Add("drpsubcategory", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["drpsubcategory"].Value = drpsubcategory;

                objmysqlcommand.Parameters.Add("drpcolor", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["drpcolor"].Value = drpcolor;

                objmysqlcommand.Parameters.Add("drpcurrency", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["drpcurrency"].Value = drpcurrency;


                objmysqlcommand.Parameters.Add("validfromdate1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["validfromdate1"].Value = validfromdate1;

                objmysqlcommand.Parameters.Add("validtill1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["validtill1"].Value = validtill1;













                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }

        }

        public DataSet chkratecode(string compcode, string ratecode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("chkratedetail", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("ratecode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["ratecode"].Value = ratecode;


                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }
        }

        public DataSet chkratecodemast(string compcode, string ratecode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("chkratedetailmast", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("ratecode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["ratecode"].Value = ratecode;


                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }
        }

        public DataSet ratedetailsinsert(string rate, string focusrate, string ratecode, string compcode, string userid, string edition, string uniquerate, string weekrate, string solofocusrate, string weekendrate, string soloweekrate)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("insertratedetail", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("uniquerate", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["uniquerate"].Value = uniquerate;


                objmysqlcommand.Parameters.Add("ratecode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["ratecode"].Value = ratecode;

                objmysqlcommand.Parameters.Add("edition", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["edition"].Value = edition;




                objmysqlcommand.Parameters.Add("rate", MySqlDbType.Decimal);
                if (rate.Trim() == "" || rate.Trim() == null)
                {
                    objmysqlcommand.Parameters["rate"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["rate"].Value = Convert.ToDecimal(rate);
                }





                objmysqlcommand.Parameters.Add("weekrate", MySqlDbType.Decimal);
                if (weekrate.Trim() == "" || weekrate == null)
                {
                    objmysqlcommand.Parameters["weekrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["weekrate"].Value = Convert.ToDecimal(weekrate);
                }

                objmysqlcommand.Parameters.Add("solofocusrate", MySqlDbType.Decimal);
                if (solofocusrate.Trim() == "" || solofocusrate.Trim() == null)
                {
                    objmysqlcommand.Parameters["solofocusrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["solofocusrate"].Value = Convert.ToDecimal(solofocusrate);
                }





                objmysqlcommand.Parameters.Add("focusrate", MySqlDbType.Decimal);
                if (focusrate.Trim() == "" || focusrate == null)
                {
                    objmysqlcommand.Parameters["focusrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["focusrate"].Value = Convert.ToDecimal(focusrate);
                }

                objmysqlcommand.Parameters.Add("weekendrate", MySqlDbType.Decimal);
                if (weekendrate.Trim() == "" || weekendrate == null)
                {
                    objmysqlcommand.Parameters["weekendrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["weekendrate"].Value = Convert.ToDecimal(weekendrate);
                }

                objmysqlcommand.Parameters.Add("soloweekrate", MySqlDbType.Decimal);
                if (soloweekrate.Trim() == "" || soloweekrate == null)
                {
                    objmysqlcommand.Parameters["soloweekrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["soloweekrate"].Value = Convert.ToDecimal(soloweekrate);
                }






                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }
        }

        public DataSet rateget(string packagecode, string compcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("binddescription12", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("packagecode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["packagecode"].Value = packagecode;







                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }

        }

        public DataSet ratedetailsupdate(string rate, string focusrate, string ratecode, string compcode, string userid, string edition, string rateuniqueid, string weekendrate)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("updateratedetail", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("rateuniqueid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["rateuniqueid"].Value = rateuniqueid;


                objmysqlcommand.Parameters.Add("ratecode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["ratecode"].Value = ratecode;

                objmysqlcommand.Parameters.Add("edition", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["edition"].Value = edition;




                objmysqlcommand.Parameters.Add("rate", MySqlDbType.Decimal);
                if (rate.Trim() == "" || rate.Trim() == null)
                {
                    objmysqlcommand.Parameters["rate"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["rate"].Value = Convert.ToDecimal(rate);
                }





                objmysqlcommand.Parameters.Add("focusrate", MySqlDbType.Decimal);
                if (focusrate.Trim() == "" || focusrate == null)
                {
                    objmysqlcommand.Parameters["focusrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["focusrate"].Value = Convert.ToDecimal(focusrate);
                }

                objmysqlcommand.Parameters.Add("weekendrate", MySqlDbType.Decimal);
                if (weekendrate.Trim() == "" || weekendrate == null)
                {
                    objmysqlcommand.Parameters["weekendrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["weekendrate"].Value = Convert.ToDecimal(weekendrate);
                }









                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }
        }


        public DataSet soloratedetailsupdate(string rate, string focusrate, string ratecode, string compcode, string userid, string edition, string rateuniqueid, string weekendrate)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("updatesoloratedetail", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("rateuniqueid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["rateuniqueid"].Value = rateuniqueid;


                objmysqlcommand.Parameters.Add("ratecode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["ratecode"].Value = ratecode;

                objmysqlcommand.Parameters.Add("edition", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["edition"].Value = edition;




                objmysqlcommand.Parameters.Add("rate", MySqlDbType.Decimal);
                if (rate.Trim() == "" || rate.Trim() == null)
                {
                    objmysqlcommand.Parameters["rate"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["rate"].Value = Convert.ToDecimal(rate);
                }





                objmysqlcommand.Parameters.Add("focusrate", MySqlDbType.Decimal);
                if (focusrate.Trim() == "" || focusrate == null)
                {
                    objmysqlcommand.Parameters["focusrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["focusrate"].Value = Convert.ToDecimal(focusrate);
                }

                objmysqlcommand.Parameters.Add("weekendrate", MySqlDbType.Decimal);
                if (weekendrate.Trim() == "" || weekendrate == null)
                {
                    objmysqlcommand.Parameters["weekendrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["weekendrate"].Value = Convert.ToDecimal(weekendrate);
                }









                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }
        }

        public DataSet bindgridfromdetail(string ratecode, string compcode)
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("bindratedetails", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("ratecode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["ratecode"].Value = ratecode;







                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }

        }

        public DataSet modifygrid(string compcode, string packagecode, string weekrate, string focusrate, string txtratecode, string drpadtype, string drpadcategory, string drpsubcategory, string drpcolor, string drpcurrency, string validfromdate1, string validtill1, string weekendrate, string decimalvalue, string uom, string adscat4, string adscat5, string adscat6, string premium, string sizefrom, string sizeto, string frominsert, string toinsert, string clientcat, string minadarea)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("ratemodifygrid", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("packagecode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["packagecode"].Value = packagecode;


                objmysqlcommand.Parameters.Add("txtratecode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["txtratecode"].Value = txtratecode;

                objmysqlcommand.Parameters.Add("drpadtype", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["drpadtype"].Value = drpadtype;

                objmysqlcommand.Parameters.Add("drpadcategory", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["drpadcategory"].Value = drpadcategory;

                objmysqlcommand.Parameters.Add("drpsubcategory", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["drpsubcategory"].Value = drpsubcategory;

                objmysqlcommand.Parameters.Add("drpcolor", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["drpcolor"].Value = drpcolor;

                objmysqlcommand.Parameters.Add("drpcurrency", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["drpcurrency"].Value = drpcurrency;


                objmysqlcommand.Parameters.Add("validfromdate1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["validfromdate1"].Value = validfromdate1;

                objmysqlcommand.Parameters.Add("validtill1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["validtill1"].Value = validtill1;



                objmysqlcommand.Parameters.Add("weekrate", MySqlDbType.Decimal);
                if (weekrate == "" || weekrate == null)
                {
                    objmysqlcommand.Parameters["weekrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["weekrate"].Value = Convert.ToDecimal(weekrate);
                }

                objmysqlcommand.Parameters.Add("focusrate", MySqlDbType.Decimal);
                if (focusrate == "" || focusrate == null)
                {
                    objmysqlcommand.Parameters["focusrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["focusrate"].Value = Convert.ToDecimal(focusrate);
                }

                objmysqlcommand.Parameters.Add("weekendrate", MySqlDbType.Decimal);
                if (weekendrate == "" || weekendrate == null)
                {
                    objmysqlcommand.Parameters["weekendrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["weekendrate"].Value = Convert.ToDecimal(weekendrate);
                }

                objmysqlcommand.Parameters.Add("decimalvalue", MySqlDbType.Int32);
                if (decimalvalue == "" || decimalvalue == null)
                {
                    objmysqlcommand.Parameters["decimalvalue"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["decimalvalue"].Value = Convert.ToInt32(decimalvalue);
                }


                objmysqlcommand.Parameters.Add("uom", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["uom"].Value = uom;

                objmysqlcommand.Parameters.Add("adscat6", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adscat6"].Value = adscat6;

                objmysqlcommand.Parameters.Add("adscat5", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adscat5"].Value = adscat5;

                objmysqlcommand.Parameters.Add("adscat4", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adscat4"].Value = adscat4;

                objmysqlcommand.Parameters.Add("premium", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["premium"].Value = premium;

                objmysqlcommand.Parameters.Add("sizefrom", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["sizefrom"].Value = sizefrom;


                objmysqlcommand.Parameters.Add("sizeto", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["sizeto"].Value = sizeto;

                objmysqlcommand.Parameters.Add("frominsert", MySqlDbType.VarChar);

                objmysqlcommand.Parameters["frominsert"].Value = frominsert;


                objmysqlcommand.Parameters.Add("toinsert", MySqlDbType.VarChar);

                objmysqlcommand.Parameters["toinsert"].Value = toinsert;


                objmysqlcommand.Parameters.Add("clientcat", MySqlDbType.VarChar);

                objmysqlcommand.Parameters["clientcat"].Value = clientcat;



                objmysqlcommand.Parameters.Add("minadarea", MySqlDbType.VarChar);
                if (minadarea == "")
                {
                    objmysqlcommand.Parameters["minadarea"].Value = "0";
                }
                else
                {
                    objmysqlcommand.Parameters["minadarea"].Value = minadarea;
                }



                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }
        }

        public DataSet sizecheck(string sizefrom, string sizeto, string adtype, string adcategory, string adsubcategory, string compcode, string uom)
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("checksizeforrate", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("uom", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["uom"].Value = uom;

                objmysqlcommand.Parameters.Add("sizefrom", MySqlDbType.VarChar);

                objmysqlcommand.Parameters["sizefrom"].Value = sizefrom;


                objmysqlcommand.Parameters.Add("sizeto", MySqlDbType.VarChar);

                objmysqlcommand.Parameters["sizeto"].Value = sizeto;


                objmysqlcommand.Parameters.Add("adtype", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adtype"].Value = adtype;

                objmysqlcommand.Parameters.Add("adcategory", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adcategory"].Value = adcategory;

                objmysqlcommand.Parameters.Add("adsubcategory", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adsubcategory"].Value = adsubcategory;










                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }

        }

        public DataSet showgrid(string compcode, string packagecode, string txtratecode, string drpadtype, string drpadcategory, string drpsubcategory, string drpcolor, string drpcurrency, string validfromdate1, string validtill1, string uom, string adscat4, string adscat5, string adscat6, string premium, string sizefrom, string sizeto, string frominsert, string toinsert, string clientcat, string minadarea)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("bindgridforexe", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("packagecode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["packagecode"].Value = packagecode;


                objmysqlcommand.Parameters.Add("txtratecode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["txtratecode"].Value = txtratecode;

                objmysqlcommand.Parameters.Add("drpadtype", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["drpadtype"].Value = drpadtype;

                objmysqlcommand.Parameters.Add("drpadcategory", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["drpadcategory"].Value = drpadcategory;

                objmysqlcommand.Parameters.Add("drpsubcategory", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["drpsubcategory"].Value = drpsubcategory;

                objmysqlcommand.Parameters.Add("drpcolor", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["drpcolor"].Value = drpcolor;

                objmysqlcommand.Parameters.Add("drpcurrency", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["drpcurrency"].Value = drpcurrency;


                objmysqlcommand.Parameters.Add("validfromdate1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["validfromdate1"].Value = validfromdate1;

                objmysqlcommand.Parameters.Add("validtill1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["validtill1"].Value = validtill1;

                objmysqlcommand.Parameters.Add("uom", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["uom"].Value = uom;

                objmysqlcommand.Parameters.Add("adscat6", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adscat6"].Value = adscat6;

                objmysqlcommand.Parameters.Add("adscat5", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adscat5"].Value = adscat5;

                objmysqlcommand.Parameters.Add("adscat4", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adscat4"].Value = adscat4;

                objmysqlcommand.Parameters.Add("premium", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["premium"].Value = premium;

                objmysqlcommand.Parameters.Add("sizefrom", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["sizefrom"].Value = sizefrom;

                objmysqlcommand.Parameters.Add("sizeto", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["sizeto"].Value = sizeto;

                objmysqlcommand.Parameters.Add("frominsert", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["frominsert"].Value = frominsert;


                objmysqlcommand.Parameters.Add("toinsert", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["toinsert"].Value = toinsert;


                objmysqlcommand.Parameters.Add("clientcat", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["clientcat"].Value = clientcat;

                objmysqlcommand.Parameters.Add("minadarea", MySqlDbType.VarChar);
                if (minadarea == "")
                {
                    objmysqlcommand.Parameters["minadarea"].Value = "0";
                }
                else
                {
                    objmysqlcommand.Parameters["minadarea"].Value = minadarea;
                }

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }
        }



        public DataSet updatesizechk(string sizefrom, string sizeto, string adtype, string adcategory, string adsubcategory, string compcode, string ratecode, string uom, string adscat4, string adscat5, string adscat6)
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("updatechecksizeforrate", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("uom", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["uom"].Value = uom;

                objmysqlcommand.Parameters.Add("sizefrom", MySqlDbType.VarChar);

                objmysqlcommand.Parameters["sizefrom"].Value = sizefrom;


                objmysqlcommand.Parameters.Add("sizeto", MySqlDbType.VarChar);

                objmysqlcommand.Parameters["sizeto"].Value = sizeto;

                objmysqlcommand.Parameters.Add("adtype", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adtype"].Value = adtype;

                objmysqlcommand.Parameters.Add("adcategory", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adcategory"].Value = adcategory;

                objmysqlcommand.Parameters.Add("adsubcategory", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adsubcategory"].Value = adsubcategory;

                objmysqlcommand.Parameters.Add("ratecode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["ratecode"].Value = ratecode;



                objmysqlcommand.Parameters.Add("adscat6", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adscat6"].Value = adscat6;

                objmysqlcommand.Parameters.Add("adscat5", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adscat5"].Value = adscat5;

                objmysqlcommand.Parameters.Add("adscat4", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adscat4"].Value = adscat4;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }

        }

        // not used anywhere

        public DataSet modsolpack(string compcode, string ratecode, string adtype, string adcategory, string adsubcategory, string color, string package, string currency, string fromdate, string todate)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("checksolopackage", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("ratecode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["ratecode"].Value = ratecode;

                objmysqlcommand.Parameters.Add("fromdate", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["fromdate"].Value = fromdate;

                objmysqlcommand.Parameters.Add("todate", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["todate"].Value = todate;

                objmysqlcommand.Parameters.Add("adtype", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adtype"].Value = adtype;

                objmysqlcommand.Parameters.Add("adcategory", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adcategory"].Value = adcategory;


                objmysqlcommand.Parameters.Add("adsubcategory", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adsubcategory"].Value = adsubcategory;

                objmysqlcommand.Parameters.Add("color", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["color"].Value = color;

                objmysqlcommand.Parameters.Add("package", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["package"].Value = package;

                objmysqlcommand.Parameters.Add("currency", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["currency"].Value = currency;



                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }
        }

        public DataSet soloratemodify(string compcode, string ratecode, string adtype, string adcategory, string adsubcategory, string color, string package, string currency, string fromdate, string todate, string rateuniqueid, string pkgdesc, string weekrate, string focusrate, string weekendrate, string uom, string adscat4, string adscat5, string adscat6, string premium, string sizefrom, string sizeto, string frominsert, string toinsert, string clientcat, string minadarea)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("soloratemodify", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("ratecode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["ratecode"].Value = ratecode;

                objmysqlcommand.Parameters.Add("fromdate", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["fromdate"].Value = fromdate;

                objmysqlcommand.Parameters.Add("todate", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["todate"].Value = todate;

                objmysqlcommand.Parameters.Add("adtype", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adtype"].Value = adtype;

                objmysqlcommand.Parameters.Add("adcategory", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adcategory"].Value = adcategory;


                objmysqlcommand.Parameters.Add("adsubcategory", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adsubcategory"].Value = adsubcategory;

                objmysqlcommand.Parameters.Add("color", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["color"].Value = color;

                objmysqlcommand.Parameters.Add("package", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["package"].Value = package;

                objmysqlcommand.Parameters.Add("currency", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["currency"].Value = currency;

                objmysqlcommand.Parameters.Add("rateuniqueid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["rateuniqueid"].Value = rateuniqueid;

                objmysqlcommand.Parameters.Add("pkgdesc", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pkgdesc"].Value = pkgdesc;

                objmysqlcommand.Parameters.Add("weekrate", MySqlDbType.Decimal);
                if (weekrate == "" || weekrate == null)
                {
                    objmysqlcommand.Parameters["weekrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["weekrate"].Value = Convert.ToDecimal(weekrate);
                }

                objmysqlcommand.Parameters.Add("focusrate", MySqlDbType.Decimal);
                if (focusrate == "" || focusrate == null)
                {
                    objmysqlcommand.Parameters["focusrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["focusrate"].Value = Convert.ToDecimal(focusrate);
                }

                objmysqlcommand.Parameters.Add("weekendrate", MySqlDbType.Decimal);
                if (weekendrate == "" || weekendrate == null)
                {
                    objmysqlcommand.Parameters["weekendrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["weekendrate"].Value = Convert.ToDecimal(weekendrate);
                }


                objmysqlcommand.Parameters.Add("uom", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["uom"].Value = uom;

                objmysqlcommand.Parameters.Add("adscat6", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adscat6"].Value = adscat6;

                objmysqlcommand.Parameters.Add("adscat5", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adscat5"].Value = adscat5;

                objmysqlcommand.Parameters.Add("adscat4", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adscat4"].Value = adscat4;

                objmysqlcommand.Parameters.Add("premium", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["premium"].Value = premium;


                objmysqlcommand.Parameters.Add("sizefrom", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["sizefrom"].Value = sizefrom;


                objmysqlcommand.Parameters.Add("sizeto", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["sizeto"].Value = sizeto;

                objmysqlcommand.Parameters.Add("frominsert", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["frominsert"].Value = frominsert;

                objmysqlcommand.Parameters.Add("toinsert", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["toinsert"].Value = toinsert;

                objmysqlcommand.Parameters.Add("clientcat", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["clientcat"].Value = clientcat;


                objmysqlcommand.Parameters.Add("minadarea", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["minadarea"].Value = minadarea;


                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }
        }

        public DataSet editionmodify(string compcode, string ratecode, string adtype, string adcategory, string adsubcategory, string color, string package, string currency, string fromdate, string todate, string rateuniqueid, string pkgdesc, string weekrate, string focusrate, string weekendrate, string uom)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("editionmodifyrate", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("ratecode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["ratecode"].Value = ratecode;

                objmysqlcommand.Parameters.Add("fromdate", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["fromdate"].Value = fromdate;

                objmysqlcommand.Parameters.Add("todate", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["todate"].Value = todate;

                objmysqlcommand.Parameters.Add("adtype", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adtype"].Value = adtype;

                objmysqlcommand.Parameters.Add("adcategory", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adcategory"].Value = adcategory;


                objmysqlcommand.Parameters.Add("adsubcategory", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adsubcategory"].Value = adsubcategory;

                objmysqlcommand.Parameters.Add("color", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["color"].Value = color;

                objmysqlcommand.Parameters.Add("package", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["package"].Value = package;

                objmysqlcommand.Parameters.Add("currency", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["currency"].Value = currency;

                objmysqlcommand.Parameters.Add("rateuniqueid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["rateuniqueid"].Value = rateuniqueid;

                objmysqlcommand.Parameters.Add("pkgdesc", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pkgdesc"].Value = pkgdesc;

                objmysqlcommand.Parameters.Add("weekrate", MySqlDbType.Decimal);
                if (weekrate == "" || weekrate == null)
                {
                    objmysqlcommand.Parameters["weekrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["weekrate"].Value = Convert.ToDecimal(weekrate);
                }

                objmysqlcommand.Parameters.Add("focusrate", MySqlDbType.Decimal);
                if (focusrate == "" || focusrate == null)
                {
                    objmysqlcommand.Parameters["focusrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["focusrate"].Value = Convert.ToDecimal(focusrate);
                }

                objmysqlcommand.Parameters.Add("weekendrate", MySqlDbType.Decimal);
                if (weekendrate == "" || weekendrate == null)
                {
                    objmysqlcommand.Parameters["weekendrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["weekendrate"].Value = Convert.ToDecimal(weekendrate);
                }

                objmysqlcommand.Parameters.Add("uom", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["uom"].Value = uom;


                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }
        }





        public DataSet modifycirculation(string compcode, string userid, string ratecode, string adtype, string rategroupcode, string adcategory, string currency, string adsubcategory, string package, string packagedesc, string uom, string sizefrom, string sizeto, string consumption, string color, string colorchrty, string weekdrate, string weeminrate, string extweerate, string focusdarate, string focminrate, string focexrate, string validfromdate, string validtill, string remarks, string premium, string premiumval, string rateuniqueid, string weekendrate, string weekendmin, string weekendextra, string combination, string insertsolo, string flag, string minadarea, string editionfrom, string editionto, string flramount, string flrdiscount, string scheme, string adscat4, string adscat5, string adscat6, string frominsert, string toinsert, string agetype, string clientcat)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                string datefrom = validfromdate;
                string dateto = validtill;
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("modifycirculation", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("rateuniqueid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["rateuniqueid"].Value = rateuniqueid;


                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("datefrom", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["datefrom"].Value = datefrom;


                objmysqlcommand.Parameters.Add("dateto", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["dateto"].Value = dateto;


                objmysqlcommand.Parameters.Add("ratecode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["ratecode"].Value = ratecode;

                objmysqlcommand.Parameters.Add("adtype", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adtype"].Value = adtype;


                objmysqlcommand.Parameters.Add("rategroupcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["rategroupcode"].Value = rategroupcode;

                objmysqlcommand.Parameters.Add("adcategory", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adcategory"].Value = adcategory;


                objmysqlcommand.Parameters.Add("currency", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["currency"].Value = currency;

                objmysqlcommand.Parameters.Add("adsubcategory", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adsubcategory"].Value = adsubcategory;


                objmysqlcommand.Parameters.Add("package", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["package"].Value = package;

                objmysqlcommand.Parameters.Add("premium", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["premium"].Value = premium;


                objmysqlcommand.Parameters.Add("premiumval", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["premiumval"].Value = premiumval;



                objmysqlcommand.Parameters.Add("packagedesc", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["packagedesc"].Value = packagedesc;

                objmysqlcommand.Parameters.Add("uom", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["uom"].Value = uom;


                objmysqlcommand.Parameters.Add("sizefrom", MySqlDbType.Int32);
                if (sizefrom == "" || sizefrom == null)
                {
                    objmysqlcommand.Parameters["sizefrom"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["sizefrom"].Value = sizefrom;
                }

                objmysqlcommand.Parameters.Add("sizeto", MySqlDbType.Int32);
                if (sizeto == "" || sizeto == null)
                {
                    objmysqlcommand.Parameters["sizeto"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["sizeto"].Value = sizeto;
                }


                objmysqlcommand.Parameters.Add("consumption", MySqlDbType.Int32);
                if (consumption == "" || consumption == null)
                {
                    objmysqlcommand.Parameters["consumption"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["consumption"].Value = consumption;
                }

                objmysqlcommand.Parameters.Add("color", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["color"].Value = color;

                objmysqlcommand.Parameters.Add("remarks", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["remarks"].Value = remarks;


                objmysqlcommand.Parameters.Add("colorchrty", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["colorchrty"].Value = colorchrty;

                objmysqlcommand.Parameters.Add("weekdrate", MySqlDbType.Decimal);
                if (weekdrate == "" || weekdrate == null)
                {
                    objmysqlcommand.Parameters["weekdrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["weekdrate"].Value = Convert.ToDecimal(weekdrate);
                }



                objmysqlcommand.Parameters.Add("weeminrate", MySqlDbType.Decimal);
                if (weeminrate == "" || weeminrate == null)
                {
                    objmysqlcommand.Parameters["weeminrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["weeminrate"].Value = Convert.ToDecimal(weeminrate);
                }


                objmysqlcommand.Parameters.Add("extweerate", MySqlDbType.Decimal);
                if (extweerate == "" || extweerate == null)
                {
                    objmysqlcommand.Parameters["extweerate"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["extweerate"].Value = Convert.ToDecimal(extweerate);
                }

                objmysqlcommand.Parameters.Add("focusdarate", MySqlDbType.Decimal);
                if (focusdarate == "" || focusdarate == null)
                {
                    objmysqlcommand.Parameters["focusdarate"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["focusdarate"].Value = Convert.ToDecimal(focusdarate);
                }


                objmysqlcommand.Parameters.Add("focminrate", MySqlDbType.Decimal);
                if (focminrate == "" || focminrate == null)
                {
                    objmysqlcommand.Parameters["focminrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["focminrate"].Value = Convert.ToDecimal(focminrate);
                }

                objmysqlcommand.Parameters.Add("focexrate", MySqlDbType.Decimal);
                if (focexrate == "" || focexrate == null)
                {
                    objmysqlcommand.Parameters["focexrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["focexrate"].Value = Convert.ToDecimal(focexrate);
                }

                objmysqlcommand.Parameters.Add("validfromdate", MySqlDbType.DateTime);
                if (validfromdate == "" || validfromdate == null)
                {
                    objmysqlcommand.Parameters["validfromdate"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["validfromdate"].Value = validfromdate;
                }

                objmysqlcommand.Parameters.Add("validtill", MySqlDbType.DateTime);
                if (validtill == "" || validtill == null)
                {
                    objmysqlcommand.Parameters["validtill"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["validtill"].Value = validtill;
                }


                //Convert.ToDateTime();
                objmysqlcommand.Parameters.Add("weekendrate", MySqlDbType.Decimal);
                if (weekendrate == "" || weekendrate == null)
                {
                    objmysqlcommand.Parameters["weekendrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["weekendrate"].Value = Convert.ToDecimal(weekendrate);
                }


                objmysqlcommand.Parameters.Add("weekendmin", MySqlDbType.Decimal);
                if (weekendmin == "" || weekendmin == null)
                {
                    objmysqlcommand.Parameters["weekendmin"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["weekendmin"].Value = Convert.ToDecimal(weekendmin);
                }

                objmysqlcommand.Parameters.Add("weekendextra", MySqlDbType.Decimal);
                if (weekendextra == "" || weekendextra == null)
                {
                    objmysqlcommand.Parameters["weekendextra"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["weekendextra"].Value = Convert.ToDecimal(weekendextra);
                }


                objmysqlcommand.Parameters.Add("combination", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["combination"].Value = combination;

                objmysqlcommand.Parameters.Add("insertsolo", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["insertsolo"].Value = insertsolo;

                objmysqlcommand.Parameters.Add("flag", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["flag"].Value = flag;

                objmysqlcommand.Parameters.Add("minadarea", MySqlDbType.Decimal);
                if (minadarea == "" || minadarea == null)
                {
                    objmysqlcommand.Parameters["minadarea"].Value = Convert.ToDecimal("0");
                }
                else
                {
                    objmysqlcommand.Parameters["minadarea"].Value = Convert.ToDecimal(minadarea);
                }


                objmysqlcommand.Parameters.Add("editionfrom", MySqlDbType.Int32);
                if (editionfrom == "" || editionfrom == null)
                {
                    objmysqlcommand.Parameters["editionfrom"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["editionfrom"].Value = Convert.ToInt32(editionfrom);
                }



                objmysqlcommand.Parameters.Add("editionto", MySqlDbType.Int32);
                if (editionto == "" || editionto == null)
                {
                    objmysqlcommand.Parameters["editionto"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["editionto"].Value = Convert.ToInt32(editionto);
                }

                objmysqlcommand.Parameters.Add("flramount", MySqlDbType.Decimal);
                if (flramount == "" || flramount == null)
                {
                    objmysqlcommand.Parameters["flramount"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["flramount"].Value = Convert.ToDecimal(flramount);
                }

                objmysqlcommand.Parameters.Add("flrdiscount", MySqlDbType.Decimal);
                if (flrdiscount == "" || flrdiscount == null)
                {
                    objmysqlcommand.Parameters["flrdiscount"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["flrdiscount"].Value = Convert.ToDecimal(flrdiscount);
                }

                objmysqlcommand.Parameters.Add("scheme", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["scheme"].Value = scheme;

                objmysqlcommand.Parameters.Add("adscat6", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adscat6"].Value = adscat6;


                objmysqlcommand.Parameters.Add("adscat5", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adscat5"].Value = adscat5;


                objmysqlcommand.Parameters.Add("adscat4", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adscat4"].Value = adscat4;

                objmysqlcommand.Parameters.Add("frominsert", MySqlDbType.Int32);
                if (frominsert == "" || frominsert == null)
                {
                    objmysqlcommand.Parameters["frominsert"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["frominsert"].Value = frominsert;
                }

                objmysqlcommand.Parameters.Add("toinsert", MySqlDbType.Int32);
                if (toinsert == "" || toinsert == null)
                {
                    objmysqlcommand.Parameters["toinsert"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["toinsert"].Value = toinsert;
                }

                objmysqlcommand.Parameters.Add("agetype", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agetype"].Value = agetype;


                objmysqlcommand.Parameters.Add("clientcat", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["clientcat"].Value = clientcat;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }
        }

        public DataSet uombind(string compcode, string userid, string value)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("BINDUOMFORRATE", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("COMPCODE", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["COMPCODE"].Value = compcode;

                objmysqlcommand.Parameters.Add("USERID", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["USERID"].Value = userid;

                objmysqlcommand.Parameters.Add("VALUE", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["VALUE"].Value = value;



                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }
        }

        public DataSet descriptioncirculation(string compcode, string packagecode, string weekrate, string focusrate, string txtratecode, string drpadtype, string drpadcategory, string drpsubcategory, string drpcolor, string drpcurrency, string validfromdate1, string validtill1, string weekendrate, string decimalvalue, string uom, string adscat4, string adscat5, string adscat6, string premium, string sizefrom, string sizeto, string frominsert, string toinsert, string decimalvalue11, string clientcat, string minadarea)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("binddescriptionforcirculation", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("packagecode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["packagecode"].Value = packagecode;


                objmysqlcommand.Parameters.Add("txtratecode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["txtratecode"].Value = txtratecode;

                objmysqlcommand.Parameters.Add("drpadtype", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["drpadtype"].Value = drpadtype;

                objmysqlcommand.Parameters.Add("drpadcategory", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["drpadcategory"].Value = drpadcategory;

                objmysqlcommand.Parameters.Add("drpsubcategory", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["drpsubcategory"].Value = drpsubcategory;

                objmysqlcommand.Parameters.Add("drpcolor", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["drpcolor"].Value = drpcolor;

                objmysqlcommand.Parameters.Add("drpcurrency", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["drpcurrency"].Value = drpcurrency;


                objmysqlcommand.Parameters.Add("validfromdate1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["validfromdate1"].Value = validfromdate1;

                objmysqlcommand.Parameters.Add("validtill1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["validtill1"].Value = validtill1;



                objmysqlcommand.Parameters.Add("weekrate", MySqlDbType.Decimal);
                if (weekrate == "" || weekrate == null)
                {
                    objmysqlcommand.Parameters["weekrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["weekrate"].Value = Convert.ToDecimal(weekrate);
                }

                objmysqlcommand.Parameters.Add("focusrate", MySqlDbType.Decimal);
                if (focusrate == "" || focusrate == null)
                {
                    objmysqlcommand.Parameters["focusrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["focusrate"].Value = Convert.ToDecimal(focusrate);
                }

                objmysqlcommand.Parameters.Add("weekendrate", MySqlDbType.Decimal);
                if (weekendrate == "" || weekendrate == null)
                {
                    objmysqlcommand.Parameters["weekendrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["weekendrate"].Value = Convert.ToDecimal(weekendrate);
                }

                objmysqlcommand.Parameters.Add("decimalvalue", MySqlDbType.Int32);
                if (decimalvalue == "" || decimalvalue == null)
                {
                    objmysqlcommand.Parameters["decimalvalue"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["decimalvalue"].Value = Convert.ToInt32(decimalvalue);
                }


                objmysqlcommand.Parameters.Add("uom", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["uom"].Value = uom;

                objmysqlcommand.Parameters.Add("adscat6", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adscat6"].Value = adscat6;

                objmysqlcommand.Parameters.Add("adscat5", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adscat5"].Value = adscat5;

                objmysqlcommand.Parameters.Add("adscat4", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adscat4"].Value = adscat4;

                objmysqlcommand.Parameters.Add("premium", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["premium"].Value = premium;

                objmysqlcommand.Parameters.Add("sizefrom", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["sizefrom"].Value = sizefrom;

                objmysqlcommand.Parameters.Add("sizeto", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["sizeto"].Value = sizeto;


                objmysqlcommand.Parameters.Add("frominsert", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["frominsert"].Value = frominsert;


                objmysqlcommand.Parameters.Add("toinsert", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["toinsert"].Value = toinsert;

                objmysqlcommand.Parameters.Add("decimalvalue11", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["decimalvalue11"].Value = decimalvalue11;


                objmysqlcommand.Parameters.Add("clientcat", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["clientcat"].Value = clientcat;


                objmysqlcommand.Parameters.Add("minadarea", MySqlDbType.VarChar);
                if (minadarea == "")
                {
                    objmysqlcommand.Parameters["minadarea"].Value = "0";
                }
                else
                {
                    objmysqlcommand.Parameters["minadarea"].Value = minadarea;
                }
                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }
        }

        public DataSet bindscategory4(string compcode, string adscat4, string value)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("Rate_bindadcat4", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("adscat4", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adscat4"].Value = adscat4;

                objmysqlcommand.Parameters.Add("value", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["value"].Value = value;



                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }
        }

        public DataSet bindclientcat(string compcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("Rate_bindclientcat_Rate_bindclientcat_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;





                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }
        }

        public DataSet bindpckforadtype(string typecode, string compcode, string adcat, string adscat)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {

                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("rate_bindpkg", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("typecode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["typecode"].Value = typecode;

                objmysqlcommand.Parameters.Add("adcat", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adcat"].Value = adcat;

                objmysqlcommand.Parameters.Add("adscat", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adscat"].Value = adscat;




                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }


        }
        public DataSet getuom_desc(string compcode, string value)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("getuomdesc", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;



                objmysqlcommand.Parameters.Add("uom", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["uom"].Value = value;



                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }
        }

        public DataSet bindrateforgrid(string packagecode, string compcode, string dateformat)
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("rate_bindgrid", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("packagecode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["packagecode"].Value = packagecode;

                objmysqlcommand.Parameters.Add("dateformat", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["dateformat"].Value = dateformat;








                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }

        }

        //------------------------ad by rinki -----------------------------------//

        public DataSet EditionBind(string flag, string adtype)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("bindedition", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("flag", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["flag"].Value = flag;

                objmysqlcommand.Parameters.Add("adtype", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adtype"].Value = adtype;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }
        }

        // bind ratecode

        public DataSet bindratecode(string compcode, string ratecode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("binndratecode", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("p_compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["p_compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("p_ratecode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["p_ratecode"].Value = ratecode;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }
        }

     
    }
}