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

/// <summary>
/// Summary description for careport
/// </summary>
/// 
namespace NewAdbooking.Report.classesoracle
{
    public class careport : orclconnection
    {
        public careport()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        public DataSet ctreport_main(string pcompcode, string ppcentcode, string Branch_Code, string padtype, string padcat, string padsubcat, string pad_subcat3, string pad_subcat4, string pad_subcat5, string pdist_code, string fromdate, string dateto, string dateformat, string puserid, string pextra1, string pextra2, string pextra3, string pextra4, string pextra5, string pub_code, string edtn_code, string team_code, string exec_code)
        {


            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("rpt_categorywise_summary.rpt_categorywise_billing", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm5 = new OracleParameter("pcompcode", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = pcompcode;
                objOraclecommand.Parameters.Add(prm5);


                OracleParameter prm8 = new OracleParameter("ppcentcode", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = ppcentcode;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm6 = new OracleParameter("punitcode", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = Branch_Code;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("padtype", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = padtype;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter tmp2 = new OracleParameter("padcat", OracleType.VarChar, 50);
                tmp2.Direction = ParameterDirection.Input;
                tmp2.Value = padcat;
                objOraclecommand.Parameters.Add(tmp2);


                OracleParameter temp3 = new OracleParameter("padsubcat", OracleType.VarChar, 50);
                temp3.Direction = ParameterDirection.Input;
                temp3.Value = padsubcat;
                objOraclecommand.Parameters.Add(temp3);



                OracleParameter tmp4 = new OracleParameter("pad_subcat3", OracleType.VarChar, 50);
                tmp4.Direction = ParameterDirection.Input;
                tmp4.Value = pad_subcat3;
                objOraclecommand.Parameters.Add(tmp4);


                OracleParameter tmp5 = new OracleParameter("pad_subcat4", OracleType.VarChar, 50);
                tmp5.Direction = ParameterDirection.Input;
                tmp5.Value = pad_subcat4;
                objOraclecommand.Parameters.Add(tmp5);


                OracleParameter tmp6 = new OracleParameter("pad_subcat5", OracleType.VarChar, 50);
                tmp6.Direction = ParameterDirection.Input;
                tmp6.Value = pad_subcat5;
                objOraclecommand.Parameters.Add(tmp6);

                OracleParameter tmp = new OracleParameter("pdist_code", OracleType.VarChar, 50);
                tmp.Direction = ParameterDirection.Input;
                tmp.Value = pdist_code;
                objOraclecommand.Parameters.Add(tmp);

                OracleParameter prm1 = new OracleParameter("pfrom_date", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = fromdate;
                //fromdate = changeformat(fromdate);
                //if (fromdate != "")
                //{
                //    prm1.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");
                //}
                //else
                //{
                //    prm1.Value = System.DBNull.Value;
                //}
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("ptill_date", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                //dateto = changeformat(dateto);
                prm2.Value = dateto;

                //if (dateto != "")
                //{
                //    prm2.Value = Convert.ToDateTime(dateto).ToString("dd-MMMM-yyyy");
                //}
                //else
                //{
                //    prm2.Value = System.DBNull.Value;
                //}
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm35 = new OracleParameter("pdateformat", OracleType.VarChar, 50);
                prm35.Direction = ParameterDirection.Input;
                prm35.Value = dateformat;
                objOraclecommand.Parameters.Add(prm35);


                OracleParameter tmp45 = new OracleParameter("puserid", OracleType.VarChar, 50);
                tmp45.Direction = ParameterDirection.Input;
                tmp45.Value = puserid;
                objOraclecommand.Parameters.Add(tmp45);
                //
                OracleParameter m1 = new OracleParameter("ppublcode", OracleType.VarChar, 50);
                m1.Direction = ParameterDirection.Input;
                if (pub_code == "0" || pub_code == "")
                    m1.Value = System.DBNull.Value;
                else
                    m1.Value = pub_code;
                objOraclecommand.Parameters.Add(m1);

                OracleParameter m2 = new OracleParameter("pedtncode", OracleType.VarChar, 50);
                m2.Direction = ParameterDirection.Input;
                if (edtn_code == "0" || edtn_code == "")
                    m2.Value = System.DBNull.Value;
                else
                    m2.Value = edtn_code;
                objOraclecommand.Parameters.Add(m2);

                OracleParameter m3 = new OracleParameter("pteamcode", OracleType.VarChar, 50);
                m3.Direction = ParameterDirection.Input;
                if (team_code == "0" || team_code == "")
                    m3.Value = System.DBNull.Value;
                else
                    m3.Value = team_code;
                objOraclecommand.Parameters.Add(m3);

                OracleParameter m4 = new OracleParameter("pexecode", OracleType.VarChar, 50);
                m4.Direction = ParameterDirection.Input;
                if (exec_code == "0" || exec_code == "")
                    m4.Value = System.DBNull.Value;
                else
                    m4.Value = exec_code;
                objOraclecommand.Parameters.Add(m4);
                //
                OracleParameter prm4 = new OracleParameter("pextra1", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = pextra1;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm12 = new OracleParameter("pextra2", OracleType.VarChar, 50);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = pextra2;
                objOraclecommand.Parameters.Add(prm12);


                OracleParameter prm13 = new OracleParameter("pextra3", OracleType.VarChar, 50);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = pextra3;
                objOraclecommand.Parameters.Add(prm13);



                OracleParameter prm14 = new OracleParameter("pextra4", OracleType.VarChar, 50);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = pextra4;
                objOraclecommand.Parameters.Add(prm14);



                OracleParameter prm15 = new OracleParameter("pextra5", OracleType.VarChar, 50);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = pextra5;
                objOraclecommand.Parameters.Add(prm15);


                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts1"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_accounts2", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts2"].Direction = ParameterDirection.Output;


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

        public DataSet ctreport_main_det(string pcompcode, string ppcentcode, string Branch_Code, string padtype, string padcat, string padsubcat, string pad_subcat3, string pad_subcat4, string pad_subcat5, string pdist_code, string fromdate, string dateto, string dateformat, string puserid, string pextra1, string pextra2, string pextra3, string pextra4, string pextra5, string pub_code, string edtn_code, string team_code, string exec_code)
        {


            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("rpt_categorywise_det.rpt_categorywise_billing_det", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm5 = new OracleParameter("pcompcode", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = pcompcode;
                objOraclecommand.Parameters.Add(prm5);


                OracleParameter prm8 = new OracleParameter("ppcentcode", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = ppcentcode;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm6 = new OracleParameter("punitcode", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = Branch_Code;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("padtype", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = padtype;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter tmp2 = new OracleParameter("padcat", OracleType.VarChar, 50);
                tmp2.Direction = ParameterDirection.Input;
                tmp2.Value = padcat;
                objOraclecommand.Parameters.Add(tmp2);


                OracleParameter temp3 = new OracleParameter("padsubcat", OracleType.VarChar, 50);
                temp3.Direction = ParameterDirection.Input;
                temp3.Value = padsubcat;
                objOraclecommand.Parameters.Add(temp3);



                OracleParameter tmp4 = new OracleParameter("pad_subcat3", OracleType.VarChar, 50);
                tmp4.Direction = ParameterDirection.Input;
                tmp4.Value = pad_subcat3;
                objOraclecommand.Parameters.Add(tmp4);


                OracleParameter tmp5 = new OracleParameter("pad_subcat4", OracleType.VarChar, 50);
                tmp5.Direction = ParameterDirection.Input;
                tmp5.Value = pad_subcat4;
                objOraclecommand.Parameters.Add(tmp5);


                OracleParameter tmp6 = new OracleParameter("pad_subcat5", OracleType.VarChar, 50);
                tmp6.Direction = ParameterDirection.Input;
                tmp6.Value = pad_subcat5;
                objOraclecommand.Parameters.Add(tmp6);

                OracleParameter tmp = new OracleParameter("pdist_code", OracleType.VarChar, 50);
                tmp.Direction = ParameterDirection.Input;
                tmp.Value = pdist_code;
                objOraclecommand.Parameters.Add(tmp);

                OracleParameter prm1 = new OracleParameter("pfrom_date", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = fromdate;
                //fromdate = changeformat(fromdate);
                //if (fromdate != "")
                //{
                //    prm1.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");
                //}
                //else
                //{
                //    prm1.Value = System.DBNull.Value;
                //}
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("ptill_date", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                //dateto = changeformat(dateto);
                prm2.Value = dateto;

                //if (dateto != "")
                //{
                //    prm2.Value = Convert.ToDateTime(dateto).ToString("dd-MMMM-yyyy");
                //}
                //else
                //{
                //    prm2.Value = System.DBNull.Value;
                //}
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm35 = new OracleParameter("pdateformat", OracleType.VarChar, 50);
                prm35.Direction = ParameterDirection.Input;
                prm35.Value = dateformat;
                objOraclecommand.Parameters.Add(prm35);


                OracleParameter tmp45 = new OracleParameter("puserid", OracleType.VarChar, 50);
                tmp45.Direction = ParameterDirection.Input;
                tmp45.Value = puserid;
                objOraclecommand.Parameters.Add(tmp45);
                //
                OracleParameter m1 = new OracleParameter("ppublcode", OracleType.VarChar, 50);
                m1.Direction = ParameterDirection.Input;
                if (pub_code == "0" || pub_code == "")
                    m1.Value = System.DBNull.Value;
                else
                    m1.Value = pub_code;
                objOraclecommand.Parameters.Add(m1);

                OracleParameter m2 = new OracleParameter("pedtncode", OracleType.VarChar, 50);
                m2.Direction = ParameterDirection.Input;
                if (edtn_code == "0" || edtn_code == "")
                    m2.Value = System.DBNull.Value;
                else
                    m2.Value = edtn_code;
                objOraclecommand.Parameters.Add(m2);

                OracleParameter m3 = new OracleParameter("pteamcode", OracleType.VarChar, 50);
                m3.Direction = ParameterDirection.Input;
                if (team_code == "0" || team_code == "")
                    m3.Value = System.DBNull.Value;
                else
                    m3.Value = team_code;
                objOraclecommand.Parameters.Add(m3);

                OracleParameter m4 = new OracleParameter("pexecode", OracleType.VarChar, 50);
                m4.Direction = ParameterDirection.Input;
                if (exec_code == "0" || exec_code == "")
                    m4.Value = System.DBNull.Value;
                else
                    m4.Value = exec_code;
                objOraclecommand.Parameters.Add(m4);
                //
                OracleParameter prm4 = new OracleParameter("pextra1", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = pextra1;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm12 = new OracleParameter("pextra2", OracleType.VarChar, 50);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = pextra2;
                objOraclecommand.Parameters.Add(prm12);


                OracleParameter prm13 = new OracleParameter("pextra3", OracleType.VarChar, 50);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = pextra3;
                objOraclecommand.Parameters.Add(prm13);



                OracleParameter prm14 = new OracleParameter("pextra4", OracleType.VarChar, 50);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = pextra4;
                objOraclecommand.Parameters.Add(prm14);



                OracleParameter prm15 = new OracleParameter("pextra5", OracleType.VarChar, 50);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = pextra5;
                objOraclecommand.Parameters.Add(prm15);


                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts1"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_accounts2", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts2"].Direction = ParameterDirection.Output;


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

        public DataSet ctreport_main_det_region(string pcompcode, string ppcentcode, string Branch_Code, string padtype, string padcat, string padsubcat, string pad_subcat3, string pad_subcat4, string pad_subcat5, string pdist_code, string fromdate, string dateto, string dateformat, string puserid, string pextra1, string pextra2, string pextra3, string pextra4, string pextra5, string pub_code, string edtn_code, string team_code, string exec_code)
        {


            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("rpt_categorywise_det_region.rpt_categorywise_det_region", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm5 = new OracleParameter("pcompcode", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = pcompcode;
                objOraclecommand.Parameters.Add(prm5);


                OracleParameter prm8 = new OracleParameter("ppcentcode", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = ppcentcode;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm6 = new OracleParameter("punitcode", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = Branch_Code;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("padtype", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = padtype;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter tmp2 = new OracleParameter("padcat", OracleType.VarChar, 50);
                tmp2.Direction = ParameterDirection.Input;
                tmp2.Value = padcat;
                objOraclecommand.Parameters.Add(tmp2);


                OracleParameter temp3 = new OracleParameter("padsubcat", OracleType.VarChar, 50);
                temp3.Direction = ParameterDirection.Input;
                temp3.Value = padsubcat;
                objOraclecommand.Parameters.Add(temp3);



                OracleParameter tmp4 = new OracleParameter("pad_subcat3", OracleType.VarChar, 50);
                tmp4.Direction = ParameterDirection.Input;
                tmp4.Value = pad_subcat3;
                objOraclecommand.Parameters.Add(tmp4);


                OracleParameter tmp5 = new OracleParameter("pad_subcat4", OracleType.VarChar, 50);
                tmp5.Direction = ParameterDirection.Input;
                tmp5.Value = pad_subcat4;
                objOraclecommand.Parameters.Add(tmp5);


                OracleParameter tmp6 = new OracleParameter("pad_subcat5", OracleType.VarChar, 50);
                tmp6.Direction = ParameterDirection.Input;
                tmp6.Value = pad_subcat5;
                objOraclecommand.Parameters.Add(tmp6);

                OracleParameter tmp = new OracleParameter("pdist_code", OracleType.VarChar, 50);
                tmp.Direction = ParameterDirection.Input;
                tmp.Value = pdist_code;
                objOraclecommand.Parameters.Add(tmp);

                OracleParameter prm1 = new OracleParameter("pfrom_date", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = fromdate;
                //fromdate = changeformat(fromdate);
                //if (fromdate != "")
                //{
                //    prm1.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");
                //}
                //else
                //{
                //    prm1.Value = System.DBNull.Value;
                //}
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("ptill_date", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                //dateto = changeformat(dateto);
                prm2.Value = dateto;

                //if (dateto != "")
                //{
                //    prm2.Value = Convert.ToDateTime(dateto).ToString("dd-MMMM-yyyy");
                //}
                //else
                //{
                //    prm2.Value = System.DBNull.Value;
                //}
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm35 = new OracleParameter("pdateformat", OracleType.VarChar, 50);
                prm35.Direction = ParameterDirection.Input;
                prm35.Value = dateformat;
                objOraclecommand.Parameters.Add(prm35);


                OracleParameter tmp45 = new OracleParameter("puserid", OracleType.VarChar, 50);
                tmp45.Direction = ParameterDirection.Input;
                tmp45.Value = puserid;
                objOraclecommand.Parameters.Add(tmp45);
                //
                OracleParameter m1 = new OracleParameter("ppublcode", OracleType.VarChar, 50);
                m1.Direction = ParameterDirection.Input;
                if (pub_code == "0" || pub_code == "")
                    m1.Value = System.DBNull.Value;
                else
                    m1.Value = pub_code;
                objOraclecommand.Parameters.Add(m1);

                OracleParameter m2 = new OracleParameter("pedtncode", OracleType.VarChar, 50);
                m2.Direction = ParameterDirection.Input;
                if (edtn_code == "0" || edtn_code == "")
                    m2.Value = System.DBNull.Value;
                else
                    m2.Value = edtn_code;
                objOraclecommand.Parameters.Add(m2);

                OracleParameter m3 = new OracleParameter("pteamcode", OracleType.VarChar, 50);
                m3.Direction = ParameterDirection.Input;
                if (team_code == "0" || team_code == "")
                    m3.Value = System.DBNull.Value;
                else
                    m3.Value = team_code;
                objOraclecommand.Parameters.Add(m3);

                OracleParameter m4 = new OracleParameter("pexecode", OracleType.VarChar, 50);
                m4.Direction = ParameterDirection.Input;
                if (exec_code == "0" || exec_code == "")
                    m4.Value = System.DBNull.Value;
                else
                    m4.Value = exec_code;
                objOraclecommand.Parameters.Add(m4);
                //
                OracleParameter prm4 = new OracleParameter("pextra1", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = pextra1;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm12 = new OracleParameter("pextra2", OracleType.VarChar, 50);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = pextra2;
                objOraclecommand.Parameters.Add(prm12);


                OracleParameter prm13 = new OracleParameter("pextra3", OracleType.VarChar, 50);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = pextra3;
                objOraclecommand.Parameters.Add(prm13);



                OracleParameter prm14 = new OracleParameter("pextra4", OracleType.VarChar, 50);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = pextra4;
                objOraclecommand.Parameters.Add(prm14);



                OracleParameter prm15 = new OracleParameter("pextra5", OracleType.VarChar, 50);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = pextra5;
                objOraclecommand.Parameters.Add(prm15);


                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts1"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_accounts2", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts2"].Direction = ParameterDirection.Output;


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

        public DataSet ctreport_main_rate(string pcompcode, string ppcentcode, string Branch_Code, string padtype, string padcat, string padsubcat, string pad_subcat3, string pad_subcat4, string pad_subcat5, string pdist_code, string fromdate, string dateto, string dateformat, string puserid, string pextra1, string pextra2, string pextra3, string pextra4, string pextra5, string pub_code, string edtn_code, string team_code, string exec_code)
        {


            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("rpt_rate_code_summ", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm5 = new OracleParameter("pcompcode", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = pcompcode;
                objOraclecommand.Parameters.Add(prm5);


                OracleParameter prm8 = new OracleParameter("ppcentcode", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = ppcentcode;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm6 = new OracleParameter("punitcode", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = Branch_Code;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("padtype", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = padtype;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter tmp2 = new OracleParameter("padcat", OracleType.VarChar, 50);
                tmp2.Direction = ParameterDirection.Input;
                tmp2.Value = padcat;
                objOraclecommand.Parameters.Add(tmp2);


                OracleParameter temp3 = new OracleParameter("padsubcat", OracleType.VarChar, 50);
                temp3.Direction = ParameterDirection.Input;
                temp3.Value = padsubcat;
                objOraclecommand.Parameters.Add(temp3);



                OracleParameter tmp4 = new OracleParameter("pad_subcat3", OracleType.VarChar, 50);
                tmp4.Direction = ParameterDirection.Input;
                tmp4.Value = pad_subcat3;
                objOraclecommand.Parameters.Add(tmp4);


                OracleParameter tmp5 = new OracleParameter("pad_subcat4", OracleType.VarChar, 50);
                tmp5.Direction = ParameterDirection.Input;
                tmp5.Value = pad_subcat4;
                objOraclecommand.Parameters.Add(tmp5);


                OracleParameter tmp6 = new OracleParameter("pad_subcat5", OracleType.VarChar, 50);
                tmp6.Direction = ParameterDirection.Input;
                tmp6.Value = pad_subcat5;
                objOraclecommand.Parameters.Add(tmp6);

                OracleParameter tmp = new OracleParameter("pdist_code", OracleType.VarChar, 50);
                tmp.Direction = ParameterDirection.Input;
                tmp.Value = pdist_code;
                objOraclecommand.Parameters.Add(tmp);

                OracleParameter prm1 = new OracleParameter("pfrom_date", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = fromdate;
                //fromdate = changeformat(fromdate);
                //if (fromdate != "")
                //{
                //    prm1.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");
                //}
                //else
                //{
                //    prm1.Value = System.DBNull.Value;
                //}
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("ptill_date", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                //dateto = changeformat(dateto);
                prm2.Value = dateto;

                //if (dateto != "")
                //{
                //    prm2.Value = Convert.ToDateTime(dateto).ToString("dd-MMMM-yyyy");
                //}
                //else
                //{
                //    prm2.Value = System.DBNull.Value;
                //}
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm35 = new OracleParameter("pdateformat", OracleType.VarChar, 50);
                prm35.Direction = ParameterDirection.Input;
                prm35.Value = dateformat;
                objOraclecommand.Parameters.Add(prm35);


                OracleParameter tmp45 = new OracleParameter("puserid", OracleType.VarChar, 50);
                tmp45.Direction = ParameterDirection.Input;
                tmp45.Value = puserid;
                objOraclecommand.Parameters.Add(tmp45);
                //
                OracleParameter m1 = new OracleParameter("ppublcode", OracleType.VarChar, 50);
                m1.Direction = ParameterDirection.Input;
                if (pub_code == "0" || pub_code == "")
                    m1.Value = System.DBNull.Value;
                else
                    m1.Value = pub_code;
                objOraclecommand.Parameters.Add(m1);

                OracleParameter m2 = new OracleParameter("pedtncode", OracleType.VarChar, 50);
                m2.Direction = ParameterDirection.Input;
                if (edtn_code == "0" || edtn_code == "")
                    m2.Value = System.DBNull.Value;
                else
                    m2.Value = edtn_code;
                objOraclecommand.Parameters.Add(m2);

                OracleParameter m3 = new OracleParameter("pteamcode", OracleType.VarChar, 50);
                m3.Direction = ParameterDirection.Input;
                if (team_code == "0" || team_code == "")
                    m3.Value = System.DBNull.Value;
                else
                    m3.Value = team_code;
                objOraclecommand.Parameters.Add(m3);

                OracleParameter m4 = new OracleParameter("pexecode", OracleType.VarChar, 50);
                m4.Direction = ParameterDirection.Input;
                if (exec_code == "0" || exec_code == "")
                    m4.Value = System.DBNull.Value;
                else
                    m4.Value = exec_code;
                objOraclecommand.Parameters.Add(m4);
                //
                OracleParameter prm4 = new OracleParameter("pextra1", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = pextra1;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm12 = new OracleParameter("pextra2", OracleType.VarChar, 50);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = pextra2;
                objOraclecommand.Parameters.Add(prm12);


                OracleParameter prm13 = new OracleParameter("pextra3", OracleType.VarChar, 50);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = pextra3;
                objOraclecommand.Parameters.Add(prm13);



                OracleParameter prm14 = new OracleParameter("pextra4", OracleType.VarChar, 50);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = pextra4;
                objOraclecommand.Parameters.Add(prm14);



                OracleParameter prm15 = new OracleParameter("pextra5", OracleType.VarChar, 50);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = pextra5;
                objOraclecommand.Parameters.Add(prm15);


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
        public DataSet ctreport_main_bookrate(string pcompcode, string ppcentcode, string Branch_Code, string padtype, string padcat, string padsubcat, string pad_subcat3, string pad_subcat4, string pad_subcat5, string pdist_code, string fromdate, string dateto, string dateformat, string puserid, string pextra1, string pextra2, string pextra3, string pextra4, string pextra5, string pub_code, string edtn_code, string team_code, string exec_code)
        {


            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("rpt_rate_code_book", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm5 = new OracleParameter("pcompcode", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = pcompcode;
                objOraclecommand.Parameters.Add(prm5);


                OracleParameter prm8 = new OracleParameter("ppcentcode", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = ppcentcode;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm6 = new OracleParameter("punitcode", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = Branch_Code;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("padtype", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = padtype;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter tmp2 = new OracleParameter("padcat", OracleType.VarChar, 50);
                tmp2.Direction = ParameterDirection.Input;
                tmp2.Value = padcat;
                objOraclecommand.Parameters.Add(tmp2);


                OracleParameter temp3 = new OracleParameter("padsubcat", OracleType.VarChar, 50);
                temp3.Direction = ParameterDirection.Input;
                temp3.Value = padsubcat;
                objOraclecommand.Parameters.Add(temp3);



                OracleParameter tmp4 = new OracleParameter("pad_subcat3", OracleType.VarChar, 50);
                tmp4.Direction = ParameterDirection.Input;
                tmp4.Value = pad_subcat3;
                objOraclecommand.Parameters.Add(tmp4);


                OracleParameter tmp5 = new OracleParameter("pad_subcat4", OracleType.VarChar, 50);
                tmp5.Direction = ParameterDirection.Input;
                tmp5.Value = pad_subcat4;
                objOraclecommand.Parameters.Add(tmp5);


                OracleParameter tmp6 = new OracleParameter("pad_subcat5", OracleType.VarChar, 50);
                tmp6.Direction = ParameterDirection.Input;
                tmp6.Value = pad_subcat5;
                objOraclecommand.Parameters.Add(tmp6);

                OracleParameter tmp = new OracleParameter("pdist_code", OracleType.VarChar, 50);
                tmp.Direction = ParameterDirection.Input;
                tmp.Value = pdist_code;
                objOraclecommand.Parameters.Add(tmp);

                OracleParameter prm1 = new OracleParameter("pfrom_date", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = fromdate;
                //fromdate = changeformat(fromdate);
                //if (fromdate != "")
                //{
                //    prm1.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");
                //}
                //else
                //{
                //    prm1.Value = System.DBNull.Value;
                //}
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("ptill_date", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                //dateto = changeformat(dateto);
                prm2.Value = dateto;

                //if (dateto != "")
                //{
                //    prm2.Value = Convert.ToDateTime(dateto).ToString("dd-MMMM-yyyy");
                //}
                //else
                //{
                //    prm2.Value = System.DBNull.Value;
                //}
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm35 = new OracleParameter("pdateformat", OracleType.VarChar, 50);
                prm35.Direction = ParameterDirection.Input;
                prm35.Value = dateformat;
                objOraclecommand.Parameters.Add(prm35);


                OracleParameter tmp45 = new OracleParameter("puserid", OracleType.VarChar, 50);
                tmp45.Direction = ParameterDirection.Input;
                tmp45.Value = puserid;
                objOraclecommand.Parameters.Add(tmp45);
                //
                OracleParameter m1 = new OracleParameter("ppublcode", OracleType.VarChar, 50);
                m1.Direction = ParameterDirection.Input;
                if (pub_code == "0" || pub_code == "")
                    m1.Value = System.DBNull.Value;
                else
                    m1.Value = pub_code;
                objOraclecommand.Parameters.Add(m1);

                OracleParameter m2 = new OracleParameter("pedtncode", OracleType.VarChar, 50);
                m2.Direction = ParameterDirection.Input;
                if (edtn_code == "0" || edtn_code == "")
                    m2.Value = System.DBNull.Value;
                else
                    m2.Value = edtn_code;
                objOraclecommand.Parameters.Add(m2);

                OracleParameter m3 = new OracleParameter("pteamcode", OracleType.VarChar, 50);
                m3.Direction = ParameterDirection.Input;
                if (team_code == "0" || team_code == "")
                    m3.Value = System.DBNull.Value;
                else
                    m3.Value = team_code;
                objOraclecommand.Parameters.Add(m3);

                OracleParameter m4 = new OracleParameter("pexecode", OracleType.VarChar, 50);
                m4.Direction = ParameterDirection.Input;
                if (exec_code == "0" || exec_code == "")
                    m4.Value = System.DBNull.Value;
                else
                    m4.Value = exec_code;
                objOraclecommand.Parameters.Add(m4);
                //
                OracleParameter prm4 = new OracleParameter("pextra1", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = pextra1;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm12 = new OracleParameter("pextra2", OracleType.VarChar, 50);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = pextra2;
                objOraclecommand.Parameters.Add(prm12);


                OracleParameter prm13 = new OracleParameter("pextra3", OracleType.VarChar, 50);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = pextra3;
                objOraclecommand.Parameters.Add(prm13);



                OracleParameter prm14 = new OracleParameter("pextra4", OracleType.VarChar, 50);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = pextra4;
                objOraclecommand.Parameters.Add(prm14);



                OracleParameter prm15 = new OracleParameter("pextra5", OracleType.VarChar, 50);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = pextra5;
                objOraclecommand.Parameters.Add(prm15);


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


        public DataSet ctreport_main_agen(string pcompcode, string ppcentcode, string Branch_Code, string padtype, string padcat, string padsubcat, string pad_subcat3, string pad_subcat4, string pad_subcat5, string pdist_code, string fromdate, string dateto, string dateformat, string puserid, string pextra1, string pextra2, string pextra3, string pextra4, string pextra5, string pub_code, string edtn_code, string team_code, string exec_code)
        {


            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("rpt_agen_client", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm5 = new OracleParameter("pcompcode", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = pcompcode;
                objOraclecommand.Parameters.Add(prm5);


                OracleParameter prm8 = new OracleParameter("ppcentcode", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = ppcentcode;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm6 = new OracleParameter("punitcode", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = Branch_Code;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("padtype", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = padtype;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter tmp2 = new OracleParameter("padcat", OracleType.VarChar, 50);
                tmp2.Direction = ParameterDirection.Input;
                tmp2.Value = padcat;
                objOraclecommand.Parameters.Add(tmp2);


                OracleParameter temp3 = new OracleParameter("padsubcat", OracleType.VarChar, 50);
                temp3.Direction = ParameterDirection.Input;
                temp3.Value = padsubcat;
                objOraclecommand.Parameters.Add(temp3);



                OracleParameter tmp4 = new OracleParameter("pad_subcat3", OracleType.VarChar, 50);
                tmp4.Direction = ParameterDirection.Input;
                tmp4.Value = pad_subcat3;
                objOraclecommand.Parameters.Add(tmp4);


                OracleParameter tmp5 = new OracleParameter("pad_subcat4", OracleType.VarChar, 50);
                tmp5.Direction = ParameterDirection.Input;
                tmp5.Value = pad_subcat4;
                objOraclecommand.Parameters.Add(tmp5);


                OracleParameter tmp6 = new OracleParameter("pad_subcat5", OracleType.VarChar, 50);
                tmp6.Direction = ParameterDirection.Input;
                tmp6.Value = pad_subcat5;
                objOraclecommand.Parameters.Add(tmp6);

                OracleParameter tmp = new OracleParameter("pdist_code", OracleType.VarChar, 50);
                tmp.Direction = ParameterDirection.Input;
                tmp.Value = pdist_code;
                objOraclecommand.Parameters.Add(tmp);

                OracleParameter prm1 = new OracleParameter("pfrom_date", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = fromdate;
                //fromdate = changeformat(fromdate);
                //if (fromdate != "")
                //{
                //    prm1.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");
                //}
                //else
                //{
                //    prm1.Value = System.DBNull.Value;
                //}
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("ptill_date", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                //dateto = changeformat(dateto);
                prm2.Value = dateto;

                //if (dateto != "")
                //{
                //    prm2.Value = Convert.ToDateTime(dateto).ToString("dd-MMMM-yyyy");
                //}
                //else
                //{
                //    prm2.Value = System.DBNull.Value;
                //}
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm35 = new OracleParameter("pdateformat", OracleType.VarChar, 50);
                prm35.Direction = ParameterDirection.Input;
                prm35.Value = dateformat;
                objOraclecommand.Parameters.Add(prm35);


                OracleParameter tmp45 = new OracleParameter("puserid", OracleType.VarChar, 50);
                tmp45.Direction = ParameterDirection.Input;
                tmp45.Value = puserid;
                objOraclecommand.Parameters.Add(tmp45);
                //
                OracleParameter m1 = new OracleParameter("ppublcode", OracleType.VarChar, 50);
                m1.Direction = ParameterDirection.Input;
                if (pub_code == "0" || pub_code == "")
                    m1.Value = System.DBNull.Value;
                else
                    m1.Value = pub_code;
                objOraclecommand.Parameters.Add(m1);

                OracleParameter m2 = new OracleParameter("pedtncode", OracleType.VarChar, 50);
                m2.Direction = ParameterDirection.Input;
                if (edtn_code == "0" || edtn_code == "")
                    m2.Value = System.DBNull.Value;
                else
                    m2.Value = edtn_code;
                objOraclecommand.Parameters.Add(m2);

                OracleParameter m3 = new OracleParameter("pteamcode", OracleType.VarChar, 50);
                m3.Direction = ParameterDirection.Input;
                if (team_code == "0" || team_code == "")
                    m3.Value = System.DBNull.Value;
                else
                    m3.Value = team_code;
                objOraclecommand.Parameters.Add(m3);

                OracleParameter m4 = new OracleParameter("pexecode", OracleType.VarChar, 50);
                m4.Direction = ParameterDirection.Input;
                if (exec_code == "0" || exec_code == "")
                    m4.Value = System.DBNull.Value;
                else
                    m4.Value = exec_code;
                objOraclecommand.Parameters.Add(m4);
                //
                OracleParameter prm4 = new OracleParameter("pextra1", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = pextra1;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm12 = new OracleParameter("pextra2", OracleType.VarChar, 50);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = pextra2;
                objOraclecommand.Parameters.Add(prm12);


                OracleParameter prm13 = new OracleParameter("pextra3", OracleType.VarChar, 50);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = pextra3;
                objOraclecommand.Parameters.Add(prm13);



                OracleParameter prm14 = new OracleParameter("pextra4", OracleType.VarChar, 50);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = pextra4;
                objOraclecommand.Parameters.Add(prm14);



                OracleParameter prm15 = new OracleParameter("pextra5", OracleType.VarChar, 50);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = pextra5;
                objOraclecommand.Parameters.Add(prm15);


                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;


                objOraclecommand.Parameters.Add("p_accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts1"].Direction = ParameterDirection.Output;


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
        public DataSet ctreport_last_ins(string pcompcode, string ppcentcode, string Branch_Code, string padtype, string padcat, string padsubcat, string pad_subcat3, string pad_subcat4, string pad_subcat5, string pdist_code, string fromdate, string dateto, string dateformat, string puserid, string pextra1, string pextra2, string pextra3, string pextra4, string pextra5, string pub_code, string edtn_code, string team_code, string exec_code)
        {


            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("rpt_last_ins_dt", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm5 = new OracleParameter("pcompcode", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = pcompcode;
                objOraclecommand.Parameters.Add(prm5);


                OracleParameter prm8 = new OracleParameter("ppcentcode", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = ppcentcode;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm6 = new OracleParameter("punitcode", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = Branch_Code;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("padtype", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = padtype;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter tmp2 = new OracleParameter("padcat", OracleType.VarChar, 50);
                tmp2.Direction = ParameterDirection.Input;
                tmp2.Value = padcat;
                objOraclecommand.Parameters.Add(tmp2);


                OracleParameter temp3 = new OracleParameter("padsubcat", OracleType.VarChar, 50);
                temp3.Direction = ParameterDirection.Input;
                temp3.Value = padsubcat;
                objOraclecommand.Parameters.Add(temp3);



                OracleParameter tmp4 = new OracleParameter("pad_subcat3", OracleType.VarChar, 50);
                tmp4.Direction = ParameterDirection.Input;
                tmp4.Value = pad_subcat3;
                objOraclecommand.Parameters.Add(tmp4);


                OracleParameter tmp5 = new OracleParameter("pad_subcat4", OracleType.VarChar, 50);
                tmp5.Direction = ParameterDirection.Input;
                tmp5.Value = pad_subcat4;
                objOraclecommand.Parameters.Add(tmp5);


                OracleParameter tmp6 = new OracleParameter("pad_subcat5", OracleType.VarChar, 50);
                tmp6.Direction = ParameterDirection.Input;
                tmp6.Value = pad_subcat5;
                objOraclecommand.Parameters.Add(tmp6);

                OracleParameter tmp = new OracleParameter("pdist_code", OracleType.VarChar, 50);
                tmp.Direction = ParameterDirection.Input;
                tmp.Value = pdist_code;
                objOraclecommand.Parameters.Add(tmp);

                OracleParameter prm1 = new OracleParameter("pfrom_date", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = fromdate;
                //fromdate = changeformat(fromdate);
                //if (fromdate != "")
                //{
                //    prm1.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");
                //}
                //else
                //{
                //    prm1.Value = System.DBNull.Value;
                //}
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("ptill_date", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                //dateto = changeformat(dateto);
                prm2.Value = dateto;

                //if (dateto != "")
                //{
                //    prm2.Value = Convert.ToDateTime(dateto).ToString("dd-MMMM-yyyy");
                //}
                //else
                //{
                //    prm2.Value = System.DBNull.Value;
                //}
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm35 = new OracleParameter("pdateformat", OracleType.VarChar, 50);
                prm35.Direction = ParameterDirection.Input;
                prm35.Value = dateformat;
                objOraclecommand.Parameters.Add(prm35);


                OracleParameter tmp45 = new OracleParameter("puserid", OracleType.VarChar, 50);
                tmp45.Direction = ParameterDirection.Input;
                tmp45.Value = puserid;
                objOraclecommand.Parameters.Add(tmp45);
                //
                OracleParameter m1 = new OracleParameter("ppublcode", OracleType.VarChar, 50);
                m1.Direction = ParameterDirection.Input;
                if (pub_code == "0" || pub_code == "")
                    m1.Value = System.DBNull.Value;
                else
                    m1.Value = pub_code;
                objOraclecommand.Parameters.Add(m1);

                OracleParameter m2 = new OracleParameter("pedtncode", OracleType.VarChar, 50);
                m2.Direction = ParameterDirection.Input;
                if (edtn_code == "0" || edtn_code == "")
                    m2.Value = System.DBNull.Value;
                else
                    m2.Value = edtn_code;
                objOraclecommand.Parameters.Add(m2);

                OracleParameter m3 = new OracleParameter("pteamcode", OracleType.VarChar, 50);
                m3.Direction = ParameterDirection.Input;
                if (team_code == "0" || team_code == "")
                    m3.Value = System.DBNull.Value;
                else
                    m3.Value = team_code;
                objOraclecommand.Parameters.Add(m3);

                OracleParameter m4 = new OracleParameter("pexecode", OracleType.VarChar, 50);
                m4.Direction = ParameterDirection.Input;
                if (exec_code == "0" || exec_code == "")
                    m4.Value = System.DBNull.Value;
                else
                    m4.Value = exec_code;
                objOraclecommand.Parameters.Add(m4);
                //
                OracleParameter prm4 = new OracleParameter("pextra1", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = pextra1;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm12 = new OracleParameter("pextra2", OracleType.VarChar, 50);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = pextra2;
                objOraclecommand.Parameters.Add(prm12);


                OracleParameter prm13 = new OracleParameter("pextra3", OracleType.VarChar, 50);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = pextra3;
                objOraclecommand.Parameters.Add(prm13);



                OracleParameter prm14 = new OracleParameter("pextra4", OracleType.VarChar, 50);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = pextra4;
                objOraclecommand.Parameters.Add(prm14);



                OracleParameter prm15 = new OracleParameter("pextra5", OracleType.VarChar, 50);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = pextra5;
                objOraclecommand.Parameters.Add(prm15);


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
        public DataSet districtwise(string pcompcode, string pcentcode, string Branch_Code, string padtype, string padcat, string padsubcat, string pad_subcat3, string pad_subcat4, string pad_subcat5, string pdist_code, string fromdate, string dateto, string dateformat, string puserid, string pub_code, string edtn_code, string team_code, string exec_code, string preporttype, string pextra1, string pextra2, string pextra3, string pextra4, string pextra5)
        {


            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("rpt_categorywise_rpt", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm5 = new OracleParameter("pcompcode", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = pcompcode;
                objOraclecommand.Parameters.Add(prm5);


                OracleParameter prm8 = new OracleParameter("ppcentcode", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = pcentcode;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm6 = new OracleParameter("punitcode", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = Branch_Code;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("padtype", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = padtype;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter tmp2 = new OracleParameter("padcat", OracleType.VarChar, 50);
                tmp2.Direction = ParameterDirection.Input;
                tmp2.Value = padcat;
                objOraclecommand.Parameters.Add(tmp2);


                OracleParameter temp3 = new OracleParameter("padsubcat", OracleType.VarChar, 50);
                temp3.Direction = ParameterDirection.Input;
                temp3.Value = padsubcat;
                objOraclecommand.Parameters.Add(temp3);



                OracleParameter tmp4 = new OracleParameter("pad_subcat3", OracleType.VarChar, 50);
                tmp4.Direction = ParameterDirection.Input;
                tmp4.Value = pad_subcat3;
                objOraclecommand.Parameters.Add(tmp4);


                OracleParameter tmp5 = new OracleParameter("pad_subcat4", OracleType.VarChar, 50);
                tmp5.Direction = ParameterDirection.Input;
                tmp5.Value = pad_subcat4;
                objOraclecommand.Parameters.Add(tmp5);


                OracleParameter tmp6 = new OracleParameter("pad_subcat5", OracleType.VarChar, 50);
                tmp6.Direction = ParameterDirection.Input;
                tmp6.Value = pad_subcat5;
                objOraclecommand.Parameters.Add(tmp6);

                OracleParameter tmp = new OracleParameter("pdist_code", OracleType.VarChar, 50);
                tmp.Direction = ParameterDirection.Input;
                tmp.Value = pdist_code;
                objOraclecommand.Parameters.Add(tmp);

                OracleParameter prm1 = new OracleParameter("pfrom_date", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = fromdate;
                //fromdate = changeformat(fromdate);
                //if (fromdate != "")
                //{
                //    prm1.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");
                //}
                //else
                //{
                //    prm1.Value = System.DBNull.Value;
                //}
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("ptill_date", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                //dateto = changeformat(dateto);
                prm2.Value = dateto;

                //if (dateto != "")
                //{
                //    prm2.Value = Convert.ToDateTime(dateto).ToString("dd-MMMM-yyyy");
                //}
                //else
                //{
                //    prm2.Value = System.DBNull.Value;
                //}
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm35 = new OracleParameter("pdateformat", OracleType.VarChar, 50);
                prm35.Direction = ParameterDirection.Input;
                prm35.Value = dateformat;
                objOraclecommand.Parameters.Add(prm35);


                OracleParameter tmp45 = new OracleParameter("puserid", OracleType.VarChar, 50);
                tmp45.Direction = ParameterDirection.Input;
                tmp45.Value = puserid;
                objOraclecommand.Parameters.Add(tmp45);

                OracleParameter m1 = new OracleParameter("ppublcode", OracleType.VarChar, 50);
                m1.Direction = ParameterDirection.Input;
                if (pub_code == "0" || pub_code == "")
                    m1.Value = System.DBNull.Value;
                else
                    m1.Value = pub_code;
                objOraclecommand.Parameters.Add(m1);

                OracleParameter m2 = new OracleParameter("pedtncode", OracleType.VarChar, 50);
                m2.Direction = ParameterDirection.Input;
                if (edtn_code == "0" || edtn_code == "")
                    m2.Value = System.DBNull.Value;
                else
                    m2.Value = edtn_code;
                objOraclecommand.Parameters.Add(m2);

                OracleParameter m3 = new OracleParameter("pteamcode", OracleType.VarChar, 50);
                m3.Direction = ParameterDirection.Input;
                if (team_code == "0" || team_code == "")
                    m3.Value = System.DBNull.Value;
                else
                    m3.Value = team_code;
                objOraclecommand.Parameters.Add(m3);


                OracleParameter m4 = new OracleParameter("pexecode", OracleType.VarChar, 50);
                m4.Direction = ParameterDirection.Input;
                if (exec_code == "0" || exec_code == "")
                    m4.Value = System.DBNull.Value;
                else
                    m4.Value = exec_code;
                objOraclecommand.Parameters.Add(m4);
                //
                OracleParameter prm4 = new OracleParameter("preporttype", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = preporttype;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm11 = new OracleParameter("pextra1", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = pextra1;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("pextra2", OracleType.VarChar, 50);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = pextra2;
                objOraclecommand.Parameters.Add(prm12);


                OracleParameter prm13 = new OracleParameter("pextra3", OracleType.VarChar, 50);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = pextra3;
                objOraclecommand.Parameters.Add(prm13);



                OracleParameter prm14 = new OracleParameter("pextra4", OracleType.VarChar, 50);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = pextra4;
                objOraclecommand.Parameters.Add(prm14);



                OracleParameter prm15 = new OracleParameter("pextra5", OracleType.VarChar, 50);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = pextra5;
                objOraclecommand.Parameters.Add(prm15);


                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts1"].Direction = ParameterDirection.Output;


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


        public DataSet categoryWise(string pcompcode, string pcentcode, string Branch_Code, string padcat, string fromdate, string dateto, string pdist_code, string pag_main_code, string pag_sub_code, string puserid, string dateformat, string preporttype, string pextra1, string pextra2, string pextra3, string pextra4, string pextra5)
        {


            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("rpt_monthwise_sale_summ_P", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("pcompcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = pcompcode;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("pcenter", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = pcentcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("pbranchcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = Branch_Code;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("pagcatg", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = padcat;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("pdatefrom", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = fromdate;
                //fromdate = changeformat(fromdate);
                //if (fromdate != "")
                //{
                //    prm1.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");
                //}
                //else
                //{
                //    prm1.Value = System.DBNull.Value;
                //}
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("pdateto", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                //dateto = changeformat(dateto);
                prm6.Value = dateto;

                //if (dateto != "")
                //{
                //    prm2.Value = Convert.ToDateTime(dateto).ToString("dd-MMMM-yyyy");
                //}
                //else
                //{
                //    prm2.Value = System.DBNull.Value;
                //}
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("pdistcode", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = pdist_code;
                objOraclecommand.Parameters.Add(prm7);


                OracleParameter prm8 = new OracleParameter("pag_main_code", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = pag_main_code;
                objOraclecommand.Parameters.Add(prm8);


                OracleParameter prm9 = new OracleParameter("pag_sub_code", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = pag_sub_code;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("puserid", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = puserid;
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("pdateformat", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = dateformat;
                objOraclecommand.Parameters.Add(prm11);


                OracleParameter prm12 = new OracleParameter("preptype", OracleType.VarChar, 50);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = preporttype;
                objOraclecommand.Parameters.Add(prm12);

                OracleParameter prm13 = new OracleParameter("pextra1", OracleType.VarChar, 50);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = pextra1;
                objOraclecommand.Parameters.Add(prm13);

                OracleParameter prm14 = new OracleParameter("pextra2", OracleType.VarChar, 50);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = pextra2;
                objOraclecommand.Parameters.Add(prm14);


                OracleParameter prm15 = new OracleParameter("pextra3", OracleType.VarChar, 50);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = pextra3;
                objOraclecommand.Parameters.Add(prm15);



                OracleParameter prm16 = new OracleParameter("pextra4", OracleType.VarChar, 50);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = pextra4;
                objOraclecommand.Parameters.Add(prm16);


                OracleParameter prm17 = new OracleParameter("pextra5", OracleType.VarChar, 50);
                prm17.Direction = ParameterDirection.Input;
                prm17.Value = pextra5;
                objOraclecommand.Parameters.Add(prm17);


                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts1"].Direction = ParameterDirection.Output;


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




        public DataSet ctrdatereport_view(string pcompcode, string ppcentcode, string Branch_Code, string padtype, string padcat, string padsubcat, string pad_subcat3, string pad_subcat4, string pad_subcat5, string pdist_code, string fromdate, string dateto, string dateformat, string puserid, string pextra1, string pextra2, string pextra3, string pextra4, string pextra5, string pub_code, string edtn_code, string team_code, string exec_code)
        {


            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("rpt_categorywisedate_summary.rpt_categorywisedate_billing", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm5 = new OracleParameter("pcompcode", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = pcompcode;
                objOraclecommand.Parameters.Add(prm5);


                OracleParameter prm8 = new OracleParameter("ppcentcode", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = ppcentcode;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm6 = new OracleParameter("punitcode", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = Branch_Code;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("padtype", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = padtype;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter tmp2 = new OracleParameter("padcat", OracleType.VarChar, 50);
                tmp2.Direction = ParameterDirection.Input;
                tmp2.Value = padcat;
                objOraclecommand.Parameters.Add(tmp2);


                OracleParameter temp3 = new OracleParameter("padsubcat", OracleType.VarChar, 50);
                temp3.Direction = ParameterDirection.Input;
                temp3.Value = padsubcat;
                objOraclecommand.Parameters.Add(temp3);



                OracleParameter tmp4 = new OracleParameter("pad_subcat3", OracleType.VarChar, 50);
                tmp4.Direction = ParameterDirection.Input;
                tmp4.Value = pad_subcat3;
                objOraclecommand.Parameters.Add(tmp4);


                OracleParameter tmp5 = new OracleParameter("pad_subcat4", OracleType.VarChar, 50);
                tmp5.Direction = ParameterDirection.Input;
                tmp5.Value = pad_subcat4;
                objOraclecommand.Parameters.Add(tmp5);


                OracleParameter tmp6 = new OracleParameter("pad_subcat5", OracleType.VarChar, 50);
                tmp6.Direction = ParameterDirection.Input;
                tmp6.Value = pad_subcat5;
                objOraclecommand.Parameters.Add(tmp6);

                OracleParameter tmp = new OracleParameter("pdist_code", OracleType.VarChar, 50);
                tmp.Direction = ParameterDirection.Input;
                tmp.Value = pdist_code;
                objOraclecommand.Parameters.Add(tmp);

                OracleParameter prm1 = new OracleParameter("pfrom_date", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = fromdate;
                //fromdate = changeformat(fromdate);
                //if (fromdate != "")
                //{
                //    prm1.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");
                //}
                //else
                //{
                //    prm1.Value = System.DBNull.Value;
                //}
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("ptill_date", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                //dateto = changeformat(dateto);
                prm2.Value = dateto;

                //if (dateto != "")
                //{
                //    prm2.Value = Convert.ToDateTime(dateto).ToString("dd-MMMM-yyyy");
                //}
                //else
                //{
                //    prm2.Value = System.DBNull.Value;
                //}
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm35 = new OracleParameter("pdateformat", OracleType.VarChar, 50);
                prm35.Direction = ParameterDirection.Input;
                prm35.Value = dateformat;
                objOraclecommand.Parameters.Add(prm35);


                OracleParameter tmp45 = new OracleParameter("puserid", OracleType.VarChar, 50);
                tmp45.Direction = ParameterDirection.Input;
                tmp45.Value = puserid;
                objOraclecommand.Parameters.Add(tmp45);
                //
                OracleParameter m1 = new OracleParameter("ppublcode", OracleType.VarChar, 50);
                m1.Direction = ParameterDirection.Input;
                if (pub_code == "0" || pub_code == "")
                    m1.Value = System.DBNull.Value;
                else
                    m1.Value = pub_code;
                objOraclecommand.Parameters.Add(m1);

                OracleParameter m2 = new OracleParameter("pedtncode", OracleType.VarChar, 50);
                m2.Direction = ParameterDirection.Input;
                if (edtn_code == "0" || edtn_code == "")
                    m2.Value = System.DBNull.Value;
                else
                    m2.Value = edtn_code;
                objOraclecommand.Parameters.Add(m2);

                OracleParameter m3 = new OracleParameter("pteamcode", OracleType.VarChar, 50);
                m3.Direction = ParameterDirection.Input;
                if (team_code == "0" || team_code == "")
                    m3.Value = System.DBNull.Value;
                else
                    m3.Value = team_code;
                objOraclecommand.Parameters.Add(m3);

                OracleParameter m4 = new OracleParameter("pexecode", OracleType.VarChar, 50);
                m4.Direction = ParameterDirection.Input;
                if (exec_code == "0" || exec_code == "")
                    m4.Value = System.DBNull.Value;
                else
                    m4.Value = exec_code;
                objOraclecommand.Parameters.Add(m4);
                //
                OracleParameter prm4 = new OracleParameter("pextra1", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = pextra1;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm12 = new OracleParameter("pextra2", OracleType.VarChar, 50);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = pextra2;
                objOraclecommand.Parameters.Add(prm12);


                OracleParameter prm13 = new OracleParameter("pextra3", OracleType.VarChar, 50);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = pextra3;
                objOraclecommand.Parameters.Add(prm13);



                OracleParameter prm14 = new OracleParameter("pextra4", OracleType.VarChar, 50);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = pextra4;
                objOraclecommand.Parameters.Add(prm14);



                OracleParameter prm15 = new OracleParameter("pextra5", OracleType.VarChar, 50);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = pextra5;
                objOraclecommand.Parameters.Add(prm15);


                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts1"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_accounts2", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts2"].Direction = ParameterDirection.Output;


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