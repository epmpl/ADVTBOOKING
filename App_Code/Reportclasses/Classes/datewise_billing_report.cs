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

namespace NewAdbooking.Report.Classes
{

    /// <summary>
    /// Summary description for datewise_billing_report
    /// </summary>
    public class datewise_billing_report : connection
    {
        public datewise_billing_report()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataSet category_billing(string compcode, string printcenter, string branchcode, string publication, string adtype, string catgcode, string fromdate, string dateto, string useid, string dateformat, string ext1, string ext2, string ext3, string ext4, string ext5)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("rpt_category_billing_summ", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcompcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@pcenter", SqlDbType.VarChar);
                if ((printcenter != "") && (printcenter != "--Select Printing Center--") && (printcenter != "0"))
                {
                    objSqlCommand.Parameters["@pcenter"].Value = printcenter;
                }
                else
                {
                    objSqlCommand.Parameters["@pcenter"].Value = System.DBNull.Value;
                }

                objSqlCommand.Parameters.Add("@pbranchcode", SqlDbType.VarChar);
                if ((branchcode != "") && (branchcode != "--Select Branch--") && (branchcode != "0"))
                {
                    objSqlCommand.Parameters["@pbranchcode"].Value = branchcode;
                }
                else
                {
                    objSqlCommand.Parameters["@pbranchcode"].Value = System.DBNull.Value;
                }

                objSqlCommand.Parameters.Add("@ppublcode", SqlDbType.VarChar);
                if ((publication != "") && (publication != "--Select Publication--") && (publication != "0"))
                {
                    objSqlCommand.Parameters["@ppublcode"].Value = publication;
                }
                else
                {
                    objSqlCommand.Parameters["@ppublcode"].Value = System.DBNull.Value;
                }

                objSqlCommand.Parameters.Add("@padtype", SqlDbType.VarChar);
                if ((adtype != "") && (adtype != "--Select Ad Type--") && (adtype != "0"))
                {
                    objSqlCommand.Parameters["@padtype"].Value = adtype;
                }
                else
                {
                    objSqlCommand.Parameters["@padtype"].Value = System.DBNull.Value;

                }

                objSqlCommand.Parameters.Add("@pcatgcode", SqlDbType.VarChar);
                if ((catgcode != "") && (catgcode != "--Select Ad Cat--"))
                {
                    objSqlCommand.Parameters["@pcatgcode"].Value = catgcode;
                }
                else
                {
                    objSqlCommand.Parameters["@pcatgcode"].Value = System.DBNull.Value;
                }


                objSqlCommand.Parameters.Add("@pdatefrom", SqlDbType.DateTime);
                if (dateformat == "dd/mm/yyyy")
                {
                    string[] arr = fromdate.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    fromdate = mm + "/" + dd + "/" + yy;
                }
                else if (dateformat == "yyyy/mm/dd")
                {
                    string[] arr = fromdate.Split('/');
                    string dd = arr[2];
                    string mm = arr[1];
                    string yy = arr[0];
                    fromdate = mm + "/" + dd + "/" + yy;
                }
                objSqlCommand.Parameters["@pdatefrom"].Value = fromdate;

                objSqlCommand.Parameters.Add("@pdateto", SqlDbType.DateTime);
                if (dateformat == "dd/mm/yyyy")
                {
                    string[] arr = dateto.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    dateto = mm + "/" + dd + "/" + yy;
                }
                else if (dateformat == "yyyy/mm/dd")
                {
                    string[] arr = dateto.Split('/');
                    string dd = arr[2];
                    string mm = arr[1];
                    string yy = arr[0];
                    dateto = mm + "/" + dd + "/" + yy;
                }
                objSqlCommand.Parameters["@pdateto"].Value = dateto;

                objSqlCommand.Parameters.Add("@puserid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@puserid"].Value = useid;

                objSqlCommand.Parameters.Add("@pdateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdateformat"].Value = dateformat;

                objSqlCommand.Parameters.Add("@pextra1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra1"].Value = ext1;

                objSqlCommand.Parameters.Add("@pextra2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra2"].Value = ext2;

                objSqlCommand.Parameters.Add("@pextra3", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra3"].Value = ext3;

                objSqlCommand.Parameters.Add("@pextra4", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra4"].Value = ext4;

                objSqlCommand.Parameters.Add("@pextra5", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra5"].Value = ext5;

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
        public DataSet publication_billing(string compcode, string printcenter, string branchcode, string publication, string adtype, string catgcode, string fromdate, string dateto, string useid, string dateformat, string ext1, string ext2, string ext3, string ext4, string ext5)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("rpt_publwise_billing_summ", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcompcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@pcenter", SqlDbType.VarChar);
                if ((printcenter != "") && (printcenter != "--Select Printing Center--") && (printcenter != "0"))
                {
                    objSqlCommand.Parameters["@pcenter"].Value = printcenter;
                }
                else
                {
                    objSqlCommand.Parameters["@pcenter"].Value = System.DBNull.Value;
                }

                objSqlCommand.Parameters.Add("@pbranchcode", SqlDbType.VarChar);
                if ((branchcode != "") && (branchcode != "--Select Branch--") && (branchcode != "0"))
                {
                    objSqlCommand.Parameters["@pbranchcode"].Value = branchcode;
                }
                else
                {
                    objSqlCommand.Parameters["@pbranchcode"].Value = System.DBNull.Value;
                }

                objSqlCommand.Parameters.Add("@ppublcode", SqlDbType.VarChar);
                if ((publication != "") && (publication != "--Select Publication--") && (publication != "0"))
                {
                    objSqlCommand.Parameters["@ppublcode"].Value = publication;
                }
                else
                {
                    objSqlCommand.Parameters["@ppublcode"].Value = System.DBNull.Value;
                }

                objSqlCommand.Parameters.Add("@padtype", SqlDbType.VarChar);
                if ((adtype != "") && (adtype != "--Select Ad Type--") && (adtype != "0"))
                {
                    objSqlCommand.Parameters["@padtype"].Value = adtype;
                }
                else
                {
                    objSqlCommand.Parameters["@padtype"].Value = System.DBNull.Value;

                }

                objSqlCommand.Parameters.Add("@pcatgcode", SqlDbType.VarChar);
                if ((catgcode != "") && (catgcode != "--Select Ad Cat--"))
                {
                    objSqlCommand.Parameters["@pcatgcode"].Value = catgcode;
                }
                else
                {
                    objSqlCommand.Parameters["@pcatgcode"].Value = System.DBNull.Value;
                }


                objSqlCommand.Parameters.Add("@pdatefrom", SqlDbType.DateTime);
                if (dateformat == "dd/mm/yyyy")
                {
                    string[] arr = fromdate.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    fromdate = mm + "/" + dd + "/" + yy;
                }
                else if (dateformat == "yyyy/mm/dd")
                {
                    string[] arr = fromdate.Split('/');
                    string dd = arr[2];
                    string mm = arr[1];
                    string yy = arr[0];
                    fromdate = mm + "/" + dd + "/" + yy;
                }
                objSqlCommand.Parameters["@pdatefrom"].Value = fromdate;

                objSqlCommand.Parameters.Add("@pdateto", SqlDbType.DateTime);
                if (dateformat == "dd/mm/yyyy")
                {
                    string[] arr = dateto.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    dateto = mm + "/" + dd + "/" + yy;
                }
                else if (dateformat == "yyyy/mm/dd")
                {
                    string[] arr = dateto.Split('/');
                    string dd = arr[2];
                    string mm = arr[1];
                    string yy = arr[0];
                    dateto = mm + "/" + dd + "/" + yy;
                }
                objSqlCommand.Parameters["@pdateto"].Value = dateto;

                objSqlCommand.Parameters.Add("@puserid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@puserid"].Value = useid;

                objSqlCommand.Parameters.Add("@pdateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdateformat"].Value = dateformat;

                objSqlCommand.Parameters.Add("@pextra1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra1"].Value = ext1;

                objSqlCommand.Parameters.Add("@pextra2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra2"].Value = ext2;

                objSqlCommand.Parameters.Add("@pextra3", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra3"].Value = ext3;

                objSqlCommand.Parameters.Add("@pextra4", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra4"].Value = ext4;

                objSqlCommand.Parameters.Add("@pextra5", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra5"].Value = ext5;

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
        public DataSet bind_function(string compcode, string catcode, string value)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand = new SqlCommand();
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                string query = "select  dbo.AD_GET_catnameE('" + compcode + "','" + catcode + "','" + value + "')";
                objSqlCommand.CommandText = query;
                objSqlCommand.Connection = objSqlConnection;
                //cmd.ExecuteNonQuery();

                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return (objDataSet);


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

        public DataSet bind_publication(string compcode, string pubcode,string value)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand = new SqlCommand();
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                string query = "select  dbo.AD_GET_catnameE('" + compcode + "','" + pubcode + "','publication')";
                objSqlCommand.CommandText = query;
                objSqlCommand.Connection = objSqlConnection;
                //cmd.ExecuteNonQuery();

                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return (objDataSet);


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


        public DataSet subcategory_billing(string compcode, string printcenter, string branchcode, string publication, string adtype, string catgcode, string fromdate, string dateto, string useid, string dateformat, string ext1, string ext2, string ext3, string ext4, string ext5)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("rpt_category_dt_summary_rpt_category_dt_billing", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcompcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@ppcentcode", SqlDbType.VarChar);
                if ((printcenter != "") && (printcenter != "--Select Printing Center--") && (printcenter != "0"))
                {
                    objSqlCommand.Parameters["@ppcentcode"].Value = printcenter;
                }
                else
                {
                    objSqlCommand.Parameters["@ppcentcode"].Value = System.DBNull.Value;
                }


                objSqlCommand.Parameters.Add("@punitcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@punitcode"].Value = System.DBNull.Value;

                objSqlCommand.Parameters.Add("@pextra2", SqlDbType.VarChar);
                if ((branchcode != "") && (branchcode != "--Select Branch--") && (branchcode != "0"))
                {
                    objSqlCommand.Parameters["@pextra2"].Value = branchcode;
                }
                else
                {
                    objSqlCommand.Parameters["@pextra2"].Value = System.DBNull.Value;
                }

                objSqlCommand.Parameters.Add("@ppublcode", SqlDbType.VarChar);
                if ((publication != "") && (publication != "--Select Publication--") && (publication != "0"))
                {
                    objSqlCommand.Parameters["@ppublcode"].Value = publication;
                }
                else
                {
                    objSqlCommand.Parameters["@ppublcode"].Value = System.DBNull.Value;
                }

                objSqlCommand.Parameters.Add("@padtype", SqlDbType.VarChar);
                if ((adtype != "") && (adtype != "--Select Ad Type--") && (adtype != "0"))
                {
                    objSqlCommand.Parameters["@padtype"].Value = adtype;
                }
                else
                {
                    objSqlCommand.Parameters["@padtype"].Value = System.DBNull.Value;

                }

                objSqlCommand.Parameters.Add("@padcat", SqlDbType.VarChar);
                if ((catgcode != "") && (catgcode != "--Select Ad Cat--"))
                {
                    objSqlCommand.Parameters["@padcat"].Value = catgcode;
                }
                else
                {
                    objSqlCommand.Parameters["@padcat"].Value = System.DBNull.Value;
                }


                objSqlCommand.Parameters.Add("@pfrom_date", SqlDbType.DateTime);
                if (dateformat == "dd/mm/yyyy")
                {
                    string[] arr = fromdate.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    fromdate = mm + "/" + dd + "/" + yy;
                }
                else if (dateformat == "yyyy/mm/dd")
                {
                    string[] arr = fromdate.Split('/');
                    string dd = arr[2];
                    string mm = arr[1];
                    string yy = arr[0];
                    fromdate = mm + "/" + dd + "/" + yy;
                }
                objSqlCommand.Parameters["@pfrom_date"].Value = fromdate;

                objSqlCommand.Parameters.Add("@ptill_date", SqlDbType.DateTime);
                if (dateformat == "dd/mm/yyyy")
                {
                    string[] arr = dateto.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    dateto = mm + "/" + dd + "/" + yy;
                }
                else if (dateformat == "yyyy/mm/dd")
                {
                    string[] arr = dateto.Split('/');
                    string dd = arr[2];
                    string mm = arr[1];
                    string yy = arr[0];
                    dateto = mm + "/" + dd + "/" + yy;
                }
                objSqlCommand.Parameters["@ptill_date"].Value = dateto;

                objSqlCommand.Parameters.Add("@puserid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@puserid"].Value = useid;

                objSqlCommand.Parameters.Add("@pdateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdateformat"].Value = dateformat;

                objSqlCommand.Parameters.Add("@pextra1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra1"].Value = System.DBNull.Value;

                objSqlCommand.Parameters.Add("@pextra3", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra3"].Value = System.DBNull.Value;

                objSqlCommand.Parameters.Add("@pextra4", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra4"].Value = System.DBNull.Value;

                objSqlCommand.Parameters.Add("@pextra5", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra5"].Value = System.DBNull.Value;

                objSqlCommand.Parameters.Add("@padsubcat", SqlDbType.VarChar);
                if ((ext1 != "") && (ext1 != "0"))
                {
                    objSqlCommand.Parameters["@padsubcat"].Value = ext1;
                }
                else
                {
                    objSqlCommand.Parameters["@padsubcat"].Value = System.DBNull.Value;
                }


                objSqlCommand.Parameters.Add("@pexecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pexecode"].Value = System.DBNull.Value;

                objSqlCommand.Parameters.Add("@pteamcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pteamcode"].Value = System.DBNull.Value;


                objSqlCommand.Parameters.Add("@pedtncode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pedtncode"].Value = System.DBNull.Value;


                objSqlCommand.Parameters.Add("@pdist_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdist_code"].Value = System.DBNull.Value;


                objSqlCommand.Parameters.Add("@pad_subcat5", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pad_subcat5"].Value = System.DBNull.Value;


                objSqlCommand.Parameters.Add("@pad_subcat4", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pad_subcat4"].Value = System.DBNull.Value;


                objSqlCommand.Parameters.Add("@pad_subcat3", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pad_subcat3"].Value = System.DBNull.Value;


             



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


    }
}