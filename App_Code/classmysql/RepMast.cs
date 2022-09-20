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
/// Summary description for RepMast
/// </summary>
    public class RepMast : connection 
{
	public RepMast()
	{
		//
		// TODO: Add constructor logic here
		//
	}

        public DataSet chkdoc(string compcode, string userid, string repcode, string repname, string dist, string taluka1)
		{
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();            
           	
			try
			{
				objmysqlconnection.Open();
                objmysqlcommand = GetCommand("chkrep_chkrep_p", ref objmysqlconnection);
				objmysqlcommand.CommandType = CommandType.StoredProcedure;

				objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["compcode"].Value =compcode;

				objmysqlcommand.Parameters.Add("repcode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["repcode"].Value =repcode;

                objmysqlcommand.Parameters.Add("repname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["repname"].Value = repname;

                objmysqlcommand.Parameters.Add("dist", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["dist"].Value = dist;

                objmysqlcommand.Parameters.Add("taluka1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["taluka1"].Value = taluka1;

				objmysqlDataAdapter.SelectCommand = objmysqlcommand;
				objmysqlDataAdapter.Fill(objDataSet);

				return objDataSet;

			}
			catch(Exception ex)
			{
				throw(ex);
			}
			finally
			{
				CloseConnection(ref objmysqlconnection);
			}
		}


        public DataSet docmodify(string compcode, string userid, string repcode, string repname, string country, string city, string state, string dist, string taluka1, string repstatus)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();            
           
			try
			{
				objmysqlconnection.Open();
                objmysqlcommand = GetCommand("repmodify_repmodify_p", ref objmysqlconnection);
				objmysqlcommand.CommandType = CommandType.StoredProcedure;

				objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["compcode"].Value =compcode;

              
				objmysqlcommand.Parameters.Add("repcode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["repcode"].Value =repcode;

				objmysqlcommand.Parameters.Add("repname", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["repname"].Value =repname;

                objmysqlcommand.Parameters.Add("country", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["country"].Value = country;


                objmysqlcommand.Parameters.Add("city", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["city"].Value = city;

                objmysqlcommand.Parameters.Add("state", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["state"].Value = state;

                objmysqlcommand.Parameters.Add("dist", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["dist"].Value = dist;


                objmysqlcommand.Parameters.Add("taluka1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["taluka1"].Value = taluka1;

                objmysqlcommand.Parameters.Add("repstatus", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["repstatus"].Value = repstatus;

				objmysqlDataAdapter.SelectCommand = objmysqlcommand;
				objmysqlDataAdapter.Fill(objDataSet);

				return objDataSet;

			}
			catch(Exception ex)
			{
				throw(ex);
			}
			finally
			{
				CloseConnection(ref objmysqlconnection);
			}
		}


        public DataSet docinsert(string compcode, string userid, string repcode, string repname, string country, string city, string state, string dist, string taluka1, string repstatus)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();            
           
			try
			{
				objmysqlconnection.Open();
                objmysqlcommand = GetCommand("repinsert_repinsert_p", ref objmysqlconnection);
				objmysqlcommand.CommandType = CommandType.StoredProcedure;

				objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["compcode"].Value =compcode;

				objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["userid"].Value =userid;

				objmysqlcommand.Parameters.Add("repcode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["repcode"].Value =repcode;

				objmysqlcommand.Parameters.Add("repname", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["repname"].Value =repname;

                objmysqlcommand.Parameters.Add("country", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["country"].Value = country;

                objmysqlcommand.Parameters.Add("city", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["city"].Value = city;

                objmysqlcommand.Parameters.Add("state", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["state"].Value = state;

                objmysqlcommand.Parameters.Add("dist", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["dist"].Value = dist;

                objmysqlcommand.Parameters.Add("taluka1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["taluka1"].Value = taluka1;

                objmysqlcommand.Parameters.Add("repstatus", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["repstatus"].Value = repstatus;


				
				objmysqlDataAdapter.SelectCommand = objmysqlcommand;
				objmysqlDataAdapter.Fill(objDataSet);

				return objDataSet;

			}
			catch(Exception ex)
			{
				throw(ex);
			}
			finally
			{
				CloseConnection(ref objmysqlconnection);
			}
		}



		public DataSet docexe(string compcode,string userid,string repcode,string repname)
		{
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();            
           
			try
			{
				objmysqlconnection.Open();
                objmysqlcommand = GetCommand("repexe_repexe_p", ref objmysqlconnection);
				objmysqlcommand.CommandType = CommandType.StoredProcedure;

				objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["compcode"].Value =compcode;

               

				objmysqlcommand.Parameters.Add("repcode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["repcode"].Value =repcode;

				objmysqlcommand.Parameters.Add("repname", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["repname"].Value =repname;

				

				objmysqlDataAdapter.SelectCommand = objmysqlcommand;
				objmysqlDataAdapter.Fill(objDataSet);

				return objDataSet;

			}
			catch(Exception ex)
			{
				throw(ex);
			}
			finally
			{
				CloseConnection(ref objmysqlconnection);
			}
		}



		public DataSet docfnpl(string compcode,string userid)
		{
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();            
           
			try
			{
				objmysqlconnection.Open();
                objmysqlcommand = GetCommand("repfnpl_repfnpl_p", ref objmysqlconnection);
				objmysqlcommand.CommandType = CommandType.StoredProcedure;

				objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["compcode"].Value =compcode;


				objmysqlDataAdapter.SelectCommand = objmysqlcommand;
				objmysqlDataAdapter.Fill(objDataSet);

				return objDataSet;

			}
			catch(Exception ex)
			{
				throw(ex);
			}
			finally
			{
				CloseConnection(ref objmysqlconnection);
			}
		}

		public DataSet docdel(string compcode,string userid,string repcode)
		{
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();            
           
			try
			{
				objmysqlconnection.Open();
                objmysqlcommand = GetCommand("repdel_repdel_p", ref objmysqlconnection);
				objmysqlcommand.CommandType = CommandType.StoredProcedure;

				objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["compcode"].Value =compcode;

				objmysqlcommand.Parameters.Add("repcode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["repcode"].Value =repcode;

				objmysqlDataAdapter.SelectCommand = objmysqlcommand;
				objmysqlDataAdapter.Fill(objDataSet);

				return objDataSet;

			}
			catch(Exception ex)
			{
				throw(ex);
			}
			finally
			{
				CloseConnection(ref objmysqlconnection);
			}

        }


        public DataSet chkrpcode1(string str)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();            
           
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("rpnamechk_rpnamechk_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("str", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["str"].Value = str;

                objmysqlcommand.Parameters.Add("cod", MySqlDbType.VarChar);
                if(str.Length >2)
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
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }
        }
// New change....
     public DataSet adcountryname(string compcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("adcountryname_adcountryname_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

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
