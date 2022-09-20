using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Data.OracleClient;
namespace NewAdbooking.classesoracle
{

    /// <summary>
    /// Summary description for PublishAudit
    /// </summary>
    public class PublishAudit : orclconnection
    {
        public PublishAudit()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataSet bindgrid(string comcode,string dateformat, string tilldate, string fromdate, string publication, string adtype, string branch)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("bindpublishert", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = comcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm11 = new OracleParameter("date1", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = dateformat;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm2 = new OracleParameter("todate", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                if (dateformat == "dd/mm/yyyy")
                {
                    string[] tilldatearr = tilldate.Split('/');
                    string dd1 = tilldatearr[0].ToString();
                    string mm1 = tilldatearr[1].ToString();
                    string yy1 = tilldatearr[2].ToString();
                    tilldate = mm1 + "/" + dd1 + "/" + yy1;
                }
                prm2.Value = Convert.ToDateTime(tilldate).ToString("dd-MMMM-yyyy");
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("fromdate", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                if (dateformat == "dd/mm/yyyy")
                {
                    string[] fromdatearr = fromdate.Split('/');
                    string dd1 = fromdatearr[0].ToString();
                    string mm1 = fromdatearr[1].ToString();
                    string yy1 = fromdatearr[2].ToString();
                    fromdate = mm1 + "/" + dd1 + "/" + yy1;
                }
                prm3.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy"); ;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("branch1", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                String BRANCHNAME = branch;
                if (branch == "Select Branch" || branch == "" || branch == "0")
                {
                    prm4.Value = System.DBNull.Value;
                }
                else
                {
                    prm4.Value = branch;
                }
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("adtype", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = adtype;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("publication", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                if (publication == "Select Center" || publication == "" || publication == "0")
                {
                    prm6.Value = System.DBNull.Value;
                }
                else
                {
                    prm6.Value = publication;
                }
               
                objOraclecommand.Parameters.Add(prm6);


                objOraclecommand.Parameters.Add("ht_rep", OracleType.Cursor);
                objOraclecommand.Parameters["ht_rep"].Direction = ParameterDirection.Output;

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


        public DataSet update(string insert_id)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("updateStatus2", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("insert_id1", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = insert_id;
                objOraclecommand.Parameters.Add(prm1);

                //objOraclecommand.Parameters.Add("ht_rep", OracleType.Cursor);
                //objOraclecommand.Parameters["ht_rep"].Direction = ParameterDirection.Output;



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
