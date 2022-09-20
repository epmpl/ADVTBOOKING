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
    /// Summary description for ClientMasterpopup
    /// </summary>
    public class ClientMasterpopup : orclconnection
    {
        public ClientMasterpopup()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataSet filldatapay(string hiddencomcode, string hiddenuserid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("payfill.payfill_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;




                OracleParameter prm1 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = hiddenuserid;
                objOraclecommand.Parameters.Add(prm1);




                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = hiddencomcode;
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

        public DataSet getData(string clientcode, string userid, string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("Clientpayselect.Clientpayselect_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("custcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = clientcode;
                objOraclecommand.Parameters.Add(prm1);



                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = compcode;
                objOraclecommand.Parameters.Add(prm3);




                objorclDataAdapter.Fill(objDataSet);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }
            return objDataSet;
        }

        public void insertData(string compcode, string custcode, string userid, int i, string strMode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("updateClientPay.updateClientPay_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("Cash", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = strMode;
                objOraclecommand.Parameters.Add(prm1);




                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);



                OracleParameter prm3 = new OracleParameter("Client_Code", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = custcode;
                objOraclecommand.Parameters.Add(prm3);



                OracleParameter prm4 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = userid;
                objOraclecommand.Parameters.Add(prm4);


                OracleParameter prm5 = new OracleParameter("Flag", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = i;
                objOraclecommand.Parameters.Add(prm5);



                //   OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
                objorclDataAdapter.SelectCommand = objOraclecommand;

                objorclDataAdapter.Fill(objDataSet);
            }
            catch (Exception ex) { throw (ex); }
            finally
            { CloseConnection(ref objOracleConnection); }
        }

        public DataSet clientcontactbind(string custcode, string userid, string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("sp_clientcontactbind.sp_clientcontactbind_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("custcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = custcode;
                objOraclecommand.Parameters.Add(prm1);




                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);



                OracleParameter prm3 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = compcode;
                objOraclecommand.Parameters.Add(prm3);

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



        public DataSet contactupdate(string contactperson, string dob, string phone, string ext, string fax, string mail, string compcode, string userid, string custcode, string contcode, string anniversary, string mobile)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("sp_clientcontactupdate.sp_clientcontactupdate_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("custcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = custcode;
                objOraclecommand.Parameters.Add(prm1);



                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);



                OracleParameter prm3 = new OracleParameter("contactperson", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = contactperson;
                objOraclecommand.Parameters.Add(prm3);



                OracleParameter prm4 = new OracleParameter("dob1", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                if (dob == "")
                    prm4.Value = dob;
                else
                    prm4.Value = Convert.ToDateTime(dob).ToString("dd-MMMM-yyyy");
                    //prm4.Value = Convert.ToDateTime(dob).ToString("dd-MMMM-yyyy");
                objOraclecommand.Parameters.Add(prm4);



                OracleParameter prm5 = new OracleParameter("phone", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = phone;
                objOraclecommand.Parameters.Add(prm5);




                OracleParameter prm6 = new OracleParameter("ext", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = ext;
                objOraclecommand.Parameters.Add(prm6);



                OracleParameter prm7 = new OracleParameter("fax", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = fax;
                objOraclecommand.Parameters.Add(prm7);



                OracleParameter prm8 = new OracleParameter("mail", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = mail;
                objOraclecommand.Parameters.Add(prm8);



                OracleParameter prm9 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = compcode;
                objOraclecommand.Parameters.Add(prm9);




                OracleParameter prm10 = new OracleParameter("contcode", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = contcode;
                objOraclecommand.Parameters.Add(prm10);



                OracleParameter prm11 = new OracleParameter("anniversary1", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                if (anniversary == "")
                    prm11.Value = anniversary;
                else
                    prm11.Value = Convert.ToDateTime(anniversary).ToString("dd-MMMM-yyyy");
                //prm11.Value = Convert.ToDateTime(anniversary).ToString("dd-MMMM-yyyy");
                objOraclecommand.Parameters.Add(prm11);



                OracleParameter prm12 = new OracleParameter("mobile", OracleType.VarChar, 50);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = mobile;
                objOraclecommand.Parameters.Add(prm12);





                //objorclDataAdapter =new SqlDataAdapter();
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

        public DataSet clientcontactbind12(string custcode, string userid, string compcode, string dateformat)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("sp_clientcontactbind12.sp_clientcontactbind12_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("custcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = custcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("date1", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = dateformat;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userid;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = compcode;
                objOraclecommand.Parameters.Add(prm4);

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




        public DataSet insertcontact(string contact, string dob, string phone, string ext, string fax, string mail, string userid, string custcode, string compcode, string anniversary, string mobile)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("sp_clientcontactdetails.sp_clientcontactdetails_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("custcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = custcode;
                objOraclecommand.Parameters.Add(prm1);



                OracleParameter prm2 = new OracleParameter("contact", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = contact;
                objOraclecommand.Parameters.Add(prm2);




                OracleParameter prm3 = new OracleParameter("dob", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                if (dob == "")
                {
                    prm3.Value = dob;
                }
                else
                {
                    prm3.Value = Convert.ToDateTime(dob).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm3);




                OracleParameter prm4 = new OracleParameter("phone", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = phone;
                objOraclecommand.Parameters.Add(prm4);

               


                //else

                OracleParameter prm5 = new OracleParameter("ext", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = ext;
                objOraclecommand.Parameters.Add(prm5);




                OracleParameter prm6 = new OracleParameter("fax", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = fax;
                objOraclecommand.Parameters.Add(prm6);




                OracleParameter prm7 = new OracleParameter("mail", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = mail;
                objOraclecommand.Parameters.Add(prm7);



                OracleParameter prm8 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = userid;
                objOraclecommand.Parameters.Add(prm8);



                OracleParameter prm9 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = compcode;
                objOraclecommand.Parameters.Add(prm9);


                OracleParameter prm10 = new OracleParameter("anniversary1", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                if (anniversary == "")
                    prm10.Value = anniversary;
                else
                    prm10.Value = Convert.ToDateTime(anniversary).ToString("dd-MMMM-yyyy");
                //prm11.Value = Convert.ToDateTime(anniversary).ToString("dd-MMMM-yyyy");
                objOraclecommand.Parameters.Add(prm10);



                OracleParameter prm11 = new OracleParameter("mobile", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = mobile;
                objOraclecommand.Parameters.Add(prm11);



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

        public DataSet addstatusname(string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("bind_status.bind_status_p", ref objOracleConnection);
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

        public DataSet statusupdate(string status, string fromdate1, string todate1, string compcode, string userid, string custcode, string update, string dateformat, string circular)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("sp_clientststuscheck11.sp_clientststuscheck11_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("custcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = custcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("date", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = dateformat;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("formdate", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = fromdate1;
                objOraclecommand.Parameters.Add(prm4);


                OracleParameter prm5 = new OracleParameter("todate", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = todate1;
                objOraclecommand.Parameters.Add(prm5);


               OracleParameter prm6 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = compcode;
                objOraclecommand.Parameters.Add(prm6);


                OracleParameter prm7 = new OracleParameter("circular", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = circular;
                objOraclecommand.Parameters.Add(prm7);

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
                CloseConnection(ref  objOracleConnection);
            }

        }



        public DataSet statusupdate11(string status, string fromdate, string todate, string compcode, string userid, string custcode, string update, string circular,string attach,string remark)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("sp_clientstatusupdate.sp_clientstatusupdate_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("custcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = custcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm9 = new OracleParameter("status", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = status;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm4 = new OracleParameter("formdate", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");
                objOraclecommand.Parameters.Add(prm4);


                OracleParameter prm5 = new OracleParameter("todate", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = Convert.ToDateTime(todate).ToString("dd-MMMM-yyyy");
                objOraclecommand.Parameters.Add(prm5);



                OracleParameter prm6 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = compcode;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7= new OracleParameter("update1", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = update;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("crcular", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = circular;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm8a = new OracleParameter("attach", OracleType.VarChar, 50);
                prm8a.Direction = ParameterDirection.Input;
                prm8a.Value = attach;
                objOraclecommand.Parameters.Add(prm8a);


                OracleParameter prm10 = new OracleParameter("remark", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = remark;
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









        public DataSet insertstatus11(string status, string fromdate, string todate, string custcode, string compcode, string userid, string circular,string attach, string remark)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("sp_insertclientstatus.sp_insertclientstatus_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("custcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = custcode;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm9 = new OracleParameter("status", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = status;
                objOraclecommand.Parameters.Add(prm9);


                OracleParameter prm4 = new OracleParameter("formdate", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = Convert .ToDateTime(fromdate).ToString ("dd-MMMM-yyyy");
                objOraclecommand.Parameters.Add(prm4);


                OracleParameter prm5 = new OracleParameter("todate", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = Convert .ToDateTime(todate).ToString("dd-MMMM-yyyy"); 
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm6 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = compcode;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm8 = new OracleParameter("circular", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = circular;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9a = new OracleParameter("attach", OracleType.VarChar, 50);
                prm9a.Direction = ParameterDirection.Input;
                prm9a.Value = attach;
                objOraclecommand.Parameters.Add(prm9a);


                OracleParameter prm10 = new OracleParameter("remark", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = remark;
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
        public DataSet chkcontact(string contactperson, string custcode, string compcode, string hiddenccode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("clientcontcheck.clientcontcheck_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("custcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = custcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm6 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = compcode;
                objOraclecommand.Parameters.Add(prm6);


                OracleParameter prm9 = new OracleParameter("contactperson", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = contactperson;
                objOraclecommand.Parameters.Add(prm9);


                OracleParameter prm4 = new OracleParameter("ccode", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = hiddenccode;
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


        public DataSet insertstatus(string status, string fromdate, string todate, string custcode, string compcode, string userid, string dateformat, string circular)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("sp_clientststuscheck12.sp_clientststuscheck12_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("custcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = custcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm4 = new OracleParameter("formdate", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = fromdate;
                objOraclecommand.Parameters.Add(prm4);


                OracleParameter prm5 = new OracleParameter("todate", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = todate;
                objOraclecommand.Parameters.Add(prm5);


                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);



                OracleParameter prm6 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = compcode;
                objOraclecommand.Parameters.Add(prm6);


                OracleParameter prm9 = new OracleParameter("date", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = dateformat;
                objOraclecommand.Parameters.Add(prm9);

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







        public DataSet clientstatusbind12(string custcode, string compcode, string userid, string datagrid, string dateformat)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("sp_clientststuscheck.sp_clientststuscheck_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("custcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = custcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);



                OracleParameter prm6 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = compcode;
                objOraclecommand.Parameters.Add(prm6);


                OracleParameter prm10 = new OracleParameter("code", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = datagrid;
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm9 = new OracleParameter("date1", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = dateformat;
                objOraclecommand.Parameters.Add(prm9);

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


        public DataSet clientstatusdelete(string custcode, string compcode, string userid, string delete1)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("sp_clientstatusdelete.sp_clientstatusdelete_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;



                OracleParameter prm1 = new OracleParameter("custcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = custcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);



                OracleParameter prm6 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = compcode;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm9 = new OracleParameter("delete1", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = delete1;
                objOraclecommand.Parameters.Add(prm9);


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




        public DataSet contactbind(string custcode, string userid, string compcode)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("sp_clientcontactbind.sp_clientcontactbind_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("custcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = custcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);



                OracleParameter prm6 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = compcode;
                objOraclecommand.Parameters.Add(prm6);


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




        public DataSet contactdelete(string custcode, string compcode, string userid, string update)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("sp_clientcontactdelete.sp_clientcontactdelete_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;




                OracleParameter prm1 = new OracleParameter("custcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = custcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);



                OracleParameter prm6 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = compcode;
                objOraclecommand.Parameters.Add(prm6);



                OracleParameter prm9 = new OracleParameter("cont_code", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = update;
                objOraclecommand.Parameters.Add(prm9);

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

        public DataSet status_name_call(string status, string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("status_name_call.status_name_call_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm6 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = compcode;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm9 = new OracleParameter("status", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = status;
                objOraclecommand.Parameters.Add(prm9);

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

        public DataSet clientstatusbind(string custcode, string userid, string compcode, string dateformat)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("sp_clientstatusbind.sp_clientstatusbind_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("custcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = custcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);



                OracleParameter prm6 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = compcode;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm9 = new OracleParameter("date1", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = dateformat;
                objOraclecommand.Parameters.Add(prm9);

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


    }
}
