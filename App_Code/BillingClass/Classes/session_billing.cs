using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

/// <summary>
/// Summary description for session_billing
/// </summary>
/// 
namespace NewAdbooking.BillingClass.Classes
{
    public class session_billing : NewAdbooking.Classes.connection
    {
        public session_billing()
        {
            //
            // TODO: Add constructor logic here
            //
        }





        public string saveinlast_vision(string orderno, string invoice1, string amountforvat, string amt3, double boxchg1, int insnum_cou, string doctyp, string maxinsert, string dateto, string dateformat, string chk_billtype, string unique_number)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {


                con.Open();
                com = GetCommand("Bill_Savelast_vision", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@orderno1", SqlDbType.VarChar);
                com.Parameters["@orderno1"].Value = orderno;



                com.Parameters.Add("@invoice1", SqlDbType.VarChar);
                com.Parameters["@invoice1"].Value = invoice1;

                com.Parameters.Add("@amountforvat", SqlDbType.Float);
                com.Parameters["@amountforvat"].Value = amountforvat;

                com.Parameters.Add("@amt3", SqlDbType.Float);
                com.Parameters["@amt3"].Value = amt3;

                com.Parameters.Add("@insnum_cou", SqlDbType.Float);
                com.Parameters["@insnum_cou"].Value = insnum_cou;


                com.Parameters.Add("@boxchg1", SqlDbType.VarChar);
                com.Parameters["@boxchg1"].Value = boxchg1;

                com.Parameters.Add("@doctyp", SqlDbType.VarChar);
                com.Parameters["@doctyp"].Value = doctyp;

                com.Parameters.Add("@todate", SqlDbType.VarChar);
                if (dateto == "" || dateto == null)
                {
                    com.Parameters["@todate"].Value = System.DBNull.Value;
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

                    com.Parameters["@todate"].Value = dateto;
                }


                com.Parameters.Add("@maxinsert", SqlDbType.VarChar);
                com.Parameters["@maxinsert"].Value = maxinsert;

                com.Parameters.Add("@chk_billtype", SqlDbType.VarChar);
                com.Parameters["@chk_billtype"].Value = chk_billtype;





                com.Parameters.Add("@unique_number", SqlDbType.VarChar);
                com.Parameters["@unique_number"].Value = unique_number;




                da.SelectCommand = com;
                da.Fill(ds);
                return "Success";
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




        public string save_det_monthly_vision(string orderno, string invoice1, string grossamt, double billamt, double boxchg1, string ins_num, string edition_name, string maxdate, string dateformat, string insert_id, string chk_billtype)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {


                con.Open();
                com = GetCommand("bill_save_det_monthly_vision", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@orderno1", SqlDbType.VarChar);
                com.Parameters["@orderno1"].Value = orderno;



                com.Parameters.Add("@invoice1", SqlDbType.VarChar);
                com.Parameters["@invoice1"].Value = invoice1;

                com.Parameters.Add("@amountforvat", SqlDbType.Float);
                com.Parameters["@amountforvat"].Value = Convert.ToDecimal(grossamt);

                com.Parameters.Add("@edition_name", SqlDbType.VarChar);
                if (edition_name == "0")
                {
                    com.Parameters["@edition_name"].Value = System.DBNull.Value;
                }
                else
                {
                    com.Parameters["@edition_name"].Value = edition_name;
                }



                com.Parameters.Add("@boxchg1", SqlDbType.VarChar);
                com.Parameters["@boxchg1"].Value = boxchg1;

                com.Parameters.Add("@noofinsert", SqlDbType.VarChar);
                com.Parameters["@noofinsert"].Value = Convert.ToDecimal(ins_num);



                com.Parameters.Add("@todate", SqlDbType.VarChar);
                if (maxdate == "" || maxdate == null)
                {
                    com.Parameters["@todate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = maxdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        maxdate = mm + "/" + dd + "/" + yy;
                    }

                    com.Parameters["@todate"].Value = maxdate;
                }



                com.Parameters.Add("@v_insert_id", SqlDbType.VarChar);
                com.Parameters["@v_insert_id"].Value = insert_id;


                com.Parameters.Add("@chk_billtype", SqlDbType.VarChar);
                com.Parameters["@chk_billtype"].Value = chk_billtype;






                da.SelectCommand = com;
                da.Fill(ds);
                return "Success";
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

        public DataSet ad_get_backdays_validate(string pcomp_code, string pformname, string puserid, string pentry_date, string pdateformat, string pextra1, string pextra2)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand = new SqlCommand();
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            {
                try
                {

                    objSqlConnection.Open();
                    string query = "select ad_get_backdays_validate('" + pcomp_code + "','" + pformname + "','" + puserid + "','" + pentry_date + "','" + pdateformat + "','" + pextra1 + "','" + pextra2 + "') AS CHKDATE";
                    objSqlCommand.CommandText = query;
                    objSqlCommand.Connection = objSqlConnection;
                    //cmd.ExecuteNonQuery();

                    objSqlDataAdapter.SelectCommand = objSqlCommand;
                    objSqlDataAdapter.Fill(objDataSet);
                    return objDataSet;



                }
                catch (Exception objException)
                {
                    throw (objException);
                }
                finally
                {
                    CloseConnection(ref objSqlConnection);
                }
            }

        }


        public DataSet getPubCenter()
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();

            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_pubcenter_BILL", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objSqlConnection.Close();

            }
        }



        public DataSet bindbill_frequency()
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();

            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("get_bill_frequency", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objSqlConnection.Close();

            }
        }


