using System;
using System.Data;
using System.Data.SqlClient;

namespace NewAdbooking.Classes
{
	/// <summary>
	/// Summary description for DepotIncMaster.
	/// </summary>
	public class DepotIncMaster:connection
	{
		public DepotIncMaster()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		

		public DataSet insertdepo(string slabfrom,string slabto,string percentage,string rate,string txtfromdate,string txtefftill,string userid,string compcode)
		{
			SqlConnection objsqlconnection;
			SqlCommand objsqlcommand;
			objsqlconnection=GetConnection();
			SqlDataAdapter objdataadapter;
			DataSet ds=new DataSet();

			try
			{
				objsqlconnection.Open();
				objsqlcommand=GetCommand("insertdepotinc",ref objsqlconnection);
				objsqlcommand.CommandType=CommandType.StoredProcedure;

				objsqlcommand.Parameters.Add("@slabfrom",SqlDbType.VarChar);
				objsqlcommand.Parameters["@slabfrom"].Value=slabfrom;

				objsqlcommand.Parameters.Add("@userid",SqlDbType.VarChar);
				objsqlcommand.Parameters["@userid"].Value=userid;

				objsqlcommand.Parameters.Add("@slabto",SqlDbType.VarChar);
				objsqlcommand.Parameters["@slabto"].Value=slabto;

				objsqlcommand.Parameters.Add("@percentage",SqlDbType.VarChar);
				objsqlcommand.Parameters["@percentage"].Value=percentage;

				objsqlcommand.Parameters.Add("@rate",SqlDbType.VarChar);
				objsqlcommand.Parameters["@rate"].Value=rate;

				objsqlcommand.Parameters.Add("@txtfromdate",SqlDbType.DateTime);
				objsqlcommand.Parameters["@txtfromdate"].Value=Convert.ToDateTime(txtfromdate);

				objsqlcommand.Parameters.Add("@txtefftill",SqlDbType.DateTime);
				if(txtefftill==null || txtefftill=="undefined" || txtefftill=="")
				{
					objsqlcommand.Parameters["@txtefftill"].Value=System.DBNull.Value;
				}
				else
				{
					objsqlcommand.Parameters["@txtefftill"].Value=txtefftill;
				}

				objsqlcommand.Parameters.Add("@compcode",SqlDbType.VarChar);
				objsqlcommand.Parameters["@compcode"].Value=compcode;

				objdataadapter=new SqlDataAdapter();
				objdataadapter.SelectCommand=objsqlcommand;
				objdataadapter.Fill(ds);
				return ds;

			}
			catch(Exception ex)
			{
				throw(ex);

			}
			finally
				   {
						CloseConnection(ref objsqlconnection);
				   }
			

		}

		public DataSet grinddepo(string compcode,string userid,string date)
		{
			SqlConnection objsqlconnection;
			SqlCommand objsqlcommand;
			objsqlconnection=GetConnection();
			SqlDataAdapter objdataadapter;
			DataSet ds=new DataSet();

			try
			{
				objsqlconnection.Open();
				objsqlcommand=GetCommand("bindgriddepo",ref objsqlconnection);
				objsqlcommand.CommandType=CommandType.StoredProcedure;

				

				objsqlcommand.Parameters.Add("@userid",SqlDbType.VarChar);
				objsqlcommand.Parameters["@userid"].Value=userid;

				

				objsqlcommand.Parameters.Add("@compcode",SqlDbType.VarChar);
				objsqlcommand.Parameters["@compcode"].Value=compcode;

				objsqlcommand.Parameters.Add("@date",SqlDbType.VarChar);
				objsqlcommand.Parameters["@date"].Value=date;

				objdataadapter=new SqlDataAdapter();
				objdataadapter.SelectCommand=objsqlcommand;
				objdataadapter.Fill(ds);
				return ds;

			}
			catch(Exception ex)
			{
				throw(ex);

			}
			finally
			{
				CloseConnection(ref objsqlconnection);
			}
			

		}

		public DataSet selectdepo(string compcode,string userid,string code)
		{
			SqlConnection objsqlconnection;
			SqlCommand objsqlcommand;
			objsqlconnection=GetConnection();
			SqlDataAdapter objdataadapter;
			DataSet ds=new DataSet();

			try
			{
				objsqlconnection.Open();
				objsqlcommand=GetCommand("selectdepot",ref objsqlconnection);
				objsqlcommand.CommandType=CommandType.StoredProcedure;

				

				objsqlcommand.Parameters.Add("@userid",SqlDbType.VarChar);
				objsqlcommand.Parameters["@userid"].Value=userid;

				objsqlcommand.Parameters.Add("@code",SqlDbType.VarChar);
				objsqlcommand.Parameters["@code"].Value=code;


				

				objsqlcommand.Parameters.Add("@compcode",SqlDbType.VarChar);
				objsqlcommand.Parameters["@compcode"].Value=compcode;

				
				objdataadapter=new SqlDataAdapter();
				objdataadapter.SelectCommand=objsqlcommand;
				objdataadapter.Fill(ds);
				return ds;

			}
			catch(Exception ex)
			{
				throw(ex);

			}
			finally
			{
				CloseConnection(ref objsqlconnection);
			}
			

		}

