using System;
using System.Data;
using System.Data.SqlClient;


namespace NewAdbooking.Classes
{
	/// <summary>
	/// Summary description for AdvertisementMaster.
	/// </summary>
    public class AdvertisementMaster : connection
    {
        public AdvertisementMaster()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataSet AdvTeamDetailSave(string Comp_Code, string Team_Code, string Team_Name, string zone, string userid, string signature, string attachment)
        {
            SqlConnection sqlcon;
            SqlCommand sqlcom;
            sqlcon = GetConnection();
            try
            {
                sqlcon.Open();
                sqlcom = GetCommand("AdvTeamDetailSave", ref sqlcon);
                sqlcom.CommandType = CommandType.StoredProcedure;

                sqlcom.Parameters.Add("@Comp_Code", SqlDbType.VarChar);
                sqlcom.Parameters["@Comp_Code"].Value = Comp_Code;

                sqlcom.Parameters.Add("@userid", SqlDbType.VarChar);
                sqlcom.Parameters["@userid"].Value = userid;

                sqlcom.Parameters.Add("@Team_Code", SqlDbType.VarChar);
                sqlcom.Parameters["@Team_Code"].Value = Team_Code;

                sqlcom.Parameters.Add("@Team_Name", SqlDbType.VarChar);

                sqlcom.Parameters["@Team_Name"].Value = Team_Name;


                sqlcom.Parameters.Add("@zone", SqlDbType.VarChar);
                sqlcom.Parameters["@zone"].Value = zone;

                sqlcom.Parameters.Add("@signature", SqlDbType.VarChar);
                sqlcom.Parameters["@signature"].Value = signature;

                sqlcom.Parameters.Add("@attachment", SqlDbType.VarChar);
                sqlcom.Parameters["@attachment"].Value = attachment;




                SqlDataAdapter da = new SqlDataAdapter(sqlcom);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref sqlcon);
            }

        }




