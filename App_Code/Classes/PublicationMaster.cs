using System;
using System.Data;
using System.Data.SqlClient;

namespace NewAdbooking.Classes
{
	/// <summary>
	/// Summary description for PublicationMaster.
	/// </summary>
	public class PublicationMaster:connection
	{
		public PublicationMaster()
		{
			//
			// TODO: Add constructor logic here
			//
		}

	public DataSet addlang(string compcode)
    {
		SqlConnection objSqlConnection;
		SqlCommand objSqlCommand;
		objSqlConnection = GetConnection();
		SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
		DataSet objDataSet = new DataSet();	
		try
		{
			objSqlConnection.Open();
			objSqlCommand = GetCommand("PubAddLanguage", ref objSqlConnection);
			objSqlCommand.CommandType = CommandType.StoredProcedure;

            objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@compcode"].Value = compcode;
 
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


       // public DataSet pubsave(string compcode, string priority, string pubcode, string pubname, string pubalias, string langcode, string estdate, string contperson, string phone, string fax, string emailid, string userid)
    public DataSet pubsave(string compcode, string pubcode, string pubname, string pubalias, string langcode, string priority, string estdate, string contperson, string phone, string fax, string emailid, string userid, string pubtype, string preocity, string txtphone2, string txtfaxno1, string txtgutter, string txtcolspc, string hr, string mint, string prod, string noofcol, string publish_code, string prefix, string MRV, string mobileno,string  acc_cd, string sacc_cd)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("pubsave", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@comcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@comcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@pubcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pubcode"].Value = pubcode;

                objSqlCommand.Parameters.Add("@pubname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pubname"].Value = pubname;

                objSqlCommand.Parameters.Add("@pubalias", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pubalias"].Value = pubalias;

                objSqlCommand.Parameters.Add("@langcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@langcode"].Value = langcode;

                objSqlCommand.Parameters.Add("@priority", SqlDbType.VarChar);
                objSqlCommand.Parameters["@priority"].Value = priority;

                //objSqlCommand.Parameters.Add("@estdate", SqlDbType.DateTime);
                //if(estdate.ToString()!=""  || estdate.ToString()!=null)



                objSqlCommand.Parameters.Add("@estdate", SqlDbType.DateTime);
                if (estdate == "" || estdate == null || estdate == "undefined")
                {
                    objSqlCommand.Parameters["@estdate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@estdate"].Value = Convert.ToDateTime(estdate);

                }

                objSqlCommand.Parameters.Add("@contperson", SqlDbType.VarChar);
                objSqlCommand.Parameters["@contperson"].Value = contperson;

                objSqlCommand.Parameters.Add("@phone", SqlDbType.VarChar);
                objSqlCommand.Parameters["@phone"].Value = phone;

                objSqlCommand.Parameters.Add("@fax", SqlDbType.VarChar);
                objSqlCommand.Parameters["@fax"].Value = fax;

                objSqlCommand.Parameters.Add("@emailid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@emailid"].Value = emailid;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@pubtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pubtype"].Value = pubtype;

                objSqlCommand.Parameters.Add("@phone2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@phone2"].Value = txtphone2;

                objSqlCommand.Parameters.Add("@fax2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@fax2"].Value = txtfaxno1;


                objSqlCommand.Parameters.Add("@preocity", SqlDbType.VarChar);
                objSqlCommand.Parameters["@preocity"].Value = preocity;

                objSqlCommand.Parameters.Add("@gutter_space", SqlDbType.VarChar);
                objSqlCommand.Parameters["@gutter_space"].Value = txtgutter;

                objSqlCommand.Parameters.Add("@column_space", SqlDbType.VarChar);
                objSqlCommand.Parameters["@column_space"].Value = txtcolspc;

                objSqlCommand.Parameters.Add("@hr", SqlDbType.VarChar);
                objSqlCommand.Parameters["@hr"].Value = hr;

                objSqlCommand.Parameters.Add("@mint", SqlDbType.VarChar);
                objSqlCommand.Parameters["@mint"].Value = mint;

                objSqlCommand.Parameters.Add("@prod", SqlDbType.VarChar);
                objSqlCommand.Parameters["@prod"].Value = prod;

                /*change ankur*/
                objSqlCommand.Parameters.Add("@noofcol", SqlDbType.VarChar);
                objSqlCommand.Parameters["@noofcol"].Value = noofcol;

                objSqlCommand.Parameters.Add("@publish_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@publish_code"].Value = publish_code;

                objSqlCommand.Parameters.Add("@prefix", SqlDbType.VarChar);
                objSqlCommand.Parameters["@prefix"].Value = publish_code;
                 
                    objSqlCommand.Parameters.Add("@mrv", SqlDbType.VarChar);
                    objSqlCommand.Parameters["@mrv"].Value = MRV;


                    objSqlCommand.Parameters.Add("@mobileno", SqlDbType.VarChar);
                    objSqlCommand.Parameters["@mobileno"].Value = mobileno;

                    objSqlCommand.Parameters.Add("@SAC_CODE", SqlDbType.VarChar);
                    objSqlCommand.Parameters["@SAC_CODE"].Value = acc_cd;

                    objSqlCommand.Parameters.Add("@SUB_SAC_CODE", SqlDbType.VarChar);
                    objSqlCommand.Parameters["@SUB_SAC_CODE"].Value = sacc_cd;
                ////////////////////

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


        public DataSet pubmodify(string compcode, string pubcode, string pubname, string pubalias, string langcode, string priority, string estdate, string contperson, string phone, string fax, string emailid, string userid, string pubtype, string preocity, string txtphone2, string txtfaxno1, string txtgutter, string txtcolspc, string hr, string mint, string prod, string noofcol, string publish_code, string prefix, string MRV, string moblieno)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("pub_modify", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@comcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@comcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@pubcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pubcode"].Value = pubcode;

                objSqlCommand.Parameters.Add("@pubname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pubname"].Value = pubname;

                objSqlCommand.Parameters.Add("@pubalias", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pubalias"].Value = pubalias;

                objSqlCommand.Parameters.Add("@langcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@langcode"].Value = langcode;

                objSqlCommand.Parameters.Add("@priority", SqlDbType.VarChar);
                objSqlCommand.Parameters["@priority"].Value = priority;

                objSqlCommand.Parameters.Add("@estdate", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@estdate"].Value =estdate;
                //if(estdate!="" )
                if (estdate == "" || estdate == null)
                {
                    objSqlCommand.Parameters["@estdate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@estdate"].Value = Convert.ToDateTime(estdate);
                }

                objSqlCommand.Parameters.Add("@contperson", SqlDbType.VarChar);
                objSqlCommand.Parameters["@contperson"].Value = contperson;

                objSqlCommand.Parameters.Add("@phone", SqlDbType.VarChar);
                objSqlCommand.Parameters["@phone"].Value = phone;

                objSqlCommand.Parameters.Add("@fax", SqlDbType.VarChar);
                objSqlCommand.Parameters["@fax"].Value = fax;


                objSqlCommand.Parameters.Add("@emailid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@emailid"].Value = emailid;

                //objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@userid"].Value =userid;

                objSqlCommand.Parameters.Add("@pubtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pubtype"].Value = pubtype;

                objSqlCommand.Parameters.Add("@preocity", SqlDbType.VarChar);
                objSqlCommand.Parameters["@preocity"].Value = preocity;

                objSqlCommand.Parameters.Add("@phone2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@phone2"].Value = txtphone2;

                objSqlCommand.Parameters.Add("@fax2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@fax2"].Value = txtfaxno1;

                objSqlCommand.Parameters.Add("@gutter_space", SqlDbType.VarChar);
                objSqlCommand.Parameters["@gutter_space"].Value = txtgutter;

                objSqlCommand.Parameters.Add("@column_space", SqlDbType.VarChar);
                objSqlCommand.Parameters["@column_space"].Value = txtcolspc;


                objSqlCommand.Parameters.Add("@hr", SqlDbType.VarChar);
                objSqlCommand.Parameters["@hr"].Value = hr;

                objSqlCommand.Parameters.Add("@mint", SqlDbType.VarChar);
                objSqlCommand.Parameters["@mint"].Value = mint;

                objSqlCommand.Parameters.Add("@prod", SqlDbType.VarChar);
                objSqlCommand.Parameters["@prod"].Value = prod;

                /*change ankur*/
                objSqlCommand.Parameters.Add("@noofcol", SqlDbType.VarChar);
                objSqlCommand.Parameters["@noofcol"].Value = noofcol;

                objSqlCommand.Parameters.Add("@publish_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@publish_code"].Value = publish_code;

                objSqlCommand.Parameters.Add("@prefix", SqlDbType.VarChar);
                objSqlCommand.Parameters["@prefix"].Value = prefix;

                objSqlCommand.Parameters.Add("@mrv", SqlDbType.VarChar);
                objSqlCommand.Parameters["@mrv"].Value = MRV;


                objSqlCommand.Parameters.Add("@mobileno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@mobileno"].Value = moblieno;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                ///////////////////////////////////

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

        public DataSet pubexecute(string compcode, string pubcode, string pubname, string pubalias, string langcode,string pubtype,string preocity)
		
        {
		
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("pubexecute", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 				
                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value =compcode;
				
				objSqlCommand.Parameters.Add("@pubcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pubcode"].Value = pubcode;
                //if (pubcode == null || pubcode == "")
                //{
                //    objSqlCommand.Parameters["@pubcode"].Value = "%%";
                //}
                //else
                //{
                //    objSqlCommand.Parameters["@pubcode"].Value = pubcode;
                //}
                

                objSqlCommand.Parameters.Add("@pubname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pubname"].Value = pubname;

                //if (pubname == null || pubname == "")
                //{
                //    objSqlCommand.Parameters["@pubname"].Value = "%%";
                //}
                //else
                //{
                //    objSqlCommand.Parameters["@pubname"].Value = pubname;
                //}
                objSqlCommand.Parameters.Add("@pubalias", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pubalias"].Value = pubalias;

                //if (pubalias == null || pubalias == "")
                //{
                //    objSqlCommand.Parameters["@pubalias"].Value = "%%";
                //}
                //else
                //{
                //    objSqlCommand.Parameters["@pubalias"].Value = pubalias;
                //}
				
                objSqlCommand.Parameters.Add("@langcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@langcode"].Value = langcode;

                //if (langcode == null || langcode == "")
                //{
                //    objSqlCommand.Parameters["@langcode"].Value = "%%";
                //}
                //else
                //{
                //    objSqlCommand.Parameters["@langcode"].Value = langcode;
                //}



                objSqlCommand.Parameters.Add("@pubtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pubtype"].Value = pubtype;

                objSqlCommand.Parameters.Add("@preocity", SqlDbType.VarChar);
                objSqlCommand.Parameters["@preocity"].Value = preocity;

                //objSqlCommand.Parameters.Add("@gutter_space", SqlDbType.Int);
                //objSqlCommand.Parameters["@gutter_space"].Value = Convert.ToInt32(gtrspc);

                //objSqlCommand.Parameters.Add("@column_space", SqlDbType.Int);
                //objSqlCommand.Parameters["@column_space"].Value = Convert.ToInt32(colspc);

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


        //if(langcode!= null&& langcode!="" && langcode!="0")
        //{
        //    objSqlCommand.Parameters["@langcode"].Value =langcode;

        //}
        //else
        //{

        //if(pubalias!= null&& pubalias!="" && pubalias!="undefined")
        //{
        //        objSqlCommand.Parameters["@pubalias"].Value =pubalias;
        //}
        //else
        //{
        //if(pubcode!= null&& pubcode!="" && pubcode!="undefined")
        //{
        //objSqlCommand.Parameters["@pubcode"].Value =pubcode;
        //}
        //else
        //{
        //objSqlCommand.Parameters["@pubcode"].Value ="%%";
        //}

        //objSqlCommand.Parameters["@langcode"].Value ="%%";
        //}


        //objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
        //objSqlCommand.Parameters["@userid"].Value =userid;

		public DataSet 	selectpublication()
		{		
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("selectpublication", ref objSqlConnection);
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



		public DataSet 	selectpubdaysave(string compcode,string pubcode,string sun,string mon,string tue,string wed,string thu,string fri,string sat,string all,string userid)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("slelectpubdaysave", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 				
				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;
				
				objSqlCommand.Parameters.Add("@pubcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@pubcode"].Value =pubcode;

				objSqlCommand.Parameters.Add("@sun", SqlDbType.VarChar);
				objSqlCommand.Parameters["@sun"].Value =sun;
				
				objSqlCommand.Parameters.Add("@mon", SqlDbType.VarChar);
				objSqlCommand.Parameters["@mon"].Value =mon;

				objSqlCommand.Parameters.Add("@tue", SqlDbType.VarChar);
				objSqlCommand.Parameters["@tue"].Value =tue;

				objSqlCommand.Parameters.Add("@wed", SqlDbType.VarChar);
				objSqlCommand.Parameters["@wed"].Value =wed;
				
				objSqlCommand.Parameters.Add("@thu", SqlDbType.VarChar);
				objSqlCommand.Parameters["@thu"].Value =thu;

				objSqlCommand.Parameters.Add("@fri", SqlDbType.VarChar);
				objSqlCommand.Parameters["@fri"].Value =fri;

				objSqlCommand.Parameters.Add("@sat", SqlDbType.VarChar);
				objSqlCommand.Parameters["@sat"].Value =sat;
				
				objSqlCommand.Parameters.Add("@all", SqlDbType.VarChar);
				objSqlCommand.Parameters["@all"].Value =all;
								
				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;

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


		public DataSet 	checkpubcode(string compcode,string pubcode,string userid)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("checkpubcode", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 				
				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;
				
				objSqlCommand.Parameters.Add("@pubcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@pubcode"].Value =pubcode;

				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;

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





		public DataSet 	selectpubdaymodify(string compcode,string pubcode,string sun,string mon,string tue,string wed,string thu,string fri,string sat,string all,string userid)
		{
		
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	

			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("slelectpubdaymodify", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 				
				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;
				
				objSqlCommand.Parameters.Add("@pubcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@pubcode"].Value =pubcode;

				objSqlCommand.Parameters.Add("@sun", SqlDbType.VarChar);
				objSqlCommand.Parameters["@sun"].Value =sun;
				
				objSqlCommand.Parameters.Add("@mon", SqlDbType.VarChar);
				objSqlCommand.Parameters["@mon"].Value =mon;


				objSqlCommand.Parameters.Add("@tue", SqlDbType.VarChar);
				objSqlCommand.Parameters["@tue"].Value =tue;

				objSqlCommand.Parameters.Add("@wed", SqlDbType.VarChar);
				objSqlCommand.Parameters["@wed"].Value =wed;
				
				objSqlCommand.Parameters.Add("@thu", SqlDbType.VarChar);
				objSqlCommand.Parameters["@thu"].Value =thu;


				objSqlCommand.Parameters.Add("@fri", SqlDbType.VarChar);
				objSqlCommand.Parameters["@fri"].Value =fri;

				objSqlCommand.Parameters.Add("@sat", SqlDbType.VarChar);
				objSqlCommand.Parameters["@sat"].Value =sat;
				
				objSqlCommand.Parameters.Add("@all", SqlDbType.VarChar);
				objSqlCommand.Parameters["@all"].Value =all;
								
                //objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@userid"].Value =userid;

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


		public DataSet 	pubdelete(string compcode,string pubcode)
		{
		
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	

			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("publicationdelete", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 				
				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;
				
				objSqlCommand.Parameters.Add("@pubcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@pubcode"].Value =pubcode;
							
                //objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@userid"].Value =userid;

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


		public DataSet publicationcheck(string compcode,string pubcode,string userid)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("publicationcheck", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
 				
				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;
				
				objSqlCommand.Parameters.Add("@pubcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@pubcode"].Value =pubcode;
							
				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;

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

        public DataSet publicationmastr(/*string cod,*/string str)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("autopublicatcode", ref objSqlConnection);
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


        public DataSet pubcity(string citycode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("publicationcity", ref objSqlConnection);
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

        public DataSet publicationtype()
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("addpublicationtype", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

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


        public DataSet preodicityname(string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("addpreodicity", ref objSqlConnection);
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

        //*********************By Manish*************************************
        public DataSet chkPriority(string compCode,string priority)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("chkPubPriority", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@comp_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@comp_code"].Value = compCode;

                objSqlCommand.Parameters.Add("@Priority", SqlDbType.VarChar);
                objSqlCommand.Parameters["@Priority"].Value = priority;

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



        //================ ad by rinki=======================///

        public DataSet publisher(string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("bindpublisher", ref objSqlConnection);
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
        //*******************************************************************


        //public DataSet chkinsbull(string compcode, string userid, string adsizecode, string abc)
        //{
        //    SqlConnection objSqlConnection;
        //    SqlCommand objSqlCommand;
        //    objSqlConnection = GetConnection();
        //    SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
        //    DataSet objDataSet = new DataSet();
        //    try
        //    {
        //        objSqlConnection.Open();
        //        objSqlCommand = GetCommand("insertmulticity", ref objSqlConnection);
        //        objSqlCommand.CommandType = CommandType.StoredProcedure;

        //        objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
        //        objSqlCommand.Parameters["@compcode"].Value = compcode;

        //        objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
        //        objSqlCommand.Parameters["@userid"].Value = userid;




        //        objSqlCommand.Parameters.Add("@adsizecode", SqlDbType.VarChar);
        //        objSqlCommand.Parameters["@adsizecode"].Value = adsizecode;

        //        objSqlCommand.Parameters.Add("@abc", SqlDbType.VarChar);
        //        objSqlCommand.Parameters["@abc"].Value = abc;

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


        //public DataSet chkmulticity(string compcode, string userid, string pubcode)
        //{
        //    SqlConnection objSqlConnection;
        //    SqlCommand objSqlCommand;
        //    objSqlConnection = GetConnection();
        //    SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
        //    DataSet objDataSet = new DataSet();
        //    try
        //    {
        //        objSqlConnection.Open();
        //        objSqlCommand = GetCommand("chkmulticityselect", ref objSqlConnection);
        //        objSqlCommand.CommandType = CommandType.StoredProcedure;

        //        objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
        //        objSqlCommand.Parameters["@compcode"].Value = compcode;

        //        objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
        //        objSqlCommand.Parameters["@userid"].Value = userid;

        //        objSqlCommand.Parameters.Add("@pubcode", SqlDbType.VarChar);
        //        objSqlCommand.Parameters["@pubcode"].Value = pubcode;



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


	}
}