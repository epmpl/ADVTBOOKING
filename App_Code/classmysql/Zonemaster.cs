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
    /// Summary description for Zonemaster
    /// </summary>
    public class Zonemaster:connection 
    {
        public Zonemaster()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        public DataSet Advsave1(string companycode, string zonecode, string zonename, string alias, string UserId)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();      
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("ZONE_SAVE", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;
                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = companycode;
                objmysqlcommand.Parameters.Add("zonecode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["zonecode"].Value = zonecode;
                objmysqlcommand.Parameters.Add("zonename", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["zonename"].Value = zonename;
                objmysqlcommand.Parameters.Add("zonealias", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["zonealias"].Value = alias;
                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = UserId;
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

        public DataSet Advmodify1(string companycode, string zonecode, string zonename, string alias, string UserId)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();      
            try
            {

                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("ZONE_MODIFY", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;
                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = companycode;
                objmysqlcommand.Parameters.Add("zonecode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["zonecode"].Value = zonecode;
                objmysqlcommand.Parameters.Add("zonename", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["zonename"].Value = zonename;
                objmysqlcommand.Parameters.Add("zonealias", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["zonealias"].Value = alias;
               
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

        public DataSet Advdelete(string companycode, string zonecode, string zonename, string alias, string UserId)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();      
            
            try
            {

                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("Zone_Delete", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;
                objmysqlcommand.Parameters.Add("Comp_Code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Comp_Code"].Value = companycode;
                objmysqlcommand.Parameters.Add("Zone_Code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Zone_Code"].Value = zonecode;
                objmysqlcommand.Parameters.Add("Zone_Name", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Zone_Name"].Value = zonename;
                objmysqlcommand.Parameters.Add("Zone_Alias", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Zone_Alias"].Value = alias;

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

        public DataSet Advexecute1(string companycode, string zonecode, string zonename, string alias, string UserId)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();      
           
            try
            {

                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("Zone_Execute", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;
                objmysqlcommand.Parameters.Add("Comp_Code1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Comp_Code1"].Value = companycode;
                objmysqlcommand.Parameters.Add("Zone_Code1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Zone_Code1"].Value = zonecode;
                objmysqlcommand.Parameters.Add("Zone_Name1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Zone_Name1"].Value = zonename;
                objmysqlcommand.Parameters.Add("Zone_Alias1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Zone_Alias1"].Value = alias;

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

        public DataSet Advexecute2(string companycode, string zonecode, string zonename, string alias, string UserId)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();      
            try
            {




                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("Zone_Execute", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;
                objmysqlcommand.Parameters.Add("Comp_Code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Comp_Code"].Value = companycode;

                objmysqlcommand.Parameters.Add("Zone_Code", MySqlDbType.VarChar);
                if (zonecode != "" && zonecode != null)
                {
                objmysqlcommand.Parameters["Zone_Code"].Value = zonecode;
                }
                else
                {
                    objmysqlcommand.Parameters["Zone_Code"].Value = "%%";
                }
                objmysqlcommand.Parameters.Add("Zone_Name", MySqlDbType.VarChar);

                if (zonename != "" && zonename != null)
                {
                objmysqlcommand.Parameters["Zone_Name"].Value = zonename;
                }
                else
                {
                    objmysqlcommand.Parameters["Zone_Name"].Value = "%%";


                }

                objmysqlcommand.Parameters.Add("Zone_Alias", MySqlDbType.VarChar);
                if(alias != "" && alias != null)
                {

                objmysqlcommand.Parameters["Zone_Alias"].Value = alias;
                }
                else 
                {
                        objmysqlcommand.Parameters["Zone_Alias"].Value = "%%";

                }

                 objmysqlcommand.Parameters.Add("UserId", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["UserId"].Value = UserId;

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


        public DataSet Zonefpnl()
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();      
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("Zonefpnl", ref objmysqlconnection);
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

        public DataSet chkzonecode(string companycode, string UserId, string zonecode, string zonename)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();      
            try
            {

                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("zonechk", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;
                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = companycode;
                objmysqlcommand.Parameters.Add("zonecode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["zonecode"].Value = zonecode;
                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = UserId;

                objmysqlcommand.Parameters.Add("zonename", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["zonename"].Value = zonename;
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

        public DataSet countzonecode(string str)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();      
            try
            {

                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("chkzonecodename", ref objmysqlconnection);
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
