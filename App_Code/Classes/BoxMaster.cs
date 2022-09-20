using System;
using System.Data;
using System.Data.SqlClient;

namespace NewAdbooking.Classes
{
	/// <summary>
	/// Summary description for BoxMaster.
	/// </summary>
	public class BoxMaster:connection
	{
		public BoxMaster()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public DataSet getedition()
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("getedition", ref objSqlConnection);
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


//		public DataSet savebox(string editioncode,string boxcode,string boxname,string alias,string dispatch,string boxcharge,string native1,string inter,string fromdate,string todate,string remarks,string compcode,string userid)
        public DataSet savebox(string boxcode, string boxname, string alias, string dispatch, string boxcharge, string native1, string inter, string fromdate, string todate, string remarks, string compcode, string userid, string pubcenter, string inc_matter)
		{

			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("boxsave", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;

                //objSqlCommand.Parameters.Add("@editioncode", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@editioncode"].Value =editioncode;

				objSqlCommand.Parameters.Add("@boxcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@boxcode"].Value =boxcode;

				objSqlCommand.Parameters.Add("@boxname", SqlDbType.VarChar);
				objSqlCommand.Parameters["@boxname"].Value =boxname;

				objSqlCommand.Parameters.Add("@alias", SqlDbType.VarChar);
				objSqlCommand.Parameters["@alias"].Value =alias;

				objSqlCommand.Parameters.Add("@dispatch", SqlDbType.VarChar);
				objSqlCommand.Parameters["@dispatch"].Value =dispatch;
				
				objSqlCommand.Parameters.Add("@boxcharge", SqlDbType.VarChar);
				objSqlCommand.Parameters["@boxcharge"].Value =boxcharge;

				objSqlCommand.Parameters.Add("@native1", SqlDbType.Decimal);
				if(native1==null || native1=="")
				{
					objSqlCommand.Parameters["@native1"].Value =System.DBNull.Value;
				}
				else
				{
                    objSqlCommand.Parameters["@native1"].Value = Convert.ToDecimal(native1);
				}

                objSqlCommand.Parameters.Add("@inter", SqlDbType.Decimal);
                if (inter == null || inter == "" || inter == "NaN")
				{
					objSqlCommand.Parameters["@inter"].Value =System.DBNull.Value;
				}
				else
				{
                    objSqlCommand.Parameters["@inter"].Value = Convert.ToDecimal(inter);
				}
				objSqlCommand.Parameters.Add("@fromdate", SqlDbType.DateTime);
				objSqlCommand.Parameters["@fromdate"].Value =Convert.ToDateTime(fromdate);

				objSqlCommand.Parameters.Add("@todate", SqlDbType.DateTime);
                if(todate=="" || todate==null || todate=="undefined/undefined/")
				{
					objSqlCommand.Parameters["@todate"].Value =System.DBNull.Value;
				}
				else
				{
					objSqlCommand.Parameters["@todate"].Value =Convert.ToDateTime(todate);
				}

				objSqlCommand.Parameters.Add("@remarks", SqlDbType.VarChar);
				objSqlCommand.Parameters["@remarks"].Value =remarks;


				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;


				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;

                objSqlCommand.Parameters.Add("@pubcenter", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pubcenter"].Value = pubcenter;

                objSqlCommand.Parameters.Add("@incwordmatter", SqlDbType.VarChar);
                objSqlCommand.Parameters["@incwordmatter"].Value = inc_matter;
                
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




//		public DataSet updatebox(string editioncode,string boxcode,string boxname,string alias,string dispatch,string boxcharge,string native1,string inter,string fromdate,string todate,string remarks,string compcode,string userid)
        public DataSet updatebox(string boxcode, string boxname, string alias, string dispatch, string boxcharge, string native1, string inter, string fromdate, string todate, string remarks, string compcode, string userid, string pubcenter, string inc_matter)
		{

			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("boxupdate", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;

                //objSqlCommand.Parameters.Add("@editioncode", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@editioncode"].Value =editioncode;

				objSqlCommand.Parameters.Add("@boxcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@boxcode"].Value =boxcode;

				objSqlCommand.Parameters.Add("@boxname", SqlDbType.VarChar);
				objSqlCommand.Parameters["@boxname"].Value =boxname;

				objSqlCommand.Parameters.Add("@alias", SqlDbType.VarChar);
				objSqlCommand.Parameters["@alias"].Value =alias;

				objSqlCommand.Parameters.Add("@dispatch", SqlDbType.VarChar);
				objSqlCommand.Parameters["@dispatch"].Value =dispatch;
				
				objSqlCommand.Parameters.Add("@boxcharge", SqlDbType.VarChar);
				objSqlCommand.Parameters["@boxcharge"].Value =boxcharge;

                objSqlCommand.Parameters.Add("@native1", SqlDbType.Decimal);
                //objSqlCommand.Parameters["@native1"].Value = native1;

                if (native1 == null || native1 == "")
                {
                    objSqlCommand.Parameters["@native1"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@native1"].Value = Convert.ToDecimal(native1);
                }


                objSqlCommand.Parameters.Add("@inter", SqlDbType.Decimal);
                //objSqlCommand.Parameters["@inter"].Value = inter;

                if (inter == null || inter == "" ||inter =="NaN")
                {
                    objSqlCommand.Parameters["@inter"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@inter"].Value = Convert.ToDecimal(inter);
                }
				objSqlCommand.Parameters.Add("@fromdate", SqlDbType.DateTime);
				objSqlCommand.Parameters["@fromdate"].Value =Convert.ToDateTime(fromdate);

				objSqlCommand.Parameters.Add("@todate", SqlDbType.DateTime);
				if(todate=="" || todate==null || todate=="undefined/undefined/")
				{
					objSqlCommand.Parameters["@todate"].Value = System.DBNull.Value;
				}
				else
				{
					objSqlCommand.Parameters["@todate"].Value =Convert.ToDateTime(todate);
				}

				objSqlCommand.Parameters.Add("@remarks", SqlDbType.VarChar);
				objSqlCommand.Parameters["@remarks"].Value =remarks;


				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;


				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;


                objSqlCommand.Parameters.Add("@pubcenter", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pubcenter"].Value = pubcenter;


                objSqlCommand.Parameters.Add("@incwordmatter", SqlDbType.VarChar);
                objSqlCommand.Parameters["@incwordmatter"].Value = inc_matter;

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



        //public DataSet boxexe(string editioncode,string boxcode,string boxname,string alias,string boxcharge,string compcode,string userid)
        public DataSet boxexe(string boxcode, string boxname, string alias, string boxcharge, string compcode, string userid, string pubcenter)
		{

			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("boxexe", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;
					
				
                //objSqlCommand.Parameters.Add("@editioncode", SqlDbType.VarChar);
                //if(editioncode=="0")
                //{
                //    objSqlCommand.Parameters["@editioncode"].Value ="%%";
                //}
                //else
                //{
                //    objSqlCommand.Parameters["@editioncode"].Value =editioncode;
                //}


                objSqlCommand.Parameters.Add("@boxcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@boxcode"].Value =boxcode;


                //objSqlCommand.Parameters.Add("@boxcode", SqlDbType.VarChar);
                //if(boxcode=="" || boxcode==null)
                //{
                //objSqlCommand.Parameters["@boxcode"].Value =;
                //}
                //else
                //{
                //    objSqlCommand.Parameters["@boxcode"].Value =boxcode;
                //}


				objSqlCommand.Parameters.Add("@boxname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@boxname"].Value = boxname;
                
                //if(boxname=="" || boxname==null)
                //{
                //    objSqlCommand.Parameters["@boxname"].Value ="%%";
                //}
                //else
                //{
                //    objSqlCommand.Parameters["@boxname"].Value =boxname;
                //}



				objSqlCommand.Parameters.Add("@alias", SqlDbType.VarChar);
                objSqlCommand.Parameters["@alias"].Value = alias;

				
                //if(alias=="" || alias== null)
                //{
                //    objSqlCommand.Parameters["@alias"].Value ="%%";
                //}
                //else
                //{
                //    objSqlCommand.Parameters["@alias"].Value =alias;
                //}

				
				objSqlCommand.Parameters.Add("@boxcharge", SqlDbType.VarChar);
                objSqlCommand.Parameters["@boxcharge"].Value = boxcharge;

            //    if(boxcharge=="0" )
            //    {
            //        objSqlCommand.Parameters["@boxcharge"].Value ="%%";
            //    }
            //else
            //    {
            //        objSqlCommand.Parameters["@boxcharge"].Value =boxcharge;
            //    }

				
				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;


				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;

                objSqlCommand.Parameters.Add("@pubcenter", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pubcenter"].Value = pubcenter;

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


        public DataSet autocode(string str, string pubcenter)
        {
            SqlConnection con;
            SqlCommand cmd;
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            con = GetConnection();

            try
            {
                con.Open();
                cmd = GetCommand("Boxautocode", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                //cmd.Parameters.Add("@compcode", SqlDbType.VarChar);
                //cmd.Parameters["@compcode"].Value = compcode;

                cmd.Parameters.Add("@str", SqlDbType.VarChar);
                cmd.Parameters["@str"].Value = str;

                cmd.Parameters.Add("@cod", SqlDbType.VarChar);
                cmd.Parameters["@cod"].Value = str;

                cmd.Parameters.Add("@pubcenter", SqlDbType.VarChar);
                cmd.Parameters["@pubcenter"].Value = pubcenter;
                
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


		public DataSet boxfnpl(string compcode,string userid)
		{

			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("boxfnpl", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;

				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;


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

         

		public DataSet boxchk(string boxcode,string boxname,string compcode,string userid, string pubcenter)
		{

			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("boxchk", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;

				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@boxcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@boxcode"].Value =boxcode;

                objSqlCommand.Parameters.Add("@boxname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@boxname"].Value = boxname;

				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;

                objSqlCommand.Parameters.Add("@pubcenter", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pubcenter"].Value = pubcenter;

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


        public DataSet modifychk(string boxcode, string boxname, string compcode, string userid, string pubcenter)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("modifychk", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@boxcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@boxcode"].Value = boxcode;

                objSqlCommand.Parameters.Add("@boxname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@boxname"].Value = boxname;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@pubcenter", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pubcenter"].Value = pubcenter;

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


//		public DataSet boxdel(string editioncode,string boxcode,string compcode,string userid)
        public DataSet boxdel(string boxcode, string compcode, string userid)
		{

			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("boxdelete", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;

				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;


				objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value =userid;

                //objSqlCommand.Parameters.Add("@editioncode", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@editioncode"].Value =editioncode;



				objSqlCommand.Parameters.Add("@boxcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@boxcode"].Value =boxcode;




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

		

	}
}
