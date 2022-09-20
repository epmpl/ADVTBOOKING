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
    /// Summary description for product_subsub_category
    /// </summary>
    public class product_subsub_category:connection
    {
        public product_subsub_category()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataSet productdes(string compcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("drpproductselect", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;


                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }
        }

        public DataSet productsubdes(string compcode, string prosubsubcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("drpsubproductselect", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("prosubcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["prosubcode"].Value = prosubsubcode;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }

        }
        //     Check code
        public DataSet chkcode(string code, string compcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("productsubcatcode", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["code"].Value = code;


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

        //Insert the value

        public DataSet insertedvalue(string drpprosub, string drpprosubsub, string prosubsubcode, string prosubsubname, string proalias, string compcode, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("productsubsubinsert", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("procatcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["procatcode"].Value = drpprosub;

                objmysqlcommand.Parameters.Add("prosubcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["prosubcode"].Value = drpprosubsub;

                objmysqlcommand.Parameters.Add("prosubsubname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["prosubsubname"].Value = prosubsubname;

                objmysqlcommand.Parameters.Add("alias", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["alias"].Value = proalias;

                objmysqlcommand.Parameters.Add("prosubsubcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["prosubsubcode"].Value = prosubsubcode;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;



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

        //Auto generated code
        public DataSet autocode(string str)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("productsubsubautocode", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                //objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("str", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["str"].Value = str;

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

        //Execute Value

        public DataSet prosubexecute(string drpprosub, string drpsubprodu, string prosubsubcode, string prosubsubname, string proalias, string compcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

            try
            {


                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("productsubsubexe", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("procatcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["procatcode"].Value = drpprosub;

                objmysqlcommand.Parameters.Add("prosubcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["prosubcode"].Value = drpsubprodu;

                objmysqlcommand.Parameters.Add("prosubsubname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["prosubsubname"].Value = prosubsubname;

                objmysqlcommand.Parameters.Add("alias", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["alias"].Value = proalias;

                objmysqlcommand.Parameters.Add("prosubsubcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["prosubsubcode"].Value = prosubsubcode;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

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


        //Delete The Value
        public DataSet deleteproduct(string prosubsubcode, string compcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {


                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("productsubsubdel", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("prosubsubcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["prosubsubcode"].Value = prosubsubcode;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

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

        //Modify The Value
        public DataSet updatepro(string drpprosub, string drpprosubsub, string prosubsubcode, string prosubsubname, string proalias, string compcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("productsubsubmodify", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("procatcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["procatcode"].Value = drpprosub;

                objmysqlcommand.Parameters.Add("prosubcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["prosubcode"].Value = drpprosubsub;

                objmysqlcommand.Parameters.Add("prosubsubname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["prosubsubname"].Value = prosubsubname;

                objmysqlcommand.Parameters.Add("alias", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["alias"].Value = proalias;

                objmysqlcommand.Parameters.Add("prosubsubcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["prosubsubcode"].Value = prosubsubcode;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;


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