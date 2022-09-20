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
    /// Summary description for Contract
    /// </summary>
    public class Contract:connection
    {
        public Contract()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataSet bindgridContract(string compcode, string userid, string values, string adcat)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();

                if (adcat == "0")
                {
                    objmysqlcommand = GetCommand("bindcontract", ref objmysqlconnection);
                    objmysqlcommand.CommandType = CommandType.StoredProcedure;

                    objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                    objmysqlcommand.Parameters["compcode"].Value = compcode;

                    objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                    objmysqlcommand.Parameters["userid"].Value = userid;
                    if (values == null)
                    {
                        values = "";
                    }
                    objmysqlcommand.Parameters.Add("values", MySqlDbType.VarChar);
                    objmysqlcommand.Parameters["values"].Value = values;
                }


                else
                {

                    objmysqlcommand = GetCommand("getedibyvat", ref objmysqlconnection);
                    objmysqlcommand.CommandType = CommandType.StoredProcedure;

                    objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                    objmysqlcommand.Parameters["compcode"].Value = compcode;

                    objmysqlcommand.Parameters.Add("adcat", MySqlDbType.VarChar);
                    objmysqlcommand.Parameters["adcat"].Value = adcat;

                    objmysqlcommand.Parameters.Add("checkboxname", MySqlDbType.VarChar);
                    objmysqlcommand.Parameters["checkboxname"].Value = values;

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
                objSqlCommand = GetCommand("bindagencyforbooking_foraudit", ref objSqlConnection);
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

        public DataSet bindagency(string compcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("bindagencyforcontract", ref objmysqlconnection);
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





        public DataSet bindsubagency(string agency, string compcode, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("bindsubagencyforcontract", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("agency", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agency"].Value = agency;




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

        public DataSet clientbind(string compcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("bindclientforcontract", ref objmysqlconnection);
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

        public DataSet productbind(string client, string compcode, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("bindproductforcontract", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("client", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["client"].Value = client;






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

        public DataSet contractcode(string DealNo, string compcode, string dealname, string dealtype)
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("checkcontractcode", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("dealname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["dealname"].Value = dealname;

                objmysqlcommand.Parameters.Add("dealtype", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["dealtype"].Value = dealtype;

                objmysqlcommand.Parameters.Add("DealNo", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["DealNo"].Value = DealNo;

    
                




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

        public DataSet insertcontact(string DealNo, string dealname, string agencycode, string subagencycode, string clientname, string product, string validfromdate, string validtill, string representative, string compcode, string userid, string totalvalue, string totalvolume, string currencys, string teamname, string dealtype, string adtype, string remarks, string executive_var, string retainer_var, string contdate_var, string closedate_var, string servicetax_var, string caption_var, string paymode_var, string b2b, string chkmulti, string chkseq, string seqno, string chkparti, string indus, string induspro, string dealon, string attach1, string transition, string centername, string printcenter, string rono, string rodate, string rostatus, string rcptno, string rcptcurr, string quotation)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                //objmysqlcommand = GetCommand("insertcontactmast", ref objmysqlconnection);
                objmysqlcommand = GetCommand("INSERTCONTACTMAST_INSERTCONTACTMAST_P", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("teamname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["teamname"].Value = teamname;

                objmysqlcommand.Parameters.Add("dealtype", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["dealtype"].Value = dealtype;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("currencys", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["currencys"].Value = currencys;

                objmysqlcommand.Parameters.Add("DealNo", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["DealNo"].Value = DealNo;

                objmysqlcommand.Parameters.Add("dealname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["dealname"].Value = dealname;

                objmysqlcommand.Parameters.Add("totalvalue", MySqlDbType.Double);
                if (totalvalue == "")
                {
                    objmysqlcommand.Parameters["totalvalue"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["totalvalue"].Value = Convert.ToDouble(totalvalue);
                }
                objmysqlcommand.Parameters.Add("totalvolume", MySqlDbType.Double);
                if (totalvolume == "")
                {
                    objmysqlcommand.Parameters["totalvolume"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["totalvolume"].Value = Convert.ToDouble(totalvolume);
                }

                objmysqlcommand.Parameters.Add("agencycode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agencycode"].Value = agencycode;

                objmysqlcommand.Parameters.Add("subagencycode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["subagencycode"].Value = subagencycode;

                objmysqlcommand.Parameters.Add("product", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["product"].Value = product;

                objmysqlcommand.Parameters.Add("validfromdate", MySqlDbType.DateTime);
                if (validfromdate == null || validfromdate == "")
                {
                    objmysqlcommand.Parameters["validfromdate"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["validfromdate"].Value = Convert.ToDateTime(validfromdate);
                }

                objmysqlcommand.Parameters.Add("validtill", MySqlDbType.DateTime);
                if (validtill == null && validtill == "")
                {
                    objmysqlcommand.Parameters["validtill"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["validtill"].Value = Convert.ToDateTime(validtill);
                }

                objmysqlcommand.Parameters.Add("representative", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["representative"].Value = representative;

                objmysqlcommand.Parameters.Add("clientname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["clientname"].Value = clientname;

                objmysqlcommand.Parameters.Add("adtype", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adtype"].Value = adtype;

                objmysqlcommand.Parameters.Add("REMARK", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["REMARK"].Value = remarks;

                objmysqlcommand.Parameters.Add("executive_var", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["executive_var"].Value = executive_var;

                objmysqlcommand.Parameters.Add("retainer_var", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["retainer_var"].Value = retainer_var;

                //objmysqlcommand.Parameters.Add("contdate_var", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["contdate_var"].Value = contdate_var;

                objmysqlcommand.Parameters.Add("contdate_var", MySqlDbType.DateTime);
                if (contdate_var == null && contdate_var == "")
                {
                    objmysqlcommand.Parameters["contdate_var"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["contdate_var"].Value = Convert.ToDateTime(contdate_var);
                }

                //objmysqlcommand.Parameters.Add("closedate_var", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["closedate_var"].Value = closedate_var;

                objmysqlcommand.Parameters.Add("closedate_var", MySqlDbType.DateTime);
                if (closedate_var == null && closedate_var == "")
                {
                    objmysqlcommand.Parameters["closedate_var"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["closedate_var"].Value = Convert.ToDateTime(closedate_var);
                }

                objmysqlcommand.Parameters.Add("servicetax_var", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["servicetax_var"].Value = servicetax_var;

                objmysqlcommand.Parameters.Add("caption_var", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["caption_var"].Value = caption_var;

                objmysqlcommand.Parameters.Add("paymode_var", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["paymode_var"].Value = paymode_var;

                objmysqlcommand.Parameters.Add("b2b_var", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["b2b_var"].Value = b2b;

                objmysqlcommand.Parameters.Add("chkmulti_var", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["chkmulti_var"].Value = chkmulti;

                objmysqlcommand.Parameters.Add("chkseq_var", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["chkseq_var"].Value = chkseq;

                objmysqlcommand.Parameters.Add("seqno_var", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["seqno_var"].Value = seqno;

                objmysqlcommand.Parameters.Add("chkparti_var", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["chkparti_var"].Value = chkparti;

                objmysqlcommand.Parameters.Add("indus_var", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["indus_var"].Value = indus;

                objmysqlcommand.Parameters.Add("induspro_var", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["induspro_var"].Value = induspro;

                objmysqlcommand.Parameters.Add("dealon_var", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["dealon_var"].Value = dealon;

                objmysqlcommand.Parameters.Add("attachment1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["attachment1"].Value = attach1;

                objmysqlcommand.Parameters.Add("translation", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["translation"].Value = transition;

                objmysqlcommand.Parameters.Add("dealfrom", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["dealfrom"].Value = centername;

                objmysqlcommand.Parameters.Add("dealcenter", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["dealcenter"].Value = printcenter;

                objmysqlcommand.Parameters.Add("rono_p", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["rono_p"].Value = rono;

                objmysqlcommand.Parameters.Add("rodate_p", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["rodate_p"].Value = rodate;

                objmysqlcommand.Parameters.Add("rostatus_p", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["rostatus_p"].Value = rostatus;

                objmysqlcommand.Parameters.Add("rcptno_p", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["rcptno_p"].Value = rcptno;

                objmysqlcommand.Parameters.Add("rcptcurr_p", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["rcptcurr_p"].Value = rcptcurr;

                objmysqlcommand.Parameters.Add("quotion_p", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["quotion_p"].Value = quotation;

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

        public DataSet modifycontact(string DealNo, string dealname, string agencycode, string subagencycode, string clientname, string product, string validfromdate, string validtill, string representative, string compcode, string userid, string totalvalue, string totalvolume, string currencys, string teamname, string dealtype, string adtype, string remarks, string executive_var, string retainer_var, string contdate_var, string closedate_var, string servicetax_var, string caption_var, string paymode_var, string b2b, string chkmulti, string chkseq, string seqno, string chkparti, string indus, string induspro, string dealon, string attach1, string transition, string centername, string printcenter, string rono, string rodate, string rostatus, string rcptno, string rcptcurr)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("updatecontactmast_updatecontactmast_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("teamname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["teamname"].Value = teamname;

                objmysqlcommand.Parameters.Add("dealname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["dealname"].Value = dealname;

                objmysqlcommand.Parameters.Add("dealtype", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["dealtype"].Value = dealtype;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("currencys", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["currencys"].Value = currencys;

                objmysqlcommand.Parameters.Add("DealNo", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["DealNo"].Value = DealNo;

                objmysqlcommand.Parameters.Add("totalvalue", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["totalvalue"].Value = totalvalue;

                objmysqlcommand.Parameters.Add("totalvolume", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["totalvolume"].Value = totalvolume;

                objmysqlcommand.Parameters.Add("agencycode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agencycode"].Value = agencycode;

                objmysqlcommand.Parameters.Add("subagencycode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["subagencycode"].Value = subagencycode;

                objmysqlcommand.Parameters.Add("product", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["product"].Value = product;

                objmysqlcommand.Parameters.Add("validfromdate", MySqlDbType.DateTime);
                if (validfromdate == null && validfromdate == "")
                {
                    objmysqlcommand.Parameters["validfromdate"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["validfromdate"].Value = Convert.ToDateTime(validfromdate);
                }

                objmysqlcommand.Parameters.Add("validtill", MySqlDbType.DateTime);
                if (validtill == null && validtill == "")
                {
                    objmysqlcommand.Parameters["validtill"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["validtill"].Value = Convert.ToDateTime(validtill);
                }

                objmysqlcommand.Parameters.Add("representative", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["representative"].Value = representative;

                objmysqlcommand.Parameters.Add("clientname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["clientname"].Value = clientname;

                objmysqlcommand.Parameters.Add("adtype", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adtype"].Value = adtype;
                
                objmysqlcommand.Parameters.Add("REMARK", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["REMARK"].Value = remarks;

                objmysqlcommand.Parameters.Add("executive_var", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["executive_var"].Value = executive_var;

                objmysqlcommand.Parameters.Add("retainer_var", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["retainer_var"].Value = retainer_var;

                objmysqlcommand.Parameters.Add("contdate_var", MySqlDbType.DateTime);
                if (contdate_var == null && contdate_var == "")
                {
                    objmysqlcommand.Parameters["contdate_var"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["contdate_var"].Value = Convert.ToDateTime(contdate_var);
                }

                objmysqlcommand.Parameters.Add("closedate_var", MySqlDbType.DateTime);
                if (closedate_var == null && closedate_var == "")
                {
                    objmysqlcommand.Parameters["closedate_var"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["closedate_var"].Value = Convert.ToDateTime(closedate_var);
                }

                objmysqlcommand.Parameters.Add("servicetax_var", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["servicetax_var"].Value = servicetax_var;

                objmysqlcommand.Parameters.Add("caption_var", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["caption_var"].Value = caption_var;

                objmysqlcommand.Parameters.Add("paymode_var", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["paymode_var"].Value = paymode_var;

                objmysqlcommand.Parameters.Add("b2b_var", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["b2b_var"].Value = b2b;

                objmysqlcommand.Parameters.Add("chkmulti_var", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["chkmulti_var"].Value = chkmulti;

                objmysqlcommand.Parameters.Add("chkseq_var", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["chkseq_var"].Value = chkseq;

                objmysqlcommand.Parameters.Add("seqno_var", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["seqno_var"].Value = seqno;

                objmysqlcommand.Parameters.Add("chkparti_var", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["chkparti_var"].Value = chkparti;

                objmysqlcommand.Parameters.Add("indus_var", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["indus_var"].Value = indus;

                objmysqlcommand.Parameters.Add("induspro_var", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["induspro_var"].Value = induspro;

                objmysqlcommand.Parameters.Add("dealon_var", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["dealon_var"].Value = dealon;

                objmysqlcommand.Parameters.Add("attachment1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["attachment1"].Value = attach1;

                objmysqlcommand.Parameters.Add("dealfrom", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["dealfrom"].Value = centername;

                objmysqlcommand.Parameters.Add("dealcenter", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["dealcenter"].Value = printcenter;

                objmysqlcommand.Parameters.Add("translation", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["translation"].Value = transition;

                objmysqlcommand.Parameters.Add("rono_p", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["rono_p"].Value = rono;

                objmysqlcommand.Parameters.Add("rodate_p", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["rodate_p"].Value = rodate;

                objmysqlcommand.Parameters.Add("rostatus_p", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["rostatus_p"].Value = rostatus;

                objmysqlcommand.Parameters.Add("rcptno_p", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["rcptno_p"].Value = rcptno;

                objmysqlcommand.Parameters.Add("rcptcurr_p", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["rcptcurr_p"].Value = rcptcurr;

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

        public DataSet dealmodifychk(string dealno, string deal_name, string compcode, string deal_type)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("dealmodifychk_dealmodifychk_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("dealno", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["dealno"].Value = dealno;

                objmysqlcommand.Parameters.Add("dealname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["dealname"].Value = deal_name;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("dealtype", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["dealtype"].Value = deal_type;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);

                return objDataSet;


                //return objDataSet;

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

        public DataSet dealchk(string Deal_No, string deal_name, string dn)
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("dealchkforcontract", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("dealno", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["dealno"].Value = Deal_No;

                objmysqlcommand.Parameters.Add("dealname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["dealname"].Value = deal_name;

                objmysqlcommand.Parameters.Add("dn", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["dn"].Value = dn;


                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);

                return objDataSet;


                //return objDataSet;

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


        public DataSet dealautocode(string dealname)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("dealautocode", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("dealname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["dealname"].Value = dealname;

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

        public DataSet querycontract(string DealNo, string dealname, string agencycode, string subagencycode, string clientname, string product, string representative, string compcode, string userid, string dealtype, string quotation, string cont_date,string teamname,string execname)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("EXECUTECONTRACT_executecontract_P", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("DealNo", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["DealNo"].Value = DealNo;

                objmysqlcommand.Parameters.Add("dealname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["dealname"].Value = dealname;

                objmysqlcommand.Parameters.Add("agencycode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agencycode"].Value = agencycode;

                objmysqlcommand.Parameters.Add("subagencycode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["subagencycode"].Value = subagencycode;

                objmysqlcommand.Parameters.Add("representative", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["representative"].Value = representative;

                objmysqlcommand.Parameters.Add("dealtype", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["dealtype"].Value = dealtype;

                // new added
                objmysqlcommand.Parameters.Add("quotion_p", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["quotion_p"].Value = quotation;

                objmysqlcommand.Parameters.Add("clientname_p", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["clientname_p"].Value = clientname;

                objmysqlcommand.Parameters.Add("pcont_date", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pcont_date"].Value = cont_date;

                objmysqlcommand.Parameters.Add("pteamname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pteamname"].Value = teamname;

                objmysqlcommand.Parameters.Add("pexecname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pexecname"].Value = execname;

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

        public DataSet firstresult(string compcode, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("firstcontract", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

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

        public DataSet bindadvcategory(string compcode, string adtype)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("bindcatforcontract", ref objmysqlconnection);
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

        public DataSet publication(string compcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("bindpublication", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                //objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["userid"].Value = userid;



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

        public DataSet supplimentbind(string compcode, string editioncode)
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("bindsuppliment", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                //objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("editioncode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["editioncode"].Value = editioncode;



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

        public DataSet editionbind(string compcode, string pubcode)
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

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;



                objmysqlcommand.Parameters.Add("pubcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pubcode"].Value = pubcode;



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

        public DataSet citybind(string compcode, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("bindcity", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

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

        public DataSet packagebind(string compcode, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("bindpackage", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

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

        public DataSet colorbind(string compcode, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("bindcolor_bindcolor_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

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

        public DataSet premiumbind(string compcode, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("bindpremium", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

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

        public DataSet uombind(string compcode, string userid,string adtype)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("binduom", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

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

        public DataSet bindgrid(string compcode, string userid, string dealno, string value)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                //objmysqlcommand = GetCommand("bindgridforcontract", ref objmysqlconnection);
                objmysqlcommand = GetCommand("bindgridforcontract_lata", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("dealno", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["dealno"].Value = dealno;

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

        public DataSet insertdetail(string dealno, string advcat, string publication, string suppli, string edition, string bookedfor, string color, string cardrate, string dealrate, string premium, string cardprem, string dealprem, string volbilled, string voldisc, string valfrom, string valto, string uom, string package, string compcode, string userid, string totalrate, string currency, string ratecode, string flag, string quantity, string weight, string free, string cyoppac, string deviation)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("insertvaluecontract", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("cyoppac", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["cyoppac"].Value = cyoppac;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("dealno", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["dealno"].Value = dealno;

                objmysqlcommand.Parameters.Add("currency", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["currency"].Value = currency;


                objmysqlcommand.Parameters.Add("advcat", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["advcat"].Value = advcat;

                objmysqlcommand.Parameters.Add("publication", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["publication"].Value = publication;

                objmysqlcommand.Parameters.Add("suppli", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["suppli"].Value = suppli;

                objmysqlcommand.Parameters.Add("edition", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["edition"].Value = edition;

                objmysqlcommand.Parameters.Add("bookedfor", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["bookedfor"].Value = bookedfor;

                objmysqlcommand.Parameters.Add("color", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["color"].Value = color;

                objmysqlcommand.Parameters.Add("cardrate", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["cardrate"].Value = cardrate;

                objmysqlcommand.Parameters.Add("dealrate", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["dealrate"].Value = dealrate;

                objmysqlcommand.Parameters.Add("dealprem", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["dealprem"].Value = dealprem;

                objmysqlcommand.Parameters.Add("premium", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["premium"].Value = premium;

                objmysqlcommand.Parameters.Add("volbilled", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["volbilled"].Value = volbilled;

                objmysqlcommand.Parameters.Add("cardprem", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["cardprem"].Value = cardprem;

                objmysqlcommand.Parameters.Add("voldisc", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["voldisc"].Value = voldisc;

                objmysqlcommand.Parameters.Add("valfrom", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["valfrom"].Value = valfrom;

                objmysqlcommand.Parameters.Add("valto", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["valto"].Value = valto;

                objmysqlcommand.Parameters.Add("uom", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["uom"].Value = uom;

                objmysqlcommand.Parameters.Add("package", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["package"].Value = package;

                objmysqlcommand.Parameters.Add("totalrate", MySqlDbType.Int32);
                if (totalrate == "")
                {
                    objmysqlcommand.Parameters["totalrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["totalrate"].Value = Convert.ToInt32(totalrate);
                }


                objmysqlcommand.Parameters.Add("quantity", MySqlDbType.Int32);
                if (quantity == "")
                {
                    objmysqlcommand.Parameters["quantity"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["quantity"].Value = Convert.ToInt32(quantity);
                }

                objmysqlcommand.Parameters.Add("weight", MySqlDbType.Int32);
                if (weight == "")
                {
                    objmysqlcommand.Parameters["weight"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["weight"].Value = Convert.ToInt32(weight);
                }

                objmysqlcommand.Parameters.Add("flag", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["flag"].Value = flag;

                objmysqlcommand.Parameters.Add("ratecode", MySqlDbType.VarChar);

                objmysqlcommand.Parameters["ratecode"].Value = ratecode;


                objmysqlcommand.Parameters.Add("deviation", MySqlDbType.Int32);
                if (deviation == "")
                {
                    objmysqlcommand.Parameters["deviation"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["deviation"].Value = Convert.ToInt32(deviation);
                }

                objmysqlcommand.Parameters.Add("free", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["free"].Value = free;



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

        public DataSet getfromcontractdetail(string compcode, string userid, string formcode, string dealcode)
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("getvalueofcontractdetail", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("formcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["formcode"].Value = formcode;

                objmysqlcommand.Parameters.Add("dealcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["dealcode"].Value = dealcode;


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



        public DataSet updatedetail(string dealno, string advcat, string publication, string suppli, string edition, string bookedfor, string color, string cardrate, string dealrate, string premium, string cardprem, string dealprem, string volbilled, string voldisc, string valfrom, string valto, string uom, string package, string compcode, string userid, string dealvalue, string totalrate, string currency, string editdisc, string flag, string quantity, string weight, string free, string cyoppac, string deviation)
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("updatevalueforcontract", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("cyoppac", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["cyoppac"].Value = cyoppac;


                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("free", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["free"].Value = free;

                objmysqlcommand.Parameters.Add("dealno", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["dealno"].Value = dealno;

                objmysqlcommand.Parameters.Add("currency", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["currency"].Value = currency;


                objmysqlcommand.Parameters.Add("advcat", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["advcat"].Value = advcat;

                objmysqlcommand.Parameters.Add("publication", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["publication"].Value = publication;

                objmysqlcommand.Parameters.Add("suppli", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["suppli"].Value = suppli;

                objmysqlcommand.Parameters.Add("edition", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["edition"].Value = edition;

                objmysqlcommand.Parameters.Add("bookedfor", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["bookedfor"].Value = bookedfor;

                objmysqlcommand.Parameters.Add("color", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["color"].Value = color;

                objmysqlcommand.Parameters.Add("cardrate", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["cardrate"].Value = cardrate;

                objmysqlcommand.Parameters.Add("dealrate", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["dealrate"].Value = dealrate;

                objmysqlcommand.Parameters.Add("dealprem", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["dealprem"].Value = dealprem;

                objmysqlcommand.Parameters.Add("premium", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["premium"].Value = premium;

                objmysqlcommand.Parameters.Add("volbilled", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["volbilled"].Value = volbilled;

                objmysqlcommand.Parameters.Add("cardprem", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["cardprem"].Value = cardprem;

                objmysqlcommand.Parameters.Add("voldisc", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["voldisc"].Value = voldisc;

                objmysqlcommand.Parameters.Add("valfrom", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["valfrom"].Value = valfrom;

                objmysqlcommand.Parameters.Add("valto", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["valto"].Value = valto;

                objmysqlcommand.Parameters.Add("uom", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["uom"].Value = uom;

                objmysqlcommand.Parameters.Add("package", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["package"].Value = package;

                objmysqlcommand.Parameters.Add("dealvalue", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["dealvalue"].Value = dealvalue;

                objmysqlcommand.Parameters.Add("totalrate", MySqlDbType.Int32);
                if (totalrate == "" || totalrate == "null")
                {
                    objmysqlcommand.Parameters["totalrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["totalrate"].Value = Convert.ToInt32(totalrate);
                }

                objmysqlcommand.Parameters.Add("flag", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["flag"].Value = flag;

                objmysqlcommand.Parameters.Add("editdisc", MySqlDbType.Int32);

                objmysqlcommand.Parameters["editdisc"].Value = Convert.ToInt32(editdisc);


                objmysqlcommand.Parameters.Add("quantity", MySqlDbType.Int32);
                if (quantity == "" || quantity == "null")
                {
                    objmysqlcommand.Parameters["quantity"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["quantity"].Value = Convert.ToInt32(quantity);
                }

                objmysqlcommand.Parameters.Add("weight", MySqlDbType.Int32);
                if (weight == "" || weight == "null")
                {
                    objmysqlcommand.Parameters["weight"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["weight"].Value = Convert.ToInt32(weight);
                }

                objmysqlcommand.Parameters.Add("deviation", MySqlDbType.Int32);
                if (deviation == "" || deviation == "null")
                {
                    objmysqlcommand.Parameters["deviation"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["deviation"].Value = Convert.ToInt32(deviation);
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

        public object deletecontractdetail(string compcode, string userid, string dealvalue)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("deletecontractdetail", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("dealvalue", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["dealvalue"].Value = dealvalue;




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



        public object deletecontractdeta(string compcode, string userid, string dealvalue)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("deletecontractdetail", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("dealvalue", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["dealvalue"].Value = dealvalue;




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

        public DataSet contractdelete(string compcode, string userid, string dealvalue)
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("deletecontractdetail", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("dealvalue", MySqlDbType.Int32);
                objmysqlcommand.Parameters["dealvalue"].Value = Convert.ToInt32(dealvalue);




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

        public DataSet autogenrated(string compcode, string userid, string deal)
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("autogeneratedeal", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("deal", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["deal"].Value = deal;






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


        public DataSet chkincontractdetail(string DealNo, string compcode, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("checkcontractdetail_checkcontractdetail_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("DealNo", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["DealNo"].Value = DealNo;






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

        public DataSet currencybind(string compcode, string userid)
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("bindcurrency", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

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

        public DataSet description(string packagecode, string compcode, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("binddescriptionforcontrcat", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

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

        public DataSet convertrate(string currcode, string compcode, string userid)
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("getconverrate", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("currcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["currcode"].Value = currcode;







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

        public DataSet discvalue(string discount, string compcode, string userid, string username)
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("getdiscount", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("discount", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["discount"].Value = discount;

                objmysqlcommand.Parameters.Add("username", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["username"].Value = username;








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

        public DataSet bindexec(string compcode, string userid, string name)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("bindexec", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("name", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["name"].Value = name;






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

        public DataSet currbind(string compcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("currbind", ref objmysqlconnection);
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

        public DataSet currencychecked(string dealcode, string compcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("currencydeal", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("dealcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["dealcode"].Value = dealcode;



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

        public DataSet deletecontractdeta(string code, string compcode)
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("deletecontract", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["code"].Value = code;






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


        public DataSet bindname(string compcode)
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("bindteamname", ref objmysqlconnection);
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

        public DataSet binddeal(string compcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("binddealtype", ref objmysqlconnection);
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


        public DataSet packagechk(string package, string compcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("packagechkcontract", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("package", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["package"].Value = package;




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

        public DataSet chkweight(string weight, string compcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("chkweight", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("weight", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["weight"].Value = weight;




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

        public DataSet getrateforcontract(string adcat, string pkgcode, string color, string currency, string uom, string advtype, string datefrom, string dateto, string compcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("contr_getpkgrate", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("adcat", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adcat"].Value = adcat;

                objmysqlcommand.Parameters.Add("pkgcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pkgcode"].Value = pkgcode;

                objmysqlcommand.Parameters.Add("color", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["color"].Value = color;

                objmysqlcommand.Parameters.Add("currency", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["currency"].Value = currency;

                objmysqlcommand.Parameters.Add("uom", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["uom"].Value = uom;

                objmysqlcommand.Parameters.Add("advtype", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["advtype"].Value = advtype;

                objmysqlcommand.Parameters.Add("datefrom", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["datefrom"].Value = datefrom;

                objmysqlcommand.Parameters.Add("dateto", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["dateto"].Value = dateto;




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
        public DataSet chkunique(string agency, string client, string prod, string compcode, string adtype, string mod)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("chkuniquecontractmaster", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("agency", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agency"].Value = agency;

                objmysqlcommand.Parameters.Add("client", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["client"].Value = client;

                objmysqlcommand.Parameters.Add("prod", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["prod"].Value = prod;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("mod1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["mod1"].Value = mod;

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

        public DataSet chkuniquedetail(string adcat, string pkgcode, string ratecode, string color, string compcode, string mod)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("chkuniquecontractdetail", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("adcat", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adcat"].Value = adcat;

                objmysqlcommand.Parameters.Add("pkgcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pkgcode"].Value = pkgcode;

                objmysqlcommand.Parameters.Add("ratecode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["ratecode"].Value = ratecode;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("color", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["color"].Value = color;

                objmysqlcommand.Parameters.Add("mod", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["mod"].Value = mod;



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
//=====================================================new
        public DataSet clspackagestatus(string compcode, string userid, string ad_type, string pkgcode, string pkgstatus)
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("websp_savepkgstatus", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("ad_type", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["ad_type"].Value = ad_type;

                objmysqlcommand.Parameters.Add("pkgcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pkgcode"].Value = pkgcode;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("pkgstatus", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pkgstatus"].Value = pkgstatus;

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
        public DataSet clsmodifypackagestatus(string compcode, string ad_type, string pkgcode, string pkgstatus, string recordid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("websp_modifypkgstatus", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("adtype", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adtype"].Value = ad_type;

                objmysqlcommand.Parameters.Add("pkgcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pkgcode"].Value = pkgcode;

                objmysqlcommand.Parameters.Add("pkgstatus", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pkgstatus"].Value = pkgstatus;

                objmysqlcommand.Parameters.Add("recordid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["recordid"].Value = recordid;

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
         public DataSet clsdeletepackagestatus(string compcode, string ad_type, string pkgcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("websp_deletepkgstatus", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("adtype1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adtype1"].Value = ad_type;

                objmysqlcommand.Parameters.Add("pkgcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pkgcode"].Value = pkgcode;
  
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
         public DataSet clsexistpackagestatus(string compcode, string ad_type, string pkgcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("websp_existpkgstatus", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("ad_type", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["ad_type"].Value = ad_type;

                objmysqlcommand.Parameters.Add("pkgcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pkgcode"].Value = pkgcode;

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
         public DataSet clsbindEntry(string compcode, string ad_type, string pkgcode, string pkgstatus)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("websp_bindEntry", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("ad_type1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["ad_type1"].Value = ad_type;

                objmysqlcommand.Parameters.Add("pkgcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pkgcode"].Value = pkgcode;

                objmysqlcommand.Parameters.Add("pkgstatus", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pkgstatus"].Value = pkgstatus;

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


         public DataSet bindProduct(string compcode, string indistry)
         {
             MySqlConnection objmysqlconnection;
             MySqlCommand objmysqlcommand;
             objmysqlconnection = GetConnection();
             MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
             DataSet objDataSet = new DataSet();
             try
             {
                 objmysqlconnection.Open();
                 objmysqlcommand = GetCommand("bindProductIndustryWise", ref objmysqlconnection);
                 objmysqlcommand.CommandType = CommandType.StoredProcedure;

                 objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                 objmysqlcommand.Parameters["compcode"].Value = compcode;

                 objmysqlcommand.Parameters.Add("industry", MySqlDbType.VarChar);
                 objmysqlcommand.Parameters["industry"].Value = indistry;

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

         public DataSet getClientNameadd(string agency_code, string compcode, string value, string datecheck)
         {
             MySqlConnection objmysqlconnection;
             MySqlCommand objmysqlcommand;
             objmysqlconnection = GetConnection();
             MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
             DataSet objDataSet = new DataSet();
             try
             {
                 objmysqlconnection.Open();
                 objmysqlcommand = GetCommand("BINDAGENCYFORAGENCY_foraudit", ref objmysqlconnection);
                 objmysqlcommand.CommandType = CommandType.StoredProcedure;

                 objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                 objmysqlcommand.Parameters["compcode"].Value = compcode;

                 objmysqlcommand.Parameters.Add("CLIENT", MySqlDbType.VarChar);
                 objmysqlcommand.Parameters["CLIENT"].Value = agency_code;

                 objmysqlcommand.Parameters.Add("VALUE", MySqlDbType.VarChar);
                 objmysqlcommand.Parameters["VALUE"].Value = value;

                 objmysqlcommand.Parameters.Add("datecheck", MySqlDbType.VarChar);
                 objmysqlcommand.Parameters["datecheck"].Value = datecheck;

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


         public DataSet getcontract(string compcode, string contaract)
         {
             MySqlConnection objmysqlconnection;
             MySqlCommand objmysqlcommand;
             objmysqlconnection = GetConnection();
             MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
             DataSet objDataSet = new DataSet();
             try
             {
                 objmysqlconnection.Open();
                 objmysqlcommand = GetCommand("BINDDEALforf2", ref objmysqlconnection);
                 objmysqlcommand.CommandType = CommandType.StoredProcedure;

                 objmysqlcommand.Parameters.Add("p_compcode", MySqlDbType.VarChar);
                 objmysqlcommand.Parameters["p_compcode"].Value = compcode;

                 objmysqlcommand.Parameters.Add("p_dealname", MySqlDbType.VarChar);
                 objmysqlcommand.Parameters["p_dealname"].Value = contaract;

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



         public DataSet chkvalidateintable(string tablename, string columnname, string value)
         {
             MySqlConnection objmysqlconnection;
             MySqlCommand objmysqlcommand;
             objmysqlconnection = GetConnection();
             MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
             DataSet objDataSet = new DataSet();
             try
             {
                 objmysqlconnection.Open();
                 objmysqlcommand = GetCommand("TV_VALUE_VALIDATE", ref objmysqlconnection);
                 objmysqlcommand.CommandType = CommandType.StoredProcedure;

                 objmysqlcommand.Parameters.Add("ptable_name", MySqlDbType.VarChar);
                 objmysqlcommand.Parameters["ptable_name"].Value = tablename;

                 objmysqlcommand.Parameters.Add("pcolumn_name", MySqlDbType.VarChar);
                 objmysqlcommand.Parameters["pcolumn_name"].Value = columnname;

                 objmysqlcommand.Parameters.Add("pvalue", MySqlDbType.VarChar);
                 objmysqlcommand.Parameters["pvalue"].Value = value;

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



         public DataSet getClientName(string compcode, string client, string center,string userid)
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

                 objSqlCommand.Parameters.Add("CLIENT", MySqlDbType.VarChar);
                 objSqlCommand.Parameters["CLIENT"].Value = client;

                 objSqlCommand.Parameters.Add("center", MySqlDbType.VarChar);
                 objSqlCommand.Parameters["center"].Value = center;

                 objSqlCommand.Parameters.Add("userid", MySqlDbType.VarChar);
                 objSqlCommand.Parameters["userid"].Value = userid;

                 objSqlDataAdapter.SelectCommand = objSqlCommand;
                 objSqlDataAdapter.Fill(objDataSet);

                 return objDataSet;
             }
             catch (Exception ex)
             {
                 throw (ex);
             }
             finally
             {
                 CloseConnection(ref objSqlConnection);
             }

         }
        

      public DataSet savecontractdetail(string dealno, string adtype, string hue, string uom, string package, string category, string premium, string cardprem, string contractprem, string contrate, string cardrate, string deviation, string disctype, string discper, string discon, string minsize, string maxsize, string valuefrom, string valueto, string day, string insertion, string commallow, string dealstart, string currency, string ratecode, string totalrate, string incentive, string remarks, string approved, string compcode, string userid, string id, string position, string contractamount, string contractpositionprem, string positionpremdisc, string toinsertion, string barter)
         {
             MySqlConnection objmysqlconnection;
             MySqlCommand objmysqlcommand;
             objmysqlconnection = GetConnection();
             MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
             DataSet objDataSet = new DataSet();
             try
             {
                 objmysqlconnection.Open();
                 objmysqlcommand = GetCommand("savecontract_detail", ref objmysqlconnection);
                 objmysqlcommand.CommandType = CommandType.StoredProcedure;

                 objmysqlcommand.Parameters.Add("dealno_p", MySqlDbType.VarChar);
                 objmysqlcommand.Parameters["dealno_p"].Value = dealno;

                 objmysqlcommand.Parameters.Add("adtype_p", MySqlDbType.VarChar);
                 objmysqlcommand.Parameters["adtype_p"].Value = adtype;

                 objmysqlcommand.Parameters.Add("hue_p", MySqlDbType.VarChar);
                 objmysqlcommand.Parameters["hue_p"].Value = hue;

                 objmysqlcommand.Parameters.Add("uom_p", MySqlDbType.VarChar);
                 objmysqlcommand.Parameters["uom_p"].Value = uom;

                 objmysqlcommand.Parameters.Add("package_p", MySqlDbType.VarChar);
                 objmysqlcommand.Parameters["package_p"].Value = package;

                 objmysqlcommand.Parameters.Add("category_p", MySqlDbType.VarChar);
                 objmysqlcommand.Parameters["category_p"].Value = category;
                                  
                 objmysqlcommand.Parameters.Add("premium_p", MySqlDbType.VarChar);
                 objmysqlcommand.Parameters["premium_p"].Value = premium;

                 objmysqlcommand.Parameters.Add("cardprem_p", MySqlDbType.VarChar);
                 objmysqlcommand.Parameters["cardprem_p"].Value = cardprem;

                 objmysqlcommand.Parameters.Add("contractprem_p", MySqlDbType.VarChar);
                 objmysqlcommand.Parameters["contractprem_p"].Value = contractprem;

                 objmysqlcommand.Parameters.Add("contrate_p", MySqlDbType.VarChar);
                 objmysqlcommand.Parameters["contrate_p"].Value = contrate;

                 objmysqlcommand.Parameters.Add("cardrate_p", MySqlDbType.VarChar);
                 objmysqlcommand.Parameters["cardrate_p"].Value = cardrate;

                 objmysqlcommand.Parameters.Add("deviation_p", MySqlDbType.VarChar);
                 objmysqlcommand.Parameters["deviation_p"].Value = deviation;

                 objmysqlcommand.Parameters.Add("disctype_p", MySqlDbType.VarChar);
                 objmysqlcommand.Parameters["disctype_p"].Value = disctype;

                 objmysqlcommand.Parameters.Add("discper_p", MySqlDbType.VarChar);
                 objmysqlcommand.Parameters["discper_p"].Value = discper;

                 objmysqlcommand.Parameters.Add("discon_p", MySqlDbType.VarChar);
                 objmysqlcommand.Parameters["discon_p"].Value = discon;

                 objmysqlcommand.Parameters.Add("minsize_p", MySqlDbType.VarChar);
                 objmysqlcommand.Parameters["minsize_p"].Value = minsize;

                 objmysqlcommand.Parameters.Add("maxsize_p", MySqlDbType.VarChar);
                 objmysqlcommand.Parameters["maxsize_p"].Value = maxsize;

                 objmysqlcommand.Parameters.Add("valuefrom_p", MySqlDbType.VarChar);
                 objmysqlcommand.Parameters["valuefrom_p"].Value = valuefrom;

                 objmysqlcommand.Parameters.Add("valueto_p", MySqlDbType.VarChar);
                 objmysqlcommand.Parameters["valueto_p"].Value = valueto;

                 objmysqlcommand.Parameters.Add("day_p", MySqlDbType.VarChar);
                 objmysqlcommand.Parameters["day_p"].Value = day;

                 objmysqlcommand.Parameters.Add("insertion_p", MySqlDbType.VarChar);
                 objmysqlcommand.Parameters["insertion_p"].Value = insertion;

                 objmysqlcommand.Parameters.Add("commallow_p", MySqlDbType.VarChar);
                 objmysqlcommand.Parameters["commallow_p"].Value = commallow;

                 objmysqlcommand.Parameters.Add("dealstart_p", MySqlDbType.VarChar);
                 objmysqlcommand.Parameters["dealstart_p"].Value = dealstart;

                 objmysqlcommand.Parameters.Add("currency_p", MySqlDbType.VarChar);
                 objmysqlcommand.Parameters["currency_p"].Value = currency;

                 objmysqlcommand.Parameters.Add("ratecode_p", MySqlDbType.VarChar);
                 objmysqlcommand.Parameters["ratecode_p"].Value = ratecode;

                 objmysqlcommand.Parameters.Add("totalrate_p", MySqlDbType.VarChar);
                 objmysqlcommand.Parameters["totalrate_p"].Value = totalrate;

                 objmysqlcommand.Parameters.Add("incentive_p", MySqlDbType.VarChar);
                 objmysqlcommand.Parameters["incentive_p"].Value = incentive;

                 objmysqlcommand.Parameters.Add("remarks_p", MySqlDbType.VarChar);
                 objmysqlcommand.Parameters["remarks_p"].Value = remarks;

                 objmysqlcommand.Parameters.Add("approved_p", MySqlDbType.VarChar);
                 objmysqlcommand.Parameters["approved_p"].Value = approved;

                 objmysqlcommand.Parameters.Add("compcode_p", MySqlDbType.VarChar);
                 objmysqlcommand.Parameters["compcode_p"].Value = compcode;

                 objmysqlcommand.Parameters.Add("userid_p", MySqlDbType.VarChar);
                 objmysqlcommand.Parameters["userid_p"].Value = userid;

                 objmysqlcommand.Parameters.Add("id_p", MySqlDbType.VarChar);
                 objmysqlcommand.Parameters["id_p"].Value = id;

                 objmysqlcommand.Parameters.Add("positionprem", MySqlDbType.VarChar);
                 objmysqlcommand.Parameters["positionprem"].Value = position;

                 objmysqlcommand.Parameters.Add("contractamount1", MySqlDbType.VarChar);
                 objmysqlcommand.Parameters["contractamount1"].Value = contractamount;

                 objmysqlcommand.Parameters.Add("pcontractpositionprem", MySqlDbType.VarChar);
                 objmysqlcommand.Parameters["pcontractpositionprem"].Value = contractpositionprem;

                 objmysqlcommand.Parameters.Add("ppositionpremdisc", MySqlDbType.VarChar);
                 objmysqlcommand.Parameters["ppositionpremdisc"].Value = positionpremdisc;

                 objmysqlcommand.Parameters.Add("ptoinsertion", MySqlDbType.VarChar);
                 objmysqlcommand.Parameters["ptoinsertion"].Value = toinsertion;

                 objmysqlcommand.Parameters.Add("pbarter", MySqlDbType.VarChar);
                 objmysqlcommand.Parameters["pbarter"].Value = barter;

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



      public DataSet dealshare(string code, string compcode, string userid)
      {

          MySqlConnection objmysqlconnection;
          MySqlCommand objmysqlcommand;
          objmysqlconnection = GetConnection();
          MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
          DataSet objDataSet = new DataSet();
          try
          {
              objmysqlconnection.Open();
              objmysqlcommand = GetCommand("binddealmarshare", ref objmysqlconnection);
              objmysqlcommand.CommandType = CommandType.StoredProcedure;

              objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
              objmysqlcommand.Parameters["compcode"].Value = compcode;

              objmysqlcommand.Parameters.Add("CODE", MySqlDbType.VarChar);
              objmysqlcommand.Parameters["CODE"].Value = code;

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



      public DataSet pub_centbind(string compcode, string mcatcode, string extra1, string extra2)
      {

          MySqlConnection objmysqlconnection;
          MySqlCommand objmysqlcommand;
          objmysqlconnection = GetConnection();
          MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
          DataSet objDataSet = new DataSet();
          try
          {
              objmysqlconnection.Open();
              objmysqlcommand = GetCommand("bind_pubcentname_new", ref objmysqlconnection);
              objmysqlcommand.CommandType = CommandType.StoredProcedure;

              objmysqlcommand.Parameters.Add("p_comp_code", MySqlDbType.VarChar);
              objmysqlcommand.Parameters["p_comp_code"].Value = compcode;

              objmysqlcommand.Parameters.Add("p_userid", MySqlDbType.VarChar);
              objmysqlcommand.Parameters["p_userid"].Value = mcatcode;

              objmysqlcommand.Parameters.Add("p_extra1", MySqlDbType.VarChar);
              objmysqlcommand.Parameters["p_extra1"].Value = extra1;

              objmysqlcommand.Parameters.Add("p_extra2", MySqlDbType.VarChar);
              objmysqlcommand.Parameters["p_extra2"].Value = extra2;

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



      public DataSet publication(string compcode, string mcatcode)
      {

          MySqlConnection objmysqlconnection;
          MySqlCommand objmysqlcommand;
          objmysqlconnection = GetConnection();
          MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
          DataSet objDataSet = new DataSet();
          try
          {
              objmysqlconnection.Open();
              objmysqlcommand = GetCommand("publication", ref objmysqlconnection);
              objmysqlcommand.CommandType = CommandType.StoredProcedure;

              objmysqlcommand.Parameters.Add("pcompcode", MySqlDbType.VarChar);
              objmysqlcommand.Parameters["pcompcode"].Value = compcode;

              objmysqlcommand.Parameters.Add("ppubcentcode", MySqlDbType.VarChar);
              objmysqlcommand.Parameters["ppubcentcode"].Value = mcatcode;

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


      public DataSet bindGridDetails_Contract(string compcode, string dealcode, string seqno)
      {
          MySqlConnection objmysqlconnection;
          MySqlCommand objmysqlcommand;
          objmysqlconnection = GetConnection();
          MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
          DataSet objDataSet = new DataSet();
          try
          {
              objmysqlconnection.Open();
              objmysqlcommand = GetCommand("bindGridDetails_Contract", ref objmysqlconnection);
              objmysqlcommand.CommandType = CommandType.StoredProcedure;

              objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
              objmysqlcommand.Parameters["compcode"].Value = compcode;

              objmysqlcommand.Parameters.Add("dealcode", MySqlDbType.VarChar);
              objmysqlcommand.Parameters["dealcode"].Value = dealcode;

              objmysqlcommand.Parameters.Add("seqno_p", MySqlDbType.VarChar);
              objmysqlcommand.Parameters["seqno_p"].Value = seqno;

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

      public DataSet modchek(string compcode, string dealno)
      {
          MySqlConnection objmysqlconnection;
          MySqlCommand objmysqlcommand;
          objmysqlconnection = GetConnection();
          MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
          DataSet objDataSet = new DataSet();
          try
          {
              objmysqlconnection.Open();
              objmysqlcommand = GetCommand("cheackdeal", ref objmysqlconnection);
              objmysqlcommand.CommandType = CommandType.StoredProcedure;

              objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
              objmysqlcommand.Parameters["compcode"].Value = compcode;

              objmysqlcommand.Parameters.Add("dealno", MySqlDbType.VarChar);
              objmysqlcommand.Parameters["dealno"].Value = dealno;

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

        // deal bil for deal audit

      public DataSet binddealNo(string compcode, string dealno, string mod)
      {
          MySqlConnection objmysqlconnection;
          MySqlCommand objmysqlcommand;
          objmysqlconnection = GetConnection();
          MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
          DataSet objDataSet = new DataSet();
          try
          {
              objmysqlconnection.Open();
              objmysqlcommand = GetCommand("tv_binddealforaudit", ref objmysqlconnection);
              objmysqlcommand.CommandType = CommandType.StoredProcedure;

              objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
              objmysqlcommand.Parameters["compcode"].Value = compcode;

              objmysqlcommand.Parameters.Add("deal", MySqlDbType.VarChar);
              objmysqlcommand.Parameters["deal"].Value = dealno;

              objmysqlcommand.Parameters.Add("mod1", MySqlDbType.VarChar);
              objmysqlcommand.Parameters["mod1"].Value = mod;

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


        // bind audit data
      public DataSet sub(string compcode, string adtype, string vf, string vt, string agencycode, string clintname, string de, string at, string dateforma, string branch, string uid)
      {
          MySqlConnection objmysqlconnection;
          MySqlCommand objmysqlcommand;
          objmysqlconnection = GetConnection();
          MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
          DataSet objDataSet = new DataSet();
          try
          {
              objmysqlconnection.Open();
              objmysqlcommand = GetCommand("tv_dealAudit", ref objmysqlconnection);
              objmysqlcommand.CommandType = CommandType.StoredProcedure;

              objmysqlcommand.Parameters.Add("compcode_p", MySqlDbType.VarChar);
              objmysqlcommand.Parameters["compcode_p"].Value = compcode;

              objmysqlcommand.Parameters.Add("adtype_p", MySqlDbType.VarChar);
              objmysqlcommand.Parameters["adtype_p"].Value = adtype;

              objmysqlcommand.Parameters.Add("validfrom_p", MySqlDbType.VarChar);
              objmysqlcommand.Parameters["validfrom_p"].Value = vf;

              objmysqlcommand.Parameters.Add("validto_p", MySqlDbType.VarChar);
              objmysqlcommand.Parameters["validto_p"].Value = vt;

              objmysqlcommand.Parameters.Add("agency_p", MySqlDbType.VarChar);
              objmysqlcommand.Parameters["agency_p"].Value = agencycode;

              objmysqlcommand.Parameters.Add("client_p", MySqlDbType.VarChar);
              objmysqlcommand.Parameters["client_p"].Value = clintname;

              objmysqlcommand.Parameters.Add("dealno_p", MySqlDbType.VarChar);
              objmysqlcommand.Parameters["dealno_p"].Value = de;

              objmysqlcommand.Parameters.Add("audittype_p", MySqlDbType.VarChar);
              objmysqlcommand.Parameters["audittype_p"].Value = at;

              objmysqlcommand.Parameters.Add("dateformat_p", MySqlDbType.VarChar);
              objmysqlcommand.Parameters["dateformat_p"].Value = dateforma;

              objmysqlcommand.Parameters.Add("pbranch", MySqlDbType.VarChar);
              objmysqlcommand.Parameters["pbranch"].Value = branch;

              objmysqlcommand.Parameters.Add("puserid", MySqlDbType.VarChar);
              objmysqlcommand.Parameters["puserid"].Value = uid;

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


        // update status

      public DataSet updatedealstatus(string compcode, string dealno, string userid, string remark, string unit, string seq, string percentage, string lvl, string dealpass, string disamt)
      {

          MySqlConnection objmysqlconnection;
          MySqlCommand objmysqlcommand;
          objmysqlconnection = GetConnection();
          MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
          DataSet objDataSet = new DataSet();
          try
          {
              objmysqlconnection.Open();
              objmysqlcommand = GetCommand("tv_dealauditupdate", ref objmysqlconnection);
              objmysqlcommand.CommandType = CommandType.StoredProcedure;

              objmysqlcommand.Parameters.Add("pcomp_code", MySqlDbType.VarChar);
              objmysqlcommand.Parameters["pcomp_code"].Value = compcode;

              objmysqlcommand.Parameters.Add("pdealno", MySqlDbType.VarChar);
              objmysqlcommand.Parameters["pdealno"].Value = dealno;

              objmysqlcommand.Parameters.Add("puserid", MySqlDbType.VarChar);
              objmysqlcommand.Parameters["puserid"].Value = userid;

              objmysqlcommand.Parameters.Add("premark", MySqlDbType.VarChar);
              objmysqlcommand.Parameters["premark"].Value = remark;

              objmysqlcommand.Parameters.Add("punit_code", MySqlDbType.VarChar);
              objmysqlcommand.Parameters["punit_code"].Value = unit;

              objmysqlcommand.Parameters.Add("pseq_no", MySqlDbType.VarChar);
              objmysqlcommand.Parameters["pseq_no"].Value = seq;

              objmysqlcommand.Parameters.Add("passing_flag", MySqlDbType.VarChar);
              objmysqlcommand.Parameters["passing_flag"].Value = dealpass;

              objmysqlcommand.Parameters.Add("passing_level", MySqlDbType.VarChar);
              objmysqlcommand.Parameters["passing_level"].Value = lvl;

              objmysqlcommand.Parameters.Add("pdicamt", MySqlDbType.VarChar);
              objmysqlcommand.Parameters["pdicamt"].Value = disamt;

              objmysqlcommand.Parameters.Add("ppercentage", MySqlDbType.VarChar);
              objmysqlcommand.Parameters["ppercentage"].Value = percentage;

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