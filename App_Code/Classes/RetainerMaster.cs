using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

/// <summary>
/// Summary description for RetainerMaster
/// </summary>
namespace NewAdbooking.Classes
{
public class RetainerMaster:connection
{
    SqlConnection sqlcon = new SqlConnection();
    SqlCommand sqlcom = new SqlCommand();
    DataSet ds = new DataSet();
	public RetainerMaster()
	{
		//
		// TODO: Add constructor logic here
		//
	}/*Retainer Master Coding*/

		//check whether the data is present in all pop up
		public DataSet checkpopupdata(string compcode,string retcode,string userid2)
		{
            sqlcon = GetConnection();
            
			try
			{
                sqlcon.Open();
                
                sqlcom = GetCommand("checkpopup",ref sqlcon);
				sqlcom.CommandType = CommandType.StoredProcedure;
				sqlcom.Parameters.Add("@Comp_Code",SqlDbType.VarChar);
				sqlcom.Parameters["@Comp_Code"].Value =compcode ;
				sqlcom.Parameters.Add("@Retain_Code",SqlDbType.VarChar);
				sqlcom.Parameters["@Retain_Code"].Value = retcode;
				sqlcom.Parameters.Add("@userid",SqlDbType.VarChar);
				sqlcom.Parameters["@userid"].Value = userid2;
			
				SqlDataAdapter da = new SqlDataAdapter(sqlcom);	
				da.Fill(ds);
				return ds;
			}
			catch(SqlException e)
			{
				throw(e);
			}
			finally
			{
				CloseConnection(ref sqlcon);
			}
			
		}


    public DataSet addstatusname(string compcode)
    {
        SqlConnection objSqlConnection;
        SqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        SqlDataAdapter objSqlDataAdapter;
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("bind_status", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@compcode"].Value = compcode;

            objSqlDataAdapter = new SqlDataAdapter();
            objSqlDataAdapter.SelectCommand = objSqlCommand;
            objSqlDataAdapter.Fill(objDataSet);
            return objDataSet;
        }
        catch (SqlException objException)
        {
            throw (objException);
        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            CloseConnection(ref objSqlConnection);
        }
    }

    public DataSet filldatapay(string hiddencomcode, string hiddenuserid)
    {
        SqlConnection objSqlConnection;
        SqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("retainer_payfill", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
            objSqlCommand.Parameters["@userid"].Value = hiddenuserid;

            objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@compcode"].Value = hiddencomcode;



            objSqlDataAdapter.SelectCommand = objSqlCommand;
            objSqlDataAdapter.Fill(objDataSet);

            return objDataSet;

        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            CloseConnection(ref objSqlConnection);
        }
    }

				
		//check if the user is already present or not 
		public DataSet checkRetaineruser(string retcode,string userid,string compcode)
		{
			sqlcon.Open();
			try
			{
				sqlcom = GetCommand("checkretainerdata",ref sqlcon);
				sqlcom.CommandType = CommandType.StoredProcedure;
				sqlcom.Parameters.Add("@Comp_Code",SqlDbType.VarChar);
				sqlcom.Parameters["@Comp_Code"].Value =compcode ;
				sqlcom.Parameters.Add("@Retain_Code",SqlDbType.VarChar);
				sqlcom.Parameters["@Retain_Code"].Value = retcode;
				sqlcom.Parameters.Add("@userid",SqlDbType.VarChar);
				sqlcom.Parameters["@userid"].Value = userid;
			
				SqlDataAdapter da = new SqlDataAdapter(sqlcom);	
				da.Fill(ds);
				return ds;
			}
			catch(SqlException e)
			{
				throw(e);
			}
			finally
			{
				CloseConnection(ref sqlcon);
			}
			
		}



		//Save the data to the retainer master
        public DataSet RetainerStore(string compcode, string retcode, string userid, string retname, string retalias, string add1, string street, string citycode, string pubcent, string zip, string dist, string state, string zone, string region, string country, string phone1, string phone2, string fax, string email, string pan, string creditdays, string remarks, string flag, string Box, string publication, string edition, string supplement, string taluka, string repname, string branchcode, string creditlimit, string mobile, string signature, string empcode, string attachment, string maincdp, string name, string contactnam, string oldcode, string accode, string gstus, string gstdt, string gstin, string gstatus, string gstcltype, string dateformate)
		{
            SqlConnection sqlcon;
            SqlCommand sqlcom;
            sqlcon = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
       
			
			try
			{
				sqlcon.Open();
				sqlcom = GetCommand("RetainerInsertDetail",ref sqlcon);
				sqlcom.CommandType = CommandType.StoredProcedure;

                //sqlcom.Parameters.Add("@branchcode", SqlDbType.VarChar);
                //sqlcom.Parameters["@branchcode"].Value = branchcode;
				
				sqlcom.Parameters.Add("@Comp_Code1",SqlDbType.VarChar);
				sqlcom.Parameters["@Comp_Code1"].Value =compcode ;
				
				sqlcom.Parameters.Add("@Retain_Code1",SqlDbType.VarChar);
				sqlcom.Parameters["@Retain_Code1"].Value = retcode;
				
				sqlcom.Parameters.Add("@Retain_Name1",SqlDbType.VarChar);
				sqlcom.Parameters["@Retain_Name1"].Value = retname;
				
				sqlcom.Parameters.Add("@Retain_Alias1",SqlDbType.VarChar);
				sqlcom.Parameters["@Retain_Alias1"].Value = retalias;

                sqlcom.Parameters.Add("@repname", SqlDbType.VarChar);
                sqlcom.Parameters["@repname"].Value = repname;
				
				sqlcom.Parameters.Add("@Add11",SqlDbType.VarChar);
				sqlcom.Parameters["@Add11"].Value = add1;
				
				sqlcom.Parameters.Add("@Street1",SqlDbType.VarChar);
				sqlcom.Parameters["@Street1"].Value = street;
				
				sqlcom.Parameters.Add("@City_Code1",SqlDbType.VarChar);
				sqlcom.Parameters["@City_Code1"].Value = citycode;


                sqlcom.Parameters.Add("@pubcent1", SqlDbType.VarChar);
                sqlcom.Parameters["@pubcent1"].Value = pubcent;




				
				sqlcom.Parameters.Add("@Zip1",SqlDbType.VarChar);
				sqlcom.Parameters["@Zip1"].Value = zip;
				
				sqlcom.Parameters.Add("@Dist_Code1",SqlDbType.VarChar);
				sqlcom.Parameters["@Dist_Code1"].Value = dist;
				
				sqlcom.Parameters.Add("@State_Code1",SqlDbType.VarChar);
				sqlcom.Parameters["@State_Code1"].Value = state;

                sqlcom.Parameters.Add("@zone_code1", SqlDbType.VarChar);
                sqlcom.Parameters["@zone_code1"].Value = zone;

                sqlcom.Parameters.Add("@region_code1", SqlDbType.VarChar);
                sqlcom.Parameters["@region_code1"].Value = region;

				sqlcom.Parameters.Add("@Country_Code1",SqlDbType.VarChar);
				sqlcom.Parameters["@Country_Code1"].Value = country;
				
				sqlcom.Parameters.Add("@phone11",SqlDbType.VarChar);
				sqlcom.Parameters["@phone11"].Value = phone1;
				
				sqlcom.Parameters.Add("@Phone21",SqlDbType.VarChar);
				sqlcom.Parameters["@Phone21"].Value = phone2;
				
				sqlcom.Parameters.Add("@Fax1",SqlDbType.VarChar);
				sqlcom.Parameters["@Fax1"].Value = fax;
				
				sqlcom.Parameters.Add("@EmailID1",SqlDbType.VarChar);
				sqlcom.Parameters["@EmailID1"].Value = email;
				
				sqlcom.Parameters.Add("@PAN_No1",SqlDbType.VarChar);
				sqlcom.Parameters["@PAN_No1"].Value = pan;
				
				sqlcom.Parameters.Add("@Credit_Days1",SqlDbType.VarChar);
				sqlcom.Parameters["@Credit_Days1"].Value = creditdays;
				
				sqlcom.Parameters.Add("@Remarks1",SqlDbType.VarChar);
				sqlcom.Parameters["@Remarks1"].Value = remarks;

                sqlcom.Parameters.Add("@userid1", SqlDbType.VarChar);
                sqlcom.Parameters["@userid1"].Value = userid;
				
				sqlcom.Parameters.Add("@flag",SqlDbType.Int);
				sqlcom.Parameters["@flag"].Value = flag;

                sqlcom.Parameters.Add("@Box1", SqlDbType.VarChar);
                sqlcom.Parameters["@Box1"].Value = Box;

                sqlcom.Parameters.Add("@Publication11", SqlDbType.VarChar);
                sqlcom.Parameters["@Publication11"].Value = publication;

                sqlcom.Parameters.Add("@Edition11", SqlDbType.VarChar);
                sqlcom.Parameters["@Edition11"].Value = edition;

                sqlcom.Parameters.Add("@Supplement11", SqlDbType.VarChar);
                sqlcom.Parameters["@Supplement11"].Value = supplement;

                sqlcom.Parameters.Add("@taluka", SqlDbType.VarChar);
                sqlcom.Parameters["@taluka"].Value = taluka;

                sqlcom.Parameters.Add("@branchcode", SqlDbType.VarChar);
                sqlcom.Parameters["@branchcode"].Value = branchcode;

                sqlcom.Parameters.Add("@creditlimit", SqlDbType.VarChar);
                if (creditlimit == "")
                    sqlcom.Parameters["@creditlimit"].Value = "";
                else
                    sqlcom.Parameters["@creditlimit"].Value = creditlimit;

                sqlcom.Parameters.Add("@mobile1", SqlDbType.VarChar);
                sqlcom.Parameters["@mobile1"].Value = mobile;

                sqlcom.Parameters.Add("@signature", SqlDbType.VarChar);
                sqlcom.Parameters["@signature"].Value = signature;

                sqlcom.Parameters.Add("@p_empcode", SqlDbType.VarChar);
                sqlcom.Parameters["@p_empcode"].Value = empcode;

                sqlcom.Parameters.Add("@p_maincdp", SqlDbType.VarChar);
                sqlcom.Parameters["@p_maincdp"].Value = maincdp;


                sqlcom.Parameters.Add("@attachment", SqlDbType.VarChar);
                sqlcom.Parameters["@attachment"].Value = attachment;

                sqlcom.Parameters.Add("@p_retname", SqlDbType.VarChar);
                sqlcom.Parameters["@p_retname"].Value = name;

                sqlcom.Parameters.Add("@p_contacname", SqlDbType.VarChar);
                sqlcom.Parameters["@p_contacname"].Value = contactnam;

                sqlcom.Parameters.Add("@poldcode", SqlDbType.VarChar);
                sqlcom.Parameters["@poldcode"].Value = oldcode;

                sqlcom.Parameters.Add("@paccode", SqlDbType.VarChar);
                sqlcom.Parameters["@paccode"].Value = accode;



                sqlcom.Parameters.Add("@gst_registration", SqlDbType.VarChar);
                sqlcom.Parameters["@gst_registration"].Value = gstus;

                sqlcom.Parameters.Add("@gst_registration_date", SqlDbType.VarChar);
                if (gstdt != "" && gstdt != null)
                {
                    if (dateformate == "dd/mm/yyyy")
                    {
                        string[] arr = gstdt.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        gstdt = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformate == "yyyy/mm/dd")
                    {
                        string[] arr = gstdt.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        gstdt = mm + "/" + dd + "/" + yy;
                    }
                }
                if (gstdt != "" && gstdt != null)
                {
                    sqlcom.Parameters["@gst_registration_date"].Value = Convert.ToDateTime(gstdt);
                }
                else
                {
                    sqlcom.Parameters["@gst_registration_date"].Value = System.DBNull.Value;
                }

               // sqlcom.Parameters["@gst_registration_date"].Value = gstdt;

                sqlcom.Parameters.Add("@gstin", SqlDbType.VarChar);
                sqlcom.Parameters["@gstin"].Value = gstin;

                sqlcom.Parameters.Add("@gstapp", SqlDbType.VarChar);
                sqlcom.Parameters["@gstapp"].Value = gstatus;

                sqlcom.Parameters.Add("@gst_client_type_cd", SqlDbType.VarChar);
                sqlcom.Parameters["@gst_client_type_cd"].Value = gstcltype;
                sqlcom.Parameters.Add("@pdateformat", SqlDbType.VarChar);
                sqlcom.Parameters["@pdateformat"].Value = dateformate;



                SqlDataAdapter da = new SqlDataAdapter(sqlcom);
                //da.SelectCommand = sqlcom;
				da.Fill(ds);
				return ds;
			}
			catch(Exception e)
			{
				throw(e);
			}
			finally
			{
				CloseConnection(ref sqlcon);
			}
			
		}

