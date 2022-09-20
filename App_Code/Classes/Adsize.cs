using System;

using System.Data;
using System.Data.SqlClient;

namespace NewAdbooking.Classes
{
	/// <summary>
	/// Summary description for Adsize.
	/// </summary>
	public class Adsize:connection
	{
		public Adsize()
		{
			//
			// TODO: Add constructor logic here
			//

		}
		public DataSet colorbind(string compcode)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("adsizecolorbind", ref objSqlConnection);
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

		public DataSet editionbind(string compcode,string userid)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("adsizeeditionbind", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;

				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@userid",SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value=userid;
 
				
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


        public DataSet listboxbind(string compcode, string adtype)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("adsizeadvcategory", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;

				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

                objSqlCommand.Parameters.Add("@adtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adtype"].Value = adtype;
 
				
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

		public DataSet typebind(string compcode,string userid)
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
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@userid",SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value=userid;
 
				
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


		public DataSet inserttinadsize(string advtype,string badcategory,string edition,string advsizecode,string description,string color,string uom,string remarks,string width1,string width2,string height1,string height2,string compcode,string userid,string column)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("insertintoadsize", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;

				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@userid",SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value=userid;

				objSqlCommand.Parameters.Add("@advtype",SqlDbType.VarChar);
				objSqlCommand.Parameters["@advtype"].Value=advtype;

				objSqlCommand.Parameters.Add("@badcategory",SqlDbType.VarChar);
				objSqlCommand.Parameters["@badcategory"].Value=badcategory;

				objSqlCommand.Parameters.Add("@edition",SqlDbType.VarChar);
				objSqlCommand.Parameters["@edition"].Value=edition;

				objSqlCommand.Parameters.Add("@advsizecode",SqlDbType.VarChar);
				objSqlCommand.Parameters["@advsizecode"].Value=advsizecode;

				objSqlCommand.Parameters.Add("@description",SqlDbType.VarChar);
				objSqlCommand.Parameters["@description"].Value=description;

				objSqlCommand.Parameters.Add("@color",SqlDbType.VarChar);
				objSqlCommand.Parameters["@color"].Value=color;

				objSqlCommand.Parameters.Add("@uom",SqlDbType.VarChar);
				objSqlCommand.Parameters["@uom"].Value=uom;

				objSqlCommand.Parameters.Add("@remarks",SqlDbType.VarChar);
				objSqlCommand.Parameters["@remarks"].Value=remarks;

				objSqlCommand.Parameters.Add("@width1",SqlDbType.VarChar);
				objSqlCommand.Parameters["@width1"].Value=width1;

				objSqlCommand.Parameters.Add("@width2",SqlDbType.VarChar);
				objSqlCommand.Parameters["@width2"].Value=width2;

				objSqlCommand.Parameters.Add("@height1",SqlDbType.VarChar);
				objSqlCommand.Parameters["@height1"].Value=height1;

				objSqlCommand.Parameters.Add("@height2",SqlDbType.VarChar);
				objSqlCommand.Parameters["@height2"].Value=height2;

                objSqlCommand.Parameters.Add("@column_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@column_p"].Value =column;
 
				
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

		public DataSet checkcode(string description,string advsizecode,string compcode,string userid)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("chechcodesize", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;

				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@userid",SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value=userid;
 
				objSqlCommand.Parameters.Add("@advsizecode",SqlDbType.VarChar);
				objSqlCommand.Parameters["@advsizecode"].Value=advsizecode;

                objSqlCommand.Parameters.Add("@description", SqlDbType.VarChar);
                objSqlCommand.Parameters["@description"].Value = description;

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

		public DataSet exceutesearch(string advtype,string badcategory,string edition,string advsizecode,string description,string color,string compcode,string userid)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("searchexecutesize", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;

				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@userid",SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value=userid;
 
				objSqlCommand.Parameters.Add("@advsizecode",SqlDbType.VarChar);
				objSqlCommand.Parameters["@advsizecode"].Value=advsizecode;

				objSqlCommand.Parameters.Add("@advtype",SqlDbType.VarChar);
				objSqlCommand.Parameters["@advtype"].Value=advtype;

				objSqlCommand.Parameters.Add("@badcategory",SqlDbType.VarChar);
				objSqlCommand.Parameters["@badcategory"].Value=badcategory;

				objSqlCommand.Parameters.Add("@edition",SqlDbType.VarChar);
				objSqlCommand.Parameters["@edition"].Value=edition;

				objSqlCommand.Parameters.Add("@description",SqlDbType.VarChar);
				objSqlCommand.Parameters["@description"].Value=description;

				objSqlCommand.Parameters.Add("@color",SqlDbType.VarChar);
				objSqlCommand.Parameters["@color"].Value=color;
 
				
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

		public DataSet updatesize(string advtype,string badcategory,string edition,string advsizecode,string description,string color,string uom,string remarks,string width1,string width2,string height1,string height2,string compcode,string userid,string column)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("updateintosize", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;

				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@userid",SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value=userid;

				objSqlCommand.Parameters.Add("@advtype",SqlDbType.VarChar);
				objSqlCommand.Parameters["@advtype"].Value=advtype;

				objSqlCommand.Parameters.Add("@badcategory",SqlDbType.VarChar);
				objSqlCommand.Parameters["@badcategory"].Value=badcategory;

				objSqlCommand.Parameters.Add("@edition",SqlDbType.VarChar);
				objSqlCommand.Parameters["@edition"].Value=edition;

				objSqlCommand.Parameters.Add("@advsizecode",SqlDbType.VarChar);
				objSqlCommand.Parameters["@advsizecode"].Value=advsizecode;

				objSqlCommand.Parameters.Add("@description",SqlDbType.VarChar);
				objSqlCommand.Parameters["@description"].Value=description;

				objSqlCommand.Parameters.Add("@color",SqlDbType.VarChar);
				objSqlCommand.Parameters["@color"].Value=color;

				objSqlCommand.Parameters.Add("@uom",SqlDbType.VarChar);
				objSqlCommand.Parameters["@uom"].Value=uom;

				objSqlCommand.Parameters.Add("@remarks",SqlDbType.VarChar);
				objSqlCommand.Parameters["@remarks"].Value=remarks;

				objSqlCommand.Parameters.Add("@width1",SqlDbType.VarChar);
				objSqlCommand.Parameters["@width1"].Value=width1;

				objSqlCommand.Parameters.Add("@width2",SqlDbType.VarChar);
				objSqlCommand.Parameters["@width2"].Value=width2;

				objSqlCommand.Parameters.Add("@height1",SqlDbType.VarChar);
				objSqlCommand.Parameters["@height1"].Value=height1;

				objSqlCommand.Parameters.Add("@height2",SqlDbType.VarChar);
				objSqlCommand.Parameters["@height2"].Value=height2;

              

                objSqlCommand.Parameters.Add("@column_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@column_p"].Value =column;

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

		public DataSet firstnext()
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("adsizefirstnext", ref objSqlConnection);
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

		public DataSet deletesizead(string advsizecode,string compcode,string userid)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("deletesize", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;

				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@userid",SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value=userid;
 
				objSqlCommand.Parameters.Add("@advsizecode",SqlDbType.VarChar);
				objSqlCommand.Parameters["@advsizecode"].Value=advsizecode;
 
				
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


		public DataSet displaybind(string compcode,string userid,string advsizecode)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("displaysizebind", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;

				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@userid",SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value=userid;
 
				objSqlCommand.Parameters.Add("@advsizecode",SqlDbType.VarChar);
				objSqlCommand.Parameters["@advsizecode"].Value=advsizecode;
 
				
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


		public DataSet insertdisplay(string minheight,string maxheight,string minwidth,string maxwidth,string compcode,string userid,string sizecode)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("insertdisplayin", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;

				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@userid",SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value=userid;
 
				objSqlCommand.Parameters.Add("@sizecode",SqlDbType.VarChar);
				objSqlCommand.Parameters["@sizecode"].Value=sizecode;

				objSqlCommand.Parameters.Add("@minheight",SqlDbType.VarChar);
				objSqlCommand.Parameters["@minheight"].Value=minheight;

				objSqlCommand.Parameters.Add("@maxheight",SqlDbType.VarChar);
				objSqlCommand.Parameters["@maxheight"].Value=maxheight;

				objSqlCommand.Parameters.Add("@minwidth",SqlDbType.VarChar);
				objSqlCommand.Parameters["@minwidth"].Value=minwidth;

				objSqlCommand.Parameters.Add("@maxwidth",SqlDbType.VarChar);
				objSqlCommand.Parameters["@maxwidth"].Value=maxwidth;
 
				
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


		public DataSet selecteddisplay(string compcode,string userid,string sizecode,string codesize)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("slecteddisplaygrid", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;

				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@codesize", SqlDbType.VarChar);
				objSqlCommand.Parameters["@codesize"].Value =codesize;

				objSqlCommand.Parameters.Add("@userid",SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value=userid;
 
				objSqlCommand.Parameters.Add("@sizecode",SqlDbType.VarChar);
				objSqlCommand.Parameters["@sizecode"].Value=sizecode;

				
 
				
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

		public DataSet deletedisplay(string compcode,string userid,string sizecode,string codesize)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("deletedisplaygrid", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;

				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@codesize", SqlDbType.VarChar);
				objSqlCommand.Parameters["@codesize"].Value =codesize;

				objSqlCommand.Parameters.Add("@userid",SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value=userid;
 
				objSqlCommand.Parameters.Add("@sizecode",SqlDbType.VarChar);
				objSqlCommand.Parameters["@sizecode"].Value=sizecode;

				
 
				
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

		public DataSet updatedisplaygrid(string minheight,string maxheight,string minwidth,string maxwidth,string compcode,string userid,string sizecode,string codesize)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("updatedisplay", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;

				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@userid",SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value=userid;
 
				objSqlCommand.Parameters.Add("@sizecode",SqlDbType.VarChar);
				objSqlCommand.Parameters["@sizecode"].Value=sizecode;

				objSqlCommand.Parameters.Add("@minheight",SqlDbType.VarChar);
				objSqlCommand.Parameters["@minheight"].Value=minheight;

				objSqlCommand.Parameters.Add("@maxheight",SqlDbType.VarChar);
				objSqlCommand.Parameters["@maxheight"].Value=maxheight;

				objSqlCommand.Parameters.Add("@minwidth",SqlDbType.VarChar);
				objSqlCommand.Parameters["@minwidth"].Value=minwidth;

				objSqlCommand.Parameters.Add("@maxwidth",SqlDbType.VarChar);
				objSqlCommand.Parameters["@maxwidth"].Value=maxwidth;
 
				objSqlCommand.Parameters.Add("@codesize",SqlDbType.VarChar);
				objSqlCommand.Parameters["@codesize"].Value=codesize;
 
				
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


		public DataSet classifiedbind(string compcode,string userid,string advsizecode)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("classifiedsizebind", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;

				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@userid",SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value=userid;
 
				objSqlCommand.Parameters.Add("@advsizecode",SqlDbType.VarChar);
				objSqlCommand.Parameters["@advsizecode"].Value=advsizecode;
 
				
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

//		public DataSet insertdisplay(string minheight,string maxheight,string minwidth,string maxwidth,string compcode,string userid,string sizecode)
//		{
//			SqlConnection objSqlConnection;
//			SqlCommand objSqlCommand;
//			objSqlConnection = GetConnection();
//			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
//			DataSet objDataSet = new DataSet();	
//			try
//			{
//				objSqlConnection.Open();
//				objSqlCommand = GetCommand("insertdisplayin", ref objSqlConnection);
//				objSqlCommand.CommandType = CommandType.StoredProcedure;
//
//				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
//				objSqlCommand.Parameters["@compcode"].Value =compcode;
//
//				objSqlCommand.Parameters.Add("@userid",SqlDbType.VarChar);
//				objSqlCommand.Parameters["@userid"].Value=userid;
// 
//				objSqlCommand.Parameters.Add("@sizecode",SqlDbType.VarChar);
//				objSqlCommand.Parameters["@sizecode"].Value=sizecode;
//
//				objSqlCommand.Parameters.Add("@minheight",SqlDbType.VarChar);
//				objSqlCommand.Parameters["@minheight"].Value=minheight;
//
//				objSqlCommand.Parameters.Add("@maxheight",SqlDbType.VarChar);
//				objSqlCommand.Parameters["@maxheight"].Value=maxheight;
//
//				objSqlCommand.Parameters.Add("@minwidth",SqlDbType.VarChar);
//				objSqlCommand.Parameters["@minwidth"].Value=minwidth;
//
//				objSqlCommand.Parameters.Add("@maxwidth",SqlDbType.VarChar);
//				objSqlCommand.Parameters["@maxwidth"].Value=maxwidth;
// 
//				
//				objSqlDataAdapter.SelectCommand = objSqlCommand;
//				objSqlDataAdapter.Fill(objDataSet);
//
//				return objDataSet;
//
//			}
//			catch(Exception ex)
//			{
//				throw(ex);
//			}
//			finally
//			{
//				CloseConnection(ref objSqlConnection);
//			}
//		}


		public DataSet insertclassifiedinto(string fromline,string toline,string maxcharacter,string compcode,string userid,string sizecode)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("insertclassified", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;

				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@sizecode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@sizecode"].Value =sizecode;

				objSqlCommand.Parameters.Add("@userid",SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value=userid;
 
				objSqlCommand.Parameters.Add("@fromline",SqlDbType.VarChar);
				objSqlCommand.Parameters["@fromline"].Value=fromline;

				objSqlCommand.Parameters.Add("@toline",SqlDbType.VarChar);
				objSqlCommand.Parameters["@toline"].Value=toline;

				objSqlCommand.Parameters.Add("@maxcharacter",SqlDbType.VarChar);
				objSqlCommand.Parameters["@maxcharacter"].Value=maxcharacter;
				
 
				
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

		public DataSet selectintoclassifiedinto(string compcode,string userid,string sizecode)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("selectgridclassified", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;

				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@sizecode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@sizecode"].Value =sizecode;

				objSqlCommand.Parameters.Add("@userid",SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value=userid;
 
				
				
 
				
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

		public DataSet updateclassified(string fromline,string toline,string maxcharacter,string compcode,string userid,string sizecode,string codeclassified)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("updateclassified", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;

				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@sizecode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@sizecode"].Value =sizecode;

				objSqlCommand.Parameters.Add("@codeclassified", SqlDbType.VarChar);
				objSqlCommand.Parameters["@codeclassified"].Value =codeclassified;

				objSqlCommand.Parameters.Add("@userid",SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value=userid;
 
				objSqlCommand.Parameters.Add("@fromline",SqlDbType.VarChar);
				objSqlCommand.Parameters["@fromline"].Value=fromline;

				objSqlCommand.Parameters.Add("@toline",SqlDbType.VarChar);
				objSqlCommand.Parameters["@toline"].Value=toline;

				objSqlCommand.Parameters.Add("@maxcharacter",SqlDbType.VarChar);
				objSqlCommand.Parameters["@maxcharacter"].Value=maxcharacter;
				
 
				
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

		public DataSet deleteclassified(string compcode,string userid,string codeclassified)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("deletesizeclassified", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;

				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				

				objSqlCommand.Parameters.Add("@codeclassified", SqlDbType.VarChar);
				objSqlCommand.Parameters["@codeclassified"].Value =codeclassified;

				objSqlCommand.Parameters.Add("@userid",SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value=userid;
 
			
 
				
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

		public DataSet listboxmultibind(string compcode,string userid,string adsizecode,string abc)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("insertmultiadsize", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;

				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@userid",SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value=userid;
 

				

				objSqlCommand.Parameters.Add("@adsizecode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@adsizecode"].Value =adsizecode;

				objSqlCommand.Parameters.Add("@abc",SqlDbType.VarChar);
				objSqlCommand.Parameters["@abc"].Value=abc;
				
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

		public DataSet checkmulti(string compcode,string userid,string adsizecode)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("checkmultiselect", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;

				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@userid",SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value=userid;
 

				

				objSqlCommand.Parameters.Add("@adsizecode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@adsizecode"].Value =adsizecode;

				
				
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

		public DataSet checkmultibullet(string compcode,string userid,string adsizecode)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("checkmultiselect", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;

				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@userid",SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value=userid;
 

				

				objSqlCommand.Parameters.Add("@adsizecode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@adsizecode"].Value =adsizecode;

				
				
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
		public DataSet listboxmultiupdate(string compcode,string userid,string adsizecode,string abc)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("updatemultiadsize", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;

				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@userid",SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value=userid;
 

				

				objSqlCommand.Parameters.Add("@adsizecode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@adsizecode"].Value =adsizecode;

				objSqlCommand.Parameters.Add("@abc",SqlDbType.VarChar);
				objSqlCommand.Parameters["@abc"].Value=abc;
				
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

		public DataSet uombind(string compcode,string userid)
		{
			SqlConnection objSqlConnection;
			SqlCommand objSqlCommand;
			objSqlConnection = GetConnection();
			SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
			DataSet objDataSet = new DataSet();	
			try
			{
				objSqlConnection.Open();
				objSqlCommand = GetCommand("uomadsize", ref objSqlConnection);
				objSqlCommand.CommandType = CommandType.StoredProcedure;

				objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
				objSqlCommand.Parameters["@compcode"].Value =compcode;

				objSqlCommand.Parameters.Add("@userid",SqlDbType.VarChar);
				objSqlCommand.Parameters["@userid"].Value=userid;
 
				
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
