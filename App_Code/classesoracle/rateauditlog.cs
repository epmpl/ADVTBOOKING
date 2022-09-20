using System;
using System.Data;
using System.Configuration;
using System.Data.OracleClient;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;


/// <summary>
/// Summary description for rateauditlog
/// </summary>
/// 

namespace NewAdbooking.classesoracle
{
    public class rateauditlog : orclconnection
    {
        public rateauditlog()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataSet bindbooking(string compcode, string bokingid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {


                objOracleConnection.Open();
                objOraclecommand = GetCommand("binbookingid", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("p_compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("p_bookingid", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = bokingid;
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

        public DataSet bindrep(string fromdate, string todate, string compcode, string bookingcenter, string branch, string dateformate, string adtype, string uom, string agency, string client, string bookingid,string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {


                objOracleConnection.Open();
                objOraclecommand = GetCommand("rate_audit_logreport", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pfromdate", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                if (fromdate != "" && fromdate != null)
                {
                    string[] arr = fromdate.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    fromdate = mm + "/" + dd + "/" + yy;
                    prm1.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");
                }
                else
                {
                    prm1.Value = System.DBNull.Value;
                }
                    objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("pdateto", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                if (todate != "" && todate != null)
                {
                    string[] arr1 = todate.Split('/');
                    string dd1 = arr1[0];
                    string mm1 = arr1[1];
                    string yy1 = arr1[2];
                    todate = mm1 + "/" + dd1 + "/" + yy1;
                    prm2.Value = Convert.ToDateTime(todate).ToString("dd-MMMM-yyyy");
                }
                else
                {
                    prm2.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("ppub_cent", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                if (bookingcenter == "0" || bookingcenter == "")
                {
                    prm3.Value = System.DBNull.Value;
                }
                else
                {
                    prm3.Value = bookingcenter;
                }
                 objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("pbranch", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                if (branch == "0" || branch == "")
                {
                    prm4.Value = System.DBNull.Value;
                }
                else
                {
                    prm4.Value = branch;

                }
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("pdateformat", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = dateformate;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("padtyp", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                if (adtype == "" || adtype == "0")
                {
                    prm6.Value = System.DBNull.Value;
                }
                else
                {

                    prm6.Value = adtype;
                }
                    objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("puom", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                if (uom == "" || uom == "0")
                {
                    prm7.Value = System.DBNull.Value;
                }
                else
                {
                    prm7.Value = uom;
                }
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("pagency", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;

                if (agency == "0" || agency == "")
                {
                    prm8.Value = System.DBNull.Value;
                }

                else
                {
                    prm8.Value = agency;
                }

                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("pclient", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                if (client == "0" || client == "")
                {
                    prm9.Value = System.DBNull.Value;
                }
                else
                {
                    prm9.Value = client;
                }
                    objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("pbkid", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = bookingid;
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("puserid", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = userid;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("pcompcode", OracleType.VarChar);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = compcode;
                objOraclecommand.Parameters.Add(prm12);

                OracleParameter prm13 = new OracleParameter("pextra1", OracleType.VarChar);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm13);


                OracleParameter prm14 = new OracleParameter("pextra2", OracleType.VarChar);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm14);

                OracleParameter prm16 = new OracleParameter("pextra3", OracleType.VarChar);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm16);


                OracleParameter prm17 = new OracleParameter("pextra4", OracleType.VarChar);
                prm17.Direction = ParameterDirection.Input;
                prm17.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm17);


                OracleParameter prm18 = new OracleParameter("pextra5", OracleType.VarChar);
                prm18.Direction = ParameterDirection.Input;
                prm18.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm18);

      

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                    objOraclecommand.Parameters.Add("p_accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts1"].Direction = ParameterDirection.Output;

                    objOraclecommand.Parameters.Add("p_accounts2", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts2"].Direction = ParameterDirection.Output;

                    objOraclecommand.Parameters.Add("p_accounts3", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts3"].Direction = ParameterDirection.Output;

                    objOraclecommand.Parameters.Add("p_accounts4", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts4"].Direction = ParameterDirection.Output;
             

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


        public DataSet binddaily(string fromdate, string todate, string compcode, string pubcent, string dateformat, string adtype, string umo, string userid, string area,string publication,string edition,string supliment)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {


                objOracleConnection.Open();
                objOraclecommand = GetCommand("dailymis_report", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pfrom_date", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                string[] arr = fromdate.Split('/');
                string dd = arr[0];
                string mm = arr[1];
                string yy = arr[2];
                fromdate = mm + "/" + dd + "/" + yy;
                prm1.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("ptill_date", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                string[] arr1 = todate.Split('/');
                string dd1 = arr1[0];
                string mm1 = arr1[1];
                string yy1 = arr1[2];
                todate = mm1 + "/" + dd1 + "/" + yy1;
                prm2.Value = Convert.ToDateTime(todate).ToString("dd-MMMM-yyyy");
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("ppubcenter", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                if (pubcent == "0" || pubcent == "")
                {
                    prm3.Value = System.DBNull.Value;
                }
                else
                {
                    prm3.Value = pubcent;
                }
                objOraclecommand.Parameters.Add(prm3);

               
                OracleParameter prm5 = new OracleParameter("pdateformat", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = dateformat;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("padtype", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                if (adtype == "" || adtype == "0")
                {
                    prm6.Value = System.DBNull.Value;
                }
                else
                {

                    prm6.Value = adtype;
                }
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("puomcode", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                if (umo == "" || umo == "0")
                {
                    prm7.Value = System.DBNull.Value;
                }
                else
                {
                    prm7.Value = umo;
                }
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("pcompcode", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;




                prm8.Value = compcode;
                

                objOraclecommand.Parameters.Add(prm8);

              
                OracleParameter prm10 = new OracleParameter("pmin_size", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = area;
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("puserid", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = userid;
                objOraclecommand.Parameters.Add(prm11);



                OracleParameter prm13 = new OracleParameter("pextra1", OracleType.VarChar);
                prm13.Direction = ParameterDirection.Input;
                if (publication == "0" || publication == "")
                {
                    prm13.Value = System.DBNull.Value;
                }
                else
                {
                    prm13.Value = publication;
                }
                //prm13.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm13);


                OracleParameter prm14 = new OracleParameter("pextra2", OracleType.VarChar);
                prm14.Direction = ParameterDirection.Input;
                if (edition == "0" || edition == "")
                {
                    prm14.Value = System.DBNull.Value;
                }
                else
                {
                    prm14.Value = edition;
                }
                objOraclecommand.Parameters.Add(prm14);
                //prm14.Value = System.DBNull.Value;
                //objOraclecommand.Parameters.Add(prm14);

                OracleParameter prm16 = new OracleParameter("pextra3", OracleType.VarChar);
                prm16.Direction = ParameterDirection.Input;
                if (supliment == "0" || supliment == "")
                {
                    prm16.Value = System.DBNull.Value;
                }
                else
                {
                    prm16.Value = supliment;
                }
                //prm16.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm16);



                OracleParameter prm17 = new OracleParameter("pextra4", OracleType.VarChar);
                prm17.Direction = ParameterDirection.Input;
                prm17.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm17);


                OracleParameter prm18 = new OracleParameter("pextra5", OracleType.VarChar);
                prm18.Direction = ParameterDirection.Input;
                prm18.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm18);



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
    }
}