    public DataSet retstatuscheck(string compcode, string userid, string retcode, string status, string circular, string todate, string fromdate, string dateformat, string codepass)
    {
        SqlConnection objSqlConnection;
        SqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("retstatuschk", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@compcode"].Value = compcode;

            objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
            objSqlCommand.Parameters["@userid"].Value = userid;

            objSqlCommand.Parameters.Add("@retcode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@retcode"].Value = retcode;

            objSqlCommand.Parameters.Add("@status", SqlDbType.VarChar);
            objSqlCommand.Parameters["@status"].Value = status;

            objSqlCommand.Parameters.Add("@circular", SqlDbType.VarChar);
            objSqlCommand.Parameters["@circular"].Value = circular;

            //objSqlCommand.Parameters.Add("@todate", SqlDbType.DateTime);
            //if (todate == "" || todate == null)//|| validtill == "undefined/undefined/")
            //{
            //    objSqlCommand.Parameters["@todate"].Value = System.DBNull.Value;
            //}
            //else
            //{
            //    objSqlCommand.Parameters["@todate"].Value = Convert.ToDateTime(todate);
            //    // com.Parameters["@validtill"].Value = Convert.ToDateTime(validtill);
            //}


            //objSqlCommand.Parameters.Add("@fromdate", SqlDbType.DateTime);
            //if (fromdate == "" || fromdate == null)//|| validtill == "undefined/undefined/")
            //{
            //    objSqlCommand.Parameters["@fromdate"].Value = System.DBNull.Value;
            //}
            //else
            //{
            //    objSqlCommand.Parameters["@fromdate"].Value = Convert.ToDateTime(fromdate);
            //}

            objSqlCommand.Parameters.Add("@fromdate", SqlDbType.VarChar);
            objSqlCommand.Parameters["@fromdate"].Value = fromdate;

            objSqlCommand.Parameters.Add("@todate", SqlDbType.VarChar);
            objSqlCommand.Parameters["@todate"].Value = todate;

            objSqlCommand.Parameters.Add("@date", SqlDbType.VarChar);
            objSqlCommand.Parameters["@date"].Value = dateformat;

            objSqlCommand.Parameters.Add("@codepass", SqlDbType.VarChar);
            objSqlCommand.Parameters["@codepass"].Value = codepass;

            objSqlDataAdapter.SelectCommand = objSqlCommand;
            objSqlDataAdapter.Fill(objDataSet);

            return objDataSet;

        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            CloseConnection(ref objSqlConnection);
        }

    }

    public void insertData(string compcode, string retcode, string userid, int i, string strMode)
    {
        SqlConnection sqlcon;
        SqlCommand sqlcomm;
        sqlcon = GetConnection();
        try
        {
            sqlcon.Open();
            sqlcomm = GetCommand("updateRetPay", ref sqlcon);
            sqlcomm.CommandType = CommandType.StoredProcedure;

            sqlcomm.Parameters.Add("@Cash", SqlDbType.VarChar);
            sqlcomm.Parameters["@Cash"].Value = strMode;
            //sqlcomm.Parameters.Add("@Credit", SqlDbType.VarChar);
            //sqlcomm.Parameters["@Credit"].Value = strMode[1];
            //sqlcomm.Parameters.Add("@Bank", SqlDbType.VarChar);
            //sqlcomm.Parameters["@Bank"].Value = strMode[2];
            sqlcomm.Parameters.Add("@Comp_Code", SqlDbType.VarChar);
            sqlcomm.Parameters["@Comp_Code"].Value = compcode;
            sqlcomm.Parameters.Add("@retcode", SqlDbType.VarChar);
            sqlcomm.Parameters["@retcode"].Value = retcode;
            sqlcomm.Parameters.Add("@userid", SqlDbType.VarChar);
            sqlcomm.Parameters["@userid"].Value = userid;
            sqlcomm.Parameters.Add("@Flag", SqlDbType.VarChar);
            sqlcomm.Parameters["@Flag"].Value = i;

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlcomm;
            DataSet ds = new DataSet();
            da.Fill(ds);
        }
        catch (Exception ex) { throw (ex); }
        finally
        { CloseConnection(ref sqlcon); }
    }

    public DataSet selectretstatus(string retcode, string compcode, string userid, string code11, string dateformat)
    {
        SqlConnection objSqlConnection;
        SqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("retselect", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@compcode"].Value = compcode;

            objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
            objSqlCommand.Parameters["@userid"].Value = userid;

            objSqlCommand.Parameters.Add("@retcode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@retcode"].Value = retcode;


            objSqlCommand.Parameters.Add("@code11", SqlDbType.VarChar);
            objSqlCommand.Parameters["@code11"].Value = code11;


            objSqlCommand.Parameters.Add("@dateformat", SqlDbType.VarChar);
            objSqlCommand.Parameters["@dateformat"].Value = dateformat;


            objSqlDataAdapter.SelectCommand = objSqlCommand;
            objSqlDataAdapter.Fill(objDataSet);

            return objDataSet;

        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            CloseConnection(ref objSqlConnection);
        }

    }

    public DataSet selectretcomm(string retcode, string compcode, string userid, string code11, string dateformat)
    {
        SqlConnection objSqlConnection;
        SqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("retcommselect", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@compcode"].Value = compcode;

            objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
            objSqlCommand.Parameters["@userid"].Value = userid;

            objSqlCommand.Parameters.Add("@retcode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@retcode"].Value = retcode;


            objSqlCommand.Parameters.Add("@code11", SqlDbType.VarChar);
            objSqlCommand.Parameters["@code11"].Value = code11;


            objSqlCommand.Parameters.Add("@dateformat", SqlDbType.VarChar);
            objSqlCommand.Parameters["@dateformat"].Value = dateformat;


            objSqlDataAdapter.SelectCommand = objSqlCommand;
            objSqlDataAdapter.Fill(objDataSet);

            return objDataSet;

        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            CloseConnection(ref objSqlConnection);
        }

    }


    public DataSet retainerstatusbind(string retcode, string userid, string compcode, string dateformat)
    {
        SqlConnection objSqlConnection;
        SqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("sp_retstatusbind", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;


            objSqlCommand.Parameters.Add("@retcode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@retcode"].Value = retcode;


            objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
            objSqlCommand.Parameters["@userid"].Value = userid;

            objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@compcode"].Value = compcode;


            objSqlCommand.Parameters.Add("@date", SqlDbType.VarChar);
            objSqlCommand.Parameters["@date"].Value = dateformat;



            objSqlDataAdapter.SelectCommand = objSqlCommand;
            objSqlDataAdapter.Fill(objDataSet);

            return objDataSet;

        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            CloseConnection(ref objSqlConnection);
        }

    }

		public DataSet RetDelete(string compcode,string Retcode)
		{
			sqlcon = GetConnection();
			
			try
			{
				sqlcon.Open();
				sqlcom = GetCommand("RetainerDelete",ref sqlcon);
				sqlcom.CommandType = CommandType.StoredProcedure;

				sqlcom.Parameters.Add("@Comp_Code",SqlDbType.VarChar);
				sqlcom.Parameters["@Comp_Code"].Value =compcode ;
				
				sqlcom.Parameters.Add("@Retain_Code",SqlDbType.VarChar);
				sqlcom.Parameters["@Retain_Code"].Value = Retcode;
				
				/*sqlcom.Parameters.Add("@userid",SqlDbType.VarChar);
				sqlcom.Parameters["@userid"].Value = userid;*/

				SqlDataAdapter da = new SqlDataAdapter(sqlcom);	
				da.Fill(ds);
				return ds;
			}
			catch(Exception e)
			{
				throw(e);
			}
			finally
			{
				CloseConnection(ref sqlcon);
			}
			
		}

