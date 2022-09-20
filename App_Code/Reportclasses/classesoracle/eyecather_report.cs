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
/// Summary description for eyecather_report
/// </summary>
public class eyecather_report : orclconnection
{
	public eyecather_report()
	{
    }
		   public DataSet bindpubcent34(string code)
        {
            string zonename = "";
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("BINDPUBLICATIONCENTER.bindpublicationcenter_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = code;
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
           public DataSet eyecatherreport(string compcode, string unitcode, string branch, string frdate, string todate, string adtype, string uom, string bullet, string categ, string reporttype, string reportfor, string userid, string dateformat, string extra1, string extra2, string extra3, string extra4,string extra5)
           {
               OracleConnection objOracleConnection;
               OracleCommand objOraclecommand;
               DataSet objDataSet = new DataSet();
               objOracleConnection = GetConnection();

               OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
               try
               {


                   objOracleConnection.Open();
                   objOraclecommand = GetCommand("rpt_unit_bulletwise_business", ref objOracleConnection);
                   objOraclecommand.CommandType = CommandType.StoredProcedure;


                   OracleParameter prm1 = new OracleParameter("pcompcode", OracleType.VarChar, 50);
                   prm1.Direction = ParameterDirection.Input;
                   prm1.Value = compcode;
                   objOraclecommand.Parameters.Add(prm1);

                   OracleParameter prm2 = new OracleParameter("punitcode", OracleType.VarChar, 50);
                   prm2.Direction = ParameterDirection.Input;
                   prm2.Value = unitcode;
                   objOraclecommand.Parameters.Add(prm2);


                   OracleParameter prm3 = new OracleParameter("pbrancode", OracleType.VarChar, 50);
                   prm3.Direction = ParameterDirection.Input;
                   prm3.Value = branch;
                   objOraclecommand.Parameters.Add(prm3);


                   OracleParameter prm4 = new OracleParameter("padtype", OracleType.VarChar, 50);
                   prm4.Direction = ParameterDirection.Input;
                   if (adtype == "" || adtype == "0")
                   {
                       prm4.Value = System.DBNull.Value;
                   }
                   else
                   {
                       prm4.Value = adtype;
                   }
                   objOraclecommand.Parameters.Add(prm4);

                   OracleParameter prm5 = new OracleParameter("puom", OracleType.VarChar, 50);
                   prm5.Direction = ParameterDirection.Input;
                   if (uom == "" || uom == "0" || uom == "--Select uom--")
                   {
                       prm5.Value = System.DBNull.Value;
                   }
                   else
                   {
                       prm5.Value = uom;
                   }
                   objOraclecommand.Parameters.Add(prm5);

                   OracleParameter prm6 = new OracleParameter("pbulletcd", OracleType.VarChar, 50);
                   prm6.Direction = ParameterDirection.Input;
                   if (bullet == "" || bullet == "0")
                   {
                       prm6.Value = System.DBNull.Value;
                   }
                   else
                   {
                       prm6.Value = bullet;
                   }
                   objOraclecommand.Parameters.Add(prm6);

                   OracleParameter prm7 = new OracleParameter("padcat", OracleType.VarChar, 50);
                   prm7.Direction = ParameterDirection.Input;
                   if (categ == "" || categ == "0")
                   {
                       prm7.Value = System.DBNull.Value;
                   }
                   else
                   {
                       prm7.Value = categ;
                   }
                   objOraclecommand.Parameters.Add(prm7);

                   OracleParameter prm8 = new OracleParameter("preptype", OracleType.VarChar, 50);
                   prm8.Direction = ParameterDirection.Input;
                   if (reporttype == "" || reporttype == "0")
                   {
                       prm8.Value = System.DBNull.Value;
                   }
                   else
                   {
                       prm8.Value = reporttype;
                   }
                   objOraclecommand.Parameters.Add(prm8);


                   OracleParameter prm9 = new OracleParameter("prepfor", OracleType.VarChar, 50);
                   prm9.Direction = ParameterDirection.Input;
                   if (reportfor == "" || reportfor == "0")
                   {
                       prm9.Value = System.DBNull.Value;
                   }
                   else
                   {
                       prm9.Value = reportfor;
                   }
                   objOraclecommand.Parameters.Add(prm9);

                   OracleParameter prm12 = new OracleParameter("pfrdt", OracleType.VarChar, 50);
                   prm12.Direction = ParameterDirection.Input;
                   prm12.Value = frdate;
                   objOraclecommand.Parameters.Add(prm12);


                   OracleParameter prm13 = new OracleParameter("ptodt", OracleType.VarChar, 50);
                   prm13.Direction = ParameterDirection.Input;
                   prm13.Value = todate;
                   objOraclecommand.Parameters.Add(prm13);


                   OracleParameter prm14 = new OracleParameter("pdateformat", OracleType.VarChar, 50);
                   prm14.Direction = ParameterDirection.Input;
                   prm14.Value = dateformat;
                   objOraclecommand.Parameters.Add(prm14);


                   OracleParameter prm15 = new OracleParameter("puserid", OracleType.VarChar, 50);
                   prm15.Direction = ParameterDirection.Input;
                   prm15.Value = userid;
                   objOraclecommand.Parameters.Add(prm15);

                   OracleParameter prm16 = new OracleParameter("pextra1", OracleType.VarChar, 50);
                   prm16.Direction = ParameterDirection.Input;
                   prm16.Value = extra1;
                   objOraclecommand.Parameters.Add(prm16);


                   OracleParameter prm17 = new OracleParameter("pextra2", OracleType.VarChar, 50);
                   prm17.Direction = ParameterDirection.Input;
                   prm17.Value = extra2;
                   objOraclecommand.Parameters.Add(prm17);


                   OracleParameter prm18 = new OracleParameter("pextra3", OracleType.VarChar, 50);
                   prm18.Direction = ParameterDirection.Input;
                   prm18.Value = extra3;
                   objOraclecommand.Parameters.Add(prm18);

                   OracleParameter prm182 = new OracleParameter("pextra4", OracleType.VarChar, 50);
                   prm182.Direction = ParameterDirection.Input;
                   prm182.Value = extra4;
                   objOraclecommand.Parameters.Add(prm182);

                   OracleParameter prm183 = new OracleParameter("pextra5", OracleType.VarChar, 50);
                   prm183.Direction = ParameterDirection.Input;
                   prm183.Value = extra5;
                   objOraclecommand.Parameters.Add(prm183);


                   objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                   objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                   objOraclecommand.Parameters.Add("p_accounts1", OracleType.Cursor);
                   objOraclecommand.Parameters["p_accounts1"].Direction = ParameterDirection.Output;

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