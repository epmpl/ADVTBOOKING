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
/// Summary description for PageType
/// </summary>
public class PageType:connection 
{
	public PageType()
	{
		//
		// TODO: Add constructor logic here
		//
	}
       public DataSet pagedes(string compcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();      

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("drppub", ref objmysqlconnection);
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
         // public DataSet chkcode(string drppub,string pagetypecode,string pagename, string height, string width, string nocolumns, string compcode)
        public DataSet chkcode(string pagetypecode, string compcode)      
          {
              MySqlConnection objmysqlconnection;
              MySqlCommand objmysqlcommand;
              objmysqlconnection = GetConnection();
              MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
              DataSet objDataSet = new DataSet();      
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("pgchkcode", ref objmysqlconnection);
            objmysqlcommand.CommandType = CommandType.StoredProcedure;

            objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["compcode"].Value = compcode;

                
            objmysqlcommand.Parameters.Add("pagetypecode1", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["pagetypecode1"].Value = pagetypecode;

               

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
                objmysqlcommand = GetCommand("ptautocode", ref objmysqlconnection);
            objmysqlcommand.CommandType = CommandType.StoredProcedure;

              

            objmysqlcommand.Parameters.Add("str", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["str"].Value = str;
                objmysqlcommand.Parameters.Add("cod", MySqlDbType.VarChar);
                if(str.Length >2)
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

        public DataSet insertedvalue(string drppub, string pagetypecode, string pagename, string height, string width, string nocolumns, string compcode, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();      
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("ptinsert", ref objmysqlconnection);
            objmysqlcommand.CommandType = CommandType.StoredProcedure;

           //objmysqlcommand.Parameters.Add("drppub", MySqlDbType.VarChar);
           //objmysqlcommand.Parameters["drppub"].Value = drppub;

            objmysqlcommand.Parameters.Add("drppub", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["drppub"].Value = drppub;

            objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["compcode"].Value = compcode;

            objmysqlcommand.Parameters.Add("pagetypecode", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["pagetypecode"].Value = pagetypecode;

            objmysqlcommand.Parameters.Add("pagename", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["pagename"].Value = pagename;

            objmysqlcommand.Parameters.Add("height", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["height"].Value = height;

            objmysqlcommand.Parameters.Add("width", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["width"].Value = width;

            objmysqlcommand.Parameters.Add("nocolumns", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["nocolumns"].Value = nocolumns;

            objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["userid"].Value = userid;

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
        
        
        
        
        //e(exepublication, exepagetypecode, exepagename,                            exeheight, exewidth, execolumns, 


        public DataSet ptexecute(string drppub, string pagetypecode, string pagename, string height, string width, string nocolumns, string compcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();      

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("ptexe", ref objmysqlconnection);
            objmysqlcommand.CommandType = CommandType.StoredProcedure;

            objmysqlcommand.Parameters.Add("drppublication", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["drppublication"].Value = drppub;

            objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["compcode"].Value = compcode;

            objmysqlcommand.Parameters.Add("pagetypecode", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["pagetypecode"].Value = pagetypecode;

            objmysqlcommand.Parameters.Add("pagename", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["pagename"].Value = pagename;

            objmysqlcommand.Parameters.Add("height", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["height"].Value = height;

            objmysqlcommand.Parameters.Add("width", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["width"].Value = width;

            objmysqlcommand.Parameters.Add("nocolumns", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["nocolumns"].Value = nocolumns;

               

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
        public DataSet ptdelete(string pagetypecode, string compcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();      
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("ptdel", ref objmysqlconnection);
            objmysqlcommand.CommandType = CommandType.StoredProcedure;

            objmysqlcommand.Parameters.Add("pagetypecode", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["pagetypecode"].Value = pagetypecode;

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
        public DataSet ptupdate(string drppub, string pagetypecode, string pagename, string height, string width, string nocolumns, string compcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();      

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("ptmodify", ref objmysqlconnection);
            objmysqlcommand.CommandType = CommandType.StoredProcedure;

            //objmysqlcommand.Parameters.Add("drppublication", MySqlDbType.VarChar);
            //objmysqlcommand.Parameters["drppublication"].Value = drppub;

            objmysqlcommand.Parameters.Add("drppub", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["drppub"].Value = drppub;

            objmysqlcommand.Parameters.Add("pagetypecode1", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["pagetypecode1"].Value = pagetypecode;

            objmysqlcommand.Parameters.Add("pagename", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["pagename"].Value = pagename;

            objmysqlcommand.Parameters.Add("height", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["height"].Value = height;

            objmysqlcommand.Parameters.Add("width", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["width"].Value = width;

            objmysqlcommand.Parameters.Add("nocolumns", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["nocolumns"].Value = nocolumns;


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
