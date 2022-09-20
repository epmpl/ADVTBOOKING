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
    /// Summary description for NoIssueDayMaster
    /// </summary>
    public class NoIssueDayMaster:connection
    {
        public NoIssueDayMaster()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataSet checknoisscode(string noisscode,string txtnoissuedayname1, string compcode, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("checknoissuedaycode_checknoissuedaycode_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("Pcomp_code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Pcomp_code"].Value = compcode;

                objmysqlcommand.Parameters.Add("Puserid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Puserid"].Value = userid;

                objmysqlcommand.Parameters.Add("Pno_iss_day_code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Pno_iss_day_code"].Value = noisscode;

                objmysqlcommand.Parameters.Add("Ptxtnoissuedayname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Ptxtnoissuedayname"].Value = txtnoissuedayname1;
              
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

        public DataSet insertnoiss(string noisscode, string noissname, string compcode, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("issuedayinsert_issuedayinsert_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("uid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["uid"].Value = userid;

                objmysqlcommand.Parameters.Add("noissuedaycode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["noissuedaycode"].Value = noisscode;

                objmysqlcommand.Parameters.Add("noissday", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["noissday"].Value = noissname;

             
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

        public DataSet executenoiss(string compcode, string noisscode, string noissname, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("NoIssueDayMaster_Execute_NoIssueDayMaster_Execute_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("pComp_Code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pComp_Code"].Value = compcode;

                objmysqlcommand.Parameters.Add("pUserId", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pUserId"].Value = userid;


                objmysqlcommand.Parameters.Add("pNo_Iss_Day_Code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pNo_Iss_Day_Code"].Value = noisscode;

                objmysqlcommand.Parameters.Add("pNo_Iss_Day", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pNo_Iss_Day"].Value = noissname;


            
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

        //public DataSet firstquery()
        //{
        //    MySqlConnection objmysqlconnection;
        //    MySqlCommand objmysqlcommand;
        //    objmysqlconnection = GetConnection();
        //    MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
        //    DataSet objDataSet = new DataSet();
        //    try
        //    {
        //        objmysqlconnection.Open();
        //        objmysqlcommand = GetCommand("NoIssueDayMaster_pnl", ref objmysqlconnection);
        //        objmysqlcommand.CommandType = CommandType.StoredProcedure;

        //        //objmysqlcommand.Parameters.Add("Comp_Code", MySqlDbType.VarChar);
        //        //objmysqlcommand.Parameters["Comp_Code"].Value =compcode;

        //        //objmysqlcommand.Parameters.Add("UserId", MySqlDbType.VarChar);
        //        //objmysqlcommand.Parameters["UserId"].Value =userid;

        //        objmysqlDataAdapter.SelectCommand = objmysqlcommand;
        //        objmysqlDataAdapter.Fill(objDataSet);
        //        return objDataSet;
        //    }
        
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //    finally
        //    {
        //        CloseConnection(ref objmysqlconnection);
        //    }
        //}

        public DataSet updaetcode(string noisscode, string noissname, string compcode, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("NoIssueDayMaster_Modify_NoIssueDayMaster_Modify_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("pcomp_code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pcomp_code"].Value = compcode;

                objmysqlcommand.Parameters.Add("puserid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["puserid"].Value = userid;

                objmysqlcommand.Parameters.Add("pno_iss_day_code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pno_iss_day_code"].Value = noisscode;

                objmysqlcommand.Parameters.Add("pno_iss_day", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pno_iss_day"].Value = noissname;

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

        public DataSet deletenoiss(string noisscode, string noissname, string compcode, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("NoIssueDayMaster_Delete_NoIssueDayMaster_Delete_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("pcomp_code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pcomp_code"].Value = compcode;

                objmysqlcommand.Parameters.Add("puserid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["puserid"].Value = userid;

                objmysqlcommand.Parameters.Add("pno_iss_day_code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pno_iss_day_code"].Value = noisscode;

                objmysqlcommand.Parameters.Add("pno_iss_day", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pno_iss_day"].Value = noissname;

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

        public DataSet dauto(string str)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("NoIssueDayMaster_Auto_NoIssueDayMaster_Auto_p", ref objmysqlconnection);
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
