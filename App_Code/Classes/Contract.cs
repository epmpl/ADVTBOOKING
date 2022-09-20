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
/// Summary description for Contract
/// </summary>
namespace NewAdbooking.Classes
{
    public class Contract : connection
    {
        public Contract()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataSet getrateforcontract_Elec(string compcode_p, string unit_p, string channel_p, string location_p, string adtype_p, string ratetype, string day_p, string category_p, string btb_p, string fct_p, string validfrom_p, string validto_p, string package_p, string valufrom_p, string valueto_p, string disctype_p, string disper, string premium, string cardprem_p, string contprem_p, string minsize_p, string maxsize_p, string progtype_p, string progname_p, string commallow_p, string ratecode_p, string source_p, string dateformat, string currency_p, string contractrate_p, string agencycode_p, string subagencycode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("tv_getcardrate", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode_p"].Value = compcode_p;


                objSqlCommand.Parameters.Add("@unit_p", SqlDbType.VarChar);
                if (unit_p == "")
                    objSqlCommand.Parameters["@unit_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@unit_p"].Value = unit_p;

                objSqlCommand.Parameters.Add("@channel_p", SqlDbType.VarChar);
                if (channel_p == "")
                    objSqlCommand.Parameters["@channel_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@channel_p"].Value = channel_p;

                objSqlCommand.Parameters.Add("@location_p", SqlDbType.VarChar);
                if (location_p == "")
                    objSqlCommand.Parameters["@location_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@location_p"].Value = location_p;

                objSqlCommand.Parameters.Add("@adtype_p", SqlDbType.VarChar);
                if (adtype_p == "")
                    objSqlCommand.Parameters["@adtype_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@adtype_p"].Value = adtype_p;

                objSqlCommand.Parameters.Add("@ratetype", SqlDbType.VarChar);
                if (ratetype == "")
                    objSqlCommand.Parameters["@ratetype"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@ratetype"].Value = ratetype;

                objSqlCommand.Parameters.Add("@day_p", SqlDbType.VarChar);
                if (day_p == "")
                    objSqlCommand.Parameters["@day_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@day_p"].Value = day_p;

                objSqlCommand.Parameters.Add("@category_p", SqlDbType.VarChar);
                if (category_p == "")
                    objSqlCommand.Parameters["@category_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@category_p"].Value = category_p;


                objSqlCommand.Parameters.Add("@btb_p", SqlDbType.VarChar);
                if (btb_p == "")
                    objSqlCommand.Parameters["@btb_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@btb_p"].Value = btb_p;


                objSqlCommand.Parameters.Add("@fct_p", SqlDbType.VarChar);
                if (fct_p == "")
                    objSqlCommand.Parameters["@fct_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@fct_p"].Value = fct_p;


                objSqlCommand.Parameters.Add("@validfrom_p", SqlDbType.VarChar);
                if (validfrom_p == "")
                    objSqlCommand.Parameters["@validfrom_p"].Value = System.DBNull.Value;
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = validfrom_p.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        validfrom_p = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = validfrom_p.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        validfrom_p = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@validfrom_p"].Value = validfrom_p;
                }

                objSqlCommand.Parameters.Add("@validto_p", SqlDbType.VarChar);
                if (validto_p == "")
                    objSqlCommand.Parameters["@validto_p"].Value = System.DBNull.Value;
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = validto_p.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        validto_p = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = validto_p.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        validto_p = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@validto_p"].Value = validto_p;
                }

                objSqlCommand.Parameters.Add("@package_p", SqlDbType.VarChar);
                if (package_p == "")
                    objSqlCommand.Parameters["@package_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@package_p"].Value = package_p;

                objSqlCommand.Parameters.Add("@valufrom_p", SqlDbType.VarChar);
                if (valufrom_p == "")
                    objSqlCommand.Parameters["@valufrom_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@valufrom_p"].Value = valufrom_p;

                objSqlCommand.Parameters.Add("@valueto_p", SqlDbType.VarChar);
                if (valueto_p == "")
                    objSqlCommand.Parameters["@valueto_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@valueto_p"].Value = valueto_p;

                objSqlCommand.Parameters.Add("@disctype_p", SqlDbType.VarChar);
                if (disctype_p == "")
                    objSqlCommand.Parameters["@disctype_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@disctype_p"].Value = disctype_p;

                objSqlCommand.Parameters.Add("@disper", SqlDbType.VarChar);
                if (disper == "")
                    objSqlCommand.Parameters["@disper"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@disper"].Value = disper;

                objSqlCommand.Parameters.Add("@premium", SqlDbType.VarChar);
                if (premium == "")
                    objSqlCommand.Parameters["@premium"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@premium"].Value = premium;


                objSqlCommand.Parameters.Add("@cardprem_p", SqlDbType.VarChar);
                if (cardprem_p == "")
                    objSqlCommand.Parameters["@cardprem_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@cardprem_p"].Value = cardprem_p;

                objSqlCommand.Parameters.Add("@contprem_p", SqlDbType.VarChar);
                if (contprem_p == "")
                    objSqlCommand.Parameters["@contprem_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@contprem_p"].Value = contprem_p;

                objSqlCommand.Parameters.Add("@minsize_p", SqlDbType.VarChar);
                if (minsize_p == "")
                    objSqlCommand.Parameters["@minsize_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@minsize_p"].Value = minsize_p;

                objSqlCommand.Parameters.Add("@maxsize_p", SqlDbType.VarChar);
                if (maxsize_p == "")
                    objSqlCommand.Parameters["@maxsize_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@maxsize_p"].Value = maxsize_p;

                objSqlCommand.Parameters.Add("@progtype_p", SqlDbType.VarChar);
                if (progtype_p == "")
                    objSqlCommand.Parameters["@progtype_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@progtype_p"].Value = progtype_p;

                objSqlCommand.Parameters.Add("@progname_p", SqlDbType.VarChar);
                if (progname_p == "")
                    objSqlCommand.Parameters["@progname_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@progname_p"].Value = progname_p;

                objSqlCommand.Parameters.Add("@commallow_p", SqlDbType.VarChar);
                if (commallow_p == "")
                    objSqlCommand.Parameters["@commallow_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@commallow_p"].Value = commallow_p;

                objSqlCommand.Parameters.Add("@ratecode_p", SqlDbType.VarChar);
                if (ratecode_p == "")
                    objSqlCommand.Parameters["@ratecode_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@ratecode_p"].Value = ratecode_p;

                objSqlCommand.Parameters.Add("@source_p", SqlDbType.VarChar);
                if (source_p == "")
                    objSqlCommand.Parameters["@source_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@source_p"].Value = source_p;

                objSqlCommand.Parameters.Add("@currency_p", SqlDbType.VarChar);
                if (currency_p == "")
                    objSqlCommand.Parameters["@currency_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@currency_p"].Value = currency_p;

                objSqlCommand.Parameters.Add("@p_pref_sec", SqlDbType.VarChar);
                if (ConfigurationSettings.AppSettings["TV_SECONDS"] == null)
                    objSqlCommand.Parameters["@p_pref_sec"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@p_pref_sec"].Value = ConfigurationSettings.AppSettings["TV_SECONDS"].ToString();

                objSqlCommand.Parameters.Add("@p_contract_rate", SqlDbType.VarChar);
                if (contractrate_p == "")
                    objSqlCommand.Parameters["@p_contract_rate"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@p_contract_rate"].Value = contractrate_p;

                objSqlCommand.Parameters.Add("@p_agency_code", SqlDbType.VarChar);
                if (agencycode_p == "")
                    objSqlCommand.Parameters["@p_agency_code"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@p_agency_code"].Value = agencycode_p;


                objSqlCommand.Parameters.Add("@p_agency_subcode", SqlDbType.VarChar);
                if (subagencycode == "")
                    objSqlCommand.Parameters["@p_agency_subcode"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@p_agency_subcode"].Value = subagencycode;
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
        public DataSet tv_paid_balance_cal(string pcomp_code, string punit_code, string pchannel, string plocation_code, string pad_type, string pdealno, string pbtb_code, string ppaid_bonus)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("tv_paid_balance_cal", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@pcomp_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcomp_code"].Value = pcomp_code;


                objSqlCommand.Parameters.Add("@punit_code", SqlDbType.VarChar);
                if (punit_code == "")
                    objSqlCommand.Parameters["@punit_code"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@punit_code"].Value = punit_code;

                objSqlCommand.Parameters.Add("@pchannel", SqlDbType.VarChar);
                if (pchannel == "")
                    objSqlCommand.Parameters["@pchannel"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@pchannel"].Value = pchannel;

                objSqlCommand.Parameters.Add("@plocation_code", SqlDbType.VarChar);
                if (plocation_code == "")
                    objSqlCommand.Parameters["@plocation_code"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@plocation_code"].Value = plocation_code;

                objSqlCommand.Parameters.Add("@pad_type", SqlDbType.VarChar);
                if (pad_type == "")
                    objSqlCommand.Parameters["@pad_type"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@pad_type"].Value = pad_type;

                objSqlCommand.Parameters.Add("@pdealno", SqlDbType.VarChar);
                if (pdealno == "")
                    objSqlCommand.Parameters["@pdealno"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@pdealno"].Value = pdealno;

                objSqlCommand.Parameters.Add("@pbtb_code", SqlDbType.VarChar);
                if (pbtb_code == "")
                    objSqlCommand.Parameters["@pbtb_code"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@pbtb_code"].Value = pbtb_code;

                objSqlCommand.Parameters.Add("@ppaid_bonus", SqlDbType.VarChar);
                if (ppaid_bonus == "")
                    objSqlCommand.Parameters["@ppaid_bonus"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@ppaid_bonus"].Value = ppaid_bonus;


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
        public DataSet TV_packagebind(string compcode, string adtype, string channel)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("TV_packagebind", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;


                objSqlCommand.Parameters.Add("@adtype", SqlDbType.VarChar);
                if (adtype == "")
                    objSqlCommand.Parameters["@adtype"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@adtype"].Value = adtype;

                objSqlCommand.Parameters.Add("@channel_p", SqlDbType.VarChar);
                if (channel == "")
                    objSqlCommand.Parameters["@channel_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@channel_p"].Value = channel;
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
        public DataSet ratebind(string compcode, string adtype)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("BINDRATECODE_TV", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;


                objSqlCommand.Parameters.Add("@adtype", SqlDbType.VarChar);
                if (adtype == "")
                    objSqlCommand.Parameters["@adtype"].Value = System.DBNull.Value;
                else
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
        public DataSet bindSource_TV(string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("TV_SOURCE_TYPE_BIND", ref objSqlConnection);
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
        public DataSet bindGridDetails_Contract(string compcode, string dealcode, string seqno_p)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("bindGridDetails_Contract", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@dealcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dealcode"].Value = dealcode;

                objSqlCommand.Parameters.Add("@seqno_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@seqno_p"].Value = seqno_p;


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
        public void saveElecDetailsProc(string dealno, string channel, string location, string advtype, string paidbonus, string progname, string btb, string ros, string day, string fct, string package, string valuefrom, string valueto, string disctype, string discper, string premium, string contpremium, string contrate, string cardrate, string deviation, string cardprem, string minsize, string maxsize, string currency, string dealstart, string progtype, string category, string commallow, string remarks, string ratecode, string discon, string sponfrom, string sponto, string compcode, string userid, string username, string incentive, string approved, string unit, string seqno, string id, string ratetype, string dateformat, string source, string totalval,string sectioncode,string resourceno,string localtotvalue,string convrate,string slot)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("savecontractelec_detail", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@dealno_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dealno_p"].Value = dealno;

                objSqlCommand.Parameters.Add("@channel_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@channel_p"].Value = channel;

                objSqlCommand.Parameters.Add("@location_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@location_p"].Value = location;

                objSqlCommand.Parameters.Add("@advtype_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@advtype_p"].Value = advtype;

                objSqlCommand.Parameters.Add("@paidbonus_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@paidbonus_p"].Value = paidbonus;

                objSqlCommand.Parameters.Add("@progname_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@progname_p"].Value = progname;

                objSqlCommand.Parameters.Add("@btb_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@btb_p"].Value = btb;

                objSqlCommand.Parameters.Add("@ros_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ros_p"].Value = ros;

                objSqlCommand.Parameters.Add("@day_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@day_p"].Value = day;

                objSqlCommand.Parameters.Add("@fct_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@fct_p"].Value = fct;

                objSqlCommand.Parameters.Add("@package_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@package_p"].Value = package;

                objSqlCommand.Parameters.Add("@valuefrom_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@valuefrom_p"].Value = valuefrom;

                objSqlCommand.Parameters.Add("@valueto_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@valueto_p"].Value = valueto;

                objSqlCommand.Parameters.Add("@disctype_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@disctype_p"].Value = disctype;

                objSqlCommand.Parameters.Add("@discper_p", SqlDbType.VarChar);
                if (discper == "")
                    objSqlCommand.Parameters["@discper_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@discper_p"].Value = discper;

                objSqlCommand.Parameters.Add("@premium_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@premium_p"].Value = premium;

                objSqlCommand.Parameters.Add("@contpremium_p", SqlDbType.VarChar);
                if (contpremium == "")
                    objSqlCommand.Parameters["@contpremium_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@contpremium_p"].Value = contpremium;


                objSqlCommand.Parameters.Add("@contrate_p", SqlDbType.VarChar);
                if (contrate == "")
                    objSqlCommand.Parameters["@contrate_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@contrate_p"].Value = contrate;

                objSqlCommand.Parameters.Add("@cardrate_p", SqlDbType.VarChar);
                if (cardrate == "")
                    objSqlCommand.Parameters["@cardrate_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@cardrate_p"].Value = cardrate;

                objSqlCommand.Parameters.Add("@deviation_p", SqlDbType.VarChar);
                if (deviation == "")
                    objSqlCommand.Parameters["@deviation_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@deviation_p"].Value = deviation;

                objSqlCommand.Parameters.Add("@cardprem_p", SqlDbType.VarChar);
                if (cardprem == "")
                    objSqlCommand.Parameters["@cardprem_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@cardprem_p"].Value = cardprem;
                objSqlCommand.Parameters.Add("@minsize_p", SqlDbType.VarChar);
                if (minsize == "")
                    objSqlCommand.Parameters["@minsize_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@minsize_p"].Value = minsize;
                objSqlCommand.Parameters.Add("@maxsize_p", SqlDbType.VarChar);
                if (maxsize == "")
                    objSqlCommand.Parameters["@maxsize_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@maxsize_p"].Value = maxsize;

                objSqlCommand.Parameters.Add("@currency_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@currency_p"].Value = currency;

                objSqlCommand.Parameters.Add("@dealstart_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dealstart_p"].Value = dealstart;

                objSqlCommand.Parameters.Add("@progtype_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@progtype_p"].Value = progtype;

                objSqlCommand.Parameters.Add("@category_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@category_p"].Value = category;

                objSqlCommand.Parameters.Add("@commallow_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@commallow_p"].Value = commallow;

                objSqlCommand.Parameters.Add("@remarks_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@remarks_p"].Value = remarks;

                objSqlCommand.Parameters.Add("@ratecode_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ratecode_p"].Value = ratecode;

                objSqlCommand.Parameters.Add("@discon_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@discon_p"].Value = discon;

                objSqlCommand.Parameters.Add("@sponfrom_p", SqlDbType.VarChar);
                if (sponfrom == "")
                    objSqlCommand.Parameters["@sponfrom_p"].Value = System.DBNull.Value;
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = sponfrom.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        sponfrom = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = sponfrom.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        sponfrom = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@sponfrom_p"].Value = sponfrom;
                }

                objSqlCommand.Parameters.Add("@sponto_p", SqlDbType.VarChar);
                if (sponto == "")
                    objSqlCommand.Parameters["@sponto_p"].Value = System.DBNull.Value;
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = sponto.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        sponto = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = sponto.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        sponto = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@sponto_p"].Value = sponto;
                }
                objSqlCommand.Parameters.Add("@compcode_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode_p"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid_p"].Value = userid;

                objSqlCommand.Parameters.Add("@username_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@username_p"].Value = username;

                objSqlCommand.Parameters.Add("@incentive_p", SqlDbType.VarChar);
                if (incentive == "")
                    objSqlCommand.Parameters["@incentive_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@incentive_p"].Value = incentive;

                objSqlCommand.Parameters.Add("@approved_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@approved_p"].Value = approved;

                objSqlCommand.Parameters.Add("@unit_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@unit_p"].Value = unit;

                objSqlCommand.Parameters.Add("@seqno_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@seqno_p"].Value = seqno;

                objSqlCommand.Parameters.Add("@id_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@id_p"].Value = id;

                objSqlCommand.Parameters.Add("@ratetype_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ratetype_p"].Value = ratetype;

                objSqlCommand.Parameters.Add("@source_p", SqlDbType.VarChar);
                if (source == "")
                    objSqlCommand.Parameters["@source_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@source_p"].Value = source;

                objSqlCommand.Parameters.Add("@totalval_p", SqlDbType.VarChar);
                if (totalval == "")
                    objSqlCommand.Parameters["@totalval_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@totalval_p"].Value = totalval;
                // for sectioncode and resourceno
                objSqlCommand.Parameters.Add("@sectioncode_p", SqlDbType.VarChar);
                if (sectioncode == "")
                    objSqlCommand.Parameters["@sectioncode_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@sectioncode_p"].Value = sectioncode;

                objSqlCommand.Parameters.Add("@resourceno_p", SqlDbType.VarChar);
                if (resourceno == "")
                    objSqlCommand.Parameters["@resourceno_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@resourceno_p"].Value = resourceno;

                //
                objSqlCommand.Parameters.Add("@localtotvalue_p", SqlDbType.VarChar);
                if (localtotvalue == "")
                    objSqlCommand.Parameters["@localtotvalue_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@localtotvalue_p"].Value = localtotvalue;

                objSqlCommand.Parameters.Add("@convrate_p", SqlDbType.VarChar);
                if (convrate == "")
                    objSqlCommand.Parameters["@convrate_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@convrate_p"].Value = convrate;

                objSqlCommand.Parameters.Add("@slot_per_day", SqlDbType.VarChar);
                if (slot == "")
                    objSqlCommand.Parameters["@slot_per_day"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@slot_per_day"].Value = slot;

                objSqlDataAdapter.SelectCommand = objSqlCommand;
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
        public void savecontractdetail(string dealno, string adtype, string hue, string uom, string package, string category, string premium, string cardprem, string contractprem, string contrate, string cardrate, string deviation, string disctype, string discper, string discon, string minsize, string maxsize, string valuefrom, string valueto, string day, string insertion, string commallow, string dealstart, string currency, string ratecode, string totalrate, string incentive, string remarks, string approved, string compcode, string userid, string id, string position, string contractamount, string contractpositionprem, string positionpremdisc, string toinsertion, string barter)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();

            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("savecontract_detail", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@dealno_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dealno_p"].Value = dealno;

                objSqlCommand.Parameters.Add("@adtype_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adtype_p"].Value = adtype;

                objSqlCommand.Parameters.Add("@hue_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@hue_p"].Value = hue;

                objSqlCommand.Parameters.Add("@uom_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@uom_p"].Value = uom;

                objSqlCommand.Parameters.Add("@package_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@package_p"].Value = package;

                objSqlCommand.Parameters.Add("@category_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@category_p"].Value = category;

                objSqlCommand.Parameters.Add("@premium_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@premium_p"].Value = premium;

                objSqlCommand.Parameters.Add("@cardprem_p", SqlDbType.VarChar);
                if (cardprem == "")
                    objSqlCommand.Parameters["@cardprem_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@cardprem_p"].Value = cardprem;
                objSqlCommand.Parameters.Add("@contractprem_p", SqlDbType.VarChar);
                if (contractprem == "")
                    objSqlCommand.Parameters["@contractprem_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@contractprem_p"].Value = contractprem;
                objSqlCommand.Parameters.Add("@contrate_p", SqlDbType.VarChar);
                if (contrate == "")
                    objSqlCommand.Parameters["@contrate_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@contrate_p"].Value = contrate;

                objSqlCommand.Parameters.Add("@cardrate_p", SqlDbType.VarChar);
                if (cardrate == "")
                    objSqlCommand.Parameters["@cardrate_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@cardrate_p"].Value = cardrate;

                objSqlCommand.Parameters.Add("@deviation_p", SqlDbType.VarChar);
                if (deviation == "")
                    objSqlCommand.Parameters["@deviation_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@deviation_p"].Value = deviation;

                objSqlCommand.Parameters.Add("@disctype_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@disctype_p"].Value = disctype;

                objSqlCommand.Parameters.Add("@discper_p", SqlDbType.VarChar);
                if (discper == "")
                    objSqlCommand.Parameters["@discper_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@discper_p"].Value = discper;

                objSqlCommand.Parameters.Add("@discon_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@discon_p"].Value = discon;

                objSqlCommand.Parameters.Add("@minsize_p", SqlDbType.VarChar);
                if (minsize == "")
                    objSqlCommand.Parameters["@minsize_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@minsize_p"].Value = minsize;

                objSqlCommand.Parameters.Add("@maxsize_p", SqlDbType.VarChar);
                if (maxsize == "")
                    objSqlCommand.Parameters["@maxsize_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@maxsize_p"].Value = maxsize;

                objSqlCommand.Parameters.Add("@valuefrom_p", SqlDbType.VarChar);
                if (valuefrom == "")
                    objSqlCommand.Parameters["@valuefrom_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@valuefrom_p"].Value = valuefrom;

                objSqlCommand.Parameters.Add("@valueto_p", SqlDbType.VarChar);
                if (valueto == "")
                    objSqlCommand.Parameters["@valueto_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@valueto_p"].Value = valueto;

                objSqlCommand.Parameters.Add("@day_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@day_p"].Value = day;

                objSqlCommand.Parameters.Add("@insertion_p", SqlDbType.VarChar);
                if (insertion == "")
                    objSqlCommand.Parameters["@insertion_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@insertion_p"].Value = insertion;

                objSqlCommand.Parameters.Add("@commallow_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@commallow_p"].Value = commallow;

                objSqlCommand.Parameters.Add("@dealstart_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dealstart_p"].Value = dealstart;

                objSqlCommand.Parameters.Add("@currency_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@currency_p"].Value = currency;

                objSqlCommand.Parameters.Add("@ratecode_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ratecode_p"].Value = ratecode;

                objSqlCommand.Parameters.Add("@totalrate_p", SqlDbType.VarChar);
                if (totalrate == "")
                    objSqlCommand.Parameters["@totalrate_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@totalrate_p"].Value = totalrate;

                objSqlCommand.Parameters.Add("@incentive_p", SqlDbType.VarChar);
                if (incentive == "")
                    objSqlCommand.Parameters["@incentive_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@incentive_p"].Value = incentive;

                objSqlCommand.Parameters.Add("@remarks_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@remarks_p"].Value = remarks;

                objSqlCommand.Parameters.Add("@approved_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@approved_p"].Value = approved;

                objSqlCommand.Parameters.Add("@compcode_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode_p"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid_p"].Value = userid;

                objSqlCommand.Parameters.Add("@id_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@id_p"].Value = id;

                  objSqlCommand.Parameters.Add("@positionprem", SqlDbType.VarChar);
                objSqlCommand.Parameters["@positionprem"].Value = position;

                  objSqlCommand.Parameters.Add("@contractamount1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@contractamount1"].Value = contractamount;

                objSqlCommand.Parameters.Add("@pcontractpositionprem", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcontractpositionprem"].Value = contractpositionprem;

                objSqlCommand.Parameters.Add("@ppositionpremdisc", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ppositionpremdisc"].Value = positionpremdisc;

                objSqlCommand.Parameters.Add("@ptoinsertion", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ptoinsertion"].Value = toinsertion;

                objSqlCommand.Parameters.Add("@pbarter", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pbarter"].Value = barter;

                objSqlDataAdapter.SelectCommand = objSqlCommand;
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
        public DataSet bindProgramType_TV(string compcode, string channel)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("TV_AD_PROGRAMME_TY_BIND", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@channel_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@channel_p"].Value = channel;

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
        public DataSet bindProgram_TV(string compcode, string progtype, string btbcode, string channel_p)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("TV_AD_PROGRAMME_BIND_BTB", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@progtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@progtype"].Value = progtype;

                objSqlCommand.Parameters.Add("@btbcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@btbcode"].Value = btbcode;

                objSqlCommand.Parameters.Add("@channel_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@channel_p"].Value = channel_p;


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
        public DataSet bindROS_TV(string compcode, string btbcode, string channel)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("TV_BND_MST_BIND", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@btbcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@btbcode"].Value = btbcode;

                objSqlCommand.Parameters.Add("@channel_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@channel_p"].Value = channel;

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
        public DataSet bindAdvType_TV(string compcode, string channel)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("TV_AD_TYPE_BIND", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@channel_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@channel_p"].Value = channel;

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
        public DataSet bindBTB_TV(string compcode, string channel)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("TV_BTB_MST_BIND", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@channel_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@channel_p"].Value = channel;

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
        public DataSet bindChannel_TV(string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("TV_AD_CHANNEL_BIND", ref objSqlConnection);
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
        public DataSet bindLocation_TV(string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("TV_AD_LOCATION_BIND", ref objSqlConnection);
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
        public DataSet bindProduct(string compcode, string industry)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("bindProductIndustryWise", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@industry", SqlDbType.VarChar);
                if (industry == "")
                    objSqlCommand.Parameters["@industry"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@industry"].Value = industry;

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
        public DataSet bindgridContract(string compcode, string userid, string values, string adcat)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();

                if (adcat == "0")
                {
                    objSqlCommand = GetCommand("bindcontract", ref objSqlConnection);
                    objSqlCommand.CommandType = CommandType.StoredProcedure;

                    objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                    objSqlCommand.Parameters["@compcode"].Value = compcode;

                    objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                    objSqlCommand.Parameters["@userid"].Value = userid;
                    if (values == null)
                    {
                        values = "";
                    }
                    objSqlCommand.Parameters.Add("@values", SqlDbType.VarChar);
                    objSqlCommand.Parameters["@values"].Value = values;
                }


                else
                {

                    objSqlCommand = GetCommand("getedibyvat", ref objSqlConnection);
                    objSqlCommand.CommandType = CommandType.StoredProcedure;

                    objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                    objSqlCommand.Parameters["@compcode"].Value = compcode;

                    objSqlCommand.Parameters.Add("@adcat", SqlDbType.VarChar);
                    objSqlCommand.Parameters["@adcat"].Value = adcat;

                    objSqlCommand.Parameters.Add("@checkboxname", SqlDbType.VarChar);
                    objSqlCommand.Parameters["@checkboxname"].Value = values;

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
        public DataSet bindagency(string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("bindagencyforcontract", ref objSqlConnection);
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





        public DataSet bindsubagency(string agency, string compcode, string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("bindsubagencyforcontract", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@agency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agency"].Value = agency;




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

        public DataSet clientbind(string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("bindclientforcontract", ref objSqlConnection);
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

        public DataSet productbind(string client, string compcode, string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("bindproductforcontract", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@client", SqlDbType.VarChar);
                objSqlCommand.Parameters["@client"].Value = client;






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

        public DataSet contractcode(string DealNo, string compcode, string dealname, string dealtype)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("checkcontractcode", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@dealname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dealname"].Value = dealname;

                objSqlCommand.Parameters.Add("@dealtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dealtype"].Value = dealtype;

                objSqlCommand.Parameters.Add("@DealNo", SqlDbType.VarChar);
                objSqlCommand.Parameters["@DealNo"].Value = DealNo;






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

        public DataSet insertcontact(string DealNo, string dealname, string agencycode, string subagencycode, string clientname, string product, string validfromdate, string validtill, string representative, string compcode, string userid, string totalvalue, string totalvolume, string currencys, string teamname, string dealtype, string adtype, string remarks, string executive_var, string retainer_var, string contdate_var, string closedate_var, string servicetax_var, string caption_var, string paymode_var, string b2b, string chkmulti, string chkseq, string seqno, string chkparti, string indus, string induspro, string dealon, string attach1, string transition, string centername, string printcenter, string rono, string rodate, string rostatus, string rcptno, string rcptcurr, string quotation)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("insertcontactmast", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@teamname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@teamname"].Value = teamname;

                objSqlCommand.Parameters.Add("@dealtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dealtype"].Value = dealtype;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@currencys", SqlDbType.VarChar);
                objSqlCommand.Parameters["@currencys"].Value = currencys;

                objSqlCommand.Parameters.Add("@DealNo", SqlDbType.VarChar);
                objSqlCommand.Parameters["@DealNo"].Value = DealNo;

                objSqlCommand.Parameters.Add("@dealname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dealname"].Value = dealname;

                objSqlCommand.Parameters.Add("@totalvalue", SqlDbType.Float);
                if (totalvalue == "")
                {
                    objSqlCommand.Parameters["@totalvalue"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@totalvalue"].Value = Convert.ToDecimal(totalvalue);
                }
                objSqlCommand.Parameters.Add("@totalvolume", SqlDbType.Float);
                if (totalvolume == "")
                {
                    objSqlCommand.Parameters["@totalvolume"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@totalvolume"].Value = Convert.ToDecimal(totalvolume);
                }

                objSqlCommand.Parameters.Add("@agencycode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencycode"].Value = agencycode;

                objSqlCommand.Parameters.Add("@subagencycode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@subagencycode"].Value = subagencycode;

                objSqlCommand.Parameters.Add("@product", SqlDbType.VarChar);
                objSqlCommand.Parameters["@product"].Value = product;

                objSqlCommand.Parameters.Add("@validfromdate", SqlDbType.DateTime);
                if (validfromdate == null || validfromdate == "")
                {
                    objSqlCommand.Parameters["@validfromdate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@validfromdate"].Value = Convert.ToDateTime(validfromdate);
                }

                objSqlCommand.Parameters.Add("@validtill", SqlDbType.DateTime);
                if (validtill == null && validtill == "")
                {
                    objSqlCommand.Parameters["@validtill"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@validtill"].Value = Convert.ToDateTime(validtill);
                }

                objSqlCommand.Parameters.Add("@representative", SqlDbType.VarChar);
                objSqlCommand.Parameters["@representative"].Value = representative;

                objSqlCommand.Parameters.Add("@clientname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@clientname"].Value = clientname;

                objSqlCommand.Parameters.Add("@adtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adtype"].Value = adtype;

                objSqlCommand.Parameters.Add("@remarks", SqlDbType.VarChar);
                objSqlCommand.Parameters["@remarks"].Value = remarks;

                objSqlCommand.Parameters.Add("@executive_var", SqlDbType.VarChar);
                objSqlCommand.Parameters["@executive_var"].Value = executive_var;

                objSqlCommand.Parameters.Add("@retainer_var", SqlDbType.VarChar);
                objSqlCommand.Parameters["@retainer_var"].Value = retainer_var;

                objSqlCommand.Parameters.Add("@contdate_var", SqlDbType.VarChar);
                if (contdate_var == "")
                    objSqlCommand.Parameters["@contdate_var"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@contdate_var"].Value = contdate_var;

                objSqlCommand.Parameters.Add("@closedate_var", SqlDbType.VarChar);
                if (closedate_var == "")
                    objSqlCommand.Parameters["@closedate_var"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@closedate_var"].Value = closedate_var;

                objSqlCommand.Parameters.Add("@servicetax_var", SqlDbType.VarChar);
                objSqlCommand.Parameters["@servicetax_var"].Value = servicetax_var;

                objSqlCommand.Parameters.Add("@caption_var", SqlDbType.VarChar);
                objSqlCommand.Parameters["@caption_var"].Value = caption_var;

                objSqlCommand.Parameters.Add("@paymode_var", SqlDbType.VarChar);
                objSqlCommand.Parameters["@paymode_var"].Value = paymode_var;


                objSqlCommand.Parameters.Add("@b2b_var", SqlDbType.VarChar);
                objSqlCommand.Parameters["@b2b_var"].Value = b2b;

                objSqlCommand.Parameters.Add("@chkmulti_var", SqlDbType.VarChar);
                objSqlCommand.Parameters["@chkmulti_var"].Value = chkmulti;

                objSqlCommand.Parameters.Add("@chkseq_var", SqlDbType.VarChar);
                objSqlCommand.Parameters["@chkseq_var"].Value = chkseq;

                objSqlCommand.Parameters.Add("@seqno_var", SqlDbType.VarChar);
                objSqlCommand.Parameters["@seqno_var"].Value = seqno;

                objSqlCommand.Parameters.Add("@chkparti_var", SqlDbType.VarChar);
                objSqlCommand.Parameters["@chkparti_var"].Value = chkparti;

                objSqlCommand.Parameters.Add("@indus_var", SqlDbType.VarChar);
                objSqlCommand.Parameters["@indus_var"].Value = indus;

                objSqlCommand.Parameters.Add("@induspro_var", SqlDbType.VarChar);
                objSqlCommand.Parameters["@induspro_var"].Value = induspro;

                objSqlCommand.Parameters.Add("@dealon_var", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dealon_var"].Value = dealon;


                objSqlCommand.Parameters.Add("@attachment1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@attachment1"].Value = attach1;

                objSqlCommand.Parameters.Add("@dealcenter", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dealcenter"].Value = printcenter;

                objSqlCommand.Parameters.Add("@dealfrom", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dealfrom"].Value = centername;

                objSqlCommand.Parameters.Add("@translation", SqlDbType.VarChar);
                objSqlCommand.Parameters["@translation"].Value = transition;
                //string rono, string rodate, string rostatus, string rcptno, string rcptcurr
                objSqlCommand.Parameters.Add("@rono_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rono_p"].Value = rono;

                objSqlCommand.Parameters.Add("@rodate_p", SqlDbType.VarChar);
                if (rodate == null || rodate == "")
                {
                    objSqlCommand.Parameters["@rodate_p"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@rodate_p"].Value = Convert.ToDateTime(rodate);
                }
              

                objSqlCommand.Parameters.Add("@rostatus_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rostatus_p"].Value = rostatus;

                objSqlCommand.Parameters.Add("@rcptno_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rcptno_p"].Value = rcptno;

                objSqlCommand.Parameters.Add("@rcptcurr_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rcptcurr_p"].Value = rcptcurr;

                objSqlCommand.Parameters.Add("@quotion_p", SqlDbType.VarChar);
                if (quotation == "" || quotation == "N")
                objSqlCommand.Parameters["@quotion_p"].Value =System.DBNull.Value;
                else
                objSqlCommand.Parameters["@quotion_p"].Value = quotation;

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

        public DataSet modifycontact(string DealNo, string dealname, string agencycode, string subagencycode, string clientname, string product, string validfromdate, string validtill, string representative, string compcode, string userid, string totalvalue, string totalvolume, string currencys, string teamname, string dealtype, string adtype, string remarks, string executive_var, string retainer_var, string contdate_var, string closedate_var, string servicetax_var, string caption_var, string paymode_var, string b2b, string chkmulti, string chkseq, string seqno, string chkparti, string indus, string induspro, string dealon, string attach1, string transition, string centername, string printcenter, string rono, string rodate, string rostatus, string rcptno, string rcptcurr)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("updatecontactmast", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@teamname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@teamname"].Value = teamname;

                objSqlCommand.Parameters.Add("@dealname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dealname"].Value = dealname;

                objSqlCommand.Parameters.Add("@dealtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dealtype"].Value = dealtype;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@currencys", SqlDbType.VarChar);
                objSqlCommand.Parameters["@currencys"].Value = currencys;

                objSqlCommand.Parameters.Add("@DealNo", SqlDbType.VarChar);
                objSqlCommand.Parameters["@DealNo"].Value = DealNo;

                objSqlCommand.Parameters.Add("@totalvalue", SqlDbType.VarChar);
                if (totalvalue == "")
                    objSqlCommand.Parameters["@totalvalue"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@totalvalue"].Value = totalvalue;

                objSqlCommand.Parameters.Add("@totalvolume", SqlDbType.VarChar);
                if (totalvolume == "")
                    objSqlCommand.Parameters["@totalvolume"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@totalvolume"].Value = totalvolume;

                objSqlCommand.Parameters.Add("@agencycode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencycode"].Value = agencycode;

                objSqlCommand.Parameters.Add("@subagencycode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@subagencycode"].Value = subagencycode;

                objSqlCommand.Parameters.Add("@product", SqlDbType.VarChar);
                objSqlCommand.Parameters["@product"].Value = product;

                objSqlCommand.Parameters.Add("@validfromdate", SqlDbType.DateTime);
                if (validfromdate == null && validfromdate == "")
                {
                    objSqlCommand.Parameters["@validfromdate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@validfromdate"].Value = Convert.ToDateTime(validfromdate);
                }

                objSqlCommand.Parameters.Add("@validtill", SqlDbType.DateTime);
                if (validtill == null && validtill == "")
                {
                    objSqlCommand.Parameters["@validtill"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@validtill"].Value = Convert.ToDateTime(validtill);
                }

                objSqlCommand.Parameters.Add("@representative", SqlDbType.VarChar);
                objSqlCommand.Parameters["@representative"].Value = representative;

                objSqlCommand.Parameters.Add("@clientname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@clientname"].Value = clientname;

                objSqlCommand.Parameters.Add("@adtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adtype"].Value = adtype;

                objSqlCommand.Parameters.Add("@remarks", SqlDbType.VarChar);
                objSqlCommand.Parameters["@remarks"].Value = remarks;

                objSqlCommand.Parameters.Add("@executive_var", SqlDbType.VarChar);
                objSqlCommand.Parameters["@executive_var"].Value = executive_var;

                objSqlCommand.Parameters.Add("@retainer_var", SqlDbType.VarChar);
                objSqlCommand.Parameters["@retainer_var"].Value = retainer_var;

                objSqlCommand.Parameters.Add("@contdate_var", SqlDbType.VarChar);
                if (contdate_var == "")
                    objSqlCommand.Parameters["@contdate_var"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@contdate_var"].Value = contdate_var;

                objSqlCommand.Parameters.Add("@closedate_var", SqlDbType.VarChar);
                if (closedate_var == "")
                    objSqlCommand.Parameters["@closedate_var"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@closedate_var"].Value = closedate_var;

                objSqlCommand.Parameters.Add("@servicetax_var", SqlDbType.VarChar);
                objSqlCommand.Parameters["@servicetax_var"].Value = servicetax_var;

                objSqlCommand.Parameters.Add("@caption_var", SqlDbType.VarChar);
                objSqlCommand.Parameters["@caption_var"].Value = caption_var;

                objSqlCommand.Parameters.Add("@paymode_var", SqlDbType.VarChar);
                objSqlCommand.Parameters["@paymode_var"].Value = paymode_var;

                objSqlCommand.Parameters.Add("@b2b_var", SqlDbType.VarChar);
                objSqlCommand.Parameters["@b2b_var"].Value = b2b;

                objSqlCommand.Parameters.Add("@chkmulti_var", SqlDbType.VarChar);
                objSqlCommand.Parameters["@chkmulti_var"].Value = chkmulti;

                objSqlCommand.Parameters.Add("@chkseq_var", SqlDbType.VarChar);
                objSqlCommand.Parameters["@chkseq_var"].Value = chkseq;

                objSqlCommand.Parameters.Add("@seqno_var", SqlDbType.VarChar);
                objSqlCommand.Parameters["@seqno_var"].Value = seqno;

                objSqlCommand.Parameters.Add("@chkparti_var", SqlDbType.VarChar);
                objSqlCommand.Parameters["@chkparti_var"].Value = chkparti;

                objSqlCommand.Parameters.Add("@indus_var", SqlDbType.VarChar);
                objSqlCommand.Parameters["@indus_var"].Value = indus;

                objSqlCommand.Parameters.Add("@induspro_var", SqlDbType.VarChar);
                objSqlCommand.Parameters["@induspro_var"].Value = induspro;

                objSqlCommand.Parameters.Add("@dealon_var", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dealon_var"].Value = dealon;

                objSqlCommand.Parameters.Add("@attachment1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@attachment1"].Value = attach1;

                objSqlCommand.Parameters.Add("@dealcenter", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dealcenter"].Value = printcenter;

                objSqlCommand.Parameters.Add("@dealfrom", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dealfrom"].Value = centername;

                objSqlCommand.Parameters.Add("@translation", SqlDbType.VarChar);
                objSqlCommand.Parameters["@translation"].Value = transition;

                objSqlCommand.Parameters.Add("@rono_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rono_p"].Value = rono;

                objSqlCommand.Parameters.Add("@rodate_p", SqlDbType.VarChar);
                if (rodate == null || rodate == "")
                {
                    objSqlCommand.Parameters["@rodate_p"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@rodate_p"].Value = Convert.ToDateTime(rodate);
                }


                objSqlCommand.Parameters.Add("@rostatus_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rostatus_p"].Value = rostatus;

                objSqlCommand.Parameters.Add("@rcptno_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rcptno_p"].Value = rcptno;

                objSqlCommand.Parameters.Add("@rcptcurr_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rcptcurr_p"].Value = rcptcurr;


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

        public DataSet dealmodifychk(string dealno, string deal_name, string compcode, string deal_type)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("dealmodifychk", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@dealno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dealno"].Value = dealno;

                objSqlCommand.Parameters.Add("@dealname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dealname"].Value = deal_name;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@dealtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dealtype"].Value = deal_type;

                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);

                return objDataSet;


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

        public DataSet dealchk(string Deal_No, string deal_name, string dn)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("dealchkforcontract", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@dealno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dealno"].Value = Deal_No;

                objSqlCommand.Parameters.Add("@dealname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dealname"].Value = deal_name;

                objSqlCommand.Parameters.Add("@dn", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dn"].Value = dn;


                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);

                return objDataSet;


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


        public DataSet dealautocode(string dealname)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("dealautocode", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@dealname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dealname"].Value = dealname;

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

        public DataSet querycontract(string DealNo, string dealname, string agencycode, string subagencycode, string clientname, string product, string representative, string compcode, string userid, string dealtype, string quotation)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("executecontract", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@dealname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dealname"].Value = dealname;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@DealNo", SqlDbType.VarChar);
                objSqlCommand.Parameters["@DealNo"].Value = DealNo;

                objSqlCommand.Parameters.Add("@dealtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dealtype"].Value = dealtype;

                objSqlCommand.Parameters.Add("@agencycode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencycode"].Value = agencycode;

                objSqlCommand.Parameters.Add("@subagencycode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@subagencycode"].Value = subagencycode;


                objSqlCommand.Parameters.Add("@representative", SqlDbType.VarChar);
                objSqlCommand.Parameters["@representative"].Value = representative;

                objSqlCommand.Parameters.Add("@quotion_p", SqlDbType.VarChar);
                if (quotation == "" || quotation == "N")
                    objSqlCommand.Parameters["@quotion_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@quotion_p"].Value = quotation;

                objSqlCommand.Parameters.Add("@clientname_p", SqlDbType.VarChar);
                if (clientname == "" || clientname == "N")
                    objSqlCommand.Parameters["@clientname_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@clientname_p"].Value = clientname;




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

        public DataSet firstresult(string compcode, string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("firstcontract", ref objSqlConnection);
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

        public DataSet bindadvcategory(string compcode, string adtype)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("bindcatforcontract", ref objSqlConnection);
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

        public DataSet publication(string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("bindpublication", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                //objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@userid"].Value = userid;



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

        public DataSet supplimentbind(string compcode, string editioncode)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("bindsuppliment", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                //objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@editioncode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@editioncode"].Value = editioncode;



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

        public DataSet editionbind(string compcode, string pubcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("bindedition", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

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

        public DataSet citybind(string compcode, string userid)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("bindcity", ref objSqlConnection);
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

        public DataSet packagebind(string compcode, string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("bindpackageActive", ref objSqlConnection);
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

        //// bhati================================================================================================================
        public DataSet clspackagestatus(string compcode, string userid, string ad_type, string pkgcode, string pkgstatus)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_savepkgstatus", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@ad_type", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ad_type"].Value = ad_type;

                objSqlCommand.Parameters.Add("@pkgcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pkgcode"].Value = pkgcode;

                objSqlCommand.Parameters.Add("@pkgstatus", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pkgstatus"].Value = pkgstatus;

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

        public DataSet clsmodifypackagestatus(string compcode, string ad_type, string pkgcode, string pkgstatus, string recordid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_modifypkgstatus", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@ad_type", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ad_type"].Value = ad_type;

                objSqlCommand.Parameters.Add("@pkgcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pkgcode"].Value = pkgcode;

                objSqlCommand.Parameters.Add("@pkgstatus", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pkgstatus"].Value = pkgstatus;

                objSqlCommand.Parameters.Add("@recordid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@recordid"].Value = recordid;

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


        public DataSet clsdeletepackagestatus(string compcode, string ad_type, string pkgcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_deletepkgstatus", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@ad_type", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ad_type"].Value = ad_type;

                objSqlCommand.Parameters.Add("@pkgcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pkgcode"].Value = pkgcode;

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

        public DataSet clsexistpackagestatus(string compcode, string ad_type, string pkgcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_existpkgstatus", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@ad_type", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ad_type"].Value = ad_type;

                objSqlCommand.Parameters.Add("@pkgcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pkgcode"].Value = pkgcode;

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

        public DataSet clsbindEntry(string compcode, string ad_type, string pkgcode, string pkgstatus)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_bindEntry", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@ad_type", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ad_type"].Value = ad_type;

                objSqlCommand.Parameters.Add("@pkgcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pkgcode"].Value = pkgcode;

                objSqlCommand.Parameters.Add("@pkgstatus", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pkgstatus"].Value = pkgstatus;

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


        /////================================================================================================================================///
        public DataSet packagebindActive(string compcode, string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("bindpackageActive", ref objSqlConnection);
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
        public DataSet colorbind(string compcode, string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("bindcolor", ref objSqlConnection);
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

        public DataSet premiumbind(string compcode, string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("bindpremium", ref objSqlConnection);
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

        public DataSet uombind(string compcode, string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("binduom", ref objSqlConnection);
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

        public DataSet bindgrid(string compcode, string userid, string dealno, string value)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                //objSqlCommand = GetCommand("bindgridforcontract", ref objSqlConnection);
                objSqlCommand = GetCommand("bindgridforcontract_lata", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@dealno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dealno"].Value = dealno;

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

        public void insertdetail(string dealno, string advcat, string publication, string suppli, string edition, string bookedfor, string color, string cardrate, string dealrate, string premium, string cardprem, string dealprem, string volbilled, string voldisc, string valfrom, string valto, string uom, string package, string compcode, string userid, string totalrate, string currency, string ratecode, string flag, string quantity, string weight, string free, string cyoppac, string deviation, string remarks, string sizefrom, string sizeto, string disctype, string discper, string insertion, string dayname, string comm_allow, string deal_start, string incentive)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("insertvaluecontract", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@cyoppac", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cyoppac"].Value = cyoppac;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@dealno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dealno"].Value = dealno;

                objSqlCommand.Parameters.Add("@currency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@currency"].Value = currency;


                objSqlCommand.Parameters.Add("@advcat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@advcat"].Value = advcat;

                objSqlCommand.Parameters.Add("@publication", SqlDbType.VarChar);
                objSqlCommand.Parameters["@publication"].Value = publication;

                objSqlCommand.Parameters.Add("@suppli", SqlDbType.VarChar);
                objSqlCommand.Parameters["@suppli"].Value = suppli;

                objSqlCommand.Parameters.Add("@edition", SqlDbType.VarChar);
                objSqlCommand.Parameters["@edition"].Value = edition;

                objSqlCommand.Parameters.Add("@bookedfor", SqlDbType.VarChar);
                objSqlCommand.Parameters["@bookedfor"].Value = bookedfor;

                objSqlCommand.Parameters.Add("@color", SqlDbType.VarChar);
                objSqlCommand.Parameters["@color"].Value = color;

                objSqlCommand.Parameters.Add("@cardrate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cardrate"].Value = cardrate;

                objSqlCommand.Parameters.Add("@dealrate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dealrate"].Value = dealrate;

                objSqlCommand.Parameters.Add("@dealprem", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dealprem"].Value = dealprem;

                objSqlCommand.Parameters.Add("@premium", SqlDbType.VarChar);
                objSqlCommand.Parameters["@premium"].Value = premium;

                objSqlCommand.Parameters.Add("@volbilled", SqlDbType.VarChar);
                objSqlCommand.Parameters["@volbilled"].Value = volbilled;

                objSqlCommand.Parameters.Add("@cardprem", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cardprem"].Value = cardprem;

                objSqlCommand.Parameters.Add("@voldisc", SqlDbType.VarChar);
                objSqlCommand.Parameters["@voldisc"].Value = voldisc;

                objSqlCommand.Parameters.Add("@valfrom", SqlDbType.VarChar);
                objSqlCommand.Parameters["@valfrom"].Value = valfrom;

                objSqlCommand.Parameters.Add("@valto", SqlDbType.VarChar);
                objSqlCommand.Parameters["@valto"].Value = valto;

                objSqlCommand.Parameters.Add("@uom", SqlDbType.VarChar);
                objSqlCommand.Parameters["@uom"].Value = uom;

                objSqlCommand.Parameters.Add("@package", SqlDbType.VarChar);
                objSqlCommand.Parameters["@package"].Value = package;

                objSqlCommand.Parameters.Add("@totalrate", SqlDbType.Int);
                if (totalrate == "")
                {
                    objSqlCommand.Parameters["@totalrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@totalrate"].Value = Convert.ToInt32(totalrate);
                }


                objSqlCommand.Parameters.Add("@quantity", SqlDbType.Int);
                if (quantity == "")
                {
                    objSqlCommand.Parameters["@quantity"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@quantity"].Value = Convert.ToInt32(quantity);
                }

                objSqlCommand.Parameters.Add("@weight", SqlDbType.Int);
                if (weight == "")
                {
                    objSqlCommand.Parameters["@weight"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@weight"].Value = Convert.ToInt32(weight);
                }

                objSqlCommand.Parameters.Add("@flag", SqlDbType.VarChar);
                objSqlCommand.Parameters["@flag"].Value = flag;

                objSqlCommand.Parameters.Add("@ratecode", SqlDbType.VarChar);

                objSqlCommand.Parameters["@ratecode"].Value = ratecode;


                objSqlCommand.Parameters.Add("@deviation", SqlDbType.Int);
                if (deviation == "")
                {
                    objSqlCommand.Parameters["@deviation"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@deviation"].Value = Convert.ToInt32(deviation);
                }

                objSqlCommand.Parameters.Add("@free", SqlDbType.VarChar);
                objSqlCommand.Parameters["@free"].Value = free;

                objSqlCommand.Parameters.Add("@REMARK", SqlDbType.VarChar);
                objSqlCommand.Parameters["@REMARK"].Value = remarks;

                objSqlCommand.Parameters.Add("@SIZEFROM", SqlDbType.VarChar);
                objSqlCommand.Parameters["@SIZEFROM"].Value = sizefrom;

                objSqlCommand.Parameters.Add("@SIZETO", SqlDbType.VarChar);
                objSqlCommand.Parameters["@SIZETO"].Value = sizeto;

                objSqlCommand.Parameters.Add("@DISCTYPE", SqlDbType.VarChar);
                objSqlCommand.Parameters["@DISCTYPE"].Value = disctype;

                objSqlCommand.Parameters.Add("@DISCPER", SqlDbType.VarChar);
                objSqlCommand.Parameters["@DISCPER"].Value = discper;

                objSqlCommand.Parameters.Add("@INSERTION", SqlDbType.VarChar);
                objSqlCommand.Parameters["@INSERTION"].Value = insertion;

                objSqlCommand.Parameters.Add("@DAYNAME", SqlDbType.VarChar);
                objSqlCommand.Parameters["@DAYNAME"].Value = dayname;

                objSqlCommand.Parameters.Add("@comm_allow", SqlDbType.VarChar);
                objSqlCommand.Parameters["@comm_allow"].Value = comm_allow;

                objSqlCommand.Parameters.Add("@deal_start", SqlDbType.VarChar);
                objSqlCommand.Parameters["@deal_start"].Value = deal_start;

                objSqlCommand.Parameters.Add("@incentive", SqlDbType.Decimal);
                if (incentive == "" || incentive == null)
                    objSqlCommand.Parameters["@incentive"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@incentive"].Value = Convert.ToDecimal(incentive);

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

        public DataSet getfromcontractdetail(string compcode, string userid, string formcode, string dealcode)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getvalueofcontractdetail", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@formcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@formcode"].Value = formcode;

                objSqlCommand.Parameters.Add("@dealcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dealcode"].Value = dealcode;


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



        public DataSet updatedetail(string dealno, string advcat, string publication, string suppli, string edition, string bookedfor, string color, string cardrate, string dealrate, string premium, string cardprem, string dealprem, string volbilled, string voldisc, string valfrom, string valto, string uom, string package, string compcode, string userid, string dealvalue, string totalrate, string currency, string editdisc, string flag, string quantity, string weight, string free, string cyoppac, string deviation, string remarks, string sizefrom, string sizeto, string disctype, string discper, string insertion, string dayname, string comm_allow, string deal_start, string incentive)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("updatevalueforcontract", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@cyoppac", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cyoppac"].Value = cyoppac;


                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@free", SqlDbType.VarChar);
                objSqlCommand.Parameters["@free"].Value = free;

                objSqlCommand.Parameters.Add("@dealno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dealno"].Value = dealno;

                objSqlCommand.Parameters.Add("@currency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@currency"].Value = currency;


                objSqlCommand.Parameters.Add("@advcat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@advcat"].Value = advcat;

                objSqlCommand.Parameters.Add("@publication", SqlDbType.VarChar);
                objSqlCommand.Parameters["@publication"].Value = publication;

                objSqlCommand.Parameters.Add("@suppli", SqlDbType.VarChar);
                objSqlCommand.Parameters["@suppli"].Value = suppli;

                objSqlCommand.Parameters.Add("@edition", SqlDbType.VarChar);
                objSqlCommand.Parameters["@edition"].Value = edition;

                objSqlCommand.Parameters.Add("@bookedfor", SqlDbType.VarChar);
                objSqlCommand.Parameters["@bookedfor"].Value = bookedfor;

                objSqlCommand.Parameters.Add("@color", SqlDbType.VarChar);
                objSqlCommand.Parameters["@color"].Value = color;

                objSqlCommand.Parameters.Add("@cardrate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cardrate"].Value = cardrate;

                objSqlCommand.Parameters.Add("@dealrate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dealrate"].Value = dealrate;

                objSqlCommand.Parameters.Add("@dealprem", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dealprem"].Value = dealprem;

                objSqlCommand.Parameters.Add("@premium", SqlDbType.VarChar);
                objSqlCommand.Parameters["@premium"].Value = premium;

                objSqlCommand.Parameters.Add("@volbilled", SqlDbType.VarChar);
                objSqlCommand.Parameters["@volbilled"].Value = volbilled;

                objSqlCommand.Parameters.Add("@cardprem", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cardprem"].Value = cardprem;

                objSqlCommand.Parameters.Add("@voldisc", SqlDbType.VarChar);
                objSqlCommand.Parameters["@voldisc"].Value = voldisc;

                objSqlCommand.Parameters.Add("@valfrom", SqlDbType.VarChar);
                objSqlCommand.Parameters["@valfrom"].Value = valfrom;

                objSqlCommand.Parameters.Add("@valto", SqlDbType.VarChar);
                objSqlCommand.Parameters["@valto"].Value = valto;

                objSqlCommand.Parameters.Add("@uom", SqlDbType.VarChar);
                objSqlCommand.Parameters["@uom"].Value = uom;

                objSqlCommand.Parameters.Add("@package", SqlDbType.VarChar);
                objSqlCommand.Parameters["@package"].Value = package;

                objSqlCommand.Parameters.Add("@dealvalue", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dealvalue"].Value = dealvalue;

                objSqlCommand.Parameters.Add("@totalrate", SqlDbType.Int);
                if (totalrate == "" || totalrate == "null")
                {
                    objSqlCommand.Parameters["@totalrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@totalrate"].Value = Convert.ToInt32(totalrate);
                }

                objSqlCommand.Parameters.Add("@flag", SqlDbType.VarChar);
                objSqlCommand.Parameters["@flag"].Value = flag;

                objSqlCommand.Parameters.Add("@editdisc", SqlDbType.VarChar);

                objSqlCommand.Parameters["@editdisc"].Value = editdisc;


                objSqlCommand.Parameters.Add("@quantity", SqlDbType.Int);
                if (quantity == "" || quantity == "null")
                {
                    objSqlCommand.Parameters["@quantity"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@quantity"].Value = Convert.ToInt32(quantity);
                }

                objSqlCommand.Parameters.Add("@weight", SqlDbType.Int);
                if (weight == "" || weight == "null")
                {
                    objSqlCommand.Parameters["@weight"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@weight"].Value = Convert.ToInt32(weight);
                }

                objSqlCommand.Parameters.Add("@deviation", SqlDbType.Int);
                if (deviation == "" || deviation == "null")
                {
                    objSqlCommand.Parameters["@deviation"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@deviation"].Value = Convert.ToInt32(deviation);
                }


                objSqlCommand.Parameters.Add("@remark1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@remark1"].Value = remarks;

                objSqlCommand.Parameters.Add("@sizefrom1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@sizefrom1"].Value = sizefrom;

                objSqlCommand.Parameters.Add("@sizeto1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@sizeto1"].Value = sizeto;

                objSqlCommand.Parameters.Add("@discper1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@discper1"].Value = discper;

                objSqlCommand.Parameters.Add("@disctype1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@disctype1"].Value = disctype;

                objSqlCommand.Parameters.Add("@insertion1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@insertion1"].Value = insertion;

                objSqlCommand.Parameters.Add("@dayname1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dayname1"].Value = dayname;

                objSqlCommand.Parameters.Add("@comm_allow", SqlDbType.VarChar);
                objSqlCommand.Parameters["@comm_allow"].Value = comm_allow;

                objSqlCommand.Parameters.Add("@deal_start", SqlDbType.VarChar);
                objSqlCommand.Parameters["@deal_start"].Value = deal_start;

                objSqlCommand.Parameters.Add("@incentive", SqlDbType.Decimal);
                if (incentive == "" || incentive == null)
                {
                    objSqlCommand.Parameters["@incentive"].Value = System.DBNull.Value;
                }
                objSqlCommand.Parameters["@incentive"].Value = Convert.ToDecimal(incentive);

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

        public object deletecontractdetail(string compcode, string userid, string dealvalue)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("deletecontractdetail", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@dealvalue", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dealvalue"].Value = dealvalue;




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



        public object deletecontractdeta(string compcode, string userid, string dealvalue)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("deletecontractdetail", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@dealvalue", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dealvalue"].Value = dealvalue;




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

        public DataSet contractdelete(string compcode, string userid, string dealvalue)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("deletecontractdetail", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@dealvalue", SqlDbType.Int);
                objSqlCommand.Parameters["@dealvalue"].Value = Convert.ToInt32(dealvalue);




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

        public DataSet autogenrated(string compcode, string userid, string deal)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("autogeneratedeal", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@deal", SqlDbType.VarChar);
                objSqlCommand.Parameters["@deal"].Value = deal;






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


        public DataSet chkincontractdetail(string DealNo, string compcode, string userid)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("checkcontractdetail", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@DealNo", SqlDbType.VarChar);
                objSqlCommand.Parameters["@DealNo"].Value = DealNo;






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

        public DataSet currencybind(string compcode, string userid)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("bindcurrency", ref objSqlConnection);
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

        public DataSet description(string packagecode, string compcode, string userid)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("binddescriptionforcontrcat", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

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

        public DataSet convertrate(string currcode, string compcode, string userid)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getconverrate", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@currcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@currcode"].Value = currcode;







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

        public DataSet discvalue(string discount, string compcode, string userid, string username)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getdiscount", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@discount", SqlDbType.VarChar);
                objSqlCommand.Parameters["@discount"].Value = discount;

                objSqlCommand.Parameters.Add("@username", SqlDbType.VarChar);
                objSqlCommand.Parameters["@username"].Value = username;








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

        public DataSet bindexec(string compcode, string userid, string name)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("bindexec", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@name", SqlDbType.VarChar);
                objSqlCommand.Parameters["@name"].Value = name;






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

        public DataSet currbind(string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("currbind", ref objSqlConnection);
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

        public DataSet currencychecked(string dealcode, string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("currencydeal", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@dealcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dealcode"].Value = dealcode;



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

        public DataSet deletecontractdeta(string code, string compcode)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("deletecontract", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@code"].Value = code;






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


        public DataSet bindname(string compcode)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("bindteamname", ref objSqlConnection);
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
        public DataSet binddealNo(string compcode, string dealno, string mod)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("tv_binddealforaudit", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@deal", SqlDbType.VarChar);
                objSqlCommand.Parameters["@deal"].Value = dealno;

                objSqlCommand.Parameters.Add("@mod", SqlDbType.VarChar);
                objSqlCommand.Parameters["@mod"].Value = mod;

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
        public DataSet binddeal(string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("binddealtype", ref objSqlConnection);
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


        public DataSet packagechk(string package, string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("packagechkcontract", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@package", SqlDbType.VarChar);
                objSqlCommand.Parameters["@package"].Value = package;




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

        public DataSet chkweight(string weight, string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("chkweight", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@weight", SqlDbType.VarChar);
                objSqlCommand.Parameters["@weight"].Value = weight;




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

        public DataSet getrateforcontract(string adcat, string pkgcode, string color, string currency, string uom, string advtype, string datefrom, string dateto, string compcode, string dateformat, string premium)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("contr_getpkgrate", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@adcat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adcat"].Value = adcat;

                objSqlCommand.Parameters.Add("@pkgcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pkgcode"].Value = pkgcode;

                objSqlCommand.Parameters.Add("@color", SqlDbType.VarChar);
                objSqlCommand.Parameters["@color"].Value = color;

                objSqlCommand.Parameters.Add("@currency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@currency"].Value = currency;

                objSqlCommand.Parameters.Add("@uom", SqlDbType.VarChar);
                objSqlCommand.Parameters["@uom"].Value = uom;

                objSqlCommand.Parameters.Add("@advtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@advtype"].Value = advtype;

                objSqlCommand.Parameters.Add("@datefrom", SqlDbType.VarChar);
                if (datefrom != "")
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = datefrom.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        datefrom = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = datefrom.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        datefrom = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@datefrom"].Value = datefrom;
                }
                else
                {
                    objSqlCommand.Parameters["@datefrom"].Value = System.DBNull.Value;
                }

                objSqlCommand.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (dateto != "")
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = dateto.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        dateto = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = dateto.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        datefrom = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@dateto"].Value = dateto;
                }
                else
                {
                    objSqlCommand.Parameters["@dateto"].Value = System.DBNull.Value;
                }


                objSqlCommand.Parameters.Add("@premium", SqlDbType.VarChar);
                if (premium == "" || premium == null)
                {
                    objSqlCommand.Parameters["@premium"].Value = "0";
                }
                else
                {
                    objSqlCommand.Parameters["@premium"].Value = premium;
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
        public DataSet chkunique(string agency, string client, string prod, string compcode, string adtype, string mod)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("chkuniquecontractmaster", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@agency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agency"].Value = agency;

                objSqlCommand.Parameters.Add("@client", SqlDbType.VarChar);
                objSqlCommand.Parameters["@client"].Value = client;

                objSqlCommand.Parameters.Add("@prod", SqlDbType.VarChar);
                objSqlCommand.Parameters["@prod"].Value = prod;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@mod", SqlDbType.VarChar);
                objSqlCommand.Parameters["@mod"].Value = mod;

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

        public DataSet chkuniquedetail(string adcat, string pkgcode, string ratecode, string color, string compcode, string mod, string day1)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("chkuniquecontractdetail", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@adcat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adcat"].Value = adcat;

                objSqlCommand.Parameters.Add("@pkgcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pkgcode"].Value = pkgcode;

                objSqlCommand.Parameters.Add("@ratecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ratecode"].Value = ratecode;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@color", SqlDbType.VarChar);
                objSqlCommand.Parameters["@color"].Value = color;

                objSqlCommand.Parameters.Add("@mod", SqlDbType.VarChar);
                objSqlCommand.Parameters["@mod"].Value = mod;

                objSqlCommand.Parameters.Add("@day1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@day1"].Value = day1;

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

        public DataSet packagebind1(string compcode, string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("bindpackageActive1", ref objSqlConnection);
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






        public DataSet modchek(string compcode, string dealno)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("cheackdeal", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@dealno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dealno"].Value = dealno;

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


        public DataSet getcontract(string compcode, string contaract)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("BINDDEALforf2", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@p_compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@p_dealname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_dealname"].Value = contaract;

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

        public DataSet pagepremiumbind(string compcode, string prem)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("bindadvposition", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("@p_compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@p_name", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_name"].Value = prem;


                objSqlCommand.Parameters.Add("@extra1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@extra1"].Value = "";

                objSqlCommand.Parameters.Add("@extra2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@extra2"].Value = "";

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



        public DataSet getposprem(string compcode, string Premcode)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("bind_pos_amount", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@Poscode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Poscode"].Value = Premcode;






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


        public DataSet getmailheader(string compcode, string userid, string dealno)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("mailrateheader", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcompcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@puserid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@puserid"].Value = userid;

                objSqlCommand.Parameters.Add("@pdeal_no", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdeal_no"].Value = dealno;

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
        public DataSet getmaildetail(string compcode, string userid, string dealno)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("maildeal", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcompcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@puserid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@puserid"].Value = userid;

                objSqlCommand.Parameters.Add("@pdeal_no", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdeal_no"].Value = dealno;

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

        public DataSet inserteditname(string txteditionname, string txtdate, string txtaddate, string compcode, string userid, string editcode, string year)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("dealmarketshare", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcompcode"].Value = txteditionname;

                objSqlCommand.Parameters.Add("@pdaelno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdaelno"].Value = txtdate;

                objSqlCommand.Parameters.Add("@ppublication", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ppublication"].Value = txtaddate;

                objSqlCommand.Parameters.Add("@ppubcent", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ppubcent"].Value = compcode;

                objSqlCommand.Parameters.Add("@pmarkertshare", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pmarkertshare"].Value = userid;


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

        public DataSet binddealmarshare(string compcode, string edtioncode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("bind_dealmarshare", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcompcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@pdealno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdealno"].Value = edtioncode;




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

        public DataSet dealshare(string code, string compcode, string userid)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("binddealmarshare.binddealmarshare_p", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;


                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;


                objSqlCommand.Parameters.Add("@code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@code"].Value = code;


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

        public DataSet chkdaetdeal(string compcode, string editcode)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("chkdatdeal.chkdatdeal_p", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;


                objSqlCommand.Parameters.Add("@editcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@editcode"].Value = editcode;


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

        public DataSet selectedfromgrid(string editcode, string compcode, string userid, string code10)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("selectfromeditDEAL.selectfromeditDEAL_p", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;


                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@editcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@editcode"].Value = editcode;

                objSqlCommand.Parameters.Add("@code10", SqlDbType.VarChar);
                objSqlCommand.Parameters["@code10"].Value = code10;


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

        public DataSet publication(string compcode, string pubcent)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("publication", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcompcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@ppubcentcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ppubcentcode"].Value = pubcent;


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

        public DataSet pub_centbind(string compcode, string useid, string chk_acc)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("bind_pubcentname_new", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@p_comp_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_comp_code"].Value = compcode;


                objSqlCommand.Parameters.Add("@p_userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_userid"].Value = useid;

                objSqlCommand.Parameters.Add("@p_extra1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_extra1"].Value = chk_acc;

                objSqlCommand.Parameters.Add("@p_extra2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_extra2"].Value = System.DBNull.Value;


                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);

                return objDataSet;


            }
            catch (SqlException objException)
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

        public DataSet griddelete(string editcode, string compcode, string userid, string code10)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("deletegriddealmarket.deletegriddealmarket_p", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = editcode;

                objSqlCommand.Parameters.Add("@editcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@editcode"].Value = System.DBNull.Value;

                objSqlCommand.Parameters.Add("@code10", SqlDbType.VarChar);
                objSqlCommand.Parameters["@code10"].Value = System.DBNull.Value;


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

        public DataSet gridupdate(string txteditionname, string txtdate, string txtaddate, string compcode, string editcode)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("UpdateDEALMARKET.UpdateDEALMARKET_p", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;


                objSqlCommand.Parameters.Add("@txteditionname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@txteditionname"].Value = txteditionname;

                objSqlCommand.Parameters.Add("@txtdate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@txtdate"].Value = txtdate;

                objSqlCommand.Parameters.Add("@txtaddate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@txtaddate"].Value = txtaddate;


                objSqlCommand.Parameters.Add("@editcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@editcode"].Value = editcode;


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