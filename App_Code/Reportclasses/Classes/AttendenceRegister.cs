using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
//using java.sql;
using System.Data.SqlClient;
namespace NewAdbooking.Report.Classes
{
    /// <summary>
    /// Summary description for AttendenceRegister
    /// </summary>
    public class AttendenceRegister : connection
    {
        public AttendenceRegister()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataSet displayonscreenreport(string frmdt, string todate, string compcode, string publication, string status, string edition, string pubcenter, string adtype, string adcategory, string dateformate, string descid, string ascdesc, string supplement, string package1, string editiondetail, string useid, string chk_access, string branch)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
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
                if (supplement == "0" || supplement == "")
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
                if (edition == "0" || edition == "")
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

//===========================  Call Procedure for Bill Register checklist =============================//
        public DataSet getbillregisterrec_chklst(string frmdt, string todate, string compcode, string publication, string branch, string edition, string pubcenter, string adtype, string dateformate, string useid, string chk_acc, string Agencytype, string ratecod, string uom, string Basedon, string type)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                if (type == "run")
                    objSqlCommand = GetCommand("rpt_billregister_checklist_LATA", ref objSqlConnection);
                else
                    objSqlCommand = GetCommand("rpt_billregister_summ", ref objSqlConnection);
                    objSqlCommand.CommandType = CommandType.StoredProcedure;
               
              
                objSqlCommand.Parameters.Add("@PADTYPE", SqlDbType.VarChar);
                if (adtype == "0" || adtype == "")
                    objSqlCommand.Parameters["@PADTYPE"].Value = System.DBNull.Value;
                else
                objSqlCommand.Parameters["@PADTYPE"].Value = adtype;

