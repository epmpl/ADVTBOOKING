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
    /// Summary description for pop
    /// </summary>
    public class pop : orclconnection
    {
        public pop()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataSet checkBgno(string bgno, string bgname)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("Wesp_chkBgNo.Wesp_chkBgNo_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm4 = new OracleParameter("bgno", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = bgno;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm3 = new OracleParameter("bgname", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = bgname;
                objOraclecommand.Parameters.Add(prm3);


                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_Accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts1"].Direction = ParameterDirection.Output;


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
                objOraclecommand = GetCommand("retainer_payfill.retainer_payfill_p", ref objOracleConnection);
               objOraclecommand.CommandType = CommandType.StoredProcedure;

               OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
               prm2.Direction = ParameterDirection.Input;
               prm2.Value = hiddenuserid;
               objOraclecommand.Parameters.Add(prm2);

               OracleParameter prm3 = new OracleParameter("compcode", OracleType.VarChar, 50);
               prm3.Direction = ParameterDirection.Input;
               prm3.Value = hiddencomcode;
               objOraclecommand.Parameters.Add(prm3);

               objOraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
               objOraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;


                objorclDataAdapter.SelectCommand =objOraclecommand;
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

        public DataSet showchk(string compcode, string userid, string retcode, string agencysubcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("showagencypay.showagencypay_p", ref objOracleConnection);
               objOraclecommand.CommandType = CommandType.StoredProcedure;

               OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar, 50);
               prm2.Direction = ParameterDirection.Input;
               prm2.Value = compcode;
               objOraclecommand.Parameters.Add(prm2);

               OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar, 50);
               prm3.Direction = ParameterDirection.Input;
               prm3.Value = userid;
               objOraclecommand.Parameters.Add(prm3);

               OracleParameter prm4 = new OracleParameter("retcode", OracleType.VarChar, 50);
               prm4.Direction = ParameterDirection.Input;
               prm4.Value = retcode;
               objOraclecommand.Parameters.Add(prm4);

               OracleParameter prm5= new OracleParameter("agencysubcode", OracleType.VarChar, 50);
               prm5.Direction = ParameterDirection.Input;
               prm5.Value = agencysubcode;
               objOraclecommand.Parameters.Add(prm5);

               objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
               objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;
                
               objorclDataAdapter.SelectCommand =objOraclecommand;
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

               OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar, 50);
               prm2.Direction = ParameterDirection.Input;
               prm2.Value = compcode;
               objOraclecommand.Parameters.Add(prm2);

               objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
               objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;


                objorclDataAdapter.SelectCommand =objOraclecommand;
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

        public DataSet CheckClientPopup(string compcode, string custcode, string custname, string userid, int flag)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
           OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
               objOracleConnection.Open();
               objOraclecommand = GetCommand("CheckClientpopup.CheckClientpopup_p", ref objOracleConnection);
               objOraclecommand.CommandType = CommandType.StoredProcedure;

               OracleParameter prm2 = new OracleParameter("custcode", OracleType.VarChar, 50);
               prm2.Direction = ParameterDirection.Input;
               prm2.Value = custcode;
               objOraclecommand.Parameters.Add(prm2);

               OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar, 50);
               prm3.Direction = ParameterDirection.Input;
               prm3.Value = userid;
               objOraclecommand.Parameters.Add(prm3);

               OracleParameter prm4 = new OracleParameter("compcode", OracleType.VarChar, 50);
               prm4.Direction = ParameterDirection.Input;
               prm4.Value = compcode;
               objOraclecommand.Parameters.Add(prm4);

               OracleParameter prm5 = new OracleParameter("flag1", OracleType.VarChar, 50);
               prm5.Direction = ParameterDirection.Input;
           
               
                   prm5.Value = flag;
          
               objOraclecommand.Parameters.Add(prm5);

               OracleParameter prm6 = new OracleParameter("custname", OracleType.VarChar, 50);
               prm6.Direction = ParameterDirection.Input;
               prm6.Value = custname;
               objOraclecommand.Parameters.Add(prm6);

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

               objOraclecommand.Parameters.Add("p_accounts5", OracleType.Cursor);
               objOraclecommand.Parameters["p_accounts5"].Direction = ParameterDirection.Output;

               //objOraclecommand.Parameters.Add("p_accounts6", OracleType.Cursor);
               //objOraclecommand.Parameters["p_accounts6"].Direction = ParameterDirection.Output;
              
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

        //------------------------------------------------Pankaj Change----------------------
        public DataSet insertcontact(string contact, string designation, string role, string dob, string phone, string ext, string fax, string mail, string userid, string agencycode, string agencysubcode, string compcode, string id,string dateformat,string mobile)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_contactdetails.websp_contactdetails_p", ref objOracleConnection);
               objOraclecommand.CommandType = CommandType.StoredProcedure;

               OracleParameter prm2 = new OracleParameter("agentcode", OracleType.VarChar, 50);
               prm2.Direction = ParameterDirection.Input;
               prm2.Value = agencycode;
               objOraclecommand.Parameters.Add(prm2);

               OracleParameter prm3 = new OracleParameter("contact", OracleType.VarChar, 50);
               prm3.Direction = ParameterDirection.Input;
               prm3.Value = contact;
               objOraclecommand.Parameters.Add(prm3);


               OracleParameter prm4 = new OracleParameter("designation", OracleType.VarChar, 50);
               prm4.Direction = ParameterDirection.Input;
               prm4.Value = designation;
               objOraclecommand.Parameters.Add(prm4);

                //----------------------------
               OracleParameter prm5 = new OracleParameter("role1", OracleType.VarChar, 50);
               prm5.Direction = ParameterDirection.Input;
               prm5.Value = role;
               objOraclecommand.Parameters.Add(prm5);
              
                //-------------------------------
               OracleParameter prm6 = new OracleParameter("dob", OracleType.VarChar, 50);
               prm6.Direction = ParameterDirection.Input;
               if (dob == "")
               {
                   prm6.Value = System.DBNull.Value;
               }
               else
               {
                   //if (dateformat == "dd/mm/yyyy")
                   //{
                   //    string[] arr = dob.Split('/');
                   //    string dd = arr[0];
                   //    string mm = arr[1];
                   //    string yy = arr[2];
                   //    dob = mm + "/" + dd + "/" + yy;


                   //}
                   //else
                   //    if (dateformat == "mm/dd/yyyy")
                   //    {
                   //        string[] arr = dob.Split('/');
                   //        string dd = arr[1];
                   //        string mm = arr[0];
                   //        string yy = arr[2];
                   //        dob = mm + "/" + dd + "/" + yy;

                   //    }

                   //    else
                   //        if (dateformat == "yyyy/mm/dd")
                   //        {
                   //            string[] arr = dob.Split('/');
                   //            string dd = arr[2];
                   //            string mm = arr[1];
                   //            string yy = arr[0];
                   //            dob = mm + "/" + dd + "/" + yy;
                   //        }

                   prm6.Value = Convert.ToDateTime(dob).ToString("dd-MMMM-yyyy");
               }
               objOraclecommand.Parameters.Add(prm6);



               OracleParameter prm7 = new OracleParameter("phone", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = phone;
                objOraclecommand.Parameters.Add(prm7);



                OracleParameter prm8 = new OracleParameter("ext", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = ext;
                objOraclecommand.Parameters.Add(prm8);


                OracleParameter prm9 = new OracleParameter("fax", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = fax;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("mail", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value =mail;
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = userid;
                objOraclecommand.Parameters.Add(prm11);


                OracleParameter prm12 = new OracleParameter("agencysubcode", OracleType.VarChar, 50);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = agencysubcode;
                objOraclecommand.Parameters.Add(prm12);


                OracleParameter prm13 = new OracleParameter("compcode", OracleType.VarChar, 50);
               prm13.Direction = ParameterDirection.Input;
               prm13.Value = compcode;
               objOraclecommand.Parameters.Add(prm13);


               OracleParameter prm14 = new OracleParameter("product", OracleType.VarChar, 50);
               prm14.Direction = ParameterDirection.Input;
               prm14.Value = id;
               objOraclecommand.Parameters.Add(prm14);

               OracleParameter prm15 = new OracleParameter("mobile", OracleType.VarChar, 50);
               prm15.Direction = ParameterDirection.Input;
               prm15.Value = mobile;
               objOraclecommand.Parameters.Add(prm15);

               objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
               objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;


               
                objorclDataAdapter.SelectCommand =objOraclecommand;
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
        //		**********************************Code**************************************

        public DataSet rolename(string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("rolename.rolename_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);

               
               OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar, 50);
               prm3.Direction = ParameterDirection.Input;
               prm3.Value = userid;
               objOraclecommand.Parameters.Add(prm3);

               objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
               objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;


                objorclDataAdapter.SelectCommand =objOraclecommand;
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

        //		*********************************End****************************************

        //

        public DataSet contactbind(string agentcode, string userid, string compcode, string dateformat, string nagencycode)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
               objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_contactbind.websp_contactbind_p", ref objOracleConnection);
               objOraclecommand.CommandType = CommandType.StoredProcedure;

               OracleParameter prm2 = new OracleParameter("gentcode", OracleType.VarChar, 50);
               prm2.Direction = ParameterDirection.Input;
               prm2.Value = agentcode;
               objOraclecommand.Parameters.Add(prm2);

               OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar, 50);
               prm3.Direction = ParameterDirection.Input;
               prm3.Value = userid;
               objOraclecommand.Parameters.Add(prm3);

               OracleParameter prm4 = new OracleParameter("DATEFORMAT1", OracleType.VarChar, 50);
               prm4.Direction = ParameterDirection.Input;
               prm4.Value = dateformat;
               objOraclecommand.Parameters.Add(prm4);

               OracleParameter prm5 = new OracleParameter("nagencycode", OracleType.VarChar, 50);
               prm5.Direction = ParameterDirection.Input;
               prm5.Value = nagencycode;
               objOraclecommand.Parameters.Add(prm5);

               objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
               objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

               //objOraclecommand.Parameters.Add("p_accounts1", OracleType.Cursor);
               //objOraclecommand.Parameters["p_accounts1"].Direction = ParameterDirection.Output;

               //objOraclecommand.Parameters.Add("p_accounts2", OracleType.Cursor);
               //objOraclecommand.Parameters["p_accounts2"].Direction = ParameterDirection.Output;

               //objOraclecommand.Parameters.Add("p_accounts3", OracleType.Cursor);
               //objOraclecommand.Parameters["p_accounts3"].Direction = ParameterDirection.Output;
             
                objorclDataAdapter.SelectCommand =objOraclecommand;
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


        public DataSet contactbind12(string agentcode, string userid, string compcode, string hiddencccode)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_contactbind12.websp_contactbind12_p", ref objOracleConnection);
               objOraclecommand.CommandType = CommandType.StoredProcedure;

               OracleParameter prm2 = new OracleParameter("agentcode", OracleType.VarChar, 50);
               prm2.Direction = ParameterDirection.Input;
               prm2.Value = agentcode;
               objOraclecommand.Parameters.Add(prm2);


               OracleParameter prm3 = new OracleParameter("hiddencccode", OracleType.VarChar, 50);
               prm3.Direction = ParameterDirection.Input;
               prm3.Value = hiddencccode;
               objOraclecommand.Parameters.Add(prm3);


               OracleParameter prm4 = new OracleParameter("userid", OracleType.VarChar, 50);
               prm4.Direction = ParameterDirection.Input;
               prm4.Value =userid;
               objOraclecommand.Parameters.Add(prm4);


               objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
               objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

               
                objorclDataAdapter.SelectCommand =objOraclecommand;
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


        public DataSet getpro(string code)
        {


            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("getpro.getpro_p", ref objOracleConnection);
               objOraclecommand.CommandType = CommandType.StoredProcedure;


               OracleParameter prm2 = new OracleParameter("code", OracleType.VarChar, 50);
               prm2.Direction = ParameterDirection.Input;
               prm2.Value = code;
               objOraclecommand.Parameters.Add(prm2);

               objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
               objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

                
                objorclDataAdapter.SelectCommand =objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (OracleException  objException)
            {
                throw (objException);
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



        public DataSet getproinsert(string newboxvalue, string comp, string userid, string clientcode, string newprodname, string contactperson, string agencycode, string agencysubcode)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("getproinsert.getproinsert_p", ref objOracleConnection);
               objOraclecommand.CommandType = CommandType.StoredProcedure;


               OracleParameter prm2 = new OracleParameter("newboxvalue", OracleType.VarChar, 50);
               prm2.Direction = ParameterDirection.Input;
               prm2.Value = newboxvalue;
               objOraclecommand.Parameters.Add(prm2);



               OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar, 50);
               prm3.Direction = ParameterDirection.Input;
               prm3.Value = userid;
               objOraclecommand.Parameters.Add(prm3);


               OracleParameter prm4 = new OracleParameter("comp", OracleType.VarChar, 50);
               prm4.Direction = ParameterDirection.Input;
               prm4.Value =comp;
               objOraclecommand.Parameters.Add(prm4);


               OracleParameter prm5 = new OracleParameter("newprodname", OracleType.VarChar, 50);
               prm5.Direction = ParameterDirection.Input;
               prm5.Value =newprodname;
               objOraclecommand.Parameters.Add(prm5);

               OracleParameter prm6 = new OracleParameter("clientcode", OracleType.VarChar, 50);
               prm6.Direction = ParameterDirection.Input;
               prm6.Value = clientcode;
               objOraclecommand.Parameters.Add(prm6);


               OracleParameter prm7 = new OracleParameter("contactperson", OracleType.VarChar, 50);
               prm7.Direction = ParameterDirection.Input;
               prm7.Value =contactperson;
               objOraclecommand.Parameters.Add(prm7);


               OracleParameter prm8 = new OracleParameter("agencycode", OracleType.VarChar, 50);
               prm8.Direction = ParameterDirection.Input;
               prm8.Value = agencycode;
               objOraclecommand.Parameters.Add(prm8);



               OracleParameter prm9 = new OracleParameter("agencysubcode", OracleType.VarChar, 50);
               prm9.Direction = ParameterDirection.Input;
               prm9.Value = agencysubcode;
               objOraclecommand.Parameters.Add(prm9);


            
                objorclDataAdapter.SelectCommand =objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (OracleException  objException)
            {
                throw (objException);
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


        public DataSet bindes(string contactperson, string comp, string userid, string agencycode, string agencysubcode)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("bindproclicont.bindproclicont_p", ref objOracleConnection);
               objOraclecommand.CommandType = CommandType.StoredProcedure;



               OracleParameter prm7 = new OracleParameter("contactperson", OracleType.VarChar, 50);
               prm7.Direction = ParameterDirection.Input;
               prm7.Value = contactperson;
               objOraclecommand.Parameters.Add(prm7);

               OracleParameter prm4 = new OracleParameter("comp", OracleType.VarChar, 50);
               prm4.Direction = ParameterDirection.Input;
               prm4.Value = comp;
               objOraclecommand.Parameters.Add(prm4);


               OracleParameter prm3 = new OracleParameter("contactperson", OracleType.VarChar, 50);
               prm3.Direction = ParameterDirection.Input;
               prm3.Value = contactperson;
               objOraclecommand.Parameters.Add(prm3);

               OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
               prm2.Direction = ParameterDirection.Input;
               prm2.Value = userid;
               objOraclecommand.Parameters.Add(prm2);

               OracleParameter prm1 = new OracleParameter("agencysubcode", OracleType.VarChar, 50);
               prm1.Direction = ParameterDirection.Input;
               prm1.Value = agencysubcode;
               objOraclecommand.Parameters.Add(prm1);
                
                objorclDataAdapter.SelectCommand =objOraclecommand;
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



        public DataSet getproname(string aftersplit)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("getproname.getproname_p", ref objOracleConnection);
               objOraclecommand.CommandType = CommandType.StoredProcedure;

               OracleParameter prm1 = new OracleParameter("aftersplit", OracleType.VarChar, 50);
               prm1.Direction = ParameterDirection.Input;
               prm1.Value = aftersplit;
               objOraclecommand.Parameters.Add(prm1);

               objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
               objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

             
                objorclDataAdapter.SelectCommand =objOraclecommand;
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




        //--------------------------*********************************************


        public DataSet contactupdate(string contactperson, string dob, string designation, string phone, string ext, string fax, string mail, string compcode, string userid, string agencode, string agencysubcode, string update, string role, string id, string mobile)
        {
            //contactperson,dob,designation,phone,ext,fax,mail,code,compcode,userid,agencode,agencysubcode
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_contactupdate.websp_contactupdate_p", ref objOracleConnection);
               objOraclecommand.CommandType = CommandType.StoredProcedure;

               OracleParameter prm1 = new OracleParameter("agencode", OracleType.VarChar, 50);
               prm1.Direction = ParameterDirection.Input;
               prm1.Value = agencode;
               objOraclecommand.Parameters.Add(prm1);


               OracleParameter prm3 = new OracleParameter("contactperson", OracleType.VarChar, 50);
               prm3.Direction = ParameterDirection.Input;
               prm3.Value = contactperson;
               objOraclecommand.Parameters.Add(prm3);

               OracleParameter prm5 = new OracleParameter("designation", OracleType.VarChar, 50);
               prm5.Direction = ParameterDirection.Input;
               prm5.Value = designation;
               objOraclecommand.Parameters.Add(prm5);


               OracleParameter prm6 = new OracleParameter("dob1", OracleType.VarChar, 50);
               prm6.Direction = ParameterDirection.Input;
               if (dob == "")
               {
                   prm6.Value = System.DBNull.Value;
               }
               else
               {
                   prm6.Value = Convert.ToDateTime(dob).ToString("dd-MMMM-yyyy");
               }
               objOraclecommand.Parameters.Add(prm6);


               OracleParameter prm7 = new OracleParameter("phone", OracleType.VarChar, 50);
               prm7.Direction = ParameterDirection.Input;
               prm7.Value = phone;
               objOraclecommand.Parameters.Add(prm7);


               OracleParameter prm8 = new OracleParameter("ext", OracleType.VarChar, 50);
               prm8.Direction = ParameterDirection.Input;
               prm8.Value = ext;
               objOraclecommand.Parameters.Add(prm8);

               OracleParameter prm9 = new OracleParameter("fax", OracleType.VarChar, 50);
               prm9.Direction = ParameterDirection.Input;
               prm9.Value = fax;
               objOraclecommand.Parameters.Add(prm9);

               OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
               prm2.Direction = ParameterDirection.Input;
               prm2.Value = userid;
               objOraclecommand.Parameters.Add(prm2);


               OracleParameter prm4 = new OracleParameter("mail", OracleType.VarChar, 50);
               prm4.Direction = ParameterDirection.Input;
               prm4.Value = mail;
               objOraclecommand.Parameters.Add(prm4); 

               OracleParameter prm10 = new OracleParameter("agencysubcode", OracleType.VarChar, 50);
               prm10.Direction = ParameterDirection.Input;
               prm10.Value = agencysubcode;
               objOraclecommand.Parameters.Add(prm10);

               OracleParameter prm16 = new OracleParameter("role1", OracleType.VarChar, 50);
               prm16.Direction = ParameterDirection.Input;
               prm16.Value = role;
               objOraclecommand.Parameters.Add(prm16);

                OracleParameter prm11 = new OracleParameter("compcode", OracleType.VarChar, 50);
               prm11.Direction = ParameterDirection.Input;
               prm11.Value = compcode;
               objOraclecommand.Parameters.Add(prm11);


               OracleParameter prm12 = new OracleParameter("update1", OracleType.VarChar, 50);
               prm12.Direction = ParameterDirection.Input;
               prm12.Value = update;
               objOraclecommand.Parameters.Add(prm12);

               OracleParameter prm13 = new OracleParameter("product", OracleType.VarChar, 50);
               prm13.Direction = ParameterDirection.Input;
               prm13.Value = id;
               objOraclecommand.Parameters.Add(prm13);

               OracleParameter prm17 = new OracleParameter("mobile", OracleType.VarChar, 50);
               prm17.Direction = ParameterDirection.Input;
               prm17.Value = mobile;
               objOraclecommand.Parameters.Add(prm17);

                
                objorclDataAdapter.SelectCommand =objOraclecommand;
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

     

        public DataSet contactdelete(string compcode, string userid, string agencode, string agencysubcode, string update)
        //contactperson,designation,dob,phone,,fax,mail,Session["userid"].ToString(),hidden
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_contactdelete.websp_contactdelete_p", ref objOracleConnection);
               objOraclecommand.CommandType = CommandType.StoredProcedure;


               OracleParameter prm1 = new OracleParameter("agentcode", OracleType.VarChar, 50);
               prm1.Direction = ParameterDirection.Input;
               prm1.Value = agencode;
               objOraclecommand.Parameters.Add(prm1);

               OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
               prm2.Direction = ParameterDirection.Input;
               prm2.Value = userid;
               objOraclecommand.Parameters.Add(prm2);

               OracleParameter prm3 = new OracleParameter("agencysubcode", OracleType.VarChar, 50);
               prm3.Direction = ParameterDirection.Input;
               prm3.Value = agencysubcode;
               objOraclecommand.Parameters.Add(prm3);

               OracleParameter prm4 = new OracleParameter("update1", OracleType.VarChar, 50);
               prm4.Direction = ParameterDirection.Input;
               prm4.Value = update;
               objOraclecommand.Parameters.Add(prm4);

                objorclDataAdapter.SelectCommand =objOraclecommand;
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

        public DataSet commission()
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_comm_detail.websp_comm_detail_p", ref objOracleConnection);
               objOraclecommand.CommandType = CommandType.StoredProcedure;

               objOraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
               objOraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand =objOraclecommand;
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

        public DataSet insertcomm(string effectivedate, string efeectivetill, string commrate, string commapply, string compcode, string userid, string agencode, string agencysubcode, string dateformat, string adtype, string adcomm, string uom, string agen, string cash_disc, string cash_amt, string adcat)
        //effectivedate,efeectivetill,commrate,commapply,Session["compcode"].ToString(),Session["userid"].ToString(),agencode,agencysubcode
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_insertcomm.websp_insertcomm_p", ref objOracleConnection);
               objOraclecommand.CommandType = CommandType.StoredProcedure;

               OracleParameter prm3 = new OracleParameter("effectivedate", OracleType.VarChar, 50);
               prm3.Direction = ParameterDirection.Input;
               //if (dateformat == "dd/mm/yyyy")
               //{
               //    string[] arr = effectivedate.Split('/');
               //    string dd = arr[0];
               //    string mm = arr[1];
               //    string yy = arr[2];
               //    effectivedate = mm + "/" + dd + "/" + yy;


               //}
               //    else
               //        if (dateformat == "yyyy/mm/dd")
               //        {
               //            string[] arr = effectivedate.Split('/');
               //            string dd = arr[2];
               //            string mm = arr[1];
               //            string yy = arr[0];
               //            effectivedate = mm + "/" + dd + "/" + yy;
               //        }


               prm3.Value =Convert.ToDateTime(effectivedate).ToString("dd-MMMM-yyyy");
               objOraclecommand.Parameters.Add(prm3);

               OracleParameter prm2 = new OracleParameter("efeectivetill", OracleType.VarChar, 50);
               prm2.Direction = ParameterDirection.Input;

               //if (dateformat == "dd/mm/yyyy")
               //{
               //    string[] arr = efeectivetill.Split('/');
               //    string dd = arr[0];
               //    string mm = arr[1];
               //    string yy = arr[2];
               //    efeectivetill = mm + "/" + dd + "/" + yy;


               //}
               //else
               //    if (dateformat == "yyyy/mm/dd")
               //    {
               //        string[] arr = efeectivetill.Split('/');
               //        string dd = arr[2];
               //        string mm = arr[1];
               //        string yy = arr[0];
               //        efeectivetill = mm + "/" + dd + "/" + yy;
               //    }
               prm2.Value =Convert.ToDateTime(efeectivetill).ToString("dd-MMMM-yyyy");
               objOraclecommand.Parameters.Add(prm2);

               OracleParameter prm4 = new OracleParameter("commrate", OracleType.VarChar, 50);
               prm4.Direction = ParameterDirection.Input;
               prm4.Value = commrate;
               objOraclecommand.Parameters.Add(prm4);


               OracleParameter prm5 = new OracleParameter("commapply", OracleType.VarChar, 50);
               prm5.Direction = ParameterDirection.Input;
               prm5.Value =commapply;
               objOraclecommand.Parameters.Add(prm5);


               OracleParameter prm6 = new OracleParameter("compcode", OracleType.VarChar, 50);
               prm6.Direction = ParameterDirection.Input;
               prm6.Value = compcode;
               objOraclecommand.Parameters.Add(prm6);

               OracleParameter prm7 = new OracleParameter("userid", OracleType.VarChar, 50);
               prm7.Direction = ParameterDirection.Input;
               prm7.Value = userid;
               objOraclecommand.Parameters.Add(prm7);

               OracleParameter prm9 = new OracleParameter("agencode", OracleType.VarChar, 50);
               prm9.Direction = ParameterDirection.Input;
               prm9.Value = agencode;
               objOraclecommand.Parameters.Add(prm9);

               OracleParameter prm8 = new OracleParameter("agencysubcode", OracleType.VarChar, 50);
               prm8.Direction = ParameterDirection.Input;
               prm8.Value = agencysubcode;
               objOraclecommand.Parameters.Add(prm8);

               OracleParameter prm10 = new OracleParameter("adtype1", OracleType.VarChar, 50);
               prm10.Direction = ParameterDirection.Input;
               prm10.Value = adtype;
               objOraclecommand.Parameters.Add(prm10);

               OracleParameter prm11 = new OracleParameter("addcomm", OracleType.VarChar, 50);
               prm11.Direction = ParameterDirection.Input;
                if(adcomm=="")
                    prm11.Value = "0";
                else
                {
                    prm11.Value = adcomm;
                }
               objOraclecommand.Parameters.Add(prm11);

               OracleParameter prm12 = new OracleParameter("uom1", OracleType.VarChar, 50);
               prm12.Direction = ParameterDirection.Input;
               prm12.Value = uom;
               objOraclecommand.Parameters.Add(prm12);

               OracleParameter prm13 = new OracleParameter("agen", OracleType.VarChar, 50);
               prm13.Direction = ParameterDirection.Input;
               prm13.Value = agen;
               objOraclecommand.Parameters.Add(prm13);

               OracleParameter prm14 = new OracleParameter("cash_disc", OracleType.VarChar, 50);
               prm14.Direction = ParameterDirection.Input;
               prm14.Value = cash_disc;
               objOraclecommand.Parameters.Add(prm14);

               OracleParameter prm15 = new OracleParameter("cash_amt", OracleType.VarChar, 50);
               prm15.Direction = ParameterDirection.Input;
               if (cash_amt == "")
                   prm15.Value = System.DBNull.Value;
               else
                   prm15.Value = cash_amt;
               objOraclecommand.Parameters.Add(prm15);


               OracleParameter prm16 = new OracleParameter("adcat11", OracleType.VarChar, 50);
               prm16.Direction = ParameterDirection.Input;
               if (adcat == "")
                   prm16.Value = System.DBNull.Value;
               else
                   prm16.Value = adcat;
               objOraclecommand.Parameters.Add(prm16);



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

        //       ***************************My Code*******************************

        public DataSet selectname(string compcode, string userid)//,string agencode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_selectname.websp_selectname_p", ref objOracleConnection);
               objOraclecommand.CommandType = CommandType.StoredProcedure;


               OracleParameter prm6 = new OracleParameter("userid", OracleType.VarChar, 50);
               prm6.Direction = ParameterDirection.Input;
               prm6.Value = userid;
               objOraclecommand.Parameters.Add(prm6);

               OracleParameter prm7= new OracleParameter("compcode", OracleType.VarChar, 50);
               prm7.Direction = ParameterDirection.Input;
               prm7.Value = compcode;
               objOraclecommand.Parameters.Add(prm7);


                
                objorclDataAdapter.SelectCommand =objOraclecommand;
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




        //       ******************************************************************






        public DataSet commbind(string agencode, string compcode, string userid, string dateformat, string newagecode)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("commbind.commbind_p", ref objOracleConnection);
               objOraclecommand.CommandType = CommandType.StoredProcedure;



               OracleParameter prm7 = new OracleParameter("compcode", OracleType.VarChar, 50);
               prm7.Direction = ParameterDirection.Input;
               prm7.Value = compcode;
               objOraclecommand.Parameters.Add(prm7);

               OracleParameter prm9 = new OracleParameter("agencode", OracleType.VarChar, 50);
               prm9.Direction = ParameterDirection.Input;
               if (agencode == "")
                    prm9.Value  = System.DBNull.Value;
               else
                    prm9.Value = agencode;
               objOraclecommand.Parameters.Add(prm9);

               OracleParameter prm6 = new OracleParameter("newagecode", OracleType.VarChar, 50);
               prm6.Direction = ParameterDirection.Input;
               prm6.Value = newagecode;
               objOraclecommand.Parameters.Add(prm6);

               OracleParameter prm8 = new OracleParameter("userid", OracleType.VarChar, 50);
               prm8.Direction = ParameterDirection.Input;
               prm8.Value = userid;
               objOraclecommand.Parameters.Add(prm8);

               OracleParameter prm5 = new OracleParameter("dateformat", OracleType.VarChar, 50);
               prm5.Direction = ParameterDirection.Input;
               prm5.Value =dateformat;
               objOraclecommand.Parameters.Add(prm5);

               objOraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
               objOraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand =objOraclecommand;
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

        public DataSet commcheckdate(string agencode, string compcode, string userid, string fromdatecomm, string tilldate, string agencysubcode, string adtype, string uom11)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("checkdatecomm.checkdatecomm_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;



                OracleParameter prm7 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = compcode;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = userid;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm6 = new OracleParameter("fromdatecomm", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = Convert.ToDateTime(fromdatecomm).ToString("dd-MMMM-yyyy");
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm5 = new OracleParameter("tilldate", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = Convert.ToDateTime(tilldate).ToString("dd-MMMM-yyyy");
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm4 = new OracleParameter("agencode", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = agencode;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm3 = new OracleParameter("agencysubcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = agencysubcode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm9 = new OracleParameter("adtype1", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = adtype;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("uom11", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                if (uom11 == "" || uom11 == "0")
                    prm10.Value = System.DBNull.Value;
                else
                prm10.Value = uom11;
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

        public DataSet commcheckdate12(string agencode, string compcode, string userid, string fromdatecomm, string tilldate, string hiddenccode, string subagencycode, string drpcommdetail, string adtype, string uom)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("checkdatecomm12.checkdatecomm12_p", ref objOracleConnection);
               objOraclecommand.CommandType = CommandType.StoredProcedure;

               OracleParameter prm7 = new OracleParameter("compcode", OracleType.VarChar, 50);
               prm7.Direction = ParameterDirection.Input;
               prm7.Value = compcode;
               objOraclecommand.Parameters.Add(prm7);

               OracleParameter prm8 = new OracleParameter("userid", OracleType.VarChar, 50);
               prm8.Direction = ParameterDirection.Input;
               prm8.Value = userid;
               objOraclecommand.Parameters.Add(prm8);

               OracleParameter prm11 = new OracleParameter("hiddenccode", OracleType.VarChar, 50);
               prm11.Direction = ParameterDirection.Input;
               prm11.Value = hiddenccode;
               objOraclecommand.Parameters.Add(prm11);

               OracleParameter prm1 = new OracleParameter("fromdatecomm", OracleType.VarChar, 50);
               prm1.Direction = ParameterDirection.Input;
               prm1.Value =Convert.ToDateTime(fromdatecomm).ToString("dd-MMMM-yyyy");
               objOraclecommand.Parameters.Add(prm1);

               OracleParameter prm5 = new OracleParameter("tilldate", OracleType.VarChar, 50);
               prm5.Direction = ParameterDirection.Input;
               prm5.Value =Convert.ToDateTime(tilldate).ToString("dd-MMMM-yyyy");
               objOraclecommand.Parameters.Add(prm5);

               OracleParameter prm4 = new OracleParameter("agencode", OracleType.VarChar, 50);
               prm4.Direction = ParameterDirection.Input;
               prm4.Value = agencode;
               objOraclecommand.Parameters.Add(prm4);

               OracleParameter prm3 = new OracleParameter("agencysubcode", OracleType.VarChar, 50);
               prm3.Direction = ParameterDirection.Input;
               prm3.Value = subagencycode;
               objOraclecommand.Parameters.Add(prm3);

               OracleParameter prm12 = new OracleParameter("adtype1", OracleType.VarChar, 50);
               prm12.Direction = ParameterDirection.Input;
               prm12.Value = adtype;
               objOraclecommand.Parameters.Add(prm12);

               OracleParameter prm13 = new OracleParameter("uom1", OracleType.VarChar, 50);
               prm13.Direction = ParameterDirection.Input;
               prm13.Value = uom;
               objOraclecommand.Parameters.Add(prm13);


               objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
               objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;
                
                objorclDataAdapter.SelectCommand =objOraclecommand;
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

        public DataSet commbind123(string agencode, string compcode, string userid, string code)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("commbind12.commbind12_p", ref objOracleConnection);
               objOraclecommand.CommandType = CommandType.StoredProcedure;

               OracleParameter prm7 = new OracleParameter("compcode", OracleType.VarChar, 50);
               prm7.Direction = ParameterDirection.Input;
               prm7.Value = compcode;
               objOraclecommand.Parameters.Add(prm7);

               OracleParameter prm1 = new OracleParameter("code", OracleType.VarChar, 50);
               prm1.Direction = ParameterDirection.Input;
               prm1.Value = code;
               objOraclecommand.Parameters.Add(prm1);

               OracleParameter prm8 = new OracleParameter("userid", OracleType.VarChar, 50);
               prm8.Direction = ParameterDirection.Input;
               prm8.Value = userid;
               objOraclecommand.Parameters.Add(prm8);

               OracleParameter prm4 = new OracleParameter("agencode", OracleType.VarChar, 50);
               prm4.Direction = ParameterDirection.Input;
               prm4.Value = agencode;
               objOraclecommand.Parameters.Add(prm4);


               objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
               objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

              
                objorclDataAdapter.SelectCommand =objOraclecommand;
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


        public DataSet insertbank(string bgno, string bgdate, string amount, string bank, string validitydate, string compcode, string userid, string agencode, string agencysubcode,string dateformat,string attach)
        //bgno,bgdate,amount,bank,validitydate,Session["compcode"].ToString(),Session["userid"].ToString(),agencode,agencysubcode)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_insertbank.websp_insertbank_p", ref objOracleConnection);
               objOraclecommand.CommandType = CommandType.StoredProcedure;

               OracleParameter prm1 = new OracleParameter("bgno", OracleType.VarChar, 50);
               prm1.Direction = ParameterDirection.Input;
               prm1.Value =bgno;
               objOraclecommand.Parameters.Add(prm1);


               OracleParameter prm2 = new OracleParameter("bgdate", OracleType.VarChar, 50);
               prm2.Direction = ParameterDirection.Input;
               //if (dateformat == "dd/mm/yyyy")
               //{
               //    string[] arr = bgdate.Split('/');
               //    string dd = arr[0];
               //    string mm = arr[1];
               //    string yy = arr[2];
               //    bgdate = mm + "/" + dd + "/" + yy;


               //}
               //else
               //    if (dateformat == "mm/dd/yyyy")
               //    {
               //        string[] arr = bgdate.Split('/');
               //        string dd = arr[1];
               //        string mm = arr[0];
               //        string yy = arr[2];
               //        bgdate = mm + "/" + dd + "/" + yy;

               //    }

               //    else
               //        if (dateformat == "yyyy/mm/dd")
               //        {
               //            string[] arr = bgdate.Split('/');
               //            string dd = arr[2];
               //            string mm = arr[1];
               //            string yy = arr[0];
               //            bgdate = mm + "/" + dd + "/" + yy;
               //        }

               prm2.Value =Convert.ToDateTime(bgdate).ToString("dd-MMMM-yyyy");
               objOraclecommand.Parameters.Add(prm2);

               OracleParameter prm11 = new OracleParameter("amount", OracleType.VarChar, 50);
               prm11.Direction = ParameterDirection.Input;
               prm11.Value =amount;
               objOraclecommand.Parameters.Add(prm11);

               OracleParameter prm12 = new OracleParameter("bank", OracleType.VarChar, 50);
               prm12.Direction = ParameterDirection.Input;
               prm12.Value =bank;
               objOraclecommand.Parameters.Add(prm12);

               OracleParameter prm3 = new OracleParameter("validitydate", OracleType.VarChar, 50);
               prm3.Direction = ParameterDirection.Input;
               //if (dateformat == "dd/mm/yyyy")
               //{
               //    string[] arr = validitydate.Split('/');
               //    string dd = arr[0];
               //    string mm = arr[1];
               //    string yy = arr[2];
               //    validitydate = mm + "/" + dd + "/" + yy;


               //}
               //else
               //    if (dateformat == "mm/dd/yyyy")
               //    {
               //        string[] arr = validitydate.Split('/');
               //        string dd = arr[1];
               //        string mm = arr[0];
               //        string yy = arr[2];
               //        validitydate = mm + "/" + dd + "/" + yy;

               //    }

               //    else
               //        if (dateformat == "yyyy/mm/dd")
               //        {
               //            string[] arr = validitydate.Split('/');
               //            string dd = arr[2];
               //            string mm = arr[1];
               //            string yy = arr[0];
               //            validitydate = mm + "/" + dd + "/" + yy;
               //        }

               prm3.Value =Convert.ToDateTime(validitydate).ToString("dd-MMMM-yyyy");
               objOraclecommand.Parameters.Add(prm3);

               OracleParameter prm4 = new OracleParameter("compcode", OracleType.VarChar, 50);
               prm4.Direction = ParameterDirection.Input;
               prm4.Value = compcode;
               objOraclecommand.Parameters.Add(prm4);

               OracleParameter prm5 = new OracleParameter("userid", OracleType.VarChar, 50);
               prm5.Direction = ParameterDirection.Input;
               prm5.Value =userid;
               objOraclecommand.Parameters.Add(prm5);


               OracleParameter prm6 = new OracleParameter("agencode", OracleType.VarChar, 50);
               prm6.Direction = ParameterDirection.Input;
               prm6.Value = agencode;
               objOraclecommand.Parameters.Add(prm6);

               OracleParameter prm7 = new OracleParameter("agencysubcode", OracleType.VarChar, 50);
               prm7.Direction = ParameterDirection.Input;
               prm7.Value =agencysubcode;
               objOraclecommand.Parameters.Add(prm7);



               OracleParameter prm8 = new OracleParameter("pattach", OracleType.VarChar, 50);
               prm8.Direction = ParameterDirection.Input;
               prm8.Value = attach;
               objOraclecommand.Parameters.Add(prm8);

                objorclDataAdapter.SelectCommand =objOraclecommand;
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


        public DataSet bankbind(string agencode, string compcode, string userid, string date, string nagencycode)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_bankbind.websp_bankbind_p", ref objOracleConnection);
               objOraclecommand.CommandType = CommandType.StoredProcedure;

               OracleParameter prm4 = new OracleParameter("compcode", OracleType.VarChar, 50);
               prm4.Direction = ParameterDirection.Input;
               prm4.Value = compcode;
               objOraclecommand.Parameters.Add(prm4);

               OracleParameter prm3 = new OracleParameter("nagencycode", OracleType.VarChar, 50);
               prm3.Direction = ParameterDirection.Input;
               prm3.Value = nagencycode;
               objOraclecommand.Parameters.Add(prm3);


               OracleParameter prm5 = new OracleParameter("userid", OracleType.VarChar, 50);
               prm5.Direction = ParameterDirection.Input;
               prm5.Value =userid;
               objOraclecommand.Parameters.Add(prm5);

               OracleParameter prm6 = new OracleParameter("agencode", OracleType.VarChar, 50);
               prm6.Direction = ParameterDirection.Input;
               prm6.Value= agencode;
               objOraclecommand.Parameters.Add(prm6);

               OracleParameter prm7 = new OracleParameter("date1", OracleType.VarChar, 50);
               prm7.Direction = ParameterDirection.Input;
               prm7.Value = date;
               objOraclecommand.Parameters.Add(prm7);

               objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
               objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;


             
                objorclDataAdapter.SelectCommand =objOraclecommand;
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


        public DataSet bankbind12(string agencode, string compcode, string userid, string code)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_bankbind12.websp_bankbind12_p", ref objOracleConnection);
               objOraclecommand.CommandType = CommandType.StoredProcedure;

               OracleParameter prm4 = new OracleParameter("compcode", OracleType.VarChar, 50);
               prm4.Direction = ParameterDirection.Input;
               prm4.Value = compcode;
               objOraclecommand.Parameters.Add(prm4);

               OracleParameter prm3 = new OracleParameter("code", OracleType.VarChar, 50);
               prm3.Direction = ParameterDirection.Input;
               prm3.Value = code;
               objOraclecommand.Parameters.Add(prm3);

               OracleParameter prm5 = new OracleParameter("userid", OracleType.VarChar, 50);
               prm5.Direction = ParameterDirection.Input;
               prm5.Value = userid;
               objOraclecommand.Parameters.Add(prm5);

               OracleParameter prm6 = new OracleParameter("agencode", OracleType.VarChar, 50);
               prm6.Direction = ParameterDirection.Input;
               prm6.Value = agencode;
               objOraclecommand.Parameters.Add(prm6);


               objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
               objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

             
                objorclDataAdapter.SelectCommand =objOraclecommand;
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



        public DataSet updatebank(string bgno, string bankdate, string amount, string bank, string validitydate, string compcode, string userid, string agencode, string agencysubcode, string code,string attach)
        //bgno,bankdate,amount,bank,validitydate,Session[""].ToString(),Session[""].ToString(),agencode,agencysubcode
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_updatebank.websp_updatebank_p", ref objOracleConnection);
               objOraclecommand.CommandType = CommandType.StoredProcedure;


               OracleParameter prm1 = new OracleParameter("bgno", OracleType.VarChar, 50);
               prm1.Direction = ParameterDirection.Input;
               prm1.Value = bgno;
               objOraclecommand.Parameters.Add(prm1);


               OracleParameter prm2 = new OracleParameter("bankdate", OracleType.VarChar, 50);
               prm2.Direction = ParameterDirection.Input;
               prm2.Value =Convert.ToDateTime(bankdate).ToString("dd-MMMM-yyyy");
               objOraclecommand.Parameters.Add(prm2);

               OracleParameter prm11 = new OracleParameter("amount1", OracleType.VarChar, 50);
               prm11.Direction = ParameterDirection.Input;
               prm11.Value = amount;
               objOraclecommand.Parameters.Add(prm11);

               OracleParameter prm12 = new OracleParameter("bank", OracleType.VarChar, 50);
               prm12.Direction = ParameterDirection.Input;
               prm12.Value = bank;
               objOraclecommand.Parameters.Add(prm12);

               OracleParameter prm3 = new OracleParameter("validitydate", OracleType.VarChar, 50);
               prm3.Direction = ParameterDirection.Input;
               prm3.Value =Convert.ToDateTime(validitydate).ToString("dd-MMMM-yyyy");
               objOraclecommand.Parameters.Add(prm3);

               OracleParameter prm7 = new OracleParameter("agencysubcode", OracleType.VarChar, 50);
               prm7.Direction = ParameterDirection.Input;
               prm7.Value = agencysubcode;
               objOraclecommand.Parameters.Add(prm7);

               OracleParameter prm4 = new OracleParameter("compcode", OracleType.VarChar, 50);
               prm4.Direction = ParameterDirection.Input;
               prm4.Value = compcode;
               objOraclecommand.Parameters.Add(prm4);

               OracleParameter prm5 = new OracleParameter("userid", OracleType.VarChar, 50);
               prm5.Direction = ParameterDirection.Input;
               prm5.Value =userid;
               objOraclecommand.Parameters.Add(prm5);

               OracleParameter prm6 = new OracleParameter("agencode", OracleType.VarChar, 50);
               prm6.Direction = ParameterDirection.Input;
               prm6.Value = agencode;
               objOraclecommand.Parameters.Add(prm6);

               OracleParameter prm8 = new OracleParameter("code", OracleType.VarChar, 50);
               prm8.Direction = ParameterDirection.Input;
               prm8.Value = code;
               objOraclecommand.Parameters.Add(prm8);

               OracleParameter prm9 = new OracleParameter("pattach", OracleType.VarChar, 50);
               prm9.Direction = ParameterDirection.Input;
               prm9.Value = attach;
               objOraclecommand.Parameters.Add(prm9);
              


                objorclDataAdapter.SelectCommand =objOraclecommand;
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

       public DataSet deletebank(string compcode, string userid, string agencode, string agencysubcode, string code)
        //bgno,bankdate,amount,bank,validitydate,Session[""].ToString(),Session[""].ToString(),agencode,agencysubcode
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_deletebank.websp_deletebank_p", ref objOracleConnection);
               objOraclecommand.CommandType = CommandType.StoredProcedure;

               OracleParameter prm7 = new OracleParameter("agencysubcode", OracleType.VarChar, 50);
               prm7.Direction = ParameterDirection.Input;
               prm7.Value = agencysubcode;
               objOraclecommand.Parameters.Add(prm7);
               OracleParameter prm4 = new OracleParameter("compcode", OracleType.VarChar, 50);
               prm4.Direction = ParameterDirection.Input;
               prm4.Value = compcode;
               objOraclecommand.Parameters.Add(prm4);

               OracleParameter prm5 = new OracleParameter("userid", OracleType.VarChar, 50);
               prm5.Direction = ParameterDirection.Input;
               prm5.Value = userid;
               objOraclecommand.Parameters.Add(prm5);

               OracleParameter prm6 = new OracleParameter("agencode", OracleType.VarChar, 50);
               prm6.Direction = ParameterDirection.Input;
               prm6.Value = agencode;
               objOraclecommand.Parameters.Add(prm6);

               OracleParameter prm8 = new OracleParameter("code", OracleType.VarChar, 50);
               prm8.Direction = ParameterDirection.Input;
               prm8.Value = code;
               objOraclecommand.Parameters.Add(prm8);
              

                
                objorclDataAdapter.SelectCommand =objOraclecommand;
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





       public DataSet commupdate(string effectivefrm, string efftill, string commrate, string commapplied, string code, string compcode, string userid, string agencode, string adtype, string addcommrate, string uom, string agen, string cash_disc, string cash_amt, string adcat)
        //effectivefrm,efftill,commrate,commapplied,code,Session["compcode"].ToString(),Session["userid"].ToString(),agencode,agencysubcode
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_commupdate.websp_commupdate_p", ref objOracleConnection);
               objOraclecommand.CommandType = CommandType.StoredProcedure;

               OracleParameter prm1 = new OracleParameter("effectivefrm", OracleType.VarChar, 50);
               prm1.Direction = ParameterDirection.Input;
               
               prm1.Value =Convert.ToDateTime(effectivefrm).ToString("dd-MMMM-yyyy");
               objOraclecommand.Parameters.Add(prm1);

               OracleParameter prm2 = new OracleParameter("efftill", OracleType.VarChar, 50);
               prm2.Direction = ParameterDirection.Input;
               
               prm2.Value =Convert.ToDateTime(efftill).ToString("dd-MMMM-yyyy");
               objOraclecommand.Parameters.Add(prm2);

               OracleParameter prm7 = new OracleParameter("commrate", OracleType.VarChar, 50);
               prm7.Direction = ParameterDirection.Input;
               prm7.Value = commrate;
               objOraclecommand.Parameters.Add(prm7);

               OracleParameter prm3 = new OracleParameter("commapplied", OracleType.VarChar, 50);
               prm3.Direction = ParameterDirection.Input;
               prm3.Value = commapplied;
               objOraclecommand.Parameters.Add(prm3);

               OracleParameter prm4 = new OracleParameter("compcode", OracleType.VarChar, 50);
               prm4.Direction = ParameterDirection.Input;
               prm4.Value = compcode;
               objOraclecommand.Parameters.Add(prm4);

               OracleParameter prm5 = new OracleParameter("userid", OracleType.VarChar, 50);
               prm5.Direction = ParameterDirection.Input;
               prm5.Value = userid;
               objOraclecommand.Parameters.Add(prm5);

               OracleParameter prm6 = new OracleParameter("agencode", OracleType.VarChar, 50);
               prm6.Direction = ParameterDirection.Input;
               prm6.Value = agencode;
               objOraclecommand.Parameters.Add(prm6);

               OracleParameter prm8 = new OracleParameter("code", OracleType.VarChar, 50);
               prm8.Direction = ParameterDirection.Input;
               prm8.Value = code;
               objOraclecommand.Parameters.Add(prm8);

               OracleParameter prm9 = new OracleParameter("adtype1", OracleType.VarChar, 50);
               prm9.Direction = ParameterDirection.Input;
               prm9.Value = adtype;
               objOraclecommand.Parameters.Add(prm9);

               OracleParameter prm10 = new OracleParameter("addcommrate", OracleType.VarChar, 50);
               prm10.Direction = ParameterDirection.Input;
               if (addcommrate == "" || addcommrate == "null" || addcommrate == null)
                    prm10.Value = "0";
                else
               prm10.Value = addcommrate;
               objOraclecommand.Parameters.Add(prm10);

               OracleParameter prm11 = new OracleParameter("uom1", OracleType.VarChar, 50);
               prm11.Direction = ParameterDirection.Input;
                if(uom =="" || uom == "0")
                    prm11.Value=System.DBNull.Value;
                else
               prm11.Value = uom;
               objOraclecommand.Parameters.Add(prm11);

               OracleParameter prm12 = new OracleParameter("agen", OracleType.VarChar, 50);
               prm12.Direction = ParameterDirection.Input;
               if (agen == "")
                   prm12.Value = System.DBNull.Value;
               else
                   prm12.Value = agen;
               objOraclecommand.Parameters.Add(prm12);

               OracleParameter prm14 = new OracleParameter("cash_disc", OracleType.VarChar, 50);
               prm14.Direction = ParameterDirection.Input;
               prm14.Value = cash_disc;
               objOraclecommand.Parameters.Add(prm14);

               OracleParameter prm15 = new OracleParameter("cash_amt", OracleType.VarChar, 50);
               prm15.Direction = ParameterDirection.Input;
               if (cash_amt == "" || cash_amt == "null" || cash_amt == null)
                   prm15.Value = System.DBNull.Value;
               else
                   prm15.Value = cash_amt;
               objOraclecommand.Parameters.Add(prm15);



               OracleParameter prm16 = new OracleParameter("adcat11", OracleType.VarChar, 50);
               prm16.Direction = ParameterDirection.Input;
               if (adcat == "" || adcat == "0")
                   prm16.Value = System.DBNull.Value;
               else
                   prm16.Value = adcat;
               objOraclecommand.Parameters.Add(prm16);



             
                objorclDataAdapter.SelectCommand =objOraclecommand;
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


        public DataSet commdelete(string code, string compcode, string userid, string agencode, string agencysubcode)
        //effectivefrm,efftill,commrate,commapplied,code,Session["compcode"].ToString(),Session["userid"].ToString(),agencode,agencysubcode
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_commdelete.websp_commdelete_p", ref objOracleConnection);
               objOraclecommand.CommandType = CommandType.StoredProcedure;

               OracleParameter prm7 = new OracleParameter("agencysubcode", OracleType.VarChar, 50);
               prm7.Direction = ParameterDirection.Input;
               prm7.Value = agencysubcode;
               objOraclecommand.Parameters.Add(prm7);
               OracleParameter prm4 = new OracleParameter("compcode", OracleType.VarChar, 50);
               prm4.Direction = ParameterDirection.Input;
               prm4.Value = compcode;
               objOraclecommand.Parameters.Add(prm4);

               OracleParameter prm5 = new OracleParameter("userid", OracleType.VarChar, 50);
               prm5.Direction = ParameterDirection.Input;
               prm5.Value = userid;
               objOraclecommand.Parameters.Add(prm5);

               OracleParameter prm6 = new OracleParameter("agencode", OracleType.VarChar, 50);
               prm6.Direction = ParameterDirection.Input;
               prm6.Value = agencode;
               objOraclecommand.Parameters.Add(prm6);

               OracleParameter prm8 = new OracleParameter("code", OracleType.VarChar, 50);
               prm8.Direction = ParameterDirection.Input;
               prm8.Value = code;
               objOraclecommand.Parameters.Add(prm8);
              
               
                objorclDataAdapter.SelectCommand =objOraclecommand;
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



        public DataSet statusbind12(string agencode, string compcode, string userid, string date, string nagencycode)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_statusbind12.websp_statusbind12_p", ref objOracleConnection);
               objOraclecommand.CommandType = CommandType.StoredProcedure;

               OracleParameter prm7 = new OracleParameter("nagencycode", OracleType.VarChar, 50);
               prm7.Direction = ParameterDirection.Input;
               prm7.Value = nagencycode;
               objOraclecommand.Parameters.Add(prm7);

               OracleParameter prm4 = new OracleParameter("compcode", OracleType.VarChar, 50);
               prm4.Direction = ParameterDirection.Input;
               prm4.Value = compcode;
               objOraclecommand.Parameters.Add(prm4);

               OracleParameter prm5 = new OracleParameter("userid", OracleType.VarChar, 50);
               prm5.Direction = ParameterDirection.Input;
               prm5.Value = userid;
               objOraclecommand.Parameters.Add(prm5);

               OracleParameter prm6 = new OracleParameter("DATE1", OracleType.VarChar, 50);
               prm6.Direction = ParameterDirection.Input;
               prm6.Value = date;
               objOraclecommand.Parameters.Add(prm6);

               OracleParameter prm8 = new OracleParameter("agencode", OracleType.VarChar, 50);
               prm8.Direction = ParameterDirection.Input;
               prm8.Value = agencode;
               objOraclecommand.Parameters.Add(prm8);

               objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
               objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                
                objorclDataAdapter.SelectCommand =objOraclecommand;
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

        public DataSet statusbind(string agencode, string compcode, string userid, string hiddenccode)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_statusbind.websp_statusbind_p", ref objOracleConnection);
               objOraclecommand.CommandType = CommandType.StoredProcedure;



               OracleParameter prm7 = new OracleParameter("agencode", OracleType.VarChar, 50);
               prm7.Direction = ParameterDirection.Input;
               prm7.Value = agencode;
               objOraclecommand.Parameters.Add(prm7);

               OracleParameter prm4 = new OracleParameter("compcode", OracleType.VarChar, 50);
               prm4.Direction = ParameterDirection.Input;
               prm4.Value = compcode;
               objOraclecommand.Parameters.Add(prm4);

               OracleParameter prm5 = new OracleParameter("userid", OracleType.VarChar, 50);
               prm5.Direction = ParameterDirection.Input;
               prm5.Value = userid;
               objOraclecommand.Parameters.Add(prm5);

               OracleParameter prm6 = new OracleParameter("hiddenccode", OracleType.VarChar, 50);
               prm6.Direction = ParameterDirection.Input;
               prm6.Value =hiddenccode;
               objOraclecommand.Parameters.Add(prm6);

               objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
               objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand =objOraclecommand;
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

        //                          drpstatus,           txtfrom,           txtto,        circular,        compcode,       userid,        agentcode,          agencycode,       txtremark
        public DataSet insertstatus(string status, string fromdate, string todate, string circular, string compcode, string userid, string agencode, string agencysubcode, string remarks,string dateformat,string attachment)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_insertstatus.websp_insertstatus_p", ref objOracleConnection);
               objOraclecommand.CommandType = CommandType.StoredProcedure;

               OracleParameter prm1 = new OracleParameter("fromdate", OracleType.VarChar, 50);
               prm1.Direction = ParameterDirection.Input;
               //if (dateformat == "dd/mm/yyyy")
               //{
               //    string[] arr = fromdate.Split('/');
               //    string dd = arr[0];
               //    string mm = arr[1];
               //    string yy = arr[2];
               //    fromdate = mm + "/" + dd + "/" + yy;


               //}
               //else
               //    if (dateformat == "mm/dd/yyyy")
               //    {
               //        string[] arr = fromdate.Split('/');
               //        string dd = arr[1];
               //        string mm = arr[0];
               //        string yy = arr[2];
               //        fromdate = mm + "/" + dd + "/" + yy;

               //    }

               //    else
               //        if (dateformat == "yyyy/mm/dd")
               //        {
               //            string[] arr = fromdate.Split('/');
               //            string dd = arr[2];
               //            string mm = arr[1];
               //            string yy = arr[0];
               //            fromdate = mm + "/" + dd + "/" + yy;
               //        }

               prm1.Value =Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");
               objOraclecommand.Parameters.Add(prm1);

               OracleParameter prm2 = new OracleParameter("todate", OracleType.VarChar, 50);
               prm2.Direction = ParameterDirection.Input;
               //if (dateformat == "dd/mm/yyyy")
               //{
               //    string[] arr = todate.Split('/');
               //    string dd = arr[0];
               //    string mm = arr[1];
               //    string yy = arr[2];
               //    todate = mm + "/" + dd + "/" + yy;


               //}
               //else
               //    if (dateformat == "mm/dd/yyyy")
               //    {
               //        string[] arr = todate.Split('/');
               //        string dd = arr[1];
               //        string mm = arr[0];
               //        string yy = arr[2];
               //        todate = mm + "/" + dd + "/" + yy;

               //    }

               //    else
               //        if (dateformat == "yyyy/mm/dd")
               //        {
               //            string[] arr = todate.Split('/');
               //            string dd = arr[2];
               //            string mm = arr[1];
               //            string yy = arr[0];
               //            todate = mm + "/" + dd + "/" + yy;
               //        }

               prm2.Value =Convert.ToDateTime(todate).ToString("dd-MMMM-yyyy");
               objOraclecommand.Parameters.Add(prm2);

               OracleParameter prm3 = new OracleParameter("circular", OracleType.VarChar, 50);
               prm3.Direction = ParameterDirection.Input;
               prm3.Value = circular;
               objOraclecommand.Parameters.Add(prm3);

               OracleParameter prm41 = new OracleParameter("status", OracleType.VarChar, 50);
               prm41.Direction = ParameterDirection.Input;
               prm41.Value = status;
               objOraclecommand.Parameters.Add(prm41);

               OracleParameter prm42 = new OracleParameter("agencysubcode", OracleType.VarChar, 50);
               prm42.Direction = ParameterDirection.Input;
               prm42.Value = agencysubcode;
               objOraclecommand.Parameters.Add(prm42);

               OracleParameter prm4 = new OracleParameter("compcode", OracleType.VarChar, 50);
               prm4.Direction = ParameterDirection.Input;
               prm4.Value = compcode;
               objOraclecommand.Parameters.Add(prm4);

               OracleParameter prm5 = new OracleParameter("userid", OracleType.VarChar, 50);
               prm5.Direction = ParameterDirection.Input;
               prm5.Value = userid;
               objOraclecommand.Parameters.Add(prm5);

               OracleParameter prm6 = new OracleParameter("agencode", OracleType.VarChar, 50);
               prm6.Direction = ParameterDirection.Input;
               prm6.Value = agencode;
               objOraclecommand.Parameters.Add(prm6);

               OracleParameter prm7 = new OracleParameter("remarks", OracleType.VarChar, 50);
               prm7.Direction = ParameterDirection.Input;
               prm7.Value = remarks;
               objOraclecommand.Parameters.Add(prm7);

               OracleParameter prm8 = new OracleParameter("attach", OracleType.VarChar, 50);
               prm8.Direction = ParameterDirection.Input;
               prm8.Value = attachment;
               objOraclecommand.Parameters.Add(prm8);

               
                objorclDataAdapter.SelectCommand =objOraclecommand;
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

      public DataSet statusupdate(string status, string frmdate, string todate, string circular, string agencode, string compcode, string userid, string agencysubcode, string code, string remarks, string attach)

            //status,frmdate,todate,code, compcode,userid,agencode,agencysubcode
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_statusupdate.websp_statusupdate_p", ref objOracleConnection);
               objOraclecommand.CommandType = CommandType.StoredProcedure;

               OracleParameter prm1 = new OracleParameter("frmdate", OracleType.VarChar, 50);
               prm1.Direction = ParameterDirection.Input;
              
               prm1.Value =Convert.ToDateTime(frmdate).ToString("dd-MMMM-yyyy");
               objOraclecommand.Parameters.Add(prm1);

               OracleParameter prm2 = new OracleParameter("todate", OracleType.VarChar, 50);
               prm2.Direction = ParameterDirection.Input;
           
               prm2.Value =Convert.ToDateTime(todate).ToString("dd-MMMM-yyyy");
               objOraclecommand.Parameters.Add(prm2);

               OracleParameter prm3 = new OracleParameter("circular", OracleType.VarChar, 50);
               prm3.Direction = ParameterDirection.Input;
               prm3.Value = circular;
               objOraclecommand.Parameters.Add(prm3);

               OracleParameter prm41 = new OracleParameter("status", OracleType.VarChar, 50);
               prm41.Direction = ParameterDirection.Input;
               prm41.Value = status;
               objOraclecommand.Parameters.Add(prm41);

               OracleParameter prm42 = new OracleParameter("agencysubcode", OracleType.VarChar, 50);
               prm42.Direction = ParameterDirection.Input;
               prm42.Value = agencysubcode;
               objOraclecommand.Parameters.Add(prm42);

               OracleParameter prm4 = new OracleParameter("compcode", OracleType.VarChar, 50);
               prm4.Direction = ParameterDirection.Input;
               prm4.Value = compcode;
               objOraclecommand.Parameters.Add(prm4);

               OracleParameter prm5 = new OracleParameter("userid", OracleType.VarChar, 50);
               prm5.Direction = ParameterDirection.Input;
               prm5.Value = userid;
               objOraclecommand.Parameters.Add(prm5);

               OracleParameter prm6 = new OracleParameter("agencode", OracleType.VarChar, 50);
               prm6.Direction = ParameterDirection.Input;
               prm6.Value = agencode;
               objOraclecommand.Parameters.Add(prm6);

               OracleParameter prm7 = new OracleParameter("remarks", OracleType.VarChar, 50);
               prm7.Direction = ParameterDirection.Input;
               prm7.Value = remarks;
               objOraclecommand.Parameters.Add(prm7);


               OracleParameter prm8 = new OracleParameter("code", OracleType.VarChar, 50);
               prm8.Direction = ParameterDirection.Input;
               prm8.Value = code;
               objOraclecommand.Parameters.Add(prm8);

               OracleParameter prm9 = new OracleParameter("attach", OracleType.VarChar, 50);
               prm9.Direction = ParameterDirection.Input;
               prm9.Value = attach;
               objOraclecommand.Parameters.Add(prm9);

                objorclDataAdapter.SelectCommand =objOraclecommand;
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

        public DataSet statusdelete(string compcode, string userid, string agencode, string agencysubcode, string hiddenccode)
        //effectivefrm,efftill,commrate,commapplied,code,Session["compcode"].ToString(),Session["userid"].ToString(),agencode,agencysubcode
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_statusdelete.websp_statusdelete_p", ref objOracleConnection);
               objOraclecommand.CommandType = CommandType.StoredProcedure;

               OracleParameter prm4 = new OracleParameter("compcode", OracleType.VarChar, 50);
               prm4.Direction = ParameterDirection.Input;
               prm4.Value = compcode;
               objOraclecommand.Parameters.Add(prm4);

               OracleParameter prm5 = new OracleParameter("userid", OracleType.VarChar, 50);
               prm5.Direction = ParameterDirection.Input;
               prm5.Value = userid;
               objOraclecommand.Parameters.Add(prm5);

               OracleParameter prm6 = new OracleParameter("agencode", OracleType.VarChar, 50);
               prm6.Direction = ParameterDirection.Input;
               prm6.Value = agencode;
               objOraclecommand.Parameters.Add(prm6);

               OracleParameter prm7 = new OracleParameter("agencysubcode", OracleType.VarChar, 50);
               prm7.Direction = ParameterDirection.Input;
               prm7.Value = agencysubcode;
               objOraclecommand.Parameters.Add(prm7);

               OracleParameter prm8 = new OracleParameter("hiddenccode", OracleType.VarChar, 50);
               prm8.Direction = ParameterDirection.Input;
               prm8.Value = hiddenccode;
               objOraclecommand.Parameters.Add(prm8);

               
                objorclDataAdapter.SelectCommand =objOraclecommand;
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
        public DataSet paybind()
        //effectivefrm,efftill,commrate,commapplied,code,Session["compcode"].ToString(),Session["userid"].ToString(),agencode,agencysubcode
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_paybind.websp_paybind_p", ref objOracleConnection);
               objOraclecommand.CommandType = CommandType.StoredProcedure;

                
                objorclDataAdapter.SelectCommand =objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (OracleException  objException)
            {
                throw (objException);
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



        public DataSet payselect(string agencode, string userid, string compcode, string subagencycode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("payselect.payselect_p", ref objOracleConnection);
               objOraclecommand.CommandType = CommandType.StoredProcedure;

               OracleParameter prm4 = new OracleParameter("compcode", OracleType.VarChar, 50);
               prm4.Direction = ParameterDirection.Input;
               prm4.Value = compcode;
               objOraclecommand.Parameters.Add(prm4);

               OracleParameter prm5 = new OracleParameter("userid", OracleType.VarChar, 50);
               prm5.Direction = ParameterDirection.Input;
               prm5.Value = userid;
               objOraclecommand.Parameters.Add(prm5);

               OracleParameter prm6 = new OracleParameter("agencode", OracleType.VarChar, 50);
               prm6.Direction = ParameterDirection.Input;
               prm6.Value = agencode;
               objOraclecommand.Parameters.Add(prm6);

               OracleParameter prm7 = new OracleParameter("subagencycode", OracleType.VarChar, 50);
               prm7.Direction = ParameterDirection.Input;
               prm7.Value = subagencycode;
               objOraclecommand.Parameters.Add(prm7);

          
                objorclDataAdapter.SelectCommand =objOraclecommand;
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


        public DataSet paydelete(string cash, string credit, string bank, string code, string compcode, string userid, string agencode, string agencysubcode)
        //effectivefrm,efftill,commrate,commapplied,code,Session["compcode"].ToString(),Session["userid"].ToString(),agencode,agencysubcode
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_paydelete.websp_paydelete_p", ref objOracleConnection);
               objOraclecommand.CommandType = CommandType.StoredProcedure;



                if (cash == null || cash == "")
                {
                   objOraclecommand.Parameters["@cash"].Value = System.DBNull.Value;

                }
                else
                {
                   objOraclecommand.Parameters["@cash"].Value = cash;
                }
                OracleParameter prm5 = new OracleParameter("credit", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = credit;
           //     objOraclecommand.Parameters.Add(prm5);

                if (credit == null || credit == "")
                {
                   objOraclecommand.Parameters["@credit"].Value = System.DBNull.Value;
                }
                else
                {

                   objOraclecommand.Parameters["@credit"].Value = credit;
                }

                OracleParameter prm10= new OracleParameter("bank", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = bank;
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm4 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = compcode;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm11 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = userid;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm6 = new OracleParameter("agencode", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = agencode;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("agencysubcode", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = agencysubcode;
                objOraclecommand.Parameters.Add(prm7);

                objorclDataAdapter.SelectCommand =objOraclecommand;
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

        public DataSet paycheck(string code, string compcode, string userid, string agencycode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_paycheck.websp_paycheck_p", ref objOracleConnection);
               objOraclecommand.CommandType = CommandType.StoredProcedure;

               OracleParameter prm1 = new OracleParameter("code", OracleType.VarChar, 50);
               prm1.Direction = ParameterDirection.Input;
               prm1.Value = code;
               objOraclecommand.Parameters.Add(prm1);

               OracleParameter prm2 = new OracleParameter("agencycode", OracleType.VarChar, 50);
               prm2.Direction = ParameterDirection.Input;
               prm2.Value = agencycode;
               objOraclecommand.Parameters.Add(prm2);

               OracleParameter prm4 = new OracleParameter("compcode", OracleType.VarChar, 50);
               prm4.Direction = ParameterDirection.Input;
               prm4.Value = compcode;
               objOraclecommand.Parameters.Add(prm4);

               OracleParameter prm5 = new OracleParameter("userid", OracleType.VarChar, 50);
               prm5.Direction = ParameterDirection.Input;
               prm5.Value = userid;
               objOraclecommand.Parameters.Add(prm5);

               objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
               objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;



                objorclDataAdapter.SelectCommand =objOraclecommand;
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

        public DataSet status(string code, string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_statuscheck.websp_statuscheck_p", ref objOracleConnection);
               objOraclecommand.CommandType = CommandType.StoredProcedure;

               OracleParameter prm1 = new OracleParameter("code", OracleType.VarChar, 50);
               prm1.Direction = ParameterDirection.Input;
               prm1.Value = code;
               objOraclecommand.Parameters.Add(prm1);

               OracleParameter prm4 = new OracleParameter("compcode", OracleType.VarChar, 50);
               prm4.Direction = ParameterDirection.Input;
               prm4.Value = compcode;
               objOraclecommand.Parameters.Add(prm4);

               OracleParameter prm5 = new OracleParameter("userid", OracleType.VarChar, 50);
               prm5.Direction = ParameterDirection.Input;
               prm5.Value = userid;
               objOraclecommand.Parameters.Add(prm5);

                objorclDataAdapter.SelectCommand =objOraclecommand;
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


        public DataSet contactcheck(string code, string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_contactcheck.websp_contactcheck_p", ref objOracleConnection);
               objOraclecommand.CommandType = CommandType.StoredProcedure;

               OracleParameter prm1 = new OracleParameter("code", OracleType.VarChar, 50);
               prm1.Direction = ParameterDirection.Input;
               prm1.Value = code;
               objOraclecommand.Parameters.Add(prm1);

               OracleParameter prm4 = new OracleParameter("compcode", OracleType.VarChar, 50);
               prm4.Direction = ParameterDirection.Input;
               prm4.Value = compcode;
               objOraclecommand.Parameters.Add(prm4);

               OracleParameter prm5 = new OracleParameter("userid", OracleType.VarChar, 50);
               prm5.Direction = ParameterDirection.Input;
               prm5.Value = userid;
               objOraclecommand.Parameters.Add(prm5);

                objorclDataAdapter.SelectCommand =objOraclecommand;
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

        public DataSet commcheck(string code, string compcode, string userid, string subagency)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_commcheck.websp_commcheck_p", ref objOracleConnection);
               objOraclecommand.CommandType = CommandType.StoredProcedure;

               OracleParameter prm1 = new OracleParameter("code", OracleType.VarChar, 50);
               prm1.Direction = ParameterDirection.Input;
               prm1.Value = code;
               objOraclecommand.Parameters.Add(prm1);

               OracleParameter prm4 = new OracleParameter("compcode", OracleType.VarChar, 50);
               prm4.Direction = ParameterDirection.Input;
               prm4.Value = compcode;
               objOraclecommand.Parameters.Add(prm4);

               OracleParameter prm5 = new OracleParameter("userid", OracleType.VarChar, 50);
               prm5.Direction = ParameterDirection.Input;
               prm5.Value = userid;
               objOraclecommand.Parameters.Add(prm5);


               OracleParameter prm6 = new OracleParameter("subagency", OracleType.VarChar, 50);
               prm6.Direction = ParameterDirection.Input;
               prm6.Value =subagency;
               objOraclecommand.Parameters.Add(prm6);

               objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
               objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;


                objorclDataAdapter.SelectCommand =objOraclecommand;
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



        public DataSet statuscheck(string drpstatus, string txtfrom, string txtto, string circular, string compcode, string userid, string agencode, string agencysubcode, string remark)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_statuscheck123.websp_statuscheck123_p", ref objOracleConnection);
               objOraclecommand.CommandType = CommandType.StoredProcedure;

               OracleParameter prm4 = new OracleParameter("compcode", OracleType.VarChar, 50);
               prm4.Direction = ParameterDirection.Input;
               prm4.Value = compcode;
               objOraclecommand.Parameters.Add(prm4);

               OracleParameter prm5 = new OracleParameter("userid", OracleType.VarChar, 50);
               prm5.Direction = ParameterDirection.Input;
               prm5.Value = userid;
               objOraclecommand.Parameters.Add(prm5);


               OracleParameter prm6 = new OracleParameter("agencode", OracleType.VarChar, 50);
               prm6.Direction = ParameterDirection.Input;
               prm6.Value = agencode;
               objOraclecommand.Parameters.Add(prm6);
                
                objorclDataAdapter.SelectCommand =objOraclecommand;
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

        public DataSet statuscheckdate(string agencode, string compcode, string userid, string txtfrom, string txtto, string circular, string date, string remarks, string subagencycode)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("statuscheckdate.statuscheckdate_p", ref objOracleConnection);
               objOraclecommand.CommandType = CommandType.StoredProcedure;



               OracleParameter prm4 = new OracleParameter("compcode", OracleType.VarChar, 50);
               prm4.Direction = ParameterDirection.Input;
               prm4.Value = compcode;
               objOraclecommand.Parameters.Add(prm4);

               OracleParameter prm5 = new OracleParameter("userid", OracleType.VarChar, 50);
               prm5.Direction = ParameterDirection.Input;
               prm5.Value = userid;
               objOraclecommand.Parameters.Add(prm5);

               OracleParameter prm2 = new OracleParameter("subagencycode", OracleType.VarChar, 50);
               prm2.Direction = ParameterDirection.Input;
               prm2.Value = subagencycode;
               objOraclecommand.Parameters.Add(prm2);
                
               OracleParameter prm3 = new OracleParameter("date", OracleType.VarChar, 50);
               prm3.Direction = ParameterDirection.Input;
               prm3.Value = date;
               objOraclecommand.Parameters.Add(prm3);
                
               OracleParameter prm6 = new OracleParameter("agencode", OracleType.VarChar, 50);
               prm6.Direction = ParameterDirection.Input;
               prm6.Value = agencode;
               objOraclecommand.Parameters.Add(prm6);

               OracleParameter prm1 = new OracleParameter("txtfrom", OracleType.VarChar, 50);
               prm1.Direction = ParameterDirection.Input;
               prm1.Value =txtfrom;
               objOraclecommand.Parameters.Add(prm1);


               OracleParameter prm8 = new OracleParameter("txtto", OracleType.VarChar, 50);
               prm8.Direction = ParameterDirection.Input;
               prm8.Value = txtto;
               objOraclecommand.Parameters.Add(prm8);

               OracleParameter prm9 = new OracleParameter("circular", OracleType.VarChar, 50);
               prm9.Direction = ParameterDirection.Input;
               prm9.Value = circular;
               objOraclecommand.Parameters.Add(prm9);


               OracleParameter prm7 = new OracleParameter("remarks", OracleType.VarChar, 50);
               prm7.Direction = ParameterDirection.Input;
               prm7.Value = remarks;
               objOraclecommand.Parameters.Add(prm7);




             
                objorclDataAdapter.SelectCommand =objOraclecommand;
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

        public DataSet statusdateupdate12(string agencode, string compcode, string userid, string txtfrom, string txtto, string code, string circular, string date, string remarks, string subagencycode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("statuscheckdateupdate.statuscheckdateupdate_p", ref objOracleConnection);
               objOraclecommand.CommandType = CommandType.StoredProcedure;



               OracleParameter prm5 = new OracleParameter("agencode", OracleType.VarChar, 50);
               prm5.Direction = ParameterDirection.Input;
               prm5.Value = agencode;
               objOraclecommand.Parameters.Add(prm5);

               OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
               prm2.Direction = ParameterDirection.Input;
               prm2.Value = userid;
               objOraclecommand.Parameters.Add(prm2);

               OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
               prm1.Direction = ParameterDirection.Input;
               prm1.Value = compcode;
               objOraclecommand.Parameters.Add(prm1);


               OracleParameter prm6 = new OracleParameter("txtfrom", OracleType.VarChar, 50);
               prm6.Direction = ParameterDirection.Input;
               prm6.Value =Convert.ToDateTime(txtfrom).ToString("dd-MMMM-yyyy");
               objOraclecommand.Parameters.Add(prm6);

               OracleParameter prm7 = new OracleParameter("txtto", OracleType.VarChar, 50);
               prm7.Direction = ParameterDirection.Input;
               prm7.Value =Convert.ToDateTime(txtto).ToString("dd-MMMM-yyyy");
               objOraclecommand.Parameters.Add(prm7);

               OracleParameter prm9 = new OracleParameter("circular", OracleType.VarChar, 50);
               prm9.Direction = ParameterDirection.Input;
               prm9.Value = circular;
               objOraclecommand.Parameters.Add(prm9);

               OracleParameter prm3 = new OracleParameter("date1", OracleType.VarChar, 50);
               prm3.Direction = ParameterDirection.Input;
               prm3.Value = date;
               objOraclecommand.Parameters.Add(prm3);


               OracleParameter prm10 = new OracleParameter("remarks", OracleType.VarChar, 50);
               prm10.Direction = ParameterDirection.Input;
               prm10.Value = remarks;
               objOraclecommand.Parameters.Add(prm10);

               OracleParameter prm4 = new OracleParameter("subagencycode", OracleType.VarChar, 50);
               prm4.Direction = ParameterDirection.Input;
               prm4.Value = subagencycode;
               objOraclecommand.Parameters.Add(prm4);

               OracleParameter prm8 = new OracleParameter("code", OracleType.VarChar, 50);
               prm8.Direction = ParameterDirection.Input;
               prm8.Value = code;
               objOraclecommand.Parameters.Add(prm8);

            
               objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
               objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand =objOraclecommand;
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


        public DataSet bindpub(string compcode, string userid, string agencycode, string agencysubcode)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_pub_mast.websp_pub_mast_p", ref objOracleConnection);
               objOraclecommand.CommandType = CommandType.StoredProcedure;

               OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
               prm1.Direction = ParameterDirection.Input;
               prm1.Value = compcode;
               objOraclecommand.Parameters.Add(prm1);




               OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
               prm2.Direction = ParameterDirection.Input;
               prm2.Value = userid;
               objOraclecommand.Parameters.Add(prm2);



               OracleParameter prm3 = new OracleParameter("agencycode", OracleType.VarChar, 50);
               prm3.Direction = ParameterDirection.Input;
               prm3.Value = agencycode;
               objOraclecommand.Parameters.Add(prm3);




               OracleParameter prm4 = new OracleParameter("agencysubcode", OracleType.VarChar, 50);
               prm4.Direction = ParameterDirection.Input;
               prm4.Value = agencysubcode;
               objOraclecommand.Parameters.Add(prm4);



              
                objorclDataAdapter.SelectCommand =objOraclecommand;
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

        public DataSet insertintopub(string compcode, string userid, string agencycode, string subagency, string pub, string commrate)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
               objOraclecommand = GetCommand("websp_pubinsert.websp_pubinsert_p", ref objOracleConnection);
               objOraclecommand.CommandType = CommandType.StoredProcedure;



               OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
               prm1.Direction = ParameterDirection.Input;
               prm1.Value = compcode;
               objOraclecommand.Parameters.Add(prm1);



               OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
               prm2.Direction = ParameterDirection.Input;
               prm2.Value = userid;
               objOraclecommand.Parameters.Add(prm2);




               OracleParameter prm3 = new OracleParameter("agencycode", OracleType.VarChar, 50);
               prm3.Direction = ParameterDirection.Input;
               prm3.Value = agencycode;
               objOraclecommand.Parameters.Add(prm3);



               OracleParameter prm4 = new OracleParameter("subagency", OracleType.VarChar, 50);
               prm4.Direction = ParameterDirection.Input;
               prm4.Value = subagency;
               objOraclecommand.Parameters.Add(prm4);





               OracleParameter prm5 = new OracleParameter("pub", OracleType.VarChar, 50);
               prm5.Direction = ParameterDirection.Input;
               prm5.Value = pub;
               objOraclecommand.Parameters.Add(prm5);



               OracleParameter prm6 = new OracleParameter("commrate", OracleType.VarChar, 50);
               prm6.Direction = ParameterDirection.Input;
               prm6.Value = commrate;
               objOraclecommand.Parameters.Add(prm6);


            

                
                objorclDataAdapter.SelectCommand =objOraclecommand;
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

        public DataSet bindpub(string agencycode, string subagency, string compcode, string userid, string codepub)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_checkpub.websp_checkpub_p", ref objOracleConnection);
               objOraclecommand.CommandType = CommandType.StoredProcedure;

               OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
               prm1.Direction = ParameterDirection.Input;
               prm1.Value = compcode;
               objOraclecommand.Parameters.Add(prm1);

              
               OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
               prm2.Direction = ParameterDirection.Input;
               prm2.Value = userid;
               objOraclecommand.Parameters.Add(prm2);


               OracleParameter prm3 = new OracleParameter("agencycode", OracleType.VarChar, 50);
               prm3.Direction = ParameterDirection.Input;
               prm3.Value = agencycode;
               objOraclecommand.Parameters.Add(prm3);



               OracleParameter prm4 = new OracleParameter("subagency", OracleType.VarChar, 50);
               prm4.Direction = ParameterDirection.Input;
               prm4.Value = subagency;
               objOraclecommand.Parameters.Add(prm4);




               OracleParameter prm5 = new OracleParameter("codepub", OracleType.VarChar, 50);
               prm5.Direction = ParameterDirection.Input;
               prm5.Value = codepub;
               objOraclecommand.Parameters.Add(prm5);

           
               
                objorclDataAdapter.SelectCommand =objOraclecommand;
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



        public DataSet updatepub1(string compcode, string userid, string agencycode, string subagency, string pub, string commrate, string code)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_updatepub.websp_updatepub_p", ref objOracleConnection);
               objOraclecommand.CommandType = CommandType.StoredProcedure;

               OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
               prm1.Direction = ParameterDirection.Input;
               prm1.Value = compcode;
               objOraclecommand.Parameters.Add(prm1);



               OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
               prm2.Direction = ParameterDirection.Input;
               prm2.Value = userid;
               objOraclecommand.Parameters.Add(prm2);


               OracleParameter prm3 = new OracleParameter("agencycode", OracleType.VarChar, 50);
               prm3.Direction = ParameterDirection.Input;
               prm3.Value = agencycode;
               objOraclecommand.Parameters.Add(prm3);

           
               OracleParameter prm4 = new OracleParameter("subagency", OracleType.VarChar, 50);
               prm4.Direction = ParameterDirection.Input;
               prm4.Value = subagency;
               objOraclecommand.Parameters.Add(prm4);



               OracleParameter prm5 = new OracleParameter("pub", OracleType.VarChar, 50);
               prm5.Direction = ParameterDirection.Input;
               prm5.Value = pub;
               objOraclecommand.Parameters.Add(prm5);



               OracleParameter prm6 = new OracleParameter("commrate", OracleType.VarChar, 50);
               prm6.Direction = ParameterDirection.Input;
               prm6.Value = commrate;
               objOraclecommand.Parameters.Add(prm6);



               OracleParameter prm7 = new OracleParameter("code", OracleType.VarChar, 50);
               prm7.Direction = ParameterDirection.Input;
               prm7.Value = code;
               objOraclecommand.Parameters.Add(prm7);




               
                objorclDataAdapter.SelectCommand =objOraclecommand;
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


        public DataSet deletpub(string compcode, string userid, string agencycode, string subagency, string pub, string commrate, string code)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_deletepub.websp_deletepub_p", ref objOracleConnection);
               objOraclecommand.CommandType = CommandType.StoredProcedure;

               OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
               prm1.Direction = ParameterDirection.Input;
               prm1.Value = compcode;
               objOraclecommand.Parameters.Add(prm1);



               OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
               prm2.Direction = ParameterDirection.Input;
               prm2.Value = userid;
               objOraclecommand.Parameters.Add(prm2);



               OracleParameter prm3 = new OracleParameter("agencycode", OracleType.VarChar, 50);
               prm3.Direction = ParameterDirection.Input;
               prm3.Value = agencycode;
               objOraclecommand.Parameters.Add(prm3);




               OracleParameter prm4 = new OracleParameter("subagency", OracleType.VarChar, 50);
               prm4.Direction = ParameterDirection.Input;
               prm4.Value = subagency;
               objOraclecommand.Parameters.Add(prm4);




               OracleParameter prm5 = new OracleParameter("pub", OracleType.VarChar, 50);
               prm5.Direction = ParameterDirection.Input;
               prm5.Value = pub;
               objOraclecommand.Parameters.Add(prm5);

               

               OracleParameter prm6 = new OracleParameter("commrate", OracleType.VarChar, 50);
               prm6.Direction = ParameterDirection.Input;
               prm6.Value = commrate;
               objOraclecommand.Parameters.Add(prm6);



               OracleParameter prm7 = new OracleParameter("code", OracleType.VarChar, 50);
               prm7.Direction = ParameterDirection.Input;
               prm7.Value = code;
               objOraclecommand.Parameters.Add(prm7);



               
                objorclDataAdapter.SelectCommand =objOraclecommand;
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




        public DataSet MasterPrev(string prev, string formname, string compcode, string userid)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("Wesp_insertModuleDetail.Wesp_insertModuleDetail_p", ref objOracleConnection);
               objOraclecommand.CommandType = CommandType.StoredProcedure;

               OracleParameter prm1 = new OracleParameter("prev", OracleType.VarChar, 50);
               prm1.Direction = ParameterDirection.Input;
               prm1.Value = prev;
               objOraclecommand.Parameters.Add(prm1);



               OracleParameter prm2 = new OracleParameter("formname", OracleType.VarChar, 50);
               prm2.Direction = ParameterDirection.Input;
               prm2.Value = formname;
               objOraclecommand.Parameters.Add(prm2);




               OracleParameter prm3 = new OracleParameter("compcode", OracleType.VarChar, 50);
               prm3.Direction = ParameterDirection.Input;
               prm3.Value = compcode;
               objOraclecommand.Parameters.Add(prm3);


            

               OracleParameter prm4 = new OracleParameter("userid", OracleType.VarChar, 50);
               prm4.Direction = ParameterDirection.Input;
               prm4.Value = userid;
               objOraclecommand.Parameters.Add(prm4);


             



                objorclDataAdapter.SelectCommand =objOraclecommand;
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



        public DataSet MasterPrevSel(string userid, string modulename)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("Wesp_ModuleDetailSel.Wesp_ModuleDetailSel_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;



                OracleParameter prm1 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = userid;
                objOraclecommand.Parameters.Add(prm1);





                OracleParameter prm2 = new OracleParameter("modulename", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = modulename;
                objOraclecommand.Parameters.Add(prm2);


                objOraclecommand.Parameters.Add("P_ACCOUNTS", OracleType.Cursor);
                objOraclecommand.Parameters["P_ACCOUNTS"].Direction = ParameterDirection.Output;


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


        public DataSet MasterPrevSel2(string user)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("Wesp_ModuleDetailSel2.Wesp_ModuleDetailSel2_p", ref objOracleConnection);
               objOraclecommand.CommandType = CommandType.StoredProcedure;


               OracleParameter prm1 = new OracleParameter("user", OracleType.VarChar, 50);
               prm1.Direction = ParameterDirection.Input;
               prm1.Value = user;
               objOraclecommand.Parameters.Add(prm1);

             

              
                objorclDataAdapter.SelectCommand =objOraclecommand;
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





        public DataSet MasterPrevbut(string priv, string formname, string compcode, string userid)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("Wesp_ModuleDetailbut.Wesp_ModuleDetailbut_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;



                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);




                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);



                OracleParameter prm3 = new OracleParameter("prev", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = priv;
                objOraclecommand.Parameters.Add(prm3);



                OracleParameter prm4 = new OracleParameter("formname", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = formname;
                objOraclecommand.Parameters.Add(prm4);





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

        public DataSet checkPrevuser(string userid, string formname)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("Wesp_Modulechekboxuser.Wesp_Modulechekboxuser_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = userid;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("formname1", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = formname;
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


        public DataSet checkPrev()
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
               objOraclecommand = GetCommand("Wesp_Modulechekbox.Wesp_Modulechekbox_p", ref objOracleConnection);
               objOraclecommand.CommandType = CommandType.StoredProcedure;

               objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
               objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;


               
                objorclDataAdapter.SelectCommand =objOraclecommand;
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



        public DataSet checkForm()
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("Wesp_ModulechekForm.Wesp_ModulechekForm_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

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

        public DataSet checkFormuser(string userid)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
               objOraclecommand = GetCommand("Wesp_ModulechekForm.Wesp_ModulechekForm_p", ref objOracleConnection);
               objOraclecommand.CommandType = CommandType.StoredProcedure;

               objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
               objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;


              
                objorclDataAdapter.SelectCommand =objOraclecommand;
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



  

        public DataSet MastPrevDisp(string compcode, string userid, string userhome, string admin, string retainer)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
               objOraclecommand = GetCommand("wesp_ModultPrevDisp.wesp_ModultPrevDisp_p", ref objOracleConnection);
               objOraclecommand.CommandType = CommandType.StoredProcedure;

                     OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
               prm1.Direction = ParameterDirection.Input;
               prm1.Value = compcode;
               objOraclecommand.Parameters.Add(prm1);

                     OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
               prm2.Direction = ParameterDirection.Input;
               prm2.Value = userid;
               objOraclecommand.Parameters.Add(prm2);

            
                     OracleParameter prm3 = new OracleParameter("userhome", OracleType.VarChar, 50);
               prm3.Direction = ParameterDirection.Input;
               prm3.Value = userhome;
               objOraclecommand.Parameters.Add(prm3);



               OracleParameter prm4 = new OracleParameter("ADMIN1", OracleType.VarChar, 50);
               prm4.Direction = ParameterDirection.Input;
               prm4.Value = admin;
               objOraclecommand.Parameters.Add(prm4);

               OracleParameter prm5 = new OracleParameter("Retainer", OracleType.VarChar, 50);
               prm5.Direction = ParameterDirection.Input;
               prm5.Value = retainer;
               objOraclecommand.Parameters.Add(prm5);


               objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
               objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

         

                objorclDataAdapter.SelectCommand =objOraclecommand;
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



        public DataSet Mastdetail(string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
               objOraclecommand = GetCommand("wesp_Modultdetail.wesp_Modultdetail_p", ref objOracleConnection);
               objOraclecommand.CommandType = CommandType.StoredProcedure;

                  OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
               prm1.Direction = ParameterDirection.Input;
               prm1.Value = compcode;
               objOraclecommand.Parameters.Add(prm1);

             

                  OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
               prm2.Direction = ParameterDirection.Input;
               prm2.Value = userid;
               objOraclecommand.Parameters.Add(prm2);

               objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
               objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;


                objorclDataAdapter.SelectCommand =objOraclecommand;
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



       


        public DataSet MastDivison(string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("wesp_Modultdivision.wesp_Modultdivision_p", ref objOracleConnection);
               objOraclecommand.CommandType = CommandType.StoredProcedure;

      
               OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
               prm1.Direction = ParameterDirection.Input;
               prm1.Value = compcode;
               objOraclecommand.Parameters.Add(prm1);

               OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
               prm2.Direction = ParameterDirection.Input;
               prm2.Value = userid;
               objOraclecommand.Parameters.Add(prm2);

               objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
               objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;


                objorclDataAdapter.SelectCommand =objOraclecommand;
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

        public DataSet MasterPrevSelect(string userid, string moduleno)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("Wesp_ModuleDetailSelect.Wesp_ModuleDetailSelect_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = userid;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("moduleno", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = moduleno;
                objOraclecommand.Parameters.Add(prm2);

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

        public DataSet MasterPrevSelchk(string userid, string modulename)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("Wesp_ModuleDetailSel.Wesp_ModuleDetailSel_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;



                OracleParameter prm1 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = userid;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("modulename", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = modulename;
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

        public DataSet buttonenablechk(string userid)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("Wesp_ModuleDetailbutton.Wesp_ModuleDetailbutton_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = userid;
                objOraclecommand.Parameters.Add(prm1);

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

        public DataSet inscheckForm(string moduleno)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("Wesp_ModuleFormins.Wesp_ModuleFormins_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("moduleno", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = moduleno;
                objOraclecommand.Parameters.Add(prm1);

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










        public DataSet dateupdation(string compcode, string userid, string dateformat, string code, string curr, string ratecode, string solo, string breakup, string bwcode, string rostatus, string filename, string tfn, string insertbreak, string prem, string dealtype, string pre, string suff, string chkfinancestatus, string voucherst, string adcode, string rodatetime, string spacearea, string vat, string bookstat, string cio_id, string receipt_no, string uom, string bgcolor, string validdate, string agencyratecode, string audit, string insert_date, string agencycomm, string rateaudit, string billaudit, string billtype, string invoice_no, string copybooking, string ratecomp, string addagencycomm, string agencyretcomm, string subrate, string displaybilltype, string classifiedbilltype, string billformat, string ratechk, string allpkg, string dayrate, string schemetype, string Includeclassi, string receiptformat, string cash_receipt, string bill_orderwiselast, string floor_chk, string Unsoldflag, string Supplystopper, string drpRokeychk, string Agencycomm_seq, string creditreciept, string cashindisplay, string cashinclassified, string rate_audit_pref, string barcoding_allow, string fmgbills, string billed_cashdis, string billed_cashcls, string v_drpbackdate, string dockitbooking, string allowprevbooking, string chkval, string cash_billtypea, string approval, string pckstatus, string cash_disc, string cash_amt, string seperate_cashier, string disp_bill, string clas_bill, string mantimepost, string bkdaypost, string maxterutn, string cir_return, string noofchkbounc, string noofdaychkrec, string retday, string chngsuppord, string max_publishday, string billno_period, string spl_trans_edit, string spl_dis_trans_editable, string mul_pac_sel_trans, string shmon_minword, string tradon_spcrg, string rateauth, string f2day, string rateauditmodify, string bindrevenuecenter, string led_allow, string clear_allow, string repeatday, string premiumedit, string BILL_GENERATION, string PUBLICATION_CENTER, string allow_discount_prem, string scheme_billing, string ALLOW_PDC, string ad_type_for_manul_bill, string RO_OUTSTAND_P, string genrate_agency_code, string dispauditbk)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("wesp_updatedate.wesp_updatedate_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                //////////////////////////////////////
                OracleParameter prm222 = new OracleParameter("billformat", OracleType.VarChar, 50);
                prm222.Direction = ParameterDirection.Input;
                prm222.Value = billformat;
                objOraclecommand.Parameters.Add(prm222);

                OracleParameter prm2221 = new OracleParameter("allpkg", OracleType.VarChar, 50);
                prm2221.Direction = ParameterDirection.Input;
                prm2221.Value = allpkg;
                objOraclecommand.Parameters.Add(prm2221);

                OracleParameter prm2222 = new OracleParameter("ratechk", OracleType.VarChar, 50);
                prm2222.Direction = ParameterDirection.Input;
                prm2222.Value = ratechk;
                objOraclecommand.Parameters.Add(prm2222);
                ///////////////////////////////////////

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("RATECODE11", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = ratecode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("dateformat", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = dateformat;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("code", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = code;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("curr", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = curr;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("solo", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = solo;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("breakup", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = breakup;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("bwcode", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = bwcode;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("rostatus", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = rostatus;
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("filename", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = filename;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("tfn", OracleType.VarChar, 50);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = tfn;
                objOraclecommand.Parameters.Add(prm12);

                OracleParameter prm13 = new OracleParameter("insertbreak", OracleType.VarChar, 50);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = insertbreak;
                objOraclecommand.Parameters.Add(prm13);

                OracleParameter prm14 = new OracleParameter("prem", OracleType.VarChar, 50);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = prem;
                objOraclecommand.Parameters.Add(prm14);

                OracleParameter prm15 = new OracleParameter("dealtype", OracleType.VarChar, 50);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = dealtype;
                objOraclecommand.Parameters.Add(prm15);

                OracleParameter prm16 = new OracleParameter("pre", OracleType.VarChar, 50);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = pre;
                objOraclecommand.Parameters.Add(prm16);

                OracleParameter prm17 = new OracleParameter("suff", OracleType.VarChar, 50);
                prm17.Direction = ParameterDirection.Input;
                prm17.Value = suff;
                objOraclecommand.Parameters.Add(prm17);


                OracleParameter prm18 = new OracleParameter("financestatus", OracleType.VarChar, 50);
                prm18.Direction = ParameterDirection.Input;
                prm18.Value = chkfinancestatus;
                objOraclecommand.Parameters.Add(prm18);

                OracleParameter prm19 = new OracleParameter("voucherst", OracleType.VarChar, 50);
                prm19.Direction = ParameterDirection.Input;
                prm19.Value = voucherst;
                objOraclecommand.Parameters.Add(prm19);


                OracleParameter prm20 = new OracleParameter("adcode", OracleType.VarChar, 50);
                prm20.Direction = ParameterDirection.Input;
                prm20.Value = adcode;
                objOraclecommand.Parameters.Add(prm20);

                OracleParameter prm21 = new OracleParameter("rodatetime", OracleType.VarChar, 50);
                prm21.Direction = ParameterDirection.Input;
                prm21.Value = rodatetime;
                objOraclecommand.Parameters.Add(prm21);

                OracleParameter prm23 = new OracleParameter("spacearea", OracleType.VarChar, 50);
                prm23.Direction = ParameterDirection.Input;
                prm23.Value = spacearea;
                objOraclecommand.Parameters.Add(prm23);

                OracleParameter prm24 = new OracleParameter("vat", OracleType.VarChar, 50);
                prm24.Direction = ParameterDirection.Input;
                prm24.Value = vat;
                objOraclecommand.Parameters.Add(prm24);


                OracleParameter prm25 = new OracleParameter("bookstat", OracleType.VarChar, 50);
                prm25.Direction = ParameterDirection.Input;
                prm25.Value = bookstat;
                objOraclecommand.Parameters.Add(prm25);

                OracleParameter prm26 = new OracleParameter("cio_id", OracleType.VarChar, 50);
                prm26.Direction = ParameterDirection.Input;
                prm26.Value = cio_id;
                objOraclecommand.Parameters.Add(prm26);

                OracleParameter prm27 = new OracleParameter("receipt_no", OracleType.VarChar, 50);
                prm27.Direction = ParameterDirection.Input;
                prm27.Value = receipt_no;
                objOraclecommand.Parameters.Add(prm27);

                /*new change ankur*/
                OracleParameter prm28 = new OracleParameter("uom", OracleType.VarChar, 50);
                prm28.Direction = ParameterDirection.Input;
                prm28.Value = uom;
                objOraclecommand.Parameters.Add(prm28);


                OracleParameter prm29 = new OracleParameter("bgcolor", OracleType.VarChar, 50);
                prm29.Direction = ParameterDirection.Input;
                prm29.Value = bgcolor;
                objOraclecommand.Parameters.Add(prm29);


                OracleParameter prm30 = new OracleParameter("validdate", OracleType.VarChar, 50);
                prm30.Direction = ParameterDirection.Input;
                prm30.Value = validdate;
                objOraclecommand.Parameters.Add(prm30);



                OracleParameter prm31 = new OracleParameter("agencyratecode", OracleType.VarChar, 50);
                prm31.Direction = ParameterDirection.Input;
                prm31.Value = agencyratecode;
                objOraclecommand.Parameters.Add(prm31);


                OracleParameter prm32 = new OracleParameter("AUDIT1", OracleType.VarChar, 50);
                prm32.Direction = ParameterDirection.Input;
                prm32.Value = audit;
                objOraclecommand.Parameters.Add(prm32);

                OracleParameter prm33 = new OracleParameter("book_insert_date", OracleType.VarChar, 50);
                prm33.Direction = ParameterDirection.Input;
                prm33.Value = insert_date;
                objOraclecommand.Parameters.Add(prm33);

                OracleParameter prm34 = new OracleParameter("agencycomm", OracleType.VarChar, 50);
                prm34.Direction = ParameterDirection.Input;
                prm34.Value = agencycomm;
                objOraclecommand.Parameters.Add(prm34);

                OracleParameter prm35 = new OracleParameter("rateaudit", OracleType.VarChar, 50);
                prm35.Direction = ParameterDirection.Input;
                prm35.Value = rateaudit;
                objOraclecommand.Parameters.Add(prm35);

                OracleParameter prm36 = new OracleParameter("billaudit", OracleType.VarChar, 50);
                prm36.Direction = ParameterDirection.Input;
                prm36.Value = billaudit;
                objOraclecommand.Parameters.Add(prm36);

                OracleParameter prm37 = new OracleParameter("bill_type", OracleType.VarChar, 50);
                prm37.Direction = ParameterDirection.Input;
                prm37.Value = billtype;
                objOraclecommand.Parameters.Add(prm37);

                OracleParameter prm38 = new OracleParameter("invoice_no1", OracleType.VarChar, 50);
                prm38.Direction = ParameterDirection.Input;
                prm38.Value = invoice_no;
                objOraclecommand.Parameters.Add(prm38);

                OracleParameter prm39 = new OracleParameter("copybooking", OracleType.VarChar, 50);
                prm39.Direction = ParameterDirection.Input;
                prm39.Value = copybooking;
                objOraclecommand.Parameters.Add(prm39);

                OracleParameter prm40 = new OracleParameter("ratecompany", OracleType.VarChar, 50);
                prm40.Direction = ParameterDirection.Input;
                prm40.Value = ratecomp;
                objOraclecommand.Parameters.Add(prm40);

                OracleParameter prm41 = new OracleParameter("addagenycomm", OracleType.VarChar, 50);
                prm41.Direction = ParameterDirection.Input;
                prm41.Value = addagencycomm;
                objOraclecommand.Parameters.Add(prm41);

                OracleParameter prm42 = new OracleParameter("agencycommlinkretainer", OracleType.VarChar, 50);
                prm42.Direction = ParameterDirection.Input;
                prm42.Value = agencyretcomm;
                objOraclecommand.Parameters.Add(prm42);

                OracleParameter prm43 = new OracleParameter("subeditionr", OracleType.VarChar, 50);
                prm43.Direction = ParameterDirection.Input;
                prm43.Value = subrate;
                objOraclecommand.Parameters.Add(prm43);

                OracleParameter prm142 = new OracleParameter("classifiedbilltype", OracleType.VarChar, 50);
                prm142.Direction = ParameterDirection.Input;
                prm142.Value = classifiedbilltype;
                objOraclecommand.Parameters.Add(prm142);

                OracleParameter prm143 = new OracleParameter("displaybilltype", OracleType.VarChar, 50);
                prm143.Direction = ParameterDirection.Input;
                prm143.Value = displaybilltype;
                objOraclecommand.Parameters.Add(prm143);

                OracleParameter prm1439 = new OracleParameter("dayrate1", OracleType.VarChar, 10);
                prm1439.Direction = ParameterDirection.Input;
                prm1439.Value = dayrate;
                objOraclecommand.Parameters.Add(prm1439);

                OracleParameter prm1440 = new OracleParameter("schemetype", OracleType.VarChar, 10);
                prm1440.Direction = ParameterDirection.Input;
                prm1440.Value = schemetype;
                objOraclecommand.Parameters.Add(prm1440);


                OracleParameter prm1441 = new OracleParameter("PIncludeclassi", OracleType.VarChar, 50);
                prm1441.Direction = ParameterDirection.Input;
                prm1441.Value = Includeclassi;
                objOraclecommand.Parameters.Add(prm1441);


                OracleParameter prm1442 = new OracleParameter("receiptformat", OracleType.VarChar, 50);
                prm1442.Direction = ParameterDirection.Input;
                prm1442.Value = receiptformat;
                objOraclecommand.Parameters.Add(prm1442);

                OracleParameter prm1443 = new OracleParameter("v_bill_orderwiselast", OracleType.VarChar, 50);
                prm1443.Direction = ParameterDirection.Input;
                prm1443.Value = bill_orderwiselast;
                objOraclecommand.Parameters.Add(prm1443);

                OracleParameter prm1463 = new OracleParameter("v_cash_receipt", OracleType.VarChar, 50);
                prm1463.Direction = ParameterDirection.Input;
                prm1463.Value = cash_receipt;
                objOraclecommand.Parameters.Add(prm1463);

                OracleParameter prm1465 = new OracleParameter("v_floor_chk", OracleType.VarChar, 50);
                prm1465.Direction = ParameterDirection.Input;
                prm1465.Value = floor_chk;
                objOraclecommand.Parameters.Add(prm1465);

                //for circulation

                OracleParameter prm1466 = new OracleParameter("Unsoldflag", OracleType.VarChar, 50);
                prm1466.Direction = ParameterDirection.Input;
                prm1466.Value = Unsoldflag;
                objOraclecommand.Parameters.Add(prm1466);

                OracleParameter prm1467 = new OracleParameter("Supplystopper", OracleType.VarChar, 50);
                prm1467.Direction = ParameterDirection.Input;
                prm1467.Value = Supplystopper;
                objOraclecommand.Parameters.Add(prm1467);

                OracleParameter prm1468 = new OracleParameter("drpRokeychk", OracleType.VarChar, 50);
                prm1468.Direction = ParameterDirection.Input;
                prm1468.Value = drpRokeychk;
                objOraclecommand.Parameters.Add(prm1468);


                OracleParameter prm1469 = new OracleParameter("Agencycomm_seq", OracleType.VarChar, 50);
                prm1469.Direction = ParameterDirection.Input;
                prm1469.Value = Agencycomm_seq;
                objOraclecommand.Parameters.Add(prm1469);

                OracleParameter prm1470 = new OracleParameter("creditreciept", OracleType.VarChar, 50);
                prm1470.Direction = ParameterDirection.Input;
                prm1470.Value = creditreciept;
                objOraclecommand.Parameters.Add(prm1470);



                OracleParameter prm1471 = new OracleParameter("cashindisplay", OracleType.VarChar, 50);
                prm1471.Direction = ParameterDirection.Input;
                prm1471.Value = cashindisplay;
                objOraclecommand.Parameters.Add(prm1471);

                OracleParameter prm1472 = new OracleParameter("cashinclassified", OracleType.VarChar, 50);
                prm1472.Direction = ParameterDirection.Input;
                prm1472.Value = cashinclassified;
                objOraclecommand.Parameters.Add(prm1472);

                OracleParameter prm1473 = new OracleParameter("v_rate_audit_pref", OracleType.VarChar, 50);
                prm1473.Direction = ParameterDirection.Input;
                prm1473.Value = rate_audit_pref;
                objOraclecommand.Parameters.Add(prm1473);



                OracleParameter prm1474 = new OracleParameter("v_barcoding_allow_pref", OracleType.VarChar, 50);
                prm1474.Direction = ParameterDirection.Input;
                prm1474.Value = barcoding_allow;
                objOraclecommand.Parameters.Add(prm1474);


                OracleParameter prm1475 = new OracleParameter("v_fmgbills", OracleType.VarChar, 50);
                prm1475.Direction = ParameterDirection.Input;
                prm1475.Value = fmgbills;
                objOraclecommand.Parameters.Add(prm1475);



                OracleParameter prm1476 = new OracleParameter("v_billed_cashdis", OracleType.VarChar, 50);
                prm1476.Direction = ParameterDirection.Input;
                prm1476.Value = billed_cashdis;
                objOraclecommand.Parameters.Add(prm1476);


                OracleParameter prm1477 = new OracleParameter("v_billed_cashcls", OracleType.VarChar, 50);
                prm1477.Direction = ParameterDirection.Input;
                prm1477.Value = billed_cashcls;
                objOraclecommand.Parameters.Add(prm1477);



                OracleParameter prm1478 = new OracleParameter("v_drpbackdate", OracleType.VarChar, 50);
                prm1478.Direction = ParameterDirection.Input;
                prm1478.Value = v_drpbackdate;
                objOraclecommand.Parameters.Add(prm1478);


                OracleParameter prm1479 = new OracleParameter("dockitbooking", OracleType.VarChar, 50);
                prm1479.Direction = ParameterDirection.Input;
                prm1479.Value = dockitbooking;
                objOraclecommand.Parameters.Add(prm1479);

                OracleParameter prm1480 = new OracleParameter("allowprevbooking", OracleType.VarChar, 50);
                prm1480.Direction = ParameterDirection.Input;
                prm1480.Value = allowprevbooking;
                objOraclecommand.Parameters.Add(prm1480);

                OracleParameter prm1481 = new OracleParameter("chkval", OracleType.VarChar, 50);
                prm1481.Direction = ParameterDirection.Input;
                prm1481.Value = chkval;
                objOraclecommand.Parameters.Add(prm1481);

                OracleParameter prm1482 = new OracleParameter("ro_wisecashbill", OracleType.VarChar, 50);
                prm1482.Direction = ParameterDirection.Input;
                prm1482.Value =cash_billtypea;
                objOraclecommand.Parameters.Add(prm1482);


                OracleParameter prm1483 = new OracleParameter("approval1", OracleType.VarChar, 50);
                prm1483.Direction = ParameterDirection.Input;
                prm1483.Value = approval;
                objOraclecommand.Parameters.Add(prm1483);

                OracleParameter prm1484 = new OracleParameter("pckstatus", OracleType.VarChar, 50);
                prm1484.Direction = ParameterDirection.Input;
                prm1484.Value = pckstatus;
                objOraclecommand.Parameters.Add(prm1484);

                OracleParameter prm1485 = new OracleParameter("cash_disc", OracleType.VarChar, 50);
                prm1485.Direction = ParameterDirection.Input;
                prm1485.Value = cash_disc;
                objOraclecommand.Parameters.Add(prm1485);

                OracleParameter prm1487 = new OracleParameter("cash_amt", OracleType.VarChar, 50);
                prm1487.Direction = ParameterDirection.Input;
                prm1487.Value = cash_amt;
                objOraclecommand.Parameters.Add(prm1487);

                OracleParameter prm1486 = new OracleParameter("seperate_cashier1", OracleType.VarChar, 50);
                prm1486.Direction = ParameterDirection.Input;
                prm1486.Value = seperate_cashier;
                objOraclecommand.Parameters.Add(prm1486);

                 OracleParameter prm50 = new OracleParameter("retday", OracleType.VarChar, 50);
                prm50.Direction = ParameterDirection.Input;
                prm50.Value = retday;
                objOraclecommand.Parameters.Add(prm50);

                 OracleParameter prm51 = new OracleParameter("disp_bill", OracleType.VarChar, 50);
                prm51.Direction = ParameterDirection.Input;
                prm51.Value = disp_bill;
                objOraclecommand.Parameters.Add(prm51);

                 OracleParameter prm52 = new OracleParameter("clas_bill", OracleType.VarChar, 50);
                prm52.Direction = ParameterDirection.Input;
                prm52.Value = clas_bill;
                objOraclecommand.Parameters.Add(prm52);

                 OracleParameter prm53 = new OracleParameter("mantimepost", OracleType.VarChar, 50);
                prm53.Direction = ParameterDirection.Input;
                prm53.Value = mantimepost;
                objOraclecommand.Parameters.Add(prm53);

                 OracleParameter prm54 = new OracleParameter("bkdaypost", OracleType.VarChar, 50);
                prm54.Direction = ParameterDirection.Input;
                prm54.Value = bkdaypost;
                objOraclecommand.Parameters.Add(prm54);

                 OracleParameter prm55 = new OracleParameter("maxterutn", OracleType.VarChar, 50);
                prm55.Direction = ParameterDirection.Input;
                prm55.Value = maxterutn;
                objOraclecommand.Parameters.Add(prm55);

                 OracleParameter prm56 = new OracleParameter("cir_return", OracleType.VarChar, 50);
                prm56.Direction = ParameterDirection.Input;
                prm56.Value = cir_return;
                objOraclecommand.Parameters.Add(prm56);

                 OracleParameter prm57 = new OracleParameter("noofchkbounc", OracleType.VarChar, 50);
                prm57.Direction = ParameterDirection.Input;
                prm57.Value = noofchkbounc;
                objOraclecommand.Parameters.Add(prm57);

                 OracleParameter prm58 = new OracleParameter("noofdaychkrec", OracleType.VarChar, 50);
                prm58.Direction = ParameterDirection.Input;
                prm58.Value = noofdaychkrec;
                objOraclecommand.Parameters.Add(prm58);

                OracleParameter prm59 = new OracleParameter("chngsuppord", OracleType.VarChar, 50);
                prm59.Direction = ParameterDirection.Input;
                prm59.Value = chngsuppord;
                objOraclecommand.Parameters.Add(prm59);

                OracleParameter prm60 = new OracleParameter("max_publishday", OracleType.VarChar, 50);
                prm60.Direction = ParameterDirection.Input;
                prm60.Value = max_publishday;
                objOraclecommand.Parameters.Add(prm60);


                OracleParameter prm61 = new OracleParameter("p_billno_period", OracleType.VarChar, 50);
                prm61.Direction = ParameterDirection.Input;
                prm61.Value = billno_period;
                objOraclecommand.Parameters.Add(prm61); 
                
                 OracleParameter prm62 = new OracleParameter("spl_trans_edit", OracleType.VarChar, 50);
                prm62.Direction = ParameterDirection.Input;
                prm62.Value = spl_trans_edit;
                objOraclecommand.Parameters.Add(prm62);

                 OracleParameter prm63 = new OracleParameter("spl_dis_trans_editable", OracleType.VarChar, 50);
                prm63.Direction = ParameterDirection.Input;
                prm63.Value = spl_dis_trans_editable;
                objOraclecommand.Parameters.Add(prm63);

                 OracleParameter prm64 = new OracleParameter("mul_pac_sel_trans", OracleType.VarChar, 50);
                prm64.Direction = ParameterDirection.Input;
                prm64.Value = mul_pac_sel_trans;
                objOraclecommand.Parameters.Add(prm64);

                OracleParameter prm65 = new OracleParameter("shmon_minword", OracleType.VarChar, 50);
                prm65.Direction = ParameterDirection.Input;
                prm65.Value = shmon_minword;
                objOraclecommand.Parameters.Add(prm65);

                OracleParameter prm66 = new OracleParameter("tradon_spcrg", OracleType.VarChar, 50);
                prm66.Direction = ParameterDirection.Input;
                prm66.Value = tradon_spcrg;
                objOraclecommand.Parameters.Add(prm66);

                OracleParameter prm67 = new OracleParameter("rateauth", OracleType.VarChar, 50);
                prm67.Direction = ParameterDirection.Input;
                prm67.Value = rateauth;
                objOraclecommand.Parameters.Add(prm67);

                OracleParameter prm68 = new OracleParameter("f2day", OracleType.VarChar, 50);
                prm68.Direction = ParameterDirection.Input;
                prm68.Value = f2day;
                objOraclecommand.Parameters.Add(prm68);

                OracleParameter prm69 = new OracleParameter("rateauditmodify", OracleType.VarChar, 50);
                prm69.Direction = ParameterDirection.Input;
                prm69.Value = rateauditmodify;
                objOraclecommand.Parameters.Add(prm69);

                OracleParameter prm70 = new OracleParameter("bindrevenuecenter", OracleType.VarChar, 50);
                prm70.Direction = ParameterDirection.Input;
                prm70.Value = bindrevenuecenter;
                objOraclecommand.Parameters.Add(prm70);


                OracleParameter prm71 = new OracleParameter("p_led_allow", OracleType.VarChar, 50);
                prm71.Direction = ParameterDirection.Input;
                prm71.Value = led_allow;
                objOraclecommand.Parameters.Add(prm71);


                OracleParameter prm72 = new OracleParameter("p_clear_allow", OracleType.VarChar, 50);
                prm72.Direction = ParameterDirection.Input;
                prm72.Value = clear_allow;
                objOraclecommand.Parameters.Add(prm72);



                OracleParameter prm1487a = new OracleParameter("repeatday", OracleType.VarChar, 50);
                prm1487a.Direction = ParameterDirection.Input;
                prm1487a.Value = repeatday;
                objOraclecommand.Parameters.Add(prm1487a);

                OracleParameter prm1488 = new OracleParameter("premiumedit", OracleType.VarChar, 50);
                prm1488.Direction = ParameterDirection.Input;
                prm1488.Value = premiumedit;
                objOraclecommand.Parameters.Add(prm1488);



                OracleParameter prm73 = new OracleParameter("P_BILL_GENERATION", OracleType.VarChar, 50);
                prm73.Direction = ParameterDirection.Input;
                prm73.Value = BILL_GENERATION;
                objOraclecommand.Parameters.Add(prm73);

                OracleParameter prm74 = new OracleParameter("P_PUBLICATION_CENTER", OracleType.VarChar, 50);
                prm74.Direction = ParameterDirection.Input;
                if (PUBLICATION_CENTER == "0")
                {
                    prm74.Value = System.DBNull.Value;
                }
                else
                {
                    prm74.Value = PUBLICATION_CENTER;
                }
                objOraclecommand.Parameters.Add(prm74);



                OracleParameter prm75 = new OracleParameter("P_allow_discount_prem", OracleType.VarChar, 50);
                prm75.Direction = ParameterDirection.Input;
                prm75.Value = allow_discount_prem;
                objOraclecommand.Parameters.Add(prm75);




                  OracleParameter prm76 = new OracleParameter("P_SCHEME_BILLING", OracleType.VarChar, 50);
                  prm76.Direction = ParameterDirection.Input;
                  prm76.Value = scheme_billing;
                  objOraclecommand.Parameters.Add(prm76);




                  OracleParameter prm77 = new OracleParameter("P_ALLOW_PDC", OracleType.VarChar, 50);
                  prm77.Direction = ParameterDirection.Input;
                  prm77.Value = ALLOW_PDC;
                  objOraclecommand.Parameters.Add(prm77);



                  OracleParameter prm78 = new OracleParameter("PAD_TYPE_FOR_MANUL_BILL", OracleType.VarChar, 50);
                  prm78.Direction = ParameterDirection.Input;
                  prm78.Value = ad_type_for_manul_bill;
                  objOraclecommand.Parameters.Add(prm78);



                  OracleParameter prm79 = new OracleParameter("RO_OUTSTAND_P", OracleType.VarChar, 50);
                  prm79.Direction = ParameterDirection.Input;
                  prm79.Value = RO_OUTSTAND_P;
                  objOraclecommand.Parameters.Add(prm79);

                  OracleParameter prm80 = new OracleParameter("genrate_agency_code", OracleType.VarChar, 50);
                  prm80.Direction = ParameterDirection.Input;
                  prm80.Value = genrate_agency_code;
                  objOraclecommand.Parameters.Add(prm80);

                  OracleParameter prm81 = new OracleParameter("p_dispauditbk", OracleType.VarChar, 50);
                  prm81.Direction = ParameterDirection.Input;
                  prm81.Value = dispauditbk;
                  objOraclecommand.Parameters.Add(prm81);


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




        ///////////////////////////////////////////////


        public DataSet datesubmit(string compcode, string userid, string dateformat, string code, string curr, string ratecode, string solo, string breakup, string bwcode, string rostatus, string filename, string tfn, string insertbreak, string prem, string dealtype, string pre, string suff, string chkfinancestatus, string voucherst, string adcode, string rodatetime, string spacearea, string vat, string bookstat, string cio_id, string receipt_no, string uom, string bgcolor, string validdate, string agencyratecode, string audit, string insert_date, string agencycomm, string rateaudit, string billaudit, string billtype, string invoice_no, string copybooking, string ratecomp, string addagencycomm, string agretainercomm, string subrate, string displaybilltype, string classifiedbilltype, string billformat, string ratechk, string allpkg, string dayrate, string schemetype, string Includeclassi, string receiptformat, string cash_receipt, string bill_orderwiselast, string floor_chk, string Unsoldflag, string Supplystopper, string drpRokeychk, string Agencycomm_seq, string creditreciept, string cashindisplay, string cashinclassified, string rate_audit_pref, string barcoding_allow, string fmgbills, string billed_cashdis, string billed_cashcls, string v_drpbackdate, string dockitbooking, string allowprevbooking, string chkval, string cash_billtypea, string approval, string pckstatus, string cash_disc, string cash_amt, string repeatday, string premiumedit, string BILL_GENERATION, string PUBLICATION_CENTER, string allow_discount_prem, string scheme_billing, string ALLOW_PDC, string ad_type_for_manul_bill,string RO_OUTSTAND_P,string genrate_agency_code)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("wesp_submitdate.wesp_submitdate_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm222 = new OracleParameter("billformat", OracleType.VarChar, 50);
                prm222.Direction = ParameterDirection.Input;
                prm222.Value = billformat;
                objOraclecommand.Parameters.Add(prm222);


                OracleParameter prm2221 = new OracleParameter("ratechk", OracleType.VarChar, 50);
                prm2221.Direction = ParameterDirection.Input;
                prm2221.Value = ratechk;
                objOraclecommand.Parameters.Add(prm2221);

                OracleParameter prm2222 = new OracleParameter("allpkg", OracleType.VarChar, 50);
                prm2222.Direction = ParameterDirection.Input;
                prm2222.Value = allpkg;
                objOraclecommand.Parameters.Add(prm2222);


                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("RATECODE11", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = ratecode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("dateformat", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = dateformat;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("code", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = code;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("curr", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = curr;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("solo", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = solo;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("breakup", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = breakup;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("bwcode", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = bwcode;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("rostatus", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = rostatus;
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("filename", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = filename;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("tfn", OracleType.VarChar, 50);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = tfn;
                objOraclecommand.Parameters.Add(prm12);

                OracleParameter prm13 = new OracleParameter("insertbreak", OracleType.VarChar, 50);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = insertbreak;
                objOraclecommand.Parameters.Add(prm13);

                OracleParameter prm14 = new OracleParameter("prem", OracleType.VarChar, 50);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = prem;
                objOraclecommand.Parameters.Add(prm14);

                OracleParameter prm15 = new OracleParameter("dealtype", OracleType.VarChar, 50);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = dealtype;
                objOraclecommand.Parameters.Add(prm15);

                OracleParameter prm16 = new OracleParameter("pre", OracleType.VarChar, 50);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = pre;
                objOraclecommand.Parameters.Add(prm16);

                OracleParameter prm17 = new OracleParameter("suff", OracleType.VarChar, 50);
                prm17.Direction = ParameterDirection.Input;
                prm17.Value = suff;
                objOraclecommand.Parameters.Add(prm17);


                OracleParameter prm18 = new OracleParameter("financestatus", OracleType.VarChar, 50);
                prm18.Direction = ParameterDirection.Input;
                prm18.Value = chkfinancestatus;
                objOraclecommand.Parameters.Add(prm18);

                OracleParameter prm19 = new OracleParameter("voucherst", OracleType.VarChar, 50);
                prm19.Direction = ParameterDirection.Input;
                prm19.Value = voucherst;
                objOraclecommand.Parameters.Add(prm19);


                OracleParameter prm20 = new OracleParameter("adcode", OracleType.VarChar, 50);
                prm20.Direction = ParameterDirection.Input;
                prm20.Value = adcode;
                objOraclecommand.Parameters.Add(prm20);

                OracleParameter prm21 = new OracleParameter("rodatetime", OracleType.VarChar, 50);
                prm21.Direction = ParameterDirection.Input;
                prm21.Value = rodatetime;
                objOraclecommand.Parameters.Add(prm21);


                OracleParameter prm23 = new OracleParameter("spacearea", OracleType.VarChar, 50);
                prm23.Direction = ParameterDirection.Input;
                prm23.Value = spacearea;
                objOraclecommand.Parameters.Add(prm23);

                OracleParameter prm24 = new OracleParameter("vat", OracleType.VarChar, 50);
                prm24.Direction = ParameterDirection.Input;
                prm24.Value = vat;
                objOraclecommand.Parameters.Add(prm24);


                OracleParameter prm25 = new OracleParameter("bookstat", OracleType.VarChar, 50);
                prm25.Direction = ParameterDirection.Input;
                prm25.Value = bookstat;
                objOraclecommand.Parameters.Add(prm25);

                OracleParameter prm26 = new OracleParameter("cio_id", OracleType.VarChar, 50);
                prm26.Direction = ParameterDirection.Input;
                prm26.Value = cio_id;
                objOraclecommand.Parameters.Add(prm26);

                OracleParameter prm27 = new OracleParameter("receipt_no", OracleType.VarChar, 50);
                prm27.Direction = ParameterDirection.Input;
                prm27.Value = receipt_no;
                objOraclecommand.Parameters.Add(prm27);

                /*new change ankur*/
                OracleParameter prm28 = new OracleParameter("uom", OracleType.VarChar, 50);
                prm28.Direction = ParameterDirection.Input;
                prm28.Value = uom;
                objOraclecommand.Parameters.Add(prm28);


                OracleParameter prm29 = new OracleParameter("bgcolor", OracleType.VarChar, 50);
                prm29.Direction = ParameterDirection.Input;
                prm29.Value = bgcolor;
                objOraclecommand.Parameters.Add(prm29);


                OracleParameter prm30 = new OracleParameter("validdate", OracleType.VarChar, 50);
                prm30.Direction = ParameterDirection.Input;
                prm30.Value = validdate;
                objOraclecommand.Parameters.Add(prm30);



                OracleParameter prm31 = new OracleParameter("agencyratecode", OracleType.VarChar, 50);
                prm31.Direction = ParameterDirection.Input;
                prm31.Value = agencyratecode;
                objOraclecommand.Parameters.Add(prm31);


                OracleParameter prm32 = new OracleParameter("audit", OracleType.VarChar, 50);
                prm32.Direction = ParameterDirection.Input;
                prm32.Value = audit;
                objOraclecommand.Parameters.Add(prm32);

                OracleParameter prm33 = new OracleParameter("book_insert_date", OracleType.VarChar, 50);
                prm33.Direction = ParameterDirection.Input;
                prm33.Value = insert_date;
                objOraclecommand.Parameters.Add(prm33);

                OracleParameter prm34 = new OracleParameter("agencycomm", OracleType.VarChar, 50);
                prm34.Direction = ParameterDirection.Input;
                prm34.Value = agencycomm;
                objOraclecommand.Parameters.Add(prm34);

                OracleParameter prm35 = new OracleParameter("rateaudit", OracleType.VarChar, 50);
                prm35.Direction = ParameterDirection.Input;
                prm35.Value = rateaudit;
                objOraclecommand.Parameters.Add(prm35);

                OracleParameter prm36 = new OracleParameter("billaudit", OracleType.VarChar, 50);
                prm36.Direction = ParameterDirection.Input;
                prm36.Value = billaudit;
                objOraclecommand.Parameters.Add(prm36);

                OracleParameter prm37 = new OracleParameter("bill_type", OracleType.VarChar, 50);
                prm37.Direction = ParameterDirection.Input;
                prm37.Value = billtype;
                objOraclecommand.Parameters.Add(prm37);


                OracleParameter prm38 = new OracleParameter("invoice_no1", OracleType.VarChar, 50);
                prm38.Direction = ParameterDirection.Input;
                prm38.Value = invoice_no;
                objOraclecommand.Parameters.Add(prm38);

                OracleParameter prm39 = new OracleParameter("copybooking", OracleType.VarChar, 50);
                prm39.Direction = ParameterDirection.Input;
                prm39.Value = copybooking;
                objOraclecommand.Parameters.Add(prm39);

                OracleParameter prm40 = new OracleParameter("ratecompagnecy", OracleType.VarChar, 50);
                prm40.Direction = ParameterDirection.Input;
                prm40.Value = ratecomp;
                objOraclecommand.Parameters.Add(prm40);

                OracleParameter prm41 = new OracleParameter("addagenycomm", OracleType.VarChar, 50);
                prm41.Direction = ParameterDirection.Input;
                prm41.Value = addagencycomm;
                objOraclecommand.Parameters.Add(prm41);

                OracleParameter prm42 = new OracleParameter("agencycommlinkretainer", OracleType.VarChar, 50);
                prm42.Direction = ParameterDirection.Input;
                prm42.Value = agretainercomm;
                objOraclecommand.Parameters.Add(prm42);

                OracleParameter prm43 = new OracleParameter("subeditionr", OracleType.VarChar, 50);
                prm43.Direction = ParameterDirection.Input;
                prm43.Value = subrate;
                objOraclecommand.Parameters.Add(prm43);


                OracleParameter prm44 = new OracleParameter("displaybilltype", OracleType.VarChar, 50);
                prm44.Direction = ParameterDirection.Input;
                prm44.Value = displaybilltype;
                objOraclecommand.Parameters.Add(prm44);

                OracleParameter prm45 = new OracleParameter("classifiedbilltype", OracleType.VarChar, 50);
                prm45.Direction = ParameterDirection.Input;
                prm45.Value = classifiedbilltype;
                objOraclecommand.Parameters.Add(prm45);

                OracleParameter prm459 = new OracleParameter("dayrate1", OracleType.VarChar, 10);
                prm459.Direction = ParameterDirection.Input;
                prm459.Value = dayrate;
                objOraclecommand.Parameters.Add(prm459);

                OracleParameter prm460 = new OracleParameter("schemetype", OracleType.VarChar, 10);
                prm460.Direction = ParameterDirection.Input;
                prm460.Value = schemetype;
                objOraclecommand.Parameters.Add(prm460);

                OracleParameter prm461 = new OracleParameter("PIncludeclassi", OracleType.VarChar, 50);
                prm461.Direction = ParameterDirection.Input;
                prm461.Value = Includeclassi;
                objOraclecommand.Parameters.Add(prm461);


                OracleParameter prm462 = new OracleParameter("receiptformat", OracleType.VarChar, 50);
                prm462.Direction = ParameterDirection.Input;
                prm462.Value = receiptformat;
                objOraclecommand.Parameters.Add(prm462);



                OracleParameter prm463 = new OracleParameter("v_cash_receipt", OracleType.VarChar, 50);
                prm463.Direction = ParameterDirection.Input;
                prm463.Value = cash_receipt;
                objOraclecommand.Parameters.Add(prm463);




                OracleParameter prm464 = new OracleParameter("v_bill_orderwiselast", OracleType.VarChar, 50);
                prm464.Direction = ParameterDirection.Input;
                prm464.Value = bill_orderwiselast;
                objOraclecommand.Parameters.Add(prm464);

                OracleParameter prm465 = new OracleParameter("v_floor_chk", OracleType.VarChar, 50);
                prm465.Direction = ParameterDirection.Input;
                prm465.Value = floor_chk;
                objOraclecommand.Parameters.Add(prm465);

                //for circulation
                OracleParameter prm1466 = new OracleParameter("Unsoldflag", OracleType.VarChar, 50);
                prm1466.Direction = ParameterDirection.Input;
                prm1466.Value = Unsoldflag;
                objOraclecommand.Parameters.Add(prm1466);

                OracleParameter prm1467 = new OracleParameter("Supplystopper", OracleType.VarChar, 50);
                prm1467.Direction = ParameterDirection.Input;
                prm1467.Value = Supplystopper;
                objOraclecommand.Parameters.Add(prm1467);

                OracleParameter prm1468 = new OracleParameter("drpRokeychk", OracleType.VarChar, 50);
                prm1468.Direction = ParameterDirection.Input;
                prm1468.Value = drpRokeychk;
                objOraclecommand.Parameters.Add(prm1468);

                OracleParameter prm1469 = new OracleParameter("Agencycomm_seq", OracleType.VarChar, 50);
                prm1469.Direction = ParameterDirection.Input;
                prm1469.Value = Agencycomm_seq;
                objOraclecommand.Parameters.Add(prm1469);

                OracleParameter prm1470 = new OracleParameter("creditreciept", OracleType.VarChar, 50);
                prm1470.Direction = ParameterDirection.Input;
                prm1470.Value = creditreciept;
                objOraclecommand.Parameters.Add(prm1470);

                OracleParameter prm1471 = new OracleParameter("cashindisplay", OracleType.VarChar, 50);
                prm1471.Direction = ParameterDirection.Input;
                prm1471.Value = cashindisplay;
                objOraclecommand.Parameters.Add(prm1471);

                OracleParameter prm1472 = new OracleParameter("cashinclassified", OracleType.VarChar, 50);
                prm1472.Direction = ParameterDirection.Input;
                prm1472.Value = cashinclassified;
                objOraclecommand.Parameters.Add(prm1472);

                OracleParameter prm1473 = new OracleParameter("v_rate_audit_pref", OracleType.VarChar, 50);
                prm1473.Direction = ParameterDirection.Input;
                prm1473.Value = rate_audit_pref;
                objOraclecommand.Parameters.Add(prm1473);



                OracleParameter prm1474 = new OracleParameter("v_barcoding_allow_pref", OracleType.VarChar, 50);
                prm1474.Direction = ParameterDirection.Input;
                prm1474.Value = barcoding_allow;
                objOraclecommand.Parameters.Add(prm1474);


                OracleParameter prm1475 = new OracleParameter("v_fmgbills", OracleType.VarChar, 50);
                prm1475.Direction = ParameterDirection.Input;
                prm1475.Value = fmgbills;
                objOraclecommand.Parameters.Add(prm1475);




                OracleParameter prm1476 = new OracleParameter("v_billed_cashdis", OracleType.VarChar, 50);
                prm1476.Direction = ParameterDirection.Input;
                prm1476.Value = billed_cashdis;
                objOraclecommand.Parameters.Add(prm1476);


                OracleParameter prm1477 = new OracleParameter("v_billed_cashcls", OracleType.VarChar, 50);
                prm1477.Direction = ParameterDirection.Input;
                prm1477.Value = billed_cashcls;
                objOraclecommand.Parameters.Add(prm1477);



                OracleParameter prm1478 = new OracleParameter("v_drpbackdate", OracleType.VarChar, 50);
                prm1478.Direction = ParameterDirection.Input;
                prm1478.Value = v_drpbackdate;
                objOraclecommand.Parameters.Add(prm1478);

                OracleParameter prm1479 = new OracleParameter("dockitbooking", OracleType.VarChar, 50);
                prm1479.Direction = ParameterDirection.Input;
                prm1479.Value = dockitbooking;
                objOraclecommand.Parameters.Add(prm1479);

                OracleParameter prm1480 = new OracleParameter("allowprevbooking", OracleType.VarChar, 50);
                prm1480.Direction = ParameterDirection.Input;
                prm1480.Value = allowprevbooking;
                objOraclecommand.Parameters.Add(prm1480);

                OracleParameter prm1481 = new OracleParameter("chkval", OracleType.VarChar, 50);
                prm1481.Direction = ParameterDirection.Input;
                prm1481.Value = chkval;
                objOraclecommand.Parameters.Add(prm1481);

                OracleParameter prm1482 = new OracleParameter("ro_wisecashbill", OracleType.VarChar, 50);
                prm1482.Direction = ParameterDirection.Input;
                prm1482.Value = cash_billtypea;
                objOraclecommand.Parameters.Add(prm1482);


                OracleParameter prm1483 = new OracleParameter("approval1", OracleType.VarChar, 50);
                prm1483.Direction = ParameterDirection.Input;
                prm1483.Value = approval;
                objOraclecommand.Parameters.Add(prm1483);

                OracleParameter prm1484 = new OracleParameter("pckstatus", OracleType.VarChar, 50);
                prm1484.Direction = ParameterDirection.Input;
                prm1484.Value = pckstatus;
                objOraclecommand.Parameters.Add(prm1484);

                OracleParameter prm1485 = new OracleParameter("cash_disc", OracleType.VarChar, 50);
                prm1485.Direction = ParameterDirection.Input;
                prm1485.Value = cash_disc;
                objOraclecommand.Parameters.Add(prm1485);

                OracleParameter prm1486 = new OracleParameter("cash_amt", OracleType.VarChar, 50);
                prm1486.Direction = ParameterDirection.Input;
                prm1486.Value = cash_amt;
                objOraclecommand.Parameters.Add(prm1486);


                OracleParameter prm1487 = new OracleParameter("repeatday", OracleType.VarChar, 50);
                prm1487.Direction = ParameterDirection.Input;
                prm1487.Value = repeatday;
                objOraclecommand.Parameters.Add(prm1487);

                OracleParameter prm1488 = new OracleParameter("premiumedit", OracleType.VarChar, 50);
                prm1488.Direction = ParameterDirection.Input;
                prm1488.Value = premiumedit;
                objOraclecommand.Parameters.Add(prm1488);


                OracleParameter prm73 = new OracleParameter("P_BILL_GENERATION", OracleType.VarChar, 50);
                prm73.Direction = ParameterDirection.Input;
                prm73.Value = BILL_GENERATION;
                objOraclecommand.Parameters.Add(prm73);

                OracleParameter prm74 = new OracleParameter("P_PUBLICATION_CENTER", OracleType.VarChar, 50);
                prm74.Direction = ParameterDirection.Input;
                prm74.Value = PUBLICATION_CENTER;
                objOraclecommand.Parameters.Add(prm74);


                OracleParameter prm75 = new OracleParameter("P_allow_discount_prem", OracleType.VarChar, 50);
                prm75.Direction = ParameterDirection.Input;
                prm75.Value = allow_discount_prem;
                objOraclecommand.Parameters.Add(prm75);


                 OracleParameter prm76 = new OracleParameter("P_SCHEME_BILLING", OracleType.VarChar, 50);
                prm76.Direction = ParameterDirection.Input;
                prm76.Value = scheme_billing;
                objOraclecommand.Parameters.Add(prm76);


                OracleParameter prm77 = new OracleParameter("P_ALLOW_PDC", OracleType.VarChar, 50);
                prm77.Direction = ParameterDirection.Input;
                prm77.Value = ALLOW_PDC;
                objOraclecommand.Parameters.Add(prm77);



                OracleParameter prm78 = new OracleParameter("P_TYPE_FOR_MANUL_BILL", OracleType.VarChar, 50);
                prm78.Direction = ParameterDirection.Input;
                prm78.Value = ad_type_for_manul_bill;
                objOraclecommand.Parameters.Add(prm78);



                OracleParameter prm79 = new OracleParameter("RO_OUTSTAND_P", OracleType.VarChar, 50);
                prm79.Direction = ParameterDirection.Input;
                prm79.Value = RO_OUTSTAND_P;
                objOraclecommand.Parameters.Add(prm79);

                OracleParameter prm80 = new OracleParameter("genrate_agency_code", OracleType.VarChar, 50);
                prm80.Direction = ParameterDirection.Input;
                prm80.Value = genrate_agency_code;
                objOraclecommand.Parameters.Add(prm80);

             

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






        //public DataSet datesubmit(string compcode, string userid, string dateformat, string code, string curr, string ratecode, string solo, string breakup, string bwcode, string rostatus, string filename, string tfn, string insertbreak, string prem, string dealtype, string pre, string suff, string chkfinancestatus, string voucherst, string adcode, string rodatetime, string spacearea, string vat, string bookstat, string cio_id, string receipt_no, string uom, string bgcolor, string validdate, string agencyratecode, string audit, string insert_date, string agencycomm, string rateaudit, string billaudit, string billtype,string dayrate)
        //{
        //    OracleConnection objOracleConnection;
        //    OracleCommand objOraclecommand;
        //    DataSet objDataSet = new DataSet();
        //    objOracleConnection = GetConnection();
        //    OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        //    try
        //    {
        //        objOracleConnection.Open();
        //        objOraclecommand = GetCommand("wesp_submitdate.wesp_submitdate_p", ref objOracleConnection);
        //        objOraclecommand.CommandType = CommandType.StoredProcedure;

        //        OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
        //        prm1.Direction = ParameterDirection.Input;
        //        prm1.Value = compcode;
        //        objOraclecommand.Parameters.Add(prm1);

        //        OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
        //        prm2.Direction = ParameterDirection.Input;
        //        prm2.Value = userid;
        //        objOraclecommand.Parameters.Add(prm2);

        //        OracleParameter prm3 = new OracleParameter("ratecode", OracleType.VarChar, 50);
        //        prm3.Direction = ParameterDirection.Input;
        //        prm3.Value = ratecode;
        //        objOraclecommand.Parameters.Add(prm3);

        //        OracleParameter prm4 = new OracleParameter("dateformat", OracleType.VarChar, 50);
        //        prm4.Direction = ParameterDirection.Input;
        //        prm4.Value = dateformat;
        //        objOraclecommand.Parameters.Add(prm4);

        //        OracleParameter prm5 = new OracleParameter("code", OracleType.VarChar, 50);
        //        prm5.Direction = ParameterDirection.Input;
        //        prm5.Value = code;
        //        objOraclecommand.Parameters.Add(prm5);

        //        OracleParameter prm6 = new OracleParameter("curr", OracleType.VarChar, 50);
        //        prm6.Direction = ParameterDirection.Input;
        //        prm6.Value = curr;
        //        objOraclecommand.Parameters.Add(prm6);

        //        OracleParameter prm7 = new OracleParameter("solo", OracleType.VarChar, 50);
        //        prm7.Direction = ParameterDirection.Input;
        //        prm7.Value = solo;
        //        objOraclecommand.Parameters.Add(prm7);

        //        OracleParameter prm8 = new OracleParameter("breakup", OracleType.VarChar, 50);
        //        prm8.Direction = ParameterDirection.Input;
        //        prm8.Value = breakup;
        //        objOraclecommand.Parameters.Add(prm8);

        //        OracleParameter prm9 = new OracleParameter("bwcode", OracleType.VarChar, 50);
        //        prm9.Direction = ParameterDirection.Input;
        //        prm9.Value = bwcode;
        //        objOraclecommand.Parameters.Add(prm9);

        //        OracleParameter prm10 = new OracleParameter("rostatus", OracleType.VarChar, 50);
        //        prm10.Direction = ParameterDirection.Input;
        //        prm10.Value = rostatus;
        //        objOraclecommand.Parameters.Add(prm10);

        //        OracleParameter prm11 = new OracleParameter("filename", OracleType.VarChar, 50);
        //        prm11.Direction = ParameterDirection.Input;
        //        prm11.Value = filename;
        //        objOraclecommand.Parameters.Add(prm11);

        //        OracleParameter prm12 = new OracleParameter("tfn", OracleType.VarChar, 50);
        //        prm12.Direction = ParameterDirection.Input;
        //        prm12.Value = tfn;
        //        objOraclecommand.Parameters.Add(prm12);

        //        OracleParameter prm13 = new OracleParameter("insertbreak", OracleType.VarChar, 50);
        //        prm13.Direction = ParameterDirection.Input;
        //        prm13.Value = insertbreak;
        //        objOraclecommand.Parameters.Add(prm13);

        //        OracleParameter prm14 = new OracleParameter("prem", OracleType.VarChar, 50);
        //        prm14.Direction = ParameterDirection.Input;
        //        prm14.Value = prem;
        //        objOraclecommand.Parameters.Add(prm14);

        //        OracleParameter prm15 = new OracleParameter("dealtype", OracleType.VarChar, 50);
        //        prm15.Direction = ParameterDirection.Input;
        //        prm15.Value = dealtype;
        //        objOraclecommand.Parameters.Add(prm15);

        //        OracleParameter prm16 = new OracleParameter("pre", OracleType.VarChar, 50);
        //        prm16.Direction = ParameterDirection.Input;
        //        prm16.Value = pre;
        //        objOraclecommand.Parameters.Add(prm16);

        //        OracleParameter prm17 = new OracleParameter("suff", OracleType.VarChar, 50);
        //        prm17.Direction = ParameterDirection.Input;
        //        prm17.Value = suff;
        //        objOraclecommand.Parameters.Add(prm17);


        //        OracleParameter prm18 = new OracleParameter("financestatus", OracleType.VarChar, 50);
        //        prm18.Direction = ParameterDirection.Input;
        //        prm18.Value = chkfinancestatus;
        //        objOraclecommand.Parameters.Add(prm18);

        //        OracleParameter prm19 = new OracleParameter("voucherst", OracleType.VarChar, 50);
        //        prm19.Direction = ParameterDirection.Input;
        //        prm19.Value = voucherst;
        //        objOraclecommand.Parameters.Add(prm19);


        //        OracleParameter prm20 = new OracleParameter("adcode", OracleType.VarChar, 50);
        //        prm20.Direction = ParameterDirection.Input;
        //        prm20.Value = adcode;
        //        objOraclecommand.Parameters.Add(prm20);

        //        OracleParameter prm21 = new OracleParameter("rodatetime", OracleType.VarChar, 50);
        //        prm21.Direction = ParameterDirection.Input;
        //        prm21.Value = rodatetime;
        //        objOraclecommand.Parameters.Add(prm21);


        //        OracleParameter prm23 = new OracleParameter("spacearea", OracleType.VarChar, 50);
        //        prm23.Direction = ParameterDirection.Input;
        //        prm23.Value = spacearea;
        //        objOraclecommand.Parameters.Add(prm23);

        //        OracleParameter prm24 = new OracleParameter("vat", OracleType.VarChar, 50);
        //        prm24.Direction = ParameterDirection.Input;
        //        prm24.Value = vat;
        //        objOraclecommand.Parameters.Add(prm24);


        //        OracleParameter prm25 = new OracleParameter("bookstat", OracleType.VarChar, 50);
        //        prm25.Direction = ParameterDirection.Input;
        //        prm25.Value = bookstat;
        //        objOraclecommand.Parameters.Add(prm25);

        //        OracleParameter prm26 = new OracleParameter("cio_id", OracleType.VarChar, 50);
        //        prm26.Direction = ParameterDirection.Input;
        //        prm26.Value = cio_id;
        //        objOraclecommand.Parameters.Add(prm26);

        //        OracleParameter prm27 = new OracleParameter("receipt_no", OracleType.VarChar, 50);
        //        prm27.Direction = ParameterDirection.Input;
        //        prm27.Value = receipt_no;
        //        objOraclecommand.Parameters.Add(prm27);

        //        /*new change ankur*/
        //        OracleParameter prm28 = new OracleParameter("uom", OracleType.VarChar, 50);
        //        prm28.Direction = ParameterDirection.Input;
        //        prm28.Value = uom;
        //        objOraclecommand.Parameters.Add(prm28);


        //        OracleParameter prm29 = new OracleParameter("bgcolor", OracleType.VarChar, 50);
        //        prm29.Direction = ParameterDirection.Input;
        //        prm29.Value = bgcolor;
        //        objOraclecommand.Parameters.Add(prm29);


        //        OracleParameter prm30 = new OracleParameter("validdate", OracleType.VarChar, 50);
        //        prm30.Direction = ParameterDirection.Input;
        //        prm30.Value = validdate;
        //        objOraclecommand.Parameters.Add(prm30);



        //        OracleParameter prm31 = new OracleParameter("agencyratecode", OracleType.VarChar, 50);
        //        prm31.Direction = ParameterDirection.Input;
        //        prm31.Value = agencyratecode;
        //        objOraclecommand.Parameters.Add(prm31);


        //        OracleParameter prm32 = new OracleParameter("audit", OracleType.VarChar, 50);
        //        prm32.Direction = ParameterDirection.Input;
        //        prm32.Value = audit;
        //        objOraclecommand.Parameters.Add(prm32);

        //        OracleParameter prm33 = new OracleParameter("book_insert_date", OracleType.VarChar, 50);
        //        prm33.Direction = ParameterDirection.Input;
        //        prm33.Value = insert_date;
        //        objOraclecommand.Parameters.Add(prm33);

        //        OracleParameter prm34 = new OracleParameter("agencycomm", OracleType.VarChar, 50);
        //        prm34.Direction = ParameterDirection.Input;
        //        prm34.Value = agencycomm;
        //        objOraclecommand.Parameters.Add(prm34);

        //        OracleParameter prm35 = new OracleParameter("rateaudit", OracleType.VarChar, 50);
        //        prm35.Direction = ParameterDirection.Input;
        //        prm35.Value = rateaudit;
        //        objOraclecommand.Parameters.Add(prm35);

        //        OracleParameter prm36 = new OracleParameter("billaudit", OracleType.VarChar, 50);
        //        prm36.Direction = ParameterDirection.Input;
        //        prm36.Value = billaudit;
        //        objOraclecommand.Parameters.Add(prm36);

        //        OracleParameter prm37 = new OracleParameter("bill_type", OracleType.VarChar, 50);
        //        prm37.Direction = ParameterDirection.Input;
        //        prm37.Value = billtype;
        //        objOraclecommand.Parameters.Add(prm37);

        //        OracleParameter prm379 = new OracleParameter("dayrate1", OracleType.VarChar, 10);
        //        prm379.Direction = ParameterDirection.Input;
        //        prm379.Value = dayrate;
        //        objOraclecommand.Parameters.Add(prm379);

        //        objorclDataAdapter.SelectCommand = objOraclecommand;
        //        objorclDataAdapter.Fill(objDataSet);
        //        return objDataSet;

        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //    finally
        //    {
        //        CloseConnection(ref objOracleConnection);
        //    }

        //}

        //********************************To check whether entry for company code exist*****************

        public DataSet datechkprefer(string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("wesp_chkdateprefer.wesp_chkdateprefer_p", ref objOracleConnection);
               objOraclecommand.CommandType = CommandType.StoredProcedure;

               OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
               prm1.Direction = ParameterDirection.Input;
               prm1.Value = compcode;
               objOraclecommand.Parameters.Add(prm1);

               objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
               objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;


                objorclDataAdapter.SelectCommand =objOraclecommand;
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



        public DataSet currbind(string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("currbindprefer.currbindprefer_p", ref objOracleConnection);
               objOraclecommand.CommandType = CommandType.StoredProcedure;



               objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
               objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand =objOraclecommand;
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
        public DataSet ratebindprefer(string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
               objOracleConnection.Open();
               objOraclecommand = GetCommand("bindrateforprefer.bindrateforprefer_p", ref objOracleConnection);
               objOraclecommand.CommandType = CommandType.StoredProcedure;

               OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
               prm1.Direction = ParameterDirection.Input;
               prm1.Value = compcode;
               objOraclecommand.Parameters.Add(prm1);

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


        public DataSet currbindpgld(string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("currbindpreferpgld.currbindpreferpgld_p", ref objOracleConnection);
               objOraclecommand.CommandType = CommandType.StoredProcedure;

               OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
               prm1.Direction = ParameterDirection.Input;
               prm1.Value = compcode;
               objOraclecommand.Parameters.Add(prm1);


               objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
               objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;



                objorclDataAdapter.SelectCommand =objOraclecommand;
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

        //GetData is used to retrieve the custcode from customer master
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

        public DataSet chkData(string clientcode, string userid, string compcode, int flag)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
               objOracleConnection.Open();
               objOraclecommand = GetCommand("Clientchkpaymode.Clientchkpaymode_p", ref objOracleConnection);
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

               OracleParameter prm4 = new OracleParameter("flag", OracleType.VarChar, 50);
               prm4.Direction = ParameterDirection.Input;
               prm4.Value = flag;
               objOraclecommand.Parameters.Add(prm4);

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

        //insert Data is used to insert/update values into payment table

        public void insertData(string compcode, string custcode, string userid, int i, params string[] strMode)
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
               prm1.Value = strMode[0];
               objOraclecommand.Parameters.Add(prm1);


               OracleParameter prm2 = new OracleParameter("Credit", OracleType.VarChar, 50);
               prm2.Direction = ParameterDirection.Input;
               prm2.Value = strMode[1];
               objOraclecommand.Parameters.Add(prm2);

               OracleParameter prm3= new OracleParameter("Bank", OracleType.VarChar, 50);
               prm3.Direction = ParameterDirection.Input;
               prm3.Value = strMode[2];
               objOraclecommand.Parameters.Add(prm3);


               OracleParameter prm4 = new OracleParameter("Comp_Code", OracleType.VarChar, 50);
               prm4.Direction = ParameterDirection.Input;
               prm4.Value = compcode;
               objOraclecommand.Parameters.Add(prm4);

               OracleParameter prm5 = new OracleParameter("Client_Code", OracleType.VarChar, 50);
               prm5.Direction = ParameterDirection.Input;
               prm5.Value = custcode;
               objOraclecommand.Parameters.Add(prm5);


               OracleParameter prm6= new OracleParameter("userid", OracleType.VarChar, 50);
               prm6.Direction = ParameterDirection.Input;
               prm6.Value = userid;
               objOraclecommand.Parameters.Add(prm6);

               OracleParameter prm7 = new OracleParameter("Flag", OracleType.VarChar, 50);
               prm7.Direction = ParameterDirection.Input;
               prm7.Value = i;
               objOraclecommand.Parameters.Add(prm7);

               objorclDataAdapter.SelectCommand = objOraclecommand;
               objorclDataAdapter.Fill(objDataSet);

               
            }
            catch (Exception ex) { throw (ex); }
            finally
            { CloseConnection(ref objOracleConnection); }
        }

        public DataSet collectadvtype(string compcode, string userid, string date)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
               objOracleConnection.Open();
               objOraclecommand = GetCommand("bindadtypeforstatus.bindadtypeforstatus_p", ref objOracleConnection);
               objOraclecommand.CommandType = CommandType.StoredProcedure;


               OracleParameter prm4 = new OracleParameter("Comp_Code", OracleType.VarChar, 50);
               prm4.Direction = ParameterDirection.Input;
               prm4.Value = compcode;
               objOraclecommand.Parameters.Add(prm4);

               OracleParameter prm6 = new OracleParameter("userid", OracleType.VarChar, 50);
               prm6.Direction = ParameterDirection.Input;
               prm6.Value = userid;
               objOraclecommand.Parameters.Add(prm6);

               OracleParameter prm7 = new OracleParameter("date1", OracleType.VarChar, 50);
               prm7.Direction = ParameterDirection.Input;
               prm7.Value = date;
               objOraclecommand.Parameters.Add(prm7);

               objOraclecommand.Parameters.Add("P_ACCOUNT", OracleType.Cursor);
               objOraclecommand.Parameters["P_ACCOUNT"].Direction = ParameterDirection.Output;

               objorclDataAdapter.SelectCommand = objOraclecommand;
               objorclDataAdapter.Fill(objDataSet);

               return objDataSet;
            }
            catch (Exception ex) { throw (ex); }
            finally
            { CloseConnection(ref objOracleConnection); }

        }




        //public DataSet insertpay(string agencycode, string compcode, string userid, string agencysubcode, params string[] strMode)
        public DataSet insertpay(string agencycode, string compcode, string userid, string agencysubcode, string cash)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOraclecommand = GetCommand("websp_insertpay.websp_insertpay_p", ref objOracleConnection);
               objOraclecommand.CommandType = CommandType.StoredProcedure;

               OracleParameter prm1 = new OracleParameter("Cash", OracleType.VarChar, 50);
               prm1.Direction = ParameterDirection.Input;
               prm1.Value = cash;
               objOraclecommand.Parameters.Add(prm1);

               OracleParameter prm4 = new OracleParameter("Comp_Code", OracleType.VarChar, 50);
               prm4.Direction = ParameterDirection.Input;
               prm4.Value = compcode;
               objOraclecommand.Parameters.Add(prm4);

               OracleParameter prm7 = new OracleParameter("Agency_Code", OracleType.VarChar, 50);
               prm7.Direction = ParameterDirection.Input;
               prm7.Value = agencycode;
               objOraclecommand.Parameters.Add(prm7);

               OracleParameter prm6 = new OracleParameter("userid", OracleType.VarChar, 50);
               prm6.Direction = ParameterDirection.Input;
               prm6.Value = userid;
               objOraclecommand.Parameters.Add(prm6);

               OracleParameter prm9 = new OracleParameter("Agency_subcat_code", OracleType.VarChar, 50);
               prm9.Direction = ParameterDirection.Input;
               prm9.Value = agencysubcode;
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

        //************to update agent paymode****************************8
        public DataSet payinsert(string agencycode, string compcode, string userid, string agencysubcode, string code)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();

                objOraclecommand = GetCommand("websp_updatepay.websp_updatepay_p", ref objOracleConnection);
               objOraclecommand.CommandType = CommandType.StoredProcedure;

               OracleParameter prm1 = new OracleParameter("code", OracleType.VarChar, 50);
               prm1.Direction = ParameterDirection.Input;
               prm1.Value = code;
               objOraclecommand.Parameters.Add(prm1);

               OracleParameter prm4 = new OracleParameter("Comp_Code", OracleType.VarChar, 50);
               prm4.Direction = ParameterDirection.Input;
               prm4.Value = compcode;
               objOraclecommand.Parameters.Add(prm4);

               OracleParameter prm7 = new OracleParameter("Agency_Code", OracleType.VarChar, 50);
               prm7.Direction = ParameterDirection.Input;
               prm7.Value = agencycode;
               objOraclecommand.Parameters.Add(prm7);

               OracleParameter prm6 = new OracleParameter("userid", OracleType.VarChar, 50);
               prm6.Direction = ParameterDirection.Input;
               prm6.Value = userid;
               objOraclecommand.Parameters.Add(prm6);

               OracleParameter prm8 = new OracleParameter("Agency_subcat_code", OracleType.VarChar, 50);
               prm8.Direction = ParameterDirection.Input;
               prm8.Value = agencysubcode;
               objOraclecommand.Parameters.Add(prm8);


                objorclDataAdapter.SelectCommand =objOraclecommand;
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


        public DataSet getpay(string agencycode, string compcode, string userid, string agencysubcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
               objOracleConnection.Open();
               objOraclecommand = GetCommand("agentpayselect.agentpayselect_p", ref objOracleConnection);
               objOraclecommand.CommandType = CommandType.StoredProcedure;

               OracleParameter prm6 = new OracleParameter("userid", OracleType.VarChar, 50);
               prm6.Direction = ParameterDirection.Input;
               prm6.Value = userid;
               objOraclecommand.Parameters.Add(prm6);

               OracleParameter prm1 = new OracleParameter("agencycode", OracleType.VarChar, 50);
               prm1.Direction = ParameterDirection.Input;
               prm1.Value = agencycode;
               objOraclecommand.Parameters.Add(prm1);
          

                
               OracleParameter prm7 = new OracleParameter("agencysubcode", OracleType.VarChar, 50);
               prm7.Direction = ParameterDirection.Input;
               prm7.Value = agencysubcode;
               objOraclecommand.Parameters.Add(prm7);

               OracleParameter prm4 = new OracleParameter("compcode", OracleType.VarChar, 50);
               prm4.Direction = ParameterDirection.Input;
               prm4.Value = compcode;
               objOraclecommand.Parameters.Add(prm4);

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

        public DataSet productbind12(string compcode, string userid, string clientcode, string agencycode, string agencysubcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
               objOracleConnection.Open();
               objOraclecommand = GetCommand("contactproduct.contactproduct_p", ref objOracleConnection);
               objOraclecommand.CommandType = CommandType.StoredProcedure;


               OracleParameter prm4 = new OracleParameter("compcode", OracleType.VarChar, 50);
               prm4.Direction = ParameterDirection.Input;
               prm4.Value = compcode;
               objOraclecommand.Parameters.Add(prm4);

                       OracleParameter prm1 = new OracleParameter("clientcode", OracleType.VarChar, 50);
               prm1.Direction = ParameterDirection.Input;
               prm1.Value = clientcode;
               objOraclecommand.Parameters.Add(prm1);


               OracleParameter prm5 = new OracleParameter("userid", OracleType.VarChar, 50);
               prm5.Direction = ParameterDirection.Input;
               prm5.Value = userid;
               objOraclecommand.Parameters.Add(prm5);

               objOraclecommand.Parameters.Add("P_ACCOUNTS", OracleType.Cursor);
               objOraclecommand.Parameters["P_ACCOUNTS"].Direction = ParameterDirection.Output;


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


        public DataSet productbind(string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
               objOracleConnection.Open();
               objOraclecommand = GetCommand("contactproductcontact.contactproductcontact_p", ref objOracleConnection);
               objOraclecommand.CommandType = CommandType.StoredProcedure;


               OracleParameter prm4 = new OracleParameter("userid", OracleType.VarChar, 50);
               prm4.Direction = ParameterDirection.Input;
               prm4.Value = userid;
               objOraclecommand.Parameters.Add(prm4);

               OracleParameter prm5 = new OracleParameter("compcode", OracleType.VarChar, 50);
               prm5.Direction = ParameterDirection.Input;
               prm5.Value = compcode;
               objOraclecommand.Parameters.Add(prm5);


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



        public DataSet clientbind(string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
               objOracleConnection.Open();
               objOraclecommand = GetCommand("listbindclient.listbindclient_p", ref objOracleConnection);
               objOraclecommand.CommandType = CommandType.StoredProcedure;

               OracleParameter prm4 = new OracleParameter("userid", OracleType.VarChar, 50);
               prm4.Direction = ParameterDirection.Input;
               prm4.Value = userid;
               objOraclecommand.Parameters.Add(prm4);

               OracleParameter prm5 = new OracleParameter("compcode", OracleType.VarChar, 50);
               prm5.Direction = ParameterDirection.Input;
               prm5.Value = compcode;
               objOraclecommand.Parameters.Add(prm5);

               objOraclecommand.Parameters.Add("P_ACCOUNTS", OracleType.Cursor);
               objOraclecommand.Parameters["P_ACCOUNTS"].Direction = ParameterDirection.Output;


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


        public DataSet buttonbind(string compcode, string userid, string code)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
               objOracleConnection.Open();
               objOraclecommand = GetCommand("contactdetailbind.contactdetailbind_p", ref objOracleConnection);
               objOraclecommand.CommandType = CommandType.StoredProcedure;

               OracleParameter prm4 = new OracleParameter("userid", OracleType.VarChar, 50);
               prm4.Direction = ParameterDirection.Input;
               prm4.Value = userid;
               objOraclecommand.Parameters.Add(prm4);

               OracleParameter prm5 = new OracleParameter("compcode", OracleType.VarChar, 50);
               prm5.Direction = ParameterDirection.Input;
               prm5.Value = compcode;
               objOraclecommand.Parameters.Add(prm5);

               OracleParameter prm6= new OracleParameter("code", OracleType.VarChar, 50);
               prm6.Direction = ParameterDirection.Input;
               prm6.Value = code;
               objOraclecommand.Parameters.Add(prm6);

               objOraclecommand.Parameters.Add("P_ACCOUNTS", OracleType.Cursor);
               objOraclecommand.Parameters["P_ACCOUNTS"].Direction = ParameterDirection.Output;



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





        public DataSet getthevalue(string contactperson, string agencycode, string subagencycode, string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
               objOracleConnection.Open();
               objOraclecommand = GetCommand("updatevalueintable.updatevalueintable_p", ref objOracleConnection);
               objOraclecommand.CommandType = CommandType.StoredProcedure;


               OracleParameter prm4 = new OracleParameter("userid", OracleType.VarChar, 50);
               prm4.Direction = ParameterDirection.Input;
               prm4.Value = userid;
               objOraclecommand.Parameters.Add(prm4);

               OracleParameter prm5 = new OracleParameter("compcode", OracleType.VarChar, 50);
               prm5.Direction = ParameterDirection.Input;
               prm5.Value = compcode;
               objOraclecommand.Parameters.Add(prm5);

               OracleParameter prm6 = new OracleParameter("contactperson", OracleType.VarChar, 50);
               prm6.Direction = ParameterDirection.Input;
               prm6.Value = contactperson;
               objOraclecommand.Parameters.Add(prm6);

               OracleParameter prm1 = new OracleParameter("subagencycode", OracleType.VarChar, 50);
               prm1.Direction = ParameterDirection.Input;
               prm1.Value = subagencycode;
               objOraclecommand.Parameters.Add(prm1);


               OracleParameter prm8 = new OracleParameter("agencycode", OracleType.VarChar, 50);
               prm8.Direction = ParameterDirection.Input;
               prm8.Value = agencycode;
               objOraclecommand.Parameters.Add(prm8);


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

        public DataSet detailofcontact(string compcode, string userid, string contactcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
               objOracleConnection.Open();
               objOraclecommand = GetCommand("getcontactvalue.getcontactvalue_p", ref objOracleConnection);
               objOraclecommand.CommandType = CommandType.StoredProcedure;

               OracleParameter prm4 = new OracleParameter("userid", OracleType.VarChar, 50);
               prm4.Direction = ParameterDirection.Input;
               prm4.Value = userid;
               objOraclecommand.Parameters.Add(prm4);

               OracleParameter prm5 = new OracleParameter("compcode", OracleType.VarChar, 50);
               prm5.Direction = ParameterDirection.Input;
               prm5.Value = compcode;
               objOraclecommand.Parameters.Add(prm5);

               OracleParameter prm8 = new OracleParameter("contactcode", OracleType.VarChar, 50);
               prm8.Direction = ParameterDirection.Input;
               prm8.Value = contactcode;
               objOraclecommand.Parameters.Add(prm8);


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

        public DataSet contactname(string conname, string agencycode, string subagency, string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
               objOracleConnection.Open();
               objOraclecommand = GetCommand("getcontactname.getcontactname_p", ref objOracleConnection);
               objOraclecommand.CommandType = CommandType.StoredProcedure;

               OracleParameter prm4 = new OracleParameter("userid", OracleType.VarChar, 50);
               prm4.Direction = ParameterDirection.Input;
               prm4.Value = userid;
               objOraclecommand.Parameters.Add(prm4);

               OracleParameter prm5 = new OracleParameter("compcode", OracleType.VarChar, 50);
               prm5.Direction = ParameterDirection.Input;
               prm5.Value = compcode;
               objOraclecommand.Parameters.Add(prm5);

               OracleParameter prm8 = new OracleParameter("conname", OracleType.VarChar, 50);
               prm8.Direction = ParameterDirection.Input;
               prm8.Value = conname;
               objOraclecommand.Parameters.Add(prm8);

               OracleParameter prm10 = new OracleParameter("agencycode", OracleType.VarChar, 50);
               prm10.Direction = ParameterDirection.Input;
               prm10.Value = agencycode;
               objOraclecommand.Parameters.Add(prm10);

               OracleParameter prm9 = new OracleParameter("subagency", OracleType.VarChar, 50);
               prm9.Direction = ParameterDirection.Input;
               prm9.Value = subagency;
               objOraclecommand.Parameters.Add(prm9);

               objOraclecommand.Parameters.Add("P_ACCOUNTS", OracleType.Cursor);
               objOraclecommand.Parameters["P_ACCOUNTS"].Direction = ParameterDirection.Output;



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

        public DataSet clientvalue(string conname, string compcode, string userid, string agencycode, string subagency)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
               objOracleConnection.Open();
               objOraclecommand = GetCommand("getclientfromcontact.getclientfromcontact_p", ref objOracleConnection);
               objOraclecommand.CommandType = CommandType.StoredProcedure;

               OracleParameter prm4 = new OracleParameter("userid", OracleType.VarChar, 50);
               prm4.Direction = ParameterDirection.Input;
               prm4.Value = userid;
               objOraclecommand.Parameters.Add(prm4);

               OracleParameter prm5 = new OracleParameter("compcode", OracleType.VarChar, 50);
               prm5.Direction = ParameterDirection.Input;
               prm5.Value = compcode;
               objOraclecommand.Parameters.Add(prm5);


               OracleParameter prm8 = new OracleParameter("conname", OracleType.VarChar, 50);
               prm8.Direction = ParameterDirection.Input;
               prm8.Value = conname;
               objOraclecommand.Parameters.Add(prm8);

               OracleParameter prm10 = new OracleParameter("agencycode", OracleType.VarChar, 50);
               prm10.Direction = ParameterDirection.Input;
               prm10.Value = agencycode;
               objOraclecommand.Parameters.Add(prm10);

               OracleParameter prm9 = new OracleParameter("subagency", OracleType.VarChar, 50);
               prm9.Direction = ParameterDirection.Input;
               prm9.Value = subagency;
               objOraclecommand.Parameters.Add(prm9);

               objOraclecommand.Parameters.Add("P_ACCOUNTS", OracleType.Cursor);
               objOraclecommand.Parameters["P_ACCOUNTS"].Direction = ParameterDirection.Output;

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

        public DataSet ratebind(string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
               objOracleConnection.Open();
               objOraclecommand = GetCommand("bindrateforpreferrence.bindrateforpreferrence_p", ref objOracleConnection);
               objOraclecommand.CommandType = CommandType.StoredProcedure;

               OracleParameter prm5 = new OracleParameter("compcode", OracleType.VarChar, 50);
               prm5.Direction = ParameterDirection.Input;
               prm5.Value = compcode;
               objOraclecommand.Parameters.Add(prm5);
              

               objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
               objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;



               objorclDataAdapter.SelectCommand = objOraclecommand;
               objorclDataAdapter.Fill(objDataSet);
               return objDataSet;
            }
            catch (Exception ex) { throw (ex); }
            finally
            { CloseConnection(ref objOracleConnection); }

        }

        public DataSet insMasterPrev(string name, string prev, string formname, string modulename, string userid, string compcode, string division, string moduleno, string formid, string rostatusval, string modelcode)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("Wesp_insertModuleDetailchk.Wesp_insertModuleDetailchk_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm11 = new OracleParameter("modulename", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = modulename;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("division", OracleType.VarChar, 50);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = division;
                objOraclecommand.Parameters.Add(prm12);


                OracleParameter prm13 = new OracleParameter("prev", OracleType.VarChar, 50);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = prev;
                objOraclecommand.Parameters.Add(prm13);


                OracleParameter prm14 = new OracleParameter("formname", OracleType.VarChar, 50);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = formname;
                objOraclecommand.Parameters.Add(prm14);


                OracleParameter prm4 = new OracleParameter("userid1", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = userid;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = compcode;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm9 = new OracleParameter("moduleno", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = moduleno;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("pback_days", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = rostatusval;
                objOraclecommand.Parameters.Add(prm10);

              OracleParameter prm15 = new OracleParameter("pmodulecode", OracleType.VarChar, 50);
              prm15.Direction = ParameterDirection.Input;
              if (modelcode == "" || modelcode == "&nbsp;")
                  prm15.Value = System.DBNull.Value;
                else
              prm15.Value = modelcode;
              objOraclecommand.Parameters.Add(prm15);

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

        public DataSet getuserinfo(string userid)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("Wesp_getuserinfo.Wesp_getuserinfo_p", ref objOracleConnection);
               objOraclecommand.CommandType = CommandType.StoredProcedure;


               OracleParameter prm4 = new OracleParameter("userid", OracleType.VarChar, 50);
               prm4.Direction = ParameterDirection.Input;
               prm4.Value = userid;
               objOraclecommand.Parameters.Add(prm4);

               objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
               objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;


                objorclDataAdapter.SelectCommand =objOraclecommand;
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


        public DataSet statusdatecheck(string drpstatus, string txtfrom, string txtto, string compcode, string userid, string agencycode, string agencysubcode, string dateformat)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("statusdatecheck", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm11 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = compcode;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = userid;
                objOraclecommand.Parameters.Add(prm12);


                OracleParameter prm13 = new OracleParameter("agencycode", OracleType.VarChar, 50);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = agencycode;
                objOraclecommand.Parameters.Add(prm13);


                OracleParameter prm14 = new OracleParameter("agencysubcode", OracleType.VarChar, 50);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = agencysubcode;
                objOraclecommand.Parameters.Add(prm14);

                OracleParameter prm1 = new OracleParameter("drpstatus", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = drpstatus;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("txtfrom", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = Convert.ToDateTime(txtfrom).ToString("dd-MMMM-yyyy");
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("txtto", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = Convert.ToDateTime(txtto).ToString("dd-MMMM-yyyy");
                objOraclecommand.Parameters.Add(prm3);


                OracleParameter prm4 = new OracleParameter("dateformat", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = dateformat;
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
        public DataSet MastPrevDisp_user(string compcode, string userid, string userhome, string admin, string retainer, string username)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("wesp_Modultuser.wesp_wesp_Modultuser_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("userhome", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userhome;
                objOraclecommand.Parameters.Add(prm3);



                OracleParameter prm4 = new OracleParameter("ADMIN1", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = admin;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("Retainer", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = retainer;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("username1", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = username;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("p_extra1", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("p_extra2", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm8);


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

        /////////bhanu date chk

        public DataSet datechk(string sf, string st, string txtfrom, string txtto, string dateformat)
        {
           OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("datechk_b", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("sf", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                if (dateformat == "dd/mm/yyyy")
                {
                    string[] arr = sf.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    sf = mm + "/" + dd + "/" + yy;


                }
                else
                    if (dateformat == "mm/dd/yyyy")
                    {
                        string[] arr = sf.Split('/');
                        string dd = arr[1];
                        string mm = arr[0];
                        string yy = arr[2];
                        sf = mm + "/" + dd + "/" + yy;

                    }

                    else
                        if (dateformat == "yyyy/mm/dd")
                        {
                            string[] arr = sf.Split('/');
                            string dd = arr[2];
                            string mm = arr[1];
                            string yy = arr[0];
                            sf = mm + "/" + dd + "/" + yy;
                        }
                prm1.Value = Convert.ToDateTime(sf).ToString("dd-MMMM-yyyy");
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("st", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                if (dateformat == "dd/mm/yyyy")
                {
                    string[] arr = st.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    st = mm + "/" + dd + "/" + yy;


                }
                else
                    if (dateformat == "mm/dd/yyyy")
                    {
                        string[] arr = st.Split('/');
                        string dd = arr[1];
                        string mm = arr[0];
                        string yy = arr[2];
                        st = mm + "/" + dd + "/" + yy;

                    }

                    else
                        if (dateformat == "yyyy/mm/dd")
                        {
                            string[] arr = st.Split('/');
                            string dd = arr[2];
                            string mm = arr[1];
                            string yy = arr[0];
                            st = mm + "/" + dd + "/" + yy;
                        }
                prm2.Value = Convert.ToDateTime(st).ToString("dd-MMMM-yyyy");
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("txtfrom", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                if (dateformat == "dd/mm/yyyy")
                {
                    string[] arr = txtfrom.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    txtfrom = mm + "/" + dd + "/" + yy;


                }
                else
                    if (dateformat == "mm/dd/yyyy")
                    {
                        string[] arr = txtfrom.Split('/');
                        string dd = arr[1];
                        string mm = arr[0];
                        string yy = arr[2];
                        txtfrom = mm + "/" + dd + "/" + yy;

                    }

                    else
                        if (dateformat == "yyyy/mm/dd")
                        {
                            string[] arr = txtfrom.Split('/');
                            string dd = arr[2];
                            string mm = arr[1];
                            string yy = arr[0];
                            txtfrom = mm + "/" + dd + "/" + yy;
                        }
                prm3.Value = Convert.ToDateTime(txtfrom).ToString("dd-MMMM-yyyy");
                objOraclecommand.Parameters.Add(prm3);



                OracleParameter prm4 = new OracleParameter("txtto", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                if (dateformat == "dd/mm/yyyy")
                {
                    string[] arr = txtto.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    txtto = mm + "/" + dd + "/" + yy;


                }
                else
                    if (dateformat == "mm/dd/yyyy")
                    {
                        string[] arr = txtto.Split('/');
                        string dd = arr[1];
                        string mm = arr[0];
                        string yy = arr[2];
                        txtto = mm + "/" + dd + "/" + yy;

                    }

                    else
                        if (dateformat == "yyyy/mm/dd")
                        {
                            string[] arr = txtto.Split('/');
                            string dd = arr[2];
                            string mm = arr[1];
                            string yy = arr[0];
                            txtto = mm + "/" + dd + "/" + yy;
                        }
                prm4.Value = Convert.ToDateTime(txtto).ToString("dd-MMMM-yyyy");
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

        /////end bhanu


        
    }











}

