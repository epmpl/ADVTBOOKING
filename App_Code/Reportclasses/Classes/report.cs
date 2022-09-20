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
namespace NewAdbooking.Report.Classes
{
    /// <summary>
    /// Summary description for report
    /// </summary>
    public class report:connection
    {
        public report()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataSet issuereport(string compcode, string fromdate, string todate, string pubcent, string edition, string dateformat, string userid, string chk_acc, string agencytyp)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("rpt_issue_pcentre_wise", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("@chk_access", SqlDbType.VarChar);
                objSqlCommand.Parameters["@chk_access"].Value = chk_acc;

                objSqlCommand.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcompcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@ppubcent", SqlDbType.VarChar);
                if (pubcent == "0")
                {
                    objSqlCommand.Parameters["@ppubcent"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@ppubcent"].Value = pubcent;
                }

                objSqlCommand.Parameters.Add("@pedtncode", SqlDbType.VarChar);
                if (edition == "0")
                {
                    objSqlCommand.Parameters["@pedtncode"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pedtncode"].Value = edition;
                }

                objSqlCommand.Parameters.Add("@pfrom_date", SqlDbType.VarChar);
                if (fromdate == "")
                {
                    objSqlCommand.Parameters["@pfrom_date"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pfrom_date"].Value = fromdate;
                }

                objSqlCommand.Parameters.Add("@ptill_date", SqlDbType.VarChar);
                if (todate == "0")
                {
                    objSqlCommand.Parameters["@ptill_date"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@ptill_date"].Value = todate;
                }

                objSqlCommand.Parameters.Add("@pratio_type", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pratio_type"].Value = "";

                objSqlCommand.Parameters.Add("@pextra1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra1"].Value = "";

                objSqlCommand.Parameters.Add("@pextra2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra2"].Value = "";


                objSqlCommand.Parameters.Add("@pdateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdateformat"].Value = dateformat;

                objSqlCommand.Parameters.Add("@puserid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@puserid"].Value = userid;

                objSqlCommand.Parameters.Add("@pagtype", SqlDbType.VarChar);
                if (agencytyp != "--Select Agency Name--")
                objSqlCommand.Parameters["@pagtype"].Value = agencytyp;
                else
                    objSqlCommand.Parameters["@pagtype"].Value = System.DBNull.Value;

                objSqlDataAdapter = new SqlDataAdapter();
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
        public DataSet completerep(string compcode, string fromdate, string dateto, string dateformate, string publication, string pub_cent, string edition, string suppliment, string zone, string branch, string district, string region, string city, string revcenter, string adtype, string agencytype, string ratetype, string adcat, string adsubcat, string adsubcat3, string adsubcat4, string adsubcat5, string package, string scheme, string agency, string client, string executive, string retainer, string product, string brand, string varient, string pagetype, string pageprem, string postprem, string rostatus, string booktype, string contractname, string filterby, string adcheck, string state, string taluka, string based, string status, string chkdetail, string insertsts, string useid, string chk_acc, string box, string basedondate)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("completereport", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.CommandTimeout = 0;

                objSqlCommand.Parameters.Add("@insertstatus", SqlDbType.VarChar);
                if (insertsts == "0")
                {
                    objSqlCommand.Parameters["@insertstatus"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@insertstatus"].Value = insertsts;
                }

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@puserid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@puserid"].Value = useid;

                objSqlCommand.Parameters.Add("@chk_access", SqlDbType.VarChar);
                objSqlCommand.Parameters["@chk_access"].Value = chk_acc;

                objSqlCommand.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dateformat"].Value = dateformate;

                objSqlCommand.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (fromdate == "" || fromdate == null)
                {
                    objSqlCommand.Parameters["@fromdate"].Value = System.DBNull.Value;;
                }
                else
                {
                    objSqlCommand.Parameters["@fromdate"].Value = fromdate;
                }

                objSqlCommand.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (dateto == "" || dateto == null)
                {
                    objSqlCommand.Parameters["@dateto"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@dateto"].Value = dateto;
                }

                objSqlCommand.Parameters.Add("@publication", SqlDbType.VarChar);
                if (publication == "0")
                {
                    objSqlCommand.Parameters["@publication"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@publication"].Value = publication;
                }

                objSqlCommand.Parameters.Add("@pub_cent", SqlDbType.VarChar);
                if (pub_cent == "0")
                {
                    objSqlCommand.Parameters["@pub_cent"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pub_cent"].Value = pub_cent;
                }

                objSqlCommand.Parameters.Add("@edition", SqlDbType.VarChar);
                if (edition == "0" || edition == "Select Edition")
                {
                    objSqlCommand.Parameters["@edition"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@edition"].Value = edition;
                }

                objSqlCommand.Parameters.Add("@suppliment", SqlDbType.VarChar);
                if (suppliment == "0" || suppliment == "Select Supplement")
                {
                    objSqlCommand.Parameters["@suppliment"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@suppliment"].Value = suppliment;
                }

                objSqlCommand.Parameters.Add("@zone", SqlDbType.VarChar);
                if (zone == "0")
                {
                    objSqlCommand.Parameters["@zone"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@zone"].Value = zone;
                }

                objSqlCommand.Parameters.Add("@branch", SqlDbType.VarChar);
                if (branch == "0" || branch == "Select Branch")
                {
                    objSqlCommand.Parameters["@branch"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@branch"].Value = branch;
                }

                objSqlCommand.Parameters.Add("@district", SqlDbType.VarChar);
                if (district == "0" || district == "Select District")
                {
                    objSqlCommand.Parameters["@district"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@district"].Value = district;
                }


                objSqlCommand.Parameters.Add("@region", SqlDbType.VarChar);
                if (region == "0" )
                {
                    objSqlCommand.Parameters["@region"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@region"].Value = region;
                }

                objSqlCommand.Parameters.Add("@city", SqlDbType.VarChar);
                if (city == "0" )
                {
                    objSqlCommand.Parameters["@city"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@city"].Value = city;
                }

                objSqlCommand.Parameters.Add("@revcenter", SqlDbType.VarChar);
                if (revcenter == "0")
                {
                    objSqlCommand.Parameters["@revcenter"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@revcenter"].Value = revcenter;
                }

                objSqlCommand.Parameters.Add("@adtype", SqlDbType.VarChar);
                if (adtype == "0")
                {
                    objSqlCommand.Parameters["@adtype"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@adtype"].Value = adtype;
                }

                objSqlCommand.Parameters.Add("@agencytype", SqlDbType.VarChar);
                if (agencytype == "0" || agencytype == "Select Agency Type")
                {
                    objSqlCommand.Parameters["@agencytype"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@agencytype"].Value = agencytype;
                }

                objSqlCommand.Parameters.Add("@ratetype", SqlDbType.VarChar);
                if (ratetype == "0")
                {
                    objSqlCommand.Parameters["@ratetype"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@ratetype"].Value = ratetype;
                }

                objSqlCommand.Parameters.Add("@adcat", SqlDbType.VarChar);
                if (adcat == "0" || adcat == "Select AdCat")
                {
                    objSqlCommand.Parameters["@adcat"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@adcat"].Value = adcat;
                }

                objSqlCommand.Parameters.Add("@adsubcat", SqlDbType.VarChar);
                if (adsubcat == "0" || adsubcat == "Select AdSubCat")
                {
                    objSqlCommand.Parameters["@adsubcat"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@adsubcat"].Value = adsubcat;
                }

                objSqlCommand.Parameters.Add("@adsubcat3", SqlDbType.VarChar);
                if (adsubcat3 == "0")
                {
                    objSqlCommand.Parameters["@adsubcat3"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@adsubcat3"].Value = adsubcat3;
                }

                objSqlCommand.Parameters.Add("@adsubcat4", SqlDbType.VarChar);
                if (adsubcat4 == "0")
                {
                    objSqlCommand.Parameters["@adsubcat4"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@adsubcat4"].Value = adsubcat4;
                }

                objSqlCommand.Parameters.Add("@adsubcat5", SqlDbType.VarChar);
                if (adsubcat5 == "0")
                {
                    objSqlCommand.Parameters["@adsubcat5"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@adsubcat5"].Value = adsubcat5;
                }

                objSqlCommand.Parameters.Add("@package", SqlDbType.VarChar);
                if (package == "0")
                {
                    objSqlCommand.Parameters["@package"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@package"].Value = package;
                }

                objSqlCommand.Parameters.Add("@scheme", SqlDbType.VarChar);
                if (scheme == "0")
                {
                    objSqlCommand.Parameters["@scheme"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@scheme"].Value = scheme;
                }

                objSqlCommand.Parameters.Add("@agency", SqlDbType.VarChar);
                if (agency == "0" || agency == "")
                {
                    objSqlCommand.Parameters["@agency"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@agency"].Value = agency;
                }

                objSqlCommand.Parameters.Add("@client", SqlDbType.VarChar);
                if (client == "0" || client=="")
                {
                    objSqlCommand.Parameters["@client"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@client"].Value = client;
                }

                objSqlCommand.Parameters.Add("@executive", SqlDbType.VarChar);
                if (executive == "0" || executive == "")
                {
                    objSqlCommand.Parameters["@executive"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@executive"].Value = executive;
                }

                objSqlCommand.Parameters.Add("@retainer", SqlDbType.VarChar);
                if (retainer == "0" || retainer == "")
                {
                    objSqlCommand.Parameters["@retainer"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@retainer"].Value = retainer;
                }

                objSqlCommand.Parameters.Add("@product", SqlDbType.VarChar);
                if (product == "0")
                {
                    objSqlCommand.Parameters["@product"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@product"].Value = product;
                }

                objSqlCommand.Parameters.Add("@brand", SqlDbType.VarChar);
                if (brand == "0")
                {
                    objSqlCommand.Parameters["@brand"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@brand"].Value = brand;
                }

                objSqlCommand.Parameters.Add("@varient", SqlDbType.VarChar);
                if (varient == "0")
                {
                    objSqlCommand.Parameters["@varient"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@varient"].Value = varient;
                }

                objSqlCommand.Parameters.Add("@pagetype", SqlDbType.VarChar);
                if (pagetype == "0")
                {
                    objSqlCommand.Parameters["@pagetype"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pagetype"].Value = pagetype;
                }

                objSqlCommand.Parameters.Add("@pageprem", SqlDbType.VarChar);
                if (pageprem == "0")
                {
                    objSqlCommand.Parameters["@pageprem"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pageprem"].Value = pageprem;
                }

                objSqlCommand.Parameters.Add("@postprem", SqlDbType.VarChar);
                if (postprem == "0")
                {
                    objSqlCommand.Parameters["@postprem"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@postprem"].Value = postprem;
                }

                objSqlCommand.Parameters.Add("@rostatus", SqlDbType.VarChar);
                if (rostatus == "0")
                {
                    objSqlCommand.Parameters["@rostatus"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@rostatus"].Value = rostatus;
                }

                objSqlCommand.Parameters.Add("@booktype", SqlDbType.VarChar);
                if (booktype == "0")
                {
                    objSqlCommand.Parameters["@booktype"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@booktype"].Value = booktype;
                }

                objSqlCommand.Parameters.Add("@contractname", SqlDbType.VarChar);
                if (contractname == "0")
                {
                    objSqlCommand.Parameters["@contractname"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@contractname"].Value = contractname;
                }

                objSqlCommand.Parameters.Add("@filterby", SqlDbType.VarChar);
                if (filterby == "0")
                {
                    objSqlCommand.Parameters["@filterby"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@filterby"].Value = filterby;
                }

                objSqlCommand.Parameters.Add("@adcheck", SqlDbType.VarChar);
                if (adcheck == "0")
                {
                    objSqlCommand.Parameters["@adcheck"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@adcheck"].Value = adcheck;
                }

                objSqlCommand.Parameters.Add("@state", SqlDbType.VarChar);
                if (state == "0" || state == "" || state == "Select State")
                {
                    objSqlCommand.Parameters["@state"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@state"].Value = state;
                }

                objSqlCommand.Parameters.Add("@taluka", SqlDbType.VarChar);
                if (taluka == "0" || taluka == "")
                {
                    objSqlCommand.Parameters["@taluka"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@taluka"].Value = taluka;
                }

                objSqlCommand.Parameters.Add("@base", SqlDbType.VarChar);
                if (based == "0" || based == "")
                {
                    objSqlCommand.Parameters["@base"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@base"].Value = based;
                }

                objSqlCommand.Parameters.Add("@drpstatus", SqlDbType.VarChar);
                if (status == "0")
                {
                    objSqlCommand.Parameters["@drpstatus"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@drpstatus"].Value = status;
                }


                objSqlCommand.Parameters.Add("@chkdetail", SqlDbType.VarChar);
                objSqlCommand.Parameters["@chkdetail"].Value = chkdetail;

                objSqlCommand.Parameters.Add("@p_baxcode", SqlDbType.VarChar);
                if (box == "0")
                {
                    objSqlCommand.Parameters["@p_baxcode"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@p_baxcode"].Value = box;
                }

                objSqlCommand.Parameters.Add("@pdate_basedon", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdate_basedon"].Value = basedondate;


                objSqlDataAdapter = new SqlDataAdapter();
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
        public DataSet netamtreportinsert(string frmdt, string todate, string compcode, string dateformate, string rowname, string columnname, string conditionchk, string useid, string chk_acc)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("billreportinsert", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@puserid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@puserid"].Value = useid;

                objSqlCommand.Parameters.Add("@chk_access", SqlDbType.VarChar);
                objSqlCommand.Parameters["@chk_access"].Value = chk_acc;

                objSqlCommand.Parameters.Add("@pfromdate", SqlDbType.VarChar);
                if (frmdt == "")
                {
                    objSqlCommand.Parameters["@pfromdate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pfromdate"].Value = frmdt;
                }

                objSqlCommand.Parameters.Add("@ptodate", SqlDbType.VarChar);
                if (todate == "")
                {
                    objSqlCommand.Parameters["@ptodate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@ptodate"].Value = todate;
                }

                objSqlCommand.Parameters.Add("@pdateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdateformat"].Value = dateformate;

                objSqlCommand.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcompcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@prowname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@prowname"].Value = rowname;

                objSqlCommand.Parameters.Add("@pcolumnname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcolumnname"].Value = columnname;


                objSqlCommand.Parameters.Add("@pconditioncheck", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pconditioncheck"].Value = conditionchk;
                objSqlCommand.Parameters.Add("@pbranch", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pbranch"].Value = System.DBNull.Value;


                objSqlDataAdapter = new SqlDataAdapter();
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


        public DataSet netamtreport(string frmdt, string todate, string compcode, string dateformate, string rowname, string columnname, string conditionchk, string useid, string chk_acc)
        {
             SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("billreport", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@puserid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@puserid"].Value = useid;

                objSqlCommand.Parameters.Add("@chk_access", SqlDbType.VarChar);
                objSqlCommand.Parameters["@chk_access"].Value = chk_acc;

                objSqlCommand.Parameters.Add("@pfromdate", SqlDbType.VarChar);
                if (frmdt == "")
                {
                    objSqlCommand.Parameters["@pfromdate"].Value =System.DBNull.Value ;
                }
                else
                {
                    objSqlCommand.Parameters["@pfromdate"].Value = frmdt;
                }

                objSqlCommand.Parameters.Add("@ptodate", SqlDbType.VarChar);
                if (todate == "")
                {
                    objSqlCommand.Parameters["@ptodate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@ptodate"].Value = todate;
                }

                objSqlCommand.Parameters.Add("@pdateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdateformat"].Value = dateformate;

                objSqlCommand.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcompcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@prowname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@prowname"].Value = rowname;

                objSqlCommand.Parameters.Add("@pcolumnname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcolumnname"].Value = columnname;


                objSqlCommand.Parameters.Add("@pconditioncheck", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pconditioncheck"].Value = conditionchk;

                objSqlDataAdapter = new SqlDataAdapter();
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
        public DataSet availableprem(string page, string position, string fromdate, string dateto, string pubname, string compcode, string edition, string dateformat, string pubcenter, string useid, string chk_acc,string pageno,string adtype,string adcategory)
        {
             SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("report_avilable_dates", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("@chk_access", SqlDbType.VarChar);
                objSqlCommand.Parameters["@chk_access"].Value = chk_acc;

                objSqlCommand.Parameters.Add("@puserid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@puserid"].Value = useid;

                objSqlCommand.Parameters.Add("@page", SqlDbType.VarChar);
                if (page == "0")
                {
                    objSqlCommand.Parameters["@page"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@page"].Value = page;
                }

                objSqlCommand.Parameters.Add("@position", SqlDbType.VarChar);
                if (position == "0")
                {
                    objSqlCommand.Parameters["@position"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@position"].Value = position;
                }

                objSqlCommand.Parameters.Add("@pubcenter", SqlDbType.VarChar);
                if (pubcenter == "0" )
                {
                    objSqlCommand.Parameters["@pubcenter"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pubcenter"].Value = pubcenter;
                }

                objSqlCommand.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (fromdate == "")
                {
                    objSqlCommand.Parameters["@fromdate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@fromdate"].Value = fromdate;
                }

                objSqlCommand.Parameters.Add("@todate", SqlDbType.VarChar);
                if (dateto == "")
                {
                    objSqlCommand.Parameters["@todate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@todate"].Value = dateto;
                }

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@pub", SqlDbType.VarChar);
                if (pubname == "0")
                {
                    objSqlCommand.Parameters["@pub"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pub"].Value = pubname;
                }

                objSqlCommand.Parameters.Add("@edition", SqlDbType.VarChar);
                if (edition == "0" || edition=="")
                {
                    objSqlCommand.Parameters["@edition"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@edition"].Value = edition;
                }

                objSqlCommand.Parameters.Add("@page_no", SqlDbType.VarChar);
                if (pageno == "0" || pageno == "")
                {
                    objSqlCommand.Parameters["@page_no"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@page_no"].Value = pageno;
                }



                objSqlCommand.Parameters.Add("@ad_type", SqlDbType.VarChar);
                if (adtype == "0" || adtype == "")
                {
                    objSqlCommand.Parameters["@ad_type"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@ad_type"].Value = adtype;
                }

                objSqlCommand.Parameters.Add("@ad_cat", SqlDbType.VarChar);
                if (adcategory == "0" || adcategory == "")
                {
                    objSqlCommand.Parameters["@ad_cat"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@ad_cat"].Value = adcategory;
                }


                objSqlCommand.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dateformat"].Value = dateformat;
                
                objSqlDataAdapter = new SqlDataAdapter();
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
        public DataSet ageana(string pubcent, string adtyp, string frmdt, string todate, string compcode, string publication, string dateformate, string descid, string ascdesc, string value, string execut, string place, string bill, string publication1, string edition1, string noofrows, string check11, string useid, string chk_acc,string branch)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Agencyana", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@executive", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@executive"].Value = execut;
                if (execut == "" || execut == "0")
                {
                    objSqlCommand.Parameters["@executive"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@executive"].Value = execut;
                }

                objSqlCommand.Parameters.Add("@chk_access", SqlDbType.VarChar);
                objSqlCommand.Parameters["@chk_access"].Value = chk_acc;

                objSqlCommand.Parameters.Add("@puserid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@puserid"].Value = useid;

                objSqlCommand.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (frmdt == "")
                {
                    objSqlCommand.Parameters["@fromdate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@fromdate"].Value = frmdt;
                }

                objSqlCommand.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (todate == "")
                {
                    objSqlCommand.Parameters["@dateto"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@dateto"].Value = todate;
                }

                objSqlCommand.Parameters.Add("@pub_name", SqlDbType.VarChar);
                if (publication == "0" || publication == "")
                {
                    objSqlCommand.Parameters["@pub_name"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pub_name"].Value = publication;
                }


                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dateformat"].Value = dateformate;

                objSqlCommand.Parameters.Add("@adtyp", SqlDbType.VarChar);
                if (adtyp == "0" || adtyp == "")
                {
                    objSqlCommand.Parameters["@adtyp"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@adtyp"].Value = adtyp;
                }


                objSqlCommand.Parameters.Add("@descid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@descid"].Value = descid;

                objSqlCommand.Parameters.Add("@ascdesc", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ascdesc"].Value = ascdesc;

                objSqlCommand.Parameters.Add("@pub_cent", SqlDbType.VarChar);
                if (pubcent == "0")
                {
                    objSqlCommand.Parameters["@pub_cent"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pub_cent"].Value = pubcent;
                }

                objSqlCommand.Parameters.Add("@value", SqlDbType.VarChar);
                objSqlCommand.Parameters["@value"].Value = value;


                objSqlCommand.Parameters.Add("@place", SqlDbType.VarChar);
                if (place == "0" || place == "")
                {
                    objSqlCommand.Parameters["@place"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@place"].Value = place;
                }


                objSqlCommand.Parameters.Add("@publication1", SqlDbType.VarChar);
                if (publication1 == "0" || publication1 == "")
                {
                    objSqlCommand.Parameters["@publication1"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@publication1"].Value = publication1;
                }

                objSqlCommand.Parameters.Add("@Edition1", SqlDbType.VarChar);
                if (edition1 == "0" || edition1 == "")
                {
                    objSqlCommand.Parameters["@Edition1"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@Edition1"].Value = edition1;
                }


                objSqlCommand.Parameters.Add("@check11", SqlDbType.VarChar);
                if (check11 == "0" || check11 == "")
                {
                    objSqlCommand.Parameters["@check11"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@check11"].Value = check11;
                }


                objSqlCommand.Parameters.Add("@totalrows", SqlDbType.VarChar);
                if (noofrows == "")
                {
                    objSqlCommand.Parameters["@totalrows"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@totalrows"].Value = noofrows;
                }

                objSqlCommand.Parameters.Add("@agency_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agency_code"].Value = System.DBNull.Value;


                objSqlCommand.Parameters.Add("@agency_sub_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agency_sub_code"].Value = System.DBNull.Value;


                
                objSqlCommand.Parameters.Add("@branch", SqlDbType.VarChar);
                objSqlCommand.Parameters["@branch"].Value =  branch;




                objSqlDataAdapter = new SqlDataAdapter();
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
        //from_date, to_date, Session["compcode"].ToString(), dppub1.SelectedValue, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), temp_agname, dpcategory.SelectedValue, dppubcent.SelectedValue, dpagtype.SelectedValue, hiddeneditionname.Value, temp_agency, dpregion.SelectedValue, dpagcat.SelectedValue, adchk, hdnexecode.Value, Session["userid"].ToString(), Session["access"].ToString(), statecod, ddldistrict.SelectedValue,drpstatus.SelectedValue,""
        public DataSet billreg(string frmdt, string todate, string compcode, string product, string dateformate, string descid, string ascdesc, string temp_agname, string temp_category, string temp_pubcent, string temp_adtype, string temp_edition, string temp_agency, string temp_region, string adchk, string exec, string useid, string chk_acc, string statcod, string district, string insertstatus, string agcat1, string extra1)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("pub_Reportnew", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.CommandTimeout = 0;


                objSqlCommand.Parameters.Add("@agname", SqlDbType.VarChar);
                if (temp_agname == "0" || temp_agname == "")
                {
                    objSqlCommand.Parameters["@agname"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@agname"].Value = temp_agname;
                }

                objSqlCommand.Parameters.Add("@Adtype", SqlDbType.VarChar);
                if (temp_adtype == "0")
                {
                    objSqlCommand.Parameters["@Adtype"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@Adtype"].Value = temp_adtype;
                }


                objSqlCommand.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (frmdt == "")
                {
                    objSqlCommand.Parameters["@fromdate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@fromdate"].Value = frmdt;
                }

                objSqlCommand.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (todate == "")
                {
                    objSqlCommand.Parameters["@dateto"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@dateto"].Value = todate;
                }

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;


                objSqlCommand.Parameters.Add("@pub_cent", SqlDbType.VarChar);
                if (temp_pubcent == "0" || temp_pubcent == "--Select AgencyType--")
                {
                    objSqlCommand.Parameters["@pub_cent"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pub_cent"].Value = temp_pubcent;
                }

                objSqlCommand.Parameters.Add("@category", SqlDbType.VarChar);
                if (temp_category == "0" || temp_category == "--Select AgencyType--")
                {
                    objSqlCommand.Parameters["@category"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@category"].Value = temp_category;
                }


                objSqlCommand.Parameters.Add("@edition", SqlDbType.VarChar);
                if (temp_edition == "0" || temp_edition == "--Select Edition Name--")
                {
                    objSqlCommand.Parameters["@edition"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@edition"].Value = temp_edition;
                }


                objSqlCommand.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dateformat"].Value = dateformate;


                objSqlCommand.Parameters.Add("@Region", SqlDbType.VarChar);
                if (temp_region == "0")
                {
                    objSqlCommand.Parameters["@Region"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@Region"].Value = temp_region;
                }


                objSqlCommand.Parameters.Add("@product", SqlDbType.VarChar);
                if (product == "0")
                {
                    objSqlCommand.Parameters["@product"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@product"].Value = product;
                }



                objSqlCommand.Parameters.Add("@agency", SqlDbType.VarChar);
                if (temp_agency == "" || temp_agency == "0")
                {
                    objSqlCommand.Parameters["@agency"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@agency"].Value = temp_agency;
                }


                objSqlCommand.Parameters.Add("@descid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@descid"].Value = descid;

                objSqlCommand.Parameters.Add("@ascdesc", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ascdesc"].Value = ascdesc;


                objSqlCommand.Parameters.Add("@agcat", SqlDbType.VarChar);
                if (agcat1 == "0")
                {
                    objSqlCommand.Parameters["@agcat"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@agcat"].Value = agcat1;
                }

                objSqlCommand.Parameters.Add("@adcheck", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adcheck"].Value = adchk;

                objSqlCommand.Parameters.Add("@executive", SqlDbType.VarChar);
                if (exec == "0" || exec == "")
                {
                    objSqlCommand.Parameters["@executive"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@executive"].Value = exec;
                }


                objSqlCommand.Parameters.Add("@puserid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@puserid"].Value = useid;


                objSqlCommand.Parameters.Add("@chk_access", SqlDbType.VarChar);
                objSqlCommand.Parameters["@chk_access"].Value = chk_acc;


                objSqlCommand.Parameters.Add("@pstatecode", SqlDbType.VarChar);
                if (statcod == "0" || statcod == "")
                {
                    objSqlCommand.Parameters["@pstatecode"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pstatecode"].Value = statcod;
                }

                objSqlCommand.Parameters.Add("@pdistcode", SqlDbType.VarChar);
                if (district == "0" || district == "")
                {
                    objSqlCommand.Parameters["@pdistcode"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pdistcode"].Value = district;
                }



                objSqlCommand.Parameters.Add("@pinsertstatus", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pinsertstatus"].Value = insertstatus;

                objSqlCommand.Parameters.Add("@extra1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@extra1"].Value = "";


                objSqlDataAdapter = new SqlDataAdapter();
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
        //from_date, to_date, Session["compcode"].ToString(), dppub1.SelectedValue, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), temp_agname, dpcategory.SelectedValue, dppubcent.SelectedValue, dpagtype.SelectedValue, hiddeneditionname.Value, temp_agency, dpregion.SelectedValue, dpagcat.SelectedValue, adchk, hdnexecode.Value, Session["userid"].ToString(), Session["access"].ToString(), statecod, ddldistrict.SelectedValue,drpstatus.SelectedValue,""
        public DataSet billreg1(string frmdt, string todate, string compcode, string product, string dateformate, string descid, string ascdesc, string temp_agname, string temp_category, string temp_pubcent, string temp_adtype, string temp_edition, string temp_agency, string temp_region, string agcat1, string adchk, string exec, string useid, string chk_acc, string statcod, string district, string insertstatus, string extra1)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("pub_Reportnew", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.CommandTimeout = 0;


                objSqlCommand.Parameters.Add("@agname", SqlDbType.VarChar);
                if (temp_agname == "0" || temp_agname == "")
                {
                    objSqlCommand.Parameters["@agname"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@agname"].Value = temp_agname;
                }

                objSqlCommand.Parameters.Add("@Adtype", SqlDbType.VarChar);
                if (temp_adtype == "0")
                {
                    objSqlCommand.Parameters["@Adtype"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@Adtype"].Value = temp_adtype;
                }


                objSqlCommand.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (frmdt == "")
                {
                    objSqlCommand.Parameters["@fromdate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@fromdate"].Value = frmdt;
                }

                objSqlCommand.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (todate == "")
                {
                    objSqlCommand.Parameters["@dateto"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@dateto"].Value = todate;
                }

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;


                objSqlCommand.Parameters.Add("@pub_cent", SqlDbType.VarChar);
                if (temp_pubcent == "0" || temp_pubcent == "--Select AgencyType--")
                {
                    objSqlCommand.Parameters["@pub_cent"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pub_cent"].Value = temp_pubcent;
                }

                objSqlCommand.Parameters.Add("@category", SqlDbType.VarChar);
                if (temp_category == "0" || temp_category == "--Select AgencyType--")
                {
                    objSqlCommand.Parameters["@category"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@category"].Value = temp_category;
                }


                objSqlCommand.Parameters.Add("@edition", SqlDbType.VarChar);
                if (temp_edition == "0" || temp_edition == "--Select Edition Name--")
                {
                    objSqlCommand.Parameters["@edition"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@edition"].Value = temp_edition;
                }


                objSqlCommand.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dateformat"].Value = dateformate;


                objSqlCommand.Parameters.Add("@Region", SqlDbType.VarChar);
                if (temp_region == "0")
                {
                    objSqlCommand.Parameters["@Region"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@Region"].Value = temp_region;
                }


                objSqlCommand.Parameters.Add("@product", SqlDbType.VarChar);
                if (product == "0")
                {
                    objSqlCommand.Parameters["@product"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@product"].Value = product;
                }



                objSqlCommand.Parameters.Add("@agency", SqlDbType.VarChar);
                if (temp_agency == "" || temp_agency == "0")
                {
                    objSqlCommand.Parameters["@agency"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@agency"].Value = temp_agency;
                }


                objSqlCommand.Parameters.Add("@descid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@descid"].Value = descid;

                objSqlCommand.Parameters.Add("@ascdesc", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ascdesc"].Value = ascdesc;


                objSqlCommand.Parameters.Add("@agcat", SqlDbType.VarChar);
                if (agcat1 == "0")
                {
                    objSqlCommand.Parameters["@agcat"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@agcat"].Value = agcat1;
                }

                objSqlCommand.Parameters.Add("@adcheck", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adcheck"].Value = adchk;

                objSqlCommand.Parameters.Add("@executive", SqlDbType.VarChar);
                if (exec == "0" || exec == "")
                {
                    objSqlCommand.Parameters["@executive"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@executive"].Value = exec;
                }


                objSqlCommand.Parameters.Add("@puserid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@puserid"].Value = useid;


                objSqlCommand.Parameters.Add("@chk_access", SqlDbType.VarChar);
                objSqlCommand.Parameters["@chk_access"].Value = chk_acc;


                objSqlCommand.Parameters.Add("@pstatecode", SqlDbType.VarChar);
                if (statcod == "0" || statcod == "")
                {
                    objSqlCommand.Parameters["@pstatecode"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pstatecode"].Value = statcod;
                }

                objSqlCommand.Parameters.Add("@pdistcode", SqlDbType.VarChar);
                if (district == "0" || district == "")
                {
                    objSqlCommand.Parameters["@pdistcode"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pdistcode"].Value = district;
                }



                objSqlCommand.Parameters.Add("@pinsertstatus", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pinsertstatus"].Value = insertstatus;

                objSqlCommand.Parameters.Add("@extra1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@extra1"].Value = "";


                objSqlDataAdapter = new SqlDataAdapter();
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
        public DataSet barter_report(string frmdt, string todate, string compcode, string client, string agency, string region, string product, string booktype, string dateformate, string descid, string ascdesc, string pub_center, string useid, string chk_acc)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("bill_report", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (frmdt == "")
                {
                    objSqlCommand.Parameters["@fromdate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@fromdate"].Value = frmdt;
                }

                objSqlCommand.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (todate == "")
                {
                    objSqlCommand.Parameters["@dateto"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@dateto"].Value = todate;
                }

                objSqlCommand.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dateformat"].Value = dateformate;

                objSqlCommand.Parameters.Add("@product", SqlDbType.VarChar);
                if (product == "0")
                {
                    objSqlCommand.Parameters["@product"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@product"].Value = product;
                }


                objSqlCommand.Parameters.Add("@Region", SqlDbType.VarChar);
                if (region == "0")
                {
                    objSqlCommand.Parameters["@Region"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@Region"].Value = region;

                }


                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;


                objSqlCommand.Parameters.Add("@descid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@descid"].Value = descid;

                objSqlCommand.Parameters.Add("@ascdesc", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ascdesc"].Value = ascdesc;

                objSqlCommand.Parameters.Add("@agency", SqlDbType.VarChar);
                if (agency == "0" || agency=="")
                {
                    objSqlCommand.Parameters["@agency"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@agency"].Value = agency;
                }

                objSqlCommand.Parameters.Add("@client", SqlDbType.VarChar);
                if (client == "0" || client=="")
                {
                    objSqlCommand.Parameters["@client"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@client"].Value = client;
                }

                objSqlCommand.Parameters.Add("@pub_cent", SqlDbType.VarChar);
                if (pub_center == "0")
                {
                    objSqlCommand.Parameters["@pub_cent"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pub_cent"].Value = pub_center;
                }

                objSqlCommand.Parameters.Add("@chk_access", SqlDbType.VarChar);
                objSqlCommand.Parameters["@chk_access"].Value = chk_acc;

                objSqlCommand.Parameters.Add("@puserid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@puserid"].Value = useid;

                objSqlCommand.Parameters.Add("@booktype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@booktype"].Value = booktype;

                objSqlDataAdapter = new SqlDataAdapter();
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
        public DataSet rebatebilling(string fromdate, string dateto, string region, string publication, string temp_category, string compcode, string dateformat, string descid, string ascdesc, string temp_agname, string adtype, string temp_pubcent, string temp_edition, string executive, string temp_state, string temp_district, string temp_client, string temp_newcateg, string orderby, string useid, string chk_acc)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Bill_Reportnew", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@region", SqlDbType.VarChar);
                if ((region == "0") || (region == "--Select Region--"))
                {
                    objSqlCommand.Parameters["@region"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@region"].Value = region;

                }

                objSqlCommand.Parameters.Add("@product", SqlDbType.VarChar);
                if (publication == "0")
                {
                    objSqlCommand.Parameters["@product"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@product"].Value = publication;
                }


                objSqlCommand.Parameters.Add("@chk_access", SqlDbType.VarChar);
                objSqlCommand.Parameters["@chk_access"].Value = chk_acc;

                objSqlCommand.Parameters.Add("@puserid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@puserid"].Value = useid;

                objSqlCommand.Parameters.Add("@category", SqlDbType.VarChar);
                if (temp_category == "0")
                {
                    objSqlCommand.Parameters["@category"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@category"].Value = temp_category;
                }






                objSqlCommand.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (fromdate == "")
                {
                    objSqlCommand.Parameters["@fromdate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@fromdate"].Value = fromdate;
                }

                objSqlCommand.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (dateto == "")
                {
                    objSqlCommand.Parameters["@dateto"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@dateto"].Value = dateto;
                }


                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dateformat"].Value = dateformat;

                objSqlCommand.Parameters.Add("@descid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@descid"].Value = descid;

                objSqlCommand.Parameters.Add("@ascdesc", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ascdesc"].Value = ascdesc;

                objSqlCommand.Parameters.Add("@agname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agname"].Value = temp_agname;

                objSqlCommand.Parameters.Add("@Adtype", SqlDbType.VarChar);
                if (adtype == "0")
                {
                    objSqlCommand.Parameters["@Adtype"].Value = System.DBNull.Value;

                }
                else
                {
                    objSqlCommand.Parameters["@Adtype"].Value = adtype;
                }


                objSqlCommand.Parameters.Add("@pub_cent", SqlDbType.VarChar);
                if (temp_pubcent == "0")
                {
                    objSqlCommand.Parameters["@pub_cent"].Value = System.DBNull.Value;

                }
                else
                {
                    objSqlCommand.Parameters["@pub_cent"].Value = temp_pubcent;
                }

                objSqlCommand.Parameters.Add("@edition", SqlDbType.VarChar);
                objSqlCommand.Parameters["@edition"].Value = temp_edition;

                objSqlCommand.Parameters.Add("@client", SqlDbType.VarChar);
                objSqlCommand.Parameters["@client"].Value = temp_client;

                objSqlCommand.Parameters.Add("@newcategory", SqlDbType.VarChar);
                objSqlCommand.Parameters["@newcategory"].Value = temp_newcateg;

                objSqlCommand.Parameters.Add("@executive1", SqlDbType.VarChar);
                if (executive == "0" || executive=="")
                {
                    objSqlCommand.Parameters["@executive1"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@executive1"].Value = executive;
                }

               

                objSqlCommand.Parameters.Add("@state", SqlDbType.VarChar);
                if (temp_state == "0")
                {
                    objSqlCommand.Parameters["@state"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@state"].Value = temp_state;
                }

                objSqlCommand.Parameters.Add("@district", SqlDbType.VarChar);
                if (temp_district == "0")
                {
                    objSqlCommand.Parameters["@district"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@district"].Value = temp_district;
                }

                objSqlCommand.Parameters.Add("@orderby", SqlDbType.VarChar);
                if (orderby == "0")
                {
                    objSqlCommand.Parameters["@orderby"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@orderby"].Value = orderby;
                }

                objSqlDataAdapter = new SqlDataAdapter();
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
        public DataSet retainonscreen(string fromdate, string dateto, string region, string product, string compcode, string dateformat, string descid, string ascdesc, string temp1, string temp2, string temp3, string temp4, string temp5, string temp6, string branch, string edition, string retainer, string addtype, string publi_center, string useid, string chk_acc)
        {
             SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Bill_Retaincomm", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@chk_access", SqlDbType.VarChar);
                objSqlCommand.Parameters["@chk_access"].Value = chk_acc;

                objSqlCommand.Parameters.Add("@puserid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@puserid"].Value = useid;

                objSqlCommand.Parameters.Add("@publication_center", SqlDbType.VarChar);
                if (publi_center == "0")
                {
                    objSqlCommand.Parameters["@publication_center"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@publication_center"].Value = publi_center;
                }


                objSqlCommand.Parameters.Add("@region", SqlDbType.VarChar);
                if ((region == "0") || (region == "--Select Region--"))
                {
                    objSqlCommand.Parameters["@region"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@region"].Value = region;
                }

                objSqlCommand.Parameters.Add("@pub_cent", SqlDbType.VarChar);
                if (product == "0")
                {
                    objSqlCommand.Parameters["@pub_cent"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pub_cent"].Value = product;
                }


                objSqlCommand.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (fromdate == "" )
                {
                    objSqlCommand.Parameters["@fromdate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@fromdate"].Value = fromdate;
                }

                objSqlCommand.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (dateto == "")
                {
                    objSqlCommand.Parameters["@dateto"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@dateto"].Value = dateto;
                }

                objSqlCommand.Parameters.Add("@Adtype", SqlDbType.VarChar);
                if (addtype == "0")
                {
                    objSqlCommand.Parameters["@Adtype"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@Adtype"].Value = addtype;
                }

                objSqlCommand.Parameters.Add("@edition", SqlDbType.VarChar);
                if ((edition == "0") || (edition == "") || (edition == "--Select Edition Name--") || (edition == "--Select Edition--"))
                {
                    objSqlCommand.Parameters["@edition"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@edition"].Value = edition;
                }

                objSqlCommand.Parameters.Add("@Retainer", SqlDbType.VarChar);
                if (retainer == "0" || retainer=="")
                {
                    objSqlCommand.Parameters["@Retainer"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@Retainer"].Value = retainer;
                }

                objSqlCommand.Parameters.Add("@Branch", SqlDbType.VarChar);
                if ((branch == "0") || (branch == "--Select Branch--"))
                {
                    objSqlCommand.Parameters["@Branch"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@Branch"].Value = branch;
                }


                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dateformat"].Value = dateformat;

                objSqlCommand.Parameters.Add("@descid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@descid"].Value = descid;

                objSqlCommand.Parameters.Add("@ascdesc", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ascdesc"].Value = ascdesc;

                objSqlCommand.Parameters.Add("@agname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agname"].Value = temp1;

                objSqlCommand.Parameters.Add("@category", SqlDbType.VarChar);
                objSqlCommand.Parameters["@category"].Value = temp4;

                objSqlCommand.Parameters.Add("@agency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agency"].Value = temp6;

                objSqlDataAdapter = new SqlDataAdapter();
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
        public DataSet money_report(string frmdt, string todate, string compcode, string client, string agency, string dateformate, string paymode, string adtype,string branch,string usercode, string pubcent, string useid, string chk_acc,string puom)
        {
             SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Money_Rep", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                //objSqlCommand.
                objSqlCommand.Parameters.Add("@chk_access", SqlDbType.VarChar);
                objSqlCommand.Parameters["@chk_access"].Value = chk_acc;

                objSqlCommand.Parameters.Add("@puserid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@puserid"].Value = useid;

                objSqlCommand.Parameters.Add("@useridcode", SqlDbType.VarChar);
                if (usercode == "0")
                {
                    objSqlCommand.Parameters["@useridcode"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@useridcode"].Value = usercode;
                }

                objSqlCommand.Parameters.Add("@pbranch", SqlDbType.VarChar);
                if (branch == "0" || branch=="")
                {
                    objSqlCommand.Parameters["@pbranch"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pbranch"].Value = branch;
                }


                objSqlCommand.Parameters.Add("@pub_cent", SqlDbType.VarChar);
                if (pubcent == "0")
                {
                    objSqlCommand.Parameters["@pub_cent"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pub_cent"].Value = pubcent;
                }

                objSqlCommand.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (frmdt == "")
                {
                    objSqlCommand.Parameters["@fromdate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@fromdate"].Value = frmdt;
                }

                objSqlCommand.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (todate == "")
                {
                    objSqlCommand.Parameters["@dateto"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@dateto"].Value = todate;
                }

                objSqlCommand.Parameters.Add("@agname", SqlDbType.VarChar);
                if (agency == "0" || agency=="")
                {
                    objSqlCommand.Parameters["@agname"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@agname"].Value = agency;
                }

                objSqlCommand.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dateformat"].Value = dateformate;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@client", SqlDbType.VarChar);
                if (client == "0" || client=="")
                {
                    objSqlCommand.Parameters["@client"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@client"].Value = client;
                }

                objSqlCommand.Parameters.Add("@agencypay", SqlDbType.VarChar);
                if (paymode == "0")
                {
                    objSqlCommand.Parameters["@agencypay"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@agencypay"].Value = paymode;
                }


                objSqlCommand.Parameters.Add("@advtype", SqlDbType.VarChar);
                if (adtype == "0")
                {
                    objSqlCommand.Parameters["@advtype"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@advtype"].Value = adtype;
                }

                objSqlCommand.Parameters.Add("@p_uom", SqlDbType.VarChar);
                if (puom == "0" || puom == "")
                    objSqlCommand.Parameters["@p_uom"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@p_uom"].Value = puom;

                objSqlCommand.Parameters.Add("@pcurency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcurency"].Value = System.DBNull.Value;

                objSqlCommand.Parameters.Add("@rostatus", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rostatus"].Value = System.DBNull.Value;

                //@pcurency  as varchar(10),
//@rostatus as varchar(8)
                objSqlDataAdapter = new SqlDataAdapter();
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
        public DataSet representative(string pubcent, string adtyp, string frmdt, string todate, string compcode, string publication, string dateformate, string descid, string ascdesc, string value, string execut, string team, string bill, string cl, string ag, string retain, string repchk, string useid, string chk_acc,string pbranch,string pdistrict)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Representative", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.CommandTimeout = 0;

                objSqlCommand.Parameters.Add("@chk_access", SqlDbType.VarChar);
                objSqlCommand.Parameters["@chk_access"].Value = chk_acc;

                objSqlCommand.Parameters.Add("@puserid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@puserid"].Value = useid;

                objSqlCommand.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (frmdt == "")
                {
                    objSqlCommand.Parameters["@fromdate"].Value =System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@fromdate"].Value = frmdt;
                }


                objSqlCommand.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (todate == "")
                {
                    objSqlCommand.Parameters["@dateto"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@dateto"].Value = todate;
                }

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@rep", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rep"].Value = repchk;

                objSqlCommand.Parameters.Add("@pub_name", SqlDbType.VarChar);
                if (publication == "0" || publication == "")
                {
                    objSqlCommand.Parameters["@pub_name"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pub_name"].Value = publication;
                }

                objSqlCommand.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dateformat"].Value = dateformate;

                objSqlCommand.Parameters.Add("@adtyp", SqlDbType.VarChar);
                if (adtyp == "0" || adtyp == "")
                {
                    objSqlCommand.Parameters["@adtyp"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@adtyp"].Value = adtyp;
                }

                objSqlCommand.Parameters.Add("@descid", SqlDbType.VarChar);
                if (descid == "")
                {
                    objSqlCommand.Parameters["@descid"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@descid"].Value = descid;
                }

                objSqlCommand.Parameters.Add("@ascdesc", SqlDbType.VarChar);
                if (ascdesc == "")
                {
                    objSqlCommand.Parameters["@ascdesc"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@ascdesc"].Value = ascdesc;
                }

                objSqlCommand.Parameters.Add("@pub_cent", SqlDbType.VarChar);
                if (pubcent == "0")
                {
                    objSqlCommand.Parameters["@pub_cent"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pub_cent"].Value = pubcent;
                }

                objSqlCommand.Parameters.Add("@value", SqlDbType.VarChar);
                objSqlCommand.Parameters["@value"].Value = value;

                objSqlCommand.Parameters.Add("@team", SqlDbType.VarChar);
                if (team == "0" || team == "")
                {
                    objSqlCommand.Parameters["@team"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@team"].Value = team;
                }


                objSqlCommand.Parameters.Add("@execut", SqlDbType.VarChar);
                if (execut == "0" || execut == "")
                {
                    objSqlCommand.Parameters["@execut"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@execut"].Value = execut;
                }


                objSqlCommand.Parameters.Add("@bill", SqlDbType.VarChar);
                if (bill == "0" || bill == "")
                {
                    objSqlCommand.Parameters["@bill"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@bill"].Value = bill;
                }


                objSqlCommand.Parameters.Add("@cl", SqlDbType.VarChar);
                if (cl == "0" || cl == "")
                {
                    objSqlCommand.Parameters["@cl"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@cl"].Value = cl;
                }

                objSqlCommand.Parameters.Add("@ag", SqlDbType.VarChar);
                if (ag == "0" || ag == "")
                {
                    objSqlCommand.Parameters["@ag"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@ag"].Value = ag;
                }

                objSqlCommand.Parameters.Add("@retainer", SqlDbType.VarChar);
                if (retain == "0" || retain == "")
                {
                    objSqlCommand.Parameters["@retainer"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@retainer"].Value = retain;
                }

                objSqlCommand.Parameters.Add("@pbrancode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pbrancode"].Value = pbranch;

                objSqlCommand.Parameters.Add("@pdistcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdistcode"].Value = pdistrict;

                objSqlCommand.Parameters.Add("@pextra1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra1"].Value = System.DBNull.Value;


                objSqlCommand.Parameters.Add("@pextra2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra2"].Value = System.DBNull.Value;


                objSqlCommand.Parameters.Add("@pextra3", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra3"].Value = System.DBNull.Value;


                objSqlCommand.Parameters.Add("@pextra4", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra4"].Value = System.DBNull.Value;


                objSqlCommand.Parameters.Add("@pextra5", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra5"].Value = System.DBNull.Value;


                objSqlDataAdapter = new SqlDataAdapter();
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
        public DataSet spcontractreportnewbilled(string fromdate, string dateto, string compcode, string dateformat, string product, string agency1, string client1, string region1, string category, string pub_center, string useid, string chk_acc)
        {
             SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("PICONTRACT_REPORTbilled", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@chk_access", SqlDbType.VarChar);
                objSqlCommand.Parameters["@chk_access"].Value = chk_acc;

                objSqlCommand.Parameters.Add("@puserid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@puserid"].Value = useid;


                objSqlCommand.Parameters.Add("@publication_center", SqlDbType.VarChar);
                if (pub_center == "0")
                {
                    objSqlCommand.Parameters["@publication_center"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@publication_center"].Value = pub_center;
                }

                objSqlCommand.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (fromdate == "")
                {
                    objSqlCommand.Parameters["@fromdate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@fromdate"].Value = fromdate;
                }

                objSqlCommand.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (dateto == "")
                {
                    objSqlCommand.Parameters["@dateto"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@dateto"].Value = dateto;
                }

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@pub_cent", SqlDbType.VarChar);
                if (product == "0")
                {
                    objSqlCommand.Parameters["@pub_cent"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pub_cent"].Value = product;
                }

                objSqlCommand.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dateformat"].Value = dateformat;

                objSqlCommand.Parameters.Add("@agname", SqlDbType.VarChar);
                if (agency1 == "0" || agency1=="")
                {
                    objSqlCommand.Parameters["@agname"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@agname"].Value = agency1;
                }

                objSqlCommand.Parameters.Add("@client", SqlDbType.VarChar);
                if (client1 == "0" || client1=="")
                {
                    objSqlCommand.Parameters["@client"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@client"].Value = client1;
                }

                objSqlCommand.Parameters.Add("@category1", SqlDbType.VarChar);
                if (category == "0")
                {
                    objSqlCommand.Parameters["@category1"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@category1"].Value = category;
                }


                objSqlCommand.Parameters.Add("@Region", SqlDbType.VarChar);
                if (region1 == "0")
                {
                    objSqlCommand.Parameters["@Region"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@Region"].Value = region1;
                }



                objSqlDataAdapter = new SqlDataAdapter();
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
        public DataSet spcontractreportnew(string fromdate, string dateto, string compcode, string dateformat, string product, string agency1, string client1, string region1, string category, string pub_center, string useid, string chk_acc)
        {
             SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("PICONTRACT_REPORT", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@chk_access", SqlDbType.VarChar);
                objSqlCommand.Parameters["@chk_access"].Value = chk_acc;

                objSqlCommand.Parameters.Add("@puserid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@puserid"].Value = useid;


                objSqlCommand.Parameters.Add("@publication_center", SqlDbType.VarChar);
                if (pub_center == "0")
                {
                    objSqlCommand.Parameters["@publication_center"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@publication_center"].Value = pub_center;
                }

                objSqlCommand.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (fromdate == "")
                {
                    objSqlCommand.Parameters["@fromdate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@fromdate"].Value = fromdate;
                }

                objSqlCommand.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (dateto == "")
                {
                    objSqlCommand.Parameters["@dateto"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@dateto"].Value = dateto;
                }

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@pub_cent", SqlDbType.VarChar);
                if (product == "0")
                {
                    objSqlCommand.Parameters["@pub_cent"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pub_cent"].Value = product;
                }

                objSqlCommand.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dateformat"].Value = dateformat;

                objSqlCommand.Parameters.Add("@agname", SqlDbType.VarChar);
                if (agency1 == "0" || agency1=="")
                {
                    objSqlCommand.Parameters["@agname"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@agname"].Value = agency1;
                }

                objSqlCommand.Parameters.Add("@client", SqlDbType.VarChar);
                if (client1 == "0" || client1=="")
                {
                    objSqlCommand.Parameters["@client"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@client"].Value = client1;
                }

                objSqlCommand.Parameters.Add("@category1", SqlDbType.VarChar);
                if (category == "0")
                {
                    objSqlCommand.Parameters["@category1"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@category1"].Value = category;
                }


                objSqlCommand.Parameters.Add("@Region", SqlDbType.VarChar);
                if (region1 == "0")
                {
                    objSqlCommand.Parameters["@Region"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@Region"].Value = region1;
                }


               

                objSqlDataAdapter = new SqlDataAdapter();
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
        public DataSet spproductreport(string fromdate, string dateto, string compcode, string region, string dateformat, string product, string descid, string ascdesc, string temp1, string temp2, string adtype, string temp4, string publnm, string temp6, string temp7, string temp8, string temp9, string temp10, string temp11, string adchk, string agencytyp, string useid, string chk_acc)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Misreportnew", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@chk_access", SqlDbType.VarChar);
                objSqlCommand.Parameters["@chk_access"].Value = chk_acc;

                objSqlCommand.Parameters.Add("@puserid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@puserid"].Value = useid;


                objSqlCommand.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (fromdate == "")
                {
                    objSqlCommand.Parameters["@fromdate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@fromdate"].Value = fromdate;
                }

                objSqlCommand.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (dateto == "")
                {
                    objSqlCommand.Parameters["@dateto"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@dateto"].Value = dateto;
                }

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;


                objSqlCommand.Parameters.Add("@region", SqlDbType.VarChar);
                if (region == "--Select Region--" || region == "0")
                {
                    objSqlCommand.Parameters["@region"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@region"].Value = region;
                }


                objSqlCommand.Parameters.Add("@product", SqlDbType.VarChar);
                if (product == "0")
                {
                    objSqlCommand.Parameters["@product"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@product"].Value = product;
                }

                objSqlCommand.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dateformat"].Value = dateformat;

                objSqlCommand.Parameters.Add("@descid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@descid"].Value = descid;

                objSqlCommand.Parameters.Add("@ascdesc", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ascdesc"].Value = ascdesc;

                objSqlCommand.Parameters.Add("@agname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agname"].Value = temp1;


                objSqlCommand.Parameters.Add("@clientname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@clientname"].Value = temp2;

                objSqlCommand.Parameters.Add("@adtype1", SqlDbType.VarChar);
                if (adtype == "0")
                {
                    objSqlCommand.Parameters["@adtype1"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@adtype1"].Value = adtype;
                }
                objSqlCommand.Parameters.Add("@adcategory", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adcategory"].Value = temp4;

                objSqlCommand.Parameters.Add("@pub_name", SqlDbType.VarChar);
                if (publnm == "0")
                {
                    objSqlCommand.Parameters["@pub_name"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pub_name"].Value = publnm;
                }

                objSqlCommand.Parameters.Add("@pub_cent", SqlDbType.VarChar);
                if (temp6 == "0")
                {
                    objSqlCommand.Parameters["@pub_cent"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pub_cent"].Value = temp6;
                }

                objSqlCommand.Parameters.Add("@status", SqlDbType.VarChar);
                objSqlCommand.Parameters["@status"].Value = temp7;

                objSqlCommand.Parameters.Add("@edition", SqlDbType.VarChar);
                objSqlCommand.Parameters["@edition"].Value = temp8;

                objSqlCommand.Parameters.Add("@hold", SqlDbType.VarChar);
                objSqlCommand.Parameters["@hold"].Value = temp9;

                objSqlCommand.Parameters.Add("@published", SqlDbType.VarChar);
                objSqlCommand.Parameters["@published"].Value = temp10;

                objSqlCommand.Parameters.Add("@orderby", SqlDbType.VarChar);
                objSqlCommand.Parameters["@orderby"].Value = temp11;

                objSqlCommand.Parameters.Add("@adcheck", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adcheck"].Value = adchk;

                objSqlCommand.Parameters.Add("@agtype", SqlDbType.VarChar);
                if (agencytyp == "0" || agencytyp == "--Select AgencyType--")
                {
                    objSqlCommand.Parameters["@agtype"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@agtype"].Value = agencytyp;
                }

                objSqlDataAdapter = new SqlDataAdapter();
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
        public DataSet Dailyrep(string fromdate, string dateto, string adtype, string pub, string pubcen, string compcode, string dateformat, string ascdesc, string descid, string edition, string useid, string chk_acc)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Dailyreport", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@chk_access", SqlDbType.VarChar);
                objSqlCommand.Parameters["@chk_access"].Value = chk_acc;

                objSqlCommand.Parameters.Add("@puserid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@puserid"].Value = useid;

                objSqlCommand.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dateformat"].Value = dateformat;

                objSqlCommand.Parameters.Add("@adcategory", SqlDbType.VarChar);
                if (adtype == "0" || adtype == "")
                {
                    objSqlCommand.Parameters["@adcategory"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@adcategory"].Value = adtype;
                }

                objSqlCommand.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (fromdate == "")
                {
                    objSqlCommand.Parameters["@fromdate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@fromdate"].Value = fromdate;
                }

                objSqlCommand.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (dateto == "")
                {
                    objSqlCommand.Parameters["@dateto"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@dateto"].Value = dateto;
                }

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;


                objSqlCommand.Parameters.Add("@pub", SqlDbType.VarChar);
                if (pub == "0" || pub == "")
                {
                    objSqlCommand.Parameters["@pub"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pub"].Value = pub;
                }


                objSqlCommand.Parameters.Add("@pubcen", SqlDbType.VarChar);
                if (pubcen == "0" || pubcen == "" || pubcen == "--Select Publication Center--")
                {
                    objSqlCommand.Parameters["@pubcen"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pubcen"].Value = pubcen;
                }

                objSqlCommand.Parameters.Add("@edition", SqlDbType.VarChar);
                if (edition == "0" || edition == "" || edition == "--Select Edition Name--")
                {
                    objSqlCommand.Parameters["@edition"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@edition"].Value = edition;
                }



                objSqlCommand.Parameters.Add("@descid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@descid"].Value = descid;

                objSqlCommand.Parameters.Add("@ascdesc", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ascdesc"].Value = ascdesc;

                objSqlDataAdapter = new SqlDataAdapter();
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
        public DataSet categoryreport(string fromdate, string dateto, string adtype, string pub, string pubcent, string execut, string region, string place, string grp, string page, string compcode, string dateformat, string ascdesc, string descid, string agcat, string useid, string chk_acc)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("categoryreport", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@chk_access", SqlDbType.VarChar);
                objSqlCommand.Parameters["@chk_access"].Value = chk_acc;

                objSqlCommand.Parameters.Add("@puserid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@puserid"].Value = useid;

                objSqlCommand.Parameters.Add("@Adtype", SqlDbType.VarChar);
                if (adtype == "0" || adtype == "")
                {
                    objSqlCommand.Parameters["@Adtype"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@Adtype"].Value = adtype;
                }

                objSqlCommand.Parameters.Add("@pub_cent", SqlDbType.VarChar);
                if (pubcent == "0" || pubcent == "")
                {
                    objSqlCommand.Parameters["@pub_cent"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pub_cent"].Value = pubcent;
                }

                objSqlCommand.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (fromdate == "" || fromdate == null)
                {
                    objSqlCommand.Parameters["@fromdate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@fromdate"].Value = fromdate;
                }

                objSqlCommand.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (dateto == "" || dateto == null)
                {
                    objSqlCommand.Parameters["@dateto"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@dateto"].Value = dateto;
                }

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@pub_name", SqlDbType.VarChar);
                if (pub == "0" || pub == "")
                {
                    objSqlCommand.Parameters["@pub_name"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pub_name"].Value = pub;
                }

                objSqlCommand.Parameters.Add("@Region", SqlDbType.VarChar);
                if (region == "0" || region == "")
                {
                    objSqlCommand.Parameters["@Region"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@Region"].Value = region;
                }

                objSqlCommand.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dateformat"].Value = dateformat;

                objSqlCommand.Parameters.Add("@execut", SqlDbType.VarChar);
                if (execut == "0" || execut == "")
                {
                    objSqlCommand.Parameters["@execut"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@execut"].Value = execut;
                }


                objSqlCommand.Parameters.Add("@place", SqlDbType.VarChar);
                if (place == "0" || place == "")
                {
                    objSqlCommand.Parameters["@place"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@place"].Value = place;
                }

                objSqlCommand.Parameters.Add("@page", SqlDbType.VarChar);
                if (page == "0" || page == "")
                {
                    objSqlCommand.Parameters["@page"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@page"].Value = page;
                }


                objSqlCommand.Parameters.Add("@grp", SqlDbType.VarChar);
                objSqlCommand.Parameters["@grp"].Value = grp;

                objSqlCommand.Parameters.Add("@descid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@descid"].Value = descid;

                objSqlCommand.Parameters.Add("@ascdesc", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ascdesc"].Value = ascdesc;

                objSqlCommand.Parameters.Add("@agcat", SqlDbType.VarChar);
                if (agcat == "0" || agcat == "")
                {
                    objSqlCommand.Parameters["@agcat"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@agcat"].Value = ascdesc;
                }

                objSqlDataAdapter = new SqlDataAdapter();
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
        public DataSet executive(string fromdate, string dateto, string adtype, string team, string execut, string compcode, string dateformat, string ascdesc, string descid, string adcategory1, string publication1, string edition1, string pubce, string useid, string chk_acc)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Executivereport", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@chk_access", SqlDbType.VarChar);
                objSqlCommand.Parameters["@chk_access"].Value = chk_acc;

                objSqlCommand.Parameters.Add("@puserid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@puserid"].Value = useid;

                objSqlCommand.Parameters.Add("@adcategory", SqlDbType.VarChar);
                if (adcategory1 == "0" || adcategory1 == "")
                {
                    objSqlCommand.Parameters["@adcategory"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@adcategory"].Value = adcategory1;
                }

                objSqlCommand.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (fromdate == "")
                {
                    objSqlCommand.Parameters["@fromdate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@fromdate"].Value = fromdate;
                }

                objSqlCommand.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (dateto == "")
                {
                    objSqlCommand.Parameters["@dateto"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@dateto"].Value = dateto;
                }


                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;


                objSqlCommand.Parameters.Add("@team", SqlDbType.VarChar);
                if (team == "0" || team == "")
                {
                    objSqlCommand.Parameters["@team"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@team"].Value = team;
                }

                objSqlCommand.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dateformat"].Value = dateformat;

                objSqlCommand.Parameters.Add("@execut", SqlDbType.VarChar);
                if (execut == "0" || execut == "" || execut == "--Select Executive Name--")
                {
                    objSqlCommand.Parameters["@execut"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@execut"].Value = execut;
                }

                objSqlCommand.Parameters.Add("@descid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@descid"].Value = descid;

                objSqlCommand.Parameters.Add("@ascdesc", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ascdesc"].Value = ascdesc;

                objSqlCommand.Parameters.Add("@adtype1", SqlDbType.VarChar);
                if (adtype == "0" || adtype == "")
                {
                    objSqlCommand.Parameters["@adtype1"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@adtype1"].Value = adtype;
                }

                objSqlCommand.Parameters.Add("@publication1", SqlDbType.VarChar);
                if (publication1 == "0" || publication1 == "")
                {
                    objSqlCommand.Parameters["@publication1"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@publication1"].Value = publication1;
                }

                objSqlCommand.Parameters.Add("@edition1", SqlDbType.VarChar);
                if (edition1 == "0" || edition1 == "")
                {
                    objSqlCommand.Parameters["@edition1"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@edition1"].Value = edition1;
                }

                objSqlCommand.Parameters.Add("@pubcent1", SqlDbType.VarChar);
                if (pubce == "0" || pubce == "")
                {
                    objSqlCommand.Parameters["@pubcent1"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pubcent1"].Value = pubce;
                }
                objSqlCommand.Parameters.Add("@pextra1", SqlDbType.VarChar);
             
                    objSqlCommand.Parameters["@pextra1"].Value = System.DBNull.Value;
          
                objSqlDataAdapter = new SqlDataAdapter();
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
        public DataSet revonscreen(string frmdt, string todate, string publication, string edition, string dateformate, string adtype, string pubcent, string compcode, string useid, string chk_acc)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Summaryreport_rev", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.CommandTimeout = 0;

                objSqlCommand.Parameters.Add("@chk_access", SqlDbType.VarChar);
                objSqlCommand.Parameters["@chk_access"].Value = chk_acc;

                objSqlCommand.Parameters.Add("@puserid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@puserid"].Value = useid;
                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                // objSqlCommand.Parameters.Add("@dateformat", SqlDbType.VarChar);
                // objSqlCommand.Parameters["@dateformat"].Value = dateformate;

                objSqlCommand.Parameters.Add("@pubcode", SqlDbType.VarChar);
                if (publication == "0" || publication == "")
                {
                    objSqlCommand.Parameters["@pubcode"].Value = System.DBNull.Value;
                }
                else
                {

                    objSqlCommand.Parameters["@pubcode"].Value = publication;
                }
                objSqlCommand.Parameters.Add("@adtype", SqlDbType.VarChar);
                if (adtype == "0" || adtype == "")
                {
                    objSqlCommand.Parameters["@adtype"].Value = System.DBNull.Value;
                }
                else
                {

                    objSqlCommand.Parameters["@adtype"].Value = adtype;
                }


                objSqlCommand.Parameters.Add("@pubcent", SqlDbType.VarChar);
                if (pubcent == "0" || pubcent == "")
                {
                    objSqlCommand.Parameters["@pubcent"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pubcent"].Value = pubcent;
                }

                objSqlCommand.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (frmdt == "")
                {
                    objSqlCommand.Parameters["@fromdate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@fromdate"].Value = frmdt;

                }

                objSqlCommand.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (todate == "")
                {
                    objSqlCommand.Parameters["@dateto"].Value = System.DBNull.Value;
                }
                else
                {

                    objSqlCommand.Parameters["@dateto"].Value = todate;
                }

                objSqlCommand.Parameters.Add("@editioncode", SqlDbType.VarChar);
                if (edition == "" || edition == "0" || edition == "--Select Edition Name--")
                {
                    objSqlCommand.Parameters["@editioncode"].Value = System.DBNull.Value;
                }
                else
                {

                    objSqlCommand.Parameters["@editioncode"].Value = edition;
                }





                objSqlDataAdapter = new SqlDataAdapter();
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
        public DataSet IssueBusnonscreen(string frmdt, string todate, string publication, string edition, string dateformate, string adtype, string pubcent, string compcode, string useid, string chk_acc)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Summaryreport", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.CommandTimeout = 0;

                objSqlCommand.Parameters.Add("@chk_access", SqlDbType.VarChar);
                objSqlCommand.Parameters["@chk_access"].Value = chk_acc;

                objSqlCommand.Parameters.Add("@puserid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@puserid"].Value = useid;
                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

               // objSqlCommand.Parameters.Add("@dateformat", SqlDbType.VarChar);
               // objSqlCommand.Parameters["@dateformat"].Value = dateformate;

                objSqlCommand.Parameters.Add("@pubcode", SqlDbType.VarChar);
                if (publication == "0" || publication=="")
                {
                    objSqlCommand.Parameters["@pubcode"].Value = System.DBNull.Value;
                }
                else
                {

                    objSqlCommand.Parameters["@pubcode"].Value = publication;
                }
                objSqlCommand.Parameters.Add("@adtype", SqlDbType.VarChar);
                if (adtype == "0" || adtype == "")
                {
                    objSqlCommand.Parameters["@adtype"].Value = System.DBNull.Value;
                }
                else
                {

                    objSqlCommand.Parameters["@adtype"].Value = adtype;
                }


                objSqlCommand.Parameters.Add("@pubcent", SqlDbType.VarChar);
                if (pubcent == "0" || pubcent == "")
                {
                    objSqlCommand.Parameters["@pubcent"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pubcent"].Value = pubcent;
                }

                objSqlCommand.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (frmdt == "" )
                {
                    objSqlCommand.Parameters["@fromdate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@fromdate"].Value = frmdt;

                }

                objSqlCommand.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (todate == "")
                {
                    objSqlCommand.Parameters["@dateto"].Value = System.DBNull.Value;
                }
                else
                {

                    objSqlCommand.Parameters["@dateto"].Value = todate;
                }

                objSqlCommand.Parameters.Add("@editioncode", SqlDbType.VarChar);
                if (edition == "" || edition == "0")
                {
                    objSqlCommand.Parameters["@editioncode"].Value = System.DBNull.Value;
                }
                else
                {

                    objSqlCommand.Parameters["@editioncode"].Value = edition;
                }


              


                objSqlDataAdapter = new SqlDataAdapter();
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
        public DataSet displayonscreenreport(string frmdt, string todate, string compcode, string publication, string status, string edition, string pubcenter, string adtype, string adcategory, string dateformate, string descid, string ascdesc, string supplement, string package1, string editiondetail, string useid, string chk_access, string branch, string ro_status, string txt_designer)
        {
       
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection  = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Schedulereport1", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;
                objSqlCommand.Parameters.Add("@chk_access", SqlDbType.VarChar);
                objSqlCommand.Parameters["@chk_access"].Value = chk_access;

                objSqlCommand.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dateformat"].Value = dateformate;

                objSqlCommand.Parameters.Add("@puserid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@puserid"].Value = useid;


                objSqlCommand.Parameters.Add("@editiondtl", SqlDbType.VarChar);
                objSqlCommand.Parameters["@editiondtl"].Value = editiondetail;


                objSqlCommand.Parameters.Add("@packagecode", SqlDbType.VarChar);
                if (package1 == "0" || package1 == "")
                {
                    objSqlCommand.Parameters["@packagecode"].Value = System.DBNull.Value;
                }
                else
                {

                    objSqlCommand.Parameters["@packagecode"].Value = package1;
                }

                objSqlCommand.Parameters.Add("@pub_name", SqlDbType.VarChar);
                if (publication == "0")
                {
                    objSqlCommand.Parameters["@pub_name"].Value = System.DBNull.Value;
                }
                else
                {

                    objSqlCommand.Parameters["@pub_name"].Value = publication;
                }
                objSqlCommand.Parameters.Add("@supplement_name", SqlDbType.VarChar);
                if (supplement == "0" || supplement=="")
                {
                    objSqlCommand.Parameters["@supplement_name"].Value = System.DBNull.Value;
                }
                else
                {

                    objSqlCommand.Parameters["@supplement_name"].Value = supplement;
                }


                objSqlCommand.Parameters.Add("@descid", SqlDbType.VarChar);
                if (descid == "")
                {
                    objSqlCommand.Parameters["@descid"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@descid"].Value = descid;
                }

                objSqlCommand.Parameters.Add("@ascdesc", SqlDbType.VarChar);
                if (ascdesc == "")
                {
                    objSqlCommand.Parameters["@ascdesc"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@ascdesc"].Value = ascdesc;

                }
                
                objSqlCommand.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (frmdt == "")
                {
                    objSqlCommand.Parameters["@fromdate"].Value = System.DBNull.Value;
                }
                else
                {

                    objSqlCommand.Parameters["@fromdate"].Value = frmdt;
                }

                objSqlCommand.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (todate == "")
                {
                    objSqlCommand.Parameters["@dateto"].Value = System.DBNull.Value;
                }
                else
                {

                    objSqlCommand.Parameters["@dateto"].Value = todate;
                }


                objSqlCommand.Parameters.Add("@edition_name", SqlDbType.VarChar);
                if (edition == "0" || edition=="")
                {
                    objSqlCommand.Parameters["@edition_name"].Value = System.DBNull.Value;
                }
                else
                {

                    objSqlCommand.Parameters["@edition_name"].Value = edition;
                }



                objSqlCommand.Parameters.Add("@pub_cent", SqlDbType.VarChar);
                if (pubcenter == "0")
                {
                    objSqlCommand.Parameters["@pub_cent"].Value = System.DBNull.Value;
                }
                else
                {

                    objSqlCommand.Parameters["@pub_cent"].Value = pubcenter;
                }


                objSqlCommand.Parameters.Add("@adcatg", SqlDbType.VarChar);
                if (adcategory == "")
                {
                    objSqlCommand.Parameters["@adcatg"].Value = System.DBNull.Value;
                }
                else
                {

                    objSqlCommand.Parameters["@adcatg"].Value = adcategory;
                }

                objSqlCommand.Parameters.Add("@adtyp", SqlDbType.VarChar);
                if (adtype == "" || adtype == "0")
                {
                    objSqlCommand.Parameters["@adtyp"].Value = System.DBNull.Value;
                }
                else
                {

                    objSqlCommand.Parameters["@adtyp"].Value = adtype;
                }

                objSqlCommand.Parameters.Add("@drpstatus", SqlDbType.VarChar);
                //if (status == "cancel")
                //{
                //    objSqlCommand.Parameters["@drpstatus"].Value = "includecancel";
                //}
                //else
                //{

                //    objSqlCommand.Parameters["@drpstatus"].Value = "cancel";
                //}
                if (status == "cancel")
                {
                    objSqlCommand.Parameters["@drpstatus"].Value = "includecancel";
                }
                else if (status == "hold")
                {
                    objSqlCommand.Parameters["@drpstatus"].Value = "includehold";
                }
                else
                {
                    objSqlCommand.Parameters["@drpstatus"].Value = "cancel";
                }


                objSqlCommand.Parameters.Add("@p_branch", SqlDbType.VarChar);
                if (branch == "" || branch == "0")
                {
                    objSqlCommand.Parameters["@p_branch"].Value = System.DBNull.Value;
                }
                else
                {

                    objSqlCommand.Parameters["@p_branch"].Value = branch;
                }

                objSqlCommand.Parameters.Add("@ro_statusres", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ro_statusres"].Value = ro_status;

                objSqlCommand.Parameters.Add("@P_designer", SqlDbType.VarChar);
                if (txt_designer == "" || txt_designer == "0")
                {
                    objSqlCommand.Parameters["@P_designer"].Value = System.DBNull.Value;
                }
                else
                {
                    
                    objSqlCommand.Parameters["@P_designer"].Value = txt_designer;
                }




                objSqlDataAdapter = new SqlDataAdapter();
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
       public DataSet spfun1(string adtype, string adcategory, string adsubcategory, string fromdate, string dateto, string pubname, string pubcent, string compcode, string edition, string dateformat, string descid, string ascdesc, string agname, string clientname, string status, string hold, string agentyp, string useid, string chk_acc, string branch, string print_cent, string docket, string searching, string uom, string bukid,string currency)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection  = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("reportnew1", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.CommandTimeout = 0;
               

                objSqlCommand.Parameters.Add("@pbranch", SqlDbType.VarChar);
                if (branch == "0" || branch == "Select Branch" || branch=="")
                {
                    objSqlCommand.Parameters["@pbranch"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pbranch"].Value = branch;
                }
                

                objSqlCommand.Parameters.Add("@pprint_center", SqlDbType.VarChar);
                if (print_cent == "0" || print_cent=="")
                {
                    objSqlCommand.Parameters["@pprint_center"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pprint_center"].Value = print_cent;
                }
                


                objSqlCommand.Parameters.Add("@chk_access", SqlDbType.VarChar);
                objSqlCommand.Parameters["@chk_access"].Value = chk_acc;

                objSqlCommand.Parameters.Add("@puserid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@puserid"].Value = useid;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;


                objSqlCommand.Parameters.Add("@adtype1", SqlDbType.VarChar);
                if (adtype == "0")
                {
                    objSqlCommand.Parameters["@adtype1"].Value = System.DBNull.Value;
                }
                else
                {
                  
                    objSqlCommand.Parameters["@adtype1"].Value = adtype;
                }


                objSqlCommand.Parameters.Add("@adcategory", SqlDbType.VarChar);
                if (adcategory == "")
                {
                    objSqlCommand.Parameters["@adcategory"].Value = System.DBNull.Value;
                }
                else
                {

                    objSqlCommand.Parameters["@adcategory"].Value = adcategory;
                }

                objSqlCommand.Parameters.Add("@Adsubcategory", SqlDbType.VarChar);
                if (adsubcategory == "")
                {
                    objSqlCommand.Parameters["@Adsubcategory"].Value = System.DBNull.Value;
                }
                else
                {

                    objSqlCommand.Parameters["@Adsubcategory"].Value = adsubcategory;
                }

                objSqlCommand.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (fromdate == "")
                {
                    objSqlCommand.Parameters["@fromdate"].Value = System.DBNull.Value;
                }
                else
                {

                    objSqlCommand.Parameters["@fromdate"].Value = fromdate;
                }

                objSqlCommand.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (dateto == "")
                {
                    objSqlCommand.Parameters["@dateto"].Value = System.DBNull.Value;
                }
                else
                {

                    objSqlCommand.Parameters["@dateto"].Value = dateto;
                }

                objSqlCommand.Parameters.Add("@pub_name", SqlDbType.VarChar);
                if (pubname == "0")
                {
                    objSqlCommand.Parameters["@pub_name"].Value = System.DBNull.Value;
                }
                else
                {

                    objSqlCommand.Parameters["@pub_name"].Value = pubname;
                }

                objSqlCommand.Parameters.Add("@pub_cent", SqlDbType.VarChar);
                if (pubcent == "0")
                {
                    objSqlCommand.Parameters["@pub_cent"].Value = System.DBNull.Value;
                }
                else
                {

                    objSqlCommand.Parameters["@pub_cent"].Value = pubcent;
                }


                objSqlCommand.Parameters.Add("@edition", SqlDbType.VarChar);
                if (edition == "0")
                {
                    objSqlCommand.Parameters["@edition"].Value = System.DBNull.Value;
                }
                else
                {

                    objSqlCommand.Parameters["@edition"].Value = edition;
                }

                objSqlCommand.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dateformat"].Value = dateformat;


                objSqlCommand.Parameters.Add("@descid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@descid"].Value = descid;

                objSqlCommand.Parameters.Add("@ascdesc", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ascdesc"].Value = ascdesc;

                objSqlCommand.Parameters.Add("@agname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agname"].Value = agname;

                objSqlCommand.Parameters.Add("@clientname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@clientname"].Value = clientname;

                objSqlCommand.Parameters.Add("@status", SqlDbType.VarChar);
                objSqlCommand.Parameters["@status"].Value = status;

                objSqlCommand.Parameters.Add("@hold", SqlDbType.VarChar);
                objSqlCommand.Parameters["@hold"].Value = hold;

                objSqlCommand.Parameters.Add("@agtype", SqlDbType.VarChar);

                if (agentyp == "0" || agentyp == "--Select AgencyType--")
                {
                    objSqlCommand.Parameters["@agtype"].Value = System.DBNull.Value;
                }
                else
                {

                    objSqlCommand.Parameters["@agtype"].Value = agentyp;
                }

                objSqlCommand.Parameters.Add("@pwithout_rono", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pwithout_rono"].Value = docket;

                objSqlCommand.Parameters.Add("@pdate_flag", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdate_flag"].Value = searching;


                objSqlCommand.Parameters.Add("@pextra1", SqlDbType.VarChar);
                if(uom=="0" || uom=="")
                objSqlCommand.Parameters["@pextra1"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@pextra1"].Value = uom;

                objSqlCommand.Parameters.Add("@pextra2", SqlDbType.VarChar);
                if (bukid == "0" || bukid == "")
                    objSqlCommand.Parameters["@pextra2"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@pextra2"].Value = bukid;

                objSqlCommand.Parameters.Add("@pextra3", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra3"].Value = currency;

                objSqlCommand.Parameters.Add("@pextra4", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra4"].Value = System.DBNull.Value;

                objSqlCommand.Parameters.Add("@pextra5", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra5"].Value = System.DBNull.Value;


                objSqlDataAdapter = new SqlDataAdapter();
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



       public DataSet quotation_report(string adtype, string adcategory, string adsubcategory, string fromdate, string dateto, string pubname, string pubcent, string compcode, string edition, string dateformat, string descid, string ascdesc, string agname, string clientname, string status, string hold, string agentyp, string useid, string chk_acc, string branch, string print_cent, string docket, string searching, string uom, string bukid,string reporttype)
       {
           SqlConnection objSqlConnection;
           SqlCommand objSqlCommand;
           objSqlConnection = GetConnection();
           SqlDataAdapter objSqlDataAdapter;
           DataSet objDataSet = new DataSet();
           try
           {
               objSqlConnection.Open();
               objSqlCommand = GetCommand("AD_QUOTATION_LISTING", ref objSqlConnection);
               objSqlCommand.CommandType = CommandType.StoredProcedure;
               objSqlCommand.CommandTimeout = 0;


               objSqlCommand.Parameters.Add("@pbranch", SqlDbType.VarChar);
               if (branch == "0" || branch == "Select Branch" || branch == "")
               {
                   objSqlCommand.Parameters["@pbranch"].Value = System.DBNull.Value;
               }
               else
               {
                   objSqlCommand.Parameters["@pbranch"].Value = branch;
               }


               objSqlCommand.Parameters.Add("@pprint_center", SqlDbType.VarChar);
               if (print_cent == "0" || print_cent == "")
               {
                   objSqlCommand.Parameters["@pprint_center"].Value = System.DBNull.Value;
               }
               else
               {
                   objSqlCommand.Parameters["@pprint_center"].Value = print_cent;
               }



               objSqlCommand.Parameters.Add("@chk_access", SqlDbType.VarChar);
               objSqlCommand.Parameters["@chk_access"].Value = chk_acc;

               objSqlCommand.Parameters.Add("@puserid", SqlDbType.VarChar);
               objSqlCommand.Parameters["@puserid"].Value = useid;

               objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
               objSqlCommand.Parameters["@compcode"].Value = compcode;


               objSqlCommand.Parameters.Add("@adtype1", SqlDbType.VarChar);
               if (adtype == "0")
               {
                   objSqlCommand.Parameters["@adtype1"].Value = System.DBNull.Value;
               }
               else
               {

                   objSqlCommand.Parameters["@adtype1"].Value = adtype;
               }


               objSqlCommand.Parameters.Add("@adcategory", SqlDbType.VarChar);
               if (adcategory == "")
               {
                   objSqlCommand.Parameters["@adcategory"].Value = System.DBNull.Value;
               }
               else
               {

                   objSqlCommand.Parameters["@adcategory"].Value = adcategory;
               }

               objSqlCommand.Parameters.Add("@Adsubcategory", SqlDbType.VarChar);
               if (adsubcategory == "")
               {
                   objSqlCommand.Parameters["@Adsubcategory"].Value = System.DBNull.Value;
               }
               else
               {

                   objSqlCommand.Parameters["@Adsubcategory"].Value = adsubcategory;
               }

               objSqlCommand.Parameters.Add("@fromdate", SqlDbType.VarChar);
               if (fromdate == "")
               {
                   objSqlCommand.Parameters["@fromdate"].Value = System.DBNull.Value;
               }
               else
               {

                   objSqlCommand.Parameters["@fromdate"].Value = fromdate;
               }

               objSqlCommand.Parameters.Add("@dateto", SqlDbType.VarChar);
               if (dateto == "")
               {
                   objSqlCommand.Parameters["@dateto"].Value = System.DBNull.Value;
               }
               else
               {

                   objSqlCommand.Parameters["@dateto"].Value = dateto;
               }

               objSqlCommand.Parameters.Add("@pub_name", SqlDbType.VarChar);
               if (pubname == "0")
               {
                   objSqlCommand.Parameters["@pub_name"].Value = System.DBNull.Value;
               }
               else
               {

                   objSqlCommand.Parameters["@pub_name"].Value = pubname;
               }

               objSqlCommand.Parameters.Add("@pub_cent", SqlDbType.VarChar);
               if (pubcent == "0")
               {
                   objSqlCommand.Parameters["@pub_cent"].Value = System.DBNull.Value;
               }
               else
               {

                   objSqlCommand.Parameters["@pub_cent"].Value = pubcent;
               }


               objSqlCommand.Parameters.Add("@edition", SqlDbType.VarChar);
               if (edition == "0")
               {
                   objSqlCommand.Parameters["@edition"].Value = System.DBNull.Value;
               }
               else
               {

                   objSqlCommand.Parameters["@edition"].Value = edition;
               }

               objSqlCommand.Parameters.Add("@dateformat", SqlDbType.VarChar);
               objSqlCommand.Parameters["@dateformat"].Value = dateformat;


               objSqlCommand.Parameters.Add("@descid", SqlDbType.VarChar);
               objSqlCommand.Parameters["@descid"].Value = descid;

               objSqlCommand.Parameters.Add("@ascdesc", SqlDbType.VarChar);
               objSqlCommand.Parameters["@ascdesc"].Value = ascdesc;

               objSqlCommand.Parameters.Add("@agname", SqlDbType.VarChar);
               objSqlCommand.Parameters["@agname"].Value = agname;

               objSqlCommand.Parameters.Add("@clientname", SqlDbType.VarChar);
               objSqlCommand.Parameters["@clientname"].Value = clientname;

               objSqlCommand.Parameters.Add("@status", SqlDbType.VarChar);
               objSqlCommand.Parameters["@status"].Value = status;

               objSqlCommand.Parameters.Add("@hold", SqlDbType.VarChar);
               objSqlCommand.Parameters["@hold"].Value = hold;

               objSqlCommand.Parameters.Add("@agtype", SqlDbType.VarChar);

               if (agentyp == "0" || agentyp == "--Select AgencyType--")
               {
                   objSqlCommand.Parameters["@agtype"].Value = System.DBNull.Value;
               }
               else
               {

                   objSqlCommand.Parameters["@agtype"].Value = agentyp;
               }

               objSqlCommand.Parameters.Add("@pwithout_rono", SqlDbType.VarChar);
               objSqlCommand.Parameters["@pwithout_rono"].Value = docket;

               objSqlCommand.Parameters.Add("@pdate_flag", SqlDbType.VarChar);
               objSqlCommand.Parameters["@pdate_flag"].Value = searching;



               objSqlCommand.Parameters.Add("@preportype", SqlDbType.VarChar);
               objSqlCommand.Parameters["@preportype"].Value = reporttype;



               objSqlCommand.Parameters.Add("@pextra1", SqlDbType.VarChar);
               if (uom == "0" || uom == "")
                   objSqlCommand.Parameters["@pextra1"].Value = System.DBNull.Value;
               else
                   objSqlCommand.Parameters["@pextra1"].Value = uom;

               objSqlCommand.Parameters.Add("@pextra2", SqlDbType.VarChar);
               if (bukid == "0" || bukid == "")
                   objSqlCommand.Parameters["@pextra2"].Value = System.DBNull.Value;
               else
                   objSqlCommand.Parameters["@pextra2"].Value = bukid;

               objSqlCommand.Parameters.Add("@pextra3", SqlDbType.VarChar);
               objSqlCommand.Parameters["@pextra3"].Value = System.DBNull.Value;

               objSqlCommand.Parameters.Add("@pextra4", SqlDbType.VarChar);
               objSqlCommand.Parameters["@pextra4"].Value = System.DBNull.Value;

               objSqlCommand.Parameters.Add("@pextra5", SqlDbType.VarChar);
               objSqlCommand.Parameters["@pextra5"].Value = System.DBNull.Value;


               objSqlDataAdapter = new SqlDataAdapter();
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


        public DataSet spAgency(string agname, string adtype, string adcategory, string fromdate, string dateto, string pubname, string pubcent, string compcode, string edition, string dateformat, string descid, string ascdesc, string clientname, string status, string hold, string agentyp, string useid, string chk_acc, string extra1, string extra2, string extra3, string extra4, string extra5)
    
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
       
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("reportnew", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.CommandTimeout = 0;

                objSqlCommand.Parameters.Add("@chk_access", SqlDbType.VarChar);
                objSqlCommand.Parameters["@chk_access"].Value = chk_acc;

                objSqlCommand.Parameters.Add("@puserid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@puserid"].Value = useid;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;


                objSqlCommand.Parameters.Add("@adtype1", SqlDbType.VarChar);
                if (adtype == "0")
                {
                    objSqlCommand.Parameters["@adtype1"].Value = System.DBNull.Value;
                }
                else
                {

                    objSqlCommand.Parameters["@adtype1"].Value = adtype;
                }


                objSqlCommand.Parameters.Add("@adcategory", SqlDbType.VarChar);
                if (adcategory == "" || adcategory == "0")
                {
                    objSqlCommand.Parameters["@adcategory"].Value = System.DBNull.Value;
                }
                else
                {

                    objSqlCommand.Parameters["@adcategory"].Value = adcategory;
                }

               

                objSqlCommand.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (fromdate == "")
                {
                    objSqlCommand.Parameters["@fromdate"].Value = System.DBNull.Value;
                }
                else
                {

                    objSqlCommand.Parameters["@fromdate"].Value = fromdate;
                }

                objSqlCommand.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (dateto == "")
                {
                    objSqlCommand.Parameters["@dateto"].Value = System.DBNull.Value;
                }
                else
                {

                    objSqlCommand.Parameters["@dateto"].Value = dateto;
                }

                objSqlCommand.Parameters.Add("@pub_name", SqlDbType.VarChar);
                if (pubname == "0")
                {
                    objSqlCommand.Parameters["@pub_name"].Value = System.DBNull.Value;
                }
                else
                {

                    objSqlCommand.Parameters["@pub_name"].Value = pubname;
                }

                objSqlCommand.Parameters.Add("@pub_cent", SqlDbType.VarChar);
                if (pubcent == "0")
                {
                    objSqlCommand.Parameters["@pub_cent"].Value = System.DBNull.Value;
                }
                else
                {

                    objSqlCommand.Parameters["@pub_cent"].Value = pubcent;
                }


                objSqlCommand.Parameters.Add("@edition", SqlDbType.VarChar);
                if (edition == "0")
                {
                    objSqlCommand.Parameters["@edition"].Value = System.DBNull.Value;
                }
                else
                {

                    objSqlCommand.Parameters["@edition"].Value = edition;
                }

                objSqlCommand.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dateformat"].Value = dateformat;


                objSqlCommand.Parameters.Add("@descid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@descid"].Value = descid;

                objSqlCommand.Parameters.Add("@ascdesc", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ascdesc"].Value = ascdesc;

                objSqlCommand.Parameters.Add("@agname", SqlDbType.VarChar);
                if (agname == "0" || agname=="")
                {
                    objSqlCommand.Parameters["@agname"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@agname"].Value = agname;
                }

                objSqlCommand.Parameters.Add("@clientname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@clientname"].Value = clientname;

                objSqlCommand.Parameters.Add("@status", SqlDbType.VarChar);
                objSqlCommand.Parameters["@status"].Value = status;

                objSqlCommand.Parameters.Add("@hold", SqlDbType.VarChar);
                objSqlCommand.Parameters["@hold"].Value = hold;

                objSqlCommand.Parameters.Add("@agtype", SqlDbType.VarChar);

                if (agentyp == "0" || agentyp == "--Select AgencyType--")
                {
                    objSqlCommand.Parameters["@agtype"].Value = System.DBNull.Value;
                }
                else
                {

                    objSqlCommand.Parameters["@agtype"].Value = agentyp;
                }

                objSqlCommand.Parameters.Add("@pextra1", SqlDbType.VarChar);
                if (extra1 == "0" || extra1 == "")
                {
                    objSqlCommand.Parameters["@pextra1"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pextra1"].Value = extra1;
                }
                objSqlCommand.Parameters.Add("@pextra2", SqlDbType.VarChar);
                if (extra2 == "0" || extra2 == "")
                {
                    objSqlCommand.Parameters["@pextra2"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pextra2"].Value = extra2;
                }

                objSqlCommand.Parameters.Add("@pextra3", SqlDbType.VarChar);
                if (extra3 == "0" || extra3 == "")
                {
                    objSqlCommand.Parameters["@pextra3"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pextra3"].Value = extra3;
                }

                objSqlCommand.Parameters.Add("@pextra4", SqlDbType.VarChar);
                if (extra4 == "0" || extra4 == "")
                {
                    objSqlCommand.Parameters["@pextra4"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pextra4"].Value = extra4;
                }

                objSqlCommand.Parameters.Add("@pextra5", SqlDbType.VarChar);
                if (extra5 == "0" || extra5 == "")
                {
                    objSqlCommand.Parameters["@pextra5"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pextra5"].Value = extra5;
                }

                objSqlDataAdapter = new SqlDataAdapter();
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

        public DataSet spclient(string cliname, string adtype, string adcategory, string fromdate, string dateto, string pubname, string pubcent, string compcode, string edition, string dateformat, string descid, string ascdesc, string agname, string status, string hold, string agentyp, string useid, string chk_acc, string extra1, string extra2, string extra3, string extra4, string extra5)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("reportnew", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@chk_access", SqlDbType.VarChar);
                objSqlCommand.Parameters["@chk_access"].Value = chk_acc;

                objSqlCommand.Parameters.Add("@puserid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@puserid"].Value = useid;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;


                objSqlCommand.Parameters.Add("@adtype1", SqlDbType.VarChar);
                if (adtype == "0")
                {
                    objSqlCommand.Parameters["@adtype1"].Value = System.DBNull.Value;
                }
                else
                {

                    objSqlCommand.Parameters["@adtype1"].Value = adtype;
                }


                objSqlCommand.Parameters.Add("@adcategory", SqlDbType.VarChar);
                if (adcategory == "" || adcategory == "0")
                {
                    objSqlCommand.Parameters["@adcategory"].Value = System.DBNull.Value;
                }
                else
                {

                    objSqlCommand.Parameters["@adcategory"].Value = adcategory;
                }



                objSqlCommand.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (fromdate == "")
                {
                    objSqlCommand.Parameters["@fromdate"].Value = System.DBNull.Value;
                }
                else
                {

                    objSqlCommand.Parameters["@fromdate"].Value = fromdate;
                }

                objSqlCommand.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (dateto == "")
                {
                    objSqlCommand.Parameters["@dateto"].Value = System.DBNull.Value;
                }
                else
                {

                    objSqlCommand.Parameters["@dateto"].Value = dateto;
                }

                objSqlCommand.Parameters.Add("@pub_name", SqlDbType.VarChar);
                if (pubname == "0")
                {
                    objSqlCommand.Parameters["@pub_name"].Value = System.DBNull.Value;
                }
                else
                {

                    objSqlCommand.Parameters["@pub_name"].Value = pubname;
                }

                objSqlCommand.Parameters.Add("@pub_cent", SqlDbType.VarChar);
                if (pubcent == "0")
                {
                    objSqlCommand.Parameters["@pub_cent"].Value = System.DBNull.Value;
                }
                else
                {

                    objSqlCommand.Parameters["@pub_cent"].Value = pubcent;
                }


                objSqlCommand.Parameters.Add("@edition", SqlDbType.VarChar);
                if (edition == "0" || edition == "--Select Edition Name--")
                {
                    objSqlCommand.Parameters["@edition"].Value = System.DBNull.Value;
                }
                else
                {

                    objSqlCommand.Parameters["@edition"].Value = edition;
                }

                objSqlCommand.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dateformat"].Value = dateformat;


                objSqlCommand.Parameters.Add("@descid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@descid"].Value = descid;

                objSqlCommand.Parameters.Add("@ascdesc", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ascdesc"].Value = ascdesc;

                objSqlCommand.Parameters.Add("@agname", SqlDbType.VarChar);
                if (agname == "0")
                {
                    objSqlCommand.Parameters["@agname"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@agname"].Value = agname;
                }

                objSqlCommand.Parameters.Add("@clientname", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@clientname"].Value = clientname;
                if (cliname == "0" || cliname=="")
                {
                    objSqlCommand.Parameters["@clientname"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@clientname"].Value = cliname;
                }

                objSqlCommand.Parameters.Add("@status", SqlDbType.VarChar);
                objSqlCommand.Parameters["@status"].Value = status;

                objSqlCommand.Parameters.Add("@hold", SqlDbType.VarChar);
                objSqlCommand.Parameters["@hold"].Value = hold;

                objSqlCommand.Parameters.Add("@agtype", SqlDbType.VarChar);

                if (agentyp == "0" || agentyp == "--Select AgencyType--")
                {
                    objSqlCommand.Parameters["@agtype"].Value = System.DBNull.Value;
                }
                else
                {

                    objSqlCommand.Parameters["@agtype"].Value = agentyp;
                }

                objSqlCommand.Parameters.Add("@pextra1", SqlDbType.VarChar);
                if (extra1 == "0" || extra1 == "" || extra1=="--Select UOM--")
                {
                    objSqlCommand.Parameters["@pextra1"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pextra1"].Value = extra1;
                }
                objSqlCommand.Parameters.Add("@pextra2", SqlDbType.VarChar);
                if (extra2 == "0" || extra2 == "")
                {
                    objSqlCommand.Parameters["@pextra2"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pextra2"].Value = extra2;
                }

                objSqlCommand.Parameters.Add("@pextra3", SqlDbType.VarChar);
                if (extra3 == "0" || extra3 == "")
                {
                    objSqlCommand.Parameters["@pextra3"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pextra3"].Value = extra3;
                }

                objSqlCommand.Parameters.Add("@pextra4", SqlDbType.VarChar);
                if (extra4 == "0" || extra4 == "")
                {
                    objSqlCommand.Parameters["@pextra4"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pextra4"].Value = extra4;
                }

                objSqlCommand.Parameters.Add("@pextra5", SqlDbType.VarChar);
                if (extra5 == "0" || extra5 == "")
                {
                    objSqlCommand.Parameters["@pextra5"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pextra5"].Value = extra5;
                }



                objSqlDataAdapter = new SqlDataAdapter();
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



        public DataSet spStatus(string agname, string adtype, string adcategory, string fromdate, string dateto, string pubname, string pubcent, string compcode, string status, string edition, string dateformat, string hold, string descid, string ascdesc, string temp1, string agencytyp, string useid, string chk_acc)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("reportnew", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@chk_access", SqlDbType.VarChar);
                objSqlCommand.Parameters["@chk_access"].Value = chk_acc;

                objSqlCommand.Parameters.Add("@puserid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@puserid"].Value = useid;


                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;


                objSqlCommand.Parameters.Add("@adtype1", SqlDbType.VarChar);
                if (adtype == "0" || adtype=="")
                {
                    objSqlCommand.Parameters["@adtype1"].Value = System.DBNull.Value;
                }
                else
                {

                    objSqlCommand.Parameters["@adtype1"].Value = adtype;
                }


                objSqlCommand.Parameters.Add("@adcategory", SqlDbType.VarChar);
                if (adcategory == "" || adcategory == "0")
                {
                    objSqlCommand.Parameters["@adcategory"].Value = System.DBNull.Value;
                }
                else
                {

                    objSqlCommand.Parameters["@adcategory"].Value = adcategory;
                }



                objSqlCommand.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (fromdate == "")
                {
                    objSqlCommand.Parameters["@fromdate"].Value = System.DBNull.Value;
                }
                else
                {

                    objSqlCommand.Parameters["@fromdate"].Value = fromdate;
                }

                objSqlCommand.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (dateto == "")
                {
                    objSqlCommand.Parameters["@dateto"].Value = System.DBNull.Value;
                }
                else
                {

                    objSqlCommand.Parameters["@dateto"].Value = dateto;
                }

                objSqlCommand.Parameters.Add("@pub_name", SqlDbType.VarChar);
                if (pubname == "0")
                {
                    objSqlCommand.Parameters["@pub_name"].Value = System.DBNull.Value;
                }
                else
                {

                    objSqlCommand.Parameters["@pub_name"].Value = pubname;
                }

                objSqlCommand.Parameters.Add("@pub_cent", SqlDbType.VarChar);
                if (pubcent == "0")
                {
                    objSqlCommand.Parameters["@pub_cent"].Value = System.DBNull.Value;
                }
                else
                {

                    objSqlCommand.Parameters["@pub_cent"].Value = pubcent;
                }


                objSqlCommand.Parameters.Add("@edition", SqlDbType.VarChar);
                if (edition == "0" || edition == "--Select Edition Name--")
                {
                    objSqlCommand.Parameters["@edition"].Value = System.DBNull.Value;
                }
                else
                {

                    objSqlCommand.Parameters["@edition"].Value = edition;
                }

                objSqlCommand.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dateformat"].Value = dateformat;


                objSqlCommand.Parameters.Add("@descid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@descid"].Value = descid;

                objSqlCommand.Parameters.Add("@ascdesc", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ascdesc"].Value = ascdesc;

                objSqlCommand.Parameters.Add("@agname", SqlDbType.VarChar);
                if (agname == "0" || agname=="")
                {
                    objSqlCommand.Parameters["@agname"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@agname"].Value = agname;
                }

                objSqlCommand.Parameters.Add("@clientname", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@clientname"].Value = clientname;
                if (temp1 == "0" || temp1=="")
                {
                    objSqlCommand.Parameters["@clientname"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@clientname"].Value = temp1;
                }

                objSqlCommand.Parameters.Add("@status", SqlDbType.VarChar);
               // objSqlCommand.Parameters["@status"].Value = status;
                if (status == "0" )
                {
                    objSqlCommand.Parameters["@status"].Value = System.DBNull.Value;
                }
                else
                {

                    objSqlCommand.Parameters["@status"].Value = status;
                }

                objSqlCommand.Parameters.Add("@hold", SqlDbType.VarChar);
               // objSqlCommand.Parameters["@hold"].Value = hold;
                if (hold == "0")
                {
                    objSqlCommand.Parameters["@hold"].Value = System.DBNull.Value;
                }
                else
                {

                    objSqlCommand.Parameters["@hold"].Value = hold;
                }

                objSqlCommand.Parameters.Add("@agtype", SqlDbType.VarChar);

                if (agencytyp == "0" || agencytyp == "--Select AgencyType--")
                {
                    objSqlCommand.Parameters["@agtype"].Value = System.DBNull.Value;
                }
                else
                {

                    objSqlCommand.Parameters["@agtype"].Value = agencytyp;
                }

                objSqlDataAdapter = new SqlDataAdapter();
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
        public DataSet spDeviation(string cliname, string agname, string adtype, string adcategory, string fromdate, string dateto, string pubname, string pubcent, string compcode, string status, string edition, string dateformate, string hold, string descid, string ascdesc, string page, string position, string agentyp, string useid, string chk_acc, string extra1, string extra2, string extra3, string extra4, string extra5)
        {
            SqlConnection objsqlcon = new SqlConnection();
            SqlCommand objsqlcom;
            objsqlcon = GetConnection();
            SqlDataAdapter objsqldap = new SqlDataAdapter();
            DataSet objdataset = new DataSet();

            try
            {

                objsqlcon.Open();
                objsqlcom = GetCommand("deviationreport", ref objsqlcon);
                objsqlcom.CommandType = CommandType.StoredProcedure;

                objsqlcom.Parameters.Add("@chk_access", SqlDbType.VarChar);
                objsqlcom.Parameters["@chk_access"].Value = chk_acc;

                objsqlcom.Parameters.Add("@puserid", SqlDbType.VarChar);
                objsqlcom.Parameters["@puserid"].Value = useid;

                objsqlcom.Parameters.Add("@clientname", SqlDbType.VarChar);
                if (cliname == "0" || cliname=="")
                {
                    objsqlcom.Parameters["@clientname"].Value = System.DBNull.Value;
                }
                else
                {
                    objsqlcom.Parameters["@clientname"].Value = cliname;
                }
                objsqlcom.Parameters.Add("@agname", SqlDbType.VarChar);
                if (agname == "0" || agname=="")
                {
                    objsqlcom.Parameters["@agname"].Value = System.DBNull.Value;
                }
                else
                {
                    objsqlcom.Parameters["@agname"].Value = agname;
                }
               
                objsqlcom.Parameters.Add("@adtype", SqlDbType.VarChar);
                if (adtype == "0")
                {
                    objsqlcom.Parameters["@adtype"].Value = System.DBNull.Value;
                }
                else
                {
                    objsqlcom.Parameters["@adtype"].Value = adtype;
                }
               
                objsqlcom.Parameters.Add("@adcategory", SqlDbType.VarChar);
                if (adcategory == "0" || adcategory=="")
                {
                    objsqlcom.Parameters["@adcategory"].Value = System.DBNull.Value;
                }
                else
                {
                    objsqlcom.Parameters["@adcategory"].Value = adcategory;
                }
               

                objsqlcom.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (fromdate == "")
                {
                    objsqlcom.Parameters["@fromdate"].Value = System.DBNull.Value;
                    
                }
                else
                {
                    objsqlcom.Parameters["@fromdate"].Value = fromdate;
                }
                objsqlcom.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (dateto == "")
                {
                    objsqlcom.Parameters["@dateto"].Value = System.DBNull.Value;
                  
                }
                else
                {
                    objsqlcom.Parameters["@dateto"].Value = dateto;
                }

                objsqlcom.Parameters.Add("@compcode", SqlDbType.VarChar);
                objsqlcom.Parameters["@compcode"].Value = compcode;

                objsqlcom.Parameters.Add("@pub_name", SqlDbType.VarChar);
                if (pubname == "0")
                {
                    objsqlcom.Parameters["@pub_name"].Value = System.DBNull.Value;
                    
                }
                else
                {
                    objsqlcom.Parameters["@pub_name"].Value = pubname;
                }
                objsqlcom.Parameters.Add("@pub_cent", SqlDbType.VarChar);
                if (pubcent == "0")
                {
                    objsqlcom.Parameters["@pub_cent"].Value = System.DBNull.Value;
                   
                }
                else
                {
                    objsqlcom.Parameters["@pub_cent"].Value = pubcent;
                }

                objsqlcom.Parameters.Add("@edition", SqlDbType.VarChar);
                if (edition == "0" || edition == "")
                {
                    objsqlcom.Parameters["@edition"].Value = System.DBNull.Value;

                }

                else
                {
                    objsqlcom.Parameters["@edition"].Value = edition;
                }
                objsqlcom.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objsqlcom.Parameters["@dateformat"].Value = dateformate;

                objsqlcom.Parameters.Add("@status", SqlDbType.VarChar);

                if (status == "0")
                {
                    objsqlcom.Parameters["@status"].Value = System.DBNull.Value;
                   
                }
                else
                {
                    objsqlcom.Parameters["@status"].Value = status;
                }
                objsqlcom.Parameters.Add("@hold", SqlDbType.VarChar);
                if (hold == "0")
                {
                    objsqlcom.Parameters["@hold"].Value = System.DBNull.Value;
                    
                }
                else
                {
                    objsqlcom.Parameters["@hold"].Value = hold;
                }



                objsqlcom.Parameters.Add("@descid", SqlDbType.VarChar);
                objsqlcom.Parameters["@descid"].Value = descid;



                objsqlcom.Parameters.Add("@ascdesc", SqlDbType.VarChar);
                objsqlcom.Parameters["@ascdesc"].Value = ascdesc;

                objsqlcom.Parameters.Add("@page", SqlDbType.VarChar);
                if (page == "0")
                {
                    objsqlcom.Parameters["@page"].Value = System.DBNull.Value;

                }
                else
                {
                    objsqlcom.Parameters["@page"].Value = page;
                }

                objsqlcom.Parameters.Add("@position", SqlDbType.VarChar);
                if (position == "0")
                {
                    objsqlcom.Parameters["@position"].Value = System.DBNull.Value;

                }
                else
                {
                    objsqlcom.Parameters["@position"].Value = position;
                }


                objsqlcom.Parameters.Add("@agtype", SqlDbType.VarChar);
                if (agentyp == "0" || agentyp == "--Select AgencyType--")
                {
                    objsqlcom.Parameters["@agtype"].Value = System.DBNull.Value;

                }
                else
                {
                    objsqlcom.Parameters["@agtype"].Value = agentyp;
                }

                objsqlcom.Parameters.Add("@pextra1", SqlDbType.VarChar);
                if (extra1 == "0" || extra1 == "")
                {
                    objsqlcom.Parameters["@pextra1"].Value = System.DBNull.Value;
                }
                else
                {
                    objsqlcom.Parameters["@pextra1"].Value = extra1;
                }
                objsqlcom.Parameters.Add("@pextra2", SqlDbType.VarChar);
                if (extra2 == "0" || extra2 == "")
                {
                    objsqlcom.Parameters["@pextra2"].Value = System.DBNull.Value;
                }
                else
                {
                    objsqlcom.Parameters["@pextra2"].Value = extra2;
                }

                objsqlcom.Parameters.Add("@pextra3", SqlDbType.VarChar);
                if (extra3 == "0" || extra3 == "")
                {
                    objsqlcom.Parameters["@pextra3"].Value = System.DBNull.Value;
                }
                else
                {
                    objsqlcom.Parameters["@pextra3"].Value = extra3;
                }

                objsqlcom.Parameters.Add("@pextra4", SqlDbType.VarChar);
                if (extra4 == "0" || extra4 == "")
                {
                    objsqlcom.Parameters["@pextra4"].Value = System.DBNull.Value;
                }
                else
                {
                    objsqlcom.Parameters["@pextra4"].Value = extra4;
                }

                objsqlcom.Parameters.Add("@pextra5", SqlDbType.VarChar);
                if (extra5 == "0" || extra5 == "")
                {
                    objsqlcom.Parameters["@pextra5"].Value = System.DBNull.Value;
                }
                else
                {
                    objsqlcom.Parameters["@pextra5"].Value = extra5;
                }


objsqlcom.CommandTimeout=0;
                objsqldap.SelectCommand = objsqlcom;
                objsqldap.Fill(objdataset);

                return objdataset;



            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {


                CloseConnection(ref objsqlcon);
            }




        }
        //public DataSet vtsreport(string agnecycode, string clientcode, string fromdate, string dateto, string pubname, string pubcent , string branch_c, string edition, string dateformat, string useid, string compcode, string chk_acc, string extra1, string extra2)
        //{
        //    SqlConnection objsqlcon = new SqlConnection();
        //    SqlCommand objsqlcom;
        //    objsqlcon = GetConnection();
        //    SqlDataAdapter objsqldap = new SqlDataAdapter();
        //    DataSet objdataset = new DataSet();

        //    try
        //    {

        //        objsqlcon.Open();
        //        objsqlcom = GetCommand("rpt_vts_report", ref objsqlcon);
        //        objsqlcom.CommandType = CommandType.StoredProcedure;       
                                
        //        objsqlcom.Parameters.Add("@pagency_code", SqlDbType.VarChar);
        //        if (agnecycode == "0" || agnecycode == "")
        //        {
        //            objsqlcom.Parameters["@pagency_code"].Value = System.DBNull.Value;
        //        }
        //        else
        //        {
        //            objsqlcom.Parameters["@pagency_code"].Value = agnecycode;
        //        }

        //        objsqlcom.Parameters.Add("@pclient_code", SqlDbType.VarChar);
        //        if (clientcode == "0" || clientcode == "")
        //        {
        //            objsqlcom.Parameters["@pclient_code"].Value = System.DBNull.Value;
        //        }
        //        else
        //        {
        //            objsqlcom.Parameters["@pclient_code"].Value = clientcode;
        //        }


        //        objsqlcom.Parameters.Add("@pfrom_date", SqlDbType.VarChar);
        //        if (fromdate == "")
        //        {
        //            objsqlcom.Parameters["@pfrom_date"].Value = System.DBNull.Value;
        //        }
        //        else
        //        {
        //            objsqlcom.Parameters["@pfrom_date"].Value = fromdate;
        //        }

        //        objsqlcom.Parameters.Add("@pto_date", SqlDbType.VarChar);
        //        if (dateto == "")
        //        {
        //            objsqlcom.Parameters["@pto_date"].Value = System.DBNull.Value;

        //        }
        //        else
        //        {
        //            objsqlcom.Parameters["@pto_date"].Value = dateto;
        //        }        
        //        objsqlcom.Parameters.Add("@pdateformat", SqlDbType.VarChar);
        //        objsqlcom.Parameters["@pdateformat"].Value = dateformat;

        //        objsqlcom.Parameters.Add("@ppublication", SqlDbType.VarChar);
        //        if (pubname == "0" || pubname == "")
        //        {
        //            objsqlcom.Parameters["@ppublication"].Value = System.DBNull.Value;

        //        }
        //        else
        //        {
        //            objsqlcom.Parameters["@ppublication"].Value = pubname;
        //        }

        //        objsqlcom.Parameters.Add("@pedition", SqlDbType.VarChar);
        //        if (edition == "0" || edition == "")
        //        {
        //            objsqlcom.Parameters["@pedition"].Value = System.DBNull.Value;

        //        }

        //        else
        //        {
        //            objsqlcom.Parameters["@pedition"].Value = edition;
        //        }

        //        objsqlcom.Parameters.Add("@ppub_center", SqlDbType.VarChar);
        //        if (pubcent == "0" || pubcent == "")
        //        {
        //            objsqlcom.Parameters["@ppub_center"].Value = System.DBNull.Value;

        //        }
        //        else
        //        {
        //            objsqlcom.Parameters["@ppub_center"].Value = pubcent;
        //        }


        //        objsqlcom.Parameters.Add("@pbranch", SqlDbType.VarChar);
        //        if (branch_c == "0" || branch_c == "")
        //        {
        //            objsqlcom.Parameters["@pbranch"].Value = System.DBNull.Value;
        //        }
        //        else
        //        {
        //            objsqlcom.Parameters["@pbranch"].Value = branch_c;
        //        }

              

        //        objsqlcom.Parameters.Add("@pcompcode", SqlDbType.VarChar);
        //        objsqlcom.Parameters["@pcompcode"].Value = compcode;

        //        objsqlcom.Parameters.Add("@puserid", SqlDbType.VarChar);
        //        objsqlcom.Parameters["@puserid"].Value = useid;


        //        objsqlcom.Parameters.Add("@chk_access", SqlDbType.VarChar);
               
        //            objsqlcom.Parameters["@chk_access"].Value = "0";
                


        //        objsqlcom.Parameters.Add("@pextra1", SqlDbType.VarChar);
        //        if (extra1 == "0" || extra1 == "")
        //        {
        //            objsqlcom.Parameters["@pextra1"].Value = System.DBNull.Value;
        //        }
        //        else
        //        {
        //            objsqlcom.Parameters["@pextra1"].Value = extra1;
        //        }

        //        objsqlcom.Parameters.Add("@pextra2", SqlDbType.VarChar);
        //        if (extra2 == "0" || extra2 == "")
        //        {
        //            objsqlcom.Parameters["@pextra2"].Value = System.DBNull.Value;
        //        }
        //        else
        //        {
        //            objsqlcom.Parameters["@pextra2"].Value = extra2;
        //        }

        //        objsqldap.SelectCommand = objsqlcom;
        //        objsqldap.Fill(objdataset);

        //        return objdataset;

        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //    finally
        //    {


        //        CloseConnection(ref objsqlcon);
        //    }


        //}

        public DataSet booking(string agnecycode, string clientcode, string fromdate, string dateto, string pubname, string pubcent, string branch_c, string edition, string dateformat, string useid, string compcode, string chk_acc, string extra1, string extra2)
        {
            SqlConnection objsqlcon = new SqlConnection();
            SqlCommand objsqlcom;
            objsqlcon = GetConnection();
            SqlDataAdapter objsqldap = new SqlDataAdapter();
            DataSet objdataset = new DataSet();

            try
            {

                objsqlcon.Open();
                objsqlcom = GetCommand("rpt_booking_report", ref objsqlcon);
                objsqlcom.CommandType = CommandType.StoredProcedure;

                objsqlcom.Parameters.Add("@pagency_code", SqlDbType.VarChar);
                if (agnecycode == "0" || agnecycode == "")
                {
                    objsqlcom.Parameters["@pagency_code"].Value = System.DBNull.Value;
                }
                else
                {
                    objsqlcom.Parameters["@pagency_code"].Value = agnecycode;
                }

                objsqlcom.Parameters.Add("@pclient_code", SqlDbType.VarChar);
                if (clientcode == "0" || clientcode == "")
                {
                    objsqlcom.Parameters["@pclient_code"].Value = System.DBNull.Value;
                }
                else
                {
                    objsqlcom.Parameters["@pclient_code"].Value = clientcode;
                }


                objsqlcom.Parameters.Add("@pfrom_date", SqlDbType.VarChar);
                //if (fromdate == "")
                //{
                //    objsqlcom.Parameters["@pfrom_date"].Value = System.DBNull.Value;
                //}
                //else
                //{
                    objsqlcom.Parameters["@pfrom_date"].Value = fromdate;
                //}

                    objsqlcom.Parameters.Add("@pto_date", SqlDbType.VarChar);
                    //if (dateto == "")
                    //{
                    //    objsqlcom.Parameters["@pto_date"].Value = System.DBNull.Value;

                    //}
                    //else
                    //{
                        objsqlcom.Parameters["@pto_date"].Value = dateto;
                    //}
                objsqlcom.Parameters.Add("@pdateformat", SqlDbType.VarChar);
                objsqlcom.Parameters["@pdateformat"].Value = dateformat;

                objsqlcom.Parameters.Add("@ppublication", SqlDbType.VarChar);
                if (pubname == "0" || pubname == "")
                {
                    objsqlcom.Parameters["@ppublication"].Value = System.DBNull.Value;

                }
                else
                {
                    objsqlcom.Parameters["@ppublication"].Value = pubname;
                }

                objsqlcom.Parameters.Add("@pedition", SqlDbType.VarChar);
                if (edition == "0" || edition == "")
                {
                    objsqlcom.Parameters["@pedition"].Value = System.DBNull.Value;

                }

                else
                {
                    objsqlcom.Parameters["@pedition"].Value = edition;
                }

                objsqlcom.Parameters.Add("@ppub_center", SqlDbType.VarChar);
                if (pubcent == "0" || pubcent == "")
                {
                    objsqlcom.Parameters["@ppub_center"].Value = System.DBNull.Value;

                }
                else
                {
                    objsqlcom.Parameters["@ppub_center"].Value = pubcent;
                }


                objsqlcom.Parameters.Add("@pbranch", SqlDbType.VarChar);
                if (branch_c == "0" || branch_c == "")
                {
                    objsqlcom.Parameters["@pbranch"].Value = System.DBNull.Value;
                }
                else
                {
                    objsqlcom.Parameters["@pbranch"].Value = branch_c;
                }



                objsqlcom.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                objsqlcom.Parameters["@pcompcode"].Value = compcode;

                objsqlcom.Parameters.Add("@puserid", SqlDbType.VarChar);
                objsqlcom.Parameters["@puserid"].Value = useid;


                objsqlcom.Parameters.Add("@chk_access", SqlDbType.VarChar);

                objsqlcom.Parameters["@chk_access"].Value = "0";



                objsqlcom.Parameters.Add("@pextra1", SqlDbType.VarChar);
                if (extra1 == "0" || extra1 == "")
                {
                    objsqlcom.Parameters["@pextra1"].Value = System.DBNull.Value;
                }
                else
                {
                    objsqlcom.Parameters["@pextra1"].Value = extra1;
                }

                objsqlcom.Parameters.Add("@pextra2", SqlDbType.VarChar);
                if (extra2 == "0" || extra2 == "")
                {
                    objsqlcom.Parameters["@pextra2"].Value = System.DBNull.Value;
                }
                else
                {
                    objsqlcom.Parameters["@pextra2"].Value = extra2;
                }

                objsqldap.SelectCommand = objsqlcom;
                objsqldap.Fill(objdataset);

                return objdataset;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {


                CloseConnection(ref objsqlcon);
            }


        }

        public DataSet spPagepremium(string page, string position, string fromdate, string dateto, string pubname, string pubcent, string compcode, string edition, string dateformat, string hold, string descid, string ascdesc, string temp1, string temp2, string temp3, string temp4, string temp5, string agentyp, string useid, string chk_acc)
        {
            SqlConnection objsqlcon = new SqlConnection();
            SqlCommand objsqlcom;
            objsqlcon = GetConnection();
            SqlDataAdapter objsqldap = new SqlDataAdapter();
            DataSet objdataset = new DataSet();

            try
            {

                objsqlcon.Open();
                objsqlcom = GetCommand("pagepremiumreport", ref objsqlcon);
                objsqlcom.CommandType = CommandType.StoredProcedure;

                objsqlcom.Parameters.Add("@chk_access", SqlDbType.VarChar);
                objsqlcom.Parameters["@chk_access"].Value = chk_acc;

                objsqlcom.Parameters.Add("@puserid", SqlDbType.VarChar);
                objsqlcom.Parameters["@puserid"].Value = useid;

                objsqlcom.Parameters.Add("@page", SqlDbType.VarChar);
                if (page == "0")
                {
                    objsqlcom.Parameters["@page"].Value = System.DBNull.Value;
                }
                else
                {
                    objsqlcom.Parameters["@page"].Value = page;
                }

                objsqlcom.Parameters.Add("@position", SqlDbType.VarChar);
                if (position == "0")
                {
                    objsqlcom.Parameters["@position"].Value = System.DBNull.Value;
                }
                else
                {
                    objsqlcom.Parameters["@position"].Value = position;
                }

                objsqlcom.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if ( fromdate=="")
                {
                    objsqlcom.Parameters["@fromdate"].Value = System.DBNull.Value;
                }
                else
                {
                    objsqlcom.Parameters["@fromdate"].Value = fromdate;
                }

                


                objsqlcom.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (dateto == "")
                {
                    objsqlcom.Parameters["@dateto"].Value = System.DBNull.Value;

                }
                else
                {
                    objsqlcom.Parameters["@dateto"].Value = dateto;
                }


                objsqlcom.Parameters.Add("@compcode", SqlDbType.VarChar);
                objsqlcom.Parameters["@compcode"].Value = compcode;

                objsqlcom.Parameters.Add("@pub_name", SqlDbType.VarChar);
                if (pubname == "0")
                {
                    objsqlcom.Parameters["@pub_name"].Value = System.DBNull.Value;

                }
                else
                {
                    objsqlcom.Parameters["@pub_name"].Value = pubname;
                }
                objsqlcom.Parameters.Add("@pub_cent", SqlDbType.VarChar);
                if (pubcent == "0")
                {
                    objsqlcom.Parameters["@pub_cent"].Value = System.DBNull.Value;

                }
                else
                {
                    objsqlcom.Parameters["@pub_cent"].Value = pubcent;
                }

                objsqlcom.Parameters.Add("@edition", SqlDbType.VarChar);
                if (edition == "0" || edition == "" || edition == "--Select Edition Name--")
                {
                    objsqlcom.Parameters["@edition"].Value = System.DBNull.Value;

                }

                else
                {
                    objsqlcom.Parameters["@edition"].Value = edition;
                }
                objsqlcom.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objsqlcom.Parameters["@dateformat"].Value = dateformat;

                objsqlcom.Parameters.Add("@status", SqlDbType.VarChar);

                if (temp4 == "0")
                {
                    objsqlcom.Parameters["@status"].Value = System.DBNull.Value;

                }
                else
                {
                    objsqlcom.Parameters["@status"].Value = temp4;
                }
                objsqlcom.Parameters.Add("@hold", SqlDbType.VarChar);
                if (hold == "0")
                {
                    objsqlcom.Parameters["@hold"].Value = System.DBNull.Value;

                }
                else
                {
                    objsqlcom.Parameters["@hold"].Value = hold;
                }



                objsqlcom.Parameters.Add("@descid", SqlDbType.VarChar);
                objsqlcom.Parameters["@descid"].Value = descid;



                objsqlcom.Parameters.Add("@ascdesc", SqlDbType.VarChar);
                objsqlcom.Parameters["@ascdesc"].Value = ascdesc;

                objsqlcom.Parameters.Add("@adtype1", SqlDbType.VarChar);
                if (temp2 == "0")
                {
                    objsqlcom.Parameters["@adtype1"].Value = System.DBNull.Value;

                }
                else
                {
                    objsqlcom.Parameters["@adtype1"].Value = temp2;
                }

                objsqlcom.Parameters.Add("@Adcategory", SqlDbType.VarChar);
                if (temp3 == "0")
                {
                    objsqlcom.Parameters["@Adcategory"].Value = System.DBNull.Value;

                }
                else
                {
                    objsqlcom.Parameters["@Adcategory"].Value = temp3;
                }

                objsqlcom.Parameters.Add("@clientname", SqlDbType.VarChar);
                if (temp5 == "0" || temp5=="")
                {
                    objsqlcom.Parameters["@clientname"].Value = System.DBNull.Value;

                }
                else
                {
                    objsqlcom.Parameters["@clientname"].Value = temp5;
                }

                objsqlcom.Parameters.Add("@agname", SqlDbType.VarChar);
                if (temp1 == "0" || temp1=="")
                {
                    objsqlcom.Parameters["@agname"].Value = System.DBNull.Value;

                }
                else
                {
                    objsqlcom.Parameters["@agname"].Value = temp1;

                }
                objsqlcom.Parameters.Add("@agtype", SqlDbType.VarChar);
                if (agentyp == "0" || agentyp == "--Select AgencyType--")
                {
                    objsqlcom.Parameters["@agtype"].Value = System.DBNull.Value;

                }
                else
                {
                    objsqlcom.Parameters["@agtype"].Value = agentyp;
                }


                objsqldap.SelectCommand = objsqlcom;
                objsqldap.Fill(objdataset);

                return objdataset;



            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {


                CloseConnection(ref objsqlcon);
            }

        }




        public DataSet areasummaryrpt(string compcode, string adtype, string fromdate, string dateto,string publication, string pubcent, string edition)
        {
            SqlConnection objsqlcon = new SqlConnection();
            SqlCommand objsqlcom;
            objsqlcon = GetConnection();
            SqlDataAdapter objsqldap = new SqlDataAdapter();
            DataSet objdataset = new DataSet();

            try
            {
                string dateformat = "dd/mm/yyyy";
                objsqlcon.Open();
                objsqlcom = GetCommand("websp_booking_area_summary", ref objsqlcon);
                objsqlcom.CommandType = CommandType.StoredProcedure;

                objsqlcom.Parameters.Add("@compcode", SqlDbType.VarChar);
                objsqlcom.Parameters["@compcode"].Value = compcode;


                objsqlcom.Parameters.Add("@adtype", SqlDbType.VarChar);

                if (adtype == "0")
                {
                    objsqlcom.Parameters["@adtype"].Value = System.DBNull.Value;

                }
                else
                {
                    objsqlcom.Parameters["@adtype"].Value = adtype;

                }

                objsqlcom.Parameters.Add("@validfrom", SqlDbType.VarChar);
                if (dateformat == "dd/mm/yyyy")
                {
                    string[] arr = fromdate.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    fromdate = mm + "/" + dd + "/" + yy;
                }
                objsqlcom.Parameters["@validfrom"].Value = fromdate;



                objsqlcom.Parameters.Add("@validto", SqlDbType.VarChar);
                  if (dateformat == "dd/mm/yyyy")
                {
                    string[] arr = dateto.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    dateto = mm + "/" + dd + "/" + yy;
                }
                objsqlcom.Parameters["@validto"].Value = dateto;

                objsqlcom.Parameters.Add("@pub_name", SqlDbType.VarChar);
                if (publication == "0")
                {
                    objsqlcom.Parameters["@pub_name"].Value = System.DBNull.Value;

                }
                else
                {
                    objsqlcom.Parameters["@pub_name"].Value = publication;

                }


                objsqlcom.Parameters.Add("@pub_cent", SqlDbType.VarChar);
                if (pubcent == "0")
                {
                    objsqlcom.Parameters["@pub_cent"].Value = System.DBNull.Value;

                }
                else
                {
                    objsqlcom.Parameters["@pub_cent"].Value = pubcent;

                }

                objsqlcom.Parameters.Add("@edition", SqlDbType.VarChar);
                if (edition == "0")
                {
                    objsqlcom.Parameters["@edition"].Value = System.DBNull.Value;

                }
                else
                {
                    objsqlcom.Parameters["@edition"].Value = edition;

                }


                objsqldap.SelectCommand = objsqlcom;
                objsqldap.Fill(objdataset);

                return objdataset;



            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {


                CloseConnection(ref objsqlcon);
            }

        }


 //=================================== **** Call Procedure for Receipt Register ****=====================//
        public DataSet rpt_booking_receipt(string frmdt, string todate, string compcode, string client, string agency, string dateformate, string paymode, string adtype, string branch, string usercode, string pubcent, string useid, string chk_acc, string puom)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("rpt_booking_collection", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                //objSqlCommand.
                objSqlCommand.Parameters.Add("@chk_access", SqlDbType.VarChar);
                objSqlCommand.Parameters["@chk_access"].Value = chk_acc;

                objSqlCommand.Parameters.Add("@puserid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@puserid"].Value = useid;

                objSqlCommand.Parameters.Add("@useridcode", SqlDbType.VarChar);
                if (usercode == "0")
                {
                    objSqlCommand.Parameters["@useridcode"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@useridcode"].Value = usercode;
                }

                objSqlCommand.Parameters.Add("@pbranch", SqlDbType.VarChar);
                if (branch == "0" || branch == "")
                {
                    objSqlCommand.Parameters["@pbranch"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pbranch"].Value = branch;
                }


                objSqlCommand.Parameters.Add("@pub_cent", SqlDbType.VarChar);
                if (pubcent == "0")
                {
                    objSqlCommand.Parameters["@pub_cent"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pub_cent"].Value = pubcent;
                }

                objSqlCommand.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (frmdt == "")
                {
                    objSqlCommand.Parameters["@fromdate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@fromdate"].Value = frmdt;
                }

                objSqlCommand.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (todate == "")
                {
                    objSqlCommand.Parameters["@dateto"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@dateto"].Value = todate;
                }

                objSqlCommand.Parameters.Add("@agname", SqlDbType.VarChar);
                if (agency == "0" || agency == "")
                {
                    objSqlCommand.Parameters["@agname"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@agname"].Value = agency;
                }

                objSqlCommand.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dateformat"].Value = dateformate;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@client", SqlDbType.VarChar);
                if (client == "0" || client == "")
                {
                    objSqlCommand.Parameters["@client"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@client"].Value = client;
                }

                objSqlCommand.Parameters.Add("@agencypay", SqlDbType.VarChar);
                if (paymode == "0")
                {
                    objSqlCommand.Parameters["@agencypay"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@agencypay"].Value = paymode;
                }


                objSqlCommand.Parameters.Add("@advtype", SqlDbType.VarChar);
                if (adtype == "0")
                {
                    objSqlCommand.Parameters["@advtype"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@advtype"].Value = adtype;
                }

                objSqlCommand.Parameters.Add("@puom_code", SqlDbType.VarChar);
                if (puom == "0" || puom == "")
                    objSqlCommand.Parameters["@puom_code"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@puom_code"].Value = puom;

                objSqlCommand.Parameters.Add("@rostatus", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rostatus"].Value = System.DBNull.Value;


                objSqlDataAdapter = new SqlDataAdapter();
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

        public DataSet spSUMMARYAgency(string agname, string adtype, string adcategory, string fromdate, string dateto, string pubname, string pubcent, string compcode, string edition, string dateformat, string descid, string ascdesc, string clientname, string status, string hold, string agentyp, string useid, string chk_acc)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();

            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("reportnew", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.CommandTimeout = 0;

                objSqlCommand.Parameters.Add("@chk_access", SqlDbType.VarChar);
                objSqlCommand.Parameters["@chk_access"].Value = chk_acc;

                objSqlCommand.Parameters.Add("@puserid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@puserid"].Value = useid;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;


                objSqlCommand.Parameters.Add("@adtype1", SqlDbType.VarChar);
                if (adtype == "0")
                {
                    objSqlCommand.Parameters["@adtype1"].Value = System.DBNull.Value;
                }
                else
                {

                    objSqlCommand.Parameters["@adtype1"].Value = adtype;
                }


                objSqlCommand.Parameters.Add("@adcategory", SqlDbType.VarChar);
                if (adcategory == "" || adcategory == "0")
                {
                    objSqlCommand.Parameters["@adcategory"].Value = System.DBNull.Value;
                }
                else
                {

                    objSqlCommand.Parameters["@adcategory"].Value = adcategory;
                }



                objSqlCommand.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (fromdate == "")
                {
                    objSqlCommand.Parameters["@fromdate"].Value = System.DBNull.Value;
                }
                else
                {
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
                }

                objSqlCommand.Parameters.Add("@dateto", SqlDbType.VarChar);

               if (dateto == "")
               {
                   objSqlCommand.Parameters["@dateto"].Value = System.DBNull.Value;
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
                   else if (dateformat == "yyyy/mm/dd")
                   {
                       string[] arr = dateto.Split('/');
                       string dd = arr[2];
                       string mm = arr[1];
                       string yy = arr[0];
                       dateto = mm + "/" + dd + "/" + yy;
                   }
                   

                    objSqlCommand.Parameters["@dateto"].Value = dateto;
                }

                objSqlCommand.Parameters.Add("@pub_name", SqlDbType.VarChar);
                if (pubname == "0")
                {
                    objSqlCommand.Parameters["@pub_name"].Value = System.DBNull.Value;
                }
                else
                {

                    objSqlCommand.Parameters["@pub_name"].Value = pubname;
                }

                objSqlCommand.Parameters.Add("@pub_cent", SqlDbType.VarChar);
                if (pubcent == "0")
                {
                    objSqlCommand.Parameters["@pub_cent"].Value = System.DBNull.Value;
                }
                else
                {

                    objSqlCommand.Parameters["@pub_cent"].Value = pubcent;
                }


                objSqlCommand.Parameters.Add("@edition", SqlDbType.VarChar);
                if (edition == "0")
                {
                    objSqlCommand.Parameters["@edition"].Value = System.DBNull.Value;
                }
                else
                {

                    objSqlCommand.Parameters["@edition"].Value = edition;
                }

                objSqlCommand.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dateformat"].Value = dateformat;


                objSqlCommand.Parameters.Add("@descid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@descid"].Value = descid;

                objSqlCommand.Parameters.Add("@ascdesc", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ascdesc"].Value = ascdesc;

                objSqlCommand.Parameters.Add("@agname", SqlDbType.VarChar);
                if (agname == "0" || agname == "")
                {
                    objSqlCommand.Parameters["@agname"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@agname"].Value = agname;
                }

                objSqlCommand.Parameters.Add("@clientname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@clientname"].Value = clientname;

                objSqlCommand.Parameters.Add("@status", SqlDbType.VarChar);
                objSqlCommand.Parameters["@status"].Value = status;

                objSqlCommand.Parameters.Add("@hold", SqlDbType.VarChar);
                objSqlCommand.Parameters["@hold"].Value = hold;

                objSqlCommand.Parameters.Add("@agtype", SqlDbType.VarChar);

                if (agentyp == "0" || agentyp == "--Select AgencyType--")
                {
                    objSqlCommand.Parameters["@agtype"].Value = System.DBNull.Value;
                }
                else
                {

                    objSqlCommand.Parameters["@agtype"].Value = agentyp;
                }

                objSqlDataAdapter = new SqlDataAdapter();
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


        public DataSet representativesummary(string pubcent, string adtyp, string frmdt, string todate, string compcode, string publication, string dateformate, string descid, string ascdesc, string value, string execut, string team, string bill, string cl, string ag, string retain, string repchk, string useid, string chk_acc, string pbranch, string pdistrict)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Representative_summmery", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.CommandTimeout = 0;
                objSqlCommand.Parameters.Add("@chk_access", SqlDbType.VarChar);
                objSqlCommand.Parameters["@chk_access"].Value = chk_acc;

                objSqlCommand.Parameters.Add("@puserid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@puserid"].Value = useid;

                objSqlCommand.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (frmdt == "")
                {
                    objSqlCommand.Parameters["@fromdate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@fromdate"].Value = frmdt;
                }


                objSqlCommand.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (todate == "")
                {
                    objSqlCommand.Parameters["@dateto"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@dateto"].Value = todate;
                }

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@rep", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rep"].Value = repchk;

                objSqlCommand.Parameters.Add("@pub_name", SqlDbType.VarChar);
                if (publication == "0" || publication == "")
                {
                    objSqlCommand.Parameters["@pub_name"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pub_name"].Value = publication;
                }

                objSqlCommand.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dateformat"].Value = dateformate;

                objSqlCommand.Parameters.Add("@adtyp", SqlDbType.VarChar);
                if (adtyp == "0" || adtyp == "")
                {
                    objSqlCommand.Parameters["@adtyp"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@adtyp"].Value = adtyp;
                }

                objSqlCommand.Parameters.Add("@descid", SqlDbType.VarChar);
                if (descid == "")
                {
                    objSqlCommand.Parameters["@descid"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@descid"].Value = descid;
                }

                objSqlCommand.Parameters.Add("@ascdesc", SqlDbType.VarChar);
                if (ascdesc == "")
                {
                    objSqlCommand.Parameters["@ascdesc"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@ascdesc"].Value = ascdesc;
                }

                objSqlCommand.Parameters.Add("@pub_cent", SqlDbType.VarChar);
                if (pubcent == "0")
                {
                    objSqlCommand.Parameters["@pub_cent"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pub_cent"].Value = pubcent;
                }

                objSqlCommand.Parameters.Add("@value", SqlDbType.VarChar);
                objSqlCommand.Parameters["@value"].Value = value;

                objSqlCommand.Parameters.Add("@team", SqlDbType.VarChar);
                if (team == "0" || team == "")
                {
                    objSqlCommand.Parameters["@team"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@team"].Value = team;
                }


                objSqlCommand.Parameters.Add("@execut", SqlDbType.VarChar);
                if (execut == "0" || execut == "")
                {
                    objSqlCommand.Parameters["@execut"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@execut"].Value = execut;
                }


                objSqlCommand.Parameters.Add("@bill", SqlDbType.VarChar);
                if (bill == "0" || bill == "")
                {
                    objSqlCommand.Parameters["@bill"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@bill"].Value = bill;
                }


                objSqlCommand.Parameters.Add("@cl", SqlDbType.VarChar);
                if (cl == "0" || cl == "")
                {
                    objSqlCommand.Parameters["@cl"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@cl"].Value = cl;
                }

                objSqlCommand.Parameters.Add("@ag", SqlDbType.VarChar);
                if (ag == "0" || ag == "")
                {
                    objSqlCommand.Parameters["@ag"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@ag"].Value = ag;
                }

                objSqlCommand.Parameters.Add("@retainer", SqlDbType.VarChar);
                if (retain == "0" || retain == "")
                {
                    objSqlCommand.Parameters["@retainer"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@retainer"].Value = retain;
                }

                objSqlCommand.Parameters.Add("@pbrancode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pbrancode"].Value = pbranch;

                objSqlCommand.Parameters.Add("@pdistcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdistcode"].Value = pdistrict;

                objSqlCommand.Parameters.Add("@pextra1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra1"].Value = System.DBNull.Value;


                objSqlCommand.Parameters.Add("@pextra2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra2"].Value = System.DBNull.Value;


                objSqlCommand.Parameters.Add("@pextra3", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra3"].Value = System.DBNull.Value;


                objSqlCommand.Parameters.Add("@pextra4", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra4"].Value = System.DBNull.Value;


                objSqlCommand.Parameters.Add("@pextra5", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra5"].Value = System.DBNull.Value;


                objSqlDataAdapter = new SqlDataAdapter();
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

        public DataSet netamtreportdatewise(string frmdt, string todate, string compcode, string dateformate, string rowname, string columnname, string conditionchk, string useid, string chk_acc)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("billreportbilled", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@puserid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@puserid"].Value = useid;

                objSqlCommand.Parameters.Add("@chk_access", SqlDbType.VarChar);
                objSqlCommand.Parameters["@chk_access"].Value = chk_acc;

                objSqlCommand.Parameters.Add("@pfromdate", SqlDbType.VarChar);
                if (frmdt == "")
                {
                    objSqlCommand.Parameters["@pfromdate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pfromdate"].Value = frmdt;
                }

                objSqlCommand.Parameters.Add("@ptodate", SqlDbType.VarChar);
                if (todate == "")
                {
                    objSqlCommand.Parameters["@ptodate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@ptodate"].Value = todate;
                }

                objSqlCommand.Parameters.Add("@pdateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdateformat"].Value = dateformate;

                objSqlCommand.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcompcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@prowname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@prowname"].Value = rowname;

                objSqlCommand.Parameters.Add("@pcolumnname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcolumnname"].Value = columnname;


                objSqlCommand.Parameters.Add("@pconditioncheck", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pconditioncheck"].Value = conditionchk;

                objSqlDataAdapter = new SqlDataAdapter();
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

    }
}
