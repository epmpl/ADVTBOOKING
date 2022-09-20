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
/// Summary description for clientbrandmast
/// </summary>
/// 
namespace NewAdbooking.Classes
{
    public class clientbrandmast : connection
    {
        public clientbrandmast()
        {
            //
            // TODO: Add constructor logic here
            //
        }



        public DataSet adexecutive(string compcode, string userid)
		{
			SqlConnection con;
			SqlCommand com;
			con=GetConnection();
			SqlDataAdapter da=new SqlDataAdapter();
			DataSet ds=new DataSet();
			try
			{
				con.Open();
                com = GetCommand("adexecutive11", ref con);
				com.CommandType=CommandType.StoredProcedure;

				com.Parameters.Add("@compcode", SqlDbType.VarChar);
				com.Parameters["@compcode"].Value =compcode;

				com.Parameters.Add("@userid", SqlDbType.VarChar);
				com.Parameters["@userid"].Value =userid;

             //   com.Parameters.Add("@custcode", SqlDbType.VarChar);
              //  com.Parameters["@custcode"].Value = custcode;

               

				da.SelectCommand=com;
				da.Fill(ds);
				return ds;
			}
			catch(Exception ex)
			{
				throw(ex);
			}
			finally
			{
				CloseConnection(ref con);
			}
		}

        
         public DataSet adproduct(string compcode,string userid,string custcode)
		{
			SqlConnection con;
			SqlCommand com;
			con=GetConnection();
			SqlDataAdapter da=new SqlDataAdapter();
			DataSet ds=new DataSet();
			try
			{
				con.Open();
                com = GetCommand("bindclientprodbrand", ref con);
				com.CommandType=CommandType.StoredProcedure;

				com.Parameters.Add("@compcode", SqlDbType.VarChar);
				com.Parameters["@compcode"].Value =compcode;

				com.Parameters.Add("@userid", SqlDbType.VarChar);
				com.Parameters["@userid"].Value =userid;

                com.Parameters.Add("@custcode", SqlDbType.VarChar);
                com.Parameters["@custcode"].Value = custcode;

               

				da.SelectCommand=com;
				da.Fill(ds);
				return ds;
			}
			catch(Exception ex)
			{
				throw(ex);
			}
			finally
			{
				CloseConnection(ref con);
			}
		}




        public DataSet adxecutive(string compcode, string userid)
		{
			SqlConnection con;
			SqlCommand com;
			con=GetConnection();
			SqlDataAdapter da=new SqlDataAdapter();
			DataSet ds=new DataSet();
			try
			{
				con.Open();
                com = GetCommand("adexecutive", ref con);
				com.CommandType=CommandType.StoredProcedure;

				com.Parameters.Add("@compcode", SqlDbType.VarChar);
				com.Parameters["@compcode"].Value =compcode;

				com.Parameters.Add("@userid", SqlDbType.VarChar);
				com.Parameters["@userid"].Value =userid;

               

				da.SelectCommand=com;
				da.Fill(ds);
				return ds;
			}
			catch(Exception ex)
			{
				throw(ex);
			}
			finally
			{
				CloseConnection(ref con);
			}
		}



