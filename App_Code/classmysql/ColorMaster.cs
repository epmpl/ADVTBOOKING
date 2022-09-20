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
/// Summary description for ColorMaster
/// </summary>
public class ColorMaster:connection 
{
	public ColorMaster()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    		public DataSet ModifyValue(string ColorCode,string ColorName,string Alias,string compcode,string userid)
		{
			MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();


			try
         {


                 objmysqlconnection.Open();
                 objmysqlcommand = GetCommand("ColorMastModify_ColorMastModify_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;
                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;
                 objmysqlcommand.Parameters.Add("ColorCode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["ColorCode"].Value = ColorCode;
                  objmysqlcommand.Parameters.Add("ColorName", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["ColorName"].Value = ColorName;
               objmysqlcommand.Parameters.Add("Alias", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Alias"].Value = Alias;


                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
          
			}

			catch(MySqlException  objException)
			{
				throw(objException);
			}
			  catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objmysqlconnection.Close();

            }
		}

            public DataSet InsertValue(string compcode, string ColorCode, string ColorName, string userid, string Alias)
		{
			MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();


			try
			{

                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("ColorMastInsert_ColorMastInsert_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;
                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;
                objmysqlcommand.Parameters.Add("colorcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["colorcode"].Value = ColorCode;
                objmysqlcommand.Parameters.Add("colorname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["colorname"].Value =  ColorName;
                objmysqlcommand.Parameters.Add("alias", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["alias"].Value = userid;
                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = Alias ;


                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
             
			}

			catch(MySqlException objException)
			{
				throw(objException);
			}
			  catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objmysqlconnection.Close();

            }
		}

		public DataSet SelectValue(string ColorCode,string ColorName,string Alias,string compcode,string userid)
		{
			MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();


			try
			{

                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("ColorMastSelect_ColorMastSelect_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;
                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;             
                objmysqlcommand.Parameters.Add("ColorCode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["ColorCode"].Value = ColorCode;
                objmysqlcommand.Parameters.Add("ColorName", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["ColorName"].Value = ColorName;
                objmysqlcommand.Parameters.Add("Alias", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Alias"].Value = Alias;
                
                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
             
			}

			catch(MySqlException objException)
			{
				throw(objException);
			}
		  catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objmysqlconnection.Close();

            }
		}

		public DataSet Selectfnpl(string ColorCode,string ColorName,string Alias,string compcode,string userid)
		{
			 MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();


			try
			{
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("ColorSelectfnpl_ColorSelectfnpl_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;
                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;  
                 objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
              
			}

			catch(MySqlException objException)
			{
				throw(objException);
			}
		  catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objmysqlconnection.Close();

            }
		}

        public DataSet checkcolor(string ColorCode, string ColorName, string compcode, string userid)
		{
			MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();


			try
			{

                  objmysqlconnection.Open();
                  objmysqlcommand = GetCommand("chkcolorcode_chkcolorcode_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;
                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;
                
                objmysqlcommand.Parameters.Add("ColorCode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["ColorCode"].Value = ColorCode;

                  objmysqlcommand.Parameters.Add("ColorName", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["ColorName"].Value = ColorName;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;
               

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
             
			}

			catch(MySqlException objException)
			{
				throw(objException);
			}
			  catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objmysqlconnection.Close();

            }
		}

		public DataSet DeleteValue(string ColorCode,string compcode,string userid)
		{
			 MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

	
			try
			{

                 objmysqlconnection.Open();
                 objmysqlcommand = GetCommand("ColorMastDelete_ColorMastDelete_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;
                
                objmysqlcommand.Parameters.Add("ColorCode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["ColorCode"].Value = ColorCode;

               
               

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
             
             
			}
		  catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objmysqlconnection.Close();

            }
		}

        public DataSet countcolorcode(string str)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();


            try
            {


                  objmysqlconnection.Open();
                  objmysqlcommand = GetCommand("chkcolorcodename_chkcolorcodename_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("str", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["str"].Value = str;
                
                objmysqlcommand.Parameters.Add("cod", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["cod"].Value = str;
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
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objmysqlconnection.Close();

            }
        }
	}
}