        public DataSet RetainerExecute(string compcode, string Retcode, string Retname, string alias, string city, string pubcent, string country, string Box, string repname, string branchname, string oldcode, string accode, string gstus, string gstdt, string gstin, string gstatus, string gstcltype)
		{
			sqlcon = GetConnection();
			try
			{
				sqlcon.Open();
				
                //saurabh added
                
                //sqlcom = GetCommand("RetainerExecute",ref sqlcon);
                
                sqlcom = GetCommand("RetainerExec", ref sqlcon);
                sqlcom.CommandType = CommandType.StoredProcedure;

                //sqlcom.Parameters.Add("@branchname", SqlDbType.VarChar);
                //sqlcom.Parameters["@branchname"].Value = branchname;

				sqlcom.Parameters.Add("@compcode",SqlDbType.VarChar);
				sqlcom.Parameters["@compcode"].Value =compcode ;
                //sqlcom.Parameters.Add("@userid",SqlDbType.VarChar);
                //sqlcom.Parameters["@userid"].Value = userid;
				
				sqlcom.Parameters.Add("@Retain_Code",SqlDbType.VarChar);
				if(Retcode==null || Retcode=="")
				{
					sqlcom.Parameters["@Retain_Code"].Value = "";
				}
				else
				{
					sqlcom.Parameters["@Retain_Code"].Value = Retcode;
				}
				
				sqlcom.Parameters.Add("@retname",SqlDbType.VarChar);
				if(Retname==null|Retname=="")
				{
					sqlcom.Parameters["@retname"].Value = "";
				}
				else
				{
					sqlcom.Parameters["@retname"].Value = Retname;
				}
				
				sqlcom.Parameters.Add("@retalias ",SqlDbType.VarChar);
				if(alias==null||alias=="")
				{
					sqlcom.Parameters["@retalias "].Value = "";
				}
				else
				{
					sqlcom.Parameters["@retalias "].Value = alias;
				}
                sqlcom.Parameters.Add("@repname", SqlDbType.VarChar);
                if (repname == null | repname == "")
                {
                    sqlcom.Parameters["@repname"].Value = "";
                }
                else
                {
                    sqlcom.Parameters["@repname"].Value = repname;
                }
				sqlcom.Parameters.Add("@citycode",SqlDbType.VarChar);
				if(city==null||city==""||city=="0")
				{
					sqlcom.Parameters["@citycode"].Value = "0";
				}
				else
				{
					sqlcom.Parameters["@citycode"].Value = city;
				}



                sqlcom.Parameters.Add("@pubcent", SqlDbType.VarChar);
                if (pubcent == null || pubcent == ""|| pubcent == "0")
                {
                    sqlcom.Parameters["@pubcent"].Value = "0";
                }
                else
                {
                    sqlcom.Parameters["@pubcent"].Value = pubcent;
                }

                sqlcom.Parameters.Add("@country", SqlDbType.VarChar);
                if (country == null || country=="" || country == "0")
                {
                    sqlcom.Parameters["@country"].Value = "0";
                }
                else
                {
                    sqlcom.Parameters["@country"].Value = country;
                }

                sqlcom.Parameters.Add("@Box", SqlDbType.VarChar);
                if (Box == null || Box == "" || Box == "0")
                {
                    sqlcom.Parameters["@Box"].Value = "0";
                }
                else
                {
                    sqlcom.Parameters["@Box"].Value = Box;
                }


                sqlcom.Parameters.Add("@branchname", SqlDbType.VarChar);
                if (branchname == null || branchname == "" || branchname == "0")
                {
                    sqlcom.Parameters["@branchname"].Value = "0";
                }
                else
                {
                    sqlcom.Parameters["@branchname"].Value = branchname;
                }

                sqlcom.Parameters.Add("@oldcode", SqlDbType.VarChar);
                if (oldcode == null || oldcode == "" || oldcode == "0")
                {
                    sqlcom.Parameters["@oldcode"].Value = "";
                }
                else
                {
                    sqlcom.Parameters["@oldcode"].Value = oldcode;
                }
                sqlcom.Parameters.Add("@accode", SqlDbType.VarChar);
                if (accode == null || accode == "" || accode == "0")
                {
                    sqlcom.Parameters["@accode"].Value = "";
                }
                else
                {
                    sqlcom.Parameters["@accode"].Value = accode;
                }



                sqlcom.Parameters.Add("@gst_registration", SqlDbType.VarChar);
                if (gstus == null || gstus == "" || gstus == "0")
                {
                    sqlcom.Parameters["@gst_registration"].Value = "";
                }
                else
                {
                    sqlcom.Parameters["@gst_registration"].Value = gstus;
                }
                sqlcom.Parameters.Add("@gst_registration_date", SqlDbType.VarChar);
                if (gstdt == null || gstdt == "" || gstdt == "0")
                {
                    sqlcom.Parameters["@gst_registration_date"].Value = "";
                }
                else
                {
                    sqlcom.Parameters["@gst_registration_date"].Value = gstdt;
                }



                sqlcom.Parameters.Add("@gstin", SqlDbType.VarChar);
                if (gstin == null || gstin == "" || gstin == "0")
                {
                    sqlcom.Parameters["@gstin"].Value = "";
                }
                else
                {
                    sqlcom.Parameters["@gstin"].Value = gstin;
                }

                sqlcom.Parameters.Add("@gstapp", SqlDbType.VarChar);
                if (gstatus == null || gstatus == "" || gstatus == "0")
                {
                    sqlcom.Parameters["@gstapp"].Value = "";
                }
                else
                {
                    sqlcom.Parameters["@gstapp"].Value = gstatus;
                }

                sqlcom.Parameters.Add("@gst_client_type_cd", SqlDbType.VarChar);
                if (gstcltype == null || gstcltype == "" || gstcltype == "0")
                {
                    sqlcom.Parameters["@gst_client_type_cd"].Value = "";
                }
                else
                {
                    sqlcom.Parameters["@gst_client_type_cd"].Value = gstcltype;
                }
				SqlDataAdapter da = new SqlDataAdapter(sqlcom);	
				da.Fill(ds);
				return ds;
			}
			catch(SqlException e)
			{
				throw(e);
			}
			finally
			{
				CloseConnection(ref sqlcon);
			}
			
		}

		
		public DataSet RetainerNavigate(string compcode,string userid)
		{
			sqlcon = GetConnection();
			try
			{
				sqlcon.Open();
				sqlcom = GetCommand("RetNavigate",ref sqlcon);
				sqlcom.CommandType = CommandType.StoredProcedure;
				
				sqlcom.Parameters.Add("@compcode",SqlDbType.VarChar);
				sqlcom.Parameters["@compcode"].Value =compcode ;
				sqlcom.Parameters.Add("@userid",SqlDbType.VarChar);
				sqlcom.Parameters["@userid"].Value = userid;
				
				SqlDataAdapter da = new SqlDataAdapter(sqlcom);	
				da.Fill(ds);
				return ds;
			}
			catch(SqlException e)
			{
				throw(e);
			}
			finally
			{
				CloseConnection(ref sqlcon);
			}
			
		}
		
		//first,next,last previous 

		public DataSet getRecords(string compcode,string Retcode,string userid2)
		{
            SqlConnection sqlcon;
            SqlCommand sqlcom;
			sqlcon = GetConnection();
			try
			{
				sqlcon.Open();
				sqlcom = GetCommand("Retpayselect",ref sqlcon);
				sqlcom.CommandType = CommandType.StoredProcedure;
				sqlcom.Parameters.Add("@Retcode",SqlDbType.VarChar);
				sqlcom.Parameters["@Retcode"].Value = Retcode ;
				sqlcom.Parameters.Add("@userid",SqlDbType.VarChar);
				sqlcom.Parameters["@userid"].Value = userid2;
				sqlcom.Parameters.Add("@compcode",SqlDbType.VarChar);
				sqlcom.Parameters["@compcode"].Value = compcode ;
				SqlDataAdapter da = new SqlDataAdapter(sqlcom);
				da.Fill(ds);
			}
			catch(Exception ex)
			{
				throw(ex);
			}
			finally
			{
				CloseConnection(ref sqlcon);
			}
			return ds;
		}



		/*Retainer Master Coding Ends*/

		/*===================================================================*/

		/*Pop up coding Starts*/

		/*Pop Up Paymode*/
		//GetData is used to retrieve the custcode from customer master
		public DataSet getData(string retcode,string userid,string compcode)
		{
            SqlConnection sqlcon;
            SqlCommand sqlcom;
			sqlcon = GetConnection();
			try
			{
				sqlcon.Open();
				sqlcom = GetCommand("Retpayselect",ref sqlcon);
				sqlcom.CommandType = CommandType.StoredProcedure;
				sqlcom.Parameters.Add("@Retcode",SqlDbType.VarChar);
				sqlcom.Parameters["@Retcode"].Value = retcode ;
				sqlcom.Parameters.Add("@userid",SqlDbType.VarChar);
				sqlcom.Parameters["@userid"].Value = userid ;
				sqlcom.Parameters.Add("@compcode",SqlDbType.VarChar);
				sqlcom.Parameters["@compcode"].Value = compcode ;
				SqlDataAdapter da = new SqlDataAdapter(sqlcom);
				da.Fill(ds);
			}
			catch(Exception ex)
			{
				throw(ex);
			}
			finally
			{
				CloseConnection(ref sqlcon);
			}
			return ds;
		}



		//insert Data is used to insert/update values into temporary retainer payment table
//		public DataSet insertRetData(string  compcode,string retcode,string  userid,int i, params string[] strMode)
    public void insertRetData(string compcode, string retcode, string userid, int i, string strMode)
		{
            SqlConnection sqlcon;
            SqlCommand sqlcom;
            sqlcon = GetConnection();
			
			try
			{
				sqlcon.Open();
				sqlcom = GetCommand("updateRetPayment",ref sqlcon);
				sqlcom.CommandType = CommandType.StoredProcedure;
				
				sqlcom.Parameters.Add("@Cash",SqlDbType.VarChar);
                sqlcom.Parameters["@Cash"].Value = strMode;


				sqlcom.Parameters.Add("@Comp_Code",SqlDbType.VarChar);
				sqlcom.Parameters["@Comp_Code"].Value = compcode;
				sqlcom.Parameters.Add("@Retain_Code",SqlDbType.VarChar);
				sqlcom.Parameters["@Retain_Code"].Value = retcode;
				sqlcom.Parameters.Add("@userid",SqlDbType.VarChar);
				sqlcom.Parameters["@userid"].Value = userid;
				sqlcom.Parameters.Add("@Flag",SqlDbType.Int);
				sqlcom.Parameters["@flag"].Value = i;
				
				SqlDataAdapter da = new SqlDataAdapter(sqlcom);
                da.SelectCommand = sqlcom;
                DataSet ds = new DataSet();
                da.Fill(ds);
					
			}
			catch(Exception ex)
            {
                throw(ex);
            }
			finally
			{
                CloseConnection(ref sqlcon);
            }
		 }


		/*Paymode coding ends*/
		

		/*Commmission coding starts*/

		//DropDown Binding

		public DataSet commission()
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("websp_comm_detail", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;			
				
				objSqlDataAdapter.SelectCommand = objSqlCommand;
				objSqlDataAdapter.Fill(objDataSet);
				return objDataSet;

			}
			catch(Exception ex)
			{
				throw(ex);
			}
			finally
			{
				CloseConnection(ref objSqlConnection);
			}

		}
		
		//Datagrid Binding

		public DataSet RetainerCommBind(string retcode,string compcode, string userid,string dateformat)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter;
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("RetainerCommBind", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 
				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;
				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;
				objSqlCommand.Parameters.Add("@Retain_Code", SqlDbType.VarChar);
				objSqlCommand.Parameters["@Retain_Code"].Value =retcode;
				objSqlCommand.Parameters.Add("@dateformat", SqlDbType.VarChar);
				objSqlCommand.Parameters["@dateformat"].Value =dateformat;
				objSqlDataAdapter =new SqlDataAdapter();
				objSqlDataAdapter.SelectCommand =objSqlCommand;
				objSqlDataAdapter.Fill(objDataSet);
				return objDataSet;
			}
			catch(SqlException objException)
			{
				throw(objException);
			}
			catch(Exception ex)
			{
				throw(ex);	
			}
			finally
			{
				CloseConnection(ref objSqlConnection);
			}
		
		}


		//Commission date Check 
		public DataSet checkdate(string retcode,string userid,string compcode,string txtefffrom,string txtefftill)
		{
			sqlcon = GetConnection();
			try
			{
				sqlcon.Open();
				sqlcom = GetCommand("chkcommdate",ref sqlcon);
				sqlcom.CommandType = CommandType.StoredProcedure;
				
				sqlcom.Parameters.Add("@retcode",SqlDbType.VarChar);
				sqlcom.Parameters["@retcode"].Value = retcode;
				sqlcom.Parameters.Add("@userid",SqlDbType.VarChar);
				sqlcom.Parameters["@userid"].Value = userid;
				sqlcom.Parameters.Add("@compcode",SqlDbType.VarChar);
				sqlcom.Parameters["@compcode"].Value = compcode;
				sqlcom.Parameters.Add("@fromdate",SqlDbType.VarChar);
				sqlcom.Parameters["@fromdate"].Value = txtefffrom;
				sqlcom.Parameters.Add("@tilldate",SqlDbType.VarChar);
				sqlcom.Parameters["@tilldate"].Value = txtefftill;
				
				SqlDataAdapter da = new SqlDataAdapter(sqlcom);
				da.Fill(ds);
				return ds;
				
			}
			catch(Exception ex)	{throw(ex);}
			finally
			{CloseConnection(ref sqlcon);}
		}

