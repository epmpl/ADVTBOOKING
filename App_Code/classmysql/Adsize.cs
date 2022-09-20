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
namespace NewAdbooking .classmysql
{

/// <summary>
/// Summary description for Adsize
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
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

			try
			{
				objmysqlconnection.Open();
                objmysqlcommand = GetCommand("adsizecolorbind_adsizecolorbind_p", ref objmysqlconnection);
				objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("COMPANY_CODE", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["COMPANY_CODE"].Value = compcode;
				
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

		public DataSet editionbind(string compcode,string userid)
		{
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

			try
			{
				objmysqlconnection.Open();
                objmysqlcommand = GetCommand("bindpackage_bindpackage_p", ref objmysqlconnection);
				objmysqlcommand.CommandType = CommandType.StoredProcedure;

				objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["compcode"].Value =compcode;

				objmysqlcommand.Parameters.Add("userid",MySqlDbType.VarChar);
				objmysqlcommand.Parameters["userid"].Value=userid;
 
				
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


    public DataSet listboxbind(string compcode, string adtype)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

			try
			{
				objmysqlconnection.Open();
                objmysqlcommand = GetCommand("adsizeadvcategory_adsizeadvcategory_p", ref objmysqlconnection);
				objmysqlcommand.CommandType = CommandType.StoredProcedure;

				objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["compcode"].Value =compcode;

                objmysqlcommand.Parameters.Add("adtype1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["adtype1"].Value = adtype;
 
				
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

		public DataSet typebind(string compcode,string userid)
		{
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

			try
			{
				objmysqlconnection.Open();
                objmysqlcommand = GetCommand("adtype_adtype_p", ref objmysqlconnection);
				objmysqlcommand.CommandType = CommandType.StoredProcedure;

				objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["compcode"].Value =compcode;

				objmysqlcommand.Parameters.Add("userid",MySqlDbType.VarChar);
				objmysqlcommand.Parameters["userid"].Value=userid;
 
				
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


        public DataSet inserttinadsize(string advtype, string badcategory, string edition, string advsizecode, string description, string color, string uom, string remarks, string width1, string width2, string height1, string height2, string compcode, string userid, string column_p)
		{
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

			try
			{
				objmysqlconnection.Open();
                objmysqlcommand = GetCommand("insertintoadsize_insertintoadsize_p", ref objmysqlconnection);
				objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("advtype", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["advtype"].Value = advtype;

                objmysqlcommand.Parameters.Add("badcategory", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["badcategory"].Value = badcategory;

                objmysqlcommand.Parameters.Add("edition", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["edition"].Value = edition;

                objmysqlcommand.Parameters.Add("advsizecode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["advsizecode"].Value = advsizecode;

                objmysqlcommand.Parameters.Add("description", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["description"].Value = description;

                objmysqlcommand.Parameters.Add("color", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["color"].Value = color;

                objmysqlcommand.Parameters.Add("uom", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["uom"].Value = description;

                objmysqlcommand.Parameters.Add("remarks", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["remarks"].Value = remarks;

                objmysqlcommand.Parameters.Add("width1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["width1"].Value = width1;

                objmysqlcommand.Parameters.Add("width2", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["width2"].Value = width2 ;

                objmysqlcommand.Parameters.Add("height1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["height1"].Value = height1;

                objmysqlcommand.Parameters.Add("height2", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["height2"].Value = height2;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("column_p", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["column_p"].Value = column_p;
				
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

		public DataSet checkcode(string description, string advsizecode,string compcode,string userid)
		{
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

			try
			{
				objmysqlconnection.Open();
                objmysqlcommand = GetCommand("chechcodesize", ref objmysqlconnection);
				objmysqlcommand.CommandType = CommandType.StoredProcedure;

				objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["compcode"].Value =compcode;

                objmysqlcommand.Parameters.Add("description", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["description"].Value = description;

				objmysqlcommand.Parameters.Add("userid",MySqlDbType.VarChar);
				objmysqlcommand.Parameters["userid"].Value=userid;
 
				objmysqlcommand.Parameters.Add("advsizecode",MySqlDbType.VarChar);
				objmysqlcommand.Parameters["advsizecode"].Value=advsizecode;
 
				
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

		public DataSet exceutesearch(string advtype,string badcategory,string edition,string advsizecode,string description,string color,string compcode)
		{
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

			try
			{
				objmysqlconnection.Open();
                objmysqlcommand = GetCommand("searchexecutesize_searchexecutesize_p", ref objmysqlconnection);
				objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("advtype", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["advtype"].Value = advtype;

                //objmysqlcommand.Parameters.Add("userid",MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["userid"].Value=userid;

                objmysqlcommand.Parameters.Add("badcategory", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["badcategory"].Value = badcategory;

                objmysqlcommand.Parameters.Add("edition", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["edition"].Value = edition;

                objmysqlcommand.Parameters.Add("advsizecode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["advsizecode"].Value = advsizecode;

                objmysqlcommand.Parameters.Add("description", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["description"].Value = description;

                objmysqlcommand.Parameters.Add("color", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["color"].Value = color;

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

		public DataSet updatesize(string advtype,string badcategory,string edition,string advsizecode,string description,string color,string uom,string remarks,string width1,string width2,string height1,string height2,string compcode,string userid, string column)
		{
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

			try
			{
				objmysqlconnection.Open();
                objmysqlcommand = GetCommand("updateintosize_updateintosize_p", ref objmysqlconnection);
				objmysqlcommand.CommandType = CommandType.StoredProcedure;

				objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["compcode"].Value =compcode;

				objmysqlcommand.Parameters.Add("userid",MySqlDbType.VarChar);
				objmysqlcommand.Parameters["userid"].Value=userid;

				objmysqlcommand.Parameters.Add("advtype",MySqlDbType.VarChar);
				objmysqlcommand.Parameters["advtype"].Value=advtype;

				objmysqlcommand.Parameters.Add("badcategory",MySqlDbType.VarChar);
				objmysqlcommand.Parameters["badcategory"].Value=badcategory;

				objmysqlcommand.Parameters.Add("edition",MySqlDbType.VarChar);
				objmysqlcommand.Parameters["edition"].Value=edition;

				objmysqlcommand.Parameters.Add("advsizecode",MySqlDbType.VarChar);
				objmysqlcommand.Parameters["advsizecode"].Value=advsizecode;

				objmysqlcommand.Parameters.Add("description",MySqlDbType.VarChar);
				objmysqlcommand.Parameters["description"].Value=description;

				objmysqlcommand.Parameters.Add("color",MySqlDbType.VarChar);
				objmysqlcommand.Parameters["color"].Value=color;

				objmysqlcommand.Parameters.Add("uom",MySqlDbType.VarChar);
				objmysqlcommand.Parameters["uom"].Value=uom;

				objmysqlcommand.Parameters.Add("remarks",MySqlDbType.VarChar);
				objmysqlcommand.Parameters["remarks"].Value=remarks;

				objmysqlcommand.Parameters.Add("width1",MySqlDbType.VarChar);
				objmysqlcommand.Parameters["width1"].Value=width1;

				objmysqlcommand.Parameters.Add("width2",MySqlDbType.VarChar);
				objmysqlcommand.Parameters["width2"].Value=width2;

				objmysqlcommand.Parameters.Add("height1",MySqlDbType.VarChar);
				objmysqlcommand.Parameters["height1"].Value=height1;

				objmysqlcommand.Parameters.Add("height2",MySqlDbType.VarChar);
				objmysqlcommand.Parameters["height2"].Value=height2;

                objmysqlcommand.Parameters.Add("column_p", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["column_p"].Value = height2;
				
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

		public DataSet firstnext()
		{
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

			try
			{
				objmysqlconnection.Open();
                objmysqlcommand = GetCommand("ADSIZEFIRSTNEXT", ref objmysqlconnection);
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

		public DataSet deletesizead(string advsizecode,string compcode,string userid)
		{
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

			try
			{
				objmysqlconnection.Open();
                objmysqlcommand = GetCommand("DELETESIZE", ref objmysqlconnection);
				objmysqlcommand.CommandType = CommandType.StoredProcedure;

				objmysqlcommand.Parameters.Add("pcompcode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["pcompcode"].Value =compcode;

				objmysqlcommand.Parameters.Add("puserid",MySqlDbType.VarChar);
				objmysqlcommand.Parameters["puserid"].Value=userid;
 
				objmysqlcommand.Parameters.Add("padvsizecode",MySqlDbType.VarChar);
				objmysqlcommand.Parameters["padvsizecode"].Value=advsizecode;
 
				
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


		public DataSet displaybind(string compcode,string userid,string advsizecode)
		{
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

			try
			{
				objmysqlconnection.Open();
				objmysqlcommand = GetCommand("displaysizebind", ref objmysqlconnection);
				objmysqlcommand.CommandType = CommandType.StoredProcedure;

				objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["compcode"].Value =compcode;

				objmysqlcommand.Parameters.Add("userid",MySqlDbType.VarChar);
				objmysqlcommand.Parameters["userid"].Value=userid;
 
				objmysqlcommand.Parameters.Add("advsizecode",MySqlDbType.VarChar);
				objmysqlcommand.Parameters["advsizecode"].Value=advsizecode;
 
				
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


		public DataSet insertdisplay(string minheight,string maxheight,string minwidth,string maxwidth,string compcode,string userid,string sizecode)
		{
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

			try
			{
				objmysqlconnection.Open();
				objmysqlcommand = GetCommand("insertdisplayin", ref objmysqlconnection);
				objmysqlcommand.CommandType = CommandType.StoredProcedure;

				objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["compcode"].Value =compcode;

				objmysqlcommand.Parameters.Add("userid",MySqlDbType.VarChar);
				objmysqlcommand.Parameters["userid"].Value=userid;
 
				objmysqlcommand.Parameters.Add("sizecode",MySqlDbType.VarChar);
				objmysqlcommand.Parameters["sizecode"].Value=sizecode;

				objmysqlcommand.Parameters.Add("minheight",MySqlDbType.VarChar);
				objmysqlcommand.Parameters["minheight"].Value=minheight;

				objmysqlcommand.Parameters.Add("maxheight",MySqlDbType.VarChar);
				objmysqlcommand.Parameters["maxheight"].Value=maxheight;

				objmysqlcommand.Parameters.Add("minwidth",MySqlDbType.VarChar);
				objmysqlcommand.Parameters["minwidth"].Value=minwidth;

				objmysqlcommand.Parameters.Add("maxwidth",MySqlDbType.VarChar);
				objmysqlcommand.Parameters["maxwidth"].Value=maxwidth;
 
				
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


		public DataSet selecteddisplay(string compcode,string userid,string sizecode,string codesize)
		{
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

			try
			{
				objmysqlconnection.Open();
				objmysqlcommand = GetCommand("slecteddisplaygrid", ref objmysqlconnection);
				objmysqlcommand.CommandType = CommandType.StoredProcedure;

				objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["compcode"].Value =compcode;

				objmysqlcommand.Parameters.Add("codesize", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["codesize"].Value =codesize;

				objmysqlcommand.Parameters.Add("userid",MySqlDbType.VarChar);
				objmysqlcommand.Parameters["userid"].Value=userid;
 
				objmysqlcommand.Parameters.Add("sizecode",MySqlDbType.VarChar);
				objmysqlcommand.Parameters["sizecode"].Value=sizecode;

				
 
				
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

		public DataSet deletedisplay(string compcode,string userid,string sizecode,string codesize)
		{
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

			try
			{
				objmysqlconnection.Open();
				objmysqlcommand = GetCommand("deletedisplaygrid", ref objmysqlconnection);
				objmysqlcommand.CommandType = CommandType.StoredProcedure;

				objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["compcode"].Value =compcode;

				objmysqlcommand.Parameters.Add("codesize", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["codesize"].Value =codesize;

				objmysqlcommand.Parameters.Add("userid",MySqlDbType.VarChar);
				objmysqlcommand.Parameters["userid"].Value=userid;
 
				objmysqlcommand.Parameters.Add("sizecode",MySqlDbType.VarChar);
				objmysqlcommand.Parameters["sizecode"].Value=sizecode;

				
 
				
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

		public DataSet updatedisplaygrid(string minheight,string maxheight,string minwidth,string maxwidth,string compcode,string userid,string sizecode,string codesize)
		{
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

			try
			{
				objmysqlconnection.Open();
				objmysqlcommand = GetCommand("updatedisplay", ref objmysqlconnection);
				objmysqlcommand.CommandType = CommandType.StoredProcedure;

				objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["compcode"].Value =compcode;

				objmysqlcommand.Parameters.Add("userid",MySqlDbType.VarChar);
				objmysqlcommand.Parameters["userid"].Value=userid;
 
				objmysqlcommand.Parameters.Add("sizecode",MySqlDbType.VarChar);
				objmysqlcommand.Parameters["sizecode"].Value=sizecode;

				objmysqlcommand.Parameters.Add("minheight",MySqlDbType.VarChar);
				objmysqlcommand.Parameters["minheight"].Value=minheight;

				objmysqlcommand.Parameters.Add("maxheight",MySqlDbType.VarChar);
				objmysqlcommand.Parameters["maxheight"].Value=maxheight;

				objmysqlcommand.Parameters.Add("minwidth",MySqlDbType.VarChar);
				objmysqlcommand.Parameters["minwidth"].Value=minwidth;

				objmysqlcommand.Parameters.Add("maxwidth",MySqlDbType.VarChar);
				objmysqlcommand.Parameters["maxwidth"].Value=maxwidth;
 
				objmysqlcommand.Parameters.Add("codesize",MySqlDbType.VarChar);
				objmysqlcommand.Parameters["codesize"].Value=codesize;
 
				
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


		public DataSet classifiedbind(string compcode,string userid,string advsizecode)
		{
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

			try
			{
				objmysqlconnection.Open();
				objmysqlcommand = GetCommand("classifiedsizebind", ref objmysqlconnection);
				objmysqlcommand.CommandType = CommandType.StoredProcedure;

				objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["compcode"].Value =compcode;

				objmysqlcommand.Parameters.Add("userid",MySqlDbType.VarChar);
				objmysqlcommand.Parameters["userid"].Value=userid;
 
				objmysqlcommand.Parameters.Add("advsizecode",MySqlDbType.VarChar);
				objmysqlcommand.Parameters["advsizecode"].Value=advsizecode;
 
				
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

//		public DataSet insertdisplay(string minheight,string maxheight,string minwidth,string maxwidth,string compcode,string userid,string sizecode)
//		{
//			SqlConnection objmysqlconnection;
//			SqlCommand objmysqlcommand;
//			objmysqlconnection = GetConnection();
//			SqlDataAdapter objmysqlDataAdapter = new SqlDataAdapter();
//			DataSet objDataSet = new DataSet();	
//			try
//			{
//				objmysqlconnection.Open();
//				objmysqlcommand = GetCommand("insertdisplayin", ref objmysqlconnection);
//				objmysqlcommand.CommandType = CommandType.StoredProcedure;
//
//				objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
//				objmysqlcommand.Parameters["compcode"].Value =compcode;
//
//				objmysqlcommand.Parameters.Add("userid",MySqlDbType.VarChar);
//				objmysqlcommand.Parameters["userid"].Value=userid;
// 
//				objmysqlcommand.Parameters.Add("sizecode",MySqlDbType.VarChar);
//				objmysqlcommand.Parameters["sizecode"].Value=sizecode;
//
//				objmysqlcommand.Parameters.Add("minheight",MySqlDbType.VarChar);
//				objmysqlcommand.Parameters["minheight"].Value=minheight;
//
//				objmysqlcommand.Parameters.Add("maxheight",MySqlDbType.VarChar);
//				objmysqlcommand.Parameters["maxheight"].Value=maxheight;
//
//				objmysqlcommand.Parameters.Add("minwidth",MySqlDbType.VarChar);
//				objmysqlcommand.Parameters["minwidth"].Value=minwidth;
//
//				objmysqlcommand.Parameters.Add("maxwidth",MySqlDbType.VarChar);
//				objmysqlcommand.Parameters["maxwidth"].Value=maxwidth;
// 
//				
//				objmysqlDataAdapter.SelectCommand = objmysqlcommand;
//				objmysqlDataAdapter.Fill(objDataSet);
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
//				CloseConnection(ref objmysqlconnection);
//			}
//		}


		public DataSet insertclassifiedinto(string fromline,string toline,string maxcharacter,string compcode,string userid,string sizecode)
		{
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

			try
			{
				objmysqlconnection.Open();
				objmysqlcommand = GetCommand("insertclassified", ref objmysqlconnection);
				objmysqlcommand.CommandType = CommandType.StoredProcedure;

				objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["compcode"].Value =compcode;

				objmysqlcommand.Parameters.Add("sizecode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["sizecode"].Value =sizecode;

				objmysqlcommand.Parameters.Add("userid",MySqlDbType.VarChar);
				objmysqlcommand.Parameters["userid"].Value=userid;
 
				objmysqlcommand.Parameters.Add("fromline",MySqlDbType.VarChar);
				objmysqlcommand.Parameters["fromline"].Value=fromline;

				objmysqlcommand.Parameters.Add("toline",MySqlDbType.VarChar);
				objmysqlcommand.Parameters["toline"].Value=toline;

				objmysqlcommand.Parameters.Add("maxcharacter",MySqlDbType.VarChar);
				objmysqlcommand.Parameters["maxcharacter"].Value=maxcharacter;
				
 
				
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

		public DataSet selectintoclassifiedinto(string compcode,string userid,string sizecode)
		{
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

			try
			{
				objmysqlconnection.Open();
				objmysqlcommand = GetCommand("selectgridclassified", ref objmysqlconnection);
				objmysqlcommand.CommandType = CommandType.StoredProcedure;

				objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["compcode"].Value =compcode;

				objmysqlcommand.Parameters.Add("sizecode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["sizecode"].Value =sizecode;

				objmysqlcommand.Parameters.Add("userid",MySqlDbType.VarChar);
				objmysqlcommand.Parameters["userid"].Value=userid;
 
				
				
 
				
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

		public DataSet updateclassified(string fromline,string toline,string maxcharacter,string compcode,string userid,string sizecode,string codeclassified)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

			try
			{
				objmysqlconnection.Open();
				objmysqlcommand = GetCommand("updateclassified", ref objmysqlconnection);
				objmysqlcommand.CommandType = CommandType.StoredProcedure;

				objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["compcode"].Value =compcode;

				objmysqlcommand.Parameters.Add("sizecode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["sizecode"].Value =sizecode;

				objmysqlcommand.Parameters.Add("codeclassified", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["codeclassified"].Value =codeclassified;

				objmysqlcommand.Parameters.Add("userid",MySqlDbType.VarChar);
				objmysqlcommand.Parameters["userid"].Value=userid;
 
				objmysqlcommand.Parameters.Add("fromline",MySqlDbType.VarChar);
				objmysqlcommand.Parameters["fromline"].Value=fromline;

				objmysqlcommand.Parameters.Add("toline",MySqlDbType.VarChar);
				objmysqlcommand.Parameters["toline"].Value=toline;

				objmysqlcommand.Parameters.Add("maxcharacter",MySqlDbType.VarChar);
				objmysqlcommand.Parameters["maxcharacter"].Value=maxcharacter;
				
 
				
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

		public DataSet deleteclassified(string compcode,string userid,string codeclassified)
		{
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

			try
			{
				objmysqlconnection.Open();
				objmysqlcommand = GetCommand("deletesizeclassified", ref objmysqlconnection);
				objmysqlcommand.CommandType = CommandType.StoredProcedure;

				objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["compcode"].Value =compcode;

				

				objmysqlcommand.Parameters.Add("codeclassified", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["codeclassified"].Value =codeclassified;

				objmysqlcommand.Parameters.Add("userid",MySqlDbType.VarChar);
				objmysqlcommand.Parameters["userid"].Value=userid;
 
			
 
				
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

		public DataSet listboxmultibind(string compcode,string userid,string adsizecode,string abc)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

			try
			{
				objmysqlconnection.Open();
				objmysqlcommand = GetCommand("insertmultiadsize", ref objmysqlconnection);
				objmysqlcommand.CommandType = CommandType.StoredProcedure;

				objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["compcode"].Value =compcode;

				objmysqlcommand.Parameters.Add("userid",MySqlDbType.VarChar);
				objmysqlcommand.Parameters["userid"].Value=userid;
 

				

				objmysqlcommand.Parameters.Add("adsizecode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["adsizecode"].Value =adsizecode;

				objmysqlcommand.Parameters.Add("abc",MySqlDbType.VarChar);
				objmysqlcommand.Parameters["abc"].Value=abc;
				
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

		public DataSet checkmulti(string compcode,string userid,string adsizecode)
		{
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
	
			try
			{
				objmysqlconnection.Open();
				objmysqlcommand = GetCommand("checkmultiselect", ref objmysqlconnection);
				objmysqlcommand.CommandType = CommandType.StoredProcedure;

				objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["compcode"].Value =compcode;

				objmysqlcommand.Parameters.Add("userid",MySqlDbType.VarChar);
				objmysqlcommand.Parameters["userid"].Value=userid;
 

				

				objmysqlcommand.Parameters.Add("adsizecode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["adsizecode"].Value =adsizecode;

				
				
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

		public DataSet checkmultibullet(string compcode,string userid,string adsizecode)
		{
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
	
			try
			{
				objmysqlconnection.Open();
				objmysqlcommand = GetCommand("checkmultiselect", ref objmysqlconnection);
				objmysqlcommand.CommandType = CommandType.StoredProcedure;

				objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["compcode"].Value =compcode;

				objmysqlcommand.Parameters.Add("userid",MySqlDbType.VarChar);
				objmysqlcommand.Parameters["userid"].Value=userid;
 

				

				objmysqlcommand.Parameters.Add("adsizecode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["adsizecode"].Value =adsizecode;

				
				
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
		public DataSet listboxmultiupdate(string compcode,string userid,string adsizecode,string abc)
		{
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

			try
			{
				objmysqlconnection.Open();
				objmysqlcommand = GetCommand("updatemultiadsize", ref objmysqlconnection);
				objmysqlcommand.CommandType = CommandType.StoredProcedure;

				objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["compcode"].Value =compcode;

				objmysqlcommand.Parameters.Add("userid",MySqlDbType.VarChar);
				objmysqlcommand.Parameters["userid"].Value=userid;
 

				

				objmysqlcommand.Parameters.Add("adsizecode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["adsizecode"].Value =adsizecode;

				objmysqlcommand.Parameters.Add("abc",MySqlDbType.VarChar);
				objmysqlcommand.Parameters["abc"].Value=abc;
				
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

		public DataSet uombind(string compcode,string userid)
		{
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();

			try
			{
				objmysqlconnection.Open();
                objmysqlcommand = GetCommand("uomadsize_uomadsize_p", ref objmysqlconnection);
				objmysqlcommand.CommandType = CommandType.StoredProcedure;

				objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
				objmysqlcommand.Parameters["compcode"].Value =compcode;

                objmysqlcommand.Parameters.Add("advtype", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["advtype"].Value = "";
 
				
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

	}
}
