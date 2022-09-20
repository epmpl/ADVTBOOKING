using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OracleClient;
namespace NewAdbooking.classesoracle
{
    /// <summary>
    /// Summary description for Contract
    /// </summary>
    public class Contract : orclconnection
    {
        public Contract()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataSet tv_paid_balance_cal(string pcomp_code, string punit_code, string pchannel, string plocation_code, string pad_type, string pdealno, string pbtb_code, string ppaid_bonus)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("tv_paid_balance_cal", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1a = new OracleParameter("pcomp_code", OracleType.VarChar, 50);
                prm1a.Direction = ParameterDirection.Input;
                prm1a.Value = pcomp_code;
                objOraclecommand.Parameters.Add(prm1a);

                OracleParameter prm1 = new OracleParameter("punit_code", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                if (punit_code == "")
                    prm1.Value = System.DBNull.Value;
                else
                    prm1.Value = punit_code;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm1b = new OracleParameter("pchannel", OracleType.VarChar, 50);
                prm1b.Direction = ParameterDirection.Input;
                if (pchannel == "")
                    prm1b.Value = System.DBNull.Value;
                else
                    prm1b.Value = pchannel;
                objOraclecommand.Parameters.Add(prm1b);


                OracleParameter prm1c = new OracleParameter("plocation_code", OracleType.VarChar, 50);
                prm1c.Direction = ParameterDirection.Input;
                if (plocation_code == "")
                    prm1c.Value = System.DBNull.Value;
                else
                    prm1c.Value = plocation_code;
                objOraclecommand.Parameters.Add(prm1c);


                OracleParameter prm1d = new OracleParameter("pad_type", OracleType.VarChar, 50);
                prm1d.Direction = ParameterDirection.Input;
                if (pad_type == "")
                    prm1d.Value = System.DBNull.Value;
                else
                    prm1d.Value = pad_type;
                objOraclecommand.Parameters.Add(prm1d);


                OracleParameter prm1e = new OracleParameter("pdealno", OracleType.VarChar, 50);
                prm1e.Direction = ParameterDirection.Input;
                if (pdealno == "")
                    prm1e.Value = System.DBNull.Value;
                else
                    prm1e.Value = pdealno;
                objOraclecommand.Parameters.Add(prm1e);


                OracleParameter prm1f = new OracleParameter("pbtb_code", OracleType.VarChar, 50);
                prm1f.Direction = ParameterDirection.Input;
                if (pbtb_code == "")
                    prm1f.Value = System.DBNull.Value;
                else
                    prm1f.Value = pbtb_code;
                objOraclecommand.Parameters.Add(prm1f);

                OracleParameter prm1g = new OracleParameter("ppaid_bonus", OracleType.VarChar, 50);
                prm1g.Direction = ParameterDirection.Input;
                if (ppaid_bonus == "")
                    prm1g.Value = System.DBNull.Value;
                else
                    prm1g.Value = ppaid_bonus;
                objOraclecommand.Parameters.Add(prm1g);

                OracleParameter prm1h = new OracleParameter("pratetype", OracleType.VarChar, 50);
                prm1h.Direction = ParameterDirection.Input;
                //if (ppaid_bonus == "")
                //    prm1g.Value = System.DBNull.Value;
                //else
                    prm1h.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm1h);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;



                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }
        }
        public DataSet ratebind(string compcode, string adtype)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("BINDRATECODE_TV", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1a = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1a.Direction = ParameterDirection.Input;
                prm1a.Value = compcode;
                objOraclecommand.Parameters.Add(prm1a);

                OracleParameter prm1 = new OracleParameter("adtype", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                if (adtype == "")
                    prm1.Value = System.DBNull.Value;
                else
                    prm1.Value = adtype;
                objOraclecommand.Parameters.Add(prm1);


                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;



                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }
        }
        public DataSet getrateforcontract_Elec(string compcode_p, string unit_p, string channel_p, string location_p, string adtype_p, string ratetype, string day_p, string category_p, string btb_p, string fct_p, string validfrom_p, string validto_p, string package_p, string valufrom_p, string valueto_p, string disctype_p, string disper, string premium, string cardprem_p, string contprem_p, string minsize_p, string maxsize_p, string progtype_p, string progname_p, string commallow_p, string ratecode_p, string source_p, string dateformat, string currency_p, string contractrate_p, string agencycode_p, string subagencycode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("tv_getcardrate", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode_p", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode_p;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("unit_p", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                if (unit_p == "")
                    prm2.Value = System.DBNull.Value;
                else
                    prm2.Value = unit_p;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("channel_p", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                if (channel_p == "")
                    prm3.Value = System.DBNull.Value;
                else
                    prm3.Value = channel_p;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("location_p", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                if (location_p == "")
                    prm4.Value = System.DBNull.Value;
                else
                    prm4.Value = location_p;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("adtype_p", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                if (adtype_p == "")
                    prm5.Value = System.DBNull.Value;
                else
                    prm5.Value = adtype_p;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("ratetype", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                if (ratetype == "")
                    prm6.Value = System.DBNull.Value;
                else
                    prm6.Value = ratetype;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm71 = new OracleParameter("day_p", OracleType.VarChar, 50);
                prm71.Direction = ParameterDirection.Input;
                if (day_p == "")
                    prm71.Value = System.DBNull.Value;
                else
                    prm71.Value = day_p;
                objOraclecommand.Parameters.Add(prm71);

                OracleParameter prm7 = new OracleParameter("category_p", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                if (category_p == "")
                    prm7.Value = System.DBNull.Value;
                else
                    prm7.Value = category_p;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm7a = new OracleParameter("btb_p", OracleType.VarChar, 50);
                prm7a.Direction = ParameterDirection.Input;
                if (btb_p == "")
                    prm7a.Value = System.DBNull.Value;
                else
                    prm7a.Value = btb_p;
                objOraclecommand.Parameters.Add(prm7a);

                OracleParameter prm7b = new OracleParameter("fct_p", OracleType.VarChar, 50);
                prm7b.Direction = ParameterDirection.Input;
                if (fct_p == "")
                    prm7b.Value = System.DBNull.Value;
                else
                    prm7b.Value = fct_p;
                objOraclecommand.Parameters.Add(prm7b);

                OracleParameter prm7c = new OracleParameter("validfrom_p", OracleType.VarChar, 50);
                prm7c.Direction = ParameterDirection.Input;
                if (validfrom_p == "")
                {
                    prm7c.Value = System.DBNull.Value;
                }
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

                    prm7c.Value = Convert.ToDateTime(validfrom_p).ToString("dd-MMMM-yyyy");
                }
                // prm7c.Value = validfrom_p;
                objOraclecommand.Parameters.Add(prm7c);

                OracleParameter prm7d = new OracleParameter("validto_p", OracleType.VarChar, 50);
                prm7d.Direction = ParameterDirection.Input;
                if (validto_p == "")
                {
                    prm7d.Value = System.DBNull.Value;
                }
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

                    prm7d.Value = Convert.ToDateTime(validto_p).ToString("dd-MMMM-yyyy");
                }

                objOraclecommand.Parameters.Add(prm7d);

                OracleParameter prm7e = new OracleParameter("package_p", OracleType.VarChar, 50);
                prm7e.Direction = ParameterDirection.Input;
                if (package_p == "")
                    prm7e.Value = System.DBNull.Value;
                else
                    prm7e.Value = package_p;
                objOraclecommand.Parameters.Add(prm7e);

                OracleParameter prm7f = new OracleParameter("valufrom_p", OracleType.VarChar, 50);
                prm7f.Direction = ParameterDirection.Input;
                if (valufrom_p == "")
                    prm7f.Value = System.DBNull.Value;
                else
                    prm7f.Value = valufrom_p;
                objOraclecommand.Parameters.Add(prm7f);

                OracleParameter prm7g = new OracleParameter("valueto_p", OracleType.VarChar, 50);
                prm7g.Direction = ParameterDirection.Input;
                if (valueto_p == "")
                    prm7g.Value = System.DBNull.Value;
                else
                    prm7g.Value = valueto_p;
                objOraclecommand.Parameters.Add(prm7g);

                OracleParameter prm7h = new OracleParameter("disctype_p", OracleType.VarChar, 50);
                prm7h.Direction = ParameterDirection.Input;
                if (disctype_p == "")
                    prm7h.Value = System.DBNull.Value;
                else
                    prm7h.Value = disctype_p;
                objOraclecommand.Parameters.Add(prm7h);

                OracleParameter prm7i = new OracleParameter("disper", OracleType.VarChar, 50);
                prm7i.Direction = ParameterDirection.Input;
                if (disper == "")
                    prm7i.Value = System.DBNull.Value;
                else
                    prm7i.Value = disper;
                objOraclecommand.Parameters.Add(prm7i);

                OracleParameter prm7j = new OracleParameter("premium", OracleType.VarChar, 50);
                prm7j.Direction = ParameterDirection.Input;
                if (premium == "")
                    prm7j.Value = System.DBNull.Value;
                else
                    prm7j.Value = premium;
                objOraclecommand.Parameters.Add(prm7j);

                OracleParameter prm7k = new OracleParameter("cardprem_p", OracleType.VarChar, 50);
                prm7k.Direction = ParameterDirection.Input;
                if (cardprem_p == "")
                    prm7k.Value = System.DBNull.Value;
                else
                    prm7k.Value = cardprem_p;
                objOraclecommand.Parameters.Add(prm7k);

                OracleParameter prm7l = new OracleParameter("contprem_p", OracleType.VarChar, 50);
                prm7l.Direction = ParameterDirection.Input;
                if (contprem_p == "")
                    prm7l.Value = System.DBNull.Value;
                else
                    prm7l.Value = contprem_p;
                objOraclecommand.Parameters.Add(prm7l);

                OracleParameter prm7m = new OracleParameter("minsize_p", OracleType.VarChar, 50);
                prm7m.Direction = ParameterDirection.Input;
                if (minsize_p == "")
                    prm7m.Value = System.DBNull.Value;
                else
                    prm7m.Value = minsize_p;
                objOraclecommand.Parameters.Add(prm7m);

                OracleParameter prm7n = new OracleParameter("maxsize_p", OracleType.VarChar, 50);
                prm7n.Direction = ParameterDirection.Input;
                if (maxsize_p == "")
                    prm7n.Value = System.DBNull.Value;
                else
                    prm7n.Value = maxsize_p;
                objOraclecommand.Parameters.Add(prm7n);

                OracleParameter prm7o = new OracleParameter("progtype_p", OracleType.VarChar, 50);
                prm7o.Direction = ParameterDirection.Input;
                if (progtype_p == "")
                    prm7o.Value = System.DBNull.Value;
                else
                    prm7o.Value = progtype_p;
                objOraclecommand.Parameters.Add(prm7o);

                OracleParameter prm7p = new OracleParameter("progname_p", OracleType.VarChar, 50);
                prm7p.Direction = ParameterDirection.Input;
                if (progname_p == "")
                    prm7p.Value = System.DBNull.Value;
                else
                    prm7p.Value = progname_p;
                objOraclecommand.Parameters.Add(prm7p);

                OracleParameter prm7q = new OracleParameter("commallow_p", OracleType.VarChar, 50);
                prm7q.Direction = ParameterDirection.Input;
                if (commallow_p == "")
                    prm7q.Value = System.DBNull.Value;
                else
                    prm7q.Value = commallow_p;
                objOraclecommand.Parameters.Add(prm7q);

                OracleParameter prm7r = new OracleParameter("ratecode_p", OracleType.VarChar, 50);
                prm7r.Direction = ParameterDirection.Input;
                if (ratecode_p == "")
                    prm7r.Value = System.DBNull.Value;
                else
                    prm7r.Value = ratecode_p;
                objOraclecommand.Parameters.Add(prm7r);

                OracleParameter prm7s = new OracleParameter("source_p", OracleType.VarChar, 50);
                prm7s.Direction = ParameterDirection.Input;
                if (source_p != "")
                    prm7s.Value = source_p;
                else
                    prm7s.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm7s);

                OracleParameter prm7sa = new OracleParameter("currency_p", OracleType.VarChar, 50);
                prm7sa.Direction = ParameterDirection.Input;
                if (currency_p != "")
                    prm7sa.Value = currency_p;
                else
                    prm7sa.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm7sa);


                OracleParameter prm7sa1 = new OracleParameter("p_pref_sec", OracleType.VarChar, 50);
                prm7sa1.Direction = ParameterDirection.Input;
                if (ConfigurationSettings.AppSettings["TV_SECONDS"] != null)
                    prm7sa1.Value = ConfigurationSettings.AppSettings["TV_SECONDS"].ToString();
                else
                    prm7sa1.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm7sa1);

                OracleParameter prm7sa2 = new OracleParameter("p_contract_rate", OracleType.VarChar, 50);
                prm7sa2.Direction = ParameterDirection.Input;
                if (contractrate_p != "")
                    prm7sa2.Value = contractrate_p;
                else
                    prm7sa2.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm7sa2);

                OracleParameter prm7sa3 = new OracleParameter("p_agency_code", OracleType.VarChar, 50);
                prm7sa3.Direction = ParameterDirection.Input;
                if (agencycode_p != "")
                    prm7sa3.Value = agencycode_p;
                else
                    prm7sa3.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm7sa3);