                objSqlCommand.Parameters.Add("@PUBLICATION", SqlDbType.VarChar);
                if (publication == "0" || publication == "")
                    objSqlCommand.Parameters["@PUBLICATION"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@PUBLICATION"].Value = publication;

                objSqlCommand.Parameters.Add("@PCOMPCODE", SqlDbType.VarChar);
                objSqlCommand.Parameters["@PCOMPCODE"].Value = compcode;

                objSqlCommand.Parameters.Add("@DATEFORMAT1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@DATEFORMAT1"].Value = dateformate;


                objSqlCommand.Parameters.Add("@PUB_CENT", SqlDbType.VarChar);
                if (pubcenter != "0" && pubcenter != "")
                    objSqlCommand.Parameters["@PUB_CENT"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@PUB_CENT"].Value = pubcenter;


                objSqlCommand.Parameters.Add("@EDITION", SqlDbType.VarChar);
                if (edition == "0" || edition == "")
                {
                    objSqlCommand.Parameters["@EDITION"].Value = System.DBNull.Value;
                }
                else
                {

                    objSqlCommand.Parameters["@EDITION"].Value = edition;
                }

                objSqlCommand.Parameters.Add("@PBRANCH", SqlDbType.VarChar);
                if (branch == "0" || branch == "")
                    objSqlCommand.Parameters["@PBRANCH"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@PBRANCH"].Value = branch;

                objSqlCommand.Parameters.Add("@PAGENTYPE", SqlDbType.VarChar);
                if (Agencytype == "0" || Agencytype == "")
                    objSqlCommand.Parameters["@PAGENTYPE"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@PAGENTYPE"].Value = Agencytype;



                objSqlCommand.Parameters.Add("@FROMDATE", SqlDbType.DateTime);
                if (dateformate == "dd/mm/yyyy")
                {
                    string[] arr = frmdt.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    frmdt = mm + "/" + dd + "/" + yy;
                }
                else if (dateformate == "yyyy/mm/dd")
                {
                    string[] arr = frmdt.Split('/');
                    string dd = arr[2];
                    string mm = arr[1];
                    string yy = arr[0];
                    frmdt = mm + "/" + dd + "/" + yy;
                }
                objSqlCommand.Parameters["@FROMDATE"].Value = frmdt;

                ////objSqlCommand.Parameters.Add("@FROMDATE", SqlDbType.VarChar);
                ////if (frmdt == "")
                ////{
                ////    objSqlCommand.Parameters["@FROMDATE"].Value = System.DBNull.Value;
                ////}
                ////else
                ////{

                ////    objSqlCommand.Parameters["@FROMDATE"].Value = frmdt;
                ////}



                objSqlCommand.Parameters.Add("@DATETO", SqlDbType.DateTime);
                if (dateformate == "dd/mm/yyyy")
                {
                    string[] arr = todate.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    todate = mm + "/" + dd + "/" + yy;
                }
                else if (dateformate == "yyyy/mm/dd")
                {
                    string[] arr = todate.Split('/');
                    string dd = arr[2];
                    string mm = arr[1];
                    string yy = arr[0];
                    todate = mm + "/" + dd + "/" + yy;
                }
                objSqlCommand.Parameters["@DATETO"].Value = todate;


                //objSqlCommand.Parameters.Add("@DATETO", SqlDbType.VarChar);
                //if (todate == "")
                //{
                //    objSqlCommand.Parameters["@DATETO"].Value = System.DBNull.Value;
                //}
                //else
                //{

                //    objSqlCommand.Parameters["@DATETO"].Value = todate;
                //}


                objSqlCommand.Parameters.Add("@PRATECODE", SqlDbType.VarChar);
                if (ratecod == "0" || ratecod == "")
                    objSqlCommand.Parameters["@PRATECODE"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@PRATECODE"].Value = ratecod;

                objSqlCommand.Parameters.Add("@PUOM", SqlDbType.VarChar);
                if (uom == "0" || uom == "")
                    objSqlCommand.Parameters["@PUOM"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@PUOM"].Value = uom;

                if (type == "run")
                {

                    objSqlCommand.Parameters.Add("@PFILTERON", SqlDbType.VarChar);
                    objSqlCommand.Parameters["@PFILTERON"].Value = Basedon;
                }
                objSqlCommand.Parameters.Add("@PUSERID", SqlDbType.VarChar);
                objSqlCommand.Parameters["@PUSERID"].Value = useid;

                objSqlCommand.Parameters.Add("@CHK_ACCESS", SqlDbType.VarChar);
                objSqlCommand.Parameters["@CHK_ACCESS"].Value = chk_acc;

                objSqlCommand.Parameters.Add("@PEXTRA1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@PEXTRA1"].Value = System.DBNull.Value;

                objSqlCommand.Parameters.Add("@PEXTRA2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@PEXTRA2"].Value = System.DBNull.Value;

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
        public DataSet dist(string compcode, string state)
        {
            SqlConnection sqlcon;
            SqlCommand sqlcom;
            sqlcon = GetConnection();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                sqlcon.Open();
                sqlcom = GetCommand("distMst_state", ref sqlcon);
                sqlcom.CommandType = CommandType.StoredProcedure;

                sqlcom.Parameters.Add("@compcode", SqlDbType.VarChar);
                sqlcom.Parameters["@compcode"].Value = compcode;

                sqlcom.Parameters.Add("@statecode", SqlDbType.VarChar);
                sqlcom.Parameters["@statecode"].Value = state;

                da.SelectCommand = sqlcom;
                da.Fill(ds);
                return ds;
            }

            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                CloseConnection(ref sqlcon);
            }
        }
        public DataSet state(string compcode)
        {
            SqlConnection sqlcon;
            SqlCommand sqlcom;
            sqlcon = GetConnection();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                sqlcon.Open();
                sqlcom = GetCommand("stateMst_state", ref sqlcon);
                sqlcom.CommandType = CommandType.StoredProcedure;

                sqlcom.Parameters.Add("@compcode", SqlDbType.VarChar);
                sqlcom.Parameters["@compcode"].Value = compcode;

                da.SelectCommand = sqlcom;
                da.Fill(ds);
                return ds;
            }

            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                CloseConnection(ref sqlcon);
            }
        }
        public DataSet city(string compcode, string dist)
        {
            SqlConnection sqlcon;
            SqlCommand sqlcom;
            sqlcon = GetConnection();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                sqlcon.Open();
                sqlcom = GetCommand("cityMst_city", ref sqlcon);
                sqlcom.CommandType = CommandType.StoredProcedure;

                sqlcom.Parameters.Add("@compcode", SqlDbType.VarChar);
                sqlcom.Parameters["@compcode"].Value = compcode;

                sqlcom.Parameters.Add("@distcode", SqlDbType.VarChar);
                sqlcom.Parameters["@distcode"].Value = dist;

                da.SelectCommand = sqlcom;
                da.Fill(ds);
                return ds;
            }

            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                CloseConnection(ref sqlcon);
            }
        }
        public DataSet bankbranch(string compcode, string centercode, string branchname)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            DataSet ds = new DataSet();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();

