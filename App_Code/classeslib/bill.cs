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
/// Summary description for bill
/// </summary>
/// 

namespace NewAdbooking.Classes
{
    public class bill : connection
    {
        public bill()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataSet barter_report(string frmdt, string todate, string compcode, string region, string product, string dateformate, string descid, string ascdesc)
        {
            SqlConnection objsqlcon = new SqlConnection();
            SqlCommand objsqlcom;
            objsqlcon = GetConnection();
            SqlDataAdapter objsqldap = new SqlDataAdapter();
            DataSet objdataset = new DataSet();
            try
            {

                objsqlcon.Open();
                objsqlcom = GetCommand("bill_report", ref objsqlcon);
                objsqlcom.CommandType = CommandType.StoredProcedure;

                objsqlcom.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (frmdt != "")
                {
                    objsqlcom.Parameters["@fromdate"].Value = frmdt;
                }
                else
                {
                    objsqlcom.Parameters["@fromdate"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (todate != "")
                {
                    objsqlcom.Parameters["@dateto"].Value = todate;
                }
                else
                {
                    objsqlcom.Parameters["@dateto"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@region", SqlDbType.VarChar);
                if (region != "0")
                {
                    objsqlcom.Parameters["@region"].Value = region;
                }
                else
                {
                    objsqlcom.Parameters["@region"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@product", SqlDbType.VarChar);
                if (product != "0")
                {
                    objsqlcom.Parameters["@product"].Value = product;
                }
                else
                {
                    objsqlcom.Parameters["@product"].Value = System.DBNull.Value;
                }



                objsqlcom.Parameters.Add("@compcode", SqlDbType.VarChar);
                objsqlcom.Parameters["@compcode"].Value = compcode;

                objsqlcom.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objsqlcom.Parameters["@dateformat"].Value = dateformate;


                objsqlcom.Parameters.Add("@descid", SqlDbType.VarChar);
                objsqlcom.Parameters["@descid"].Value = descid;



                objsqlcom.Parameters.Add("@ascdesc", SqlDbType.VarChar);
                objsqlcom.Parameters["@ascdesc"].Value = ascdesc;


                objsqldap.SelectCommand = objsqlcom;
                objsqldap.Fill(objdataset);

                return objdataset;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objsqlcon);
            }


        }


        public SqlDataReader barter_reportexcel(string frmdt, string todate, string compcode, string region, string product, string dateformate)
        {
            SqlConnection objsqlcon = new SqlConnection();
            SqlCommand objsqlcom;
            objsqlcon = GetConnection();
            SqlDataAdapter objsqldap = new SqlDataAdapter();
            DataSet objdataset = new DataSet();

            try
            {

                objsqlcon.Open();
                objsqlcom = GetCommand("bill_report", ref objsqlcon);
                objsqlcom.CommandType = CommandType.StoredProcedure;
              
             
                objsqlcom.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (frmdt != "")
                {
                    objsqlcom.Parameters["@fromdate"].Value = frmdt;
                }
                else
                {
                    objsqlcom.Parameters["@fromdate"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (todate != "")
                {
                    objsqlcom.Parameters["@dateto"].Value = todate;
                }
                else
                {
                    objsqlcom.Parameters["@dateto"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@region", SqlDbType.VarChar);
                if (region != "0")
                {
                    objsqlcom.Parameters["@region"].Value = region;
                }
                else
                {
                    objsqlcom.Parameters["@region"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@product", SqlDbType.VarChar);
                if (product != "0")
                {
                    objsqlcom.Parameters["@product"].Value = product;
                }
                else
                {
                    objsqlcom.Parameters["@product"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@compcode", SqlDbType.VarChar);
                objsqlcom.Parameters["@compcode"].Value = compcode;

              
             

                objsqlcom.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objsqlcom.Parameters["@dateformat"].Value = dateformate;


                objsqldap.SelectCommand = objsqlcom;
                SqlDataReader objdatareadre = objsqlcom.ExecuteReader();

                return objdatareadre;
               

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                //CloseConnection(ref objsqlcon);
            }


        }


        public DataSet value_pub(string frmdt, string todate, string compcode, string product, string dateformate, string descid, string ascdesc)
        {
            SqlConnection objsqlcon = new SqlConnection();
            SqlCommand objsqlcom;
            objsqlcon = GetConnection();
            SqlDataAdapter objsqldap = new SqlDataAdapter();
            DataSet objdataset = new DataSet();
            try
            {

                objsqlcon.Open();
                objsqlcom = GetCommand("bill_report", ref objsqlcon);
                objsqlcom.CommandType = CommandType.StoredProcedure;

                objsqlcom.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (frmdt != "")
                {
                    objsqlcom.Parameters["@fromdate"].Value = frmdt;
                }
                else
                {
                    objsqlcom.Parameters["@fromdate"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (todate != "")
                {
                    objsqlcom.Parameters["@dateto"].Value = todate;
                }
                else
                {
                    objsqlcom.Parameters["@dateto"].Value = System.DBNull.Value;
                }

                //objsqlcom.Parameters.Add("@region", SqlDbType.VarChar);
                //if (region != "")
                //{
                //    objsqlcom.Parameters["@region"].Value = region;
                //}
                //else
                //{
                //    objsqlcom.Parameters["@region"].Value = System.DBNull.Value;
                //}
                objsqlcom.Parameters.Add("@product", SqlDbType.VarChar);
                if (product != "0")
                {
                    objsqlcom.Parameters["@product"].Value = product;
                }
                else
                {
                    objsqlcom.Parameters["@product"].Value = System.DBNull.Value;
                }



                objsqlcom.Parameters.Add("@compcode", SqlDbType.VarChar);
                objsqlcom.Parameters["@compcode"].Value = compcode;

                objsqlcom.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objsqlcom.Parameters["@dateformat"].Value = dateformate;


                objsqlcom.Parameters.Add("@descid", SqlDbType.VarChar);
                objsqlcom.Parameters["@descid"].Value = descid;



                objsqlcom.Parameters.Add("@ascdesc", SqlDbType.VarChar);
                objsqlcom.Parameters["@ascdesc"].Value = ascdesc;



                objsqldap.SelectCommand = objsqlcom;
                objsqldap.Fill(objdataset);

                return objdataset;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objsqlcon);
            }


        }


        public SqlDataReader value_pubexcel(string frmdt, string todate, string compcode, string product, string dateformate)
        {
            SqlConnection objsqlcon = new SqlConnection();
            SqlCommand objsqlcom;
            objsqlcon = GetConnection();
            SqlDataAdapter objsqldap = new SqlDataAdapter();
            DataSet objdataset = new DataSet();

            try
            {

                objsqlcon.Open();
                objsqlcom = GetCommand("bill_report", ref objsqlcon);
                objsqlcom.CommandType = CommandType.StoredProcedure;


                objsqlcom.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (frmdt != "")
                {
                    objsqlcom.Parameters["@fromdate"].Value = frmdt;
                }
                else
                {
                    objsqlcom.Parameters["@fromdate"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (todate != "")
                {
                    objsqlcom.Parameters["@dateto"].Value = todate;
                }
                else
                {
                    objsqlcom.Parameters["@dateto"].Value = System.DBNull.Value;
                }

                //objsqlcom.Parameters.Add("@region", SqlDbType.VarChar);
                //if (region != "")
                //{
                //    objsqlcom.Parameters["@region"].Value = region;
                //}
                //else
                //{
                //    objsqlcom.Parameters["@region"].Value = System.DBNull.Value;
                //}
                objsqlcom.Parameters.Add("@product", SqlDbType.VarChar);
                if (product != "0")
                {
                    objsqlcom.Parameters["@product"].Value = product;
                }
                else
                {
                    objsqlcom.Parameters["@product"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@compcode", SqlDbType.VarChar);
                objsqlcom.Parameters["@compcode"].Value = compcode;




                objsqlcom.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objsqlcom.Parameters["@dateformat"].Value = dateformate;


                objsqldap.SelectCommand = objsqlcom;
                SqlDataReader objdatareadre = objsqlcom.ExecuteReader();

                return objdatareadre;


            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                //CloseConnection(ref objsqlcon);
            }


        }
        public DataSet valuereportregion(string frmdt, string todate, string compcode, string region, string product, string dateformate, string descid, string ascdesc)
        {
            SqlConnection objsqlcon = new SqlConnection();
            SqlCommand objsqlcom;
            objsqlcon = GetConnection();
            SqlDataAdapter objsqldap = new SqlDataAdapter();
            DataSet objdataset = new DataSet();
            try
            {

                objsqlcon.Open();
                objsqlcom = GetCommand("bill_report", ref objsqlcon);
                objsqlcom.CommandType = CommandType.StoredProcedure;

                objsqlcom.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (frmdt != "")
                {
                    objsqlcom.Parameters["@fromdate"].Value = frmdt;
                }
                else
                {
                    objsqlcom.Parameters["@fromdate"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (todate != "")
                {
                    objsqlcom.Parameters["@dateto"].Value = todate;
                }
                else
                {
                    objsqlcom.Parameters["@dateto"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@region", SqlDbType.VarChar);
                if (region != "0")
                {
                    objsqlcom.Parameters["@region"].Value = region;
                }
                else
                {
                    objsqlcom.Parameters["@region"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@product", SqlDbType.VarChar);
                if (product != "0")
                {
                    objsqlcom.Parameters["@product"].Value = product;
                }
                else
                {
                    objsqlcom.Parameters["@product"].Value = System.DBNull.Value;
                }



                objsqlcom.Parameters.Add("@compcode", SqlDbType.VarChar);
                objsqlcom.Parameters["@compcode"].Value = compcode;

                objsqlcom.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objsqlcom.Parameters["@dateformat"].Value = dateformate;

                objsqlcom.Parameters.Add("@descid", SqlDbType.VarChar);
                objsqlcom.Parameters["@descid"].Value = descid;



                objsqlcom.Parameters.Add("@ascdesc", SqlDbType.VarChar);
                objsqlcom.Parameters["@ascdesc"].Value = ascdesc;


                objsqldap.SelectCommand = objsqlcom;
                objsqldap.Fill(objdataset);

                return objdataset;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objsqlcon);
            }


        }
        
        public SqlDataReader valuereportexcel(string frmdt, string todate, string compcode, string region, string product, string dateformate)
        {
            SqlConnection objsqlcon = new SqlConnection();
            SqlCommand objsqlcom;
            objsqlcon = GetConnection();
            SqlDataAdapter objsqldap = new SqlDataAdapter();
            DataSet objdataset = new DataSet();

            try
            {

                objsqlcon.Open();
                objsqlcom = GetCommand("bill_report", ref objsqlcon);
                objsqlcom.CommandType = CommandType.StoredProcedure;

                objsqlcom.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (frmdt != "")
                {
                    objsqlcom.Parameters["@fromdate"].Value = frmdt;
                }
                else
                {
                    objsqlcom.Parameters["@fromdate"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (todate != "")
                {
                    objsqlcom.Parameters["@dateto"].Value = todate;
                }
                else
                {
                    objsqlcom.Parameters["@dateto"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@region", SqlDbType.VarChar);
                if (region != "0")
                {
                    objsqlcom.Parameters["@region"].Value = region;
                }
                else
                {
                    objsqlcom.Parameters["@region"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@product", SqlDbType.VarChar);
                if (product != "0")
                {
                    objsqlcom.Parameters["@product"].Value = product;
                }
                else
                {
                    objsqlcom.Parameters["@product"].Value = System.DBNull.Value;
                }



                objsqlcom.Parameters.Add("@compcode", SqlDbType.VarChar);
                objsqlcom.Parameters["@compcode"].Value = compcode;

                objsqlcom.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objsqlcom.Parameters["@dateformat"].Value = dateformate;

                objsqldap.SelectCommand = objsqlcom;
                SqlDataReader objdatareadre = objsqlcom.ExecuteReader();

                return objdatareadre;
                //objsqldap.Fill(objdataset);

                //return objdataset;



            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                //CloseConnection(ref objsqlcon);
            }


        }

        public DataSet regionrebate(string frmdt, string todate, string compcode, string region, string product, string category, string dateformate, string descid, string ascdesc)
        {
            SqlConnection objsqlcon = new SqlConnection();
            SqlCommand objsqlcom;
            objsqlcon = GetConnection();
            SqlDataAdapter objsqldap = new SqlDataAdapter();
            DataSet objdataset = new DataSet();
            try
            {

                objsqlcon.Open();
                objsqlcom = GetCommand("bill_report", ref objsqlcon);
                objsqlcom.CommandType = CommandType.StoredProcedure;

                objsqlcom.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (frmdt != "")
                {
                    objsqlcom.Parameters["@fromdate"].Value = frmdt;
                }
                else
                {
                    objsqlcom.Parameters["@fromdate"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (todate != "")
                {
                    objsqlcom.Parameters["@dateto"].Value = todate;
                }
                else
                {
                    objsqlcom.Parameters["@dateto"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@region", SqlDbType.VarChar);
                if (region != "0")
                {
                    objsqlcom.Parameters["@region"].Value = region;
                }
                else
                {
                    objsqlcom.Parameters["@region"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@product", SqlDbType.VarChar);
                if (product != "0")
                {
                    objsqlcom.Parameters["@product"].Value = product;
                }
                else
                {
                    objsqlcom.Parameters["@product"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@category", SqlDbType.VarChar);
                if (category != "0")
                {
                    objsqlcom.Parameters["@category"].Value = category;
                }
                else
                {
                    objsqlcom.Parameters["@category"].Value = System.DBNull.Value;
                }



                objsqlcom.Parameters.Add("@compcode", SqlDbType.VarChar);
                objsqlcom.Parameters["@compcode"].Value = compcode;

                objsqlcom.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objsqlcom.Parameters["@dateformat"].Value = dateformate;


                objsqlcom.Parameters.Add("@descid", SqlDbType.VarChar);
                objsqlcom.Parameters["@descid"].Value = descid;



                objsqlcom.Parameters.Add("@ascdesc", SqlDbType.VarChar);
                objsqlcom.Parameters["@ascdesc"].Value = ascdesc;


                objsqldap.SelectCommand = objsqlcom;
                objsqldap.Fill(objdataset);

                return objdataset;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objsqlcon);
            }


        }

        public SqlDataReader regionrebateexcel(string frmdt, string todate, string compcode, string region, string product,string category, string dateformate)
        {
            SqlConnection objsqlcon = new SqlConnection();
            SqlCommand objsqlcom;
            objsqlcon = GetConnection();
            SqlDataAdapter objsqldap = new SqlDataAdapter();
            DataSet objdataset = new DataSet();

            try
            {

                objsqlcon.Open();
                objsqlcom = GetCommand("bill_report", ref objsqlcon);
                objsqlcom.CommandType = CommandType.StoredProcedure;

                objsqlcom.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (frmdt != "")
                {
                    objsqlcom.Parameters["@fromdate"].Value = frmdt;
                }
                else
                {
                    objsqlcom.Parameters["@fromdate"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (todate != "")
                {
                    objsqlcom.Parameters["@dateto"].Value = todate;
                }
                else
                {
                    objsqlcom.Parameters["@dateto"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@region", SqlDbType.VarChar);
                if (region != "0")
                {
                    objsqlcom.Parameters["@region"].Value = region;
                }
                else
                {
                    objsqlcom.Parameters["@region"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@product", SqlDbType.VarChar);
                if (product != "0")
                {
                    objsqlcom.Parameters["@product"].Value = product;
                }
                else
                {
                    objsqlcom.Parameters["@product"].Value = System.DBNull.Value;
                }


                objsqlcom.Parameters.Add("@category", SqlDbType.VarChar);
                if (category != "0")
                {
                    objsqlcom.Parameters["@category"].Value = category;
                }
                else
                {
                    objsqlcom.Parameters["@category"].Value = System.DBNull.Value;
                } 

                objsqlcom.Parameters.Add("@compcode", SqlDbType.VarChar);
                objsqlcom.Parameters["@compcode"].Value = compcode;

                objsqlcom.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objsqlcom.Parameters["@dateformat"].Value = dateformate;

                objsqldap.SelectCommand = objsqlcom;
                SqlDataReader objdatareadre = objsqlcom.ExecuteReader();

                return objdatareadre;
                //objsqldap.Fill(objdataset);

                //return objdataset;



            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                //CloseConnection(ref objsqlcon);
            }


        }
        public DataSet pubrebate(string frmdt, string todate, string compcode, string category, string product, string dateformate, string descid, string ascdesc)
        {
            SqlConnection objsqlcon = new SqlConnection();
            SqlCommand objsqlcom;
            objsqlcon = GetConnection();
            SqlDataAdapter objsqldap = new SqlDataAdapter();
            DataSet objdataset = new DataSet();
            try
            {

                objsqlcon.Open();
                objsqlcom = GetCommand("bill_report", ref objsqlcon);
                objsqlcom.CommandType = CommandType.StoredProcedure;

                objsqlcom.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (frmdt != "")
                {
                    objsqlcom.Parameters["@fromdate"].Value = frmdt;
                }
                else
                {
                    objsqlcom.Parameters["@fromdate"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (todate != "")
                {
                    objsqlcom.Parameters["@dateto"].Value = todate;
                }
                else
                {
                    objsqlcom.Parameters["@dateto"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@category", SqlDbType.VarChar);
                if (category != "0")
                {
                    objsqlcom.Parameters["@category"].Value = category;
                }
                else
                {
                    objsqlcom.Parameters["@category"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@product", SqlDbType.VarChar);
                if (product != "0")
                {
                    objsqlcom.Parameters["@product"].Value = product;
                }
                else
                {
                    objsqlcom.Parameters["@product"].Value = System.DBNull.Value;
                }



                objsqlcom.Parameters.Add("@compcode", SqlDbType.VarChar);
                objsqlcom.Parameters["@compcode"].Value = compcode;

                objsqlcom.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objsqlcom.Parameters["@dateformat"].Value = dateformate;

                objsqlcom.Parameters.Add("@descid", SqlDbType.VarChar);
                objsqlcom.Parameters["@descid"].Value = descid;



                objsqlcom.Parameters.Add("@ascdesc", SqlDbType.VarChar);
                objsqlcom.Parameters["@ascdesc"].Value = ascdesc;


                objsqldap.SelectCommand = objsqlcom;
                objsqldap.Fill(objdataset);

                return objdataset;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objsqlcon);
            }


        }
        public SqlDataReader pubrebateexcel(string frmdt, string todate, string compcode, string category, string product, string dateformate)
        {
            SqlConnection objsqlcon = new SqlConnection();
            SqlCommand objsqlcom;
            objsqlcon = GetConnection();
            SqlDataAdapter objsqldap = new SqlDataAdapter();
            DataSet objdataset = new DataSet();

            try
            {

                objsqlcon.Open();
                objsqlcom = GetCommand("bill_report", ref objsqlcon);
                objsqlcom.CommandType = CommandType.StoredProcedure;

                objsqlcom.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (frmdt != "")
                {
                    objsqlcom.Parameters["@fromdate"].Value = frmdt;
                }
                else
                {
                    objsqlcom.Parameters["@fromdate"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (todate != "")
                {
                    objsqlcom.Parameters["@dateto"].Value = todate;
                }
                else
                {
                    objsqlcom.Parameters["@dateto"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@category", SqlDbType.VarChar);
                if (category != "0")
                {
                    objsqlcom.Parameters["@category"].Value = category;
                }
                else
                {
                    objsqlcom.Parameters["@category"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@product", SqlDbType.VarChar);
                if (product != "0")
                {
                    objsqlcom.Parameters["@product"].Value = product;
                }
                else
                {
                    objsqlcom.Parameters["@product"].Value = System.DBNull.Value;
                }



                objsqlcom.Parameters.Add("@compcode", SqlDbType.VarChar);
                objsqlcom.Parameters["@compcode"].Value = compcode;

                objsqlcom.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objsqlcom.Parameters["@dateformat"].Value = dateformate;

                objsqldap.SelectCommand = objsqlcom;
                SqlDataReader objdatareadre = objsqlcom.ExecuteReader();

                return objdatareadre;
                //objsqldap.Fill(objdataset);

                //return objdataset;



            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                //CloseConnection(ref objsqlcon);
            }


        }
        public DataSet Extra_report(string frmdt, string todate, string compcode, string region, string product, string dateformate, string category, string descid, string ascdesc)
        {
            SqlConnection objsqlcon = new SqlConnection();
            SqlCommand objsqlcom;
            objsqlcon = GetConnection();
            SqlDataAdapter objsqldap = new SqlDataAdapter();
            DataSet objdataset = new DataSet();
            try
            {

                objsqlcon.Open();
                objsqlcom = GetCommand("bill_report", ref objsqlcon);
                objsqlcom.CommandType = CommandType.StoredProcedure;

                objsqlcom.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (frmdt != "")
                {
                    objsqlcom.Parameters["@fromdate"].Value = frmdt;
                }
                else
                {
                    objsqlcom.Parameters["@fromdate"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (todate != "")
                {
                    objsqlcom.Parameters["@dateto"].Value = todate;
                }
                else
                {
                    objsqlcom.Parameters["@dateto"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@region", SqlDbType.VarChar);
                if (region != "0")
                {
                    objsqlcom.Parameters["@region"].Value = region;
                }
                else
                {
                    objsqlcom.Parameters["@region"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@product", SqlDbType.VarChar);
                if (product != "0")
                {
                    objsqlcom.Parameters["@product"].Value = product;
                }
                else
                {
                    objsqlcom.Parameters["@product"].Value = System.DBNull.Value;
                }



                objsqlcom.Parameters.Add("@compcode", SqlDbType.VarChar);
                objsqlcom.Parameters["@compcode"].Value = compcode;

                objsqlcom.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objsqlcom.Parameters["@dateformat"].Value = dateformate;


                //objsqlcom.Parameters.Add("@agname", SqlDbType.VarChar);
                objsqlcom.Parameters.Add("@category", SqlDbType.VarChar);
                if (category != "0")
                {
                    objsqlcom.Parameters["@category"].Value = category;
                }
                else
                {
                    objsqlcom.Parameters["@category"].Value = System.DBNull.Value;

                }

                objsqlcom.Parameters.Add("@descid", SqlDbType.VarChar);
                objsqlcom.Parameters["@descid"].Value = descid;



                objsqlcom.Parameters.Add("@ascdesc", SqlDbType.VarChar);
                objsqlcom.Parameters["@ascdesc"].Value = ascdesc;




                objsqldap.SelectCommand = objsqlcom;
                objsqldap.Fill(objdataset);

                return objdataset;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objsqlcon);
            }
        }





        public SqlDataReader Extra_reportexcel(string frmdt, string todate, string compcode, string region, string product, string dateformate, string category)
        {
            SqlConnection objsqlcon = new SqlConnection();
            SqlCommand objsqlcom;
            objsqlcon = GetConnection();
            SqlDataAdapter objsqldap = new SqlDataAdapter();
            DataSet objdataset = new DataSet();

            try
            {

                objsqlcon.Open();
                objsqlcom = GetCommand("bill_report", ref objsqlcon);
                objsqlcom.CommandType = CommandType.StoredProcedure;


                objsqlcom.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (frmdt != "")
                {
                    objsqlcom.Parameters["@fromdate"].Value = frmdt;
                }
                else
                {
                    objsqlcom.Parameters["@fromdate"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (todate != "")
                {
                    objsqlcom.Parameters["@dateto"].Value = todate;
                }
                else
                {
                    objsqlcom.Parameters["@dateto"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@region", SqlDbType.VarChar);
                if (region != "0")
                {
                    objsqlcom.Parameters["@region"].Value = region;
                }
                else
                {
                    objsqlcom.Parameters["@region"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@product", SqlDbType.VarChar);
                if (product != "0")
                {
                    objsqlcom.Parameters["@product"].Value = product;
                }
                else
                {
                    objsqlcom.Parameters["@product"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@compcode", SqlDbType.VarChar);
                objsqlcom.Parameters["@compcode"].Value = compcode;




                objsqlcom.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objsqlcom.Parameters["@dateformat"].Value = dateformate;
                objsqlcom.Parameters.Add("@category", SqlDbType.VarChar);
                if (category != "")
                {
                    objsqlcom.Parameters["@category"].Value = category;
                }
                else
                {
                    objsqlcom.Parameters["@category"].Value = System.DBNull.Value;
                }


                objsqldap.SelectCommand = objsqlcom;
                SqlDataReader objdatareadre = objsqlcom.ExecuteReader();

                return objdatareadre;


            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                //CloseConnection(ref objsqlcon);
            }


        }

        public DataSet bindregionname(string compcode)
        {
            SqlConnection objsqlcon = new SqlConnection();
            SqlCommand objsqlcom;
            objsqlcon = GetConnection();
            SqlDataAdapter objsqldap = new SqlDataAdapter();
            DataSet objdataset = new DataSet();
            try
            {

                objsqlcon.Open();
                objsqlcom = GetCommand("sp_region", ref objsqlcon);
                objsqlcom.CommandType = CommandType.StoredProcedure;

                objsqlcom.Parameters.Add("@Compcode", SqlDbType.VarChar);
                objsqlcom.Parameters["@Compcode"].Value = compcode;


                objsqldap.SelectCommand = objsqlcom;
                objsqldap.Fill(objdataset);

                return objdataset;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objsqlcon);
            }
        }

        public DataSet bindProductcategory(string region, string compcode)
        {
            SqlConnection objsqlcon = new SqlConnection();
            SqlCommand objsqlcom;
            objsqlcon = GetConnection();
            SqlDataAdapter objsqldap = new SqlDataAdapter();
            DataSet objdataset = new DataSet();
            try
            {

                objsqlcon.Open();
                objsqlcom = GetCommand("An_publicationreport", ref objsqlcon);
                objsqlcom.CommandType = CommandType.StoredProcedure;

                objsqlcom.Parameters.Add("@Compcode", SqlDbType.VarChar);
                objsqlcom.Parameters["@Compcode"].Value = compcode;

                objsqlcom.Parameters.Add("@regioncode", SqlDbType.VarChar);
                objsqlcom.Parameters["@regioncode"].Value = region;



                objsqldap.SelectCommand = objsqlcom;
                objsqldap.Fill(objdataset);

                return objdataset;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objsqlcon);
            }
        }


        public DataSet billingonscreen(string fromdate, string dateto, string region, string product, string category, string compcode, string dateformat,string descid,string ascdesc)
        {
            SqlConnection objsqlcon = new SqlConnection();
            SqlCommand objsqlcom;
            objsqlcon = GetConnection();
            SqlDataAdapter objsqldap = new SqlDataAdapter();
            DataSet objdataset = new DataSet();

            try
            {

                objsqlcon.Open();
                objsqlcom = GetCommand("bill_report", ref objsqlcon);
                objsqlcom.CommandType = CommandType.StoredProcedure;

                objsqlcom.Parameters.Add("@region", SqlDbType.VarChar);
                if (region != "0")
                {
                    objsqlcom.Parameters["@region"].Value = region;
                }
                else
                {
                    objsqlcom.Parameters["@region"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@product", SqlDbType.VarChar);
                if (product != "0")
                {
                    objsqlcom.Parameters["@product"].Value = product;
                }

                else
                {
                    objsqlcom.Parameters["@product"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@category", SqlDbType.VarChar);
                if (category != "0")
                {
                    objsqlcom.Parameters["@category"].Value = category;
                }
                else
                {
                    objsqlcom.Parameters["@category"].Value = System.DBNull.Value;
                }


                objsqlcom.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (fromdate != "")
                {
                    objsqlcom.Parameters["@fromdate"].Value = fromdate;
                }
                else
                {
                    objsqlcom.Parameters["@fromdate"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (dateto != "")
                {
                    objsqlcom.Parameters["@dateto"].Value = dateto;
                }
                else
                {
                    objsqlcom.Parameters["@dateto"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@compcode", SqlDbType.VarChar);
                objsqlcom.Parameters["@compcode"].Value = compcode;



                objsqlcom.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objsqlcom.Parameters["@dateformat"].Value = dateformat;


                objsqlcom.Parameters.Add("@descid", SqlDbType.VarChar);
                objsqlcom.Parameters["@descid"].Value = descid;



                objsqlcom.Parameters.Add("@ascdesc", SqlDbType.VarChar);
                objsqlcom.Parameters["@ascdesc"].Value = ascdesc;




                objsqldap.SelectCommand = objsqlcom;
                objsqldap.Fill(objdataset);

                return objdataset;



            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objsqlcon);
            }

        }

        public SqlDataReader Billingrepexcel(string fromdate, string dateto, string region, string product, string category, string compcode, string dateformat)
        {
            SqlConnection objsqlcon = new SqlConnection();
            SqlCommand objsqlcom;
            objsqlcon = GetConnection();
            SqlDataAdapter objsqldap = new SqlDataAdapter();
            DataSet objdataset = new DataSet();

            try
            {

                objsqlcon.Open();
                objsqlcom = GetCommand("bill_report", ref objsqlcon);
                objsqlcom.CommandType = CommandType.StoredProcedure;

                objsqlcom.Parameters.Add("@region", SqlDbType.VarChar);
                if (region != "0")
                {
                    objsqlcom.Parameters["@region"].Value = region;
                }
                else
                {
                    objsqlcom.Parameters["@region"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@product", SqlDbType.VarChar);
                if (product != "0")
                {
                    objsqlcom.Parameters["@product"].Value = product;
                }

                else
                {
                    objsqlcom.Parameters["@product"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@category", SqlDbType.VarChar);
                if (category != "0")
                {
                    objsqlcom.Parameters["@category"].Value = category;
                }
                else
                {
                    objsqlcom.Parameters["@category"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (fromdate != "")
                {
                    objsqlcom.Parameters["@fromdate"].Value = fromdate;
                }
                else
                {
                    objsqlcom.Parameters["@fromdate"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (dateto != "")
                {
                    objsqlcom.Parameters["@dateto"].Value = dateto;
                }
                else
                {
                    objsqlcom.Parameters["@dateto"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@compcode", SqlDbType.VarChar);
                objsqlcom.Parameters["@compcode"].Value = compcode;



                objsqlcom.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objsqlcom.Parameters["@dateformat"].Value = dateformat;
                objsqldap.SelectCommand = objsqlcom;
                SqlDataReader objdatareadre = objsqlcom.ExecuteReader();

                return objdatareadre;
                //objsqldap.Fill(objdataset);

                //return objdataset;



            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                //CloseConnection(ref objsqlcon);
            }


        }

        public DataSet retainonscreen(string fromdate, string dateto, string region, string product, string compcode, string dateformat, string descid, string ascdesc)
        {
            SqlConnection objsqlcon = new SqlConnection();
            SqlCommand objsqlcom;
            objsqlcon = GetConnection();
            SqlDataAdapter objsqldap = new SqlDataAdapter();
            DataSet objdataset = new DataSet();

            try
            {

                objsqlcon.Open();
                objsqlcom = GetCommand("bill_report", ref objsqlcon);
                objsqlcom.CommandType = CommandType.StoredProcedure;

                objsqlcom.Parameters.Add("@region", SqlDbType.VarChar);
                if (region != "0")
                {
                    objsqlcom.Parameters["@region"].Value = region;
                }
                else
                {
                    objsqlcom.Parameters["@region"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@product", SqlDbType.VarChar);
                if (product != "0")
                {
                    objsqlcom.Parameters["@product"].Value = product;
                }

                else
                {
                    objsqlcom.Parameters["@product"].Value = System.DBNull.Value;
                }

                //objsqlcom.Parameters.Add("@category", SqlDbType.VarChar);
                //if (category != "")
                //{
                //    objsqlcom.Parameters["@category"].Value = category;
                //}
                //else
                //{
                //    objsqlcom.Parameters["@category"].Value = System.DBNull.Value;
                //}

                objsqlcom.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (fromdate != "")
                {
                    objsqlcom.Parameters["@fromdate"].Value = fromdate;
                }
                else
                {
                    objsqlcom.Parameters["@fromdate"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (dateto != "")
                {
                    objsqlcom.Parameters["@dateto"].Value = dateto;
                }
                else
                {
                    objsqlcom.Parameters["@dateto"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@compcode", SqlDbType.VarChar);
                objsqlcom.Parameters["@compcode"].Value = compcode;



                objsqlcom.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objsqlcom.Parameters["@dateformat"].Value = dateformat;
                objsqlcom.Parameters.Add("@descid", SqlDbType.VarChar);
                objsqlcom.Parameters["@descid"].Value = descid;



                objsqlcom.Parameters.Add("@ascdesc", SqlDbType.VarChar);
                objsqlcom.Parameters["@ascdesc"].Value = ascdesc;


                objsqldap.SelectCommand = objsqlcom;
                objsqldap.Fill(objdataset);

                return objdataset;



            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objsqlcon);
            }

        }


        public SqlDataReader retainexcel(string fromdate, string dateto, string region, string product, string compcode, string dateformat)
        {
            SqlConnection objsqlcon = new SqlConnection();
            SqlCommand objsqlcom;
            objsqlcon = GetConnection();
            SqlDataAdapter objsqldap = new SqlDataAdapter();
            DataSet objdataset = new DataSet();

            try
            {

                objsqlcon.Open();
                objsqlcom = GetCommand("bill_report", ref objsqlcon);
                objsqlcom.CommandType = CommandType.StoredProcedure;
                objsqlcom.Parameters.Add("@region", SqlDbType.VarChar);
                if (region != "0")
                {
                    objsqlcom.Parameters["@region"].Value = region;
                }
                else
                {
                    objsqlcom.Parameters["@region"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@product", SqlDbType.VarChar);
                if (product != "0")
                {
                    objsqlcom.Parameters["@product"].Value = product;
                }

                else
                {
                    objsqlcom.Parameters["@product"].Value = System.DBNull.Value;
                }

                //objsqlcom.Parameters.Add("@category", SqlDbType.VarChar);
                //if (category != "")
                //{
                //    objsqlcom.Parameters["@category"].Value = category;
                //}
                //else
                //{
                //    objsqlcom.Parameters["@category"].Value = System.DBNull.Value;
                //}

                objsqlcom.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (fromdate != "")
                {
                    objsqlcom.Parameters["@fromdate"].Value = fromdate;
                }
                else
                {
                    objsqlcom.Parameters["@fromdate"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (dateto != "")
                {
                    objsqlcom.Parameters["@dateto"].Value = dateto;
                }
                else
                {
                    objsqlcom.Parameters["@dateto"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@compcode", SqlDbType.VarChar);
                objsqlcom.Parameters["@compcode"].Value = compcode;



                objsqlcom.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objsqlcom.Parameters["@dateformat"].Value = dateformat;

                objsqldap.SelectCommand = objsqlcom;
                SqlDataReader objdatareadre = objsqlcom.ExecuteReader();

                return objdatareadre;
                //objsqldap.Fill(objdataset);

                //return objdataset;



            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                //CloseConnection(ref objsqlcon);
            }


        }







        public DataSet product(string region, string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("sp_publication", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@region", SqlDbType.VarChar);
                objSqlCommand.Parameters["@region"].Value = region;

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






        public DataSet payment(string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("an_payment", ref objSqlConnection);
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




        public DataSet retainname(string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("an_retainname", ref objSqlConnection);
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

        public DataSet billstatus()
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("an_billstatus", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                //objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@compcode"].Value = compcode;


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
        public DataSet drillout(string fromdate, string dateto, string region, string product, string category, string compcode, string dateformat, string agency, string client, string publication, string adtype, string payment, string billstatus, string myrange, string maxrange, string descid, string ascdesc)
        {
            SqlConnection objsqlcon = new SqlConnection();
            SqlCommand objsqlcom;
            objsqlcon = GetConnection();
            SqlDataAdapter objsqldap = new SqlDataAdapter();
            DataSet objdataset = new DataSet();

            try
            {

                objsqlcon.Open();
                objsqlcom = GetCommand("bill_drillout", ref objsqlcon);
                objsqlcom.CommandType = CommandType.StoredProcedure;

                objsqlcom.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (fromdate != "")
                {
                    objsqlcom.Parameters["@fromdate"].Value = fromdate;
                }
                else
                {
                    objsqlcom.Parameters["@fromdate"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (dateto != "")
                {
                    objsqlcom.Parameters["@dateto"].Value = dateto;
                }
                else
                {
                    objsqlcom.Parameters["@dateto"].Value = System.DBNull.Value;
                }




                objsqlcom.Parameters.Add("@region", SqlDbType.VarChar);
                if (region != "0")
                {
                    objsqlcom.Parameters["@region"].Value = region;
                }
                else
                {
                    objsqlcom.Parameters["@region"].Value = System.DBNull.Value;
                }

               
                objsqlcom.Parameters.Add("@compcode", SqlDbType.VarChar);
                objsqlcom.Parameters["@compcode"].Value = compcode;



                objsqlcom.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objsqlcom.Parameters["@dateformat"].Value = dateformat;


              
                objsqlcom.Parameters.Add("@agency", SqlDbType.VarChar);
                if (agency != "0")
                {
                    objsqlcom.Parameters["@agency"].Value = agency;
                }
                else
                {
                    objsqlcom.Parameters["@agency"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@client", SqlDbType.VarChar);
                if (client != "0")
                {
                    objsqlcom.Parameters["@client"].Value = client;
                }
                else
                {
                    objsqlcom.Parameters["@client"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@pub_cent", SqlDbType.VarChar);
                if (publication != "0")
                {
                    objsqlcom.Parameters["@pub_cent"].Value = publication;
                }
                else
                {
                    objsqlcom.Parameters["@pub_cent"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@adtype", SqlDbType.VarChar);
                if (adtype != "0")
                {
                    objsqlcom.Parameters["@adtype"].Value = adtype;
                }
                else
                {
                    objsqlcom.Parameters["@adtype"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@payment", SqlDbType.VarChar);
                if (payment != "0")
                {
                    objsqlcom.Parameters["@payment"].Value = payment;
                }
                else
                {
                    objsqlcom.Parameters["@payment"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@billstatus", SqlDbType.VarChar);
                if (billstatus != "0")
                {
                    objsqlcom.Parameters["@billstatus"].Value = billstatus;
                }
                else
                {
                    objsqlcom.Parameters["@billstatus"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@myrange", SqlDbType.VarChar);
                if (myrange != "0")
                {
                    objsqlcom.Parameters["@myrange"].Value = myrange;
                }
                else
                {
                    objsqlcom.Parameters["@myrange"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@maxrange", SqlDbType.VarChar);
                if (maxrange != "0")
                {
                    objsqlcom.Parameters["@maxrange"].Value = maxrange;
                }
                else
                {
                    objsqlcom.Parameters["@maxrange"].Value = System.DBNull.Value;
                }
                
                objsqlcom.Parameters.Add("@descid", SqlDbType.VarChar);
                if (descid != "0")
                {
                    objsqlcom.Parameters["@descid"].Value = descid;
                }
                else
                {
                    objsqlcom.Parameters["@descid"].Value = System.DBNull.Value;
                }


                objsqlcom.Parameters.Add("@ascdesc", SqlDbType.VarChar);
                if (ascdesc != "0")
                {
                    objsqlcom.Parameters["@ascdesc"].Value = ascdesc;
                }
                else
                {
                    objsqlcom.Parameters["@ascdesc"].Value = System.DBNull.Value;
                }
                





                objsqldap.SelectCommand = objsqlcom;
                objsqldap.Fill(objdataset);

                return objdataset;



            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objsqlcon);
            }

        }




        public SqlDataReader drillout_excelbill(string fromdate, string dateto, string region, string product, string category, string compcode, string dateformat, string agency, string client, string publication, string adtype, string payment, string billstatus, string myrange, string maxrange)
        {
            SqlConnection objsqlcon = new SqlConnection();
            SqlCommand objsqlcom;
            objsqlcon = GetConnection();
            SqlDataAdapter objsqldap = new SqlDataAdapter();
            DataSet objdataset = new DataSet();

            try
            {

                objsqlcon.Open();
                objsqlcom = GetCommand("bill_drillout", ref objsqlcon);
                objsqlcom.CommandType = CommandType.StoredProcedure;

                objsqlcom.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (fromdate != "")
                {
                    objsqlcom.Parameters["@fromdate"].Value = fromdate;
                }
                else
                {
                    objsqlcom.Parameters["@fromdate"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (dateto != "")
                {
                    objsqlcom.Parameters["@dateto"].Value = dateto;
                }
                else
                {
                    objsqlcom.Parameters["@dateto"].Value = System.DBNull.Value;
                }




                objsqlcom.Parameters.Add("@region", SqlDbType.VarChar);
                if (region != "0")
                {
                    objsqlcom.Parameters["@region"].Value = region;
                }
                else
                {
                    objsqlcom.Parameters["@region"].Value = System.DBNull.Value;
                }


                objsqlcom.Parameters.Add("@compcode", SqlDbType.VarChar);
                objsqlcom.Parameters["@compcode"].Value = compcode;



                objsqlcom.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objsqlcom.Parameters["@dateformat"].Value = dateformat;



                objsqlcom.Parameters.Add("@agency", SqlDbType.VarChar);
                if (agency != "0")
                {
                    objsqlcom.Parameters["@agency"].Value = agency;
                }
                else
                {
                    objsqlcom.Parameters["@agency"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@client", SqlDbType.VarChar);
                if (client != "0")
                {
                    objsqlcom.Parameters["@client"].Value = client;
                }
                else
                {
                    objsqlcom.Parameters["@client"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@pub_cent", SqlDbType.VarChar);
                if (publication != "0")
                {
                    objsqlcom.Parameters["@pub_cent"].Value = publication;
                }
                else
                {
                    objsqlcom.Parameters["@pub_cent"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@adtype", SqlDbType.VarChar);
                if (adtype != "0")
                {
                    objsqlcom.Parameters["@adtype"].Value = adtype;
                }
                else
                {
                    objsqlcom.Parameters["@adtype"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@payment", SqlDbType.VarChar);
                if (payment != "0")
                {
                    objsqlcom.Parameters["@payment"].Value = payment;
                }
                else
                {
                    objsqlcom.Parameters["@payment"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@billstatus", SqlDbType.VarChar);
                if (billstatus != "0")
                {
                    objsqlcom.Parameters["@billstatus"].Value = billstatus;
                }
                else
                {
                    objsqlcom.Parameters["@billstatus"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@myrange", SqlDbType.VarChar);
                if (myrange != "0")
                {
                    objsqlcom.Parameters["@myrange"].Value = myrange;
                }
                else
                {
                    objsqlcom.Parameters["@myrange"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@maxrange", SqlDbType.VarChar);
                if (maxrange != "0")
                {
                    objsqlcom.Parameters["@maxrange"].Value = maxrange;
                }
                else
                {
                    objsqlcom.Parameters["@maxrange"].Value = System.DBNull.Value;
                }




                objsqldap.SelectCommand = objsqlcom;
                SqlDataReader objdatareadre = objsqlcom.ExecuteReader();

                return objdatareadre;
                //objsqldap.Fill(objdataset);

                //return objdataset;



            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                //CloseConnection(ref objsqlcon);
            }


        }









        public DataSet drillout_barter(string fromdate, string todate, string compcode, string region, string dateformat, string publication, string agency, string client, string billstatus, string payment, string adtype, string descid, string ascdesc, string myrange, string maxrange)
        {
            SqlConnection objsqlcon = new SqlConnection();
            SqlCommand objsqlcom;
            objsqlcon = GetConnection();
            SqlDataAdapter objsqldap = new SqlDataAdapter();
            DataSet objdataset = new DataSet();

            try
            {

                objsqlcon.Open();
                objsqlcom = GetCommand("bill_drillout", ref objsqlcon);
                objsqlcom.CommandType = CommandType.StoredProcedure;

                objsqlcom.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (fromdate != "")
                {
                    objsqlcom.Parameters["@fromdate"].Value = fromdate;
                }
                else
                {
                    objsqlcom.Parameters["@fromdate"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (todate != "")
                {
                    objsqlcom.Parameters["@dateto"].Value = todate;
                }
                else
                {
                    objsqlcom.Parameters["@dateto"].Value = System.DBNull.Value;
                }


                objsqlcom.Parameters.Add("@compcode", SqlDbType.VarChar);
                objsqlcom.Parameters["@compcode"].Value = compcode;


                objsqlcom.Parameters.Add("@region", SqlDbType.VarChar);
                if (region != "0")
                {
                    objsqlcom.Parameters["@region"].Value = region;
                }
                else
                {
                    objsqlcom.Parameters["@region"].Value = System.DBNull.Value;
                }


                objsqlcom.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objsqlcom.Parameters["@dateformat"].Value = dateformat;


                objsqlcom.Parameters.Add("@pub_name", SqlDbType.VarChar);
                if (publication != "0")
                {
                    objsqlcom.Parameters["@pub_name"].Value = publication;
                }

                else
                {
                    objsqlcom.Parameters["@pub_name"].Value = System.DBNull.Value;
                }


                objsqlcom.Parameters.Add("@agency", SqlDbType.VarChar);
                if (agency != "0")
                {
                    objsqlcom.Parameters["@agency"].Value = agency;
                }
                else
                {
                    objsqlcom.Parameters["@agency"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@client", SqlDbType.VarChar);
                if (client != "0")
                {
                    objsqlcom.Parameters["@client"].Value = client;
                }
                else
                {
                    objsqlcom.Parameters["@client"].Value = System.DBNull.Value;
                }



                objsqlcom.Parameters.Add("@payment", SqlDbType.VarChar);
                if (payment != "0")
                {
                    objsqlcom.Parameters["@payment"].Value = payment;
                }
                else
                {
                    objsqlcom.Parameters["@payment"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@billstatus", SqlDbType.VarChar);
                if (billstatus != "0")
                {
                    objsqlcom.Parameters["@billstatus"].Value = billstatus;
                }
                else
                {
                    objsqlcom.Parameters["@billstatus"].Value = System.DBNull.Value;
                }


                objsqlcom.Parameters.Add("@adtype", SqlDbType.VarChar);
                if (adtype != "0")
                {
                    objsqlcom.Parameters["@adtype"].Value = adtype;
                }
                else
                {
                    objsqlcom.Parameters["@adtype"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@descid", SqlDbType.VarChar);
                objsqlcom.Parameters["@descid"].Value = descid;



                objsqlcom.Parameters.Add("@ascdesc", SqlDbType.VarChar);
                objsqlcom.Parameters["@ascdesc"].Value = ascdesc;
                objsqlcom.Parameters.Add("@myrange", SqlDbType.VarChar);
                if (myrange != "0")
                {
                    objsqlcom.Parameters["@myrange"].Value = myrange;
                }
                else
                {
                    objsqlcom.Parameters["@myrange"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@maxrange", SqlDbType.VarChar);
                if (maxrange != "0")
                {
                    objsqlcom.Parameters["@maxrange"].Value = maxrange;
                }
                else
                {
                    objsqlcom.Parameters["@maxrange"].Value = System.DBNull.Value;
                }




                objsqldap.SelectCommand = objsqlcom;
                objsqldap.Fill(objdataset);

                return objdataset;



            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objsqlcon);
            }

        }





        public SqlDataReader drillout_excelbarter(string fromdate, string todate, string compcode, string region, string dateformat, string publication, string agency, string client, string billstatus, string payment, string adtype, string myrange, string maxrange)
        {
            SqlConnection objsqlcon = new SqlConnection();
            SqlCommand objsqlcom;
            objsqlcon = GetConnection();
            SqlDataAdapter objsqldap = new SqlDataAdapter();
            DataSet objdataset = new DataSet();


            try
            {

                objsqlcon.Open();
                objsqlcom = GetCommand("bill_drillout", ref objsqlcon);
                objsqlcom.CommandType = CommandType.StoredProcedure;

                objsqlcom.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (fromdate != "")
                {
                    objsqlcom.Parameters["@fromdate"].Value = fromdate;
                }
                else
                {
                    objsqlcom.Parameters["@fromdate"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (todate != "")
                {
                    objsqlcom.Parameters["@dateto"].Value = todate;
                }
                else
                {
                    objsqlcom.Parameters["@dateto"].Value = System.DBNull.Value;
                }


                objsqlcom.Parameters.Add("@compcode", SqlDbType.VarChar);
                objsqlcom.Parameters["@compcode"].Value = compcode;


                objsqlcom.Parameters.Add("@region", SqlDbType.VarChar);
                if (region != "0")
                {
                    objsqlcom.Parameters["@region"].Value = region;
                }
                else
                {
                    objsqlcom.Parameters["@region"].Value = System.DBNull.Value;
                }


                objsqlcom.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objsqlcom.Parameters["@dateformat"].Value = dateformat;


                objsqlcom.Parameters.Add("@pub_name", SqlDbType.VarChar);
                if (publication != "0")
                {
                    objsqlcom.Parameters["@pub_name"].Value = publication;
                }

                else
                {
                    objsqlcom.Parameters["@pub_name"].Value = System.DBNull.Value;
                }


                objsqlcom.Parameters.Add("@agency", SqlDbType.VarChar);
                if (agency != "0")
                {
                    objsqlcom.Parameters["@agency"].Value = agency;
                }
                else
                {
                    objsqlcom.Parameters["@agency"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@client", SqlDbType.VarChar);
                if (client != "0")
                {
                    objsqlcom.Parameters["@client"].Value = client;
                }
                else
                {
                    objsqlcom.Parameters["@client"].Value = System.DBNull.Value;
                }



                objsqlcom.Parameters.Add("@payment", SqlDbType.VarChar);
                if (payment != "0")
                {
                    objsqlcom.Parameters["@payment"].Value = payment;
                }
                else
                {
                    objsqlcom.Parameters["@payment"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@billstatus", SqlDbType.VarChar);
                if (billstatus != "0")
                {
                    objsqlcom.Parameters["@billstatus"].Value = billstatus;
                }
                else
                {
                    objsqlcom.Parameters["@billstatus"].Value = System.DBNull.Value;
                }


                objsqlcom.Parameters.Add("@adtype", SqlDbType.VarChar);
                if (adtype != "0")
                {
                    objsqlcom.Parameters["@adtype"].Value = adtype;
                }
                else
                {
                    objsqlcom.Parameters["@adtype"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@myrange", SqlDbType.VarChar);
                if (myrange != "0")
                {
                    objsqlcom.Parameters["@myrange"].Value = myrange;
                }
                else
                {
                    objsqlcom.Parameters["@myrange"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@maxrange", SqlDbType.VarChar);
                if (maxrange != "0")
                {
                    objsqlcom.Parameters["@maxrange"].Value = maxrange;
                }
                else
                {
                    objsqlcom.Parameters["@maxrange"].Value = System.DBNull.Value;
                }



                objsqldap.SelectCommand = objsqlcom;
                SqlDataReader objdatareadre = objsqlcom.ExecuteReader();

                return objdatareadre;
                //objsqldap.Fill(objdataset);

                //return objdataset;



            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                //CloseConnection(ref objsqlcon);
            }


        }




        public SqlDataReader drillout_excelregion(string fromdate, string todate, string compcode, string region, string dateformat, string publication, string agency, string client, string billstatus, string payment, string adtype, string category, string myrange, string maxrange)
        {
            SqlConnection objsqlcon = new SqlConnection();
            SqlCommand objsqlcom;
            objsqlcon = GetConnection();
            SqlDataAdapter objsqldap = new SqlDataAdapter();
            DataSet objdataset = new DataSet();


            try
            {

                objsqlcon.Open();
                objsqlcom = GetCommand("bill_drillout", ref objsqlcon);
                objsqlcom.CommandType = CommandType.StoredProcedure;

                objsqlcom.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (fromdate != "")
                {
                    objsqlcom.Parameters["@fromdate"].Value = fromdate;
                }
                else
                {
                    objsqlcom.Parameters["@fromdate"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (todate != "")
                {
                    objsqlcom.Parameters["@dateto"].Value = todate;
                }
                else
                {
                    objsqlcom.Parameters["@dateto"].Value = System.DBNull.Value;
                }


                objsqlcom.Parameters.Add("@compcode", SqlDbType.VarChar);
                objsqlcom.Parameters["@compcode"].Value = compcode;


                objsqlcom.Parameters.Add("@region", SqlDbType.VarChar);
                if (region != "0")
                {
                    objsqlcom.Parameters["@region"].Value = region;
                }
                else
                {
                    objsqlcom.Parameters["@region"].Value = System.DBNull.Value;
                }


                objsqlcom.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objsqlcom.Parameters["@dateformat"].Value = dateformat;


                objsqlcom.Parameters.Add("@pub_name", SqlDbType.VarChar);
                if (publication != "0")
                {
                    objsqlcom.Parameters["@pub_name"].Value = publication;
                }

                else
                {
                    objsqlcom.Parameters["@pub_name"].Value = System.DBNull.Value;
                }

                //objsqlcom.Parameters.Add("@category", SqlDbType.VarChar);
                //if (category != "0")
                //{
                //    objsqlcom.Parameters["@category"].Value = category;
                //}
                //else
                //{
                //    objsqlcom.Parameters["@category"].Value = System.DBNull.Value;
                //}





                /*objsqlcom.Parameters.Add("@descid", SqlDbType.VarChar);
                objsqlcom.Parameters["@descid"].Value = descid;



                objsqlcom.Parameters.Add("@ascdesc", SqlDbType.VarChar);
                objsqlcom.Parameters["@ascdesc"].Value = ascdesc;*/
                objsqlcom.Parameters.Add("@agency", SqlDbType.VarChar);
                if (agency != "0")
                {
                    objsqlcom.Parameters["@agency"].Value = agency;
                }
                else
                {
                    objsqlcom.Parameters["@agency"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@client", SqlDbType.VarChar);
                if (client != "0")
                {
                    objsqlcom.Parameters["@client"].Value = client;
                }
                else
                {
                    objsqlcom.Parameters["@client"].Value = System.DBNull.Value;
                }



                objsqlcom.Parameters.Add("@payment", SqlDbType.VarChar);
                if (payment != "0")
                {
                    objsqlcom.Parameters["@payment"].Value = payment;
                }
                else
                {
                    objsqlcom.Parameters["@payment"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@billstatus", SqlDbType.VarChar);
                if (billstatus != "0")
                {
                    objsqlcom.Parameters["@billstatus"].Value = billstatus;
                }
                else
                {
                    objsqlcom.Parameters["@billstatus"].Value = System.DBNull.Value;
                }


                objsqlcom.Parameters.Add("@adtype", SqlDbType.VarChar);
                if (adtype != "0")
                {
                    objsqlcom.Parameters["@adtype"].Value = adtype;
                }
                else
                {
                    objsqlcom.Parameters["@adtype"].Value = System.DBNull.Value;
                }


                objsqlcom.Parameters.Add("@category", SqlDbType.VarChar);
                if (category != "0")
                {
                    objsqlcom.Parameters["@category"].Value = category;
                }
                else
                {
                    objsqlcom.Parameters["@category"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@myrange", SqlDbType.VarChar);
                if (myrange != "0")
                {
                    objsqlcom.Parameters["@myrange"].Value = myrange;
                }
                else
                {
                    objsqlcom.Parameters["@myrange"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@maxrange", SqlDbType.VarChar);
                if (maxrange != "0")
                {
                    objsqlcom.Parameters["@maxrange"].Value = maxrange;
                }
                else
                {
                    objsqlcom.Parameters["@maxrange"].Value = System.DBNull.Value;
                }


                objsqldap.SelectCommand = objsqlcom;
                SqlDataReader objdatareadre = objsqlcom.ExecuteReader();

                return objdatareadre;
                //objsqldap.Fill(objdataset);

                //return objdataset;



            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                //CloseConnection(ref objsqlcon);
            }


        }



        public DataSet drillout_region(string fromdate, string todate, string compcode, string region, string dateformat, string publication, string agency, string client, string billstatus, string payment, string adtype, string category, string descid, string ascdesc,string myrange,string maxrange)
        {
            SqlConnection objsqlcon = new SqlConnection();
            SqlCommand objsqlcom;
            objsqlcon = GetConnection();
            SqlDataAdapter objsqldap = new SqlDataAdapter();
            DataSet objdataset = new DataSet();

            try
            {

                objsqlcon.Open();
                objsqlcom = GetCommand("bill_drillout", ref objsqlcon);
                objsqlcom.CommandType = CommandType.StoredProcedure;

                objsqlcom.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (fromdate != "")
                {
                    objsqlcom.Parameters["@fromdate"].Value = fromdate;
                }
                else
                {
                    objsqlcom.Parameters["@fromdate"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (todate != "")
                {
                    objsqlcom.Parameters["@dateto"].Value = todate;
                }
                else
                {
                    objsqlcom.Parameters["@dateto"].Value = System.DBNull.Value;
                }


                objsqlcom.Parameters.Add("@compcode", SqlDbType.VarChar);
                objsqlcom.Parameters["@compcode"].Value = compcode;


                objsqlcom.Parameters.Add("@region", SqlDbType.VarChar);
                if (region != "0")
                {
                    objsqlcom.Parameters["@region"].Value = region;
                }
                else
                {
                    objsqlcom.Parameters["@region"].Value = System.DBNull.Value;
                }


                objsqlcom.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objsqlcom.Parameters["@dateformat"].Value = dateformat;


                objsqlcom.Parameters.Add("@pub_name", SqlDbType.VarChar);
                if (publication != "0")
                {
                    objsqlcom.Parameters["@pub_name"].Value = publication;
                }

                else
                {
                    objsqlcom.Parameters["@pub_name"].Value = System.DBNull.Value;
                }

                //objsqlcom.Parameters.Add("@category", SqlDbType.VarChar);
                //if (category != "0")
                //{
                //    objsqlcom.Parameters["@category"].Value = category;
                //}
                //else
                //{
                //    objsqlcom.Parameters["@category"].Value = System.DBNull.Value;
                //}





                /*objsqlcom.Parameters.Add("@descid", SqlDbType.VarChar);
                objsqlcom.Parameters["@descid"].Value = descid;



                objsqlcom.Parameters.Add("@ascdesc", SqlDbType.VarChar);
                objsqlcom.Parameters["@ascdesc"].Value = ascdesc;*/
                objsqlcom.Parameters.Add("@agency", SqlDbType.VarChar);
                if (agency != "0")
                {
                    objsqlcom.Parameters["@agency"].Value = agency;
                }
                else
                {
                    objsqlcom.Parameters["@agency"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@client", SqlDbType.VarChar);
                if (client != "0")
                {
                    objsqlcom.Parameters["@client"].Value = client;
                }
                else
                {
                    objsqlcom.Parameters["@client"].Value = System.DBNull.Value;
                }



               
                objsqlcom.Parameters.Add("@billstatus", SqlDbType.VarChar);
                if (billstatus != "0")
                {
                    objsqlcom.Parameters["@billstatus"].Value = billstatus;
                }
                else
                {
                    objsqlcom.Parameters["@billstatus"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@payment", SqlDbType.VarChar);
                if (payment != "0")
                {
                    objsqlcom.Parameters["@payment"].Value = payment;
                }
                else
                {
                    objsqlcom.Parameters["@payment"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@adtype", SqlDbType.VarChar);
                if (adtype != "0")
                {
                    objsqlcom.Parameters["@adtype"].Value = adtype;
                }
                else
                {
                    objsqlcom.Parameters["@adtype"].Value = System.DBNull.Value;
                }


                objsqlcom.Parameters.Add("@category", SqlDbType.VarChar);
                if (category != "0")
                {
                    objsqlcom.Parameters["@category"].Value = category;
                }
                else
                {
                    objsqlcom.Parameters["@category"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@myrange", SqlDbType.VarChar);
                if (myrange != "0")
                {
                    objsqlcom.Parameters["@myrange"].Value = myrange;
                }
                else
                {
                    objsqlcom.Parameters["@myrange"].Value = System.DBNull.Value;
                }
                objsqlcom.Parameters.Add("@maxrange", SqlDbType.VarChar);
                if (maxrange != "0")
                {
                    objsqlcom.Parameters["@maxrange"].Value = maxrange;
                }
                else
                {
                    objsqlcom.Parameters["@maxrange"].Value = System.DBNull.Value;
                }

                objsqlcom.Parameters.Add("@descid", SqlDbType.VarChar);
                objsqlcom.Parameters["@descid"].Value = descid;



                objsqlcom.Parameters.Add("@ascdesc", SqlDbType.VarChar);
                objsqlcom.Parameters["@ascdesc"].Value = ascdesc;






                objsqldap.SelectCommand = objsqlcom;
                objsqldap.Fill(objdataset);

                return objdataset;



            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objsqlcon);
            }

        }



    }
}

  