                OracleParameter prm7sa4 = new OracleParameter("p_agency_subcode", OracleType.VarChar, 50);
                prm7sa4.Direction = ParameterDirection.Input;
                if (subagencycode != "")
                    prm7sa4.Value = subagencycode;
                else
                    prm7sa4.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm7sa4);


                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }
        }
        public DataSet bindGridDetails_Contract(string compcode, string dealcode, string seqno)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("bindGridDetails_Contract", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1a = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1a.Direction = ParameterDirection.Input;
                prm1a.Value = compcode;
                objOraclecommand.Parameters.Add(prm1a);

                OracleParameter prm1 = new OracleParameter("dealcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = dealcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm1b = new OracleParameter("seqno_p", OracleType.VarChar, 50);
                prm1b.Direction = ParameterDirection.Input;
                if (seqno == "")
                    prm1b.Value = System.DBNull.Value;
                else
                    prm1b.Value = seqno;
                objOraclecommand.Parameters.Add(prm1b);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts1"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }
        }
        public void saveElecDetailsProc(string dealno, string channel, string location, string advtype, string paidbonus, string progname, string btb, string ros, string day, string fct, string package, string valuefrom, string valueto, string disctype, string discper, string premium, string contpremium, string contrate, string cardrate, string deviation, string cardprem, string minsize, string maxsize, string currency, string dealstart, string progtype, string category, string commallow, string remarks, string ratecode, string discon, string sponfrom, string sponto, string compcode, string userid, string username, string incentive, string approved, string unit, string seqno, string id, string ratetype, string dateformat, string source, string totalval,string sectioncode,string resourceno,string localtotvalue,string convrate,string slot)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            //  OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("savecontractelec_detail", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("dealno_p", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = dealno;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm1a = new OracleParameter("channel_p", OracleType.VarChar, 50);
                prm1a.Direction = ParameterDirection.Input;
                prm1a.Value = channel;
                objOraclecommand.Parameters.Add(prm1a);

                OracleParameter prm1b = new OracleParameter("location_p", OracleType.VarChar, 50);
                prm1b.Direction = ParameterDirection.Input;
                prm1b.Value = location;
                objOraclecommand.Parameters.Add(prm1b);

                OracleParameter prm1c = new OracleParameter("advtype_p", OracleType.VarChar, 50);
                prm1c.Direction = ParameterDirection.Input;
                prm1c.Value = advtype;
                objOraclecommand.Parameters.Add(prm1c);

                OracleParameter prm1d = new OracleParameter("paidbonus_p", OracleType.VarChar, 50);
                prm1d.Direction = ParameterDirection.Input;
                prm1d.Value = paidbonus;
                objOraclecommand.Parameters.Add(prm1d);

                OracleParameter prm1e = new OracleParameter("progname_p", OracleType.VarChar, 50);
                prm1e.Direction = ParameterDirection.Input;
                prm1e.Value = progname;
                objOraclecommand.Parameters.Add(prm1e);

                OracleParameter prm1f = new OracleParameter("btb_p", OracleType.VarChar, 50);
                prm1f.Direction = ParameterDirection.Input;
                prm1f.Value = btb;
                objOraclecommand.Parameters.Add(prm1f);

                OracleParameter prm1g = new OracleParameter("ros_p", OracleType.VarChar, 50);
                prm1g.Direction = ParameterDirection.Input;
                prm1g.Value = ros;
                objOraclecommand.Parameters.Add(prm1g);

                OracleParameter prm1h = new OracleParameter("day_p", OracleType.VarChar, 50);
                prm1h.Direction = ParameterDirection.Input;
                prm1h.Value = day;
                objOraclecommand.Parameters.Add(prm1h);

                OracleParameter prm1i = new OracleParameter("fct_p", OracleType.VarChar, 50);
                prm1i.Direction = ParameterDirection.Input;
                prm1i.Value = fct;
                objOraclecommand.Parameters.Add(prm1i);

                OracleParameter prm1j = new OracleParameter("package_p", OracleType.VarChar, 50);
                prm1j.Direction = ParameterDirection.Input;
                prm1j.Value = package;
                objOraclecommand.Parameters.Add(prm1j);

                OracleParameter prm1k = new OracleParameter("valuefrom_p", OracleType.VarChar, 50);
                prm1k.Direction = ParameterDirection.Input;
                prm1k.Value = valuefrom;
                objOraclecommand.Parameters.Add(prm1k);

                OracleParameter prm1l = new OracleParameter("valueto_p", OracleType.VarChar, 50);
                prm1l.Direction = ParameterDirection.Input;
                prm1l.Value = valueto;
                objOraclecommand.Parameters.Add(prm1l);

                OracleParameter prm1m = new OracleParameter("disctype_p", OracleType.VarChar, 50);
                prm1m.Direction = ParameterDirection.Input;
                prm1m.Value = disctype;
                objOraclecommand.Parameters.Add(prm1m);

                OracleParameter prm1n = new OracleParameter("discper_p", OracleType.VarChar, 50);
                prm1n.Direction = ParameterDirection.Input;
                prm1n.Value = discper;
                objOraclecommand.Parameters.Add(prm1n);

                OracleParameter prm1o = new OracleParameter("premium_p", OracleType.VarChar, 50);
                prm1o.Direction = ParameterDirection.Input;
                prm1o.Value = premium;
                objOraclecommand.Parameters.Add(prm1o);

                OracleParameter prm1p = new OracleParameter("contpremium_p", OracleType.VarChar, 50);
                prm1p.Direction = ParameterDirection.Input;
                prm1p.Value = contpremium;
                objOraclecommand.Parameters.Add(prm1p);

                OracleParameter prm1q = new OracleParameter("contrate_p", OracleType.VarChar, 50);
                prm1q.Direction = ParameterDirection.Input;
                prm1q.Value = contrate;
                objOraclecommand.Parameters.Add(prm1q);

                OracleParameter prm1r = new OracleParameter("cardrate_p", OracleType.VarChar, 50);
                prm1r.Direction = ParameterDirection.Input;
                prm1r.Value = cardrate;
                objOraclecommand.Parameters.Add(prm1r);

                OracleParameter prm1s = new OracleParameter("deviation_p", OracleType.VarChar, 50);
                prm1s.Direction = ParameterDirection.Input;
                prm1s.Value = deviation;
                objOraclecommand.Parameters.Add(prm1s);

                OracleParameter prm1t = new OracleParameter("cardprem_p", OracleType.VarChar, 50);
                prm1t.Direction = ParameterDirection.Input;
                prm1t.Value = cardprem;
                objOraclecommand.Parameters.Add(prm1t);

                OracleParameter prm1u = new OracleParameter("minsize_p", OracleType.VarChar, 50);
                prm1u.Direction = ParameterDirection.Input;
                prm1u.Value = minsize;
                objOraclecommand.Parameters.Add(prm1u);

                OracleParameter prm1v = new OracleParameter("maxsize_p", OracleType.VarChar, 50);
                prm1v.Direction = ParameterDirection.Input;
                prm1v.Value = maxsize;
                objOraclecommand.Parameters.Add(prm1v);

                OracleParameter prm1w = new OracleParameter("currency_p", OracleType.VarChar, 50);
                prm1w.Direction = ParameterDirection.Input;
                prm1w.Value = currency;
                objOraclecommand.Parameters.Add(prm1w);

                OracleParameter prm1x = new OracleParameter("dealstart_p", OracleType.VarChar, 50);
                prm1x.Direction = ParameterDirection.Input;
                prm1x.Value = dealstart;
                objOraclecommand.Parameters.Add(prm1x);

                OracleParameter prm1y = new OracleParameter("progtype_p", OracleType.VarChar, 50);
                prm1y.Direction = ParameterDirection.Input;
                prm1y.Value = progtype;
                objOraclecommand.Parameters.Add(prm1y);

                OracleParameter prm1z = new OracleParameter("category_p", OracleType.VarChar, 50);
                prm1z.Direction = ParameterDirection.Input;
                prm1z.Value = category;
                objOraclecommand.Parameters.Add(prm1z);

                OracleParameter prm1aa = new OracleParameter("commallow_p", OracleType.VarChar, 50);
                prm1aa.Direction = ParameterDirection.Input;
                prm1aa.Value = commallow;
                objOraclecommand.Parameters.Add(prm1aa);

                OracleParameter prm1ab = new OracleParameter("remarks_p", OracleType.VarChar, 50);
                prm1ab.Direction = ParameterDirection.Input;
                prm1ab.Value = remarks;
                objOraclecommand.Parameters.Add(prm1ab);

                OracleParameter prm1ac = new OracleParameter("ratecode_p", OracleType.VarChar, 50);
                prm1ac.Direction = ParameterDirection.Input;
                prm1ac.Value = ratecode;
                objOraclecommand.Parameters.Add(prm1ac);



                OracleParameter prm1ae = new OracleParameter("discon_p", OracleType.VarChar, 50);
                prm1ae.Direction = ParameterDirection.Input;
                prm1ae.Value = discon;
                objOraclecommand.Parameters.Add(prm1ae);

                OracleParameter prm1af = new OracleParameter("sponfrom_p", OracleType.VarChar, 50);
                prm1af.Direction = ParameterDirection.Input;
                if (sponfrom == "")
                    prm1af.Value = System.DBNull.Value;
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

                    prm1af.Value = Convert.ToDateTime(sponfrom).ToString("dd-MMMM-yyyy");

                }
                objOraclecommand.Parameters.Add(prm1af);

                OracleParameter prm1ag = new OracleParameter("sponto_p", OracleType.VarChar, 50);
                prm1ag.Direction = ParameterDirection.Input;
                if (sponto == "")
                    prm1ag.Value = System.DBNull.Value;
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

                    prm1ag.Value = Convert.ToDateTime(sponto).ToString("dd-MMMM-yyyy");

                }
                objOraclecommand.Parameters.Add(prm1ag);

                OracleParameter prm1ah = new OracleParameter("compcode_p", OracleType.VarChar, 50);
                prm1ah.Direction = ParameterDirection.Input;
                prm1ah.Value = compcode;
                objOraclecommand.Parameters.Add(prm1ah);

                OracleParameter prm1ai = new OracleParameter("userid_p", OracleType.VarChar, 50);
                prm1ai.Direction = ParameterDirection.Input;
                prm1ai.Value = userid;
                objOraclecommand.Parameters.Add(prm1ai);

                OracleParameter prm1aj = new OracleParameter("username_p", OracleType.VarChar, 50);
                prm1aj.Direction = ParameterDirection.Input;
                prm1aj.Value = username;
                objOraclecommand.Parameters.Add(prm1aj);

                OracleParameter prm1ak = new OracleParameter("incentive_p", OracleType.VarChar, 50);
                prm1ak.Direction = ParameterDirection.Input;
                prm1ak.Value = incentive;
                objOraclecommand.Parameters.Add(prm1ak);

                OracleParameter prm1al = new OracleParameter("approved_p", OracleType.VarChar, 50);
                prm1al.Direction = ParameterDirection.Input;
                prm1al.Value = approved;
                objOraclecommand.Parameters.Add(prm1al);

                OracleParameter prm1am = new OracleParameter("unit_p", OracleType.VarChar, 50);
                prm1am.Direction = ParameterDirection.Input;
                prm1am.Value = unit;
                objOraclecommand.Parameters.Add(prm1am);

                OracleParameter prm1an = new OracleParameter("seqno_p", OracleType.VarChar, 50);
                prm1an.Direction = ParameterDirection.Input;
                prm1an.Value = seqno;
                objOraclecommand.Parameters.Add(prm1an);

                OracleParameter prm1ad1 = new OracleParameter("id_p", OracleType.VarChar, 50);
                prm1ad1.Direction = ParameterDirection.Input;
                if (id == "" || id == "null" || id == null)
                    prm1ad1.Value = System.DBNull.Value;
                else
                    prm1ad1.Value = id;
                objOraclecommand.Parameters.Add(prm1ad1);

                OracleParameter prm1an1a = new OracleParameter("ratetype_p", OracleType.VarChar, 50);
                prm1an1a.Direction = ParameterDirection.Input;
                prm1an1a.Value = ratetype;
                objOraclecommand.Parameters.Add(prm1an1a);

                OracleParameter prm1an1b = new OracleParameter("source_p", OracleType.VarChar, 50);
                prm1an1b.Direction = ParameterDirection.Input;
                if (source == "")
                    prm1an1b.Value = System.DBNull.Value;
                else
                    prm1an1b.Value = source;
                objOraclecommand.Parameters.Add(prm1an1b);

                OracleParameter prm1an1 = new OracleParameter("totalval_p", OracleType.VarChar, 50);
                prm1an1.Direction = ParameterDirection.Input;
                if (totalval == "")
                    prm1an1.Value = System.DBNull.Value;
                else
                    prm1an1.Value = totalval;
                objOraclecommand.Parameters.Add(prm1an1);
                // for sectioncode and resourceno
                OracleParameter prm1an1aC = new OracleParameter("sectioncode_p", OracleType.VarChar, 50);
                prm1an1aC.Direction = ParameterDirection.Input;
                if (sectioncode == "")
                    prm1an1aC.Value = System.DBNull.Value;
                else
                    prm1an1aC.Value = sectioncode;
                objOraclecommand.Parameters.Add(prm1an1aC);

                OracleParameter prm1an11 = new OracleParameter("resourceno_p", OracleType.VarChar, 50);
                prm1an11.Direction = ParameterDirection.Input;
                if (resourceno == "")
                    prm1an11.Value = System.DBNull.Value;
                else
                    prm1an11.Value = resourceno;
                objOraclecommand.Parameters.Add(prm1an11);

                OracleParameter prm1an11a = new OracleParameter("localtotvalue_p", OracleType.VarChar, 50);
                prm1an11a.Direction = ParameterDirection.Input;
                if (localtotvalue == "")
                    prm1an11a.Value = System.DBNull.Value;
                else
                    prm1an11a.Value = localtotvalue;
                objOraclecommand.Parameters.Add(prm1an11a);


                OracleParameter prm1an11b = new OracleParameter("convrate_p", OracleType.VarChar, 50);
                prm1an11b.Direction = ParameterDirection.Input;
                if (convrate == "")
                    prm1an11b.Value = System.DBNull.Value;
                else
                    prm1an11b.Value = convrate;
                objOraclecommand.Parameters.Add(prm1an11b);


                OracleParameter prm1an11c = new OracleParameter("p_slot_per_day", OracleType.VarChar, 50);
                prm1an11c.Direction = ParameterDirection.Input;
                if (slot == "")
                    prm1an11c.Value = System.DBNull.Value;
                else
                    prm1an11c.Value = slot;
                objOraclecommand.Parameters.Add(prm1an11c);

                objOraclecommand.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }
        }
        public void savecontractdetail(string dealno, string adtype, string hue, string uom, string package, string category, string premium, string cardprem, string contractprem, string contrate, string cardrate, string deviation, string disctype, string discper, string discon, string minsize, string maxsize, string valuefrom, string valueto, string day, string insertion, string commallow, string dealstart, string currency, string ratecode, string totalrate, string incentive, string remarks, string approved, string compcode, string userid, string id, string position, string contractamount, string contractpositionprem, string positionpremdisc,string toinsertion,string barter)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            //  OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("savecontract_detail", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("dealno_p", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = dealno;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm1a = new OracleParameter("adtype_p", OracleType.VarChar, 50);
                prm1a.Direction = ParameterDirection.Input;
                prm1a.Value = adtype;
                objOraclecommand.Parameters.Add(prm1a);

                OracleParameter prm1b = new OracleParameter("hue_p", OracleType.VarChar, 50);
                prm1b.Direction = ParameterDirection.Input;
                prm1b.Value = hue;
                objOraclecommand.Parameters.Add(prm1b);


                OracleParameter prm1c = new OracleParameter("uom_p", OracleType.VarChar, 50);
                prm1c.Direction = ParameterDirection.Input;
                prm1c.Value = uom;
                objOraclecommand.Parameters.Add(prm1c);


                OracleParameter prm1d = new OracleParameter("package_p", OracleType.VarChar, 50);
                prm1d.Direction = ParameterDirection.Input;
                prm1d.Value = package;
                objOraclecommand.Parameters.Add(prm1d);

                OracleParameter prm1e = new OracleParameter("category_p", OracleType.VarChar, 50);
                prm1e.Direction = ParameterDirection.Input;
                prm1e.Value = category;
                objOraclecommand.Parameters.Add(prm1e);

                OracleParameter prm1f = new OracleParameter("premium_p", OracleType.VarChar, 50);
                prm1f.Direction = ParameterDirection.Input;
                prm1f.Value = premium;
                objOraclecommand.Parameters.Add(prm1f);

                OracleParameter prm1g = new OracleParameter("cardprem_p", OracleType.VarChar, 50);
                prm1g.Direction = ParameterDirection.Input;
                prm1g.Value = cardprem;
                objOraclecommand.Parameters.Add(prm1g);

                OracleParameter prm1h = new OracleParameter("contractprem_p", OracleType.VarChar, 50);
                prm1h.Direction = ParameterDirection.Input;
                prm1h.Value = contractprem;
                objOraclecommand.Parameters.Add(prm1h);

                OracleParameter prm1i = new OracleParameter("contrate_p", OracleType.VarChar, 50);
                prm1i.Direction = ParameterDirection.Input;
                prm1i.Value = contrate;
                objOraclecommand.Parameters.Add(prm1i);

                OracleParameter prm1j = new OracleParameter("cardrate_p", OracleType.VarChar, 50);
                prm1j.Direction = ParameterDirection.Input;
                prm1j.Value = cardrate;
                objOraclecommand.Parameters.Add(prm1j);

                OracleParameter prm1k = new OracleParameter("deviation_p", OracleType.VarChar, 50);
                prm1k.Direction = ParameterDirection.Input;
                prm1k.Value = deviation;
                objOraclecommand.Parameters.Add(prm1k);

                OracleParameter prm1l = new OracleParameter("disctype_p", OracleType.VarChar, 50);
                prm1l.Direction = ParameterDirection.Input;
                prm1l.Value = disctype;
                objOraclecommand.Parameters.Add(prm1l);

                OracleParameter prm1m = new OracleParameter("discper_p", OracleType.VarChar, 50);
                prm1m.Direction = ParameterDirection.Input;
                prm1m.Value = discper;
                objOraclecommand.Parameters.Add(prm1m);

                OracleParameter prm1n = new OracleParameter("discon_p", OracleType.VarChar, 50);
                prm1n.Direction = ParameterDirection.Input;
                prm1n.Value = discon;
                objOraclecommand.Parameters.Add(prm1n);

                OracleParameter prm1o = new OracleParameter("minsize_p", OracleType.VarChar, 50);
                prm1o.Direction = ParameterDirection.Input;
                prm1o.Value = minsize;
                objOraclecommand.Parameters.Add(prm1o);

                OracleParameter prm1p = new OracleParameter("maxsize_p", OracleType.VarChar, 50);
                prm1p.Direction = ParameterDirection.Input;
                prm1p.Value = maxsize;
                objOraclecommand.Parameters.Add(prm1p);

                OracleParameter prm1q = new OracleParameter("valuefrom_p", OracleType.VarChar, 50);
                prm1q.Direction = ParameterDirection.Input;
                prm1q.Value = valuefrom;
                objOraclecommand.Parameters.Add(prm1q);

                OracleParameter prm1q1 = new OracleParameter("valueto_p", OracleType.VarChar, 50);
                prm1q1.Direction = ParameterDirection.Input;
                prm1q1.Value = valueto;
                objOraclecommand.Parameters.Add(prm1q1);

                OracleParameter prm1r = new OracleParameter("day_p", OracleType.VarChar, 50);
                prm1r.Direction = ParameterDirection.Input;
                prm1r.Value = day;
                objOraclecommand.Parameters.Add(prm1r);

                OracleParameter prm1s = new OracleParameter("insertion_p", OracleType.VarChar, 50);
                prm1s.Direction = ParameterDirection.Input;
                prm1s.Value = insertion;
                objOraclecommand.Parameters.Add(prm1s);

                OracleParameter prm1t = new OracleParameter("commallow_p", OracleType.VarChar, 50);
                prm1t.Direction = ParameterDirection.Input;
                prm1t.Value = commallow;
                objOraclecommand.Parameters.Add(prm1t);

                OracleParameter prm1u = new OracleParameter("dealstart_p", OracleType.VarChar, 50);
                prm1u.Direction = ParameterDirection.Input;
                prm1u.Value = dealstart;
                objOraclecommand.Parameters.Add(prm1u);

                OracleParameter prm1v = new OracleParameter("currency_p", OracleType.VarChar, 50);
                prm1v.Direction = ParameterDirection.Input;
                prm1v.Value = currency;
                objOraclecommand.Parameters.Add(prm1v);

                OracleParameter prm1w = new OracleParameter("ratecode_p", OracleType.VarChar, 50);
                prm1w.Direction = ParameterDirection.Input;
                prm1w.Value = ratecode;
                objOraclecommand.Parameters.Add(prm1w);

                OracleParameter prm1x = new OracleParameter("totalrate_p", OracleType.VarChar, 50);
                prm1x.Direction = ParameterDirection.Input;
                prm1x.Value = totalrate;
                objOraclecommand.Parameters.Add(prm1x);

                OracleParameter prm1y = new OracleParameter("incentive_p", OracleType.VarChar, 50);
                prm1y.Direction = ParameterDirection.Input;
                prm1y.Value = incentive;
                objOraclecommand.Parameters.Add(prm1y);

                OracleParameter prm1z = new OracleParameter("remarks_p", OracleType.VarChar, 50);
                prm1z.Direction = ParameterDirection.Input;
                prm1z.Value = remarks;
                objOraclecommand.Parameters.Add(prm1z);

                OracleParameter prm1aa = new OracleParameter("approved_p", OracleType.VarChar, 50);
                prm1aa.Direction = ParameterDirection.Input;
                prm1aa.Value = approved;
                objOraclecommand.Parameters.Add(prm1aa);

                OracleParameter prm1ab = new OracleParameter("compcode_p", OracleType.VarChar, 50);
                prm1ab.Direction = ParameterDirection.Input;
                prm1ab.Value = compcode;
                objOraclecommand.Parameters.Add(prm1ab);


                OracleParameter prm1ac = new OracleParameter("userid_p", OracleType.VarChar, 50);
                prm1ac.Direction = ParameterDirection.Input;
                prm1ac.Value = userid;
                objOraclecommand.Parameters.Add(prm1ac);

                OracleParameter prm1ad = new OracleParameter("id_p", OracleType.VarChar, 50);
                prm1ad.Direction = ParameterDirection.Input;
                if (id == "" || id == "null" || id == null)
                    prm1ad.Value = System.DBNull.Value;
                else
                    prm1ad.Value = id;
                objOraclecommand.Parameters.Add(prm1ad);

                OracleParameter prm12ac = new OracleParameter("positionprem", OracleType.VarChar, 50);
                prm12ac.Direction = ParameterDirection.Input;
                prm12ac.Value = position;
                objOraclecommand.Parameters.Add(prm12ac);


                OracleParameter prm14ac = new OracleParameter("contractamount1", OracleType.VarChar, 50);
                prm14ac.Direction = ParameterDirection.Input;
                prm14ac.Value = contractamount;
                objOraclecommand.Parameters.Add(prm14ac);


                OracleParameter prm15ac = new OracleParameter("pcontractpositionprem", OracleType.VarChar, 50);
                prm15ac.Direction = ParameterDirection.Input;
                prm15ac.Value = contractpositionprem;
                objOraclecommand.Parameters.Add(prm15ac);



                OracleParameter prm13ac = new OracleParameter("ppositionpremdisc", OracleType.VarChar, 50);
                prm13ac.Direction = ParameterDirection.Input;
                prm13ac.Value = positionpremdisc;
                objOraclecommand.Parameters.Add(prm13ac);

                OracleParameter prm16ac = new OracleParameter("ptoinsertion", OracleType.VarChar, 50);
                prm16ac.Direction = ParameterDirection.Input;
                prm16ac.Value = toinsertion;
                objOraclecommand.Parameters.Add(prm16ac);

                OracleParameter prm17ac = new OracleParameter("pbarter", OracleType.VarChar, 50);
                prm17ac.Direction = ParameterDirection.Input;
                prm17ac.Value = barter;
                objOraclecommand.Parameters.Add(prm17ac);

                objOraclecommand.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }
        }
        public DataSet bindSource_TV(string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("TV_SOURCE_TYPE_BIND", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);


                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }
        }
        public DataSet bindAdvType_TV(string compcode, string channel)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("TV_AD_TYPE_BIND", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm1a = new OracleParameter("channel_p", OracleType.VarChar, 50);
                prm1a.Direction = ParameterDirection.Input;
                prm1a.Value = channel;
                objOraclecommand.Parameters.Add(prm1a);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }
        }
        public DataSet bindROS_TV(string compcode, string btbcode, string channel)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("TV_BND_MST_BIND", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("btbcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = btbcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm1a = new OracleParameter("channel_p", OracleType.VarChar, 50);
                prm1a.Direction = ParameterDirection.Input;
                prm1a.Value = channel;
                objOraclecommand.Parameters.Add(prm1a);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }
        }
        public DataSet bindProduct(string compcode, string industry)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("bindProductIndustryWise", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("industry", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                if (industry == "")
                    prm2.Value = System.DBNull.Value;
                else
                    prm2.Value = industry;
                objOraclecommand.Parameters.Add(prm2);


                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }
        }
        public DataSet bindBTB_TV(string compcode, string channel)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("TV_BTB_MST_BIND", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm1a = new OracleParameter("channel_p", OracleType.VarChar, 50);
                prm1a.Direction = ParameterDirection.Input;
                prm1a.Value = channel;
                objOraclecommand.Parameters.Add(prm1a);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }
        }
        public DataSet bindProgram_TV(string compcode, string progtype, string btbcode, string channel_p)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("TV_AD_PROGRAMME_BIND_BTB", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("progtype", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = progtype;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("btbcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = btbcode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("channel_p", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = channel_p;
                objOraclecommand.Parameters.Add(prm4);


                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }
        }
        public DataSet bindProgramType_TV(string compcode, string channel)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("TV_AD_PROGRAMME_TY_BIND", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm11 = new OracleParameter("channel_p", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = channel;
                objOraclecommand.Parameters.Add(prm11);


                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }
        }
        public DataSet bindLocation_TV(string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("TV_AD_LOCATION_BIND", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);


                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }
        }
        public DataSet bindChannel_TV(string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("TV_AD_CHANNEL_BIND", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);


                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }
        }
        public DataSet bindgridContract(string compcode, string userid, string values, string adcat)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();

                if (adcat == "0")
                {
                    objOraclecommand = GetCommand("bindcontract.bindcontract_p", ref objOracleConnection);
                    objOraclecommand.CommandType = CommandType.StoredProcedure;

                    OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                    prm1.Direction = ParameterDirection.Input;
                    prm1.Value = compcode;
                    objOraclecommand.Parameters.Add(prm1);


                    OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                    prm2.Direction = ParameterDirection.Input;
                    prm2.Value = userid;
                    objOraclecommand.Parameters.Add(prm2);




                    OracleParameter prm3 = new OracleParameter("values1", OracleType.VarChar, 50);
                    prm3.Direction = ParameterDirection.Input;
                    if (values == "null" || values == "")
                    {
                        prm3.Value = System.DBNull.Value;
                    }
                    else
                    {
                        prm3.Value = values;
                    }
                    objOraclecommand.Parameters.Add(prm3);


                    objOraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
                    objOraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;

                }


                else
                {

                    objOraclecommand = GetCommand("getedibyvat.getedibyvat_p", ref objOracleConnection);
                    objOraclecommand.CommandType = CommandType.StoredProcedure;

                    OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                    prm1.Direction = ParameterDirection.Input;
                    prm1.Value = compcode;
                    objOraclecommand.Parameters.Add(prm1);



                    OracleParameter prm2 = new OracleParameter("adcat1", OracleType.VarChar, 50);
                    prm2.Direction = ParameterDirection.Input;
                    prm2.Value = adcat;
                    objOraclecommand.Parameters.Add(prm2);



                    OracleParameter prm3 = new OracleParameter("checkboxname", OracleType.VarChar, 50);
                    prm3.Direction = ParameterDirection.Input;
                    prm3.Value = values;
                    objOraclecommand.Parameters.Add(prm3);

                    objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                    objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                }
                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }
        }
        public DataSet bindagency(string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("bindagencyforcontract.bindagencyforcontract_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);


                objOraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;










                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }
        }


        public DataSet bindsubagency(string agency, string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("bindsubagencyforcontract.bindsubagencyforcontract_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);



                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);



                OracleParameter prm3 = new OracleParameter("agency", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = agency;
                objOraclecommand.Parameters.Add(prm3);


                objOraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;


                objOraclecommand.Parameters.Add("P_Accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts1"].Direction = ParameterDirection.Output;








                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }

        }

        public DataSet clientbind(string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("bindclientforcontract.bindclientforcontract_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;











                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }


        }

        public DataSet productbind(string client, string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("bindproductforcontract.bindproductforcontract_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);



                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);



                OracleParameter prm3 = new OracleParameter("client", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = client;
                objOraclecommand.Parameters.Add(prm3);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;









                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }

        }

        public DataSet contractcode(string DealNo, string compcode, string dealname, string dealtype)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("checkcontractcode.checkcontractcode_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);



                OracleParameter prm2 = new OracleParameter("dealname", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = dealname;
                objOraclecommand.Parameters.Add(prm2);



                OracleParameter prm3 = new OracleParameter("dealtype", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = dealtype;
                objOraclecommand.Parameters.Add(prm3);



                OracleParameter prm4 = new OracleParameter("DealNo", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = DealNo;
                objOraclecommand.Parameters.Add(prm4);


                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts1"].Direction = ParameterDirection.Output;









                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }

        }

        public void insertcontact(string DealNo, string dealname, string agencycode, string subagencycode, string clientname, string product, string validfromdate, string validtill, string representative, string compcode, string userid, string totalvalue, string totalvolume, string currencys, string teamname, string dealtype, string adtype, string remarks, string executive_var, string retainer_var, string contdate_var, string closedate_var, string servicetax_var, string caption_var, string paymode_var, string b2b, string chkmulti, string chkseq, string seqno, string chkparti, string indus, string induspro, string dealon, string attach1, string transition, string centername, string printcenter, string rono, string rodate, string rostatus, string rcptno, string rcptcurr, string quotation)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            //  OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("insertcontactmast.insertcontactmast_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("teamname", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = teamname;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("dealtype", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = dealtype;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = userid;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("currencys", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = currencys;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("dealno", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = DealNo;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("dealname", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = dealname;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("totalvalue", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                if (totalvalue == "")
                {
                    prm8.Value = totalvalue;
                }
                else
                {
                    prm8.Value = Convert.ToInt64(totalvalue);
                }
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("totalvolume", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                if (totalvolume == "")
                {
                    prm9.Value = totalvolume;
                }
                else
                {
                    prm9.Value = Convert.ToInt64(totalvolume);
                }
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("agencycode", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = agencycode;
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("subagencycode", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = subagencycode;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("product", OracleType.VarChar, 50);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = product;
                objOraclecommand.Parameters.Add(prm12);

                OracleParameter prm13 = new OracleParameter("validfromdate", OracleType.VarChar, 50);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = Convert.ToDateTime(validfromdate).ToString("dd-MMMM-yyyy");
                objOraclecommand.Parameters.Add(prm13);

                OracleParameter prm14 = new OracleParameter("validtill", OracleType.VarChar, 50);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = Convert.ToDateTime(validtill).ToString("dd-MMMM-yyyy");
                objOraclecommand.Parameters.Add(prm14);

                OracleParameter prm15 = new OracleParameter("representative", OracleType.VarChar, 50);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = representative;
                objOraclecommand.Parameters.Add(prm15);

                OracleParameter prm16 = new OracleParameter("clientname", OracleType.VarChar, 50);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = clientname;
                objOraclecommand.Parameters.Add(prm16);

                OracleParameter prm17 = new OracleParameter("adtype1", OracleType.VarChar, 50);
                prm17.Direction = ParameterDirection.Input;
                prm17.Value = adtype;
                objOraclecommand.Parameters.Add(prm17);

                OracleParameter prm18 = new OracleParameter("REMARK", OracleType.VarChar);
                prm18.Direction = ParameterDirection.Input;
                prm18.Value = remarks;
                objOraclecommand.Parameters.Add(prm18);

                OracleParameter prm19 = new OracleParameter("executive_var", OracleType.VarChar);
                prm19.Direction = ParameterDirection.Input;
                prm19.Value = executive_var;
                objOraclecommand.Parameters.Add(prm19);


                OracleParameter prm20 = new OracleParameter("retainer_var", OracleType.VarChar);
                prm20.Direction = ParameterDirection.Input;
                prm20.Value = retainer_var;
                objOraclecommand.Parameters.Add(prm20);

                OracleParameter prm14a = new OracleParameter("contdate_var", OracleType.VarChar, 50);
                prm14a.Direction = ParameterDirection.Input;
                if (contdate_var == "")
                    prm14a.Value = System.DBNull.Value;
                else
                    prm14a.Value = Convert.ToDateTime(contdate_var).ToString("dd-MMMM-yyyy");
                objOraclecommand.Parameters.Add(prm14a);

                OracleParameter prm14b = new OracleParameter("closedate_var", OracleType.VarChar, 50);
                prm14b.Direction = ParameterDirection.Input;
                if (closedate_var == "")
                    prm14b.Value = System.DBNull.Value;
                else
                    prm14b.Value = Convert.ToDateTime(closedate_var).ToString("dd-MMMM-yyyy");
                objOraclecommand.Parameters.Add(prm14b);

                OracleParameter prm20a = new OracleParameter("servicetax_var", OracleType.VarChar);
                prm20a.Direction = ParameterDirection.Input;
                prm20a.Value = servicetax_var;
                objOraclecommand.Parameters.Add(prm20a);

                OracleParameter prm20b = new OracleParameter("caption_var", OracleType.VarChar);
                prm20b.Direction = ParameterDirection.Input;
                prm20b.Value = caption_var;
                objOraclecommand.Parameters.Add(prm20b);

                OracleParameter prm20c = new OracleParameter("paymode_var", OracleType.VarChar);
                prm20c.Direction = ParameterDirection.Input;
                prm20c.Value = paymode_var;
                objOraclecommand.Parameters.Add(prm20c);



                OracleParameter prm20c1 = new OracleParameter("b2b_var", OracleType.VarChar);
                prm20c1.Direction = ParameterDirection.Input;
                prm20c1.Value = b2b;
                objOraclecommand.Parameters.Add(prm20c1);

                OracleParameter prm20c2 = new OracleParameter("chkmulti_var", OracleType.VarChar);
                prm20c2.Direction = ParameterDirection.Input;
                prm20c2.Value = chkmulti;
                objOraclecommand.Parameters.Add(prm20c2);

                OracleParameter prm20c3 = new OracleParameter("chkseq_var", OracleType.VarChar);
                prm20c3.Direction = ParameterDirection.Input;
                prm20c3.Value = chkseq;
                objOraclecommand.Parameters.Add(prm20c3);

                OracleParameter prm20c4 = new OracleParameter("seqno_var", OracleType.VarChar);
                prm20c4.Direction = ParameterDirection.Input;
                prm20c4.Value = seqno;
                objOraclecommand.Parameters.Add(prm20c4);

                OracleParameter prm20c5 = new OracleParameter("chkparti_var", OracleType.VarChar);
                prm20c5.Direction = ParameterDirection.Input;
                prm20c5.Value = chkparti;
                objOraclecommand.Parameters.Add(prm20c5);

                OracleParameter prm20c6 = new OracleParameter("indus_var", OracleType.VarChar);
                prm20c6.Direction = ParameterDirection.Input;
                prm20c6.Value = indus;
                objOraclecommand.Parameters.Add(prm20c6);

                OracleParameter prm20c7 = new OracleParameter("induspro_var", OracleType.VarChar);
                prm20c7.Direction = ParameterDirection.Input;
                prm20c7.Value = induspro;
                objOraclecommand.Parameters.Add(prm20c7);

                OracleParameter prm20c71 = new OracleParameter("dealon_var", OracleType.VarChar);
                prm20c71.Direction = ParameterDirection.Input;
                prm20c71.Value = dealon;
                objOraclecommand.Parameters.Add(prm20c71);


                OracleParameter prm20c72 = new OracleParameter("attachment1", OracleType.VarChar);
                prm20c72.Direction = ParameterDirection.Input;
                prm20c72.Value = attach1;
                objOraclecommand.Parameters.Add(prm20c72);

                OracleParameter prm20c73 = new OracleParameter("dealcenter", OracleType.VarChar);
                prm20c73.Direction = ParameterDirection.Input;
                prm20c73.Value = printcenter;
                objOraclecommand.Parameters.Add(prm20c73);

                OracleParameter prm20c74 = new OracleParameter("dealfrom", OracleType.VarChar);
                prm20c74.Direction = ParameterDirection.Input;
                prm20c74.Value = centername;
                objOraclecommand.Parameters.Add(prm20c74);

                OracleParameter prm20c75 = new OracleParameter("translation", OracleType.VarChar);
                prm20c75.Direction = ParameterDirection.Input;
                prm20c75.Value = transition;
                objOraclecommand.Parameters.Add(prm20c75);

                //string rono, string rodate, string rostatus, string rcptno, string rcptcurr

                OracleParameter prmn = new OracleParameter("rono_p", OracleType.VarChar);
                prmn.Direction = ParameterDirection.Input;
                prmn.Value = rono;
                objOraclecommand.Parameters.Add(prmn);

                OracleParameter prmn1 = new OracleParameter("rodate_p", OracleType.VarChar);
                prmn1.Direction = ParameterDirection.Input;
                if (rodate == "")
                    prmn1.Value = System.DBNull.Value;
                else
                    prmn1.Value = Convert.ToDateTime(rodate).ToString("dd-MMMM-yyyy");
              
                objOraclecommand.Parameters.Add(prmn1);

                OracleParameter prmn2 = new OracleParameter("rostatus_p", OracleType.VarChar);
                prmn2.Direction = ParameterDirection.Input;
                prmn2.Value = rostatus;
                objOraclecommand.Parameters.Add(prmn2);

                OracleParameter prmn3 = new OracleParameter("rcptno_p", OracleType.VarChar);
                prmn3.Direction = ParameterDirection.Input;
                prmn3.Value = rcptno;
                objOraclecommand.Parameters.Add(prmn3);

                OracleParameter prmn4 = new OracleParameter("rcptcurr_p", OracleType.VarChar);
                prmn4.Direction = ParameterDirection.Input;
                prmn4.Value = rcptcurr;
                objOraclecommand.Parameters.Add(prmn4);
                ////objorclDataAdapter.SelectCommand = objOraclecommand;
                ////objorclDataAdapter.Fill(objDataSet);
                ////return objDataSet;
              //  objOraclecommand.ExecuteNonQuery();

                OracleParameter prmn5 = new OracleParameter("quotion_p", OracleType.VarChar);
                prmn5.Direction = ParameterDirection.Input;
                if (quotation==""||quotation=="N")
                    prmn5.Value = System.DBNull.Value;
                else
                    prmn5.Value = quotation;
                objOraclecommand.Parameters.Add(prmn5);
                objOraclecommand.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }

        }

        public DataSet modifycontact(string DealNo, string dealname, string agencycode, string subagencycode, string clientname, string product, string validfromdate, string validtill, string representative, string compcode, string userid, string totalvalue, string totalvolume, string currencys, string teamname, string dealtype, string adtype, string remarks, string executive_var, string retainer_var, string contdate_var, string closedate_var, string servicetax_var, string caption_var, string paymode_var, string b2b, string chkmulti, string chkseq, string seqno, string chkparti, string indus, string induspro, string dealon, string attach1, string transition, string centername, string printcenter,string rono, string rodate, string rostatus, string rcptno, string rcptcurr)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("updatecontactmast.updatecontactmast_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);



                OracleParameter prm2 = new OracleParameter("teamname", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = teamname;
                objOraclecommand.Parameters.Add(prm2);



                OracleParameter prm3 = new OracleParameter("dealname", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = dealname;
                objOraclecommand.Parameters.Add(prm3);



                OracleParameter prm4 = new OracleParameter("dealtype", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = dealtype;
                objOraclecommand.Parameters.Add(prm4);


                OracleParameter prm5 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = userid;
                objOraclecommand.Parameters.Add(prm5);



                OracleParameter prm6 = new OracleParameter("currencys", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = currencys;
                objOraclecommand.Parameters.Add(prm6);



                OracleParameter prm7 = new OracleParameter("DealNo", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = DealNo;
                objOraclecommand.Parameters.Add(prm7);



                OracleParameter prm8 = new OracleParameter("totalvalue", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = totalvalue;
                objOraclecommand.Parameters.Add(prm8);



                OracleParameter prm9 = new OracleParameter("totalvolume", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = totalvolume;
                objOraclecommand.Parameters.Add(prm9);



                OracleParameter prm10 = new OracleParameter("agencycode", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = agencycode;
                objOraclecommand.Parameters.Add(prm10);



                OracleParameter prm11 = new OracleParameter("subagencycode", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = subagencycode;
                objOraclecommand.Parameters.Add(prm11);



                OracleParameter prm12 = new OracleParameter("product", OracleType.VarChar, 50);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = product;
                objOraclecommand.Parameters.Add(prm12);



                OracleParameter prm13 = new OracleParameter("validfromdate", OracleType.VarChar, 50);
                prm13.Direction = ParameterDirection.Input;
                if (validfromdate == "")
                {
                    prm13.Value = System.DBNull.Value;
                }
                else
                {
                    prm13.Value = Convert.ToDateTime(validfromdate).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm13);


                OracleParameter prm14 = new OracleParameter("validtill", OracleType.VarChar, 50);
                prm14.Direction = ParameterDirection.Input;
                if (validtill == "")
                {
                    prm14.Value = System.DBNull.Value;
                }
                else
                {
                    prm14.Value = Convert.ToDateTime(validtill).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm14);


                OracleParameter prm15 = new OracleParameter("representative", OracleType.VarChar, 50);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = representative;
                objOraclecommand.Parameters.Add(prm15);

                OracleParameter prm16 = new OracleParameter("clientname", OracleType.VarChar, 50);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = clientname;
                objOraclecommand.Parameters.Add(prm16);

                OracleParameter prm17 = new OracleParameter("adtype", OracleType.VarChar, 50);
                prm17.Direction = ParameterDirection.Input;
                prm17.Value = adtype;
                objOraclecommand.Parameters.Add(prm17);

                OracleParameter prm18 = new OracleParameter("REMARK", OracleType.VarChar);
                prm18.Direction = ParameterDirection.Input;
                prm18.Value = remarks;
                objOraclecommand.Parameters.Add(prm18);

                OracleParameter prm19 = new OracleParameter("executive_var", OracleType.VarChar);
                prm19.Direction = ParameterDirection.Input;
                prm19.Value = executive_var;
                objOraclecommand.Parameters.Add(prm19);


                OracleParameter prm20 = new OracleParameter("retainer_var", OracleType.VarChar);
                prm20.Direction = ParameterDirection.Input;
                prm20.Value = retainer_var;
                objOraclecommand.Parameters.Add(prm20);

                OracleParameter prm14a = new OracleParameter("contdate_var", OracleType.VarChar, 50);
                prm14a.Direction = ParameterDirection.Input;
                if (contdate_var == "")
                    prm14a.Value = System.DBNull.Value;
                else
                    prm14a.Value = Convert.ToDateTime(contdate_var).ToString("dd-MMMM-yyyy");
                objOraclecommand.Parameters.Add(prm14a);

                OracleParameter prm14b = new OracleParameter("closedate_var", OracleType.VarChar, 50);
                prm14b.Direction = ParameterDirection.Input;
                if (closedate_var == "")
                    prm14b.Value = System.DBNull.Value;
                else
                    prm14b.Value = Convert.ToDateTime(closedate_var).ToString("dd-MMMM-yyyy");
                objOraclecommand.Parameters.Add(prm14b);

                OracleParameter prm20a = new OracleParameter("servicetax_var", OracleType.VarChar);
                prm20a.Direction = ParameterDirection.Input;
                prm20a.Value = servicetax_var;
                objOraclecommand.Parameters.Add(prm20a);

                OracleParameter prm20b = new OracleParameter("caption_var", OracleType.VarChar);
                prm20b.Direction = ParameterDirection.Input;
                prm20b.Value = caption_var;
                objOraclecommand.Parameters.Add(prm20b);

                OracleParameter prm20c = new OracleParameter("paymode_var", OracleType.VarChar);
                prm20c.Direction = ParameterDirection.Input;
                prm20c.Value = paymode_var;
                objOraclecommand.Parameters.Add(prm20c);

                OracleParameter prm20c1 = new OracleParameter("b2b_var", OracleType.VarChar);
                prm20c1.Direction = ParameterDirection.Input;
                prm20c1.Value = b2b;
                objOraclecommand.Parameters.Add(prm20c1);

                OracleParameter prm20c2 = new OracleParameter("chkmulti_var", OracleType.VarChar);
                prm20c2.Direction = ParameterDirection.Input;
                prm20c2.Value = chkmulti;
                objOraclecommand.Parameters.Add(prm20c2);

                OracleParameter prm20c3 = new OracleParameter("chkseq_var", OracleType.VarChar);
                prm20c3.Direction = ParameterDirection.Input;
                prm20c3.Value = chkseq;
                objOraclecommand.Parameters.Add(prm20c3);

                OracleParameter prm20c4 = new OracleParameter("seqno_var", OracleType.VarChar);
                prm20c4.Direction = ParameterDirection.Input;
                prm20c4.Value = seqno;
                objOraclecommand.Parameters.Add(prm20c4);

                OracleParameter prm20c5 = new OracleParameter("chkparti_var", OracleType.VarChar);
                prm20c5.Direction = ParameterDirection.Input;
                prm20c5.Value = chkparti;
                objOraclecommand.Parameters.Add(prm20c5);

                OracleParameter prm20c6 = new OracleParameter("indus_var", OracleType.VarChar);
                prm20c6.Direction = ParameterDirection.Input;
                prm20c6.Value = indus;
                objOraclecommand.Parameters.Add(prm20c6);

                OracleParameter prm20c7 = new OracleParameter("induspro_var", OracleType.VarChar);
                prm20c7.Direction = ParameterDirection.Input;
                prm20c7.Value = induspro;
                objOraclecommand.Parameters.Add(prm20c7);

                OracleParameter prm20c71 = new OracleParameter("dealon_var", OracleType.VarChar);
                prm20c71.Direction = ParameterDirection.Input;
                prm20c71.Value = dealon;
                objOraclecommand.Parameters.Add(prm20c71);

                OracleParameter prm20c72 = new OracleParameter("attachment1", OracleType.VarChar);
                prm20c72.Direction = ParameterDirection.Input;
                prm20c72.Value = attach1;
                objOraclecommand.Parameters.Add(prm20c72);

                OracleParameter prm20c73 = new OracleParameter("dealcenter", OracleType.VarChar);
                prm20c73.Direction = ParameterDirection.Input;
                prm20c73.Value = printcenter;
                objOraclecommand.Parameters.Add(prm20c73);

                OracleParameter prm20c74 = new OracleParameter("dealfrom", OracleType.VarChar);
                prm20c74.Direction = ParameterDirection.Input;
                prm20c74.Value = centername;
                objOraclecommand.Parameters.Add(prm20c74);

                OracleParameter prm20c75 = new OracleParameter("translation", OracleType.VarChar);
                prm20c75.Direction = ParameterDirection.Input;
                prm20c75.Value = transition;
                objOraclecommand.Parameters.Add(prm20c75);
                //string rono, string rodate, string rostatus, string rcptno, string rcptcurr

                OracleParameter prmn = new OracleParameter("rono_p", OracleType.VarChar);
                prmn.Direction = ParameterDirection.Input;
                prmn.Value = rono;
                objOraclecommand.Parameters.Add(prmn);

                OracleParameter prmn1 = new OracleParameter("rodate_p", OracleType.VarChar);
                prmn1.Direction = ParameterDirection.Input;
                if (rodate == "")
                    prmn1.Value = System.DBNull.Value;
                else
                    prmn1.Value = Convert.ToDateTime(rodate).ToString("dd-MMMM-yyyy");

                objOraclecommand.Parameters.Add(prmn1);

                OracleParameter prmn2 = new OracleParameter("rostatus_p", OracleType.VarChar);
                prmn2.Direction = ParameterDirection.Input;
                prmn2.Value = rostatus;
                objOraclecommand.Parameters.Add(prmn2);

                OracleParameter prmn3 = new OracleParameter("rcptno_p", OracleType.VarChar);
                prmn3.Direction = ParameterDirection.Input;
                prmn3.Value = rcptno;
                objOraclecommand.Parameters.Add(prmn3);

                OracleParameter prmn4 = new OracleParameter("rcptcurr_p", OracleType.VarChar);
                prmn4.Direction = ParameterDirection.Input;
                prmn4.Value = rcptcurr;
                objOraclecommand.Parameters.Add(prmn4);
                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }

        }

        public DataSet dealmodifychk(string dealno, string deal_name, string compcode, string deal_type)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("dealmodifychk.dealmodifychk_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("dealno", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = dealno;
                objOraclecommand.Parameters.Add(prm1);



                OracleParameter prm2 = new OracleParameter("dealname", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = deal_name;
                objOraclecommand.Parameters.Add(prm2);



                OracleParameter prm3 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = compcode;
                objOraclecommand.Parameters.Add(prm3);


                OracleParameter prm4 = new OracleParameter("dealtype", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = deal_type;
                objOraclecommand.Parameters.Add(prm4);


                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;





                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;


                //return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }


        }

        public DataSet dealchk(string Deal_No, string deal_name, string dn)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("dealchkforcontract.dealchkforcontract_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("dealno", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = Deal_No;
                objOraclecommand.Parameters.Add(prm1);



                OracleParameter prm2 = new OracleParameter("dealname", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = deal_name;
                objOraclecommand.Parameters.Add(prm2);



                OracleParameter prm3 = new OracleParameter("dn", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = dn;
                objOraclecommand.Parameters.Add(prm3);




                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;


                //return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }


        }


        public DataSet dealautocode(string dealname)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("dealautocode.dealautocode_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("dealname", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = dealname;
                objOraclecommand.Parameters.Add(prm1);
                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;




                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }


        }

        public DataSet querycontract(string DealNo, string dealname, string agencycode, string subagencycode, string clientname, string product, string representative, string compcode, string userid, string dealtype, string quotation)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("executecontract.executecontract_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);



                OracleParameter prm2 = new OracleParameter("dealname", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = dealname;
                objOraclecommand.Parameters.Add(prm2);



                OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userid;
                objOraclecommand.Parameters.Add(prm3);



                OracleParameter prm4 = new OracleParameter("DealNo", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = DealNo;
                objOraclecommand.Parameters.Add(prm4);



                OracleParameter prm5 = new OracleParameter("dealtype", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                if (dealtype == "0")
                {
                    prm5.Value = System.DBNull.Value;
                }
                else
                {
                    prm5.Value = dealtype;
                }
                objOraclecommand.Parameters.Add(prm5);



                OracleParameter prm6 = new OracleParameter("agencycode", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                if (agencycode == "0")
                {
                    prm6.Value = System.DBNull.Value;
                }
                else
                {
                    prm6.Value = agencycode;
                }
                objOraclecommand.Parameters.Add(prm6);



                OracleParameter prm7 = new OracleParameter("subagencycode", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                if (subagencycode == "0")
                {
                    prm7.Value = System.DBNull.Value;
                }
                else
                {
                    prm7.Value = subagencycode;
                }
                objOraclecommand.Parameters.Add(prm7);



                OracleParameter prm8 = new OracleParameter("Representative", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                if (representative == "0")
                {

                    prm8.Value = System.DBNull.Value;
                }
                else
                {
                    prm8.Value = representative;
                }
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("quotion_p", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                if (quotation == "" || quotation == "N")
                {

                    prm9.Value = System.DBNull.Value;
                }
                else
                {
                    prm9.Value = quotation;
                }
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("clientname_p", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                if (clientname == "")
                {

                    prm10.Value = System.DBNull.Value;
                }
                else
                {
                    prm10.Value = clientname;
                }
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("pcont_date", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                //if (clientname == "")
                //{

                    prm11.Value = System.DBNull.Value;
                //}
                //else
                //{
                //    prm11.Value = clientname;
                //}
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("pteamname", OracleType.VarChar, 50);
                prm12.Direction = ParameterDirection.Input;
                //if (clientname == "")
                //{

                prm12.Value = System.DBNull.Value;
                //}
                //else
                //{
                //    prm11.Value = clientname;
                //}
                objOraclecommand.Parameters.Add(prm12);

                OracleParameter prm13 = new OracleParameter("pexecname", OracleType.VarChar, 50);
                prm13.Direction = ParameterDirection.Input;
                //if (clientname == "")
                //{

                prm13.Value = System.DBNull.Value;
                //}
                //else
                //{
                //    prm11.Value = clientname;
                //}
                objOraclecommand.Parameters.Add(prm13);


                objOraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;










                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }

        }

        public DataSet firstresult(string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("firstcontract.firstcontract_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);



                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);





                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }
        }

        public DataSet bindadvcategory(string compcode, string adtype)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("bindcatforcontract.bindcatforcontract_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);



                OracleParameter prm2 = new OracleParameter("adtype", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = adtype;
                objOraclecommand.Parameters.Add(prm2);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;






                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }


        }

        public DataSet publication(string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("bindpublication.bindpublication_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;




                //objOraclecommand.Parameters.Add("@userid", SqlDbType.VarChar);
                //objOraclecommand.Parameters["@userid"].Value = userid;



                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }

        }

        public DataSet supplimentbind(string compcode, string editioncode)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("bindsuppliment.bindsuppliment_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);



                //objOraclecommand.Parameters.Add("@userid", SqlDbType.VarChar);
                //objOraclecommand.Parameters["@userid"].Value = userid;

                OracleParameter prm2 = new OracleParameter("editioncode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = editioncode;
                objOraclecommand.Parameters.Add(prm2);


                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;






                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }

        }

        public DataSet editionbind(string compcode, string pubcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("bindedition.bindedition_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);



                OracleParameter prm2 = new OracleParameter("pubcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = pubcode;
                objOraclecommand.Parameters.Add(prm2);

                objOraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;








                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }

        }

        public DataSet citybind(string compcode, string userid)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("bindcity.bindcity_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);



                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);





                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }

        }

        public DataSet packagebind(string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("bindpackage.bindpackage_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                objOraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;


                objOraclecommand.Parameters.Add("P_Accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts1"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }
        }
        public DataSet TV_packagebind(string compcode, string adtype, string channel)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("TV_packagebind", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("adtype", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = adtype;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm2a = new OracleParameter("channel_p", OracleType.VarChar, 50);
                prm2a.Direction = ParameterDirection.Input;
                prm2a.Value = channel;
                objOraclecommand.Parameters.Add(prm2a);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;




                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }
        }
        public DataSet packagebindActive(string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("bindpackageActive.bindpackageActive_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                objOraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;



                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }
        }
        public DataSet bindpackage_DateWise(string compcode, string userid,string dtime,string dateformat)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("bindpackageActiveDateWise.bindpackageActiveDateWise_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm7c = new OracleParameter("date_p", OracleType.VarChar, 50);
                prm7c.Direction = ParameterDirection.Input;
                if (dtime == "")
                {
                    prm7c.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = dtime.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        dtime = mm + "/" + dd + "/" + yy;
                    }

                    prm7c.Value = Convert.ToDateTime(dtime).ToString("dd-MMMM-yyyy");
                }
                // prm7c.Value = validfrom_p;
                objOraclecommand.Parameters.Add(prm7c);


                objOraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;



                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }
        }
        //Edition status ***************************************************************************
        public void clspackagestatus(string compcode, string userid, string ad_type, string pkgcode, string pkgstatus, string editionname)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            objOracleConnection = GetConnection();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_savepkgstatus", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("ad_type", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = ad_type;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("pkgcode", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = pkgcode;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("pkgstatus", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = pkgstatus;
                objOraclecommand.Parameters.Add(prm5);


                OracleParameter prm6 = new OracleParameter("editioncode", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = editionname;
                objOraclecommand.Parameters.Add(prm6);



                

                objOraclecommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }

        }

        public void clsmodifypackagestatus(string compcode, string ad_type, string pkgcode, string pkgstatus, string recordid, string editionname)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            objOracleConnection = GetConnection();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_modifypkgstatus", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm3 = new OracleParameter("adtype1", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = ad_type;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("pkgcode", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = pkgcode;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm2 = new OracleParameter("pkgstatus", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = pkgstatus;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm5 = new OracleParameter("recordid", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = recordid;
                objOraclecommand.Parameters.Add(prm5);


                OracleParameter prm6 = new OracleParameter("editioncode", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = editionname;
                objOraclecommand.Parameters.Add(prm6);


                objOraclecommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }

        }

        public void clsdeletepackagestatus(string compcode, string ad_type, string pkgcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            objOracleConnection = GetConnection();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_deletepkgstatus", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm3 = new OracleParameter("adtype1", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = ad_type;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("pkgcode", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = pkgcode;
                objOraclecommand.Parameters.Add(prm4);

                objOraclecommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }

        }

        public DataSet clsexistpackagestatus(string compcode, string ad_type, string pkgcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            objOracleConnection = GetConnection();
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_existpkgstatus.websp_existpkgstatus_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm3 = new OracleParameter("ad_type", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = ad_type;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("pkgcode", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = pkgcode;
                objOraclecommand.Parameters.Add(prm4);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }

        }

        public DataSet clsbindEntry(string compcode, string ad_type, string pkgcode, string pkgstatus)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            objOracleConnection = GetConnection();
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_bindEntry.websp_bindEntry_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm3 = new OracleParameter("ad_type1", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                if (ad_type == "0" || ad_type == "")
                    prm3.Value = System.DBNull.Value;
                else
                    prm3.Value = ad_type;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("pkgcode", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                if (pkgcode == "0" || pkgcode == "")
                    prm4.Value = System.DBNull.Value;
                else
                    prm4.Value = pkgcode;

                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("pkgstatus", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                if (pkgstatus == "0" || pkgstatus == "")
                    prm5.Value = System.DBNull.Value;
                else
                    prm5.Value = pkgstatus;

                objOraclecommand.Parameters.Add(prm5);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }

        }
        //******************************************************************************************


        public DataSet colorbind(string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("bindcolor.bindcolor_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);



                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }
        }

        public DataSet premiumbind(string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("bindpremium.bindpremium_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);



                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;






                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }
        }

        public DataSet uombind(string compcode, string userid, string adType)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("binduom.binduom_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("adType", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = adType;
                objOraclecommand.Parameters.Add(prm3);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;
                ////objOraclecommand.Parameters.Add("p_accounts1", OracleType.Cursor);
                ////objOraclecommand.Parameters["p_accounts1"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }
        }

        public DataSet bindgrid(string compcode, string userid, string dealno, string value)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                //objOraclecommand = GetCommand("bindgridforcontract", ref objOracleConnection);
                objOraclecommand = GetCommand("bindgridforcontract_lata.bindgridforcontract_lata_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);



                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);



                OracleParameter prm3 = new OracleParameter("dealno", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = dealno;
                objOraclecommand.Parameters.Add(prm3);



                OracleParameter prm4 = new OracleParameter("value1", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = value;
                objOraclecommand.Parameters.Add(prm4);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }
        }


        public void insertdetail(string dealno, string advcat, string publication, string suppli, string edition, string bookedfor, string color, string cardrate, string dealrate, string premium, string cardprem, string dealprem, string volbilled, string voldisc, string valfrom, string valto, string uom, string package, string compcode, string userid, string totalrate, string currency, string ratecode, string flag, string quantity, string weight, string free, string cyoppac, string deviation, string remarks, string sizefrom, string sizeto, string disctype, string discper, string insertion, string dayname, string comm_allow, string deal_start, string incentive)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            //   OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("insertvaluecontract.insertvaluecontract_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userid;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("dealno", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = dealno;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm6 = new OracleParameter("advcat", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = advcat;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("publication", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = publication;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("suppli", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = suppli;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("edition", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = edition;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("bookedfor", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = bookedfor;
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("color", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = color;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("cardrate", OracleType.VarChar, 50);
                prm12.Direction = ParameterDirection.Input;
                if (cardrate == "" || cardrate == "null")
                {
                    prm12.Value = System.DBNull.Value;
                }
                else
                {
                    prm12.Value = cardrate;
                }
                objOraclecommand.Parameters.Add(prm12);

                OracleParameter prm13 = new OracleParameter("dealrate", OracleType.VarChar, 50);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = dealrate;
                objOraclecommand.Parameters.Add(prm13);

                OracleParameter prm14 = new OracleParameter("dealprem", OracleType.VarChar, 50);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = dealprem;
                objOraclecommand.Parameters.Add(prm14);

                OracleParameter prm15 = new OracleParameter("premium", OracleType.VarChar, 50);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = premium;
                objOraclecommand.Parameters.Add(prm15);

                OracleParameter prm16 = new OracleParameter("volbilled", OracleType.VarChar, 50);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = volbilled;
                objOraclecommand.Parameters.Add(prm16);

                OracleParameter prm17 = new OracleParameter("cardprem", OracleType.VarChar, 50);
                prm17.Direction = ParameterDirection.Input;
                prm17.Value = cardprem;
                objOraclecommand.Parameters.Add(prm17);

                OracleParameter prm18 = new OracleParameter("voldisc", OracleType.VarChar, 50);
                prm18.Direction = ParameterDirection.Input;
                prm18.Value = voldisc;
                objOraclecommand.Parameters.Add(prm18);

                OracleParameter prm19 = new OracleParameter("valfrom", OracleType.VarChar, 50);
                prm19.Direction = ParameterDirection.Input;
                if (valfrom == "" || valfrom == "null")
                {
                    prm19.Value = System.DBNull.Value;
                }
                else
                {
                    //prm19.Value =Convert.ToDateTime(valfrom).ToString("dd-MMMM-yyyy");
                    prm19.Value = valfrom;
                }
                objOraclecommand.Parameters.Add(prm19);

                OracleParameter prm20 = new OracleParameter("valto", OracleType.VarChar, 50);
                prm20.Direction = ParameterDirection.Input;
                if (valto == "" || valto == "null")
                {
                    prm20.Value = System.DBNull.Value;
                }
                else
                {
                    //prm20.Value =Convert.ToDateTime(valto).ToString("dd-MMMM-yyyy");
                    prm20.Value = valto;
                }
                objOraclecommand.Parameters.Add(prm20);

                OracleParameter prm21 = new OracleParameter("uom", OracleType.VarChar, 50);
                prm21.Direction = ParameterDirection.Input;
                prm21.Value = uom;
                objOraclecommand.Parameters.Add(prm21);

                OracleParameter prm22 = new OracleParameter("PACKAGE1", OracleType.VarChar, 50);
                prm22.Direction = ParameterDirection.Input;
                prm22.Value = package;
                objOraclecommand.Parameters.Add(prm22);

                OracleParameter prm23 = new OracleParameter("totalrate", OracleType.VarChar, 50);
                prm23.Direction = ParameterDirection.Input;
                if (totalrate == "" || totalrate == "null")
                {
                    prm23.Value = System.DBNull.Value;
                }
                else
                {
                    prm23.Value = Convert.ToInt32(totalrate);
                }
                objOraclecommand.Parameters.Add(prm23);

                OracleParameter prm5 = new OracleParameter("currency", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = currency;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm26 = new OracleParameter("flag", OracleType.VarChar, 50);
                prm26.Direction = ParameterDirection.Input;
                prm26.Value = flag;
                objOraclecommand.Parameters.Add(prm26);

                OracleParameter prm27 = new OracleParameter("ratecod", OracleType.VarChar, 50);
                prm27.Direction = ParameterDirection.Input;
                prm27.Value = ratecode;
                objOraclecommand.Parameters.Add(prm27);

                OracleParameter prm2 = new OracleParameter("cyoppac", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = cyoppac;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm24 = new OracleParameter("quantity", OracleType.VarChar, 50);
                prm24.Direction = ParameterDirection.Input;
                if (quantity == "" || quantity == "null")
                {
                    prm24.Value = System.DBNull.Value;
                }
                else
                {
                    prm24.Value = Convert.ToInt32(quantity);
                }
                objOraclecommand.Parameters.Add(prm24);

                OracleParameter prm25 = new OracleParameter("weight", OracleType.VarChar, 50);
                prm25.Direction = ParameterDirection.Input;
                if (weight == "" || weight == "null")
                {
                    prm25.Value = System.DBNull.Value;
                }
                else
                {
                    prm25.Value = Convert.ToInt32(weight);
                }
                objOraclecommand.Parameters.Add(prm25);

                OracleParameter prm28 = new OracleParameter("deviation", OracleType.VarChar, 50);
                prm28.Direction = ParameterDirection.Input;
                if (deviation == "" || deviation == "null")
                {
                    prm28.Value = System.DBNull.Value;
                }
                else
                {
                    prm28.Value = Convert.ToInt32(deviation);
                }
                objOraclecommand.Parameters.Add(prm28);

                OracleParameter prm29 = new OracleParameter("free", OracleType.VarChar, 50);
                prm29.Direction = ParameterDirection.Input;
                prm29.Value = free;
                objOraclecommand.Parameters.Add(prm29);

                OracleParameter prm30 = new OracleParameter("REMARK", OracleType.VarChar, 50);
                prm30.Direction = ParameterDirection.Input;
                prm30.Value = remarks;
                objOraclecommand.Parameters.Add(prm30);

                OracleParameter prm31 = new OracleParameter("SIZEFROM", OracleType.VarChar, 50);
                prm31.Direction = ParameterDirection.Input;
                prm31.Value = sizefrom;
                objOraclecommand.Parameters.Add(prm31);

                OracleParameter prm32 = new OracleParameter("SIZETO", OracleType.VarChar, 50);
                prm32.Direction = ParameterDirection.Input;
                prm32.Value = sizeto;
                objOraclecommand.Parameters.Add(prm32);


                OracleParameter prm33 = new OracleParameter("DISCTYPE", OracleType.VarChar, 50);
                prm33.Direction = ParameterDirection.Input;
                prm33.Value = disctype;
                objOraclecommand.Parameters.Add(prm33);

                OracleParameter prm34 = new OracleParameter("DISCPER", OracleType.VarChar, 50);
                prm34.Direction = ParameterDirection.Input;
                prm34.Value = discper;
                objOraclecommand.Parameters.Add(prm34);


                OracleParameter prm35 = new OracleParameter("INSERTION", OracleType.VarChar, 50);
                prm35.Direction = ParameterDirection.Input;
                prm35.Value = insertion;
                objOraclecommand.Parameters.Add(prm35);

                OracleParameter prm36 = new OracleParameter("DAYNAME", OracleType.VarChar, 50);
                prm36.Direction = ParameterDirection.Input;
                prm36.Value = dayname;
                objOraclecommand.Parameters.Add(prm36);

                OracleParameter prm37 = new OracleParameter("comm_allow", OracleType.VarChar, 50);
                prm37.Direction = ParameterDirection.Input;
                prm37.Value = comm_allow;
                objOraclecommand.Parameters.Add(prm37);

                OracleParameter prm38 = new OracleParameter("deal_start1", OracleType.VarChar, 50);
                prm38.Direction = ParameterDirection.Input;
                prm38.Value = deal_start;
                objOraclecommand.Parameters.Add(prm38);

                OracleParameter prm39 = new OracleParameter("incentive1", OracleType.VarChar, 50);
                prm39.Direction = ParameterDirection.Input;
                prm39.Value = incentive;
                objOraclecommand.Parameters.Add(prm39);

                objOraclecommand.ExecuteNonQuery();

                ////objorclDataAdapter.SelectCommand = objOraclecommand;
                ////objorclDataAdapter.Fill(objDataSet);

                ////return objDataSet;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }

        }
        public DataSet getfromcontractdetail(string compcode, string userid, string formcode, string dealcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("getvalueofcontractdetail.getvalueofcontractdetail_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);



                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);



                OracleParameter prm3 = new OracleParameter("formcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = formcode;
                objOraclecommand.Parameters.Add(prm3);



                OracleParameter prm4 = new OracleParameter("dealcode", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = dealcode;
                objOraclecommand.Parameters.Add(prm4);

                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;





                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }

        }



        public DataSet updatedetail(string dealno, string advcat, string publication, string suppli, string edition, string bookedfor, string color, string cardrate, string dealrate, string premium, string cardprem, string dealprem, string volbilled, string voldisc, string valfrom, string valto, string uom, string package, string compcode, string userid, string dealvalue, string totalrate, string currency, string editdisc, string flag, string quantity, string weight, string free, string cyoppac, string deviation, string remarks, string sizefrom, string sizeto, string disctype, string discper, string insertion, string dayname, string comm_allow, string deal_start, string incentive)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("updatevalueforcontract.updatevalueforcontract_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userid;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm5 = new OracleParameter("dealno", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = dealno;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm7 = new OracleParameter("advcat", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = advcat;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("publication", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = publication;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("suppli", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = suppli;
                objOraclecommand.Parameters.Add(prm9);



                OracleParameter prm10 = new OracleParameter("edition", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = edition;
                objOraclecommand.Parameters.Add(prm10);



                OracleParameter prm11 = new OracleParameter("bookedfor", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = bookedfor;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("color", OracleType.VarChar, 50);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = color;
                objOraclecommand.Parameters.Add(prm12);



                OracleParameter prm13 = new OracleParameter("cardrate", OracleType.VarChar, 50);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = cardrate;
                objOraclecommand.Parameters.Add(prm13);



                OracleParameter prm14 = new OracleParameter("dealrate", OracleType.VarChar, 50);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = dealrate;
                objOraclecommand.Parameters.Add(prm14);

                OracleParameter prm15 = new OracleParameter("dealprem", OracleType.VarChar, 50);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = dealprem;
                objOraclecommand.Parameters.Add(prm15);




                OracleParameter prm16 = new OracleParameter("premium", OracleType.VarChar, 50);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = premium;
                objOraclecommand.Parameters.Add(prm16);




                OracleParameter prm17 = new OracleParameter("volbilled", OracleType.VarChar, 50);
                prm17.Direction = ParameterDirection.Input;
                prm17.Value = volbilled;
                objOraclecommand.Parameters.Add(prm17);




                OracleParameter prm18 = new OracleParameter("cardprem", OracleType.VarChar, 50);
                prm18.Direction = ParameterDirection.Input;
                prm18.Value = cardprem;
                objOraclecommand.Parameters.Add(prm18);



                OracleParameter prm19 = new OracleParameter("voldisc", OracleType.VarChar, 50);
                prm19.Direction = ParameterDirection.Input;
                prm19.Value = voldisc;
                objOraclecommand.Parameters.Add(prm19);



                OracleParameter prm20 = new OracleParameter("valfrom", OracleType.VarChar, 50);
                prm20.Direction = ParameterDirection.Input;
                if (valfrom == "" || valfrom == "null")
                {
                    prm20.Value = System.DBNull.Value;
                }
                else
                {
                    //prm20.Value = Convert.ToDateTime(valfrom).ToString("dd-MMMM-yyyy");
                    prm20.Value = valfrom;
                }
                objOraclecommand.Parameters.Add(prm20);



                OracleParameter prm21 = new OracleParameter("valto", OracleType.VarChar, 50);
                prm21.Direction = ParameterDirection.Input;
                if (valto == "" || valto == "null")
                {
                    prm21.Value = System.DBNull.Value;
                }
                else
                {
                    //prm21.Value = Convert.ToDateTime(valto).ToString("dd-MMMM-yyyy");
                    prm21.Value = valto;
                }
                objOraclecommand.Parameters.Add(prm21);



                OracleParameter prm22 = new OracleParameter("uom", OracleType.VarChar, 50);
                prm22.Direction = ParameterDirection.Input;
                prm22.Value = uom;
                objOraclecommand.Parameters.Add(prm22);

                OracleParameter prm23 = new OracleParameter("package1", OracleType.VarChar, 50);
                prm23.Direction = ParameterDirection.Input;
                prm23.Value = package;
                objOraclecommand.Parameters.Add(prm23);


                OracleParameter prm24 = new OracleParameter("dealvalue", OracleType.VarChar, 50);
                prm24.Direction = ParameterDirection.Input;
                prm24.Value = dealvalue;
                objOraclecommand.Parameters.Add(prm24);



                OracleParameter prm25 = new OracleParameter("totalrate", OracleType.VarChar, 50);
                prm25.Direction = ParameterDirection.Input;
                if (totalrate == "" || totalrate == "null")
                {
                    prm25.Value = System.DBNull.Value; ;
                }
                else
                {
                    prm25.Value = Convert.ToInt32(totalrate);
                }
                objOraclecommand.Parameters.Add(prm25);

                OracleParameter prm6 = new OracleParameter("currency", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = currency;
                objOraclecommand.Parameters.Add(prm6);


                OracleParameter prm26 = new OracleParameter("flag", OracleType.VarChar, 50);
                prm26.Direction = ParameterDirection.Input;
                prm26.Value = flag;
                objOraclecommand.Parameters.Add(prm26);

                OracleParameter prm27 = new OracleParameter("editdisc", OracleType.VarChar, 50);
                prm27.Direction = ParameterDirection.Input;
                if (editdisc == "" || editdisc == "null")
                {
                    prm27.Value = System.DBNull.Value;
                }
                else
                {
                    prm27.Value = editdisc;
                }
                objOraclecommand.Parameters.Add(prm27);

                OracleParameter prm28 = new OracleParameter("quantity", OracleType.VarChar, 50);
                prm28.Direction = ParameterDirection.Input;
                if (quantity == "" || quantity == "null")
                {
                    prm28.Value = System.DBNull.Value;
                }
                else
                {
                    prm28.Value = Convert.ToInt32(quantity);
                }
                objOraclecommand.Parameters.Add(prm28);


                OracleParameter prm29 = new OracleParameter("weight", OracleType.VarChar, 50);
                prm29.Direction = ParameterDirection.Input;
                if (weight == "" || weight == "null")
                {
                    prm29.Value = System.DBNull.Value;
                }
                else
                {
                    prm29.Value = Convert.ToInt32(weight);
                }
                objOraclecommand.Parameters.Add(prm29);



                OracleParameter prm4 = new OracleParameter("free", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = free;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm2 = new OracleParameter("cyoppac", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = cyoppac;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm30 = new OracleParameter("deviation", OracleType.VarChar, 50);
                prm30.Direction = ParameterDirection.Input;
                if (deviation == "" || deviation == "null")
                {
                    prm30.Value = System.DBNull.Value;
                }
                else
                {
                    prm30.Value = Convert.ToInt32(deviation);
                }
                objOraclecommand.Parameters.Add(prm30);


                OracleParameter prm31 = new OracleParameter("remark1", OracleType.VarChar, 50);
                prm31.Direction = ParameterDirection.Input;
                prm31.Value = remarks;
                objOraclecommand.Parameters.Add(prm31);

                OracleParameter prm32 = new OracleParameter("sizefrom1", OracleType.VarChar, 50);
                prm32.Direction = ParameterDirection.Input;
                prm32.Value = sizefrom;
                objOraclecommand.Parameters.Add(prm32);

                OracleParameter prm33 = new OracleParameter("sizeto1", OracleType.VarChar, 50);
                prm33.Direction = ParameterDirection.Input;
                prm33.Value = sizeto;
                objOraclecommand.Parameters.Add(prm33);

                OracleParameter prm34 = new OracleParameter("discper1", OracleType.VarChar, 50);
                prm34.Direction = ParameterDirection.Input;
                prm34.Value = discper;
                objOraclecommand.Parameters.Add(prm34);


                OracleParameter prm35 = new OracleParameter("disctype1", OracleType.VarChar, 50);
                prm35.Direction = ParameterDirection.Input;
                prm35.Value = disctype;
                objOraclecommand.Parameters.Add(prm35);

                OracleParameter prm36 = new OracleParameter("insertion1", OracleType.VarChar, 50);
                prm36.Direction = ParameterDirection.Input;
                prm36.Value = insertion;
                objOraclecommand.Parameters.Add(prm36);

                OracleParameter prm37 = new OracleParameter("dayname1", OracleType.VarChar, 50);
                prm37.Direction = ParameterDirection.Input;
                prm37.Value = dayname;
                objOraclecommand.Parameters.Add(prm37);

                OracleParameter prm39 = new OracleParameter("comm_allow", OracleType.VarChar, 50);
                prm39.Direction = ParameterDirection.Input;
                prm39.Value = comm_allow;
                objOraclecommand.Parameters.Add(prm39);

                OracleParameter prm40 = new OracleParameter("deal_start1", OracleType.VarChar, 50);
                prm40.Direction = ParameterDirection.Input;
                prm40.Value = deal_start;
                objOraclecommand.Parameters.Add(prm40);

                OracleParameter prm41 = new OracleParameter("incentive1", OracleType.VarChar, 50);
                prm41.Direction = ParameterDirection.Input;
                prm41.Value = incentive;
                objOraclecommand.Parameters.Add(prm41);

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }

        }

        public object deletecontractdetail(string compcode, string userid, string dealvalue)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("deletecontractdetail.deletecontractdetail_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);



                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);



                OracleParameter prm3 = new OracleParameter("dealvalue", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = dealvalue;
                objOraclecommand.Parameters.Add(prm3);






                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }

        }



        public object deletecontractdeta(string compcode, string userid, string dealvalue)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("deletecontractdetail.deletecontractdetail_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);



                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);



                OracleParameter prm3 = new OracleParameter("dealvalue", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = dealvalue;
                objOraclecommand.Parameters.Add(prm3);






                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }
        }

        public DataSet contractdelete(string compcode, string userid, string dealvalue)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("deletecontractdetail.deletecontractdetail_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);



                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);



                OracleParameter prm3 = new OracleParameter("dealvalue", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = Convert.ToInt32(dealvalue);
                objOraclecommand.Parameters.Add(prm3);
                /*
                objOraclecommand.Parameters.Add("@dealvalue", SqlDbType.Int);
                objOraclecommand.Parameters["@dealvalue"].Value = Convert.ToInt32(dealvalue);

                */



                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }

        }

        public DataSet autogenrated(string compcode, string userid, string deal)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("autogeneratedeal.autogeneratedeal_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);



                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);



                OracleParameter prm3 = new OracleParameter("deal", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = deal;
                objOraclecommand.Parameters.Add(prm3);

                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;









                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }

        }


        public DataSet chkincontractdetail(string DealNo, string compcode, string userid)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("checkcontractdetail.checkcontractdetail_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("DealNo", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = DealNo;

                objOraclecommand.Parameters.Add(prm3);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }

        }

        public DataSet currencybind(string compcode, string userid)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("bindcurrency.bindcurrency_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);



                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;








                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }

        }

        public DataSet description(string packagecode, string compcode, string userid)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("binddescriptionforcontrcat.binddescriptionforcontrcat_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);



                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);



                OracleParameter prm3 = new OracleParameter("packagecode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = packagecode;
                objOraclecommand.Parameters.Add(prm3);

                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;











                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }

        }

        public DataSet convertrate(string currcode, string compcode, string userid)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("getconverrate.getconverrate_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);



                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);



                OracleParameter prm3 = new OracleParameter("currcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = currcode;
                objOraclecommand.Parameters.Add(prm3);



                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;





                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }

        }

        public DataSet discvalue(string discount, string compcode, string userid, string username)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("getdiscount.getdiscount_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);



                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);



                OracleParameter prm3 = new OracleParameter("discount", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = discount;
                objOraclecommand.Parameters.Add(prm3);



                OracleParameter prm4 = new OracleParameter("username", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = username;
                objOraclecommand.Parameters.Add(prm4);

                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }

        }

        public DataSet bindexec(string compcode, string userid, string name)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("bindexec.bindexec_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);



                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);



                OracleParameter prm3 = new OracleParameter("name", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = name;
                objOraclecommand.Parameters.Add(prm3);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;












                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }


        }

        public DataSet currbind(string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("currbind.currbind_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);






                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }


        }

        public DataSet currencychecked(string dealcode, string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("currencydeal.currencydeal_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);



                OracleParameter prm2 = new OracleParameter("dealcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = dealcode;
                objOraclecommand.Parameters.Add(prm2);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;






                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }
        }

        public void deletecontractdeta(string code, string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            // OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("deletecontract.deletecontract_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("code", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = code;
                objOraclecommand.Parameters.Add(prm2);

                objOraclecommand.ExecuteNonQuery();

                ////objorclDataAdapter.SelectCommand = objOraclecommand;
                ////objorclDataAdapter.Fill(objDataSet);
                ////return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }

        }


        public DataSet bindname(string compcode)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("bindteamname.bindteamname_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;










                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }

        }

        public DataSet binddeal(string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("binddealtype.binddealtype_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }

        }


        public DataSet packagechk(string package, string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("packagechkcontract.packagechkcontract_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);



                OracleParameter prm2 = new OracleParameter("package", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = package;
                objOraclecommand.Parameters.Add(prm2);





                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }


        }

        public DataSet chkweight(string weight, string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("chkweight.chkweight_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);



                OracleParameter prm2 = new OracleParameter("weight", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = weight;
                objOraclecommand.Parameters.Add(prm2);


                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;







                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }


        }

        public DataSet getrateforcontract(string adcat, string pkgcode, string color, string currency, string uom, string advtype, string datefrom, string dateto, string compcode, string dateformat, string premium)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("contr_getpkgrate.contr_getpkgrate_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("adcat", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = adcat;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("pkgcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = pkgcode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("color", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = color;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("currency", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = currency;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("uom", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = uom;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("advtype", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = advtype;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("datefrom", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                if (datefrom == "")
                {
                    prm8.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = datefrom.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        datefrom = mm + "/" + dd + "/" + yy;
                    }

                    prm8.Value = Convert.ToDateTime(datefrom).ToString("dd-MMMM-yyyy");
                }

                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("dateto", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                if (dateto == "")
                {
                    prm9.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = dateto.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        dateto = mm + "/" + dd + "/" + yy;
                    }
                    prm9.Value = Convert.ToDateTime(dateto).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm9);


                OracleParameter prm10 = new OracleParameter("ppremium", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                if (premium == "" || premium == null)
                {
                    prm10.Value = "0";
                }
                else
                {
                    prm10.Value = premium;
                }
                objOraclecommand.Parameters.Add(prm10);


                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }
        }
        public DataSet chkunique(string agency, string client, string prod, string compcode, string adtype, string mod)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("chkuniquecontractmaster.chkuniquecontractmaster_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("agency", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = agency;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("client", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = client;
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("prod", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = prod;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = compcode;
                objOraclecommand.Parameters.Add(prm4);


                OracleParameter prm5 = new OracleParameter("MOD1", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = mod;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("adtype", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = adtype;
                objOraclecommand.Parameters.Add(prm6);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }

        }
        public DataSet packagebind_n(string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("bindpackageActive1.bindpackageActive1_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                objOraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;


                objOraclecommand.Parameters.Add("P_Accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts1"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }
        }
        public DataSet chkuniquedetail(string adcat, string pkgcode, string ratecode, string color, string compcode, string mod, string day1)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("chkuniquecontractdetail.chkuniquecontractdetail_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("adcat", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = adcat;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("pkgcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = pkgcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("ratecode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = ratecode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = compcode;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("color", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = color;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("mod1", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = mod;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("day1", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = day1;
                objOraclecommand.Parameters.Add(prm7);


                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }

        }


        public DataSet modchek(string compcode, string dealno)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("cheackdeal", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm1a = new OracleParameter("dealno", OracleType.VarChar, 50);
                prm1a.Direction = ParameterDirection.Input;
                prm1a.Value = dealno;
                objOraclecommand.Parameters.Add(prm1a);

                objOraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }
        }



        public DataSet getcontract(string compcode, string contaract)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("BINDDEALforf2", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("p_compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("p_dealname", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = contaract;
                objOraclecommand.Parameters.Add(prm2);




                objOraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }
        }



        public DataSet pagepremiumbind(string compcode, string prem)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("bindadvposition", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("p_compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("p_name", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = prem;
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("extra1", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = "";
                objOraclecommand.Parameters.Add(prm3);


                OracleParameter prm4 = new OracleParameter("extra2", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = "";
                objOraclecommand.Parameters.Add(prm4);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;





                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return (objDataSet);


            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }
        }


        public DataSet getposprem(string compcode, string Premcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("bind_pos_amount", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("Poscode", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = Premcode;
                objOraclecommand.Parameters.Add(prm2);




                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }
        }




        public DataSet Editionbind_n(string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("bindeditionActive1.bindeditionActive1_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                objOraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;


                objOraclecommand.Parameters.Add("P_Accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts1"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }
        }



        public DataSet inserteditname(string txteditionname, string txtdate, string txtaddate, string compcode, string userid, string editcode, string year)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("dealmarketshare", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pcompcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = txteditionname;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("pdaelno", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = txtdate;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("ppublication", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = txtaddate;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("ppubcent", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = compcode;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("pmarkertshare", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = userid;
                objOraclecommand.Parameters.Add(prm5);


                



                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                CloseConnection(ref objOracleConnection);
            }
        }

        public DataSet binddealmarshare(string compcode, string edtioncode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("bind_dealmarshare", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pcompcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("pdealno", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = edtioncode;
                objOraclecommand.Parameters.Add(prm2);





                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;




                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;



            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }

        }

        public DataSet dealshare(string code, string compcode, string userid)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("binddealmarshare.binddealmarshare_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("code", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = code;
                objOraclecommand.Parameters.Add(prm3);

                //OracleParameter prm4 = new OracleParameter("date1", OracleType.VarChar, 50);
                //prm4.Direction = ParameterDirection.Input;
                //prm4.Value = date;
                //objOraclecommand.Parameters.Add(prm4);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;




                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                CloseConnection(ref objOracleConnection);
            }
        }

        public DataSet chkdaetdeal(string compcode, string editcode)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("chkdatdeal.chkdatdeal_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm3 = new OracleParameter("editcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = editcode;
                objOraclecommand.Parameters.Add(prm3);

                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                CloseConnection(ref objOracleConnection);
            }
        }

        public DataSet selectedfromgrid(string editcode, string compcode, string userid, string code10)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("selectfromeditDEAL.selectfromeditDEAL_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("editcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = editcode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("code10", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = code10;
                objOraclecommand.Parameters.Add(prm4);


                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;


                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                CloseConnection(ref objOracleConnection);
            }
        }

        public DataSet publication(string compcode, string pubcent)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("publication", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("pcompcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("ppubcentcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = pubcent;
                objOraclecommand.Parameters.Add(prm2);

                
                //OracleParameter prm4 = new OracleParameter("date1", OracleType.VarChar, 50);
                //prm4.Direction = ParameterDirection.Input;
                //prm4.Value = date;
                //objOraclecommand.Parameters.Add(prm4);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;




                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                CloseConnection(ref objOracleConnection);
            }
        }

        public DataSet pub_centbind(string compcode, string useid, string chk_acc)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("bind_pubcentname_new", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter top2 = new OracleParameter("p_comp_code", OracleType.VarChar);
                top2.Direction = ParameterDirection.Input;
                top2.Value = compcode;
                objOraclecommand.Parameters.Add(top2);

                OracleParameter prm1 = new OracleParameter("p_userid", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = useid;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("p_extra1", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = chk_acc;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("p_extra2", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm3);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (OracleException objException)
            {
                throw (objException);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }

        }

        public DataSet griddelete(string editcode, string compcode, string userid, string code10)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("deletegriddealmarket.deletegriddealmarket_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = editcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("editcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("code10", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm4);

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                CloseConnection(ref objOracleConnection);
            }
        }

        public DataSet gridupdate(string txteditionname, string txtdate, string txtaddate, string compcode, string editcode)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("UpdateDEALMARKET.UpdateDEALMARKET_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                //OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                //prm2.Direction = ParameterDirection.Input;
                //prm2.Value = userid;
                //objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("txteditionname", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = txteditionname;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("txtdate", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = txtdate;
                objOraclecommand.Parameters.Add(prm4);



                OracleParameter prm5 = new OracleParameter("txtaddate", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = txtaddate;
                objOraclecommand.Parameters.Add(prm5);



                OracleParameter prm6 = new OracleParameter("editcode", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = editcode;
                objOraclecommand.Parameters.Add(prm6);

                //OracleParameter prm7 = new OracleParameter("code10", OracleType.VarChar, 50);
                //prm7.Direction = ParameterDirection.Input;
                //prm7.Value = code10;
                //objOraclecommand.Parameters.Add(prm7);

                //OracleParameter prm8 = new OracleParameter("year1", OracleType.VarChar, 50);
                //prm8.Direction = ParameterDirection.Input;
                //prm8.Value = year;
                //objOraclecommand.Parameters.Add(prm8);





                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                CloseConnection(ref objOracleConnection);
            }
        }
    }


}
