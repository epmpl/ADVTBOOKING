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

namespace NewAdbooking.BillingClass.classesoracle
{

    /// <summary>
    /// Summary description for billing_save_supp
    /// </summary>
    public class billing_save_supp : orclconnection
    {
        public billing_save_supp()
        {
            //
            // TODO: Add constructor logic here
            //
        }






        public DataSet selectclassified_bill(string agcode, string fromdate, string dateto, string bookingid, string Client, string dateformat)
        {
            OracleConnection con;
            OracleCommand com;
            DataSet objDataSet = new DataSet();
            con = GetConnection();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {
                con.Open();
                com = GetCommand("websp_classified_bill", ref con);
                com.CommandType = CommandType.StoredProcedure;




                OracleParameter prm21 = new OracleParameter("agcode", OracleType.VarChar);
                prm21.Direction = ParameterDirection.Input;
                prm21.Value = agcode;
                com.Parameters.Add(prm21);

                OracleParameter prm22 = new OracleParameter("fromdate", OracleType.VarChar);
                prm22.Direction = ParameterDirection.Input;
                if (fromdate == "")
                {
                    prm22.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = fromdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        fromdate = mm + "/" + dd + "/" + yy;
                    }
                    prm22.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");

                }

                com.Parameters.Add(prm22);

                OracleParameter prm23 = new OracleParameter("dateto", OracleType.VarChar);
                prm23.Direction = ParameterDirection.Input;
                if (dateto == "")
                {
                    prm23.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = dateto.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        dateto = mm + "/" + dd + "/" + yy;
                    }
                    prm23.Value = Convert.ToDateTime(dateto).ToString("dd-MMMM-yyyy");

                }

                com.Parameters.Add(prm23);

                OracleParameter prm24 = new OracleParameter("bookingid", OracleType.VarChar);
                prm24.Direction = ParameterDirection.Input;
                prm24.Value = bookingid;
                com.Parameters.Add(prm24);


                OracleParameter prm32 = new OracleParameter("Client", OracleType.VarChar);
                prm32.Direction = ParameterDirection.Input;
                if (Client == "")
                {
                    prm32.Value = System.DBNull.Value;

                }
                else
                {
                    prm32.Value = Client;
                }
                com.Parameters.Add(prm32);

                OracleParameter prm20 = new OracleParameter("dateformat", OracleType.VarChar);
                prm20.Direction = ParameterDirection.Input;
                prm20.Value = dateformat;
                com.Parameters.Add(prm20);




                com.Parameters.Add("p_classs", OracleType.Cursor);
                com.Parameters["p_classs"].Direction = ParameterDirection.Output;

                com.Parameters.Add("p_classs1", OracleType.Cursor);
                com.Parameters["p_classs1"].Direction = ParameterDirection.Output;

                com.Parameters.Add("p_classs2", OracleType.Cursor);
                com.Parameters["p_classs2"].Direction = ParameterDirection.Output;



