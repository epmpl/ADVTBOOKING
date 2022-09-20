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

/// <summary>
/// Summary description for PaginationDays
/// </summary>
namespace NewAdbooking.classesoracle
{
    public class PaginationDays:orclconnection
    {
        public PaginationDays()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        public DataSet clsCheckExistingRecord(string compcode, string pubcode, string centercode, string editioncode, string suppcode, string pageno, string daycode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();

            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_CheckRecord.websp_CheckRecord_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("pubcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = pubcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("centercode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = centercode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("editioncode", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = editioncode;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("suppcode", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = suppcode;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("pageno", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = pageno;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("daycode", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = daycode;
                objOraclecommand.Parameters.Add(prm7);

                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;


                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objOracleConnection.Close();
            }
        }

        //save new record
        public DataSet clsSaveDaysRecord(string compcode, string userid, string ddlpubcode, string ddlcentercode, string ddleditioncode, string ddlsuppcode, string ddlpgno, string ddldaycode, string txtvalidfromdate, string txtvalidtodate, string dateformat)  //,string ddlpubname,string ddlcentername,string ddleditionname,string ddlsuppname)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();

            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_SavenewPaginationdays.websp_SavenewPaginationdays_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("ddlpubcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = ddlpubcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("ddlcentercode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = ddlcentercode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("ddleditioncode", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = ddleditioncode;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("ddlsuppcode", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = ddlsuppcode;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("ddlpgno", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = ddlpgno.Trim();
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("ddldaycode", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = ddldaycode;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("txtvalidfromdate", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                if (txtvalidfromdate == "" || txtvalidfromdate == null)
                {
                    prm8.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = txtvalidfromdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        txtvalidfromdate = mm + "/" + dd + "/" + yy;
                    }
                    prm8.Value = Convert.ToDateTime(txtvalidfromdate).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("txtvalidtodate", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                if (txtvalidtodate == "" || txtvalidtodate == null)
                {
                    prm8.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = txtvalidtodate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        txtvalidtodate = mm + "/" + dd + "/" + yy;
                    }
                    prm9.Value = Convert.ToDateTime(txtvalidtodate).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = userid;
                objOraclecommand.Parameters.Add(prm10);



                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objOracleConnection.Close();
            }

        }

        // MOdify Records

        public DataSet clsUpdateDaysRecord(string compcode, string ddlpubcode, string ddlcentercode, string ddleditioncode, string ddlsuppcode, string ddlpgno, string ddldaycode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();

            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_Modifypagination_Master", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("pubcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = ddlpubcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("centercode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = ddlcentercode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("editioncode", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = ddleditioncode;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("suppcode", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = ddlsuppcode;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("txtno", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = ddlpgno.Trim();
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("pubday", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = ddldaycode;
                objOraclecommand.Parameters.Add(prm7);

                //OracleParameter prm8 = new OracleParameter("txtvalidfromdate", OracleType.VarChar, 50);
                //prm8.Direction = ParameterDirection.Input;
                //if (txtvalidfromdate == "" || txtvalidfromdate == null)
                //{
                //    prm8.Value = System.DBNull.Value;
                //}
                //else
                //{
                //    if (dateformat == "dd/mm/yyyy")
                //    {
                //        string[] arr = txtvalidfromdate.Split('/');
                //        string dd = arr[0];
                //        string mm = arr[1];
                //        string yy = arr[2];
                //        txtvalidfromdate = mm + "/" + dd + "/" + yy;
                //    }
                //    prm8.Value = Convert.ToDateTime(txtvalidfromdate).ToString("dd-MMMM-yyyy");
                //}
                //objOraclecommand.Parameters.Add(prm8);

                //OracleParameter prm9 = new OracleParameter("txtvalidtodate", OracleType.VarChar, 50);
                //prm9.Direction = ParameterDirection.Input;
                //if (txtvalidtodate == "" || txtvalidtodate == null)
                //{
                //    prm8.Value = System.DBNull.Value;
                //}
                //else
                //{
                //    if (dateformat == "dd/mm/yyyy")
                //    {
                //        string[] arr = txtvalidtodate.Split('/');
                //        string dd = arr[0];
                //        string mm = arr[1];
                //        string yy = arr[2];
                //        txtvalidtodate = mm + "/" + dd + "/" + yy;
                //    }
                //    prm9.Value = Convert.ToDateTime(txtvalidtodate).ToString("dd-MMMM-yyyy");
                //}
                //objOraclecommand.Parameters.Add(prm9);

                //OracleParameter prm10 = new OracleParameter("userid", OracleType.VarChar, 50);
                //prm10.Direction = ParameterDirection.Input;
                //prm10.Value = userid;
                //objOraclecommand.Parameters.Add(prm10);



                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objOracleConnection.Close();
            }

        }

        public DataSet clsExecuteDaysRecord(string compcode, string pubcode, string centercode, string editioncode, string suppcode, string pageno, string ddldaycode, string dateformat)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();

            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("Websp_ExecuteDaysRecord.Websp_ExecuteDaysRecord_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("pubcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                if (pubcode == "0")
                {
                    prm2.Value = System.DBNull.Value;
                }
                else
                {
                    prm2.Value = pubcode;
                }
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("centercode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                if (centercode == "0")
                {
                    prm3.Value = System.DBNull.Value;
                }
                else
                {
                    prm3.Value = centercode;
                }
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("editioncode", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                if (editioncode == "0")
                {
                    prm4.Value = System.DBNull.Value;
                }
                else
                {
                    prm4.Value = editioncode;
                }

                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("suppcode", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                if (suppcode == "0")
                {
                    prm5.Value = System.DBNull.Value;
                }
                else
                {
                    prm5.Value = suppcode;
                }
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("pageno", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                if (pageno == "")
                {
                    prm6.Value = System.DBNull.Value;
                }
                else
                {
                    prm6.Value = pageno;
                }

                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("ddldaycode", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                if (ddldaycode == "0")
                {
                    prm7.Value = System.DBNull.Value;
                }
                else
                {
                    prm7.Value = ddldaycode;
                }


                objOraclecommand.Parameters.Add(prm7);



                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objOracleConnection.Close();
            }
        }


        // Delete Page configuration's record
        public DataSet clsDeleteDaysRecord(string compcode, string pubcode, string centercode, string editioncode, string suppcode, string dday, string pgnumber)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();

            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("Websp_DeleteDaysRecord.Websp_DeleteDaysRecord_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("pubcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = pubcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("centercode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = centercode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("editioncode", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = editioncode;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("suppcode", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = suppcode;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("dday", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = dday;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("pgnumber", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = pgnumber;
                objOraclecommand.Parameters.Add(prm7);

                //OracleParameter prm8 = new OracleParameter("rec_id", OracleType.VarChar, 50);
                //prm8.Direction = ParameterDirection.Input;
                //prm8.Value = rec_id;
                //objOraclecommand.Parameters.Add(prm8);

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objOracleConnection.Close();
            }
        }
        public DataSet Pripubcode(string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOracleCommand;
            objOracleConnection = GetConnection();

            OracleDataAdapter objOracleDataAdapter = new OracleDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objOracleConnection.Open();
                objOracleCommand = GetCommand("Websp_addpubcode1.Websp_addpubcode1_p", ref objOracleConnection);
                objOracleCommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOracleCommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOracleCommand.Parameters.Add(prm2);

                objOracleCommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOracleCommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;


                objOracleDataAdapter.SelectCommand = objOracleCommand;
                objOracleDataAdapter.Fill(objDataSet);

                return objDataSet;

                //OracleParameter prm3 = new OracleParameter("pubcode", OracleType.VarChar, 50);
                //prm3.Direction = ParameterDirection.Output;
                //objOracleCommand.Parameters.Add(prm3);

                //OracleParameter prm4 = new OracleParameter("pubname", OracleType.VarChar, 50);
                //prm4.Direction = ParameterDirection.Output;
                //objOracleCommand.Parameters.Add(prm4);


                //int n=objOracleCommand.ExecuteNonQuery();

                //DataTable dt1 = new DataTable();

                //for (int i = 0; i < n; i++)
                //{
                //    DataRow dr = dt1.NewRow();
                //    DataColumn d1 = new DataColumn("a1", System.Type.GetType("System.String"));
                //    DataColumn d2 = new DataColumn("a2", System.Type.GetType("System.String"));
                //    dt1.Columns.Add(d1);
                //    dt1.Columns.Add(d2);
                //    dr[0] = prm3.Value;
                //    dr[1] = prm4.Value;
                //    dt1.Rows.Add(dr);
                //    objDataSet.Tables.Add(dt1);

                //}



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

        public DataSet Pripubcodebooking(string compcode, string userid,string flag)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOracleCommand;
            objOracleConnection = GetConnection();

            OracleDataAdapter objOracleDataAdapter = new OracleDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objOracleConnection.Open();
                objOracleCommand = GetCommand("Websp_addpub_forbooking", ref objOracleConnection);
                objOracleCommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOracleCommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOracleCommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("flag", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = flag;
                objOracleCommand.Parameters.Add(prm3);

                objOracleCommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOracleCommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;


                objOracleDataAdapter.SelectCommand = objOracleCommand;
                objOracleDataAdapter.Fill(objDataSet);

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

        public DataSet centercode(string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOracleCommand;
            objOracleConnection = GetConnection();
            OracleDataAdapter objOracleDataAdapter = new OracleDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objOracleConnection.Open();
                objOracleCommand = GetCommand("Websp_addcenter_p.Websp_addcenter", ref objOracleConnection);
                objOracleCommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOracleCommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOracleCommand.Parameters.Add(prm2);

                objOracleCommand.Parameters.Add("p_center", OracleType.Cursor);
                objOracleCommand.Parameters["p_center"].Direction = ParameterDirection.Output;

                ////OracleParameter prm3 = new OracleParameter("p_center", OracleType.Cursor);
                ////prm3.Direction = ParameterDirection.Output;
                ////objOracleCommand.Parameters.Add(prm3);

                objOracleDataAdapter.SelectCommand = objOracleCommand;
                objOracleDataAdapter.Fill(objDataSet);

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

        public DataSet centcodebooking(string compcode, string userid,string flag)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOracleCommand;
            objOracleConnection = GetConnection();
            OracleDataAdapter objOracleDataAdapter = new OracleDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objOracleConnection.Open();
                objOracleCommand = GetCommand("Websp_addcent_forbooking", ref objOracleConnection);
                objOracleCommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOracleCommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOracleCommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("flag", OracleType.VarChar,50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = flag;
                objOracleCommand.Parameters.Add(prm3);

                objOracleCommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOracleCommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;
                  
                objOracleDataAdapter.SelectCommand = objOracleCommand;
                objOracleDataAdapter.Fill(objDataSet);

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

        public DataSet editioncodes(string centercode, string userid, string pubcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOracleCommand;
            objOracleConnection = GetConnection();
            OracleDataAdapter objOracleDataAdapter = new OracleDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objOracleConnection.Open();
                objOracleCommand = GetCommand("websp_addeditions", ref objOracleConnection);
                objOracleCommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("centercode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = centercode;
                objOracleCommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOracleCommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("pubcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = pubcode;
                objOracleCommand.Parameters.Add(prm3);

                objOracleCommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOracleCommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

                ////OracleParameter prm3 = new OracleParameter("p_center", OracleType.Cursor);
                ////prm3.Direction = ParameterDirection.Output;
                ////objOracleCommand.Parameters.Add(prm3);

                objOracleDataAdapter.SelectCommand = objOracleCommand;
                objOracleDataAdapter.Fill(objDataSet);

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

        public DataSet editioncodesbooking(string centercode, string userid, string pubcode,string flag)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOracleCommand;
            objOracleConnection = GetConnection();
            OracleDataAdapter objOracleDataAdapter = new OracleDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objOracleConnection.Open();
                objOracleCommand = GetCommand("websp_addedtn_forbooking", ref objOracleConnection);
                objOracleCommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("centercode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = centercode;
                objOracleCommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOracleCommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("pubcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = pubcode;
                objOracleCommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("flag", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = flag;
                objOracleCommand.Parameters.Add(prm4);

                objOracleCommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOracleCommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;
                    
                objOracleDataAdapter.SelectCommand = objOracleCommand;
                objOracleDataAdapter.Fill(objDataSet);

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

        public DataSet secpubcodes(string compcode, string userid, string editioncode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOracleCommand;
            objOracleConnection = GetConnection();
            OracleDataAdapter objOracleDataAdapter = new OracleDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objOracleConnection.Open();
                objOracleCommand = GetCommand("Websp_Addsecpubs", ref objOracleConnection);
                objOracleCommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOracleCommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOracleCommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("editioncode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = editioncode;
                objOracleCommand.Parameters.Add(prm3);

                objOracleCommand.Parameters.Add("p_secpub", OracleType.Cursor);
                objOracleCommand.Parameters["p_secpub"].Direction = ParameterDirection.Output;

                ////OracleParameter prm3 = new OracleParameter("p_center", OracleType.Cursor);
                ////prm3.Direction = ParameterDirection.Output;
                ////objOracleCommand.Parameters.Add(prm3);

                objOracleDataAdapter.SelectCommand = objOracleCommand;
                objOracleDataAdapter.Fill(objDataSet);

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
        public DataSet secpubcodesbooking(string compcode, string userid, string editioncode,string flag)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOracleCommand;
            objOracleConnection = GetConnection();
            OracleDataAdapter objOracleDataAdapter = new OracleDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objOracleConnection.Open();
                objOracleCommand = GetCommand("Websp_Addsubedtn_forbooking", ref objOracleConnection);
                objOracleCommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOracleCommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOracleCommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("editioncode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = editioncode;
                objOracleCommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("flag", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = flag;
                objOracleCommand.Parameters.Add(prm4);

                objOracleCommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOracleCommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;
                
                objOracleDataAdapter.SelectCommand = objOracleCommand;
                objOracleDataAdapter.Fill(objDataSet);

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