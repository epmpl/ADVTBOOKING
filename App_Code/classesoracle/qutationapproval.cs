using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.OracleClient;

/// <summary>
/// Summary description for qutationapproval
/// </summary>
/// 

namespace NewAdbooking.classesoracle
{
    public class qutationapproval : orclconnection
    {
        public qutationapproval()
        {
            //
            // TODO: Add constructor logic here
            //
        }



        public DataSet executeauditmast1(string bookingid, string compcode, string adtype, string dateformat)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {


                objOracleConnection.Open();
                objOraclecommand = GetCommand("executebooking_new_quotation1", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("ciobookid", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = bookingid;
                objOraclecommand.Parameters.Add(prm2);
                OracleParameter prm3 = new OracleParameter("docno", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("keyno", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm4);




                OracleParameter prm5 = new OracleParameter("rono", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("agencycode", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm6);



                OracleParameter prm7 = new OracleParameter("client", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = System.DBNull.Value;

                objOraclecommand.Parameters.Add(prm7);


                OracleParameter prm8 = new OracleParameter("booking", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = adtype;
                objOraclecommand.Parameters.Add(prm8);



                OracleParameter prm9 = new OracleParameter("dateformat", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = dateformat;
                objOraclecommand.Parameters.Add(prm9);



                OracleParameter prm10 = new OracleParameter("revenue", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm10);

                //objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                //objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;


                objOraclecommand.Parameters.Add("p_accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts1"].Direction = ParameterDirection.Output;


                objOraclecommand.Parameters.Add("p_accounts2", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts2"].Direction = ParameterDirection.Output;


                objOraclecommand.Parameters.Add("p_accounts3", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts3"].Direction = ParameterDirection.Output;


                objOraclecommand.Parameters.Add("p_accounts4", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts4"].Direction = ParameterDirection.Output;

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





        public DataSet savedata(string remarks, string userid, string appstatus, string insertid, string bookid1, string compcode, string center, string dateformate)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {


                objOracleConnection.Open();
                objOraclecommand = GetCommand("savequotationinbookingtable1", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("premarks", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = remarks;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("puserid", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);
                OracleParameter prm3 = new OracleParameter("pappstatus", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = appstatus;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("pinsertid", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = insertid;
                objOraclecommand.Parameters.Add(prm4);




                OracleParameter prm5 = new OracleParameter("pbookid1", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = bookid1;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("pcompcode", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = compcode;
                objOraclecommand.Parameters.Add(prm6);



                OracleParameter prm7 = new OracleParameter("pcenter", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = center;

                objOraclecommand.Parameters.Add(prm7);


                OracleParameter prm8 = new OracleParameter("pdateformate", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = dateformate;
                objOraclecommand.Parameters.Add(prm8);








                objOraclecommand.Parameters.Add("p_error", OracleType.VarChar,50);
                objOraclecommand.Parameters["p_error"].Direction = ParameterDirection.Output;


                objOraclecommand.Parameters.Add("p_new_cioid", OracleType.VarChar,50);
                objOraclecommand.Parameters["p_new_cioid"].Direction = ParameterDirection.Output;



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
