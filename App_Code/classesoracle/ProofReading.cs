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
/// Summary description for ProofReading
/// </summary>
namespace NewAdbooking.classesoracle
{
    public class ProofReading : orclconnection
    {
        public ProofReading()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataSet findrec(string frmdate, string todate, string cat, string filter, string compcode, string dateformat, string cat2, string InsertionType, string bookingtype, string p_bkid, string pextra1, string pextra2, string pextra3, string pextra4, string pextra5, string userid) 
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("bindproofreading", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);



                OracleParameter prm2 = new OracleParameter("filter1", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = filter;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("cate", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = cat;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("frdate", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                if (frmdate == "" || frmdate == null)
                {
                    prm4.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = frmdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        frmdate = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = frmdate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        frmdate = mm + "/" + dd + "/" + yy;
                    }
                    prm4.Value = Convert.ToDateTime(frmdate).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("todate", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                if (todate == "" || todate == null)
                {
                    prm5.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = todate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        todate = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = todate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        todate = mm + "/" + dd + "/" + yy;
                    }
                    prm5.Value = Convert.ToDateTime(todate).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("cat2", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                if (cat2 == "" || cat2 == "0")
                    prm6.Value = System.DBNull.Value;
                else
                prm6.Value = cat2;
                objOraclecommand.Parameters.Add(prm6);
                //...
                OracleParameter prm7 = new OracleParameter("p_repeat", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                if (InsertionType == "" || InsertionType == "0")
                    prm7.Value = System.DBNull.Value;
                else
                    prm7.Value = InsertionType;
                objOraclecommand.Parameters.Add(prm7);
                //...

                OracleParameter prm8 = new OracleParameter("p_booktype", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = bookingtype;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("p_bkid", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = p_bkid;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("pextra1", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = pextra1;
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("pextra2", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = pextra2;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("pextra3", OracleType.VarChar, 50);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = pextra3;
                objOraclecommand.Parameters.Add(prm12);

                OracleParameter prm13 = new OracleParameter("pextra4", OracleType.VarChar, 50);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = pextra4;
                objOraclecommand.Parameters.Add(prm13);

                OracleParameter prm14 = new OracleParameter("pextra5", OracleType.VarChar, 50);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = pextra5;
                objOraclecommand.Parameters.Add(prm14);

                OracleParameter prm15 = new OracleParameter("pdateformat", OracleType.VarChar, 50);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = dateformat;
                objOraclecommand.Parameters.Add(prm15);

                OracleParameter prm16 = new OracleParameter("puserid", OracleType.VarChar, 50);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = userid;
                objOraclecommand.Parameters.Add(prm16);






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





        public DataSet findrecagency(string frmdate, string todate, string cat, string filter, string compcode, string dateformat, string cat2, string InsertionType, string bookingtype, string p_bkid, string pextra1, string pextra2, string pextra3, string pextra4, string pextra5, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("bindproofreadingforagencyaudit", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);



                OracleParameter prm2 = new OracleParameter("filter1", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = filter;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("cate", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = cat;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("frdate", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                if (frmdate == "" || frmdate == null)
                {
                    prm4.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = frmdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        frmdate = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = frmdate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        frmdate = mm + "/" + dd + "/" + yy;
                    }
                    prm4.Value = Convert.ToDateTime(frmdate).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("todate", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                if (todate == "" || todate == null)
                {
                    prm5.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = todate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        todate = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = todate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        todate = mm + "/" + dd + "/" + yy;
                    }
                    prm5.Value = Convert.ToDateTime(todate).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("cat2", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                if (cat2 == "" || cat2 == "0")
                    prm6.Value = System.DBNull.Value;
                else
                    prm6.Value = cat2;
                objOraclecommand.Parameters.Add(prm6);
                //...
                OracleParameter prm7 = new OracleParameter("p_repeat", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                if (InsertionType == "" || InsertionType == "0")
                    prm7.Value = System.DBNull.Value;
                else
                    prm7.Value = InsertionType;
                objOraclecommand.Parameters.Add(prm7);
                //...

                OracleParameter prm8 = new OracleParameter("p_booktype", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = bookingtype;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("p_bkid", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = p_bkid;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("pextra1", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = pextra1;
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("pextra2", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = pextra2;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("pextra3", OracleType.VarChar, 50);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = pextra3;
                objOraclecommand.Parameters.Add(prm12);

                OracleParameter prm13 = new OracleParameter("pextra4", OracleType.VarChar, 50);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = pextra4;
                objOraclecommand.Parameters.Add(prm13);

                OracleParameter prm14 = new OracleParameter("pextra5", OracleType.VarChar, 50);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = pextra5;
                objOraclecommand.Parameters.Add(prm14);

                OracleParameter prm15 = new OracleParameter("pdateformat", OracleType.VarChar, 50);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = dateformat;
                objOraclecommand.Parameters.Add(prm15);

                OracleParameter prm16 = new OracleParameter("puserid", OracleType.VarChar, 50);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = userid;
                objOraclecommand.Parameters.Add(prm16);






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

















        public DataSet findprec(string bookid, string filename)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_proorec", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("filename", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = filename;
                objOraclecommand.Parameters.Add(prm1);



                OracleParameter prm2 = new OracleParameter("bookid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = bookid;
                objOraclecommand.Parameters.Add(prm2);


                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                //objOraclecommand.Parameters.Add("p_accounts1", OracleType.Cursor);
                //objOraclecommand.Parameters["p_accounts1"].Direction = ParameterDirection.Output;

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


        public DataSet selectproofaudir(string bookid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("updateproofauditbooking", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("cioid", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = bookid;
                objOraclecommand.Parameters.Add(prm1);



                



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






        public DataSet selecproof(string bookid, string filename)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_proofad", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("filename", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = filename;
                objOraclecommand.Parameters.Add(prm1);



                OracleParameter prm2 = new OracleParameter("bookid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = bookid;
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

        public DataSet pub_cent_NEW(string compcode, string chk_access, string useid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {


                objOracleConnection.Open();
                objOraclecommand = GetCommand("Bind_PubCentName_r.Bind_PubCentName_r_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;



                OracleParameter prm1 = new OracleParameter("puserid", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = useid;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("chk_access", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = chk_access;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = compcode;
                objOraclecommand.Parameters.Add(prm3);


                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (OracleException objException)
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



    }

}
