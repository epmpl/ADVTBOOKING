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
    /// Summary description for preodicitymaster
    /// </summary>
    public class preodicitymaster:connection 
    {
        public preodicitymaster()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataSet ModifyValue(string precode, string prename, string Alias, string compcode, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();            
           
           
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("preodicitymodify_preodicitymodify_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("precode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["precode"].Value = precode;

                objmysqlcommand.Parameters.Add("prename", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["prename"].Value = prename;


                objmysqlcommand.Parameters.Add("Alias", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Alias"].Value = Alias;

            
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


        public DataSet save(string precode, string compcode, string userid)
        {
           MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter=new MySqlDataAdapter ();
            DataSet objDataSet = new DataSet();            
           try 
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("preodicitychk_preodicitychk_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("precode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["precode"].Value = precode;

               
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



        public DataSet delete1(string precode, string compcode, string userid)
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();            
           
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("preodicitydelete_preodicitydelete_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;



                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;


                objmysqlcommand.Parameters.Add("precode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["precode"].Value = precode;





               
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



        public DataSet InsertValue(string precode, string prename, string Alias, string compcode, string userid)
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();            
           
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("Preodicitytypemasterinsert_Preodicitytypemasterinsert_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;



                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;


                objmysqlcommand.Parameters.Add("precode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["precode"].Value = precode;

                objmysqlcommand.Parameters.Add("prename", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["prename"].Value = prename;

                objmysqlcommand.Parameters.Add("Alias", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Alias"].Value = Alias;



                
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

        public DataSet Execute1(string precode, string prename, string Alias, string compcode, string userid)
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();            
           
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("preodicitytype_preodicitytype_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;



                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;


                objmysqlcommand.Parameters.Add("precode", MySqlDbType.VarChar);
                //if (precode == "" || precode == null || precode == "undefined")
                //{
                //    objmysqlcommand.Parameters["precode"].Value = "%%";
                //}
                //else
                //{
                objmysqlcommand.Parameters["precode"].Value = precode;
                //}




                objmysqlcommand.Parameters.Add("prename", MySqlDbType.VarChar);
                //if (prename == "" || prename == null || prename == "undefined")
                //{
                //    objmysqlcommand.Parameters["prename"].Value = "%%";
                //}
                //else
                //{
                objmysqlcommand.Parameters["prename"].Value = prename;
                //}


                objmysqlcommand.Parameters.Add("Alias", MySqlDbType.VarChar);
                //if (Alias == "" || Alias == null)
                //{
                //    objmysqlcommand.Parameters["Alias "].Value = "%%";
                //}
                //else
                //{
                objmysqlcommand.Parameters["Alias"].Value = Alias;
                //}

                
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

        public DataSet Selectfnpl(string precode, string compcode, string userid)
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();            
           
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("preodicityfnpl_preodicityfnpl_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;



                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("precode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["precode"].Value = precode;





               
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



        public DataSet prodicityauto(string str,string compcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();            
           
            try
            {
                objmysqlconnection.Open();
                //  objmysqlcommand = GetCommand("autopublicatcode", ref objmysqlconnection);
                objmysqlcommand = GetCommand("autopreodicitycode_autopreodicitycode_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("str", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["str"].Value = str;

                objmysqlcommand.Parameters.Add("company_code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["company_code"].Value = compcode;
                objmysqlcommand.Parameters.Add("cod", MySqlDbType.VarChar);

                if(str.Length >2)
                {
                    objmysqlcommand.Parameters["cod"].Value = str.Substring(0,2);

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




    }
}