//comm date update
		public DataSet checkdateupdate(string retcode,string userid,string compcode,string txtefffrom,string txtefftill,string code)
		{
			sqlcon = GetConnection();
			try
			{
				sqlcon.Open();
				sqlcom = GetCommand("chkcommdateupdate",ref sqlcon);
				sqlcom.CommandType = CommandType.StoredProcedure;
				
				sqlcom.Parameters.Add("@retcode",SqlDbType.VarChar);
				sqlcom.Parameters["@retcode"].Value = retcode;
				sqlcom.Parameters.Add("@userid",SqlDbType.VarChar);
				sqlcom.Parameters["@userid"].Value = userid;
				sqlcom.Parameters.Add("@compcode",SqlDbType.VarChar);
				sqlcom.Parameters["@compcode"].Value = compcode;
				sqlcom.Parameters.Add("@fromdate",SqlDbType.VarChar);
				sqlcom.Parameters["@fromdate"].Value = txtefffrom;
				sqlcom.Parameters.Add("@tilldate",SqlDbType.VarChar);
				sqlcom.Parameters["@tilldate"].Value = txtefftill;
				sqlcom.Parameters.Add("@code",SqlDbType.VarChar);
				sqlcom.Parameters["@code"].Value = code;
				
				SqlDataAdapter da = new SqlDataAdapter(sqlcom);
				da.Fill(ds);
				return ds;
				
			}
			catch(Exception ex)	{throw(ex);}
			finally
			{CloseConnection(ref sqlcon);}
		}

		//Commission Data insert/Update
    public DataSet RetainerCommission(string retcode, string userid, string compcode, string txtefffrom, string txtefftill, string txtcommrate, string discount, string updatecommission, int flag, string frmamt, string toamt, string addcommrate)
		{
			sqlcon = GetConnection();
			try
			{
				sqlcon.Open();
				sqlcom = GetCommand("RetainerCommission",ref sqlcon);
				sqlcom.CommandType = CommandType.StoredProcedure;
				
				sqlcom.Parameters.Add("@Retain_Code",SqlDbType.VarChar);
				sqlcom.Parameters["@Retain_Code"].Value = retcode;

				sqlcom.Parameters.Add("@userid",SqlDbType.VarChar);
				sqlcom.Parameters["@userid"].Value = userid;

				sqlcom.Parameters.Add("@compcode",SqlDbType.VarChar);
				sqlcom.Parameters["@compcode"].Value = compcode;

				sqlcom.Parameters.Add("@effectivefrm",SqlDbType.VarChar);
                sqlcom.Parameters["@effectivefrm"].Value = txtefffrom;// Convert.ToDateTime(txtefffrom);

				sqlcom.Parameters.Add("@efftill",SqlDbType.VarChar);
                sqlcom.Parameters["@efftill"].Value = txtefftill;// Convert.ToDateTime(txtefftill);

				sqlcom.Parameters.Add("@commrate",SqlDbType.VarChar);
				sqlcom.Parameters["@commrate"].Value = txtcommrate;

				sqlcom.Parameters.Add("@discount",SqlDbType.VarChar);
				sqlcom.Parameters["@discount"].Value = discount;

				sqlcom.Parameters.Add("@codeid",SqlDbType.VarChar);
                if (updatecommission == "")
                {
                    sqlcom.Parameters["@codeid"].Value = System.DBNull.Value;
                }
                else
                {
                    sqlcom.Parameters["@codeid"].Value = updatecommission;
                }

				sqlcom.Parameters.Add("@flag",SqlDbType.Int);
				sqlcom.Parameters["@flag"].Value = flag;

                sqlcom.Parameters.Add("@frmamt", SqlDbType.VarChar);
                if (frmamt == "")
                    sqlcom.Parameters["@frmamt"].Value = System.DBNull.Value;
                else
                    sqlcom.Parameters["@frmamt"].Value = frmamt;

                sqlcom.Parameters.Add("@toamt", SqlDbType.VarChar);
                if (toamt == "")
                    sqlcom.Parameters["@toamt"].Value = System.DBNull.Value;
                else
                    sqlcom.Parameters["@toamt"].Value = toamt;

                sqlcom.Parameters.Add("@addcommrate", SqlDbType.VarChar);
                if (addcommrate == "")
                    sqlcom.Parameters["@addcommrate"].Value = System.DBNull.Value;
                else
                    sqlcom.Parameters["@addcommrate"].Value = addcommrate;

				SqlDataAdapter da = new SqlDataAdapter(sqlcom);
				da.Fill(ds);
				return ds;
				
			}
			catch(Exception ex)	{throw(ex);}
			finally
			{CloseConnection(ref sqlcon);}
		
		}

		//Get the values with respect to dates 
		public DataSet getCommData(string compcode,string userid,string retcode,string codeid,int flag)
		{
			sqlcon = GetConnection();
			try
			{
				sqlcon.Open();
				sqlcom = GetCommand("GetRetComm",ref sqlcon);
				sqlcom.CommandType = CommandType.StoredProcedure;
				
				sqlcom.Parameters.Add("@retcode",SqlDbType.VarChar);
				sqlcom.Parameters["@retcode"].Value = retcode;
				sqlcom.Parameters.Add("@userid",SqlDbType.VarChar);
				sqlcom.Parameters["@userid"].Value = userid;
				sqlcom.Parameters.Add("@compcode",SqlDbType.VarChar);
				sqlcom.Parameters["@compcode"].Value = compcode;
				sqlcom.Parameters.Add("@codeid",SqlDbType.VarChar);
				sqlcom.Parameters["@codeid"].Value = codeid;
				sqlcom.Parameters.Add("@flag",SqlDbType.Int);
				sqlcom.Parameters["@flag"].Value = flag;

				SqlDataAdapter da = new SqlDataAdapter(sqlcom);
				da.Fill(ds);
				return ds;
				
			}
			catch(Exception ex)	{throw(ex);}
			finally
			{CloseConnection(ref sqlcon);}
		}

		/*Commmission coding ends*/


		/*Retainer Status Detail coding starts  */

		/*Bind the data to the datagrid during page load 
		 * & also to check the date whether the date is present or not*/
		public DataSet Ret_GetStatus(string retcode,string compcode, string userid,string date,string fromdate,string todate,string codestatusid,int flag)
		{
			sqlcon = GetConnection();
			try
			{
				sqlcon.Open();
				sqlcom = GetCommand("Ret_GetStatus",ref sqlcon);
				sqlcom.CommandType = CommandType.StoredProcedure;
				
				sqlcom.Parameters.Add("@Retain_Code",SqlDbType.VarChar);
				sqlcom.Parameters["@Retain_Code"].Value = retcode;
				sqlcom.Parameters.Add("@userid",SqlDbType.VarChar);
				sqlcom.Parameters["@userid"].Value = userid;
				sqlcom.Parameters.Add("@compcode",SqlDbType.VarChar);
				sqlcom.Parameters["@compcode"].Value = compcode;
				sqlcom.Parameters.Add("@date",SqlDbType.VarChar);
				sqlcom.Parameters["@date"].Value = date;
				sqlcom.Parameters.Add("@txtfrom",SqlDbType.VarChar);
				if(fromdate==""||fromdate==null)
				{
					sqlcom.Parameters["@txtfrom"].Value = fromdate;
				}
				else
				{
					sqlcom.Parameters["@txtfrom"].Value = Convert.ToDateTime(fromdate);
				}
				
				sqlcom.Parameters.Add("@txtto",SqlDbType.VarChar);
				if(fromdate==""||fromdate==null)
				{
					sqlcom.Parameters["@txtto"].Value = todate;
				}
				else
				{
					sqlcom.Parameters["@txtto"].Value = Convert.ToDateTime(todate);
				}
				
				sqlcom.Parameters.Add("@codestatusid",SqlDbType.VarChar);
				sqlcom.Parameters["@codestatusid"].Value = codestatusid;
				sqlcom.Parameters.Add("@flag",SqlDbType.VarChar);
				sqlcom.Parameters["@flag"].Value = flag;

				SqlDataAdapter da = new SqlDataAdapter(sqlcom);
				da.Fill(ds);
				return ds;
				
			}
			catch(Exception ex)	{throw(ex);}
			finally
			{CloseConnection(ref sqlcon);}
		}

		public DataSet Ret_GetStatusupdate(string retcode,string compcode, string userid,string status, string circular, string todate,string fromdate,string code)
		{
			sqlcon = GetConnection();
			try
			{
				sqlcon.Open();
				sqlcom = GetCommand("Ret_GetStatusupdate",ref sqlcon);
				sqlcom.CommandType = CommandType.StoredProcedure;
				
				sqlcom.Parameters.Add("@retcode",SqlDbType.VarChar);
                sqlcom.Parameters["@retcode"].Value = retcode;

				sqlcom.Parameters.Add("@userid",SqlDbType.VarChar);
				sqlcom.Parameters["@userid"].Value = userid;

				sqlcom.Parameters.Add("@compcode",SqlDbType.VarChar);
				sqlcom.Parameters["@compcode"].Value = compcode;

                //sqlcom.Parameters.Add("@date",SqlDbType.VarChar);
                //sqlcom.Parameters["@date"].Value = date;

                sqlcom.Parameters.Add("@status", SqlDbType.VarChar);
                sqlcom.Parameters["@status"].Value = status;

                sqlcom.Parameters.Add("@circular", SqlDbType.VarChar);
                sqlcom.Parameters["@circular"].Value = circular;


                sqlcom.Parameters.Add("@fromdate", SqlDbType.VarChar);
				if(fromdate==""||fromdate==null)
				{
                    sqlcom.Parameters["@fromdate"].Value = fromdate;
				}
				else
				{
                    sqlcom.Parameters["@fromdate"].Value = fromdate;// Convert.ToDateTime(fromdate);
				}

                sqlcom.Parameters.Add("@todate", SqlDbType.VarChar);
				if(fromdate==""||fromdate==null)
				{
                    sqlcom.Parameters["@todate"].Value = todate;
				}
				else
				{
                    sqlcom.Parameters["@todate"].Value = todate;//Convert.ToDateTime(todate);
				}
				
				sqlcom.Parameters.Add("@code",SqlDbType.VarChar);
				sqlcom.Parameters["@code"].Value = code;
				

				SqlDataAdapter da = new SqlDataAdapter(sqlcom);
				da.Fill(ds);
				return ds;
				
			}
			catch(Exception ex)	{throw(ex);}
			finally
			{CloseConnection(ref sqlcon);}
		}

		/*Insert ,Update & Delete operation */
		public DataSet Ret_StatusOperation(string userid,string compcode,string retcode,string statusname ,string fromdate,string todate,string circular,string codeid,int flag)
		{
			sqlcon = GetConnection();
			try
			{
				sqlcon.Open();
				sqlcom = GetCommand("RetStatusUpdate",ref sqlcon);
				sqlcom.CommandType = CommandType.StoredProcedure;
				
				sqlcom.Parameters.Add("@Retain_Code",SqlDbType.VarChar);
				sqlcom.Parameters["@Retain_Code"].Value = retcode;
				sqlcom.Parameters.Add("@userid",SqlDbType.VarChar);
				sqlcom.Parameters["@userid"].Value = userid;
				sqlcom.Parameters.Add("@compcode",SqlDbType.VarChar);
				sqlcom.Parameters["@compcode"].Value = compcode;
				sqlcom.Parameters.Add("@circular",SqlDbType.VarChar);
				sqlcom.Parameters["@circular"].Value = circular;
				sqlcom.Parameters.Add("@statusname",SqlDbType.VarChar);
				sqlcom.Parameters["@statusname"].Value = statusname;
				sqlcom.Parameters.Add("@fromdate",SqlDbType.VarChar);
                sqlcom.Parameters["@fromdate"].Value = fromdate;
				sqlcom.Parameters.Add("@todate",SqlDbType.VarChar);
				sqlcom.Parameters["@todate"].Value = todate;
                sqlcom.Parameters.Add("@codeid", SqlDbType.VarChar);
				sqlcom.Parameters["@codeid"].Value = codeid;
				sqlcom.Parameters.Add("@flag",SqlDbType.VarChar);
				sqlcom.Parameters["@flag"].Value = flag;

				SqlDataAdapter da = new SqlDataAdapter(sqlcom);
				da.Fill(ds);
				return ds;
				
			}
			catch(Exception ex)	{throw(ex);}
			finally
			{CloseConnection(ref sqlcon);}
		}


    public DataSet insertretstatus(string compcode, string userid, string retcode, string status, string fromdate, string todate, string circular)
    {
        SqlConnection objSqlConnection;
        SqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("insertretstatus", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@compcode"].Value = compcode;

            objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
            objSqlCommand.Parameters["@userid"].Value = userid;

            objSqlCommand.Parameters.Add("@retcode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@retcode"].Value = retcode;

            objSqlCommand.Parameters.Add("@status", SqlDbType.VarChar);
            objSqlCommand.Parameters["@status"].Value = status;

            objSqlCommand.Parameters.Add("@circular", SqlDbType.VarChar);
            objSqlCommand.Parameters["@circular"].Value = circular;

            objSqlCommand.Parameters.Add("@todate", SqlDbType.DateTime);
            if (todate == "" || todate == null)//|| validtill == "undefined/undefined/")
            {
                objSqlCommand.Parameters["@todate"].Value = System.DBNull.Value;
            }
            else
            {
                objSqlCommand.Parameters["@todate"].Value = Convert.ToDateTime(todate);
                // com.Parameters["@validtill"].Value = Convert.ToDateTime(validtill);
            }

            objSqlCommand.Parameters.Add("@fromdate", SqlDbType.DateTime);
            if (fromdate == "" || fromdate == null)//|| validtill == "undefined/undefined/")
            {
                objSqlCommand.Parameters["@fromdate"].Value = System.DBNull.Value;
            }
            else
            {
                objSqlCommand.Parameters["@fromdate"].Value = Convert.ToDateTime(fromdate);
            }
            //objSqlCommand.Parameters.Add("@flag", SqlDbType.VarChar);
            //objSqlCommand.Parameters["@flag"].Value =flag;

            objSqlDataAdapter.SelectCommand = objSqlCommand;
            objSqlDataAdapter.Fill(objDataSet);

            return objDataSet;

        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            CloseConnection(ref objSqlConnection);
        }

    }


      //public DataSet showchk(string compcode, string userid, string retcode)
      //  {
      //      sqlcon = GetConnection();
      //      try
      //      {
      //          sqlcon.Open();
      //          sqlcom = GetCommand("showagencypay",ref sqlcon);
      //          sqlcom.CommandType = CommandType.StoredProcedure;
				
      //          sqlcom.Parameters.Add("@compcode",SqlDbType.VarChar);
      //          sqlcom.Parameters["@compcode"].Value = compcode;

      //          sqlcom.Parameters.Add("@userid",SqlDbType.VarChar);
      //          sqlcom.Parameters["@userid"].Value = userid;

      //          sqlcom.Parameters.Add("@retcode",SqlDbType.VarChar);
      //          sqlcom.Parameters["@retcode"].Value = retcode;

      //          SqlDataAdapter da = new SqlDataAdapter(sqlcom);
      //          da.Fill(ds);
      //          return ds;
				
      //      }
      //      catch(Exception ex)	{throw(ex);}
      //      finally
      //      {CloseConnection(ref sqlcon);}
      //  }


    public DataSet showchk(string compcode, string userid, string retcode)
    {

        sqlcon = GetConnection();
        try
        {
            sqlcon.Open();
            sqlcom = GetCommand("showchk", ref sqlcon);
            sqlcom.CommandType = CommandType.StoredProcedure;

            sqlcom.Parameters.Add("@compcode", SqlDbType.VarChar);
            sqlcom.Parameters["@compcode"].Value = compcode;

            sqlcom.Parameters.Add("@userid", SqlDbType.VarChar);
            sqlcom.Parameters["@userid"].Value = userid;

            sqlcom.Parameters.Add("@retcode", SqlDbType.VarChar);
            sqlcom.Parameters["@retcode"].Value = retcode;

            SqlDataAdapter da = new SqlDataAdapter(sqlcom);
            da.Fill(ds);
            return ds;

        }
        catch (Exception ex) { throw (ex); }
        finally
        { CloseConnection(ref sqlcon); }
    }


    public DataSet agcode(string compcode, string name, string unit, string cdp, string extra1, string extra2, string extra3, string extra4, string extra5)
    {
        SqlConnection objSqlConnection;
        SqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("ad_agency_bind_p", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            objSqlCommand.Parameters.Add("@pcompcode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@pcompcode"].Value = compcode;

            objSqlCommand.Parameters.Add("@pag_name", SqlDbType.VarChar);
            objSqlCommand.Parameters["@pag_name"].Value = name;

            objSqlCommand.Parameters.Add("@puserid", SqlDbType.VarChar);
            objSqlCommand.Parameters["@puserid"].Value = cdp;

            objSqlCommand.Parameters.Add("@pdateformat", SqlDbType.VarChar);
            objSqlCommand.Parameters["@pdateformat"].Value = unit;

            objSqlCommand.Parameters.Add("@pextra1", SqlDbType.VarChar);
            objSqlCommand.Parameters["@pextra1"].Value = System.DBNull.Value;

            objSqlCommand.Parameters.Add("@pextra2", SqlDbType.VarChar);
            objSqlCommand.Parameters["@pextra2"].Value = System.DBNull.Value;

            objSqlCommand.Parameters.Add("@pextra3", SqlDbType.VarChar);
            objSqlCommand.Parameters["@pextra3"].Value = System.DBNull.Value;

            objSqlCommand.Parameters.Add("@pextra4", SqlDbType.VarChar);
            objSqlCommand.Parameters["@pextra4"].Value = System.DBNull.Value;

            objSqlCommand.Parameters.Add("@pextra5", SqlDbType.VarChar);
            objSqlCommand.Parameters["@pextra5"].Value = System.DBNull.Value;

            objSqlDataAdapter.SelectCommand = objSqlCommand;
            objSqlDataAdapter.Fill(objDataSet);

            return objDataSet;

        }
        catch (Exception ex) { throw (ex); }
        finally
        { CloseConnection(ref objSqlConnection); }
    }

    public DataSet chkretainercode(string str)
    {
        SqlConnection objSqlConnection;
        SqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("chkretainername", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            objSqlCommand.Parameters.Add("@str", SqlDbType.VarChar);
            objSqlCommand.Parameters["@str"].Value = str;

            objSqlCommand.Parameters.Add("@cod", SqlDbType.VarChar);
            objSqlCommand.Parameters["@cod"].Value = str;


            objSqlDataAdapter.SelectCommand = objSqlCommand;
            objSqlDataAdapter.Fill(objDataSet);

            return objDataSet;

        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            CloseConnection(ref objSqlConnection);
        }
    }


    public DataSet chkretainercodemod(string strcode, string strname)
    {
        SqlConnection objSqlConnection;
        SqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("chkretainernamemod", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            objSqlCommand.Parameters.Add("@strname", SqlDbType.VarChar);
            objSqlCommand.Parameters["@strname"].Value = strname;

            objSqlCommand.Parameters.Add("@strcode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@strcode"].Value = strcode;


            objSqlDataAdapter.SelectCommand = objSqlCommand;
            objSqlDataAdapter.Fill(objDataSet);

            return objDataSet;

        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            CloseConnection(ref objSqlConnection);
        }
    }

    public DataSet chkretainerusercode(string strcode, string strname)
    {
        SqlConnection objSqlConnection;
        SqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("chkretaineruser", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            objSqlCommand.Parameters.Add("@strname", SqlDbType.VarChar);
            objSqlCommand.Parameters["@strname"].Value = strname;

            objSqlCommand.Parameters.Add("@strcode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@strcode"].Value = strcode;


            objSqlDataAdapter.SelectCommand = objSqlCommand;
            objSqlDataAdapter.Fill(objDataSet);

            return objDataSet;

        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            CloseConnection(ref objSqlConnection);
        }
    }

    public DataSet addcitydist(string cityname, string pcompcode)
    {
        SqlConnection objSqlConnection;
        SqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            //objSqlCommand = GetCommand("filldiststate", ref objSqlConnection);
            // saurabh change
            objSqlCommand = GetCommand("retaineraddregion", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            objSqlCommand.Parameters.Add("@regioncode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@regioncode"].Value = cityname;

            objSqlCommand.Parameters.Add("@pcompcode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@pcompcode"].Value = pcompcode;

            
            objSqlDataAdapter.SelectCommand = objSqlCommand;
            objSqlDataAdapter.Fill(objDataSet);

            return objDataSet;

        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            CloseConnection(ref objSqlConnection);
        }
    }



    public DataSet addpubcent(string compcode)
    {
        SqlConnection objSqlConnection;
        SqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("Bind_PubCentName", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;



            objSqlCommand.Parameters.Add("@comp_code", SqlDbType.VarChar);
            objSqlCommand.Parameters["@comp_code"].Value = compcode;

            objSqlDataAdapter.SelectCommand = objSqlCommand;
            objSqlDataAdapter.Fill(objDataSet);

            return objDataSet;

        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            CloseConnection(ref objSqlConnection);
        }

    }


    public DataSet addedition(string pubname)
    {
       
        SqlConnection objSqlConnection;
        SqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("fill_editionalias", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;
  

            objSqlCommand.Parameters.Add("@pubname", SqlDbType.VarChar);
            objSqlCommand.Parameters["@pubname"].Value = pubname;

            objSqlDataAdapter.SelectCommand = objSqlCommand;
            objSqlDataAdapter.Fill(objDataSet);

            return objDataSet;

        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            CloseConnection(ref objSqlConnection);
        }

    }



    public DataSet countedition(string editioncode)
    {

        SqlConnection objSqlConnection;
        SqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("getsupplement", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;


            objSqlCommand.Parameters.Add("@editioncode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@editioncode"].Value = editioncode;

            objSqlDataAdapter.SelectCommand = objSqlCommand;
            objSqlDataAdapter.Fill(objDataSet);

            return objDataSet;

        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            CloseConnection(ref objSqlConnection);
        }

    }

		/*Retainer Status Detail coding ends*/

    public DataSet addrepname(string compcode)
    {
        SqlConnection objSqlConnection;
        SqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("getrepname", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@compcode"].Value = compcode;

            objSqlDataAdapter.SelectCommand = objSqlCommand;
            objSqlDataAdapter.Fill(objDataSet);

            return objDataSet;

        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            CloseConnection(ref objSqlConnection);
        }
    }

    public DataSet retcomcheck(string compcode, string retcode, string todate, string fromdate, string dateformat, string codepass, string txtframt, string txttoamt)
    {
        SqlConnection objSqlConnection;
        SqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("retcomchk", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@compcode"].Value = compcode;

            objSqlCommand.Parameters.Add("@retcode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@retcode"].Value = retcode;

            //objSqlCommand.Parameters.Add("@todate", SqlDbType.DateTime);
            //if (todate == "" || todate == null)//|| validtill == "undefined/undefined/")
            //{
            //    objSqlCommand.Parameters["@todate"].Value = System.DBNull.Value;
            //}
            //else
            //{
            //    objSqlCommand.Parameters["@todate"].Value = Convert.ToDateTime(todate);
            //    // com.Parameters["@validtill"].Value = Convert.ToDateTime(validtill);
            //}


            //objSqlCommand.Parameters.Add("@fromdate", SqlDbType.DateTime);
            //if (fromdate == "" || fromdate == null)//|| validtill == "undefined/undefined/")
            //{
            //    objSqlCommand.Parameters["@fromdate"].Value = System.DBNull.Value;
            //}
            //else
            //{
            //    objSqlCommand.Parameters["@fromdate"].Value = Convert.ToDateTime(fromdate);
            //}

            objSqlCommand.Parameters.Add("@fromdate", SqlDbType.VarChar);
            objSqlCommand.Parameters["@fromdate"].Value = fromdate;

            objSqlCommand.Parameters.Add("@todate", SqlDbType.VarChar);
            objSqlCommand.Parameters["@todate"].Value = todate;

            objSqlCommand.Parameters.Add("@date", SqlDbType.VarChar);
            objSqlCommand.Parameters["@date"].Value = dateformat;

            objSqlCommand.Parameters.Add("@codepass", SqlDbType.VarChar);
            objSqlCommand.Parameters["@codepass"].Value = codepass;

            objSqlCommand.Parameters.Add("@txtframt", SqlDbType.VarChar);
            objSqlCommand.Parameters["@txtframt"].Value = txtframt;

            objSqlCommand.Parameters.Add("@txttoamt", SqlDbType.VarChar);
            objSqlCommand.Parameters["@txttoamt"].Value = txttoamt;

            objSqlDataAdapter.SelectCommand = objSqlCommand;
            objSqlDataAdapter.Fill(objDataSet);

            return objDataSet;

        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            CloseConnection(ref objSqlConnection);
        }

    }


    //================================================Ad for Retainer Slab Pop Up================================================//
    //-----------------------------------------------------------------------------------------------------------------------------//
    public DataSet retainerstatusbind_b(string retcode, string userid, string compcode, string dateformat,string commid)
    {
        SqlConnection objSqlConnection;
        SqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("sp_retstatusbind_b", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@compcode"].Value = compcode;

            objSqlCommand.Parameters.Add("@retcode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@retcode"].Value = retcode;

            objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
            objSqlCommand.Parameters["@userid"].Value = userid;

            objSqlCommand.Parameters.Add("@commid", SqlDbType.VarChar);
            objSqlCommand.Parameters["@commid"].Value = commid;

            objSqlDataAdapter.SelectCommand = objSqlCommand;
            objSqlDataAdapter.Fill(objDataSet);

            return objDataSet;

        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            CloseConnection(ref objSqlConnection);
        }

    }

    public DataSet selectretslab(string retcode, string compcode, string userid, string code11)
    {
        SqlConnection objSqlConnection;
        SqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("retselectslab", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@compcode"].Value = compcode;

            objSqlCommand.Parameters.Add("@retcode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@retcode"].Value = retcode;

            objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
            objSqlCommand.Parameters["@userid"].Value = userid;

            objSqlCommand.Parameters.Add("@code11", SqlDbType.VarChar);
            objSqlCommand.Parameters["@code11"].Value = code11;

            objSqlDataAdapter.SelectCommand = objSqlCommand;
            objSqlDataAdapter.Fill(objDataSet);

            return objDataSet;

        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            CloseConnection(ref objSqlConnection);
        }

    }

    public DataSet Ret_GetSlabupdate(string retcode, string compcode, string userid, string common, string commrate, string todays, string fromdays, string code, string agency_type)
    {
        SqlConnection objSqlConnection;
        SqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("updateretstatus_slab", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@compcode"].Value = compcode;

            objSqlCommand.Parameters.Add("@retcode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@retcode"].Value = retcode;

            objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
            objSqlCommand.Parameters["@userid"].Value = userid;

            objSqlCommand.Parameters.Add("@code", SqlDbType.VarChar);
            objSqlCommand.Parameters["@code"].Value = code;

            objSqlCommand.Parameters.Add("@common", SqlDbType.VarChar);
            objSqlCommand.Parameters["@common"].Value = common;

            objSqlCommand.Parameters.Add("@commrate", SqlDbType.VarChar);
            objSqlCommand.Parameters["@commrate"].Value = commrate;

            objSqlCommand.Parameters.Add("@fromdays", SqlDbType.VarChar);
            objSqlCommand.Parameters["@fromdays"].Value = fromdays;

            objSqlCommand.Parameters.Add("@todays", SqlDbType.VarChar);
            objSqlCommand.Parameters["@todays"].Value = todays;


            objSqlCommand.Parameters.Add("@agency_type", SqlDbType.VarChar);
            objSqlCommand.Parameters["@agency_type"].Value = agency_type;
           
            objSqlDataAdapter.SelectCommand = objSqlCommand;
            objSqlDataAdapter.Fill(objDataSet);

            return objDataSet;

        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            CloseConnection(ref objSqlConnection);
        }
    }

    public DataSet insertretstatus_slab(string compcode, string userid, string retcode, string fromdays, string todays, string drpcommon, string commrate, string commid, string agency_type)
    {
        SqlConnection objSqlConnection;
        SqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("insertretstatus_slab", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@compcode"].Value = compcode;

            objSqlCommand.Parameters.Add("@retcode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@retcode"].Value = retcode;

            objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
            objSqlCommand.Parameters["@userid"].Value = userid;

            

            objSqlCommand.Parameters.Add("@drpcommon", SqlDbType.VarChar);
            objSqlCommand.Parameters["@drpcommon"].Value = drpcommon;

            objSqlCommand.Parameters.Add("@commrate", SqlDbType.VarChar);
            objSqlCommand.Parameters["@commrate"].Value = commrate;

            objSqlCommand.Parameters.Add("@fromdays", SqlDbType.VarChar);
            objSqlCommand.Parameters["@fromdays"].Value = fromdays;

            objSqlCommand.Parameters.Add("@todays", SqlDbType.VarChar);
            objSqlCommand.Parameters["@todays"].Value = todays;

            objSqlCommand.Parameters.Add("@P_COMM_TARGET_ID", SqlDbType.VarChar);
            objSqlCommand.Parameters["@P_COMM_TARGET_ID"].Value = commid;

            objSqlCommand.Parameters.Add("@agency_type", SqlDbType.VarChar);
            objSqlCommand.Parameters["@agency_type"].Value = agency_type;

          
            objSqlDataAdapter.SelectCommand = objSqlCommand;
            objSqlDataAdapter.Fill(objDataSet);

            return objDataSet;

        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            CloseConnection(ref objSqlConnection);
        }

    }

    public DataSet Ret_StatusDeleteSlab(string userid, string compcode, string retcode, string enlncode)
    {

        SqlConnection objSqlConnection;
        SqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("retdeleteslab", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@compcode"].Value = compcode;

            objSqlCommand.Parameters.Add("@retcode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@retcode"].Value = retcode;

            objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
            objSqlCommand.Parameters["@userid"].Value = userid;

            objSqlCommand.Parameters.Add("@enlncode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@enlncode"].Value = enlncode;

            objSqlDataAdapter.SelectCommand = objSqlCommand;
            objSqlDataAdapter.Fill(objDataSet);

            return objDataSet;

        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            CloseConnection(ref objSqlConnection);
        }
    }


    public DataSet retslabcheck(string compcode, string userid, string retcode, string todays, string fromdays, string codepass, string agency_type)
    {
        SqlConnection objSqlConnection;
        SqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("retcheckslab", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@compcode"].Value = compcode;

            objSqlCommand.Parameters.Add("@retcode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@retcode"].Value = retcode;

            objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
            objSqlCommand.Parameters["@userid"].Value = userid;

            objSqlCommand.Parameters.Add("@fromdays", SqlDbType.VarChar);
            objSqlCommand.Parameters["@fromdays"].Value = fromdays;

            objSqlCommand.Parameters.Add("@todays", SqlDbType.VarChar);
            objSqlCommand.Parameters["@todays"].Value = todays;


            objSqlCommand.Parameters.Add("@agency_type", SqlDbType.VarChar);
            objSqlCommand.Parameters["@agency_type"].Value = agency_type;

            objSqlDataAdapter.SelectCommand = objSqlCommand;
            objSqlDataAdapter.Fill(objDataSet);

            return objDataSet;

        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            CloseConnection(ref objSqlConnection);
        }
    }
    public DataSet Retainerchkname(string compcode, string Retname)
    {
        SqlConnection objSqlConnection;
        SqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("Retchknameforbook", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@compcode"].Value = compcode;

            objSqlCommand.Parameters.Add("@Retname", SqlDbType.VarChar);
            objSqlCommand.Parameters["@Retname"].Value = Retname;

            objSqlDataAdapter.SelectCommand = objSqlCommand;
            objSqlDataAdapter.Fill(objDataSet);

            return objDataSet;

        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            CloseConnection(ref objSqlConnection);
        }
    }