    public DataSet clientbind(string userid, string compcode,string custcode)
    {

        SqlConnection objSqlConnection;
        SqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        SqlDataAdapter objSqlDataAdapter;
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("websp_clientbindbrand", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;


            objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
            objSqlCommand.Parameters["@userid"].Value = userid;

            objSqlCommand.Parameters.Add("@custcode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@custcode"].Value = custcode;


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


        public DataSet insertclientcode(string client_code, string client_name, string exec_code, string compcode, string userid, string product_code, string brandcode)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter;
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
                objSqlCommand = GetCommand("insertclientbrand", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;

				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@code", SqlDbType.VarChar);
				objSqlCommand.Parameters["@code"].Value =client_code;


				
				objSqlCommand.Parameters.Add("@client", SqlDbType.VarChar);
				objSqlCommand.Parameters["@client"].Value =client_name;

				//objSqlCommand.Parameters.Add("@product", SqlDbType.VarChar);
				//objSqlCommand.Parameters["@product"].Value =product_name;

                objSqlCommand.Parameters.Add("@product_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@product_code"].Value = product_code;



				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;


                objSqlCommand.Parameters.Add("@brand_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@brand_code"].Value = brandcode;

                objSqlCommand.Parameters.Add("@exec_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@exec_code"].Value = exec_code;


				

				


				//objSqlCommand.Parameters.Add("@flag", SqlDbType.VarChar);
				//objSqlCommand.Parameters["@flag"].Value =z;
				
				
				
				objSqlDataAdapter =new SqlDataAdapter();
				objSqlDataAdapter.SelectCommand =objSqlCommand;
				objSqlDataAdapter.Fill(objDataSet);
				return objDataSet;


			}
			catch(SqlException objException)
			{
				throw(objException);
			}
			catch(Exception ex)
			{
				throw(ex);	
			}
			finally
			{
				CloseConnection(ref objSqlConnection);
			}
		
		}

		


		public DataSet deleteclientprod(string client_code,string client_name,string product_name,string compcode,string userid,string client_prod_code)
		{
			SqlConnection con;
			SqlCommand com;
			con=GetConnection();
			SqlDataAdapter da=new SqlDataAdapter();
			DataSet ds=new DataSet();
			try
			{
				con.Open();
                com = GetCommand("delclientbrand", ref con);
				com.CommandType=CommandType.StoredProcedure;
				
				com.Parameters.Add("@compcode",SqlDbType.VarChar);
				com.Parameters["@compcode"].Value=compcode;

				com.Parameters.Add("@client_code", SqlDbType.VarChar);
				com.Parameters["@client_code"].Value=client_code;

                com.Parameters.Add("@client_name",SqlDbType.VarChar);
				com.Parameters["@client_name"].Value=client_name;

                com.Parameters.Add("@brand_name", SqlDbType.VarChar);
                com.Parameters["@brand_name"].Value = product_name;

                com.Parameters.Add("@client_brand_code", SqlDbType.VarChar);
                com.Parameters["@client_brand_code"].Value = client_prod_code;


	
				com.Parameters.Add("@userid",SqlDbType.VarChar);
				com.Parameters["@userid"].Value=userid;


				da.SelectCommand=com;
				da.Fill(ds);
				return ds;
			}
			catch(Exception ex)
			{
				throw(ex);
			}
			finally
			{
				CloseConnection(ref con);
			}
		}



    public DataSet contactbind12(string client_code, string userid, string compcode,string client_prod_code)
    {

        SqlConnection objSqlConnection;
        SqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        SqlDataAdapter objSqlDataAdapter;
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("websp_clientbrandbind12", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            objSqlCommand.Parameters.Add("@client_code", SqlDbType.VarChar);
            objSqlCommand.Parameters["@client_code"].Value = client_code;

            objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@compcode"].Value = compcode;

            objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
            objSqlCommand.Parameters["@userid"].Value = userid;

            objSqlCommand.Parameters.Add("@client_brand_code", SqlDbType.VarChar);
            objSqlCommand.Parameters["@client_brand_code"].Value = client_prod_code;


       
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


        public DataSet chk(string client_code, string exec_code, string compcode, string userid, string prod_code, string brand_code)
    {
        SqlConnection con;
        SqlCommand com;
        con = GetConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        try
        {
            con.Open();
            com = GetCommand("chkclientbrand", ref con);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.Add("@compcode", SqlDbType.VarChar);
            com.Parameters["@compcode"].Value = compcode;

            com.Parameters.Add("@client_code", SqlDbType.VarChar);
            com.Parameters["@client_code"].Value = client_code;


            com.Parameters.Add("@product_code", SqlDbType.VarChar);
            com.Parameters["@product_code"].Value = prod_code;

            com.Parameters.Add("@userid", SqlDbType.VarChar);
            com.Parameters["@userid"].Value = userid;


            com.Parameters.Add("@exec_code", SqlDbType.VarChar);
            com.Parameters["@exec_code"].Value = exec_code;


            com.Parameters.Add("@brand_code", SqlDbType.VarChar);
            com.Parameters["@brand_code"].Value = brand_code;


            da.SelectCommand = com;
            da.Fill(ds);
            return ds;
        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            CloseConnection(ref con);
        }
    }

    public DataSet chk1(string client_code, string product_code, string compcode, string userid)
    {
        SqlConnection con;
        SqlCommand com;
        con = GetConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        try
        {
            con.Open();
            com = GetCommand("chkclientprod1", ref con);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.Add("@compcode", SqlDbType.VarChar);
            com.Parameters["@compcode"].Value = compcode;

            com.Parameters.Add("@client_code", SqlDbType.VarChar);
            com.Parameters["@client_code"].Value = client_code;


            com.Parameters.Add("@product_code", SqlDbType.VarChar);
            com.Parameters["@product_code"].Value = product_code;

            com.Parameters.Add("@userid", SqlDbType.VarChar);
            com.Parameters["@userid"].Value = userid;


          

            da.SelectCommand = com;
            da.Fill(ds);
            return ds;
        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            CloseConnection(ref con);
        }
    }


    public DataSet updateclientcode(string client_code, string client_name, string brand_code, string compcode, string userid, string client_prod_code, string prod_code ,string exec_code)
    {
        SqlConnection objSqlConnection;
        SqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        SqlDataAdapter objSqlDataAdapter;
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("updateclientbrand", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@compcode"].Value = compcode;

            objSqlCommand.Parameters.Add("@code", SqlDbType.VarChar);
            objSqlCommand.Parameters["@code"].Value = client_code;



            objSqlCommand.Parameters.Add("@client", SqlDbType.VarChar);
            objSqlCommand.Parameters["@client"].Value = client_name;

            objSqlCommand.Parameters.Add("@client_brand_code", SqlDbType.VarChar);
            objSqlCommand.Parameters["@client_brand_code"].Value = client_prod_code;

            objSqlCommand.Parameters.Add("@product_code", SqlDbType.VarChar);
            objSqlCommand.Parameters["@product_code"].Value = prod_code;

            objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
            objSqlCommand.Parameters["@userid"].Value = userid;


            objSqlCommand.Parameters.Add("@exec_code", SqlDbType.VarChar);
            objSqlCommand.Parameters["@exec_code"].Value = exec_code;


            objSqlCommand.Parameters.Add("@brand_code", SqlDbType.VarChar);
            objSqlCommand.Parameters["@brand_code"].Value = brand_code;


            




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






          public DataSet adbrand1(string compcode,string prod_code)
		{
			SqlConnection con;
			SqlCommand com;
			con=GetConnection();
			SqlDataAdapter da=new SqlDataAdapter();
			DataSet ds=new DataSet();
			try
			{
				con.Open();
                com = GetCommand("clientproductbrandbind ", ref con);
				com.CommandType=CommandType.StoredProcedure;

				com.Parameters.Add("@compcode", SqlDbType.VarChar);
				com.Parameters["@compcode"].Value =compcode;

                com.Parameters.Add("@productcode", SqlDbType.VarChar);
                com.Parameters["@productcode"].Value = prod_code;

               

				da.SelectCommand=com;
				da.Fill(ds);
				return ds;
			}
			catch(Exception ex)
			{
				throw(ex);
			}
			finally
			{
				CloseConnection(ref con);
			}
		}





    }

}