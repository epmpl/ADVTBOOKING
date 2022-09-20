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
/// Summary description for AdBookingIssue1
/// </summary>
public class AdBookingIssue1:connection
{
	public AdBookingIssue1()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataSet Adpub(string compcode)
    {
        MySqlConnection objmysqlconnection;
        MySqlCommand objmysqlcommand;
        objmysqlconnection = GetConnection();
        MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objmysqlconnection.Open();
            objmysqlcommand = GetCommand("Bind_PubName", ref objmysqlconnection);
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
    //********************************************************************************************************

    public DataSet pubcenter()
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

            //objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
            //objmysqlcommand.Parameters["compcode"].Value = compcode;

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
    //**********************************************************************************************************


    public DataSet pubedition(string pubname, string pubcenter)
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
            objmysqlcommand.Parameters["edit"].Value = pubname;

            objmysqlcommand.Parameters.Add("center", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["center"].Value = pubcenter;

            //objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
            //objmysqlcommand.Parameters["compcode"].Value = compcode;

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

    //**********************************************************************************************************       

    public DataSet pubsupply(string pubname, string pubedit)
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
            objmysqlcommand.Parameters["compcode"].Value = pubname;

            objmysqlcommand.Parameters.Add("editioncode", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["editioncode"].Value = pubedit;

            //objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
            //objmysqlcommand.Parameters["compcode"].Value = compcode;

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
    //***********************************************************************************************************



    //**********************************************************************************************************
    //This code is used for insert data into database

    public DataSet insertad(string adpub, string adcenter, string adedition, string adsuplement, int adbook, int adpages, string compcode)
    {
        MySqlConnection objmysqlconnection;
        MySqlCommand objmysqlcommand;
        objmysqlconnection = GetConnection();
        MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objmysqlconnection.Open();
            objmysqlcommand = GetCommand("insertadbookissue", ref objmysqlconnection);
            objmysqlcommand.CommandType = CommandType.StoredProcedure;

            objmysqlcommand.Parameters.Add("pubname", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["pubname"].Value = adpub;

            objmysqlcommand.Parameters.Add("pubcenter", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["pubcenter"].Value = adcenter;


            objmysqlcommand.Parameters.Add("edition", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["edition"].Value = adedition;

            objmysqlcommand.Parameters.Add("suplement", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["suplement"].Value = adsuplement;

            objmysqlcommand.Parameters.Add("bookvolume", MySqlDbType.Int32);
            objmysqlcommand.Parameters["bookvolume"].Value = adbook;

            objmysqlcommand.Parameters.Add("noofpages", MySqlDbType.Int32);
            objmysqlcommand.Parameters["noofpages"].Value = adpages;

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
    //*********************************************************************************************************

    public DataSet executead(string adpub, string adcenter, string adedition, string adsup, string compcode, string userid)
    {
        MySqlConnection objmysqlconnection;
        MySqlCommand objmysqlcommand;
        objmysqlconnection = GetConnection();
        MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objmysqlconnection.Open();
            objmysqlcommand = GetCommand("executeadbookissue", ref objmysqlconnection);
            objmysqlcommand.CommandType = CommandType.StoredProcedure;

            objmysqlcommand.Parameters.Add("pubname", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["pubname"].Value = adpub;


            objmysqlcommand.Parameters.Add("pubcenter", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["pubcenter"].Value = adcenter;


            objmysqlcommand.Parameters.Add("edition", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["edition"].Value = adedition;


            objmysqlcommand.Parameters.Add("supplement", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["supplement"].Value = adsup;


            objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["compcode"].Value = compcode;

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
    //**********************************************************************************************************
    //this code is used for check duplicate case;

    public DataSet duplicate(string adpub, string adcenter, string adedition, string adsuplement, string compcode, string userid)
    {
        MySqlConnection objmysqlconnection;
        MySqlCommand objmysqlcommand;
        objmysqlconnection = GetConnection();
        MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
        DataSet objDataSet = new DataSet();

        try
        {
            objmysqlconnection.Open();
            objmysqlcommand = GetCommand("adduplicate", ref objmysqlconnection);
            objmysqlcommand.CommandType = CommandType.StoredProcedure;

            objmysqlcommand.Parameters.Add("publication", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["publication"].Value = adpub;

            objmysqlcommand.Parameters.Add("center", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["center"].Value = adcenter;

            objmysqlcommand.Parameters.Add("edition", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["edition"].Value = adedition;

            objmysqlcommand.Parameters.Add("supplement", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["supplement"].Value = adsuplement;

            objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["compcode"].Value = compcode;

            objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
            if (userid == "NULL")
            {
                objmysqlcommand.Parameters["userid"].Value = System.DBNull.Value;
            }
            else
            {
                objmysqlcommand.Parameters["userid"].Value = userid;
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
    //*******************************************************************************************************

    //*******************************************************************************************************

    public DataSet deletead(string adpub, string adcenter, string adedition, string adsup, string compcode, string userid)
    {
        MySqlConnection objmysqlconnection;
        MySqlCommand objmysqlcommand;
        objmysqlconnection = GetConnection();
        MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objmysqlconnection.Open();
            objmysqlcommand = GetCommand("deleteadbooking", ref objmysqlconnection);
            objmysqlcommand.CommandType = CommandType.StoredProcedure;

            objmysqlcommand.Parameters.Add("pubname", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["pubname"].Value = adpub;

            objmysqlcommand.Parameters.Add("pubcenter", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["pubcenter"].Value = adcenter;

            objmysqlcommand.Parameters.Add("pubedition", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["pubedition"].Value = adedition;

            objmysqlcommand.Parameters.Add("pubsup", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["pubsup"].Value = adsup;

            objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["compcode"].Value = compcode;

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
    //*********************************************************************************************************
    public DataSet updatead(string adpub, string adcenter, string adedition, string adsup, string adbook, string adpages, string compcode, string userid)
    {
        MySqlConnection objmysqlconnection;
        MySqlCommand objmysqlcommand;
        objmysqlconnection = GetConnection();
        MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objmysqlconnection.Open();
            objmysqlcommand = GetCommand("updateadbooking", ref objmysqlconnection);
            objmysqlcommand.CommandType = CommandType.StoredProcedure;

            objmysqlcommand.Parameters.Add("pubname", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["pubname"].Value = adpub;

            objmysqlcommand.Parameters.Add("pubcenter", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["pubcenter"].Value = adcenter;

            objmysqlcommand.Parameters.Add("pubedition", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["pubedition"].Value = adedition;

            objmysqlcommand.Parameters.Add("pubsup", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["pubsup"].Value = adsup;

            objmysqlcommand.Parameters.Add("pubbook", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["pubbook"].Value = adbook;

            objmysqlcommand.Parameters.Add("pubpages", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["pubpages"].Value = adpages;



            objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["compcode"].Value = compcode;

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
    //********************************************************************************************************
}
}

