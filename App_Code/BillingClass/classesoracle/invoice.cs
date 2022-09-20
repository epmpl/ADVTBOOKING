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
    /// Summary description for invoice
    /// </summary>
    public class invoice : orclconnection
    {
        public invoice()
        {
            //
            // TODO: Add constructor logic here
            //
        }





  public DataSet fetchnextvalue()
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand = new OracleCommand();
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {

                objOracleConnection.Open();
                string query = "select TBL_BILLING_SEQ.nextval as newPass from dual";
                objOraclecommand.CommandText = query;
                objOraclecommand.Connection = objOracleConnection;
                //cmd.ExecuteNonQuery();

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


        public DataSet edition(string editioncode, string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_selectedition", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;
               

                 OracleParameter prm2 = new OracleParameter("editoncode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = editioncode;
                objOraclecommand.Parameters.Add(prm2);

               

                
                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);


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
                objOraclecommand = GetCommand("websp_packagecode", ref objOracleConnection);
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
        /////////



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






        public DataSet invoice_no(string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("getautoinvoiceno", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);


                objOraclecommand.Parameters.Add("P_GetLogin", OracleType.Cursor);
                objOraclecommand.Parameters["P_GetLogin"].Direction = ParameterDirection.Output;

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


        public DataSet invoice_no_pune(string compcode, string from_date, string date_format, string cond_flag)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("getautoinvoiceno_pune", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("pfrom_date", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                if (from_date=="")
                {
                    prm2.Value = System.DBNull.Value;
                }
                else
                {
                    if (date_format == "dd/mm/yyyy")
                    {
                        string[] arr = from_date.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        from_date = mm + "/" + dd + "/" + yy;


                    }
                    prm2.Value = Convert.ToDateTime(from_date).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("pdate_format", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = date_format;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm13 = new OracleParameter("pcond_flag", OracleType.VarChar, 50);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = cond_flag;
                objOraclecommand.Parameters.Add(prm13);
                


                objOraclecommand.Parameters.Add("P_GetLogin", OracleType.Cursor);
                objOraclecommand.Parameters["P_GetLogin"].Direction = ParameterDirection.Output;

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

                
        //////


     
        public DataSet values_bill(string ciobooking, string editionname, string insertion, string compcode, string dateformat)
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


                objOraclecommand = GetCommand("websp_selectvaluesnew", ref objOracleConnection);
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
                prm4.Value = Convert .ToInt16 (insertion);
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

        public DataSet editiondate(string editioncode, string bookingid, string compcode, string dateformat)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_selecteditiondate", ref objOracleConnection);
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

        public DataSet bindaddress(string compcode, string unit, string extra1, string extra2)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("adgetbindaddress", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm2 = new OracleParameter("pcompcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3=new OracleParameter("punit", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value  = unit;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("pextra1", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = extra1;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("pextra2", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = extra2;
                objOraclecommand.Parameters.Add(prm5);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return objDataSet;




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