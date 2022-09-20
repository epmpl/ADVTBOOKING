using System;
using System.Data;
using System.Data.SqlClient;


namespace NewAdbooking.Classes
{
	/// <summary>
	/// Summary description for PubCatMast.
	/// </summary>
	public class PubCatMast:connection
	{
		public PubCatMast()
		{
			//
			// TODO: Add constructor logic here
			//
		}

        
//************************************************************
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
				objSqlCommand.Parameters["@citycode"].Value =citycode;
 
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
        //Code for the insert the data into the data base//

        public DataSet insertpcm(string compcode, string centercode, string centername, string alias, string add1, string street, string city, string dist, string country, string phone1, string phone2, string pin, string state, string fax, string email, string remarks, string userid, string region, string zone, string fax1, string boxaddress, string printval, string imgpath, string cir_imgpath, string companyname, string logofilename, string statecode, string MRV, string agcode, string dpcode, string booking_cutof_time)
        {
            SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("pcminsert", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;


				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;


				objSqlCommand.Parameters.Add("@centercode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@centercode"].Value =centercode;

					objSqlCommand.Parameters.Add("@centername", SqlDbType.VarChar);
				objSqlCommand.Parameters["@centername"].Value =centername;

					objSqlCommand.Parameters.Add("@alias", SqlDbType.VarChar);
				objSqlCommand.Parameters["@alias"].Value =alias;

					objSqlCommand.Parameters.Add("@add1", SqlDbType.VarChar);
				objSqlCommand.Parameters["@add1"].Value =add1;

					objSqlCommand.Parameters.Add("@street", SqlDbType.VarChar);
				objSqlCommand.Parameters["@street"].Value =street;

					objSqlCommand.Parameters.Add("@city", SqlDbType.VarChar);
				objSqlCommand.Parameters["@city"].Value =city;

					objSqlCommand.Parameters.Add("@dist", SqlDbType.VarChar);
				objSqlCommand.Parameters["@dist"].Value =dist;

					
				objSqlCommand.Parameters.Add("@country", SqlDbType.VarChar);
				objSqlCommand.Parameters["@country"].Value =country;

				objSqlCommand.Parameters.Add("@phone1", SqlDbType.VarChar);
				objSqlCommand.Parameters["@phone1"].Value =phone1;

				objSqlCommand.Parameters.Add("@phone2", SqlDbType.VarChar);
				objSqlCommand.Parameters["@phone2"].Value =phone2;

					

				objSqlCommand.Parameters.Add("@pin", SqlDbType.VarChar);
				objSqlCommand.Parameters["@pin"].Value =pin;

				objSqlCommand.Parameters.Add("@state", SqlDbType.VarChar);
				objSqlCommand.Parameters["@state"].Value =state;

				objSqlCommand.Parameters.Add("@fax", SqlDbType.VarChar);
				objSqlCommand.Parameters["@fax"].Value =fax;

				objSqlCommand.Parameters.Add("@email", SqlDbType.VarChar);
				objSqlCommand.Parameters["@email"].Value =email;

				//objSqlCommand.Parameters.Add("@status", SqlDbType.VarChar);
				//objSqlCommand.Parameters["@status"].Value =status;

				//objSqlCommand.Parameters.Add("@statusdate", SqlDbType.VarChar);
				//objSqlCommand.Parameters["@statusdate"].Value =statusdate;

				objSqlCommand.Parameters.Add("@remarks", SqlDbType.VarChar);
				objSqlCommand.Parameters["@remarks"].Value =remarks;

				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;

                objSqlCommand.Parameters.Add("@region", SqlDbType.VarChar);
                objSqlCommand.Parameters["@region"].Value = region;

                objSqlCommand.Parameters.Add("@zone", SqlDbType.VarChar);
                objSqlCommand.Parameters["@zone"].Value = zone;

                objSqlCommand.Parameters.Add("@fax1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@fax1"].Value = fax1;

        
                objSqlCommand.Parameters.Add("@boxaddress", SqlDbType.VarChar);
                objSqlCommand.Parameters["@boxaddress"].Value = boxaddress;

                objSqlCommand.Parameters.Add("@printval", SqlDbType.VarChar);
                objSqlCommand.Parameters["@printval"].Value = printval;

                objSqlCommand.Parameters.Add("@imgpath", SqlDbType.VarChar);
                objSqlCommand.Parameters["@imgpath"].Value = imgpath;

                objSqlCommand.Parameters.Add("@cir_imgpath", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cir_imgpath"].Value = cir_imgpath;

                objSqlCommand.Parameters.Add("@pcompanyname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcompanyname"].Value = companyname;

                objSqlCommand.Parameters.Add("@plogopath", SqlDbType.VarChar);
                objSqlCommand.Parameters["@plogopath"].Value = logofilename;

                objSqlCommand.Parameters.Add("@pstate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pstate"].Value = statecode;


                objSqlCommand.Parameters.Add("@pmrv", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pmrv"].Value = MRV;

                objSqlCommand.Parameters.Add("@pcir_agcdpo_upd", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcir_agcdpo_upd"].Value = agcode;

                objSqlCommand.Parameters.Add("@pcir_dpcdpo_upd", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcir_dpcdpo_upd"].Value = dpcode;

                objSqlCommand.Parameters.Add("@booking_cutof_timep", SqlDbType.VarChar);
                objSqlCommand.Parameters["@booking_cutof_timep"].Value = booking_cutof_time;
                

		

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


        //Code for the Modify the data into the data base//
        public DataSet updatepcm(string compcode, string centercode, string centername, string alias, string add1, string street, string city, string dist, string country, string phone1, string phone2, string pin, string state, string fax, string email, string remarks, string userid, string region, string zone, string fax1, string boxadd, string printval, string imgpath, string cir_imgpath, string companyname, string logofilename, string statecode, string MRV, string agcode, string dpcode, string booking_cutof_time)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("pcmupdate", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;


				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;


				objSqlCommand.Parameters.Add("@centercode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@centercode"].Value =centercode;

				objSqlCommand.Parameters.Add("@centername", SqlDbType.VarChar);
				objSqlCommand.Parameters["@centername"].Value =centername;

				objSqlCommand.Parameters.Add("@alias", SqlDbType.VarChar);
				objSqlCommand.Parameters["@alias"].Value =alias;

				objSqlCommand.Parameters.Add("@add1", SqlDbType.VarChar);
				objSqlCommand.Parameters["@add1"].Value =add1;

				objSqlCommand.Parameters.Add("@street", SqlDbType.VarChar);
				objSqlCommand.Parameters["@street"].Value =street;

				objSqlCommand.Parameters.Add("@city", SqlDbType.VarChar);
				objSqlCommand.Parameters["@city"].Value =city;

				objSqlCommand.Parameters.Add("@dist", SqlDbType.VarChar);
				objSqlCommand.Parameters["@dist"].Value =dist;

					
				objSqlCommand.Parameters.Add("@country", SqlDbType.VarChar);
				objSqlCommand.Parameters["@country"].Value =country;

				objSqlCommand.Parameters.Add("@phone1", SqlDbType.VarChar);
				objSqlCommand.Parameters["@phone1"].Value =phone1;

				objSqlCommand.Parameters.Add("@phone2", SqlDbType.VarChar);
				objSqlCommand.Parameters["@phone2"].Value =phone2;

				objSqlCommand.Parameters.Add("@pin", SqlDbType.VarChar);
				objSqlCommand.Parameters["@pin"].Value =pin;

				objSqlCommand.Parameters.Add("@state", SqlDbType.VarChar);
				objSqlCommand.Parameters["@state"].Value =state;

				objSqlCommand.Parameters.Add("@fax", SqlDbType.VarChar);
				objSqlCommand.Parameters["@fax"].Value =fax;

				objSqlCommand.Parameters.Add("@email", SqlDbType.VarChar);
				objSqlCommand.Parameters["@email"].Value =email;

				//objSqlCommand.Parameters.Add("@status", SqlDbType.VarChar);
				//objSqlCommand.Parameters["@status"].Value =status;

				//objSqlCommand.Parameters.Add("@statusdate", SqlDbType.VarChar);
				//objSqlCommand.Parameters["@statusdate"].Value =statusdate;

				objSqlCommand.Parameters.Add("@remarks", SqlDbType.VarChar);
				objSqlCommand.Parameters["@remarks"].Value =remarks;

                //objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@userid"].Value =userid;

                objSqlCommand.Parameters.Add("@region", SqlDbType.VarChar);
                objSqlCommand.Parameters["@region"].Value = region;

                objSqlCommand.Parameters.Add("@zone", SqlDbType.VarChar);
                objSqlCommand.Parameters["@zone"].Value = zone;

                objSqlCommand.Parameters.Add("@fax1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@fax1"].Value = fax1;
       
                objSqlCommand.Parameters.Add("@boxadd", SqlDbType.VarChar);
                objSqlCommand.Parameters["@boxadd"].Value = boxadd;

                objSqlCommand.Parameters.Add("@printval", SqlDbType.VarChar);
                objSqlCommand.Parameters["@printval"].Value = printval;

                objSqlCommand.Parameters.Add("@imgpath", SqlDbType.VarChar);
                objSqlCommand.Parameters["@imgpath"].Value = imgpath;

                objSqlCommand.Parameters.Add("@cir_imgpath", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cir_imgpath"].Value = imgpath;


                objSqlCommand.Parameters.Add("@pcompanyname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcompanyname"].Value = companyname;

                objSqlCommand.Parameters.Add("@plogopath", SqlDbType.VarChar);
                objSqlCommand.Parameters["@plogopath"].Value = logofilename;


                objSqlCommand.Parameters.Add("@pstate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pstate"].Value = statecode;



                objSqlCommand.Parameters.Add("@pmrv", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pmrv"].Value = MRV;

                objSqlCommand.Parameters.Add("@pcir_agcdpo_upd", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcir_agcdpo_upd"].Value = agcode;

                objSqlCommand.Parameters.Add("@pcir_dpcdpo_upd", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcir_dpcdpo_upd"].Value = dpcode;


                objSqlCommand.Parameters.Add("@booking_cutof_timep", SqlDbType.VarChar);
                objSqlCommand.Parameters["@booking_cutof_timep"].Value = booking_cutof_time;
                
				
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



        //Code for the Execute the commande for fetch the data from the data base//
        public DataSet pcmexe(string compcode, string centcode, string centname, string alias, string country, string city,  string companyname, string state, string MRV, string agcode, string dpcode)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("pcmexe", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;


				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;


				objSqlCommand.Parameters.Add("@centcode", SqlDbType.VarChar);
                //if(centcode=="" || centcode== null || centcode=="undefined")
                //{
                //objSqlCommand.Parameters["@centcode"].Value ="%%";
                //}
                //else
                //{
					objSqlCommand.Parameters["@centcode"].Value =centcode;
                //}


				objSqlCommand.Parameters.Add("@centname", SqlDbType.VarChar);
                //if(centname=="" || centname==null || centname=="Undefined")
                //{
                //    objSqlCommand.Parameters["@centname"].Value ="%%";
                //}
                //else
                //{
					objSqlCommand.Parameters["@centname"].Value =centname;
                //}



				objSqlCommand.Parameters.Add("@alias", SqlDbType.VarChar);
                //if (alias=="" || alias==null || alias == "undefined")
                //{
                //    objSqlCommand.Parameters["@alias"].Value ="%%";
				
                //}
                //else
                //{
					objSqlCommand.Parameters["@alias"].Value =alias;
                //}


                objSqlCommand.Parameters.Add("@country", SqlDbType.VarChar);

                //if (country == "0" || country == null || country == "undefined")
                //{
                //    objSqlCommand.Parameters["@country"].Value = "%%";
                //}
                //else
                //{
                    objSqlCommand.Parameters["@country"].Value = country;
                //}


				objSqlCommand.Parameters.Add("@city", SqlDbType.VarChar);

               //if (city == "0" || city == null|| city == "undefined" )
               
               // {
               //     objSqlCommand.Parameters["@city"].Value ="%%";
               // }
               // else
               // {
					objSqlCommand.Parameters["@city"].Value =city;
                //}
				
                //objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@userid"].Value =userid;





                    objSqlCommand.Parameters.Add("@pcompname", SqlDbType.VarChar);
                    objSqlCommand.Parameters["@pcompname"].Value = companyname;



                    objSqlCommand.Parameters.Add("@pstate", SqlDbType.VarChar);
                    objSqlCommand.Parameters["@pstate"].Value = state;

                     objSqlCommand.Parameters.Add("@pmrv", SqlDbType.VarChar);
                    objSqlCommand.Parameters["@pmrv"].Value = MRV;


                    objSqlCommand.Parameters.Add("@pcir_agcdpo_upd", SqlDbType.VarChar);
                    objSqlCommand.Parameters["@pcir_agcdpo_upd"].Value = agcode;


                    objSqlCommand.Parameters.Add("@pcir_dpcdpo_upd", SqlDbType.VarChar);
                    objSqlCommand.Parameters["@pcir_dpcdpo_upd"].Value = dpcode;
                
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


        public DataSet addregion(string regioncode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("pcmaddregion", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                //				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                //				objSqlCommand.Parameters["@compcode"].Value =compcode;
                //
                //				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                //				objSqlCommand.Parameters["@userid"].Value =userid;

                objSqlCommand.Parameters.Add("@regioncode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@regioncode"].Value = regioncode;


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




        public DataSet checkpubcode(string compcode, string centcode, string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("checkpubcatcode", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@centcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@centcode"].Value = centcode;

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


      


        public DataSet getbind(string centcode, string compcode, string userid, string dateformat)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("pcmbinddata", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
				
				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;

                objSqlCommand.Parameters.Add("@centcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@centcode"].Value = centcode;

                objSqlCommand.Parameters.Add("@date", SqlDbType.VarChar);
                objSqlCommand.Parameters["@date"].Value = dateformat;


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



        //Code for the See the first,next,privious,last data//
		public DataSet pcmfnpl(string compcode, string userid)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("pcmfnpl", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
				
				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;

				//objSqlCommand.Parameters.Add("@centcode", SqlDbType.VarChar);
				//objSqlCommand.Parameters["@centcode"].Value =centcode;


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

        //Code for the Delete the Data from the data base//
		public DataSet pcmdel(string compcode,string centercode, string userid)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("pcmdel", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
				
				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

                //objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@userid"].Value =userid;

				objSqlCommand.Parameters.Add("@centcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@centcode"].Value =centercode;


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





		public DataSet chkpcm(string compcode, string userid, string centcode)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("chkpcm", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
				
				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;

				objSqlCommand.Parameters.Add("@centcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@centcode"].Value =centcode;


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

        //pankaj//

        public DataSet chkcity(string compcode, string userid, string centername, string city)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("checkcity", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@centername", SqlDbType.VarChar);
                objSqlCommand.Parameters["@centername"].Value = centername;

                objSqlCommand.Parameters.Add("@city", SqlDbType.VarChar);
                objSqlCommand.Parameters["@city"].Value = city;



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

        // for modify saurabh agarwal

        public DataSet chkcitymodify(string compcode, string userid, string centername, string city,string code)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("checkcitymodify", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@centername", SqlDbType.VarChar);
                objSqlCommand.Parameters["@centername"].Value = centername;

                objSqlCommand.Parameters.Add("@city", SqlDbType.VarChar);
                objSqlCommand.Parameters["@city"].Value = city;


                objSqlCommand.Parameters.Add("@code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@code"].Value = code;

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


		public DataSet pcmstatuscheck(string compcode,string userid,string centcode,string status,string circular,string todate,string fromdate,string dateformat)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("pcmstatuschk", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
				
				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;

				objSqlCommand.Parameters.Add("@centcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@centcode"].Value =centcode;
				
				objSqlCommand.Parameters.Add("@status", SqlDbType.VarChar);
				objSqlCommand.Parameters["@status"].Value =status;
 
				objSqlCommand.Parameters.Add("@circular", SqlDbType.VarChar);
				objSqlCommand.Parameters["@circular"].Value =circular;
 
				objSqlCommand.Parameters.Add("@todate", SqlDbType.DateTime);
                if (todate == "" || todate == null )//|| validtill == "undefined/undefined/")
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
				objSqlCommand.Parameters.Add("@date", SqlDbType.VarChar);
				objSqlCommand.Parameters["@date"].Value =dateformat;
 
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

        //Code for the insert the status by clicking on link Button//
        public DataSet insertpcmstatus(string compcode, string userid, string centcode, string status, string fromdate, string todate, string circular)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("pcmstatusin", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
				
				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;

				objSqlCommand.Parameters.Add("@centcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@centcode"].Value =centcode;
				
				objSqlCommand.Parameters.Add("@status", SqlDbType.VarChar);
				objSqlCommand.Parameters["@status"].Value =status;
 
				objSqlCommand.Parameters.Add("@circular", SqlDbType.VarChar);
				objSqlCommand.Parameters["@circular"].Value =circular;
 
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



		public DataSet pcmstatuscheck12(string compcode,string userid,string centcode,string status,string circular,string todate,string fromdate,string dateformat,string codepass)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("pcmstatuschk12", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
				
				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;

				objSqlCommand.Parameters.Add("@centcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@centcode"].Value =centcode;
				
				objSqlCommand.Parameters.Add("@status", SqlDbType.VarChar);
				objSqlCommand.Parameters["@status"].Value =status;
 
				objSqlCommand.Parameters.Add("@circular", SqlDbType.VarChar);
				objSqlCommand.Parameters["@circular"].Value =circular;
 
				objSqlCommand.Parameters.Add("@todate", SqlDbType.VarChar);
				objSqlCommand.Parameters["@todate"].Value =todate;
 
				objSqlCommand.Parameters.Add("@fromdate", SqlDbType.VarChar);
				objSqlCommand.Parameters["@fromdate"].Value =fromdate;

				objSqlCommand.Parameters.Add("@date", SqlDbType.VarChar);
				objSqlCommand.Parameters["@date"].Value =dateformat;

				objSqlCommand.Parameters.Add("@code", SqlDbType.VarChar);
				objSqlCommand.Parameters["@code"].Value =codepass;
 
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





        //Code for the Update the status by clicking on link Button//
		public DataSet updatepcmstatus(string compcode,string userid,string centcode,string status,string circular,string todate,string fromdate,string codepass)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("pcmstatusupdate", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
				
				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;

				objSqlCommand.Parameters.Add("@centcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@centcode"].Value =centcode;
				
				objSqlCommand.Parameters.Add("@status", SqlDbType.VarChar);
				objSqlCommand.Parameters["@status"].Value =status;
 
				objSqlCommand.Parameters.Add("@circular", SqlDbType.VarChar);
				objSqlCommand.Parameters["@circular"].Value =circular;
 
				objSqlCommand.Parameters.Add("@todate", SqlDbType.VarChar);
				objSqlCommand.Parameters["@todate"].Value =todate;
 
				objSqlCommand.Parameters.Add("@fromdate", SqlDbType.VarChar);
				objSqlCommand.Parameters["@fromdate"].Value =fromdate;

				objSqlCommand.Parameters.Add("@code", SqlDbType.VarChar);
				objSqlCommand.Parameters["@code"].Value =codepass;
 
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




        //Code for the Delete the status by clicking on link Button//
		public DataSet deletepcmstatus(string centcode,string compcode,string userid,string codepass)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("pcmstatdel", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
				
				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;

				objSqlCommand.Parameters.Add("@centcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@centcode"].Value =centcode;
				
				objSqlCommand.Parameters.Add("@code", SqlDbType.VarChar);
				objSqlCommand.Parameters["@code"].Value =codepass;
 
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





		public DataSet selectpcmstatus(string centcode,string compcode,string userid,string code11,string dateformat)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("pcmselect", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
				
				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;

				objSqlCommand.Parameters.Add("@centcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@centcode"].Value =centcode;
				
				
				objSqlCommand.Parameters.Add("@code11", SqlDbType.VarChar);
				objSqlCommand.Parameters["@code11"].Value =code11;


				objSqlCommand.Parameters.Add("@dateformat", SqlDbType.VarChar);
				objSqlCommand.Parameters["@dateformat"].Value =dateformat;

				 
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


        //Code for the Update the Contact of person  by clicking on link Button//
		public DataSet contactupdate (string contactperson,string dob,string desi,string phone,string ext,string fax,string mail,string compcode,string userid,string centcode,string update)
		{
		
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter;
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("pcmcontactupdate", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 
				objSqlCommand.Parameters.Add("@centcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@centcode"].Value =centcode;

				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;

				objSqlCommand.Parameters.Add("@contactperson", SqlDbType.VarChar);
				objSqlCommand.Parameters["@contactperson"].Value =contactperson;

				objSqlCommand.Parameters.Add("@desi", SqlDbType.VarChar);
				objSqlCommand.Parameters["@desi"].Value =desi;


                //objSqlCommand.Parameters.Add("@dob", SqlDbType.DateTime);
                //objSqlCommand.Parameters["@dob"].Value = Convert.ToDateTime(dob);

                objSqlCommand.Parameters.Add("@dob", SqlDbType.DateTime);
                if (dob == "" || dob == null || dob == "Undefined")
                {
                    objSqlCommand.Parameters["@dob"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@dob"].Value = Convert.ToDateTime(dob);
                }

				objSqlCommand.Parameters.Add("@phone", SqlDbType.VarChar);
				objSqlCommand.Parameters["@phone"].Value =phone;

				objSqlCommand.Parameters.Add("@ext", SqlDbType.VarChar);
				objSqlCommand.Parameters["@ext"].Value =ext;

				objSqlCommand.Parameters.Add("@fax", SqlDbType.VarChar);
				objSqlCommand.Parameters["@fax"].Value =fax;

				objSqlCommand.Parameters.Add("@mail", SqlDbType.VarChar);
				objSqlCommand.Parameters["@mail"].Value =mail;

				
				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				

				objSqlCommand.Parameters.Add("@update", SqlDbType.VarChar);
				objSqlCommand.Parameters["@update"].Value =update;


				
					
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


        //Code for the Insert the Contact of person  by clicking on link Button//
        public DataSet insertcontact(string contact, string dob, string desi, string phone, string ext, string fax, string mail, string userid, string centcode, string compcode)
		{
			
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter;
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("pcmcontactdetails", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 
				objSqlCommand.Parameters.Add("@centcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@centcode"].Value =centcode;

				objSqlCommand.Parameters.Add("@contact", SqlDbType.VarChar);
				objSqlCommand.Parameters["@contact"].Value =contact;

				objSqlCommand.Parameters.Add("@desi", SqlDbType.VarChar);
				objSqlCommand.Parameters["@desi"].Value =desi;

				
				objSqlCommand.Parameters.Add("@dob", SqlDbType.DateTime);
				if(dob=="" || dob==null || dob=="Undefined")
				{
					objSqlCommand.Parameters["@dob"].Value=System.DBNull.Value;
				}
				else
				{
					objSqlCommand.Parameters["@dob"].Value =Convert.ToDateTime(dob);
				}

				objSqlCommand.Parameters.Add("@phone",SqlDbType.VarChar);
				//if (Comment =="" || Comment==null)
				objSqlCommand.Parameters["@phone"].Value=phone;
				//else

				objSqlCommand.Parameters.Add("@ext", SqlDbType.VarChar);
				objSqlCommand.Parameters["@ext"].Value =ext;

				objSqlCommand.Parameters.Add("@fax", SqlDbType.VarChar);
				objSqlCommand.Parameters["@fax"].Value =fax;

				objSqlCommand.Parameters.Add("@mail", SqlDbType.VarChar);
				objSqlCommand.Parameters["@mail"].Value =mail;

				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;


				
				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;



				
					
				objSqlDataAdapter =new SqlDataAdapter();
				objSqlDataAdapter.SelectCommand =objSqlCommand;
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




        public DataSet pcmcontbind(string centcode, string compcode, string userid, string dateformat)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("pcmcontbind", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;


				objSqlCommand.Parameters.Add("@centcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@centcode"].Value =centcode;

				objSqlCommand.Parameters.Add("@date", SqlDbType.VarChar);
				objSqlCommand.Parameters["@date"].Value =dateformat;


				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;

				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;


				 
				objSqlDataAdapter.SelectCommand = objSqlCommand;
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



        //Code for the Select the Contact of person  by clicking on Check boxes//
		public DataSet selpcmbind(string centcode,string userid,string compcode)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("pcmselcont", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;


				objSqlCommand.Parameters.Add("@contcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@contcode"].Value =centcode;


				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;

				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;


				 
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
        //Code for the Delete the Contact of person  by clicking on Delete Button//
		public DataSet pcmcontdelete(string centcode,string compcode,string userid,string update)
			
		{
			
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter;
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("pcmcontdelete", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 
				objSqlCommand.Parameters.Add("@centcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@centcode"].Value =centcode;

				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;

				objSqlCommand.Parameters.Add("@update", SqlDbType.VarChar);
				objSqlCommand.Parameters["@update"].Value =update;
	
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

       
        public DataSet pubcatcode(/*string cod, */string str, string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("autopubcatcode", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@str", SqlDbType.VarChar);
                objSqlCommand.Parameters["@str"].Value = str;

                objSqlCommand.Parameters.Add("@cod", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cod"].Value = str;

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

        public DataSet pubcodechk(string str, string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("chkpubcatcode", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                 objSqlCommand.Parameters.Add("@str", SqlDbType.VarChar);
                objSqlCommand.Parameters["@str"].Value = str;

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
        public DataSet bindcontact(string compcode, string userid, string centcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("pcmbinddata", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@centcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@centcode"].Value = centcode;


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

        public DataSet chkcolor(string contactperson1, string centcode, string compcode)
        {
            SqlCommand cmd;
            SqlConnection con;
            con = GetConnection();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();
                cmd = GetCommand("pub_chkname", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@centcode", SqlDbType.VarChar);
                cmd.Parameters["@centcode"].Value = centcode;

                cmd.Parameters.Add("@compcode", SqlDbType.VarChar);
                cmd.Parameters["@compcode"].Value = compcode;

                cmd.Parameters.Add("@contactper", SqlDbType.VarChar);
                cmd.Parameters["@contactper"].Value = contactperson1;

                da.SelectCommand = cmd;

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

          //txtphoneno,txtext,txtfaxno,mail,desi,txtdob

        public DataSet chkcolormod(string contactperson1, string centcode, string compcode, string txtphoneno, string txtext, string txtfaxno, string mail, string desi, string txtdob)
        {
            SqlCommand cmd;
            SqlConnection con;
            con = GetConnection();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();
                cmd = GetCommand("pub_chkname_mod", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                //cmd.Parameters.Add("@code", SqlDbType.VarChar);
                //cmd.Parameters["@code"].Value = crgcode;

                //saurabh add 
                cmd.Parameters.Add("@centcode", SqlDbType.VarChar);
                cmd.Parameters["@centcode"].Value = centcode;

                cmd.Parameters.Add("@compcode", SqlDbType.VarChar);
                cmd.Parameters["@compcode"].Value = compcode;

                cmd.Parameters.Add("@contactper", SqlDbType.VarChar);
                cmd.Parameters["@contactper"].Value = contactperson1;

                //txtphoneno,txtext,txtfaxno,mail,desi,txtdob

                cmd.Parameters.Add("@txtphoneno", SqlDbType.VarChar);
                cmd.Parameters["@txtphoneno"].Value = txtphoneno;

                cmd.Parameters.Add("@txtext", SqlDbType.VarChar);
                cmd.Parameters["@txtext"].Value = txtext;

                cmd.Parameters.Add("@txtfaxno", SqlDbType.VarChar);
                cmd.Parameters["@txtfaxno"].Value = txtfaxno;

                cmd.Parameters.Add("@mail", SqlDbType.VarChar);
                cmd.Parameters["@mail"].Value = mail;

                cmd.Parameters.Add("@desi", SqlDbType.VarChar);
                cmd.Parameters["@desi"].Value = desi;

                cmd.Parameters.Add("@txtdob", SqlDbType.VarChar);
                cmd.Parameters["@txtdob"].Value = txtdob;

                da.SelectCommand = cmd;

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

        public DataSet chkusercode(string compcode, string code)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("pcmusercodechk", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@code"].Value = compcode;

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

        //=================================================================//

        public DataSet pubnamechk(string str)//, string city)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("chkbranchname", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@str", SqlDbType.VarChar);
                objSqlCommand.Parameters["@str"].Value = str;

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

        public DataSet bind_agency(string code, string unit, string brcode, string dateformat, string extra1, string extra2)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();

            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("cir_agency_bind_cir_agency_bind_p", ref objSqlConnection);

                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlDataAdapter = new SqlDataAdapter();



                objSqlCommand.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcompcode"].Value = code;


                objSqlCommand.Parameters.Add("@punit", SqlDbType.VarChar);
                objSqlCommand.Parameters["@punit"].Value = unit;


                //objSqlCommand.Parameters.Add("@pbranchcode", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@pbranchcode"].Value = brcode;




                objSqlCommand.Parameters.Add("@pdateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdateformat"].Value = dateformat;


                objSqlCommand.Parameters.Add("@pextra1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra1"].Value = extra1;




                objSqlCommand.Parameters.Add("@pextra2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra2"].Value = extra2;


                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objSqlConnection.Close();

            }
        }

        public DataSet get_agency_name(string comp, string unit, string agcd, string dpcd)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();

            try
            {
                objSqlConnection.Open();
                objSqlCommand = new SqlCommand();
                string query = "select dbo.cir_get_agency('" + comp + "','" + unit + "','" + agcd + "','" + dpcd + "') as AG_NAME";// from dual"; 
                objSqlDataAdapter = new SqlDataAdapter();
                objSqlCommand = new SqlCommand();
                objSqlCommand.CommandText = query;
                objSqlCommand.Connection = objSqlConnection;
                objSqlCommand.ExecuteNonQuery();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objSqlConnection.Close();

            }
        }

       /* public DataSet get_agency_name(string code, string unit, string agcd, string dpcd, string dateformat, string extra1, string extra2)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();

            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("cir_agency_bind_cir_agency_bind_p1", ref objSqlConnection);

                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlDataAdapter = new SqlDataAdapter();



                objSqlCommand.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcompcode"].Value = code;



                objSqlCommand.Parameters.Add("@punit", SqlDbType.VarChar);
                objSqlCommand.Parameters["@punit"].Value = unit;


                objSqlCommand.Parameters.Add("@pagcd", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pagcd"].Value = agcd;


                objSqlCommand.Parameters.Add("@pdpcd", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdpcd"].Value = dpcd;



                objSqlCommand.Parameters.Add("@pdateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdateformat"].Value = dateformat;



                objSqlCommand.Parameters.Add("@pextra1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra1"].Value = extra1;



                objSqlCommand.Parameters.Add("@pextra2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra2"].Value = extra2;


                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objSqlConnection.Close();

            }
        }
      */

    }
}
    
