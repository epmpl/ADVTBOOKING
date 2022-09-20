using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OracleClient;
namespace NewAdbooking.classesoracle
{

/// <summary>
/// Summary description for PublisherMaster
/// </summary>
    public class PublisherMaster : orclconnection
{
	public PublisherMaster()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataSet pagedes(string compcode)
        {
            OracleConnection con;
            OracleCommand cmd;
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();
           

            try
            {
                con.Open();
                cmd = GetCommand("drpcty.drpcty_p", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

               
                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                cmd.Parameters.Add(prm2);
                cmd.Parameters.Add("p_Accounts", OracleType.Cursor);
                cmd.Parameters["p_Accounts"].Direction = ParameterDirection.Output;



                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection(ref con);
            }
        }


        public DataSet pubcity(string country)
        {
            OracleConnection con;
            OracleCommand cmd;
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();

            try
            {
                con.Open();
                cmd = GetCommand("drpcity.drpcity_p", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                
                OracleParameter prm2 = new OracleParameter("country", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = country;
                cmd.Parameters.Add(prm2);
                cmd.Parameters.Add("p_Accounts", OracleType.Cursor);
                cmd.Parameters["p_Accounts"].Direction = ParameterDirection.Output;




                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection(ref con);
            }
        }
        public DataSet autocodeDUP(string str)
        {
            OracleConnection con;
            OracleCommand cmd;
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();

            try
            {
                con.Open();
                cmd = GetCommand("publisherautocodeDup.publisherautocodeDup_p", ref con);
                cmd.CommandType = CommandType.StoredProcedure;


                OracleParameter prm2 = new OracleParameter("str", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = str;
                cmd.Parameters.Add(prm2);
                cmd.Parameters.Add("p_Accounts", OracleType.Cursor);
                cmd.Parameters["p_Accounts"].Direction = ParameterDirection.Output;




                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection(ref con);
            }
        }
        public DataSet pubregion(string city)
        {
            OracleConnection con;
            OracleCommand cmd;
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();

            try
            {
                con.Open();
                cmd = GetCommand("drpregion.drpregion_p", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                OracleParameter prm2 = new OracleParameter("city", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = city;
                cmd.Parameters.Add(prm2);
                cmd.Parameters.Add("p_Accounts", OracleType.Cursor);
                cmd.Parameters["p_Accounts"].Direction = ParameterDirection.Output;





                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection(ref con);
            }
        }


        public DataSet pubzone(string city)
        {
            OracleConnection con;
            OracleCommand cmd;
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();

            try
            {
                con.Open();
                cmd = GetCommand("drpzone.drpzone_p", ref con);
                cmd.CommandType = CommandType.StoredProcedure;


                OracleParameter prm2 = new OracleParameter("city", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = city;

                cmd.Parameters.Add(prm2);
                cmd.Parameters.Add("p_Accounts", OracleType.Cursor);
                cmd.Parameters["p_Accounts"].Direction = ParameterDirection.Output;




                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection(ref con);
            }
        }

        public DataSet pubstate(string city)
        {
            OracleConnection con;
            OracleCommand cmd;
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();

            try
            {
                con.Open();
                cmd = GetCommand("drpstate.drpstate_p", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                OracleParameter prm2 = new OracleParameter("city", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = city;
                cmd.Parameters.Add(prm2);
                cmd.Parameters.Add("p_Accounts", OracleType.Cursor);
                cmd.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

                cmd.Parameters.Add("p_Accounts1", OracleType.Cursor);
                cmd.Parameters["p_Accounts1"].Direction = ParameterDirection.Output;


                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection(ref con);
            }
        }



        public DataSet autocode(string str)
        {
            OracleConnection con;
            OracleCommand cmd;
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();

            try
            {
                con.Open();
                cmd = GetCommand("publisherautocode.publisherautocode_p", ref con);
                cmd.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("str", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = str;
                cmd.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("cod", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                if (str.Length > 2)
                {
                    prm2.Value = str.Substring(0, 2);
                    cmd.Parameters.Add(prm2);
                }
                else
                {

                    prm2.Value = str;
                    cmd.Parameters.Add(prm2);
                }
                cmd.Parameters.Add("p_Accounts", OracleType.Cursor);
                cmd.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

                cmd.Parameters.Add("p_Accounts1", OracleType.Cursor);
                cmd.Parameters["p_Accounts1"].Direction = ParameterDirection.Output;
           
   
              

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
        
        public DataSet pmexecute(string pubcode, string pubname, string pubalias,string address, string country, string state, string city, string district, string zone, string region, string pubtype, string sharing, string compcode)
        {
            OracleConnection con;
            OracleCommand cmd;
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();

            try
            {
                con.Open();
                cmd = GetCommand("pmexe.pmexe_p", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("sharing", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = sharing;
                cmd.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("pubtype", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                if (pubtype == "0")
                {
                    prm2.Value = System.DBNull.Value;
                }
                else
                {
                    prm2.Value = pubtype;
                }
                cmd.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("region1", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                if (region == "0")
                {
                    prm3.Value = System.DBNull.Value;
                }
                else
                {
                    prm3.Value = region;
                }
                cmd.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("zone", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                if (zone == "0")
                {
                    prm4.Value = System.DBNull.Value;
                }
                else
                {
                    prm4.Value = zone;
                }
                cmd.Parameters.Add(prm4);


                OracleParameter prm5 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = compcode;
                cmd.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("district", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = district;
                cmd.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("city", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                if (city == "0")
                {
                    prm7.Value = System.DBNull.Value;
                }
                else
                {
                    prm7.Value = city;
                }
                cmd.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("state", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = state;
                cmd.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("country", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                if (country == "0")
                {
                    prm9.Value = System.DBNull.Value;
                }
                else
                {

                    prm9.Value = country;
                }
                cmd.Parameters.Add(prm9);


                OracleParameter prm10 = new OracleParameter("address", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = address;
                cmd.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("pubalias", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = pubalias;
                cmd.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("pubname", OracleType.VarChar, 50);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = pubname;
                cmd.Parameters.Add(prm12);

                OracleParameter prm13 = new OracleParameter("pubcode", OracleType.VarChar, 50);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = pubcode;
                cmd.Parameters.Add(prm13);

                cmd.Parameters.Add("p_Accounts", OracleType.Cursor);
                cmd.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

              
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

        public DataSet pmdelete(string pubcode, string compcode)
        {
            OracleConnection con;
            OracleCommand cmd;
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {
                con.Open();
                cmd = GetCommand("pmdel.pmdel_p", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

               

                OracleParameter prm5 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = compcode;
                cmd.Parameters.Add(prm5);
                OracleParameter prm13 = new OracleParameter("pubcode", OracleType.VarChar, 50);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = pubcode;
                cmd.Parameters.Add(prm13);

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


        public DataSet chkcode(string pubcode,string pubname, string compcode)
        {
            OracleConnection con;
            OracleCommand cmd;
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {
                con.Open();
                cmd = GetCommand("pmchkcode.pmchkcode_p", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                OracleParameter prm5 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = compcode;
                cmd.Parameters.Add(prm5);
                OracleParameter prm13 = new OracleParameter("pubcode", OracleType.VarChar, 50);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = pubcode;
                cmd.Parameters.Add(prm13);
                OracleParameter prm1 = new OracleParameter("pubname", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = pubname;
                cmd.Parameters.Add(prm1);

                cmd.Parameters.Add("p_Accounts", OracleType.Cursor);
                cmd.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

                cmd.Parameters.Add("p_Accounts1", OracleType.Cursor);
                cmd.Parameters["p_Accounts1"].Direction = ParameterDirection.Output;


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


        //Modify The Value

        public DataSet pmupdate(string pubcode, string pubname, string pubalias, string address, string country, string state, string city, string district, string zone, string region, string pubtype, string sharing, string compcode)
         {
             OracleConnection con;
             OracleCommand cmd;
             con = GetConnection();
             DataSet ds = new DataSet();
             OracleDataAdapter da = new OracleDataAdapter();

             try
             {
                 con.Open();
                 cmd = GetCommand("pmmodify.pmmodify_p", ref con);
                 cmd.CommandType = CommandType.StoredProcedure;

                
                 OracleParameter prm1 = new OracleParameter("sharing", OracleType.VarChar, 50);
                 prm1.Direction = ParameterDirection.Input;
                 prm1.Value = sharing;
                 cmd.Parameters.Add(prm1);

                 OracleParameter prm2 = new OracleParameter("pubtype", OracleType.VarChar, 50);
                 prm2.Direction = ParameterDirection.Input;
                 prm2.Value = pubtype;
                 cmd.Parameters.Add(prm2);

                 OracleParameter prm3 = new OracleParameter("region1", OracleType.VarChar, 50);
                 prm3.Direction = ParameterDirection.Input;
                 prm3.Value = region;
                 cmd.Parameters.Add(prm3);

                 OracleParameter prm4 = new OracleParameter("zone", OracleType.VarChar, 50);
                 prm4.Direction = ParameterDirection.Input;
                 prm4.Value = zone;
                 cmd.Parameters.Add(prm4);


                 OracleParameter prm5 = new OracleParameter("compcode", OracleType.VarChar, 50);
                 prm5.Direction = ParameterDirection.Input;
                 prm5.Value = compcode;
                 cmd.Parameters.Add(prm5);

                 OracleParameter prm6 = new OracleParameter("district", OracleType.VarChar, 50);
                 prm6.Direction = ParameterDirection.Input;
                 prm6.Value = district;
                 cmd.Parameters.Add(prm6);

                 OracleParameter prm7 = new OracleParameter("city", OracleType.VarChar, 50);
                 prm7.Direction = ParameterDirection.Input;
                 prm7.Value = city;
                 cmd.Parameters.Add(prm7);

                 OracleParameter prm8 = new OracleParameter("state", OracleType.VarChar, 50);
                 prm8.Direction = ParameterDirection.Input;
                 prm8.Value = state;
                 cmd.Parameters.Add(prm8);

                 OracleParameter prm9 = new OracleParameter("country", OracleType.VarChar, 50);
                 prm9.Direction = ParameterDirection.Input;
                 prm9.Value = country;
                 cmd.Parameters.Add(prm9);

                 OracleParameter prm10 = new OracleParameter("address", OracleType.VarChar, 50);
                 prm10.Direction = ParameterDirection.Input;
                 prm10.Value = address;
                 cmd.Parameters.Add(prm10);

                 OracleParameter prm11 = new OracleParameter("pubalias", OracleType.VarChar, 50);
                 prm11.Direction = ParameterDirection.Input;
                 prm11.Value = pubalias;
                 cmd.Parameters.Add(prm11);

                 OracleParameter prm12 = new OracleParameter("pubname", OracleType.VarChar, 50);
                 prm12.Direction = ParameterDirection.Input;
                 prm12.Value = pubname;
                 cmd.Parameters.Add(prm12);

                 OracleParameter prm13 = new OracleParameter("pubcode", OracleType.VarChar, 50);
                 prm13.Direction = ParameterDirection.Input;
                 prm13.Value = pubcode;
                 cmd.Parameters.Add(prm13);

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

        public DataSet insertedvalue(string pubcode,string pubname,string pubalias,string address,string country,string state,string city,string district,string zone,string region,string pubtype,string sharing,string userid,string compcode)
        {
            OracleConnection con;
            OracleCommand cmd;
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {
                con.Open();
                cmd = GetCommand("pminsert.pminsert_p", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

              



                OracleParameter prm1 = new OracleParameter("sharing", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = sharing;
                cmd.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("pubtype", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = pubtype;
                cmd.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("region1", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = region;
                cmd.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("ZONE1", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = zone;
                cmd.Parameters.Add(prm4);


                OracleParameter prm5 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = compcode;
                cmd.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("district", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = district;
                cmd.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("city", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = city;
                cmd.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("state", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = state;
                cmd.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("country", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = country;
                cmd.Parameters.Add(prm9);










                OracleParameter prm10 = new OracleParameter("address", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = address;
                cmd.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("pubalias", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = pubalias;
                cmd.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("pubname", OracleType.VarChar, 50);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = pubname;
                cmd.Parameters.Add(prm12);

                OracleParameter prm13 = new OracleParameter("pubcode", OracleType.VarChar, 50);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = pubcode;
                cmd.Parameters.Add(prm13);

                OracleParameter prm14 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = userid;
                cmd.Parameters.Add(prm14);



           

             

               



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
        
        









    }
}
