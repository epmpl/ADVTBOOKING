using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using MySql.Data;
using MySql.Data.MySqlClient;
namespace NewAdbooking.classmysql
{
    /// <summary>
    /// Summary description for vatmaster
    /// </summary>
    public class vatmaster:connection
    {
        public vatmaster()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataSet vatsave(string compcode, string userid, string description, string vatrate, string fromdate, string todate, string grosstype, string orderno)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand= GetCommand("vatsave", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("comp_code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["comp_code"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("vat_description", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["vat_description"].Value = description;

                objmysqlcommand.Parameters.Add("vat_rate", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["vat_rate"].Value = vatrate;

                objmysqlcommand.Parameters.Add("vat_from_date", MySqlDbType.DateTime);
                objmysqlcommand.Parameters["vat_from_date"].Value =Convert.ToDateTime(fromdate);


                objmysqlcommand.Parameters.Add("vat_to_date", MySqlDbType.DateTime);
                objmysqlcommand.Parameters["vat_to_date"].Value =Convert.ToDateTime(todate);

                objmysqlcommand.Parameters.Add("vat_gross_type", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["vat_gross_type"].Value = grosstype;

                //objmysqlcommand.Parameters.Add("vat_code", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["vat_code"].Value = vatcode;


                objmysqlcommand.Parameters.Add("vat_order_no", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["vat_order_no"].Value = orderno;


                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception ex)
            {
                throw (ex);

            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }

        }
        public DataSet dauto(string str)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand= GetCommand("vat_Auto", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;


                objmysqlcommand.Parameters.Add("cod", MySqlDbType.VarChar);
                if (str.Length > 2)
                {
                    objmysqlcommand.Parameters["cod"].Value = str.Substring(0, 2);
                }
                else
                {
                    objmysqlcommand.Parameters["cod"].Value = str;
                }



                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }
        }

        public DataSet vatexecute(string compcode, string userid, string description, string vatrate, string fromdate, string todate, string grosstype, string orderno)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand= GetCommand("Vat_Exe", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("comp_code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["comp_code"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("vat_description", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["vat_description"].Value = description;

                objmysqlcommand.Parameters.Add("vat_rate", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["vat_rate"].Value = vatrate;

                objmysqlcommand.Parameters.Add("vat_from_date", MySqlDbType.DateTime);
                objmysqlcommand.Parameters["vat_from_date"].Value =fromdate;


                objmysqlcommand.Parameters.Add("vat_to_date", MySqlDbType.DateTime);
                objmysqlcommand.Parameters["vat_to_date"].Value =todate;

                objmysqlcommand.Parameters.Add("vat_gross_type", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["vat_gross_type"].Value = grosstype;

                //objmysqlcommand.Parameters.Add("vat_code", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["vat_code"].Value = vatcode;


                objmysqlcommand.Parameters.Add("vat_order_no", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["vat_order_no"].Value = orderno;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception ex)
            {
                throw (ex);

            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }

        }
        public DataSet vatchk(string description)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand= GetCommand("vat_Chk", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("vat_description", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["vat_description"].Value = description;

                //objmysqlcommand.Parameters.Add("vat_from_date", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["vat_from_date"].Value = fromdate;


                //objmysqlcommand.Parameters.Add("vat_to_date", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["vat_to_date"].Value = todate;

                //objmysqlcommand.Parameters.Add("vat_order_no", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["vat_order_no"].Value = orderno;

                //objmysqlcommand.Parameters.Add("vat_code", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["vat_code"].Value = vatcode;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception ex)
            {
                throw (ex);

            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }

        }
        public DataSet vatdelete(string compcode, string description)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand= GetCommand("vat_delete", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("comp_code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["comp_code"].Value = compcode;

                objmysqlcommand.Parameters.Add("vat_description", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["vat_description"].Value = description;


                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception ex)
            {
                throw (ex);

            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }



        }
        public DataSet vatmodify(string compcode, string userid, string description, string vatrate, string fromdate, string todate, string grosstype, string orderno)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand= GetCommand("vat_modify", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("comp_code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["comp_code"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("vat_description", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["vat_description"].Value = description;

                objmysqlcommand.Parameters.Add("vat_rate", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["vat_rate"].Value = vatrate;

                objmysqlcommand.Parameters.Add("vat_from_date", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["vat_from_date"].Value = fromdate;


                objmysqlcommand.Parameters.Add("vat_to_date", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["vat_to_date"].Value = todate;

                objmysqlcommand.Parameters.Add("vat_gross_type", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["vat_gross_type"].Value = grosstype;

                //objmysqlcommand.Parameters.Add("vat_code", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["vat_code"].Value = vatcode;


                objmysqlcommand.Parameters.Add("vat_order_no", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["vat_order_no"].Value = orderno;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception ex)
            {
                throw (ex);

            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }

        }

        public DataSet grosstype(string compcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand= GetCommand("vat_GrossType", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("comp_code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["comp_code"].Value = compcode;

                //objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["userid"].Value = userid;


                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception ex)
            {
                throw (ex);

            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }



        }
        public DataSet chkdate(string description, string fromdate, string todate)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand= GetCommand("vat_chkdate", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                // objmysqlcommand.Parameters.Add("comp_code", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["comp_code"].Value = compcode;

                //objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("vat_description", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["vat_description"].Value = description;

                //objmysqlcommand.Parameters.Add("vat_rate", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["vat_rate"].Value = vatrate;

                objmysqlcommand.Parameters.Add("vat_from_date", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["vat_from_date"].Value = fromdate;


                objmysqlcommand.Parameters.Add("vat_to_date", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["vat_to_date"].Value = todate;

                //objmysqlcommand.Parameters.Add("vat_gross_type", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["vat_gross_type"].Value = grosstype;

                //objmysqlcommand.Parameters.Add("vat_code", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["vat_code"].Value = vatcode;


                //objmysqlcommand.Parameters.Add("vat_order_no", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["vat_order_no"].Value = orderno;


                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception ex)
            {
                throw (ex);

            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }

        }


    }
}