//=========************************ To save Retainer Comm Structure *****************************================//
    public DataSet insertretcommstructure(string compcode, string userid, string retcode,string PTEAM_CODE,string PADCTG_CODE,string PFROM_TGT,string PTO_TGT,string PCUST_TYPE,string PAD_TYPE,string PPUB_TYPE,string PPUBL_CODE,string PCOMM_TARGET_ID)
    {
        SqlConnection objSqlConnection;
        SqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("AD_RETAIN_COMM_TARGET_INS", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            objSqlCommand.Parameters.Add("@PCOMP_CODE", SqlDbType.VarChar);
            objSqlCommand.Parameters["@PCOMP_CODE"].Value = compcode;

            objSqlCommand.Parameters.Add("@PRETAIN_CODE", SqlDbType.VarChar);
            objSqlCommand.Parameters["@PRETAIN_CODE"].Value = retcode;

            objSqlCommand.Parameters.Add("@PCREATED_BY", SqlDbType.VarChar);
            objSqlCommand.Parameters["@PCREATED_BY"].Value = userid;

            objSqlCommand.Parameters.Add("@PTEAM_CODE", SqlDbType.VarChar);
            objSqlCommand.Parameters["@PTEAM_CODE"].Value = PTEAM_CODE;

            objSqlCommand.Parameters.Add("@PADCTG_CODE", SqlDbType.VarChar);
            objSqlCommand.Parameters["@PADCTG_CODE"].Value = PADCTG_CODE;

            objSqlCommand.Parameters.Add("@PFROM_TGT", SqlDbType.VarChar);
            objSqlCommand.Parameters["@PFROM_TGT"].Value = PFROM_TGT;  

            objSqlCommand.Parameters.Add("@PTO_TGT", SqlDbType.VarChar);
            objSqlCommand.Parameters["@PTO_TGT"].Value = PTO_TGT;

            objSqlCommand.Parameters.Add("@PCUST_TYPE", SqlDbType.VarChar);
            objSqlCommand.Parameters["@PCUST_TYPE"].Value = PCUST_TYPE;

            objSqlCommand.Parameters.Add("@PAD_TYPE", SqlDbType.VarChar);
            objSqlCommand.Parameters["@PAD_TYPE"].Value = PAD_TYPE;

            objSqlCommand.Parameters.Add("@PPUB_TYPE", SqlDbType.VarChar);
            objSqlCommand.Parameters["@PPUB_TYPE"].Value = PPUB_TYPE;

            objSqlCommand.Parameters.Add("@PPUBL_CODE", SqlDbType.VarChar);
            objSqlCommand.Parameters["@PPUBL_CODE"].Value = PPUBL_CODE;

            objSqlCommand.Parameters.Add("@PCOMM_TARGET_ID", SqlDbType.VarChar);
            objSqlCommand.Parameters["@PCOMM_TARGET_ID"].Value = PCOMM_TARGET_ID;

            objSqlCommand.Parameters.Add("@PCREATED_DT", SqlDbType.VarChar);
            objSqlCommand.Parameters["@PCREATED_DT"].Value = System.DBNull.Value;

            objSqlCommand.Parameters.Add("@PUPDATED_BY", SqlDbType.VarChar);
            objSqlCommand.Parameters["@PUPDATED_BY"].Value = System.DBNull.Value;

            objSqlCommand.Parameters.Add("@PUPDATED_DT", SqlDbType.VarChar);
            objSqlCommand.Parameters["@PUPDATED_DT"].Value = System.DBNull.Value;

            objSqlCommand.Parameters.Add("@PDML_TYPE", SqlDbType.VarChar);
            objSqlCommand.Parameters["@PDML_TYPE"].Value = "I";

            objSqlDataAdapter.SelectCommand = objSqlCommand;
            objSqlDataAdapter.Fill(objDataSet);

            return objDataSet;

        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            CloseConnection(ref objSqlConnection);
        }

    }
    //================================================Ad for Retainer structure Slab Pop Up================================================//
    //-----------------------------------------------------------------------------------------------------------------------------//
    public DataSet retainerstructuresbind_b(string retcode, string userid, string compcode, string dateformat)
    {
        SqlConnection objSqlConnection;
        SqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("AD_RETAIN_COMM_TARGET_BIND", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@compcode"].Value = compcode;

            objSqlCommand.Parameters.Add("@retcode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@retcode"].Value = retcode;

            objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
            objSqlCommand.Parameters["@userid"].Value = userid;

            objSqlDataAdapter.SelectCommand = objSqlCommand;
            objSqlDataAdapter.Fill(objDataSet);

            return objDataSet;

        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            CloseConnection(ref objSqlConnection);
        }

    }

    public DataSet selectretstruct(string retcode, string compcode, string userid, string code11)
    {
        SqlConnection objSqlConnection;
        SqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("retselectstructslab", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@compcode"].Value = compcode;

            objSqlCommand.Parameters.Add("@retcode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@retcode"].Value = retcode;

            objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
            objSqlCommand.Parameters["@userid"].Value = userid;

            objSqlCommand.Parameters.Add("@code11", SqlDbType.VarChar);
            objSqlCommand.Parameters["@code11"].Value = code11;

            objSqlDataAdapter.SelectCommand = objSqlCommand;
            objSqlDataAdapter.Fill(objDataSet);

            return objDataSet;

        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            CloseConnection(ref objSqlConnection);
        }

    }
    //=========************************ To Update Retainer Comm Structure *****************************================//
    public DataSet Ret_GetStructSlabupdate(string compcode, string userid, string retcode, string PTEAM_CODE, string PADCTG_CODE, string PFROM_TGT, string PTO_TGT, string PCUST_TYPE, string PAD_TYPE, string PPUB_TYPE, string PPUBL_CODE, string PCOMM_TARGET_ID)
    {
        SqlConnection objSqlConnection;
        SqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("AD_RETAIN_COMM_TARGET_INS", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            objSqlCommand.Parameters.Add("@PCOMP_CODE", SqlDbType.VarChar);
            objSqlCommand.Parameters["@PCOMP_CODE"].Value = compcode;

            objSqlCommand.Parameters.Add("@PRETAIN_CODE", SqlDbType.VarChar);
            objSqlCommand.Parameters["@PRETAIN_CODE"].Value = retcode;

            objSqlCommand.Parameters.Add("@PCREATED_BY", SqlDbType.VarChar);
            objSqlCommand.Parameters["@PCREATED_BY"].Value = System.DBNull.Value;

            objSqlCommand.Parameters.Add("@PTEAM_CODE", SqlDbType.VarChar);
            objSqlCommand.Parameters["@PTEAM_CODE"].Value = PTEAM_CODE;

            objSqlCommand.Parameters.Add("@PADCTG_CODE", SqlDbType.VarChar);
            objSqlCommand.Parameters["@PADCTG_CODE"].Value = PADCTG_CODE;

            objSqlCommand.Parameters.Add("@PFROM_TGT", SqlDbType.VarChar);
            objSqlCommand.Parameters["@PFROM_TGT"].Value = PFROM_TGT;

            objSqlCommand.Parameters.Add("@PTO_TGT", SqlDbType.VarChar);
            objSqlCommand.Parameters["@PTO_TGT"].Value = PTO_TGT;

            objSqlCommand.Parameters.Add("@PCUST_TYPE", SqlDbType.VarChar);
            objSqlCommand.Parameters["@PCUST_TYPE"].Value = PCUST_TYPE;

            objSqlCommand.Parameters.Add("@PAD_TYPE", SqlDbType.VarChar);
            objSqlCommand.Parameters["@PAD_TYPE"].Value = PAD_TYPE;

            objSqlCommand.Parameters.Add("@PPUB_TYPE", SqlDbType.VarChar);
            objSqlCommand.Parameters["@PPUB_TYPE"].Value = PPUB_TYPE;

            objSqlCommand.Parameters.Add("@PPUBL_CODE", SqlDbType.VarChar);
            objSqlCommand.Parameters["@PPUBL_CODE"].Value = PPUBL_CODE;

            objSqlCommand.Parameters.Add("@PCOMM_TARGET_ID", SqlDbType.VarChar);
            objSqlCommand.Parameters["@PCOMM_TARGET_ID"].Value = PCOMM_TARGET_ID;

            objSqlCommand.Parameters.Add("@PCREATED_DT", SqlDbType.VarChar);
            objSqlCommand.Parameters["@PCREATED_DT"].Value = System.DBNull.Value;

            objSqlCommand.Parameters.Add("@PUPDATED_BY", SqlDbType.VarChar);
            objSqlCommand.Parameters["@PUPDATED_BY"].Value = userid;

            objSqlCommand.Parameters.Add("@PUPDATED_DT", SqlDbType.VarChar);
            objSqlCommand.Parameters["@PUPDATED_DT"].Value = System.DBNull.Value;

            objSqlCommand.Parameters.Add("@PDML_TYPE", SqlDbType.VarChar);
            objSqlCommand.Parameters["@PDML_TYPE"].Value = "U";

            objSqlDataAdapter.SelectCommand = objSqlCommand;
            objSqlDataAdapter.Fill(objDataSet);

            return objDataSet;

        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            CloseConnection(ref objSqlConnection);
        }

    }
    /*public DataSet insertretstatus_slab(string compcode, string userid, string retcode, string fromdays, string todays, string drpcommon, string commrate)
    {
        SqlConnection objSqlConnection;
        SqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("insertretstatus_slab", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@compcode"].Value = compcode;

            objSqlCommand.Parameters.Add("@retcode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@retcode"].Value = retcode;

            objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
            objSqlCommand.Parameters["@userid"].Value = userid;



            objSqlCommand.Parameters.Add("@drpcommon", SqlDbType.VarChar);
            objSqlCommand.Parameters["@drpcommon"].Value = drpcommon;

            objSqlCommand.Parameters.Add("@commrate", SqlDbType.VarChar);
            objSqlCommand.Parameters["@commrate"].Value = commrate;

            objSqlCommand.Parameters.Add("@fromdays", SqlDbType.VarChar);
            objSqlCommand.Parameters["@fromdays"].Value = fromdays;

            objSqlCommand.Parameters.Add("@todays", SqlDbType.VarChar);
            objSqlCommand.Parameters["@todays"].Value = todays;


            objSqlDataAdapter.SelectCommand = objSqlCommand;
            objSqlDataAdapter.Fill(objDataSet);

            return objDataSet;

        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            CloseConnection(ref objSqlConnection);
        }

    }*/
