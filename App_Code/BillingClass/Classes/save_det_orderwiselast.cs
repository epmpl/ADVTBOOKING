using System;
using System.Data;
using System.Configuration;
//using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
//using System.Xml.Linq;
using System.Data.SqlClient;

namespace NewAdbooking.BillingClass.Classes
{

    /// <summary>
    /// Summary description for billing_save
    /// </summary>
    public class save_det_orderwiselast : NewAdbooking.Classes.connection
    {
        public save_det_orderwiselast()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataSet bill_save_data_orderwiselast(string pcompcode, string pcenter, string porderno, string pinsertion_no, string pbill_cycle, string puserid, string pfrom_date, string ptill_date, string pbill_date, string pdateformat, string pnoofinsert, string pprefix, string pextra1, string pextra2, string pextra3, string pextra4, string pextra5)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("bill_save_bookingwise", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                com.Parameters["@pcompcode"].Value = pcompcode;

                com.Parameters.Add("@pcenter", SqlDbType.VarChar);
                com.Parameters["@pcenter"].Value = pcenter;


                com.Parameters.Add("@pfrom_date", SqlDbType.VarChar);
                if (pfrom_date == "" || pfrom_date == null)
                {
                    com.Parameters["@pfrom_date"].Value = System.DBNull.Value;
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

                    com.Parameters["@pfrom_date"].Value = Convert.ToDateTime(pfrom_date).ToString();
                }


                com.Parameters.Add("@ptill_date", SqlDbType.VarChar);
                if (ptill_date == "" || ptill_date == null)
                {
                    com.Parameters["@ptill_date"].Value = System.DBNull.Value;
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

                    com.Parameters["@ptill_date"].Value = Convert.ToDateTime(ptill_date).ToString();
                }
                com.Parameters.Add("@pbill_date", SqlDbType.VarChar);
                if (pbill_date == "" || pbill_date == null)
                {
                    com.Parameters["@pbill_date"].Value = System.DBNull.Value;
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

                    com.Parameters["@pbill_date"].Value = pbill_date;
                }
                com.Parameters.Add("@porderno", SqlDbType.VarChar);
                if (porderno == "" || porderno == null)
                {
                    com.Parameters["@porderno"].Value = System.DBNull.Value;
                }
                else
                {
                    //com.Parameters["@pbill_process_id"].Value =Convert.ToInt32(bill_process_id);
                    com.Parameters["@porderno"].Value = porderno;
                }

                com.Parameters.Add("@pinsertion_no", SqlDbType.VarChar);
                com.Parameters["@pinsertion_no"].Value = pinsertion_no;

                com.Parameters.Add("@pbill_cycle", SqlDbType.VarChar);
                com.Parameters["@pbill_cycle"].Value = pbill_cycle;

                com.Parameters.Add("@puserid", SqlDbType.VarChar);
                com.Parameters["@puserid"].Value = puserid;

                com.Parameters.Add("@pdateformat", SqlDbType.VarChar);
                com.Parameters["@pdateformat"].Value = pdateformat;

                com.Parameters.Add("@pnoofinsert", SqlDbType.VarChar);
                com.Parameters["@pnoofinsert"].Value = pnoofinsert;

                com.Parameters.Add("@pprefix", SqlDbType.VarChar);
                com.Parameters["@pprefix"].Value = pprefix;

                com.Parameters.Add("@pextra1", SqlDbType.VarChar);
                com.Parameters["@pextra1"].Value = pextra1;

                com.Parameters.Add("@pextra2", SqlDbType.VarChar);
                com.Parameters["@pextra2"].Value = pextra2;

                com.Parameters.Add("@pextra3", SqlDbType.VarChar);
                com.Parameters["@pextra3"].Value = pextra3;

                com.Parameters.Add("@pextra4", SqlDbType.VarChar);
                com.Parameters["@pextra4"].Value = pextra4;

                com.Parameters.Add("@pextra5", SqlDbType.VarChar);
                com.Parameters["@pextra5"].Value = pextra5;

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


        public DataSet bill_save_data_insertionwise(string pcompcode, string pcenter, string porderno, string pinsertion_no, string pbill_cycle, string puserid, string pfrom_date, string ptill_date, string pbill_date, string pdateformat, string pnoofinsert, string pprefix, string pextra1, string pextra2, string pextra3, string pextra4, string pextra5)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("bill_save_insertionwise", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                com.Parameters["@pcompcode"].Value = pcompcode;

                com.Parameters.Add("@pcenter", SqlDbType.VarChar);
                com.Parameters["@pcenter"].Value = pcenter;


                com.Parameters.Add("@pfrom_date", SqlDbType.VarChar);
                if (pfrom_date == "" || pfrom_date == null)
                {
                    com.Parameters["@pfrom_date"].Value = System.DBNull.Value;
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

                    com.Parameters["@pfrom_date"].Value =pfrom_date;
                }


                com.Parameters.Add("@ptill_date", SqlDbType.VarChar);
                if (ptill_date == "" || ptill_date == null)
                {
                    com.Parameters["@ptill_date"].Value = System.DBNull.Value;
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

                    com.Parameters["@ptill_date"].Value = Convert.ToDateTime(ptill_date).ToString();
                }
                com.Parameters.Add("@pbill_date", SqlDbType.VarChar);
                if (pbill_date == "" || pbill_date == null)
                {
                    com.Parameters["@pbill_date"].Value = System.DBNull.Value;
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

                    com.Parameters["@pbill_date"].Value = pbill_date;
                }
                com.Parameters.Add("@porderno", SqlDbType.VarChar);
                if (porderno == "" || porderno == null)
                {
                    com.Parameters["@porderno"].Value = System.DBNull.Value;
                }
                else
                {
                    //com.Parameters["@pbill_process_id"].Value =Convert.ToInt32(bill_process_id);
                    com.Parameters["@porderno"].Value = porderno;
                }

                com.Parameters.Add("@pinsertion_no", SqlDbType.VarChar);
                com.Parameters["@pinsertion_no"].Value = pinsertion_no;

                com.Parameters.Add("@pbill_cycle", SqlDbType.VarChar);
                com.Parameters["@pbill_cycle"].Value = pbill_cycle;

                com.Parameters.Add("@puserid", SqlDbType.VarChar);
                com.Parameters["@puserid"].Value = puserid;

                com.Parameters.Add("@pdateformat", SqlDbType.VarChar);
                com.Parameters["@pdateformat"].Value = pdateformat;

                com.Parameters.Add("@pnoofinsert", SqlDbType.VarChar);
                com.Parameters["@pnoofinsert"].Value = pnoofinsert;

                com.Parameters.Add("@pprefix", SqlDbType.VarChar);
                com.Parameters["@pprefix"].Value = pprefix;

                com.Parameters.Add("@pextra1", SqlDbType.VarChar);
                com.Parameters["@pextra1"].Value = pextra1;

                com.Parameters.Add("@pextra2", SqlDbType.VarChar);
                com.Parameters["@pextra2"].Value = pextra2;

                com.Parameters.Add("@pextra3", SqlDbType.VarChar);
                com.Parameters["@pextra3"].Value = pextra3;

                com.Parameters.Add("@pextra4", SqlDbType.VarChar);
                com.Parameters["@pextra4"].Value = pextra4;

                com.Parameters.Add("@pextra5", SqlDbType.VarChar);
                com.Parameters["@pextra5"].Value = pextra5;

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

        public DataSet bill_save_data_editionwise(string pcompcode, string pcenter, string porderno, string pinsertion_no, string pbill_cycle, string puserid, string pfrom_date, string ptill_date, string pbill_date, string pdateformat, string pnoofinsert, string pprefix, string pextra1, string pextra2, string pextra3, string pextra4, string pextra5)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("bill_save_editionwise", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                com.Parameters["@pcompcode"].Value = pcompcode;

                com.Parameters.Add("@pcenter", SqlDbType.VarChar);
                com.Parameters["@pcenter"].Value = pcenter;


                com.Parameters.Add("@pfrom_date", SqlDbType.VarChar);
                if (pfrom_date == "" || pfrom_date == null)
                {
                    com.Parameters["@pfrom_date"].Value = System.DBNull.Value;
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

                    com.Parameters["@pfrom_date"].Value = Convert.ToDateTime(pfrom_date).ToString();
                }


                com.Parameters.Add("@ptill_date", SqlDbType.VarChar);
                if (ptill_date == "" || ptill_date == null)
                {
                    com.Parameters["@ptill_date"].Value = System.DBNull.Value;
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

                    com.Parameters["@ptill_date"].Value = Convert.ToDateTime(ptill_date).ToString();
                }
                com.Parameters.Add("@pbill_date", SqlDbType.VarChar);
                if (pbill_date == "" || pbill_date == null)
                {
                    com.Parameters["@pbill_date"].Value = System.DBNull.Value;
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

                    com.Parameters["@pbill_date"].Value = pbill_date;
                }
                com.Parameters.Add("@porderno", SqlDbType.VarChar);
                if (porderno == "" || porderno == null)
                {
                    com.Parameters["@porderno"].Value = System.DBNull.Value;
                }
                else
                {
                    //com.Parameters["@pbill_process_id"].Value =Convert.ToInt32(bill_process_id);
                    com.Parameters["@porderno"].Value = porderno;
                }

                com.Parameters.Add("@pinsertion_no", SqlDbType.VarChar);
                com.Parameters["@pinsertion_no"].Value = pinsertion_no;

                com.Parameters.Add("@pbill_cycle", SqlDbType.VarChar);
                com.Parameters["@pbill_cycle"].Value = pbill_cycle;

                com.Parameters.Add("@puserid", SqlDbType.VarChar);
                com.Parameters["@puserid"].Value = puserid;

                com.Parameters.Add("@pdateformat", SqlDbType.VarChar);
                com.Parameters["@pdateformat"].Value = pdateformat;

                com.Parameters.Add("@pnoofinsert", SqlDbType.VarChar);
                com.Parameters["@pnoofinsert"].Value = pnoofinsert;

                com.Parameters.Add("@pprefix", SqlDbType.VarChar);
                com.Parameters["@pprefix"].Value = pprefix;

                com.Parameters.Add("@pextra1", SqlDbType.VarChar);
                com.Parameters["@pextra1"].Value = pextra1;

                com.Parameters.Add("@pextra2", SqlDbType.VarChar);
                com.Parameters["@pextra2"].Value = pextra2;

                com.Parameters.Add("@pextra3", SqlDbType.VarChar);
                com.Parameters["@pextra3"].Value = pextra3;

                com.Parameters.Add("@pextra4", SqlDbType.VarChar);
                com.Parameters["@pextra4"].Value = pextra4;

                com.Parameters.Add("@pextra5", SqlDbType.VarChar);
                com.Parameters["@pextra5"].Value = pextra5;

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