        public DataSet AdvExecDetail(string Comp_Code, string Team_Code, string Team_Name, string zone, int Flag, string userid, string signature, string attachment)
        {
            SqlConnection sqlcon;
            SqlCommand sqlcom;
            sqlcon = GetConnection();
            try
            {
                sqlcon.Open();
                sqlcom = GetCommand("AdvTeamDetail", ref sqlcon);
                sqlcom.CommandType = CommandType.StoredProcedure;
                sqlcom.Parameters.Add("@Comp_Code", SqlDbType.VarChar);
                sqlcom.Parameters["@Comp_Code"].Value = Comp_Code;

                sqlcom.Parameters.Add("@userid", SqlDbType.VarChar);
                sqlcom.Parameters["@userid"].Value = userid;

                sqlcom.Parameters.Add("@Team_Code", SqlDbType.VarChar);
                //	if(Team_Code!="" && Team_Code!=null)
                //	{
                sqlcom.Parameters["@Team_Code"].Value = Team_Code;
                //	}
                /*else
                {
                    sqlcom.Parameters["@Team_Code"].Value = "%%";
                }*/
                sqlcom.Parameters.Add("@Team_Name", SqlDbType.VarChar);
                //	if(Team_Name!="" && Team_Name!=null)
                //{
                sqlcom.Parameters["@Team_Name"].Value = Team_Name;
                //}
                /*else
                {
                    sqlcom.Parameters["@Team_Name"].Value ="%%";
                }*/



                //sqlcom.Parameters.Add("@cat", SqlDbType.VarChar);
                //sqlcom.Parameters["@cat"].Value = cat;

                sqlcom.Parameters.Add("@zone", SqlDbType.VarChar);
                sqlcom.Parameters["@zone"].Value = zone;



                sqlcom.Parameters.Add("@Flag", SqlDbType.VarChar);
                sqlcom.Parameters["@Flag"].Value = Flag;

                sqlcom.Parameters.Add("@signature", SqlDbType.VarChar);
                sqlcom.Parameters["@signature"].Value = signature;


                sqlcom.Parameters.Add("@attachment", SqlDbType.VarChar);
                if (attachment == "" && attachment == null)
                    	{
                            sqlcom.Parameters["@attachment"].Value = System.DBNull.Value;
                        }
             else
                {
                    sqlcom.Parameters["@attachment"].Value = attachment;
                }


              


                SqlDataAdapter da = new SqlDataAdapter(sqlcom);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref sqlcon);
            }

        }


        public DataSet chkAdv(string Comp_Code, string Team_Code, string userid, string teamname, string bname)
        {
            SqlConnection sqlcon;
            SqlCommand sqlcom;
            sqlcon = GetConnection();
            try
            {

                sqlcon.Open();
                sqlcom = GetCommand("chkAdv", ref sqlcon);
                sqlcom.CommandType = CommandType.StoredProcedure;

                sqlcom.Parameters.Add("@Comp_Code", SqlDbType.VarChar);
                sqlcom.Parameters["@Comp_Code"].Value = Comp_Code;

                sqlcom.Parameters.Add("@userid", SqlDbType.VarChar);
                sqlcom.Parameters["@userid"].Value = userid;

                sqlcom.Parameters.Add("@Team_Code", SqlDbType.VarChar);
                sqlcom.Parameters["@Team_Code"].Value = Team_Code;

                sqlcom.Parameters.Add("@teamname", SqlDbType.VarChar);
                sqlcom.Parameters["@teamname"].Value = teamname;

                sqlcom.Parameters.Add("@bname", SqlDbType.VarChar);
                sqlcom.Parameters["@bname"].Value = bname;

                SqlDataAdapter da = new SqlDataAdapter(sqlcom);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref sqlcon);
            }

        }


        public DataSet detailinserted(string exename, string designation, string address, string street, string city, string district, string state, string country, string pin, string phone, string status, string compcode, string userid, string teamcode, string report, string taluka1, string repname, string adtype, string zone, string craditlimit, string email, string mobile, string empcode, string mailto, string ATTACHMENT, string PAYMENTMODE)
        {
            SqlConnection sqlcon;
            SqlCommand sqlcom;
            sqlcon = GetConnection();
            try
            {
                sqlcon.Open();
                sqlcom = GetCommand("execcontactinsert", ref sqlcon);
                sqlcom.CommandType = CommandType.StoredProcedure;

                sqlcom.Parameters.Add("@repname", SqlDbType.VarChar);
                sqlcom.Parameters["@repname"].Value = repname;

                sqlcom.Parameters.Add("@zone", SqlDbType.VarChar);
                sqlcom.Parameters["@zone"].Value = zone;


                sqlcom.Parameters.Add("@exename", SqlDbType.VarChar);
                sqlcom.Parameters["@exename"].Value = exename;

                sqlcom.Parameters.Add("@designation", SqlDbType.VarChar);
                sqlcom.Parameters["@designation"].Value = designation;

                sqlcom.Parameters.Add("@address", SqlDbType.VarChar);
                sqlcom.Parameters["@address"].Value = address;

                sqlcom.Parameters.Add("@street", SqlDbType.VarChar);
                sqlcom.Parameters["@street"].Value = street;

                sqlcom.Parameters.Add("@city", SqlDbType.VarChar);
                sqlcom.Parameters["@city"].Value = city;

                sqlcom.Parameters.Add("@district", SqlDbType.VarChar);
                sqlcom.Parameters["@district"].Value = district;

                sqlcom.Parameters.Add("@state", SqlDbType.VarChar);
                sqlcom.Parameters["@state"].Value = state;

                sqlcom.Parameters.Add("@country", SqlDbType.VarChar);
                sqlcom.Parameters["@country"].Value = country;

                sqlcom.Parameters.Add("@pin", SqlDbType.VarChar);
                sqlcom.Parameters["@pin"].Value = pin;

                sqlcom.Parameters.Add("@phone", SqlDbType.VarChar);
                sqlcom.Parameters["@phone"].Value = phone;

                sqlcom.Parameters.Add("@status", SqlDbType.VarChar);
                sqlcom.Parameters["@status"].Value = status;

                sqlcom.Parameters.Add("@compcode", SqlDbType.VarChar);
                sqlcom.Parameters["@compcode"].Value = compcode;

                sqlcom.Parameters.Add("@userid", SqlDbType.VarChar);
                sqlcom.Parameters["@userid"].Value = userid;

                sqlcom.Parameters.Add("@teamcode", SqlDbType.VarChar);
                sqlcom.Parameters["@teamcode"].Value = teamcode;

                sqlcom.Parameters.Add("@report", SqlDbType.VarChar);
                sqlcom.Parameters["@report"].Value = report;

                sqlcom.Parameters.Add("@taluka1", SqlDbType.VarChar);
                sqlcom.Parameters["@taluka1"].Value = taluka1;

                sqlcom.Parameters.Add("@adtype", SqlDbType.VarChar);
                sqlcom.Parameters["@adtype"].Value = adtype;

                sqlcom.Parameters.Add("@craditlimit", SqlDbType.VarChar);
                if (craditlimit == "")
                    sqlcom.Parameters["@craditlimit"].Value = "";
                else
                    sqlcom.Parameters["@craditlimit"].Value = Convert.ToDecimal(craditlimit);

                sqlcom.Parameters.Add("@email", SqlDbType.VarChar);
                sqlcom.Parameters["@email"].Value = email;

                sqlcom.Parameters.Add("@mobile", SqlDbType.VarChar);
                sqlcom.Parameters["@mobile"].Value = mobile;


                sqlcom.Parameters.Add("@p_empcode", SqlDbType.VarChar);
                sqlcom.Parameters["@p_empcode"].Value = empcode;

                sqlcom.Parameters.Add("@mailto", SqlDbType.VarChar);
                sqlcom.Parameters["@mailto"].Value = mailto;

                sqlcom.Parameters.Add("@attachment", SqlDbType.VarChar);
                sqlcom.Parameters["@attachment"].Value = ATTACHMENT;



                sqlcom.Parameters.Add("@paymode", SqlDbType.VarChar);
                sqlcom.Parameters["@paymode"].Value = PAYMENTMODE;



                SqlDataAdapter da = new SqlDataAdapter(sqlcom);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref sqlcon);
            }

        }


        // ---------------------------------------------- for insert adcategory ----------------------------------------//


        public void insertedExecAdetail(string compcode, string userid, string teamcode, string adcategory, string flag, string execode)
        {
            SqlConnection sqlcon;
            SqlCommand sqlcom;
            sqlcon = GetConnection();
            try
            {
                sqlcon.Open();
                sqlcom = GetCommand("execcontactinsertadcat", ref sqlcon);
                sqlcom.CommandType = CommandType.StoredProcedure;

                sqlcom.Parameters.Add("@compcode", SqlDbType.VarChar);
                sqlcom.Parameters["@compcode"].Value = compcode;

                sqlcom.Parameters.Add("@userid", SqlDbType.VarChar);
                sqlcom.Parameters["@userid"].Value = userid;

                sqlcom.Parameters.Add("@flag", SqlDbType.VarChar);
                sqlcom.Parameters["@flag"].Value = flag;

                sqlcom.Parameters.Add("@adcategory", SqlDbType.VarChar);
                sqlcom.Parameters["@adcategory"].Value = adcategory;

                sqlcom.Parameters.Add("@execode", SqlDbType.VarChar);
                sqlcom.Parameters["@execode"].Value = execode;

                sqlcom.Parameters.Add("@teamcode", SqlDbType.VarChar);
                sqlcom.Parameters["@teamcode"].Value = teamcode;


                sqlcom.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref sqlcon);
            }
        }


        public DataSet exebind(string compcode, string userid, string teamcode)
        {
            SqlConnection sqlcon;
            SqlCommand sqlcom;
            sqlcon = GetConnection();
            try
            {
                sqlcon.Open();

                //sqlcom = GetCommand("execcontactbind",ref sqlcon);
                sqlcom = GetCommand("execcontactbind_grid", ref sqlcon);
                sqlcom.CommandType = CommandType.StoredProcedure;

                sqlcom.Parameters.Add("@compcode", SqlDbType.VarChar);
                sqlcom.Parameters["@compcode"].Value = compcode;

                sqlcom.Parameters.Add("@userid", SqlDbType.VarChar);
                sqlcom.Parameters["@userid"].Value = userid;

                sqlcom.Parameters.Add("@teamcode", SqlDbType.VarChar);
                sqlcom.Parameters["@teamcode"].Value = teamcode;

                SqlDataAdapter da = new SqlDataAdapter(sqlcom);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref sqlcon);
            }

        }

        public DataSet detailinsertedexec(string compcode, string userid, string code)
        {
            SqlConnection sqlcon;
            SqlCommand sqlcom;
            sqlcon = GetConnection();
            try
            {
                sqlcon.Open();
                sqlcom = GetCommand("execselectbind", ref sqlcon);
                sqlcom.CommandType = CommandType.StoredProcedure;

                sqlcom.Parameters.Add("@compcode", SqlDbType.VarChar);
                sqlcom.Parameters["@compcode"].Value = compcode;

                sqlcom.Parameters.Add("@userid", SqlDbType.VarChar);
                sqlcom.Parameters["@userid"].Value = userid;

                sqlcom.Parameters.Add("@code", SqlDbType.VarChar);
                sqlcom.Parameters["@code"].Value = code;

                SqlDataAdapter da = new SqlDataAdapter(sqlcom);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref sqlcon);
            }
        }

        public DataSet detailupdate(string exename, string designation, string address, string street, string city, string district, string state, string country, string pin, string phone, string status, string compcode, string userid, string teamcode, string code, string report, string taluka, string repname, string adtype, string brancgname1, string craditlimit, string email, string mobile, string empcode, string mailto, string attachment, string PAYMENTMODE)
        {
            SqlConnection sqlcon;
            SqlCommand sqlcom;
            sqlcon = GetConnection();
            try
            {
                sqlcon.Open();
                sqlcom = GetCommand("execcontactupdate", ref sqlcon);
                sqlcom.CommandType = CommandType.StoredProcedure;

                sqlcom.Parameters.Add("@exename", SqlDbType.VarChar);

                sqlcom.Parameters["@exename"].Value = exename;

                sqlcom.Parameters.Add("@designation", SqlDbType.VarChar);
                sqlcom.Parameters["@designation"].Value = designation;

                sqlcom.Parameters.Add("@address", SqlDbType.VarChar);
                sqlcom.Parameters["@address"].Value = address;

                sqlcom.Parameters.Add("@street", SqlDbType.VarChar);
                sqlcom.Parameters["@street"].Value = street;

                sqlcom.Parameters.Add("@city", SqlDbType.VarChar);
                sqlcom.Parameters["@city"].Value = city;

                sqlcom.Parameters.Add("@district", SqlDbType.VarChar);
                sqlcom.Parameters["@district"].Value = district;

                sqlcom.Parameters.Add("@state", SqlDbType.VarChar);
                sqlcom.Parameters["@state"].Value = state;

                sqlcom.Parameters.Add("@country", SqlDbType.VarChar);
                sqlcom.Parameters["@country"].Value = country;

                sqlcom.Parameters.Add("@pin", SqlDbType.VarChar);
                sqlcom.Parameters["@pin"].Value = pin;

                sqlcom.Parameters.Add("@phone", SqlDbType.VarChar);
                sqlcom.Parameters["@phone"].Value = phone;

                sqlcom.Parameters.Add("@status", SqlDbType.VarChar);
                sqlcom.Parameters["@status"].Value = status;

                sqlcom.Parameters.Add("@compcode", SqlDbType.VarChar);
                sqlcom.Parameters["@compcode"].Value = compcode;

                sqlcom.Parameters.Add("@userid", SqlDbType.VarChar);
                sqlcom.Parameters["@userid"].Value = userid;

                sqlcom.Parameters.Add("@teamcode", SqlDbType.VarChar);
                sqlcom.Parameters["@teamcode"].Value = teamcode;

                sqlcom.Parameters.Add("@code", SqlDbType.VarChar);
                sqlcom.Parameters["@code"].Value = code;

                sqlcom.Parameters.Add("@report", SqlDbType.VarChar);
                sqlcom.Parameters["@report"].Value = report;

                sqlcom.Parameters.Add("@TALUKA1", SqlDbType.VarChar);
                sqlcom.Parameters["@TALUKA1"].Value = taluka;

                sqlcom.Parameters.Add("@repname", SqlDbType.VarChar);
                sqlcom.Parameters["@repname"].Value = repname;

                sqlcom.Parameters.Add("@adtype", SqlDbType.VarChar);
                sqlcom.Parameters["@adtype"].Value = adtype;

                sqlcom.Parameters.Add("@branchcode", SqlDbType.VarChar);
                sqlcom.Parameters["@branchcode"].Value = brancgname1;

                sqlcom.Parameters.Add("@craditlimit", SqlDbType.VarChar);
                if (craditlimit == "")
                    sqlcom.Parameters["@craditlimit"].Value = "";
                else
                    sqlcom.Parameters["@craditlimit"].Value = craditlimit;
                
                sqlcom.Parameters.Add("@email", SqlDbType.VarChar);
                sqlcom.Parameters["@email"].Value = email;

                sqlcom.Parameters.Add("@mobile", SqlDbType.VarChar);
                sqlcom.Parameters["@mobile"].Value = mobile;

                sqlcom.Parameters.Add("@p_empcode", SqlDbType.VarChar);
                sqlcom.Parameters["@p_empcode"].Value = empcode;

                sqlcom.Parameters.Add("@mailto", SqlDbType.VarChar);
                sqlcom.Parameters["@mailto"].Value = mailto;

                sqlcom.Parameters.Add("@pattachment", SqlDbType.VarChar);
                sqlcom.Parameters["@pattachment"].Value = attachment;

                sqlcom.Parameters.Add("@paymode", SqlDbType.VarChar);
                sqlcom.Parameters["@paymode"].Value = PAYMENTMODE;



                SqlDataAdapter da = new SqlDataAdapter(sqlcom);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref sqlcon);
            }

        }

        /*	public DataSet checkadvexcode(string compcode,string Team_Code,string userid)
            {
                SqlConnection objSqlConnection;
                SqlCommand objSqlCommand;
                objSqlConnection = GetConnection();
                SqlDataAdapter objSqlDataAdapter;
                DataSet objDataSet = new DataSet();	
                try
                {
                    objSqlConnection.Open();
                    objSqlCommand = GetCommand("checkadvcode", ref objSqlConnection);
                    objSqlCommand.CommandType = CommandType.StoredProcedure;
 
                    objSqlCommand.Parameters.Add("@Comp_Code", SqlDbType.VarChar);
                    objSqlCommand.Parameters["@Comp_Code"].Value =compcode;

                    objSqlCommand.Parameters.Add("@UserId", SqlDbType.VarChar);
                    objSqlCommand.Parameters["@UserId"].Value =userid;

                    objSqlCommand.Parameters.Add("@Team_Code", SqlDbType.VarChar);
                    objSqlCommand.Parameters["@Team_Code"].Value =Team_Code;

                    //objSqlCommand.Parameters.Add("@flag", SqlDbType.VarChar);
                    //objSqlCommand.Parameters["@flag"].Value =z;
	
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
		
            }*/

        public DataSet deleteexecdetail(string compcode, string userid, string code)
        {
            SqlConnection sqlcon;
            SqlCommand sqlcom;
            sqlcon = GetConnection();
            try
            {
                sqlcon.Open();
                sqlcom = GetCommand("execdelete", ref sqlcon);
                sqlcom.CommandType = CommandType.StoredProcedure;

                sqlcom.Parameters.Add("@compcode", SqlDbType.VarChar);
                sqlcom.Parameters["@compcode"].Value = compcode;

                sqlcom.Parameters.Add("@userid", SqlDbType.VarChar);
                sqlcom.Parameters["@userid"].Value = userid;

                sqlcom.Parameters.Add("@code", SqlDbType.VarChar);
                sqlcom.Parameters["@code"].Value = code;

                SqlDataAdapter da = new SqlDataAdapter(sqlcom);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref sqlcon);
            }
        }

        public DataSet chkpopup(string teamcode, string compcode, string userid)
        {
            SqlConnection sqlcon;
            SqlCommand sqlcom;
            sqlcon = GetConnection();
            try
            {
                sqlcon.Open();
                sqlcom = GetCommand("chkpopteam", ref sqlcon);
                sqlcom.CommandType = CommandType.StoredProcedure;

                sqlcom.Parameters.Add("@compcode", SqlDbType.VarChar);
                sqlcom.Parameters["@compcode"].Value = compcode;

                sqlcom.Parameters.Add("@userid", SqlDbType.VarChar);
                sqlcom.Parameters["@userid"].Value = userid;

                sqlcom.Parameters.Add("@teamcode", SqlDbType.VarChar);
                sqlcom.Parameters["@teamcode"].Value = teamcode;

                SqlDataAdapter da = new SqlDataAdapter(sqlcom);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref sqlcon);
            }
        }


        public DataSet addpickdistname(string citycode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("fillstaedistcountry", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@citycode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@citycode"].Value = citycode;

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

        public DataSet report(string compcode, string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("bindreportto", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

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

        public DataSet valueofcount(string countcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getcountryname", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@countcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@countcode"].Value = countcode;

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



        public DataSet chkexeccode1(string str, string region)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("chkadvexename", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@str", SqlDbType.VarChar);
                objSqlCommand.Parameters["@str"].Value = str;

                objSqlCommand.Parameters.Add("@cod", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cod"].Value = str;

                objSqlCommand.Parameters.Add("@region", SqlDbType.VarChar);
                objSqlCommand.Parameters["@region"].Value = region;



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


        public DataSet chkexecname1(string Comp_Code, string exename, string userid, string teamcode)
        {
            SqlConnection sqlcon;
            SqlCommand sqlcom;
            sqlcon = GetConnection();
            try
            {

                sqlcon.Open();
                sqlcom = GetCommand("chkexecname", ref sqlcon);
                sqlcom.CommandType = CommandType.StoredProcedure;

                sqlcom.Parameters.Add("@Comp_Code", SqlDbType.VarChar);
                sqlcom.Parameters["@Comp_Code"].Value = Comp_Code;

                sqlcom.Parameters.Add("@userid", SqlDbType.VarChar);
                sqlcom.Parameters["@userid"].Value = userid;

                sqlcom.Parameters.Add("@execname", SqlDbType.VarChar);
                sqlcom.Parameters["@execname"].Value = exename;

                sqlcom.Parameters.Add("@teamcode1", SqlDbType.VarChar);
                sqlcom.Parameters["@teamcode1"].Value = teamcode;


                SqlDataAdapter da = new SqlDataAdapter(sqlcom);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref sqlcon);
            }

        }





        public DataSet bindteam1()
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("addpubname", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                //				objSqlCommand.Parameters.Add("@dist", SqlDbType.VarChar);
                //				objSqlCommand.Parameters["@dist"].Value =dist;
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











        public DataSet adcategory1()
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("adcat", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                //				objSqlCommand.Parameters.Add("@dist", SqlDbType.VarChar);
                //				objSqlCommand.Parameters["@dist"].Value =dist;
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

        public DataSet addesignation(string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("addesignation", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;


                //				objSqlCommand.Parameters.Add("@dist", SqlDbType.VarChar);
                //				objSqlCommand.Parameters["@dist"].Value =dist;
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





        /*public DataSet adzone(string userid, string compcode)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("bindzone1", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

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

        }*/

        public DataSet adzone(string userid, string compcode)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                //  objSqlCommand = GetCommand("regionbind", ref objSqlConnection);
                //  objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand = GetCommand("branchbind_adv", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                //objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@userid"].Value = userid;

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





        public DataSet countczone(string pub)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("fillzone", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@pub", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pub"].Value = pub;

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


        //ad by rinki
        public DataSet typebind(string compcode, string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("adtype", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

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

        public DataSet addadvcat(string adtypcode)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("addadvcatpage", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@adtypcode", SqlDbType.VarChar);
                com.Parameters["@adtypcode"].Value = adtypcode;

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


        // ad for adcategory
        public void deleteExecAdetail(string compcode, string code)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            try
            {
                con.Open();
                com = GetCommand("execcontactdeleteadcat", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@compcode", SqlDbType.VarChar);
                com.Parameters["@compcode"].Value = compcode;

                com.Parameters.Add("@execode", SqlDbType.VarChar);
                com.Parameters["@execode"].Value = code;

                com.ExecuteNonQuery();


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

        //public void insertedExecAdetail(string compcode, string userid, string teamcode, string adcategory, string flag, string execode)
        //{
        //    SqlConnection con;
        //    SqlCommand com;
        //    con = GetConnection();
        //    SqlDataAdapter da = new SqlDataAdapter();
        //    try
        //    {
        //        con.Open();
        //        com = GetCommand("execcontactinsertadcat", ref con);
        //        com.CommandType = CommandType.StoredProcedure;

        //        com.Parameters.Add("@compcode", SqlDbType.VarChar);
        //        com.Parameters["@compcode"].Value = compcode;

        //        com.Parameters.Add("@userid", SqlDbType.VarChar);
        //        com.Parameters["@userid"].Value = userid;

        //        com.Parameters.Add("@flag", SqlDbType.VarChar);
        //        com.Parameters["@flag"].Value = flag;

        //        com.Parameters.Add("@adcategory", SqlDbType.VarChar);
        //        com.Parameters["@adcategory"].Value = adcategory;


        //        com.Parameters.Add("@execode", SqlDbType.VarChar);
        //        com.Parameters["@execode"].Value = execode;

        //        com.Parameters.Add("@teamcode", SqlDbType.VarChar);
        //        com.Parameters["@teamcode"].Value = teamcode;

        //        com.ExecuteNonQuery();


        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //    finally
        //    {
        //        CloseConnection(ref con);
        //    }

        //}


        public DataSet bindempcode(string compcode, string empname)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                //  objSqlCommand = GetCommand("regionbind", ref objSqlConnection);
                //  objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand = GetCommand("emp_code_bind", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                //objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@pcomp_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcomp_code"].Value = compcode;

                objSqlCommand.Parameters.Add("@pname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pname"].Value = empname;

                objSqlCommand.Parameters.Add("@pextra1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra1"].Value = System.DBNull.Value;

                objSqlCommand.Parameters.Add("@pextra2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra2"].Value = System.DBNull.Value;

                objSqlCommand.Parameters.Add("@pextra3", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra3"].Value = System.DBNull.Value;

                objSqlCommand.Parameters.Add("@pextra4", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra4"].Value = System.DBNull.Value;

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
                objSqlCommand = GetCommand("exeaddstatusbind", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@execode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@execode"].Value = retcode;

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



        public DataSet insertretaddcomm(string compcode, string userid, string retcode, string lstpub, string minpub, string publication, string commid)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("ad_execu_add_comm_target_ins", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@PCOMP_CODE", SqlDbType.VarChar);
                objSqlCommand.Parameters["@PCOMP_CODE"].Value = compcode;

                objSqlCommand.Parameters.Add("@pexecu_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pexecu_code"].Value = retcode;

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
                objSqlCommand = GetCommand("ad_execu_add_comm_target_ins", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@PCOMP_CODE", SqlDbType.VarChar);
                objSqlCommand.Parameters["@PCOMP_CODE"].Value = compcode;

                objSqlCommand.Parameters.Add("@pexecu_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pexecu_code"].Value = retcode;

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
                objSqlCommand = GetCommand("ad_execu_add_comm_target_ins", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@PCOMP_CODE", SqlDbType.VarChar);
                objSqlCommand.Parameters["@PCOMP_CODE"].Value = compcode;

                objSqlCommand.Parameters.Add("@pexecu_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pexecu_code"].Value = retcode;

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
                objSqlCommand = GetCommand("exeaddselectslab", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@execode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@execode"].Value = retcode;

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
                objSqlCommand = GetCommand("ad_execut_comm_target_bind", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@execode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@execode"].Value = retcode;

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
                objSqlCommand = GetCommand("exeselectstructslab", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@execode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@execode"].Value = retcode;

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
                objSqlCommand = GetCommand("AD_execu_COMM_TARGET_INS", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@PCOMP_CODE", SqlDbType.VarChar);
                objSqlCommand.Parameters["@PCOMP_CODE"].Value = compcode;

                objSqlCommand.Parameters.Add("@Pexe_CODE", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Pexe_CODE"].Value = retcode;

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


        public DataSet insertretcommstructure(string compcode, string userid, string retcode, string PTEAM_CODE, string PADCTG_CODE, string PFROM_TGT, string PTO_TGT, string PCUST_TYPE, string PAD_TYPE, string PPUB_TYPE, string PPUBL_CODE, string PCOMM_TARGET_ID)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("AD_execu_COMM_TARGET_INS", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@PCOMP_CODE", SqlDbType.VarChar);
                objSqlCommand.Parameters["@PCOMP_CODE"].Value = compcode;

                objSqlCommand.Parameters.Add("@Pexe_CODE", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Pexe_CODE"].Value = retcode;

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


        public DataSet insertretstatus_slab(string compcode, string userid, string retcode, string fromdays, string todays, string drpcommon, string commrate, string commid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("insertexestatus_slab ", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@execode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@execode"].Value = retcode;

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
                objSqlCommand = GetCommand("AD_execu_COMM_TARGET_INS", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@PCOMP_CODE", SqlDbType.VarChar);
                objSqlCommand.Parameters["@PCOMP_CODE"].Value = compcode;

                objSqlCommand.Parameters.Add("@Pexe_CODE", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Pexe_CODE"].Value = retcode;

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
                objSqlCommand = GetCommand("exegencodeforcommstruct", ref objSqlConnection);
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


        public DataSet retainerstatusbind_b(string retcode, string userid, string compcode, string dateformat, string commid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("sp_exestatusbind_b", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@execode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@execode"].Value = retcode;

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
                objSqlCommand = GetCommand("exeselectslab", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@execode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@execode"].Value = retcode;

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







        public DataSet Ret_GetSlabupdate(string retcode, string compcode, string userid, string common, string commrate, string todays, string fromdays, string code)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("updateexestatus_slab", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@execode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@execode"].Value = retcode;

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





        public DataSet retslabcheck(string compcode, string userid, string retcode, string todays, string fromdays, string codepass)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("execheckslab", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@execode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@execode"].Value = retcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

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
        }


        //public DataSet insertretstatus_slab(string compcode, string userid, string retcode, string fromdays, string todays, string drpcommon, string commrate, string commid)
        //{
        //    SqlConnection objSqlConnection;
        //    SqlCommand objSqlCommand;
        //    objSqlConnection = GetConnection();
        //    SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
        //    DataSet objDataSet = new DataSet();
        //    try
        //    {
        //        objSqlConnection.Open();
        //        objSqlCommand = GetCommand("insertexestatus_slab", ref objSqlConnection);
        //        objSqlCommand.CommandType = CommandType.StoredProcedure;

        //        objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
        //        objSqlCommand.Parameters["@compcode"].Value = compcode;

        //        objSqlCommand.Parameters.Add("@execode", SqlDbType.VarChar);
        //        objSqlCommand.Parameters["@execode"].Value = retcode;

        //        objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
        //        objSqlCommand.Parameters["@userid"].Value = userid;



        //        objSqlCommand.Parameters.Add("@drpcommon", SqlDbType.VarChar);
        //        objSqlCommand.Parameters["@drpcommon"].Value = drpcommon;

        //        objSqlCommand.Parameters.Add("@commrate", SqlDbType.VarChar);
        //        objSqlCommand.Parameters["@commrate"].Value = commrate;

        //        objSqlCommand.Parameters.Add("@fromdays", SqlDbType.VarChar);
        //        objSqlCommand.Parameters["@fromdays"].Value = fromdays;

        //        objSqlCommand.Parameters.Add("@todays", SqlDbType.VarChar);
        //        objSqlCommand.Parameters["@todays"].Value = todays;

        //        objSqlCommand.Parameters.Add("@P_COMM_TARGET_ID", SqlDbType.VarChar);
        //        objSqlCommand.Parameters["@P_COMM_TARGET_ID"].Value = commid;


        //        objSqlDataAdapter.SelectCommand = objSqlCommand;
        //        objSqlDataAdapter.Fill(objDataSet);

        //        return objDataSet;

        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //    finally
        //    {
        //        CloseConnection(ref objSqlConnection);
        //    }

        //}



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
                objSqlCommand = GetCommand("exedeleteslab", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@execode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@execode"].Value = retcode;

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
    
    
    }

    

}
