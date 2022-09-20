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
    /// Summary description for vtsrpt
    /// </summary>
    public class vtsrpt : connection
    {
        public vtsrpt()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataSet booking(string agnecycode, string clientcode, string fromdate, string dateto, string pubname, string pubcent, string branch_c, string edition, string dateformat, string useid, string compcode, string chk_acc, string agencytype, string extra1, string extra2,string currency)
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
                if (edition == "0" || edition == ""||edition == "--Select Edition Name--")
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

                objsqlcom.Parameters.Add("@pagency_type", SqlDbType.VarChar);
                if (agencytype == "0" || agencytype == "")
                {
                    objsqlcom.Parameters["@pagency_type"].Value = System.DBNull.Value;
                }
                else
                {
                    objsqlcom.Parameters["@pagency_type"].Value = agencytype;
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
                //*******adtype, adcategory, adsubcategory

                //objsqlcom.Parameters.Add("@pad_type", SqlDbType.VarChar);
                //if (adtype == "0" || adtype == "")
                //{
                //    objsqlcom.Parameters["@pad_type"].Value = System.DBNull.Value;
                //}
                //else
                //{
                //    objsqlcom.Parameters["@pad_type"].Value = adtype;
                //}

                //objsqlcom.Parameters.Add("@pad_cat", SqlDbType.VarChar);
                //if (adcategory == "0" || adcategory == "")
                //{
                //    objsqlcom.Parameters["@pad_cat"].Value = System.DBNull.Value;
                //}
                //else
                //{
                //    objsqlcom.Parameters["@pad_cat"].Value = adcategory;
                //}


               // objsqlcom.Parameters.Add("@pad_sub_cat", SqlDbType.VarChar);
                //if (adsubcategory == "0" || adsubcategory == "")
                //{
                //    objsqlcom.Parameters["@pad_sub_cat"].Value = System.DBNull.Value;
                //}
                //else
                //{
                //    objsqlcom.Parameters["@pad_sub_cat"].Value = adsubcategory;
                //}


                objsqlcom.Parameters.Add("@pextra3", SqlDbType.VarChar);
               
                    objsqlcom.Parameters["@pextra3"].Value = currency;
                
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
        public DataSet vtsreport(string edition, string agency_code, string from_date, string to_date, string client_code, string publication, string pub_center, string branch, string dateformat, string userid, string compcode, string chk_access, string clienttype, string extra1, string extra2)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Rpt_vts_Report", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("@pedition", SqlDbType.VarChar);
                if (edition == "0" || edition == "--Select Edition Name--" || edition == "")
                {
                    objSqlCommand.Parameters["@pedition"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pedition"].Value = edition;
                }


                objSqlCommand.Parameters.Add("@pagency_code", SqlDbType.VarChar);
                if (agency_code == "0" || agency_code == "")
                {
                    objSqlCommand.Parameters["@pagency_code"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pagency_code"].Value = agency_code;
                }


                objSqlCommand.Parameters.Add("@pfrom_date", SqlDbType.VarChar);

                if (from_date == "0" || from_date == "")
                {
                    objSqlCommand.Parameters["@pfrom_date"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pfrom_date"].Value = from_date;
                }

                objSqlCommand.Parameters.Add("@pto_date", SqlDbType.VarChar);
                if (to_date == "" || to_date == "")
                {
                    objSqlCommand.Parameters["@pto_date"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pto_date"].Value = to_date;
                }

                objSqlCommand.Parameters.Add("@pclient_code", SqlDbType.VarChar);
                if (client_code == "" || client_code == "")
                {
                    objSqlCommand.Parameters["@pclient_code"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pclient_code"].Value = client_code;
                }


                objSqlCommand.Parameters.Add("@ppublication", SqlDbType.VarChar);
                if (publication == "0" || publication == "")
                {
                    objSqlCommand.Parameters["@ppublication"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@ppublication"].Value = publication;
                }

                objSqlCommand.Parameters.Add("@ppub_center", SqlDbType.VarChar);
                if (pub_center == "0" || pub_center == "")
                {
                    objSqlCommand.Parameters["@ppub_center"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@ppub_center"].Value = pub_center;

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


                objSqlCommand.Parameters.Add("@pdateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdateformat"].Value = dateformat;

                objSqlCommand.Parameters.Add("@puserid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@puserid"].Value = userid;

                //objSqlCommand.Parameters.Add("@pad_type", SqlDbType.VarChar);
                //if (adtype == "0" || adtype == "")
                //{
                //    objSqlCommand.Parameters["@pad_type"].Value = System.DBNull.Value;
                //}
                //else
                //{
                //    objSqlCommand.Parameters["@pad_type"].Value = adtype;
                //}

                objSqlCommand.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcompcode"].Value = compcode;


                objSqlCommand.Parameters.Add("@chk_access", SqlDbType.VarChar);
                objSqlCommand.Parameters["@chk_access"].Value = "0";

                
                objSqlCommand.Parameters.Add("@clienttype", SqlDbType.VarChar);
                if (clienttype == "0" || clienttype == "")
                {
                    objSqlCommand.Parameters["@clienttype"].Value = "R";
                }
                else
                {
                    objSqlCommand.Parameters["@clienttype"].Value = clienttype;

                }
              

                objSqlCommand.Parameters.Add("@pextra1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra1"].Value = extra1;

                objSqlCommand.Parameters.Add("@pextra2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra2"].Value = extra2;



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