        public DataSet selectmonthly_genrate(string agcode, string fromdate, string dateto, string bookingid, string Client, string dateformat, string booking)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {

                objSqlConnection.Open();
                objSqlCommand = GetCommand("selectmonthly_genbill", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@agcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agcode"].Value = agcode;


                objSqlCommand.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (fromdate == "" || fromdate == null)
                {
                    objSqlCommand.Parameters["@fromdate"].Value = System.DBNull.Value;
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

                    objSqlCommand.Parameters["@fromdate"].Value = fromdate;
                }


                objSqlCommand.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (dateto == "" || dateto == null)
                {
                    objSqlCommand.Parameters["@dateto"].Value = System.DBNull.Value;
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

                    objSqlCommand.Parameters["@dateto"].Value = dateto;
                }


                objSqlCommand.Parameters.Add("@bookingid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@bookingid"].Value = bookingid;


                objSqlCommand.Parameters.Add("@Client", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Client"].Value = Client;

                objSqlCommand.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dateformat"].Value = dateformat;

                objSqlCommand.Parameters.Add("@bookingtot", SqlDbType.VarChar);
                objSqlCommand.Parameters["@bookingtot"].Value = booking;


                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;

            }

            catch (SqlException objException)
            {
                throw (objException);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }

        }


        public DataSet advtype(string adtype, string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("RA_bindadcategory", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@advtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@advtype"].Value = adtype;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;


                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (SqlException objException)
            {
                throw (objException);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }

        }


        public DataSet bindbranch(string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("bindbranch", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (SqlException objException)
            {
                throw (objException);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }
        }

        public DataSet chklogin_billing(string user_id, string comp_code)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {


                con.Open();
                com = GetCommand("billing_session", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("vusername", SqlDbType.VarChar);
                com.Parameters["vusername"].Value = user_id;

                com.Parameters.Add("vcomp_code", SqlDbType.VarChar);
                if (comp_code == "")
                {
                    com.Parameters["vcomp_code"].Value = System.DBNull.Value;
                }
                else
                {
                    com.Parameters["vcomp_code"].Value = comp_code;
                }


                da.SelectCommand = com;
                da.Fill(ds);
                return ds;
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

        public DataSet retainerxls(string compcode, string ret)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("xlsRetainerbind", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@retainer", SqlDbType.VarChar);
                objSqlCommand.Parameters["@retainer"].Value = ret;



                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (SqlException objException)
            {
                throw (objException);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }
        }
        public DataSet executivexls(string comcode, string usid, string tname, string ext)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("xlsBindexecnew", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = comcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = usid;

                objSqlCommand.Parameters.Add("@name1", SqlDbType.VarChar);
                if (tname == "")
                {
                    objSqlCommand.Parameters["@name1"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@name1"].Value = tname;
                }

                objSqlCommand.Parameters.Add("@executive", SqlDbType.VarChar);
                objSqlCommand.Parameters["@executive"].Value = ext;

                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (SqlException objException)
            {
                throw (objException);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }
        }
        public DataSet talukabind(string compcode, string dist_code)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("BINDTALUKA", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@pdist_code", SqlDbType.VarChar);
                if (dist_code == "0" || dist_code == "")
                    objSqlCommand.Parameters["@pdist_code"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@pdist_code"].Value = dist_code;


                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (SqlException objException)
            {
                throw (objException);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }
        }

        public DataSet district(string compcode, string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("CityMst_District", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;



                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (SqlException objException)
            {
                throw (objException);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }
        }


        public DataSet packagebind_NEW(string compcode, string userid)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {


                con.Open();
                com = GetCommand("Bindpackage_new", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@compcode", SqlDbType.VarChar);
                com.Parameters["@compcode"].Value = compcode;

                com.Parameters.Add("@userid", SqlDbType.VarChar);
                com.Parameters["@userid"].Value = userid;



                da.SelectCommand = com;
                da.Fill(ds);
                return ds;
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


        public DataSet updateinsert_table(string compcode)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {


                con.Open();
                com = GetCommand("update_tbl_insert", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@compcode", SqlDbType.VarChar);
                com.Parameters["@compcode"].Value = compcode;




                da.SelectCommand = com;
                da.Fill(ds);
                return ds;
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


        public string save_det_monthly(string orderno, string invoice1, string grossamt, double billamt, double boxchg1, string ins_num, string edition_name, string maxdate, string dateformat, string insert_id, string chk_billtype)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {


                con.Open();
                com = GetCommand("bill_save_det_monthly", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@orderno1", SqlDbType.VarChar);
                com.Parameters["@orderno1"].Value = orderno;



                com.Parameters.Add("@invoice1", SqlDbType.VarChar);
                com.Parameters["@invoice1"].Value = invoice1;

                com.Parameters.Add("@amountforvat", SqlDbType.Float);
                com.Parameters["@amountforvat"].Value = Convert.ToDecimal(grossamt);

                com.Parameters.Add("@edition_name", SqlDbType.VarChar);
                if (edition_name=="0")
                {
                    com.Parameters["@edition_name"].Value = System.DBNull.Value;
                }
                else
                {
                com.Parameters["@edition_name"].Value = edition_name;
                }



                com.Parameters.Add("@boxchg1", SqlDbType.VarChar);
                com.Parameters["@boxchg1"].Value = boxchg1;

                com.Parameters.Add("@noofinsert", SqlDbType.VarChar);
                com.Parameters["@noofinsert"].Value = Convert.ToDecimal(ins_num);



                com.Parameters.Add("@todate", SqlDbType.VarChar);
                if (maxdate == "" || maxdate == null)
                {
                    com.Parameters["@todate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = maxdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        maxdate = mm + "/" + dd + "/" + yy;
                    }

                    com.Parameters["@todate"].Value = maxdate;
                }



                com.Parameters.Add("@v_insert_id", SqlDbType.VarChar);
                com.Parameters["@v_insert_id"].Value = insert_id;


                com.Parameters.Add("@chk_billtype", SqlDbType.VarChar);
                com.Parameters["@chk_billtype"].Value = chk_billtype;






                da.SelectCommand = com;
                da.Fill(ds);
                return "Success";
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

        public string save_det_monthly_ro(string orderno, string invoice1, string grossamt, double billamt, double boxchg1, string ins_num, string edition_name, string maxdate, string dateformat, string insert_id, string chk_billtype)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {


                con.Open();
                com = GetCommand("bill_save_det_monthly_ro", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@orderno1", SqlDbType.VarChar);
                com.Parameters["@orderno1"].Value = orderno;



                com.Parameters.Add("@invoice1", SqlDbType.VarChar);
                com.Parameters["@invoice1"].Value = invoice1;

                com.Parameters.Add("@amountforvat", SqlDbType.Float);
                com.Parameters["@amountforvat"].Value = Convert.ToDecimal(grossamt);

                com.Parameters.Add("@edition_name", SqlDbType.VarChar);
                if (edition_name == "0")
                {
                    com.Parameters["@edition_name"].Value = System.DBNull.Value;
                }
                else
                {
                    com.Parameters["@edition_name"].Value = edition_name;
                }



                com.Parameters.Add("@boxchg1", SqlDbType.VarChar);
                com.Parameters["@boxchg1"].Value = boxchg1;

                com.Parameters.Add("@noofinsert", SqlDbType.VarChar);
                com.Parameters["@noofinsert"].Value = Convert.ToDecimal(ins_num);



                com.Parameters.Add("@todate", SqlDbType.VarChar);
                if (maxdate == "" || maxdate == null)
                {
                    com.Parameters["@todate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = maxdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        maxdate = mm + "/" + dd + "/" + yy;
                    }

                    com.Parameters["@todate"].Value = maxdate;
                }



                com.Parameters.Add("@v_insert_id", SqlDbType.VarChar);
                com.Parameters["@v_insert_id"].Value = insert_id;


                com.Parameters.Add("@chk_billtype", SqlDbType.VarChar);
                com.Parameters["@chk_billtype"].Value = chk_billtype;






                da.SelectCommand = com;
                da.Fill(ds);
                return "Success";
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


        public DataSet delete_bill_det(string invoice1)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {


                con.Open();
                com = GetCommand("delete_adbills_det", ref con);
                com.CommandType = CommandType.StoredProcedure;


                com.Parameters.Add("@invoice1", SqlDbType.VarChar);
                com.Parameters["@invoice1"].Value = invoice1;




                da.SelectCommand = com;
                da.Fill(ds);
                return ds;
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

        public string saveinlast(string orderno, string invoice1, string amountforvat, string amt3, double boxchg1, int insnum_cou, string doctyp, string maxinsert, string dateto, string dateformat, string chk_billtype)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {


                con.Open();
                com = GetCommand("Bill_Savelast_G", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@orderno1", SqlDbType.VarChar);
                com.Parameters["@orderno1"].Value = orderno;



                com.Parameters.Add("@invoice1", SqlDbType.VarChar);
                com.Parameters["@invoice1"].Value = invoice1;

                com.Parameters.Add("@amountforvat", SqlDbType.Float);
                com.Parameters["@amountforvat"].Value = amountforvat;

                com.Parameters.Add("@amt3", SqlDbType.Float);
                com.Parameters["@amt3"].Value = amt3;

                com.Parameters.Add("@insnum_cou", SqlDbType.Float);
                com.Parameters["@insnum_cou"].Value = insnum_cou;


                com.Parameters.Add("@boxchg1", SqlDbType.VarChar);
                com.Parameters["@boxchg1"].Value = boxchg1;

                com.Parameters.Add("@doctyp", SqlDbType.VarChar);
                com.Parameters["@doctyp"].Value = doctyp;

                com.Parameters.Add("@todate", SqlDbType.VarChar);
                if (dateto == "" || dateto == null)
                {
                    com.Parameters["@todate"].Value = System.DBNull.Value;
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

                    com.Parameters["@todate"].Value = dateto;
                }


                com.Parameters.Add("@maxinsert", SqlDbType.VarChar);
                com.Parameters["@maxinsert"].Value = maxinsert;

                com.Parameters.Add("@chk_billtype", SqlDbType.VarChar);
                com.Parameters["@chk_billtype"].Value = chk_billtype;








                da.SelectCommand = com;
                da.Fill(ds);
                return "Success";
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

        public DataSet fetchstatusmonthly1(string BOOKINGID, string maxdate, string dateformat, string comp_code)
        {

            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {


                con.Open();
                com = GetCommand("fetchstatusmon_n", ref con);
                com.CommandType = CommandType.StoredProcedure;


                com.Parameters.Add("@BOOKINGID_v", SqlDbType.VarChar);
                com.Parameters["@BOOKINGID_v"].Value = BOOKINGID;



                com.Parameters.Add("@todate", SqlDbType.VarChar);
                if (maxdate == "" || maxdate == null)
                {
                    com.Parameters["@todate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = maxdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        maxdate = mm + "/" + dd + "/" + yy;
                    }

                    com.Parameters["@todate"].Value = maxdate;
                }


                com.Parameters.Add("@v_comp_code", SqlDbType.VarChar);
                com.Parameters["@v_comp_code"].Value = comp_code;







                da.SelectCommand = com;
                da.Fill(ds);
                return ds;
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



        public DataSet updatestatus_order(string bookingid, string insertion, string edition, string from_date, string date_format)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("updatestaus_orderwise", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@ciobookid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ciobookid"].Value = bookingid;


                objSqlCommand.Parameters.Add("@insertion", SqlDbType.VarChar);
                objSqlCommand.Parameters["@insertion"].Value = insertion;



                objSqlCommand.Parameters.Add("@edition", SqlDbType.VarChar);
                objSqlCommand.Parameters["@edition"].Value = edition;

                objSqlCommand.Parameters.Add("@v_from_date", SqlDbType.VarChar);
                if (from_date == "" || from_date == null)
                {
                    objSqlCommand.Parameters["@v_from_date"].Value = System.DBNull.Value;
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

                    objSqlCommand.Parameters["@v_from_date"].Value = from_date;
                }

                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (SqlException objException)
            {
                throw (objException);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }

        }


        public DataSet selectmonthlynew_b(string agcode, string fromdate, string dateto, string bookingid, string Client, string dateformat, string bookingtot)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {

                objSqlConnection.Open();
                objSqlCommand = GetCommand("selectmonthly_B", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@agcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agcode"].Value = agcode;


                objSqlCommand.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (fromdate == "" || fromdate == null)
                {
                    objSqlCommand.Parameters["@fromdate"].Value = System.DBNull.Value;
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

                    objSqlCommand.Parameters["@fromdate"].Value = fromdate;
                }


                objSqlCommand.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (dateto == "" || dateto == null)
                {
                    objSqlCommand.Parameters["@dateto"].Value = System.DBNull.Value;
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

                    objSqlCommand.Parameters["@dateto"].Value = dateto;
                }


                objSqlCommand.Parameters.Add("@bookingid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@bookingid"].Value = bookingid;


                objSqlCommand.Parameters.Add("@Client", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Client"].Value = Client;

                objSqlCommand.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dateformat"].Value = dateformat;

                objSqlCommand.Parameters.Add("@bookingtot", SqlDbType.VarChar);
                objSqlCommand.Parameters["@bookingtot"].Value = bookingtot;


                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;

            }

            catch (SqlException objException)
            {
                throw (objException);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }

        }


        public DataSet fetchMatter(string cioid, string uomdesc)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {


                con.Open();
                com = GetCommand("websp_fetchmatter", ref con);
                com.CommandType = CommandType.StoredProcedure;


                com.Parameters.Add("@cioid1", SqlDbType.VarChar);
                com.Parameters["@cioid1"].Value = cioid;


                com.Parameters.Add("@uomdesc", SqlDbType.VarChar);
                com.Parameters["@uomdesc"].Value = uomdesc;




                da.SelectCommand = com;
                da.Fill(ds);
                return ds;
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



        public DataSet selectmonthlynew_coverletter(string agcode, string fromdate, string dateto, string bookingid, string Client, string dateformat, string bookingtot)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {

                objSqlConnection.Open();
                objSqlCommand = GetCommand("selectmonthly_coverletter", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@agcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agcode"].Value = agcode;


                objSqlCommand.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (fromdate == "" || fromdate == null)
                {
                    objSqlCommand.Parameters["@fromdate"].Value = System.DBNull.Value;
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

                    objSqlCommand.Parameters["@fromdate"].Value = fromdate;
                }


                objSqlCommand.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (dateto == "" || dateto == null)
                {
                    objSqlCommand.Parameters["@dateto"].Value = System.DBNull.Value;
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

                    objSqlCommand.Parameters["@dateto"].Value = dateto;
                }


                objSqlCommand.Parameters.Add("@bookingid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@bookingid"].Value = bookingid;


                objSqlCommand.Parameters.Add("@Client", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Client"].Value = Client;

                objSqlCommand.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dateformat"].Value = dateformat;

                objSqlCommand.Parameters.Add("@bookingtot", SqlDbType.VarChar);
                objSqlCommand.Parameters["@bookingtot"].Value = bookingtot;


                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;

            }

            catch (SqlException objException)
            {
                throw (objException);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }

        }

        public DataSet get_agency_name(string invoice_no, string cio_booking_id,string dateformat)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {


                con.Open();
                com = GetCommand("websp_cover_letter", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@invoice_no", SqlDbType.VarChar);
                com.Parameters["@invoice_no"].Value = invoice_no;

                com.Parameters.Add("@cio_booking_id", SqlDbType.VarChar);
                com.Parameters["@cio_booking_id"].Value = cio_booking_id;

                com.Parameters.Add("@dateformat", SqlDbType.VarChar);
                com.Parameters["@dateformat"].Value = dateformat;


                da.SelectCommand = com;
                da.Fill(ds);
                return ds;
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