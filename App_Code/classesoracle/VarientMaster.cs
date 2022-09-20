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
/// Summary description for VarientMaster
/// </summary>
    public class VarientMaster : orclconnection
{
	public VarientMaster()
	{
		//
		// TODO: Add constructor logic here
		//
	}
   public DataSet productdes(string compcode)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("drpbrand.drpbrand_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

           
            OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = compcode;
            objOraclecommand.Parameters.Add(prm1);
            objOraclecommand.Parameters.Add("P_ACCOUNT", OracleType.Cursor);
            objOraclecommand.Parameters["P_ACCOUNT"].Direction = ParameterDirection.Output;



         objorclDataAdapter.SelectCommand = objOraclecommand;
         objorclDataAdapter.Fill(objDataSet);
            return objDataSet;

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            CloseConnection(ref objOracleConnection);
        }
    }

    //Check code
    public DataSet chkcode(string code, string compcode)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("chkvarientcode.chkvarientcode_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = compcode;
            objOraclecommand.Parameters.Add(prm1);

            OracleParameter prm2 = new OracleParameter("code", OracleType.VarChar, 50);
            prm2.Direction = ParameterDirection.Input;
            prm2.Value = code;
            objOraclecommand.Parameters.Add(prm2);
            objOraclecommand.Parameters.Add("P_ACCOUNT", OracleType.Cursor);
            objOraclecommand.Parameters["P_ACCOUNT"].Direction = ParameterDirection.Output;


            

       


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
    //Insert the value
    public DataSet insertedvalue(string drpbrand, string varientcode, string varientname, string varientalias, string compcode, string userid)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("varientinsert.varientinsert_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;


            OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = compcode;
            objOraclecommand.Parameters.Add(prm1);

            OracleParameter prm2 = new OracleParameter("varientcode", OracleType.VarChar, 50);
            prm2.Direction = ParameterDirection.Input;
            prm2.Value = varientcode;
            objOraclecommand.Parameters.Add(prm2);

            OracleParameter prm3 = new OracleParameter("varientname", OracleType.VarChar, 50);
            prm3.Direction = ParameterDirection.Input;
            prm3.Value = varientname;
            objOraclecommand.Parameters.Add(prm3);

            OracleParameter prm4 = new OracleParameter("varientalias", OracleType.VarChar, 50);
            prm4.Direction = ParameterDirection.Input;
            prm4.Value = varientalias;
            objOraclecommand.Parameters.Add(prm4);

            OracleParameter prm5 = new OracleParameter("userid", OracleType.VarChar, 50);
            prm5.Direction = ParameterDirection.Input;
            prm5.Value = userid;
            objOraclecommand.Parameters.Add(prm5);

            OracleParameter prm6 = new OracleParameter("drpbrand", OracleType.VarChar, 50);
            prm6.Direction = ParameterDirection.Input;
            prm6.Value = drpbrand;
            objOraclecommand.Parameters.Add(prm6);
          



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

    //Auto generated code
    public DataSet autocode(string str)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("varientautocode.varientautocode_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

           

          
            OracleParameter prm1 = new OracleParameter("str", OracleType.VarChar, 50);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = str;
            objOraclecommand.Parameters.Add(prm1);

            OracleParameter prm2 = new OracleParameter("cod", OracleType.VarChar, 50);
            prm2.Direction = ParameterDirection.Input;
            if(str.Length >2)
            {
            prm2.Value = str.Substring (0,2);
            }
            else
            {
                prm2.Value = str;


            }
            objOraclecommand.Parameters.Add(prm2);

            objOraclecommand.Parameters.Add("P_ACCOUNT", OracleType.Cursor);
            objOraclecommand.Parameters["P_ACCOUNT"].Direction = ParameterDirection.Output;
            objOraclecommand.Parameters.Add("P_ACCOUNT1", OracleType.Cursor);
            objOraclecommand.Parameters["P_ACCOUNT1"].Direction = ParameterDirection.Output;



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

    //Execute Value
    public DataSet prosubexecute(string drpprodes, string varientcode, string varientname, string varientalias, string compcode)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("varientexe.varientexe_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

           


            OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
            prm1.Direction = ParameterDirection.Input;

            prm1.Value = compcode;
            objOraclecommand.Parameters.Add(prm1);

            OracleParameter prm2 = new OracleParameter("varientcode", OracleType.VarChar, 50);
            prm2.Direction = ParameterDirection.Input;
            prm2.Value = varientcode;
            objOraclecommand.Parameters.Add(prm2);

            OracleParameter prm3 = new OracleParameter("varientname", OracleType.VarChar, 50);
            prm3.Direction = ParameterDirection.Input;
            prm3.Value = varientname;
            objOraclecommand.Parameters.Add(prm3);

            OracleParameter prm4 = new OracleParameter("varientalias", OracleType.VarChar, 50);
            prm4.Direction = ParameterDirection.Input;
            prm4.Value = varientalias;
            objOraclecommand.Parameters.Add(prm4);

           

            OracleParameter prm6 = new OracleParameter("drpbrand", OracleType.VarChar, 50);
            prm6.Direction = ParameterDirection.Input;
            if (drpprodes=="0")
            {
                prm6.Value = System.DBNull.Value;
            }
            else
            {
            prm6.Value = drpprodes;
            }
            objOraclecommand.Parameters.Add(prm6);

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

    //Delete The Value
    public DataSet deleteproduct(string varientcode, string compcode)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("varientdel.varientdel_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            
            OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = compcode;
            objOraclecommand.Parameters.Add(prm1);

            OracleParameter prm2 = new OracleParameter("varientcode", OracleType.VarChar, 50);
            prm2.Direction = ParameterDirection.Input;
            prm2.Value = varientcode;
            objOraclecommand.Parameters.Add(prm2);

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

    //Modify The Value
    public DataSet updatepro(string drpprodes, string varientcode, string varientname, string varientalias, string compcode)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("varientmodify.varientmodify_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            

            OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = compcode;
            objOraclecommand.Parameters.Add(prm1);

            OracleParameter prm2 = new OracleParameter("varientcode", OracleType.VarChar, 50);
            prm2.Direction = ParameterDirection.Input;
            prm2.Value = varientcode;
            objOraclecommand.Parameters.Add(prm2);

            OracleParameter prm3 = new OracleParameter("varientname", OracleType.VarChar, 50);
            prm3.Direction = ParameterDirection.Input;
            prm3.Value = varientname;
            objOraclecommand.Parameters.Add(prm3);

            OracleParameter prm4 = new OracleParameter("varientalias", OracleType.VarChar, 50);
            prm4.Direction = ParameterDirection.Input;
            prm4.Value = varientalias;
            objOraclecommand.Parameters.Add(prm4);



            OracleParameter prm6 = new OracleParameter("drpbrand", OracleType.VarChar, 50);
            prm6.Direction = ParameterDirection.Input;
            prm6.Value = drpprodes;
            objOraclecommand.Parameters.Add(prm6);


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
    }
}
