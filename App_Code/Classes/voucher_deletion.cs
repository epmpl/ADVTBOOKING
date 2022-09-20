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
namespace NewAdbooking.Classes
{
    /// <summary>
    /// Summary description for voucher_deletion
    /// </summary>
    public class voucher_deletion : connection
    {
        public voucher_deletion()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        public DataSet getbranch(string compcode, string citycode, string dateformat, string extra1, string extra2)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("bind_branch", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;



                objSqlCommand.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcompcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@pcitycode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcitycode"].Value = citycode;



                objSqlCommand.Parameters.Add("@pdateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdateformat"].Value = dateformat;

                objSqlCommand.Parameters.Add("@pextra1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra1"].Value = extra1;

                objSqlCommand.Parameters.Add("@pextra2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra2"].Value = extra2;


                

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
        public DataSet bind_voucherno(string compcode,string doctype, string unit,string rcptdt, string dateformat,string voucherno)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("ad_voucherno_List_bind_p", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcompcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@punit", SqlDbType.VarChar);
                objSqlCommand.Parameters["@punit"].Value = unit;

                objSqlCommand.Parameters.Add("@pdoctyp", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdoctyp"].Value = doctype;

                objSqlCommand.Parameters.Add("@precptdt", SqlDbType.VarChar);
                objSqlCommand.Parameters["@precptdt"].Value = rcptdt;

                objSqlCommand.Parameters.Add("@pdateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdateformat"].Value = dateformat;

                

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
        public DataSet bind_voucherdelete(string compcode, string doctype, string unit, string rcptdt, string dateformat, string voucherno, string rcptno)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("ad_vch_delete_bind_p", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcompcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@punit", SqlDbType.VarChar);
                objSqlCommand.Parameters["@punit"].Value = unit;

                objSqlCommand.Parameters.Add("@pdoctyp", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdoctyp"].Value = doctype;

                objSqlCommand.Parameters.Add("@pvoucherno", SqlDbType.VarChar);
                // objSqlCommand.Parameters["@pvoucherno"].Value = voucherno;
                if (voucherno == "")
                    objSqlCommand.Parameters["@pvoucherno"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@pvoucherno"].Value = voucherno;

                objSqlCommand.Parameters.Add("@precptdt", SqlDbType.VarChar);
                objSqlCommand.Parameters["@precptdt"].Value = rcptdt;

                objSqlCommand.Parameters.Add("@precptno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@precptno"].Value = rcptno;

                objSqlCommand.Parameters.Add("@pdateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdateformat"].Value = dateformat;


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

        public DataSet bind_voucherdetail(string compcode,string doctype, string unit,string rcptdt, string dateformat,string voucherno,string rcptno)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("ad_vch_detail_List_bind_p", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcompcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@punit", SqlDbType.VarChar);
                objSqlCommand.Parameters["@punit"].Value = unit;

                objSqlCommand.Parameters.Add("@pdoctyp", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdoctyp"].Value = doctype;

                objSqlCommand.Parameters.Add("@pvoucherno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pvoucherno"].Value = voucherno;

                objSqlCommand.Parameters.Add("@precptdt", SqlDbType.VarChar);
                objSqlCommand.Parameters["@precptdt"].Value = rcptdt;

                objSqlCommand.Parameters.Add("@precptno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@precptno"].Value = rcptno;

                objSqlCommand.Parameters.Add("@pdateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdateformat"].Value = dateformat;

                
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


        /////////////////////////////////////////////For bill No.//////////////////////////////////////////////

        public DataSet bind_billno(string compcode, string doctype, string unit, string billdt, string dateformat)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("ad_bills_List_bind_p", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcompcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@punit", SqlDbType.VarChar);
                objSqlCommand.Parameters["@punit"].Value = unit;

                objSqlCommand.Parameters.Add("@pdoctyp", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdoctyp"].Value = doctype;

                objSqlCommand.Parameters.Add("@pbildt", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pbildt"].Value = billdt;

                objSqlCommand.Parameters.Add("@pdateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdateformat"].Value = dateformat;



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


        ///////////////////////////////For Bill Detail/////////////////////////////


        public DataSet bind_billdetail(string compcode, string doctype, string unit, string billdt, string dateformat, string billno)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("ad_bills_detail_List_bind_p", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcompcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@punit", SqlDbType.VarChar);
                objSqlCommand.Parameters["@punit"].Value = unit;

                objSqlCommand.Parameters.Add("@pdoctyp", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdoctyp"].Value = doctype;

                objSqlCommand.Parameters.Add("@pbillno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pbillno"].Value = billno;

                objSqlCommand.Parameters.Add("@pbildt", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pbildt"].Value = billdt;

                objSqlCommand.Parameters.Add("@pdateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdateformat"].Value = dateformat;


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

        ///////////////////////////////////////////For Bill Delete////////////////////////


        public DataSet bind_billdelete(string compcode, string doctype, string unit, string billdt, string dateformat, string billno, string userid)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("ad_bills_delete_p", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcompcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@punit", SqlDbType.VarChar);
                objSqlCommand.Parameters["@punit"].Value = unit;

                objSqlCommand.Parameters.Add("@pdoctyp", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdoctyp"].Value = doctype;

                objSqlCommand.Parameters.Add("@pbilldt", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pbilldt"].Value = billdt;
             
                objSqlCommand.Parameters.Add("@pbillno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pbillno"].Value = billno;

                objSqlCommand.Parameters.Add("@pbilldtformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pbilldtformat"].Value = dateformat;


                objSqlCommand.Parameters.Add("@puserid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@puserid"].Value = userid;




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

        /////////////////////////////////////////////// for bill adjust/////////////////////////////////////////////

        public DataSet bill_adjust(string compcode, string billdt,string billno,string userid, string dateformat, string extra1, string extra2)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("ad_bill_unadjusted", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcompcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@pbilldate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pbilldate"].Value = billdt;

                objSqlCommand.Parameters.Add("@pbillno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pbillno"].Value = billno;

                objSqlCommand.Parameters.Add("@puserid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@puserid"].Value = userid;

                objSqlCommand.Parameters.Add("@pdateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdateformat"].Value = dateformat;

                objSqlCommand.Parameters.Add("@pextra1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra1"].Value = extra1;

                objSqlCommand.Parameters.Add("@pextra2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra2"].Value = extra2;

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

        public DataSet check_drcr(string compcode, string doctype, string dateformat, string extra1, string extra2)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("ad_doctype_bind", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@pcomp_code", SqlDbType.VarChar);
                if (compcode == "0")
                    objSqlCommand.Parameters["@pcomp_code"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@pcomp_code"].Value = compcode;

                objSqlCommand.Parameters.Add("@pdoctype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdoctype"].Value = doctype;

                objSqlCommand.Parameters.Add("@pdateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdateformat"].Value = dateformat;

                objSqlCommand.Parameters.Add("@pextra1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra1"].Value = extra1;

                objSqlCommand.Parameters.Add("@pextra2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra2"].Value = extra2;

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
        
    }
}
