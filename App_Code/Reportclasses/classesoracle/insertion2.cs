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
namespace NewAdbooking.Report.classesoracle
{
/// <summary>
/// Summary description for insertion2
/// </summary>
    public class insertion2 : orclconnection
{
	public insertion2()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataSet insertionwisebilling(string compcode, string pcentcode, string unitcode, string publcode, string edtncode, string dist_code, string from_date, string till_date, string dateformat, string userid, string extra1, string extra2, string extra3, string extra4, string extra5)
    {
        OracleConnection con;
        OracleCommand cmd;
        con = GetConnection();
        DataSet ds = new DataSet();
        OracleDataAdapter da = new OracleDataAdapter();
        try
        {
            con.Open();
            cmd = GetCommand("rpt_edtionwise_summary.rpt_edtionwise_billing", ref con);
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter prm1 = new OracleParameter("pcompcode", OracleType.VarChar, 2000);
            prm1.Direction = ParameterDirection.Input;
            if (compcode == "0" || compcode == "")
            {
                prm1.Value = System.DBNull.Value;
            }
            else
            {
                prm1.Value = compcode;

            }
            cmd.Parameters.Add(prm1);

            OracleParameter prm2 = new OracleParameter("ppcentcode", OracleType.VarChar, 2000);
            prm2.Direction = ParameterDirection.Input;
            if (pcentcode == "0" || pcentcode == "")
            {
                prm2.Value = System.DBNull.Value;
            }
            else
            {
                prm2.Value = pcentcode;

            }

            cmd.Parameters.Add(prm2);



            OracleParameter prm224 = new OracleParameter("punitcode", OracleType.VarChar, 2000);
            prm224.Direction = ParameterDirection.Input;
            if (unitcode == "0" || unitcode == "")
            {
                prm224.Value = System.DBNull.Value;
            }
            else
            {
                prm224.Value = unitcode;

            }

            cmd.Parameters.Add(prm224);

            OracleParameter prm2214 = new OracleParameter("ppublcode", OracleType.VarChar, 2000);
            prm2214.Direction = ParameterDirection.Input;
            if (publcode == "0" || publcode == "")
            {
                prm2214.Value = System.DBNull.Value;
            }
            else
            {
                prm2214.Value = publcode;

            }
            cmd.Parameters.Add(prm2214);


            OracleParameter prm22 = new OracleParameter("pedtncode", OracleType.VarChar, 2000);
            prm22.Direction = ParameterDirection.Input;
            if (edtncode == "0" || edtncode == "")
            {
                prm22.Value = System.DBNull.Value;
            }
            else
            {
                prm22.Value = edtncode;

            }

            cmd.Parameters.Add(prm22);


            OracleParameter prm221 = new OracleParameter("pdist_code", OracleType.VarChar, 2000);
            prm221.Direction = ParameterDirection.Input;
            if (dist_code == "0" || dist_code == "")
            {
                prm221.Value = System.DBNull.Value;
            }
            else
            {
                prm221.Value = dist_code;
            }

            cmd.Parameters.Add(prm221);


            OracleParameter prm3 = new OracleParameter("pfrom_date", OracleType.VarChar, 2000);
            prm3.Direction = ParameterDirection.Input;
            prm3.Value = from_date;
            cmd.Parameters.Add(prm3);

            OracleParameter prm4 = new OracleParameter("ptill_date", OracleType.VarChar, 2000);
            prm4.Direction = ParameterDirection.Input;
            prm4.Value = till_date;
            cmd.Parameters.Add(prm4);



            OracleParameter prm21 = new OracleParameter("pdateformat", OracleType.VarChar, 2000);
            prm21.Direction = ParameterDirection.Input;
            prm21.Value = dateformat;
            cmd.Parameters.Add(prm21);

            OracleParameter prm31 = new OracleParameter("puserid", OracleType.VarChar, 2000);
            prm31.Direction = ParameterDirection.Input;
            prm31.Value = userid;
            cmd.Parameters.Add(prm31);

            OracleParameter prm41 = new OracleParameter("pextra1", OracleType.VarChar, 2000);
            prm41.Direction = ParameterDirection.Input;
            prm41.Value =extra1;
            cmd.Parameters.Add(prm41);

            OracleParameter prm222 = new OracleParameter("pextra2", OracleType.VarChar, 2000);
            prm222.Direction = ParameterDirection.Input;
            prm222.Value =extra2;
            cmd.Parameters.Add(prm222);


            OracleParameter prm225 = new OracleParameter("pextra3", OracleType.VarChar, 2000);
            prm225.Direction = ParameterDirection.Input;
            prm225.Value =extra3;
            cmd.Parameters.Add(prm225);

            OracleParameter prm223 = new OracleParameter("pextra4", OracleType.VarChar, 2000);
            prm223.Direction = ParameterDirection.Input;
            prm223.Value =extra4;
            cmd.Parameters.Add(prm223);

            OracleParameter prm2231 = new OracleParameter("pextra5", OracleType.VarChar, 2000);
            prm2231.Direction = ParameterDirection.Input;
            prm2231.Value = extra5;
            cmd.Parameters.Add(prm2231);


            cmd.Parameters.Add("p_accounts", OracleType.Cursor);
            cmd.Parameters["p_accounts"].Direction = ParameterDirection.Output;

            cmd.Parameters.Add("p_accounts2", OracleType.Cursor);
            cmd.Parameters["p_accounts2"].Direction = ParameterDirection.Output;

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
}


}
