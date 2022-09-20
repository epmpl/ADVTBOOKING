using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.OracleClient;
namespace NewAdbooking.classesoracle
{

/// <summary>
/// Summary description for materiallog
/// </summary>
public class materiallog:orclconnection
{
	public materiallog()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataSet MastPrevDisp(string compcode, string userid, string userhome, string admin, string retainer)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("wesp_ModultPrevDisp.wesp_ModultPrevDisp_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = compcode;
            objOraclecommand.Parameters.Add(prm1);

            OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
            prm2.Direction = ParameterDirection.Input;
            prm2.Value = userid;
            objOraclecommand.Parameters.Add(prm2);


            OracleParameter prm3 = new OracleParameter("userhome", OracleType.VarChar, 50);
            prm3.Direction = ParameterDirection.Input;
            prm3.Value = userhome;
            objOraclecommand.Parameters.Add(prm3);



            OracleParameter prm4 = new OracleParameter("ADMIN1", OracleType.VarChar, 50);
            prm4.Direction = ParameterDirection.Input;
            prm4.Value = admin;
            objOraclecommand.Parameters.Add(prm4);

            OracleParameter prm5 = new OracleParameter("Retainer", OracleType.VarChar, 50);
            prm5.Direction = ParameterDirection.Input;
            prm5.Value = retainer;
            objOraclecommand.Parameters.Add(prm5);


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

    public DataSet pub_centbind(string compcode, string useid, string chk_acc)
    {
        //OracleConnection objOracleConnection;
        //OracleCommand objOraclecommand;
        //DataSet objDataSet = new DataSet();
        //objOracleConnection = GetConnection();
        //OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        //try
        //{

        //    objOracleConnection.Open();
        //    objOraclecommand = GetCommand("pubcent_proc.pubcent_proc_p", ref objOracleConnection);
        //    objOraclecommand.CommandType = CommandType.StoredProcedure;

        //    OracleParameter top2 = new OracleParameter("chk_access", OracleType.VarChar);
        //    top2.Direction = ParameterDirection.Input;
        //    top2.Value = chk_acc;
        //    objOraclecommand.Parameters.Add(top2);

        //    OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
        //    prm1.Direction = ParameterDirection.Input;
        //    prm1.Value = compcode;
        //    objOraclecommand.Parameters.Add(prm1);

        //    OracleParameter prm2 = new OracleParameter("puserid", OracleType.VarChar, 50);
        //    prm2.Direction = ParameterDirection.Input;
        //    prm2.Value = useid;
        //    objOraclecommand.Parameters.Add(prm2);

        //    objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
        //    objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

        //    objorclDataAdapter.SelectCommand = objOraclecommand;
        //    objorclDataAdapter.Fill(objDataSet);
        //    return objDataSet;


        //}
        //catch (OracleException objException)
        //{
        //    throw (objException);
        //}
        //catch (Exception ex)
        //{
        //    throw (ex);
        //}
        //finally
        //{
        //    CloseConnection(ref objOracleConnection);
        //}

        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("websp_pubcenter.websp_pubcenter_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            //OracleParameter prm2 = new OracleParameter("company_code", OracleType.VarChar);
            //prm2.Direction = ParameterDirection.Input;
            //prm2.Value = compcode;
            //objOraclecommand.Parameters.Add(prm2);
            objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
            objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

            objOraclecommand.Parameters.Add("p_accounts1", OracleType.Cursor);
            objOraclecommand.Parameters["p_accounts1"].Direction = ParameterDirection.Output;

            objorclDataAdapter.SelectCommand = objOraclecommand;
            objorclDataAdapter.Fill(objDataSet);
            return objDataSet;
        }
        catch (Exception objException)
        {
            throw (objException);
        }
        finally
        {
            objOracleConnection.Close();
        }

    }


    public DataSet getdata(string pubdate, string pubcenter, string user, string extra1, string extra2, string dateformat)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {

            objOracleConnection.Open();
            objOraclecommand = GetCommand("websp_rep_material_log", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter top2 = new OracleParameter("pinsdate", OracleType.VarChar);
            top2.Direction = ParameterDirection.Input;
            if (pubdate == "" || pubdate == null)
                {
                    top2.Value = System.DBNull.Value;
                }
                else
                {

                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = pubdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        pubdate = mm + "/" + dd + "/" + yy;


                    }
                    top2.Value = Convert.ToDateTime(pubdate).ToString("dd-MMMM-yyyy");
                }

           // top2.Value = pubdate;
            objOraclecommand.Parameters.Add(top2);

            OracleParameter prm1 = new OracleParameter("pcenter", OracleType.VarChar, 50);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = pubcenter;
            objOraclecommand.Parameters.Add(prm1);

            OracleParameter prm2 = new OracleParameter("pusername", OracleType.VarChar, 50);
            prm2.Direction = ParameterDirection.Input;
            prm2.Value = user;
            objOraclecommand.Parameters.Add(prm2);

            OracleParameter prm3 = new OracleParameter("pextra1", OracleType.VarChar, 50);
            prm3.Direction = ParameterDirection.Input;
            prm3.Value = extra1;
            objOraclecommand.Parameters.Add(prm3);

            OracleParameter prm4 = new OracleParameter("pextra2", OracleType.VarChar, 50);
            prm4.Direction = ParameterDirection.Input;
            prm4.Value = extra2;
            objOraclecommand.Parameters.Add(prm4);

            objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
            objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

            objorclDataAdapter.SelectCommand = objOraclecommand;
            objorclDataAdapter.Fill(objDataSet);
            return objDataSet;


        }
        catch (OracleException objException)
        {
            throw (objException);
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