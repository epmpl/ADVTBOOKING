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
/// Summary description for DocumentMaster
/// </summary>
public class DocumentMaster:connection 
{
	public DocumentMaster()
	{
		//
		// TODO: Add constructor logic here
		//
	}

		public DataSet chkdoc(string compcode,string userid,string doccode)
		{
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
			try
			{
				objmysqlconnection.Open();
				objmysqlcommand = GetCommand("chkdoc", ref objmysqlconnection);
				objmysqlcommand.CommandType = CommandType.StoredProcedure;

				objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["compcode"].Value =compcode;

				objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["userid"].Value =userid;

				objmysqlcommand.Parameters.Add("doccode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["doccode"].Value =doccode;

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
	

		public DataSet docmodify(string compcode,string userid,string doccode,string doctype,string alias,string multi)
		{
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
			try
			{
				objmysqlconnection.Open();
				objmysqlcommand = GetCommand("docmodify", ref objmysqlconnection);
				objmysqlcommand.CommandType = CommandType.StoredProcedure;

				objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["compcode"].Value =compcode;

				objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["userid"].Value =userid;

				objmysqlcommand.Parameters.Add("doccode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["doccode"].Value =doccode;

				objmysqlcommand.Parameters.Add("doctype", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["doctype"].Value =doctype;

				objmysqlcommand.Parameters.Add("alias", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["alias"].Value =alias;

				objmysqlcommand.Parameters.Add("multi", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["multi"].Value =multi;

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


		public DataSet docinsert(string compcode,string userid,string doccode,string doctype,string alias,string multi)
		{
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
			try
			{
				objmysqlconnection.Open();
				objmysqlcommand = GetCommand("docinsert", ref objmysqlconnection);
				objmysqlcommand.CommandType = CommandType.StoredProcedure;

				objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["compcode"].Value =compcode;

				objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["userid"].Value =userid;

				objmysqlcommand.Parameters.Add("doccode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["doccode"].Value =doccode;

				objmysqlcommand.Parameters.Add("doctype", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["doctype"].Value =doctype;

				objmysqlcommand.Parameters.Add("alias", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["alias"].Value =alias;

				objmysqlcommand.Parameters.Add("multi", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["multi"].Value =multi;

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


		public DataSet docexe(string compcode,string userid,string doccode,string doctype,string alias,string multi)
		{
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
			try
			{
				objmysqlconnection.Open();
				objmysqlcommand = GetCommand("docexe", ref objmysqlconnection);
				objmysqlcommand.CommandType = CommandType.StoredProcedure;

				objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["compcode"].Value =compcode;

				objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["userid"].Value =userid;

				objmysqlcommand.Parameters.Add("doccode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["doccode"].Value =doccode;

				objmysqlcommand.Parameters.Add("doctype", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["doctype"].Value =doctype;

				objmysqlcommand.Parameters.Add("alias", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["alias"].Value =alias;

				objmysqlcommand.Parameters.Add("multi", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["multi"].Value =multi;

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
				objmysqlcommand = GetCommand("docfnpl", ref objmysqlconnection);
				objmysqlcommand.CommandType = CommandType.StoredProcedure;

				objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["compcode"].Value =compcode;

				objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["userid"].Value =userid;

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

		public DataSet docdel(string compcode,string userid,string doccode)
		{
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
			try
			{
				objmysqlconnection.Open();
				objmysqlcommand = GetCommand("docdel", ref objmysqlconnection);
				objmysqlcommand.CommandType = CommandType.StoredProcedure;

				objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["compcode"].Value =compcode;

				objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["userid"].Value =userid;

				objmysqlcommand.Parameters.Add("doccode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["doccode"].Value =doccode;

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
	
	}
}

