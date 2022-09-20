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
/// Summary description for currencymaster
/// </summary>
public class currencymaster:connection 
{
    static string prev = "";
	public currencymaster()
	{
		//
		// TODO: Add constructor logic here
		//
	}

	public DataSet bindcount(string compcode,string userid)
		{
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();        
			try
			{

                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("BINDCOUNTRY_BINDCOUNTRY_P", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;
                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;
                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;
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

		public DataSet chkcurrcode(string code,string compcode,string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();        
			
			try
			{

                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("CHKCURRCODE_CHKCURRCODE_P", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;
                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;
                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;
                objmysqlcommand.Parameters.Add("code1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["code1"].Value = code;
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

		public DataSet currsave(string txtcurrcode,string txtcurrname,string txtalias,string drpcountryname,string compcode,string userid)
		{
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();        
			
			try
			{



                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("INSERTCURRENCYMST_INSERTCURRENCYMST_P", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;
                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;
                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;
                objmysqlcommand.Parameters.Add("txtcurrcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["txtcurrcode"].Value = txtcurrcode;
                objmysqlcommand.Parameters.Add("txtcurrname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["txtcurrname"].Value = txtcurrname;
                objmysqlcommand.Parameters.Add("txtalias", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["txtalias"].Value = txtalias;
                objmysqlcommand.Parameters.Add("drpcountryname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["drpcountryname"].Value = drpcountryname;
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

		public DataSet executecurrmst(string txtcurrcode,string txtcurrname,string txtalias,string drpcountryname,string compcode,string userid)
		{
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();        
			try
			{

                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("EXEECUTECURRENCYMAST_EXEECUTECURRENCYMAST_P", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;
                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;
                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;
                objmysqlcommand.Parameters.Add("txtcurrcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["txtcurrcode"].Value = txtcurrcode;
                objmysqlcommand.Parameters.Add("txtcurrname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["txtcurrname"].Value = txtcurrname;
                objmysqlcommand.Parameters.Add("txtalias", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["txtalias"].Value = txtalias;
                objmysqlcommand.Parameters.Add("drpcountryname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["drpcountryname"].Value = drpcountryname;
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

		public DataSet firstcurrmst()
		{
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();        
			try
			{

                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("FIRSTCURRENMAST_FIRSTCURRENMAST_P", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;
               
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

		public DataSet currmodify(string txtcurrcode,string txtcurrname,string txtalias,string drpcountryname,string compcode,string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();  
			
			try
			{


                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("MODIFYCURRMAST_MODIFYCURRMAST_P", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;
                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("txtcurrcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["txtcurrcode"].Value = txtcurrcode;

                objmysqlcommand.Parameters.Add("txtcurrname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["txtcurrname"].Value = txtcurrname;

                objmysqlcommand.Parameters.Add("txtalias", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["txtalias"].Value = txtalias;

                objmysqlcommand.Parameters.Add("drpcountryname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["drpcountryname"].Value = drpcountryname;
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

		public DataSet currdelete(string code,string compcode,string userid)
		{
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();        
			try
           {

               objmysqlconnection.Open();
               objmysqlcommand = GetCommand("deletecurrmast", ref objmysqlconnection);
               objmysqlcommand.CommandType = CommandType.StoredProcedure;
               objmysqlcommand.Parameters.Add("code1", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["code1"].Value = code;

               objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["compcode"].Value = compcode;

               objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
               objmysqlcommand.Parameters["userid"].Value = userid;

             
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

		public DataSet checkratecode(string code,string compcode,string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();        
			
			try
			{




                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("converartechk", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;
                objmysqlcommand.Parameters.Add("code1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["code1"].Value = code;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["code"].Value = code;



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
		public DataSet ratebind(string code,string compcode,string userid,string date)
		{
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();        
			try
			{



                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("bindcurrmast", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("code1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["code1"].Value = code;





                objmysqlcommand.Parameters.Add("date1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["date1"].Value = date;



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

		public DataSet insertconverrate(string txtconrate,string txtfromdate,string txtefftill,string compcode,string userid,string currcode)
		{
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();        
			try
			{

                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("INSERTCONVERTRATE_INSERTCONVERTRATE_P", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("txtconrate", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["txtconrate"].Value = txtconrate;
                objmysqlcommand.Parameters.Add("txtfromdate", MySqlDbType.Datetime);
                objmysqlcommand.Parameters["txtfromdate"].Value = Convert.ToDateTime(txtfromdate).ToString("yyyy-MM-dd");


                objmysqlcommand.Parameters.Add("txtefftill", MySqlDbType.Datetime);
                objmysqlcommand.Parameters["txtefftill"].Value = Convert.ToDateTime(txtefftill).ToString("yyyy-MM-dd");


                objmysqlcommand.Parameters.Add("currcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["currcode"].Value = currcode;



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

		public DataSet selectedfromgrid(string currcode,string compcode,string userid,string code10)
		{
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();        
			try
			{


                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("selectfromcurrmast", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;
                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;
                objmysqlcommand.Parameters.Add("currcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["currcode"].Value = currcode;
             


             
                objmysqlcommand.Parameters.Add("code10", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["code10"].Value = code10;





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

		public DataSet gridupdate(string txtconrate,string txtfromdate,string txtefftill,string compcode,string userid,string currcode,string code10)
		{
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();        
			try
			{


                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("updateconvertrate", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;
                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;
                objmysqlcommand.Parameters.Add("txtconrate", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["txtconrate"].Value = txtconrate;


                objmysqlcommand.Parameters.Add("txtfromdate", MySqlDbType.DateTime);
                objmysqlcommand.Parameters["txtfromdate"].Value = Convert.ToDateTime(txtfromdate);
                objmysqlcommand.Parameters.Add("txtefftill", MySqlDbType.DateTime);
                objmysqlcommand.Parameters["txtefftill"].Value = Convert.ToDateTime(txtefftill);
                



                objmysqlcommand.Parameters.Add("currcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["currcode"].Value = currcode;
                objmysqlcommand.Parameters.Add("code10", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["code10"].Value = code10;

                



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

		public DataSet griddelete(string currcode,string compcode,string userid,string code10)
		{
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();        
			try
			{


                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("deletegridconrate", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;
                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

               

              
                objmysqlcommand.Parameters.Add("currcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["currcode"].Value = currcode;

                objmysqlcommand.Parameters.Add("code10", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["code10"].Value = code10;



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
		public DataSet chkdaetconv(string txtconrate,string txtfromdate,string txtefftill,string compcode,string userid,string currcode)
		{
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();        
			try
			{

                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("chkdateconrate", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;
                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("txtconrate", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["txtconrate"].Value = txtconrate;

                objmysqlcommand.Parameters.Add("txtfromdate", MySqlDbType.DateTime);
                objmysqlcommand.Parameters["txtfromdate"].Value = Convert.ToDateTime(txtfromdate);

                objmysqlcommand.Parameters.Add("txtefftill", MySqlDbType.DateTime);
                objmysqlcommand.Parameters["txtefftill"].Value = Convert.ToDateTime(txtefftill);

                objmysqlcommand.Parameters.Add("currcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["currcode"].Value = currcode;

               

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

		public DataSet chkdateupdate(string txtconrate,string txtfromdate,string txtefftill,string compcode,string userid,string currcode,string code10)
		{
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();        
			try
			{
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("chkdateupdate", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;
                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("txtconrate", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["txtconrate"].Value = txtconrate;

                objmysqlcommand.Parameters.Add("txtfromdate", MySqlDbType.DateTime);
                objmysqlcommand.Parameters["txtfromdate"].Value = Convert.ToDateTime(txtfromdate);

                objmysqlcommand.Parameters.Add("txtefftill", MySqlDbType.DateTime);
                objmysqlcommand.Parameters["txtefftill"].Value = Convert.ToDateTime(txtefftill);

                objmysqlcommand.Parameters.Add("currcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["currcode"].Value = currcode;

                objmysqlcommand.Parameters.Add("code10", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["code10"].Value = code10;

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

        public DataSet countcurrencycode(string str,string country)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();        
          
            try
            {

                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("CHKCURRENCYCODENAME", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;
                objmysqlcommand.Parameters.Add("country", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["country"].Value = country;
                objmysqlcommand.Parameters.Add("str", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["str"].Value = str;

                
                objmysqlcommand.Parameters.Add("cod", MySqlDbType.VarChar);
                if (str.Length > 2)
                {
                    objmysqlcommand.Parameters["cod"].Value = str.Substring (0,2);
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


        public DataSet countcurrencycodectry(string country)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();        
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("chkcurrencycodenamectry", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;
                objmysqlcommand.Parameters.Add("country", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["country"].Value = country;
                
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
