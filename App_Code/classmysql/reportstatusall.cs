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
/// Summary description for reportstatusall
/// </summary>
    public class reportstatusall : connection
    {
        public reportstatusall()
        {
            //
            // TODO: Add constructor logic here
            //
        }

                                                                                                                                                                                                                                                                                                                                                            

        public DataSet statusreportsummary(string agname, string clientname, string dpdadtype, string adcategory, string fromdate, string todate, string compcode, string publication1, string pubcent, string bookingstatus, string editioncode, string dateformate, string hold, string descid, string ascdesc, string adtype, string userid, string chk_access, string extra1, string extra2,string extra3 , string extra4,string  extra5, string branch)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            objmysqlconnection = GetConnection();

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("REPORTNEW_SUM", ref objmysqlconnection);
                //objmysqlcommand = GetCommand("report_test", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;
                objmysqlcommand.CommandTimeout = 200;

                objmysqlcommand.Parameters.Add("agname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agname"].Value = agname;

                objmysqlcommand.Parameters.Add("clientname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["clientname"].Value = clientname;

                objmysqlcommand.Parameters.Add("adtype1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adtype1"].Value = dpdadtype;

                objmysqlcommand.Parameters.Add("adcategory", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adcategory"].Value = adcategory;

                objmysqlcommand.Parameters.Add("fromdate", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["fromdate"].Value = fromdate;

                objmysqlcommand.Parameters.Add("dateto", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["dateto"].Value = todate;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("pub_name", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pub_name"].Value = publication1;

                objmysqlcommand.Parameters.Add("pub_cent", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pub_cent"].Value = pubcent;

                objmysqlcommand.Parameters.Add("STATUS", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["STATUS"].Value = bookingstatus;

                objmysqlcommand.Parameters.Add("edition", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["edition"].Value = editioncode;

                objmysqlcommand.Parameters.Add("DATEFORMAT", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["DATEFORMAT"].Value = dateformate;

                objmysqlcommand.Parameters.Add("hold", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["hold"].Value = hold;

                objmysqlcommand.Parameters.Add("descid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["descid"].Value = descid;

                objmysqlcommand.Parameters.Add("ascdesc", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["ascdesc"].Value = ascdesc;

                objmysqlcommand.Parameters.Add("agtype", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agtype"].Value = adtype;

                objmysqlcommand.Parameters.Add("puserid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["puserid"].Value = userid;

                objmysqlcommand.Parameters.Add("chk_access", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["chk_access"].Value = chk_access;

                objmysqlcommand.Parameters.Add("pextra1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pextra1"].Value = extra1;

                objmysqlcommand.Parameters.Add("pextra2", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pextra2"].Value = extra2;

                objmysqlcommand.Parameters.Add("pextra3", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pextra3"].Value = extra3;

                objmysqlcommand.Parameters.Add("pextra4", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pextra4"].Value = extra4;

                objmysqlcommand.Parameters.Add("pextra5", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pextra5"].Value = extra5;

                objmysqlcommand.Parameters.Add("pbranch", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pbranch"].Value = branch;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }
        }


        public DataSet revenuesummaryrpt(string agname, string clientname, string dpdadtype, string adcategory, string fromdate, string todate, string compcode, string publication1, string pubcent, string bookingstatus, string editioncode, string dateformate, string hold, string descid, string ascdesc, string adtype, string userid, string chk_access, string extra1, string extra2, string extra3, string extra4, string extra5, string branch)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            objmysqlconnection = GetConnection();

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("REPORTNEW_SUM", ref objmysqlconnection);
                //objmysqlcommand = GetCommand("report_test", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("agname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agname"].Value = agname;

                objmysqlcommand.Parameters.Add("clientname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["clientname"].Value = clientname;

                objmysqlcommand.Parameters.Add("adtype1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adtype1"].Value = dpdadtype;

                objmysqlcommand.Parameters.Add("adcategory", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adcategory"].Value = adcategory;

                objmysqlcommand.Parameters.Add("fromdate", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["fromdate"].Value = fromdate;

                objmysqlcommand.Parameters.Add("dateto", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["dateto"].Value = todate;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("pub_name", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pub_name"].Value = publication1;

                objmysqlcommand.Parameters.Add("pub_cent", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pub_cent"].Value = pubcent;

                objmysqlcommand.Parameters.Add("STATUS", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["STATUS"].Value = bookingstatus;

                objmysqlcommand.Parameters.Add("edition", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["edition"].Value = editioncode;

                objmysqlcommand.Parameters.Add("DATEFORMAT", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["DATEFORMAT"].Value = dateformate;

                objmysqlcommand.Parameters.Add("hold", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["hold"].Value = hold;

                objmysqlcommand.Parameters.Add("descid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["descid"].Value = descid;

                objmysqlcommand.Parameters.Add("ascdesc", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["ascdesc"].Value = ascdesc;

                objmysqlcommand.Parameters.Add("agtype", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agtype"].Value = adtype;

                objmysqlcommand.Parameters.Add("puserid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["puserid"].Value = userid;

                objmysqlcommand.Parameters.Add("chk_access", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["chk_access"].Value = chk_access;

                objmysqlcommand.Parameters.Add("pextra1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pextra1"].Value = extra1;

                objmysqlcommand.Parameters.Add("pextra2", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pextra2"].Value = extra2;

                objmysqlcommand.Parameters.Add("pextra3", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pextra3"].Value = extra3;

                objmysqlcommand.Parameters.Add("pextra4", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pextra4"].Value = extra4;

                objmysqlcommand.Parameters.Add("pextra5", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pextra5"].Value = extra5;

                objmysqlcommand.Parameters.Add("pbranch", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pbranch"].Value = branch;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }
        }


        public DataSet alladssummaryrptexl(string agname, string clientname, string dpdadtype, string adcategory, string listadsubcat, string fromdate, string todate, string compcode, string publication1, string pubcent, string bookingstatus, string editioncode, string dateformate, string hold, string descid, string ascdesc, string adtype, string useridmain, string chk_access, string branch, string printcenter, string docket, string searching, string include, string uom, string userid, string state, string dist, string city, string extra1, string extra2, string extra3, string extra4, string extra5)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            objmysqlconnection = GetConnection();

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("reportnew1_sum", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;
                objmysqlcommand.CommandTimeout = 200;

                objmysqlcommand.Parameters.Add("agname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agname"].Value = agname;

                objmysqlcommand.Parameters.Add("clientname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["clientname"].Value = clientname;

                objmysqlcommand.Parameters.Add("adtype1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adtype1"].Value = dpdadtype;

                objmysqlcommand.Parameters.Add("Adcategory", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Adcategory"].Value = adcategory;

                objmysqlcommand.Parameters.Add("Adsubcategory", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Adsubcategory"].Value = listadsubcat;

                objmysqlcommand.Parameters.Add("fromdate", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["fromdate"].Value = fromdate;

                objmysqlcommand.Parameters.Add("dateto", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["dateto"].Value = todate;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("pub_name", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pub_name"].Value = publication1;

                objmysqlcommand.Parameters.Add("pub_cent", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pub_cent"].Value = pubcent;

                objmysqlcommand.Parameters.Add("status", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["status"].Value = bookingstatus;

                objmysqlcommand.Parameters.Add("edition", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["edition"].Value = editioncode;

                objmysqlcommand.Parameters.Add("dateformat", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["dateformat"].Value = dateformate;

                objmysqlcommand.Parameters.Add("hold", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["hold"].Value = hold;

                objmysqlcommand.Parameters.Add("descid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["descid"].Value = descid;

                objmysqlcommand.Parameters.Add("ascdesc", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["ascdesc"].Value = ascdesc;

                objmysqlcommand.Parameters.Add("agtype", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agtype"].Value = adtype;

                objmysqlcommand.Parameters.Add("puserid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["puserid"].Value = useridmain;

                objmysqlcommand.Parameters.Add("chk_access", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["chk_access"].Value = chk_access;

                objmysqlcommand.Parameters.Add("pbranch", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pbranch"].Value = branch;

                objmysqlcommand.Parameters.Add("pprint_center", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pprint_center"].Value = printcenter;

                objmysqlcommand.Parameters.Add("pwithout_rono", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pwithout_rono"].Value = docket;

                objmysqlcommand.Parameters.Add("pdate_flag", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pdate_flag"].Value = searching;

                objmysqlcommand.Parameters.Add("pinclude", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pinclude"].Value = include;

                objmysqlcommand.Parameters.Add("pextra1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pextra1"].Value = uom;

                objmysqlcommand.Parameters.Add("pextra2", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pextra2"].Value = userid;

                objmysqlcommand.Parameters.Add("pextra3", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pextra3"].Value = state;

                objmysqlcommand.Parameters.Add("pextra4", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pextra4"].Value = dist;

                objmysqlcommand.Parameters.Add("pextra5", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pextra5"].Value = city;

                objmysqlcommand.Parameters.Add("pextra6", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pextra6"].Value = extra1;

                objmysqlcommand.Parameters.Add("pextra7", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pextra7"].Value = extra2;

                objmysqlcommand.Parameters.Add("pextra8", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pextra8"].Value = extra3;

                objmysqlcommand.Parameters.Add("pextra9", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pextra9"].Value = extra4;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }
        }

        //
        public DataSet alladssummaryrptexlcls(string agname, string clientname, string dpdadtype, string adcategory, string listadsubcat, string fromdate, string todate, string compcode, string publication1, string pubcent, string bookingstatus, string editioncode, string dateformate, string hold, string descid, string ascdesc, string adtype, string useridmain, string chk_access, string branch, string printcenter, string docket, string searching, string include, string uom, string userid, string state, string dist, string city, string extra1, string extra2, string extra3, string extra4, string extra5)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            objmysqlconnection = GetConnection();

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("reportnew1_sum_pub_status_clad", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;
                objmysqlcommand.CommandTimeout = 200;

                objmysqlcommand.Parameters.Add("agname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agname"].Value = agname;

                objmysqlcommand.Parameters.Add("clientname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["clientname"].Value = clientname;

                objmysqlcommand.Parameters.Add("adtype1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adtype1"].Value = dpdadtype;

                objmysqlcommand.Parameters.Add("Adcategory", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Adcategory"].Value = adcategory;

                objmysqlcommand.Parameters.Add("Adsubcategory", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Adsubcategory"].Value = listadsubcat;

                objmysqlcommand.Parameters.Add("fromdate", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["fromdate"].Value = fromdate;

                objmysqlcommand.Parameters.Add("dateto", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["dateto"].Value = todate;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("pub_name", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pub_name"].Value = publication1;

                objmysqlcommand.Parameters.Add("pub_cent", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pub_cent"].Value = pubcent;

                objmysqlcommand.Parameters.Add("status", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["status"].Value = bookingstatus;

                objmysqlcommand.Parameters.Add("edition", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["edition"].Value = editioncode;

                objmysqlcommand.Parameters.Add("dateformat", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["dateformat"].Value = dateformate;

                objmysqlcommand.Parameters.Add("hold", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["hold"].Value = hold;

                objmysqlcommand.Parameters.Add("descid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["descid"].Value = descid;

                objmysqlcommand.Parameters.Add("ascdesc", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["ascdesc"].Value = ascdesc;

                objmysqlcommand.Parameters.Add("agtype", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agtype"].Value = adtype;

                objmysqlcommand.Parameters.Add("puserid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["puserid"].Value = useridmain;

                objmysqlcommand.Parameters.Add("chk_access", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["chk_access"].Value = chk_access;

                objmysqlcommand.Parameters.Add("pbranch", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pbranch"].Value = branch;

                objmysqlcommand.Parameters.Add("pprint_center", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pprint_center"].Value = printcenter;

                objmysqlcommand.Parameters.Add("pwithout_rono", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pwithout_rono"].Value = docket;

                objmysqlcommand.Parameters.Add("pdate_flag", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pdate_flag"].Value = searching;

                objmysqlcommand.Parameters.Add("pinclude", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pinclude"].Value = include;

                objmysqlcommand.Parameters.Add("pextra1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pextra1"].Value = uom;

                objmysqlcommand.Parameters.Add("pextra2", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pextra2"].Value = userid;

                objmysqlcommand.Parameters.Add("pextra3", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pextra3"].Value = state;

                objmysqlcommand.Parameters.Add("pextra4", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pextra4"].Value = dist;

                objmysqlcommand.Parameters.Add("pextra5", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pextra5"].Value = city;

                objmysqlcommand.Parameters.Add("pextra6", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pextra6"].Value = extra1;

                objmysqlcommand.Parameters.Add("pextra7", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pextra7"].Value = extra2;

                objmysqlcommand.Parameters.Add("pextra8", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pextra8"].Value = extra3;

                objmysqlcommand.Parameters.Add("pextra9", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pextra9"].Value = extra4;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }
        }


        public DataSet getgromdate_todatedata(string fromdate, string todate)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            objmysqlconnection = GetConnection();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("all_date", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;
                objmysqlcommand.CommandTimeout = 200;

                objmysqlcommand.Parameters.Add("pfromdate", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pfromdate"].Value = fromdate;

                objmysqlcommand.Parameters.Add("ptodate", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["ptodate"].Value = todate;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }
        }

    }



}