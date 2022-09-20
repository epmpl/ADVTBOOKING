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

    public class save_det_orderwiselast : orclconnection
    {
        public save_det_orderwiselast()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataSet bill_save_data_orderwiselast(string pcompcode,string pcenter,string porderno,string pinsertion_no,string pbill_cycle,string puserid,string pfrom_date,string ptill_date,string pbill_date,string pdateformat,string pnoofinsert,string pprefix,string pextra1,string pextra2,string pextra3,string pextra4,string pextra5)
        {
            OracleConnection con;
            OracleCommand com;
            DataSet objDataSet = new DataSet();
            con = GetConnection();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {

                con.Open();
                com = GetCommand("bill_save_data_orderwiselast", ref con);
                com.CommandType = CommandType.StoredProcedure;



                OracleParameter prm1 = new OracleParameter("pcompcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = pcompcode;
                com.Parameters.Add(prm1);



                OracleParameter prm2 = new OracleParameter("pcenter", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = pcenter;
                com.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("porderno", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = porderno;
                com.Parameters.Add(prm3);



                OracleParameter prm4 = new OracleParameter("pinsertion_no", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = pinsertion_no;
                com.Parameters.Add(prm4);




                OracleParameter prm5 = new OracleParameter("pbill_cycle", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = pbill_cycle;
                com.Parameters.Add(prm5);







                OracleParameter prm6 = new OracleParameter("puserid", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = puserid;
                com.Parameters.Add(prm6);





                OracleParameter prm7 = new OracleParameter("pfrom_date", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                if (pfrom_date == "")
                {
                    prm7.Value = System.DBNull.Value;
                }
                else
                {
                    if (pdateformat == "dd/mm/yyyy")
                    {
                        string[] arr = pfrom_date.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        pfrom_date = mm + "/" + dd + "/" + yy;
                    }
                    prm7.Value = Convert.ToDateTime(pfrom_date).ToString("dd-MMMM-yyyy");

                }

                com.Parameters.Add(prm7);


                OracleParameter prm8 = new OracleParameter("ptill_date", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                if (ptill_date == "")
                {
                    prm8.Value = System.DBNull.Value;
                }
                else
                {
                    if (pdateformat == "dd/mm/yyyy")
                    {
                        string[] arr = ptill_date.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        ptill_date = mm + "/" + dd + "/" + yy;
                    }
                    prm8.Value = Convert.ToDateTime(ptill_date).ToString("dd-MMMM-yyyy");

                }

                com.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("pbill_date", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                if (pbill_date == "")
                {
                    prm9.Value = System.DBNull.Value;
                }
                else
                {
                    if (pdateformat == "dd/mm/yyyy")
                    {
                        string[] arr = pbill_date.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        pbill_date = mm + "/" + dd + "/" + yy;
                    }
                    prm9.Value = Convert.ToDateTime(pbill_date).ToString("dd-MMMM-yyyy");

                }                
                com.Parameters.Add(prm9);


                OracleParameter prm10 = new OracleParameter("pdateformat", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = pdateformat;
                com.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("pnoofinsert", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = pnoofinsert;
                com.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("pprefix", OracleType.VarChar);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = pprefix;
                com.Parameters.Add(prm12);

                OracleParameter prm13 = new OracleParameter("pextra1", OracleType.VarChar);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = pextra1;
                com.Parameters.Add(prm13);


                OracleParameter prm14 = new OracleParameter("pextra2", OracleType.VarChar);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = pextra2;
                com.Parameters.Add(prm14);


                OracleParameter prm15 = new OracleParameter("pextra3", OracleType.VarChar);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = pextra3;
                com.Parameters.Add(prm15);

                OracleParameter prm16 = new OracleParameter("pextra4", OracleType.VarChar);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = pextra4;
                com.Parameters.Add(prm16);


                OracleParameter prm17 = new OracleParameter("pextra5", OracleType.VarChar);
                prm17.Direction = ParameterDirection.Input;
                prm17.Value = pextra5;
                com.Parameters.Add(prm17);


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
       
        
        public DataSet bill_save_data_insertionwise(string pcompcode, string pcenter, string porderno, string pinsertion_no, string pbill_cycle, string puserid, string pfrom_date, string ptill_date, string pbill_date, string pdateformat, string pnoofinsert, string pprefix, string pextra1, string pextra2, string pextra3, string pextra4, string pextra5)
        {
            OracleConnection con;
            OracleCommand com;
            DataSet objDataSet = new DataSet();
            con = GetConnection();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {

                con.Open();
                com = GetCommand("bill_save_insertionwise_new", ref con);
                com.CommandType = CommandType.StoredProcedure;



                OracleParameter prm1 = new OracleParameter("pcompcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = pcompcode;
                com.Parameters.Add(prm1);



                OracleParameter prm2 = new OracleParameter("pcenter", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = pcenter;
                com.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("porderno", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = porderno;
                com.Parameters.Add(prm3);



                OracleParameter prm4 = new OracleParameter("pinsertion_no", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = pinsertion_no;
                com.Parameters.Add(prm4);




                OracleParameter prm5 = new OracleParameter("pbill_cycle", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = pbill_cycle;
                com.Parameters.Add(prm5);







                OracleParameter prm6 = new OracleParameter("puserid", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = puserid;
                com.Parameters.Add(prm6);





                OracleParameter prm7 = new OracleParameter("pfrom_date", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                if (pfrom_date == "")
                {
                    prm7.Value = System.DBNull.Value;
                }
                else
                {
                    if (pdateformat == "dd/mm/yyyy")
                    {
                        string[] arr = pfrom_date.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        pfrom_date = mm + "/" + dd + "/" + yy;
                    }
                    prm7.Value = Convert.ToDateTime(pfrom_date).ToString("dd-MMMM-yyyy");

                }

                com.Parameters.Add(prm7);


                OracleParameter prm8 = new OracleParameter("ptill_date", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                if (ptill_date == "")
                {
                    prm8.Value = System.DBNull.Value;
                }
                else
                {
                    if (pdateformat == "dd/mm/yyyy")
                    {
                        string[] arr = ptill_date.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        ptill_date = mm + "/" + dd + "/" + yy;
                    }
                    prm8.Value = Convert.ToDateTime(ptill_date).ToString("dd-MMMM-yyyy");

                }

                com.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("pbill_date", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                if (pbill_date == "")
                {
                    prm9.Value = System.DBNull.Value;
                }
                else
                {
                    if (pdateformat == "dd/mm/yyyy")
                    {
                        string[] arr = pbill_date.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        ptill_date = mm + "/" + dd + "/" + yy;
                    }
                    prm9.Value = Convert.ToDateTime(pbill_date).ToString("dd-MMMM-yyyy");

                }
                com.Parameters.Add(prm9);


                OracleParameter prm10 = new OracleParameter("pdateformat", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = pdateformat;
                com.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("pnoofinsert", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = pnoofinsert;
                com.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("pprefix", OracleType.VarChar);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = pprefix;
                com.Parameters.Add(prm12);

                OracleParameter prm13 = new OracleParameter("pextra1", OracleType.VarChar);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = pextra1;
                com.Parameters.Add(prm13);


                OracleParameter prm14 = new OracleParameter("pextra2", OracleType.VarChar);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = pextra2;
                com.Parameters.Add(prm14);


                OracleParameter prm15 = new OracleParameter("pextra3", OracleType.VarChar);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = pextra3;
                com.Parameters.Add(prm15);

                OracleParameter prm16 = new OracleParameter("pextra4", OracleType.VarChar);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = pextra4;
                com.Parameters.Add(prm16);


                OracleParameter prm17 = new OracleParameter("pextra5", OracleType.VarChar);
                prm17.Direction = ParameterDirection.Input;
                prm17.Value = pextra5;
                com.Parameters.Add(prm17);


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


        public DataSet bill_save_data_orderwisefirst(string pcompcode, string pcenter, string porderno, string pinsertion_no, string pbill_cycle, string puserid, string pfrom_date, string ptill_date, string pbill_date, string pdateformat, string pnoofinsert, string pprefix, string pextra1, string pextra2, string pextra3, string pextra4, string pextra5)
        {
            OracleConnection con;
            OracleCommand com;
            DataSet objDataSet = new DataSet();
            con = GetConnection();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {

                con.Open();
                com = GetCommand("bill_save_data_orderwisefirst", ref con);
                com.CommandType = CommandType.StoredProcedure;



                OracleParameter prm1 = new OracleParameter("pcompcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = pcompcode;
                com.Parameters.Add(prm1);



                OracleParameter prm2 = new OracleParameter("pcenter", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = pcenter;
                com.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("porderno", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = porderno;
                com.Parameters.Add(prm3);



                OracleParameter prm4 = new OracleParameter("pinsertion_no", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = pinsertion_no;
                com.Parameters.Add(prm4);




                OracleParameter prm5 = new OracleParameter("pbill_cycle", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = pbill_cycle;
                com.Parameters.Add(prm5);







                OracleParameter prm6 = new OracleParameter("puserid", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = puserid;
                com.Parameters.Add(prm6);





                OracleParameter prm7 = new OracleParameter("pfrom_date", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                if (pfrom_date == "")
                {
                    prm7.Value = System.DBNull.Value;
                }
                else
                {
                    if (pdateformat == "dd/mm/yyyy")
                    {
                        string[] arr = pfrom_date.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        pfrom_date = mm + "/" + dd + "/" + yy;
                    }
                    prm7.Value = Convert.ToDateTime(pfrom_date).ToString("dd-MMMM-yyyy");

                }

                com.Parameters.Add(prm7);


                OracleParameter prm8 = new OracleParameter("ptill_date", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                if (ptill_date == "")
                {
                    prm8.Value = System.DBNull.Value;
                }
                else
                {
                    if (pdateformat == "dd/mm/yyyy")
                    {
                        string[] arr = ptill_date.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        ptill_date = mm + "/" + dd + "/" + yy;
                    }
                    prm8.Value = Convert.ToDateTime(ptill_date).ToString("dd-MMMM-yyyy");

                }

                com.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("pbill_date", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                if (pbill_date == "")
                {
                    prm9.Value = System.DBNull.Value;
                }
                else
                {
                    if (pdateformat == "dd/mm/yyyy")
                    {
                        string[] arr = pbill_date.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        pbill_date = mm + "/" + dd + "/" + yy;
                    }
                    prm9.Value = Convert.ToDateTime(pbill_date).ToString("dd-MMMM-yyyy");

                }
                com.Parameters.Add(prm9);


                OracleParameter prm10 = new OracleParameter("pdateformat", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = pdateformat;
                com.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("pnoofinsert", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = pnoofinsert;
                com.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("pprefix", OracleType.VarChar);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = pprefix;
                com.Parameters.Add(prm12);

                OracleParameter prm13 = new OracleParameter("pextra1", OracleType.VarChar);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = pextra1;
                com.Parameters.Add(prm13);


                OracleParameter prm14 = new OracleParameter("pextra2", OracleType.VarChar);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = pextra2;
                com.Parameters.Add(prm14);


                OracleParameter prm15 = new OracleParameter("pextra3", OracleType.VarChar);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = pextra3;
                com.Parameters.Add(prm15);

                OracleParameter prm16 = new OracleParameter("pextra4", OracleType.VarChar);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = pextra4;
                com.Parameters.Add(prm16);


                OracleParameter prm17 = new OracleParameter("pextra5", OracleType.VarChar);
                prm17.Direction = ParameterDirection.Input;
                prm17.Value = pextra5;
                com.Parameters.Add(prm17);


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
       
    
    }
}
