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
/// Summary description for BgColor
/// </summary>
public class BgColor:connection 
{
	public BgColor()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataSet bgSave(string bgid, string bgname, string bgalias, string pub, string edit, string cat, string cat2, string cat3, string cat4, string cat5, string coltyp, string comcode, string bgtype, string bgamt)
    {
              MySqlConnection objmysqlconnection;
              MySqlCommand objmysqlcommand;
              objmysqlconnection = GetConnection();
              MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
              DataSet objDataSet = new DataSet();       
           
            try
            {

                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("bg_save_bg_save_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("bgid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["bgid"].Value = bgid;

                objmysqlcommand.Parameters.Add("bgname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["bgname"].Value = bgname;

                objmysqlcommand.Parameters.Add("bgalias", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["bgalias"].Value = bgalias;

                objmysqlcommand.Parameters.Add("pub1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pub1"].Value = pub;

                objmysqlcommand.Parameters.Add("edit", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["edit"].Value = edit;

                objmysqlcommand.Parameters.Add("cat1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["cat1"].Value = cat;

                objmysqlcommand.Parameters.Add("cat2", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["cat2"].Value = cat2;

                objmysqlcommand.Parameters.Add("cat3", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["cat3"].Value = cat3;

                objmysqlcommand.Parameters.Add("cat4", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["cat4"].Value = cat4;

                objmysqlcommand.Parameters.Add("cat5", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["cat5"].Value = cat5;

                objmysqlcommand.Parameters.Add("coltype", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["coltype"].Value = coltyp;

                objmysqlcommand.Parameters.Add("comcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["comcode"].Value = comcode;

                objmysqlcommand.Parameters.Add("bgtype", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["bgtype"].Value = bgtype;

                objmysqlcommand.Parameters.Add("bgamt", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["bgamt"].Value = bgamt;


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
    public DataSet chkbgid(string bgid, string pub, string edit, string cat, string coltyp, string bgname)
    {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();       
            
            try
            {

                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("bgchk_bgchk_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("pbgid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pbgid"].Value = bgid;

                objmysqlcommand.Parameters.Add("ppub1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["ppub1"].Value = pub;

                objmysqlcommand.Parameters.Add("pedit1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pedit1"].Value = edit;

                objmysqlcommand.Parameters.Add("pcat1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pcat1"].Value = cat;

                objmysqlcommand.Parameters.Add("pcoltyp", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pcoltyp"].Value = coltyp;

                objmysqlcommand.Parameters.Add("pbgname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pbgname"].Value = bgname;
               
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
    public DataSet bgmodify(string bgid, string bgname, string bgalias, string pub, string edit, string cat, string cat2, string cat3, string cat4, string cat5, string coltyp, string compcode)
    {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();       
            try
            {

                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("Bg_Modify_Bg_Modify_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("bgid1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["bgid1"].Value = bgid;

                objmysqlcommand.Parameters.Add("bgname1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["bgname1"].Value = bgname;

                objmysqlcommand.Parameters.Add("bgalias1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["bgalias1"].Value = bgalias;

                objmysqlcommand.Parameters.Add("pub", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pub"].Value = pub;

                objmysqlcommand.Parameters.Add("edit", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["edit"].Value = edit;

                objmysqlcommand.Parameters.Add("cat", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["cat"].Value = cat;

                objmysqlcommand.Parameters.Add("cat2", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["cat2"].Value = cat2;

                objmysqlcommand.Parameters.Add("cat3", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["cat3"].Value = cat3;

                objmysqlcommand.Parameters.Add("cat4", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["cat4"].Value = cat4;

                objmysqlcommand.Parameters.Add("cat5", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["cat5"].Value = cat5;

                objmysqlcommand.Parameters.Add("coltyp", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["coltyp"].Value = coltyp;

                objmysqlcommand.Parameters.Add("comcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["comcode"].Value = compcode;

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
        public DataSet bgexecute1(string bgid, string bgname, string bgalias,string compcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();       
            try
            {

                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("bg_exe_bg_exe_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;
                objmysqlcommand.Parameters.Add("vbgid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["vbgid"].Value = bgid;
                objmysqlcommand.Parameters.Add("vbgname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["vbgname"].Value = bgname;
                objmysqlcommand.Parameters.Add("vbgalias", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["vbgalias"].Value = bgalias;
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

        public DataSet bgfpnl()
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();       
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("BGFPNL_BGFPNL_p", ref objmysqlconnection);
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
        public DataSet bgdelete(string bgid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();       
           
            try
            {

                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("BG_DELETE_BG_DELETE_P", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;
                objmysqlcommand.Parameters.Add("bgid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["bgid"].Value = bgid;
                
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
    public DataSet bgdauto(string str, string pub, string edit, string cat, string coltype)
    {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();       
            
            try
            {


                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("bg_auto_bg_auto_p", ref objmysqlconnection);
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
                objmysqlcommand.Parameters.Add("pub1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pub1"].Value = pub;

                objmysqlcommand.Parameters.Add("edit", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["edit"].Value = edit;

                objmysqlcommand.Parameters.Add("cat1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["cat1"].Value = cat;

                objmysqlcommand.Parameters.Add("coltype", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["coltype"].Value = coltype;

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
//
    public DataSet addcategoryname2(string cat1, string compcode)
    {
        MySqlConnection objmysqlconnection;
        MySqlCommand objmysqlcommand;
        objmysqlconnection=GetConnection();
        MySqlDataAdapter objmysqlDataAdapter=new MySqlDataAdapter();
        DataSet objdataset=new DataSet();

        try
        {
        objmysqlconnection.Open();
        objmysqlcommand = GetCommand("advsubcategory_advsubcategory_p", ref objmysqlconnection);
        objmysqlcommand.CommandType=CommandType.StoredProcedure;

        objmysqlcommand.Parameters.Add("adcategory", MySqlDbType.VarChar);
        objmysqlcommand.Parameters["adcategory"].Value = cat1;

        objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
        objmysqlcommand.Parameters["compcode"].Value = compcode;

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
public DataSet addcategoryname3(string cat1)
{
    MySqlConnection objmysqlconnection;
    MySqlCommand objmysqlcommand;
    objmysqlconnection=GetConnection();
    MySqlDataAdapter objmysqlDataAdapter=new MySqlDataAdapter();
    DataSet objdataset=new DataSet();

    try
    {
    objmysqlconnection.Open();
    objmysqlcommand = GetCommand("advsubsubcategory_advsubsubcategory_p", ref objmysqlconnection);
    objmysqlcommand.CommandType=CommandType.StoredProcedure;

    objmysqlcommand.Parameters.Add("adsubcategory",MySqlDbType.VarChar);
    objmysqlcommand.Parameters["adsubcategory"].Value = cat1;

    objmysqlDataAdapter.SelectCommand=objmysqlcommand;
    objmysqlDataAdapter.Fill(objdataset);
    return objdataset;
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
 public DataSet bindscategory4(string adscat4, string value, string compcode)
        {
     MySqlConnection objmysqlconnection;
     MySqlCommand objmysqlcommand;
     objmysqlconnection=GetConnection();
     MySqlDataAdapter objmysqlDataAdapter=new MySqlDataAdapter();
     DataSet objdataset=new DataSet();

     try
     {
     objmysqlconnection.Open();
     objmysqlcommand = GetCommand("Rate_bindadcat4_Rate_bindadcat4_p", ref objmysqlconnection);
     objmysqlcommand.CommandType=CommandType.StoredProcedure;

     objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
     objmysqlcommand.Parameters["compcode"].Value = compcode;

     objmysqlcommand.Parameters.Add("adscat4", MySqlDbType.VarChar);
     objmysqlcommand.Parameters["adscat4"].Value = adscat4;

     objmysqlcommand.Parameters.Add("value1", MySqlDbType.VarChar);
     objmysqlcommand.Parameters["value1"].Value = value;

     objmysqlDataAdapter.SelectCommand=objmysqlcommand;
     objmysqlDataAdapter.Fill(objdataset);
     return objdataset;
     }
     catch(Exception ex)
     {
         throw (ex);
     }
     finally
     {
         CloseConnection(ref objmysqlconnection);
     }
 }
public DataSet bindscategory5(string adscat5, string value, string compcode)
        {
    MySqlConnection objmysqlconnection;
    MySqlCommand objmysqlcommand;
    objmysqlconnection=GetConnection();
    MySqlDataAdapter objmysqlDataAdapter=new MySqlDataAdapter();
    DataSet objdataset=new DataSet();

    try
    {
    objmysqlconnection.Open();
    objmysqlcommand = GetCommand("Rate_bindadcat4_Rate_bindadcat4_p", ref objmysqlconnection);
    objmysqlcommand.CommandType=CommandType.StoredProcedure;

    objmysqlcommand.Parameters.Add("compcode",MySqlDbType.VarChar);
    objmysqlcommand.Parameters["compcode"].Value=compcode;

    objmysqlcommand.Parameters.Add("adscat4",MySqlDbType.VarChar);
    objmysqlcommand.Parameters["adscat4"].Value=adscat5;

    objmysqlcommand.Parameters.Add("value1", MySqlDbType.VarChar);
    objmysqlcommand.Parameters["value1"].Value = value;

    objmysqlDataAdapter.SelectCommand=objmysqlcommand;
    objmysqlDataAdapter.Fill(objdataset);
    return objdataset;
    }
    catch(Exception ex)
    {
       throw (ex);
    }
    finally
    {
        CloseConnection(ref objmysqlconnection);
    }
}

        public DataSet bgexecute2(string bgid, string bgname, string bgalias)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();       
            try
            {

                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("BG_EXE1_BG_EXE1_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;
                objmysqlcommand.Parameters.Add("bgid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["bgid"].Value = bgid;
                objmysqlcommand.Parameters.Add("bgname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["bgname"].Value = bgname;
                objmysqlcommand.Parameters.Add("bgalias", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["bgalias"].Value = bgalias;

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

    public DataSet bindcolortyp(string compcode)
    {
        MySqlConnection con;
        MySqlCommand com;
        con = GetConnection();
        MySqlDataAdapter da = new MySqlDataAdapter();
        DataSet ds = new DataSet(); 
        try
        {
            con.Open();
            com = GetCommand("bindcolortype_bindcolortype_p", ref con);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.Add("compcode", MySqlDbType.VarChar);
            com.Parameters["compcode"].Value = compcode;

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




    }
  }  
    
  
        
        


