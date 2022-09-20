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
    /// Summary description for cash_recipt
    /// </summary>
    public class cash_recipt : orclconnection
    {
        public cash_recipt()
        {
            //
            // TODO: Add constructor logic here
            //
        }



        public DataSet InsertCashDetailmulti(string cioid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("InsertCashDetailmulti", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("cioid", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = cioid;
                objOraclecommand.Parameters.Add(prm1);
                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;



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



        public DataSet executeauditmast1(string bookingid, string compcode, string adtype, string dateformat)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("executebookingdispaudit.executebookingdispaudit_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("ciobookid", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = bookingid;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("booking", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = adtype;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("docno", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("keyno", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("rono", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("agencycode", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("client", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("dateformat", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = dateformat;
                objOraclecommand.Parameters.Add(prm9);

                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_Accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts1"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_Accounts2", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts2"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_Accounts3", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts3"].Direction = ParameterDirection.Output;

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


        public DataSet mulcashrcpt1234(string dateformat, string fromdate, string todate, string bookingid, string agency, string executive, string compcode, string adtype, string booking_id, string rostatus)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("adjustedunadjusted1", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("fromdate", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                if (fromdate == "")
                {

                    prm1.Value = System.DBNull.Value;

                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] tilldatearr = fromdate.Split('/');
                        string dd1 = tilldatearr[0].ToString();
                        string mm1 = tilldatearr[1].ToString();
                        string yy1 = tilldatearr[2].ToString();
                        fromdate = mm1 + "/" + dd1 + "/" + yy1;
                    }

                    prm1.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");
                }

                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("todate", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                if (todate == "")
                {

                    prm2.Value = System.DBNull.Value;
                }

                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] tilldatearr = todate.Split('/');
                        string dd1 = tilldatearr[0].ToString();
                        string mm1 = tilldatearr[1].ToString();
                        string yy1 = tilldatearr[2].ToString();
                        todate = mm1 + "/" + dd1 + "/" + yy1;
                    }
                    prm2.Value = Convert.ToDateTime(todate).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("date1", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = dateformat;
                objOraclecommand.Parameters.Add(prm3);


                OracleParameter prm4 = new OracleParameter("agency", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = agency;
                objOraclecommand.Parameters.Add(prm4);


                OracleParameter prm5 = new OracleParameter("Adtype", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = adtype;
                objOraclecommand.Parameters.Add(prm5);


                OracleParameter prm6 = new OracleParameter("pexecutive", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = executive;
                objOraclecommand.Parameters.Add(prm6);



                OracleParameter prm7 = new OracleParameter("comp_code", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = compcode;
                objOraclecommand.Parameters.Add(prm7);



                OracleParameter prm8 = new OracleParameter("pbooking_id", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = booking_id;
                objOraclecommand.Parameters.Add(prm8);


                OracleParameter prm9 = new OracleParameter("prostatus", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = rostatus;
                objOraclecommand.Parameters.Add(prm9);







                objOraclecommand.Parameters.Add("P_ACCOUNT", OracleType.Cursor);
                objOraclecommand.Parameters["P_ACCOUNT"].Direction = ParameterDirection.Output;

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





        public DataSet mulcashrcpt123(string dateformat, string fromdate, string todate, string bookingid, string agency, string executive, string compcode, string adtype, string booking_id, string rostatus)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("adjustedunadjusted", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("fromdate", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                if (fromdate == "")
                {

                    prm1.Value = System.DBNull.Value;

                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] tilldatearr = fromdate.Split('/');
                        string dd1 = tilldatearr[0].ToString();
                        string mm1 = tilldatearr[1].ToString();
                        string yy1 = tilldatearr[2].ToString();
                        fromdate = mm1 + "/" + dd1 + "/" + yy1;
                    }

                    prm1.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");
                }

                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("todate", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                if (todate == "")
                {

                    prm2.Value = System.DBNull.Value;
                }

                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] tilldatearr = todate.Split('/');
                        string dd1 = tilldatearr[0].ToString();
                        string mm1 = tilldatearr[1].ToString();
                        string yy1 = tilldatearr[2].ToString();
                        todate = mm1 + "/" + dd1 + "/" + yy1;
                    }
                    prm2.Value = Convert.ToDateTime(todate).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("date1", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = dateformat;
                objOraclecommand.Parameters.Add(prm3);


                OracleParameter prm4 = new OracleParameter("agency", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = agency;
                objOraclecommand.Parameters.Add(prm4);


                OracleParameter prm5 = new OracleParameter("Adtype", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = adtype;
                objOraclecommand.Parameters.Add(prm5);


                OracleParameter prm6 = new OracleParameter("pexecutive", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = executive;
                objOraclecommand.Parameters.Add(prm6);



                OracleParameter prm7 = new OracleParameter("comp_code", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = compcode;
                objOraclecommand.Parameters.Add(prm7);



                OracleParameter prm8 = new OracleParameter("pbooking_id", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = booking_id;
                objOraclecommand.Parameters.Add(prm8);


                OracleParameter prm9 = new OracleParameter("prostatus", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = rostatus;
                objOraclecommand.Parameters.Add(prm9);







                objOraclecommand.Parameters.Add("P_ACCOUNT", OracleType.Cursor);
                objOraclecommand.Parameters["P_ACCOUNT"].Direction = ParameterDirection.Output;

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




        public string updaterostatus(string compcode, string paymode, string booking_id, string rcptno, string cardmonth, string cardyear, string cardname, string cardtype, string cardnumber, string chkno, string chkdate, string chkamt, string chkbankname)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("updatecashrcpt", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pcompcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("ppaymode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = paymode;
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("pbooking_id", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = booking_id;
                objOraclecommand.Parameters.Add(prm3);


                OracleParameter prm4 = new OracleParameter("prcptno", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = rcptno;
                objOraclecommand.Parameters.Add(prm4);





                OracleParameter prm5 = new OracleParameter("pcardmonth", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                if (cardmonth == "" || cardmonth == "0")
                {
                    prm5.Value = System.DBNull.Value;
                }
                else
                {
                    prm5.Value = cardmonth;
                }
                objOraclecommand.Parameters.Add(prm5);




                OracleParameter prm6 = new OracleParameter("pcardyear", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;

                if (cardyear == "" || cardyear == "0")
                {
                    prm6.Value = System.DBNull.Value;
                }
                else
                {
                    prm6.Value = cardyear;
                }


                objOraclecommand.Parameters.Add(prm6);



                OracleParameter prm7 = new OracleParameter("pcardname", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;

                if (cardname == "" || cardname == "0")
                {
                    prm7.Value = System.DBNull.Value;
                }
                else
                {
                    prm7.Value = cardname;
                }

                objOraclecommand.Parameters.Add(prm7);



                OracleParameter prm8 = new OracleParameter("pcardtype", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;

                if (cardtype == "" || cardtype == "0")
                {
                    prm8.Value = System.DBNull.Value;
                }
                else
                {
                    prm8.Value = cardtype;
                }
                objOraclecommand.Parameters.Add(prm8);



                OracleParameter prm9 = new OracleParameter("pcardnumber", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;

                if (cardnumber == "" || cardnumber == "0")
                {
                    prm9.Value = System.DBNull.Value;
                }
                else
                {
                    prm9.Value = cardnumber;
                }

                objOraclecommand.Parameters.Add(prm9);



                OracleParameter prm10 = new OracleParameter("pchkno", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;

                if (chkno == "" || chkno == "0")
                {
                    prm10.Value = System.DBNull.Value;
                }
                else
                {
                    prm10.Value = chkno;
                }

                objOraclecommand.Parameters.Add(prm10);



                OracleParameter prm11 = new OracleParameter("pchkdate", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                //string dateformat = "dd/mm/yyyy";
                if (chkdate == "" || chkdate == "0")
                {

                    prm11.Value = System.DBNull.Value;
                }
                else
                {

                    //if (dateformat == "dd/mm/yyyy")
                    //{
                    //    string[] tilldatearr = chkdate.Split('/');
                    //    string dd1 = tilldatearr[0].ToString();
                    //    string mm1 = tilldatearr[1].ToString();
                    //    string yy1 = tilldatearr[2].ToString();
                    //    chkdate = mm1 + "/" + dd1 + "/" + yy1;
                    //}

                    prm11.Value = Convert.ToDateTime(chkdate).ToString("dd-MMMM-yyyy");





                }

                objOraclecommand.Parameters.Add(prm11);


                OracleParameter prm12 = new OracleParameter("pchkamt", OracleType.VarChar, 50);
                prm12.Direction = ParameterDirection.Input;

                if (chkamt == "" || chkamt == "0")
                {
                    prm12.Value = System.DBNull.Value;

                }
                else
                {

                    prm12.Value = chkamt;
                }

                objOraclecommand.Parameters.Add(prm12);


                OracleParameter prm13 = new OracleParameter("pchkbankname", OracleType.VarChar, 50);
                prm13.Direction = ParameterDirection.Input;

                if (chkbankname == "" || chkbankname == "0")
                {

                    prm13.Value = System.DBNull.Value;
                }
                else
                {
                    prm13.Value = chkbankname;
                }

                objOraclecommand.Parameters.Add(prm13);


                objOraclecommand.ExecuteNonQuery();



                return "true";
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





        public DataSet bindpub(string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("bindpay", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("p_compcode", OracleType.VarChar, 50);
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






        public DataSet InsertCashDetailExternalSource(string cioid, string receipt, string compcode, string userid, string ip)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("InsertCashDetailExternalSource", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("cioid", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = cioid;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm1a = new OracleParameter("receipt", OracleType.VarChar, 50);
                prm1a.Direction = ParameterDirection.Input;
                prm1a.Value = receipt;
                objOraclecommand.Parameters.Add(prm1a);

                OracleParameter prm1b = new OracleParameter("compcode_p", OracleType.VarChar, 50);
                prm1b.Direction = ParameterDirection.Input;
                prm1b.Value = compcode;
                objOraclecommand.Parameters.Add(prm1b);

                OracleParameter prm1c = new OracleParameter("userid_p", OracleType.VarChar, 50);
                prm1c.Direction = ParameterDirection.Input;
                prm1c.Value = userid;
                objOraclecommand.Parameters.Add(prm1c);

                OracleParameter prm1d = new OracleParameter("ip", OracleType.VarChar, 50);
                prm1d.Direction = ParameterDirection.Input;
                prm1d.Value = ip;
                objOraclecommand.Parameters.Add(prm1d);


                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;



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
        public DataSet chkreci(string cioid,string compcode,string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("chkrecifrombooking", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("cioid", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = cioid;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);



                OracleParameter prm3 = new OracleParameter("userid_p", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userid;
                objOraclecommand.Parameters.Add(prm3);

                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

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
        public DataSet InsertCashDetail(string cioid,string bankcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("InsertCashDetail", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("cioid", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = cioid;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("pbankcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = bankcode;
                objOraclecommand.Parameters.Add(prm2);

                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

                

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
        //////////////////////////////////add by anuja for payment type
        public string updaterostatus1(string compcode, string paymode, string booking_id, string rcptno, string cardmonth, string cardyear, string cardname, string cardtype, string cardnumber, string chkno, string chkdate, string chkamt, string chkbankname, string buttontype, string username)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("updatecashrcpt1", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pcompcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("ppaymode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = paymode;
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("pbooking_id", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = booking_id;
                objOraclecommand.Parameters.Add(prm3);


                OracleParameter prm4 = new OracleParameter("prcptno", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = rcptno;
                objOraclecommand.Parameters.Add(prm4);





                OracleParameter prm5 = new OracleParameter("pcardmonth", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                if (cardmonth == "" || cardmonth == "0")
                {
                    prm5.Value = System.DBNull.Value;
                }
                else
                {
                    prm5.Value = cardmonth;
                }
                objOraclecommand.Parameters.Add(prm5);




                OracleParameter prm6 = new OracleParameter("pcardyear", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;

                if (cardyear == "" || cardyear == "0")
                {
                    prm6.Value = System.DBNull.Value;
                }
                else
                {
                    prm6.Value = cardyear;
                }


                objOraclecommand.Parameters.Add(prm6);



                OracleParameter prm7 = new OracleParameter("pcardname", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;

                if (cardname == "" || cardname == "0")
                {
                    prm7.Value = System.DBNull.Value;
                }
                else
                {
                    prm7.Value = cardname;
                }

                objOraclecommand.Parameters.Add(prm7);



                OracleParameter prm8 = new OracleParameter("pcardtype", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;

                if (cardtype == "" || cardtype == "0")
                {
                    prm8.Value = System.DBNull.Value;
                }
                else
                {
                    prm8.Value = cardtype;
                }
                objOraclecommand.Parameters.Add(prm8);



                OracleParameter prm9 = new OracleParameter("pcardnumber", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;

                if (cardnumber == "" || cardnumber == "0")
                {
                    prm9.Value = System.DBNull.Value;
                }
                else
                {
                    prm9.Value = cardnumber;
                }

                objOraclecommand.Parameters.Add(prm9);



                OracleParameter prm10 = new OracleParameter("pchkno", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;

                if (chkno == "" || chkno == "0")
                {
                    prm10.Value = System.DBNull.Value;
                }
                else
                {
                    prm10.Value = chkno;
                }

                objOraclecommand.Parameters.Add(prm10);



                OracleParameter prm11 = new OracleParameter("pchkdate", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                //string dateformat = "dd/mm/yyyy";
                if (chkdate == "" || chkdate == "0")
                {

                    prm11.Value = System.DBNull.Value;
                }
                else
                {

                    //if (dateformat == "dd/mm/yyyy")
                    //{
                    string[] tilldatearr = chkdate.Split('/');
                    string dd1 = tilldatearr[0].ToString();
                    string mm1 = tilldatearr[1].ToString();
                    string yy1 = tilldatearr[2].ToString();
                    chkdate = mm1 + "/" + dd1 + "/" + yy1;
                    // }

                    prm11.Value = Convert.ToDateTime(chkdate).ToString("dd-MMMM-yyyy");





                }

                objOraclecommand.Parameters.Add(prm11);


                OracleParameter prm12 = new OracleParameter("pchkamt", OracleType.VarChar, 50);
                prm12.Direction = ParameterDirection.Input;

                if (chkamt == "" || chkamt == "0")
                {
                    prm12.Value = System.DBNull.Value;

                }
                else
                {

                    prm12.Value = chkamt;
                }

                objOraclecommand.Parameters.Add(prm12);


                OracleParameter prm13 = new OracleParameter("pchkbankname", OracleType.VarChar, 50);
                prm13.Direction = ParameterDirection.Input;

                if (chkbankname == "" || chkbankname == "0")
                {

                    prm13.Value = System.DBNull.Value;
                }
                else
                {
                    prm13.Value = chkbankname;
                }

                objOraclecommand.Parameters.Add(prm13);

                OracleParameter prm3a = new OracleParameter("buttontype", OracleType.VarChar, 50);
                prm3a.Direction = ParameterDirection.Input;
                prm3a.Value = buttontype;
                objOraclecommand.Parameters.Add(prm3a);

                OracleParameter prm3z = new OracleParameter("username_p", OracleType.VarChar, 50);
                prm3z.Direction = ParameterDirection.Input;
                prm3z.Value = username;
                objOraclecommand.Parameters.Add(prm3z);

                objOraclecommand.ExecuteNonQuery();



                return "true";
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

        public DataSet InsertCashDetailmulti1(string cioid, string idofbutton, string paymode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("InsertCashDetailmulti1", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("cioid", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = cioid;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm11 = new OracleParameter("idofbutton", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = idofbutton;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm11a = new OracleParameter("paymode_p", OracleType.VarChar, 50);
                prm11a.Direction = ParameterDirection.Input;
                prm11a.Value = paymode;
                objOraclecommand.Parameters.Add(prm11a);


                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;



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
        public DataSet reciptget(string compcode, string bkid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("findrecieptno", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pCompCode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm11 = new OracleParameter("pbookingid", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = bkid;
                objOraclecommand.Parameters.Add(prm11);


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