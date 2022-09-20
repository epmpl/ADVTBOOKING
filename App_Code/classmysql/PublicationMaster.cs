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
/// Summary description for PublicationMaster
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
        MySqlConnection objmysqlconnection;
        MySqlCommand objmysqlcommand;
        objmysqlconnection = GetConnection();
        MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
        DataSet objDataSet = new DataSet();	
		try
		{
			objmysqlconnection.Open();
            objmysqlcommand = GetCommand("PubAddLanguage_PubAddLanguage_p", ref objmysqlconnection);
			objmysqlcommand.CommandType = CommandType.StoredProcedure;

            objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["compcode"].Value = compcode;
 
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


       // public DataSet pubsave(string compcode, string priority, string pubcode, string pubname, string pubalias, string langcode, string estdate, string contperson, string phone, string fax, string emailid, string userid)
    public DataSet pubsave(string compcode, string pubcode, string pubname, string pubalias, string langcode, string priority, string estdate, string contperson, string phone, string fax, string emailid, string userid, string pubtype, string preocity, string txtphone2, string txtfaxno1, string txtgutter, string txtcolspc, string hr, string mint, string prod, string noofcol, string publish_code, string prefix, string MRV, string integration,string mobileno,string acc_cd,string sacc_cd)
		{
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
			try
			{
				objmysqlconnection.Open();
                objmysqlcommand = GetCommand("pubsave_pubsave_p", ref objmysqlconnection);
				objmysqlcommand.CommandType = CommandType.StoredProcedure;
 				
				objmysqlcommand.Parameters.Add("comcode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["comcode"].Value =compcode;
				
				objmysqlcommand.Parameters.Add("pubcode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["pubcode"].Value =pubcode;

				objmysqlcommand.Parameters.Add("pubname", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["pubname"].Value =pubname;
				
				objmysqlcommand.Parameters.Add("pubalias", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["pubalias"].Value =pubalias;

				objmysqlcommand.Parameters.Add("langcode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["langcode"].Value =langcode;

				objmysqlcommand.Parameters.Add("priority", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["priority"].Value =priority;
				
				//objmysqlcommand.Parameters.Add("estdate", MySqlDbType.DateTime);
				//if(estdate.ToString()!=""  || estdate.ToString()!=null)



                objmysqlcommand.Parameters.Add("estdate", MySqlDbType.DateTime);
                if (estdate== "" || estdate== null ||estdate=="undefined")
				{
                    objmysqlcommand.Parameters["estdate"].Value = System.DBNull.Value;
				}
				else
				{
                    objmysqlcommand.Parameters["estdate"].Value = Convert.ToDateTime(estdate);
					
				}

				objmysqlcommand.Parameters.Add("contperson", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["contperson"].Value =contperson;

				objmysqlcommand.Parameters.Add("phone", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["phone"].Value =phone;
				
				objmysqlcommand.Parameters.Add("fax", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["fax"].Value =fax;

				objmysqlcommand.Parameters.Add("emailid", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["emailid"].Value =emailid;
				
				objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["userid"].Value =userid;

                objmysqlcommand.Parameters.Add("pubtype", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pubtype"].Value = pubtype;

                objmysqlcommand.Parameters.Add("phone2", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["phone2"].Value = txtphone2;

                objmysqlcommand.Parameters.Add("fax2", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["fax2"].Value = txtfaxno1;


                objmysqlcommand.Parameters.Add("preocity", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["preocity"].Value = preocity;

                objmysqlcommand.Parameters.Add("gutter_space", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["gutter_space"].Value= txtgutter;

                objmysqlcommand.Parameters.Add("column_space", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["column_space"].Value = txtcolspc;

                objmysqlcommand.Parameters.Add("hr", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["hr"].Value = hr;

                objmysqlcommand.Parameters.Add("mint", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["mint"].Value = mint;

                objmysqlcommand.Parameters.Add("prod", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["prod"].Value = prod;

                objmysqlcommand.Parameters.Add("noofcol", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["noofcol"].Value = noofcol;

                objmysqlcommand.Parameters.Add("publish_code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["publish_code"].Value = publish_code;


                objmysqlcommand.Parameters.Add("prefix", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["prefix"].Value = prefix;


                objmysqlcommand.Parameters.Add("mrv", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["mrv"].Value = MRV;


                objmysqlcommand.Parameters.Add("integration", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["integration"].Value = integration;

                objmysqlcommand.Parameters.Add("pmobileno", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pmobileno"].Value = integration;

                objmysqlcommand.Parameters.Add("pacc_cd", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pacc_cd"].Value = integration;

                objmysqlcommand.Parameters.Add("psacc_cd", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["psacc_cd"].Value = integration;

               
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


    public DataSet pubmodify(string compcode, string pubcode, string pubname, string pubalias, string langcode, string priority, string estdate, string contperson, string phone, string fax, string emailid, string userid, string pubtype, string preocity, string txtphone2, string txtfaxno1, string txtgutter, string txtcolspc, string hr, string mint, string prod, string noofcol, string publishcode,string prefix,string MRV ,string integration)
		{
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
			try
			{
				objmysqlconnection.Open();
				objmysqlcommand = GetCommand("pub_modify", ref objmysqlconnection);
				objmysqlcommand.CommandType = CommandType.StoredProcedure;
 				
				objmysqlcommand.Parameters.Add("comcode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["comcode"].Value =compcode;
				
				objmysqlcommand.Parameters.Add("pubcode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["pubcode"].Value =pubcode;

				objmysqlcommand.Parameters.Add("pubname", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["pubname"].Value =pubname;
				
				objmysqlcommand.Parameters.Add("pubalias", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["pubalias"].Value =pubalias;

				objmysqlcommand.Parameters.Add("langcode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["langcode"].Value =langcode;

				objmysqlcommand.Parameters.Add("priority", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["priority"].Value =priority;
				
				objmysqlcommand.Parameters.Add("estdate", MySqlDbType.VarChar);
				//objmysqlcommand.Parameters["estdate"].Value =estdate;
				//if(estdate!="" )
                if (estdate == "" || estdate == null)
				{
                    objmysqlcommand.Parameters["estdate"].Value = System.DBNull.Value;
				}
				else
				{
                    objmysqlcommand.Parameters["estdate"].Value = Convert.ToDateTime(estdate); 
				}

				objmysqlcommand.Parameters.Add("contperson", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["contperson"].Value =contperson;

				objmysqlcommand.Parameters.Add("phone", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["phone"].Value =phone;
				
				objmysqlcommand.Parameters.Add("fax", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["fax"].Value =fax;


				objmysqlcommand.Parameters.Add("emailid", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["emailid"].Value =emailid;
				
                //objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["userid"].Value =userid;

                objmysqlcommand.Parameters.Add("pubtype", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pubtype"].Value = pubtype;

                objmysqlcommand.Parameters.Add("preocity", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["preocity"].Value = preocity;

                objmysqlcommand.Parameters.Add("phone2", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["phone2"].Value = txtphone2;

                objmysqlcommand.Parameters.Add("fax2", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["fax2"].Value = txtfaxno1;

                objmysqlcommand.Parameters.Add("gutter_space", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["gutter_space"].Value = txtgutter;

                objmysqlcommand.Parameters.Add("column_space", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["column_space"].Value = txtcolspc;


                objmysqlcommand.Parameters.Add("hr", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["hr"].Value = hr;

                objmysqlcommand.Parameters.Add("mint", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["mint"].Value = mint;

                objmysqlcommand.Parameters.Add("prod", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["prod"].Value = prod;

                objmysqlcommand.Parameters.Add("noofcol", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["noofcol"].Value = noofcol;

                objmysqlcommand.Parameters.Add("publishcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["publishcode"].Value = publishcode;


                objmysqlcommand.Parameters.Add("PREFIX", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["PREFIX"].Value = prefix;

                objmysqlcommand.Parameters.Add("MRV", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["MRV"].Value = MRV;


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


        public DataSet pubexecute(string compcode, string pubcode, string pubname, string pubalias, string langcode,string pubtype,string preocity)
		
        {

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
			try
			{
				objmysqlconnection.Open();
                objmysqlcommand = GetCommand("pubexecute_pubexecute_p", ref objmysqlconnection);
				objmysqlcommand.CommandType = CommandType.StoredProcedure;
 				
                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value =compcode;
				
				objmysqlcommand.Parameters.Add("pubcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pubcode"].Value = pubcode;
                //if (pubcode == null || pubcode == "")
                //{
                //    objmysqlcommand.Parameters["pubcode"].Value = "%%";
                //}
                //else
                //{
                //    objmysqlcommand.Parameters["pubcode"].Value = pubcode;
                //}
                

                objmysqlcommand.Parameters.Add("pubname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pubname"].Value = pubname;

                //if (pubname == null || pubname == "")
                //{
                //    objmysqlcommand.Parameters["pubname"].Value = "%%";
                //}
                //else
                //{
                //    objmysqlcommand.Parameters["pubname"].Value = pubname;
                //}
                objmysqlcommand.Parameters.Add("pubalias", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pubalias"].Value = pubalias;

                //if (pubalias == null || pubalias == "")
                //{
                //    objmysqlcommand.Parameters["pubalias"].Value = "%%";
                //}
                //else
                //{
                //    objmysqlcommand.Parameters["pubalias"].Value = pubalias;
                //}
				
                objmysqlcommand.Parameters.Add("langcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["langcode"].Value = langcode;

                //if (langcode == null || langcode == "")
                //{
                //    objmysqlcommand.Parameters["langcode"].Value = "%%";
                //}
                //else
                //{
                //    objmysqlcommand.Parameters["langcode"].Value = langcode;
                //}



                objmysqlcommand.Parameters.Add("pubtype", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pubtype"].Value = pubtype;

                objmysqlcommand.Parameters.Add("preocity", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["preocity"].Value = preocity;

                //objmysqlcommand.Parameters.Add("gutter_space", MySqlDbType.Int);
                //objmysqlcommand.Parameters["gutter_space"].Value = Convert.ToInt32(gtrspc);

                //objmysqlcommand.Parameters.Add("column_space", MySqlDbType.Int);
                //objmysqlcommand.Parameters["column_space"].Value = Convert.ToInt32(colspc);

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


        //if(langcode!= null&& langcode!="" && langcode!="0")
        //{
        //    objmysqlcommand.Parameters["langcode"].Value =langcode;

        //}
        //else
        //{

        //if(pubalias!= null&& pubalias!="" && pubalias!="undefined")
        //{
        //        objmysqlcommand.Parameters["pubalias"].Value =pubalias;
        //}
        //else
        //{
        //if(pubcode!= null&& pubcode!="" && pubcode!="undefined")
        //{
        //objmysqlcommand.Parameters["pubcode"].Value =pubcode;
        //}
        //else
        //{
        //objmysqlcommand.Parameters["pubcode"].Value ="%%";
        //}

        //objmysqlcommand.Parameters["langcode"].Value ="%%";
        //}


        //objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
        //objmysqlcommand.Parameters["userid"].Value =userid;

		public DataSet 	selectpublication()
		{
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();	
			try
			{
				objmysqlconnection.Open();
                objmysqlcommand = GetCommand("selectpublication_selectpublication_p", ref objmysqlconnection);
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



		public DataSet 	selectpubdaysave(string compcode,string pubcode,string sun,string mon,string tue,string wed,string thu,string fri,string sat,string all,string userid)
		{
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
			try
			{
				objmysqlconnection.Open();
                objmysqlcommand = GetCommand("slelectpubdaysave_slelectpubdaysave_p", ref objmysqlconnection);
				objmysqlcommand.CommandType = CommandType.StoredProcedure;
 				
				objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["compcode"].Value =compcode;
				
				objmysqlcommand.Parameters.Add("pubcode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["pubcode"].Value =pubcode;

				objmysqlcommand.Parameters.Add("sun", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["sun"].Value =sun;
				
				objmysqlcommand.Parameters.Add("mon", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["mon"].Value =mon;

				objmysqlcommand.Parameters.Add("tue", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["tue"].Value =tue;

				objmysqlcommand.Parameters.Add("wed", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["wed"].Value =wed;
				
				objmysqlcommand.Parameters.Add("thu", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["thu"].Value =thu;

				objmysqlcommand.Parameters.Add("fri", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["fri"].Value =fri;

				objmysqlcommand.Parameters.Add("sat", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["sat"].Value =sat;
				
				objmysqlcommand.Parameters.Add("all1", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["all1"].Value =all;
								
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


		public DataSet 	checkpubcode(string compcode,string pubcode,string userid)
		{
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
			try
			{
				objmysqlconnection.Open();
                objmysqlcommand = GetCommand("checkpubcode_checkpubcode_p", ref objmysqlconnection);
				objmysqlcommand.CommandType = CommandType.StoredProcedure;
 				
				objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["compcode"].Value =compcode;
				
				objmysqlcommand.Parameters.Add("pubcode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["pubcode"].Value =pubcode;

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





		public DataSet 	selectpubdaymodify(string compcode,string pubcode,string sun,string mon,string tue,string wed,string thu,string fri,string sat,string all,string userid)
		{

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

			try
			{
				objmysqlconnection.Open();
                objmysqlcommand = GetCommand("slelectpubdaymodify_slelectpubdaymodify_p", ref objmysqlconnection);
				objmysqlcommand.CommandType = CommandType.StoredProcedure;
 				
				objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["compcode"].Value =compcode;
				
				objmysqlcommand.Parameters.Add("pubcode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["pubcode"].Value =pubcode;

				objmysqlcommand.Parameters.Add("sun", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["sun"].Value =sun;
				
				objmysqlcommand.Parameters.Add("mon", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["mon"].Value =mon;


				objmysqlcommand.Parameters.Add("tue", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["tue"].Value =tue;

				objmysqlcommand.Parameters.Add("wed", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["wed"].Value =wed;
				
				objmysqlcommand.Parameters.Add("thu", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["thu"].Value =thu;


				objmysqlcommand.Parameters.Add("fri", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["fri"].Value =fri;

				objmysqlcommand.Parameters.Add("sat", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["sat"].Value =sat;

                objmysqlcommand.Parameters.Add("all1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["all1"].Value = all;
								
                //objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["userid"].Value =userid;

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


		public DataSet 	pubdelete(string compcode,string pubcode)
		{

            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

			try
			{
				objmysqlconnection.Open();
                objmysqlcommand = GetCommand("publicationdelete_publicationdelete_p", ref objmysqlconnection);
				objmysqlcommand.CommandType = CommandType.StoredProcedure;
 				
				objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["compcode"].Value =compcode;
				
				objmysqlcommand.Parameters.Add("pubcode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["pubcode"].Value =pubcode;
							
                //objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["userid"].Value =userid;

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


		public DataSet publicationcheck(string compcode,string pubcode,string userid)
		{
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
			try
			{
				objmysqlconnection.Open();
                objmysqlcommand = GetCommand("publicationcheck_publicationcheck_p", ref objmysqlconnection);
				objmysqlcommand.CommandType = CommandType.StoredProcedure;
 				
				objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["compcode"].Value =compcode;
				
				objmysqlcommand.Parameters.Add("pubcode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["pubcode"].Value =pubcode;
							
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

        public DataSet publicationmastr(/*string cod,*/string str)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("autopublicatcode_autopublicatcode_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("str", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["str"].Value = str;
                
                objmysqlcommand.Parameters.Add("cod", MySqlDbType.VarChar);
                if(str.Length >2)
                {

                    objmysqlcommand.Parameters["cod"].Value = str.Substring(0, 2);
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


        public DataSet pubcity(string citycode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("publicationcity", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("citycode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["citycode"].Value = citycode;

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

        public DataSet publicationtype()
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("addpublicationtype_addpublicationtype_p", ref objmysqlconnection);
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


        public DataSet preodicityname(string compcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("addpreodicity_addpreodicity_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

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

        //*********************By Manish*************************************
        public DataSet chkPriority(string compCode,string priority)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("chkPubPriority_chkPubPriority_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("comp_code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["comp_code"].Value = compCode;

                objmysqlcommand.Parameters.Add("Priority", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Priority"].Value = priority;

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


    public DataSet publisher(string compcode)
    {
        MySqlConnection objmysqlconnection;
        MySqlCommand objmysqlcommand;
        objmysqlconnection = GetConnection();
        MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objmysqlconnection.Open();
            objmysqlcommand = GetCommand("bindpublisher", ref objmysqlconnection);
            objmysqlcommand.CommandType = CommandType.StoredProcedure;

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


	}
}