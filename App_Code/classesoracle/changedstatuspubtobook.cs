using System;
using System.Data;
using System.Configuration;
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
    /// Summary description for changedstatuspubtobook
    /// </summary>
    public class changedstatuspubtobook : orclconnection
    {
        public changedstatuspubtobook()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        public DataSet update(string insertid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("updatepublishtobooked", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("insertid", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = insertid;
                objOraclecommand.Parameters.Add(prm1);




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




        public DataSet bindgridchangestatus(string validfrom, string validto, string agency, string cioid, string adtype)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("bindgrid_changestatusptob", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pagencycode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = agency;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("pcioid", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = cioid;
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("validfrom", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;

                string dateformat = "dd/mm/yyyy";

                if (validfrom == "")
                {
                    validfrom = System.DBNull.Value.ToString();
                }
                else
                {

                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = validfrom.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        validfrom = mm + "/" + dd + "/" + yy;
                    }
                }




                prm3.Value = Convert.ToDateTime(validfrom).ToString("dd-MMMM-yyyy");
                objOraclecommand.Parameters.Add(prm3);


                OracleParameter prm4 = new OracleParameter("validto", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;

                if (validto == "")
                {
                    validto = System.DBNull.Value.ToString();
                }
                else
                {

                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = validto.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        validto = mm + "/" + dd + "/" + yy;
                    }
                }


                prm4.Value = Convert.ToDateTime(validto).ToString("dd-MMMM-yyyy");

                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("padtype", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = adtype;
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



    }
}
