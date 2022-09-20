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
namespace NewAdbooking.classesoracle
{

    public class dealaudi : orclconnection
    {
        public dealaudi()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        public DataSet sub(string compcode, string adtype, string vf, string vt, string agencycode, string clintname, string de, string at, string dateforma, string branch, string uid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("tv_dealAudit", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode_p", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("adtype_p", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = adtype;
                objOraclecommand.Parameters.Add(prm2);



                OracleParameter prm3 = new OracleParameter("validfrom_p", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                if (dateforma == "dd/mm/yyyy")
                {
                    string[] fromdatearr = vf.Split('/');
                    string dd1 = fromdatearr[0].ToString();
                    string mm1 = fromdatearr[1].ToString();
                    string yy1 = fromdatearr[2].ToString();
                    vf = mm1 + "/" + dd1 + "/" + yy1;
                }
                prm3.Value = Convert.ToDateTime(vf).ToString("dd-MMMM-yyyy"); ;
                objOraclecommand.Parameters.Add(prm3);







                OracleParameter prm4 = new OracleParameter("validto_p", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                if (dateforma == "dd/mm/yyyy")
                {
                    string[] fromdatearr = vt.Split('/');
                    string dd1 = fromdatearr[0].ToString();
                    string mm1 = fromdatearr[1].ToString();
                    string yy1 = fromdatearr[2].ToString();
                    vt = mm1 + "/" + dd1 + "/" + yy1;
                }
                prm4.Value = Convert.ToDateTime(vt).ToString("dd-MMMM-yyyy"); ;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("agency_p", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = agencycode;
                objOraclecommand.Parameters.Add(prm5);


                OracleParameter prm6 = new OracleParameter("client_p", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = clintname;
                objOraclecommand.Parameters.Add(prm6);


                OracleParameter prm7 = new OracleParameter("dealno_p", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = de;
                objOraclecommand.Parameters.Add(prm7);


                OracleParameter prm8 = new OracleParameter("audittype_p", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = at;
                objOraclecommand.Parameters.Add(prm8);



                OracleParameter prm9 = new OracleParameter("dateformat_p", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = dateforma;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("pbranch", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = branch;
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("puserid", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = uid;
                objOraclecommand.Parameters.Add(prm11);

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

        //public DataSet updatedealstatus(string dealno, string userid,string remark)
        //{
        //    OracleConnection objOracleConnection;
        //    OracleCommand objOraclecommand;
        //    DataSet objDataSet = new DataSet();
        //    objOracleConnection = GetConnection();
        //    OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        //    try
        //    {
        //        objOracleConnection.Open();
        //        objOraclecommand = GetCommand("tv_dealauditupdate", ref objOracleConnection);
        //        objOraclecommand.CommandType = CommandType.StoredProcedure;

        //        OracleParameter prm1 = new OracleParameter("pdealno", OracleType.VarChar, 50);
        //        prm1.Direction = ParameterDirection.Input;
        //        prm1.Value = dealno;
        //        objOraclecommand.Parameters.Add(prm1);

        //        OracleParameter prm2 = new OracleParameter("puserid", OracleType.VarChar, 50);
        //        prm2.Direction = ParameterDirection.Input;
        //        prm2.Value = userid;
        //        objOraclecommand.Parameters.Add(prm2);

        //        OracleParameter prm3 = new OracleParameter("premark", OracleType.VarChar, 50);
        //        prm3.Direction = ParameterDirection.Input;
        //        prm3.Value = remark;
        //        objOraclecommand.Parameters.Add(prm3);

        //        objorclDataAdapter.SelectCommand = objOraclecommand;
        //        objorclDataAdapter.Fill(objDataSet);

        //        return objDataSet;

        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //    finally
        //    {
        //        CloseConnection(ref objOracleConnection);
        //    }
        //}
        public DataSet updatedealstatus(string compcode, string dealno, string userid, string remark, string unit, string seq, string percentage, string lvl, string dealpass, string disamt)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("tv_dealauditupdate", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm44 = new OracleParameter("pcomp_code", OracleType.VarChar, 50);
                prm44.Direction = ParameterDirection.Input;
                prm44.Value = compcode;
                objOraclecommand.Parameters.Add(prm44);

                OracleParameter prm1 = new OracleParameter("pdealno", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = dealno;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("puserid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("premark", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = remark;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm31 = new OracleParameter("punit_code", OracleType.VarChar, 50);
                prm31.Direction = ParameterDirection.Input;
                prm31.Value = unit;
                objOraclecommand.Parameters.Add(prm31);

                OracleParameter prm32 = new OracleParameter("pseq_no", OracleType.VarChar, 50);
                prm32.Direction = ParameterDirection.Input;
                prm32.Value = seq;
                objOraclecommand.Parameters.Add(prm32);

                OracleParameter prm33 = new OracleParameter("ppercentage", OracleType.VarChar, 50);
                prm33.Direction = ParameterDirection.Input;
                prm33.Value = percentage;
                objOraclecommand.Parameters.Add(prm33);

                OracleParameter prm35 = new OracleParameter("passing_flag", OracleType.VarChar, 50);
                prm35.Direction = ParameterDirection.Input;
                prm35.Value = dealpass;
                objOraclecommand.Parameters.Add(prm35);

                OracleParameter prm34 = new OracleParameter("passing_level", OracleType.VarChar, 50);
                prm34.Direction = ParameterDirection.Input;
                prm34.Value = lvl;
                objOraclecommand.Parameters.Add(prm34);

                OracleParameter prm36 = new OracleParameter("pdicamt", OracleType.VarChar, 50);
                prm36.Direction = ParameterDirection.Input;
                if (disamt == " ")
                {
                    prm36.Value = 0;
                }
                else
                {
                    prm36.Value = disamt;
                }
                objOraclecommand.Parameters.Add(prm36);

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

        public DataSet binddealNo(string compcode, string dealno, string mod)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("tv_binddealforaudit", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("deal", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = dealno;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("mod1", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = mod;
                objOraclecommand.Parameters.Add(prm3);

                objOraclecommand.Parameters.Add("p_account", OracleType.Cursor);
                objOraclecommand.Parameters["p_account"].Direction = ParameterDirection.Output;


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

        public DataSet levelper(string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("deallevel_ad_fetch_amount12", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pcomp_code", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("passed_by", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                objOraclecommand.Parameters.Add("paccounts", OracleType.Cursor);
                objOraclecommand.Parameters["paccounts"].Direction = ParameterDirection.Output;


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





