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
/// Summary description for BillStatus
/// </summary>
public class BillStatus:connection 
{
	public BillStatus()
	{
		//
		// TODO: Add constructor logic here
		//
	}

       public DataSet billsave1(string billid, string billstatus, string billalias)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();            
           
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("BILL_SAVE_BILL_SAVE_P", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;
                objmysqlcommand.Parameters.Add("pbillid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pbillid"].Value = billid;
                objmysqlcommand.Parameters.Add("pbillstatus", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pbillstatus"].Value = billstatus;
                objmysqlcommand.Parameters.Add("pbillalias", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pbillalias"].Value = billalias;

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
         //public DataSet billmodify(string companycode, string billid, string billstatus, string billalias, string UserId)

        public DataSet billmodify(string billid, string billstatus, string billalias)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();            
           
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("BILL_MODIFY_BILL_MODIFY_P", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;
                objmysqlcommand.Parameters.Add("pbill_id", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pbill_id"].Value = billid;
                objmysqlcommand.Parameters.Add("pbillstatus", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pbillstatus"].Value = billstatus;
                objmysqlcommand.Parameters.Add("pbillalias", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pbillalias"].Value = billalias;

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

    public DataSet chkbillid(string billid, string billstatus, string mod)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();            
           
            try
            {

                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("BILLCHK_BILLCHK_P", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;
                objmysqlcommand.Parameters.Add("pbillid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pbillid"].Value = billid;
                objmysqlcommand.Parameters.Add("pmod1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pmod1"].Value = mod;
                objmysqlcommand.Parameters.Add("pbillstatus", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pbillstatus"].Value = billstatus; 
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

       public DataSet billexecute1(string billid, string billstatus, string billalias)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();            
           
            try
            {


                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("BILL_EXE_BILL_EXE_P", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;
                objmysqlcommand.Parameters.Add("vbill_id", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["vbill_id"].Value = billid;
                objmysqlcommand.Parameters.Add("vbillstatus", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["vbillstatus"].Value = billstatus;
                objmysqlcommand.Parameters.Add("vbillalias", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["vbillalias"].Value = billalias;
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


        public DataSet billfpnl()
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();            
           
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("BILLFPNL_BILLFPNL_P", ref objmysqlconnection);
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


        public DataSet billdelete(string billid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();            
           
            try
            {


                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("bill_delete_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;
                objmysqlcommand.Parameters.Add("billid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["billid"].Value = billid;
             
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


        public DataSet billexecute2(string billid, string billstatus, string billalias)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();            
           
            try
            {

                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("BILL_EXE_BILL_EXE_P", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;
                objmysqlcommand.Parameters.Add("billid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["billid"].Value = billid;
                objmysqlcommand.Parameters.Add("billstatus", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["billstatus"].Value = billstatus;
                objmysqlcommand.Parameters.Add("billalias", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["billalias"].Value = billalias;
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


        public DataSet billidauto(string str)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();            
           
            try
            {

                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("BILL_AUTO_BILL_AUTO_P", ref objmysqlconnection);
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
