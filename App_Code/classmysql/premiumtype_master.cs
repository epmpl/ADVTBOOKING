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
    /// Summary description for premiumtype_master
    /// </summary>
    public class premiumtype_master:connection
    {
        public premiumtype_master()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataSet checkpremcode(string premcode, string compcode, string userid, string premname, string advtype)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objdataset = new DataSet();

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("checkprem", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("premcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["premcode"].Value = premcode;

                objmysqlcommand.Parameters.Add("userid1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid1"].Value = userid;

                objmysqlcommand.Parameters.Add("premname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["premname"].Value = premname;

                objmysqlcommand.Parameters.Add("advtype", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["advtype"].Value = advtype;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objdataset);
                return objdataset;
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
public DataSet insertintoprem(string advtype,string premcode,string alias,string premdesc,string compcode,string userid)
		{
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objdataset = new DataSet();

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("insertpremtype", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("premcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["premcode"].Value = premcode;

                objmysqlcommand.Parameters.Add("alias", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["alias"].Value = alias;

                objmysqlcommand.Parameters.Add("userid1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid1"].Value = userid;

                objmysqlcommand.Parameters.Add("premdesc", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["premdesc"].Value = premdesc;

                objmysqlcommand.Parameters.Add("advtype", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["advtype"].Value = advtype;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objdataset);
                return objdataset;
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
public DataSet executeintoprem(string advtype,string premcode,string alias,string premdesc,string compcode,string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objdataset = new DataSet();

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("executepremtype", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("premcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["premcode"].Value = premcode;

                objmysqlcommand.Parameters.Add("alias", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["alias"].Value = alias;

                //objmysqlcommand.Parameters.Add("userid1", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["userid1"].Value = userid;

                objmysqlcommand.Parameters.Add("premdesc", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["premdesc"].Value = premdesc;

                objmysqlcommand.Parameters.Add("advtype", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["advtype"].Value = advtype;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objdataset);
                return objdataset;
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
        public DataSet firstfromprem()
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objdataset = new DataSet();

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objdataset);

                return objdataset;
            }
            catch (Exception e)
            {
                throw (e);
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }
        }
public DataSet updateintoprem(string advtype,string premcode,string alias,string premdesc,string compcode,string userid)
		{
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objdataset = new DataSet();

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("updatepremtype", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("premcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["premcode"].Value = premcode;

                objmysqlcommand.Parameters.Add("alias", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["alias"].Value = alias;

                //objmysqlcommand.Parameters.Add("userid1", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["userid1"].Value = userid;

                objmysqlcommand.Parameters.Add("premdesc", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["premdesc"].Value = premdesc;

                objmysqlcommand.Parameters.Add("advtype", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["advtype"].Value = advtype;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objdataset);
                return objdataset;
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
public DataSet deleteintoprem(string premcode,string compcode,string userid)
		{
    MySqlConnection objmysqlconnection;
    MySqlCommand objmysqlcommand;
    objmysqlconnection=GetConnection();
    MySqlDataAdapter objmysqlDataAdapter=new MySqlDataAdapter();
    DataSet objdataset=new DataSet();

    try
    {
        objmysqlconnection.Open();
        objmysqlcommand=GetCommand("deletepremtype",ref objmysqlconnection);
        objmysqlcommand.CommandType=CommandType.StoredProcedure;

        objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
        objmysqlcommand.Parameters["compcode"].Value = compcode;

        objmysqlcommand.Parameters.Add("premcode", MySqlDbType.VarChar);
        objmysqlcommand.Parameters["premcode"].Value = premcode;

        
        //objmysqlcommand.Parameters.Add("userid", SqlDbType.VarChar);
        //objmysqlcommand.Parameters["userid"].Value = userid;

        objmysqlDataAdapter.SelectCommand=objmysqlcommand;
        objmysqlDataAdapter.Fill(objdataset);

        return objdataset;
    }
    catch(Exception e)
    {
        throw(e);
    }
    finally
    {
        CloseConnection(ref objmysqlconnection);
    }
}
 public DataSet chkptcode1(string str)
            {
                MySqlConnection objmysqlconnection;
                MySqlCommand objmysqlcommand;
                objmysqlconnection = GetConnection();
                MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
                DataSet objdataset = new DataSet();

                try
                {
                    objmysqlconnection.Open();
                    objmysqlcommand = GetCommand("chkptname", ref objmysqlconnection);
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
                   // objmysqlcommand.Parameters["cod"].Value = str;

                    objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                    objmysqlDataAdapter.Fill(objdataset);

                    return objdataset;
                }
                catch (Exception e)
                {
                    throw (e);
                }
                finally
                {
                    CloseConnection(ref objmysqlconnection);
                }
            }


    }

}