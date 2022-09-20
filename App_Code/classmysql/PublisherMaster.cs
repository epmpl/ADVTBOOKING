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
/// Summary description for PublisherMaster
/// </summary>
public class PublisherMaster:connection 
{
	public PublisherMaster()
	{
		//
		// TODO: Add constructor logic here
		//
	}
      public DataSet pagedes(string compcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();            
           

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("drpcty_drpcty_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;


                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }
        }


        public DataSet pubcity(string country)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();            
           
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("drpcity_drpcity_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("country", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["country"].Value = country;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }
        }

        public DataSet pubregion(string city)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();            
           

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("drpregion_drpregion_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("city", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["city"].Value = city;


                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }
        }


        public DataSet pubzone(string city)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();            
           

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("drpzone_drpzone_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("city", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["city"].Value = city;


                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }
        }

        public DataSet pubstate(string city)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();            
           

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("drpstate_drpstate_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("city", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["city"].Value = city;


                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }
        }



        public DataSet autocode(string str)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();            
           

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("publisherautocode_publisherautocode_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;


                objmysqlcommand.Parameters.Add("str", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["str"].Value = str;

                objmysqlcommand.Parameters.Add("cod", MySqlDbType.VarChar);
                if (str.Length > 2)
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
        
        public DataSet pmexecute(string pubcode, string pubname, string pubalias,string address, string country, string state, string city, string district, string zone, string region, string pubtype, string sharing, string compcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();            
           

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("pmexe_pmexe_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("pubcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pubcode"].Value = pubcode;

                objmysqlcommand.Parameters.Add("pubname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pubname"].Value = pubname;

                objmysqlcommand.Parameters.Add("pubalias", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pubalias"].Value = pubalias;

                objmysqlcommand.Parameters.Add("address", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["address"].Value = address;

                objmysqlcommand.Parameters.Add("country", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["country"].Value = country;

                objmysqlcommand.Parameters.Add("state", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["state"].Value = state;

                objmysqlcommand.Parameters.Add("city", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["city"].Value = city;

                objmysqlcommand.Parameters.Add("district", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["district"].Value = district;

                objmysqlcommand.Parameters.Add("zone", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["zone"].Value = zone;

                objmysqlcommand.Parameters.Add("region", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["region"].Value = region;

                objmysqlcommand.Parameters.Add("pubtype", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pubtype"].Value = pubtype;

                objmysqlcommand.Parameters.Add("sharing", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["sharing"].Value = sharing;

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

        public DataSet pmdelete(string pubcode, string compcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();            
           
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("pmdel_pmdel_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("pubcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pubcode"].Value = pubcode;

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


    public DataSet chkcode(string pubcode, string pubname, string compcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();            
           
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("pmchkcode_pmchkcode_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;


                objmysqlcommand.Parameters.Add("pubcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pubcode"].Value = pubcode;

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


       

        public DataSet pmupdate(string pubcode, string pubname, string pubalias, string address, string country, string state, string city, string district, string zone, string region, string pubtype, string sharing, string compcode)
         {
             MySqlConnection objmysqlconnection;
             MySqlCommand objmysqlcommand;
             objmysqlconnection = GetConnection();
             MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
             DataSet objDataSet = new DataSet();            
           
             try
             {
                 objmysqlconnection.Open();
                 objmysqlcommand = GetCommand("pmmodify_pmmodify_p", ref objmysqlconnection);
                 objmysqlcommand.CommandType = CommandType.StoredProcedure;

                 objmysqlcommand.Parameters.Add("pubcode", MySqlDbType.VarChar);
                 objmysqlcommand.Parameters["pubcode"].Value = pubcode;

                 objmysqlcommand.Parameters.Add("pubname", MySqlDbType.VarChar);
                 objmysqlcommand.Parameters["pubname"].Value = pubname;

                 objmysqlcommand.Parameters.Add("pubalias", MySqlDbType.VarChar);
                 objmysqlcommand.Parameters["pubalias"].Value = pubalias;

                 objmysqlcommand.Parameters.Add("address", MySqlDbType.VarChar);
                 objmysqlcommand.Parameters["address"].Value = address;

                 objmysqlcommand.Parameters.Add("country", MySqlDbType.VarChar);
                 objmysqlcommand.Parameters["country"].Value = country;

                 objmysqlcommand.Parameters.Add("state", MySqlDbType.VarChar);
                 objmysqlcommand.Parameters["state"].Value = state;

                 objmysqlcommand.Parameters.Add("city", MySqlDbType.VarChar);
                 objmysqlcommand.Parameters["city"].Value = city;

                 objmysqlcommand.Parameters.Add("district", MySqlDbType.VarChar);
                 objmysqlcommand.Parameters["district"].Value = district;

                 objmysqlcommand.Parameters.Add("zone", MySqlDbType.VarChar);
                 objmysqlcommand.Parameters["zone"].Value = zone;

                 objmysqlcommand.Parameters.Add("region", MySqlDbType.VarChar);
                 objmysqlcommand.Parameters["region"].Value = region;

                 objmysqlcommand.Parameters.Add("pubtype", MySqlDbType.VarChar);
                 objmysqlcommand.Parameters["pubtype"].Value = pubtype;

                 objmysqlcommand.Parameters.Add("sharing", MySqlDbType.VarChar);
                 objmysqlcommand.Parameters["sharing"].Value = sharing;

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

        public DataSet insertedvalue(string pubcode,string pubname,string pubalias,string address,string country,string state,string city,string district,string zone,string region,string pubtype,string sharing,string userid,string compcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();            
           
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("pminsert_pminsert_p", ref objmysqlconnection);
               objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("pubcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pubcode"].Value = pubcode;

                objmysqlcommand.Parameters.Add("pubname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pubname"].Value = pubname;

                objmysqlcommand.Parameters.Add("pubalias", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pubalias"].Value = pubalias;

                objmysqlcommand.Parameters.Add("address", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["address"].Value = address;

                objmysqlcommand.Parameters.Add("country", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["country"].Value = country;

                objmysqlcommand.Parameters.Add("state", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["state"].Value = state;

                objmysqlcommand.Parameters.Add("city", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["city"].Value = city;

                objmysqlcommand.Parameters.Add("district", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["district"].Value = district;

                objmysqlcommand.Parameters.Add("zone", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["zone"].Value = zone;

                objmysqlcommand.Parameters.Add("region", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["region"].Value = region;

                objmysqlcommand.Parameters.Add("pubtype", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pubtype"].Value = pubtype;

                objmysqlcommand.Parameters.Add("sharing", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["sharing"].Value = sharing;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

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



    public DataSet autocodeDUP(string str)
    {
        MySqlConnection objmysqlconnection;
        MySqlCommand objmysqlcommand;
        objmysqlconnection = GetConnection();
        MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
        DataSet objDataSet = new DataSet();

        try
        {
            objmysqlconnection.Open();
            objmysqlcommand = GetCommand("publisherautocodeDup", ref objmysqlconnection);
            objmysqlcommand.CommandType = CommandType.StoredProcedure;

            objmysqlcommand.Parameters.Add("str", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["str"].Value = str;

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