		public DataSet updatevalue(string slabfrom,string slabto,string percentage,string rate,string txtfromdate,string txtefftill,string userid,string compcode,string code)
		{
			SqlConnection objsqlconnection;
			SqlCommand objsqlcommand;
			objsqlconnection=GetConnection();
			SqlDataAdapter objdataadapter;
			DataSet ds=new DataSet();

			try
			{
				objsqlconnection.Open();
				objsqlcommand=GetCommand("updatedepotinc",ref objsqlconnection);
				objsqlcommand.CommandType=CommandType.StoredProcedure;

				objsqlcommand.Parameters.Add("@slabfrom",SqlDbType.VarChar);
				objsqlcommand.Parameters["@slabfrom"].Value=slabfrom;

				objsqlcommand.Parameters.Add("@userid",SqlDbType.VarChar);
				objsqlcommand.Parameters["@userid"].Value=userid;

				objsqlcommand.Parameters.Add("@slabto",SqlDbType.VarChar);
				objsqlcommand.Parameters["@slabto"].Value=slabto;

				objsqlcommand.Parameters.Add("@percentage",SqlDbType.VarChar);
				objsqlcommand.Parameters["@percentage"].Value=percentage;

				objsqlcommand.Parameters.Add("@rate",SqlDbType.VarChar);
				objsqlcommand.Parameters["@rate"].Value=rate;

				objsqlcommand.Parameters.Add("@txtfromdate",SqlDbType.DateTime);
				objsqlcommand.Parameters["@txtfromdate"].Value=Convert.ToDateTime(txtfromdate);

				objsqlcommand.Parameters.Add("@txtefftill",SqlDbType.DateTime);
				if(txtefftill==null || txtefftill=="undefined" || txtefftill=="")
				{
					objsqlcommand.Parameters["@txtefftill"].Value=System.DBNull.Value;
				}
				else
				{
					objsqlcommand.Parameters["@txtefftill"].Value=Convert.ToDateTime(txtefftill);
				}

				objsqlcommand.Parameters.Add("@compcode",SqlDbType.VarChar);
				objsqlcommand.Parameters["@compcode"].Value=compcode;

				objsqlcommand.Parameters.Add("@code",SqlDbType.VarChar);
				objsqlcommand.Parameters["@code"].Value=code;

				objdataadapter=new SqlDataAdapter();
				objdataadapter.SelectCommand=objsqlcommand;
				objdataadapter.Fill(ds);
				return ds;

			}
			catch(Exception ex)
			{
				throw(ex);

			}
			finally
			{
				CloseConnection(ref objsqlconnection);
			}
			

		}
		public DataSet deleteit(string compcode,string userid,string code)
		{
			SqlConnection objsqlconnection;
			SqlCommand objsqlcommand;
			objsqlconnection=GetConnection();
			SqlDataAdapter objdataadapter;
			DataSet ds=new DataSet();

			try
			{
				objsqlconnection.Open();
				objsqlcommand=GetCommand("deletedepot",ref objsqlconnection);
				objsqlcommand.CommandType=CommandType.StoredProcedure;

				

				objsqlcommand.Parameters.Add("@userid",SqlDbType.VarChar);
				objsqlcommand.Parameters["@userid"].Value=userid;

				objsqlcommand.Parameters.Add("@code",SqlDbType.VarChar);
				objsqlcommand.Parameters["@code"].Value=code;


				

				objsqlcommand.Parameters.Add("@compcode",SqlDbType.VarChar);
				objsqlcommand.Parameters["@compcode"].Value=compcode;

				
				objdataadapter=new SqlDataAdapter();
				objdataadapter.SelectCommand=objsqlcommand;
				objdataadapter.Fill(ds);
				return ds;

			}
			catch(Exception ex)
			{
				throw(ex);

			}
			finally
			{
				CloseConnection(ref objsqlconnection);
			}
			

		}

