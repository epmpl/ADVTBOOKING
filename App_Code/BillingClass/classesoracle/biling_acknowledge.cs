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
namespace NewAdbooking.BillingClass.classesoracle
{
    /// <summary>
    /// Summary description for biling_acknowledge
    /// </summary>
    public class biling_acknowledge : orclconnection
    {
        public biling_acknowledge()
        {
            //
            // TODO: Add constructor logic here
            //
        }




        public DataSet updatestatusnew(string bill_number, string delivery_man_name, string delivery_date, string acknowledge_date, string remarks,string date_format)
        {
            OracleConnection con;
            OracleCommand com;
            DataSet objDataSet = new DataSet();
            con = GetConnection();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {
                con.Open();
                com = GetCommand("ACKNOWLEDGE_UPDATE", ref con);
                com.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("BILL_NO", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = bill_number;
                com.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("DELIVERY_MAN_NAME", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = delivery_man_name;
                com.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("DELIVERY_DATE", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = delivery_date;
                com.Parameters.Add(prm3);

                OracleParameter prm5 = new OracleParameter("ACKNOWLEDGE_DATE", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = acknowledge_date;
                com.Parameters.Add(prm5);

                OracleParameter prm4 = new OracleParameter("ACKNOWLEDGE_REMARK", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = remarks;
                com.Parameters.Add(prm4);

                da.SelectCommand = com;
                da.Fill(objDataSet);
                return objDataSet;
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


        public DataSet fetchdata_acknow(string fromdate, string tilldate, string branch, string pubcent, string user, string agency, string edition, string adtype, string acknowledege,string date_format)
        {
            OracleConnection con;
            OracleCommand com;
            DataSet objDataSet = new DataSet();
            con = GetConnection();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {

                con.Open();


                com = GetCommand("webs_bills_acknowledgement", ref con);
                com.CommandType = CommandType.StoredProcedure;






                OracleParameter prm12 = new OracleParameter("p_fromdate", OracleType.VarChar);
                prm12.Direction = ParameterDirection.Input;
                if (fromdate == "" || fromdate == "0")
                {
                    prm12.Value = System.DBNull.Value;

                }
                else
                {

                    prm12.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");
                }
                com.Parameters.Add(prm12);


                OracleParameter prm11 = new OracleParameter("p_todate", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                if (tilldate == "" || tilldate == "0")
                {
                    prm11.Value = System.DBNull.Value;
                }
                else
                {
                    prm11.Value = Convert.ToDateTime(tilldate).ToString("dd-MMMM-yyyy");
                }
                com.Parameters.Add(prm11);




                OracleParameter prm31 = new OracleParameter("p_branch", OracleType.VarChar);
                prm31.Direction = ParameterDirection.Input;
                if (branch == "0" || branch == "")
                {
                    prm31.Value = branch;
                }
                else
                {
                    prm31.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm31);




                OracleParameter prm32 = new OracleParameter("p_pub_cent", OracleType.VarChar);
                prm32.Direction = ParameterDirection.Input;
                if (pubcent == "0" || pubcent == "")
                {
                    prm32.Value = pubcent;
                }
                else
                {
                    prm32.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm32);



                OracleParameter prm33 = new OracleParameter("p_user", OracleType.VarChar);
                prm33.Direction = ParameterDirection.Input;
                if (user == "0" || user == "")
                {
                    prm33.Value = user;
                }
                else
                {
                    prm33.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm33);



                OracleParameter prm50 = new OracleParameter("p_agency", OracleType.VarChar);
                prm50.Direction = ParameterDirection.Input;
                if (agency == "0" || agency == "")
                {
                    prm50.Value = System.DBNull.Value;

                }
                else
                {
                    prm50.Value = agency;
                }
                com.Parameters.Add(prm50);


                OracleParameter prm18 = new OracleParameter("p_editon", OracleType.VarChar);
                prm18.Direction = ParameterDirection.Input;
                if (edition == "0" || edition == "")
                {
                    prm18.Value = System.DBNull.Value;

                }
                else
                {
                    prm18.Value = edition;
                }
                com.Parameters.Add(prm18);




                OracleParameter prm59 = new OracleParameter("p_adtype", OracleType.VarChar);
                prm59.Direction = ParameterDirection.Input;
                if (adtype == "0" || adtype == "")
                {
                    prm59.Value = System.DBNull.Value;

                }
                else
                {
                    prm59.Value = adtype;
                }
                com.Parameters.Add(prm59);



                OracleParameter prm159 = new OracleParameter("p_acknowledege", OracleType.VarChar);
                prm159.Direction = ParameterDirection.Input;
                if (acknowledege == "0" || acknowledege == "")
                {
                    prm159.Value = System.DBNull.Value;

                }
                else
                {
                    prm159.Value = acknowledege;
                }
                com.Parameters.Add(prm159);



                com.Parameters.Add("p_Accounts", OracleType.Cursor);
                com.Parameters["p_Accounts"].Direction = ParameterDirection.Output;



                da.SelectCommand = com;
                da.Fill(objDataSet);
                return objDataSet;
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