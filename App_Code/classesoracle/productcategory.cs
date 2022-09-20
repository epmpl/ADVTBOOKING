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
/// Summary description for productcategory
/// </summary>
    public class productcategory : orclconnection
{
	public productcategory()
	{
		//
		// TODO: Add constructor logic here
		//
	}
     public DataSet chkcode(string code,string productdescription,string industry,string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("checkproductcatcode.checkproductcatcode_P", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;



                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);
                OracleParameter prm6 = new OracleParameter("code", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = code;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm1 = new OracleParameter("desc1", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = productdescription;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm3 = new OracleParameter("incode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = industry;
                objOraclecommand.Parameters.Add(prm3);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts1"].Direction = ParameterDirection.Output;


                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }
        }

        public DataSet insertedvalue(string productcode,string productdescription,string alias, string compcode,string userid,string industry)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("insertproductcat.insertproductcat_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);
                OracleParameter prm6 = new OracleParameter("productcode", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = productcode;
                objOraclecommand.Parameters.Add(prm6);
                OracleParameter prm1 = new OracleParameter("productdescription", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = productdescription;
                objOraclecommand.Parameters.Add(prm1);
                OracleParameter prm3 = new OracleParameter("alias", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = alias;
                objOraclecommand.Parameters.Add(prm3);
                OracleParameter prm7 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = userid;
                objOraclecommand.Parameters.Add(prm7);
                OracleParameter prm8 = new OracleParameter("industry", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = industry;
                objOraclecommand.Parameters.Add(prm8);     

               

             


                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }
        }

        public DataSet updatepro(string productcode, string productdescription, string alias, string compcode, string userid,string industry)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("updateproductcat.updateproductcat_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;           



                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);
                OracleParameter prm6 = new OracleParameter("productcode", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = productcode;
                objOraclecommand.Parameters.Add(prm6);
                OracleParameter prm1 = new OracleParameter("productdescription", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = productdescription;
                objOraclecommand.Parameters.Add(prm1);
                OracleParameter prm3 = new OracleParameter("alias", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = alias;
                objOraclecommand.Parameters.Add(prm3);
               
                OracleParameter prm8 = new OracleParameter("industry", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = industry;
                objOraclecommand.Parameters.Add(prm8);     



                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }
        }

        public DataSet executequery(string productcode, string alias, string productdescription, string compcode,string industry)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("executeprocat.executeprocat_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm6 = new OracleParameter("productcode", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = productcode;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm1 = new OracleParameter("productdescription", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = productdescription;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm3 = new OracleParameter("alias", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = alias;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm8 = new OracleParameter("industry", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                if (industry == "0")
                {
                    prm8.Value = System.DBNull.Value;
                }
                else
                {
                    prm8.Value = industry;
                }
                objOraclecommand.Parameters.Add(prm8);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;


                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }
        }


        public DataSet deleteproduct(string code,  string compcode)
        {
            OracleConnection con;
            OracleCommand cmd;
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();
            con = GetConnection();

      

            try
            {
                con.Open();
                cmd = GetCommand("deleteproduct.deleteproduct_p", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                
                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                cmd.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("productcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = code;
                cmd.Parameters.Add(prm2);

              


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
        public DataSet bind_industry(string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("Bind_Ind_Name.Bind_Ind_Name_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);
                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

            

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }
        }

        public DataSet autocode(string str, string indus)
        {
            OracleConnection con;
            OracleCommand cmd;
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();
            con = GetConnection();

            try
            {
                con.Open();
                cmd = GetCommand("productautocode.productautocode_p", ref con);
                cmd.CommandType = CommandType.StoredProcedure;


                OracleParameter prm2 = new OracleParameter("str", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = str;
                cmd.Parameters.Add(prm2);
                OracleParameter prm6 = new OracleParameter("cod", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                if(str.Length >2)
                {
                prm6.Value = str.Substring (0,2);
                }
                else
                {
                    prm6.Value = str;
                }
                cmd.Parameters.Add(prm6);

                OracleParameter prm4 = new OracleParameter("indus", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = indus;
                cmd.Parameters.Add(prm4);

                //OracleParameter prm5 = new OracleParameter("pcomp", OracleType.VarChar, 50);
                //prm5.Direction = ParameterDirection.Input;
                //prm5.Value = compcode;
                //cmd.Parameters.Add(prm5);

                cmd.Parameters.Add("p_accounts", OracleType.Cursor);
                cmd.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                cmd.Parameters.Add("p_accounts1", OracleType.Cursor);
                cmd.Parameters["p_accounts1"].Direction = ParameterDirection.Output;


                

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

