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
/// <summary>
/// Summary description for booking_subedition
/// </summary>
/// 
namespace NewAdbooking.classesoracle
{
    public class booking_subedition:orclconnection
    {
        public booking_subedition()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public void updateData(string srno, string insertid, string height, string width, string totarea, string dateI, string edition, string receiptno, string dateformat, string insstatus, string pageno)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("updateDataEditionDetail", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("srno_p", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = srno;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("insertid_p", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = insertid;
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("height_p", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = height;
                objOraclecommand.Parameters.Add(prm3);


                OracleParameter prm4 = new OracleParameter("width_p", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = width;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("totarea_p", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = totarea;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("dateI_p", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                if (dateI == "" || dateI == null)
                {
                    prm6.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = dateI.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        dateI = mm + "/" + dd + "/" + yy;


                    }

                    prm6.Value = Convert.ToDateTime(dateI).ToString("dd-MMMM-yyyy");
                }
              //  prm6.Value = dateI;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("edition_p", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = edition;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("receiptno_p", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = receiptno;
                objOraclecommand.Parameters.Add(prm8);
                OracleParameter prm9 = new OracleParameter("insstatus_p", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = insstatus;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("pageno_p", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = pageno;
                objOraclecommand.Parameters.Add(prm10);

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
              //  return objDataSet;
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
        public DataSet fetchSubEdition(string edition, string compcode,string insertid,string dataeformat,string pkgcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("FetchSubEditionDetail", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("edition", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = edition;
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("insertid", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = insertid;
                objOraclecommand.Parameters.Add(prm3);


                OracleParameter prm4 = new OracleParameter("dateformat", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = dataeformat;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("pkgcode", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = pkgcode;
                objOraclecommand.Parameters.Add(prm5);

                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_Accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts1"].Direction = ParameterDirection.Output;

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
    }
}