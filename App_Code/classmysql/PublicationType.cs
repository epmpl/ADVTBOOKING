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
/// Summary description for PublicationType
/// </summary>
public class PublicationType:connection 
{
	public PublicationType()
	{
		//
		// TODO: Add constructor logic here
		//
	}
     public DataSet ModifyValue(string pubcode, string pubname, string Alias, string compcode, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter=new MySqlDataAdapter ();
            DataSet objDataSet = new DataSet();            
          
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("pubtypemodify_pubtypemodify_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;


                objmysqlcommand.Parameters.Add("pubcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pubcode"].Value = pubcode;

                objmysqlcommand.Parameters.Add("pubname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pubname"].Value = pubname;


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


    public DataSet save(string pubtypename, string pubcode, string compcode, string userid)
    {
             MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter=new MySqlDataAdapter ();
            DataSet objDataSet = new DataSet();            
           
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("pubtypechk", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("pubcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pubcode"].Value = pubcode;

                objmysqlcommand.Parameters.Add("prename", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["prename"].Value = pubtypename;

                
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



        public DataSet delete1(string pubcode, string compcode, string userid)
        {

             MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter=new MySqlDataAdapter ();
            DataSet objDataSet = new DataSet();            
           
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("pubtypedelete", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;



                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;



                objmysqlcommand.Parameters.Add("pubcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pubcode"].Value = pubcode;





               
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



        public DataSet InsertValue(string pubcode, string pubname, string Alias, string compcode, string userid)
        {
          MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter=new MySqlDataAdapter ();
            DataSet objDataSet = new DataSet();            
           
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("PUBTYPEINSERT", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;



                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;


                objmysqlcommand.Parameters.Add("pubcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pubcode"].Value = pubcode;

                objmysqlcommand.Parameters.Add("pubname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pubname"].Value = pubname;

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

        public DataSet Execute1(string pubcode, string pubname, string Alias, string compcode, string userid)
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter=new MySqlDataAdapter ();
            DataSet objDataSet = new DataSet();            
           
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("pubtypeexe_pubtypeexe_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;



                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;



                objmysqlcommand.Parameters.Add("pubcode", MySqlDbType.VarChar);
                    objmysqlcommand.Parameters["pubcode"].Value = pubcode;




                    objmysqlcommand.Parameters.Add("pPUBNAME", MySqlDbType.VarChar);
                    objmysqlcommand.Parameters["pPUBNAME"].Value = pubname;


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

        public DataSet Selectfnpl(string pubcode, string compcode, string userid)
        {
           MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter=new MySqlDataAdapter ();
            DataSet objDataSet = new DataSet();            
           
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("pubtypefnpl_pubtypefnpl_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;



                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("pubcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pubcode"].Value = pubcode;





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
            MySqlDataAdapter objmysqlDataAdapter=new MySqlDataAdapter ();
            DataSet objDataSet = new DataSet();            
           
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("pubtypeautocode_pubtypeautocode_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

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
                objmysqlcommand.Parameters.Add("COMPANY_CODE", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["COMPANY_CODE"].Value = compcode;

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
