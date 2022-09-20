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
    /// Summary description for billreport
    /// </summary>
    public class billreport : orclconnection
    {
        public billreport()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataSet spcontractreport(string fromdate, string dateto, string compcode, string dateformat, string product, string descid, string ascdesc, string temp1, string temp2, string temp3, string temp4, string temp5, string temp6, string temp7, string temp8, string temp9, string temp10, string temp11)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {

                objOracleConnection.Open();
                //objOraclecommand = GetCommand("MisReport.MisReport_p", ref objOracleConnection);
                //objOraclecommand.CommandType = CommandType.StoredProcedure;

                objOraclecommand = GetCommand("Misreportnew", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm4 = new OracleParameter("fromdate", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                if (fromdate == "")
                {
                    prm4.Value = System.DBNull.Value;
                }
                else
                {
                    prm4.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("dateto", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                if (dateto == "")
                {
                    prm5.Value = System.DBNull.Value;
                }
                else
                {
                    prm5.Value = Convert.ToDateTime(dateto).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("compcode", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = compcode;
                objOraclecommand.Parameters.Add(prm6);


                OracleParameter prm7 = new OracleParameter("product", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                if (product == "0")
                {
                    prm7.Value = System.DBNull.Value;
                }
                else
                {
                    prm7.Value = product;
                }
                objOraclecommand.Parameters.Add(prm7);



                OracleParameter prm14 = new OracleParameter("dateformat", OracleType.VarChar);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = dateformat;
                objOraclecommand.Parameters.Add(prm14);

                OracleParameter prm15 = new OracleParameter("descid", OracleType.VarChar);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = descid;
                objOraclecommand.Parameters.Add(prm15);

                OracleParameter prm16 = new OracleParameter("ascdesc", OracleType.VarChar);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = ascdesc;
                objOraclecommand.Parameters.Add(prm16);

                //====================

                OracleParameter tmp1 = new OracleParameter("agname", OracleType.VarChar);
                tmp1.Direction = ParameterDirection.Input;
                tmp1.Value = temp1;
                objOraclecommand.Parameters.Add(tmp1);

                OracleParameter tmp2 = new OracleParameter("clientname", OracleType.VarChar);
                tmp2.Direction = ParameterDirection.Input;
                tmp2.Value = temp2;
                objOraclecommand.Parameters.Add(tmp2);

                OracleParameter tmp3 = new OracleParameter("adtype1", OracleType.VarChar);
                tmp3.Direction = ParameterDirection.Input;
                tmp3.Value = temp3;
                objOraclecommand.Parameters.Add(tmp3);

                OracleParameter tmp4 = new OracleParameter("adcategory", OracleType.VarChar);
                tmp4.Direction = ParameterDirection.Input;
                tmp4.Value = temp4;
                objOraclecommand.Parameters.Add(tmp4);

                OracleParameter tmp5 = new OracleParameter("Region", OracleType.VarChar);
                tmp5.Direction = ParameterDirection.Input;
                tmp5.Value = temp5;
                objOraclecommand.Parameters.Add(tmp5);

                OracleParameter tmp6 = new OracleParameter("pub_cent", OracleType.VarChar);
                tmp6.Direction = ParameterDirection.Input;
                tmp6.Value = temp6;
                objOraclecommand.Parameters.Add(tmp6);

                OracleParameter tmp7 = new OracleParameter("status", OracleType.VarChar);
                tmp7.Direction = ParameterDirection.Input;
                tmp7.Value = temp7;
                objOraclecommand.Parameters.Add(tmp7);

                OracleParameter tmp8 = new OracleParameter("edition", OracleType.VarChar);
                tmp8.Direction = ParameterDirection.Input;
                tmp8.Value = temp8;
                objOraclecommand.Parameters.Add(tmp8);

                OracleParameter tmp9 = new OracleParameter("hold", OracleType.VarChar);
                tmp9.Direction = ParameterDirection.Input;
                tmp9.Value = temp9;
                objOraclecommand.Parameters.Add(tmp9);

                OracleParameter tmp10 = new OracleParameter("published", OracleType.VarChar);
                tmp10.Direction = ParameterDirection.Input;
                tmp10.Value = temp10;
                objOraclecommand.Parameters.Add(tmp10);

                OracleParameter tmp11 = new OracleParameter("pub_name", OracleType.VarChar);
                tmp11.Direction = ParameterDirection.Input;
                tmp11.Value = temp11;
                objOraclecommand.Parameters.Add(tmp11);

                objOraclecommand.Parameters.Add("p_recordsetmis", OracleType.Cursor);
                objOraclecommand.Parameters["p_recordsetmis"].Direction = ParameterDirection.Output;

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
            // spregionexcel


        }
        public DataSet spregionreport(string fromdate, string dateto, string compcode, string region, string dateformat, string descid, string ascdesc, string temp1, string temp2, string temp3, string temp4, string temp5, string temp6, string temp7, string temp8, string temp9, string temp10, string temp11)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("Misreportnew", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm4 = new OracleParameter("fromdate", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                if (fromdate == "")
                {
                    prm4.Value = System.DBNull.Value;
                }
                else
                {
                    prm4.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("dateto", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                if (dateto == "")
                {
                    prm5.Value = System.DBNull.Value;
                }
                else
                {
                    prm5.Value = Convert.ToDateTime(dateto).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("compcode", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = compcode;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("region", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                if (region == "0")
                {
                    prm7.Value = System.DBNull.Value;
                }
                else
                {
                    prm7.Value = region;
                }
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm10 = new OracleParameter("dateformat", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = dateformat;
                objOraclecommand.Parameters.Add(prm10);
                ;

                OracleParameter prm11 = new OracleParameter("descid", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = descid;
                objOraclecommand.Parameters.Add(prm11);



                OracleParameter prm12 = new OracleParameter("ascdesc", OracleType.VarChar);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = ascdesc;
                objOraclecommand.Parameters.Add(prm12);
                //=========================
                OracleParameter tmp1 = new OracleParameter("agname", OracleType.VarChar);
                tmp1.Direction = ParameterDirection.Input;
                tmp1.Value = temp1;
                objOraclecommand.Parameters.Add(tmp1);

                OracleParameter tmp2 = new OracleParameter("clientname", OracleType.VarChar);
                tmp2.Direction = ParameterDirection.Input;
                tmp2.Value = temp2;
                objOraclecommand.Parameters.Add(tmp2);

                OracleParameter tmp3 = new OracleParameter("adtype1", OracleType.VarChar);
                tmp3.Direction = ParameterDirection.Input;
                tmp3.Value = temp3;
                objOraclecommand.Parameters.Add(tmp3);

                OracleParameter tmp4 = new OracleParameter("adcategory", OracleType.VarChar);
                tmp4.Direction = ParameterDirection.Input;
                tmp4.Value = temp4;
                objOraclecommand.Parameters.Add(tmp4);

                OracleParameter tmp5 = new OracleParameter("pub_name", OracleType.VarChar);
                tmp5.Direction = ParameterDirection.Input;
                tmp5.Value = temp5;
                objOraclecommand.Parameters.Add(tmp5);

                OracleParameter tmp6 = new OracleParameter("pub_cent", OracleType.VarChar);
                tmp6.Direction = ParameterDirection.Input;
                tmp6.Value = temp6;
                objOraclecommand.Parameters.Add(tmp6);

                OracleParameter tmp7 = new OracleParameter("status", OracleType.VarChar);
                tmp7.Direction = ParameterDirection.Input;
                tmp7.Value = temp7;
                objOraclecommand.Parameters.Add(tmp7);

                OracleParameter tmp8 = new OracleParameter("edition", OracleType.VarChar);
                tmp8.Direction = ParameterDirection.Input;
                tmp8.Value = temp8;
                objOraclecommand.Parameters.Add(tmp8);

                OracleParameter tmp9 = new OracleParameter("hold", OracleType.VarChar);
                tmp9.Direction = ParameterDirection.Input;
                tmp9.Value = temp9;
                objOraclecommand.Parameters.Add(tmp9);

                OracleParameter tmp10 = new OracleParameter("published", OracleType.VarChar);
                tmp10.Direction = ParameterDirection.Input;
                tmp10.Value = temp10;
                objOraclecommand.Parameters.Add(tmp10);

                OracleParameter tmp11 = new OracleParameter("product", OracleType.VarChar);
                tmp11.Direction = ParameterDirection.Input;
                tmp11.Value = temp11;
                objOraclecommand.Parameters.Add(tmp11);

                //=================================

                objOraclecommand.Parameters.Add("p_recordsetmis", OracleType.Cursor);
                objOraclecommand.Parameters["p_recordsetmis"].Direction = ParameterDirection.Output;

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
            // spregionexcel

        }
        public DataSet spproductreport(string fromdate, string dateto, string compcode, string region, string dateformat, string product, string descid, string ascdesc, string temp1, string temp2, string temp3, string temp4, string temp5, string temp6, string temp7, string temp8, string temp9, string temp10)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {

                objOracleConnection.Open();

                objOraclecommand = GetCommand("Misreportnew", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;
                // objOraclecommand = GetCommand("MisReport.MisReport_p", ref objOracleConnection);
                //objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm4 = new OracleParameter("fromdate", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                if (dateformat == "dd/mm/yyyy" && fromdate != "" && fromdate != null)
                {
                    string[] arr = fromdate.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    fromdate = mm + "/" + dd + "/" + yy;
                }
                else
                {
                    prm4.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("dateto", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                if (dateformat == "dd/mm/yyyy" && dateto != "" && dateto != null)
                {

                    string[] arr = dateto.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    dateto = mm + "/" + dd + "/" + yy;
                }
                else
                {
                    prm5.Value = Convert.ToDateTime(dateto).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("compcode", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = compcode;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm8 = new OracleParameter("region", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                if (region == "--Select Region--")
                {
                    prm8.Value = System.DBNull.Value;
                }
                else
                {
                    prm8.Value = region;
                }
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm11 = new OracleParameter("product", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                if (product == "0")
                {
                    prm11.Value = System.DBNull.Value;
                }
                else
                {
                    prm11.Value = product;
                }
                objOraclecommand.Parameters.Add(prm11);


                OracleParameter prm14 = new OracleParameter("dateformat", OracleType.VarChar);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = dateformat;
                objOraclecommand.Parameters.Add(prm14);

                OracleParameter prm15 = new OracleParameter("descid", OracleType.VarChar);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = descid;
                objOraclecommand.Parameters.Add(prm15);

                OracleParameter prm16 = new OracleParameter("ascdesc", OracleType.VarChar);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = ascdesc;
                objOraclecommand.Parameters.Add(prm16);
                //=================================

                OracleParameter tmp1 = new OracleParameter("agname", OracleType.VarChar);
                tmp1.Direction = ParameterDirection.Input;
                tmp1.Value = temp1;
                objOraclecommand.Parameters.Add(tmp1);

                OracleParameter tmp2 = new OracleParameter("clientname", OracleType.VarChar);
                tmp2.Direction = ParameterDirection.Input;
                tmp2.Value = temp2;
                objOraclecommand.Parameters.Add(tmp2);

                OracleParameter tmp3 = new OracleParameter("adtype1", OracleType.VarChar);
                tmp3.Direction = ParameterDirection.Input;
                tmp3.Value = temp3;
                objOraclecommand.Parameters.Add(tmp3);

                OracleParameter tmp4 = new OracleParameter("adcategory", OracleType.VarChar);
                tmp4.Direction = ParameterDirection.Input;
                tmp4.Value = temp4;
                objOraclecommand.Parameters.Add(tmp4);

                OracleParameter tmp5 = new OracleParameter("pub_name", OracleType.VarChar);
                tmp5.Direction = ParameterDirection.Input;
                tmp5.Value = temp5;
                objOraclecommand.Parameters.Add(tmp5);

                OracleParameter tmp6 = new OracleParameter("pub_cent", OracleType.VarChar);
                tmp6.Direction = ParameterDirection.Input;
                tmp6.Value = temp6;
                objOraclecommand.Parameters.Add(tmp6);

                OracleParameter tmp7 = new OracleParameter("status", OracleType.VarChar);
                tmp7.Direction = ParameterDirection.Input;
                tmp7.Value = temp7;
                objOraclecommand.Parameters.Add(tmp7);

                OracleParameter tmp8 = new OracleParameter("edition", OracleType.VarChar);
                tmp8.Direction = ParameterDirection.Input;
                tmp8.Value = temp8;
                objOraclecommand.Parameters.Add(tmp8);

                OracleParameter tmp9 = new OracleParameter("hold", OracleType.VarChar);
                tmp9.Direction = ParameterDirection.Input;
                tmp9.Value = temp9;
                objOraclecommand.Parameters.Add(tmp9);

                OracleParameter tmp10 = new OracleParameter("published", OracleType.VarChar);
                tmp10.Direction = ParameterDirection.Input;
                tmp10.Value = temp10;
                objOraclecommand.Parameters.Add(tmp10);

                //=================================

                objOraclecommand.Parameters.Add("p_recordsetmis", OracleType.Cursor);
                objOraclecommand.Parameters["p_recordsetmis"].Direction = ParameterDirection.Output;


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
            // spregionexcel

        }
        public DataSet spcontractreportnew(string fromdate, string dateto, string compcode, string dateformat, string product, string agency1, string client1, string region1, string category, string pub_center, string useid, string chk_acc)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {

                objOracleConnection.Open();
                //objOraclecommand = GetCommand("MisReport.MisReport_p", ref objOracleConnection);
                //objOraclecommand.CommandType = CommandType.StoredProcedure;

                objOraclecommand = GetCommand("SHACHI_PICONTRACT_REPORT", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm15 = new OracleParameter("agname", OracleType.VarChar);
                prm15.Direction = ParameterDirection.Input;

                if (agency1 == "0" || agency1 == "")
                {
                    prm15.Value = System.DBNull.Value;
                }
                else
                {
                    prm15.Value = agency1;
                }

                objOraclecommand.Parameters.Add(prm15);

                OracleParameter prm4 = new OracleParameter("fromdate", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                if (fromdate == "")
                {
                    prm4.Value = System.DBNull.Value;
                }
                else
                {
                    prm4.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("dateto", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                if (dateto == "")
                {
                    prm5.Value = System.DBNull.Value;
                }
                else
                {
                    prm5.Value = Convert.ToDateTime(dateto).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("compcode", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = compcode;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("pub_cent", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                if (product == "0")
                {
                    prm7.Value = System.DBNull.Value;
                }
                else
                {
                    prm7.Value = product;
                }
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter tmp3 = new OracleParameter("category1", OracleType.VarChar);
                tmp3.Direction = ParameterDirection.Input;
                if (category == "0")
                {
                    tmp3.Value = System.DBNull.Value;
                }
                else
                {
                    tmp3.Value = category;
                }

                objOraclecommand.Parameters.Add(tmp3);


                OracleParameter prm14 = new OracleParameter("dateformat", OracleType.VarChar);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = dateformat;
                objOraclecommand.Parameters.Add(prm14);

                OracleParameter tmp5 = new OracleParameter("Region", OracleType.VarChar);
                tmp5.Direction = ParameterDirection.Input;
                if (region1 == "0")
                {
                    tmp5.Value = System.DBNull.Value;
                }
                else
                {
                    tmp5.Value = region1;
                }

                objOraclecommand.Parameters.Add(tmp5);




                OracleParameter prm16 = new OracleParameter("client", OracleType.VarChar);
                prm16.Direction = ParameterDirection.Input;
                if (client1 == "0" || client1 == "")
                {
                    prm16.Value = System.DBNull.Value;
                }
                else
                {
                    prm16.Value = client1;
                }


                objOraclecommand.Parameters.Add(prm16);


                OracleParameter top1 = new OracleParameter("puserid", OracleType.VarChar);
                top1.Direction = ParameterDirection.Input;
                top1.Value = useid;
                objOraclecommand.Parameters.Add(top1);

                OracleParameter top2 = new OracleParameter("chk_access", OracleType.VarChar);
                top2.Direction = ParameterDirection.Input;
                top2.Value = chk_acc;
                objOraclecommand.Parameters.Add(top2);

                OracleParameter pra2 = new OracleParameter("publication_center", OracleType.VarChar);
                pra2.Direction = ParameterDirection.Input;
                if (pub_center == "0")
                {
                    pra2.Value = System.DBNull.Value;
                }
                else
                {
                    pra2.Value = pub_center;
                }
                objOraclecommand.Parameters.Add(pra2);






                objOraclecommand.Parameters.Add("p_recordset1", OracleType.Cursor);
                objOraclecommand.Parameters["p_recordset1"].Direction = ParameterDirection.Output;

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




  public OracleDataReader spcontractreportnewexcel(string fromdate, string dateto, string compcode, string dateformat, string product, string agency1, string client1, string region1, string category)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {

                objOracleConnection.Open();
                //objOraclecommand = GetCommand("MisReport.MisReport_p", ref objOracleConnection);
                //objOraclecommand.CommandType = CommandType.StoredProcedure;

                objOraclecommand = GetCommand("SHACHI_PICONTRACT_REPORT", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm4 = new OracleParameter("fromdate", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                if (fromdate == "")
                {
                    prm4.Value = System.DBNull.Value;
                }
                else
                {
                    prm4.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("dateto", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                if (dateto == "")
                {
                    prm5.Value = System.DBNull.Value;
                }
                else
                {
                    prm5.Value = Convert.ToDateTime(dateto).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("compcode", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = compcode;
                objOraclecommand.Parameters.Add(prm6);


                OracleParameter prm7 = new OracleParameter("pub_cent", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                if (product == "0")
                {
                    prm7.Value = System.DBNull.Value;
                }
                else
                {
                    prm7.Value = product;
                }
                objOraclecommand.Parameters.Add(prm7);



                OracleParameter prm14 = new OracleParameter("dateformat", OracleType.VarChar);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = dateformat;
                objOraclecommand.Parameters.Add(prm14);

                OracleParameter prm15 = new OracleParameter("agname", OracleType.VarChar);
                prm15.Direction = ParameterDirection.Input;

                if (agency1 == "0")
                {
                    prm15.Value = System.DBNull.Value;
                }
                else
                {
                    prm15.Value = agency1;
                }

                objOraclecommand.Parameters.Add(prm15);

                OracleParameter prm16 = new OracleParameter("client", OracleType.VarChar);
                prm16.Direction = ParameterDirection.Input;
                if (client1 == "0")
                {
                    prm16.Value = System.DBNull.Value;
                }
                else
                {
                    prm16.Value = client1;
                }


                objOraclecommand.Parameters.Add(prm16);



                OracleParameter tmp3 = new OracleParameter("category1", OracleType.VarChar);
                tmp3.Direction = ParameterDirection.Input;
                if (category == "0")
                {
                    tmp3.Value = System.DBNull.Value;
                }
                else
                {
                    tmp3.Value = category;
                }

                objOraclecommand.Parameters.Add(tmp3);

                //OracleParameter tmp4 = new OracleParameter("adcategory", OracleType.VarChar);
                //tmp4.Direction = ParameterDirection.Input;
                //tmp4.Value = temp4;
                //objOraclecommand.Parameters.Add(tmp4);

                OracleParameter tmp5 = new OracleParameter("Region", OracleType.VarChar);
                tmp5.Direction = ParameterDirection.Input;
                if (region1 == "0")
                {
                    tmp5.Value = System.DBNull.Value;
                }
                else
                {
                    tmp5.Value = region1;
                }

                objOraclecommand.Parameters.Add(tmp5);

                //OracleParameter tmp6 = new OracleParameter("pub_cent", OracleType.VarChar);
                //tmp6.Direction = ParameterDirection.Input;
                //tmp6.Value = temp6;
                //objOraclecommand.Parameters.Add(tmp6);

                //OracleParameter tmp7 = new OracleParameter("status", OracleType.VarChar);
                //tmp7.Direction = ParameterDirection.Input;
                //tmp7.Value = temp7;
                //objOraclecommand.Parameters.Add(tmp7);

                //OracleParameter tmp8 = new OracleParameter("edition", OracleType.VarChar);
                //tmp8.Direction = ParameterDirection.Input;
                //tmp8.Value = temp8;
                //objOraclecommand.Parameters.Add(tmp8);

                //OracleParameter tmp9 = new OracleParameter("hold", OracleType.VarChar);
                //tmp9.Direction = ParameterDirection.Input;
                //tmp9.Value = temp9;
                //objOraclecommand.Parameters.Add(tmp9);

                //OracleParameter tmp10 = new OracleParameter("published", OracleType.VarChar);
                //tmp10.Direction = ParameterDirection.Input;
                //tmp10.Value = temp10;
                //objOraclecommand.Parameters.Add(tmp10);



                objOraclecommand.Parameters.Add("p_recordset1", OracleType.Cursor);
                objOraclecommand.Parameters["p_recordset1"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                OracleDataReader objdatareadre = objOraclecommand.ExecuteReader();

                return objdatareadre;


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










        public DataSet sppublication(string fromdate, string dateto, string pubname, string compcode, string dateformat, string published, string descid, string ascdesc, string temp1, string temp2, string temp3, string temp4, string temp5, string temp6, string temp7, string temp8, string temp9, string temp10)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("Misreportnew", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;



                OracleParameter prm4 = new OracleParameter("fromdate", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                if (fromdate == "0" || fromdate == "" || fromdate == null)
                {
                    prm4.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = fromdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        fromdate = mm + "/" + dd + "/" + yy;


                    }
                    prm4.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("dateto", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                if (dateto == "0" || dateto == "" || dateto == null)
                {
                    prm5.Value = System.DBNull.Value;
                }
                else
                {

                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = dateto.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        dateto = mm + "/" + dd + "/" + yy;


                    }
                    prm5.Value = Convert.ToDateTime(dateto).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("compcode", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = compcode;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("pub_name", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                if (pubname == "0")
                {
                    prm7.Value = System.DBNull.Value;
                }
                else
                {
                    prm7.Value = pubname;
                }
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm10 = new OracleParameter("dateformat", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = dateformat;
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("published", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                if (published == "0")
                {
                    prm11.Value = System.DBNull.Value;
                }
                else
                {
                    prm11.Value = published;
                }
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("descid", OracleType.VarChar);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = descid;
                objOraclecommand.Parameters.Add(prm12);

                OracleParameter prm13 = new OracleParameter("ascdesc", OracleType.VarChar);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = ascdesc;
                objOraclecommand.Parameters.Add(prm13);
                //=========================
                OracleParameter tmp1 = new OracleParameter("agname", OracleType.VarChar);
                tmp1.Direction = ParameterDirection.Input;
                tmp1.Value = temp1;
                objOraclecommand.Parameters.Add(tmp1);

                OracleParameter tmp2 = new OracleParameter("clientname", OracleType.VarChar);
                tmp2.Direction = ParameterDirection.Input;
                tmp2.Value = temp2;
                objOraclecommand.Parameters.Add(tmp2);

                OracleParameter tmp3 = new OracleParameter("adtype1", OracleType.VarChar);
                tmp3.Direction = ParameterDirection.Input;
                tmp3.Value = temp3;
                objOraclecommand.Parameters.Add(tmp3);

                OracleParameter tmp4 = new OracleParameter("adcategory", OracleType.VarChar);
                tmp4.Direction = ParameterDirection.Input;
                tmp4.Value = temp4;
                objOraclecommand.Parameters.Add(tmp4);

                OracleParameter tmp5 = new OracleParameter("Region", OracleType.VarChar);
                tmp5.Direction = ParameterDirection.Input;
                tmp5.Value = temp5;
                objOraclecommand.Parameters.Add(tmp5);

                OracleParameter tmp6 = new OracleParameter("pub_cent", OracleType.VarChar);
                tmp6.Direction = ParameterDirection.Input;
                tmp6.Value = temp6;
                objOraclecommand.Parameters.Add(tmp6);

                OracleParameter tmp7 = new OracleParameter("status", OracleType.VarChar);
                tmp7.Direction = ParameterDirection.Input;
                tmp7.Value = temp7;
                objOraclecommand.Parameters.Add(tmp7);

                OracleParameter tmp8 = new OracleParameter("edition", OracleType.VarChar);
                tmp8.Direction = ParameterDirection.Input;
                tmp8.Value = temp8;
                objOraclecommand.Parameters.Add(tmp8);

                OracleParameter tmp9 = new OracleParameter("hold", OracleType.VarChar);
                tmp9.Direction = ParameterDirection.Input;
                tmp9.Value = temp9;
                objOraclecommand.Parameters.Add(tmp9);

                OracleParameter tmp10 = new OracleParameter("product", OracleType.VarChar);
                tmp10.Direction = ParameterDirection.Input;
                tmp10.Value = temp10;
                objOraclecommand.Parameters.Add(tmp10);

                //=================================

                objOraclecommand.Parameters.Add("p_recordsetmis", OracleType.Cursor);
                objOraclecommand.Parameters["p_recordsetmis"].Direction = ParameterDirection.Output;


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
        public DataSet Extra_report(string frmdt, string todate, string compcode, string region, string product, string dateformate, string category, string descid, string ascdesc, string temp1, string temp2, string temp3, string temp4, string temp5)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("Bill_Reportnew11", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("fromdate", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                if (frmdt != "")
                {
                    prm1.Value = Convert.ToDateTime(frmdt).ToString("dd-MMMM-yyyy");
                }
                else
                {
                    prm1.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("dateto", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                if (todate != "")
                {
                    prm2.Value = Convert.ToDateTime(todate).ToString("dd-MMMM-yyyy");
                }
                else
                {
                    prm2.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("region", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                if ((region != "0") && (region != "--Select Region--"))
                {
                    prm3.Value = region;
                }
                else
                {
                    prm3.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm3);


                OracleParameter prm4 = new OracleParameter("product", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                if (product != "0")
                {
                    prm4.Value = product;
                }
                else
                {
                    prm4.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm4);


                OracleParameter prm5 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = compcode;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("dateformat", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = dateformate;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("category", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                if (category != "0")
                {
                    prm7.Value = category;
                }
                else
                {
                    prm7.Value = System.DBNull.Value;

                }
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("descid", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = descid;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("ascdesc", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = ascdesc;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter tmp = new OracleParameter("agname", OracleType.VarChar, 50);
                tmp.Direction = ParameterDirection.Input;
                tmp.Value = temp1;
                objOraclecommand.Parameters.Add(tmp);

                OracleParameter tmp2 = new OracleParameter("Adtype", OracleType.VarChar, 50);
                tmp2.Direction = ParameterDirection.Input;
                tmp2.Value = temp2;
                objOraclecommand.Parameters.Add(tmp2);


                OracleParameter tmp3 = new OracleParameter("pub_cent", OracleType.VarChar, 50);
                tmp3.Direction = ParameterDirection.Input;
                tmp3.Value = temp3;
                objOraclecommand.Parameters.Add(tmp3);



                OracleParameter tmp4 = new OracleParameter("agency", OracleType.VarChar, 50);
                tmp4.Direction = ParameterDirection.Input;
                tmp4.Value = temp4;
                objOraclecommand.Parameters.Add(tmp4);


                OracleParameter tmp5 = new OracleParameter("edition", OracleType.VarChar, 50);
                tmp5.Direction = ParameterDirection.Input;
                tmp5.Value = temp5;
                objOraclecommand.Parameters.Add(tmp5);



                //OracleParameter tmp6 = new OracleParameter("agency", OracleType.VarChar, 50);
                //tmp6.Direction = ParameterDirection.Input;
                //tmp6.Value = temp6;
                //objOraclecommand.Parameters.Add(tmp6);

                //OracleParameter tmp7 = new OracleParameter("descid", OracleType.VarChar, 50);
                //tmp7.Direction = ParameterDirection.Input;
                //tmp7.Value = temp7;
                //objOraclecommand.Parameters.Add(tmp7);



                //OracleParameter tmp8 = new OracleParameter("ascdesc", OracleType.VarChar, 50);
                //tmp8.Direction = ParameterDirection.Input;
                //tmp8.Value = temp8;
                //objOraclecommand.Parameters.Add(tmp8);

                objOraclecommand.Parameters.Add("p_recordset1", OracleType.Cursor);
                objOraclecommand.Parameters["p_recordset1"].Direction = ParameterDirection.Output;


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


        ////////////

        public DataSet barter_report(string frmdt, string todate, string compcode, string region, string product, string dateformate, string descid, string ascdesc, string adtype, string adcategory, string client)
        {



            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {



                objOracleConnection.Open();
                objOraclecommand = GetCommand("Bill_Reportnew11", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("fromdate", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                if (frmdt == "" || frmdt == null)
                {
                    prm1.Value = System.DBNull.Value;
                }

                else
                {
                    if (dateformate == "dd/mm/yyyy")
                    {
                        string[] arr = frmdt.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        frmdt = mm + "/" + dd + "/" + yy;


                    }

                    prm1.Value = Convert.ToDateTime(frmdt).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("dateto", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;


                if (todate == "" || todate == null)
                {
                    prm2.Value = System.DBNull.Value;
                    // prm2.Value =Convert.ToDateTime(todate).ToString("dd-MMMM-yyyy");
                }
                else
                {

                    if (dateformate == "dd/mm/yyyy")
                    {
                        string[] arr = todate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        todate = mm + "/" + dd + "/" + yy;


                    }
                    prm2.Value = Convert.ToDateTime(todate).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("region", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                if ((region != "0") && (region != "--Select Region--"))
                {
                    prm3.Value = region;
                }
                else
                {
                    prm3.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm3);


                OracleParameter prm4 = new OracleParameter("product", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                if (product != "0")
                {
                    prm4.Value = product;
                }
                else
                {
                    prm4.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm4);



                OracleParameter prm5 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = compcode;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("dateformat", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = dateformate;
                objOraclecommand.Parameters.Add(prm6);


                OracleParameter prm7 = new OracleParameter("descid", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = descid;
                objOraclecommand.Parameters.Add(prm7);



                OracleParameter prm8 = new OracleParameter("ascdesc", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = ascdesc;
                objOraclecommand.Parameters.Add(prm8);
                //temp_agname, string temp_adtype, string temp_pubcent, string temp_edition, string temp_agency, string temp_category



                OracleParameter tmp2 = new OracleParameter("client", OracleType.VarChar, 50);
                tmp2.Direction = ParameterDirection.Input;
                if (client == "0")
                {
                    tmp2.Value = System.DBNull.Value;
                }
                else
                {
                    tmp2.Value = client;

                }

                objOraclecommand.Parameters.Add(tmp2);




                OracleParameter tmp4 = new OracleParameter("newcategory", OracleType.VarChar, 50);
                tmp4.Direction = ParameterDirection.Input;
                if (adcategory == "0" || adcategory == "")
                {
                    tmp4.Value = System.DBNull.Value;
                }
                else
                {
                    tmp4.Value = adcategory;
                }
                objOraclecommand.Parameters.Add(tmp4);





                OracleParameter tmp6 = new OracleParameter("newadtype", OracleType.VarChar, 50);
                tmp6.Direction = ParameterDirection.Input;
                if (adtype == "0")
                {

                    tmp6.Value = System.DBNull.Value;
                }
                else
                {
                    tmp6.Value = adtype;
                }
                objOraclecommand.Parameters.Add(tmp6);

                objOraclecommand.Parameters.Add("p_recordset1", OracleType.Cursor);
                objOraclecommand.Parameters["p_recordset1"].Direction = ParameterDirection.Output;


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



        public DataSet value_pub(string frmdt, string todate, string compcode, string product, string dateformate, string descid, string ascdesc, string temp_agname, string temp_adtype, string temp_pubcent, string temp_category, string temp_edition, string temp_agency, string temp_region)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("Bill_Reportnew11", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("fromdate", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                if (frmdt != "")
                {
                    prm1.Value = Convert.ToDateTime(frmdt).ToString("dd-MMMM-yyyy");
                }
                else
                {
                    prm1.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("dateto", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                if (todate != "")
                {
                    prm2.Value = Convert.ToDateTime(todate).ToString("dd-MMMM-yyyy");
                }
                else
                {
                    prm2.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("product", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                if (product != "0")
                {
                    prm3.Value = product;
                }
                else
                {
                    prm3.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm3);


                OracleParameter prm4 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = compcode;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("dateformat", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = dateformate;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("descid", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = descid;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("ascdesc", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = ascdesc;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter tmp1 = new OracleParameter("agname", OracleType.VarChar, 50);
                tmp1.Direction = ParameterDirection.Input;
                tmp1.Value = temp_agname;
                objOraclecommand.Parameters.Add(tmp1);

                OracleParameter tmp2 = new OracleParameter("Adtype", OracleType.VarChar, 50);
                tmp2.Direction = ParameterDirection.Input;
                tmp2.Value = temp_adtype;
                objOraclecommand.Parameters.Add(tmp2);

                OracleParameter tmp3 = new OracleParameter("pub_cent", OracleType.VarChar, 50);
                tmp3.Direction = ParameterDirection.Input;
                tmp3.Value = temp_pubcent;
                objOraclecommand.Parameters.Add(tmp3);
                //string temp_agname, string temp_adtype, string temp_pubcent,string temp_category, string temp_edition, string temp_agency
                OracleParameter tmp4 = new OracleParameter("category", OracleType.VarChar, 50);
                tmp4.Direction = ParameterDirection.Input;
                tmp4.Value = temp_category;
                objOraclecommand.Parameters.Add(tmp4);

                OracleParameter tmp5 = new OracleParameter("edition", OracleType.VarChar, 50);
                tmp5.Direction = ParameterDirection.Input;
                tmp5.Value = temp_edition;
                objOraclecommand.Parameters.Add(tmp5);

                OracleParameter prm61 = new OracleParameter("region", OracleType.VarChar, 50);
                prm61.Direction = ParameterDirection.Input;
                if ((temp_region != "0") && (temp_region != "--Select Region--"))
                {
                    prm61.Value = temp_region;
                }
                else
                {
                    prm61.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm61);

                OracleParameter tmp7 = new OracleParameter("agency", OracleType.VarChar, 50);
                tmp7.Direction = ParameterDirection.Input;
                tmp7.Value = temp_agency;
                objOraclecommand.Parameters.Add(tmp7);

                objOraclecommand.Parameters.Add("p_recordset1", OracleType.Cursor);
                objOraclecommand.Parameters["p_recordset1"].Direction = ParameterDirection.Output;

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



        public DataSet valuereportregion(string frmdt, string todate, string compcode, string region, string product, string dateformate, string descid, string ascdesc, string temp_agname, string temp_adtype, string temp_pubcent, string temp_prod, string temp_edition, string temp_agency)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            //DataSet objDataSet = new DataSet();
            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("Bill_Reportnew11", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("fromdate", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                if (frmdt != "")
                {
                    prm1.Value = Convert.ToDateTime(frmdt).ToString("dd-MMMM-yyyy");
                }
                else
                {
                    prm1.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("dateto", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                if (todate != "")
                {
                    prm2.Value = Convert.ToDateTime(todate).ToString("dd-MMMM-yyyy");
                }
                else
                {
                    prm2.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("region", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                if ((region != "0") && (region != "--Select Region--"))
                {
                    prm3.Value = region;
                }
                else
                {
                    prm3.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm3);


                OracleParameter prm4 = new OracleParameter("product", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                if (product != "0")
                {
                    prm4.Value = product;
                }
                else
                {
                    prm4.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm4);


                OracleParameter prm5 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = compcode;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("dateformat", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = dateformate;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("descid", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = descid;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("ascdesc", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = ascdesc;
                objOraclecommand.Parameters.Add(prm8);


                OracleParameter temp = new OracleParameter("agname", OracleType.VarChar, 50);
                temp.Direction = ParameterDirection.Input;
                temp.Value = temp_agname;
                objOraclecommand.Parameters.Add(temp);

                OracleParameter temp1 = new OracleParameter("Adtype", OracleType.VarChar, 50);
                temp1.Direction = ParameterDirection.Input;
                temp1.Value = temp_adtype;
                objOraclecommand.Parameters.Add(temp1);


                OracleParameter temp2 = new OracleParameter("pub_cent", OracleType.VarChar, 50);
                temp2.Direction = ParameterDirection.Input;
                temp2.Value = temp_pubcent;
                objOraclecommand.Parameters.Add(temp2);

                OracleParameter temp3 = new OracleParameter("edition", OracleType.VarChar, 50);
                temp3.Direction = ParameterDirection.Input;
                temp3.Value = temp_edition;
                objOraclecommand.Parameters.Add(temp3);

                OracleParameter temp4 = new OracleParameter("category", OracleType.VarChar, 50);
                temp4.Direction = ParameterDirection.Input;
                temp4.Value = temp_prod;
                objOraclecommand.Parameters.Add(temp4);

                OracleParameter temp5 = new OracleParameter("agency", OracleType.VarChar, 50);
                temp5.Direction = ParameterDirection.Input;
                temp5.Value = temp_agency;
                objOraclecommand.Parameters.Add(temp5);


                objOraclecommand.Parameters.Add("p_recordset1", OracleType.Cursor);
                objOraclecommand.Parameters["p_recordset1"].Direction = ParameterDirection.Output;
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




        public DataSet regionrebate(string frmdt, string todate, string compcode, string region, string product, string category, string dateformate, string descid, string ascdesc, string temp1, string temp2, string temp3, string temp4, string temp5)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("Bill_Reportnew11", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("fromdate", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                if (frmdt != "")
                {
                    prm1.Value = Convert.ToDateTime(frmdt).ToString("dd-MMMM-yyyy");
                }
                else
                {
                    prm1.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("dateto", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                if (todate != "")
                {
                    prm2.Value = Convert.ToDateTime(todate).ToString("dd-MMMM-yyyy");
                }
                else
                {
                    prm2.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("region", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                if ((region != "0") && (region != "--Select Region--"))
                {
                    prm3.Value = region;
                }
                else
                {
                    prm3.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm3);


                OracleParameter prm4 = new OracleParameter("product", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                if (product != "0")
                {
                    prm4.Value = product;
                }
                else
                {
                    prm4.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("category", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                if (category != "0")
                {
                    prm5.Value = category;
                }
                else
                {
                    prm5.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = compcode;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("dateformat", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = dateformate;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("descid", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = descid;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("ascdesc", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = ascdesc;
                objOraclecommand.Parameters.Add(prm9);


                OracleParameter tmp = new OracleParameter("agname", OracleType.VarChar, 50);
                tmp.Direction = ParameterDirection.Input;
                tmp.Value = temp1;
                objOraclecommand.Parameters.Add(tmp);

                OracleParameter tmp2 = new OracleParameter("Adtype", OracleType.VarChar, 50);
                tmp2.Direction = ParameterDirection.Input;
                tmp2.Value = temp2;
                objOraclecommand.Parameters.Add(tmp2);


                OracleParameter tmp3 = new OracleParameter("pub_cent", OracleType.VarChar, 50);
                tmp3.Direction = ParameterDirection.Input;
                tmp3.Value = temp3;
                objOraclecommand.Parameters.Add(tmp3);



                OracleParameter tmp4 = new OracleParameter("agency", OracleType.VarChar, 50);
                tmp4.Direction = ParameterDirection.Input;
                tmp4.Value = temp4;
                objOraclecommand.Parameters.Add(tmp4);


                OracleParameter tmp5 = new OracleParameter("edition", OracleType.VarChar, 50);
                tmp5.Direction = ParameterDirection.Input;
                tmp5.Value = temp5;
                objOraclecommand.Parameters.Add(tmp5);



                //OracleParameter tmp6 = new OracleParameter("agency", OracleType.VarChar, 50);
                //tmp6.Direction = ParameterDirection.Input;
                //tmp6.Value = temp6;
                //objOraclecommand.Parameters.Add(tmp6);

                //OracleParameter tmp7 = new OracleParameter("descid", OracleType.VarChar, 50);
                //tmp7.Direction = ParameterDirection.Input;
                //tmp7.Value = temp7;
                //objOraclecommand.Parameters.Add(tmp7);



                //OracleParameter tmp8 = new OracleParameter("ascdesc", OracleType.VarChar, 50);
                //tmp8.Direction = ParameterDirection.Input;
                //tmp8.Value = temp8;
                //objOraclecommand.Parameters.Add(tmp8);

                objOraclecommand.Parameters.Add("p_recordset1", OracleType.Cursor);
                objOraclecommand.Parameters["p_recordset1"].Direction = ParameterDirection.Output;



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
        public DataSet pubrebate(string frmdt, string todate, string compcode, string category, string product, string dateformate, string descid, string ascdesc, string temp1, string temp2, string temp3, string temp4, string temp5, string temp6)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("Bill_Reportnew11", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("fromdate", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                if (frmdt != "")
                {
                    prm1.Value = Convert.ToDateTime(frmdt).ToString("dd-MMMM-yyyy");
                }
                else
                {
                    prm1.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("dateto", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                if (todate != "")
                {
                    prm2.Value = Convert.ToDateTime(todate).ToString("dd-MMMM-yyyy");
                }
                else
                {
                    prm2.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("category", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                if (category != "0")
                {
                    prm3.Value = category;
                }
                else
                {
                    prm3.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("product", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                if (product != "0")
                {
                    prm4.Value = product;
                }
                else
                {
                    prm4.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm4);



                OracleParameter prm5 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = compcode;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("dateformat", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = dateformate;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("descid", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = descid;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("ascdesc", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = ascdesc;
                objOraclecommand.Parameters.Add(prm8);


                OracleParameter tmp = new OracleParameter("agname", OracleType.VarChar, 50);
                tmp.Direction = ParameterDirection.Input;
                tmp.Value = temp1;
                objOraclecommand.Parameters.Add(tmp);

                OracleParameter tmp2 = new OracleParameter("Adtype", OracleType.VarChar, 50);
                tmp2.Direction = ParameterDirection.Input;
                tmp2.Value = temp2;
                objOraclecommand.Parameters.Add(tmp2);


                OracleParameter tmp3 = new OracleParameter("pub_cent", OracleType.VarChar, 50);
                tmp3.Direction = ParameterDirection.Input;
                tmp3.Value = temp3;
                objOraclecommand.Parameters.Add(tmp3);



                //OracleParameter prm11 = new OracleParameter("region", OracleType.VarChar, 50);
                //prm11.Direction = ParameterDirection.Input;
                //if ((temp_region != "0") && (temp_region != "--Select Region--"))
                //{
                //    prm11.Value = temp_region;
                //}
                //else
                //{
                //    prm11.Value = System.DBNull.Value;
                //}
                //objOraclecommand.Parameters.Add(prm11);


                OracleParameter tmp5 = new OracleParameter("edition", OracleType.VarChar, 50);
                tmp5.Direction = ParameterDirection.Input;
                tmp5.Value = temp5;
                objOraclecommand.Parameters.Add(tmp5);



                OracleParameter tmp6 = new OracleParameter("agency", OracleType.VarChar, 50);
                tmp6.Direction = ParameterDirection.Input;
                tmp6.Value = temp6;
                objOraclecommand.Parameters.Add(tmp6);



                objOraclecommand.Parameters.Add("p_recordset1", OracleType.Cursor);
                objOraclecommand.Parameters["p_recordset1"].Direction = ParameterDirection.Output;



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
        public DataSet retainonscreen(string fromdate, string dateto, string region, string product, string compcode, string dateformat, string descid, string ascdesc, string temp1, string temp2, string temp3, string temp4, string temp5, string temp6, string branch, string edition, string retainer, string addtype,string publi_center, string useid, string chk_acc)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("SACHI_Bill_Reportnew333111", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter top1 = new OracleParameter("puserid", OracleType.VarChar);
                top1.Direction = ParameterDirection.Input;
                top1.Value = useid;
                objOraclecommand.Parameters.Add(top1);

                OracleParameter top2 = new OracleParameter("chk_access", OracleType.VarChar);
                top2.Direction = ParameterDirection.Input;
                top2.Value = chk_acc;
                objOraclecommand.Parameters.Add(top2);
                OracleParameter pa1 = new OracleParameter("publication_center", OracleType.VarChar, 50);
                pa1.Direction = ParameterDirection.Input;
                if (publi_center == "0")
                {
                    pa1.Value = System.DBNull.Value;
                    
                }
                else
                {
                    pa1.Value = publi_center;
                }
                objOraclecommand.Parameters.Add(pa1);

                OracleParameter prm1 = new OracleParameter("region", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                if ((region != "0") && (region != "--Select Region--"))
                {
                    prm1.Value = region;
                }
                else
                {
                    prm1.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("pub_cent", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                if (product != "0")
                {
                    prm2.Value = product;
                }
                else
                {
                    prm2.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm2);


                //OracleParameter prm3 = new OracleParameter("fromdate", OracleType.VarChar, 50);
                //prm3.Direction = ParameterDirection.Input;
                //if (fromdate != "0")
                //{


                //    prm3.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");
                //}
                //else
                //{
                //    prm3.Value = System.DBNull.Value;
                //}
                //objOraclecommand.Parameters.Add(prm3);

                //OracleParameter prm4 = new OracleParameter("dateto", OracleType.VarChar, 50);
                //prm4.Direction = ParameterDirection.Input;
                //if (dateto != "0")
                //{
                //    prm4.Value = Convert.ToDateTime(dateto).ToString("dd-MMMM-yyyy");
                //}
                //else
                //{
                //    prm4.Value = System.DBNull.Value;
                //}
                //objOraclecommand.Parameters.Add(prm4);


                OracleParameter prm3 = new OracleParameter("fromdate", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                if (fromdate == "" || fromdate == null)
                {
                    prm3.Value = System.DBNull.Value;
                }
                else
                {


                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = fromdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        fromdate = mm + "/" + dd + "/" + yy;


                    }
                    prm3.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");

                }
                objOraclecommand.Parameters.Add(prm3);


                OracleParameter prm4 = new OracleParameter("dateto", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                if (dateto == "" || dateto == null)
                {
                    prm4.Value = System.DBNull.Value;
                }
                else
                {


                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = dateto.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        dateto = mm + "/" + dd + "/" + yy;


                    }
                    prm4.Value = Convert.ToDateTime(dateto).ToString("dd-MMMM-yyyy");

                }
                objOraclecommand.Parameters.Add(prm4);





                OracleParameter prm5 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = compcode;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("dateformat", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = dateformat;
                objOraclecommand.Parameters.Add(prm6);


                OracleParameter prm7 = new OracleParameter("descid", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = descid;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("ascdesc", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = ascdesc;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter tmp = new OracleParameter("agname", OracleType.VarChar, 50);
                tmp.Direction = ParameterDirection.Input;
                tmp.Value = temp1;
                objOraclecommand.Parameters.Add(tmp);

                //OracleParameter prm2 = new OracleParameter("pub_cent", OracleType.VarChar, 50);
                //prm2.Direction = ParameterDirection.Input;
                //if (product != "0")
                //{
                //    prm2.Value = product;
                //}
                //else
                //{
                //    prm2.Value = System.DBNull.Value;
                //}
                //objOraclecommand.Parameters.Add(prm2);

                OracleParameter tmp2 = new OracleParameter("Adtype", OracleType.VarChar, 50);
                tmp2.Direction = ParameterDirection.Input;
                if (addtype != "0")
                {
                    tmp2.Value = addtype;
                }
                else
                {
                    tmp2.Value = System.DBNull.Value;
                }
                
                objOraclecommand.Parameters.Add(tmp2);


                //OracleParameter tmp3 = new OracleParameter("pub_cent", OracleType.VarChar, 50);
                //tmp3.Direction = ParameterDirection.Input;
                //tmp3.Value = temp3;
                //objOraclecommand.Parameters.Add(tmp3);



                OracleParameter tmp4 = new OracleParameter("category", OracleType.VarChar, 50);
                tmp4.Direction = ParameterDirection.Input;

                tmp4.Value = temp4;
                objOraclecommand.Parameters.Add(tmp4);


                OracleParameter tmp5 = new OracleParameter("edition", OracleType.VarChar, 50);
                tmp5.Direction = ParameterDirection.Input;
                if ((edition == "0") || (edition == "") || (edition == "--Select Edition Name--"))
                {
                    tmp5.Value = System.DBNull.Value;
                   
                }
                else
                {
                    tmp5.Value = edition;
                }
               
                objOraclecommand.Parameters.Add(tmp5);



                OracleParameter tmp6 = new OracleParameter("agency", OracleType.VarChar, 50);
                tmp6.Direction = ParameterDirection.Input;
                tmp6.Value = temp6;
                objOraclecommand.Parameters.Add(tmp6);

                OracleParameter tmp61 = new OracleParameter("Retainer", OracleType.VarChar, 50);
                tmp61.Direction = ParameterDirection.Input;
                if (retainer != "0" || retainer!="")
                {
                    tmp61.Value = retainer;
                }
                else
                {
                    tmp61.Value = System.DBNull.Value;
                }
                
                objOraclecommand.Parameters.Add(tmp61);


                OracleParameter tmp62 = new OracleParameter("Branch", OracleType.VarChar, 50);
                tmp62.Direction = ParameterDirection.Input;
                if ((branch != "0")&& (branch != "--Select Branch--"))
                {
                    tmp62.Value = branch;
                }
                else
                {
                   tmp62.Value = System.DBNull.Value;
                }
              //  tmp62.Value = branch;
                objOraclecommand.Parameters.Add(tmp62);

               

                objOraclecommand.Parameters.Add("p_recordset1", OracleType.Cursor);
                objOraclecommand.Parameters["p_recordset1"].Direction = ParameterDirection.Output;


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


        public DataSet retainonexcel11(string fromdate, string dateto, string region, string product, string compcode, string dateformat, string descid, string ascdesc, string temp1, string temp2, string temp3, string temp4, string temp5, string temp6, string branch, string edition, string retainer, string addtype)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("SACHI_Bill_Reportnew333111", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("region", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                if ((region != "0") && (region != "--Select Region--"))
                {
                    prm1.Value = region;
                }
                else
                {
                    prm1.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("pub_cent", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                if (product != "0")
                {
                    prm2.Value = product;
                }
                else
                {
                    prm2.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm2);


                //OracleParameter prm3 = new OracleParameter("fromdate", OracleType.VarChar, 50);
                //prm3.Direction = ParameterDirection.Input;
                //if (fromdate != "0")
                //{


                //    prm3.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");
                //}
                //else
                //{
                //    prm3.Value = System.DBNull.Value;
                //}
                //objOraclecommand.Parameters.Add(prm3);

                //OracleParameter prm4 = new OracleParameter("dateto", OracleType.VarChar, 50);
                //prm4.Direction = ParameterDirection.Input;
                //if (dateto != "0")
                //{
                //    prm4.Value = Convert.ToDateTime(dateto).ToString("dd-MMMM-yyyy");
                //}
                //else
                //{
                //    prm4.Value = System.DBNull.Value;
                //}
                //objOraclecommand.Parameters.Add(prm4);


                OracleParameter prm3 = new OracleParameter("fromdate", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                if (fromdate == "" || fromdate == null)
                {
                    prm3.Value = System.DBNull.Value;
                }
                else
                {


                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = fromdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        fromdate = mm + "/" + dd + "/" + yy;


                    }
                    prm3.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");

                }
                objOraclecommand.Parameters.Add(prm3);


                OracleParameter prm4 = new OracleParameter("dateto", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                if (dateto == "" || dateto == null)
                {
                    prm4.Value = System.DBNull.Value;
                }
                else
                {


                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = dateto.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        dateto = mm + "/" + dd + "/" + yy;


                    }
                    prm4.Value = Convert.ToDateTime(dateto).ToString("dd-MMMM-yyyy");

                }
                objOraclecommand.Parameters.Add(prm4);





                OracleParameter prm5 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = compcode;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("dateformat", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = dateformat;
                objOraclecommand.Parameters.Add(prm6);


                OracleParameter prm7 = new OracleParameter("descid", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = descid;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("ascdesc", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = ascdesc;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter tmp = new OracleParameter("agname", OracleType.VarChar, 50);
                tmp.Direction = ParameterDirection.Input;
                tmp.Value = temp1;
                objOraclecommand.Parameters.Add(tmp);

                //OracleParameter prm2 = new OracleParameter("pub_cent", OracleType.VarChar, 50);
                //prm2.Direction = ParameterDirection.Input;
                //if (product != "0")
                //{
                //    prm2.Value = product;
                //}
                //else
                //{
                //    prm2.Value = System.DBNull.Value;
                //}
                //objOraclecommand.Parameters.Add(prm2);

                OracleParameter tmp2 = new OracleParameter("Adtype", OracleType.VarChar, 50);
                tmp2.Direction = ParameterDirection.Input;
                if (addtype != "0")
                {
                    tmp2.Value = addtype;
                }
                else
                {
                    tmp2.Value = System.DBNull.Value;
                }

                objOraclecommand.Parameters.Add(tmp2);


                //OracleParameter tmp3 = new OracleParameter("pub_cent", OracleType.VarChar, 50);
                //tmp3.Direction = ParameterDirection.Input;
                //tmp3.Value = temp3;
                //objOraclecommand.Parameters.Add(tmp3);



                OracleParameter tmp4 = new OracleParameter("category", OracleType.VarChar, 50);
                tmp4.Direction = ParameterDirection.Input;

                tmp4.Value = temp4;
                objOraclecommand.Parameters.Add(tmp4);


                OracleParameter tmp5 = new OracleParameter("edition", OracleType.VarChar, 50);
                tmp5.Direction = ParameterDirection.Input;
                if ((edition != "0") && (edition != ""))
                {
                    tmp5.Value = edition;
                }
                else
                {
                    tmp5.Value = System.DBNull.Value;
                }

                objOraclecommand.Parameters.Add(tmp5);



                OracleParameter tmp6 = new OracleParameter("agency", OracleType.VarChar, 50);
                tmp6.Direction = ParameterDirection.Input;
                tmp6.Value = temp6;
                objOraclecommand.Parameters.Add(tmp6);

                OracleParameter tmp61 = new OracleParameter("Retainer", OracleType.VarChar, 50);
                tmp61.Direction = ParameterDirection.Input;
                if (retainer != "0")
                {
                    tmp61.Value = retainer;
                }
                else
                {
                    tmp61.Value = System.DBNull.Value;
                }

                objOraclecommand.Parameters.Add(tmp61);


                OracleParameter tmp62 = new OracleParameter("Branch", OracleType.VarChar, 50);
                tmp62.Direction = ParameterDirection.Input;
                if ((branch != "0") && (branch != "--Select Branch--"))
                {
                    tmp62.Value = branch;
                }
                else
                {
                    tmp62.Value = System.DBNull.Value;
                }
                //  tmp62.Value = branch;
                objOraclecommand.Parameters.Add(tmp62);



                objOraclecommand.Parameters.Add("p_recordset1", OracleType.Cursor);
                objOraclecommand.Parameters["p_recordset1"].Direction = ParameterDirection.Output;


                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;

                //objorclDataAdapter.SelectCommand = objOraclecommand;
                //OracleDataReader objdatareadre = objOraclecommand.ExecuteReader();

                //return objdatareadre;

                //objorclDataAdapter.SelectCommand = objOraclecommand;
                //objorclDataAdapter.Fill(OracleDataReader);

                //return OracleDataReader;



            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                // CloseConnection(ref objOracleConnection);
            }

        }


        public OracleDataReader retainonexcel(string fromdate, string dateto, string region, string product, string compcode, string dateformat, string descid, string ascdesc, string temp1, string temp2, string temp3, string temp4, string temp5, string temp6, string branch, string edition, string retainer, string addtype)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("Bill_Reportnewexcel", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("region", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                if ((region != "0") && (region != "--Select Region--"))
                {
                    prm1.Value = region;
                }
                else
                {
                    prm1.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("pub_cent", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                if (product != "0")
                {
                    prm2.Value = product;
                }
                else
                {
                    prm2.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm2);


                //OracleParameter prm3 = new OracleParameter("fromdate", OracleType.VarChar, 50);
                //prm3.Direction = ParameterDirection.Input;
                //if (fromdate != "0")
                //{


                //    prm3.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");
                //}
                //else
                //{
                //    prm3.Value = System.DBNull.Value;
                //}
                //objOraclecommand.Parameters.Add(prm3);

                //OracleParameter prm4 = new OracleParameter("dateto", OracleType.VarChar, 50);
                //prm4.Direction = ParameterDirection.Input;
                //if (dateto != "0")
                //{
                //    prm4.Value = Convert.ToDateTime(dateto).ToString("dd-MMMM-yyyy");
                //}
                //else
                //{
                //    prm4.Value = System.DBNull.Value;
                //}
                //objOraclecommand.Parameters.Add(prm4);


                OracleParameter prm3 = new OracleParameter("fromdate", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                if (fromdate == "" || fromdate == null)
                {
                    prm3.Value = System.DBNull.Value;
                }
                else
                {


                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = fromdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        fromdate = mm + "/" + dd + "/" + yy;


                    }
                    prm3.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");

                }
                objOraclecommand.Parameters.Add(prm3);


                OracleParameter prm4 = new OracleParameter("dateto", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                if (dateto == "" || dateto == null)
                {
                    prm4.Value = System.DBNull.Value;
                }
                else
                {


                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = dateto.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        dateto = mm + "/" + dd + "/" + yy;


                    }
                    prm4.Value = Convert.ToDateTime(dateto).ToString("dd-MMMM-yyyy");

                }
                objOraclecommand.Parameters.Add(prm4);





                OracleParameter prm5 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = compcode;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("dateformat", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = dateformat;
                objOraclecommand.Parameters.Add(prm6);


                OracleParameter prm7 = new OracleParameter("descid", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = descid;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("ascdesc", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = ascdesc;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter tmp = new OracleParameter("agname", OracleType.VarChar, 50);
                tmp.Direction = ParameterDirection.Input;
                tmp.Value = temp1;
                objOraclecommand.Parameters.Add(tmp);

                //OracleParameter prm2 = new OracleParameter("pub_cent", OracleType.VarChar, 50);
                //prm2.Direction = ParameterDirection.Input;
                //if (product != "0")
                //{
                //    prm2.Value = product;
                //}
                //else
                //{
                //    prm2.Value = System.DBNull.Value;
                //}
                //objOraclecommand.Parameters.Add(prm2);

                OracleParameter tmp2 = new OracleParameter("Adtype", OracleType.VarChar, 50);
                tmp2.Direction = ParameterDirection.Input;
                if (addtype != "0")
                {
                    tmp2.Value = addtype;
                }
                else
                {
                    tmp2.Value = System.DBNull.Value;
                }

                objOraclecommand.Parameters.Add(tmp2);


                //OracleParameter tmp3 = new OracleParameter("pub_cent", OracleType.VarChar, 50);
                //tmp3.Direction = ParameterDirection.Input;
                //tmp3.Value = temp3;
                //objOraclecommand.Parameters.Add(tmp3);



                OracleParameter tmp4 = new OracleParameter("category", OracleType.VarChar, 50);
                tmp4.Direction = ParameterDirection.Input;

                tmp4.Value = temp4;
                objOraclecommand.Parameters.Add(tmp4);


                OracleParameter tmp5 = new OracleParameter("edition", OracleType.VarChar, 50);
                tmp5.Direction = ParameterDirection.Input;
                if ((edition != "0") && (edition != ""))
                {
                    tmp5.Value = edition;
                }
                else
                {
                    tmp5.Value = System.DBNull.Value;
                }

                objOraclecommand.Parameters.Add(tmp5);



                OracleParameter tmp6 = new OracleParameter("agency", OracleType.VarChar, 50);
                tmp6.Direction = ParameterDirection.Input;
                tmp6.Value = temp6;
                objOraclecommand.Parameters.Add(tmp6);

                OracleParameter tmp61 = new OracleParameter("Retainer", OracleType.VarChar, 50);
                tmp61.Direction = ParameterDirection.Input;
                if (retainer != "0")
                {
                    tmp61.Value = retainer;
                }
                else
                {
                    tmp61.Value = System.DBNull.Value;
                }

                objOraclecommand.Parameters.Add(tmp61);


                OracleParameter tmp62 = new OracleParameter("Branch", OracleType.VarChar, 50);
                tmp62.Direction = ParameterDirection.Input;
                if ((branch != "0") && (branch != "--Select Branch--"))
                {
                    tmp62.Value = branch;
                }
                else
                {
                    tmp62.Value = System.DBNull.Value;
                }
                //  tmp62.Value = branch;
                objOraclecommand.Parameters.Add(tmp62);



                objOraclecommand.Parameters.Add("p_recordset1", OracleType.Cursor);
                objOraclecommand.Parameters["p_recordset1"].Direction = ParameterDirection.Output;


                objorclDataAdapter.SelectCommand = objOraclecommand;
                OracleDataReader objdatareadre = objOraclecommand.ExecuteReader();

                return objdatareadre;

                //objorclDataAdapter.SelectCommand = objOraclecommand;
                //objorclDataAdapter.Fill(OracleDataReader);

                //return OracleDataReader;



            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
               // CloseConnection(ref objOracleConnection);
            }

        }


        public DataSet billingonscreen(string fromdate, string dateto, string region, string product, string category, string compcode, string dateformat, string descid, string ascdesc, string temp_agname, string temp_adtype, string temp_pubcent, string temp_edition, string temp_agency, string executive)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("Bill_Reportnew11", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("region", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                if ((region != "0") && (region != "--Select Region--"))
                {
                    prm1.Value = region;
                }
                else
                {
                    prm1.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("product", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                if (product != "0")
                {
                    prm2.Value = product;
                }
                else
                {
                    prm2.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("category", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                if (category != "0")
                {
                    prm3.Value = category;
                }
                else
                {
                    prm3.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm3);


                OracleParameter prm9 = new OracleParameter("fromdate", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                if (fromdate != "0")
                {
                    prm9.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");
                }
                else
                {
                    prm9.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm4 = new OracleParameter("dateto", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                if (dateto != "0")
                {
                    prm4.Value = Convert.ToDateTime(dateto).ToString("dd-MMMM-yyyy");
                }
                else
                {
                    prm4.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm4);



                OracleParameter prm5 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = compcode;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("dateformat", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = dateformat;
                objOraclecommand.Parameters.Add(prm6);


                OracleParameter prm7 = new OracleParameter("descid", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = descid;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("ascdesc", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = ascdesc;
                objOraclecommand.Parameters.Add(prm8);


                OracleParameter temp = new OracleParameter("agname", OracleType.VarChar, 50);
                temp.Direction = ParameterDirection.Input;
                temp.Value = temp_agname;
                objOraclecommand.Parameters.Add(temp);
                //string temp_agname=null, temp_adtype=null, temp_pubcent=null, temp_edition=null, temp_prod=null, temp_agency
                OracleParameter temp1 = new OracleParameter("Adtype", OracleType.VarChar, 50);
                temp1.Direction = ParameterDirection.Input;
                temp1.Value = temp_adtype;
                objOraclecommand.Parameters.Add(temp1);


                OracleParameter temp2 = new OracleParameter("pub_cent", OracleType.VarChar, 50);
                temp2.Direction = ParameterDirection.Input;
                temp2.Value = temp_pubcent;
                objOraclecommand.Parameters.Add(temp2);

                OracleParameter temp3 = new OracleParameter("edition", OracleType.VarChar, 50);
                temp3.Direction = ParameterDirection.Input;
                temp3.Value = temp_edition;
                objOraclecommand.Parameters.Add(temp3);

                //OracleParameter temp4 = new OracleParameter("temp_prod", OracleType.VarChar, 50);
                //temp4.Direction = ParameterDirection.Input;
                //temp4.Value = temp_prod;
                //objOraclecommand.Parameters.Add(temp4);

                OracleParameter temp5 = new OracleParameter("agency", OracleType.VarChar, 50);
                temp5.Direction = ParameterDirection.Input;
                temp5.Value = temp_agency;
                objOraclecommand.Parameters.Add(temp5);



                OracleParameter temp15 = new OracleParameter("executive1", OracleType.VarChar, 50);
                temp15.Direction = ParameterDirection.Input;
                if (executive == "0")
                {
                    temp15.Value = System.DBNull.Value;
                }
                else
                {
                    temp15.Value = executive;
                }
                objOraclecommand.Parameters.Add(temp15);


                objOraclecommand.Parameters.Add("p_recordset1", OracleType.Cursor);
                objOraclecommand.Parameters["p_recordset1"].Direction = ParameterDirection.Output;


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
        public DataSet billingonscreen(string fromdate, string dateto, string region, string product, string category, string compcode, string dateformat, string descid, string ascdesc, string temp_agname, string temp_adtype, string temp_pubcent, string temp_edition, string temp_agency, string executive, string state, string district)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("Bill_Reportnew11", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("region", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                if ((region != "0") && (region != "--Select Region--"))
                {
                    prm1.Value = region;
                }
                else
                {
                    prm1.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("product", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                if (product != "0")
                {
                    prm2.Value = product;
                }
                else
                {
                    prm2.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("category", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                if (category != "0")
                {
                    prm3.Value = category;
                }
                else
                {
                    prm3.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm3);


                OracleParameter prm9 = new OracleParameter("fromdate", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                if (fromdate != "0")
                {
                    prm9.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");
                }
                else
                {
                    prm9.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm4 = new OracleParameter("dateto", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                if (dateto != "0")
                {
                    prm4.Value = Convert.ToDateTime(dateto).ToString("dd-MMMM-yyyy");
                }
                else
                {
                    prm4.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm4);



                OracleParameter prm5 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = compcode;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("dateformat", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = dateformat;
                objOraclecommand.Parameters.Add(prm6);


                OracleParameter prm7 = new OracleParameter("descid", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = descid;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("ascdesc", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = ascdesc;
                objOraclecommand.Parameters.Add(prm8);
                ///////////////////////////////////////////////////////////////////////////

                ///////////////////////////////////////////////////////////////////////////

                OracleParameter temp = new OracleParameter("agname", OracleType.VarChar, 50);
                temp.Direction = ParameterDirection.Input;
                temp.Value = temp_agname;
                objOraclecommand.Parameters.Add(temp);
                //string temp_agname=null, temp_adtype=null, temp_pubcent=null, temp_edition=null, temp_prod=null, temp_agency
                OracleParameter temp1 = new OracleParameter("Adtype", OracleType.VarChar, 50);
                temp1.Direction = ParameterDirection.Input;
                temp1.Value = temp_adtype;
                objOraclecommand.Parameters.Add(temp1);


                OracleParameter temp2 = new OracleParameter("pub_cent", OracleType.VarChar, 50);
                temp2.Direction = ParameterDirection.Input;
                temp2.Value = temp_pubcent;
                objOraclecommand.Parameters.Add(temp2);

                OracleParameter temp3 = new OracleParameter("edition", OracleType.VarChar, 50);
                temp3.Direction = ParameterDirection.Input;
                temp3.Value = temp_edition;
                objOraclecommand.Parameters.Add(temp3);

               
                OracleParameter temp5 = new OracleParameter("agency", OracleType.VarChar, 50);
                temp5.Direction = ParameterDirection.Input;
                temp5.Value = temp_agency;
                objOraclecommand.Parameters.Add(temp5);



                OracleParameter temp15 = new OracleParameter("executive1", OracleType.VarChar, 50);
                temp15.Direction = ParameterDirection.Input;
                if (executive == "0")
                {
                    temp15.Value = System.DBNull.Value;
                }
                else
                {
                    temp15.Value = executive;
                }
                objOraclecommand.Parameters.Add(temp15);



                OracleParameter prm51 = new OracleParameter("state", OracleType.VarChar, 50);
                prm51.Direction = ParameterDirection.Input;
                if (state == "")
                {
                    prm51.Value = System.DBNull.Value;
                }
                else
                {

                    prm51.Value = state;
                }
                objOraclecommand.Parameters.Add(prm51);

                OracleParameter prm52 = new OracleParameter("district", OracleType.VarChar, 50);
                prm52.Direction = ParameterDirection.Input;
                if (district == "0")
                {
                    prm52.Value = System.DBNull.Value;
                }
                else
                {
                    prm52.Value = district;
                }



                objOraclecommand.Parameters.Add(prm52);


                objOraclecommand.Parameters.Add("p_recordset1", OracleType.Cursor);
                objOraclecommand.Parameters["p_recordset1"].Direction = ParameterDirection.Output;


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


        public DataSet spcontractreportnewbilled(string fromdate, string dateto, string compcode, string dateformat, string product, string agency1, string client1, string region1, string category, string pub_center, string useid, string chk_acc)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {

                objOracleConnection.Open();
                //objOraclecommand = GetCommand("MisReport.MisReport_p", ref objOracleConnection);
                //objOraclecommand.CommandType = CommandType.StoredProcedure;

                objOraclecommand = GetCommand("SHACHI_PICONTRACT_REPORTbilled", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter top1 = new OracleParameter("puserid", OracleType.VarChar);
                top1.Direction = ParameterDirection.Input;
                top1.Value = useid;
                objOraclecommand.Parameters.Add(top1);

                OracleParameter top2 = new OracleParameter("chk_access", OracleType.VarChar);
                top2.Direction = ParameterDirection.Input;
                top2.Value = chk_acc;
                objOraclecommand.Parameters.Add(top2);

                OracleParameter pra2 = new OracleParameter("publication_center", OracleType.VarChar);
                pra2.Direction = ParameterDirection.Input;
                if (pub_center == "0")
                {
                    pra2.Value = System.DBNull.Value;
                }
                else
                {
                    pra2.Value = pub_center;
                }
                objOraclecommand.Parameters.Add(pra2);

                OracleParameter prm4 = new OracleParameter("fromdate", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                if (fromdate == "")
                {
                    prm4.Value = System.DBNull.Value;
                }
                else
                {
                    prm4.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("dateto", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                if (dateto == "")
                {
                    prm5.Value = System.DBNull.Value;
                }
                else
                {
                    prm5.Value = Convert.ToDateTime(dateto).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("compcode", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = compcode;
                objOraclecommand.Parameters.Add(prm6);


                OracleParameter prm7 = new OracleParameter("pub_cent", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                if (product == "0")
                {
                    prm7.Value = System.DBNull.Value;
                }
                else
                {
                    prm7.Value = product;
                }
                objOraclecommand.Parameters.Add(prm7);



                OracleParameter prm14 = new OracleParameter("dateformat", OracleType.VarChar);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = dateformat;
                objOraclecommand.Parameters.Add(prm14);

                OracleParameter prm15 = new OracleParameter("agname", OracleType.VarChar);
                prm15.Direction = ParameterDirection.Input;

                if (agency1 == "0" || agency1=="")
                {
                    prm15.Value = System.DBNull.Value;
                }
                else
                {
                    prm15.Value = agency1;
                }

                objOraclecommand.Parameters.Add(prm15);

                OracleParameter prm16 = new OracleParameter("client", OracleType.VarChar);
                prm16.Direction = ParameterDirection.Input;
                if (client1 == "0" || client1=="")
                {
                    prm16.Value = System.DBNull.Value;
                }
                else
                {
                    prm16.Value = client1;
                }


                objOraclecommand.Parameters.Add(prm16);



                OracleParameter tmp3 = new OracleParameter("category1", OracleType.VarChar);
                tmp3.Direction = ParameterDirection.Input;
                if (category == "0")
                {
                    tmp3.Value = System.DBNull.Value;
                }
                else
                {
                    tmp3.Value = category;
                }

                objOraclecommand.Parameters.Add(tmp3);

                //OracleParameter tmp4 = new OracleParameter("adcategory", OracleType.VarChar);
                //tmp4.Direction = ParameterDirection.Input;
                //tmp4.Value = temp4;
                //objOraclecommand.Parameters.Add(tmp4);

                OracleParameter tmp5 = new OracleParameter("Region", OracleType.VarChar);
                tmp5.Direction = ParameterDirection.Input;
                if (region1 == "0")
                {
                    tmp5.Value = System.DBNull.Value;
                }
                else
                {
                    tmp5.Value = region1;
                }

                objOraclecommand.Parameters.Add(tmp5);

                //OracleParameter tmp6 = new OracleParameter("pub_cent", OracleType.VarChar);
                //tmp6.Direction = ParameterDirection.Input;
                //tmp6.Value = temp6;
                //objOraclecommand.Parameters.Add(tmp6);

                //OracleParameter tmp7 = new OracleParameter("status", OracleType.VarChar);
                //tmp7.Direction = ParameterDirection.Input;
                //tmp7.Value = temp7;
                //objOraclecommand.Parameters.Add(tmp7);

                //OracleParameter tmp8 = new OracleParameter("edition", OracleType.VarChar);
                //tmp8.Direction = ParameterDirection.Input;
                //tmp8.Value = temp8;
                //objOraclecommand.Parameters.Add(tmp8);

                //OracleParameter tmp9 = new OracleParameter("hold", OracleType.VarChar);
                //tmp9.Direction = ParameterDirection.Input;
                //tmp9.Value = temp9;
                //objOraclecommand.Parameters.Add(tmp9);

                //OracleParameter tmp10 = new OracleParameter("published", OracleType.VarChar);
                //tmp10.Direction = ParameterDirection.Input;
                //tmp10.Value = temp10;
                //objOraclecommand.Parameters.Add(tmp10);



                objOraclecommand.Parameters.Add("p_recordset1", OracleType.Cursor);
                objOraclecommand.Parameters["p_recordset1"].Direction = ParameterDirection.Output;

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




  public OracleDataReader spcontractreportnewbilledexcel(string fromdate, string dateto, string compcode, string dateformat, string product, string agency1, string client1, string region1, string category)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {

                objOracleConnection.Open();
                //objOraclecommand = GetCommand("MisReport.MisReport_p", ref objOracleConnection);
                //objOraclecommand.CommandType = CommandType.StoredProcedure;

                objOraclecommand = GetCommand("SHACHI_PICONTRACT_REPORTbilled", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm4 = new OracleParameter("fromdate", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                if (fromdate == "")
                {
                    prm4.Value = System.DBNull.Value;
                }
                else
                {
                    prm4.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("dateto", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                if (dateto == "")
                {
                    prm5.Value = System.DBNull.Value;
                }
                else
                {
                    prm5.Value = Convert.ToDateTime(dateto).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("compcode", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = compcode;
                objOraclecommand.Parameters.Add(prm6);


                OracleParameter prm7 = new OracleParameter("pub_cent", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                if (product == "0")
                {
                    prm7.Value = System.DBNull.Value;
                }
                else
                {
                    prm7.Value = product;
                }
                objOraclecommand.Parameters.Add(prm7);



                OracleParameter prm14 = new OracleParameter("dateformat", OracleType.VarChar);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = dateformat;
                objOraclecommand.Parameters.Add(prm14);

                OracleParameter prm15 = new OracleParameter("agname", OracleType.VarChar);
                prm15.Direction = ParameterDirection.Input;

                if (agency1 == "0")
                {
                    prm15.Value = System.DBNull.Value;
                }
                else
                {
                    prm15.Value = agency1;
                }

                objOraclecommand.Parameters.Add(prm15);

                OracleParameter prm16 = new OracleParameter("client", OracleType.VarChar);
                prm16.Direction = ParameterDirection.Input;
                if (client1 == "0")
                {
                    prm16.Value = System.DBNull.Value;
                }
                else
                {
                    prm16.Value = client1;
                }


                objOraclecommand.Parameters.Add(prm16);



                OracleParameter tmp3 = new OracleParameter("category1", OracleType.VarChar);
                tmp3.Direction = ParameterDirection.Input;
                if (category == "0")
                {
                    tmp3.Value = System.DBNull.Value;
                }
                else
                {
                    tmp3.Value = category;
                }

                objOraclecommand.Parameters.Add(tmp3);

                //OracleParameter tmp4 = new OracleParameter("adcategory", OracleType.VarChar);
                //tmp4.Direction = ParameterDirection.Input;
                //tmp4.Value = temp4;
                //objOraclecommand.Parameters.Add(tmp4);

                OracleParameter tmp5 = new OracleParameter("Region", OracleType.VarChar);
                tmp5.Direction = ParameterDirection.Input;
                if (region1 == "0")
                {
                    tmp5.Value = System.DBNull.Value;
                }
                else
                {
                    tmp5.Value = region1;
                }

                objOraclecommand.Parameters.Add(tmp5);

                //OracleParameter tmp6 = new OracleParameter("pub_cent", OracleType.VarChar);
                //tmp6.Direction = ParameterDirection.Input;
                //tmp6.Value = temp6;
                //objOraclecommand.Parameters.Add(tmp6);

                //OracleParameter tmp7 = new OracleParameter("status", OracleType.VarChar);
                //tmp7.Direction = ParameterDirection.Input;
                //tmp7.Value = temp7;
                //objOraclecommand.Parameters.Add(tmp7);

                //OracleParameter tmp8 = new OracleParameter("edition", OracleType.VarChar);
                //tmp8.Direction = ParameterDirection.Input;
                //tmp8.Value = temp8;
                //objOraclecommand.Parameters.Add(tmp8);

                //OracleParameter tmp9 = new OracleParameter("hold", OracleType.VarChar);
                //tmp9.Direction = ParameterDirection.Input;
                //tmp9.Value = temp9;
                //objOraclecommand.Parameters.Add(tmp9);

                //OracleParameter tmp10 = new OracleParameter("published", OracleType.VarChar);
                //tmp10.Direction = ParameterDirection.Input;
                //tmp10.Value = temp10;
                //objOraclecommand.Parameters.Add(tmp10);



                objOraclecommand.Parameters.Add("p_recordset1", OracleType.Cursor);
                objOraclecommand.Parameters["p_recordset1"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                OracleDataReader objdatareadre = objOraclecommand.ExecuteReader();

                return objdatareadre;


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