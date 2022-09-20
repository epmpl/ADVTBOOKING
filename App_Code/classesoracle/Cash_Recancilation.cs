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
    /// Summary description for Cash_Recancilation
    /// </summary>
    public class Cash_Recancilation : orclconnection
    {
        public Cash_Recancilation()
        {
            //
            // TODO: Add constructor logic here
            //
        }
           
        public DataSet submitdata(string compcode, string branch_code, string frmdt, string todt, string extra1,string extra2,string extra3,string extra4,string extra5,string extra6)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                string pdateformat = "dd/mm/yyyy";
                objOracleConnection.Open();
                objOraclecommand = GetCommand("FATCH_CASH_RECONCILLATION", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pcompcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("pbran_code", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = branch_code;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("pfromdate", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;                
                if (frmdt == "" || frmdt == null)
                {
                    prm3.Value = System.DBNull.Value;
                }
                else
                {
                    if (pdateformat == "dd/mm/yyyy")
                    {
                        string[] arr = frmdt.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        frmdt = mm + "/" + dd + "/" + yy;
                    }
                    else if (pdateformat == "yyyy/mm/dd")
                    {
                        string[] arr = frmdt.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        frmdt = mm + "/" + dd + "/" + yy;
                    }
                    prm3.Value = Convert.ToDateTime(frmdt).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("ptodate", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;                
                if (todt == "" || todt == null)
                {
                    prm4.Value = System.DBNull.Value;
                }
                else
                {
                    if (pdateformat== "dd/mm/yyyy")
                    {
                        string[] arr = todt.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        todt = mm + "/" + dd + "/" + yy;
                    }
                    else if (pdateformat == "yyyy/mm/dd")
                    {
                        string[] arr = todt.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        todt = mm + "/" + dd + "/" + yy;
                    }
                    prm4.Value = Convert.ToDateTime(todt).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("pextra1", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("pextra2", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("pextra3", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("pextra4", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("pextra5", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm9);

                 OracleParameter prm10 = new OracleParameter("pextra6", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = System.DBNull.Value;
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

        public DataSet savedata(string compcode, string branch_code, string doctype, string bkidnum, string recptno, string recptdt, string amount, string agmaincode, string agsubcode, string deposittype, string depositnum, string depositdate, string userid, string extra1, string extra2, string extra3, string extra4, string extra5, string extra6, string extra7)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                string pdateformat = "dd/mm/yyyy";
                objOracleConnection.Open();
                objOraclecommand = GetCommand("SAVE_CASH_RECONCILLATION", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pcompcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("pbrancode", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = branch_code;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("pdoctype", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = doctype;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("pbkidnum", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = bkidnum;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("precptno", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = recptno;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("precptdt", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                if (recptdt == "" || recptdt == null)
                {
                    prm3.Value = System.DBNull.Value;
                }
                else
                {
                    if (pdateformat == "dd/mm/yyyy")
                    {
                        string[] arr = recptdt.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        recptdt = mm + "/" + dd + "/" + yy;
                    }
                    else if (pdateformat == "yyyy/mm/dd")
                    {
                        string[] arr = recptdt.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        recptdt = mm + "/" + dd + "/" + yy;
                    }
                    prm6.Value = Convert.ToDateTime(recptdt).ToString("dd-MMMM-yyyy");
                }
                
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("pamount", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = amount;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("pagmaincode", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = agmaincode;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("pagsubcode", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = agsubcode;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("pdeposittype", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = deposittype;
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("pdepositnum", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = depositnum;
                objOraclecommand.Parameters.Add(prm11);


                OracleParameter prm12 = new OracleParameter("pdepositdate", OracleType.VarChar);
                prm12.Direction = ParameterDirection.Input;
                if (depositdate == "" || depositdate == null)
                {
                    prm12.Value = System.DBNull.Value;
                }
                else
                {
                    if (pdateformat == "dd/mm/yyyy")
                    {
                        string[] arr = depositdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        depositdate = mm + "/" + dd + "/" + yy;
                    }
                    else if (pdateformat == "yyyy/mm/dd")
                    {
                        string[] arr = depositdate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        depositdate = mm + "/" + dd + "/" + yy;
                    }
                    prm12.Value = Convert.ToDateTime(depositdate).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm12);


                OracleParameter prm13 = new OracleParameter("puserid", OracleType.VarChar);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = userid;
                objOraclecommand.Parameters.Add(prm13);

                OracleParameter prm14 = new OracleParameter("pextra1", OracleType.VarChar);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm14);

                OracleParameter prm15 = new OracleParameter("pextra2", OracleType.VarChar);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm15);

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

                OracleParameter prm19 = new OracleParameter("pextra6", OracleType.VarChar);
                prm19.Direction = ParameterDirection.Input;
                prm19.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm19);

                OracleParameter prm20 = new OracleParameter("pextra7", OracleType.VarChar);
                prm20.Direction = ParameterDirection.Input;
                prm20.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm20);


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

           public DataSet count(string compcode, string deposite_type)
           {
               OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
               
                objOracleConnection.Open();
                objOraclecommand = GetCommand("COUNT_CASH_RECONCILLATION", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pcompcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("pdeposittype", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = deposite_type;
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


        


    }
}