                da.SelectCommand = com;
                da.Fill(objDataSet);
                return objDataSet;


            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref con);
            }
        }




        public DataSet packagecode_bill(string ciobookingid, string compcode, string dateformat)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("Websp_Packagecode_bill", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm2 = new OracleParameter("ciobooking", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = ciobookingid;
                objOraclecommand.Parameters.Add(prm2);




                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm3 = new OracleParameter("dateformat", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = dateformat;
                objOraclecommand.Parameters.Add(prm3);



                objOraclecommand.Parameters.Add("p_getbookingrecord", OracleType.Cursor);
                objOraclecommand.Parameters["p_getbookingrecord"].Direction = ParameterDirection.Output;

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


        public DataSet editiondate_bill(string editioncode, string bookingid, string compcode, string dateformat)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_selecteditiondate_bill", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm2 = new OracleParameter("editoncode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = editioncode;
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("bookingid", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = bookingid;
                objOraclecommand.Parameters.Add(prm3);





                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);



                OracleParameter prm5 = new OracleParameter("dateformat", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = dateformat;
                objOraclecommand.Parameters.Add(prm5);

                objOraclecommand.Parameters.Add("P_GetUserRecord", OracleType.Cursor);
                objOraclecommand.Parameters["P_GetUserRecord"].Direction = ParameterDirection.Output;

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






        public DataSet saveininsertion_bill(string orderno, string invoice1, string amountforvat, string amt3, double boxchg1, int insnum_cou, string doctyp, string maxinsert, string dateformat, string chk_billtype)
        {
            OracleConnection con;
            OracleCommand com;
            DataSet objDataSet = new DataSet();
            con = GetConnection();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {

                con.Open();
                com = GetCommand("Bill_Saveinsert_bill", ref con);
                com.CommandType = CommandType.StoredProcedure;



                OracleParameter prm21 = new OracleParameter("orderno1", OracleType.VarChar);
                prm21.Direction = ParameterDirection.Input;
                prm21.Value = orderno;
                com.Parameters.Add(prm21);



                OracleParameter prm22 = new OracleParameter("invoice1", OracleType.VarChar);
                prm22.Direction = ParameterDirection.Input;
                prm22.Value = invoice1;
                com.Parameters.Add(prm22);


                OracleParameter prm23 = new OracleParameter("amountforvat", OracleType.VarChar);
                prm23.Direction = ParameterDirection.Input;
                prm23.Value = amountforvat;
                com.Parameters.Add(prm23);


                OracleParameter prm24 = new OracleParameter("amt3", OracleType.VarChar);
                prm24.Direction = ParameterDirection.Input;
                prm24.Value = amt3;
                com.Parameters.Add(prm24);

                OracleParameter prm25 = new OracleParameter("boxchg1", OracleType.VarChar);
                prm25.Direction = ParameterDirection.Input;
                prm25.Value = boxchg1;
                com.Parameters.Add(prm25);
                OracleParameter prm26 = new OracleParameter("insnum_cou", OracleType.Number);
                prm26.Direction = ParameterDirection.Input;
                prm26.Value = insnum_cou;
                com.Parameters.Add(prm26);

                OracleParameter prm111 = new OracleParameter("doctyp", OracleType.VarChar);
                prm111.Direction = ParameterDirection.Input;
                prm111.Value = doctyp;
                com.Parameters.Add(prm111);

                OracleParameter prm112 = new OracleParameter("maxinsert", OracleType.VarChar);
                prm112.Direction = ParameterDirection.Input;
                prm112.Value = maxinsert;
                com.Parameters.Add(prm112);



                OracleParameter prm113 = new OracleParameter("chk_billtype", OracleType.VarChar);
                prm113.Direction = ParameterDirection.Input;
                prm113.Value = chk_billtype;
                com.Parameters.Add(prm113);


                //OracleParameter prm27 = new OracleParameter("todate", OracleType.VarChar);
                //prm27.Direction = ParameterDirection.Input;

                //if (dateto == "" || dateto == null)
                //{
                //    prm27.Value = System.DBNull.Value;

                //}
                //else
                //{
                //    if (dateformat == "dd/mm/yyyy")
                //    {
                //        string[] arr = dateto.Split('/');
                //        string dd = arr[0];
                //        string mm = arr[1];
                //        string yy = arr[2];
                //        dateto = mm + "/" + dd + "/" + yy;


                //    }
                //    prm27.Value = Convert.ToDateTime(dateto).ToString("dd-MMMM-yyyy");

                //}
                //com.Parameters.Add(prm27);



                da.SelectCommand = com;
                da.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref con);
            }
        }





        public DataSet save_det_insert_bill(string orderno, string invoice1, string grossamt, double billamt, double boxchg1, string ins_num, string edition_name, string insertid)
        {
            OracleConnection con;
            OracleCommand com;
            DataSet objDataSet = new DataSet();
            con = GetConnection();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {

                con.Open();
                com = GetCommand("bill_save_det_insert23_bill", ref con);
                com.CommandType = CommandType.StoredProcedure;



                OracleParameter prm21 = new OracleParameter("orderno1", OracleType.VarChar);
                prm21.Direction = ParameterDirection.Input;
                prm21.Value = orderno;
                com.Parameters.Add(prm21);



                OracleParameter prm22 = new OracleParameter("invoice1", OracleType.VarChar);
                prm22.Direction = ParameterDirection.Input;
                prm22.Value = invoice1;
                com.Parameters.Add(prm22);


                OracleParameter prm23 = new OracleParameter("amountforvat", OracleType.VarChar);
                prm23.Direction = ParameterDirection.Input;
                prm23.Value = Convert.ToDecimal(grossamt);
                com.Parameters.Add(prm23);



                OracleParameter prm113 = new OracleParameter("edition_name", OracleType.VarChar);
                prm113.Direction = ParameterDirection.Input;
                prm113.Value = edition_name;
                com.Parameters.Add(prm113);




                OracleParameter prm25 = new OracleParameter("boxchg1", OracleType.VarChar);
                prm25.Direction = ParameterDirection.Input;
                prm25.Value = Convert.ToDecimal(boxchg1);
                com.Parameters.Add(prm25);







                OracleParameter prm114 = new OracleParameter("noofinsert", OracleType.VarChar);
                prm114.Direction = ParameterDirection.Input;
                prm114.Value = Convert.ToDecimal(ins_num);
                com.Parameters.Add(prm114);





                //OracleParameter prm24 = new OracleParameter("todate", OracleType.VarChar);
                //prm24.Direction = ParameterDirection.Input;
                //if (maxdate == "")
                //{
                //    prm24.Value = System.DBNull.Value;
                //}
                //else
                //{
                //    if (dateformat == "dd/mm/yyyy")
                //    {
                //        string[] arr = maxdate.Split('/');
                //        string dd = arr[0];
                //        string mm = arr[1];
                //        string yy = arr[2];
                //        maxdate = mm + "/" + dd + "/" + yy;
                //    }
                //    prm24.Value = Convert.ToDateTime(maxdate).ToString("dd-MMMM-yyyy");

                //}

                //com.Parameters.Add(prm24);







                OracleParameter prm125 = new OracleParameter("insertid", OracleType.VarChar);
                prm125.Direction = ParameterDirection.Input;
                prm125.Value = insertid;
                com.Parameters.Add(prm125);







                da.SelectCommand = com;
                da.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref con);
            }
        }
















        public DataSet selectinvoicefmadbills_ins(string ciobooking, string insertion)
        {
            OracleConnection con;
            OracleCommand com;
            DataSet objDataSet = new DataSet();
            con = GetConnection();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {
                con.Open();
                com = GetCommand("websp_selectinvoiceno11.websp_selectinvoiceno11_p", ref con);
                com.CommandType = CommandType.StoredProcedure;

                OracleParameter prm22 = new OracleParameter("ciobooking", OracleType.VarChar);
                prm22.Direction = ParameterDirection.Input;
                prm22.Value = ciobooking;
                com.Parameters.Add(prm22);


                OracleParameter prm24 = new OracleParameter("insertion", OracleType.VarChar);
                prm24.Direction = ParameterDirection.Input;
                prm24.Value = insertion;
                com.Parameters.Add(prm24);



                com.Parameters.Add("p_accounts", OracleType.Cursor);
                com.Parameters["p_accounts"].Direction = ParameterDirection.Output;



                da.SelectCommand = com;
                da.Fill(objDataSet);
                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref con);
            }
        }

        public DataSet packagecode(string ciobookingid, string compcode,string dateformat)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("Websp_Packagecode_bill", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm2 = new OracleParameter("ciobooking", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = ciobookingid;
                objOraclecommand.Parameters.Add(prm2);




                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);


                  OracleParameter prm3 = new OracleParameter("dateformat", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = dateformat;
                objOraclecommand.Parameters.Add(prm3);


                





                objOraclecommand.Parameters.Add("p_getbookingrecord", OracleType.Cursor);
                objOraclecommand.Parameters["p_getbookingrecord"].Direction = ParameterDirection.Output;

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






        public DataSet values_bill_supp(string ciobooking, string editionname, string insertion, string compcode, string dateformat)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                //objOraclecommand = GetCommand("websp_selectvalues1.websp_selectvalues1_p", ref objOracleConnection);
                //objOraclecommand.CommandType = CommandType.StoredProcedure;


                objOraclecommand = GetCommand("Websp_Selectvaluesnew_bill", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("ciobooking", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = ciobooking;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("editionname", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = editionname;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = compcode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("insertion", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = Convert.ToInt16(insertion);
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("dateformat", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = dateformat;
                objOraclecommand.Parameters.Add(prm5);


                objOraclecommand.Parameters.Add("p_getbookingrecord", OracleType.Cursor);
                objOraclecommand.Parameters["p_getbookingrecord"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts1"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("P_ACCOUNTS2", OracleType.Cursor);
                objOraclecommand.Parameters["P_ACCOUNTS2"].Direction = ParameterDirection.Output;


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

        public DataSet selectbranchalias(string branchname)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("selectbranchalias", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pbranch_code", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = branchname;
                objOraclecommand.Parameters.Add(prm1);



                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;





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


        public DataSet checkReceiptno(string compcode, string prefix, string suffix)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("chkreceiptno.chkreceiptno_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pcompcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("p_prefix_recpt", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = prefix;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("p_sufix_recpt", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                if (suffix == "")
                {
                    prm3.Value = System.DBNull.Value;
                }
                else
                {
                    prm3.Value = suffix;
                }
                objOraclecommand.Parameters.Add(prm3);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;



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



        public DataSet save_det_new1_bill(string orderno, string invoice1, string grossamt, double billamt, double boxchg1, string ins_num, string edition_name, string dateto, string dateformat, string insert_id)
        {
            OracleConnection con;
            OracleCommand com;
            DataSet objDataSet = new DataSet();
            con = GetConnection();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {

                con.Open();
                com = GetCommand("bill_save_det_classi_bill", ref con);
                com.CommandType = CommandType.StoredProcedure;



                OracleParameter prm21 = new OracleParameter("orderno1", OracleType.VarChar);
                prm21.Direction = ParameterDirection.Input;
                prm21.Value = orderno;
                com.Parameters.Add(prm21);



                OracleParameter prm22 = new OracleParameter("invoice1", OracleType.VarChar);
                prm22.Direction = ParameterDirection.Input;
                prm22.Value = invoice1;
                com.Parameters.Add(prm22);


                OracleParameter prm23 = new OracleParameter("amountforvat", OracleType.VarChar);
                prm23.Direction = ParameterDirection.Input;
                prm23.Value = Convert.ToDecimal(grossamt);
                com.Parameters.Add(prm23);



                OracleParameter prm113 = new OracleParameter("edition_name", OracleType.VarChar);
                prm113.Direction = ParameterDirection.Input;
                prm113.Value = edition_name;
                com.Parameters.Add(prm113);




                OracleParameter prm25 = new OracleParameter("boxchg1", OracleType.VarChar);
                prm25.Direction = ParameterDirection.Input;
                prm25.Value = Convert.ToDecimal(boxchg1);
                com.Parameters.Add(prm25);







                OracleParameter prm114 = new OracleParameter("noofinsert", OracleType.VarChar);
                prm114.Direction = ParameterDirection.Input;
                prm114.Value = Convert.ToDecimal(ins_num);
                com.Parameters.Add(prm114);





                OracleParameter prm123 = new OracleParameter("todate", OracleType.VarChar);
                prm123.Direction = ParameterDirection.Input;
                if (dateto == "")
                {
                    prm123.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = dateto.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        dateto = mm + "/" + dd + "/" + yy;
                    }
                    prm123.Value = Convert.ToDateTime(dateto).ToString("dd-MMMM-yyyy");

                }

                com.Parameters.Add(prm123);


                OracleParameter prm118 = new OracleParameter("v_insert_id", OracleType.VarChar);
                prm118.Direction = ParameterDirection.Input;
                prm118.Value = insert_id;
                com.Parameters.Add(prm118);


















                da.SelectCommand = com;
                da.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref con);
            }
        }





        public DataSet saveinclassified_bill(string orderno, string invoice1, string amountforvat, string amt3, double boxchg1, int insnum_cou, string doctyp, string maxinsert)
        {
            OracleConnection con;
            OracleCommand com;
            DataSet objDataSet = new DataSet();
            con = GetConnection();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {

                con.Open();
                com = GetCommand("bill_saveclassified", ref con);
                com.CommandType = CommandType.StoredProcedure;



                OracleParameter prm21 = new OracleParameter("orderno1", OracleType.VarChar);
                prm21.Direction = ParameterDirection.Input;
                prm21.Value = orderno;
                com.Parameters.Add(prm21);



                OracleParameter prm22 = new OracleParameter("invoice1", OracleType.VarChar);
                prm22.Direction = ParameterDirection.Input;
                prm22.Value = invoice1;
                com.Parameters.Add(prm22);


                OracleParameter prm23 = new OracleParameter("amountforvat", OracleType.VarChar);
                prm23.Direction = ParameterDirection.Input;
                prm23.Value = amountforvat;
                com.Parameters.Add(prm23);


                OracleParameter prm24 = new OracleParameter("amt3", OracleType.VarChar);
                prm24.Direction = ParameterDirection.Input;
                prm24.Value = amt3;
                com.Parameters.Add(prm24);

                OracleParameter prm25 = new OracleParameter("boxchg1", OracleType.VarChar);
                prm25.Direction = ParameterDirection.Input;
                prm25.Value = boxchg1;
                com.Parameters.Add(prm25);
                OracleParameter prm26 = new OracleParameter("insnum_cou", OracleType.Number);
                prm26.Direction = ParameterDirection.Input;
                prm26.Value = insnum_cou;
                com.Parameters.Add(prm26);

                OracleParameter prm111 = new OracleParameter("doctyp", OracleType.VarChar);
                prm111.Direction = ParameterDirection.Input;
                prm111.Value = doctyp;
                com.Parameters.Add(prm111);

                OracleParameter prm112 = new OracleParameter("maxinsert", OracleType.VarChar);
                prm112.Direction = ParameterDirection.Input;
                prm112.Value = maxinsert;
                com.Parameters.Add(prm112);




                da.SelectCommand = com;
                da.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref con);
            }
        }





    }
}