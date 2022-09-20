using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using MySql.Data ;
using MySql.Data.MySqlClient ;
namespace NewAdbooking.classmysql
{

    /// <summary>
    /// Summary description for productmaster
    /// </summary>
    public class productmaster:connection 
    {
        public productmaster()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataSet checkcode(string txtproductcode, string txtprodsubcode, string compcode, string userid)
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("checkproductcode_checkproductcode_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;



                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;


                objmysqlcommand.Parameters.Add("txtproductcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["txtproductcode"].Value = txtproductcode;

                objmysqlcommand.Parameters.Add("txtprodsubcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["txtprodsubcode"].Value = txtprodsubcode;

                objmysqlcommand.Parameters.Add("txtprodname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["txtprodname"].Value = "null" ;



            
                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }

            catch (MySqlException objException)
            {
                throw (objException);
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

        public DataSet saveproduct(string txtproductcode, string txtprodsubcode, string txtprodname, string clientname, string compcode, string userid)
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("insertproduct_insertproduct_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;



                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;


                objmysqlcommand.Parameters.Add("txtproductcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["txtproductcode"].Value = txtproductcode;

                objmysqlcommand.Parameters.Add("txtprodsubcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["txtprodsubcode"].Value = txtprodsubcode;

                objmysqlcommand.Parameters.Add("txtprodname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["txtprodname"].Value = txtprodname;

                objmysqlcommand.Parameters.Add("clientname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["clientname"].Value = clientname;





               
                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }

            catch (MySqlException objException)
            {
                throw (objException);
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

        public DataSet executeproduct(string txtproductcode, string txtprodsubcode, string txtprodname, string clientname, string compcode, string userid)
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("executeproduct_executeproduct_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;



                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;


                objmysqlcommand.Parameters.Add("txtproductcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["txtproductcode"].Value = txtproductcode;

                objmysqlcommand.Parameters.Add("txtprodsubcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["txtprodsubcode"].Value = txtprodsubcode;

                objmysqlcommand.Parameters.Add("txtprodname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["txtprodname"].Value = txtprodname;

                objmysqlcommand.Parameters.Add("clientname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["clientname"].Value = clientname;

               
                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }

            catch (MySqlException objException)
            {
                throw (objException);
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

        public DataSet firstprodctcode()
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("firstproduct_firstproduct_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                
                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }

            catch (MySqlException objException)
            {
                throw (objException);
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

        public DataSet deleteproduct(string txtproductcode, string compcode, string userid)
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("deleteprducycode_deleteprducycode_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;



                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;


                objmysqlcommand.Parameters.Add("txtproductcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["txtproductcode"].Value = txtproductcode;





               
                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }

            catch (MySqlException objException)
            {
                throw (objException);
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

        public DataSet updateproduct(string txtproductcode, string txtprodsubcode, string txtprodname, string clientname, string compcode, string userid)
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("updateproduct_updateproduct_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;



                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;


                objmysqlcommand.Parameters.Add("txtproductcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["txtproductcode"].Value = txtproductcode;

                objmysqlcommand.Parameters.Add("txtprodsubcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["txtprodsubcode"].Value = txtprodsubcode;

                objmysqlcommand.Parameters.Add("txtprodname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["txtprodname"].Value = txtprodname;

                objmysqlcommand.Parameters.Add("clientname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["clientname"].Value = clientname;




               
                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }

            catch (MySqlException objException)
            {
                throw (objException);
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

        public DataSet bindclientname(string compcode, string userid)
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("bindproductclientname_bindproductclientname_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;



                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;








            
                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }

            catch (MySqlException objException)
            {
                throw (objException);
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
