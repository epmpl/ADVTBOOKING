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
/// Summary description for BookingMaster
/// </summary>
    public class BookingMaster : connection
    {
        public BookingMaster()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataSet clsOldMatter(string rcpt_no)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_oldmatter_p", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("rcpt_no", MySqlDbType.VarChar);
                objSqlCommand.Parameters["rcpt_no"].Value = rcpt_no;


                objSqlDataAdapter = new MySqlDataAdapter();
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

        public DataSet fetchqbcdetail(string compcode, string cioid)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("fetchqbcdetail", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("cioid", MySqlDbType.VarChar);
                objSqlCommand.Parameters["cioid"].Value = cioid;

                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;

                objSqlDataAdapter = new MySqlDataAdapter();
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
        public DataSet getstatuspaymodeAgency(string agency, string compcode)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getstatuspaymodeAgency", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("agencycode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["agencycode"].Value = agency;

                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;

                objSqlDataAdapter = new MySqlDataAdapter();
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
        public DataSet getPremPage(string premcode, string id)
        {
            string zonename = "";
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getPremium_PageNo", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("premcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["premcode"].Value = premcode;

                objSqlCommand.Parameters.Add("id", MySqlDbType.VarChar);
                objSqlCommand.Parameters["id"].Value = id;

                objSqlDataAdapter = new MySqlDataAdapter();
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
        public DataSet getAdSizeHeightWidth(string adtype, string adcategory, string col, string edi, string compcode, string code, string uom)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                string openreferExtra = ConfigurationSettings.AppSettings["openreferExtra"];
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getAdSizeHeightWidth", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("adtype", MySqlDbType.VarChar);
                objSqlCommand.Parameters["adtype"].Value = adtype;

                objSqlCommand.Parameters.Add("adcategory", MySqlDbType.VarChar);
                objSqlCommand.Parameters["adcategory"].Value = adcategory;

                objSqlCommand.Parameters.Add("col", MySqlDbType.VarChar);
                objSqlCommand.Parameters["col"].Value = col;

                objSqlCommand.Parameters.Add("code", MySqlDbType.VarChar);
                objSqlCommand.Parameters["code"].Value = code;

                objSqlCommand.Parameters.Add("edi", MySqlDbType.VarChar);
                objSqlCommand.Parameters["edi"].Value = edi;

                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;


                objSqlCommand.Parameters.Add("uomcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["uomcode"].Value = uom;

                objSqlDataAdapter = new MySqlDataAdapter();
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
        public DataSet getBarter(string compcode, string center, string branch, string agency, string client)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getBarter", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlDataAdapter = new MySqlDataAdapter();
                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("center", MySqlDbType.VarChar);
                objSqlCommand.Parameters["center"].Value = center;
                objSqlCommand.Parameters.Add("branch", MySqlDbType.VarChar);
                objSqlCommand.Parameters["branch"].Value = branch;
                objSqlCommand.Parameters.Add("agency", MySqlDbType.VarChar);
                objSqlCommand.Parameters["agency"].Value = agency;
                objSqlCommand.Parameters.Add("client", MySqlDbType.VarChar);
                objSqlCommand.Parameters["client"].Value = client;

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
        public DataSet getOurBank(string compcode)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getOurBank", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlDataAdapter = new MySqlDataAdapter();
                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;

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
        public DataSet get_rate_qbc(string noofinsertion, string dateformat, string compcode, string uom, string adtype, string currency, string ratecode, string clientcode, string uomdesc, string agencycode, string newcode, string center, string ratepremtype, string premium, string schemetype, string fdate, string ldate)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("RATE_QBC", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                string openreferExtra = ConfigurationSettings.AppSettings["openreferExtra"];
                objSqlCommand.Parameters.Add("noofinsertion", MySqlDbType.VarChar);
                objSqlCommand.Parameters["noofinsertion"].Value = noofinsertion;

                objSqlCommand.Parameters.Add("dateformat", MySqlDbType.VarChar);
                objSqlCommand.Parameters["dateformat"].Value = dateformat;

                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("uom", MySqlDbType.VarChar);
                objSqlCommand.Parameters["uom"].Value = uom;

                objSqlCommand.Parameters.Add("Adtype", MySqlDbType.VarChar);
                objSqlCommand.Parameters["Adtype"].Value = adtype;

                objSqlCommand.Parameters.Add("currency", MySqlDbType.VarChar);
                objSqlCommand.Parameters["currency"].Value = "0";

                objSqlCommand.Parameters.Add("RATECODE", MySqlDbType.VarChar);
                objSqlCommand.Parameters["RATECODE"].Value = "LOCAL";

                objSqlCommand.Parameters.Add("clientcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["clientcode"].Value = clientcode;

                objSqlCommand.Parameters.Add("uomdesc", MySqlDbType.VarChar);
                objSqlCommand.Parameters["uomdesc"].Value = uomdesc;

                objSqlCommand.Parameters.Add("openreferExtra", MySqlDbType.VarChar);
                objSqlCommand.Parameters["openreferExtra"].Value = openreferExtra;

                objSqlCommand.Parameters.Add("agencycode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["agencycode"].Value = agencycode;

                objSqlCommand.Parameters.Add("newcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["newcode"].Value = newcode;

                objSqlCommand.Parameters.Add("center", MySqlDbType.VarChar);
                objSqlCommand.Parameters["center"].Value = "0";

                objSqlCommand.Parameters.Add("ratepremtype", MySqlDbType.VarChar);
                objSqlCommand.Parameters["ratepremtype"].Value = ratepremtype;

                objSqlCommand.Parameters.Add("premiumval", MySqlDbType.VarChar);
                objSqlCommand.Parameters["premiumval"].Value = premium;

                objSqlCommand.Parameters.Add("schemetype", MySqlDbType.VarChar);
                objSqlCommand.Parameters["schemetype"].Value = schemetype;

                objSqlCommand.Parameters.Add("fDate", MySqlDbType.Datetime);
                objSqlCommand.Parameters["fDate"].Value = System.DBNull.Value;

                objSqlCommand.Parameters.Add("lDate", MySqlDbType.Datetime);
                objSqlCommand.Parameters["lDate"].Value = System.DBNull.Value;

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
        public DataSet clsShow_NoAd()
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_tempdata_websp_tempdata_p", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

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
        public DataSet getStatus()
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_getStatus", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

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

        public DataSet get_paystatus(string receiptno)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("GETPAYSTATUS", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("receiptno", MySqlDbType.VarChar);
                objSqlCommand.Parameters["receiptno"].Value = receiptno;
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


        public DataSet getBillStatus()
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_getBillStatus", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

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
        public DataSet getExecZoneName(string execcode, string compcode)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();

            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_getExecZoneName", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("exexcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["exexcode"].Value = execcode;
                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;

                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                //if (objDataSet.Tables[0].Rows.Count > 0)
                //{
                //    zonename = objDataSet.Tables[0].Rows[0].ItemArray[0].ToString();
                //}
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
        public DataSet getClientName(string compcode, string client)//, string center)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();

            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_getclientName", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;
                objSqlCommand.Parameters.Add("client1", MySqlDbType.VarChar);
                objSqlCommand.Parameters["client1"].Value = client;

                //objSqlCommand.Parameters.Add("pubcenter", MySqlDbType.VarChar);
                //objSqlCommand.Parameters["pubcenter"].Value = center;

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
        public DataSet getClientNa(string compcode, string client)
        {
            string zonename = "";


            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Add_bindParentclient", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;
                objSqlCommand.Parameters.Add("@client", SqlDbType.VarChar);
                objSqlCommand.Parameters["@client"].Value = client;
                objSqlDataAdapter = new MySqlDataAdapter();
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
        public DataSet bindBrand(string compcode, string procat)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();

            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_getBrand", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;
                objSqlCommand.Parameters.Add("procat", MySqlDbType.VarChar);
                objSqlCommand.Parameters["procat"].Value = procat;

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
        public DataSet getInsertion(string package, string noofinsertion, string insertiondate, string startdate, string dateformat, string compcode, string adcategory, string adsubcat, string color, string adtype, string currency, string ratecode, string clickdate, string flag, string code, string pck, string uom, string dealrate, string checkforor, string premium, string clientname)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();

            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("bindBookingInsertion", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("package", MySqlDbType.VarChar);
                objSqlCommand.Parameters["package"].Value = package;

                objSqlCommand.Parameters.Add("noofinsertion", MySqlDbType.VarChar);
                objSqlCommand.Parameters["noofinsertion"].Value = noofinsertion;

                objSqlCommand.Parameters.Add("insertiondate", MySqlDbType.VarChar);
                objSqlCommand.Parameters["insertiondate"].Value = insertiondate;

                objSqlCommand.Parameters.Add("startdate", MySqlDbType.VarChar);
                objSqlCommand.Parameters["startdate"].Value = startdate;

                objSqlCommand.Parameters.Add("dateformat", MySqlDbType.VarChar);
                objSqlCommand.Parameters["dateformat"].Value = dateformat;

                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("adcategory", MySqlDbType.VarChar);
                objSqlCommand.Parameters["adcategory"].Value = adcategory;

                objSqlCommand.Parameters.Add("adsubcat", MySqlDbType.VarChar);
                objSqlCommand.Parameters["adsubcat"].Value = adsubcat;

                objSqlCommand.Parameters.Add("color", MySqlDbType.VarChar);
                objSqlCommand.Parameters["color"].Value = color;

                objSqlCommand.Parameters.Add("adtype", MySqlDbType.VarChar);
                objSqlCommand.Parameters["adtype"].Value = adtype;

                objSqlCommand.Parameters.Add("currency", MySqlDbType.VarChar);
                objSqlCommand.Parameters["currency"].Value = currency;

                objSqlCommand.Parameters.Add("ratecode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["ratecode"].Value = ratecode;

                objSqlCommand.Parameters.Add("clickdate", MySqlDbType.VarChar);
                objSqlCommand.Parameters["clickdate"].Value = clickdate;

                objSqlCommand.Parameters.Add("flag", MySqlDbType.Int64);
                if (flag == "" || flag == null)
                {
                    objSqlCommand.Parameters["flag"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["flag"].Value = Convert.ToInt32(flag);
                }

                objSqlCommand.Parameters.Add("code", MySqlDbType.VarChar);
                objSqlCommand.Parameters["code"].Value = code;

                objSqlCommand.Parameters.Add("pck", MySqlDbType.Decimal);
                if (pck == "" || pck == null)
                {
                    objSqlCommand.Parameters["pck"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["pck"].Value = Convert.ToDecimal(pck);
                }

                objSqlCommand.Parameters.Add("uom", MySqlDbType.VarChar);
                objSqlCommand.Parameters["uom"].Value = uom;

                objSqlCommand.Parameters.Add("dealrate", MySqlDbType.Decimal);
                if (dealrate == "" || dealrate == null)
                {
                    objSqlCommand.Parameters["dealrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["dealrate"].Value = Convert.ToDecimal(dealrate);
                }

                objSqlCommand.Parameters.Add("checkforor", MySqlDbType.VarChar);
                objSqlCommand.Parameters["checkforor"].Value = checkforor;

                objSqlCommand.Parameters.Add("premium", MySqlDbType.VarChar);
                objSqlCommand.Parameters["premium"].Value = premium;


                objSqlCommand.Parameters.Add("clientname", MySqlDbType.VarChar);
                objSqlCommand.Parameters["clientname"].Value = clientname;


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
        public DataSet bindProduct(string compcode, string product, string value)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();

            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_getProduct", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;
                objSqlCommand.Parameters.Add("product", MySqlDbType.VarChar);
                objSqlCommand.Parameters["product"].Value = product;
                objSqlCommand.Parameters.Add("value1", MySqlDbType.VarChar);
                objSqlCommand.Parameters["value1"].Value = value;

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
        public DataSet bindPagePosition(string compcode)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_getPagePosition", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;

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
        public DataSet bindAdSizeType(string compcode)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_getadsize", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;

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
        public DataSet getCustomer(string compcode)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_getCustomerName", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;

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
        public DataSet getExec(string compcode, string execname, string value, string center)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_getExec", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("execname", MySqlDbType.VarChar);
                objSqlCommand.Parameters["execname"].Value = execname;

                objSqlCommand.Parameters.Add("value1", MySqlDbType.VarChar);
                objSqlCommand.Parameters["value1"].Value = value;

                objSqlCommand.Parameters.Add("center", MySqlDbType.VarChar);
                objSqlCommand.Parameters["center"].Value = center;

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

        public DataSet autogenrated(string compcode, string auto, string no)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getautocodebooking", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("auto", MySqlDbType.VarChar);
                objSqlCommand.Parameters["auto"].Value = auto;

                objSqlCommand.Parameters.Add("no1", MySqlDbType.VarChar);
                objSqlCommand.Parameters["no1"].Value = no;



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

        public DataSet bookidchk(string compcode, string ciobookid, string agency, string agencycode, string rono, string saveormod, string keyno)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("chkciobookid", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("ciobookid", MySqlDbType.VarChar);
                objSqlCommand.Parameters["ciobookid"].Value = ciobookid;

                objSqlCommand.Parameters.Add("agency", MySqlDbType.VarChar);
                objSqlCommand.Parameters["agency"].Value = agency;

                objSqlCommand.Parameters.Add("agencycode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["agencycode"].Value = agencycode;

                objSqlCommand.Parameters.Add("rono", MySqlDbType.VarChar);
                objSqlCommand.Parameters["rono"].Value = rono;

                objSqlCommand.Parameters.Add("saveormod", MySqlDbType.VarChar);
                objSqlCommand.Parameters["saveormod"].Value = saveormod;



                objSqlCommand.Parameters.Add("keyno", MySqlDbType.VarChar);
                objSqlCommand.Parameters["keyno"].Value = keyno;


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
        //string dateformat, string retainer, string addagencyrate, string mobileno, string addlamt, string retamt, string retper, string cashrecieved
        public DataSet insertbooking(string adsizetype, string branch, string booked_by, string prevbook, string date_time, string ciobookid, string approvedby, string audit, string rono, string rodate, string caption, string billstatus, string rostatus, string agency, string client, string agencyaddress, string clientaddresses, string agencycode, string dockitno, string execname, string execzone, string product, string brand, string keyno, string billremark, string printremark, string package, string insertion, string startdate, string repeatdate, string adtype, string adcategory, string subcategory, string color, string uom, string pageposition, string pagetype, string pageno, string adsizheight, string adsizwidth, string ratecode, string scheme, string currency, string agreedrate, string agreedamt, string spedisc, string spacedisx, string compcode, string userid, string specialcharges, string agencytype, string agencystatus, string paymode, string agencredit, string cardrate, string cardamount, string discount, string discountper, string billaddress, string totarea, string billcycle, string revenuecenter, string billpay, string billheight, string billwidth, string billto, string invoices, string vts, string tradedisc, string agencyout, string boxcode, string boxno, string boxaddress, string boxagency, string boxclient, string bookingtype, string tfn, string coupan, string campaign, string bill_amt, string pageprem, string pageamt, string premper, string grossamt, string adsizcolumn, string billcolumn, Decimal billarea, string specdiscper, string spacediscper, string paidins, string dealrate, string deviation, string varient, string contractname, string dealtype, string cardname, string cardtype, string cardmonth, string cardyear, string cardno, string receiptno, string adscat3, string adscat4, string adscat5, string bgcolor, string bulletcode, string bulletprm, string material, string receiptdate, string prevcioid, string prevreceipt, Decimal prev_ga, string region, string varient_name, string coltype, string logo_h, string logo_w, string logo_col, string logo_uom, string dateformat, string retainer, string addagencyrate, string mobileno, string addlamt, string retamt, string retper, string cashrecieved)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {

                objSqlConnection.Open();
                objSqlCommand = GetCommand("insertintobooking", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("date_time", MySqlDbType.Datetime);
                if (date_time == "" || date_time == null)
                {
                    objSqlCommand.Parameters["date_time"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "mm/dd/yyyy" && date_time != "")
                    {
                        string[] arr = null;
                        arr = date_time.Split("/".ToCharArray());
                        date_time = arr[2] + "/" + arr[0] + "/" + arr[1];

                    }
                    if (dateformat == "dd/mm/yyyy" && date_time != "")
                    {
                        string[] arr = null;
                        arr = date_time.Split("/".ToCharArray());
                        date_time = arr[1] + "/" + arr[0] + "/" + arr[2];

                    }
                    if (dateformat == "yyyy/mm/dd" && date_time != "")
                    {
                        string[] arr = null;
                        arr = date_time.Split("/".ToCharArray());
                        date_time = arr[1] + "/" + arr[2] + "/" + arr[0];

                    }
                    objSqlCommand.Parameters["date_time"].Value = Convert.ToDateTime(date_time).ToString("yyyy-MM-dd");

                }

                objSqlCommand.Parameters.Add("adsizetype", MySqlDbType.VarChar);
                objSqlCommand.Parameters["adsizetype"].Value = adsizetype;

                objSqlCommand.Parameters.Add("branch", MySqlDbType.VarChar);
                objSqlCommand.Parameters["branch"].Value = branch;

                objSqlCommand.Parameters.Add("booked_by", MySqlDbType.VarChar);
                objSqlCommand.Parameters["booked_by"].Value = booked_by;

                objSqlCommand.Parameters.Add("prevbook", MySqlDbType.VarChar);
                objSqlCommand.Parameters["prevbook"].Value = prevbook;

                objSqlCommand.Parameters.Add("approvedby", MySqlDbType.VarChar);
                objSqlCommand.Parameters["approvedby"].Value = approvedby;

                objSqlCommand.Parameters.Add("ciobookid", MySqlDbType.VarChar);
                objSqlCommand.Parameters["ciobookid"].Value = ciobookid;

                objSqlCommand.Parameters.Add("audit", MySqlDbType.VarChar);
                objSqlCommand.Parameters["audit"].Value = audit;

                objSqlCommand.Parameters.Add("rono", MySqlDbType.VarChar);
                objSqlCommand.Parameters["rono"].Value = rono;

                objSqlCommand.Parameters.Add("rodate", MySqlDbType.Datetime);
                if (rodate == "" || rodate == null)
                {
                    objSqlCommand.Parameters["rodate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "mm/dd/yyyy" && rodate != "")
                    {
                        string[] arr = null;
                        arr = rodate.Split("/".ToCharArray());
                        rodate = arr[2] + "/" + arr[0] + "/" + arr[1];

                    }
                    if (dateformat == "dd/mm/yyyy" && rodate != "")
                    {
                        string[] arr = null;
                        arr = rodate.Split("/".ToCharArray());
                        rodate = arr[1] + "/" + arr[0] + "/" + arr[2];

                    }
                    if (dateformat == "yyyy/mm/dd" && rodate != "")
                    {
                        string[] arr = null;
                        arr = rodate.Split("/".ToCharArray());
                        rodate = arr[1] + "/" + arr[2] + "/" + arr[0];

                    }
                    objSqlCommand.Parameters["rodate"].Value = Convert.ToDateTime(rodate).ToString("yyyy-MM-dd");

                }

                objSqlCommand.Parameters.Add("caption", MySqlDbType.VarChar);
                objSqlCommand.Parameters["caption"].Value = caption;

                objSqlCommand.Parameters.Add("billstatus", MySqlDbType.VarChar);
                objSqlCommand.Parameters["billstatus"].Value = billstatus;

                objSqlCommand.Parameters.Add("rostatus", MySqlDbType.VarChar);
                objSqlCommand.Parameters["rostatus"].Value = rostatus;

                objSqlCommand.Parameters.Add("agency", MySqlDbType.VarChar);
                objSqlCommand.Parameters["agency"].Value = agency;

                objSqlCommand.Parameters.Add("client", MySqlDbType.VarChar);
                objSqlCommand.Parameters["client"].Value = client;

                objSqlCommand.Parameters.Add("agencyaddress", MySqlDbType.VarChar);
                objSqlCommand.Parameters["agencyaddress"].Value = agencyaddress;

                objSqlCommand.Parameters.Add("clientaddresses", MySqlDbType.VarChar);
                objSqlCommand.Parameters["clientaddresses"].Value = clientaddresses;

                objSqlCommand.Parameters.Add("agencycode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["agencycode"].Value = agencycode;

                objSqlCommand.Parameters.Add("dockitno", MySqlDbType.VarChar);
                objSqlCommand.Parameters["dockitno"].Value = dockitno;

                objSqlCommand.Parameters.Add("execname", MySqlDbType.VarChar);
                objSqlCommand.Parameters["execname"].Value = execname;

                objSqlCommand.Parameters.Add("execzone", MySqlDbType.VarChar);
                objSqlCommand.Parameters["execzone"].Value = execzone;

                objSqlCommand.Parameters.Add("product", MySqlDbType.VarChar);
                objSqlCommand.Parameters["product"].Value = product;

                objSqlCommand.Parameters.Add("brand", MySqlDbType.VarChar);
                objSqlCommand.Parameters["brand"].Value = brand;

                objSqlCommand.Parameters.Add("keyno", MySqlDbType.VarChar);
                objSqlCommand.Parameters["keyno"].Value = keyno;

                objSqlCommand.Parameters.Add("billremark", MySqlDbType.VarChar);
                objSqlCommand.Parameters["billremark"].Value = billremark;

                objSqlCommand.Parameters.Add("printremark", MySqlDbType.VarChar);
                objSqlCommand.Parameters["printremark"].Value = printremark;

                objSqlCommand.Parameters.Add("package", MySqlDbType.VarChar);
                objSqlCommand.Parameters["package"].Value = package;

                objSqlCommand.Parameters.Add("insertion", MySqlDbType.Int64);
                if (insertion == "" || insertion == null)
                {
                    objSqlCommand.Parameters["insertion"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["insertion"].Value = Convert.ToInt32(insertion);
                }

                objSqlCommand.Parameters.Add("startdate", MySqlDbType.Datetime);
                if (startdate == "" || startdate == null)
                {
                    objSqlCommand.Parameters["startdate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "mm/dd/yyyy" && startdate != "")
                    {
                        string[] arr = null;
                        arr = startdate.Split("/".ToCharArray());
                        startdate = arr[2] + "/" + arr[0] + "/" + arr[1];

                    }
                    if (dateformat == "dd/mm/yyyy" && startdate != "")
                    {
                        string[] arr = null;
                        arr = startdate.Split("/".ToCharArray());
                        startdate = arr[1] + "/" + arr[0] + "/" + arr[2];

                    }
                    if (dateformat == "yyyy/mm/dd" && startdate != "")
                    {
                        string[] arr = null;
                        arr = startdate.Split("/".ToCharArray());
                        startdate = arr[1] + "/" + arr[2] + "/" + arr[0];

                    }
                    objSqlCommand.Parameters["startdate"].Value = Convert.ToDateTime(startdate).ToString("yyyy-MM-dd");

                }

                objSqlCommand.Parameters.Add("repeatdate", MySqlDbType.VarChar);
                objSqlCommand.Parameters["repeatdate"].Value = repeatdate;

                objSqlCommand.Parameters.Add("adtype", MySqlDbType.VarChar);
                objSqlCommand.Parameters["adtype"].Value = adtype;

                objSqlCommand.Parameters.Add("adcategory", MySqlDbType.VarChar);
                objSqlCommand.Parameters["adcategory"].Value = adcategory;

                objSqlCommand.Parameters.Add("subcategory", MySqlDbType.VarChar);
                objSqlCommand.Parameters["subcategory"].Value = subcategory;

                objSqlCommand.Parameters.Add("color", MySqlDbType.VarChar);
                objSqlCommand.Parameters["color"].Value = color;

                objSqlCommand.Parameters.Add("uom", MySqlDbType.VarChar);
                objSqlCommand.Parameters["uom"].Value = uom;

                objSqlCommand.Parameters.Add("pageposition", MySqlDbType.VarChar);
                objSqlCommand.Parameters["pageposition"].Value = pageposition;

                objSqlCommand.Parameters.Add("pagetype", MySqlDbType.VarChar);
                objSqlCommand.Parameters["pagetype"].Value = pagetype;

                objSqlCommand.Parameters.Add("pageno", MySqlDbType.Int64);
                if (pageno == "" || pageno == null)
                {
                    objSqlCommand.Parameters["pageno"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["pageno"].Value = Convert.ToInt32(pageno);
                }

                objSqlCommand.Parameters.Add("adsizheight", MySqlDbType.Decimal);
                if (adsizheight == "" || adsizheight == null)
                {
                    objSqlCommand.Parameters["adsizheight"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["adsizheight"].Value = Convert.ToDecimal(adsizheight);
                }

                objSqlCommand.Parameters.Add("adsizwidth", MySqlDbType.Decimal);
                if (adsizwidth == "" || adsizwidth == null)
                {
                    objSqlCommand.Parameters["adsizwidth"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["adsizwidth"].Value = Convert.ToDecimal(adsizwidth);
                }

                objSqlCommand.Parameters.Add("ratecode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["ratecode"].Value = ratecode;

                objSqlCommand.Parameters.Add("scheme", MySqlDbType.VarChar);
                objSqlCommand.Parameters["scheme"].Value = scheme;

                objSqlCommand.Parameters.Add("currency", MySqlDbType.VarChar);
                objSqlCommand.Parameters["currency"].Value = currency;

                objSqlCommand.Parameters.Add("agreedrate", MySqlDbType.Decimal);
                if (agreedrate == "" || agreedrate == null)
                {
                    objSqlCommand.Parameters["agreedrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["agreedrate"].Value = Convert.ToDecimal(agreedrate);
                }
                //    , , ,Session["compcode"].ToString(),Session["userid"].ToString()
                objSqlCommand.Parameters.Add("agreedamt", MySqlDbType.Decimal);
                if (agreedamt == "" || agreedamt == null)
                {
                    objSqlCommand.Parameters["agreedamt"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["agreedamt"].Value = Convert.ToDecimal(agreedamt);
                }

                objSqlCommand.Parameters.Add("spedisc", MySqlDbType.Decimal);
                if (spedisc == "" || spedisc == null)
                {
                    objSqlCommand.Parameters["spedisc"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["spedisc"].Value = Convert.ToDecimal(spedisc);
                }

                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("spacedisx", MySqlDbType.Decimal);
                if (spacedisx == "" || spacedisx == null)
                {
                    objSqlCommand.Parameters["spacedisx"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["spacedisx"].Value = Convert.ToDecimal(spacedisx);
                }

                objSqlCommand.Parameters.Add("specialcharges", MySqlDbType.Decimal);
                if (specialcharges == "" || specialcharges == null)
                {
                    objSqlCommand.Parameters["specialcharges"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["specialcharges"].Value = Convert.ToDecimal(specialcharges);
                }

                objSqlCommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objSqlCommand.Parameters["userid"].Value = userid;

                objSqlCommand.Parameters.Add("agencytype", MySqlDbType.VarChar);
                objSqlCommand.Parameters["agencytype"].Value = agencytype;

                objSqlCommand.Parameters.Add("agencystatus", MySqlDbType.VarChar);
                objSqlCommand.Parameters["agencystatus"].Value = agencystatus;

                objSqlCommand.Parameters.Add("paymode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["paymode"].Value = paymode;

                objSqlCommand.Parameters.Add("agencredit", MySqlDbType.Int64);
                if (agencredit == "" || agencredit == null)
                {
                    objSqlCommand.Parameters["agencredit"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["agencredit"].Value = Convert.ToInt32(agencredit);
                }

                objSqlCommand.Parameters.Add("cardrate", MySqlDbType.Decimal);
                if (cardrate == "" || cardrate == null)
                {
                    objSqlCommand.Parameters["cardrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["cardrate"].Value = Convert.ToDecimal(cardrate);
                }

                objSqlCommand.Parameters.Add("cardamount", MySqlDbType.Decimal);
                if (cardamount == "" || cardamount == null)
                {
                    objSqlCommand.Parameters["cardamount"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["cardamount"].Value = Convert.ToDecimal(cardamount);
                }

                objSqlCommand.Parameters.Add("discount", MySqlDbType.Decimal);
                if (discount == "" || discount == null)
                {
                    objSqlCommand.Parameters["discount"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["discount"].Value = Convert.ToDecimal(discount);
                }


                objSqlCommand.Parameters.Add("discountper", MySqlDbType.Decimal);
                if (discountper == "" || discountper == null)
                {
                    objSqlCommand.Parameters["discountper"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["discountper"].Value = Convert.ToDecimal(discountper);
                }

                objSqlCommand.Parameters.Add("billaddress", MySqlDbType.VarChar);
                objSqlCommand.Parameters["billaddress"].Value = billaddress;

                objSqlCommand.Parameters.Add("totarea", MySqlDbType.Decimal);
                if (totarea == "" || totarea == null)
                {
                    objSqlCommand.Parameters["totarea"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["totarea"].Value = Convert.ToDecimal(totarea);
                }


                objSqlCommand.Parameters.Add("billcycle", MySqlDbType.VarChar);
                objSqlCommand.Parameters["billcycle"].Value = billcycle;

                objSqlCommand.Parameters.Add("revenuecenter", MySqlDbType.VarChar);
                objSqlCommand.Parameters["revenuecenter"].Value = revenuecenter;

                objSqlCommand.Parameters.Add("billpay", MySqlDbType.VarChar);
                objSqlCommand.Parameters["billpay"].Value = billpay;

                objSqlCommand.Parameters.Add("billheight", MySqlDbType.Decimal);
                if (billheight == "" || billheight == null)
                {
                    objSqlCommand.Parameters["billheight"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["billheight"].Value = Convert.ToDecimal(billheight);
                }

                objSqlCommand.Parameters.Add("billwidth", MySqlDbType.Decimal);
                if (billwidth == "" || billwidth == null)
                {
                    objSqlCommand.Parameters["billwidth"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["billwidth"].Value = Convert.ToDecimal(billwidth);
                }

                //////, , , , , , , , , , , , , , , , , , , 

                objSqlCommand.Parameters.Add("billto", MySqlDbType.VarChar);
                objSqlCommand.Parameters["billto"].Value = billto;

                objSqlCommand.Parameters.Add("invoices", MySqlDbType.Int64);
                if (invoices == "" || invoices == null)
                {
                    objSqlCommand.Parameters["invoices"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["invoices"].Value = Convert.ToInt32(invoices);
                }

                objSqlCommand.Parameters.Add("vts", MySqlDbType.Int64);
                if (vts == "" || vts == null)
                {
                    objSqlCommand.Parameters["vts"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["vts"].Value = Convert.ToInt32(vts);
                }

                objSqlCommand.Parameters.Add("tradedisc", MySqlDbType.Decimal);
                if (tradedisc == "" || tradedisc == null)
                {
                    objSqlCommand.Parameters["tradedisc"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["tradedisc"].Value = Convert.ToDecimal(tradedisc);
                }

                objSqlCommand.Parameters.Add("agencyout", MySqlDbType.VarChar);
                objSqlCommand.Parameters["agencyout"].Value = agencyout;

                objSqlCommand.Parameters.Add("boxcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["boxcode"].Value = boxcode;

                objSqlCommand.Parameters.Add("boxno", MySqlDbType.VarChar);
                objSqlCommand.Parameters["boxno"].Value = boxno;

                objSqlCommand.Parameters.Add("boxaddress", MySqlDbType.VarChar);
                objSqlCommand.Parameters["boxaddress"].Value = boxaddress;

                objSqlCommand.Parameters.Add("boxagency", MySqlDbType.VarChar);
                objSqlCommand.Parameters["boxagency"].Value = boxagency;

                objSqlCommand.Parameters.Add("boxclient", MySqlDbType.VarChar);
                objSqlCommand.Parameters["boxclient"].Value = boxclient;

                objSqlCommand.Parameters.Add("bookingtype", MySqlDbType.VarChar);
                objSqlCommand.Parameters["bookingtype"].Value = bookingtype;

                objSqlCommand.Parameters.Add("tfn", MySqlDbType.VarChar);
                objSqlCommand.Parameters["tfn"].Value = tfn;

                objSqlCommand.Parameters.Add("coupan", MySqlDbType.VarChar);
                objSqlCommand.Parameters["coupan"].Value = coupan;

                objSqlCommand.Parameters.Add("campaign", MySqlDbType.VarChar);
                objSqlCommand.Parameters["campaign"].Value = campaign;


                objSqlCommand.Parameters.Add("bill_amt", MySqlDbType.Decimal);
                if (bill_amt == "" || bill_amt == null)
                {
                    objSqlCommand.Parameters["bill_amt"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["bill_amt"].Value = Convert.ToDecimal(bill_amt);
                }

                objSqlCommand.Parameters.Add("pageprem", MySqlDbType.VarChar);
                objSqlCommand.Parameters["pageprem"].Value = pageprem;


                objSqlCommand.Parameters.Add("pageamt", MySqlDbType.Decimal);
                if (pageamt == "" || pageamt == null)
                {
                    objSqlCommand.Parameters["pageamt"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["pageamt"].Value = Convert.ToDecimal(pageamt);
                }

                objSqlCommand.Parameters.Add("premper", MySqlDbType.Decimal);
                if (premper == "" || premper == null)
                {
                    objSqlCommand.Parameters["premper"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["premper"].Value = Convert.ToDecimal(premper);
                }

                objSqlCommand.Parameters.Add("grossamt", MySqlDbType.Decimal);
                if (grossamt == "" || grossamt == null)
                {
                    objSqlCommand.Parameters["grossamt"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["grossamt"].Value = Convert.ToDecimal(grossamt);
                }

                objSqlCommand.Parameters.Add("adsizcolumn", MySqlDbType.Decimal);
                if (adsizcolumn == "" || adsizcolumn == null)
                {
                    objSqlCommand.Parameters["adsizcolumn"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["adsizcolumn"].Value = Convert.ToDecimal(adsizcolumn);
                }

                objSqlCommand.Parameters.Add("billcolumn", MySqlDbType.Decimal);
                if (billcolumn == "" || billcolumn == null)
                {
                    objSqlCommand.Parameters["billcolumn"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["billcolumn"].Value = Convert.ToDecimal(billcolumn);
                }

                objSqlCommand.Parameters.Add("billarea", MySqlDbType.Decimal);

                objSqlCommand.Parameters["billarea"].Value = Convert.ToDecimal(billarea);

                objSqlCommand.Parameters.Add("specdiscper", MySqlDbType.Decimal);
                if (specdiscper == "" || specdiscper == null)
                {
                    objSqlCommand.Parameters["specdiscper"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["specdiscper"].Value = Convert.ToDecimal(specdiscper);
                }

                objSqlCommand.Parameters.Add("spacediscper", MySqlDbType.Decimal);
                if (spacediscper == "" || spacediscper == null)
                {
                    objSqlCommand.Parameters["spacediscper"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["spacediscper"].Value = Convert.ToDecimal(spacediscper);
                }

                objSqlCommand.Parameters.Add("paidins", MySqlDbType.Int64);
                if (paidins == "" || paidins == null)
                {
                    objSqlCommand.Parameters["paidins"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["paidins"].Value = Convert.ToInt32(paidins);
                }

                objSqlCommand.Parameters.Add("dealrate", MySqlDbType.Decimal);
                if (dealrate == "" || dealrate == null)
                {
                    objSqlCommand.Parameters["dealrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["dealrate"].Value = Convert.ToDecimal(dealrate);
                }

                objSqlCommand.Parameters.Add("deviation", MySqlDbType.Decimal);
                if (deviation == "" || deviation == null)
                {
                    objSqlCommand.Parameters["deviation"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["deviation"].Value = Convert.ToDecimal(deviation);
                }

                objSqlCommand.Parameters.Add("varient", MySqlDbType.VarChar);
                objSqlCommand.Parameters["varient"].Value = varient;

                objSqlCommand.Parameters.Add("contractname", MySqlDbType.VarChar);
                objSqlCommand.Parameters["contractname"].Value = contractname;

                objSqlCommand.Parameters.Add("dealtype", MySqlDbType.VarChar);
                objSqlCommand.Parameters["dealtype"].Value = dealtype;


                ////////////////
                objSqlCommand.Parameters.Add("cardname", MySqlDbType.VarChar);
                objSqlCommand.Parameters["cardname"].Value = cardname;

                objSqlCommand.Parameters.Add("cardtype", MySqlDbType.VarChar);
                objSqlCommand.Parameters["cardtype"].Value = cardtype;

                objSqlCommand.Parameters.Add("cardmonth", MySqlDbType.VarChar);
                objSqlCommand.Parameters["cardmonth"].Value = cardmonth;

                objSqlCommand.Parameters.Add("cardyear", MySqlDbType.VarChar);
                objSqlCommand.Parameters["cardyear"].Value = cardyear;

                objSqlCommand.Parameters.Add("cardno", MySqlDbType.VarChar);
                objSqlCommand.Parameters["cardno"].Value = cardno;

                objSqlCommand.Parameters.Add("receiptno", MySqlDbType.VarChar);
                objSqlCommand.Parameters["receiptno"].Value = receiptno;

                objSqlCommand.Parameters.Add("adscat3", MySqlDbType.VarChar);
                objSqlCommand.Parameters["adscat3"].Value = adscat3;

                objSqlCommand.Parameters.Add("adscat4", MySqlDbType.VarChar);
                objSqlCommand.Parameters["adscat4"].Value = adscat4;

                objSqlCommand.Parameters.Add("adscat5", MySqlDbType.VarChar);
                objSqlCommand.Parameters["adscat5"].Value = adscat5;

                objSqlCommand.Parameters.Add("bgcolor", MySqlDbType.VarChar);
                objSqlCommand.Parameters["bgcolor"].Value = bgcolor;

                objSqlCommand.Parameters.Add("bulletcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["bulletcode"].Value = bulletcode;

                objSqlCommand.Parameters.Add("bulletprm", MySqlDbType.Decimal);
                if (bulletprm == "" || bulletprm == null)
                {
                    objSqlCommand.Parameters["bulletprm"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["bulletprm"].Value = Convert.ToDecimal(bulletprm);
                }

                objSqlCommand.Parameters.Add("material", MySqlDbType.VarChar);
                objSqlCommand.Parameters["material"].Value = material;


                objSqlCommand.Parameters.Add("receiptdate", MySqlDbType.Datetime);
                if (receiptdate == "" || receiptdate == null)
                {
                    objSqlCommand.Parameters["receiptdate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["receiptdate"].Value = receiptdate;
                }


                objSqlCommand.Parameters.Add("prevcioid", MySqlDbType.VarChar);
                objSqlCommand.Parameters["prevcioid"].Value = prevcioid;

                objSqlCommand.Parameters.Add("prevreceipt", MySqlDbType.VarChar);
                objSqlCommand.Parameters["prevreceipt"].Value = prevreceipt;

                objSqlCommand.Parameters.Add("prev_ga", MySqlDbType.Decimal);

                objSqlCommand.Parameters["prev_ga"].Value = prev_ga;



                objSqlCommand.Parameters.Add("region", MySqlDbType.VarChar);
                objSqlCommand.Parameters["region"].Value = region;

                objSqlCommand.Parameters.Add("varient_name", MySqlDbType.VarChar);
                objSqlCommand.Parameters["varient_name"].Value = varient_name;
                /*new change ankur 9 feb*/

                objSqlCommand.Parameters.Add("coltype", MySqlDbType.VarChar);
                objSqlCommand.Parameters["coltype"].Value = coltype;

                objSqlCommand.Parameters.Add("logo_h", MySqlDbType.VarChar);
                objSqlCommand.Parameters["logo_h"].Value = logo_h;

                objSqlCommand.Parameters.Add("logo_w", MySqlDbType.VarChar);
                objSqlCommand.Parameters["logo_w"].Value = logo_w;

                objSqlCommand.Parameters.Add("logo_col", MySqlDbType.VarChar);
                objSqlCommand.Parameters["logo_col"].Value = logo_col;

                objSqlCommand.Parameters.Add("logo_uom", MySqlDbType.VarChar);
                objSqlCommand.Parameters["logo_uom"].Value = logo_uom;
                // string dateformat, string retainer, string addagencyrate, string mobileno,  string addlamt, string retamt, string retper, string cashrecieved
                objSqlCommand.Parameters.Add("dateformat", MySqlDbType.VarChar);
                objSqlCommand.Parameters["dateformat"].Value = dateformat;

                objSqlCommand.Parameters.Add("retainer1", MySqlDbType.VarChar);
                if (retainer.IndexOf("(") >= 0)
                {
                    retainer = retainer.Substring(retainer.IndexOf("(") + 1, retainer.Length - retainer.IndexOf("(") - 2);
                }
                objSqlCommand.Parameters["retainer1"].Value = retainer;

                objSqlCommand.Parameters.Add("addagencyrate", MySqlDbType.VarChar);
                objSqlCommand.Parameters["addagencyrate"].Value = addagencyrate;

                objSqlCommand.Parameters.Add("mobileno", MySqlDbType.VarChar);
                objSqlCommand.Parameters["mobileno"].Value = mobileno;


                objSqlCommand.Parameters.Add("addlamt", MySqlDbType.VarChar);
                objSqlCommand.Parameters["addlamt"].Value = addlamt;

                objSqlCommand.Parameters.Add("retamt", MySqlDbType.VarChar);
                objSqlCommand.Parameters["retamt"].Value = retamt;

                objSqlCommand.Parameters.Add("retper", MySqlDbType.VarChar);
                objSqlCommand.Parameters["retper"].Value = retper;

                objSqlCommand.Parameters.Add("cashrecieved", MySqlDbType.VarChar);
                objSqlCommand.Parameters["cashrecieved"].Value = cashrecieved;

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

        public DataSet updatebooking(string adsizetype, string branch, string booked_by, string prevbook, string date_time, string ciobookid, string approvedby, string audit, string rono, string rodate, string caption, string billstatus, string rostatus, string agency, string client, string agencyaddress, string clientaddresses, string agencycode, string dockitno, string execname, string execzone, string product, string brand, string keyno, string billremark, string printremark, string package, string insertion, string startdate, string repeatdate, string adtype, string adcategory, string subcategory, string color, string uom, string pageposition, string pagetype, string pageno, string adsizheight, string adsizwidth, string ratecode, string scheme, string currency, string agreedrate, string agreedamt, string spedisc, string spacedisx, string compcode, string userid, string specialcharges, string agencytype, string agencystatus, string paymode, string agencredit, string cardrate, string cardamount, string discount, string discountper, string billaddress, string totarea, string billcycle, string revenuecenter, string billpay, string billheight, string billwidth, string billto, string invoices, string vts, string tradedisc, string agencyout, string boxcode, string boxno, string boxaddress, string boxagency, string boxclient, string bookingtype, string tfn, string coupan, string campaign, string bill_amt, string pageprem, string pageamt, string premper, string grossamt, string adsizcolumn, string billcolumn, Decimal billarea, string specdiscper, string spacediscper, string paidins, string dealrate, string deviation, string varient, string contractname, string dealtype, string cardname, string cardtype, string cardmonth, string cardyear, string cardno, string receiptno, string adscat3, string adscat4, string adscat5, string bgcolor, string bulletcode, string bulletprm, string material, string region, string varient_name, string coltype, string logo_hei, string logo_wid, string logo_color, string logo_uom, string status, string dateformat, string retainer, string addagencyrate, string mobileno, string addlamt, string retamt, string retper, string cashrecieved)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {

                objSqlConnection.Open();
                objSqlCommand = GetCommand("updatebooking", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("date_time", MySqlDbType.Datetime);
                if (date_time == "" || date_time == null)
                {
                    objSqlCommand.Parameters["date_time"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "mm/dd/yyyy" && date_time != "")
                    {
                        string[] arr = null;
                        arr = date_time.Split("/".ToCharArray());
                        date_time = arr[2] + "/" + arr[0] + "/" + arr[1];

                    }
                    if (dateformat == "dd/mm/yyyy" && date_time != "")
                    {
                        string[] arr = null;
                        arr = date_time.Split("/".ToCharArray());
                        date_time = arr[1] + "/" + arr[0] + "/" + arr[2];

                    }
                    if (dateformat == "yyyy/mm/dd" && date_time != "")
                    {
                        string[] arr = null;
                        arr = date_time.Split("/".ToCharArray());
                        date_time = arr[1] + "/" + arr[2] + "/" + arr[0];

                    }
                    objSqlCommand.Parameters["date_time"].Value = Convert.ToDateTime(date_time).ToString("yyyy-MM-dd");
                }

                objSqlCommand.Parameters.Add("adsizetype", MySqlDbType.VarChar);
                objSqlCommand.Parameters["adsizetype"].Value = adsizetype;

                objSqlCommand.Parameters.Add("branch", MySqlDbType.VarChar);
                objSqlCommand.Parameters["branch"].Value = branch;

                objSqlCommand.Parameters.Add("booked_by", MySqlDbType.VarChar);
                objSqlCommand.Parameters["booked_by"].Value = booked_by;

                objSqlCommand.Parameters.Add("prevbook", MySqlDbType.VarChar);
                objSqlCommand.Parameters["prevbook"].Value = prevbook;

                objSqlCommand.Parameters.Add("approvedby", MySqlDbType.VarChar);
                objSqlCommand.Parameters["approvedby"].Value = approvedby;

                objSqlCommand.Parameters.Add("ciobookid", MySqlDbType.VarChar);
                objSqlCommand.Parameters["ciobookid"].Value = ciobookid;

                objSqlCommand.Parameters.Add("audit", MySqlDbType.VarChar);
                objSqlCommand.Parameters["audit"].Value = audit;

                objSqlCommand.Parameters.Add("rono", MySqlDbType.VarChar);
                objSqlCommand.Parameters["rono"].Value = rono;

                objSqlCommand.Parameters.Add("rodate", MySqlDbType.Datetime);
                if (rodate == "" || rodate == null)
                {
                    rodate = "1900/01/01";
                }
                if (rodate == "" || rodate == null)
                {
                    objSqlCommand.Parameters["rodate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "mm/dd/yyyy" && rodate != "")
                    {
                        string[] arr = null;
                        arr = rodate.Split("/".ToCharArray());
                        rodate = arr[2] + "/" + arr[0] + "/" + arr[1];

                    }
                    if (dateformat == "dd/mm/yyyy" && rodate != "")
                    {
                        string[] arr = null;
                        arr = rodate.Split("/".ToCharArray());
                        rodate = arr[1] + "/" + arr[0] + "/" + arr[2];

                    }
                    if (dateformat == "yyyy/mm/dd" && rodate != "")
                    {
                        string[] arr = null;
                        arr = rodate.Split("/".ToCharArray());
                        rodate = arr[1] + "/" + arr[2] + "/" + arr[0];

                    }
                    objSqlCommand.Parameters["rodate"].Value = Convert.ToDateTime(rodate).ToString("yyyy-MM-dd");
                }

                objSqlCommand.Parameters.Add("caption", MySqlDbType.VarChar);
                objSqlCommand.Parameters["caption"].Value = caption;

                objSqlCommand.Parameters.Add("billstatus", MySqlDbType.VarChar);
                objSqlCommand.Parameters["billstatus"].Value = billstatus;

                objSqlCommand.Parameters.Add("rostatus", MySqlDbType.VarChar);
                objSqlCommand.Parameters["rostatus"].Value = rostatus;

                objSqlCommand.Parameters.Add("agency", MySqlDbType.VarChar);
                objSqlCommand.Parameters["agency"].Value = agency;

                objSqlCommand.Parameters.Add("client1", MySqlDbType.VarChar);
                objSqlCommand.Parameters["client1"].Value = client;

                objSqlCommand.Parameters.Add("agencyaddress", MySqlDbType.VarChar);
                objSqlCommand.Parameters["agencyaddress"].Value = agencyaddress;

                objSqlCommand.Parameters.Add("clientaddresses", MySqlDbType.VarChar);
                objSqlCommand.Parameters["clientaddresses"].Value = clientaddresses;

                objSqlCommand.Parameters.Add("agencycode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["agencycode"].Value = agencycode;

                objSqlCommand.Parameters.Add("dockitno", MySqlDbType.VarChar);
                objSqlCommand.Parameters["dockitno"].Value = dockitno;

                objSqlCommand.Parameters.Add("execname", MySqlDbType.VarChar);
                objSqlCommand.Parameters["execname"].Value = execname;

                objSqlCommand.Parameters.Add("execzone", MySqlDbType.VarChar);
                objSqlCommand.Parameters["execzone"].Value = execzone;

                objSqlCommand.Parameters.Add("product", MySqlDbType.VarChar);
                objSqlCommand.Parameters["product"].Value = product;

                objSqlCommand.Parameters.Add("brand", MySqlDbType.VarChar);
                objSqlCommand.Parameters["brand"].Value = brand;

                objSqlCommand.Parameters.Add("keyno", MySqlDbType.VarChar);
                objSqlCommand.Parameters["keyno"].Value = keyno;

                objSqlCommand.Parameters.Add("billremark", MySqlDbType.VarChar);
                objSqlCommand.Parameters["billremark"].Value = billremark;

                objSqlCommand.Parameters.Add("printremark", MySqlDbType.VarChar);
                objSqlCommand.Parameters["printremark"].Value = printremark;

                objSqlCommand.Parameters.Add("package", MySqlDbType.VarChar);
                objSqlCommand.Parameters["package"].Value = package;

                objSqlCommand.Parameters.Add("insertion", MySqlDbType.Int64);
                if (insertion == "" || insertion == null)
                {
                    objSqlCommand.Parameters["insertion"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["insertion"].Value = Convert.ToInt32(insertion);
                }

                objSqlCommand.Parameters.Add("startdate", MySqlDbType.Datetime);
                if (startdate == "" || startdate == null)
                {
                    objSqlCommand.Parameters["startdate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "mm/dd/yyyy" && startdate != "")
                    {
                        string[] arr = null;
                        arr = startdate.Split("/".ToCharArray());
                        startdate = arr[2] + "/" + arr[0] + "/" + arr[1];

                    }
                    if (dateformat == "dd/mm/yyyy" && startdate != "")
                    {
                        string[] arr = null;
                        arr = startdate.Split("/".ToCharArray());
                        startdate = arr[1] + "/" + arr[0] + "/" + arr[2];

                    }
                    if (dateformat == "yyyy/mm/dd" && startdate != "")
                    {
                        string[] arr = null;
                        arr = startdate.Split("/".ToCharArray());
                        startdate = arr[1] + "/" + arr[2] + "/" + arr[0];

                    }
                    objSqlCommand.Parameters["startdate"].Value = Convert.ToDateTime(startdate).ToString("yyyy-MM-dd");
                }

                objSqlCommand.Parameters.Add("repeatdate", MySqlDbType.VarChar);
                objSqlCommand.Parameters["repeatdate"].Value = repeatdate;

                objSqlCommand.Parameters.Add("adtype", MySqlDbType.VarChar);
                objSqlCommand.Parameters["adtype"].Value = adtype;

                objSqlCommand.Parameters.Add("adcategory", MySqlDbType.VarChar);
                objSqlCommand.Parameters["adcategory"].Value = adcategory;

                objSqlCommand.Parameters.Add("subcategory", MySqlDbType.VarChar);
                objSqlCommand.Parameters["subcategory"].Value = subcategory;

                objSqlCommand.Parameters.Add("color", MySqlDbType.VarChar);
                objSqlCommand.Parameters["color"].Value = color;

                objSqlCommand.Parameters.Add("uom", MySqlDbType.VarChar);
                objSqlCommand.Parameters["uom"].Value = uom;

                objSqlCommand.Parameters.Add("pageposition", MySqlDbType.VarChar);
                objSqlCommand.Parameters["pageposition"].Value = pageposition;

                objSqlCommand.Parameters.Add("pagetype", MySqlDbType.VarChar);
                objSqlCommand.Parameters["pagetype"].Value = pagetype;

                objSqlCommand.Parameters.Add("pageno", MySqlDbType.Int64);
                if (pageno == "" || pageno == null)
                {
                    objSqlCommand.Parameters["pageno"].Value = 0;//System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["pageno"].Value = Convert.ToInt32(pageno);
                }

                objSqlCommand.Parameters.Add("adsizheight", MySqlDbType.Decimal);
                if (adsizheight == "" || adsizheight == null)
                {
                    objSqlCommand.Parameters["adsizheight"].Value = 0;//System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["adsizheight"].Value = Convert.ToDecimal(adsizheight);
                }

                objSqlCommand.Parameters.Add("adsizwidth", MySqlDbType.Decimal);
                if (adsizwidth == "" || adsizwidth == null)
                {
                    objSqlCommand.Parameters["adsizwidth"].Value = 0;//System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["adsizwidth"].Value = Convert.ToDecimal(adsizwidth);
                }

                objSqlCommand.Parameters.Add("ratecode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["ratecode"].Value = ratecode;

                objSqlCommand.Parameters.Add("scheme", MySqlDbType.VarChar);
                objSqlCommand.Parameters["scheme"].Value = scheme;

                objSqlCommand.Parameters.Add("currency", MySqlDbType.VarChar);
                objSqlCommand.Parameters["currency"].Value = currency;

                objSqlCommand.Parameters.Add("agreedrate", MySqlDbType.Decimal);
                if (agreedrate == "" || agreedrate == null)
                {
                    objSqlCommand.Parameters["agreedrate"].Value = 0;//System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["agreedrate"].Value = Convert.ToDecimal(agreedrate);
                }
                //    , , ,Session["compcode"].ToString(),Session["userid"].ToString()
                objSqlCommand.Parameters.Add("agreedamt", MySqlDbType.Decimal);
                if (agreedamt == "" || agreedamt == null)
                {
                    objSqlCommand.Parameters["agreedamt"].Value = 0;//System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["agreedamt"].Value = Convert.ToDecimal(agreedamt);
                }

                objSqlCommand.Parameters.Add("spedisc", MySqlDbType.Decimal);
                if (spedisc == "" || spedisc == null)
                {
                    objSqlCommand.Parameters["spedisc"].Value = 0;//System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["spedisc"].Value = Convert.ToDecimal(spedisc);
                }

                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("spacedisx", MySqlDbType.Decimal);
                if (spacedisx == "" || spacedisx == null)
                {
                    objSqlCommand.Parameters["spacedisx"].Value = 0;//System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["spacedisx"].Value = Convert.ToDecimal(spacedisx);
                }

                objSqlCommand.Parameters.Add("specialcharges", MySqlDbType.Decimal);
                if (specialcharges == "" || specialcharges == null)
                {
                    objSqlCommand.Parameters["specialcharges"].Value = 0;//System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["specialcharges"].Value = Convert.ToDecimal(specialcharges);
                }

                objSqlCommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objSqlCommand.Parameters["userid"].Value = userid;

                objSqlCommand.Parameters.Add("agencytype", MySqlDbType.VarChar);
                objSqlCommand.Parameters["agencytype"].Value = agencytype;

                objSqlCommand.Parameters.Add("agencystatus", MySqlDbType.VarChar);
                objSqlCommand.Parameters["agencystatus"].Value = agencystatus;

                objSqlCommand.Parameters.Add("paymode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["paymode"].Value = paymode;

                objSqlCommand.Parameters.Add("agencredit", MySqlDbType.Int64);
                if (agencredit == "" || agencredit == null)
                {
                    objSqlCommand.Parameters["agencredit"].Value = 0;//System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["agencredit"].Value = Convert.ToInt32(agencredit);
                }

                objSqlCommand.Parameters.Add("cardrate", MySqlDbType.Decimal);
                if (cardrate == "" || cardrate == null)
                {
                    objSqlCommand.Parameters["cardrate"].Value = 0;//System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["cardrate"].Value = Convert.ToDecimal(cardrate);
                }

                objSqlCommand.Parameters.Add("cardamount", MySqlDbType.Decimal);
                if (cardamount == "" || cardamount == null)
                {
                    objSqlCommand.Parameters["cardamount"].Value = 0;//System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["cardamount"].Value = Convert.ToDecimal(cardamount);
                }

                objSqlCommand.Parameters.Add("discount", MySqlDbType.Decimal);
                if (discount == "" || discount == null)
                {
                    objSqlCommand.Parameters["discount"].Value = 0;//System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["discount"].Value = Convert.ToDecimal(discount);
                }


                objSqlCommand.Parameters.Add("discountper", MySqlDbType.Decimal);
                if (discountper == "" || discountper == null)
                {
                    objSqlCommand.Parameters["discountper"].Value = 0;//System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["discountper"].Value = Convert.ToDecimal(discountper);
                }

                objSqlCommand.Parameters.Add("billaddress", MySqlDbType.VarChar);
                objSqlCommand.Parameters["billaddress"].Value = billaddress;

                objSqlCommand.Parameters.Add("totarea", MySqlDbType.Decimal);
                if (totarea == "" || totarea == null)
                {
                    objSqlCommand.Parameters["totarea"].Value = 0;//System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["totarea"].Value = Convert.ToDecimal(totarea);
                }


                objSqlCommand.Parameters.Add("billcycle", MySqlDbType.VarChar);
                objSqlCommand.Parameters["billcycle"].Value = billcycle;

                objSqlCommand.Parameters.Add("revenuecenter", MySqlDbType.VarChar);
                objSqlCommand.Parameters["revenuecenter"].Value = revenuecenter;

                objSqlCommand.Parameters.Add("billpay", MySqlDbType.VarChar);
                objSqlCommand.Parameters["billpay"].Value = billpay;

                objSqlCommand.Parameters.Add("billheight", MySqlDbType.Decimal);
                if (billheight == "" || billheight == null)
                {
                    objSqlCommand.Parameters["billheight"].Value = 0;//System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["billheight"].Value = Convert.ToDecimal(billheight);
                }

                objSqlCommand.Parameters.Add("billwidth", MySqlDbType.Decimal);
                if (billwidth == "" || billwidth == null)
                {
                    objSqlCommand.Parameters["billwidth"].Value = 0;//System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["billwidth"].Value = Convert.ToDecimal(billwidth);
                }

                //////, , , , , , , , , , , , , , , , , , , 

                objSqlCommand.Parameters.Add("billto", MySqlDbType.VarChar);
                objSqlCommand.Parameters["billto"].Value = billto;

                objSqlCommand.Parameters.Add("invoices", MySqlDbType.Int64);
                if (invoices == "" || invoices == null)
                {
                    objSqlCommand.Parameters["invoices"].Value = 0;//System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["invoices"].Value = Convert.ToInt32(invoices);
                }

                objSqlCommand.Parameters.Add("vts", MySqlDbType.Int64);
                if (vts == "" || vts == null)
                {
                    objSqlCommand.Parameters["vts"].Value = 0;//System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["vts"].Value = Convert.ToInt32(vts);
                }

                objSqlCommand.Parameters.Add("tradedisc", MySqlDbType.Decimal);
                if (tradedisc == "" || tradedisc == null)
                {
                    objSqlCommand.Parameters["tradedisc"].Value = 0;//System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["tradedisc"].Value = Convert.ToDecimal(tradedisc);
                }

                objSqlCommand.Parameters.Add("agencyout", MySqlDbType.VarChar);
                objSqlCommand.Parameters["agencyout"].Value = agencyout;

                objSqlCommand.Parameters.Add("boxcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["boxcode"].Value = boxcode;

                objSqlCommand.Parameters.Add("boxno", MySqlDbType.VarChar);
                objSqlCommand.Parameters["boxno"].Value = boxno;

                objSqlCommand.Parameters.Add("boxaddress", MySqlDbType.VarChar);
                objSqlCommand.Parameters["boxaddress"].Value = boxaddress;

                objSqlCommand.Parameters.Add("boxagency", MySqlDbType.VarChar);
                objSqlCommand.Parameters["boxagency"].Value = boxagency;

                objSqlCommand.Parameters.Add("boxclient", MySqlDbType.VarChar);
                objSqlCommand.Parameters["boxclient"].Value = boxclient;

                objSqlCommand.Parameters.Add("bookingtype", MySqlDbType.VarChar);
                objSqlCommand.Parameters["bookingtype"].Value = bookingtype;

                objSqlCommand.Parameters.Add("tfn", MySqlDbType.VarChar);
                objSqlCommand.Parameters["tfn"].Value = tfn;

                objSqlCommand.Parameters.Add("coupan", MySqlDbType.VarChar);
                objSqlCommand.Parameters["coupan"].Value = coupan;

                objSqlCommand.Parameters.Add("campaign", MySqlDbType.VarChar);
                objSqlCommand.Parameters["campaign"].Value = campaign;


                objSqlCommand.Parameters.Add("bill_amt", MySqlDbType.Decimal);
                if (bill_amt == "" || bill_amt == null)
                {
                    objSqlCommand.Parameters["bill_amt"].Value = 0;//System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["bill_amt"].Value = Convert.ToDecimal(bill_amt);
                }

                objSqlCommand.Parameters.Add("pageprem", MySqlDbType.VarChar);
                objSqlCommand.Parameters["pageprem"].Value = pageprem;


                objSqlCommand.Parameters.Add("pageamt", MySqlDbType.Decimal);
                if (pageamt == "" || pageamt == null)
                {
                    objSqlCommand.Parameters["pageamt"].Value = 0;//System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["pageamt"].Value = Convert.ToDecimal(pageamt);
                }

                objSqlCommand.Parameters.Add("premper", MySqlDbType.Decimal);
                if (premper == "" || premper == null)
                {
                    objSqlCommand.Parameters["premper"].Value = 0;//System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["premper"].Value = Convert.ToDecimal(premper);
                }

                objSqlCommand.Parameters.Add("grossamt", MySqlDbType.Decimal);
                if (grossamt == "" || grossamt == null)
                {
                    objSqlCommand.Parameters["grossamt"].Value = 0;//System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["grossamt"].Value = Convert.ToDecimal(grossamt);
                }

                objSqlCommand.Parameters.Add("adsizcolumn", MySqlDbType.Decimal);
                if (adsizcolumn == "" || adsizcolumn == null)
                {
                    objSqlCommand.Parameters["adsizcolumn"].Value = 0;//System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["adsizcolumn"].Value = Convert.ToDecimal(adsizcolumn);
                }

                objSqlCommand.Parameters.Add("billcolumn", MySqlDbType.Decimal);
                if (billcolumn == "" || billcolumn == null)
                {
                    objSqlCommand.Parameters["billcolumn"].Value = 0;//System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["billcolumn"].Value = Convert.ToDecimal(billcolumn);
                }

                objSqlCommand.Parameters.Add("billarea", MySqlDbType.Decimal);
                if (billarea == null)
                {
                    objSqlCommand.Parameters["billarea"].Value = 0;
                }
                else
                {

                    objSqlCommand.Parameters["billarea"].Value = Convert.ToDecimal(billarea);
                }


                objSqlCommand.Parameters.Add("specdiscper", MySqlDbType.Decimal);
                if (specdiscper == "" || specdiscper == null)
                {
                    objSqlCommand.Parameters["specdiscper"].Value = 0;//System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["specdiscper"].Value = Convert.ToDecimal(specdiscper);
                }

                objSqlCommand.Parameters.Add("spacediscper", MySqlDbType.Decimal);
                if (spacediscper == "" || spacediscper == null)
                {
                    objSqlCommand.Parameters["spacediscper"].Value = 0;//System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["spacediscper"].Value = Convert.ToDecimal(spacediscper);
                }

                objSqlCommand.Parameters.Add("paidins", MySqlDbType.Int64);
                if (paidins == "" || paidins == null)
                {
                    objSqlCommand.Parameters["paidins"].Value = 0;//System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["paidins"].Value = Convert.ToInt32(paidins);
                }

                objSqlCommand.Parameters.Add("dealrate", MySqlDbType.Decimal);
                if (dealrate == "" || dealrate == null)
                {
                    objSqlCommand.Parameters["dealrate"].Value = 0;//System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["dealrate"].Value = Convert.ToDecimal(dealrate);
                }

                objSqlCommand.Parameters.Add("deviation", MySqlDbType.Decimal);
                if (deviation == "" || deviation == null)
                {
                    objSqlCommand.Parameters["deviation"].Value = 0;//System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["deviation"].Value = Convert.ToDecimal(deviation);
                }

                objSqlCommand.Parameters.Add("varient", MySqlDbType.VarChar);
                objSqlCommand.Parameters["varient"].Value = varient;

                objSqlCommand.Parameters.Add("contractname", MySqlDbType.VarChar);
                objSqlCommand.Parameters["contractname"].Value = contractname;


                objSqlCommand.Parameters.Add("dealtype", MySqlDbType.VarChar);
                objSqlCommand.Parameters["dealtype"].Value = dealtype;

                objSqlCommand.Parameters.Add("cardname", MySqlDbType.VarChar);
                objSqlCommand.Parameters["cardname"].Value = cardname;

                objSqlCommand.Parameters.Add("cardtype", MySqlDbType.VarChar);
                objSqlCommand.Parameters["cardtype"].Value = cardtype;

                objSqlCommand.Parameters.Add("cardmonth", MySqlDbType.VarChar);
                objSqlCommand.Parameters["cardmonth"].Value = cardmonth;

                objSqlCommand.Parameters.Add("cardyear", MySqlDbType.VarChar);
                objSqlCommand.Parameters["cardyear"].Value = cardyear;

                objSqlCommand.Parameters.Add("cardno", MySqlDbType.VarChar);
                objSqlCommand.Parameters["cardno"].Value = cardno;

                objSqlCommand.Parameters.Add("receiptno", MySqlDbType.VarChar);
                objSqlCommand.Parameters["receiptno"].Value = receiptno;

                objSqlCommand.Parameters.Add("adscat3", MySqlDbType.VarChar);
                objSqlCommand.Parameters["adscat3"].Value = adscat3;

                objSqlCommand.Parameters.Add("adscat4", MySqlDbType.VarChar);
                objSqlCommand.Parameters["adscat4"].Value = adscat4;

                objSqlCommand.Parameters.Add("adscat5", MySqlDbType.VarChar);
                objSqlCommand.Parameters["adscat5"].Value = adscat5;

                objSqlCommand.Parameters.Add("bgcolor", MySqlDbType.VarChar);
                objSqlCommand.Parameters["bgcolor"].Value = bgcolor;

                objSqlCommand.Parameters.Add("bulletcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["bulletcode"].Value = bulletcode;

                objSqlCommand.Parameters.Add("bulletprm", MySqlDbType.Decimal);
                if (bulletprm == "" || bulletprm == null)
                {
                    objSqlCommand.Parameters["bulletprm"].Value = 0;//System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["bulletprm"].Value = Convert.ToDecimal(bulletprm);
                }

                objSqlCommand.Parameters.Add("material", MySqlDbType.VarChar);
                objSqlCommand.Parameters["material"].Value = material;

                objSqlCommand.Parameters.Add("region", MySqlDbType.VarChar);
                objSqlCommand.Parameters["region"].Value = region;

                objSqlCommand.Parameters.Add("varient_name", MySqlDbType.VarChar);
                objSqlCommand.Parameters["varient_name"].Value = varient_name;
                /*new change ankur 9 feb*/


                objSqlCommand.Parameters.Add("coltype", MySqlDbType.VarChar);
                objSqlCommand.Parameters["coltype"].Value = coltype;
                //////////////////////////////

                objSqlCommand.Parameters.Add("logo_h", MySqlDbType.VarChar);
                objSqlCommand.Parameters["logo_h"].Value = logo_hei;

                objSqlCommand.Parameters.Add("logo_w", MySqlDbType.VarChar);
                objSqlCommand.Parameters["logo_w"].Value = logo_wid;

                objSqlCommand.Parameters.Add("logo_col", MySqlDbType.VarChar);
                objSqlCommand.Parameters["logo_col"].Value = logo_color;

                objSqlCommand.Parameters.Add("logo_uom", MySqlDbType.VarChar);
                objSqlCommand.Parameters["logo_uom"].Value = logo_uom;

                objSqlCommand.Parameters.Add("status", MySqlDbType.VarChar);
                objSqlCommand.Parameters["status"].Value = status;
                //retainer, string addagencyrate, string mobileno, string addlamt, string retamt, string retper, string cashrecieved)
                //-------------------------------------------------------------------//
                objSqlCommand.Parameters.Add("retainer1", MySqlDbType.VarChar);
                objSqlCommand.Parameters["retainer1"].Value = retainer;

                objSqlCommand.Parameters.Add("addagencyrate", MySqlDbType.VarChar);
                objSqlCommand.Parameters["addagencyrate"].Value = addagencyrate;

                objSqlCommand.Parameters.Add("mobileno1", MySqlDbType.VarChar);
                objSqlCommand.Parameters["mobileno1"].Value = mobileno;

                objSqlCommand.Parameters.Add("addlamt", MySqlDbType.VarChar);
                objSqlCommand.Parameters["addlamt"].Value = addlamt;

                objSqlCommand.Parameters.Add("retper", MySqlDbType.VarChar);
                objSqlCommand.Parameters["retper"].Value = retper;

                objSqlCommand.Parameters.Add("cashrecieved", MySqlDbType.VarChar);
                objSqlCommand.Parameters["cashrecieved"].Value = cashrecieved;

                objSqlCommand.Parameters.Add("retamt", MySqlDbType.VarChar);
                objSqlCommand.Parameters["retamt"].Value = retamt;

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

        public DataSet executebooking(string compcode, string ciobookid, string docno, string keyno, string rono, string agencycode, string client, string booking)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("executebooking", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("ciobookid", MySqlDbType.VarChar);
                objSqlCommand.Parameters["ciobookid"].Value = ciobookid;

                objSqlCommand.Parameters.Add("docno", MySqlDbType.VarChar);
                objSqlCommand.Parameters["docno"].Value = docno;

                objSqlCommand.Parameters.Add("keyno", MySqlDbType.VarChar);
                objSqlCommand.Parameters["keyno"].Value = keyno;

                objSqlCommand.Parameters.Add("rono", MySqlDbType.VarChar);
                objSqlCommand.Parameters["rono"].Value = rono;

                objSqlCommand.Parameters.Add("agencycode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["agencycode"].Value = agencycode;

                objSqlCommand.Parameters.Add("client1", MySqlDbType.VarChar);
                objSqlCommand.Parameters["client1"].Value = client;

                objSqlCommand.Parameters.Add("booking", MySqlDbType.VarChar);
                objSqlCommand.Parameters["booking"].Value = booking;

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


        //------- for classified booking -----------------//
        public DataSet executebookingdisp(string compcode, string ciobookid, string docno, string keyno, string rono, string agencycode, string client, string booking, string dateformat, string revenue)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("executebookingdisp", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("ciobookid", MySqlDbType.VarChar);
                objSqlCommand.Parameters["ciobookid"].Value = ciobookid;

                objSqlCommand.Parameters.Add("docno", MySqlDbType.VarChar);
                objSqlCommand.Parameters["docno"].Value = docno;

                objSqlCommand.Parameters.Add("keyno", MySqlDbType.VarChar);
                objSqlCommand.Parameters["keyno"].Value = keyno;

                objSqlCommand.Parameters.Add("rono", MySqlDbType.VarChar);
                objSqlCommand.Parameters["rono"].Value = rono;

                objSqlCommand.Parameters.Add("agencycode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["agencycode"].Value = agencycode;

                objSqlCommand.Parameters.Add("client1", MySqlDbType.VarChar);
                objSqlCommand.Parameters["client1"].Value = client;

                objSqlCommand.Parameters.Add("booking", MySqlDbType.VarChar);
                objSqlCommand.Parameters["booking"].Value = booking;

                objSqlCommand.Parameters.Add("dateformat", MySqlDbType.VarChar);
                objSqlCommand.Parameters["dateformat"].Value = dateformat;

                objSqlCommand.Parameters.Add("revenue", MySqlDbType.VarChar);
                objSqlCommand.Parameters["revenue"].Value = revenue;



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



        public DataSet executebookingqbc(string compcode, string ciobookid, string docno, string keyno, string rono, string agencycode, string client, string booking)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("executebooking", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("ciobookid", MySqlDbType.VarChar);
                objSqlCommand.Parameters["ciobookid"].Value = ciobookid;

                objSqlCommand.Parameters.Add("docno", MySqlDbType.VarChar);
                objSqlCommand.Parameters["docno"].Value = docno;

                objSqlCommand.Parameters.Add("keyno", MySqlDbType.VarChar);
                objSqlCommand.Parameters["keyno"].Value = keyno;

                objSqlCommand.Parameters.Add("rono", MySqlDbType.VarChar);
                objSqlCommand.Parameters["rono"].Value = rono;

                objSqlCommand.Parameters.Add("agencycode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["agencycode"].Value = agencycode;

                objSqlCommand.Parameters.Add("client1", MySqlDbType.VarChar);
                objSqlCommand.Parameters["client1"].Value = client;

                objSqlCommand.Parameters.Add("booking", MySqlDbType.VarChar);
                objSqlCommand.Parameters["booking"].Value = booking;



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

        public DataSet bindpaymode(string compcode)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("bindpaymode", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;


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

        public DataSet bindrevenue(string compcode)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("bindrevenue", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;


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

        public DataSet getstatuspaymode(string agency, string agencysubcode, string compcode, string datecheck, string dateformat, string adtype)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getstatuspaymode", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("agency", MySqlDbType.VarChar);
                objSqlCommand.Parameters["agency"].Value = agency;

                objSqlCommand.Parameters.Add("agencysubcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["agencysubcode"].Value = agencysubcode;

                objSqlCommand.Parameters.Add("datecheck", MySqlDbType.Datetime);
                if (datecheck == "" || datecheck == null)
                {
                    objSqlCommand.Parameters["datecheck"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "mm/dd/yyyy" && datecheck != "")
                    {
                        string[] arr = null;
                        arr = datecheck.Split("/".ToCharArray());
                        datecheck = arr[2] + "/" + arr[0] + "/" + arr[1];

                    }
                    if (dateformat == "dd/mm/yyyy" && datecheck != "")
                    {
                        string[] arr = null;
                        arr = datecheck.Split("/".ToCharArray());
                        datecheck = arr[1] + "/" + arr[0] + "/" + arr[2];

                    }
                    if (dateformat == "yyyy/mm/dd" && datecheck != "")
                    {
                        string[] arr = null;
                        arr = datecheck.Split("/".ToCharArray());
                        datecheck = arr[1] + "/" + arr[2] + "/" + arr[0];

                    }
                    objSqlCommand.Parameters["datecheck"].Value = Convert.ToDateTime(datecheck).ToString("yyyy-MM-dd");
                }

                //   objSqlCommand.Parameters["datecheck"].Value = datecheck;


                objSqlCommand.Parameters.Add("adtype1", MySqlDbType.VarChar);
                objSqlCommand.Parameters["adtype1"].Value = adtype;

                objSqlCommand.Parameters.Add("dateformat", MySqlDbType.VarChar);
                objSqlCommand.Parameters["dateformat"].Value = dateformat;

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

        public DataSet getthedatabook(string compcode)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getuomforbook", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;


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

        public DataSet getpercentage(string premium, string compcode)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getpremiumforbook", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("premium", MySqlDbType.VarChar);
                objSqlCommand.Parameters["premium"].Value = premium;

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

        public DataSet ratebind(string adcat, string compcode)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("bindratecode", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("adcat", MySqlDbType.VarChar);
                objSqlCommand.Parameters["adcat"].Value = adcat;


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

        public DataSet getrate(string adtype, string color, string adcat, string adsucat, string currency, string ratecode, string package, string selecdate, string compcode, string uom, string premium, string clientcode, string noof_ins)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getratecode", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("adtype", MySqlDbType.VarChar);
                objSqlCommand.Parameters["adtype"].Value = adtype;

                objSqlCommand.Parameters.Add("color", MySqlDbType.VarChar);
                objSqlCommand.Parameters["color"].Value = color;

                objSqlCommand.Parameters.Add("adcat", MySqlDbType.VarChar);
                objSqlCommand.Parameters["adcat"].Value = adcat;

                objSqlCommand.Parameters.Add("adsucat", MySqlDbType.VarChar);
                objSqlCommand.Parameters["adsucat"].Value = adsucat;

                objSqlCommand.Parameters.Add("currency", MySqlDbType.VarChar);
                objSqlCommand.Parameters["currency"].Value = currency;

                objSqlCommand.Parameters.Add("ratecode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["ratecode"].Value = ratecode;

                objSqlCommand.Parameters.Add("package", MySqlDbType.VarChar);
                objSqlCommand.Parameters["package"].Value = package;

                objSqlCommand.Parameters.Add("selecdate", MySqlDbType.VarChar);
                objSqlCommand.Parameters["selecdate"].Value = selecdate;

                objSqlCommand.Parameters.Add("uom", MySqlDbType.VarChar);
                objSqlCommand.Parameters["uom"].Value = uom;

                objSqlCommand.Parameters.Add("premium", MySqlDbType.VarChar);
                objSqlCommand.Parameters["premium"].Value = premium;


                objSqlCommand.Parameters.Add("clientcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["clientcode"].Value = clientcode;

                objSqlCommand.Parameters.Add("noof_ins", MySqlDbType.VarChar);
                objSqlCommand.Parameters["noof_ins"].Value = noof_ins;



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

        public DataSet class_getrate(string adtype, string color, string adcat, string adsucat, string currency, string ratecode, string package, string selecdate, string compcode, string uom, string insert, string lines, string prem, string adcat3, string adcat4, string adcat5, string clientname, string noof_ins)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("class_getratecode", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("adtype", MySqlDbType.VarChar);
                objSqlCommand.Parameters["adtype"].Value = adtype;

                objSqlCommand.Parameters.Add("color", MySqlDbType.VarChar);
                objSqlCommand.Parameters["color"].Value = color;

                objSqlCommand.Parameters.Add("adcat", MySqlDbType.VarChar);
                objSqlCommand.Parameters["adcat"].Value = adcat;

                objSqlCommand.Parameters.Add("adsucat", MySqlDbType.VarChar);
                objSqlCommand.Parameters["adsucat"].Value = adsucat;

                objSqlCommand.Parameters.Add("currency", MySqlDbType.VarChar);
                objSqlCommand.Parameters["currency"].Value = currency;

                objSqlCommand.Parameters.Add("ratecode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["ratecode"].Value = ratecode;

                objSqlCommand.Parameters.Add("package", MySqlDbType.VarChar);
                objSqlCommand.Parameters["package"].Value = package;

                objSqlCommand.Parameters.Add("selecdate", MySqlDbType.VarChar);
                objSqlCommand.Parameters["selecdate"].Value = selecdate;

                objSqlCommand.Parameters.Add("uom", MySqlDbType.VarChar);
                objSqlCommand.Parameters["uom"].Value = uom;


                objSqlCommand.Parameters.Add("insert", MySqlDbType.VarChar);
                objSqlCommand.Parameters["insert"].Value = insert;

                objSqlCommand.Parameters.Add("lines", MySqlDbType.VarChar);
                objSqlCommand.Parameters["lines"].Value = lines;


                objSqlCommand.Parameters.Add("prem", MySqlDbType.VarChar);
                objSqlCommand.Parameters["prem"].Value = prem;

                objSqlCommand.Parameters.Add("adcat3", MySqlDbType.VarChar);
                if (adcat3 == "")
                {
                    objSqlCommand.Parameters["adcat3"].Value = "0";
                }
                else
                {
                    objSqlCommand.Parameters["adcat3"].Value = adcat3;
                }

                objSqlCommand.Parameters.Add("adcat4", MySqlDbType.VarChar);
                if (adcat4 == "")
                {
                    objSqlCommand.Parameters["adcat4"].Value = "0";
                }
                else
                {
                    objSqlCommand.Parameters["adcat4"].Value = adcat4;
                }
                objSqlCommand.Parameters.Add("adcat5", MySqlDbType.VarChar);
                if (adcat5 == "")
                {
                    objSqlCommand.Parameters["adcat5"].Value = "0";
                }
                else
                {
                    objSqlCommand.Parameters["adcat5"].Value = adcat5;
                }

                objSqlCommand.Parameters.Add("clientname", MySqlDbType.VarChar);
                objSqlCommand.Parameters["clientname"].Value = clientname;

                objSqlCommand.Parameters.Add("noof_ins", MySqlDbType.VarChar);
                objSqlCommand.Parameters["noof_ins"].Value = noof_ins;






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

        public DataSet class_getrate_qbc(string adtype, string color, string adcat, string adsucat, string currency, string ratecode, string package, string selecdate, string compcode, string uom, string insert, string lines, string prem, string adcat3, string adcat4, string adcat5, string clientname, string noof_ins)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                //objSqlCommand = GetCommand("class_getratecode_qbc", ref objSqlConnection);
                objSqlCommand = GetCommand("getratefor_qbc", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("adtype", MySqlDbType.VarChar);
                objSqlCommand.Parameters["adtype"].Value = adtype;

                objSqlCommand.Parameters.Add("color", MySqlDbType.VarChar);
                objSqlCommand.Parameters["color"].Value = color;

                objSqlCommand.Parameters.Add("adcat", MySqlDbType.VarChar);
                objSqlCommand.Parameters["adcat"].Value = adcat;

                objSqlCommand.Parameters.Add("adsucat", MySqlDbType.VarChar);
                objSqlCommand.Parameters["adsucat"].Value = adsucat;

                objSqlCommand.Parameters.Add("currency", MySqlDbType.VarChar);
                objSqlCommand.Parameters["currency"].Value = currency;

                objSqlCommand.Parameters.Add("ratecode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["ratecode"].Value = ratecode;

                objSqlCommand.Parameters.Add("package", MySqlDbType.VarChar);
                objSqlCommand.Parameters["package"].Value = package;

                objSqlCommand.Parameters.Add("selecdate", MySqlDbType.VarChar);
                objSqlCommand.Parameters["selecdate"].Value = selecdate;

                objSqlCommand.Parameters.Add("uom", MySqlDbType.VarChar);
                objSqlCommand.Parameters["uom"].Value = uom;


                objSqlCommand.Parameters.Add("insert1", MySqlDbType.VarChar);
                objSqlCommand.Parameters["insert1"].Value = insert;

                objSqlCommand.Parameters.Add("lines1", MySqlDbType.VarChar);
                objSqlCommand.Parameters["lines1"].Value = lines;


                objSqlCommand.Parameters.Add("prem", MySqlDbType.VarChar);
                objSqlCommand.Parameters["prem"].Value = prem;

                objSqlCommand.Parameters.Add("adcat3", MySqlDbType.VarChar);
                if (adcat3 == "")
                {
                    objSqlCommand.Parameters["adcat3"].Value = "0";
                }
                else
                {
                    objSqlCommand.Parameters["adcat3"].Value = adcat3;
                }

                objSqlCommand.Parameters.Add("adcat4", MySqlDbType.VarChar);
                if (adcat4 == "")
                {
                    objSqlCommand.Parameters["adcat4"].Value = "0";
                }
                else
                {
                    objSqlCommand.Parameters["adcat4"].Value = adcat4;
                }
                objSqlCommand.Parameters.Add("adcat5", MySqlDbType.VarChar);
                if (adcat5 == "")
                {
                    objSqlCommand.Parameters["adcat5"].Value = "0";
                }
                else
                {
                    objSqlCommand.Parameters["adcat5"].Value = adcat5;
                }

                objSqlCommand.Parameters.Add("clientname", MySqlDbType.VarChar);
                objSqlCommand.Parameters["clientname"].Value = clientname;

                objSqlCommand.Parameters.Add("noof_ins", MySqlDbType.VarChar);
                objSqlCommand.Parameters["noof_ins"].Value = noof_ins;






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


        public DataSet boxbind(string compcode, string center)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("boxbind_boxbind_p", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("center", MySqlDbType.VarChar);
                objSqlCommand.Parameters["center"].Value = center;

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

        public DataSet boxbind_qbc(string compcode, string userid)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("boxbindqbc", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;



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

        public DataSet bindagency(string compcode, string userid, string agency, string center)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("bindagencyforbooking", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objSqlCommand.Parameters["userid"].Value = userid;

                objSqlCommand.Parameters.Add("agency", MySqlDbType.VarChar);
                objSqlCommand.Parameters["agency"].Value = agency;

                objSqlCommand.Parameters.Add("pubcenter", MySqlDbType.VarChar);
                objSqlCommand.Parameters["pubcenter"].Value = center;

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

        public DataSet getClientNameadd(string client, string compcode, string value, string datecheck, string dateformat)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("bindagencyforagency", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;
                objSqlCommand.Parameters.Add("client", MySqlDbType.VarChar);
                objSqlCommand.Parameters["client"].Value = client;

                objSqlCommand.Parameters.Add("VALUE", MySqlDbType.VarChar);
                objSqlCommand.Parameters["VALUE"].Value = value;

                objSqlCommand.Parameters.Add("datecheck", MySqlDbType.Datetime);
                if (datecheck == "" || datecheck == null)
                {
                    objSqlCommand.Parameters["datecheck"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "mm/dd/yyyy" && datecheck != "")
                    {
                        string[] arr = null;
                        arr = datecheck.Split("/".ToCharArray());
                        datecheck = arr[2] + "/" + arr[0] + "/" + arr[1];

                    }
                    if (dateformat == "dd/mm/yyyy" && datecheck != "")
                    {
                        string[] arr = null;
                        arr = datecheck.Split("/".ToCharArray());
                        datecheck = arr[1] + "/" + arr[0] + "/" + arr[2];

                    }
                    if (dateformat == "yyyy/mm/dd" && datecheck != "")
                    {
                        string[] arr = null;
                        arr = datecheck.Split("/".ToCharArray());
                        datecheck = arr[1] + "/" + arr[2] + "/" + arr[0];

                    }
                    objSqlCommand.Parameters["datecheck"].Value = Convert.ToDateTime(datecheck).ToString("yyyy-MM-dd");
                }



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


        public DataSet chkrategroup(string color, string adcat, string adsucat, string package, string ratecode, string selecdate, string currency, string adtype, string compcode, string agency, string client, string dateformat)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("chkrategroupcode", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("adtype1", MySqlDbType.VarChar);
                objSqlCommand.Parameters["adtype1"].Value = adtype;

                objSqlCommand.Parameters.Add("color", MySqlDbType.VarChar);
                objSqlCommand.Parameters["color"].Value = color;

                objSqlCommand.Parameters.Add("adcat1", MySqlDbType.VarChar);
                objSqlCommand.Parameters["adcat1"].Value = adcat;

                objSqlCommand.Parameters.Add("adsucat", MySqlDbType.VarChar);
                objSqlCommand.Parameters["adsucat"].Value = adsucat;

                objSqlCommand.Parameters.Add("currency1", MySqlDbType.VarChar);
                objSqlCommand.Parameters["currency1"].Value = currency;

                objSqlCommand.Parameters.Add("ratecode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["ratecode"].Value = ratecode;

                objSqlCommand.Parameters.Add("package", MySqlDbType.VarChar);
                objSqlCommand.Parameters["package"].Value = package;

                objSqlCommand.Parameters.Add("selecdate", MySqlDbType.Datetime);
                if (selecdate == "" || selecdate == null)
                {
                    objSqlCommand.Parameters["selecdate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "mm/dd/yyyy" && selecdate != "")
                    {
                        string[] arr = null;
                        arr = selecdate.Split("/".ToCharArray());
                        selecdate = arr[0] + "-" + arr[1] + "-" + arr[2];

                    }
                    if (dateformat == "dd/mm/yyyy" && selecdate != "")
                    {
                        string[] arr = null;
                        arr = selecdate.Split("/".ToCharArray());
                        selecdate = arr[1] + "-" + arr[0] + "-" + arr[2];

                    }
                    if (dateformat == "yyyy/mm/dd" && selecdate != "")
                    {
                        string[] arr = null;
                        arr = selecdate.Split("/".ToCharArray());
                        selecdate = arr[1] + "-" + arr[2] + "-" + arr[0];

                    }
                    objSqlCommand.Parameters["selecdate"].Value = Convert.ToDateTime(selecdate).ToString("yyyy-MM-dd");
                }


                objSqlCommand.Parameters.Add("agency", MySqlDbType.VarChar);
                objSqlCommand.Parameters["agency"].Value = agency;

                objSqlCommand.Parameters.Add("client1", MySqlDbType.VarChar);
                objSqlCommand.Parameters["client1"].Value = client;






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

        //err = insertchild.insertbook_ins(insertdate, edition, premium1, premium2, premallow, adcategory, latestdate, material, cardrate, filename, discrate,                                                            insertstatus, billstatus, adsubcat, compcode, userid, cioid, height, width,                                                 totalsize, pagepost, premper1, premper2, colid, repeat, insertno, paid,                                                         insertinsertion, solorate, grossrate, insert_pageno, insert_remarks, page_code, page_per, noofcol, billamt,                                                             billrate, "0", "0", "0", "0", "0", "0",                                                                             pkgcode, gridins, pkgalias, cirvts, cirpub, ciredi, cirrate, cirdate, ciragency, ciragencysubcode, center, branch, splitdata, subedidata, "", vatrate, boxcharge, vat_inc_p, grossamtlocal_p, billamtlocal_p, sectioncode_p, resourceno_p, caption_inserts, dealerheight, dealerwidth, disc_, agncyamnt, adlgncyamnt, spldisc, cashdisc, roundoffamt, pdfheight, cpnamt, clicatamt, flatfreqamt, catamt, null, premamtval, null, null);
        //public DataSet insertbook_ins(string insertdate, string edition, string premium1, string premium2, string premallow, string adcategory, string latestdate, string material, string cardrate, string matfilename, string discrate, string insertstatus, string billstatus, string adsubcat, string compcode, string userid, string cioid, string height, string width, string totalsize, string pagepost, string premper1, string premper2, string colid, string repeat, string insertno, string paid, string agrrate, string solorate, string grossrate, string insert_pageno, string insert_remarks, string page_code, string page_per, string noofcol, string billamt, string billrate, string logo_h, string logo_w, string logo_name, string dateformat, string adcat3, string adcat4, string adcat5, string pkgcode, string gridins, string pkgalias)
//        public DataSet insertbook_ins(string insertdate, string edition, string premium1, string premium2, string premallow, string adcategory, string latestdate, string material, string cardrate, string matfilename, string discrate, string insertstatus, string billstatus, string adsubcat, string compcode, string userid, string cioid, string height, string width, string totalsize, string pagepost, string premper1, string premper2, string colid, string repeat, string insertno, string paid, string agrrate, string solorate, string grossrate, string insert_pageno, string insert_remarks, string page_code, string page_per, string noofcol, string billamt, string billrate, string logo_h, string logo_w, string logo_name, string dateformat, string adcat3, string adcat4, string adcat5, string pkgcode, string gridins, string pkgalias, string cirvts, string cirpub, string ciredi, string cirrate, string cirdate, string ciragency, string ciragencysubcode, string center, string branch, string splitdata, string subedidata, string undef1, string vatrate, string boxcharge, string vat_inc_p, string grossamtlocal_p, string billamtlocal_p, string sectioncode_p, string resourceno_p, string caption_inserts, string dealerheight, string dealerwidth, string disc_, string agncyamnt, string adlgncyamnt, string spldisc, string cashdisc, string roundoffamt, string pdfheight, string cpnamt, string clicatamt, string flatfreqamt, string catamt, string undef2, string premamtval, string undef3, string undef4)  before gst changes
        public DataSet insertbook_ins(string insertdate, string edition, string premium1, string premium2, string premallow, string adcategory, string latestdate, string material, string cardrate, string matfilename, string discrate, string insertstatus, string billstatus, string adsubcat, string compcode, string userid, string cioid, string height, string width, string totalsize, string pagepost, string premper1, string premper2, string colid, string repeat, string insertno, string paid, string agrrate, string solorate, string grossrate, string insert_pageno, string insert_remarks, string page_code, string page_per, string noofcol, string billamt, string billrate, string logo_h, string logo_w, string logo_name, string dateformat, string adcat3, string adcat4, string adcat5, string pkgcode, string gridins, string pkgalias, string cirvts, string cirpub, string ciredi, string cirrate, string cirdate, string ciragency, string ciragencysubcode, string center, string branch, string splitdata, string subedidata, string undef1, string vatrate, string boxcharge, string vat_inc_p, string grossamtlocal_p, string billamtlocal_p, string sectioncode_p, string resourceno_p, string caption_inserts, string dealerheight, string dealerwidth, string disc_, string agncyamnt, string adlgncyamnt, string spldisc, string cashdisc, string roundoffamt, string pdfheight, string cpnamt, string clicatamt, string flatfreqamt, string catamt, string undef2, string premamtval, string undef3, string undef4, string gstamount, string gstgrid)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("insertintobookchild_insertintobookchild_p", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("insertdate", MySqlDbType.DateTime);
                if (insertdate == "" || insertdate == null)
                {
                    objSqlCommand.Parameters["insertdate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "mm/dd/yyyy" && insertdate != "")
                    {
                        string[] arr = null;
                        arr = insertdate.Split("/".ToCharArray());
                        insertdate = arr[0] + "-" + arr[1] + "-" + arr[2];
                    }
                    if (dateformat == "dd/mm/yyyy" && insertdate != "")
                    {
                        string[] arr = null;
                        arr = insertdate.Split("/".ToCharArray());
                        insertdate = arr[1] + "-" + arr[0] + "-" + arr[2];
                        //insertdate = arr[2] + "-" + arr[1] + "-" + arr[0];
                    }
                    if (dateformat == "yyyy/mm/dd" && insertdate != "")
                    {
                        string[] arr = null;
                        arr = insertdate.Split("/".ToCharArray());
                        insertdate = arr[1] + "-" + arr[2] + "-" + arr[0];
                    }
                    objSqlCommand.Parameters["insertdate"].Value = Convert.ToDateTime(insertdate).ToString("yyyy-MM-dd");
                }

                objSqlCommand.Parameters.Add("edition", MySqlDbType.VarChar);
                objSqlCommand.Parameters["edition"].Value = edition;

                objSqlCommand.Parameters.Add("premium1", MySqlDbType.VarChar);
                objSqlCommand.Parameters["premium1"].Value = premium1;

                objSqlCommand.Parameters.Add("premium2", MySqlDbType.VarChar);
                objSqlCommand.Parameters["premium2"].Value = premium2;

                objSqlCommand.Parameters.Add("premallow", MySqlDbType.VarChar);
                objSqlCommand.Parameters["premallow"].Value = premallow;

                objSqlCommand.Parameters.Add("adcategory", MySqlDbType.VarChar);
                objSqlCommand.Parameters["adcategory"].Value = adcategory;

                objSqlCommand.Parameters.Add("latestdate", MySqlDbType.DateTime);
                if (latestdate == "" || latestdate == null)
                {
                    objSqlCommand.Parameters["latestdate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "mm/dd/yyyy" && latestdate != "")
                    {
                        string[] arr = null;
                        arr = latestdate.Split("/".ToCharArray());
                        latestdate = arr[0] + "-" + arr[1] + "-" + arr[2];
                    }
                    if (dateformat == "dd/mm/yyyy" && latestdate != "")
                    {
                        string[] arr = null;
                        arr = latestdate.Split("/".ToCharArray());
                        latestdate = arr[1] + "-" + arr[0] + "-" + arr[2];
                    }
                    if (dateformat == "yyyy/mm/dd" && latestdate != "")
                    {
                        string[] arr = null;
                        arr = latestdate.Split("/".ToCharArray());
                        latestdate = arr[1] + "-" + arr[2] + "-" + arr[0];
                    }
                    objSqlCommand.Parameters["latestdate"].Value = Convert.ToDateTime(latestdate).ToString("yyyy-MM-dd"); ;
                }
                //,,,,,,,,,,,,,

                objSqlCommand.Parameters.Add("material", MySqlDbType.VarChar);
                objSqlCommand.Parameters["material"].Value = material;

                objSqlCommand.Parameters.Add("cardrate", MySqlDbType.Double);
                if (cardrate == "" || cardrate == null)
                {
                    objSqlCommand.Parameters["cardrate"].Value = Convert.ToDouble("0");
                }
                else
                {
                    objSqlCommand.Parameters["cardrate"].Value = Convert.ToDouble(cardrate);

                }

                objSqlCommand.Parameters.Add("matfilename", MySqlDbType.VarChar);
                objSqlCommand.Parameters["matfilename"].Value = matfilename;

                objSqlCommand.Parameters.Add("discrate", MySqlDbType.Double);
                if (discrate == "" || discrate == null)
                {
                    objSqlCommand.Parameters["discrate"].Value = Convert.ToDouble("0");
                }
                else
                {
                    objSqlCommand.Parameters["discrate"].Value = Convert.ToDouble(discrate);
                }

                objSqlCommand.Parameters.Add("insertstatus", MySqlDbType.VarChar);
                objSqlCommand.Parameters["insertstatus"].Value = insertstatus;

                objSqlCommand.Parameters.Add("billstatus", MySqlDbType.VarChar);
                objSqlCommand.Parameters["billstatus"].Value = billstatus;

                objSqlCommand.Parameters.Add("adsubcat1", MySqlDbType.VarChar);
                objSqlCommand.Parameters["adsubcat1"].Value = adsubcat;

                objSqlCommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objSqlCommand.Parameters["userid"].Value = userid;

                objSqlCommand.Parameters.Add("cioid", MySqlDbType.VarChar);
                objSqlCommand.Parameters["cioid"].Value = cioid;
                //
                objSqlCommand.Parameters.Add("height", MySqlDbType.Double);
                if (height == "" || height == null)
                {
                    objSqlCommand.Parameters["height"].Value = Convert.ToDouble("0");
                }
                else
                {
                    objSqlCommand.Parameters["height"].Value = Convert.ToDouble(height);
                }

                objSqlCommand.Parameters.Add("width", MySqlDbType.Double);
                if (width == "" || width == null)
                {
                    objSqlCommand.Parameters["width"].Value = Convert.ToDouble("0");
                }
                else
                {
                    objSqlCommand.Parameters["width"].Value = Convert.ToDouble(width);
                }

                objSqlCommand.Parameters.Add("totalsize", MySqlDbType.Double);
                if (totalsize == "" || totalsize == null)
                {
                    objSqlCommand.Parameters["totalsize"].Value = Convert.ToDouble("0");
                }
                else
                {
                    objSqlCommand.Parameters["totalsize"].Value = Convert.ToDouble(totalsize);
                }

                objSqlCommand.Parameters.Add("pagepost", MySqlDbType.VarChar);
                objSqlCommand.Parameters["pagepost"].Value = pagepost;

                objSqlCommand.Parameters.Add("premper1", MySqlDbType.Double);
                if (premper1 == "" || premper1 == null || premper1 == "null")
                {
                    objSqlCommand.Parameters["premper1"].Value = Convert.ToDouble("0");
                }
                else
                {
                    objSqlCommand.Parameters["premper1"].Value = Convert.ToDouble(premper1);
                }

                objSqlCommand.Parameters.Add("premper2", MySqlDbType.Double);
                if (premper2 == "" || premper2 == null)
                {
                    objSqlCommand.Parameters["premper2"].Value = Convert.ToDouble("0");
                }
                else
                {
                    objSqlCommand.Parameters["premper2"].Value = Convert.ToDouble(premper2);
                }

                objSqlCommand.Parameters.Add("colid", MySqlDbType.VarChar);
                objSqlCommand.Parameters["colid"].Value = colid;

                objSqlCommand.Parameters.Add("prepeat", MySqlDbType.DateTime);
                if (repeat == "" || repeat == null)
                {
                    objSqlCommand.Parameters["prepeat"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "mm/dd/yyyy" && repeat != "")
                    {
                        string[] arr = null;
                        arr = repeat.Split("/".ToCharArray());
                        repeat = arr[0] + "-" + arr[1] + "-" + arr[2];

                    }
                    if (dateformat == "dd/mm/yyyy" && repeat != "")
                    {
                        string[] arr = null;
                        arr = repeat.Split("/".ToCharArray());
                        repeat = arr[1] + "-" + arr[0] + "-" + arr[2];

                    }
                    if (dateformat == "yyyy/mm/dd" && repeat != "")
                    {
                        string[] arr = null;
                        arr = repeat.Split("/".ToCharArray());
                        repeat = arr[1] + "-" + arr[2] + "-" + arr[0];

                    }
                    objSqlCommand.Parameters["prepeat"].Value = Convert.ToDateTime(repeat).ToString("yyyy-MM-dd");
                }

                objSqlCommand.Parameters.Add("insertno", MySqlDbType.Int64);
                if (insertno == "" || insertno == null)
                {
                    objSqlCommand.Parameters["insertno"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["insertno"].Value = Convert.ToInt32(insertno);
                }

                objSqlCommand.Parameters.Add("paid", MySqlDbType.VarChar);
                objSqlCommand.Parameters["paid"].Value = paid;

                objSqlCommand.Parameters.Add("agrrate", MySqlDbType.Double);
                if (agrrate == "" || agrrate == null)
                {
                    objSqlCommand.Parameters["agrrate"].Value = Convert.ToDouble("0");
                }
                else
                {
                    objSqlCommand.Parameters["agrrate"].Value = Convert.ToDouble(agrrate);
                }

                objSqlCommand.Parameters.Add("solorate", MySqlDbType.Double);
                if (solorate == "" || solorate == null)
                {
                    objSqlCommand.Parameters["solorate"].Value = Convert.ToDouble("0");
                }
                else
                {
                    objSqlCommand.Parameters["solorate"].Value = Convert.ToDouble(solorate);
                }

                objSqlCommand.Parameters.Add("grossrate", MySqlDbType.Double);
                if (grossrate == "" || grossrate == null)
                {
                    objSqlCommand.Parameters["grossrate"].Value = Convert.ToDouble("0");
                }
                else
                {
                    objSqlCommand.Parameters["grossrate"].Value = Convert.ToDouble(grossrate);
                }

                objSqlCommand.Parameters.Add("insert_pageno", MySqlDbType.Double);
                if (insert_pageno == "" || insert_pageno == null)
                {
                    objSqlCommand.Parameters["insert_pageno"].Value = Convert.ToDouble("0");
                }
                else
                {
                    objSqlCommand.Parameters["insert_pageno"].Value = Convert.ToDouble(insert_pageno);
                }

                objSqlCommand.Parameters.Add("insert_remarks", MySqlDbType.VarChar);
                objSqlCommand.Parameters["insert_remarks"].Value = insert_remarks;

                objSqlCommand.Parameters.Add("page_code", MySqlDbType.VarChar);
                objSqlCommand.Parameters["page_code"].Value = page_code;

                objSqlCommand.Parameters.Add("page_per", MySqlDbType.Double);
                if (page_per == "" || page_per == null)
                {
                    objSqlCommand.Parameters["page_per"].Value = Convert.ToDouble("0");
                }
                else
                {
                    objSqlCommand.Parameters["page_per"].Value = Convert.ToDouble(page_per);
                }

                objSqlCommand.Parameters.Add("noofcol", MySqlDbType.Double);
                if (noofcol == "" || noofcol == null)
                {
                    objSqlCommand.Parameters["noofcol"].Value = Convert.ToDouble("0");
                }
                else
                {
                    objSqlCommand.Parameters["noofcol"].Value = Convert.ToDouble(noofcol);
                }

                objSqlCommand.Parameters.Add("billamt", MySqlDbType.Double);
                if (billamt == "" || billamt == null)
                {
                    objSqlCommand.Parameters["billamt"].Value = Convert.ToDouble("0");
                }
                else
                {
                    objSqlCommand.Parameters["billamt"].Value = Convert.ToDouble(billamt);
                }

                objSqlCommand.Parameters.Add("billrate", MySqlDbType.Double);
                if (billrate == "" || billrate == null)
                {
                    objSqlCommand.Parameters["billrate"].Value = Convert.ToDouble("0");
                }
                else
                {
                    objSqlCommand.Parameters["billrate"].Value = Convert.ToDouble(billrate);
                }

                objSqlCommand.Parameters.Add("logo_h", MySqlDbType.VarChar);
                objSqlCommand.Parameters["logo_h"].Value = logo_h;

                objSqlCommand.Parameters.Add("logo_w", MySqlDbType.VarChar);
                objSqlCommand.Parameters["logo_w"].Value = logo_w;

                objSqlCommand.Parameters.Add("logo_name", MySqlDbType.VarChar);
                objSqlCommand.Parameters["logo_name"].Value = logo_name;
                //, string adcat3, string adcat4, string adcat5, string pkgcode, string gridins, string pkgalias

                objSqlCommand.Parameters.Add("ad_cat_3", MySqlDbType.VarChar);
                objSqlCommand.Parameters["ad_cat_3"].Value = adcat3;

                objSqlCommand.Parameters.Add("ad_cat_4", MySqlDbType.VarChar);
                objSqlCommand.Parameters["ad_cat_4"].Value = adcat4;

                objSqlCommand.Parameters.Add("ad_cat_5", MySqlDbType.VarChar);
                objSqlCommand.Parameters["ad_cat_5"].Value = adcat5;

                objSqlCommand.Parameters.Add("pkgcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["pkgcode"].Value = pkgcode;

                //objSqlCommand.Parameters.Add("gridins", MySqlDbType.Double);
                //objSqlCommand.Parameters["gridins"].Value = gridins;

                objSqlCommand.Parameters.Add("gridins", MySqlDbType.Double);
                if (gridins == "" || gridins == null)
                {
                    objSqlCommand.Parameters["gridins"].Value = Convert.ToDouble("0");
                }
                else
                {
                    objSqlCommand.Parameters["gridins"].Value = Convert.ToDouble(gridins);
                }

                objSqlCommand.Parameters.Add("pkgalias", MySqlDbType.VarChar);
                objSqlCommand.Parameters["pkgalias"].Value = pkgalias;

                // --//0000000000000000000000000000000000000000000000000000000

                objSqlCommand.Parameters.Add("cirvts", MySqlDbType.VarChar);
                objSqlCommand.Parameters["cirvts"].Value = cirvts;

                objSqlCommand.Parameters.Add("cirpub", MySqlDbType.VarChar);
                objSqlCommand.Parameters["cirpub"].Value = cirpub;

                objSqlCommand.Parameters.Add("ciredi", MySqlDbType.VarChar);
                objSqlCommand.Parameters["ciredi"].Value = ciredi;

                objSqlCommand.Parameters.Add("cirrate", MySqlDbType.VarChar);
                objSqlCommand.Parameters["cirrate"].Value = cirrate;

                //objSqlCommand.Parameters.Add("cirdate_v", MySqlDbType.DateTime);
                //objSqlCommand.Parameters["cirdate_v"].Value = cirdate;

                objSqlCommand.Parameters.Add("cirdate_v", MySqlDbType.DateTime);
                if (cirdate == "" || cirdate == null)
                {
                    objSqlCommand.Parameters["cirdate_v"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "mm/dd/yyyy" && repeat != "")
                    {
                        string[] arr = null;
                        arr = cirdate.Split("/".ToCharArray());
                        cirdate = arr[0] + "-" + arr[1] + "-" + arr[2];

                    }
                    if (dateformat == "dd/mm/yyyy" && repeat != "")
                    {
                        string[] arr = null;
                        arr = cirdate.Split("/".ToCharArray());
                        cirdate = arr[1] + "-" + arr[0] + "-" + arr[2];

                    }
                    if (dateformat == "yyyy/mm/dd" && repeat != "")
                    {
                        string[] arr = null;
                        arr = cirdate.Split("/".ToCharArray());
                        cirdate = arr[1] + "-" + arr[2] + "-" + arr[0];

                    }
                    objSqlCommand.Parameters["cirdate_v"].Value = Convert.ToDateTime(cirdate).ToString("yyyy-MM-dd");
                }


                objSqlCommand.Parameters.Add("ciragency_v", MySqlDbType.VarChar);
                objSqlCommand.Parameters["ciragency_v"].Value = ciragency;

                objSqlCommand.Parameters.Add("ciragencysubcode_v", MySqlDbType.VarChar);
                objSqlCommand.Parameters["ciragencysubcode_v"].Value = ciragencysubcode;

                objSqlCommand.Parameters.Add("center_v", MySqlDbType.VarChar);
                objSqlCommand.Parameters["center_v"].Value = center;

                objSqlCommand.Parameters.Add("branch_v", MySqlDbType.VarChar);
                objSqlCommand.Parameters["branch_v"].Value = branch;

                objSqlCommand.Parameters.Add("splitdata_v", MySqlDbType.VarChar);
                objSqlCommand.Parameters["splitdata_v"].Value = splitdata;

                objSqlCommand.Parameters.Add("subedidata", MySqlDbType.VarChar);
                objSqlCommand.Parameters["subedidata"].Value = subedidata;

                objSqlCommand.Parameters.Add("splboldsizevalue", MySqlDbType.VarChar);
                objSqlCommand.Parameters["splboldsizevalue"].Value = undef1;

                //objSqlCommand.Parameters.Add("vatrate_p", MySqlDbType.Double);
                //objSqlCommand.Parameters["vatrate_p"].Value = vatrate;

                objSqlCommand.Parameters.Add("vatrate_p", MySqlDbType.Double);
                if (vatrate == "" || vatrate == null || vatrate == "null")
                {
                    objSqlCommand.Parameters["vatrate_p"].Value = Convert.ToDouble("0");
                }
                else
                {
                    objSqlCommand.Parameters["vatrate_p"].Value = Convert.ToDouble(vatrate);
                }


                //objSqlCommand.Parameters.Add("boxcharge_p", MySqlDbType.Double);
                //objSqlCommand.Parameters["boxcharge_p"].Value = boxcharge;

                objSqlCommand.Parameters.Add("boxcharge_p", MySqlDbType.Double);
                if (boxcharge == "" || boxcharge == null || boxcharge == "null")
                {
                    objSqlCommand.Parameters["boxcharge_p"].Value = Convert.ToDouble("0");
                }
                else
                {
                    objSqlCommand.Parameters["boxcharge_p"].Value = Convert.ToDouble(boxcharge);
                }


                objSqlCommand.Parameters.Add("vat_inc_p", MySqlDbType.VarChar);
                objSqlCommand.Parameters["vat_inc_p"].Value = vat_inc_p;

                // ---------------------

                objSqlCommand.Parameters.Add("grossamtlocal_p", MySqlDbType.VarChar);
                objSqlCommand.Parameters["grossamtlocal_p"].Value = grossamtlocal_p;

                objSqlCommand.Parameters.Add("billamtlocal_p", MySqlDbType.VarChar);
                objSqlCommand.Parameters["billamtlocal_p"].Value = billamtlocal_p;

                objSqlCommand.Parameters.Add("sectioncode_p", MySqlDbType.VarChar);
                objSqlCommand.Parameters["sectioncode_p"].Value = sectioncode_p;

                objSqlCommand.Parameters.Add("resourceno_p", MySqlDbType.VarChar);
                objSqlCommand.Parameters["resourceno_p"].Value = resourceno_p;

                objSqlCommand.Parameters.Add("caption_inserts_p", MySqlDbType.VarChar);
                objSqlCommand.Parameters["caption_inserts_p"].Value = caption_inserts;

                //objSqlCommand.Parameters.Add("dealerheight", MySqlDbType.Double);
                //objSqlCommand.Parameters["dealerheight"].Value = dealerheight;

                objSqlCommand.Parameters.Add("dealerheight", MySqlDbType.Double);
                if (dealerheight == "" || dealerheight == null || dealerheight == "null")
                {
                    objSqlCommand.Parameters["dealerheight"].Value = Convert.ToDouble("0");
                }
                else
                {
                    objSqlCommand.Parameters["dealerheight"].Value = Convert.ToDouble(dealerheight);
                }

                //objSqlCommand.Parameters.Add("dealerwidth", MySqlDbType.Double);
                //objSqlCommand.Parameters["dealerwidth"].Value = dealerwidth;

                objSqlCommand.Parameters.Add("dealerwidth", MySqlDbType.Double);
                if (dealerwidth == "" || dealerwidth == null || dealerwidth == "null")
                {
                    objSqlCommand.Parameters["dealerwidth"].Value = Convert.ToDouble("0");
                }
                else
                {
                    objSqlCommand.Parameters["dealerwidth"].Value = Convert.ToDouble(dealerwidth);
                }

                //objSqlCommand.Parameters.Add("disc_p", MySqlDbType.Double);
                //objSqlCommand.Parameters["disc_p"].Value = disc_;

                objSqlCommand.Parameters.Add("disc_p", MySqlDbType.Double);
                if (disc_ == "" || disc_ == null || disc_ == "null")
                {
                    objSqlCommand.Parameters["disc_p"].Value = Convert.ToDouble("0");
                }
                else
                {
                    objSqlCommand.Parameters["disc_p"].Value = Convert.ToDouble(disc_);
                }

                objSqlCommand.Parameters.Add("agncyamnt", MySqlDbType.VarChar);
                objSqlCommand.Parameters["agncyamnt"].Value = agncyamnt;

                objSqlCommand.Parameters.Add("adlgncyamnt", MySqlDbType.VarChar);
                objSqlCommand.Parameters["adlgncyamnt"].Value = adlgncyamnt;

                objSqlCommand.Parameters.Add("spldiscamt", MySqlDbType.VarChar);
                objSqlCommand.Parameters["spldiscamt"].Value = spldisc;

                objSqlCommand.Parameters.Add("cashdamnt", MySqlDbType.VarChar);
                objSqlCommand.Parameters["cashdamnt"].Value = cashdisc;

                //objSqlCommand.Parameters.Add("roundoff", MySqlDbType.Double);
                //objSqlCommand.Parameters["roundoff"].Value = roundoffamt;

                objSqlCommand.Parameters.Add("roundoff", MySqlDbType.Double);
                if (roundoffamt == "" || roundoffamt == null || roundoffamt == "null")
                {
                    objSqlCommand.Parameters["roundoff"].Value = Convert.ToDouble("0");
                }
                else
                {
                    objSqlCommand.Parameters["roundoff"].Value = Convert.ToDouble(roundoffamt);
                }

                //objSqlCommand.Parameters.Add("pdfheight", MySqlDbType.Double);
                //objSqlCommand.Parameters["pdfheight"].Value = pdfheight;

                objSqlCommand.Parameters.Add("pdfheight", MySqlDbType.Double);
                if (pdfheight == "" || pdfheight == null || pdfheight == "null")
                {
                    objSqlCommand.Parameters["pdfheight"].Value = Convert.ToDouble("0");
                }
                else
                {
                    objSqlCommand.Parameters["pdfheight"].Value = Convert.ToDouble(pdfheight);
                }

                //objSqlCommand.Parameters.Add("cpnamt", MySqlDbType.Double);
                //objSqlCommand.Parameters["cpnamt"].Value = cpnamt;

                objSqlCommand.Parameters.Add("cpnamt", MySqlDbType.Double);
                if (cpnamt == "" || cpnamt == null || cpnamt == "null")
                {
                    objSqlCommand.Parameters["cpnamt"].Value = Convert.ToDouble("0");
                }
                else
                {
                    objSqlCommand.Parameters["cpnamt"].Value = Convert.ToDouble(cpnamt);
                }

                //objSqlCommand.Parameters.Add("clientcatamt", MySqlDbType.Double);
                //objSqlCommand.Parameters["clientcatamt"].Value = clicatamt;

                objSqlCommand.Parameters.Add("clientcatamt", MySqlDbType.Double);
                if (clicatamt == "" || clicatamt == null || clicatamt == "null")
                {
                    objSqlCommand.Parameters["clientcatamt"].Value = Convert.ToDouble("0");
                }
                else
                {
                    objSqlCommand.Parameters["clientcatamt"].Value = Convert.ToDouble(clicatamt);
                }

                //objSqlCommand.Parameters.Add("flatfreqamt", MySqlDbType.Double);
                //objSqlCommand.Parameters["flatfreqamt"].Value = flatfreqamt;

                objSqlCommand.Parameters.Add("flatfreqamt", MySqlDbType.Double);
                if (flatfreqamt == "" || flatfreqamt == null || flatfreqamt == "null")
                {
                    objSqlCommand.Parameters["flatfreqamt"].Value = Convert.ToDouble("0");
                }
                else
                {
                    objSqlCommand.Parameters["flatfreqamt"].Value = Convert.ToDouble(flatfreqamt);
                }

                //objSqlCommand.Parameters.Add("catamt", MySqlDbType.Double);
                //objSqlCommand.Parameters["catamt"].Value = catamt;

                objSqlCommand.Parameters.Add("catamt", MySqlDbType.Double);
                if (catamt == "" || catamt == null || catamt == "null")
                {
                    objSqlCommand.Parameters["catamt"].Value = Convert.ToDouble("0");
                }
                else
                {
                    objSqlCommand.Parameters["catamt"].Value = Convert.ToDouble(catamt);
                }

                //objSqlCommand.Parameters.Add("extrarate", MySqlDbType.Double);
                //objSqlCommand.Parameters["extrarate"].Value = undef2;

                objSqlCommand.Parameters.Add("extrarate", MySqlDbType.Double);
                if (undef2 == "" || undef2 == null || undef2 == "null")
                {
                    objSqlCommand.Parameters["extrarate"].Value = Convert.ToDouble("0");
                }
                else
                {
                    objSqlCommand.Parameters["extrarate"].Value = Convert.ToDouble(undef2);
                }

                //objSqlCommand.Parameters.Add("premamtval", MySqlDbType.Double);
                //objSqlCommand.Parameters["premamtval"].Value = premamtval;

                objSqlCommand.Parameters.Add("premamtval", MySqlDbType.Double);
                if (premamtval == "" || premamtval == null || premamtval == "null")
                {
                    objSqlCommand.Parameters["premamtval"].Value = Convert.ToDouble("0");
                }
                else
                {
                    objSqlCommand.Parameters["premamtval"].Value = Convert.ToDouble(premamtval);
                }

                //objSqlCommand.Parameters.Add("peyecather", MySqlDbType.Double);
                //objSqlCommand.Parameters["peyecather"].Value = undef3;

                objSqlCommand.Parameters.Add("peyecather", MySqlDbType.Double);
                if (undef3 == "" || undef3 == null || undef3 == "null")
                {
                    objSqlCommand.Parameters["peyecather"].Value = Convert.ToDouble("0");
                }
                else
                {
                    objSqlCommand.Parameters["peyecather"].Value = Convert.ToDouble(undef3);
                }

                //objSqlCommand.Parameters.Add("pdaywisepr", MySqlDbType.Double);
                //objSqlCommand.Parameters["pdaywisepr"].Value = undef4;

                objSqlCommand.Parameters.Add("pdaywisepr", MySqlDbType.Double);
                if (undef4 == "" || undef4 == null || undef4 == "null")
                {
                    objSqlCommand.Parameters["pdaywisepr"].Value = Convert.ToDouble("0");
                }
                else
                {
                    objSqlCommand.Parameters["pdaywisepr"].Value = Convert.ToDouble(undef4);
                }

                objSqlCommand.Parameters.Add("pgstamt", MySqlDbType.Double);
                if (gstamount == "" || gstamount == null || gstamount == "null")
                {
                    objSqlCommand.Parameters["pgstamt"].Value = Convert.ToDouble("0");
                }
                else
                {
                    objSqlCommand.Parameters["pgstamt"].Value = Convert.ToDouble(gstamount);
                }

                objSqlCommand.Parameters.Add("pgstgd", MySqlDbType.VarChar);
                objSqlCommand.Parameters["pgstgd"].Value = gstgrid;

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

        public DataSet forwalkclient(string client, string compcode)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("chkforwalkinnclient", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("client1", MySqlDbType.VarChar);
                objSqlCommand.Parameters["client1"].Value = client;


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

        //public DataSet prevbooking(string compcode, string userid,string formname)
        //{
        //    MySqlConnection objSqlConnection;
        //    MySqlCommand objSqlCommand;
        //    objSqlConnection = GetConnection();
        //    MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
        //    DataSet objDataSet = new DataSet();
        //    try
        //    {
        //        objSqlConnection.Open();
        //        objSqlCommand = GetCommand("gettheprevbooking", ref objSqlConnection);
        //        objSqlCommand.CommandType = CommandType.StoredProcedure;
        //        objSqlCommand.Parameters.Add("userid", MySqlDbType.VarChar);
        //        objSqlCommand.Parameters["userid"].Value = userid;
        //        objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
        //        objSqlCommand.Parameters["compcode"].Value = compcode;
        //        objSqlCommand.Parameters.Add("formname", MySqlDbType.VarChar);
        //        objSqlCommand.Parameters["formname"].Value = formname;

        //         objSqlDataAdapter.SelectCommand = objSqlCommand;
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

        public DataSet prevbooking(string compcode, string userid, string formname)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("gettheprevbooking_gettheprevbooking_p", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("vuserid", MySqlDbType.VarChar);
                objSqlCommand.Parameters["vuserid"].Value = userid;
                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("formname", MySqlDbType.VarChar);
                objSqlCommand.Parameters["formname"].Value = formname;


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


        public DataSet fetchdataforexe(string ciobid, string compcode)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getdataforexecute", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("ciobid", MySqlDbType.VarChar);
                objSqlCommand.Parameters["ciobid"].Value = ciobid;

                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;

                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                //if (objDataSet.Tables[0].Rows.Count > 0)
                //{
                //    zonename = objDataSet.Tables[0].Rows[0].ItemArray[0].ToString();
                //}
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

        public DataSet getagencyname(string agency, string compcode, string product, string execname)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {

                objSqlConnection.Open();
                objSqlCommand = GetCommand("chkagen_prod_exec", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("agency", MySqlDbType.VarChar);
                objSqlCommand.Parameters["agency"].Value = agency;

                objSqlCommand.Parameters.Add("product", MySqlDbType.VarChar);
                objSqlCommand.Parameters["product"].Value = product;

                objSqlCommand.Parameters.Add("execname", MySqlDbType.VarChar);
                objSqlCommand.Parameters["execname"].Value = execname;

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

        public DataSet getpageamt(string pagecode, string compcode)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getpageamount", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("pagecode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["pagecode"].Value = pagecode;

                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;

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

        public DataSet packagebindforexebook(string compcode, string pckcode)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getpckexebook", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("pckcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["pckcode"].Value = pckcode;


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


        public DataSet getdealvalue(string compcode, string agencysplit, string subagencycode, string bookingdate, string color, string curr, string adcat, string clientsplit, string prod, string col, string code, string rate_cod, string adtype, string totalarea, string dealtype)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("BOOKING_GETDEAL_DUMMY_booking_getdeal_dummy_p", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("agencysplit", MySqlDbType.VarChar);
                objSqlCommand.Parameters["agencysplit"].Value = agencysplit;

                objSqlCommand.Parameters.Add("subagencycode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["subagencycode"].Value = subagencycode;

                objSqlCommand.Parameters.Add("bookingdate", MySqlDbType.VarChar);
                objSqlCommand.Parameters["bookingdate"].Value = bookingdate;

                objSqlCommand.Parameters.Add("color", MySqlDbType.VarChar);
                objSqlCommand.Parameters["color"].Value = color;

                objSqlCommand.Parameters.Add("curr", MySqlDbType.VarChar);
                objSqlCommand.Parameters["curr"].Value = curr;

                objSqlCommand.Parameters.Add("adcat1", MySqlDbType.VarChar);
                objSqlCommand.Parameters["adcat1"].Value = adcat;

                objSqlCommand.Parameters.Add("clientsplit", MySqlDbType.VarChar);
                objSqlCommand.Parameters["clientsplit"].Value = clientsplit;

                objSqlCommand.Parameters.Add("prod", MySqlDbType.VarChar);
                objSqlCommand.Parameters["prod"].Value = prod;

                objSqlCommand.Parameters.Add("col", MySqlDbType.VarChar);
                objSqlCommand.Parameters["col"].Value = col;

                objSqlCommand.Parameters.Add("code", MySqlDbType.VarChar);
                objSqlCommand.Parameters["code"].Value = code;

                objSqlCommand.Parameters.Add("rate_cod", MySqlDbType.VarChar);
                objSqlCommand.Parameters["rate_cod"].Value = rate_cod;

                objSqlCommand.Parameters.Add("adtype1", MySqlDbType.VarChar);
                objSqlCommand.Parameters["adtype1"].Value = adtype;

                objSqlCommand.Parameters.Add("totalarea", MySqlDbType.VarChar);
                objSqlCommand.Parameters["totalarea"].Value = totalarea;

                objSqlCommand.Parameters.Add("dealtype", MySqlDbType.VarChar);
                objSqlCommand.Parameters["dealtype"].Value = dealtype;

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

        public DataSet booking_getdealdisc(string dealcode, string compcode, string agencysplit, string subagency, string clientsplit)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("booking_getdeealdisc", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("agencysplit", MySqlDbType.VarChar);
                objSqlCommand.Parameters["agencysplit"].Value = agencysplit;

                objSqlCommand.Parameters.Add("subagency", MySqlDbType.VarChar);
                objSqlCommand.Parameters["subagency"].Value = subagency;

                objSqlCommand.Parameters.Add("dealcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["dealcode"].Value = dealcode;

                objSqlCommand.Parameters.Add("clientsplit", MySqlDbType.VarChar);
                objSqlCommand.Parameters["clientsplit"].Value = clientsplit;




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

        public DataSet schemebind(string compcode)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("bindscheme", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;







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

        public DataSet getschemedisc(string schemcode, string compcode, string noofinsert)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("booking_getschdisc", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("schemcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["schemcode"].Value = schemcode;

                objSqlCommand.Parameters.Add("noofinsert", MySqlDbType.VarChar);
                objSqlCommand.Parameters["noofinsert"].Value = noofinsert;



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

        public DataSet deleteid(string ciobookid, string compcode)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("deletecioid", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("ciobookid", MySqlDbType.VarChar);
                objSqlCommand.Parameters["ciobookid"].Value = ciobookid;

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

        public DataSet bindvarient(string brand, string Compcode)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("AN_BRANDVARIENT", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = Compcode;

                objSqlCommand.Parameters.Add("brand", MySqlDbType.VarChar);
                objSqlCommand.Parameters["brand"].Value = brand;
                
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

        public DataSet bindsubagency(string agency, string compcode)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("book_bindsubagency_book_bindsubagency_p", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;
                
                objSqlCommand.Parameters.Add("agency", MySqlDbType.VarChar);
                objSqlCommand.Parameters["agency"].Value = agency;
                
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

        public DataSet getbillval(string agency, string compcode)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("book_bindbillto", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("agency", MySqlDbType.VarChar);
                objSqlCommand.Parameters["agency"].Value = agency;

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

        public DataSet chkclient(string client, string compcode)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("book_chkcasualclient", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;
                
                objSqlCommand.Parameters.Add("client1", MySqlDbType.VarChar);
                objSqlCommand.Parameters["client1"].Value = client;

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

        public DataSet getinsertsche(string schemecode, string compcode)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("book_getinsertscheme", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("schemecode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["schemecode"].Value = schemecode;

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
        public DataSet book_packagename(string value, string compcode)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("book_packagename", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                
                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("value1", MySqlDbType.VarChar);
                objSqlCommand.Parameters["value1"].Value = value;

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

        public DataSet book_chkpublishday(string value, string compcode, string pkgname, string dateday, string dateformat, string adcat, string adtype, string center, string pkgid, string pkgalias)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("book_chkpublishday", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("value1", MySqlDbType.VarChar);
                objSqlCommand.Parameters["value1"].Value = value;

                objSqlCommand.Parameters.Add("pkgname", MySqlDbType.VarChar);
                objSqlCommand.Parameters["pkgname"].Value = pkgname;

                objSqlCommand.Parameters.Add("dateday", MySqlDbType.Datetime);
                if (dateformat == "mm/dd/yyyy" && dateday != "")
                {
                    string[] arr = null;
                    arr = dateday.Split("/".ToCharArray());
                    dateday = arr[2] + "-" + arr[0] + "-" + arr[1];

                }
                if (dateformat == "dd/mm/yyyy" && dateday != "")
                {
                    string[] arr = null;
                    arr = dateday.Split("/".ToCharArray());
                    dateday = arr[2] + "-" + arr[1] + "-" + arr[0];

                }
                if (dateformat == "yyyy/mm/dd" && dateday != "")
                {
                    string[] arr = null;
                    arr = dateday.Split("/".ToCharArray());
                    dateday = arr[0] + "-" + arr[1] + "-" + arr[2];

                }
                if (dateday != "")
                {
                    objSqlCommand.Parameters["dateday"].Value = Convert.ToDateTime(dateday).ToString("yyyy-MM-dd");
                }
                else
                {
                    objSqlCommand.Parameters["dateday"].Value = System.DBNull.Value;
                }
                // adcat,string adtype,string center,string pkgid,string pkgalias
                objSqlCommand.Parameters.Add("adcat", MySqlDbType.VarChar);
                objSqlCommand.Parameters["adcat"].Value = adcat;

                objSqlCommand.Parameters.Add("adtype1", MySqlDbType.VarChar);
                objSqlCommand.Parameters["adtype1"].Value = adtype;

                objSqlCommand.Parameters.Add("center", MySqlDbType.VarChar);
                objSqlCommand.Parameters["center"].Value = center;

                objSqlCommand.Parameters.Add("pkgid", MySqlDbType.VarChar);
                objSqlCommand.Parameters["pkgid"].Value = pkgid;

                objSqlCommand.Parameters.Add("pkgalias", MySqlDbType.VarChar);
                objSqlCommand.Parameters["pkgalias"].Value = pkgalias;

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
        public DataSet getname(string curr, string compcode)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); ;
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("book_getcurrname", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("curr", MySqlDbType.VarChar);
                objSqlCommand.Parameters["curr"].Value = curr;
                
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

        ///////////////these are the class file used in classified booking form]

        public DataSet getvalfromadcat3(string adcat, string compcode, string value)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("class_bindadcat3", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("adcat", MySqlDbType.VarChar);
                objSqlCommand.Parameters["adcat"].Value = adcat;

                objSqlCommand.Parameters.Add("value1", MySqlDbType.VarChar);
                objSqlCommand.Parameters["value1"].Value = value;

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

        public DataSet bgcolorbind(string compcode, string value)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("class_bindbgcolor", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("value1", MySqlDbType.VarChar);
                objSqlCommand.Parameters["value1"].Value = value;

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

        public DataSet advdatacategory(string compcode, string booking)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {

                objSqlConnection.Open();
                objSqlCommand = GetCommand("book_advcategory1_book_advcategory1_p", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("booking", MySqlDbType.VarChar);
                objSqlCommand.Parameters["booking"].Value = booking;

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

        public DataSet chkfilename(string cioid, string compcode)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("book_getfilename", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("ciobookid", MySqlDbType.VarChar);
                objSqlCommand.Parameters["ciobookid"].Value = cioid;

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

        public DataSet getPkgDetail(string pkgname)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {

                objSqlConnection.Open();
                objSqlCommand = GetCommand("getPackageName", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("pkgcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["pkgcode"].Value = pkgname;

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

        public DataSet getrotime(string Rohours, string Romin, string compcode, string publishdate, string packagename)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("book_chkrotime", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("Rohours", MySqlDbType.VarChar);
                objSqlCommand.Parameters["Rohours"].Value = Rohours;

                objSqlCommand.Parameters.Add("Romin", MySqlDbType.VarChar);
                objSqlCommand.Parameters["Romin"].Value = Romin;

                objSqlCommand.Parameters.Add("publishdate", MySqlDbType.VarChar);
                objSqlCommand.Parameters["publishdate"].Value = publishdate;

                objSqlCommand.Parameters.Add("packagename", MySqlDbType.VarChar);
                objSqlCommand.Parameters["packagename"].Value = packagename;

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

        public DataSet book_bindpagetyp(string compcode)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("book_bindpagetyp", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                
                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;
                
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

        public DataSet chkforspace(string page_no, string edit_name, string edit_date, string compcode, string nopag)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("book_chkspace", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("page_no", MySqlDbType.VarChar);
                objSqlCommand.Parameters["page_no"].Value = page_no;

                objSqlCommand.Parameters.Add("edit_name", MySqlDbType.VarChar);
                objSqlCommand.Parameters["edit_name"].Value = edit_name;

                objSqlCommand.Parameters.Add("edit_date", MySqlDbType.VarChar);
                objSqlCommand.Parameters["edit_date"].Value = edit_date;

                objSqlCommand.Parameters.Add("nopag", MySqlDbType.VarChar);
                objSqlCommand.Parameters["nopag"].Value = nopag;
                
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
        public DataSet advdatasubcatcat(string compcode, string catcode, string agencytype)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {

                objSqlConnection.Open();
                objSqlCommand = GetCommand("book_advsubcattyp", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("agencytype", MySqlDbType.VarChar);
                objSqlCommand.Parameters["agencytype"].Value = agencytype;

                objSqlCommand.Parameters.Add("catcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["catcode"].Value = catcode;

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

        public DataSet getInsertion_classified(string package, string noofinsertion, string insertiondate, string startdate, string dateformat, string compcode, string adcategory, string adsubcat, string color, string adtype, string currency, string ratecode, string clickdate, string flag, string code, string pck, string uom, string dealrate, string checkforor, string classinserts, string lines, string adcat3, string adcat4, string adcat5, string clientcode, string userid, string center)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("qbc_getinsertion", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("package", MySqlDbType.VarChar);
                objSqlCommand.Parameters["package"].Value = package;

                objSqlCommand.Parameters.Add("noofinsertion", MySqlDbType.VarChar);
                objSqlCommand.Parameters["noofinsertion"].Value = noofinsertion;

                objSqlCommand.Parameters.Add("insertiondate", MySqlDbType.VarChar);
                objSqlCommand.Parameters["insertiondate"].Value = insertiondate;

                objSqlCommand.Parameters.Add("startdate", MySqlDbType.Datetime);
                objSqlCommand.Parameters["startdate"].Value = startdate;

                objSqlCommand.Parameters.Add("dateformat", MySqlDbType.VarChar);
                objSqlCommand.Parameters["dateformat"].Value = dateformat;

                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("adcategory", MySqlDbType.VarChar);
                objSqlCommand.Parameters["adcategory"].Value = adcategory;

                objSqlCommand.Parameters.Add("adsubcat", MySqlDbType.VarChar);
                objSqlCommand.Parameters["adsubcat"].Value = adsubcat;

                objSqlCommand.Parameters.Add("color", MySqlDbType.VarChar);
                objSqlCommand.Parameters["color"].Value = color;

                objSqlCommand.Parameters.Add("adtype", MySqlDbType.VarChar);
                objSqlCommand.Parameters["adtype"].Value = adtype;

                objSqlCommand.Parameters.Add("currency", MySqlDbType.VarChar);
                objSqlCommand.Parameters["currency"].Value = currency;

                objSqlCommand.Parameters.Add("ratecode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["ratecode"].Value = ratecode;

                objSqlCommand.Parameters.Add("clickdate", MySqlDbType.VarChar);
                objSqlCommand.Parameters["clickdate"].Value = clickdate;

                objSqlCommand.Parameters.Add("flag", MySqlDbType.Int64);
                if (flag == "" || flag == null)
                {
                    objSqlCommand.Parameters["flag"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["flag"].Value = Convert.ToInt32(flag);
                }

                objSqlCommand.Parameters.Add("code1", MySqlDbType.VarChar);
                objSqlCommand.Parameters["code1"].Value = code;

                objSqlCommand.Parameters.Add("pck", MySqlDbType.Decimal);
                if (pck == "" || pck == null)
                {
                    objSqlCommand.Parameters["pck"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["pck"].Value = Convert.ToDecimal(pck);
                }

                objSqlCommand.Parameters.Add("uom", MySqlDbType.VarChar);
                objSqlCommand.Parameters["uom"].Value = uom;

                objSqlCommand.Parameters.Add("dealrate", MySqlDbType.Decimal);
                if (dealrate == "" || dealrate == null)
                {
                    objSqlCommand.Parameters["dealrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["dealrate"].Value = Convert.ToDecimal(dealrate);
                }

                objSqlCommand.Parameters.Add("checkforor", MySqlDbType.VarChar);
                objSqlCommand.Parameters["checkforor"].Value = checkforor;

                objSqlCommand.Parameters.Add("classinserts", MySqlDbType.VarChar);
                objSqlCommand.Parameters["classinserts"].Value = classinserts;

                objSqlCommand.Parameters.Add("lines1", MySqlDbType.VarChar);
                objSqlCommand.Parameters["lines1"].Value = lines;

                objSqlCommand.Parameters.Add("adcat3", MySqlDbType.VarChar);
                if (adcat3 == "")
                {
                    objSqlCommand.Parameters["adcat3"].Value = "0";
                }
                else
                {
                    objSqlCommand.Parameters["adcat3"].Value = adcat3;
                }
                objSqlCommand.Parameters.Add("adcat4", MySqlDbType.VarChar);
                if (adcat4 == "")
                {
                    objSqlCommand.Parameters["adcat4"].Value = "0";
                }
                else
                {
                    objSqlCommand.Parameters["adcat4"].Value = adcat4;
                }
                objSqlCommand.Parameters.Add("adcat5", MySqlDbType.VarChar);
                if (adcat5 == "")
                {

                    objSqlCommand.Parameters["adcat5"].Value = "0";
                }
                else
                {
                    objSqlCommand.Parameters["adcat5"].Value = adcat5;
                }

                //objSqlCommand.Parameters.Add("userid", MySqlDbType.VarChar);
                //objSqlCommand.Parameters["userid"].Value = userid;

                objSqlCommand.Parameters.Add("clientcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["clientcode"].Value = clientcode;

                //objSqlCommand.Parameters.Add("center", MySqlDbType.VarChar);
                //objSqlCommand.Parameters["center"].Value = center;


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
        public DataSet getInsertion_qbc(string package, string noofinsertion, string insertiondate, string startdate, string dateformat, string compcode, string adcategory, string adsubcat, string color, string adtype, string currency, string ratecode, string clickdate, string flag, string code, string pck, string uom, string dealrate, string checkforor, string classinserts, string lines, string adcat3, string adcat4, string adcat5, string clientcode) //,string uomdesc,string agencycode)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("qbc_getinsertion", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("package", MySqlDbType.VarChar);
                objSqlCommand.Parameters["package"].Value = package;

                objSqlCommand.Parameters.Add("noofinsertion", MySqlDbType.VarChar);
                objSqlCommand.Parameters["noofinsertion"].Value = noofinsertion;

                objSqlCommand.Parameters.Add("insertiondate", MySqlDbType.VarChar);
                objSqlCommand.Parameters["insertiondate"].Value = insertiondate;

                objSqlCommand.Parameters.Add("startdate", MySqlDbType.VarChar);
                if (startdate == "")
                {
                    objSqlCommand.Parameters["startdate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "mm/dd/yyyy" && startdate != "")
                    {
                        string[] arr = null;
                        arr = startdate.Split("/".ToCharArray());
                        startdate = arr[2] + "-" + arr[0] + "-" + arr[1];

                    }
                    if (dateformat == "dd/mm/yyyy" && startdate != "")
                    {
                        string[] arr = null;
                        arr = startdate.Split("/".ToCharArray());
                        startdate = arr[2] + "-" + arr[1] + "-" + arr[0];

                    }
                    if (dateformat == "yyyy/mm/dd" && startdate != "")
                    {
                        string[] arr = null;
                        arr = startdate.Split("/".ToCharArray());
                        startdate = arr[0] + "-" + arr[1] + "-" + arr[2];

                    }
                    objSqlCommand.Parameters["startdate"].Value = startdate;
                }


                objSqlCommand.Parameters.Add("dateformat", MySqlDbType.VarChar);
                objSqlCommand.Parameters["dateformat"].Value = dateformat;

                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("adcategory", MySqlDbType.VarChar);
                objSqlCommand.Parameters["adcategory"].Value = adcategory;

                objSqlCommand.Parameters.Add("adsubcat", MySqlDbType.VarChar);
                objSqlCommand.Parameters["adsubcat"].Value = adsubcat;

                objSqlCommand.Parameters.Add("color", MySqlDbType.VarChar);
                objSqlCommand.Parameters["color"].Value = color;

                objSqlCommand.Parameters.Add("adtype", MySqlDbType.VarChar);
                objSqlCommand.Parameters["adtype"].Value = adtype;

                objSqlCommand.Parameters.Add("currency", MySqlDbType.VarChar);
                objSqlCommand.Parameters["currency"].Value = currency;

                objSqlCommand.Parameters.Add("ratecode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["ratecode"].Value = ratecode;

                objSqlCommand.Parameters.Add("clickdate", MySqlDbType.VarChar);
                if (clickdate == "")
                {
                    objSqlCommand.Parameters["clickdate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "mm/dd/yyyy" && clickdate != "")
                    {
                        string[] arr = null;
                        arr = clickdate.Split("/".ToCharArray());
                        clickdate = arr[2] + "-" + arr[0] + "-" + arr[1];

                    }
                    else if (dateformat == "dd/mm/yyyy" && clickdate != "")
                    {
                        string[] arr = null;
                        arr = clickdate.Split("/".ToCharArray());
                        clickdate = arr[2] + "-" + arr[1] + "-" + arr[0];

                    }
                    else if (dateformat == "yyyy/mm/dd" && clickdate != "")
                    {
                        string[] arr = null;
                        arr = clickdate.Split("/".ToCharArray());
                        clickdate = arr[0] + "-" + arr[1] + "-" + arr[2];

                    }
                    objSqlCommand.Parameters["clickdate"].Value = clickdate;
                }
                objSqlCommand.Parameters.Add("flag", MySqlDbType.Int64);
                if (flag == "" || flag == null)
                {
                    objSqlCommand.Parameters["flag"].Value = 0;//System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["flag"].Value = Convert.ToInt32(flag);
                }

                objSqlCommand.Parameters.Add("code1", MySqlDbType.VarChar);
                objSqlCommand.Parameters["code1"].Value = code;

                objSqlCommand.Parameters.Add("pck", MySqlDbType.Decimal);
                if (pck == "" || pck == null)
                {
                    objSqlCommand.Parameters["pck"].Value = 0;//System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["pck"].Value = Convert.ToDecimal(pck);
                }

                objSqlCommand.Parameters.Add("uom", MySqlDbType.VarChar);
                objSqlCommand.Parameters["uom"].Value = uom;

                objSqlCommand.Parameters.Add("dealrate", MySqlDbType.Decimal);
                if (dealrate == "" || dealrate == null)
                {
                    objSqlCommand.Parameters["dealrate"].Value = 0;//System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["dealrate"].Value = Convert.ToDecimal(dealrate);
                }

                objSqlCommand.Parameters.Add("checkforor", MySqlDbType.VarChar);
                objSqlCommand.Parameters["checkforor"].Value = checkforor;

                objSqlCommand.Parameters.Add("classinserts", MySqlDbType.VarChar);
                objSqlCommand.Parameters["classinserts"].Value = classinserts;

                objSqlCommand.Parameters.Add("lines1", MySqlDbType.VarChar);
                objSqlCommand.Parameters["lines1"].Value = lines;

                objSqlCommand.Parameters.Add("adcat3", MySqlDbType.VarChar);
                if (adcat3 == "")
                {
                    objSqlCommand.Parameters["adcat3"].Value = "0";
                }
                else
                {
                    objSqlCommand.Parameters["adcat3"].Value = adcat3;
                }
                objSqlCommand.Parameters.Add("adcat4", MySqlDbType.VarChar);
                if (adcat4 == "")
                {
                    objSqlCommand.Parameters["adcat4"].Value = "0";
                }
                else
                {
                    objSqlCommand.Parameters["adcat4"].Value = adcat4;
                }
                objSqlCommand.Parameters.Add("adcat5", MySqlDbType.VarChar);
                if (adcat5 == "")
                {

                    objSqlCommand.Parameters["adcat5"].Value = "0";
                }
                else
                {
                    objSqlCommand.Parameters["adcat5"].Value = adcat5;
                }

                objSqlCommand.Parameters.Add("clientcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["clientcode"].Value = clientcode;

                //objSqlCommand.Parameters.Add("uomdesc", MySqlDbType.VarChar);
                //objSqlCommand.Parameters["uomdesc"].Value = uomdesc;

                //objSqlCommand.Parameters.Add("agencycode", MySqlDbType.VarChar);
                //objSqlCommand.Parameters["agencycode"].Value = agencycode;

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

        public DataSet getInsertion_classified_fillgrid(string package, string noofinsertion, string insertiondate, string startdate, string dateformat, string compcode, string adcategory, string adsubcat, string color, string adtype, string currency, string ratecode, string clickdate, string flag, string code, string pck, string uom, string dealrate, string checkforor, string classinserts, string lines, string adcat3, string adcat4, string adcat5, string clientcode)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("bindClassifiedInsertion_temp", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("package", MySqlDbType.VarChar);
                objSqlCommand.Parameters["package"].Value = package;

                objSqlCommand.Parameters.Add("noofinsertion", MySqlDbType.VarChar);
                objSqlCommand.Parameters["noofinsertion"].Value = noofinsertion;

                objSqlCommand.Parameters.Add("insertiondate", MySqlDbType.VarChar);
                objSqlCommand.Parameters["insertiondate"].Value = insertiondate;

                objSqlCommand.Parameters.Add("startdate", MySqlDbType.VarChar);
                objSqlCommand.Parameters["startdate"].Value = startdate;

                objSqlCommand.Parameters.Add("dateformat", MySqlDbType.VarChar);
                objSqlCommand.Parameters["dateformat"].Value = dateformat;

                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("adcategory", MySqlDbType.VarChar);
                objSqlCommand.Parameters["adcategory"].Value = adcategory;

                objSqlCommand.Parameters.Add("adsubcat", MySqlDbType.VarChar);
                objSqlCommand.Parameters["adsubcat"].Value = adsubcat;

                objSqlCommand.Parameters.Add("color", MySqlDbType.VarChar);
                objSqlCommand.Parameters["color"].Value = color;

                objSqlCommand.Parameters.Add("adtype", MySqlDbType.VarChar);
                objSqlCommand.Parameters["adtype"].Value = adtype;

                objSqlCommand.Parameters.Add("currency", MySqlDbType.VarChar);
                objSqlCommand.Parameters["currency"].Value = currency;

                objSqlCommand.Parameters.Add("ratecode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["ratecode"].Value = ratecode;

                objSqlCommand.Parameters.Add("clickdate", MySqlDbType.VarChar);
                objSqlCommand.Parameters["clickdate"].Value = clickdate;

                objSqlCommand.Parameters.Add("flag", MySqlDbType.Int64);
                if (flag == "" || flag == null)
                {
                    objSqlCommand.Parameters["flag"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["flag"].Value = Convert.ToInt32(flag);
                }

                objSqlCommand.Parameters.Add("code", MySqlDbType.VarChar);
                objSqlCommand.Parameters["code"].Value = code;

                objSqlCommand.Parameters.Add("pck", MySqlDbType.Decimal);
                if (pck == "" || pck == null)
                {
                    objSqlCommand.Parameters["pck"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["pck"].Value = Convert.ToDecimal(pck);
                }

                objSqlCommand.Parameters.Add("uom", MySqlDbType.VarChar);
                objSqlCommand.Parameters["uom"].Value = uom;

                objSqlCommand.Parameters.Add("dealrate", MySqlDbType.Decimal);
                if (dealrate == "" || dealrate == null)
                {
                    objSqlCommand.Parameters["dealrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["dealrate"].Value = Convert.ToDecimal(dealrate);
                }

                objSqlCommand.Parameters.Add("checkforor", MySqlDbType.VarChar);
                objSqlCommand.Parameters["checkforor"].Value = checkforor;

                objSqlCommand.Parameters.Add("classinserts", MySqlDbType.VarChar);
                objSqlCommand.Parameters["classinserts"].Value = classinserts;

                objSqlCommand.Parameters.Add("lines", MySqlDbType.VarChar);
                objSqlCommand.Parameters["lines"].Value = lines;

                objSqlCommand.Parameters.Add("adcat3", MySqlDbType.VarChar);
                if (adcat3 == "")
                {
                    objSqlCommand.Parameters["adcat3"].Value = "0";
                }
                else
                {
                    objSqlCommand.Parameters["adcat3"].Value = adcat3;
                }
                objSqlCommand.Parameters.Add("adcat4", MySqlDbType.VarChar);
                if (adcat4 == "")
                {
                    objSqlCommand.Parameters["adcat4"].Value = "0";
                }
                else
                {
                    objSqlCommand.Parameters["adcat4"].Value = adcat4;
                }
                objSqlCommand.Parameters.Add("adcat5", MySqlDbType.VarChar);
                if (adcat5 == "")
                {

                    objSqlCommand.Parameters["adcat5"].Value = "0";
                }
                else
                {
                    objSqlCommand.Parameters["adcat5"].Value = adcat5;
                }

                objSqlCommand.Parameters.Add("clientcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["clientcode"].Value = clientcode;


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





        public DataSet getrateforprmpkg(string adtype, string color, string adcat, string adsucat, string currency, string ratecode, string package, string compcode, string uom, string premium)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getrate_forprempkg", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("adtype", MySqlDbType.VarChar);
                objSqlCommand.Parameters["adtype"].Value = adtype;

                objSqlCommand.Parameters.Add("color", MySqlDbType.VarChar);
                objSqlCommand.Parameters["color"].Value = color;

                objSqlCommand.Parameters.Add("adcat", MySqlDbType.VarChar);
                objSqlCommand.Parameters["adcat"].Value = adcat;

                objSqlCommand.Parameters.Add("adsucat", MySqlDbType.VarChar);
                objSqlCommand.Parameters["adsucat"].Value = adsucat;

                objSqlCommand.Parameters.Add("currency", MySqlDbType.VarChar);
                objSqlCommand.Parameters["currency"].Value = currency;

                objSqlCommand.Parameters.Add("ratecode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["ratecode"].Value = ratecode;

                objSqlCommand.Parameters.Add("package", MySqlDbType.VarChar);
                objSqlCommand.Parameters["package"].Value = package;


                objSqlCommand.Parameters.Add("uom", MySqlDbType.VarChar);
                objSqlCommand.Parameters["uom"].Value = uom;

                objSqlCommand.Parameters.Add("premium", MySqlDbType.VarChar);
                objSqlCommand.Parameters["premium"].Value = premium;






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



        public DataSet getvatamt(string grossamt, string compcode)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getthevatrate", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("grossamt", MySqlDbType.VarChar);
                objSqlCommand.Parameters["grossamt"].Value = grossamt;


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

        public DataSet class_chklinerate(string adtype, string color, string adcat, string adsucat, string currency, string ratecode, string package, string selecdate, string compcode, string uom, string insert, string lines, string prem, string adcat3, string adcat4, string adcat5, string clientname, string editionsolo)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("class_chklinerate", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("adtype", MySqlDbType.VarChar);
                objSqlCommand.Parameters["adtype"].Value = adtype;

                objSqlCommand.Parameters.Add("color", MySqlDbType.VarChar);
                objSqlCommand.Parameters["color"].Value = color;

                objSqlCommand.Parameters.Add("adcat", MySqlDbType.VarChar);
                objSqlCommand.Parameters["adcat"].Value = adcat;

                objSqlCommand.Parameters.Add("adsucat", MySqlDbType.VarChar);
                objSqlCommand.Parameters["adsucat"].Value = adsucat;

                objSqlCommand.Parameters.Add("currency", MySqlDbType.VarChar);
                objSqlCommand.Parameters["currency"].Value = currency;

                objSqlCommand.Parameters.Add("ratecode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["ratecode"].Value = ratecode;

                objSqlCommand.Parameters.Add("package", MySqlDbType.VarChar);
                objSqlCommand.Parameters["package"].Value = package;

                objSqlCommand.Parameters.Add("selecdate", MySqlDbType.VarChar);
                objSqlCommand.Parameters["selecdate"].Value = selecdate;

                objSqlCommand.Parameters.Add("uom", MySqlDbType.VarChar);
                objSqlCommand.Parameters["uom"].Value = uom;


                objSqlCommand.Parameters.Add("insert", MySqlDbType.VarChar);
                objSqlCommand.Parameters["insert"].Value = insert;

                objSqlCommand.Parameters.Add("lines", MySqlDbType.VarChar);
                objSqlCommand.Parameters["lines"].Value = lines;


                objSqlCommand.Parameters.Add("prem", MySqlDbType.VarChar);
                objSqlCommand.Parameters["prem"].Value = prem;

                objSqlCommand.Parameters.Add("adcat3", MySqlDbType.VarChar);
                if (adcat3 == "")
                {
                    objSqlCommand.Parameters["adcat3"].Value = "0";
                }
                else
                {
                    objSqlCommand.Parameters["adcat3"].Value = adcat3;
                }

                objSqlCommand.Parameters.Add("adcat4", MySqlDbType.VarChar);
                if (adcat4 == "")
                {
                    objSqlCommand.Parameters["adcat4"].Value = "0";
                }
                else
                {
                    objSqlCommand.Parameters["adcat4"].Value = adcat4;
                }
                objSqlCommand.Parameters.Add("adcat5", MySqlDbType.VarChar);
                if (adcat5 == "")
                {
                    objSqlCommand.Parameters["adcat5"].Value = "0";
                }
                else
                {
                    objSqlCommand.Parameters["adcat5"].Value = adcat5;
                }

                objSqlCommand.Parameters.Add("clientname", MySqlDbType.VarChar);
                objSqlCommand.Parameters["clientname"].Value = clientname;

                objSqlCommand.Parameters.Add("editionsolo", MySqlDbType.VarChar);
                objSqlCommand.Parameters["editionsolo"].Value = editionsolo;






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

        public DataSet updatebookstatus(string cioid, string compcode)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("updatebookstatus", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("cioid", MySqlDbType.VarChar);
                objSqlCommand.Parameters["cioid"].Value = cioid;

                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;


                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                //if (objDataSet.Tables[0].Rows.Count > 0)
                //{
                //    zonename = objDataSet.Tables[0].Rows[0].ItemArray[0].ToString();
                //}
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

        public DataSet book_getcyoppkg(string code, string compcode, string adtype)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("book_getcyoppkg", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("code1", MySqlDbType.VarChar);
                objSqlCommand.Parameters["code1"].Value = code;

                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("adtype", MySqlDbType.VarChar);
                objSqlCommand.Parameters["adtype"].Value = adtype;

                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                //if (objDataSet.Tables[0].Rows.Count > 0)
                //{
                //    zonename = objDataSet.Tables[0].Rows[0].ItemArray[0].ToString();
                //}
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

        public DataSet getwidthforcollumn(string desc, string collumn, string compcode)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("book_getwidthforcollumn", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;



                objSqlCommand.Parameters.Add("desc1", MySqlDbType.VarChar);
                objSqlCommand.Parameters["desc1"].Value = desc;

                objSqlCommand.Parameters.Add("collumn", MySqlDbType.VarChar);
                objSqlCommand.Parameters["collumn"].Value = collumn;




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
        /*change*/
        public DataSet getwidthforcollumn_qbc(string desc, string collumn, string compcode)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("book_getwidthforcollumn_qbc", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;



                objSqlCommand.Parameters.Add("desc1", MySqlDbType.VarChar);
                objSqlCommand.Parameters["desc1"].Value = desc;

                objSqlCommand.Parameters.Add("collumn", MySqlDbType.VarChar);
                objSqlCommand.Parameters["collumn"].Value = collumn;




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

        //public DataSet getwidthforcollumn_qbc(string desc, string collumn, string compcode)
        //{
        //    MySqlConnection objSqlConnection;
        //    MySqlCommand objSqlCommand;
        //    objSqlConnection = GetConnection();
        //    MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
        //    DataSet objDataSet = new DataSet();
        //    try
        //    {
        //        objSqlConnection.Open();
        //        objSqlCommand = GetCommand("book_getwidthforcollumn_qbc", ref objSqlConnection);
        //        objSqlCommand.CommandType = CommandType.StoredProcedure;

        //        objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
        //        objSqlCommand.Parameters["compcode"].Value = compcode;



        //        objSqlCommand.Parameters.Add("desc1", MySqlDbType.VarChar);
        //        objSqlCommand.Parameters["desc1"].Value = desc;

        //        objSqlCommand.Parameters.Add("collumn", MySqlDbType.VarChar);
        //        objSqlCommand.Parameters["collumn"].Value = collumn;




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

        //*****************************By Manish Verma*************************************
        public DataSet fetchStyleSheetName(string uom)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getStyleSheet", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("uom", MySqlDbType.VarChar);
                objSqlCommand.Parameters["uom"].Value = uom;



                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (MySqlException objException)
            {
                throw (objException);
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


        public DataSet saveMatter(string cioid, string matterFName, string RTFformat, string XTGformat, string matter, string receiptno)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_insertMatter", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("cioid", MySqlDbType.VarChar);
                objSqlCommand.Parameters["cioid"].Value = cioid;

                objSqlCommand.Parameters.Add("matter_filename", MySqlDbType.VarChar);
                objSqlCommand.Parameters["matter_filename"].Value = matterFName;

                objSqlCommand.Parameters.Add("RTFformat", MySqlDbType.VarChar);
                objSqlCommand.Parameters["RTFformat"].Value = RTFformat;

                objSqlCommand.Parameters.Add("XTGformat", MySqlDbType.VarChar);
                objSqlCommand.Parameters["XTGformat"].Value = XTGformat;

                objSqlCommand.Parameters.Add("matter", MySqlDbType.VarChar);
                objSqlCommand.Parameters["matter"].Value = matter;


                objSqlCommand.Parameters.Add("receiptno", MySqlDbType.VarChar);
                objSqlCommand.Parameters["receiptno"].Value = receiptno;


                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (MySqlException objException)
            {
                throw (objException);
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
        public DataSet getMatter(string cioid, string matterFName)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_getMatter", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("cioid", MySqlDbType.VarChar);
                objSqlCommand.Parameters["cioid"].Value = cioid;

                objSqlCommand.Parameters.Add("pmatter_filename", MySqlDbType.VarChar);
                objSqlCommand.Parameters["pmatter_filename"].Value = matterFName;

                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (MySqlException objException)
            {
                throw (objException);
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

        public DataSet modifyMatter(string cioid, string matterFName, string RTFformat, string XTGformat, string matter, string flag, string receiptnumber, string lang, string userid)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_modifymatter_websp_modifymatter_p", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("cioid", MySqlDbType.VarChar);
                objSqlCommand.Parameters["cioid"].Value = cioid;

                objSqlCommand.Parameters.Add("pmatter_filename", MySqlDbType.VarChar);
                objSqlCommand.Parameters["pmatter_filename"].Value = matterFName;

                objSqlCommand.Parameters.Add("RTFformat", MySqlDbType.VarChar);
                objSqlCommand.Parameters["RTFformat"].Value = RTFformat;

                objSqlCommand.Parameters.Add("XTGformat", MySqlDbType.VarChar);
                objSqlCommand.Parameters["XTGformat"].Value = XTGformat;

                objSqlCommand.Parameters.Add("matter", MySqlDbType.VarChar);
                objSqlCommand.Parameters["matter"].Value = matter;

                objSqlCommand.Parameters.Add("flag", MySqlDbType.VarChar);
                objSqlCommand.Parameters["flag"].Value = flag;

                objSqlCommand.Parameters.Add("receiptnumber", MySqlDbType.VarChar);
                objSqlCommand.Parameters["receiptnumber"].Value = receiptnumber;

                objSqlCommand.Parameters.Add("p_lang", MySqlDbType.VarChar);
                objSqlCommand.Parameters["p_lang"].Value = lang;

                objSqlCommand.Parameters.Add("p_userid", MySqlDbType.VarChar);
                objSqlCommand.Parameters["p_userid"].Value = userid;

                objSqlCommand.Parameters.Add("ptemptype", MySqlDbType.VarChar);
                objSqlCommand.Parameters["ptemptype"].Value = null;

                objSqlCommand.Parameters.Add("punimatter", MySqlDbType.VarChar);
                objSqlCommand.Parameters["punimatter"].Value = null;

                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (MySqlException objException)
            {
                throw (objException);
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
       
        /*
        public DataSet modifyMatter(string cioid, string matterFName, string RTFformat, string XTGformat, string matter, string flag, string receiptnumber)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_modifyMatter", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("cioid", MySqlDbType.VarChar);
                objSqlCommand.Parameters["cioid"].Value = cioid;

                objSqlCommand.Parameters.Add("matter_filename", MySqlDbType.VarChar);
                objSqlCommand.Parameters["matter_filename"].Value = matterFName;

                objSqlCommand.Parameters.Add("RTFformat", MySqlDbType.VarChar);
                objSqlCommand.Parameters["RTFformat"].Value = RTFformat;

                objSqlCommand.Parameters.Add("XTGformat", MySqlDbType.VarChar);
                objSqlCommand.Parameters["XTGformat"].Value = XTGformat;
                objSqlCommand.Parameters.Add("matter", MySqlDbType.VarChar);
                objSqlCommand.Parameters["matter"].Value = matter;

                objSqlCommand.Parameters.Add("flag", MySqlDbType.VarChar);
                objSqlCommand.Parameters["flag"].Value = flag;
                objSqlCommand.Parameters.Add("receiptnumber", MySqlDbType.VarChar);
                objSqlCommand.Parameters["receiptnumber"].Value = receiptnumber;



                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (MySqlException objException)
            {
                throw (objException);
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
        */
        //***********************************************************************************


        //public DataSet packagebind(string compcode, string userid)
        //{
        //    MySqlConnection objSqlConnection;
        //    MySqlCommand objSqlCommand;
        //    objSqlConnection = GetConnection();
        //    MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
        //    DataSet objDataSet = new DataSet();
        //    try
        //    {
        //        objSqlConnection.Open();
        //        objSqlCommand = GetCommand("bindpackage", ref objSqlConnection);
        //        objSqlCommand.CommandType = CommandType.StoredProcedure;

        //        objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
        //        objSqlCommand.Parameters["compcode"].Value = compcode;

        //        objSqlCommand.Parameters.Add("userid", MySqlDbType.VarChar);
        //        objSqlCommand.Parameters["userid"].Value = userid;



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


        public DataSet packagebind(string compcode, string userid)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("bindpackage", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objSqlCommand.Parameters["userid"].Value = userid;

                //objSqlCommand.Parameters.Add("center", MySqlDbType.VarChar);
                //objSqlCommand.Parameters["center"].Value = center;

                //objSqlCommand.Parameters.Add("no", MySqlDbType.VarChar);
                //objSqlCommand.Parameters["no"].Value = no;



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

        public void insertResult(string package, string pkgname)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("InsertSplitData", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("package", MySqlDbType.VarChar);
                objSqlCommand.Parameters["package"].Value = package;

                objSqlCommand.Parameters.Add("pkgname", MySqlDbType.VarChar);
                objSqlCommand.Parameters["pkgname"].Value = pkgname;



                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);

                //return objDataSet;
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

        public void insertcodeResult(string package, string pkgname)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("insertsplitcodedata", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;





                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);

                //return objDataSet;
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

        public void truncateResult()
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("truncateResult", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);

                //return objDataSet;
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

        /*          this is to calculate the total rate as well as break up rate  */
        public DataSet getbreakuprate(string package, string noofinsertion, string insertiondate, string startdate, string dateformat, string compcode, string adcategory, string adsubcat, string color, string adtype, string currency, string ratecode, string clickdate, string flag, string code, string pck, string uom, string dealrate, string checkforor, string classinserts, string lines, string adcat3, string adcat4, string adcat5, string clientcode, string uomdesc)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("new_qbc", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("package", MySqlDbType.VarChar);
                objSqlCommand.Parameters["package"].Value = package;

                objSqlCommand.Parameters.Add("noofinsertion", MySqlDbType.VarChar);
                objSqlCommand.Parameters["noofinsertion"].Value = noofinsertion;

                objSqlCommand.Parameters.Add("insertiondate", MySqlDbType.VarChar);
                objSqlCommand.Parameters["insertiondate"].Value = insertiondate;

                objSqlCommand.Parameters.Add("startdate", MySqlDbType.VarChar);
                objSqlCommand.Parameters["startdate"].Value = startdate;

                objSqlCommand.Parameters.Add("dateformat", MySqlDbType.VarChar);
                objSqlCommand.Parameters["dateformat"].Value = dateformat;

                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("adcategory", MySqlDbType.VarChar);
                objSqlCommand.Parameters["adcategory"].Value = adcategory;

                objSqlCommand.Parameters.Add("adsubcat", MySqlDbType.VarChar);
                objSqlCommand.Parameters["adsubcat"].Value = adsubcat;

                objSqlCommand.Parameters.Add("color1", MySqlDbType.VarChar);
                objSqlCommand.Parameters["color1"].Value = color;

                objSqlCommand.Parameters.Add("adtype", MySqlDbType.VarChar);
                objSqlCommand.Parameters["adtype"].Value = adtype;

                objSqlCommand.Parameters.Add("currency", MySqlDbType.VarChar);
                objSqlCommand.Parameters["currency"].Value = currency;

                objSqlCommand.Parameters.Add("ratecode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["ratecode"].Value = ratecode;

                objSqlCommand.Parameters.Add("clickdate", MySqlDbType.VarChar);
                objSqlCommand.Parameters["clickdate"].Value = clickdate;

                objSqlCommand.Parameters.Add("flag", MySqlDbType.Int64);
                if (flag == "" || flag == null)
                {
                    objSqlCommand.Parameters["flag"].Value = 0;
                }
                else
                {
                    objSqlCommand.Parameters["flag"].Value = Convert.ToInt32(flag);
                }

                objSqlCommand.Parameters.Add("code1", MySqlDbType.VarChar);
                objSqlCommand.Parameters["code1"].Value = code;

                objSqlCommand.Parameters.Add("pck", MySqlDbType.Decimal);
                if (pck == "" || pck == null || pck == "null")
                {
                    objSqlCommand.Parameters["pck"].Value = 0;
                }
                else
                {
                    objSqlCommand.Parameters["pck"].Value = Convert.ToDecimal(pck);
                }

                objSqlCommand.Parameters.Add("uom1", MySqlDbType.VarChar);
                objSqlCommand.Parameters["uom1"].Value = uom;

                objSqlCommand.Parameters.Add("dealrate", MySqlDbType.Decimal);
                if (dealrate == "" || dealrate == null || dealrate == "undefined")
                {
                    objSqlCommand.Parameters["dealrate"].Value = 0;
                }
                else
                {
                    objSqlCommand.Parameters["dealrate"].Value = Convert.ToDecimal(dealrate);
                }

                objSqlCommand.Parameters.Add("checkforor", MySqlDbType.VarChar);
                objSqlCommand.Parameters["checkforor"].Value = checkforor;

                objSqlCommand.Parameters.Add("classinserts", MySqlDbType.VarChar);
                objSqlCommand.Parameters["classinserts"].Value = classinserts;

                objSqlCommand.Parameters.Add("lines1", MySqlDbType.VarChar);
                objSqlCommand.Parameters["lines1"].Value = lines;

                objSqlCommand.Parameters.Add("adcat3", MySqlDbType.VarChar);
                if (adcat3 == "")
                {
                    objSqlCommand.Parameters["adcat3"].Value = "0";
                }
                else
                {
                    objSqlCommand.Parameters["adcat3"].Value = adcat3;
                }
                objSqlCommand.Parameters.Add("adcat4", MySqlDbType.VarChar);
                if (adcat4 == "")
                {
                    objSqlCommand.Parameters["adcat4"].Value = "0";
                }
                else
                {
                    objSqlCommand.Parameters["adcat4"].Value = adcat4;
                }
                objSqlCommand.Parameters.Add("adcat5", MySqlDbType.VarChar);
                if (adcat5 == "")
                {

                    objSqlCommand.Parameters["adcat5"].Value = "0";
                }
                else
                {
                    objSqlCommand.Parameters["adcat5"].Value = adcat5;
                }

                objSqlCommand.Parameters.Add("clientcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["clientcode"].Value = clientcode;


                objSqlCommand.Parameters.Add("uomdesc", MySqlDbType.VarChar);
                objSqlCommand.Parameters["uomdesc"].Value = uomdesc;
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




        /*          this is to calculate the total rate as well as break up rate  */
        public DataSet getpkgrate(string package, string noofinsertion, string insertiondate, string startdate, string dateformat, string compcode, string adcategory, string adsubcat, string color, string adtype, string currency, string ratecode, string clickdate, string flag, string code, string pck, string uom, string dealrate, string checkforor, string classinserts, string lines, string adcat3, string adcat4, string adcat5, string clientcode, string uomdesc)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getpackagerate", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("package", MySqlDbType.VarChar);
                objSqlCommand.Parameters["package"].Value = package;

                objSqlCommand.Parameters.Add("noofinsertion", MySqlDbType.VarChar);
                objSqlCommand.Parameters["noofinsertion"].Value = noofinsertion;

                objSqlCommand.Parameters.Add("insertiondate", MySqlDbType.VarChar);
                objSqlCommand.Parameters["insertiondate"].Value = insertiondate;

                objSqlCommand.Parameters.Add("startdate", MySqlDbType.VarChar);
                objSqlCommand.Parameters["startdate"].Value = startdate;

                objSqlCommand.Parameters.Add("dateformat", MySqlDbType.VarChar);
                objSqlCommand.Parameters["dateformat"].Value = dateformat;

                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("adcategory", MySqlDbType.VarChar);
                objSqlCommand.Parameters["adcategory"].Value = adcategory;

                objSqlCommand.Parameters.Add("adsubcat", MySqlDbType.VarChar);
                objSqlCommand.Parameters["adsubcat"].Value = adsubcat;

                objSqlCommand.Parameters.Add("color1", MySqlDbType.VarChar);
                objSqlCommand.Parameters["color1"].Value = color;

                objSqlCommand.Parameters.Add("adtype", MySqlDbType.VarChar);
                objSqlCommand.Parameters["adtype"].Value = adtype;

                objSqlCommand.Parameters.Add("currency", MySqlDbType.VarChar);
                objSqlCommand.Parameters["currency"].Value = currency;

                objSqlCommand.Parameters.Add("ratecode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["ratecode"].Value = ratecode;

                objSqlCommand.Parameters.Add("clickdate", MySqlDbType.VarChar);
                objSqlCommand.Parameters["clickdate"].Value = clickdate;

                objSqlCommand.Parameters.Add("flag", MySqlDbType.Int64);
                if (flag == "" || flag == null)
                {
                    objSqlCommand.Parameters["flag"].Value = 0;
                }
                else
                {
                    objSqlCommand.Parameters["flag"].Value = Convert.ToInt32(flag);
                }

                objSqlCommand.Parameters.Add("code1", MySqlDbType.VarChar);
                objSqlCommand.Parameters["code1"].Value = code;

                objSqlCommand.Parameters.Add("pck", MySqlDbType.Decimal);
                if (pck == "" || pck == null)
                {
                    objSqlCommand.Parameters["pck"].Value = 0;
                }
                else
                {
                    objSqlCommand.Parameters["pck"].Value = Convert.ToDecimal(pck);
                }

                objSqlCommand.Parameters.Add("uom1", MySqlDbType.VarChar);
                objSqlCommand.Parameters["uom1"].Value = uom;

                objSqlCommand.Parameters.Add("dealrate", MySqlDbType.Decimal);
                if (dealrate == "" || dealrate == null || dealrate == "undefined")
                {
                    objSqlCommand.Parameters["dealrate"].Value = 0;
                }
                else
                {
                    objSqlCommand.Parameters["dealrate"].Value = Convert.ToDecimal(dealrate);
                }

                objSqlCommand.Parameters.Add("checkforor", MySqlDbType.VarChar);
                objSqlCommand.Parameters["checkforor"].Value = checkforor;

                objSqlCommand.Parameters.Add("classinserts", MySqlDbType.VarChar);
                objSqlCommand.Parameters["classinserts"].Value = classinserts;

                objSqlCommand.Parameters.Add("lines1", MySqlDbType.VarChar);
                objSqlCommand.Parameters["lines1"].Value = lines;

                objSqlCommand.Parameters.Add("adcat3", MySqlDbType.VarChar);
                if (adcat3 == "")
                {
                    objSqlCommand.Parameters["adcat3"].Value = "0";
                }
                else
                {
                    objSqlCommand.Parameters["adcat3"].Value = adcat3;
                }
                objSqlCommand.Parameters.Add("adcat4", MySqlDbType.VarChar);
                if (adcat4 == "")
                {
                    objSqlCommand.Parameters["adcat4"].Value = "0";
                }
                else
                {
                    objSqlCommand.Parameters["adcat4"].Value = adcat4;
                }
                objSqlCommand.Parameters.Add("adcat5", MySqlDbType.VarChar);
                if (adcat5 == "")
                {

                    objSqlCommand.Parameters["adcat5"].Value = "0";
                }
                else
                {
                    objSqlCommand.Parameters["adcat5"].Value = adcat5;
                }

                objSqlCommand.Parameters.Add("clientcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["clientcode"].Value = clientcode;

                objSqlCommand.Parameters.Add("uomdesc", MySqlDbType.VarChar);
                objSqlCommand.Parameters["uomdesc"].Value = uomdesc;



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

        public DataSet getwidth_qbc(string edition, string compcode)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getwidth_qbc", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("edition", MySqlDbType.VarChar);
                objSqlCommand.Parameters["edition"].Value = edition;

                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;


                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (MySqlException objException)
            {
                throw (objException);
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
        public DataSet fetchbookingdata(string edition, string date)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_getbookingdetail", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("edition", MySqlDbType.VarChar);
                objSqlCommand.Parameters["edition"].Value = edition;




                objSqlCommand.Parameters.Add("date", MySqlDbType.VarChar);
                objSqlCommand.Parameters["date"].Value = date;



                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (MySqlException objException)
            {
                throw (objException);
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

        public DataSet cancelbooking(string prevbookingid)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("cancelbooking", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("prevbook", MySqlDbType.VarChar);
                objSqlCommand.Parameters["prevbook"].Value = prevbookingid;


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


        /*new change ankur 24 feb*/
        public DataSet getvaliddate_qbc(string dateformat, string datetoadd, string pkgname)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("get_validdate", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("dateformat", MySqlDbType.VarChar);
                objSqlCommand.Parameters["dateformat"].Value = dateformat;




                objSqlCommand.Parameters.Add("datetoadd", MySqlDbType.VarChar);
                if (datetoadd == "" || datetoadd == null)
                {
                    objSqlCommand.Parameters["datetoadd"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "mm/dd/yyyy" && datetoadd != "")
                    {
                        string[] arr = null;
                        arr = datetoadd.Split("/".ToCharArray());
                        datetoadd = arr[2] + "-" + arr[0] + "-" + arr[1];

                    }
                    if (dateformat == "dd/mm/yyyy" && datetoadd != "")
                    {
                        string[] arr = null;
                        arr = datetoadd.Split("/".ToCharArray());
                        datetoadd = arr[2] + "-" + arr[1] + "-" + arr[0];

                    }
                    if (dateformat == "yyyy/mm/dd" && datetoadd != "")
                    {
                        string[] arr = null;
                        arr = datetoadd.Split("/".ToCharArray());
                        datetoadd = arr[0] + "-" + arr[1] + "-" + arr[2];

                    }
                    objSqlCommand.Parameters["datetoadd"].Value = datetoadd;
                }


                objSqlCommand.Parameters.Add("pkgname", MySqlDbType.VarChar);
                objSqlCommand.Parameters["pkgname"].Value = pkgname;


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

        /*new change ankur 9 feb*/
        public DataSet bingbgcolor_drp(string category, string coltype)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_bingbgcolor", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("category", MySqlDbType.VarChar);
                objSqlCommand.Parameters["category"].Value = category;

                objSqlCommand.Parameters.Add("coltype", MySqlDbType.VarChar);
                objSqlCommand.Parameters["coltype"].Value = coltype;




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
        public DataSet bindbgandfont(string cat, string cat2, string cat3, string cat4, string cat5, string desc)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {

                objSqlConnection.Open();
                objSqlCommand = GetCommand("book_bindbgandfont", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("cat", MySqlDbType.VarChar);
                objSqlCommand.Parameters["cat"].Value = cat;

                objSqlCommand.Parameters.Add("cat2", MySqlDbType.VarChar);
                objSqlCommand.Parameters["cat2"].Value = cat2;

                objSqlCommand.Parameters.Add("cat3", MySqlDbType.VarChar);
                objSqlCommand.Parameters["cat3"].Value = cat3;

                objSqlCommand.Parameters.Add("cat4", MySqlDbType.VarChar);
                objSqlCommand.Parameters["cat4"].Value = cat4;

                objSqlCommand.Parameters.Add("cat5", MySqlDbType.VarChar);
                objSqlCommand.Parameters["cat5"].Value = cat5;

                objSqlCommand.Parameters.Add("desc1", MySqlDbType.VarChar);
                objSqlCommand.Parameters["desc1"].Value = desc;




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
        public DataSet binduomforedit(string adtype, string desc, string compcode)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("qbc_binduomedition", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("adtype", MySqlDbType.VarChar);
                objSqlCommand.Parameters["adtype"].Value = adtype;

                objSqlCommand.Parameters.Add("desc1", MySqlDbType.VarChar);
                objSqlCommand.Parameters["desc1"].Value = desc;

                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;





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
        public DataSet bindcolortyp(string compcode)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("bindcolortype", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;

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

        /*new changes ankur*/
        public DataSet variable_name(string compcode)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("bindvariable", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;


                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                //if (objDataSet.Tables[0].Rows.Count > 0)
                //{
                //    zonename = objDataSet.Tables[0].Rows[0].ItemArray[0].ToString();
                //}
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


        /*new change ankur agency*/
        public DataSet class_getrate_qbcagency(string adtype, string color, string adcat, string adsucat, string currency, string ratecode, string package, string selecdate, string compcode, string uom, string insert, string lines, string prem, string adcat3, string adcat4, string adcat5, string clientname, string noof_ins, string uomdesc, string agencycode)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getpackgaerate_agency", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("adtype", MySqlDbType.VarChar);
                objSqlCommand.Parameters["adtype"].Value = adtype;

                objSqlCommand.Parameters.Add("color", MySqlDbType.VarChar);
                objSqlCommand.Parameters["color"].Value = color;

                objSqlCommand.Parameters.Add("adcat", MySqlDbType.VarChar);
                objSqlCommand.Parameters["adcat"].Value = adcat;

                objSqlCommand.Parameters.Add("adsucat", MySqlDbType.VarChar);
                objSqlCommand.Parameters["adsucat"].Value = adsucat;

                objSqlCommand.Parameters.Add("currency", MySqlDbType.VarChar);
                objSqlCommand.Parameters["currency"].Value = currency;

                objSqlCommand.Parameters.Add("ratecode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["ratecode"].Value = ratecode;

                objSqlCommand.Parameters.Add("package", MySqlDbType.VarChar);
                objSqlCommand.Parameters["package"].Value = package;

                objSqlCommand.Parameters.Add("selecdate", MySqlDbType.VarChar);
                objSqlCommand.Parameters["selecdate"].Value = selecdate;

                objSqlCommand.Parameters.Add("uom", MySqlDbType.VarChar);
                objSqlCommand.Parameters["uom"].Value = uom;


                objSqlCommand.Parameters.Add("insert", MySqlDbType.VarChar);
                objSqlCommand.Parameters["insert"].Value = insert;

                objSqlCommand.Parameters.Add("lines", MySqlDbType.VarChar);
                objSqlCommand.Parameters["lines"].Value = lines;


                objSqlCommand.Parameters.Add("prem", MySqlDbType.VarChar);
                objSqlCommand.Parameters["prem"].Value = prem;

                objSqlCommand.Parameters.Add("adcat3", MySqlDbType.VarChar);
                if (adcat3 == "")
                {
                    objSqlCommand.Parameters["adcat3"].Value = "0";
                }
                else
                {
                    objSqlCommand.Parameters["adcat3"].Value = adcat3;
                }

                objSqlCommand.Parameters.Add("adcat4", MySqlDbType.VarChar);
                if (adcat4 == "")
                {
                    objSqlCommand.Parameters["adcat4"].Value = "0";
                }
                else
                {
                    objSqlCommand.Parameters["adcat4"].Value = adcat4;
                }
                objSqlCommand.Parameters.Add("adcat5", MySqlDbType.VarChar);
                if (adcat5 == "")
                {
                    objSqlCommand.Parameters["adcat5"].Value = "0";
                }
                else
                {
                    objSqlCommand.Parameters["adcat5"].Value = adcat5;
                }

                objSqlCommand.Parameters.Add("clientname", MySqlDbType.VarChar);
                objSqlCommand.Parameters["clientname"].Value = clientname;

                objSqlCommand.Parameters.Add("noof_ins", MySqlDbType.VarChar);
                objSqlCommand.Parameters["noof_ins"].Value = noof_ins;


                /*new change ankur 17 feb*/
                objSqlCommand.Parameters.Add("uomdesc", MySqlDbType.VarChar);
                objSqlCommand.Parameters["uomdesc"].Value = uomdesc;

                objSqlCommand.Parameters.Add("agencycode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["agencycode"].Value = agencycode;



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

        /*new change for agency*/
        public DataSet getpkgrate_agency(string package, string noofinsertion, string insertiondate, string startdate, string dateformat, string compcode, string adcategory, string adsubcat, string color, string adtype, string currency, string ratecode, string clickdate, string flag, string code, string pck, string uom, string dealrate, string checkforor, string classinserts, string lines, string adcat3, string adcat4, string adcat5, string clientcode, string uomdesc, string agencycode)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getpackagerate_agency", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("package", MySqlDbType.VarChar);
                objSqlCommand.Parameters["package"].Value = package;

                objSqlCommand.Parameters.Add("noofinsertion", MySqlDbType.VarChar);
                objSqlCommand.Parameters["noofinsertion"].Value = noofinsertion;

                objSqlCommand.Parameters.Add("insertiondate", MySqlDbType.VarChar);
                objSqlCommand.Parameters["insertiondate"].Value = insertiondate;

                objSqlCommand.Parameters.Add("startdate", MySqlDbType.VarChar);
                objSqlCommand.Parameters["startdate"].Value = startdate;

                objSqlCommand.Parameters.Add("dateformat", MySqlDbType.VarChar);
                objSqlCommand.Parameters["dateformat"].Value = dateformat;

                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("adcategory", MySqlDbType.VarChar);
                objSqlCommand.Parameters["adcategory"].Value = adcategory;

                objSqlCommand.Parameters.Add("adsubcat", MySqlDbType.VarChar);
                objSqlCommand.Parameters["adsubcat"].Value = adsubcat;

                objSqlCommand.Parameters.Add("color1", MySqlDbType.VarChar);
                objSqlCommand.Parameters["color1"].Value = color;

                objSqlCommand.Parameters.Add("adtype", MySqlDbType.VarChar);
                objSqlCommand.Parameters["adtype"].Value = adtype;

                objSqlCommand.Parameters.Add("currency", MySqlDbType.VarChar);
                objSqlCommand.Parameters["currency"].Value = currency;

                objSqlCommand.Parameters.Add("ratecode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["ratecode"].Value = ratecode;

                objSqlCommand.Parameters.Add("clickdate", MySqlDbType.VarChar);
                objSqlCommand.Parameters["clickdate"].Value = clickdate;

                objSqlCommand.Parameters.Add("flag", MySqlDbType.Int64);
                if (flag == "" || flag == null)
                {
                    objSqlCommand.Parameters["flag"].Value = 0;
                }
                else
                {
                    objSqlCommand.Parameters["flag"].Value = Convert.ToInt32(flag);
                }

                objSqlCommand.Parameters.Add("code1", MySqlDbType.VarChar);
                objSqlCommand.Parameters["code1"].Value = code;

                objSqlCommand.Parameters.Add("pck", MySqlDbType.Decimal);
                if (pck == "" || pck == null)
                {
                    objSqlCommand.Parameters["pck"].Value = 0;
                }
                else
                {
                    objSqlCommand.Parameters["pck"].Value = Convert.ToDecimal(pck);
                }

                objSqlCommand.Parameters.Add("uom1", MySqlDbType.VarChar);
                objSqlCommand.Parameters["uom1"].Value = uom;

                objSqlCommand.Parameters.Add("dealrate", MySqlDbType.Decimal);
                if (dealrate == "" || dealrate == null || dealrate == "undefined")
                {
                    objSqlCommand.Parameters["dealrate"].Value = 0;
                }
                else
                {
                    objSqlCommand.Parameters["dealrate"].Value = Convert.ToDecimal(dealrate);
                }

                objSqlCommand.Parameters.Add("checkforor", MySqlDbType.VarChar);
                objSqlCommand.Parameters["checkforor"].Value = checkforor;

                objSqlCommand.Parameters.Add("classinserts", MySqlDbType.VarChar);
                objSqlCommand.Parameters["classinserts"].Value = classinserts;

                objSqlCommand.Parameters.Add("lines1", MySqlDbType.VarChar);
                objSqlCommand.Parameters["lines1"].Value = lines;

                objSqlCommand.Parameters.Add("adcat3", MySqlDbType.VarChar);
                if (adcat3 == "")
                {
                    objSqlCommand.Parameters["adcat3"].Value = "0";
                }
                else
                {
                    objSqlCommand.Parameters["adcat3"].Value = adcat3;
                }
                objSqlCommand.Parameters.Add("adcat4", MySqlDbType.VarChar);
                if (adcat4 == "")
                {
                    objSqlCommand.Parameters["adcat4"].Value = "0";
                }
                else
                {
                    objSqlCommand.Parameters["adcat4"].Value = adcat4;
                }
                objSqlCommand.Parameters.Add("adcat5", MySqlDbType.VarChar);
                if (adcat5 == "")
                {

                    objSqlCommand.Parameters["adcat5"].Value = "0";
                }
                else
                {
                    objSqlCommand.Parameters["adcat5"].Value = adcat5;
                }

                objSqlCommand.Parameters.Add("clientcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["clientcode"].Value = clientcode;

                /*new change ankur 17 feb*/

                objSqlCommand.Parameters.Add("uomdesc", MySqlDbType.VarChar);
                objSqlCommand.Parameters["uomdesc"].Value = uomdesc;


                objSqlCommand.Parameters.Add("agencycode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["agencycode"].Value = agencycode;

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


        public DataSet getmaxlines(string package, string noofinsertion, string insertiondate, string startdate, string dateformat, string compcode, string adcategory, string adsubcat, string color, string adtype, string currency, string ratecode, string clickdate, string flag, string code, string pck, string uom, string dealrate, string checkforor, string classinserts, string lines, string adcat3, string adcat4, string adcat5, string clientcode, string uomdesc)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getmaxlines", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("package", MySqlDbType.VarChar);
                objSqlCommand.Parameters["package"].Value = package;

                objSqlCommand.Parameters.Add("noofinsertion", MySqlDbType.VarChar);
                objSqlCommand.Parameters["noofinsertion"].Value = noofinsertion;

                objSqlCommand.Parameters.Add("insertiondate", MySqlDbType.VarChar);
                objSqlCommand.Parameters["insertiondate"].Value = insertiondate;

                objSqlCommand.Parameters.Add("startdate", MySqlDbType.VarChar);
                objSqlCommand.Parameters["startdate"].Value = startdate;

                objSqlCommand.Parameters.Add("dateformat", MySqlDbType.VarChar);
                objSqlCommand.Parameters["dateformat"].Value = dateformat;

                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("adcategory", MySqlDbType.VarChar);
                objSqlCommand.Parameters["adcategory"].Value = adcategory;

                objSqlCommand.Parameters.Add("adsubcat", MySqlDbType.VarChar);
                objSqlCommand.Parameters["adsubcat"].Value = adsubcat;

                objSqlCommand.Parameters.Add("color1", MySqlDbType.VarChar);
                objSqlCommand.Parameters["color1"].Value = color;

                objSqlCommand.Parameters.Add("adtype", MySqlDbType.VarChar);
                objSqlCommand.Parameters["adtype"].Value = adtype;

                objSqlCommand.Parameters.Add("currency", MySqlDbType.VarChar);
                objSqlCommand.Parameters["currency"].Value = currency;

                objSqlCommand.Parameters.Add("ratecode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["ratecode"].Value = ratecode;

                objSqlCommand.Parameters.Add("clickdate", MySqlDbType.VarChar);
                objSqlCommand.Parameters["clickdate"].Value = clickdate;

                objSqlCommand.Parameters.Add("flag", MySqlDbType.Int64);
                if (flag == "" || flag == null)
                {
                    objSqlCommand.Parameters["flag"].Value = 0;
                }
                else
                {
                    objSqlCommand.Parameters["flag"].Value = Convert.ToInt32(flag);
                }

                objSqlCommand.Parameters.Add("code1", MySqlDbType.VarChar);
                objSqlCommand.Parameters["code1"].Value = code;

                objSqlCommand.Parameters.Add("pck", MySqlDbType.Decimal);
                if (pck == "" || pck == null)
                {
                    objSqlCommand.Parameters["pck"].Value = 0;
                }
                else
                {
                    objSqlCommand.Parameters["pck"].Value = Convert.ToDecimal(pck);
                }

                objSqlCommand.Parameters.Add("uom1", MySqlDbType.VarChar);
                objSqlCommand.Parameters["uom1"].Value = uom;

                objSqlCommand.Parameters.Add("dealrate", MySqlDbType.Decimal);
                if (dealrate == "" || dealrate == null || dealrate == "undefined")
                {
                    objSqlCommand.Parameters["dealrate"].Value = 0;
                }
                else
                {
                    objSqlCommand.Parameters["dealrate"].Value = Convert.ToDecimal(dealrate);
                }

                objSqlCommand.Parameters.Add("checkforor", MySqlDbType.VarChar);
                objSqlCommand.Parameters["checkforor"].Value = checkforor;

                objSqlCommand.Parameters.Add("classinserts", MySqlDbType.VarChar);
                objSqlCommand.Parameters["classinserts"].Value = classinserts;

                objSqlCommand.Parameters.Add("lines1", MySqlDbType.VarChar);
                objSqlCommand.Parameters["lines1"].Value = lines;

                objSqlCommand.Parameters.Add("adcat3", MySqlDbType.VarChar);
                if (adcat3 == "")
                {
                    objSqlCommand.Parameters["adcat3"].Value = "0";
                }
                else
                {
                    objSqlCommand.Parameters["adcat3"].Value = adcat3;
                }
                objSqlCommand.Parameters.Add("adcat4", MySqlDbType.VarChar);
                if (adcat4 == "")
                {
                    objSqlCommand.Parameters["adcat4"].Value = "0";
                }
                else
                {
                    objSqlCommand.Parameters["adcat4"].Value = adcat4;
                }
                objSqlCommand.Parameters.Add("adcat5", MySqlDbType.VarChar);
                if (adcat5 == "")
                {

                    objSqlCommand.Parameters["adcat5"].Value = "0";
                }
                else
                {
                    objSqlCommand.Parameters["adcat5"].Value = adcat5;
                }

                objSqlCommand.Parameters.Add("clientcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["clientcode"].Value = clientcode;

                objSqlCommand.Parameters.Add("uomdesc", MySqlDbType.VarChar);
                objSqlCommand.Parameters["uomdesc"].Value = clientcode;



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



        public DataSet getmaxlines_agency(string package, string noofinsertion, string insertiondate, string startdate, string dateformat, string compcode, string adcategory, string adsubcat, string color, string adtype, string currency, string ratecode, string clickdate, string flag, string code, string pck, string uom, string dealrate, string checkforor, string classinserts, string lines, string adcat3, string adcat4, string adcat5, string clientcode, string uomdesc, string agencycode)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getmaxlines_agency", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("package", MySqlDbType.VarChar);
                objSqlCommand.Parameters["package"].Value = package;

                objSqlCommand.Parameters.Add("noofinsertion", MySqlDbType.VarChar);
                objSqlCommand.Parameters["noofinsertion"].Value = noofinsertion;

                objSqlCommand.Parameters.Add("insertiondate", MySqlDbType.VarChar);
                objSqlCommand.Parameters["insertiondate"].Value = insertiondate;

                objSqlCommand.Parameters.Add("startdate", MySqlDbType.VarChar);
                objSqlCommand.Parameters["startdate"].Value = startdate;

                objSqlCommand.Parameters.Add("dateformat", MySqlDbType.VarChar);
                objSqlCommand.Parameters["dateformat"].Value = dateformat;

                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("adcategory", MySqlDbType.VarChar);
                objSqlCommand.Parameters["adcategory"].Value = adcategory;

                objSqlCommand.Parameters.Add("adsubcat", MySqlDbType.VarChar);
                objSqlCommand.Parameters["adsubcat"].Value = adsubcat;

                objSqlCommand.Parameters.Add("color1", MySqlDbType.VarChar);
                objSqlCommand.Parameters["color1"].Value = color;

                objSqlCommand.Parameters.Add("adtype", MySqlDbType.VarChar);
                objSqlCommand.Parameters["adtype"].Value = adtype;

                objSqlCommand.Parameters.Add("currency", MySqlDbType.VarChar);
                objSqlCommand.Parameters["currency"].Value = currency;

                objSqlCommand.Parameters.Add("ratecode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["ratecode"].Value = ratecode;

                objSqlCommand.Parameters.Add("clickdate", MySqlDbType.VarChar);
                objSqlCommand.Parameters["clickdate"].Value = clickdate;

                objSqlCommand.Parameters.Add("flag", MySqlDbType.Int64);
                if (flag == "" || flag == null)
                {
                    objSqlCommand.Parameters["flag"].Value = 0;
                }
                else
                {
                    objSqlCommand.Parameters["flag"].Value = Convert.ToInt32(flag);
                }

                objSqlCommand.Parameters.Add("code1", MySqlDbType.VarChar);
                objSqlCommand.Parameters["code1"].Value = code;

                objSqlCommand.Parameters.Add("pck", MySqlDbType.Decimal);
                if (pck == "" || pck == null)
                {
                    objSqlCommand.Parameters["pck"].Value = 0;
                }
                else
                {
                    objSqlCommand.Parameters["pck"].Value = Convert.ToDecimal(pck);
                }

                objSqlCommand.Parameters.Add("uom1", MySqlDbType.VarChar);
                objSqlCommand.Parameters["uom1"].Value = uom;

                objSqlCommand.Parameters.Add("dealrate", MySqlDbType.Decimal);
                if (dealrate == "" || dealrate == null || dealrate == "undefined")
                {
                    objSqlCommand.Parameters["dealrate"].Value = 0;
                }
                else
                {
                    objSqlCommand.Parameters["dealrate"].Value = Convert.ToDecimal(dealrate);
                }

                objSqlCommand.Parameters.Add("checkforor", MySqlDbType.VarChar);
                objSqlCommand.Parameters["checkforor"].Value = checkforor;

                objSqlCommand.Parameters.Add("classinserts", MySqlDbType.VarChar);
                objSqlCommand.Parameters["classinserts"].Value = classinserts;

                objSqlCommand.Parameters.Add("lines1", MySqlDbType.VarChar);
                objSqlCommand.Parameters["lines1"].Value = lines;

                objSqlCommand.Parameters.Add("adcat3", MySqlDbType.VarChar);
                if (adcat3 == "")
                {
                    objSqlCommand.Parameters["adcat3"].Value = "0";
                }
                else
                {
                    objSqlCommand.Parameters["adcat3"].Value = adcat3;
                }
                objSqlCommand.Parameters.Add("adcat4", MySqlDbType.VarChar);
                if (adcat4 == "")
                {
                    objSqlCommand.Parameters["adcat4"].Value = "0";
                }
                else
                {
                    objSqlCommand.Parameters["adcat4"].Value = adcat4;
                }
                objSqlCommand.Parameters.Add("adcat5", MySqlDbType.VarChar);
                if (adcat5 == "")
                {

                    objSqlCommand.Parameters["adcat5"].Value = "0";
                }
                else
                {
                    objSqlCommand.Parameters["adcat5"].Value = adcat5;
                }

                objSqlCommand.Parameters.Add("clientcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["clientcode"].Value = clientcode;

                objSqlCommand.Parameters.Add("uomdesc", MySqlDbType.VarChar);
                objSqlCommand.Parameters["uomdesc"].Value = clientcode;

                objSqlCommand.Parameters.Add("agencycode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["agencycode"].Value = agencycode;



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

        public DataSet getinserts_combin(string compcode, string code, string desc, string agencytype)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("gettheinserts_combin", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("code1", MySqlDbType.VarChar);
                objSqlCommand.Parameters["code1"].Value = code;


                objSqlCommand.Parameters.Add("agencytype", MySqlDbType.VarChar);
                objSqlCommand.Parameters["agencytype"].Value = agencytype;


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

        public DataSet getbreakuprate_agency(string package, string noofinsertion, string insertiondate, string startdate, string dateformat, string compcode, string adcategory, string adsubcat, string color, string adtype, string currency, string ratecode, string clickdate, string flag, string code, string pck, string uom, string dealrate, string checkforor, string classinserts, string lines, string adcat3, string adcat4, string adcat5, string clientcode, string uomdesc, string agencycode)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("new_qbc_agency", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("package", MySqlDbType.VarChar);
                objSqlCommand.Parameters["package"].Value = package;

                objSqlCommand.Parameters.Add("noofinsertion", MySqlDbType.VarChar);
                objSqlCommand.Parameters["noofinsertion"].Value = noofinsertion;

                objSqlCommand.Parameters.Add("insertiondate", MySqlDbType.VarChar);
                objSqlCommand.Parameters["insertiondate"].Value = insertiondate;

                objSqlCommand.Parameters.Add("startdate", MySqlDbType.VarChar);
                objSqlCommand.Parameters["startdate"].Value = startdate;

                objSqlCommand.Parameters.Add("dateformat", MySqlDbType.VarChar);
                objSqlCommand.Parameters["dateformat"].Value = dateformat;

                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("adcategory", MySqlDbType.VarChar);
                objSqlCommand.Parameters["adcategory"].Value = adcategory;

                objSqlCommand.Parameters.Add("adsubcat", MySqlDbType.VarChar);
                objSqlCommand.Parameters["adsubcat"].Value = adsubcat;

                objSqlCommand.Parameters.Add("color1", MySqlDbType.VarChar);
                objSqlCommand.Parameters["color1"].Value = color;

                objSqlCommand.Parameters.Add("adtype", MySqlDbType.VarChar);
                objSqlCommand.Parameters["adtype"].Value = adtype;

                objSqlCommand.Parameters.Add("currency", MySqlDbType.VarChar);
                objSqlCommand.Parameters["currency"].Value = currency;

                objSqlCommand.Parameters.Add("ratecode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["ratecode"].Value = ratecode;

                objSqlCommand.Parameters.Add("clickdate", MySqlDbType.VarChar);
                objSqlCommand.Parameters["clickdate"].Value = clickdate;

                objSqlCommand.Parameters.Add("flag", MySqlDbType.Int64);
                if (flag == "" || flag == null)
                {
                    objSqlCommand.Parameters["flag"].Value = 0;
                }
                else
                {
                    objSqlCommand.Parameters["flag"].Value = Convert.ToInt32(flag);
                }

                objSqlCommand.Parameters.Add("code1", MySqlDbType.VarChar);
                objSqlCommand.Parameters["code1"].Value = code;

                objSqlCommand.Parameters.Add("pck", MySqlDbType.Decimal);
                if (pck == "" || pck == null || pck == "null")
                {
                    objSqlCommand.Parameters["pck"].Value = 0;
                }
                else
                {
                    objSqlCommand.Parameters["pck"].Value = Convert.ToDecimal(pck);
                }

                objSqlCommand.Parameters.Add("uom1", MySqlDbType.VarChar);
                objSqlCommand.Parameters["uom1"].Value = uom;

                objSqlCommand.Parameters.Add("dealrate", MySqlDbType.Decimal);
                if (dealrate == "" || dealrate == null || dealrate == "undefined")
                {
                    objSqlCommand.Parameters["dealrate"].Value = 0;
                }
                else
                {
                    objSqlCommand.Parameters["dealrate"].Value = Convert.ToDecimal(dealrate);
                }

                objSqlCommand.Parameters.Add("checkforor", MySqlDbType.VarChar);
                objSqlCommand.Parameters["checkforor"].Value = checkforor;

                objSqlCommand.Parameters.Add("classinserts", MySqlDbType.VarChar);
                objSqlCommand.Parameters["classinserts"].Value = classinserts;

                objSqlCommand.Parameters.Add("lines1", MySqlDbType.VarChar);
                objSqlCommand.Parameters["lines1"].Value = lines;

                objSqlCommand.Parameters.Add("adcat3", MySqlDbType.VarChar);
                if (adcat3 == "")
                {
                    objSqlCommand.Parameters["adcat3"].Value = "0";
                }
                else
                {
                    objSqlCommand.Parameters["adcat3"].Value = adcat3;
                }
                objSqlCommand.Parameters.Add("adcat4", MySqlDbType.VarChar);
                if (adcat4 == "")
                {
                    objSqlCommand.Parameters["adcat4"].Value = "0";
                }
                else
                {
                    objSqlCommand.Parameters["adcat4"].Value = adcat4;
                }
                objSqlCommand.Parameters.Add("adcat5", MySqlDbType.VarChar);
                if (adcat5 == "")
                {

                    objSqlCommand.Parameters["adcat5"].Value = "0";
                }
                else
                {
                    objSqlCommand.Parameters["adcat5"].Value = adcat5;
                }

                objSqlCommand.Parameters.Add("clientcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["clientcode"].Value = clientcode;

                objSqlCommand.Parameters.Add("uomdesc", MySqlDbType.VarChar);
                objSqlCommand.Parameters["uomdesc"].Value = uomdesc;

                /*new change ankur for agency*/

                objSqlCommand.Parameters.Add("agencycode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["agencycode"].Value = agencycode;



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

        public DataSet getInsertion_qbc_agency(string package, string noofinsertion, string insertiondate, string startdate, string dateformat, string compcode, string adcategory, string adsubcat, string color, string adtype, string currency, string ratecode, string clickdate, string flag, string code, string pck, string uom, string dealrate, string checkforor, string classinserts, string lines, string adcat3, string adcat4, string adcat5, string clientcode, string uomdesc, string agencycode)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("qbc_insertsrate_agency", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("package", MySqlDbType.VarChar);
                objSqlCommand.Parameters["package"].Value = package;

                objSqlCommand.Parameters.Add("noofinsertion", MySqlDbType.VarChar);
                objSqlCommand.Parameters["noofinsertion"].Value = noofinsertion;

                objSqlCommand.Parameters.Add("insertiondate", MySqlDbType.VarChar);
                objSqlCommand.Parameters["insertiondate"].Value = insertiondate;

                objSqlCommand.Parameters.Add("startdate", MySqlDbType.VarChar);
                objSqlCommand.Parameters["startdate"].Value = startdate;

                objSqlCommand.Parameters.Add("dateformat", MySqlDbType.VarChar);
                objSqlCommand.Parameters["dateformat"].Value = dateformat;

                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("adcategory", MySqlDbType.VarChar);
                objSqlCommand.Parameters["adcategory"].Value = adcategory;

                objSqlCommand.Parameters.Add("adsubcat", MySqlDbType.VarChar);
                objSqlCommand.Parameters["adsubcat"].Value = adsubcat;

                objSqlCommand.Parameters.Add("color", MySqlDbType.VarChar);
                objSqlCommand.Parameters["color"].Value = color;

                objSqlCommand.Parameters.Add("adtype", MySqlDbType.VarChar);
                objSqlCommand.Parameters["adtype"].Value = adtype;

                objSqlCommand.Parameters.Add("currency", MySqlDbType.VarChar);
                objSqlCommand.Parameters["currency"].Value = currency;

                objSqlCommand.Parameters.Add("ratecode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["ratecode"].Value = ratecode;

                objSqlCommand.Parameters.Add("clickdate", MySqlDbType.VarChar);
                objSqlCommand.Parameters["clickdate"].Value = clickdate;

                objSqlCommand.Parameters.Add("flag", MySqlDbType.Int24);
                /*new change ankur 11 feb*/
                if (flag == "" || flag == null || flag == "null")
                {
                    objSqlCommand.Parameters["flag"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["flag"].Value = Convert.ToInt32(flag);
                }

                objSqlCommand.Parameters.Add("code", MySqlDbType.VarChar);
                objSqlCommand.Parameters["code"].Value = code;

                objSqlCommand.Parameters.Add("pck", MySqlDbType.Decimal);
                /*new change ankur 11 feb*/
                if (pck == "" || pck == null || pck == "null")
                {
                    objSqlCommand.Parameters["pck"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["pck"].Value = Convert.ToDecimal(pck);
                }

                objSqlCommand.Parameters.Add("uom", MySqlDbType.VarChar);
                objSqlCommand.Parameters["uom"].Value = uom;

                objSqlCommand.Parameters.Add("dealrate", MySqlDbType.Decimal);
                /*new change ankur 11 feb*/
                if (dealrate == "" || dealrate == null || dealrate == "null")
                {
                    objSqlCommand.Parameters["dealrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["dealrate"].Value = Convert.ToDecimal(dealrate);
                }

                objSqlCommand.Parameters.Add("checkforor", MySqlDbType.VarChar);
                objSqlCommand.Parameters["checkforor"].Value = checkforor;

                objSqlCommand.Parameters.Add("classinserts", MySqlDbType.VarChar);
                objSqlCommand.Parameters["classinserts"].Value = classinserts;

                objSqlCommand.Parameters.Add("lines", MySqlDbType.VarChar);
                objSqlCommand.Parameters["lines"].Value = lines;

                objSqlCommand.Parameters.Add("adcat3", MySqlDbType.VarChar);
                if (adcat3 == "")
                {
                    objSqlCommand.Parameters["adcat3"].Value = "0";
                }
                else
                {
                    objSqlCommand.Parameters["adcat3"].Value = adcat3;
                }
                objSqlCommand.Parameters.Add("adcat4", MySqlDbType.VarChar);
                if (adcat4 == "")
                {
                    objSqlCommand.Parameters["adcat4"].Value = "0";
                }
                else
                {
                    objSqlCommand.Parameters["adcat4"].Value = adcat4;
                }
                objSqlCommand.Parameters.Add("adcat5", MySqlDbType.VarChar);
                if (adcat5 == "")
                {

                    objSqlCommand.Parameters["adcat5"].Value = "0";
                }
                else
                {
                    objSqlCommand.Parameters["adcat5"].Value = adcat5;
                }

                objSqlCommand.Parameters.Add("clientcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["clientcode"].Value = clientcode;

                objSqlCommand.Parameters.Add("uomdesc", MySqlDbType.VarChar);
                objSqlCommand.Parameters["uomdesc"].Value = uomdesc;


                objSqlCommand.Parameters.Add("agencycode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["agencycode"].Value = agencycode;


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


        public DataSet insertbookingqbc(string adsizetype, string branch, string booked_by, string prevbook, string date_time, string ciobookid, string approvedby, string audit, string rono, string rodate, string caption, string billstatus, string rostatus, string agency, string client, string agencyaddress, string clientaddresses, string agencycode, string dockitno, string execname, string execzone, string product, string brand, string keyno, string billremark, string printremark, string package, string insertion, string startdate, string repeatdate, string adtype, string adcategory, string subcategory, string color, string uom, string pageposition, string pagetype, string pageno, string adsizheight, string adsizwidth, string ratecode, string scheme, string currency, string agreedrate, string agreedamt, string spedisc, string spacedisx, string compcode, string userid, string specialcharges, string agencytype, string agencystatus, string paymode, string agencredit, string cardrate, string cardamount, string discount, string discountper, string billaddress, string totarea, string billcycle, string revenuecenter, string billpay, string billheight, string billwidth, string billto, string invoices, string vts, string tradedisc, string agencyout, string boxcode, string boxno, string boxaddress, string boxagency, string boxclient, string bookingtype, string tfn, string coupan, string campaign, string bill_amt, string pageprem, string pageamt, string premper, string grossamt, string adsizcolumn, string billcolumn, Decimal billarea, string specdiscper, string spacediscper, string paidins, string dealrate, string deviation, string varient, string contractname, string dealtype, string cardname, string cardtype, string cardmonth, string cardyear, string cardno, string receiptno, string adscat3, string adscat4, string adscat5, string bgcolor, string bulletcode, string bulletprm, string material, string receiptdate, string prevcioid, string prevreceipt, Decimal prev_ga, string region, string varient_name, string coltype, string logo_h, string logo_w, string logo_col, string logo_uom, string dateformat, string retainer, string addagencyrate, string mobileno, string addlamt, string retamt, string retper, string cashrecieved)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {

                objSqlConnection.Open();
                objSqlCommand = GetCommand("insertintobooking", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("date_time", MySqlDbType.Datetime);
                if (date_time == "" || date_time == null)
                {
                    objSqlCommand.Parameters["date_time"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "mm/dd/yyyy" && date_time != "")
                    {
                        string[] arr = null;
                        arr = date_time.Split("/".ToCharArray());
                        date_time = arr[2] + "-" + arr[0] + "-" + arr[1];

                    }
                    if (dateformat == "dd/mm/yyyy" && date_time != "")
                    {
                        string[] arr = null;
                        arr = date_time.Split("/".ToCharArray());
                        date_time = arr[2] + "-" + arr[1] + "-" + arr[0];

                    }
                    if (dateformat == "yyyy/mm/dd" && date_time != "")
                    {
                        string[] arr = null;
                        arr = date_time.Split("/".ToCharArray());
                        date_time = arr[0] + "-" + arr[1] + "-" + arr[2];

                    }
                    objSqlCommand.Parameters["date_time"].Value = date_time;
                }

                objSqlCommand.Parameters.Add("adsizetype", MySqlDbType.VarChar);
                objSqlCommand.Parameters["adsizetype"].Value = adsizetype;

                objSqlCommand.Parameters.Add("branch", MySqlDbType.VarChar);
                objSqlCommand.Parameters["branch"].Value = branch;

                objSqlCommand.Parameters.Add("booked_by", MySqlDbType.VarChar);
                objSqlCommand.Parameters["booked_by"].Value = booked_by;

                objSqlCommand.Parameters.Add("prevbook", MySqlDbType.VarChar);
                objSqlCommand.Parameters["prevbook"].Value = prevbook;

                objSqlCommand.Parameters.Add("approvedby", MySqlDbType.VarChar);
                objSqlCommand.Parameters["approvedby"].Value = approvedby;

                objSqlCommand.Parameters.Add("ciobookid", MySqlDbType.VarChar);
                objSqlCommand.Parameters["ciobookid"].Value = ciobookid;

                objSqlCommand.Parameters.Add("audit", MySqlDbType.VarChar);
                objSqlCommand.Parameters["audit"].Value = audit;

                objSqlCommand.Parameters.Add("rono", MySqlDbType.VarChar);
                objSqlCommand.Parameters["rono"].Value = rono;

                objSqlCommand.Parameters.Add("rodate", MySqlDbType.Datetime);
                if (rodate == "" || rodate == null)
                {
                    objSqlCommand.Parameters["rodate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "mm/dd/yyyy" && rodate != "")
                    {
                        string[] arr = null;
                        arr = rodate.Split("/".ToCharArray());
                        rodate = arr[2] + "-" + arr[0] + "-" + arr[1];

                    }
                    if (dateformat == "dd/mm/yyyy" && rodate != "")
                    {
                        string[] arr = null;
                        arr = rodate.Split("/".ToCharArray());
                        rodate = arr[2] + "-" + arr[1] + "-" + arr[0];

                    }
                    if (dateformat == "yyyy/mm/dd" && rodate != "")
                    {
                        string[] arr = null;
                        arr = rodate.Split("/".ToCharArray());
                        rodate = arr[0] + "-" + arr[1] + "-" + arr[2];

                    }
                    objSqlCommand.Parameters["rodate"].Value = rodate;
                }

                objSqlCommand.Parameters.Add("caption", MySqlDbType.VarChar);
                objSqlCommand.Parameters["caption"].Value = caption;

                objSqlCommand.Parameters.Add("billstatus", MySqlDbType.VarChar);
                objSqlCommand.Parameters["billstatus"].Value = billstatus;

                objSqlCommand.Parameters.Add("rostatus", MySqlDbType.VarChar);
                objSqlCommand.Parameters["rostatus"].Value = rostatus;

                objSqlCommand.Parameters.Add("agency", MySqlDbType.VarChar);
                objSqlCommand.Parameters["agency"].Value = agency;

                objSqlCommand.Parameters.Add("client", MySqlDbType.VarChar);
                objSqlCommand.Parameters["client"].Value = client;

                objSqlCommand.Parameters.Add("agencyaddress", MySqlDbType.VarChar);
                objSqlCommand.Parameters["agencyaddress"].Value = agencyaddress;

                objSqlCommand.Parameters.Add("clientaddresses", MySqlDbType.VarChar);
                objSqlCommand.Parameters["clientaddresses"].Value = clientaddresses;

                objSqlCommand.Parameters.Add("agencycode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["agencycode"].Value = agencycode;

                objSqlCommand.Parameters.Add("dockitno", MySqlDbType.VarChar);
                objSqlCommand.Parameters["dockitno"].Value = dockitno;

                objSqlCommand.Parameters.Add("execname", MySqlDbType.VarChar);
                objSqlCommand.Parameters["execname"].Value = execname;

                objSqlCommand.Parameters.Add("execzone", MySqlDbType.VarChar);
                objSqlCommand.Parameters["execzone"].Value = execzone;

                objSqlCommand.Parameters.Add("product", MySqlDbType.VarChar);
                objSqlCommand.Parameters["product"].Value = product;

                objSqlCommand.Parameters.Add("brand", MySqlDbType.VarChar);
                objSqlCommand.Parameters["brand"].Value = brand;

                objSqlCommand.Parameters.Add("keyno", MySqlDbType.VarChar);
                objSqlCommand.Parameters["keyno"].Value = keyno;

                objSqlCommand.Parameters.Add("billremark", MySqlDbType.VarChar);
                objSqlCommand.Parameters["billremark"].Value = billremark;

                objSqlCommand.Parameters.Add("printremark", MySqlDbType.VarChar);
                objSqlCommand.Parameters["printremark"].Value = printremark;

                objSqlCommand.Parameters.Add("package", MySqlDbType.VarChar);
                objSqlCommand.Parameters["package"].Value = package;

                objSqlCommand.Parameters.Add("insertion", MySqlDbType.Int64);
                if (insertion == "" || insertion == null)
                {
                    objSqlCommand.Parameters["insertion"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["insertion"].Value = Convert.ToInt32(insertion);
                }

                objSqlCommand.Parameters.Add("startdate", MySqlDbType.Datetime);
                if (startdate == "" || startdate == null)
                {
                    objSqlCommand.Parameters["startdate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "mm/dd/yyyy" && startdate != "")
                    {
                        string[] arr = null;
                        arr = startdate.Split("/".ToCharArray());
                        startdate = arr[2] + "-" + arr[0] + "-" + arr[1];

                    }
                    if (dateformat == "dd/mm/yyyy" && startdate != "")
                    {
                        string[] arr = null;
                        arr = startdate.Split("/".ToCharArray());
                        startdate = arr[2] + "-" + arr[1] + "-" + arr[0];

                    }
                    if (dateformat == "yyyy/mm/dd" && startdate != "")
                    {
                        string[] arr = null;
                        arr = startdate.Split("/".ToCharArray());
                        startdate = arr[0] + "-" + arr[1] + "-" + arr[2];

                    }
                    objSqlCommand.Parameters["startdate"].Value = startdate;
                }

                objSqlCommand.Parameters.Add("repeatdate", MySqlDbType.VarChar);

                objSqlCommand.Parameters["repeatdate"].Value = repeatdate;

                objSqlCommand.Parameters.Add("adtype", MySqlDbType.VarChar);
                objSqlCommand.Parameters["adtype"].Value = adtype;

                objSqlCommand.Parameters.Add("adcategory", MySqlDbType.VarChar);
                objSqlCommand.Parameters["adcategory"].Value = adcategory;

                objSqlCommand.Parameters.Add("subcategory", MySqlDbType.VarChar);
                objSqlCommand.Parameters["subcategory"].Value = subcategory;

                objSqlCommand.Parameters.Add("color", MySqlDbType.VarChar);
                objSqlCommand.Parameters["color"].Value = color;

                objSqlCommand.Parameters.Add("uom", MySqlDbType.VarChar);
                objSqlCommand.Parameters["uom"].Value = uom;

                objSqlCommand.Parameters.Add("pageposition", MySqlDbType.VarChar);
                objSqlCommand.Parameters["pageposition"].Value = pageposition;

                objSqlCommand.Parameters.Add("pagetype", MySqlDbType.VarChar);
                objSqlCommand.Parameters["pagetype"].Value = pagetype;

                objSqlCommand.Parameters.Add("pageno", MySqlDbType.Int64);
                if (pageno == "" || pageno == null)
                {
                    objSqlCommand.Parameters["pageno"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["pageno"].Value = Convert.ToInt32(pageno);
                }

                objSqlCommand.Parameters.Add("adsizheight", MySqlDbType.Decimal);
                if (adsizheight == "" || adsizheight == null)
                {
                    objSqlCommand.Parameters["adsizheight"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["adsizheight"].Value = Convert.ToDecimal(adsizheight);
                }

                objSqlCommand.Parameters.Add("adsizwidth", MySqlDbType.Decimal);
                if (adsizwidth == "" || adsizwidth == null)
                {
                    objSqlCommand.Parameters["adsizwidth"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["adsizwidth"].Value = Convert.ToDecimal(adsizwidth);
                }

                objSqlCommand.Parameters.Add("ratecode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["ratecode"].Value = ratecode;

                objSqlCommand.Parameters.Add("scheme", MySqlDbType.VarChar);
                objSqlCommand.Parameters["scheme"].Value = scheme;

                objSqlCommand.Parameters.Add("currency", MySqlDbType.VarChar);
                objSqlCommand.Parameters["currency"].Value = currency;

                objSqlCommand.Parameters.Add("agreedrate", MySqlDbType.Decimal);
                if (agreedrate == "" || agreedrate == null)
                {
                    objSqlCommand.Parameters["agreedrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["agreedrate"].Value = Convert.ToDecimal(agreedrate);
                }
                //    , , ,Session["compcode"].ToString(),Session["userid"].ToString()
                objSqlCommand.Parameters.Add("agreedamt", MySqlDbType.Decimal);
                if (agreedamt == "" || agreedamt == null)
                {
                    objSqlCommand.Parameters["agreedamt"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["agreedamt"].Value = Convert.ToDecimal(agreedamt);
                }

                objSqlCommand.Parameters.Add("spedisc", MySqlDbType.Decimal);
                if (spedisc == "" || spedisc == null)
                {
                    objSqlCommand.Parameters["spedisc"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["spedisc"].Value = Convert.ToDecimal(spedisc);
                }

                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("spacedisx", MySqlDbType.Decimal);
                if (spacedisx == "" || spacedisx == null)
                {
                    objSqlCommand.Parameters["spacedisx"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["spacedisx"].Value = Convert.ToDecimal(spacedisx);
                }

                objSqlCommand.Parameters.Add("specialcharges", MySqlDbType.Decimal);
                if (specialcharges == "" || specialcharges == null)
                {
                    objSqlCommand.Parameters["specialcharges"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["specialcharges"].Value = Convert.ToDecimal(specialcharges);
                }

                objSqlCommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objSqlCommand.Parameters["userid"].Value = userid;

                objSqlCommand.Parameters.Add("agencytype", MySqlDbType.VarChar);
                objSqlCommand.Parameters["agencytype"].Value = agencytype;

                objSqlCommand.Parameters.Add("agencystatus", MySqlDbType.VarChar);
                objSqlCommand.Parameters["agencystatus"].Value = agencystatus;

                objSqlCommand.Parameters.Add("paymode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["paymode"].Value = paymode;

                objSqlCommand.Parameters.Add("agencredit", MySqlDbType.Int64);
                if (agencredit == "" || agencredit == null)
                {
                    objSqlCommand.Parameters["agencredit"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["agencredit"].Value = Convert.ToInt32(agencredit);
                }

                objSqlCommand.Parameters.Add("cardrate", MySqlDbType.Decimal);
                if (cardrate == "" || cardrate == null)
                {
                    objSqlCommand.Parameters["cardrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["cardrate"].Value = Convert.ToDecimal(cardrate);
                }

                objSqlCommand.Parameters.Add("cardamount", MySqlDbType.Decimal);
                if (cardamount == "" || cardamount == null)
                {
                    objSqlCommand.Parameters["cardamount"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["cardamount"].Value = Convert.ToDecimal(cardamount);
                }

                objSqlCommand.Parameters.Add("discount", MySqlDbType.Decimal);
                if (discount == "" || discount == null)
                {
                    objSqlCommand.Parameters["discount"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["discount"].Value = Convert.ToDecimal(discount);
                }


                objSqlCommand.Parameters.Add("discountper", MySqlDbType.Decimal);
                if (discountper == "" || discountper == null)
                {
                    objSqlCommand.Parameters["discountper"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["discountper"].Value = Convert.ToDecimal(discountper);
                }

                objSqlCommand.Parameters.Add("billaddress", MySqlDbType.VarChar);
                objSqlCommand.Parameters["billaddress"].Value = billaddress;

                objSqlCommand.Parameters.Add("totarea", MySqlDbType.Decimal);
                if (totarea == "" || totarea == null)
                {
                    objSqlCommand.Parameters["totarea"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["totarea"].Value = Convert.ToDecimal(totarea);
                }


                objSqlCommand.Parameters.Add("billcycle", MySqlDbType.VarChar);
                objSqlCommand.Parameters["billcycle"].Value = billcycle;

                objSqlCommand.Parameters.Add("revenuecenter", MySqlDbType.VarChar);
                objSqlCommand.Parameters["revenuecenter"].Value = revenuecenter;

                objSqlCommand.Parameters.Add("billpay", MySqlDbType.VarChar);
                objSqlCommand.Parameters["billpay"].Value = billpay;

                objSqlCommand.Parameters.Add("billheight", MySqlDbType.Decimal);
                if (billheight == "" || billheight == null)
                {
                    objSqlCommand.Parameters["billheight"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["billheight"].Value = Convert.ToDecimal(billheight);
                }

                objSqlCommand.Parameters.Add("billwidth", MySqlDbType.Decimal);
                if (billwidth == "" || billwidth == null)
                {
                    objSqlCommand.Parameters["billwidth"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["billwidth"].Value = Convert.ToDecimal(billwidth);
                }

                //////, , , , , , , , , , , , , , , , , , , 

                objSqlCommand.Parameters.Add("billto", MySqlDbType.VarChar);
                objSqlCommand.Parameters["billto"].Value = billto;

                objSqlCommand.Parameters.Add("invoices", MySqlDbType.Int64);
                if (invoices == "" || invoices == null)
                {
                    objSqlCommand.Parameters["invoices"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["invoices"].Value = Convert.ToInt32(invoices);
                }

                objSqlCommand.Parameters.Add("vts", MySqlDbType.Int64);
                if (vts == "" || vts == null)
                {
                    objSqlCommand.Parameters["vts"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["vts"].Value = Convert.ToInt32(vts);
                }

                objSqlCommand.Parameters.Add("tradedisc", MySqlDbType.Decimal);
                if (tradedisc == "" || tradedisc == null)
                {
                    objSqlCommand.Parameters["tradedisc"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["tradedisc"].Value = Convert.ToDecimal(tradedisc);
                }

                objSqlCommand.Parameters.Add("agencyout", MySqlDbType.VarChar);
                objSqlCommand.Parameters["agencyout"].Value = agencyout;

                objSqlCommand.Parameters.Add("boxcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["boxcode"].Value = boxcode;

                objSqlCommand.Parameters.Add("boxno", MySqlDbType.VarChar);
                objSqlCommand.Parameters["boxno"].Value = boxno;

                objSqlCommand.Parameters.Add("boxaddress", MySqlDbType.VarChar);
                objSqlCommand.Parameters["boxaddress"].Value = boxaddress;

                objSqlCommand.Parameters.Add("boxagency", MySqlDbType.VarChar);
                objSqlCommand.Parameters["boxagency"].Value = boxagency;

                objSqlCommand.Parameters.Add("boxclient", MySqlDbType.VarChar);
                objSqlCommand.Parameters["boxclient"].Value = boxclient;

                objSqlCommand.Parameters.Add("bookingtype", MySqlDbType.VarChar);
                objSqlCommand.Parameters["bookingtype"].Value = bookingtype;

                objSqlCommand.Parameters.Add("tfn", MySqlDbType.VarChar);
                objSqlCommand.Parameters["tfn"].Value = tfn;

                objSqlCommand.Parameters.Add("coupan", MySqlDbType.VarChar);
                objSqlCommand.Parameters["coupan"].Value = coupan;

                objSqlCommand.Parameters.Add("campaign", MySqlDbType.VarChar);
                objSqlCommand.Parameters["campaign"].Value = campaign;


                objSqlCommand.Parameters.Add("bill_amt", MySqlDbType.Decimal);
                if (bill_amt == "" || bill_amt == null)
                {
                    objSqlCommand.Parameters["bill_amt"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["bill_amt"].Value = Convert.ToDecimal(bill_amt);
                }

                objSqlCommand.Parameters.Add("pageprem", MySqlDbType.VarChar);
                objSqlCommand.Parameters["pageprem"].Value = pageprem;


                objSqlCommand.Parameters.Add("pageamt", MySqlDbType.Decimal);
                if (pageamt == "" || pageamt == null)
                {
                    objSqlCommand.Parameters["pageamt"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["pageamt"].Value = Convert.ToDecimal(pageamt);
                }

                objSqlCommand.Parameters.Add("premper", MySqlDbType.Decimal);
                if (premper == "" || premper == null)
                {
                    objSqlCommand.Parameters["premper"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["premper"].Value = Convert.ToDecimal(premper);
                }

                objSqlCommand.Parameters.Add("grossamt", MySqlDbType.Decimal);
                if (grossamt == "" || grossamt == null)
                {
                    objSqlCommand.Parameters["grossamt"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["grossamt"].Value = Convert.ToDecimal(grossamt);
                }

                objSqlCommand.Parameters.Add("adsizcolumn", MySqlDbType.Decimal);
                if (adsizcolumn == "" || adsizcolumn == null)
                {
                    objSqlCommand.Parameters["adsizcolumn"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["adsizcolumn"].Value = Convert.ToDecimal(adsizcolumn);
                }

                objSqlCommand.Parameters.Add("billcolumn", MySqlDbType.Decimal);
                if (billcolumn == "" || billcolumn == null)
                {
                    objSqlCommand.Parameters["billcolumn"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["billcolumn"].Value = Convert.ToDecimal(billcolumn);
                }

                objSqlCommand.Parameters.Add("billarea", MySqlDbType.Decimal);

                objSqlCommand.Parameters["billarea"].Value = Convert.ToDecimal(billarea);

                objSqlCommand.Parameters.Add("specdiscper", MySqlDbType.Decimal);
                if (specdiscper == "" || specdiscper == null)
                {
                    objSqlCommand.Parameters["specdiscper"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["specdiscper"].Value = Convert.ToDecimal(specdiscper);
                }

                objSqlCommand.Parameters.Add("spacediscper", MySqlDbType.Decimal);
                if (spacediscper == "" || spacediscper == null)
                {
                    objSqlCommand.Parameters["spacediscper"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["spacediscper"].Value = Convert.ToDecimal(spacediscper);
                }

                objSqlCommand.Parameters.Add("paidins", MySqlDbType.Int64);
                if (paidins == "" || paidins == null)
                {
                    objSqlCommand.Parameters["paidins"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["paidins"].Value = Convert.ToInt32(paidins);
                }

                objSqlCommand.Parameters.Add("dealrate", MySqlDbType.Decimal);
                if (dealrate == "" || dealrate == null)
                {
                    objSqlCommand.Parameters["dealrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["dealrate"].Value = Convert.ToDecimal(dealrate);
                }

                objSqlCommand.Parameters.Add("deviation", MySqlDbType.Decimal);
                if (deviation == "" || deviation == null)
                {
                    objSqlCommand.Parameters["deviation"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["deviation"].Value = Convert.ToDecimal(deviation);
                }

                objSqlCommand.Parameters.Add("varient", MySqlDbType.VarChar);
                objSqlCommand.Parameters["varient"].Value = varient;

                objSqlCommand.Parameters.Add("contractname", MySqlDbType.VarChar);
                objSqlCommand.Parameters["contractname"].Value = contractname;

                objSqlCommand.Parameters.Add("dealtype", MySqlDbType.VarChar);
                objSqlCommand.Parameters["dealtype"].Value = dealtype;


                ////////////////
                objSqlCommand.Parameters.Add("cardname", MySqlDbType.VarChar);
                objSqlCommand.Parameters["cardname"].Value = cardname;

                objSqlCommand.Parameters.Add("cardtype", MySqlDbType.VarChar);
                objSqlCommand.Parameters["cardtype"].Value = cardtype;

                objSqlCommand.Parameters.Add("cardmonth", MySqlDbType.VarChar);
                objSqlCommand.Parameters["cardmonth"].Value = cardmonth;

                objSqlCommand.Parameters.Add("cardyear", MySqlDbType.VarChar);
                objSqlCommand.Parameters["cardyear"].Value = cardyear;

                objSqlCommand.Parameters.Add("cardno", MySqlDbType.VarChar);
                objSqlCommand.Parameters["cardno"].Value = cardno;

                objSqlCommand.Parameters.Add("receiptno", MySqlDbType.VarChar);
                objSqlCommand.Parameters["receiptno"].Value = receiptno;

                objSqlCommand.Parameters.Add("adscat3", MySqlDbType.VarChar);
                objSqlCommand.Parameters["adscat3"].Value = adscat3;

                objSqlCommand.Parameters.Add("adscat4", MySqlDbType.VarChar);
                objSqlCommand.Parameters["adscat4"].Value = adscat4;

                objSqlCommand.Parameters.Add("adscat5", MySqlDbType.VarChar);
                objSqlCommand.Parameters["adscat5"].Value = adscat5;

                objSqlCommand.Parameters.Add("bgcolor", MySqlDbType.VarChar);
                objSqlCommand.Parameters["bgcolor"].Value = bgcolor;

                objSqlCommand.Parameters.Add("bulletcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["bulletcode"].Value = bulletcode;

                objSqlCommand.Parameters.Add("bulletprm", MySqlDbType.Decimal);
                if (bulletprm == "" || bulletprm == null)
                {
                    objSqlCommand.Parameters["bulletprm"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["bulletprm"].Value = Convert.ToDecimal(bulletprm);
                }

                objSqlCommand.Parameters.Add("material", MySqlDbType.VarChar);
                objSqlCommand.Parameters["material"].Value = material;


                objSqlCommand.Parameters.Add("receiptdate", MySqlDbType.Datetime);
                if (receiptdate == "" || receiptdate == null)
                {
                    objSqlCommand.Parameters["receiptdate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "mm/dd/yyyy" && receiptdate != "")
                    {
                        string[] arr = null;
                        arr = receiptdate.Split("/".ToCharArray());
                        receiptdate = arr[2] + "-" + arr[0] + "-" + arr[1];

                    }
                    if (dateformat == "dd/mm/yyyy" && receiptdate != "")
                    {
                        string[] arr = null;
                        arr = receiptdate.Split("/".ToCharArray());
                        receiptdate = arr[2] + "-" + arr[1] + "-" + arr[0];

                    }
                    if (dateformat == "yyyy/mm/dd" && receiptdate != "")
                    {
                        string[] arr = null;
                        arr = receiptdate.Split("/".ToCharArray());
                        receiptdate = arr[0] + "-" + arr[1] + "-" + arr[2];

                    }
                    objSqlCommand.Parameters["receiptdate"].Value = receiptdate;
                }


                objSqlCommand.Parameters.Add("prevcioid", MySqlDbType.VarChar);
                objSqlCommand.Parameters["prevcioid"].Value = prevcioid;

                objSqlCommand.Parameters.Add("prevreceipt", MySqlDbType.VarChar);
                objSqlCommand.Parameters["prevreceipt"].Value = prevreceipt;

                objSqlCommand.Parameters.Add("prev_ga", MySqlDbType.Decimal);

                objSqlCommand.Parameters["prev_ga"].Value = prev_ga;



                objSqlCommand.Parameters.Add("region", MySqlDbType.VarChar);
                objSqlCommand.Parameters["region"].Value = region;

                objSqlCommand.Parameters.Add("varient_name", MySqlDbType.VarChar);
                objSqlCommand.Parameters["varient_name"].Value = varient_name;
                /*new change ankur 9 feb*/

                objSqlCommand.Parameters.Add("coltype", MySqlDbType.VarChar);
                objSqlCommand.Parameters["coltype"].Value = coltype;

                objSqlCommand.Parameters.Add("logo_h", MySqlDbType.VarChar);
                objSqlCommand.Parameters["logo_h"].Value = logo_h;

                objSqlCommand.Parameters.Add("logo_w", MySqlDbType.VarChar);
                objSqlCommand.Parameters["logo_w"].Value = logo_w;

                objSqlCommand.Parameters.Add("logo_col", MySqlDbType.VarChar);
                objSqlCommand.Parameters["logo_col"].Value = logo_col;

                objSqlCommand.Parameters.Add("logo_uom", MySqlDbType.VarChar);
                objSqlCommand.Parameters["logo_uom"].Value = logo_uom;

                // ad new parameter
                objSqlCommand.Parameters.Add("retainer1", MySqlDbType.VarChar);
                if (retainer.IndexOf("(") >= 0)
                {
                    retainer = retainer.Substring(retainer.IndexOf("(") + 1, retainer.Length - retainer.IndexOf("(") - 2);
                }
                objSqlCommand.Parameters["retainer1"].Value = retainer;

                objSqlCommand.Parameters.Add("addagencyrate", MySqlDbType.VarChar);
                objSqlCommand.Parameters["addagencyrate"].Value = addagencyrate;

                objSqlCommand.Parameters.Add("mobileno", MySqlDbType.VarChar);
                objSqlCommand.Parameters["mobileno"].Value = mobileno;

                objSqlCommand.Parameters.Add("addlamt", MySqlDbType.VarChar);
                objSqlCommand.Parameters["addlamt"].Value = addlamt;

                objSqlCommand.Parameters.Add("retamt", MySqlDbType.VarChar);
                objSqlCommand.Parameters["retamt"].Value = retamt;


                objSqlCommand.Parameters.Add("retper", MySqlDbType.VarChar);
                objSqlCommand.Parameters["retper"].Value = retper;

                objSqlCommand.Parameters.Add("cashrecieved", MySqlDbType.Decimal);
                if (cashrecieved == "")
                    objSqlCommand.Parameters["cashrecieved"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["cashrecieved"].Value = Convert.ToDecimal(cashrecieved);

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

        public DataSet getboxmatter(string retcode)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getboxmetter", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("retcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["retcode"].Value = retcode;



                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (MySqlException objException)
            {
                throw (objException);
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

        public DataSet autogenratedbox(string compcode, string auto, string no, string center1, string agncodesubcode)
        {

            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getautocodebox", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("auto1", MySqlDbType.VarChar);
                objSqlCommand.Parameters["auto1"].Value = auto;

                objSqlCommand.Parameters.Add("no1", MySqlDbType.VarChar);
                objSqlCommand.Parameters["no1"].Value = no;

                objSqlCommand.Parameters.Add("center1", MySqlDbType.VarChar);
                if (center1 == "" || center1 == "0")
                    objSqlCommand.Parameters["center1"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["center1"].Value = center1;

                objSqlCommand.Parameters.Add("agency_codescode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["agency_codescode"].Value = agncodesubcode;

                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (MySqlException objException)
            {
                throw (objException);
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

        //--------------------------- ad new (by rinki) --------------------------//
        public DataSet clsCioId(string s_agencycode)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_cioid", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("s_agencycode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["s_agencycode"].Value = s_agencycode;

                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (MySqlException objException)
            {
                throw (objException);
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


        public DataSet getReciptNo()
        {

            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Websp_Maxreceipt", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (MySqlException objException)
            {
                throw (objException);
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

        public DataSet getbgcolcode(string bgcolname)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getbgcolorcode", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("bgcolorname", MySqlDbType.VarChar);
                objSqlCommand.Parameters["bgcolorname"].Value = bgcolname;


                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (MySqlException objException)
            {
                throw (objException);
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

        public DataSet checkPrevId(string cioid)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("checkID_matter", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("cioid1", MySqlDbType.VarChar);
                objSqlCommand.Parameters["cioid1"].Value = cioid;

                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (MySqlException objException)
            {
                throw (objException);
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

        public DataSet getmaincode(string name, string code, string compname)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getmaincodeChk", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("pname", MySqlDbType.VarChar);
                objSqlCommand.Parameters["pname"].Value = name;

                objSqlCommand.Parameters.Add("pcode1", MySqlDbType.VarChar);
                objSqlCommand.Parameters["pcode1"].Value = code;

                objSqlCommand.Parameters.Add("pcompany", MySqlDbType.VarChar);
                objSqlCommand.Parameters["pcompany"].Value = compname;

                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (MySqlException objException)
            {
                throw (objException);
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

        public DataSet getAgencyCode(string compcode, string codesubcode)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getAgencyCode1", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("codesubcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["codesubcode"].Value = codesubcode;

                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (MySqlException objException)
            {
                throw (objException);
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


        public DataSet getPackageInsert(string pckcode, string cioid)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getPackageInsert", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("packagecode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["packagecode"].Value = pckcode;

                objSqlCommand.Parameters.Add("cioid", MySqlDbType.VarChar);
                objSqlCommand.Parameters["cioid"].Value = cioid;

                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (MySqlException objException)
            {
                throw (objException);
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

        public DataSet checkCIOIDReference(string compcode, string cioid)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("checkCioidRef", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("cioid", MySqlDbType.VarChar);
                objSqlCommand.Parameters["cioid"].Value = cioid;

                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (MySqlException objException)
            {
                throw (objException);
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
        //(insertdate, edition, premium1, premium2, premallow, adcategory, latestdate, material, cardrate, filename, discrate, insertstatus, billstatus, adsubcat, compcode, userid, cioid, height, width, totalsize, pagepost, premper1, premper2, colid, repeat, insertno, paid, agrrate/*insertinsertion*/, solorate, grossrate, insert_pageno, insert_remarks, page_code, page_per, no_ofcol, billamt, billrate, logo_h, logo_w, logo_name, cat3, cat4, cat5, pkgcodegrid_value, pkginsgrid_value, pkg_alias_value, insertid, cirvts, cirpub, ciredi, cirrate, cirdate, ciragency, ciragencysubcode, center, branch, splboldsizevalue, vatrate, boxcharge, vat_inc_p, grossamtlocal_p, billamtlocal_p, sectioncode_p, resourceno_p, insert_caption, subedidata, disc_, ip, agncyamnt, adlgncyamnt, spldisc, cashdisc, roundoffamt, pdfheightval, cpnamt, clicatamt, flatfreqamt, catamt, extrarate, premamtval, modifyrateaudit, peyecather, pdaywisepr,pgstamt,pgstgd);
        public DataSet insertbook_ins_update(string insertdate, string edition, string premium1, string premium2, string premallow, string adcategory, string latestdate, string material, string cardrate, string filename, string discrate, string insertstatus, string billstatus, string adsubcat, string compcode, string userid, string cioid, string height, string width, string totalsize, string pagepost, string premper1, string premper2, string colid, string repeat, string insertno, string paid, string agrrate/*insertinsertion*/, string solorate, string grossrate, string insert_pageno, string insert_remarks, string page_code, string page_per, string no_ofcol, string billamt, string billrate, string logo_h, string logo_w, string logo_name, string cat3, string cat4, string cat5, string pkgcodegrid_value, string pkginsgrid_value, string pkg_alias_value, string insertid, string cirvts, string cirpub, string ciredi, string cirrate, string cirdate, string ciragency, string ciragencysubcode, string center, string branch, string splboldsizevalue, string vatrate, string boxcharge, string vat_inc_p, string grossamtlocal_p, string billamtlocal_p, string sectioncode_p, string resourceno_p, string insert_caption, string subedidata, string disc_, string ip, string agncyamnt, string adlgncyamnt, string spldisc, string cashdisc, string roundoffamt, string pdfheightval, string cpnamt, string clicatamt, string flatfreqamt, string catamt, string extrarate, string premamtval, string modifyrateaudit, string peyecather, string pdaywisepr, string pgstamt, string pgstgd, string dateformat)
        //public DataSet insertbook_ins_update(string insertdate, string edition, string premium1, string premium2, string premallow, string adcategory, string latestdate, string material, string cardrate, string matfilename, string discrate, string insertstatus, string billstatus, string adsubcat, string compcode, string userid, string cioid, string height, string width, string totalsize, string pagepost, string premper1, string premper2, string colid, string repeat, string insertno, string paid, string agrrate, string solorate, string grossrate, string insert_pageno, string insert_remarks, string page_code, string page_per, string noofcol, string billamt, string billrate, string logo_h, string logo_w, string logo_name, string dateformat, string adcat3, string adcat4, string adcat5, string pkgcode, string gridins, string pkgalias, string insertid)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("insertintobookchild_update_insertintobookchild_update_p", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;



                objSqlCommand.Parameters.Add("insertdate", MySqlDbType.Datetime);
                if (insertdate == "" || insertdate == null)
                {
                    objSqlCommand.Parameters["insertdate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "mm/dd/yyyy" && insertdate != "")
                    {
                        string[] arr = null;
                        arr = insertdate.Split("/".ToCharArray());
                        insertdate = arr[0] + "-" + arr[1] + "-" + arr[2];

                    }
                    if (dateformat == "dd/mm/yyyy" && insertdate != "")
                    {
                        string[] arr = null;
                        arr = insertdate.Split("/".ToCharArray());
                        // insertdate = arr[1] + "-" + arr[0] + "-" + arr[2];
                        insertdate = arr[2] + "-" + arr[1] + "-" + arr[0];

                    }
                    if (dateformat == "yyyy/mm/dd" && insertdate != "")
                    {
                        string[] arr = null;
                        arr = insertdate.Split("/".ToCharArray());
                        insertdate = arr[1] + "-" + arr[2] + "-" + arr[0];

                    }
                    objSqlCommand.Parameters["insertdate"].Value = Convert.ToDateTime(insertdate).ToString("yyyy-MM-dd");
                }

                objSqlCommand.Parameters.Add("pedition", MySqlDbType.VarChar);
                objSqlCommand.Parameters["pedition"].Value = edition;

                objSqlCommand.Parameters.Add("premium1", MySqlDbType.VarChar);
                objSqlCommand.Parameters["premium1"].Value = premium1;

                objSqlCommand.Parameters.Add("premium2", MySqlDbType.VarChar);
                objSqlCommand.Parameters["premium2"].Value = premium2;

                objSqlCommand.Parameters.Add("premallow", MySqlDbType.VarChar);
                objSqlCommand.Parameters["premallow"].Value = premallow;

                objSqlCommand.Parameters.Add("adcategory", MySqlDbType.VarChar);
                objSqlCommand.Parameters["adcategory"].Value = adcategory;

                objSqlCommand.Parameters.Add("latestdate", MySqlDbType.Datetime);
                if (latestdate == "" || latestdate == null)
                {
                    objSqlCommand.Parameters["latestdate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "mm/dd/yyyy" && latestdate != "")
                    {
                        string[] arr = null;
                        arr = latestdate.Split("/".ToCharArray());
                        latestdate = arr[0] + "-" + arr[1] + "-" + arr[2];

                    }
                    if (dateformat == "dd/mm/yyyy" && latestdate != "")
                    {
                        string[] arr = null;
                        arr = latestdate.Split("/".ToCharArray());
                        // latestdate = arr[1] + "-" + arr[0] + "-" + arr[2];
                        latestdate = arr[2] + "-" + arr[1] + "-" + arr[0];

                    }
                    if (dateformat == "yyyy/mm/dd" && latestdate != "")
                    {
                        string[] arr = null;
                        arr = latestdate.Split("/".ToCharArray());
                        latestdate = arr[1] + "-" + arr[2] + "-" + arr[0];

                    }
                    objSqlCommand.Parameters["latestdate"].Value = Convert.ToDateTime(latestdate).ToString("yyyy-MM-dd"); ;
                }
                //,,,,,,,,,,,,,

                objSqlCommand.Parameters.Add("material", MySqlDbType.VarChar);
                objSqlCommand.Parameters["material"].Value = material;

                objSqlCommand.Parameters.Add("cardrate", MySqlDbType.Double);
                if (cardrate == "" || cardrate == null)
                {
                    objSqlCommand.Parameters["cardrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["cardrate"].Value = Convert.ToDouble(cardrate);
                }

                objSqlCommand.Parameters.Add("matfilename", MySqlDbType.VarChar);
                objSqlCommand.Parameters["matfilename"].Value = filename;

                objSqlCommand.Parameters.Add("discrate", MySqlDbType.Double);
                if (discrate == "" || discrate == null || discrate == "null")
                {
                    objSqlCommand.Parameters["discrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["discrate"].Value = Convert.ToDouble(discrate);
                }

                objSqlCommand.Parameters.Add("insertstatus", MySqlDbType.VarChar);
                objSqlCommand.Parameters["insertstatus"].Value = insertstatus;

                objSqlCommand.Parameters.Add("billstatus", MySqlDbType.VarChar);
                objSqlCommand.Parameters["billstatus"].Value = billstatus;

                objSqlCommand.Parameters.Add("adsubcat1", MySqlDbType.VarChar);
                objSqlCommand.Parameters["adsubcat1"].Value = adsubcat;

                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("puserid", MySqlDbType.VarChar);
                objSqlCommand.Parameters["puserid"].Value = userid;

                objSqlCommand.Parameters.Add("cioid", MySqlDbType.VarChar);
                objSqlCommand.Parameters["cioid"].Value = cioid;

                objSqlCommand.Parameters.Add("pheight", MySqlDbType.Double);
                if (height == "" || height == null)
                {
                    objSqlCommand.Parameters["pheight"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["pheight"].Value = Convert.ToDouble(height);
                }

                objSqlCommand.Parameters.Add("pwidth", MySqlDbType.Double);
                if (width == "" || width == null)
                {
                    objSqlCommand.Parameters["pwidth"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["pwidth"].Value = Convert.ToDouble(width);
                }

                objSqlCommand.Parameters.Add("totalsize", MySqlDbType.Double);
                if (totalsize == "" || totalsize == null)
                {
                    objSqlCommand.Parameters["totalsize"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["totalsize"].Value = Convert.ToDouble(totalsize);
                }

                objSqlCommand.Parameters.Add("pagepost", MySqlDbType.VarChar);
                objSqlCommand.Parameters["pagepost"].Value = pagepost;

                objSqlCommand.Parameters.Add("premper1", MySqlDbType.Double);
                if (premper1 == "" || premper1 == null)
                {
                    objSqlCommand.Parameters["premper1"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["premper1"].Value = Convert.ToDouble(premper1);
                }

                objSqlCommand.Parameters.Add("premper2", MySqlDbType.Double);
                if (premper2 == "" || premper2 == null)
                {
                    objSqlCommand.Parameters["premper2"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["premper2"].Value = Convert.ToDouble(premper2);
                }

                objSqlCommand.Parameters.Add("colid", MySqlDbType.VarChar);
                objSqlCommand.Parameters["colid"].Value = colid;

                objSqlCommand.Parameters.Add("Prepeat", MySqlDbType.Datetime);
                if (repeat == "" || repeat == null)
                {
                    objSqlCommand.Parameters["Prepeat"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "mm/dd/yyyy" && repeat != "")
                    {
                        string[] arr = null;
                        arr = repeat.Split("/".ToCharArray());
                        repeat = arr[0] + "-" + arr[1] + "-" + arr[2];

                    }
                    if (dateformat == "dd/mm/yyyy" && repeat != "")
                    {
                        string[] arr = null;
                        arr = repeat.Split("/".ToCharArray());
                        //repeat = arr[1] + "-" + arr[0] + "-" + arr[2];
                        repeat = arr[2] + "-" + arr[1] + "-" + arr[0];
                    }
                    if (dateformat == "yyyy/mm/dd" && repeat != "")
                    {
                        string[] arr = null;
                        arr = repeat.Split("/".ToCharArray());
                        repeat = arr[1] + "-" + arr[2] + "-" + arr[0];
                    }
                    objSqlCommand.Parameters["Prepeat"].Value = Convert.ToDateTime(repeat).ToString("yyyy-MM-dd");
                }

                objSqlCommand.Parameters.Add("insertno", MySqlDbType.Int32);
                if (insertno == "" || insertno == null)
                {
                    objSqlCommand.Parameters["insertno"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["insertno"].Value = Convert.ToInt32(insertno);
                }

                objSqlCommand.Parameters.Add("paid", MySqlDbType.VarChar);
                objSqlCommand.Parameters["paid"].Value = paid;

                objSqlCommand.Parameters.Add("agrrate", MySqlDbType.Double);
                if (agrrate == "" || agrrate == null || agrrate == "null")
                {
                    objSqlCommand.Parameters["agrrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["agrrate"].Value = Convert.ToDouble(agrrate);
                }

                objSqlCommand.Parameters.Add("solorate", MySqlDbType.Double);
                if (solorate == "" || solorate == null)
                {
                    objSqlCommand.Parameters["solorate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["solorate"].Value = Convert.ToDouble(solorate);
                }

                objSqlCommand.Parameters.Add("grossrate", MySqlDbType.Double);
                if (grossrate == "" || grossrate == null)
                {
                    objSqlCommand.Parameters["grossrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["grossrate"].Value = Convert.ToDouble(grossrate);
                }

                objSqlCommand.Parameters.Add("insert_pageno", MySqlDbType.Double);
                if (insert_pageno == "" || insert_pageno == null)
                {
                    objSqlCommand.Parameters["insert_pageno"].Value = Convert.ToDouble("0");
                }
                else
                {
                    objSqlCommand.Parameters["insert_pageno"].Value = Convert.ToDouble(insert_pageno);
                }

                objSqlCommand.Parameters.Add("insert_remarks", MySqlDbType.VarChar);
                objSqlCommand.Parameters["insert_remarks"].Value = insert_remarks;

                objSqlCommand.Parameters.Add("page_code", MySqlDbType.VarChar);
                objSqlCommand.Parameters["page_code"].Value = page_code;

                objSqlCommand.Parameters.Add("page_per", MySqlDbType.Double);
                if (page_per == "" || page_per == null)
                {
                    objSqlCommand.Parameters["page_per"].Value = Convert.ToDecimal("0");
                }
                else
                {
                    objSqlCommand.Parameters["page_per"].Value = Convert.ToDouble(page_per);
                }

                objSqlCommand.Parameters.Add("noofcol", MySqlDbType.Double);
                if (no_ofcol == "" || no_ofcol == null)
                {
                    objSqlCommand.Parameters["noofcol"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["noofcol"].Value = Convert.ToDouble(no_ofcol);
                }

                objSqlCommand.Parameters.Add("billamt", MySqlDbType.Double);
                if (billamt == "" || billamt == null)
                {
                    objSqlCommand.Parameters["billamt"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["billamt"].Value = Convert.ToDouble(billamt);
                }

                objSqlCommand.Parameters.Add("billrate", MySqlDbType.Double);
                if (billrate == "" || billrate == null)
                {
                    objSqlCommand.Parameters["billrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["billrate"].Value = Convert.ToDouble(billrate);
                }

                objSqlCommand.Parameters.Add("logo_h", MySqlDbType.VarChar);
                objSqlCommand.Parameters["logo_h"].Value = logo_h;

                objSqlCommand.Parameters.Add("logo_w", MySqlDbType.VarChar);
                objSqlCommand.Parameters["logo_w"].Value = logo_w;

                objSqlCommand.Parameters.Add("logo_name", MySqlDbType.VarChar);
                objSqlCommand.Parameters["logo_name"].Value = logo_name;
                //, string adcat3, string adcat4, string adcat5, string pkgcode, string gridins, string pkgalias

                objSqlCommand.Parameters.Add("ad_cat_3", MySqlDbType.VarChar);
                objSqlCommand.Parameters["ad_cat_3"].Value = cat3;

                objSqlCommand.Parameters.Add("ad_cat_4", MySqlDbType.VarChar);
                objSqlCommand.Parameters["ad_cat_4"].Value = cat4;

                objSqlCommand.Parameters.Add("ad_cat_5", MySqlDbType.VarChar);
                objSqlCommand.Parameters["ad_cat_5"].Value = cat5;

                objSqlCommand.Parameters.Add("pkgcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["pkgcode"].Value = pkgcodegrid_value;

                objSqlCommand.Parameters.Add("gridins", MySqlDbType.VarChar);
                objSqlCommand.Parameters["gridins"].Value = pkginsgrid_value;

                objSqlCommand.Parameters.Add("pkgalias", MySqlDbType.VarChar);
                objSqlCommand.Parameters["pkgalias"].Value = pkg_alias_value;

                objSqlCommand.Parameters.Add("insertid1", MySqlDbType.VarChar);
                if (insertid == "" || insertid == null)
                {
                    objSqlCommand.Parameters["insertid1"].Value = "0";
                }
                else
                {
                    objSqlCommand.Parameters["insertid1"].Value = insertid;
                }

                objSqlCommand.Parameters.Add("cirvts", MySqlDbType.VarChar);
                objSqlCommand.Parameters["cirvts"].Value = cirvts;

                objSqlCommand.Parameters.Add("cirpub", MySqlDbType.VarChar);
                objSqlCommand.Parameters["cirpub"].Value = cirpub;

                objSqlCommand.Parameters.Add("ciredi", MySqlDbType.VarChar);
                objSqlCommand.Parameters["ciredi"].Value = ciredi;

                objSqlCommand.Parameters.Add("cirrate", MySqlDbType.VarChar);
                objSqlCommand.Parameters["cirrate"].Value = cirrate;

                objSqlCommand.Parameters.Add("cirdate_v", MySqlDbType.Datetime);
                if (cirdate == "" || cirdate == null)
                {
                    objSqlCommand.Parameters["cirdate_v"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "mm/dd/yyyy" && cirdate != "")
                    {
                        string[] arr = null;
                        arr = cirdate.Split("/".ToCharArray());
                        cirdate = arr[0] + "-" + arr[1] + "-" + arr[2];
                    }
                    if (dateformat == "dd/mm/yyyy" && cirdate != "")
                    {
                        string[] arr = null;
                        arr = cirdate.Split("/".ToCharArray());
                        //cirdate = arr[1] + "-" + arr[0] + "-" + arr[2];
                        cirdate = arr[2] + "-" + arr[1] + "-" + arr[0];

                    }
                    if (dateformat == "yyyy/mm/dd" && cirdate != "")
                    {
                        string[] arr = null;
                        arr = cirdate.Split("/".ToCharArray());
                        cirdate = arr[1] + "-" + arr[2] + "-" + arr[0];
                    }
                    objSqlCommand.Parameters["cirdate_v"].Value = Convert.ToDateTime(cirdate).ToString("yyyy-MM-dd");
                }

                objSqlCommand.Parameters.Add("ciragency_v", MySqlDbType.VarChar);
                objSqlCommand.Parameters["ciragency_v"].Value = ciragency;

                objSqlCommand.Parameters.Add("ciragencysubcode_v", MySqlDbType.VarChar);
                objSqlCommand.Parameters["ciragencysubcode_v"].Value = ciragencysubcode;

                objSqlCommand.Parameters.Add("center_v", MySqlDbType.VarChar);
                objSqlCommand.Parameters["center_v"].Value = center;

                objSqlCommand.Parameters.Add("branch_v", MySqlDbType.VarChar);
                objSqlCommand.Parameters["branch_v"].Value = branch;

                objSqlCommand.Parameters.Add("splboldsizevalue", MySqlDbType.VarChar);
                objSqlCommand.Parameters["splboldsizevalue"].Value = splboldsizevalue;

                objSqlCommand.Parameters.Add("vatrate_p", MySqlDbType.Double);
                if (vatrate == "" || vatrate == null)
                {
                    objSqlCommand.Parameters["vatrate_p"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["vatrate_p"].Value = Convert.ToDouble(vatrate);
                }

                objSqlCommand.Parameters.Add("boxcharge_p", MySqlDbType.Double);
                if (boxcharge == "" || boxcharge == null)
                {
                    objSqlCommand.Parameters["boxcharge_p"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["boxcharge_p"].Value = Convert.ToDouble(boxcharge);
                }

                objSqlCommand.Parameters.Add("vat_inc_p", MySqlDbType.VarChar);
                objSqlCommand.Parameters["vat_inc_p"].Value = vat_inc_p;

                objSqlCommand.Parameters.Add("grossamtlocal_p", MySqlDbType.Double);
                if (grossamtlocal_p == "" || grossamtlocal_p == null)
                {
                    objSqlCommand.Parameters["grossamtlocal_p"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["grossamtlocal_p"].Value = Convert.ToDouble(grossamtlocal_p);
                }

                objSqlCommand.Parameters.Add("billamtlocal_p", MySqlDbType.Double);
                if (billamtlocal_p == "" || billamtlocal_p == null)
                {
                    objSqlCommand.Parameters["billamtlocal_p"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["billamtlocal_p"].Value = Convert.ToDouble(billamtlocal_p);
                }

                objSqlCommand.Parameters.Add("sectioncode_p", MySqlDbType.VarChar);
                objSqlCommand.Parameters["sectioncode_p"].Value = sectioncode_p;

                objSqlCommand.Parameters.Add("resourceno_p", MySqlDbType.VarChar);
                objSqlCommand.Parameters["resourceno_p"].Value = resourceno_p;

                objSqlCommand.Parameters.Add("caption_inserts_p", MySqlDbType.VarChar);
                objSqlCommand.Parameters["caption_inserts_p"].Value = insert_caption;

                objSqlCommand.Parameters.Add("subedidata", MySqlDbType.VarChar);
                objSqlCommand.Parameters["subedidata"].Value = subedidata;

                objSqlCommand.Parameters.Add("disc_p", MySqlDbType.Double);
                if (disc_ == "" || disc_ == null)
                {
                    objSqlCommand.Parameters["disc_p"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["disc_p"].Value = Convert.ToDouble(disc_);
                }

                objSqlCommand.Parameters.Add("P_ip", MySqlDbType.VarChar);
                objSqlCommand.Parameters["P_ip"].Value = ip;

                objSqlCommand.Parameters.Add("agncyamnt", MySqlDbType.VarChar);
                objSqlCommand.Parameters["agncyamnt"].Value = agncyamnt;

                objSqlCommand.Parameters.Add("adlgncyamnt", MySqlDbType.VarChar);
                objSqlCommand.Parameters["adlgncyamnt"].Value = adlgncyamnt;

                objSqlCommand.Parameters.Add("spldiscamt", MySqlDbType.VarChar);
                objSqlCommand.Parameters["spldiscamt"].Value = spldisc;

                objSqlCommand.Parameters.Add("cashdamnt", MySqlDbType.VarChar);
                objSqlCommand.Parameters["cashdamnt"].Value = cashdisc;

                objSqlCommand.Parameters.Add("ROUNDOFF", MySqlDbType.Double);
                if (roundoffamt == "" || roundoffamt == null)
                {
                    objSqlCommand.Parameters["ROUNDOFF"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["ROUNDOFF"].Value = Convert.ToDouble(roundoffamt);
                }

                objSqlCommand.Parameters.Add("PDFHEIGHT", MySqlDbType.Double);
                if (pdfheightval == "" || pdfheightval == null)
                {
                    objSqlCommand.Parameters["PDFHEIGHT"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["PDFHEIGHT"].Value = Convert.ToDouble(pdfheightval);
                }

                objSqlCommand.Parameters.Add("CPNAMT", MySqlDbType.Double);
                if (cpnamt == "" || cpnamt == null)
                {
                    objSqlCommand.Parameters["CPNAMT"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["CPNAMT"].Value = Convert.ToDouble(cpnamt);
                }

                objSqlCommand.Parameters.Add("clientcatamt", MySqlDbType.Double);
                if (clicatamt == "" || clicatamt == null)
                {
                    objSqlCommand.Parameters["clientcatamt"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["clientcatamt"].Value = Convert.ToDouble(clicatamt);
                }

                objSqlCommand.Parameters.Add("flatfreqamt", MySqlDbType.Double);
                if (flatfreqamt == "" || flatfreqamt == null)
                {
                    objSqlCommand.Parameters["flatfreqamt"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["flatfreqamt"].Value = Convert.ToDouble(flatfreqamt);
                }

                objSqlCommand.Parameters.Add("catamt", MySqlDbType.Double);
                if (catamt == "" || catamt == null)
                {
                    objSqlCommand.Parameters["catamt"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["catamt"].Value = Convert.ToDouble(catamt);
                }

                objSqlCommand.Parameters.Add("extrarate", MySqlDbType.Double);
                if (extrarate == "" || extrarate == null)
                {
                    objSqlCommand.Parameters["extrarate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["extrarate"].Value = Convert.ToDouble(extrarate);
                }

                objSqlCommand.Parameters.Add("premamtval", MySqlDbType.Double);
                if (premamtval == "" || premamtval == null)
                {
                    objSqlCommand.Parameters["premamtval"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["premamtval"].Value = Convert.ToDouble(premamtval);
                }

                objSqlCommand.Parameters.Add("P_RATE_AUDIT_FLAG", MySqlDbType.VarChar);
                objSqlCommand.Parameters["P_RATE_AUDIT_FLAG"].Value = modifyrateaudit;

                objSqlCommand.Parameters.Add("peyecather", MySqlDbType.Double);
                if (peyecather == "" || peyecather == null)
                {
                    objSqlCommand.Parameters["peyecather"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["peyecather"].Value = Convert.ToDouble(peyecather);
                }

                objSqlCommand.Parameters.Add("pdaywisepr", MySqlDbType.Double);
                if (pdaywisepr == "" || pdaywisepr == null)
                {
                    objSqlCommand.Parameters["pdaywisepr"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["pdaywisepr"].Value = Convert.ToDouble(pdaywisepr);
                }

                objSqlCommand.Parameters.Add("pgstamt", MySqlDbType.Double);
                if (pgstamt == "" || pgstamt == null)
                {
                    objSqlCommand.Parameters["pgstamt"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["pgstamt"].Value = Convert.ToDouble(pgstamt);
                }

                objSqlCommand.Parameters.Add("pgstgd", MySqlDbType.VarChar);
                objSqlCommand.Parameters["pgstgd"].Value = pgstgd;

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

        /*
        public DataSet insertbook_ins_update(string insertdate, string edition, string premium1, string premium2, string premallow, string adcategory, string latestdate, string material, string cardrate, string matfilename, string discrate, string insertstatus, string billstatus, string adsubcat, string compcode, string userid, string cioid, string height, string width, string totalsize, string pagepost, string premper1, string premper2, string colid, string repeat, string insertno, string paid, string agrrate, string solorate, string grossrate, string insert_pageno, string insert_remarks, string page_code, string page_per, string noofcol, string billamt, string billrate, string logo_h, string logo_w, string logo_name, string dateformat, string adcat3, string adcat4, string adcat5, string pkgcode, string gridins, string pkgalias, string insertid)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("insertintobookchild_update", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("insertdate", MySqlDbType.Datetime);
                if (insertdate == "" || insertdate == null)
                {
                    objSqlCommand.Parameters["insertdate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "mm/dd/yyyy" && insertdate != "")
                    {
                        string[] arr = null;
                        arr = insertdate.Split("/".ToCharArray());
                        insertdate = arr[0] + "-" + arr[1] + "-" + arr[2];

                    }
                    if (dateformat == "dd/mm/yyyy" && insertdate != "")
                    {
                        string[] arr = null;
                        arr = insertdate.Split("/".ToCharArray());
                        insertdate = arr[1] + "-" + arr[0] + "-" + arr[2];

                    }
                    if (dateformat == "yyyy/mm/dd" && insertdate != "")
                    {
                        string[] arr = null;
                        arr = insertdate.Split("/".ToCharArray());
                        insertdate = arr[1] + "-" + arr[2] + "-" + arr[0];

                    }
                    objSqlCommand.Parameters["insertdate"].Value = Convert.ToDateTime(insertdate).ToString("yyyy-MM-dd");
                }

                objSqlCommand.Parameters.Add("edition", MySqlDbType.VarChar);
                objSqlCommand.Parameters["edition"].Value = edition;

                objSqlCommand.Parameters.Add("premium1", MySqlDbType.VarChar);
                objSqlCommand.Parameters["premium1"].Value = premium1;

                objSqlCommand.Parameters.Add("premium2", MySqlDbType.VarChar);
                objSqlCommand.Parameters["premium2"].Value = premium2;

                objSqlCommand.Parameters.Add("premallow", MySqlDbType.VarChar);
                objSqlCommand.Parameters["premallow"].Value = premallow;

                objSqlCommand.Parameters.Add("adcategory", MySqlDbType.VarChar);
                objSqlCommand.Parameters["adcategory"].Value = adcategory;

                objSqlCommand.Parameters.Add("latestdate", MySqlDbType.Datetime);
                if (latestdate == "" || latestdate == null)
                {
                    objSqlCommand.Parameters["latestdate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "mm/dd/yyyy" && latestdate != "")
                    {
                        string[] arr = null;
                        arr = latestdate.Split("/".ToCharArray());
                        latestdate = arr[0] + "-" + arr[1] + "-" + arr[2];

                    }
                    if (dateformat == "dd/mm/yyyy" && latestdate != "")
                    {
                        string[] arr = null;
                        arr = latestdate.Split("/".ToCharArray());
                        latestdate = arr[1] + "-" + arr[0] + "-" + arr[2];

                    }
                    if (dateformat == "yyyy/mm/dd" && latestdate != "")
                    {
                        string[] arr = null;
                        arr = latestdate.Split("/".ToCharArray());
                        latestdate = arr[1] + "-" + arr[2] + "-" + arr[0];

                    }
                    objSqlCommand.Parameters["latestdate"].Value = Convert.ToDateTime(latestdate).ToString("yyyy-MM-dd"); ;
                }
                //,,,,,,,,,,,,,

                objSqlCommand.Parameters.Add("material", MySqlDbType.VarChar);
                objSqlCommand.Parameters["material"].Value = material;

                objSqlCommand.Parameters.Add("cardrate", MySqlDbType.Decimal);
                if (cardrate == "" || cardrate == null)
                {
                    objSqlCommand.Parameters["cardrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["cardrate"].Value = Convert.ToDecimal(cardrate);
                }

                objSqlCommand.Parameters.Add("matfilename", MySqlDbType.VarChar);
                objSqlCommand.Parameters["matfilename"].Value = matfilename;

                objSqlCommand.Parameters.Add("discrate", MySqlDbType.Decimal);
                if (discrate == "" || discrate == null || discrate == "null")
                {
                    objSqlCommand.Parameters["discrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["discrate"].Value = Convert.ToDecimal(discrate);
                }

                objSqlCommand.Parameters.Add("insertstatus", MySqlDbType.VarChar);
                objSqlCommand.Parameters["insertstatus"].Value = insertstatus;

                objSqlCommand.Parameters.Add("billstatus", MySqlDbType.VarChar);
                objSqlCommand.Parameters["billstatus"].Value = billstatus;

                objSqlCommand.Parameters.Add("adsubcat", MySqlDbType.VarChar);
                objSqlCommand.Parameters["adsubcat"].Value = adsubcat;





                objSqlCommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objSqlCommand.Parameters["userid"].Value = userid;


                objSqlCommand.Parameters.Add("cioid", MySqlDbType.VarChar);
                objSqlCommand.Parameters["cioid"].Value = cioid;

                //

                objSqlCommand.Parameters.Add("height", MySqlDbType.Decimal);
                if (height == "" || height == null)
                {
                    objSqlCommand.Parameters["height"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["height"].Value = Convert.ToDecimal(height);
                }

                objSqlCommand.Parameters.Add("width", MySqlDbType.Decimal);
                if (width == "" || width == null)
                {
                    objSqlCommand.Parameters["width"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["width"].Value = Convert.ToDecimal(width);
                }

                objSqlCommand.Parameters.Add("totalsize", MySqlDbType.Decimal);
                if (totalsize == "" || totalsize == null)
                {
                    objSqlCommand.Parameters["totalsize"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["totalsize"].Value = Convert.ToDecimal(totalsize);
                }

                objSqlCommand.Parameters.Add("pagepost", MySqlDbType.VarChar);
                objSqlCommand.Parameters["pagepost"].Value = pagepost;

                objSqlCommand.Parameters.Add("premper1", MySqlDbType.Decimal);
                if (premper1 == "" || premper1 == null)
                {
                    objSqlCommand.Parameters["premper1"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["premper1"].Value = Convert.ToDecimal(premper1);
                }

                objSqlCommand.Parameters.Add("premper2", MySqlDbType.Decimal);
                if (premper2 == "" || premper2 == null)
                {
                    objSqlCommand.Parameters["premper2"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["premper2"].Value = Convert.ToDecimal(premper2);
                }

                objSqlCommand.Parameters.Add("colid", MySqlDbType.VarChar);
                objSqlCommand.Parameters["colid"].Value = colid;

                objSqlCommand.Parameters.Add("repeat1", MySqlDbType.Datetime);
                if (repeat == "" || repeat == null)
                {
                    objSqlCommand.Parameters["repeat1"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "mm/dd/yyyy" && repeat != "")
                    {
                        string[] arr = null;
                        arr = repeat.Split("/".ToCharArray());
                        repeat = arr[0] + "-" + arr[1] + "-" + arr[2];

                    }
                    if (dateformat == "dd/mm/yyyy" && repeat != "")
                    {
                        string[] arr = null;
                        arr = repeat.Split("/".ToCharArray());
                        repeat = arr[1] + "-" + arr[0] + "-" + arr[2];

                    }
                    if (dateformat == "yyyy/mm/dd" && repeat != "")
                    {
                        string[] arr = null;
                        arr = repeat.Split("/".ToCharArray());
                        repeat = arr[1] + "-" + arr[2] + "-" + arr[0];

                    }
                    objSqlCommand.Parameters["repeat1"].Value = Convert.ToDateTime(repeat).ToString("yyyy-MM-dd");
                }




                objSqlCommand.Parameters.Add("insertno", MySqlDbType.Int64);
                if (insertno == "" || insertno == null)
                {
                    objSqlCommand.Parameters["insertno"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["insertno"].Value = Convert.ToInt32(insertno);
                }

                objSqlCommand.Parameters.Add("paid", MySqlDbType.VarChar);
                objSqlCommand.Parameters["paid"].Value = paid;

                objSqlCommand.Parameters.Add("agrrate", MySqlDbType.Decimal);
                if (agrrate == "" || agrrate == null || agrrate == "null")
                {
                    objSqlCommand.Parameters["agrrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["agrrate"].Value = Convert.ToDecimal(agrrate);
                }

                objSqlCommand.Parameters.Add("solorate", MySqlDbType.Decimal);
                if (solorate == "" || solorate == null)
                {
                    objSqlCommand.Parameters["solorate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["solorate"].Value = Convert.ToDecimal(solorate);
                }

                objSqlCommand.Parameters.Add("grossrate", MySqlDbType.Decimal);
                if (grossrate == "" || grossrate == null)
                {
                    objSqlCommand.Parameters["grossrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["grossrate"].Value = Convert.ToDecimal(grossrate);
                }

                objSqlCommand.Parameters.Add("insert_remarks", MySqlDbType.VarChar);
                objSqlCommand.Parameters["insert_remarks"].Value = insert_remarks;

                objSqlCommand.Parameters.Add("insert_pageno", MySqlDbType.Int64);
                if (insert_pageno == "" || insert_pageno == null)
                {
                    objSqlCommand.Parameters["insert_pageno"].Value = Convert.ToInt32("0");
                }
                else
                {
                    objSqlCommand.Parameters["insert_pageno"].Value = Convert.ToInt32(insert_pageno);
                }

                objSqlCommand.Parameters.Add("page_code", MySqlDbType.VarChar);
                objSqlCommand.Parameters["page_code"].Value = page_code;

                objSqlCommand.Parameters.Add("page_per", MySqlDbType.Decimal);
                if (page_per == "" || page_per == null)
                {
                    objSqlCommand.Parameters["page_per"].Value = Convert.ToDecimal("0");
                }
                else
                {
                    objSqlCommand.Parameters["page_per"].Value = Convert.ToDecimal(page_per);
                }

                objSqlCommand.Parameters.Add("noofcol", MySqlDbType.Decimal);
                if (noofcol == "" || noofcol == null)
                {
                    objSqlCommand.Parameters["noofcol"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["noofcol"].Value = Convert.ToDecimal(noofcol);
                }

                objSqlCommand.Parameters.Add("billamt", MySqlDbType.Decimal);
                if (billamt == "" || billamt == null)
                {
                    objSqlCommand.Parameters["billamt"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["billamt"].Value = Convert.ToDecimal(billamt);
                }


                objSqlCommand.Parameters.Add("billrate", MySqlDbType.Decimal);
                if (billrate == "" || billrate == null)
                {
                    objSqlCommand.Parameters["billrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["billrate"].Value = Convert.ToDecimal(billrate);
                }


                objSqlCommand.Parameters.Add("logo_h", MySqlDbType.VarChar);
                objSqlCommand.Parameters["logo_h"].Value = logo_h;

                objSqlCommand.Parameters.Add("logo_w", MySqlDbType.VarChar);
                objSqlCommand.Parameters["logo_w"].Value = logo_w;

                objSqlCommand.Parameters.Add("logo_name", MySqlDbType.VarChar);
                objSqlCommand.Parameters["logo_name"].Value = logo_name;
                //, string adcat3, string adcat4, string adcat5, string pkgcode, string gridins, string pkgalias

                objSqlCommand.Parameters.Add("adcat3", MySqlDbType.VarChar);
                objSqlCommand.Parameters["adcat3"].Value = adcat3;

                objSqlCommand.Parameters.Add("adcat4", MySqlDbType.VarChar);
                objSqlCommand.Parameters["adcat4"].Value = adcat4;

                objSqlCommand.Parameters.Add("adcat5", MySqlDbType.VarChar);
                objSqlCommand.Parameters["adcat5"].Value = adcat5;

                objSqlCommand.Parameters.Add("pkgcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["pkgcode"].Value = pkgcode;

                objSqlCommand.Parameters.Add("gridins", MySqlDbType.VarChar);
                objSqlCommand.Parameters["gridins"].Value = gridins;

                objSqlCommand.Parameters.Add("pkgalias", MySqlDbType.VarChar);
                objSqlCommand.Parameters["pkgalias"].Value = pkgalias;

                objSqlCommand.Parameters.Add("insertid", MySqlDbType.Int24);
                if (insertid == "" || insertid == null)
                {
                    objSqlCommand.Parameters["insertid"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["insertid"].Value = Convert.ToInt32(insertid);
                }

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
        */
        public DataSet getAgencyStatus(string compcode, string codesubcode)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getAgencyStatus", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("codesubcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["codesubcode"].Value = codesubcode;

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

        public void deleteBooking(string cioid)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("deleteBooking", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("cioid", MySqlDbType.VarChar);
                objSqlCommand.Parameters["cioid"].Value = cioid;


                // objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlCommand.ExecuteNonQuery();

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

        public void clsInsertintoTemp(string ciobookid, string compcode)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_InsertintoTemp", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("ciobookid", MySqlDbType.VarChar);
                objSqlCommand.Parameters["ciobookid"].Value = ciobookid;

                objSqlCommand.ExecuteNonQuery();

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

        public void clsdeletefromtemp(string ciobookid, string compcode)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_deletefromtemp", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("ciobookid", MySqlDbType.VarChar);
                objSqlCommand.Parameters["ciobookid"].Value = ciobookid;


                objSqlCommand.ExecuteNonQuery();

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

        public DataSet getTemplate(string category)
        {

            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getTemplateCategoryWise", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;



                objSqlCommand.Parameters.Add("adcat", MySqlDbType.VarChar);
                objSqlCommand.Parameters["adcat"].Value = category;

                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (MySqlException objException)
            {
                throw (objException);
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

        public DataSet getPkgEdition_P(string compcode, string combincode)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getPkgEdition_P", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("combincode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["combincode"].Value = combincode;


                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (MySqlException objException)
            {
                throw (objException);
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

        public DataSet getretainer(string compcode, string center, string centermain)
        {

            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("GETRETAINER", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("COMPCODE1", MySqlDbType.VarChar);
                objSqlCommand.Parameters["COMPCODE1"].Value = compcode;

                objSqlCommand.Parameters.Add("PUBCENTER", MySqlDbType.VarChar);
                objSqlCommand.Parameters["PUBCENTER"].Value = center;

                objSqlCommand.Parameters.Add("center", MySqlDbType.VarChar);
                objSqlCommand.Parameters["center"].Value = centermain;
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (MySqlException objException)
            {
                throw (objException);
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

        public DataSet getCurrdate()
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getCurrDate", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (MySqlException objException)
            {
                throw (objException);
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

        public DataSet clsBranchAlias(string compcode, string branchcode)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_BranchAlias_websp_BranchAlias_P", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("branchcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["branchcode"].Value = branchcode;


                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (MySqlException objException)
            {
                throw (objException);
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


        public DataSet clsMaxReceipt(string bookingid)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_MaxReceipt", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                //objSqlCommand.Parameters.Add("bookingid", MySqlDbType.VarChar);
                //objSqlCommand.Parameters["bookingid"].Value = bookingid;

                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (MySqlException objException)
            {
                throw (objException);
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

        public DataSet insertCashReceived(string ciobookid, string receiptno, string drpcashrecieved)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("insertintocashreceiveddetail", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("ciobookid", MySqlDbType.VarChar);
                objSqlCommand.Parameters["ciobookid"].Value = ciobookid;

                objSqlCommand.Parameters.Add("receiptno", MySqlDbType.VarChar);
                objSqlCommand.Parameters["receiptno"].Value = receiptno;

                objSqlCommand.Parameters.Add("drpcashrecieved", MySqlDbType.VarChar);
                if (drpcashrecieved == "" || drpcashrecieved == null)
                {
                    objSqlCommand.Parameters["drpcashrecieved"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["drpcashrecieved"].Value = Convert.ToDecimal(drpcashrecieved);

                }
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (MySqlException objException)
            {
                throw (objException);
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

        public DataSet getRepressentative(string compcode, string executive, string retainer)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getRepresenttaive", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("executive", MySqlDbType.VarChar);
                objSqlCommand.Parameters["executive"].Value = executive;


                objSqlCommand.Parameters.Add("retainer", MySqlDbType.VarChar);
                objSqlCommand.Parameters["retainer"].Value = retainer;


                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (MySqlException objException)
            {
                throw (objException);
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

        public DataSet getBAlias(string branch, string compcode)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getBAlias", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("branch", MySqlDbType.VarChar);
                if (branch == "")
                    objSqlCommand.Parameters["branch"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["branch"].Value = branch;


                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (MySqlException objException)
            {
                throw (objException);
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


        public DataSet getAmount(string cioid)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getCioAmount", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("cioid", MySqlDbType.VarChar);
                objSqlCommand.Parameters["cioid"].Value = cioid;

                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (MySqlException objException)
            {
                throw (objException);
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

        public void clsupdate_chqinfo(string compcode, string rcptno, string chqno, string chqdate, string chqamt, string bankname, string ag_codesubcode, string ag_code, string ag_subcode, string ppaymodres, string ptype, string rcptdate, string dateformat, string remarks, string ourbank, string repcode, string unit, string userid, string cioid)
        {

            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            //   MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            // DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Websp_Update_Chqinfo", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("pcompcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["pcompcode"].Value = compcode;

                objSqlCommand.Parameters.Add("precpt", MySqlDbType.VarChar);
                objSqlCommand.Parameters["precpt"].Value = rcptno;

                objSqlCommand.Parameters.Add("pchno", MySqlDbType.VarChar);
                objSqlCommand.Parameters["pchno"].Value = chqno;

                objSqlCommand.Parameters.Add("pchedate", MySqlDbType.VarChar);
                objSqlCommand.Parameters["pchedate"].Value = chqdate;

                objSqlCommand.Parameters.Add("pamount", MySqlDbType.VarChar);
                if (chqamt == "" || chqamt == null)
                {
                    objSqlCommand.Parameters["pamount"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["pamount"].Value = chqamt;
                }


                objSqlCommand.Parameters.Add("pbank", MySqlDbType.VarChar);
                objSqlCommand.Parameters["pbank"].Value = bankname;

                objSqlCommand.Parameters.Add("pagency", MySqlDbType.VarChar);
                objSqlCommand.Parameters["pagency"].Value = ag_codesubcode;

                objSqlCommand.Parameters.Add("pag_main_code", MySqlDbType.VarChar);
                objSqlCommand.Parameters["pag_main_code"].Value = ag_code;

                objSqlCommand.Parameters.Add("pag_sub_code", MySqlDbType.VarChar);
                objSqlCommand.Parameters["pag_sub_code"].Value = ag_subcode;


                objSqlCommand.Parameters.Add("ppaymodres", MySqlDbType.VarChar);
                objSqlCommand.Parameters["ppaymodres"].Value = ppaymodres;

                objSqlCommand.Parameters.Add("ptype", MySqlDbType.VarChar);
                objSqlCommand.Parameters["ptype"].Value = ptype;

                objSqlCommand.Parameters.Add("prdate", MySqlDbType.VarChar);
                objSqlCommand.Parameters["prdate"].Value = ag_code;

                objSqlCommand.Parameters.Add("pag_sub_code", MySqlDbType.VarChar);
                objSqlCommand.Parameters["pag_sub_code"].Value = rcptdate;

                objSqlCommand.Parameters.Add("remarks", MySqlDbType.VarChar);
                objSqlCommand.Parameters["remarks"].Value = remarks;

                objSqlCommand.Parameters.Add("ourbank", MySqlDbType.VarChar);
                objSqlCommand.Parameters["ourbank"].Value = ourbank;

                objSqlCommand.Parameters.Add("rep_code", MySqlDbType.VarChar);
                if (repcode == "0")
                    objSqlCommand.Parameters["rep_code"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["rep_code"].Value = repcode;


                objSqlCommand.Parameters.Add("punit", MySqlDbType.VarChar);
                objSqlCommand.Parameters["punit"].Value = unit;

                objSqlCommand.Parameters.Add("puser", MySqlDbType.VarChar);
                objSqlCommand.Parameters["puser"].Value = userid;

                objSqlCommand.Parameters.Add("cioid", MySqlDbType.VarChar);
                objSqlCommand.Parameters["cioid"].Value = cioid;



                objSqlCommand.ExecuteNonQuery();

            }
            catch (MySqlException objException)
            {
                throw (objException);
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


        public DataSet getRetainerComm(string retainercode, string compcode)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("GETRETAINERCOMM", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("COMPCODE", MySqlDbType.VarChar);
                objSqlCommand.Parameters["COMPCODE"].Value = compcode;

                objSqlCommand.Parameters.Add("RETAINERCODE", MySqlDbType.VarChar);
                objSqlCommand.Parameters["RETAINERCODE"].Value = retainercode;

                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (MySqlException objException)
            {
                throw (objException);
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


        public DataSet clsClientInfo(string compcode, string clientname)
        {

            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_ClientInfo", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("clientname", MySqlDbType.VarChar);
                objSqlCommand.Parameters["clientname"].Value = clientname;

                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (MySqlException objException)
            {
                throw (objException);
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

        //for receipt matter
        public DataSet clsreceiptmatter(string booking_id)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_clsmatter", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("booking_id", MySqlDbType.VarChar);
                objSqlCommand.Parameters["booking_id"].Value = booking_id;


                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (MySqlException objException)
            {
                throw (objException);
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
        public DataSet bindagencyfromadd(string compcode, string userid, string agency, string agencyaddress)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_clsmatter", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objSqlCommand.Parameters["userid"].Value = userid;

                objSqlCommand.Parameters.Add("agency", MySqlDbType.VarChar);
                objSqlCommand.Parameters["agency"].Value = agency;

                objSqlCommand.Parameters.Add("agencyaddress", MySqlDbType.VarChar);
                objSqlCommand.Parameters["agencyaddress"].Value = agencyaddress;




                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (MySqlException objException)
            {
                throw (objException);
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


        /* public DataSet getOurBank(string compcode)
         {
             MySqlConnection objSqlConnection;
             MySqlCommand objSqlCommand;
             objSqlConnection = GetConnection();
             MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
             DataSet objDataSet = new DataSet();
             try
             {
                 objSqlConnection.Open();
                 objSqlCommand = GetCommand("getOurBank", ref objSqlConnection);
                 objSqlCommand.CommandType = CommandType.StoredProcedure;

                 objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                 objSqlCommand.Parameters["compcode"].Value = compcode;

                 objSqlDataAdapter.SelectCommand = objSqlCommand;
                 objSqlDataAdapter.Fill(objDataSet);
                 return objDataSet;


             }
             catch (MySqlException objException)
             {
                 throw (objException);
             }
             catch (Exception ex)
             {
                 throw (ex);
             }
             finally
             {
                 CloseConnection(ref objSqlConnection);
             }
         }*/
        public DataSet getExecbooking(string compcode, string execname, string value, string center, string adtype)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("WEBSP_GETEXECBOOKING_websp_getexecbooking_p", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("execname", MySqlDbType.VarChar);
                objSqlCommand.Parameters["execname"].Value = execname;

                objSqlCommand.Parameters.Add("VALUE", MySqlDbType.VarChar);
                objSqlCommand.Parameters["VALUE"].Value = value;

                objSqlCommand.Parameters.Add("center", MySqlDbType.VarChar);
                objSqlCommand.Parameters["center"].Value = center;


                objSqlCommand.Parameters.Add("padtype", MySqlDbType.VarChar);
                objSqlCommand.Parameters["padtype"].Value = adtype;

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


        // for checking date edition

        //        dateformat, book_date, pkgname, adcat, center, "CL0", pkgid, pkgalias

        public DataSet getvaliddate_qbc_New(string dateformat, string book_date, string pkgname, string adcat, string center, string adtype, string pkgid, string pkgalias)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();

            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("get_validdate_qbc_get_validdate_qbc_P", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("pkgname", MySqlDbType.VarChar);
                objSqlCommand.Parameters["pkgname"].Value = pkgname;

                objSqlCommand.Parameters.Add("adcat1", MySqlDbType.VarChar);
                objSqlCommand.Parameters["adcat1"].Value = adcat;

                objSqlCommand.Parameters.Add("datetoadd", MySqlDbType.VarChar);
                objSqlCommand.Parameters["datetoadd"].Value = book_date;

                objSqlCommand.Parameters.Add("center", MySqlDbType.VarChar);
                objSqlCommand.Parameters["center"].Value = center;

                objSqlCommand.Parameters.Add("DATEFORMAT", MySqlDbType.VarChar);
                objSqlCommand.Parameters["DATEFORMAT"].Value = dateformat;

                objSqlCommand.Parameters.Add("adtype1", MySqlDbType.VarChar);
                objSqlCommand.Parameters["adtype1"].Value = adtype;

                objSqlCommand.Parameters.Add("pkgid", MySqlDbType.VarChar);
                objSqlCommand.Parameters["pkgid"].Value = pkgid;

                objSqlCommand.Parameters.Add("pkgalias", MySqlDbType.VarChar);
                objSqlCommand.Parameters["pkgalias"].Value = pkgalias;

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

        public DataSet getbranchname(string compcode, string revenuecenter)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("AD_GET_BRANCH_NAME", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("pcompcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["pcompcode"].Value = compcode;

                objSqlCommand.Parameters.Add("pbranch_code", MySqlDbType.VarChar);
                objSqlCommand.Parameters["pbranch_code"].Value = revenuecenter;

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

        public DataSet chkdiscountpremedit_per(string compcode, string userid)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("chkdiscountpremedit_per", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("userid1", MySqlDbType.VarChar);
                objSqlCommand.Parameters["userid1"].Value = userid;

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

        public DataSet getQBC_n(string center, string compcode)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_QBC_n", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("pubcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["pubcode"].Value = center;

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

        public DataSet packagebindbooking(string compcode, string userid, string center, string adtype)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("bindpackageActive_bindpackageActive_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("pcenter", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pcenter"].Value = center;

                objmysqlcommand.Parameters.Add("padtype", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["padtype"].Value = adtype;

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

        public DataSet mailpritingcenter(string compcode, string userid, string center, string adtype)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("bind_pubcentname_new", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("p_comp_code", MySqlDbType.VarChar);
                objSqlCommand.Parameters["p_comp_code"].Value = compcode;

                objSqlCommand.Parameters.Add("p_userid", MySqlDbType.VarChar);
                objSqlCommand.Parameters["p_userid"].Value = userid;

                objSqlCommand.Parameters.Add("p_extra1", MySqlDbType.VarChar);
                objSqlCommand.Parameters["p_extra1"].Value = center;

                objSqlCommand.Parameters.Add("p_extra2", MySqlDbType.VarChar);
                objSqlCommand.Parameters["p_extra2"].Value = adtype;

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

        public DataSet maildetailsbind(string compcode, string cioid, string extra1, string extra2, string extra3, string extra4, string extra5)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("SEND_SMS_ad_booking", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("p_comp_cd", MySqlDbType.VarChar);
                objSqlCommand.Parameters["p_comp_cd"].Value = compcode;

                objSqlCommand.Parameters.Add("p_booing_id", MySqlDbType.VarChar);
                objSqlCommand.Parameters["p_booing_id"].Value = cioid;

                objSqlCommand.Parameters.Add("p_pextra1", MySqlDbType.VarChar);
                objSqlCommand.Parameters["p_pextra1"].Value = extra1;

                objSqlCommand.Parameters.Add("p_pextra2", MySqlDbType.VarChar);
                objSqlCommand.Parameters["p_pextra2"].Value = extra2;

                objSqlCommand.Parameters.Add("p_pextra3", MySqlDbType.VarChar);
                objSqlCommand.Parameters["p_pextra3"].Value = extra3;

                objSqlCommand.Parameters.Add("p_pextra4", MySqlDbType.VarChar);
                objSqlCommand.Parameters["p_pextra4"].Value = extra4;

                objSqlCommand.Parameters.Add("p_pextra5", MySqlDbType.VarChar);
                objSqlCommand.Parameters["p_pextra5"].Value = extra5;

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

       
        public DataSet clsSpaceAvailability(string compcode, string pdate, string ppub, string pbkfor, string pedition, string psecpub, string dateformat)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_spaceAvailability_websp_spaceAvailability_p", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("pubdate", MySqlDbType.VarChar);
                objSqlCommand.Parameters["pubdate"].Value = pdate;

                objSqlCommand.Parameters.Add("pubcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["pubcode"].Value = ppub;

                objSqlCommand.Parameters.Add("centercode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["centercode"].Value = pbkfor;

                objSqlCommand.Parameters.Add("editioncode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["editioncode"].Value = pedition;

                objSqlCommand.Parameters.Add("suppcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["suppcode"].Value = psecpub;

                //objSqlCommand.Parameters.Add("p_pextra5", MySqlDbType.VarChar);
                //objSqlCommand.Parameters["p_pextra5"].Value = psecpub;

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

        public DataSet clsPagesBookedVol(string compcode, string pdate, string ppub, string pbkfor, string pedition, string psecpub, string pgno)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_getPagesBookedVol_websp_getPagesBookedVol_p", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("pubdate", MySqlDbType.VarChar);
                objSqlCommand.Parameters["pubdate"].Value = pdate;

                objSqlCommand.Parameters.Add("pubcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["pubcode"].Value = ppub;

                objSqlCommand.Parameters.Add("centercode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["centercode"].Value = pbkfor;

                objSqlCommand.Parameters.Add("editioncode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["editioncode"].Value = pedition;

                objSqlCommand.Parameters.Add("suppcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["suppcode"].Value = psecpub;

                objSqlCommand.Parameters.Add("pgno", MySqlDbType.VarChar);
                objSqlCommand.Parameters["pgno"].Value = pgno;

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

        public DataSet clspageHeading(string pubdate, string pubcode, string centercode, string editioncode, string suppcode, string dateformat)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Websp_Pageheading_P_Websp_Pageheading", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                //objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                //objSqlCommand.Parameters["compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("pubdate", MySqlDbType.VarChar);
                objSqlCommand.Parameters["pubdate"].Value = pubdate;

                objSqlCommand.Parameters.Add("pubcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["pubcode"].Value = pubcode;

                objSqlCommand.Parameters.Add("centercode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["centercode"].Value = centercode;

                objSqlCommand.Parameters.Add("editioncode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["editioncode"].Value = editioncode;

                objSqlCommand.Parameters.Add("suppcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["suppcode"].Value = suppcode;

                //objSqlCommand.Parameters.Add("pgno", MySqlDbType.VarChar);
                //objSqlCommand.Parameters["pgno"].Value = pgno;

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

        //pdate, ppub, pbkfor, pedition, psecpub, pageno, dateformat
        public DataSet clsShowAd(string pdate, string ppub, string pbkfor, string pedition, string psecpub,string pageno, string dateformat)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Websp_Adonpage_P_Websp_Adonpage", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                //objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                //objSqlCommand.Parameters["compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("pubdate", MySqlDbType.VarChar);
                objSqlCommand.Parameters["pubdate"].Value = pdate;

                objSqlCommand.Parameters.Add("pubcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["pubcode"].Value = ppub;

                objSqlCommand.Parameters.Add("centercode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["centercode"].Value = pbkfor;

                objSqlCommand.Parameters.Add("editioncode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["editioncode"].Value = pedition;

                objSqlCommand.Parameters.Add("suppcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["suppcode"].Value = psecpub;

                objSqlCommand.Parameters.Add("pageno", MySqlDbType.VarChar);
                objSqlCommand.Parameters["pageno"].Value = pageno;

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
	public DataSet book_chkpublishday_n(string compcode, string pkgname, string dateday, string dateformat)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getperiodDate_Edition", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["compcode"].Value = compcode;
                objSqlCommand.Parameters.Add("pkgname", MySqlDbType.VarChar);
                objSqlCommand.Parameters["pkgname"].Value = pkgname;

                objSqlCommand.Parameters.Add("dateday", MySqlDbType.VarChar);
                objSqlCommand.Parameters["dateday"].Value = dateday;


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

    public DataSet mailsave(string cioid, string compcode, string mailcenter, string mailbranch, string mailid, string userid, string extra1, string extra2, string extra3, string extra4, string extra5)
    {
        MySqlConnection objSqlConnection;
        MySqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("savebookingmaildetails", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            objSqlCommand.Parameters.Add("pcioid", MySqlDbType.VarChar);
            objSqlCommand.Parameters["pcioid"].Value = cioid;

            objSqlCommand.Parameters.Add("pcompcode", MySqlDbType.VarChar);
            objSqlCommand.Parameters["pcompcode"].Value = compcode;

            objSqlCommand.Parameters.Add("pmailcenter", MySqlDbType.VarChar);
            objSqlCommand.Parameters["pmailcenter"].Value = mailcenter;

            objSqlCommand.Parameters.Add("pmailbranch", MySqlDbType.VarChar);
            objSqlCommand.Parameters["pmailbranch"].Value = mailbranch;

            objSqlCommand.Parameters.Add("pmailid", MySqlDbType.VarChar);
            objSqlCommand.Parameters["pmailid"].Value = mailid;

            objSqlCommand.Parameters.Add("puserid", MySqlDbType.VarChar);
            objSqlCommand.Parameters["puserid"].Value = userid;

            objSqlCommand.Parameters.Add("pextra1", MySqlDbType.VarChar);
            objSqlCommand.Parameters["pextra1"].Value = extra1;

            objSqlCommand.Parameters.Add("pextra2", MySqlDbType.VarChar);
            objSqlCommand.Parameters["pextra2"].Value = extra2;

            objSqlCommand.Parameters.Add("pextra3", MySqlDbType.VarChar);
            objSqlCommand.Parameters["pextra3"].Value = extra3;

            objSqlCommand.Parameters.Add("pextra4", MySqlDbType.VarChar);
            objSqlCommand.Parameters["pextra4"].Value = extra4;

            objSqlCommand.Parameters.Add("pextra5", MySqlDbType.VarChar);
            objSqlCommand.Parameters["pextra5"].Value = extra5;

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

        // ad cat data 10022018
    public DataSet advdatacategoryp(string compcode, string booking,string extra1)
    {
        MySqlConnection objSqlConnection;
        MySqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {

            objSqlConnection.Open();
            objSqlCommand = GetCommand("book_advcategory_book_advcategory_p", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
            objSqlCommand.Parameters["compcode"].Value = compcode;

            objSqlCommand.Parameters.Add("booking", MySqlDbType.VarChar);
            objSqlCommand.Parameters["booking"].Value = booking;

            objSqlCommand.Parameters.Add("center", MySqlDbType.VarChar);
            objSqlCommand.Parameters["center"].Value = extra1;


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

      // uom for booking
    public DataSet uombindp(string compcode, string userid, string value)
    {
        MySqlConnection objmysqlconnection;
        MySqlCommand objmysqlcommand;
        objmysqlconnection = GetConnection();
        MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objmysqlconnection.Open();
            objmysqlcommand = GetCommand("binduomforrate_binduomforrate_p", ref objmysqlconnection);
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

    // client for booking
    public DataSet get10ClientName_n(string compcode, string client, string revcenter, string userid)
    {
        MySqlConnection objmysqlconnection;
        MySqlCommand objmysqlcommand;
        objmysqlconnection = GetConnection();
        MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objmysqlconnection.Open();
            objmysqlcommand = GetCommand("websp_get10clientName1", ref objmysqlconnection);
            objmysqlcommand.CommandType = CommandType.StoredProcedure;

            objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["compcode"].Value = compcode;

            objmysqlcommand.Parameters.Add("pclient", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["pclient"].Value = client;

            objmysqlcommand.Parameters.Add("center", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["center"].Value = revcenter;

            objmysqlcommand.Parameters.Add("puserid", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["puserid"].Value = userid;


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

    public DataSet getClientName_n(string compcode, string client, string revcenter, string userid)
    {
        MySqlConnection objmysqlconnection;
        MySqlCommand objmysqlcommand;
        objmysqlconnection = GetConnection();
        MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objmysqlconnection.Open();
            objmysqlcommand = GetCommand("websp_getclientName_websp_getclientName_p", ref objmysqlconnection);
            objmysqlcommand.CommandType = CommandType.StoredProcedure;

            objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["compcode"].Value = compcode;

            objmysqlcommand.Parameters.Add("CLIENT", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["CLIENT"].Value = client;

            objmysqlcommand.Parameters.Add("center", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["center"].Value = revcenter;

            objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["userid"].Value = userid;


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

    // agnecy  for booking
    public DataSet bind10agency_n(string compcode, string userid, string agency, string center)
    {
        MySqlConnection objmysqlconnection;
        MySqlCommand objmysqlcommand;
        objmysqlconnection = GetConnection();
        MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objmysqlconnection.Open();
            objmysqlcommand = GetCommand("bind10agencyforbooking_N", ref objmysqlconnection);
            objmysqlcommand.CommandType = CommandType.StoredProcedure;

            objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["compcode"].Value = compcode;

            objmysqlcommand.Parameters.Add("puserid", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["puserid"].Value = userid;

            objmysqlcommand.Parameters.Add("agency", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["agency"].Value = agency;

            objmysqlcommand.Parameters.Add("pubcenter", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["pubcenter"].Value = center;


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

    public DataSet bindagency_n(string compcode, string userid, string agency, string center)
    {
        MySqlConnection objmysqlconnection;
        MySqlCommand objmysqlcommand;
        objmysqlconnection = GetConnection();
        MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objmysqlconnection.Open();
            objmysqlcommand = GetCommand("bindagencyforbooking_N", ref objmysqlconnection);
            objmysqlcommand.CommandType = CommandType.StoredProcedure;

            objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["compcode"].Value = compcode;

            objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["userid"].Value = userid;

            objmysqlcommand.Parameters.Add("agency", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["agency"].Value = agency;

            objmysqlcommand.Parameters.Add("pubcenter", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["pubcenter"].Value = center;


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

        // package details

    public DataSet getCombinDesc(string strid)
    {
        MySqlConnection objmysqlconnection;
        MySqlCommand objmysqlcommand;
        objmysqlconnection = GetConnection();
        MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objmysqlconnection.Open();
            objmysqlcommand = GetCommand("GETCOMBINDESC", ref objmysqlconnection);
            objmysqlcommand.CommandType = CommandType.StoredProcedure;

            objmysqlcommand.Parameters.Add("pkgcode", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["pkgcode"].Value = strid;

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

        // current time

    public DataSet getCurTime(string compcode)
    {
        MySqlConnection objmysqlconnection;
        MySqlCommand objmysqlcommand;
        objmysqlconnection = GetConnection();
        MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objmysqlconnection.Open();
            objmysqlcommand = GetCommand("GETCURTIME", ref objmysqlconnection);
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

    // gettempBookingIdNo
    public DataSet autogenratedtempid(string compcode, string extra1,string extra2)
    {
        MySqlConnection objmysqlconnection;
        MySqlCommand objmysqlcommand;
        objmysqlconnection = GetConnection();
        MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objmysqlconnection.Open();
            objmysqlcommand = GetCommand("GETAUTOCODEBOOKING_PRE_SAVE_GETAUTOCODEBOOKING_PRE_SAVE_P", ref objmysqlconnection);
            objmysqlcommand.CommandType = CommandType.StoredProcedure;

            objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["compcode"].Value = compcode;

            objmysqlcommand.Parameters.Add("auto1", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["auto1"].Value = extra1;

            objmysqlcommand.Parameters.Add("no1", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["no1"].Value = extra2;

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


    // chk booking bookidchk

    public DataSet bookidchkp(string compcode, string ciobookid, string agency, string agencycode, string rono, string saveormod, string keyno)
    {
        MySqlConnection objSqlConnection;
        MySqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("chkciobookid_chkciobookid_p", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
            objSqlCommand.Parameters["compcode"].Value = compcode;

            objSqlCommand.Parameters.Add("ciobookid", MySqlDbType.VarChar);
            objSqlCommand.Parameters["ciobookid"].Value = ciobookid;

            objSqlCommand.Parameters.Add("agency", MySqlDbType.VarChar);
            objSqlCommand.Parameters["agency"].Value = agency;

            objSqlCommand.Parameters.Add("agencycode", MySqlDbType.VarChar);
            objSqlCommand.Parameters["agencycode"].Value = agencycode;

            objSqlCommand.Parameters.Add("rono", MySqlDbType.VarChar);
            objSqlCommand.Parameters["rono"].Value = rono;

            objSqlCommand.Parameters.Add("saveormod", MySqlDbType.VarChar);
            objSqlCommand.Parameters["saveormod"].Value = saveormod;

            objSqlCommand.Parameters.Add("keyno", MySqlDbType.VarChar);
            objSqlCommand.Parameters["keyno"].Value = keyno;

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

        // GET RATE  
       
    public DataSet get_rate_qbc1(string noofinsertion,string dateformat,string compcode,string uom,string adtype,string currency,string ratecode,string clientcode,string uomdesc,string openreferExtra,string agencycode,string newcode,string center,string ratepremtype,string premium,string schemetype,string fdate,string ldate,string currentcounter,string FETCHMINSIZEPACKAGERATE,string chkadon_var,string discprem,string spediscper,string pospremdisc,string designbox,string logoprem,string style_p)
    {
        MySqlConnection objSqlConnection;
        MySqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("rate_qbc_rate_qbc_p", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            //string openreferExtra = ConfigurationSettings.AppSettings["openreferExtra"];

            objSqlCommand.Parameters.Add("noofinsertion", MySqlDbType.VarChar);
            objSqlCommand.Parameters["noofinsertion"].Value = noofinsertion;

            objSqlCommand.Parameters.Add("dateformat", MySqlDbType.VarChar);
            objSqlCommand.Parameters["dateformat"].Value = dateformat;

            objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
            objSqlCommand.Parameters["compcode"].Value = compcode;

            objSqlCommand.Parameters.Add("uom", MySqlDbType.VarChar);
            objSqlCommand.Parameters["uom"].Value = uom;

            objSqlCommand.Parameters.Add("Adtype", MySqlDbType.VarChar);
            objSqlCommand.Parameters["Adtype"].Value = adtype;

            objSqlCommand.Parameters.Add("currency", MySqlDbType.VarChar);
            objSqlCommand.Parameters["currency"].Value = currency;

            objSqlCommand.Parameters.Add("RATECODE", MySqlDbType.VarChar);
            objSqlCommand.Parameters["RATECODE"].Value = ratecode;

            objSqlCommand.Parameters.Add("clientcode", MySqlDbType.VarChar);
            objSqlCommand.Parameters["clientcode"].Value = clientcode;

            objSqlCommand.Parameters.Add("uomdesc", MySqlDbType.VarChar);
            objSqlCommand.Parameters["uomdesc"].Value = uomdesc;

            objSqlCommand.Parameters.Add("openreferExtra", MySqlDbType.VarChar);
            objSqlCommand.Parameters["openreferExtra"].Value = openreferExtra;

            objSqlCommand.Parameters.Add("agencycode", MySqlDbType.VarChar);
            objSqlCommand.Parameters["agencycode"].Value = agencycode;

            objSqlCommand.Parameters.Add("newcode", MySqlDbType.VarChar);
            objSqlCommand.Parameters["newcode"].Value = newcode;

            objSqlCommand.Parameters.Add("center", MySqlDbType.VarChar);
            objSqlCommand.Parameters["center"].Value = center;

            objSqlCommand.Parameters.Add("ratepremtype", MySqlDbType.VarChar);
            objSqlCommand.Parameters["ratepremtype"].Value = ratepremtype;

            objSqlCommand.Parameters.Add("premiumval", MySqlDbType.VarChar);
            objSqlCommand.Parameters["premiumval"].Value = premium;

            objSqlCommand.Parameters.Add("schemetype", MySqlDbType.VarChar);
            objSqlCommand.Parameters["schemetype"].Value = schemetype;

            objSqlCommand.Parameters.Add("fdate", MySqlDbType.DateTime);
            objSqlCommand.Parameters["fdate"].Value = fdate;

            objSqlCommand.Parameters.Add("ldate", MySqlDbType.DateTime);
            objSqlCommand.Parameters["ldate"].Value = ldate;

            objSqlCommand.Parameters.Add("counter", MySqlDbType.Int64);
            if (currentcounter == "" || currentcounter == null)
            {
                objSqlCommand.Parameters["counter"].Value = Convert.ToInt64("0");
            }
            else
            {
                objSqlCommand.Parameters["counter"].Value = Convert.ToInt32(currentcounter);
            }

            objSqlCommand.Parameters.Add("rateflag", MySqlDbType.VarChar);
            objSqlCommand.Parameters["rateflag"].Value = FETCHMINSIZEPACKAGERATE;

            objSqlCommand.Parameters.Add("chkadon_p", MySqlDbType.VarChar);
            objSqlCommand.Parameters["chkadon_p"].Value = chkadon_var;

            objSqlCommand.Parameters.Add("discprem_p", MySqlDbType.VarChar);
            objSqlCommand.Parameters["discprem_p"].Value = discprem;

            objSqlCommand.Parameters.Add("spediscper_p", MySqlDbType.VarChar);
            objSqlCommand.Parameters["spediscper_p"].Value = spediscper;

            objSqlCommand.Parameters.Add("pospremdisc_p", MySqlDbType.VarChar);
            objSqlCommand.Parameters["pospremdisc_p"].Value = pospremdisc;

            objSqlCommand.Parameters.Add("designbox", MySqlDbType.VarChar);
            objSqlCommand.Parameters["designbox"].Value = designbox;

            objSqlCommand.Parameters.Add("logoprem", MySqlDbType.VarChar);
            objSqlCommand.Parameters["logoprem"].Value = logoprem;

            objSqlCommand.Parameters.Add("style_p", MySqlDbType.VarChar);
            objSqlCommand.Parameters["style_p"].Value = style_p;

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

        // FOR WALIKNG CLIENT CHECK
    public DataSet forwalkclientN(string client, string compcode)
    {
        MySqlConnection objSqlConnection;
        MySqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("chkforwalkinnclient_chkforwalkinnclient_p", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;
            objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
            objSqlCommand.Parameters["compcode"].Value = compcode;

            objSqlCommand.Parameters.Add("pclient", MySqlDbType.VarChar);
            objSqlCommand.Parameters["pclient"].Value = client;

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

        // FOR MULTIBILLING

    public DataSet multi_billing(string compcode, string client_code, string client_name, string client_address, string width, string height, string gross_amt, string comm, string bill_amt, string bill_no, string bill_dt, string userid, string flag, string extra1, string extra2, string extra3, string extra4, string extra5)
    {
        MySqlConnection objSqlConnection;
        MySqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("MULTIBILLING_RO", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            objSqlCommand.Parameters.Add("pcomp_code", MySqlDbType.VarChar);
            objSqlCommand.Parameters["pcomp_code"].Value = compcode;

            objSqlCommand.Parameters.Add("pclient_name", MySqlDbType.VarChar);
            objSqlCommand.Parameters["pclient_name"].Value = client_code;

            objSqlCommand.Parameters.Add("pclient_code", MySqlDbType.VarChar);
            objSqlCommand.Parameters["pclient_code"].Value = client_name;

            objSqlCommand.Parameters.Add("pcleint_address", MySqlDbType.VarChar);
            objSqlCommand.Parameters["pcleint_address"].Value = client_address;

            objSqlCommand.Parameters.Add("pwidth", MySqlDbType.VarChar);
            objSqlCommand.Parameters["pwidth"].Value = width;

            objSqlCommand.Parameters.Add("pheight", MySqlDbType.VarChar);
            objSqlCommand.Parameters["pheight"].Value = height;

            objSqlCommand.Parameters.Add("pgross_amt", MySqlDbType.VarChar);
            objSqlCommand.Parameters["pgross_amt"].Value = gross_amt;

            objSqlCommand.Parameters.Add("pcomm", MySqlDbType.VarChar);
            objSqlCommand.Parameters["pcomm"].Value = comm;

            objSqlCommand.Parameters.Add("pbill_amt", MySqlDbType.VarChar);
            objSqlCommand.Parameters["pbill_amt"].Value = bill_amt;

            objSqlCommand.Parameters.Add("pbill_no", MySqlDbType.VarChar);
            objSqlCommand.Parameters["pbill_no"].Value = bill_no;

            objSqlCommand.Parameters.Add("pbill_date", MySqlDbType.VarChar);
            objSqlCommand.Parameters["pbill_date"].Value = bill_dt;

            objSqlCommand.Parameters.Add("puser_id", MySqlDbType.VarChar);
            objSqlCommand.Parameters["puser_id"].Value = userid;

            objSqlCommand.Parameters.Add("pflag", MySqlDbType.VarChar);
            objSqlCommand.Parameters["pflag"].Value = flag;

            objSqlCommand.Parameters.Add("pextra1", MySqlDbType.VarChar);
            objSqlCommand.Parameters["pextra1"].Value = extra1;

            objSqlCommand.Parameters.Add("pextra2", MySqlDbType.VarChar);
            objSqlCommand.Parameters["pextra2"].Value = extra2;

            objSqlCommand.Parameters.Add("pextra3", MySqlDbType.VarChar);
            objSqlCommand.Parameters["pextra3"].Value = extra3;

            objSqlCommand.Parameters.Add("pextra4", MySqlDbType.VarChar);
            objSqlCommand.Parameters["pextra4"].Value = extra4;

            objSqlCommand.Parameters.Add("pextra5", MySqlDbType.VarChar);
            objSqlCommand.Parameters["pextra5"].Value = extra5;
                        
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


    //------- for display booking -----------------//

    public DataSet executebookingdisp1(string compcode, string ciobookid, string docno, string keyno, string rono, string agencycode, string client, string adtype, string dateformat, string branch)
    {
        MySqlConnection objSqlConnection;
        MySqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("executebookingdisp_executebookingdisp_p", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
            objSqlCommand.Parameters["compcode"].Value = compcode;

            objSqlCommand.Parameters.Add("ciobookid", MySqlDbType.VarChar);
            objSqlCommand.Parameters["ciobookid"].Value = ciobookid;

            objSqlCommand.Parameters.Add("docno", MySqlDbType.VarChar);
            objSqlCommand.Parameters["docno"].Value = docno;

            objSqlCommand.Parameters.Add("keyno", MySqlDbType.VarChar);
            objSqlCommand.Parameters["keyno"].Value = keyno;

            objSqlCommand.Parameters.Add("rono", MySqlDbType.VarChar);
            objSqlCommand.Parameters["rono"].Value = rono;

            objSqlCommand.Parameters.Add("agencycode", MySqlDbType.VarChar);
            objSqlCommand.Parameters["agencycode"].Value = agencycode;

            objSqlCommand.Parameters.Add("CLIENT", MySqlDbType.VarChar);
            objSqlCommand.Parameters["CLIENT"].Value = client;

            objSqlCommand.Parameters.Add("booking", MySqlDbType.VarChar);
            objSqlCommand.Parameters["booking"].Value = adtype;

            objSqlCommand.Parameters.Add("DATEFORMAT", MySqlDbType.VarChar);
            objSqlCommand.Parameters["DATEFORMAT"].Value = dateformat;

            objSqlCommand.Parameters.Add("revenue", MySqlDbType.VarChar);
            objSqlCommand.Parameters["revenue"].Value = branch;

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

    //------- for EXECUTE GRID display booking -----------------//

    public DataSet fetchdataforexenew(string ciobid, string compcode)
    {
        MySqlConnection objSqlConnection;
        MySqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("getdataforexecute_getdataforexecute_p", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            objSqlCommand.Parameters.Add("ciobid", MySqlDbType.VarChar);
            objSqlCommand.Parameters["ciobid"].Value = ciobid;

            objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
            objSqlCommand.Parameters["compcode"].Value = compcode;

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


        // for product bind

    public DataSet bindprodyc(string brand,string compcode )
    {
        MySqlConnection objSqlConnection;
        MySqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("AN_PRODUCT_AN_bindproductcat_p", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
            objSqlCommand.Parameters["compcode"].Value = compcode;

            objSqlCommand.Parameters.Add("indus", MySqlDbType.VarChar);
            objSqlCommand.Parameters["indus"].Value = brand;

            objSqlDataAdapter.SelectCommand = objSqlCommand;
            objSqlDataAdapter.Fill(objDataSet);
            return objDataSet;
        }
        catch (MySqlException objException)
        {
            throw (objException);
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

    // for circulation agency

    public DataSet getciragency(string compcode, string branch, string ciragency, string ciragencysubcode)
    {
        MySqlConnection objSqlConnection;
        MySqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("cir_get_name_cir_agname_branch", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
            objSqlCommand.Parameters["compcode"].Value = compcode;

            objSqlCommand.Parameters.Add("indus", MySqlDbType.VarChar);
            objSqlCommand.Parameters["indus"].Value = branch;

            objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
            objSqlCommand.Parameters["compcode"].Value = ciragency;

            objSqlCommand.Parameters.Add("indus", MySqlDbType.VarChar);
            objSqlCommand.Parameters["indus"].Value = ciragencysubcode;

            objSqlDataAdapter.SelectCommand = objSqlCommand;
            objSqlDataAdapter.Fill(objDataSet);
            return objDataSet;
        }
        catch (MySqlException objException)
        {
            throw (objException);
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


    // for main group for package
    public DataSet bindpackagemaingrp(string compcode, string maingrpcode, string maingrpname, string extra1, string extra2)
    {
        MySqlConnection objSqlConnection;
        MySqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("adv_combin_main_group_bind", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            objSqlCommand.Parameters.Add("pcomp_code", MySqlDbType.VarChar);
            objSqlCommand.Parameters["pcomp_code"].Value = compcode;

            objSqlCommand.Parameters.Add("pmain_group_code", MySqlDbType.VarChar);
            objSqlCommand.Parameters["pmain_group_code"].Value = maingrpcode;

            objSqlCommand.Parameters.Add("pmain_group_name", MySqlDbType.VarChar);
            objSqlCommand.Parameters["pmain_group_name"].Value = maingrpname;

            objSqlCommand.Parameters.Add("pextra1", MySqlDbType.VarChar);
            objSqlCommand.Parameters["pextra1"].Value = extra1;

            objSqlCommand.Parameters.Add("pextra2", MySqlDbType.VarChar);
            objSqlCommand.Parameters["pextra2"].Value = extra2;

            objSqlDataAdapter.SelectCommand = objSqlCommand;
            objSqlDataAdapter.Fill(objDataSet);
            return objDataSet;
        }
        catch (MySqlException objException)
        {
            throw (objException);
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


    // for sub group for package   compcode, maingrpcode, varpacksubgrpc, subgrpname, extra1, extra2
    public DataSet bindpackagesubgrp(string compcode, string maingrpcode, string varpacksubgrpc,string subgrpname, string extra1, string extra2)
    {
        MySqlConnection objSqlConnection;
        MySqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("adv_combin_sub_group_bind", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            objSqlCommand.Parameters.Add("pcomp_code", MySqlDbType.VarChar);
            objSqlCommand.Parameters["pcomp_code"].Value = compcode;

            objSqlCommand.Parameters.Add("pmain_group_code", MySqlDbType.VarChar);
            objSqlCommand.Parameters["pmain_group_code"].Value = maingrpcode;

            objSqlCommand.Parameters.Add("psub_group_code", MySqlDbType.VarChar);
            objSqlCommand.Parameters["psub_group_code"].Value = varpacksubgrpc;

            objSqlCommand.Parameters.Add("psub_group_name", MySqlDbType.VarChar);
            objSqlCommand.Parameters["psub_group_name"].Value = subgrpname;

            objSqlCommand.Parameters.Add("pextra1", MySqlDbType.VarChar);
            objSqlCommand.Parameters["pextra1"].Value = extra1;

            objSqlCommand.Parameters.Add("pextra2", MySqlDbType.VarChar);
            objSqlCommand.Parameters["pextra2"].Value = extra2;

            objSqlDataAdapter.SelectCommand = objSqlCommand;
            objSqlDataAdapter.Fill(objDataSet);
            return objDataSet;
        }
        catch (MySqlException objException)
        {
            throw (objException);
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


        // for after 
    public DataSet packagebindbookinggroup(string compcode, string userid, string center, string adtype , string maingrp, string subgroup)
    {
        MySqlConnection objmysqlconnection;
        MySqlCommand objmysqlcommand;
        objmysqlconnection = GetConnection();
        MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objmysqlconnection.Open();
            objmysqlcommand = GetCommand("bindpackageActive_with_group", ref objmysqlconnection);
            objmysqlcommand.CommandType = CommandType.StoredProcedure;

            objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["compcode"].Value = compcode;

            objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["userid"].Value = userid;

            objmysqlcommand.Parameters.Add("pcenter", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["pcenter"].Value = center;

            objmysqlcommand.Parameters.Add("padtype", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["padtype"].Value = adtype;

            objmysqlcommand.Parameters.Add("pmain_group_code", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["pmain_group_code"].Value = maingrp;

            objmysqlcommand.Parameters.Add("psub_group_code", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["psub_group_code"].Value = subgroup;
            

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

    public DataSet remove_dulicate_in_str(string mailid)
    {
        MySqlConnection objSqlConnection;
        MySqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("remove_dulicate_in_str", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            objSqlCommand.Parameters.Add("p_str", MySqlDbType.VarChar);
            objSqlCommand.Parameters["p_str"].Value = mailid;

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

        // for modify data date check
    public DataSet book_chkpublishday_modify(string value, string compcode, string pkgname, string dateday, string dateformat, string adcat, string adtype, string center, string pkgid, string pkgalias, string chkbtnstatusdate)
    {
        MySqlConnection objSqlConnection;
        MySqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("book_chkpublishday_alw_for_next_days", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
            objSqlCommand.Parameters["compcode"].Value = compcode;

            objSqlCommand.Parameters.Add("value1", MySqlDbType.VarChar);
            objSqlCommand.Parameters["value1"].Value = value;

            objSqlCommand.Parameters.Add("pkgname", MySqlDbType.VarChar);
            objSqlCommand.Parameters["pkgname"].Value = pkgname;

            objSqlCommand.Parameters.Add("dateday", MySqlDbType.Datetime);
            if (dateformat == "mm/dd/yyyy" && dateday != "")
            {
                string[] arr = null;
                arr = dateday.Split("/".ToCharArray());
                dateday = arr[2] + "-" + arr[0] + "-" + arr[1];

            }
            if (dateformat == "dd/mm/yyyy" && dateday != "")
            {
                string[] arr = null;
                arr = dateday.Split("/".ToCharArray());
                dateday = arr[2] + "-" + arr[1] + "-" + arr[0];

            }
            if (dateformat == "yyyy/mm/dd" && dateday != "")
            {
                string[] arr = null;
                arr = dateday.Split("/".ToCharArray());
                dateday = arr[0] + "-" + arr[1] + "-" + arr[2];

            }
            if (dateday != "")
            {
                objSqlCommand.Parameters["dateday"].Value = Convert.ToDateTime(dateday).ToString("yyyy-MM-dd");
            }
            else
            {
                objSqlCommand.Parameters["dateday"].Value = System.DBNull.Value;
            }
            // adcat,string adtype,string center,string pkgid,string pkgalias
            objSqlCommand.Parameters.Add("adcat", MySqlDbType.VarChar);
            objSqlCommand.Parameters["adcat"].Value = adcat;

            objSqlCommand.Parameters.Add("adtype1", MySqlDbType.VarChar);
            objSqlCommand.Parameters["adtype1"].Value = adtype;

            objSqlCommand.Parameters.Add("center", MySqlDbType.VarChar);
            objSqlCommand.Parameters["center"].Value = center;

            objSqlCommand.Parameters.Add("pkgid", MySqlDbType.VarChar);
            objSqlCommand.Parameters["pkgid"].Value = pkgid;

            objSqlCommand.Parameters.Add("pkgalias", MySqlDbType.VarChar);
            objSqlCommand.Parameters["pkgalias"].Value = pkgalias;

            objSqlCommand.Parameters.Add("pflag", MySqlDbType.VarChar);
            objSqlCommand.Parameters["pflag"].Value = chkbtnstatusdate;

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


    public DataSet getteamname(string compcode, string teamname, string extra1, string extra2, string extra3, string extra4, string extra5)
    {
        MySqlConnection objSqlConnection;
        MySqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("BIND_BOOKING_TEAM", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            objSqlCommand.Parameters.Add("compcode1", MySqlDbType.VarChar);
            objSqlCommand.Parameters["compcode1"].Value = compcode;

            objSqlCommand.Parameters.Add("teamname", MySqlDbType.VarChar);
            objSqlCommand.Parameters["teamname"].Value = teamname;

            objSqlCommand.Parameters.Add("extra1", MySqlDbType.VarChar);
            objSqlCommand.Parameters["extra1"].Value = extra1;

            objSqlCommand.Parameters.Add("extra2", MySqlDbType.VarChar);
            objSqlCommand.Parameters["extra2"].Value = extra2;

            objSqlCommand.Parameters.Add("extra3", MySqlDbType.VarChar);
            objSqlCommand.Parameters["extra3"].Value = extra3;

            objSqlCommand.Parameters.Add("extra4", MySqlDbType.VarChar);
            objSqlCommand.Parameters["extra4"].Value = extra4;

            objSqlCommand.Parameters.Add("extra5", MySqlDbType.VarChar);
            objSqlCommand.Parameters["extra5"].Value = extra5;

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

    // for material upload form bind edition from package
    public DataSet editionfordatagrid(string compcode, string packagepckcode, string extra1, string extra2)
    {
        MySqlConnection objSqlConnection;
        MySqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("editionname_formatterfrom_pck_sou", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            objSqlCommand.Parameters.Add("pcomp_code", MySqlDbType.VarChar);
            objSqlCommand.Parameters["pcomp_code"].Value = compcode;

            objSqlCommand.Parameters.Add("ppackage_code", MySqlDbType.VarChar);
            objSqlCommand.Parameters["ppackage_code"].Value = packagepckcode;

            objSqlCommand.Parameters.Add("pextra1", MySqlDbType.VarChar);
            objSqlCommand.Parameters["pextra1"].Value = extra1;

            objSqlCommand.Parameters.Add("pextra2", MySqlDbType.VarChar);
            objSqlCommand.Parameters["pextra2"].Value = extra2;

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


    // 
    public DataSet clsCioId(string s_agencycode, string filename, string reciept)
    {
        MySqlConnection objSqlConnection;
        MySqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("websp_cioid_qbcrono_websp_cioid_p_qbc", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            objSqlCommand.Parameters.Add("s_agencycode", MySqlDbType.VarChar);
            objSqlCommand.Parameters["s_agencycode"].Value = s_agencycode;

            objSqlCommand.Parameters.Add("filename", MySqlDbType.VarChar);
            objSqlCommand.Parameters["filename"].Value = filename;

            objSqlCommand.Parameters.Add("reciept", MySqlDbType.VarChar);
            objSqlCommand.Parameters["reciept"].Value = reciept;

            objSqlDataAdapter.SelectCommand = objSqlCommand;
            objSqlDataAdapter.Fill(objDataSet);
            return objDataSet;


        }
        catch (MySqlException objException)
        {
            throw (objException);
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


