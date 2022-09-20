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
/// Summary description for RetainerMaster
/// </summary>
public class RetainerMaster:connection 
{
	public RetainerMaster()
	{
		//
		// TODO: Add constructor logic here
		//
	}
		public DataSet checkpopupdata(string compcode,string retcode,string userid2)
		{
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();  
			try
			{
                objmysqlconnection.Open();

                objmysqlcommand = GetCommand("checkpopup_checkpopup_p", ref objmysqlconnection);
				objmysqlcommand.CommandType = CommandType.StoredProcedure;
				objmysqlcommand.Parameters.Add("Comp_Code",MySqlDbType.VarChar);
				objmysqlcommand.Parameters["Comp_Code"].Value =compcode ;
				objmysqlcommand.Parameters.Add("Retain_Code",MySqlDbType.VarChar);
				objmysqlcommand.Parameters["Retain_Code"].Value = retcode;
				objmysqlcommand.Parameters.Add("userid",MySqlDbType.VarChar);
				objmysqlcommand.Parameters["userid"].Value = userid2;
                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
                
			}
			catch(MySqlException e)
			{
				throw(e);
			}
			finally
			{
				CloseConnection(ref objmysqlconnection);
			}
			
		}


    public DataSet addstatusname(string compcode)
    {
        MySqlConnection objmysqlconnection;
        MySqlCommand objmysqlcommand;
        objmysqlconnection = GetConnection();
        MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
        DataSet objDataSet = new DataSet();  
        try
        {
            objmysqlconnection.Open();
            objmysqlcommand = GetCommand("bind_status_bind_status_p", ref objmysqlconnection);
            objmysqlcommand.CommandType = CommandType.StoredProcedure;

            objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["compcode"].Value = compcode;

           objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
        }
        catch (MySqlException objException)
        {
            throw (objException);
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

    public DataSet filldatapay(string hiddencomcode, string hiddenuserid)
    {
        MySqlConnection objmysqlconnection;
        MySqlCommand objmysqlcommand;
        objmysqlconnection = GetConnection();
        MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
        DataSet objDataSet = new DataSet();  
        try
        {
            objmysqlconnection.Open();
            objmysqlcommand = GetCommand("retainer_payfill", ref objmysqlconnection);
            objmysqlcommand.CommandType = CommandType.StoredProcedure;

            objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["userid"].Value = hiddenuserid;

            objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["compcode"].Value = hiddencomcode;



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

				
		//check if the user is already present or not 
		public DataSet checkRetaineruser(string retcode,string userid,string compcode)
		{
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
			try
			{
                objmysqlcommand = GetCommand("checkretainerdata_checkretainerdata_p", ref objmysqlconnection);
				objmysqlcommand.CommandType = CommandType.StoredProcedure;
				objmysqlcommand.Parameters.Add("Comp_Code",MySqlDbType.VarChar);
				objmysqlcommand.Parameters["Comp_Code"].Value =compcode ;
				objmysqlcommand.Parameters.Add("Retain_Code",MySqlDbType.VarChar);
				objmysqlcommand.Parameters["Retain_Code"].Value = retcode;
				objmysqlcommand.Parameters.Add("userid",MySqlDbType.VarChar);
				objmysqlcommand.Parameters["userid"].Value = userid;
			
				 objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
			}
			catch(MySqlException e)
			{
				throw(e);
			}
			finally
			{
				CloseConnection(ref objmysqlconnection);
			}
			
		}



		//Save the data to the retainer master
    public DataSet RetainerStore(string compcode, string retcode, string retname, string retalias, string add1, string street, string citycode, string pubcent, string zip, string dist, string state, string zone, string region, string country, string phone1, string phone2, string fax, string email, string pan, string creditdays, string remarks, string userid, int flag, string Box, string publication, string edition, string supplement, string taluka, string repname, string branchcode,string mobile)
    {
		
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
			
			try
			{
				objmysqlconnection.Open();
                objmysqlcommand = GetCommand("RetainerInsertDetail_RetainerInsertDetail_p", ref objmysqlconnection);
				objmysqlcommand.CommandType = CommandType.StoredProcedure;


                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("retcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["retcode"].Value = retcode;

                objmysqlcommand.Parameters.Add("retname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["retname"].Value = retname;

                objmysqlcommand.Parameters.Add("retalias", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["retalias"].Value = retalias;

                objmysqlcommand.Parameters.Add("repname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["repname"].Value = repname;

                objmysqlcommand.Parameters.Add("add1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["add1"].Value = add1;

                objmysqlcommand.Parameters.Add("street1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["street1"].Value = street;

                objmysqlcommand.Parameters.Add("citycode1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["citycode1"].Value = citycode;


                objmysqlcommand.Parameters.Add("pubcent1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pubcent1"].Value = pubcent;





                objmysqlcommand.Parameters.Add("Zip1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Zip1"].Value = zip;

                objmysqlcommand.Parameters.Add("dist", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["dist"].Value = dist;

                objmysqlcommand.Parameters.Add("state", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["state"].Value = state;

                objmysqlcommand.Parameters.Add("zone", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["zone"].Value = zone;

                objmysqlcommand.Parameters.Add("region", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["region"].Value = region;

                objmysqlcommand.Parameters.Add("country", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["country"].Value = country;

                objmysqlcommand.Parameters.Add("phone11", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["phone11"].Value = phone1;

                objmysqlcommand.Parameters.Add("Phone21", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Phone21"].Value = phone2;

                objmysqlcommand.Parameters.Add("Fax1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Fax1"].Value = fax;

                objmysqlcommand.Parameters.Add("email", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["email"].Value = email;

                objmysqlcommand.Parameters.Add("PAN_No1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["PAN_No1"].Value = pan;

                objmysqlcommand.Parameters.Add("creditdays", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["creditdays"].Value = creditdays;

                objmysqlcommand.Parameters.Add("Remarks1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Remarks1"].Value = remarks;

                objmysqlcommand.Parameters.Add("userid1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid1"].Value = userid;

                objmysqlcommand.Parameters.Add("flag", MySqlDbType.Int24);
                objmysqlcommand.Parameters["flag"].Value = flag;

                objmysqlcommand.Parameters.Add("Box1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Box1"].Value = Box;

                objmysqlcommand.Parameters.Add("Publication11", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Publication11"].Value = publication;

                objmysqlcommand.Parameters.Add("Edition11", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Edition11"].Value = edition;

                objmysqlcommand.Parameters.Add("Supplement11", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Supplement11"].Value = supplement;

                objmysqlcommand.Parameters.Add("taluka1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["taluka1"].Value = taluka;

                objmysqlcommand.Parameters.Add("branchcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["branchcode"].Value = branchcode;

                objmysqlcommand.Parameters.Add("mobile1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["mobile1"].Value = branchcode;

           objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
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

    public DataSet retstatuscheck(string compcode, string userid, string retcode, string status, string circular, string todate, string fromdate, string dateformat, string codepass)
    {
        MySqlConnection objmysqlconnection;
        MySqlCommand objmysqlcommand;
        objmysqlconnection = GetConnection();
        MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
        DataSet objDataSet = new DataSet(); 
        try
        {
            objmysqlconnection.Open();
            objmysqlcommand = GetCommand("retstatuschk_retstatuschk_P", ref objmysqlconnection);
            objmysqlcommand.CommandType = CommandType.StoredProcedure;

            objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["compcode"].Value = compcode;

            objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["userid"].Value = userid;

            objmysqlcommand.Parameters.Add("retcode", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["retcode"].Value = retcode;

            objmysqlcommand.Parameters.Add("status1", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["status1"].Value = status;

            objmysqlcommand.Parameters.Add("circular", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["circular"].Value = circular;

            //objmysqlcommand.Parameters.Add("todate", MySqlDbType.DateTime);
            //if (todate == "" || todate == null)//|| validtill == "undefined/undefined/")
            //{
            //    objmysqlcommand.Parameters["todate"].Value = System.DBNull.Value;
            //}
            //else
            //{
            //    objmysqlcommand.Parameters["todate"].Value = Convert.ToDateTime(todate);
            //    // com.Parameters["validtill"].Value = Convert.ToDateTime(validtill);
            //}


            //objmysqlcommand.Parameters.Add("fromdate", MySqlDbType.DateTime);
            //if (fromdate == "" || fromdate == null)//|| validtill == "undefined/undefined/")
            //{
            //    objmysqlcommand.Parameters["fromdate"].Value = System.DBNull.Value;
            //}
            //else
            //{
            //    objmysqlcommand.Parameters["fromdate"].Value = Convert.ToDateTime(fromdate);
            //}

            objmysqlcommand.Parameters.Add("fromdate", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["fromdate"].Value = fromdate;

            objmysqlcommand.Parameters.Add("todate", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["todate"].Value = todate;

            objmysqlcommand.Parameters.Add("date1", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["date1"].Value = dateformat;

            objmysqlcommand.Parameters.Add("codepass", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["codepass"].Value = codepass;

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

    public void insertData(string compcode, string retcode, string userid, int i, string strMode)
    {
        MySqlConnection objmysqlconnection;
        MySqlCommand objmysqlcommand;
        objmysqlconnection = GetConnection();
        MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
        DataSet objDataSet = new DataSet();   
        try
        {
            objmysqlconnection.Open();
           objmysqlcommand = GetCommand("updateRetPay", ref objmysqlconnection);
           objmysqlcommand.CommandType = CommandType.StoredProcedure;

           objmysqlcommand.Parameters.Add("Cash", MySqlDbType.VarChar);
           objmysqlcommand.Parameters["Cash"].Value = strMode;
            //sqlcomm.Parameters.Add("Credit", MySqlDbType.VarChar);
            //sqlcomm.Parameters["Credit"].Value = strMode[1];
            //sqlcomm.Parameters.Add("Bank", MySqlDbType.VarChar);
            //sqlcomm.Parameters["Bank"].Value = strMode[2];
           objmysqlcommand.Parameters.Add("Comp_Code", MySqlDbType.VarChar);
           objmysqlcommand.Parameters["Comp_Code"].Value = compcode;
           objmysqlcommand.Parameters.Add("retcode", MySqlDbType.VarChar);
           objmysqlcommand.Parameters["retcode"].Value = retcode;
           objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
           objmysqlcommand.Parameters["userid"].Value = userid;
           objmysqlcommand.Parameters.Add("Flag", MySqlDbType.VarChar);
           objmysqlcommand.Parameters["Flag"].Value = i;


            objmysqlDataAdapter.SelectCommand = objmysqlcommand;
            objmysqlDataAdapter.Fill(objDataSet);
           
        }
        catch (Exception ex) { throw (ex); }
        finally
        { CloseConnection(ref objmysqlconnection); }
    }

    public DataSet selectretstatus(string retcode, string compcode, string userid, string code11, string dateformat)
    {
        MySqlConnection objmysqlconnection;
        MySqlCommand objmysqlcommand;
        objmysqlconnection = GetConnection();
        MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
        DataSet objDataSet = new DataSet(); 
        try
        {
            objmysqlconnection.Open();
            objmysqlcommand = GetCommand("retselect_retselect_p", ref objmysqlconnection);
            objmysqlcommand.CommandType = CommandType.StoredProcedure;

            objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["compcode"].Value = compcode;

            objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["userid"].Value = userid;

            objmysqlcommand.Parameters.Add("retcode", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["retcode"].Value = retcode;


            objmysqlcommand.Parameters.Add("code11", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["code11"].Value = code11;


            objmysqlcommand.Parameters.Add("dateformat", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["dateformat"].Value = dateformat;



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

    public DataSet selectretcomm(string retcode, string compcode, string userid, string code11, string dateformat)
    {
        MySqlConnection objmysqlconnection;
        MySqlCommand objmysqlcommand;
        objmysqlconnection = GetConnection();
        MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
        DataSet objDataSet = new DataSet();  
        try
        {
            objmysqlconnection.Open();
           objmysqlcommand =GetCommand("retcommselect", ref objmysqlconnection);
            objmysqlcommand.CommandType = CommandType.StoredProcedure;

            objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["compcode"].Value = compcode;

            objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["userid"].Value = userid;

            objmysqlcommand.Parameters.Add("retcode", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["retcode"].Value = retcode;


            objmysqlcommand.Parameters.Add("code11", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["code11"].Value = code11;


            objmysqlcommand.Parameters.Add("dateformat", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["dateformat"].Value = dateformat;


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


    public DataSet retainerstatusbind(string retcode, string userid, string compcode, string dateformat)
    {
        MySqlConnection objmysqlconnection;
        MySqlCommand objmysqlcommand;
        objmysqlconnection = GetConnection();
        MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
        DataSet objDataSet = new DataSet();  
        try
        {
            objmysqlconnection.Open();
            objmysqlcommand = GetCommand("sp_retstatusbind_sp_retstatusbind_p", ref objmysqlconnection);
            objmysqlcommand.CommandType = CommandType.StoredProcedure;


            objmysqlcommand.Parameters.Add("retcode", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["retcode"].Value = retcode;


            objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["userid"].Value = userid;

            objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["compcode"].Value = compcode;


            objmysqlcommand.Parameters.Add("date1", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["date1"].Value = dateformat;




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
    public DataSet retstatuscheck1(string compcode, string retcode, string todate, string fromdate, string dateformat, string codepass)
    {
        MySqlConnection objmysqlconnection;
        MySqlCommand objmysqlcommand;
        objmysqlconnection = GetConnection();
        MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
        DataSet objDataSet = new DataSet();

        try
        {
            objmysqlconnection.Open();
            objmysqlcommand = GetCommand("retcomchk", ref objmysqlconnection);
            objmysqlcommand.CommandType = CommandType.StoredProcedure;

            objmysqlcommand.Parameters.Add("v_compcode", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["v_compcode"].Value = compcode;

            objmysqlcommand.Parameters.Add("retcode", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["retcode"].Value = retcode;

            objmysqlcommand.Parameters.Add("todate", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["todate"].Value = todate;

            objmysqlcommand.Parameters.Add("fromdate", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["fromdate"].Value = fromdate;

            objmysqlcommand.Parameters.Add("date_format1", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["date_format1"].Value = dateformat;

            objmysqlcommand.Parameters.Add("codepass", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["codepass"].Value = codepass;

            objmysqlDataAdapter.SelectCommand = objmysqlcommand;
            objmysqlDataAdapter.Fill(objDataSet);
            return objDataSet;
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
		public DataSet RetDelete(string compcode,string Retcode)
		{
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
			
			try
			{
				objmysqlconnection.Open();
                objmysqlcommand = GetCommand("RetainerDelete_RetainerDelete_p", ref objmysqlconnection);
				objmysqlcommand.CommandType = CommandType.StoredProcedure;

				objmysqlcommand.Parameters.Add("Comp_Code",MySqlDbType.VarChar);
				objmysqlcommand.Parameters["Comp_Code"].Value =compcode ;
				
				objmysqlcommand.Parameters.Add("Retain_Code",MySqlDbType.VarChar);
				objmysqlcommand.Parameters["Retain_Code"].Value = Retcode;
				
				/*objmysqlcommand.Parameters.Add("userid",MySqlDbType.VarChar);
				objmysqlcommand.Parameters["userid"].Value = userid;*/

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
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

    public DataSet RetainerExecute(string compcode, string Retcode, string Retname, string alias, string city, string pubcent, string country, string Box, string repname, string branchname)
    {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
			try
			{
				objmysqlconnection.Open();
				
                //saurabh added
                
                //objmysqlcommand = GetCommand("RetainerExecute",ref objmysqlconnection);

                objmysqlcommand = GetCommand("RetainerExec_RetainerExec_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;
				
				objmysqlcommand.Parameters.Add("compcode",MySqlDbType.VarChar);
				objmysqlcommand.Parameters["compcode"].Value =compcode ;
                //objmysqlcommand.Parameters.Add("userid",MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["userid"].Value = userid;
				
				objmysqlcommand.Parameters.Add("Retain_Code",MySqlDbType.VarChar);
				if(Retcode==null || Retcode=="")
				{
					objmysqlcommand.Parameters["Retain_Code"].Value = "";
				}
				else
				{
					objmysqlcommand.Parameters["Retain_Code"].Value = Retcode;
				}
				
				objmysqlcommand.Parameters.Add("retname",MySqlDbType.VarChar);
				if(Retname==null|Retname=="")
				{
					objmysqlcommand.Parameters["retname"].Value = "";
				}
				else
				{
					objmysqlcommand.Parameters["retname"].Value = Retname;
				}
				
				objmysqlcommand.Parameters.Add("retalias",MySqlDbType.VarChar);
				if(alias==null||alias=="")
				{
					objmysqlcommand.Parameters["retalias"].Value = "";
				}
				else
				{
					objmysqlcommand.Parameters["retalias"].Value = alias;
				}

				
				objmysqlcommand.Parameters.Add("citycode",MySqlDbType.VarChar);
				if(city==null||city==""||city=="0")
				{
					objmysqlcommand.Parameters["citycode"].Value = "0";
				}
				else
				{
					objmysqlcommand.Parameters["citycode"].Value = city;
				}



                objmysqlcommand.Parameters.Add("pubcent", MySqlDbType.VarChar);
                if (pubcent == null || pubcent == ""|| pubcent == "0")
                {
                    objmysqlcommand.Parameters["pubcent"].Value = "0";
                }
                else
                {
                    objmysqlcommand.Parameters["pubcent"].Value = pubcent;
                }

                objmysqlcommand.Parameters.Add("country", MySqlDbType.VarChar);
                if (country == null || country=="" || country == "0")
                {
                    objmysqlcommand.Parameters["country"].Value = "0";
                }
                else
                {
                    objmysqlcommand.Parameters["country"].Value = country;
                }

                objmysqlcommand.Parameters.Add("box_matter", MySqlDbType.VarChar);
                if (Box == null || Box == "" || Box == "0")
                {
                    objmysqlcommand.Parameters["box_matter"].Value = "0";
                }
                else
                {
                    objmysqlcommand.Parameters["box_matter"].Value = Box;
                }


                objmysqlcommand.Parameters.Add("branchname", MySqlDbType.VarChar);
                if (branchname == null || branchname == "" || branchname == "0")
                {
                    objmysqlcommand.Parameters["branchname"].Value = "0";
                }
                else
                {
                    objmysqlcommand.Parameters["branchname"].Value = branchname;
                }


                objmysqlcommand.Parameters.Add("repname", MySqlDbType.VarChar);
                if (repname == null | repname == "")
                {
                    objmysqlcommand.Parameters["repname"].Value = "";
                }
                else
                {
                    objmysqlcommand.Parameters["repname"].Value = repname;
                }
               

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
			}
			catch(MySqlException e)
			{
				throw(e);
			}
			finally
			{
				CloseConnection(ref objmysqlconnection);
			}
			
		}

		
		public DataSet RetainerNavigate(string compcode,string userid)
		{
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();  
			try
			{
				objmysqlconnection.Open();
                objmysqlcommand = GetCommand("RetNavigate_RetNavigate_p", ref objmysqlconnection);
				objmysqlcommand.CommandType = CommandType.StoredProcedure;
				
				objmysqlcommand.Parameters.Add("compcode",MySqlDbType.VarChar);
				objmysqlcommand.Parameters["compcode"].Value =compcode ;
				objmysqlcommand.Parameters.Add("userid",MySqlDbType.VarChar);
				objmysqlcommand.Parameters["userid"].Value = userid;


                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
			}
			catch(MySqlException e)
			{
				throw(e);
			}
			finally
			{
				CloseConnection(ref objmysqlconnection);
			}
			
		}
		
		//first,next,last previous 

		public DataSet getRecords(string compcode,string Retcode,string userid2)
		{
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
			try
			{
				objmysqlconnection.Open();
				objmysqlcommand = GetCommand("Retpayselect",ref objmysqlconnection);
				objmysqlcommand.CommandType = CommandType.StoredProcedure;
				objmysqlcommand.Parameters.Add("Retcode",MySqlDbType.VarChar);
				objmysqlcommand.Parameters["Retcode"].Value = Retcode ;
				objmysqlcommand.Parameters.Add("userid",MySqlDbType.VarChar);
				objmysqlcommand.Parameters["userid"].Value = userid2;
				objmysqlcommand.Parameters.Add("compcode",MySqlDbType.VarChar);
				objmysqlcommand.Parameters["compcode"].Value = compcode ;

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



		/*Retainer Master Coding Ends*/

		/*===================================================================*/

		/*Pop up coding Starts*/

		/*Pop Up Paymode*/
		//GetData is used to retrieve the custcode from customer master
		public DataSet getData(string retcode,string userid,string compcode)
		{
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
			try
			{
				objmysqlconnection.Open();
				objmysqlcommand = GetCommand("Retpayselect",ref objmysqlconnection);
				objmysqlcommand.CommandType = CommandType.StoredProcedure;
				objmysqlcommand.Parameters.Add("Retcode",MySqlDbType.VarChar);
				objmysqlcommand.Parameters["Retcode"].Value = retcode ;
				objmysqlcommand.Parameters.Add("userid",MySqlDbType.VarChar);
				objmysqlcommand.Parameters["userid"].Value = userid ;
				objmysqlcommand.Parameters.Add("compcode",MySqlDbType.VarChar);
				objmysqlcommand.Parameters["compcode"].Value = compcode ;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet; ;
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



		//insert Data is used to insert/update values into temporary retainer payment table
//		public DataSet insertRetData(string  compcode,string retcode,string  userid,int i, params string[] strMode)
    //public void insertRetData(string compcode, string retcode, string userid, int i, string strMode)
    //    {
    //        MySqlConnection objmysqlconnection;
    //        MySqlCommand objmysqlcommand;
    //        objmysqlconnection = GetConnection();
    //        MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
    //        DataSet objDataSet = new DataSet();  
			
    //        try
    //        {
    //            objmysqlconnection.Open();
    //            objmysqlcommand = GetCommand("updateRetPayment",ref objmysqlconnection);
    //            objmysqlcommand.CommandType = CommandType.StoredProcedure;
				
    //            objmysqlcommand.Parameters.Add("Cash",MySqlDbType.VarChar);
    //            objmysqlcommand.Parameters["Cash"].Value = strMode;

    //            //objmysqlcommand.Parameters["Cash"].Value = strMode[0];
    //            //objmysqlcommand.Parameters.Add("Credit", MySqlDbType.VarChar);
    //            //objmysqlcommand.Parameters["Credit"].Value = strMode[1];
    //            //objmysqlcommand.Parameters.Add("Bank", MySqlDbType.VarChar);
    //            //objmysqlcommand.Parameters["Bank"].Value = strMode[2];

    //            objmysqlcommand.Parameters.Add("Comp_Code",MySqlDbType.VarChar);
    //            objmysqlcommand.Parameters["Comp_Code"].Value = compcode;
    //            objmysqlcommand.Parameters.Add("Retain_Code",MySqlDbType.VarChar);
    //            objmysqlcommand.Parameters["Retain_Code"].Value = retcode;
    //            objmysqlcommand.Parameters.Add("userid",MySqlDbType.VarChar);
    //            objmysqlcommand.Parameters["userid"].Value = userid;
    //            objmysqlcommand.Parameters.Add("Flag",MySqlDbType.Int);
    //            objmysqlcommand.Parameters["flag"].Value = i;


    //            objmysqlDataAdapter.SelectCommand = objmysqlcommand;
    //            objmysqlDataAdapter.Fill(objDataSet);
              
					
    //        }
    //        catch(Exception ex)
    //        {
    //            throw(ex);
    //        }
    //        finally
    //        {
    //            CloseConnection(ref objmysqlconnection);
    //        }
    //     }


		/*Paymode coding ends*/
		

		/*Commmission coding starts*/

		//DropDown Binding

		public DataSet commission()
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();   
			try
			{
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("websp_comm_detail", ref objmysqlconnection);
				objmysqlcommand.CommandType = CommandType.StoredProcedure;


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
		
    public DataSet addedition(string pubname)
    {
        MySqlConnection objmysqlconnection;
        MySqlCommand objmysqlcommand;
        objmysqlconnection = GetConnection();
        MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objmysqlconnection.Open();
            objmysqlcommand = GetCommand("fill_editionalias_fill_editionalias_p", ref objmysqlconnection);
            objmysqlcommand.CommandType = CommandType.StoredProcedure;

            objmysqlcommand.Parameters.Add("pubname", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["pubname"].Value = pubname;

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
    public DataSet countedition(string editioncode)
    {
        MySqlConnection objmysqlconnection;
        MySqlCommand objmysqlcommand;
        objmysqlconnection = GetConnection();
        MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objmysqlconnection.Open();
            objmysqlcommand = GetCommand("getsupplement_getsupplement_p", ref objmysqlconnection);
            objmysqlcommand.CommandType = CommandType.StoredProcedure;

            objmysqlcommand.Parameters.Add("editioncode", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["editioncode"].Value = editioncode;

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
    public DataSet addrepname(string compcode)
    {
        MySqlConnection objmysqlconnection;
        MySqlCommand objmysqlcommand;
        objmysqlconnection = GetConnection();
        MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
        DataSet objdataset=new DataSet();

        try
        {
            objmysqlconnection.Open();
            objmysqlcommand = GetCommand("getrepname", ref objmysqlconnection);
            objmysqlcommand.CommandType = CommandType.StoredProcedure;

            objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["compcode"].Value = compcode;

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
    public DataSet retcomcheck(string compcode, string retcode, string todate, string fromdate, string dateformat, string codepass)
    {
        MySqlConnection objmysqlconnection;
        MySqlCommand objmysqlcommand;
        objmysqlconnection = GetConnection();
        MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
        DataSet objdataset=new DataSet();

        try
        {
        objmysqlconnection.Open();
        objmysqlcommand=GetCommand("retcomchk",ref objmysqlconnection);

        objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
        objmysqlcommand.Parameters["compcode"].Value = compcode;

        objmysqlcommand.Parameters.Add("retcode", MySqlDbType.VarChar);
        objmysqlcommand.Parameters["retcode"].Value = retcode;

        objmysqlcommand.Parameters.Add("fromdate", MySqlDbType.VarChar);
        objmysqlcommand.Parameters["fromdate"].Value = fromdate;

        objmysqlcommand.Parameters.Add("todate", MySqlDbType.VarChar);
        objmysqlcommand.Parameters["todate"].Value = todate;

        objmysqlcommand.Parameters.Add("date", MySqlDbType.VarChar);
        objmysqlcommand.Parameters["date"].Value = dateformat;

        objmysqlcommand.Parameters.Add("codepass", MySqlDbType.VarChar);
        objmysqlcommand.Parameters["codepass"].Value = codepass;
        
        objmysqlDataAdapter.SelectCommand = objmysqlcommand;
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
          
		//Datagrid Binding

		public DataSet RetainerCommBind(string retcode,string compcode, string userid,string dateformat)
		{
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
			try
			{
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("RetainerCommBind_RetainerCommBind_p", ref objmysqlconnection);
				objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("comp_code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["comp_code"].Value = compcode;
				objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["userid"].Value =userid;
				objmysqlcommand.Parameters.Add("Retain_Code", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["Retain_Code"].Value =retcode;
				objmysqlcommand.Parameters.Add("dateformat", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["dateformat"].Value =dateformat;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
			}
			catch(MySqlException objException)
			{
				throw(objException);
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


		//Commission date Check 
		public DataSet checkdate(string retcode,string userid,string compcode,string txtefffrom,string txtefftill)
		{
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();  
			try
			{
				objmysqlconnection.Open();
				objmysqlcommand = GetCommand("chkcommdate",ref objmysqlconnection);
				objmysqlcommand.CommandType = CommandType.StoredProcedure;
				
				objmysqlcommand.Parameters.Add("retcode",MySqlDbType.VarChar);
				objmysqlcommand.Parameters["retcode"].Value = retcode;
				objmysqlcommand.Parameters.Add("userid",MySqlDbType.VarChar);
				objmysqlcommand.Parameters["userid"].Value = userid;
				objmysqlcommand.Parameters.Add("compcode",MySqlDbType.VarChar);
				objmysqlcommand.Parameters["compcode"].Value = compcode;
				objmysqlcommand.Parameters.Add("fromdate",MySqlDbType.VarChar);
				objmysqlcommand.Parameters["fromdate"].Value = txtefffrom;
				objmysqlcommand.Parameters.Add("tilldate",MySqlDbType.VarChar);
				objmysqlcommand.Parameters["tilldate"].Value = txtefftill;


                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
				
			}
			catch(Exception ex)	{throw(ex);}
			finally
			{CloseConnection(ref objmysqlconnection);}
		}

//comm date update
		public DataSet checkdateupdate(string retcode,string userid,string compcode,string txtefffrom,string txtefftill,string code)
		{
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();   
			try
			{
				objmysqlconnection.Open();
				objmysqlcommand = GetCommand("chkcommdateupdate",ref objmysqlconnection);
				objmysqlcommand.CommandType = CommandType.StoredProcedure;
				
				objmysqlcommand.Parameters.Add("retcode",MySqlDbType.VarChar);
				objmysqlcommand.Parameters["retcode"].Value = retcode;
				objmysqlcommand.Parameters.Add("userid",MySqlDbType.VarChar);
				objmysqlcommand.Parameters["userid"].Value = userid;
				objmysqlcommand.Parameters.Add("compcode",MySqlDbType.VarChar);
				objmysqlcommand.Parameters["compcode"].Value = compcode;
				objmysqlcommand.Parameters.Add("fromdate",MySqlDbType.VarChar);
				objmysqlcommand.Parameters["fromdate"].Value = txtefffrom;
				objmysqlcommand.Parameters.Add("tilldate",MySqlDbType.VarChar);
				objmysqlcommand.Parameters["tilldate"].Value = txtefftill;
				objmysqlcommand.Parameters.Add("code",MySqlDbType.VarChar);
				objmysqlcommand.Parameters["code"].Value = code;


                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
				
			}
			catch(Exception ex)	{throw(ex);}
			finally
			{CloseConnection(ref objmysqlconnection);}
		}

		//Commission Data insert/Update
    public DataSet RetainerCommission(string retcode, string userid, string compcode, string txtefffrom, string txtefftill, string txtcommrate, string discount, string updatecommission, int flag, string frmamt, string toamt, string addcommrate)
    {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
			try
			{
				objmysqlconnection.Open();
				objmysqlcommand = GetCommand("RetainerCommission",ref objmysqlconnection);
				objmysqlcommand.CommandType = CommandType.StoredProcedure;
				
				objmysqlcommand.Parameters.Add("Retain_Code",MySqlDbType.VarChar);
				objmysqlcommand.Parameters["Retain_Code"].Value = retcode;

				objmysqlcommand.Parameters.Add("userid",MySqlDbType.VarChar);
				objmysqlcommand.Parameters["userid"].Value = userid;

				objmysqlcommand.Parameters.Add("compcode",MySqlDbType.VarChar);
				objmysqlcommand.Parameters["compcode"].Value = compcode;

				objmysqlcommand.Parameters.Add("effectivefrm",MySqlDbType.VarChar);
                if (txtefffrom == "" || txtefffrom == null)
                {
                    objmysqlcommand.Parameters["barterstdt"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["effectivefrm"].Value = Convert.ToDateTime(txtefffrom).ToString("yyyy-MM-dd");
                }
				objmysqlcommand.Parameters.Add("efftill",MySqlDbType.VarChar);
                if (txtefftill == "" || txtefftill == null)
                {
                    objmysqlcommand.Parameters["txtefftill"].Value = System.DBNull.Value;
                }
                else
                {
                    objmysqlcommand.Parameters["efftill"].Value = Convert.ToDateTime(txtefftill).ToString("yyyy-MM-dd");
                }
			

				objmysqlcommand.Parameters.Add("commrate",MySqlDbType.VarChar);
				objmysqlcommand.Parameters["commrate"].Value = txtcommrate;

				objmysqlcommand.Parameters.Add("discount",MySqlDbType.VarChar);
				objmysqlcommand.Parameters["discount"].Value = discount;

				objmysqlcommand.Parameters.Add("codeid",MySqlDbType.VarChar);
				objmysqlcommand.Parameters["codeid"].Value = updatecommission;

				objmysqlcommand.Parameters.Add("flag",MySqlDbType.Int24);
				objmysqlcommand.Parameters["flag"].Value = flag;

                objmysqlcommand.Parameters.Add("frmamt", MySqlDbType.VarChar);
                if (frmamt == "")
                    objmysqlcommand.Parameters["frmamt"].Value = System.DBNull.Value;
                else
                    objmysqlcommand.Parameters["frmamt"].Value = frmamt;

                objmysqlcommand.Parameters.Add("toamt", MySqlDbType.VarChar);
                if (toamt == "")
                    objmysqlcommand.Parameters["toamt"].Value = System.DBNull.Value;
                else
                    objmysqlcommand.Parameters["toamt"].Value = toamt;

                objmysqlcommand.Parameters.Add("addcommrate", MySqlDbType.VarChar);
                if (addcommrate == "")
                    objmysqlcommand.Parameters["addcommrate"].Value = System.DBNull.Value;
                else
                    objmysqlcommand.Parameters["addcommrate"].Value = addcommrate;


                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
				
			}
			catch(Exception ex)	{throw(ex);}
			finally
			{CloseConnection(ref objmysqlconnection);}
		
		}

		//Get the values with respect to dates 
		public DataSet getCommData(string compcode,string userid,string retcode,string codeid,int flag)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();  
			try
			{
				objmysqlconnection.Open();
				objmysqlcommand = GetCommand("GetRetComm",ref objmysqlconnection);
				objmysqlcommand.CommandType = CommandType.StoredProcedure;
				
				objmysqlcommand.Parameters.Add("retcode",MySqlDbType.VarChar);
				objmysqlcommand.Parameters["retcode"].Value = retcode;
				objmysqlcommand.Parameters.Add("userid",MySqlDbType.VarChar);
				objmysqlcommand.Parameters["userid"].Value = userid;
				objmysqlcommand.Parameters.Add("compcode",MySqlDbType.VarChar);
				objmysqlcommand.Parameters["compcode"].Value = compcode;
				objmysqlcommand.Parameters.Add("codeid",MySqlDbType.VarChar);
				objmysqlcommand.Parameters["codeid"].Value = codeid;
				objmysqlcommand.Parameters.Add("flag",MySqlDbType.Int24);
				objmysqlcommand.Parameters["flag"].Value = flag;


                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
				
			}
			catch(Exception ex)	{throw(ex);}
			finally
			{CloseConnection(ref objmysqlconnection);}
		}

		/*Commmission coding ends*/


		/*Retainer Status Detail coding starts  */

		/*Bind the data to the datagrid during page load 
		 * & also to check the date whether the date is present or not*/
		public DataSet Ret_GetStatus(string retcode,string compcode, string userid,string date,string fromdate,string todate,string codestatusid,int flag)
		{
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet(); 
			try
			{
				objmysqlconnection.Open();
                objmysqlcommand = GetCommand("Ret_GetStatus_Ret_GetStatus_p", ref objmysqlconnection);
				objmysqlcommand.CommandType = CommandType.StoredProcedure;
				
				objmysqlcommand.Parameters.Add("Retain_Code",MySqlDbType.VarChar);
				objmysqlcommand.Parameters["Retain_Code"].Value = retcode;
				objmysqlcommand.Parameters.Add("userid",MySqlDbType.VarChar);
				objmysqlcommand.Parameters["userid"].Value = userid;
				objmysqlcommand.Parameters.Add("compcode",MySqlDbType.VarChar);
				objmysqlcommand.Parameters["compcode"].Value = compcode;
				objmysqlcommand.Parameters.Add("date",MySqlDbType.VarChar);
				objmysqlcommand.Parameters["date"].Value = date;
				objmysqlcommand.Parameters.Add("txtfrom",MySqlDbType.VarChar);
				if(fromdate==""||fromdate==null)
				{
					objmysqlcommand.Parameters["txtfrom"].Value = fromdate;
				}
				else
				{
					objmysqlcommand.Parameters["txtfrom"].Value = Convert.ToDateTime(fromdate);
				}
				
				objmysqlcommand.Parameters.Add("txtto",MySqlDbType.VarChar);
				if(fromdate==""||fromdate==null)
				{
					objmysqlcommand.Parameters["txtto"].Value = todate;
				}
				else
				{
					objmysqlcommand.Parameters["txtto"].Value = Convert.ToDateTime(todate);
				}
				
				objmysqlcommand.Parameters.Add("codestatusid",MySqlDbType.VarChar);
				objmysqlcommand.Parameters["codestatusid"].Value = codestatusid;
				objmysqlcommand.Parameters.Add("flag",MySqlDbType.VarChar);
				objmysqlcommand.Parameters["flag"].Value = flag;


                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
				
			}
			catch(Exception ex)	{throw(ex);}
			finally
			{CloseConnection(ref objmysqlconnection);}
		}

		public DataSet Ret_GetStatusupdate(string retcode,string compcode, string userid,string status, string circular, string todate,string fromdate,string code)
		{
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();   
			try
			{
				objmysqlconnection.Open();
                objmysqlcommand = GetCommand("Ret_GetStatusupdate_Ret_GetStatusupdate_p", ref objmysqlconnection);
				objmysqlcommand.CommandType = CommandType.StoredProcedure;
				
				objmysqlcommand.Parameters.Add("retcode",MySqlDbType.VarChar);
                objmysqlcommand.Parameters["retcode"].Value = retcode;

				objmysqlcommand.Parameters.Add("userid",MySqlDbType.VarChar);
				objmysqlcommand.Parameters["userid"].Value = userid;

				objmysqlcommand.Parameters.Add("compcode",MySqlDbType.VarChar);
				objmysqlcommand.Parameters["compcode"].Value = compcode;

                //objmysqlcommand.Parameters.Add("date",MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["date"].Value = date;

                objmysqlcommand.Parameters.Add("status1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["status1"].Value = status;

                objmysqlcommand.Parameters.Add("circular", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["circular"].Value = circular;


                objmysqlcommand.Parameters.Add("fromdate", MySqlDbType.VarChar);
				if(fromdate==""||fromdate==null)
				{
                    objmysqlcommand.Parameters["fromdate"].Value = System.DBNull.Value;
				}
				else
				{
                    objmysqlcommand.Parameters["fromdate"].Value = Convert.ToDateTime(fromdate).ToString("yyyy-MM-dd");
				}

                objmysqlcommand.Parameters.Add("todate", MySqlDbType.VarChar);
                if (todate == "" || todate == null)
				{
                    objmysqlcommand.Parameters["todate"].Value = System.DBNull.Value;
				}
				else
				{
                    objmysqlcommand.Parameters["todate"].Value = Convert.ToDateTime(todate).ToString("yyyy-MM-dd");
				}
				
				objmysqlcommand.Parameters.Add("code1",MySqlDbType.VarChar);
				objmysqlcommand.Parameters["code1"].Value = code;



                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
				
			}
			catch(Exception ex)	{throw(ex);}
			finally
			{CloseConnection(ref objmysqlconnection);}
		}

		/*Insert ,Update & Delete operation */
		public DataSet Ret_StatusOperation(string userid,string compcode,string retcode,string statusname ,string fromdate,string todate,string circular,string codeid,int flag)
		{
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();   
			try
			{
				objmysqlconnection.Open();
                objmysqlcommand = GetCommand("RetStatusUpdate_RetStatusUpdate_p", ref objmysqlconnection);
				objmysqlcommand.CommandType = CommandType.StoredProcedure;
				
				objmysqlcommand.Parameters.Add("Retain_Code",MySqlDbType.VarChar);
				objmysqlcommand.Parameters["Retain_Code"].Value = retcode;
				objmysqlcommand.Parameters.Add("userid",MySqlDbType.VarChar);
				objmysqlcommand.Parameters["userid"].Value = userid;
				objmysqlcommand.Parameters.Add("compcode",MySqlDbType.VarChar);
				objmysqlcommand.Parameters["compcode"].Value = compcode;
				objmysqlcommand.Parameters.Add("circular",MySqlDbType.VarChar);
				objmysqlcommand.Parameters["circular"].Value = circular;
				objmysqlcommand.Parameters.Add("statusname",MySqlDbType.VarChar);
				objmysqlcommand.Parameters["statusname"].Value = statusname;
				objmysqlcommand.Parameters.Add("fromdate",MySqlDbType.VarChar);
                objmysqlcommand.Parameters["fromdate"].Value = fromdate;
				objmysqlcommand.Parameters.Add("todate",MySqlDbType.VarChar);
				objmysqlcommand.Parameters["todate"].Value = todate;
                objmysqlcommand.Parameters.Add("codeid", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["codeid"].Value = codeid;
				objmysqlcommand.Parameters.Add("flag",MySqlDbType.VarChar);
				objmysqlcommand.Parameters["flag"].Value = flag;


                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
				
			}
			catch(Exception ex)	{throw(ex);}
			finally
			{CloseConnection(ref objmysqlconnection);}
		}
/*public DataSet retslabcheck(string compcode, string userid, string retcode, string todays, string fromdays, string codepass)
    {
        MySqlConnection objmysqlconnection;
        MySqlCommand objmysqlcommand;
        objmysqlconnection = GetConnection();
        MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objmysqlconnection.Open();
            objmysqlcommand = GetCommand("retcheckslab", ref objmysqlconnection);
            objmysqlcommand.CommandType = CommandType.StoredProcedure;

            objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["compcode"].Value = compcode;

            objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["userid"].Value = userid;

            objmysqlcommand.Parameters.Add("retcode", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["retcode"].Value = retcode;

            objmysqlcommand.Parameters.Add("todays", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["todays"].Value = todays;

            objmysqlcommand.Parameters.Add("fromdays", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["fromdays"].Value = fromdays;

            //objmysqlcommand.Parameters.Add("statusname", MySqlDbType.VarChar);
           // objmysqlcommand.Parameters["statusname"].Value = codepass;


            objmysqlDataAdapter.SelectCommand = objmysqlcommand;
            objmysqlDataAdapter.Fill(objDataSet);
            return objDataSet;

        }
        catch (Exception ex) { throw (ex); }
        finally
        { CloseConnection(ref objmysqlconnection); }
    }*/
    public DataSet insertretstatus(string compcode, string userid, string retcode, string status, string fromdate, string todate, string circular)
    {
        MySqlConnection objmysqlconnection;
        MySqlCommand objmysqlcommand;
        objmysqlconnection = GetConnection();
        MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
        DataSet objDataSet = new DataSet();  
        try
        {
            objmysqlconnection.Open();
            objmysqlcommand = GetCommand("insertretstatus_insertretstatus_p", ref objmysqlconnection);
            objmysqlcommand.CommandType = CommandType.StoredProcedure;

            objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["compcode"].Value = compcode;

            objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["userid"].Value = userid;

            objmysqlcommand.Parameters.Add("retcode", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["retcode"].Value = retcode;

            objmysqlcommand.Parameters.Add("status1", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["status1"].Value = status;

            objmysqlcommand.Parameters.Add("circular", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["circular"].Value = circular;

            objmysqlcommand.Parameters.Add("todate", MySqlDbType.DateTime);
            if (todate == "" || todate == null)//|| validtill == "undefined/undefined/")
            {
                objmysqlcommand.Parameters["todate"].Value = System.DBNull.Value;
            }
            else
            {
                objmysqlcommand.Parameters["todate"].Value = Convert.ToDateTime(todate).ToString ("yyyy-MM-dd");
                // com.Parameters["validtill"].Value = Convert.ToDateTime(validtill);
            }

            objmysqlcommand.Parameters.Add("fromdate", MySqlDbType.DateTime);
            if (fromdate == "" || fromdate == null)//|| validtill == "undefined/undefined/")
            {
                objmysqlcommand.Parameters["fromdate"].Value = System.DBNull.Value;
            }
            else
            {
                objmysqlcommand.Parameters["fromdate"].Value = Convert.ToDateTime(fromdate).ToString("yyyy-MM-dd");
            }
            //objmysqlcommand.Parameters.Add("flag", MySqlDbType.VarChar);
            //objmysqlcommand.Parameters["flag"].Value =flag;


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


      //public DataSet showchk(string compcode, string userid, string retcode)
      //  {
      //      objmysqlconnection = GetConnection();
      //      try
      //      {
      //          objmysqlconnection.Open();
      //          objmysqlcommand = GetCommand("showagencypay",ref objmysqlconnection);
      //          objmysqlcommand.CommandType = CommandType.StoredProcedure;
				
      //          objmysqlcommand.Parameters.Add("compcode",MySqlDbType.VarChar);
      //          objmysqlcommand.Parameters["compcode"].Value = compcode;

      //          objmysqlcommand.Parameters.Add("userid",MySqlDbType.VarChar);
      //          objmysqlcommand.Parameters["userid"].Value = userid;

      //          objmysqlcommand.Parameters.Add("retcode",MySqlDbType.VarChar);
      //          objmysqlcommand.Parameters["retcode"].Value = retcode;

      //          SqlDataAdapter da = new SqlDataAdapter(sqlcom);
      //          da.Fill(ds);
      //          return ds;
				
      //      }
      //      catch(Exception ex)	{throw(ex);}
      //      finally
      //      {CloseConnection(ref objmysqlconnection);}
      //  }


    public DataSet showchk(string compcode, string userid, string retcode)
    {

        MySqlConnection objmysqlconnection;
        MySqlCommand objmysqlcommand;
        objmysqlconnection = GetConnection();
        MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
        DataSet objDataSet = new DataSet(); 
        try
        {
            objmysqlconnection.Open();
            objmysqlcommand = GetCommand("showchk_showchk_p", ref objmysqlconnection);
            objmysqlcommand.CommandType = CommandType.StoredProcedure;

            objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["compcode"].Value = compcode;

            objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["userid"].Value = userid;

            objmysqlcommand.Parameters.Add("retcode", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["retcode"].Value = retcode;

            objmysqlDataAdapter.SelectCommand = objmysqlcommand;
            objmysqlDataAdapter.Fill(objDataSet);
            return objDataSet;

        }
        catch (Exception ex) { throw (ex); }
        finally
        { CloseConnection(ref objmysqlconnection); }
    }

    public DataSet chkretainercode(string str)
    {
        MySqlConnection objmysqlconnection;
        MySqlCommand objmysqlcommand;
        objmysqlconnection = GetConnection();
        MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
        DataSet objDataSet = new DataSet();  
        try
        {
            objmysqlconnection.Open();
            objmysqlcommand = GetCommand("chkretainername_chkretainername_p", ref objmysqlconnection);
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


    public DataSet chkretainercodemod(string strcode, string strname)
    {
        MySqlConnection objmysqlconnection;
        MySqlCommand objmysqlcommand;
        objmysqlconnection = GetConnection();
        MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
        DataSet objDataSet = new DataSet();  
        try
        {
            objmysqlconnection.Open();
            objmysqlcommand = GetCommand("chkretainernamemod_chkretainernamemod_p", ref objmysqlconnection);
            objmysqlcommand.CommandType = CommandType.StoredProcedure;

            objmysqlcommand.Parameters.Add("strname", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["strname"].Value = strname;

            objmysqlcommand.Parameters.Add("strcode", MySqlDbType.VarChar);
            if (strcode.Length > 2)
            {
            objmysqlcommand.Parameters["strcode"].Value = strcode.Substring (0,2);
            }
            else
            {
                objmysqlcommand.Parameters["strcode"].Value = strcode;
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

    public DataSet chkretainerusercode(string strcode, string strname)
    {
        MySqlConnection objmysqlconnection;
        MySqlCommand objmysqlcommand;
        objmysqlconnection = GetConnection();
        MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
        DataSet objDataSet = new DataSet();  
        try
        {
            objmysqlconnection.Open();
            objmysqlcommand = GetCommand("chkretaineruser_chkretaineruser_p", ref objmysqlconnection);
            objmysqlcommand.CommandType = CommandType.StoredProcedure;

            objmysqlcommand.Parameters.Add("strname", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["strname"].Value = strname;

            objmysqlcommand.Parameters.Add("strcode", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["strcode"].Value = strcode;



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

    public DataSet addcitydist(string cityname)
    {
        MySqlConnection objmysqlconnection;
        MySqlCommand objmysqlcommand;
        objmysqlconnection = GetConnection();
        MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
        DataSet objDataSet = new DataSet();   
        try
        {
            objmysqlconnection.Open();
            //objSqlCommand = GetCommand("filldiststate", ref objobjmysqlconnectionnection);
            // saurabh change
            objmysqlcommand = GetCommand("retaineraddregion_retaineraddregion_p", ref objmysqlconnection);
            objmysqlcommand.CommandType = CommandType.StoredProcedure;

            objmysqlcommand.Parameters.Add("regioncode", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["regioncode"].Value = cityname;


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



    public DataSet addpubcent()
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
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            CloseConnection(ref objmysqlconnection);
        }

    }

    public void insertRetData(string compcode, string retcode, string userid, int i, string strMode)
    {
        MySqlConnection objmysqlconnection;
        MySqlCommand objmysqlcommand;
        objmysqlconnection = GetConnection();

        try
        {
            objmysqlconnection.Open();
            objmysqlcommand = GetCommand("updateRetPayment_updateRetPayment_p", ref objmysqlconnection);
            objmysqlcommand.CommandType = CommandType.StoredProcedure;

            objmysqlcommand.Parameters.Add("Cash", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["Cash"].Value = strMode;


            objmysqlcommand.Parameters.Add("Comp_Code", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["Comp_Code"].Value = compcode;
            objmysqlcommand.Parameters.Add("Retain_Code", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["Retain_Code"].Value = retcode;
            objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["userid"].Value = userid;
            objmysqlcommand.Parameters.Add("Flag", MySqlDbType.Int24);
            objmysqlcommand.Parameters["flag"].Value = i;

            MySqlDataAdapter da = new MySqlDataAdapter(objmysqlcommand);
            da.SelectCommand = objmysqlcommand;
            DataSet ds = new DataSet();
            da.Fill(ds);

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

    public DataSet retslabcheck(string compcode, string userid, string retcode, string todays, string fromdays, string codepass)
    {
        MySqlConnection objmysqlconnection;
        MySqlCommand objmysqlcommand;
        objmysqlconnection = GetConnection();
        MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objmysqlconnection.Open();
            objmysqlcommand = GetCommand("retcheckslab", ref objmysqlconnection);
            objmysqlcommand.CommandType = CommandType.StoredProcedure;

            objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["userid"].Value = userid;

            objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["compcode"].Value = compcode;

            objmysqlcommand.Parameters.Add("retcode", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["retcode"].Value = retcode;

            objmysqlcommand.Parameters.Add("todays", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["todays"].Value = todays;

            objmysqlcommand.Parameters.Add("fromdays", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["fromdays"].Value = fromdays;

            //objmysqlcommand.Parameters.Add("codepass", MySqlDbType.VarChar);
            //objmysqlcommand.Parameters["codepass"].Value = codepass;

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

    public DataSet retainerstatusbind_b(string retcode, string userid, string compcode, string dateformat)
    {
        MySqlConnection objmysqlconnection;
        MySqlCommand objmysqlcommand;
        objmysqlconnection = GetConnection();
        MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objmysqlconnection.Open();
            objmysqlcommand = GetCommand("sp_retstatusbind_b", ref objmysqlconnection);
            objmysqlcommand.CommandType = CommandType.StoredProcedure;

            objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["userid"].Value = userid;

            objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["compcode"].Value = compcode;

            objmysqlcommand.Parameters.Add("retcode", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["retcode"].Value = retcode;

           
            //objmysqlcommand.Parameters.Add("codepass", MySqlDbType.VarChar);
            //objmysqlcommand.Parameters["codepass"].Value = codepass;

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

    public DataSet selectretslab(string retcode, string compcode, string userid, string code11)
    {
        MySqlConnection objmysqlconnection;
        MySqlCommand objmysqlcommand;
        objmysqlconnection = GetConnection();
        MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objmysqlconnection.Open();
            objmysqlcommand = GetCommand("retselectslab", ref objmysqlconnection);
            objmysqlcommand.CommandType = CommandType.StoredProcedure;

            objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["userid"].Value = userid;

            objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["compcode"].Value = compcode;

            objmysqlcommand.Parameters.Add("retcode", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["retcode"].Value = retcode;


            objmysqlcommand.Parameters.Add("code11", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["code11"].Value = code11;

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
    public DataSet Ret_GetSlabupdate(string retcode, string compcode, string userid, string common, string commrate, string todays, string fromdays, string code)
    {
        MySqlConnection objmysqlconnection;
        MySqlCommand objmysqlcommand;
        objmysqlconnection = GetConnection();
        MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objmysqlconnection.Open();
            objmysqlcommand = GetCommand("updateretstatus_slab", ref objmysqlconnection);
            objmysqlcommand.CommandType = CommandType.StoredProcedure;

            objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["userid"].Value = userid;

            objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["compcode"].Value = compcode;

            objmysqlcommand.Parameters.Add("retcode", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["retcode"].Value = retcode;


            objmysqlcommand.Parameters.Add("code1", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["code1"].Value = code;

            objmysqlcommand.Parameters.Add("commrate", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["commrate"].Value = commrate;

            objmysqlcommand.Parameters.Add("fromdays", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["fromdays"].Value = fromdays;

            objmysqlcommand.Parameters.Add("todays", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["todays"].Value = todays;


            objmysqlcommand.Parameters.Add("common", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["common"].Value = common;

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
    public DataSet insertretstatus_slab(string compcode, string userid, string retcode, string fromdays, string todays, string drpcommon, string commrate)
    {
        MySqlConnection objmysqlconnection;
        MySqlCommand objmysqlcommand;
        objmysqlconnection = GetConnection();
        MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objmysqlconnection.Open();
            objmysqlcommand = GetCommand("insertretstatus_slab", ref objmysqlconnection);
            objmysqlcommand.CommandType = CommandType.StoredProcedure;

            objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["userid"].Value = userid;

            objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["compcode"].Value = compcode;

            objmysqlcommand.Parameters.Add("retcode", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["retcode"].Value = retcode;

            objmysqlcommand.Parameters.Add("drpcommon", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["drpcommon"].Value = drpcommon;

            objmysqlcommand.Parameters.Add("commrate", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["commrate"].Value = commrate;

            objmysqlcommand.Parameters.Add("fromdays", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["fromdays"].Value = fromdays;

            objmysqlcommand.Parameters.Add("todays", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["todays"].Value = todays;

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

    public DataSet Ret_StatusDeleteSlab(string userid, string compcode, string retcode, string enlncode)
    {
        MySqlConnection objmysqlconnection;
        MySqlCommand objmysqlcommand;
        objmysqlconnection = GetConnection();
        MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objmysqlconnection.Open();
            objmysqlcommand = GetCommand("retdeleteslab", ref objmysqlconnection);
            objmysqlcommand.CommandType = CommandType.StoredProcedure;

            objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["userid"].Value = userid;

            objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["compcode"].Value = compcode;

            objmysqlcommand.Parameters.Add("retcode", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["retcode"].Value = retcode;

            objmysqlcommand.Parameters.Add("enlncode", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["enlncode"].Value = enlncode;

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

    public DataSet Retainerchkname(string compcode, string Retname)
    {
        MySqlConnection objmysqlconnection;
        MySqlCommand objmysqlcommand;
        objmysqlconnection = GetConnection();
        MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objmysqlconnection.Open();
            objmysqlcommand = GetCommand("Retchknameforbook", ref objmysqlconnection);
            objmysqlcommand.CommandType = CommandType.StoredProcedure;

            objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["compcode"].Value = compcode;

            objmysqlcommand.Parameters.Add("Retname", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["Retname"].Value = Retname;

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
		/*Retainer Status Detail coding ends*/
	}
}

