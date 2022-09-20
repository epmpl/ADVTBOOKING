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
/// Summary description for addummydaypages
/// </summary>
public class addummydaypages:connection 
{
	public addummydaypages()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    public DataSet getPubName(string compcode)
    {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
        
        try
        {
            objmysqlconnection.Open();
            objmysqlcommand = GetCommand("bind_pubname_bind_pubedname_p", ref objmysqlconnection);
            objmysqlcommand.CommandType = CommandType.StoredProcedure;
            objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["compcode"].Value = compcode;

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

    public DataSet getPubCName()
    {
          MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
      
        try
        {

            objmysqlconnection.Open();
                objmysqlcommand = GetCommand("Bind_PubCentName", ref objmysqlconnection);
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
    //**********************************************************************************************************

    //**********This function is used to GET the Edition Name using stored procedure Bind_EdiName***************
    public DataSet getEdiName(string pubcode, string pubcenter)
    {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
        
        try
        {
            objmysqlconnection.Open();
            objmysqlcommand = GetCommand("Bind_EdiName", ref objmysqlconnection);
            objmysqlcommand.CommandType = CommandType.StoredProcedure;
            objmysqlcommand.Parameters.Add("edit", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["edit"].Value = pubcode;
            objmysqlcommand.Parameters.Add("center", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["center"].Value = pubcenter;

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

    //**********************************************************************************************************

    //**********This function is used to GET the Suppliment using stored procedure bindsuppliment***************

    public DataSet getSuppliment(string pubcode, string pubedit)
    {
          MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
       

        try
        {
            objmysqlconnection.Open();
            objmysqlcommand = GetCommand("bindsuppliment", ref objmysqlconnection);
            objmysqlcommand.CommandType = CommandType.StoredProcedure;
            objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["compcode"].Value = pubcode;
            objmysqlcommand.Parameters.Add("editioncode", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["editioncode"].Value = pubedit;


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
    //**********************************************************************************************************

    //**********This function is used to Insert the Data using stored procedure adDDPInsert***************

    public DataSet insertData(string day, string pubCode, string centerCode, string ediCode, string supCode, string nPages, string dFrom, string dTo, string compCode, string userId)
    {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
       

        try
        {
            objmysqlconnection.Open();
            objmysqlcommand = GetCommand("adDDPInsert", ref objmysqlconnection);
            objmysqlcommand.CommandType = CommandType.StoredProcedure;
            objmysqlcommand.Parameters.Add("pub_day", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["pub_day"].Value = day;

            objmysqlcommand.Parameters.Add("pub_code", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["pub_code"].Value = pubCode;

            objmysqlcommand.Parameters.Add("center_code", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["center_code"].Value = centerCode;

            objmysqlcommand.Parameters.Add("edition_code", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["edition_code"].Value = ediCode;

            objmysqlcommand.Parameters.Add("sub_pub", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["sub_pub"].Value = supCode;

            objmysqlcommand.Parameters.Add("npages", MySqlDbType.Int24);
            if (nPages == "")
            {
                objmysqlcommand.Parameters["npages"].Value = System.DBNull.Value;
            }
            else
            {
                objmysqlcommand.Parameters["npages"].Value = Convert.ToInt32(nPages);
            }
            objmysqlcommand.Parameters.Add("datefrom", MySqlDbType.DateTime);
            if (dFrom == "")
            {
                objmysqlcommand.Parameters["datefrom"].Value = System.DBNull.Value;
            }
            else
            {
                objmysqlcommand.Parameters["datefrom"].Value = Convert.ToDateTime(dFrom);
            }
            objmysqlcommand.Parameters.Add("dateto", MySqlDbType.DateTime);
            if (dTo == "")
            {
                objmysqlcommand.Parameters["dateto"].Value = System.DBNull.Value;
            }
            else
            {
                objmysqlcommand.Parameters["dateto"].Value = Convert.ToDateTime(dTo);
            }
            objmysqlcommand.Parameters.Add("comp_code", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["comp_code"].Value = compCode;

            objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["userid"].Value = userId;


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

    //**********************************************************************************************************

    //**********This function is used to check the Duplicate Data using stored procedure adDDPDupChk*********************
    public string chkDupRec(string day, string pubCode, string centerCode, string ediCode, string supCode, string recordId)
    {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            string dup;

        try
        {
            objmysqlconnection.Open();
            objmysqlcommand = GetCommand("adDDPDupChk", ref objmysqlconnection);
            objmysqlcommand.CommandType = CommandType.StoredProcedure;
            objmysqlcommand.Parameters.Add("pub_day", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["pub_day"].Value = day;

            objmysqlcommand.Parameters.Add("pub_code", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["pub_code"].Value = pubCode;

            objmysqlcommand.Parameters.Add("center_code", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["center_code"].Value = centerCode;

            objmysqlcommand.Parameters.Add("edition_code", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["edition_code"].Value = ediCode;

            objmysqlcommand.Parameters.Add("sub_pub", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["sub_pub"].Value = supCode;

            objmysqlcommand.Parameters.Add("record_id", MySqlDbType.VarChar);
            if (recordId == "")
            {
                objmysqlcommand.Parameters["record_id"].Value = System.DBNull.Value;
            }
            else
            {
                objmysqlcommand.Parameters["record_id"].Value = recordId;
            }

            objmysqlDataAdapter.SelectCommand = objmysqlcommand;
            objmysqlDataAdapter.Fill(objDataSet);
          
            if (objDataSet.Tables[0].Rows.Count > 0)
            {
                dup = "y";
            }
            else
            {
                dup = "n";
            }
            return dup;
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
    //**********************************************************************************************************
    public DataSet getData(string compCode, string day, string pubCode, string centerCode, string ediCode, string supCode)
    {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
      

        try
        {
            objmysqlconnection.Open();
            objmysqlcommand = GetCommand("adDDPExecute", ref objmysqlconnection);
            objmysqlcommand.CommandType = CommandType.StoredProcedure;

            objmysqlcommand.Parameters.Add("comp_code", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["comp_code"].Value = compCode;

            objmysqlcommand.Parameters.Add("pub_day", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["pub_day"].Value = day;

            objmysqlcommand.Parameters.Add("pub_code", MySqlDbType.VarChar);
            if (pubCode == "")
            {
                objmysqlcommand.Parameters["pub_code"].Value = "0";
            }
            else
            {
                objmysqlcommand.Parameters["pub_code"].Value = pubCode;
            }

            objmysqlcommand.Parameters.Add("center_code", MySqlDbType.VarChar);
            if (centerCode == "")
            {
                objmysqlcommand.Parameters["center_code"].Value = "0";
            }
            else
            {
                objmysqlcommand.Parameters["center_code"].Value = centerCode;
            }

            objmysqlcommand.Parameters.Add("edition_code", MySqlDbType.VarChar);
            if (ediCode == "")
            {
                objmysqlcommand.Parameters["edition_code"].Value = "0";
            }
            else
            {
                objmysqlcommand.Parameters["edition_code"].Value = ediCode;
            }

            objmysqlcommand.Parameters.Add("sub_pub", MySqlDbType.VarChar);
            if (supCode == "")
            {
                objmysqlcommand.Parameters["sub_pub"].Value = "0";
            }
            else
            {
                objmysqlcommand.Parameters["sub_pub"].Value = supCode;
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

    //**********************************************************************************************************
    public DataSet deleteData(string recordId)
    {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();       
     
        try
        {
            objmysqlconnection.Open();
            objmysqlcommand = GetCommand("adDDPDelete", ref objmysqlconnection);
            objmysqlcommand.CommandType = CommandType.StoredProcedure;



            objmysqlcommand.Parameters.Add("record_id", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["record_id"].Value = recordId;

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

    //******This is used to Update the data ori stand for original data on the basis update will occur************
    public DataSet updateData(string recordId, string day, string pubCode, string centerCode, string ediCode, string supCode, string nPages, string dFrom, string dTo, string compCode, string userId)
    {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
       

        try
        {
            objmysqlconnection.Open();
            objmysqlcommand = GetCommand("adDDPUpdate", ref objmysqlconnection);
            objmysqlcommand.CommandType = CommandType.StoredProcedure;

            objmysqlcommand.Parameters.Add("record_id", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["record_id"].Value = recordId;

            objmysqlcommand.Parameters.Add("pub_day", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["pub_day"].Value = day;

            objmysqlcommand.Parameters.Add("pub_code", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["pub_code"].Value = pubCode;

            objmysqlcommand.Parameters.Add("center_code", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["center_code"].Value = centerCode;

            objmysqlcommand.Parameters.Add("edition_code", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["edition_code"].Value = ediCode;

            objmysqlcommand.Parameters.Add("sub_pub", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["sub_pub"].Value = supCode;

            objmysqlcommand.Parameters.Add("npages", MySqlDbType.Int24);
            if (nPages == "")
            {
                objmysqlcommand.Parameters["npages"].Value = System.DBNull.Value;
            }
            else
            {
                objmysqlcommand.Parameters["npages"].Value = Convert.ToInt32(nPages);
            }
            objmysqlcommand.Parameters.Add("datefrom", MySqlDbType.DateTime);
            if (dFrom == "")
            {
                objmysqlcommand.Parameters["datefrom"].Value = System.DBNull.Value;
            }
            else
            {
                objmysqlcommand.Parameters["datefrom"].Value = Convert.ToDateTime(dFrom);
            }
            objmysqlcommand.Parameters.Add("dateto", MySqlDbType.DateTime);
            if (dTo == "")
            {
                objmysqlcommand.Parameters["dateto"].Value = System.DBNull.Value;
            }
            else
            {
                objmysqlcommand.Parameters["dateto"].Value = Convert.ToDateTime(dTo);
            }
            objmysqlcommand.Parameters.Add("comp_code", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["comp_code"].Value = compCode;

            objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["userid"].Value = userId;


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


    //**********************************************************************************************************
}
}