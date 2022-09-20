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
namespace NewAdbooking.BillingClass.Classes
{


    /// <summary>
    /// Summary description for invoice
    /// </summary>
    public class invoice : connection
    {
        public invoice()
        {
            //
            // TODO: Add constructor logic here
            //

            
        }




     public DataSet fetchnextvalue()
        {
            SqlConnection con;
            SqlCommand com = new SqlCommand();
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {

                con.Open();
                string query = "SELECT Left( NEWID(),4) AS newPass";
                com.CommandText = query;
                com.Connection = con;
                //cmd.ExecuteNonQuery();

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
     

        public DataSet invoice_no_uday(string compcode, string prefix)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("getautoinvoiceno_uday", ref con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@compcode", SqlDbType.VarChar);
                com.Parameters["@compcode"].Value = compcode;

                com.Parameters.Add("@pprefix", SqlDbType.VarChar);
                com.Parameters["@pprefix"].Value = prefix;


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



        public DataSet values_bill_p(string invoiceno, string billcycle, string insertion, string compcode, string dateformat)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("websp_selectvalues_pra", ref con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@pbillcycle", SqlDbType.VarChar);
                com.Parameters["@pbillcycle"].Value = billcycle;

                com.Parameters.Add("@pinvoiceno", SqlDbType.VarChar);
                com.Parameters["@pinvoiceno"].Value = invoiceno;

                com.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                com.Parameters["@pcompcode"].Value = compcode;

                com.Parameters.Add("@pdateformat", SqlDbType.VarChar);
                com.Parameters["@pdateformat"].Value = dateformat;

                com.Parameters.Add("@pextra1", SqlDbType.VarChar);
                com.Parameters["@pextra1"].Value = System.DBNull.Value;

                com.Parameters.Add("@pextra2", SqlDbType.VarChar);
                com.Parameters["@pextra2"].Value = System.DBNull.Value;

                com.Parameters.Add("@pextra3", SqlDbType.VarChar);
                com.Parameters["@pextra3"].Value = System.DBNull.Value;

                com.Parameters.Add("@pextra4", SqlDbType.VarChar);
                com.Parameters["@pextra4"].Value = System.DBNull.Value;

                com.Parameters.Add("@pextra5", SqlDbType.VarChar);
                com.Parameters["@pextra5"].Value = System.DBNull.Value;

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


        public DataSet packagecode(string ciobookingid, string compcode)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("websp_packagecode", ref con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@ciobooking", SqlDbType.VarChar);
                com.Parameters["@ciobooking"].Value = ciobookingid;


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

        public DataSet edition(string editioncode, string compcode)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("websp_selectedition", ref con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@editoncode", SqlDbType.VarChar);
                com.Parameters["@editoncode"].Value = editioncode;               

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

        public DataSet values_bill(string ciobooking, string editionname, string insertion, string compcode, string dateformat)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("websp_selectvalues", ref con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@ciobooking", SqlDbType.VarChar);
                com.Parameters["@ciobooking"].Value = ciobooking;

                com.Parameters.Add("@editionname", SqlDbType.VarChar);
                com.Parameters["@editionname"].Value = editionname;
                com.Parameters.Add("@compcode", SqlDbType.VarChar);
                com.Parameters["@compcode"].Value = compcode;

                com.Parameters.Add("@insertion", SqlDbType.VarChar);
                com.Parameters["@insertion"].Value = insertion;

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


        public DataSet values_bill_state(string ciobooking, string editionname, string insertion, string compcode, string dateformat, string package)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("websp_selectvalues_states", ref con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@ciobooking", SqlDbType.VarChar);
                com.Parameters["@ciobooking"].Value = ciobooking;

                com.Parameters.Add("@editionname", SqlDbType.VarChar);
                com.Parameters["@editionname"].Value = editionname;
                com.Parameters.Add("@compcode", SqlDbType.VarChar);
                com.Parameters["@compcode"].Value = compcode;

                com.Parameters.Add("@insertion", SqlDbType.VarChar);
                com.Parameters["@insertion"].Value = insertion;

                com.Parameters.Add("@dateformat", SqlDbType.VarChar);
                com.Parameters["@dateformat"].Value = dateformat;

                com.Parameters.Add("@extra1", SqlDbType.VarChar);
                com.Parameters["@extra1"].Value = package;

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

        public DataSet billstatusinsert(string ciobooking, string editionname, string insertion, string compcode)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("websp_billstatusinsert", ref con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@ciobooking", SqlDbType.VarChar);
                com.Parameters["@ciobooking"].Value = ciobooking;

                com.Parameters.Add("@editionname", SqlDbType.VarChar);
                com.Parameters["@editionname"].Value = editionname;
                com.Parameters.Add("@compcode", SqlDbType.VarChar);
                com.Parameters["@compcode"].Value = compcode;

                com.Parameters.Add("@insertion", SqlDbType.VarChar);
                com.Parameters["@insertion"].Value = insertion;



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




        public DataSet invoice_no(string compcode)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("getautoinvoiceno", ref con);
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
        public DataSet values_bill_kannad(string ciobooking, string editionname, string insertion, string compcode, string dateformat)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("websp_selectvalues_kannad", ref con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@ciobooking", SqlDbType.VarChar);
                com.Parameters["@ciobooking"].Value = ciobooking;

                com.Parameters.Add("@editionname", SqlDbType.VarChar);
                com.Parameters["@editionname"].Value = editionname;
                com.Parameters.Add("@compcode", SqlDbType.VarChar);
                com.Parameters["@compcode"].Value = compcode;

                com.Parameters.Add("@insertion", SqlDbType.VarChar);
                com.Parameters["@insertion"].Value = insertion;

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
        //To get the Branch Address...........................
        public DataSet values_bill(string compcode, string branchcode, string extra1)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("websp_getbranchadd", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                com.Parameters["@pcompcode"].Value = compcode;

                com.Parameters.Add("@pbranchcode", SqlDbType.VarChar);
                com.Parameters["@pbranchcode"].Value = branchcode;

                com.Parameters.Add("@extra1", SqlDbType.VarChar);
                com.Parameters["@extra1"].Value = extra1;

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
        
        
        
        
        
        
        public DataSet invoice_no_haribhoomi(string compcode, string cen, string date_from, string dateformat,string cond_flag , string prefix,string extra1,string extra2)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("Getautoinvoiceno_centerwise", ref con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@compcode", SqlDbType.VarChar);
                com.Parameters["@compcode"].Value = compcode;





                com.Parameters.Add("@pcenter", SqlDbType.VarChar);
                com.Parameters["@pcenter"].Value = cen;

                com.Parameters.Add("@pfrom_date", SqlDbType.VarChar);
                com.Parameters["@pfrom_date"].Value = date_from;



                com.Parameters.Add("@pdate_format", SqlDbType.VarChar);
                com.Parameters["@pdate_format"].Value = dateformat;






                com.Parameters.Add("@pcond_flag", SqlDbType.VarChar);
                com.Parameters["@pcond_flag"].Value = cond_flag;



                com.Parameters.Add("@pprefix", SqlDbType.VarChar);
                com.Parameters["@pprefix"].Value = prefix;


                com.Parameters.Add("@pextra1", SqlDbType.VarChar);
                com.Parameters["@pextra1"].Value = extra1;



                com.Parameters.Add("@pextra2", SqlDbType.VarChar);
                com.Parameters["@pextra2"].Value = extra2;




                



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

        public DataSet bindaddress(string compcode, string unit, string extra1, string extra2)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("adgetbindaddress", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcompcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@punit", SqlDbType.VarChar);
                objSqlCommand.Parameters["@punit"].Value = unit;

                objSqlCommand.Parameters.Add("@pextra1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra1"].Value = extra1;

                objSqlCommand.Parameters.Add("@pextra2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra2"].Value = extra2;

                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);




                return objDataSet;

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

        public DataSet values_bill_rj(string ciobooking, string editionname, string insertion, string compcode, string dateformat, string invoice, string editionreq)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("websp_selectvaluesnew_rj", ref con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@ciobooking", SqlDbType.VarChar);
                com.Parameters["@ciobooking"].Value = ciobooking;

                com.Parameters.Add("@editionname", SqlDbType.VarChar);
                com.Parameters["@editionname"].Value = editionname;
                com.Parameters.Add("@compcode", SqlDbType.VarChar);
                com.Parameters["@compcode"].Value = compcode;

                com.Parameters.Add("@insertion", SqlDbType.VarChar);
                com.Parameters["@insertion"].Value = insertion;

                com.Parameters.Add("@dateformat", SqlDbType.VarChar);
                com.Parameters["@dateformat"].Value = dateformat;

                com.Parameters.Add("@pinvoice_no", SqlDbType.VarChar);
                if (invoice == "&nbsp;")
                {
                    com.Parameters["@pinvoice_no"].Value = "";
                }
                else
                {
                    com.Parameters["@pinvoice_no"].Value = invoice;
                }


                com.Parameters.Add("@pedtn_billreq", SqlDbType.VarChar);
                com.Parameters["@pedtn_billreq"].Value = editionreq;


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