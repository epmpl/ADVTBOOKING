using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.OracleClient;

/// <summary>
/// Summary description for edition_wise_discount
/// </summary>
/// 

namespace NewAdbooking.classesoracle
{
    public class edition_wise_discount : orclconnection
    {
        public edition_wise_discount()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataSet filleditalias(string editcode, string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOracleCommand;
            objOracleConnection = GetConnection();
            OracleDataAdapter objOracleDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objOracleConnection.Open();
                objOracleCommand = GetCommand("filleditalias", ref objOracleConnection);
                objOracleCommand.CommandType = CommandType.StoredProcedure;

                //OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                //prm1.Direction = ParameterDirection.Input;
                //prm1.Value = compcode;
                //objOracleCommand.Parameters.Add(prm1);

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOracleCommand.Parameters.Add(prm1);

                //objOracleCommand.Parameters.Add("compcode", OracleType.VarChar);
                //objOracleCommand.Parameters["compcode"].Value = compcode;

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOracleCommand.Parameters.Add(prm2);

                //objOracleCommand.Parameters.Add("userid", OracleType.VarChar);
                //objOracleCommand.Parameters["userid"].Value = userid;

                OracleParameter prm3 = new OracleParameter("editcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = editcode;
                objOracleCommand.Parameters.Add(prm3);

                //objOracleCommand.Parameters.Add("editcode", OracleType.VarChar);
                //objOracleCommand.Parameters["editcode"].Value = editcode;

                //OracleParameter prm4 = new OracleParameter("date", OracleType.VarChar, 50);
                //prm4.Direction = ParameterDirection.Input;
                //prm4.Value = date;
                //objOracleCommand.Parameters.Add(prm4);


                objOracleCommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOracleCommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;



                objOracleDataAdapter = new OracleDataAdapter();
                objOracleDataAdapter.SelectCommand = objOracleCommand;
                objOracleDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (OracleException objException)
            {
                throw (objException);
            }

            finally
            {
                CloseConnection(ref objOracleConnection);
            }
        }

        public DataSet discbind(string code, string compcode, string userid, string date)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOracleCommand;
            objOracleConnection = GetConnection();
            OracleDataAdapter objOracleDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objOracleConnection.Open();
                objOracleCommand = GetCommand("bindeditdisc", ref objOracleConnection);
                objOracleCommand.CommandType = CommandType.StoredProcedure;

                //objOracleCommand.Parameters.Add("compcode", OracleType.VarChar);
                //objOracleCommand.Parameters["compcode"].Value = compcode;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOracleCommand.Parameters.Add(prm1);

                //objOracleCommand.Parameters.Add("userid", OracleType.VarChar);
                //objOracleCommand.Parameters["userid"].Value = userid;

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOracleCommand.Parameters.Add(prm2);

                //objOracleCommand.Parameters.Add("code", OracleType.VarChar);
                //objOracleCommand.Parameters["code"].Value = code;

                OracleParameter prm3 = new OracleParameter("code", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = code;
                objOracleCommand.Parameters.Add(prm3);


                //objOracleCommand.Parameters.Add("date", OracleType.VarChar);
                //objOracleCommand.Parameters["date"].Value = date;

                OracleParameter prm4 = new OracleParameter("date", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = date;
                objOracleCommand.Parameters.Add(prm4);


                objOracleCommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOracleCommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

     


                objOracleDataAdapter = new OracleDataAdapter();
                objOracleDataAdapter.SelectCommand = objOracleCommand;
                objOracleDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (OracleException objException)
            {
                throw (objException);
            }

            finally
            {
                CloseConnection(ref objOracleConnection);
            }
        }

        public DataSet chkduplicate(string compcode, string disccode, string unit)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOracleCommand;
            objOracleConnection = GetConnection();
            OracleDataAdapter objOracleDataAdapter = new OracleDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objOracleConnection.Open();
                objOracleCommand = GetCommand("editdiscchk", ref objOracleConnection);
                objOracleCommand.CommandType = CommandType.StoredProcedure;

                //objOracleCommand.Parameters.Add("compcode", OracleType.VarChar);
                //objOracleCommand.Parameters["compcode"].Value = compcode;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOracleCommand.Parameters.Add(prm1);

                //objOracleCommand.Parameters.Add("disccode", OracleType.VarChar);
                //objOracleCommand.Parameters["disccode"].Value = disccode;

                OracleParameter prm2 = new OracleParameter("disccode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = disccode;
                objOracleCommand.Parameters.Add(prm2);

                //objOracleCommand.Parameters.Add("discdes", OracleType.VarChar);
                //objOracleCommand.Parameters["discdes"].Value = unit;

                OracleParameter prm3 = new OracleParameter("discdes", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = unit;
                objOracleCommand.Parameters.Add(prm3);

                //objOracleCommand.Parameters.Add("padtype", OracleType.VarChar);
                //objOracleCommand.Parameters["padtype"].Value = adtype;

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
        public DataSet inserteditname(string compcode, string unit, string txtaddate, string year, string txteditionname, string txtdate, string createddate, string userid, string updateddate, string updatedby, string editcode,string dateformat)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOracleCommand;
            objOracleConnection = GetConnection();
            OracleDataAdapter objOracleDataAdapter = new OracleDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objOracleConnection.Open();
                objOracleCommand = GetCommand("editdiscsave", ref objOracleConnection);
                objOracleCommand.CommandType = CommandType.StoredProcedure;

                
                OracleParameter prm1 = new OracleParameter("pcompcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOracleCommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("pUNIT_CODE", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = unit;
                objOracleCommand.Parameters.Add(prm2);

                //objOracleCommand.Parameters.Add("pUNIT_CODE", OracleType.VarChar );
                //objOracleCommand.Parameters["pUNIT_CODE"].Value = unit;


                OracleParameter prm3 = new OracleParameter("pFROM_EDITION", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = txtaddate;
                objOracleCommand.Parameters.Add(prm3);

                //objOracleCommand.Parameters.Add("pFROM_EDITION", OracleType.VarChar);
                //objOracleCommand.Parameters["pFROM_EDITION"].Value = txtaddate;

                OracleParameter prm4 = new OracleParameter("pTO_EDITION", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = year;
                objOracleCommand.Parameters.Add(prm4);

                //objOracleCommand.Parameters.Add("pTO_EDITION", OracleType.VarChar);
                //objOracleCommand.Parameters["pTO_EDITION"].Value = year;

                OracleParameter prm5 = new OracleParameter("pDISC_TYPE", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = txteditionname;
                objOracleCommand.Parameters.Add(prm5);

                //objOracleCommand.Parameters.Add("pDISC_TYPE", OracleType.VarChar);
                //objOracleCommand.Parameters["pDISC_TYPE"].Value = txteditionname;


                OracleParameter prm6 = new OracleParameter("pDISCOUNT", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = txtdate;
                objOracleCommand.Parameters.Add(prm6);

                //objOracleCommand.Parameters.Add("pDISCOUNT", OracleType.VarChar);
                //objOracleCommand.Parameters["pDISCOUNT"].Value = txtdate;


                OracleParameter prm7 = new OracleParameter("pCREATION_DATETIME", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                if (createddate != "")
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = createddate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        createddate = mm + "/" + dd + "/" + yy;
                    }
                    prm7.Value = Convert.ToDateTime(createddate).ToString("dd-MMMM-yyyy");
                }
                else
                {
                    prm7.Value = System.DBNull.Value;
                }
                //prm7.Value = createddate;
                objOracleCommand.Parameters.Add(prm7);


                //objOracleCommand.Parameters.Add("pCREATION_DATETIME", OracleType.VarChar);
                //objOracleCommand.Parameters["pCREATION_DATETIME"].Value = createddate;

                OracleParameter prm8 = new OracleParameter("pUSERID", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = userid;
                objOracleCommand.Parameters.Add(prm8);

                //objOracleCommand.Parameters.Add("pUSERID", OracleType.VarChar);
                //objOracleCommand.Parameters["pUSERID"].Value = userid;

                OracleParameter prm9 = new OracleParameter("pUPDATED_DATETIME", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = updateddate;
                objOracleCommand.Parameters.Add(prm9);



                //objOracleCommand.Parameters.Add("pUPDATED_DATETIME", OracleType.VarChar);
                //objOracleCommand.Parameters["pUPDATED_DATETIME"].Value = updateddate;

                OracleParameter prm10 = new OracleParameter("pUPDATEDBY", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = updatedby;
                objOracleCommand.Parameters.Add(prm10);

                //objOracleCommand.Parameters.Add("pUPDATEDBY", OracleType.VarChar);
                //objOracleCommand.Parameters["pUPDATEDBY"].Value = updatedby;

                OracleParameter prm11 = new OracleParameter("pDISC_CODE", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = editcode;
                objOracleCommand.Parameters.Add(prm11);

                //objOracleCommand.Parameters.Add("pDISC_CODE", OracleType.VarChar);
                //objOracleCommand.Parameters["pDISC_CODE"].Value = editcode;

                //objOracleCommand.Parameters.Add("p_accounts", OracleType.Cursor);
                //objOracleCommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;



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

        public DataSet selectedfromgrid(string compcode, string userid, string unitcode, string disccode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOracleCommand;
            objOracleConnection = GetConnection();
            OracleDataAdapter objOracleDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objOracleConnection.Open();
                objOracleCommand = GetCommand("selecteditiondiscount", ref objOracleConnection);
                objOracleCommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOracleCommand.Parameters.Add(prm1);

                //objOracleCommand.Parameters.Add("compcode", OracleType.VarChar);
                //objOracleCommand.Parameters["compcode"].Value = compcode;

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOracleCommand.Parameters.Add(prm2);


                //objOracleCommand.Parameters.Add("userid", OracleType.VarChar);
                //objOracleCommand.Parameters["userid"].Value = userid;

                OracleParameter prm3 = new OracleParameter("editcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = unitcode;
                objOracleCommand.Parameters.Add(prm3);

                //objOracleCommand.Parameters.Add("editcode", OracleType.VarChar);
                //objOracleCommand.Parameters["editcode"].Value = unitcode;

                OracleParameter prm4 = new OracleParameter("code10", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = disccode;
                objOracleCommand.Parameters.Add(prm4);

                //objOracleCommand.Parameters.Add("code10", OracleType.VarChar);
                //objOracleCommand.Parameters["code10"].Value = disccode;




                //objOracleCommand.Parameters.Add("flag", OracleType.VarChar);
                //objOracleCommand.Parameters["flag"].Value =z;

                objOracleCommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOracleCommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;


                objOracleDataAdapter = new OracleDataAdapter();
                objOracleDataAdapter.SelectCommand = objOracleCommand;
                objOracleDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (OracleException objException)
            {
                throw (objException);
            }

            finally
            {
                CloseConnection(ref objOracleConnection);
            }
        }

        public DataSet chkdateupdate(string txteditionname, string txtdate, string txtaddate, string compcode, string userid, string editcode, string unit)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOracleCommand;
            objOracleConnection = GetConnection();
            OracleDataAdapter objOracleDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objOracleConnection.Open();
                objOracleCommand = GetCommand("chkeditdiscountupdate", ref objOracleConnection);
                objOracleCommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOracleCommand.Parameters.Add(prm1);

                //objOracleCommand.Parameters.Add("compcode", OracleType.VarChar);
                //objOracleCommand.Parameters["compcode"].Value = compcode;

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOracleCommand.Parameters.Add(prm2);

                //objOracleCommand.Parameters.Add("userid", OracleType.VarChar);
                //objOracleCommand.Parameters["userid"].Value = userid;

                OracleParameter prm3 = new OracleParameter("txteditionname", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = txteditionname;
                objOracleCommand.Parameters.Add(prm3);

                //objOracleCommand.Parameters.Add("txteditionname", OracleType.VarChar);
                //objOracleCommand.Parameters["txteditionname"].Value = txteditionname;

                OracleParameter prm4 = new OracleParameter("txtdate", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = txtdate;
                objOracleCommand.Parameters.Add(prm4);

                //objOracleCommand.Parameters.Add("txtdate", OracleType.VarChar);
                //objOracleCommand.Parameters["txtdate"].Value = txtdate;


                OracleParameter prm5 = new OracleParameter("txtaddate", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = txtaddate;
                objOracleCommand.Parameters.Add(prm5);

                //objOracleCommand.Parameters.Add("txtaddate", OracleType.VarChar);
                //objOracleCommand.Parameters["txtaddate"].Value = txtaddate;

                OracleParameter prm6 = new OracleParameter("editcode", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = editcode;
                objOracleCommand.Parameters.Add(prm6);

                //objOracleCommand.Parameters.Add("editcode", OracleType.VarChar);
                //objOracleCommand.Parameters["editcode"].Value = editcode;

                OracleParameter prm7 = new OracleParameter("code10", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = unit;
                objOracleCommand.Parameters.Add(prm7);

                objOracleCommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOracleCommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;



                //objOracleCommand.Parameters.Add("code10", OracleType.VarChar);
                //objOracleCommand.Parameters["code10"].Value = unit;


                objOracleDataAdapter = new OracleDataAdapter();
                objOracleDataAdapter.SelectCommand = objOracleCommand;
                objOracleDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (OracleException objException)
            {
                throw (objException);
            }

            finally
            {
                CloseConnection(ref objOracleConnection);
            }
        }

        public DataSet gridupdate(string compcode, string unit, string txtaddate, string year, string txteditionname, string txtdate, string createddate, string userid, string updateddate, string updatedby, string editcode,string dateformat)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOracleCommand;
            objOracleConnection = GetConnection();
            OracleDataAdapter objOracleDataAdapter = new OracleDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objOracleConnection.Open();
                objOracleCommand = GetCommand("updateeditdiscount", ref objOracleConnection);
                objOracleCommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pcompcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOracleCommand.Parameters.Add(prm1);



                OracleParameter prm2 = new OracleParameter("pUNIT_CODE", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = unit;
                objOracleCommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("pFROM_EDITION", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = txtaddate;
                objOracleCommand.Parameters.Add(prm3);

              
                OracleParameter prm4 = new OracleParameter("pTO_EDITION", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = year;
                objOracleCommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("pDISC_TYPE", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = txteditionname;
                objOracleCommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("pDISCOUNT", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = txtdate;
                objOracleCommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("pCREATION_DATETIME", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = createddate;
                objOracleCommand.Parameters.Add(prm7);


                OracleParameter prm8 = new OracleParameter("pUSERID", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = userid;
                objOracleCommand.Parameters.Add(prm8);


                OracleParameter prm9 = new OracleParameter("pUPDATED_DATETIME", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
               if (updateddate != "")
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = updateddate.Split('/');
                        string dd = arr[1];
                        string mm = arr[0];
                        string yy = arr[2];
                        updateddate = mm + "/" + dd + "/" + yy;
                    }
                    prm9.Value = Convert.ToDateTime(updateddate).ToString("dd-MMMM-yyyy");
                }
                else
                {
                    prm9.Value = System.DBNull.Value;
                }
               
                objOracleCommand.Parameters.Add(prm9);



                OracleParameter prm10 = new OracleParameter("pUPDATEDBY", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = updatedby;
                objOracleCommand.Parameters.Add(prm10);

          

                OracleParameter prm11 = new OracleParameter("pDISC_CODE", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = editcode;
                objOracleCommand.Parameters.Add(prm11);




                objOracleDataAdapter.SelectCommand = objOracleCommand;
                objOracleDataAdapter.Fill(objDataSet);

                return objDataSet;


            }
            catch (OracleException objException)
            {
                throw (objException);
            }

            finally
            {
                CloseConnection(ref objOracleConnection);
            }
        }

        public DataSet griddelete(string editcode, string compcode, string userid, string Unit)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOracleCommand;
            objOracleConnection = GetConnection();
            OracleDataAdapter objOracleDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objOracleConnection.Open();
                objOracleCommand = GetCommand("deletegrideditdiscount", ref objOracleConnection);
                objOracleCommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOracleCommand.Parameters.Add(prm1);

                //objOracleCommand.Parameters.Add("compcode", OracleType.VarChar);
                //objOracleCommand.Parameters["compcode"].Value = compcode;

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOracleCommand.Parameters.Add(prm2);

                //objOracleCommand.Parameters.Add("userid", OracleType.VarChar);
                //objOracleCommand.Parameters["userid"].Value = userid;

                OracleParameter prm3 = new OracleParameter("editcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = editcode;
                objOracleCommand.Parameters.Add(prm3);

                //objOracleCommand.Parameters.Add("editcode", OracleType.VarChar);
                //objOracleCommand.Parameters["editcode"].Value = editcode;

                OracleParameter prm4 = new OracleParameter("code10", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = Unit;
                objOracleCommand.Parameters.Add(prm4);

                //objOracleCommand.Parameters.Add("p_accounts", OracleType.Cursor);
                //objOracleCommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;


                //objOracleCommand.Parameters.Add("code10", OracleType.VarChar);
                //objOracleCommand.Parameters["code10"].Value = Unit;

                objOracleDataAdapter = new OracleDataAdapter();
                objOracleDataAdapter.SelectCommand = objOracleCommand;
                objOracleDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (OracleException objException)
            {
                throw (objException);
            }

            finally
            {
                CloseConnection(ref objOracleConnection);
            }
        }

    }


}