		public DataSet chkvalue(string slabfrom,string slabto,string percentage,string rate,string txtfromdate,string txtefftill,string userid,string compcode)
		{
			SqlConnection objsqlconnection;
			SqlCommand objsqlcommand;
			objsqlconnection=GetConnection();
			SqlDataAdapter objdataadapter;
			DataSet ds=new DataSet();

			try
			{
				objsqlconnection.Open();
				objsqlcommand=GetCommand("chkinsertdepo",ref objsqlconnection);
				objsqlcommand.CommandType=CommandType.StoredProcedure;

				objsqlcommand.Parameters.Add("@slabfrom",SqlDbType.VarChar);
				objsqlcommand.Parameters["@slabfrom"].Value=slabfrom;

				objsqlcommand.Parameters.Add("@userid",SqlDbType.VarChar);
				objsqlcommand.Parameters["@userid"].Value=userid;

				objsqlcommand.Parameters.Add("@slabto",SqlDbType.VarChar);
				objsqlcommand.Parameters["@slabto"].Value=slabto;

				objsqlcommand.Parameters.Add("@percentage",SqlDbType.VarChar);
				objsqlcommand.Parameters["@percentage"].Value=percentage;

				objsqlcommand.Parameters.Add("@rate",SqlDbType.VarChar);
				objsqlcommand.Parameters["@rate"].Value=rate;

				objsqlcommand.Parameters.Add("@txtfromdate",SqlDbType.DateTime);
				objsqlcommand.Parameters["@txtfromdate"].Value=Convert.ToDateTime(txtfromdate);

				objsqlcommand.Parameters.Add("@txtefftill",SqlDbType.DateTime);
				if(txtefftill==null || txtefftill=="undefined" || txtefftill=="")
				{
					objsqlcommand.Parameters["@txtefftill"].Value=System.DBNull.Value;
				}
				else
				{
					objsqlcommand.Parameters["@txtefftill"].Value=txtefftill;
				}

				objsqlcommand.Parameters.Add("@compcode",SqlDbType.VarChar);
				objsqlcommand.Parameters["@compcode"].Value=compcode;

				objdataadapter=new SqlDataAdapter();
				objdataadapter.SelectCommand=objsqlcommand;
				objdataadapter.Fill(ds);
				return ds;

			}
			catch(Exception ex)
			{
				throw(ex);

			}
			finally
			{
				CloseConnection(ref objsqlconnection);
			}
			

		}

		public DataSet chkupdatevalue(string slabfrom,string slabto,string percentage,string rate,string txtfromdate,string txtefftill,string userid,string compcode,string code)
		{
			SqlConnection objsqlconnection;
			SqlCommand objsqlcommand;
			objsqlconnection=GetConnection();
			SqlDataAdapter objdataadapter;
			DataSet ds=new DataSet();

			try
			{
				objsqlconnection.Open();
				objsqlcommand=GetCommand("chkupdatedepo",ref objsqlconnection);
				objsqlcommand.CommandType=CommandType.StoredProcedure;

				objsqlcommand.Parameters.Add("@slabfrom",SqlDbType.VarChar);
				objsqlcommand.Parameters["@slabfrom"].Value=slabfrom;

				objsqlcommand.Parameters.Add("@userid",SqlDbType.VarChar);
				objsqlcommand.Parameters["@userid"].Value=userid;

				objsqlcommand.Parameters.Add("@slabto",SqlDbType.VarChar);
				objsqlcommand.Parameters["@slabto"].Value=slabto;

				objsqlcommand.Parameters.Add("@percentage",SqlDbType.VarChar);
				objsqlcommand.Parameters["@percentage"].Value=percentage;

				objsqlcommand.Parameters.Add("@rate",SqlDbType.VarChar);
				objsqlcommand.Parameters["@rate"].Value=rate;

				objsqlcommand.Parameters.Add("@txtfromdate",SqlDbType.DateTime);
				objsqlcommand.Parameters["@txtfromdate"].Value=Convert.ToDateTime(txtfromdate);

				objsqlcommand.Parameters.Add("@txtefftill",SqlDbType.DateTime);
				if(txtefftill==null || txtefftill=="undefined" || txtefftill=="")
				{
					objsqlcommand.Parameters["@txtefftill"].Value=System.DBNull.Value;
				}
				else
				{
					objsqlcommand.Parameters["@txtefftill"].Value=txtefftill;
				}

				objsqlcommand.Parameters.Add("@compcode",SqlDbType.VarChar);
				objsqlcommand.Parameters["@compcode"].Value=compcode;

				objsqlcommand.Parameters.Add("@code",SqlDbType.VarChar);
				objsqlcommand.Parameters["@code"].Value=code;

				objdataadapter=new SqlDataAdapter();
				objdataadapter.SelectCommand=objsqlcommand;
				objdataadapter.Fill(ds);
				return ds;

			}
			catch(Exception ex)
			{
				throw(ex);

			}
			finally
			{
				CloseConnection(ref objsqlconnection);
			}
			

		}

	}
}