//==============================================*****Insert Retainer additional Slab **********======================//
    public DataSet insertretaddcomm(string compcode, string userid, string retcode, string  lstpub,string minpub,string publication,string commid)
    {

        SqlConnection objSqlConnection;
        SqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("AD_RETAIN_ADD_COMM_TARGET_INS", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            objSqlCommand.Parameters.Add("@PCOMP_CODE", SqlDbType.VarChar);
            objSqlCommand.Parameters["@PCOMP_CODE"].Value = compcode;

            objSqlCommand.Parameters.Add("@PRETAIN_CODE", SqlDbType.VarChar);
            objSqlCommand.Parameters["@PRETAIN_CODE"].Value = retcode;

            objSqlCommand.Parameters.Add("@PCREATED_BY", SqlDbType.VarChar);
            objSqlCommand.Parameters["@PCREATED_BY"].Value = userid;

            objSqlCommand.Parameters.Add("@PPUBL_CODE", SqlDbType.VarChar);
            objSqlCommand.Parameters["@PPUBL_CODE"].Value = lstpub;

            objSqlCommand.Parameters.Add("@PNO_OF_PUBL", SqlDbType.VarChar);
            objSqlCommand.Parameters["@PNO_OF_PUBL"].Value = minpub;

            objSqlCommand.Parameters.Add("@PADCOMM_PER", SqlDbType.VarChar);
            objSqlCommand.Parameters["@PADCOMM_PER"].Value = publication;

            objSqlCommand.Parameters.Add("@PCOMM_TYPE", SqlDbType.VarChar);
            objSqlCommand.Parameters["@PCOMM_TYPE"].Value = System.DBNull.Value;

            objSqlCommand.Parameters.Add("@PCOMM_TARGET_ID", SqlDbType.VarChar);
            objSqlCommand.Parameters["@PCOMM_TARGET_ID"].Value = commid;

            objSqlCommand.Parameters.Add("@PCREATED_DT", SqlDbType.VarChar);
            objSqlCommand.Parameters["@PCREATED_DT"].Value = System.DBNull.Value;

            objSqlCommand.Parameters.Add("@PUPDATED_BY", SqlDbType.VarChar);
            objSqlCommand.Parameters["@PUPDATED_BY"].Value = System.DBNull.Value;

            objSqlCommand.Parameters.Add("@PUPDATED_DT", SqlDbType.VarChar);
            objSqlCommand.Parameters["@PUPDATED_DT"].Value = System.DBNull.Value;

            objSqlCommand.Parameters.Add("@PADD_COMM_ID", SqlDbType.VarChar);
            objSqlCommand.Parameters["@PADD_COMM_ID"].Value = "1";

            objSqlCommand.Parameters.Add("@PDML_TYPE", SqlDbType.VarChar);
            objSqlCommand.Parameters["@PDML_TYPE"].Value = "I";

            objSqlDataAdapter.SelectCommand = objSqlCommand;
            objSqlDataAdapter.Fill(objDataSet);

            return objDataSet;

        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            CloseConnection(ref objSqlConnection);
        }
    }
    //==============================================***** Update Retainer additional Slab **********======================//
    public DataSet AddSlabupdate(string compcode, string userid, string retcode, string lstpub, string minpub, string publication, string targetid)
    {

        SqlConnection objSqlConnection;
        SqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("AD_RETAIN_ADD_COMM_TARGET_INS", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            objSqlCommand.Parameters.Add("@PCOMP_CODE", SqlDbType.VarChar);
            objSqlCommand.Parameters["@PCOMP_CODE"].Value = compcode;

            objSqlCommand.Parameters.Add("@PRETAIN_CODE", SqlDbType.VarChar);
            objSqlCommand.Parameters["@PRETAIN_CODE"].Value = retcode;

            objSqlCommand.Parameters.Add("@PCREATED_BY", SqlDbType.VarChar);
            objSqlCommand.Parameters["@PCREATED_BY"].Value = System.DBNull.Value;

            objSqlCommand.Parameters.Add("@PPUBL_CODE", SqlDbType.VarChar);
            objSqlCommand.Parameters["@PPUBL_CODE"].Value = lstpub;

            objSqlCommand.Parameters.Add("@PNO_OF_PUBL", SqlDbType.VarChar);
            objSqlCommand.Parameters["@PNO_OF_PUBL"].Value = minpub;

            objSqlCommand.Parameters.Add("@PADCOMM_PER", SqlDbType.VarChar);
            objSqlCommand.Parameters["@PADCOMM_PER"].Value = publication;

            objSqlCommand.Parameters.Add("@PCOMM_TYPE", SqlDbType.VarChar);
            objSqlCommand.Parameters["@PCOMM_TYPE"].Value = System.DBNull.Value;

            objSqlCommand.Parameters.Add("@PCOMM_TARGET_ID", SqlDbType.VarChar);
            objSqlCommand.Parameters["@PCOMM_TARGET_ID"].Value = "1";

            objSqlCommand.Parameters.Add("@PCREATED_DT", SqlDbType.VarChar);
            objSqlCommand.Parameters["@PCREATED_DT"].Value = System.DBNull.Value;

            objSqlCommand.Parameters.Add("@PUPDATED_BY", SqlDbType.VarChar);
            objSqlCommand.Parameters["@PUPDATED_BY"].Value = userid;

            objSqlCommand.Parameters.Add("@PUPDATED_DT", SqlDbType.VarChar);
            objSqlCommand.Parameters["@PUPDATED_DT"].Value = System.DBNull.Value;

            objSqlCommand.Parameters.Add("@PADD_COMM_ID", SqlDbType.VarChar);
            objSqlCommand.Parameters["@PADD_COMM_ID"].Value = targetid;

            objSqlCommand.Parameters.Add("@PDML_TYPE", SqlDbType.VarChar);
            objSqlCommand.Parameters["@PDML_TYPE"].Value = "U";

            objSqlDataAdapter.SelectCommand = objSqlCommand;
            objSqlDataAdapter.Fill(objDataSet);

            return objDataSet;

        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            CloseConnection(ref objSqlConnection);
        }
    }

    //==============================================***** Delete Retainer additional Slab **********======================//
    public DataSet Ret_AddDelete(string compcode, string userid, string retcode, string targetid)
    {

        SqlConnection objSqlConnection;
        SqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("AD_RETAIN_ADD_COMM_TARGET_INS", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            objSqlCommand.Parameters.Add("@PCOMP_CODE", SqlDbType.VarChar);
            objSqlCommand.Parameters["@PCOMP_CODE"].Value = compcode;

            objSqlCommand.Parameters.Add("@PRETAIN_CODE", SqlDbType.VarChar);
            objSqlCommand.Parameters["@PRETAIN_CODE"].Value = retcode;

            objSqlCommand.Parameters.Add("@PCREATED_BY", SqlDbType.VarChar);
            objSqlCommand.Parameters["@PCREATED_BY"].Value = System.DBNull.Value;

            objSqlCommand.Parameters.Add("@PPUBL_CODE", SqlDbType.VarChar);
            objSqlCommand.Parameters["@PPUBL_CODE"].Value = System.DBNull.Value;

            objSqlCommand.Parameters.Add("@PNO_OF_PUBL", SqlDbType.VarChar);
            objSqlCommand.Parameters["@PNO_OF_PUBL"].Value = System.DBNull.Value;

            objSqlCommand.Parameters.Add("@PADCOMM_PER", SqlDbType.VarChar);
            objSqlCommand.Parameters["@PADCOMM_PER"].Value = System.DBNull.Value;

            objSqlCommand.Parameters.Add("@PCOMM_TYPE", SqlDbType.VarChar);
            objSqlCommand.Parameters["@PCOMM_TYPE"].Value = System.DBNull.Value;

            objSqlCommand.Parameters.Add("@PCOMM_TARGET_ID", SqlDbType.VarChar);
            objSqlCommand.Parameters["@PCOMM_TARGET_ID"].Value = "1";

            objSqlCommand.Parameters.Add("@PCREATED_DT", SqlDbType.VarChar);
            objSqlCommand.Parameters["@PCREATED_DT"].Value = System.DBNull.Value;

            objSqlCommand.Parameters.Add("@PUPDATED_BY", SqlDbType.VarChar);
            objSqlCommand.Parameters["@PUPDATED_BY"].Value = System.DBNull.Value;

            objSqlCommand.Parameters.Add("@PUPDATED_DT", SqlDbType.VarChar);
            objSqlCommand.Parameters["@PUPDATED_DT"].Value = System.DBNull.Value;

            objSqlCommand.Parameters.Add("@PADD_COMM_ID", SqlDbType.VarChar);
            objSqlCommand.Parameters["@PADD_COMM_ID"].Value = targetid;

            objSqlCommand.Parameters.Add("@PDML_TYPE", SqlDbType.VarChar);
            objSqlCommand.Parameters["@PDML_TYPE"].Value = "D";

            objSqlDataAdapter.SelectCommand = objSqlCommand;
            objSqlDataAdapter.Fill(objDataSet);

            return objDataSet;

        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            CloseConnection(ref objSqlConnection);
        }
    }
   //-----------------------------------------------------------------------------------------------------------------------------//
    public DataSet retaineraddbind_b(string retcode, string userid, string compcode, string dateformat, string commid)
    {
        SqlConnection objSqlConnection;
        SqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("retaddstatusbind", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@compcode"].Value = compcode;

            objSqlCommand.Parameters.Add("@retcode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@retcode"].Value = retcode;

            objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
            objSqlCommand.Parameters["@userid"].Value = userid;

            objSqlCommand.Parameters.Add("@commid", SqlDbType.VarChar);
            objSqlCommand.Parameters["@commid"].Value = commid;

            objSqlDataAdapter.SelectCommand = objSqlCommand;
            objSqlDataAdapter.Fill(objDataSet);

            return objDataSet;

        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            CloseConnection(ref objSqlConnection);
        }

    }

    public DataSet selectretaddslab(string retcode, string compcode, string userid, string code11)
    {
        SqlConnection objSqlConnection;
        SqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("retaddselectslab", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@compcode"].Value = compcode;

            objSqlCommand.Parameters.Add("@retcode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@retcode"].Value = retcode;

            objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
            objSqlCommand.Parameters["@userid"].Value = userid;

            objSqlCommand.Parameters.Add("@code11", SqlDbType.VarChar);
            objSqlCommand.Parameters["@code11"].Value = code11;

            objSqlDataAdapter.SelectCommand = objSqlCommand;
            objSqlDataAdapter.Fill(objDataSet);

            return objDataSet;

        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            CloseConnection(ref objSqlConnection);
        }

    }
    //=========************************ To Delete Retainer Comm Structure *****************************================//
    public DataSet delretcommstructure(string compcode, string userid, string retcode, string PCOMM_TARGET_ID)
    {
        SqlConnection objSqlConnection;
        SqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("AD_RETAIN_COMM_TARGET_INS", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            objSqlCommand.Parameters.Add("@PCOMP_CODE", SqlDbType.VarChar);
            objSqlCommand.Parameters["@PCOMP_CODE"].Value = compcode;

            objSqlCommand.Parameters.Add("@PRETAIN_CODE", SqlDbType.VarChar);
            objSqlCommand.Parameters["@PRETAIN_CODE"].Value = retcode;

            objSqlCommand.Parameters.Add("@PCREATED_BY", SqlDbType.VarChar);
            objSqlCommand.Parameters["@PCREATED_BY"].Value = userid;

            objSqlCommand.Parameters.Add("@PTEAM_CODE", SqlDbType.VarChar);
            objSqlCommand.Parameters["@PTEAM_CODE"].Value = System.DBNull.Value;

            objSqlCommand.Parameters.Add("@PADCTG_CODE", SqlDbType.VarChar);
            objSqlCommand.Parameters["@PADCTG_CODE"].Value = System.DBNull.Value;

            objSqlCommand.Parameters.Add("@PFROM_TGT", SqlDbType.VarChar);
            objSqlCommand.Parameters["@PFROM_TGT"].Value = System.DBNull.Value;

            objSqlCommand.Parameters.Add("@PTO_TGT", SqlDbType.VarChar);
            objSqlCommand.Parameters["@PTO_TGT"].Value = System.DBNull.Value;

            objSqlCommand.Parameters.Add("@PCUST_TYPE", SqlDbType.VarChar);
            objSqlCommand.Parameters["@PCUST_TYPE"].Value = System.DBNull.Value;

            objSqlCommand.Parameters.Add("@PAD_TYPE", SqlDbType.VarChar);
            objSqlCommand.Parameters["@PAD_TYPE"].Value = System.DBNull.Value;

            objSqlCommand.Parameters.Add("@PPUB_TYPE", SqlDbType.VarChar);
            objSqlCommand.Parameters["@PPUB_TYPE"].Value = System.DBNull.Value;

            objSqlCommand.Parameters.Add("@PPUBL_CODE", SqlDbType.VarChar);
            objSqlCommand.Parameters["@PPUBL_CODE"].Value = System.DBNull.Value;

            objSqlCommand.Parameters.Add("@PCOMM_TARGET_ID", SqlDbType.VarChar);
            objSqlCommand.Parameters["@PCOMM_TARGET_ID"].Value = PCOMM_TARGET_ID;

            objSqlCommand.Parameters.Add("@PCREATED_DT", SqlDbType.VarChar);
            objSqlCommand.Parameters["@PCREATED_DT"].Value = System.DBNull.Value;

            objSqlCommand.Parameters.Add("@PUPDATED_BY", SqlDbType.VarChar);
            objSqlCommand.Parameters["@PUPDATED_BY"].Value = System.DBNull.Value;

            objSqlCommand.Parameters.Add("@PUPDATED_DT", SqlDbType.VarChar);
            objSqlCommand.Parameters["@PUPDATED_DT"].Value = System.DBNull.Value;

            objSqlCommand.Parameters.Add("@PDML_TYPE", SqlDbType.VarChar);
            objSqlCommand.Parameters["@PDML_TYPE"].Value = "D";

            objSqlDataAdapter.SelectCommand = objSqlCommand;
            objSqlDataAdapter.Fill(objDataSet);

            return objDataSet;

        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            CloseConnection(ref objSqlConnection);
        }

    }

    //=========************************ To Generate code for Retainer Comm Structure *****************************================//
    public DataSet gencodeforslab(string compcode, string userid)
    {
        SqlConnection objSqlConnection;
        SqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("gencodeforcommstruct", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            objSqlCommand.Parameters.Add("@p_compcode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@p_compcode"].Value = compcode;

            objSqlCommand.Parameters.Add("@p_userid", SqlDbType.VarChar);
            objSqlCommand.Parameters["@p_userid"].Value = userid;

            objSqlDataAdapter.SelectCommand = objSqlCommand;
            objSqlDataAdapter.Fill(objDataSet);

            return objDataSet;

        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            CloseConnection(ref objSqlConnection);
        }

    }

    public DataSet advpub(string compcode, string ptype, string publcode, string extra1, string extra2)
    {
        SqlConnection objSqlConnection;
        SqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        SqlDataAdapter objSqlDataAdapter;
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("bind_publ_name", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            objSqlCommand.Parameters.Add("@pcompcode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@pcompcode"].Value = compcode;

            objSqlCommand.Parameters.Add("@ppubtype", SqlDbType.VarChar);
            objSqlCommand.Parameters["@ppubtype"].Value = ptype;

            objSqlCommand.Parameters.Add("@ppublcode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@ppublcode"].Value = publcode;

            objSqlCommand.Parameters.Add("@pexrta1", SqlDbType.VarChar);
            objSqlCommand.Parameters["@pexrta1"].Value = extra1;

            objSqlCommand.Parameters.Add("@pexrta2", SqlDbType.VarChar);
            objSqlCommand.Parameters["@pexrta2"].Value = extra2;

            objSqlDataAdapter = new SqlDataAdapter();
            objSqlDataAdapter.SelectCommand = objSqlCommand;
            objSqlDataAdapter.Fill(objDataSet);
            return objDataSet;


        }
        catch (SqlException objException)
        {
            throw (objException);
        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            CloseConnection(ref objSqlConnection);
        }

    }


    public DataSet bindmaincdp(string compcode, string maincdp, string extra1)
    {

        SqlConnection objSqlConnection;
        SqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("ad_acc_name_bind", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;


            objSqlCommand.Parameters.Add("@pcompcode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@pcompcode"].Value = compcode;

            objSqlCommand.Parameters.Add("@paccname", SqlDbType.VarChar);
            objSqlCommand.Parameters["@paccname"].Value = maincdp;

            objSqlCommand.Parameters.Add("@pextra2", SqlDbType.VarChar);
            objSqlCommand.Parameters["@pextra2"].Value = extra1;

            objSqlDataAdapter.SelectCommand = objSqlCommand;
            objSqlDataAdapter.Fill(objDataSet);

            return objDataSet;

        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            CloseConnection(ref objSqlConnection);
        }

    }

    public DataSet bind_agname(string pcomp_code, string pcity_code, string pagcode, string pagsubcode, string pextra1, string pextra2)
    {
        SqlConnection objSqlConnection;
        SqlCommand objSqlCommand=new SqlCommand();
        objSqlConnection = GetConnection();
        SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            string query = "select dbo.get_adagency_name_new('" + pcomp_code + "','" + pcity_code + "','" + pagcode + "','" + pagsubcode + "','" + pextra1 + "','" + pextra2 + "') as AGENCY_NAME";
            objSqlCommand.CommandText = query;
            objSqlCommand.Connection = objSqlConnection;
            objSqlCommand.ExecuteNonQuery();

            objSqlDataAdapter.SelectCommand = objSqlCommand;
            objSqlDataAdapter.Fill(objDataSet);
            return objDataSet;
        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            CloseConnection(ref objSqlConnection);
        }
    }
    


}





}