            try
            {

                objSqlConnection.Open();
                objSqlCommand = GetCommand("branch_name_new", ref  objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcompcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@punitcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@punitcode"].Value = centercode;

                objSqlCommand.Parameters.Add("@pbranchname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pbranchname"].Value = branchname;

                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(ds);
                return ds;

            }


            catch (Exception ex)
            {
                throw (ex);

            }


            finally
            {
                CloseConnection(ref objSqlConnection);
            }
        }


        public DataSet displaycardratereport(string frmdt, string todate, string compcode, string pcenter, string pratecode, string adtype, string adcategory, string dateformate, string package1, string useid, string uomcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            DataSet ds = new DataSet();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();

            try
            {

                objSqlConnection.Open();
                objSqlCommand = GetCommand("rpt_ratecard", ref  objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("@pfromdate", SqlDbType.VarChar);

                if (frmdt != "0" && frmdt != "")
                {
                    if (dateformate == "dd/mm/yyyy")
                    {
                        string[] arr = frmdt.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        frmdt = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@pfromdate"].Value = frmdt;
                }
                else
                {
                    objSqlCommand.Parameters["@pfromdate"].Value = System.DBNull.Value;
                }
             //   objSqlCommand.Parameters["@pfromdate"].Value = frmdt;

                objSqlCommand.Parameters.Add("@pdateto", SqlDbType.VarChar);
                if (todate != "0" && todate != "")
                {
                    if (dateformate == "dd/mm/yyyy")
                    {
                        string[] arr = todate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        todate = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@pdateto"].Value = todate;
                }
                else
                {
                    objSqlCommand.Parameters["@pdateto"].Value = System.DBNull.Value;
                }
            //    objSqlCommand.Parameters["@pdateto"].Value = todate;

                objSqlCommand.Parameters.Add("@padtyp", SqlDbType.VarChar);
                objSqlCommand.Parameters["@padtyp"].Value = adtype;

                objSqlCommand.Parameters.Add("@padcatg", SqlDbType.VarChar);

                if (adcategory == "")
                {
                    objSqlCommand.Parameters["@padcatg"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@padcatg"].Value = adcategory;
                }
                

                objSqlCommand.Parameters.Add("@ppackagecode", SqlDbType.VarChar);
                if (package1 == "0" || package1 == "")
                {
                    objSqlCommand.Parameters["@ppackagecode"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@ppackagecode"].Value = package1;
                }
               

                objSqlCommand.Parameters.Add("@pcenter", SqlDbType.VarChar);
                if (pcenter == "0" || pcenter == "")
                {
                    objSqlCommand.Parameters["@pcenter"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pcenter"].Value = pcenter;
                }

                

                objSqlCommand.Parameters.Add("@pratecode", SqlDbType.VarChar);
                if (pratecode != "0")
                {
                    objSqlCommand.Parameters["@pratecode"].Value = pratecode;
                }
                else
                {
                    objSqlCommand.Parameters["@pratecode"].Value = System.DBNull.Value;
                }
               

                objSqlCommand.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcompcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@p_uom", SqlDbType.VarChar);
                if (uomcode == "0" || uomcode == "")
                {
                    objSqlCommand.Parameters["@p_uom"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@p_uom"].Value = uomcode;
                }
               

                objSqlCommand.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dateformat"].Value = dateformate;

                objSqlCommand.Parameters.Add("@puserid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@puserid"].Value = useid;

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

                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(ds);
                return ds;

            }
            catch (Exception ex)
            {
                throw (ex);

            }


            finally
            {
                CloseConnection(ref objSqlConnection);
            }
        }
        public DataSet spfun1(string agname, string clientname, string adtype, string listadcat, string listadsubcat, string fromdate, string dateto, string compcode, string pubname, string pubcent, string status, string edition, string dateformat, string ascdesc, string hold, string descid, string agencytype, string useridmain, string chk_access, string branch, string printcenter, string docket, string searching, string uom, string userid, string state, string dist, string city)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            DataSet ds = new DataSet();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();

            try
            {

                objSqlConnection.Open();
                objSqlCommand = GetCommand("daily_booking_report", ref  objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("@agname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agname"].Value = agname;

                objSqlCommand.Parameters.Add("@clientname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@clientname"].Value = clientname;

                objSqlCommand.Parameters.Add("@adtype1", SqlDbType.VarChar);
                if (adtype == "0" || adtype == "")
                {
                    objSqlCommand.Parameters["@adtype1"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@adtype1"].Value = adtype;
                }
             //   objSqlCommand.Parameters["@adtype1"].Value = adtype;


                objSqlCommand.Parameters.Add("@Adcategory", SqlDbType.VarChar);
                if ( listadcat == "")
                {
                    objSqlCommand.Parameters["@Adcategory"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@Adcategory"].Value = listadcat;
                }
              //  objSqlCommand.Parameters["@Adcategory"].Value = listadcat;



                objSqlCommand.Parameters.Add("@Adsubcategory", SqlDbType.VarChar);
                if (listadsubcat == "")
                {
                    objSqlCommand.Parameters["@Adsubcategory"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@Adsubcategory"].Value = listadsubcat;
                }
               // objSqlCommand.Parameters["@Adsubcategory"].Value = listadsubcat;



                objSqlCommand.Parameters.Add("@fromdate", SqlDbType.VarChar);

                if (fromdate != "0" && fromdate != "")
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = fromdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        fromdate = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@fromdate"].Value = fromdate;
                }
                else
                {
                    objSqlCommand.Parameters["@fromdate"].Value = System.DBNull.Value;
                }

                objSqlCommand.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (dateto != "0" && dateto != "")
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = dateto.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        dateto = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@dateto"].Value = dateto;
                }
                else
                {
                    objSqlCommand.Parameters["@dateto"].Value = System.DBNull.Value;
                }


                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;


                objSqlCommand.Parameters.Add("@pub_name", SqlDbType.VarChar);
                if (pubname == "" || pubname=="0")
                {
                    objSqlCommand.Parameters["@pub_name"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pub_name"].Value = pubname;
                }
               // objSqlCommand.Parameters["@pub_name"].Value = pubname;


                objSqlCommand.Parameters.Add("@pub_cent", SqlDbType.VarChar);
                if (pubcent == "" || pubcent=="0")
                {
                    objSqlCommand.Parameters["@pub_cent"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pub_cent"].Value = pubcent;
                }
             //   objSqlCommand.Parameters["@pub_cent"].Value = pubcent;




                objSqlCommand.Parameters.Add("@status", SqlDbType.VarChar);
                if (status == "")
                {
                    objSqlCommand.Parameters["@status"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@status"].Value = status;
                }
              //  objSqlCommand.Parameters["@status"].Value = status;


                objSqlCommand.Parameters.Add("@edition", SqlDbType.VarChar);
                if (edition == "" || edition=="0" || edition=="--Select Edition Name--")
                {
                    objSqlCommand.Parameters["@edition"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@edition"].Value = edition;
                }
          //      objSqlCommand.Parameters["@edition"].Value = edition;


                objSqlCommand.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dateformat"].Value = dateformat;



                objSqlCommand.Parameters.Add("@hold", SqlDbType.VarChar);
                objSqlCommand.Parameters["@hold"].Value = hold;


                objSqlCommand.Parameters.Add("@descid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@descid"].Value = descid;

                objSqlCommand.Parameters.Add("@ascdesc", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ascdesc"].Value = ascdesc;


                objSqlCommand.Parameters.Add("@agtype", SqlDbType.VarChar);
                if (agencytype == "0")
                {
                    objSqlCommand.Parameters["@agtype"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@agtype"].Value = agencytype;
                }
             //   objSqlCommand.Parameters["@agtype"].Value = agencytype;

                objSqlCommand.Parameters.Add("@puserid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@puserid"].Value = userid;

                objSqlCommand.Parameters.Add("@chk_access", SqlDbType.VarChar);
                objSqlCommand.Parameters["@chk_access"].Value = chk_access;


                objSqlCommand.Parameters.Add("@pbranch", SqlDbType.VarChar);
                if (branch == "0" || branch=="")
                {
                    objSqlCommand.Parameters["@pbranch"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pbranch"].Value = branch;
                }
              //  objSqlCommand.Parameters["@pbranch"].Value = branch;



                objSqlCommand.Parameters.Add("@pprint_center", SqlDbType.VarChar);
                if (printcenter == "0")
                {
                    objSqlCommand.Parameters["@pprint_center"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pprint_center"].Value = printcenter;
                }
             //   objSqlCommand.Parameters["@pprint_center"].Value = printcenter;


                objSqlCommand.Parameters.Add("@pwithout_rono", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pwithout_rono"].Value = docket;

                objSqlCommand.Parameters.Add("@pdate_flag", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdate_flag"].Value = searching;

                objSqlCommand.Parameters.Add("@pextra1", SqlDbType.VarChar);
                if (uom == "0" || uom=="--Select UOM Name--")
                {
                    objSqlCommand.Parameters["@pextra1"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pextra1"].Value = uom;
                }
              //  objSqlCommand.Parameters["@pextra1"].Value = uom;

                objSqlCommand.Parameters.Add("@pextra2", SqlDbType.VarChar);
                if (userid == "0" || userid=="")
                {
                    objSqlCommand.Parameters["@pextra2"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pextra2"].Value = userid;
                }
            //    objSqlCommand.Parameters["@pextra2"].Value = userid;


            
                objSqlCommand.Parameters.Add("@pextra3", SqlDbType.VarChar);
                if (state == "0" || state == "")
                {
                    objSqlCommand.Parameters["@pextra3"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pextra3"].Value = state;
                }
          //      objSqlCommand.Parameters["@pextra3"].Value = state;



                objSqlCommand.Parameters.Add("@pextra4", SqlDbType.VarChar);
                if (dist == "0" || dist == "")
                {
                    objSqlCommand.Parameters["@pextra4"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pextra4"].Value = dist;
                }
              //  objSqlCommand.Parameters["@pextra4"].Value = dist;



                objSqlCommand.Parameters.Add("@pextra5", SqlDbType.VarChar);
                if (city == "0" || city == "")
                {
                    objSqlCommand.Parameters["@pextra5"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pextra5"].Value = city;
                }
            //    objSqlCommand.Parameters["@pextra5"].Value = city;



                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw (ex);

            }


            finally
            {
                CloseConnection(ref objSqlConnection);
            }
        }

       
        public DataSet getbillregisterrec_chklst_detail(string frmdt, string todate, string compcode, string publication, string branch, string edition, string pubcenter, string adtype, string dateformate, string useid, string chk_acc, string Agencytype, string ratecod, string uom, string Basedon, string type)
       // public DataSet getbillregisterrec_chklst(string frmdt, string todate, string compcode, string publication, string branch, string edition, string pubcenter, string adtype, string dateformate, string useid, string chk_acc, string Agencytype, string ratecod, string uom, string Basedon, string type)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                if (type == "run")
                    //objSqlCommand = GetCommand("rpt_billregister_checklist_LATA", ref objSqlConnection);
                    objSqlCommand = GetCommand("rpt_billsummary_checklist", ref objSqlConnection);
                else
                    objSqlCommand = GetCommand("rpt_billsummary_checklist", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("@PADTYPE", SqlDbType.VarChar);
                if (adtype == "0" || adtype == "")
                    objSqlCommand.Parameters["@PADTYPE"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@PADTYPE"].Value = adtype;

                //objSqlCommand.Parameters.Add("@PUBLICATION", SqlDbType.VarChar);
                //if (publication == "0" || publication == "")
                //    objSqlCommand.Parameters["@PUBLICATION"].Value = System.DBNull.Value;
                //else
                //    objSqlCommand.Parameters["@PUBLICATION"].Value = publication;


                objSqlCommand.Parameters.Add("@FROMDATE", SqlDbType.DateTime);
                if (dateformate == "dd/mm/yyyy")
                {
                    string[] arr = frmdt.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    frmdt = mm + "/" + dd + "/" + yy;
                }
                else if (dateformate == "yyyy/mm/dd")
                {
                    string[] arr = frmdt.Split('/');
                    string dd = arr[2];
                    string mm = arr[1];
                    string yy = arr[0];
                    frmdt = mm + "/" + dd + "/" + yy;
                }
                objSqlCommand.Parameters["@FROMDATE"].Value = frmdt;



                objSqlCommand.Parameters.Add("@DATETO", SqlDbType.DateTime);
                if (dateformate == "dd/mm/yyyy")
                {
                    string[] arr = todate.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    todate = mm + "/" + dd + "/" + yy;
                }
                else if (dateformate == "yyyy/mm/dd")
                {
                    string[] arr = todate.Split('/');
                    string dd = arr[2];
                    string mm = arr[1];
                    string yy = arr[0];
                    todate = mm + "/" + dd + "/" + yy;
                }
                objSqlCommand.Parameters["@DATETO"].Value = todate;


                
                objSqlCommand.Parameters.Add("@PCOMPCODE", SqlDbType.VarChar);
                objSqlCommand.Parameters["@PCOMPCODE"].Value = compcode;

                objSqlCommand.Parameters.Add("@PUB_CENT", SqlDbType.VarChar);
                if (pubcenter != "0" && pubcenter != "")
                    objSqlCommand.Parameters["@PUB_CENT"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@PUB_CENT"].Value = pubcenter;

                objSqlCommand.Parameters.Add("@DATEFORMAT1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@DATEFORMAT1"].Value = dateformate;

                objSqlCommand.Parameters.Add("@PBRANCH", SqlDbType.VarChar);
                if (branch == "0" || branch == "")
                    objSqlCommand.Parameters["@PBRANCH"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@PBRANCH"].Value = branch;
               




               

                objSqlCommand.Parameters.Add("@PAGENTYPE", SqlDbType.VarChar);
                if (Agencytype == "0" || Agencytype == "")
                    objSqlCommand.Parameters["@PAGENTYPE"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@PAGENTYPE"].Value = Agencytype;




                ////objSqlCommand.Parameters.Add("@EDITION", SqlDbType.VarChar);
                ////if (edition == "0" || edition == "")
                ////{
                ////    objSqlCommand.Parameters["@EDITION"].Value = System.DBNull.Value;
                ////}
                ////else
                ////{

                ////    objSqlCommand.Parameters["@EDITION"].Value = edition;
                ////}






               


                objSqlCommand.Parameters.Add("@PRATECODE", SqlDbType.VarChar);
                if (ratecod == "0" || ratecod == "")
                    objSqlCommand.Parameters["@PRATECODE"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@PRATECODE"].Value = ratecod;

                objSqlCommand.Parameters.Add("@PUOM", SqlDbType.VarChar);
                if (uom == "0" || uom == "")
                    objSqlCommand.Parameters["@PUOM"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@PUOM"].Value = uom;

                //if (type == "run")
                //{

                //    objSqlCommand.Parameters.Add("@PFILTERON", SqlDbType.VarChar);
                //    objSqlCommand.Parameters["@PFILTERON"].Value = Basedon;
                //}
                objSqlCommand.Parameters.Add("@PUSERID", SqlDbType.VarChar);
                objSqlCommand.Parameters["@PUSERID"].Value = useid;

                objSqlCommand.Parameters.Add("@CHK_ACCESS", SqlDbType.VarChar);
                objSqlCommand.Parameters["@CHK_ACCESS"].Value = chk_acc;

                objSqlCommand.Parameters.Add("@PEXTRA1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@PEXTRA1"].Value = System.DBNull.Value;

                objSqlCommand.Parameters.Add("@PEXTRA2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@PEXTRA2"].Value = System.DBNull.Value;

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







      //  public DataSet getbillregisterrec_chklst_detail(string frmdt, string todate, string compcode, string publication, string branch, string edition, string pubcenter, string adtype, string dateformate, string useid, string chk_acc, string Agencytype, string ratecod, string uom, string Basedon, string type)
         public DataSet dailyreportdata(string dpaddtype, string frmdt, string todate, string compcode, string pubcenter, string branch, string dateformate, string Agencytype, string ratecod, string uom, string useid, string chk_acc, string extra1, string extra2)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();


                objSqlCommand = GetCommand("daily_billing_data_report", ref objSqlConnection);

                    objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("@PADTYPE", SqlDbType.VarChar);
                if (dpaddtype == "0" || dpaddtype == "")
                    objSqlCommand.Parameters["@PADTYPE"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@PADTYPE"].Value = dpaddtype;

              


                objSqlCommand.Parameters.Add("@FROMDATE", SqlDbType.DateTime);
                if (dateformate == "dd/mm/yyyy")
                {
                    string[] arr = frmdt.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    frmdt = mm + "/" + dd + "/" + yy;
                }
                else if (dateformate == "yyyy/mm/dd")
                {
                    string[] arr = frmdt.Split('/');
                    string dd = arr[2];
                    string mm = arr[1];
                    string yy = arr[0];
                    frmdt = mm + "/" + dd + "/" + yy;
                }
                objSqlCommand.Parameters["@FROMDATE"].Value = frmdt;



                objSqlCommand.Parameters.Add("@DATETO", SqlDbType.DateTime);
                if (dateformate == "dd/mm/yyyy")
                {
                    string[] arr = todate.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    todate = mm + "/" + dd + "/" + yy;
                }
                else if (dateformate == "yyyy/mm/dd")
                {
                    string[] arr = todate.Split('/');
                    string dd = arr[2];
                    string mm = arr[1];
                    string yy = arr[0];
                    todate = mm + "/" + dd + "/" + yy;
                }
                objSqlCommand.Parameters["@DATETO"].Value = todate;



                objSqlCommand.Parameters.Add("@PCOMPCODE", SqlDbType.VarChar);
                objSqlCommand.Parameters["@PCOMPCODE"].Value = compcode;

                objSqlCommand.Parameters.Add("@PUB_CENT", SqlDbType.VarChar);
                if (pubcenter != "0" && pubcenter != "")
                    objSqlCommand.Parameters["@PUB_CENT"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@PUB_CENT"].Value = pubcenter;

                objSqlCommand.Parameters.Add("@DATEFORMAT1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@DATEFORMAT1"].Value = dateformate;

                objSqlCommand.Parameters.Add("@PBRANCH", SqlDbType.VarChar);
                if (branch == "0" || branch == "")
                    objSqlCommand.Parameters["@PBRANCH"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@PBRANCH"].Value = branch;







                objSqlCommand.Parameters.Add("@PAGENTYPE", SqlDbType.VarChar);
                if (Agencytype == "0" || Agencytype == "")
                    objSqlCommand.Parameters["@PAGENTYPE"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@PAGENTYPE"].Value = Agencytype;




         








                objSqlCommand.Parameters.Add("@PRATECODE", SqlDbType.VarChar);
                if (ratecod == "0" || ratecod == "")
                    objSqlCommand.Parameters["@PRATECODE"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@PRATECODE"].Value = ratecod;

                objSqlCommand.Parameters.Add("@PUOM", SqlDbType.VarChar);
                if (uom == "0" || uom == "")
                    objSqlCommand.Parameters["@PUOM"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@PUOM"].Value = uom;

                //if (type == "run")
                //{

                //    objSqlCommand.Parameters.Add("@PFILTERON", SqlDbType.VarChar);
                //    objSqlCommand.Parameters["@PFILTERON"].Value = Basedon;
                //}
                objSqlCommand.Parameters.Add("@PUSERID", SqlDbType.VarChar);
                objSqlCommand.Parameters["@PUSERID"].Value = useid;

                objSqlCommand.Parameters.Add("@CHK_ACCESS", SqlDbType.VarChar);
                objSqlCommand.Parameters["@CHK_ACCESS"].Value = chk_acc;

                objSqlCommand.Parameters.Add("@PEXTRA1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@PEXTRA1"].Value = System.DBNull.Value;

                objSqlCommand.Parameters.Add("@PEXTRA2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@PEXTRA2"].Value = System.DBNull.Value;

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
