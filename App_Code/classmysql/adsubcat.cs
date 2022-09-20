using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using MySql.Data ;
using MySql.Data .MySqlClient ;
namespace NewAdbooking.classmysql
{
/// <summary>
/// Summary description for adsubcat
/// </summary>
public class adsubcat:connection 
{
	public adsubcat()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataSet addcategoryname(string comp_code)
    {
        MySqlConnection objmysqlconnection;
        MySqlCommand objmysqlcommand;
        objmysqlconnection = GetConnection();
        MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
        DataSet objDataSet = new DataSet(); 
        try
        {
            objmysqlconnection.Open();
            objmysqlcommand = GetCommand("ADCAT_ADCAT_P", ref objmysqlconnection);
            objmysqlcommand.CommandType = CommandType.StoredProcedure;

            objmysqlcommand.Parameters.Add("COMPANY_CODE", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["COMPANY_CODE"].Value = comp_code;

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


    public DataSet getcode(string catname)
    {
        MySqlConnection objmysqlconnection;
        MySqlCommand objmysqlcommand;
        objmysqlconnection = GetConnection();
        MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
        DataSet objDataSet = new DataSet(); 
        try
        {
            objmysqlconnection.Open();
            objmysqlcommand = GetCommand("FILLCATCODE_FILLCATCODE_P", ref objmysqlconnection);
            objmysqlcommand.CommandType = CommandType.StoredProcedure;

            objmysqlcommand.Parameters.Add("catname", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["catname"].Value = catname;


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






    public DataSet savesubcat(string compcode, string catcode, string subcatcode, string subcatname, string subcatalias, string userid,string imagename,string txtxml,string pri)
    {
        MySqlConnection objmysqlconnection;
        MySqlCommand objmysqlcommand;
        objmysqlconnection = GetConnection();
        MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
        DataSet objDataSet = new DataSet(); 
        try
        {
            objmysqlconnection.Open();
            objmysqlcommand = GetCommand("SUBCATSAVE_SUBCATSAVE_P", ref objmysqlconnection);
            objmysqlcommand.CommandType = CommandType.StoredProcedure;


            objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["compcode"].Value = compcode;

            objmysqlcommand.Parameters.Add("catcode", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["catcode"].Value = catcode;

            objmysqlcommand.Parameters.Add("subcatcode", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["subcatcode"].Value = subcatcode;

            objmysqlcommand.Parameters.Add("subcatname", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["subcatname"].Value = subcatname;

            objmysqlcommand.Parameters.Add("subcatalias", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["subcatalias"].Value = subcatalias;

            objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["userid"].Value = userid;

            objmysqlcommand.Parameters.Add("imagename", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["imagename"].Value = imagename;

            objmysqlcommand.Parameters.Add("subcatxml", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["subcatxml"].Value = txtxml;

            objmysqlcommand.Parameters.Add("pri", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["pri"].Value = pri;
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







    public DataSet exesubcat(string compcode, string catcode, string subcatcode, string subcatname, string subcatalias, string userid)
    {
        MySqlConnection objmysqlconnection;
        MySqlCommand objmysqlcommand;
        objmysqlconnection = GetConnection();
        MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
        DataSet objDataSet = new DataSet(); 
        try
        {
            objmysqlconnection.Open();
            objmysqlcommand = GetCommand("SUBCATEXE_SUBCATEXE_P", ref objmysqlconnection);
            objmysqlcommand.CommandType = CommandType.StoredProcedure;


            objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["compcode"].Value = compcode;

            objmysqlcommand.Parameters.Add("catcode", MySqlDbType.VarChar);
           
            objmysqlcommand.Parameters["catcode"].Value = catcode;


            objmysqlcommand.Parameters.Add("subcatcode", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["subcatcode"].Value = subcatcode;





            objmysqlcommand.Parameters.Add("subcatname", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["subcatname"].Value = subcatname;


            objmysqlcommand.Parameters.Add("subcatalias", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["subcatalias"].Value = subcatalias;


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












    public DataSet updatesubcat(string compcode, string catcode, string subcatcode, string subcatname, string subcatalias, string userid, string imagename, string txtxml, string pri)
    {
        MySqlConnection objmysqlconnection;
        MySqlCommand objmysqlcommand;
        objmysqlconnection = GetConnection();
        MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
        DataSet objDataSet = new DataSet(); 
        try
        {
            objmysqlconnection.Open();
            objmysqlcommand = GetCommand("SUBCATUPDATE_SUBCATUPDATE_P", ref objmysqlconnection);
            objmysqlcommand.CommandType = CommandType.StoredProcedure;


            objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["compcode"].Value = compcode;

            objmysqlcommand.Parameters.Add("catcode", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["catcode"].Value = catcode;

            objmysqlcommand.Parameters.Add("subcatcode", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["subcatcode"].Value = subcatcode;

            objmysqlcommand.Parameters.Add("subcatname", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["subcatname"].Value = subcatname;

            objmysqlcommand.Parameters.Add("subcatalias", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["subcatalias"].Value = subcatalias;

            objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["userid"].Value = userid;


            objmysqlcommand.Parameters.Add("imagename", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["imagename"].Value = imagename;

            objmysqlcommand.Parameters.Add("subcatxml", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["subcatxml"].Value = txtxml;

            objmysqlcommand.Parameters.Add("pri", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["pri"].Value = pri;

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




    public DataSet firstsubcat(string compcode, string catcode, string userid)
    {
        MySqlConnection objmysqlconnection;
        MySqlCommand objmysqlcommand;
        objmysqlconnection = GetConnection();
        MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
        DataSet objDataSet = new DataSet(); 
        try
        {
            objmysqlconnection.Open();
            objmysqlcommand = GetCommand("SUBCATFNPL_SUBCATFNPL_P", ref objmysqlconnection);
            objmysqlcommand.CommandType = CommandType.StoredProcedure;


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


    public DataSet chksubcat(string compcode, string subcatcode, string userid)
    {
        MySqlConnection objmysqlconnection;
        MySqlCommand objmysqlcommand;
        objmysqlconnection = GetConnection();
        MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
        DataSet objDataSet = new DataSet(); 
        try
        {
            objmysqlconnection.Open();
            objmysqlcommand = GetCommand("SUBCATCHK_SUBCATCHK_P", ref objmysqlconnection);
            objmysqlcommand.CommandType = CommandType.StoredProcedure;


            objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["compcode"].Value = compcode;

            objmysqlcommand.Parameters.Add("subcatcode", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["subcatcode"].Value = subcatcode;


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







    public DataSet presubcat(string compcode, string catcode, string userid)
    {
        MySqlConnection objmysqlconnection;
        MySqlCommand objmysqlcommand;
        objmysqlconnection = GetConnection();
        MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
        DataSet objDataSet = new DataSet(); 
        try
        {
            objmysqlconnection.Open();
            objmysqlcommand = GetCommand("SUBCATFNPL_SUBCATFNPL_P", ref objmysqlconnection);
            objmysqlcommand.CommandType = CommandType.StoredProcedure;


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



    public DataSet nextsubcat(string compcode, string catcode, string userid)
    {
        MySqlConnection objmysqlconnection;
        MySqlCommand objmysqlcommand;
        objmysqlconnection = GetConnection();
        MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
        DataSet objDataSet = new DataSet(); 
        try
        {
            objmysqlconnection.Open();
            objmysqlcommand = GetCommand("SUBCATFNPL_SUBCATFNPL_P", ref objmysqlconnection);
            objmysqlcommand.CommandType = CommandType.StoredProcedure;


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





    public DataSet lastsubcat(string compcode, string catcode, string userid)
    {
        MySqlConnection objmysqlconnection;
        MySqlCommand objmysqlcommand;
        objmysqlconnection = GetConnection();
        MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
        DataSet objDataSet = new DataSet(); 
        try
        {
            objmysqlconnection.Open();
            objmysqlcommand = GetCommand("SUBCATFNPL_SUBCATFNPL_P", ref objmysqlconnection);
            objmysqlcommand.CommandType = CommandType.StoredProcedure;


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



    public DataSet delsubcat(string compcode, string catcode, string userid, string subcatcode)
    {
        MySqlConnection objmysqlconnection;
        MySqlCommand objmysqlcommand;
        objmysqlconnection = GetConnection();
        MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
        DataSet objDataSet = new DataSet(); 
        try
        {
            objmysqlconnection.Open();
            objmysqlcommand = GetCommand("SUBCATDEL_SSUBCATDEL_P", ref objmysqlconnection);
            objmysqlcommand.CommandType = CommandType.StoredProcedure;


            objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["compcode"].Value = compcode;



            objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["userid"].Value = userid;

            objmysqlcommand.Parameters.Add("catcode", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["catcode"].Value = catcode;



            objmysqlcommand.Parameters.Add("subcatcode", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["subcatcode"].Value = subcatcode;

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



    public DataSet chksubcatcode1(string str, string catcode, string statecode)
    {
        MySqlConnection objmysqlconnection;
        MySqlCommand objmysqlcommand;
        objmysqlconnection = GetConnection();
        MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
        DataSet objDataSet = new DataSet(); 
        try
        {
            objmysqlconnection.Open();
            objmysqlcommand = GetCommand("CHKADSUBCATNAME_CHKADSUBCATNAME_P", ref objmysqlconnection);
            objmysqlcommand.CommandType = CommandType.StoredProcedure;

            objmysqlcommand.Parameters.Add("STR", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["STR"].Value = str;

            objmysqlcommand.Parameters.Add("COD", MySqlDbType.VarChar);
            if(str.Length >2)
            {
                objmysqlcommand.Parameters["COD"].Value = str.Substring(0, 2);
            }

            else
            {
            objmysqlcommand.Parameters["cod"].Value = str;
            }

            objmysqlcommand.Parameters.Add("CATCODE", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["CATCODE"].Value = catcode;

            objmysqlcommand.Parameters.Add("PSTATECODE", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["PSTATECODE"].Value = statecode;

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
