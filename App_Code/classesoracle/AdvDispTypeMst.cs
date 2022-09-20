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

namespace NewAdbooking.classesoracle
{


    /// <summary>
    /// Summary description for AdvDispTypeMst
    /// </summary>
    public class AdvDispTypeMst : orclconnection
    {
        public AdvDispTypeMst()
        {
            //
            // TODO: Add constructor logic here
            //
        }





        public DataSet Delete(string compcode, string amount)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("deldesign", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pcompcoed", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("pamount", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = amount;
                objOraclecommand.Parameters.Add(prm2);



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



        public DataSet update1(string COMP_CODE, string USERID, string LOGOPREMIUM_CODE, string EDITION, string AMOUNT, string PREMIUM, string hdnsequenceno, string validfrom, string validto)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("updatedesignchild", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pCOMP_CODE", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = COMP_CODE;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("pUSERID", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = USERID;
                objOraclecommand.Parameters.Add(prm2);



                OracleParameter prm3 = new OracleParameter("pLOGOPREMIUM_CODE", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = LOGOPREMIUM_CODE;
                objOraclecommand.Parameters.Add(prm3);



                OracleParameter prm4 = new OracleParameter("pEDITION", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = EDITION;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("pPREMIUM", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = PREMIUM;
                objOraclecommand.Parameters.Add(prm5);


                OracleParameter prm6 = new OracleParameter("pAMOUNT", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = AMOUNT;
                objOraclecommand.Parameters.Add(prm6);



                OracleParameter prm7 = new OracleParameter("pseq", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = hdnsequenceno;
                objOraclecommand.Parameters.Add(prm7);


                OracleParameter prm8 = new OracleParameter("pvalidfrom", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = validfrom;


                string dateformat = "dd/mm/yyyy";
                if (dateformat == "dd/mm/yyyy")
                {
                    string[] arr = validfrom.Split('/');
                    string dd = arr[2];
                    string mm = arr[1];
                    string yy = arr[0];
                    validfrom = mm + "/" + dd + "/" + yy;
                }




                prm8.Value = Convert.ToDateTime(validfrom).ToString("dd-MMMM-yyyy");




                objOraclecommand.Parameters.Add(prm8);


                OracleParameter prm9 = new OracleParameter("pvalidto", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = validto;


                if (dateformat == "dd/mm/yyyy")
                {
                    string[] arr = validto.Split('/');
                    string dd = arr[2];
                    string mm = arr[1];
                    string yy = arr[0];
                    validto = mm + "/" + dd + "/" + yy;
                }




                prm9.Value = Convert.ToDateTime(validto).ToString("dd-MMMM-yyyy");



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










        public DataSet save1(string compcode, string userid, string logoprem, string edition, string premimum, string amount,string validfrom,string validto)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("savedesignchild", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pCOMP_CODE", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("pUSERID", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);



                OracleParameter prm3 = new OracleParameter("pLOGOPREMIUM_CODE", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = logoprem;
                objOraclecommand.Parameters.Add(prm3);



                OracleParameter prm4 = new OracleParameter("pEDITION", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = edition;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("pPREMIUM", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = premimum;
                objOraclecommand.Parameters.Add(prm5);


                OracleParameter prm6 = new OracleParameter("pAMOUNT", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = amount;
                objOraclecommand.Parameters.Add(prm6);





                  OracleParameter prm7 = new OracleParameter("pvalidfrom", OracleType.VarChar, 50);
            prm7.Direction = ParameterDirection.Input;


            if (validfrom == "")
            {
                prm7.Value = System.DBNull.Value; 
            }

            else
            {
                string dateformat = "dd/mm/yyyy";
                if (dateformat == "dd/mm/yyyy")
                {
                    string[] arr = validfrom.Split('/');
                    string dd = arr[2];
                    string mm = arr[1];
                    string yy = arr[0];
                   // validfrom = mm + "/" + dd + "/" + yy;
                    validfrom = yy + "/" + dd + "/" + mm;
                }




                prm7.Value = Convert.ToDateTime(validfrom).ToString("dd-MMMM-yyyy"); 
            }
            objOraclecommand.Parameters.Add(prm7);




            OracleParameter prm8 = new OracleParameter("pvalidto", OracleType.VarChar, 50);
            prm8.Direction = ParameterDirection.Input;
            if (validto == "")
            {
                prm8.Value = System.DBNull.Value;
            }
            else
            {

                string dateformat = "dd/mm/yyyy";
                if (dateformat == "dd/mm/yyyy")
                {
                    string[] arr = validto.Split('/');
                    string dd = arr[2];
                    string mm = arr[1];
                    string yy = arr[0];
                 //   validto = mm + "/" + dd + "/" + yy;
                    validto = yy + "/" + dd + "/" + mm;
                }





                prm8.Value = Convert.ToDateTime(validto).ToString("dd-MMMM-yyyy"); 
            }

          
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



        public DataSet duplicay1(string compcode ,string logoprem, string edition, string validfrom ,string validto)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("duplicaydesingbind", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pcompcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("pdesigntypecode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = logoprem;
                objOraclecommand.Parameters.Add(prm2);



                OracleParameter prm5 = new OracleParameter("pedition", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = edition;
                objOraclecommand.Parameters.Add(prm5);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;



                OracleParameter prm3 = new OracleParameter("pvalidfrom", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;

                string dateformat = "dd/mm/yyyy";
                if (dateformat == "dd/mm/yyyy")
                {
                    string[] arr = validfrom.Split('/');
                    string dd = arr[2];
                    string mm = arr[1];
                    string yy = arr[0];
                  //  validfrom = mm + "/" + dd + "/" + yy;
                    validfrom = mm + "/" + yy + "/" + dd;
                }


                prm3.Value = Convert.ToDateTime(validfrom).ToString("dd-MMMM-yyyy");
                objOraclecommand.Parameters.Add(prm3);



                OracleParameter prm4 = new OracleParameter("pvalidto", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;


                if (dateformat == "dd/mm/yyyy")
                {
                    string[] arr = validto.Split('/');
                    string dd = arr[2];
                    string mm = arr[1];
                    string yy = arr[0];
                   // validto = mm + "/" + dd + "/" + yy;
                    validfrom = mm + "/" + yy + "/" + dd;
                }


                prm4.Value = Convert.ToDateTime(validto).ToString("dd-MMMM-yyyy");
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




        public DataSet logobind1(string compcode, string logocode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("designlogobind1", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pcompcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("pamount", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = logocode;
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







        public DataSet logobind(string compcode, string logocode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("designbind", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pcompcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("plogoprcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = logocode;
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



        public DataSet chkadvposition1(string str)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("chkadvdistyp.chkadvdistyp_P", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("str", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = str;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("cod", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                if (str.Length > 2)
                {
                    prm2.Value = str.Substring(0, 2);
                    objOraclecommand.Parameters.Add(prm2);
                }
                else
                {
                    prm2.Value = str;
                    objOraclecommand.Parameters.Add(prm2);
                }


                objOraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;


                objOraclecommand.Parameters.Add("P_Accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts1"].Direction = ParameterDirection.Output;

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





        public DataSet ModifyValue(string PosTypCode, string PosType, string Alias, string amount, string premium, string compcode, string userid, string fdate, string tdate, string dateformat, string description, string adcat)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("DispTypeMstModify.DispTypeMstModify_P", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("PosTypCode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = PosTypCode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("PosType", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = PosType;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("pAlias", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = Alias;
                objOraclecommand.Parameters.Add(prm5);


                OracleParameter prm6 = new OracleParameter("ppremium", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = premium;
                objOraclecommand.Parameters.Add(prm6);


                OracleParameter prm7 = new OracleParameter("Amount1", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = amount;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm9 = new OracleParameter("p_fdate", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                if (fdate == "" || fdate == null)
                {
                    prm9.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = fdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        fdate = mm + "/" + dd + "/" + yy;
                    }
                    prm9.Value = Convert.ToDateTime(fdate).ToString("dd-MMMM-yyyy");
                }

                objOraclecommand.Parameters.Add(prm9);


                OracleParameter prm10 = new OracleParameter("p_tdate", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                if (tdate == "" || tdate == null)
                {
                    prm10.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = tdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        tdate = mm + "/" + dd + "/" + yy;
                    }
                    prm10.Value = Convert.ToDateTime(tdate).ToString("dd-MMMM-yyyy");
                }

                objOraclecommand.Parameters.Add(prm10);





                OracleParameter prm11 = new OracleParameter("pDES_DESCRIPTION", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = description;
                objOraclecommand.Parameters.Add(prm11);


              






                OracleParameter prm22 = new OracleParameter("adcat", OracleType.VarChar, 2000);
                prm22.Direction = ParameterDirection.Input;
                if (adcat == "" || adcat == "0")
                    prm22.Value = System.DBNull.Value;
                else
                    prm22.Value = adcat;
                objOraclecommand.Parameters.Add(prm22);


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






        public DataSet chkpastypename1(string PosTypCode, string PosTypName, string compcode, string userid, string fdate, string tdate, string flag)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("designPositionTypechkname", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("p_PosTypCode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = PosTypCode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("p_PosTypName", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = PosTypName;
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("p_compcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = compcode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("p_userid", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = userid;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("p_flag", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = flag;
                objOraclecommand.Parameters.Add(prm5);
                string dateformat = "dd/mm/yyyy";
                OracleParameter prm9 = new OracleParameter("p_fdate", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                if (fdate == "" || fdate == null)
                {
                    prm9.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = fdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        fdate = mm + "/" + dd + "/" + yy;
                    }
                    prm9.Value = Convert.ToDateTime(fdate).ToString("dd-MMMM-yyyy");
                }

                objOraclecommand.Parameters.Add(prm9);


                OracleParameter prm10 = new OracleParameter("p_tdate", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                if (tdate == "" || tdate == null)
                {
                    prm10.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = tdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        tdate = mm + "/" + dd + "/" + yy;
                    }
                    prm10.Value = Convert.ToDateTime(tdate).ToString("dd-MMMM-yyyy");
                }

                objOraclecommand.Parameters.Add(prm10);

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




        public DataSet chksave(string PosTypCode, string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("DisplayTypechk.DisplayTypechk_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("PosTypCode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = PosTypCode;
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






        public DataSet InsertValue(string PosTypCode, string PosType, string Alias, string amount, string premium, string compcode, string userid, string fdate, string tdate, string dateformat, string description, string adcat)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("DisplayTypeMstInsert.DisplayTypeMstInsert_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;



                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("PosTypCode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = PosTypCode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("PosType", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = PosType;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("Alias", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = Alias;
                objOraclecommand.Parameters.Add(prm5);


                OracleParameter prm6 = new OracleParameter("premium", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = premium;
                objOraclecommand.Parameters.Add(prm6);


                OracleParameter prm7 = new OracleParameter("Amount", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                if (amount == "" || amount == null)
                {
                    prm7.Value = "0".ToString();
                }
                else
                {
                    prm7.Value = amount;
                }
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm9 = new OracleParameter("p_fdate", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                if (fdate == "" || fdate == null)
                {
                    prm9.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = fdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        fdate = mm + "/" + dd + "/" + yy;
                    }
                    prm9.Value = Convert.ToDateTime(fdate).ToString("dd-MMMM-yyyy");
                }

                objOraclecommand.Parameters.Add(prm9);


                OracleParameter prm10 = new OracleParameter("p_tdate", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                if (tdate == "" || tdate == null)
                {
                    prm10.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = tdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        tdate = mm + "/" + dd + "/" + yy;
                    }
                    prm10.Value = Convert.ToDateTime(tdate).ToString("dd-MMMM-yyyy");
                }

                objOraclecommand.Parameters.Add(prm10);



                OracleParameter prm11 = new OracleParameter("des_desc", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                if (description == "" || description == null)
                {
                    prm11.Value = System.DBNull.Value;
                }
                else
                {
                    prm11.Value = description;
                }
                objOraclecommand.Parameters.Add(prm11);



                




                OracleParameter prm22 = new OracleParameter("adcat", OracleType.VarChar, 2000);
                prm22.Direction = ParameterDirection.Input;
                if (adcat == "" || adcat == "0")
                    prm22.Value = System.DBNull.Value;
                else
                    prm22.Value = adcat;
                objOraclecommand.Parameters.Add(prm22);






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





        public DataSet SelectValue(string PosTypCode, string PosType, string Alias, string amount, string premium, string compcode, string userid, string dateformat)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("AdvDisTypeSelect.AdvDisTypeSelect_P", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("PosTypCode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = PosTypCode;
                objOraclecommand.Parameters.Add(prm3);
                OracleParameter prm4 = new OracleParameter("PosType", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = PosType;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("Alias", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = Alias;
                objOraclecommand.Parameters.Add(prm5);


                OracleParameter prm6 = new OracleParameter("premium", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                if (premium == "0")
                {
                    prm6.Value = System.DBNull.Value;
                }
                else
                {

                    prm6.Value = premium;
                }
                objOraclecommand.Parameters.Add(prm6);


                OracleParameter prm7 = new OracleParameter("Amount", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = amount;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("p_dateformat", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = dateformat;
                objOraclecommand.Parameters.Add(prm8);


                objOraclecommand.Parameters.Add("P_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["P_accounts"].Direction = ParameterDirection.Output;


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




        public DataSet delete1(string PosTypCode, string compcode, string userid)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("DispTypedel.DisTypedel_P", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("PosTypCode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = PosTypCode;
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





    }
}
