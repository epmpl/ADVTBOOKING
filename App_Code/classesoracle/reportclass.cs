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


    public class reportclass : orclconnection
    {
        public reportclass()
        {
            
        }



        public DataSet page(string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("bindpremiumforrate.bindpremiumforrate_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);

                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

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



        public DataSet position(string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_getPagePosition.websp_getPagePosition_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);

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

        public DataSet spproductreport(string frmdt, string todate, string compcode, string region, string dateformat, string product, string descid, string ascdesc, string temp1, string temp2, string temp3, string temp4, string temp5, string temp6, string temp7, string temp8, string temp9, string temp10)
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


                OracleParameter prm1 = new OracleParameter("fromdate", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                if (frmdt == "" || frmdt == null)
                {
                    prm1.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
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
                    if (dateformat == "dd/mm/yyyy")
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
                OracleParameter prm6 = new OracleParameter("compcode", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = compcode;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm8 = new OracleParameter("region", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                if (region == "0")
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
        }


        public DataSet bindlanguage(string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("PubAddLanguage.PubAddLanguage_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm6 = new OracleParameter("compcode", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = compcode;
                objOraclecommand.Parameters.Add(prm6);


                objOraclecommand.Parameters.Add("P_ACCOUNT", OracleType.Cursor);
                objOraclecommand.Parameters["P_ACCOUNT"].Direction = ParameterDirection.Output;

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


        public DataSet spregionreport(string frmdt, string todate, string compcode, string region, string dateformat, string descid, string ascdesc, string temp1, string temp2, string temp3, string temp4, string temp5, string temp6, string temp7, string temp8, string temp9, string temp10, string temp11)
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

                OracleParameter prm1 = new OracleParameter("fromdate", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                if (frmdt == "" || frmdt == null)
                {
                    prm1.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
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
                    if (dateformat == "dd/mm/yyyy")
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
        /////////////////
        public DataSet spcontractreportnew(string frmdt, string todate, string compcode, string dateformat, string product, string descid, string ascdesc, string temp1, string temp2, string temp3, string temp4, string temp5, string temp6, string temp7, string temp8, string temp9, string temp10, string temp11)
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


                OracleParameter prm1 = new OracleParameter("fromdate", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                if (frmdt == "" || frmdt == null)
                {
                    prm1.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
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
                    if (dateformat == "dd/mm/yyyy")
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

                OracleParameter prm6 = new OracleParameter("compcode", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = compcode;
                objOraclecommand.Parameters.Add(prm6);


                OracleParameter prm7 = new OracleParameter("pub_name", OracleType.VarChar);
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
        public DataSet spPagepremium(string page, string position, string frmdt, string todate, string pubname, string pubcent, string compcode, string edition, string dateformat, string hold, string descid, string ascdesc, string temp1, string temp2, string temp3, string temp4, string temp5)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {

                objOracleConnection.Open();
                //objOraclecommand = GetCommand("deviationreport.deviationreport_p", ref objOracleConnection);
                //objOraclecommand.CommandType = CommandType.StoredProcedure;



                objOraclecommand = GetCommand("Deviationreportnew", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm3 = new OracleParameter("page", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                if (page == "0")
                {
                    prm3.Value = System.DBNull.Value;
                }
                else
                {
                    prm3.Value = page;
                }
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("position", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                if (page == "0")
                {
                    prm4.Value = System.DBNull.Value;
                }
                else
                {
                    prm4.Value = position;
                }
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm1 = new OracleParameter("fromdate", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                if (frmdt == "" || frmdt == null)
                {
                    prm1.Value = System.DBNull.Value;
                }

                else
                {
                    if (dateformat == "dd/mm/yyyy")
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

                    if (dateformat == "dd/mm/yyyy")
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


                OracleParameter prm8 = new OracleParameter("pub_cent", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                if (pubcent == "0")
                {
                    prm8.Value = System.DBNull.Value;
                }
                else
                {
                    prm8.Value = pubcent;
                }
                objOraclecommand.Parameters.Add(prm8);


                OracleParameter prm9 = new OracleParameter("edition", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                if (edition == "0")
                {
                    prm9.Value = System.DBNull.Value;
                }
                else
                {
                    prm9.Value = edition;
                }
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm12 = new OracleParameter("dateformat", OracleType.VarChar);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = dateformat;
                objOraclecommand.Parameters.Add(prm12);

                OracleParameter prm10 = new OracleParameter("hold", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                if (hold == "0")
                {
                    prm10.Value = System.DBNull.Value;
                }
                else
                {
                    prm10.Value = hold;
                }
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("descid", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = descid;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm122 = new OracleParameter("ascdesc", OracleType.VarChar);
                prm122.Direction = ParameterDirection.Input;
                prm122.Value = ascdesc;
                objOraclecommand.Parameters.Add(prm122);

                //====================
                OracleParameter tmp2 = new OracleParameter("adtype1", OracleType.VarChar);
                tmp2.Direction = ParameterDirection.Input;
                tmp2.Value = temp2;
                objOraclecommand.Parameters.Add(tmp2);


                OracleParameter tmp3 = new OracleParameter("adcategory", OracleType.VarChar);
                tmp3.Direction = ParameterDirection.Input;
                tmp3.Value = temp3;
                objOraclecommand.Parameters.Add(tmp3);

                OracleParameter tmp4 = new OracleParameter("status", OracleType.VarChar);
                tmp4.Direction = ParameterDirection.Input;
                tmp4.Value = temp4;
                objOraclecommand.Parameters.Add(tmp4);

                OracleParameter tmp5 = new OracleParameter("clientname", OracleType.VarChar);
                tmp5.Direction = ParameterDirection.Input;
                tmp5.Value = temp5;
                objOraclecommand.Parameters.Add(tmp5);

                OracleParameter tmp1 = new OracleParameter("agname", OracleType.VarChar);
                tmp1.Direction = ParameterDirection.Input;
                tmp1.Value = temp1;
                objOraclecommand.Parameters.Add(tmp1);

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
                objOraclecommand = GetCommand("bill_report.bill_report_p", ref objOracleConnection);
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

                OracleParameter tmp11 = new OracleParameter("agname", OracleType.VarChar, 50);
                tmp11.Direction = ParameterDirection.Input;
                tmp11.Value = temp_agname;
                objOraclecommand.Parameters.Add(tmp11);

                OracleParameter tmp12 = new OracleParameter("Adtype", OracleType.VarChar, 50);
                tmp12.Direction = ParameterDirection.Input;
                tmp12.Value = temp_adtype;
                objOraclecommand.Parameters.Add(tmp12);

                OracleParameter tmp3 = new OracleParameter("pub_cent", OracleType.VarChar, 50);
                tmp3.Direction = ParameterDirection.Input;
                tmp3.Value = temp_pubcent;
                objOraclecommand.Parameters.Add(tmp3);

                OracleParameter tmp4 = new OracleParameter("category", OracleType.VarChar, 50);
                tmp4.Direction = ParameterDirection.Input;
                tmp4.Value = temp_category;
                objOraclecommand.Parameters.Add(tmp4);

                OracleParameter tmp5 = new OracleParameter("edition", OracleType.VarChar, 50);
                tmp5.Direction = ParameterDirection.Input;
                tmp5.Value = temp_edition;
                objOraclecommand.Parameters.Add(tmp5);

                OracleParameter tmp6 = new OracleParameter("Region", OracleType.VarChar, 50);
                tmp6.Direction = ParameterDirection.Input;
                tmp6.Value = temp_region;
                objOraclecommand.Parameters.Add(tmp6);

                OracleParameter tmp7 = new OracleParameter("agency", OracleType.VarChar, 50);
                tmp7.Direction = ParameterDirection.Input;
                tmp7.Value = temp_agency;
                objOraclecommand.Parameters.Add(tmp7);

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

        public DataSet spclient(string cliname, string adtype, string adcategory, string fromdate, string dateto, string pubname, string pubcent, string compcode, string edition, string dateformat, string descid, string ascdesc, string agname, string status, string hold)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("reportnew", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("clientname", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                if (cliname == "0")
                {
                    prm1.Value = System.DBNull.Value;
                }
                else
                {
                    prm1.Value = cliname;
                }
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("adtype1", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                if (adtype == "0")
                {
                    prm2.Value = System.DBNull.Value;
                }
                else
                {
                    prm2.Value = adtype;
                }
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("adcategory", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                if (adcategory == "0")
                {
                    prm3.Value = System.DBNull.Value;
                }
                else
                {
                    prm3.Value = adcategory;
                }
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("fromdate", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                if (fromdate == "")
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
                if (dateto == "")
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


                OracleParameter prm8 = new OracleParameter("pub_cent", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                if (pubcent == "0")
                {
                    prm8.Value = System.DBNull.Value;
                }
                else
                {
                    prm8.Value = pubcent;
                }
                objOraclecommand.Parameters.Add(prm8);


                OracleParameter prm9 = new OracleParameter("edition", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                if ((edition == "--Select Edition Name--") || (edition == "0"))
                {
                    prm9.Value = System.DBNull.Value;
                }
                else
                {
                    prm9.Value = edition;
                }
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm12 = new OracleParameter("dateformat", OracleType.VarChar);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = dateformat;
                objOraclecommand.Parameters.Add(prm12);

                OracleParameter prm13 = new OracleParameter("descid", OracleType.VarChar);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = descid;
                objOraclecommand.Parameters.Add(prm13);

                OracleParameter prm14 = new OracleParameter("ascdesc", OracleType.VarChar);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = ascdesc;
                objOraclecommand.Parameters.Add(prm14);


                OracleParameter temp1 = new OracleParameter("agname", OracleType.VarChar);
                temp1.Direction = ParameterDirection.Input;
                if (agname == "" || agname == "0")
                    temp1.Value = System.DBNull.Value;
                else
                    temp1.Value = agname;
                objOraclecommand.Parameters.Add(temp1);


                OracleParameter temp2 = new OracleParameter("status", OracleType.VarChar);
                temp2.Direction = ParameterDirection.Input;
                temp2.Value = status;
                objOraclecommand.Parameters.Add(temp2);


                OracleParameter temp3 = new OracleParameter("hold", OracleType.VarChar);
                temp3.Direction = ParameterDirection.Input;
                temp3.Value = hold;
                objOraclecommand.Parameters.Add(temp3);

                objOraclecommand.Parameters.Add("p_reportnew", OracleType.Cursor);
                objOraclecommand.Parameters["p_reportnew"].Direction = ParameterDirection.Output;

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




        

        public DataSet spStatus(string agname, string adtype, string adcategory, string fromdate, string dateto, string pubname, string pubcent, string compcode, string status, string edition, string dateformat, string hold, string descid, string ascdesc, string temp1)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("Reportnew", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("agname", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                if (agname == "0")
                {
                    prm1.Value = System.DBNull.Value;
                }
                else
                {
                    prm1.Value = agname;
                }
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("adtype1", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                if (adtype == "0")
                {
                    prm2.Value = System.DBNull.Value;
                }
                else
                {
                    prm2.Value = adtype;
                }
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("adcategory", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                if (adcategory == "0")
                {
                    prm3.Value = System.DBNull.Value;
                }
                else
                {
                    prm3.Value = adcategory;
                }
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("fromdate", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                if (fromdate == "")
                {
                    prm4.Value = System.DBNull.Value;
                }
                else
                {

                    if (dateformat == "dd/mm/yyyy" && fromdate != "" && fromdate != null)
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
                if (dateto == "")
                {
                    prm5.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy" && dateto != "" && dateto != null)
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


                OracleParameter prm8 = new OracleParameter("pub_cent", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                if (pubcent == "0")
                {
                    prm8.Value = System.DBNull.Value;
                }
                else
                {
                    prm8.Value = pubcent;
                }
                objOraclecommand.Parameters.Add(prm8);


                OracleParameter prm9 = new OracleParameter("edition", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                if (edition == "0")
                {
                    prm9.Value = System.DBNull.Value;
                }
                else
                {
                    prm9.Value = edition;
                }
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm12 = new OracleParameter("dateformat", OracleType.VarChar);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = dateformat;
                objOraclecommand.Parameters.Add(prm12);


                OracleParameter prm13 = new OracleParameter("status", OracleType.VarChar);
                prm13.Direction = ParameterDirection.Input;
                if (status == "0")
                {
                    prm13.Value = System.DBNull.Value;
                }
                else
                {
                    prm13.Value = status;
                }
                objOraclecommand.Parameters.Add(prm13);

                OracleParameter prm16 = new OracleParameter("hold", OracleType.VarChar);
                prm16.Direction = ParameterDirection.Input;
                if (hold == "0")
                {
                    prm16.Value = System.DBNull.Value;
                }
                else
                {
                    prm16.Value = hold;
                }
                objOraclecommand.Parameters.Add(prm16);


                OracleParameter prm14 = new OracleParameter("descid", OracleType.VarChar);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = descid;
                objOraclecommand.Parameters.Add(prm14);



                OracleParameter prm15 = new OracleParameter("ascdesc", OracleType.VarChar);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = ascdesc;
                objOraclecommand.Parameters.Add(prm15);


                OracleParameter tmp1 = new OracleParameter("clientname", OracleType.VarChar);
                tmp1.Direction = ParameterDirection.Input;
                tmp1.Value = temp1;
                objOraclecommand.Parameters.Add(tmp1);

                objOraclecommand.Parameters.Add("p_reportnew", OracleType.Cursor);
                objOraclecommand.Parameters["p_reportnew"].Direction = ParameterDirection.Output;

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

        public DataSet spAgency(string agname, string adtype, string adcategory, string fromdate, string dateto, string pubname, string pubcent, string compcode, string edition, string dateformat, string descid, string ascdesc, string clientname, string status, string hold)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {

                objOracleConnection.Open();
                //objOraclecommand = GetCommand("Report1.Report1_p", ref objOracleConnection);
                //objOraclecommand.CommandType = CommandType.StoredProcedure;

                objOraclecommand = GetCommand("reportnew", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("agname", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                if (agname == "0")
                {
                    prm1.Value = System.DBNull.Value;
                }
                else
                {
                    prm1.Value = agname;
                }
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("adtype1", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                if (adtype == "0")
                {
                    prm2.Value = System.DBNull.Value;
                }
                else
                {
                    prm2.Value = adtype;
                }
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("adcategory", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                if (adcategory == "0")
                {
                    prm3.Value = System.DBNull.Value;
                }
                else
                {
                    prm3.Value = adcategory;
                }
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("fromdate", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                if (fromdate == "0")
                {
                    prm4.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy" && fromdate != "" && fromdate != null)
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
                if (dateto == "0")
                {
                    prm5.Value = System.DBNull.Value;
                }
                else
                {

                    if (dateformat == "dd/mm/yyyy" && dateto != "" && dateto != null)
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


                OracleParameter prm8 = new OracleParameter("pub_cent", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                if (pubcent == "0")
                {
                    prm8.Value = System.DBNull.Value;
                }
                else
                {
                    prm8.Value = pubcent;
                }
                objOraclecommand.Parameters.Add(prm8);


                OracleParameter prm9 = new OracleParameter("edition", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                if (edition == "0")
                {
                    prm9.Value = System.DBNull.Value;
                }
                else
                {
                    prm9.Value = edition;
                }
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm12 = new OracleParameter("dateformat", OracleType.VarChar);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = dateformat;
                objOraclecommand.Parameters.Add(prm12);


                OracleParameter prm10 = new OracleParameter("descid", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = descid;
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("ascdesc", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = ascdesc;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter temp1 = new OracleParameter("clientname", OracleType.VarChar);
                temp1.Direction = ParameterDirection.Input;
                temp1.Value = clientname;
                objOraclecommand.Parameters.Add(temp1);

                OracleParameter temp2 = new OracleParameter("status", OracleType.VarChar);
                temp2.Direction = ParameterDirection.Input;
                temp2.Value = status;
                objOraclecommand.Parameters.Add(temp2);

                OracleParameter temp3 = new OracleParameter("hold", OracleType.VarChar);
                temp3.Direction = ParameterDirection.Input;
                temp3.Value = hold;
                objOraclecommand.Parameters.Add(temp3);

                objOraclecommand.Parameters.Add("p_reportnew", OracleType.Cursor);
                objOraclecommand.Parameters["p_reportnew"].Direction = ParameterDirection.Output;

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


        public DataSet agency(string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("bindagencyforcontract.bindagencyforcontract_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm6 = new OracleParameter("compcode", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = compcode;
                objOraclecommand.Parameters.Add(prm6);

                objOraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;

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

        public DataSet spfun(string adtype, string adcategory, string fromdate, string dateto, string pubname, string pubcent, string compcode, string edition, string dateformat, string descid, string ascdesc, string agname, string clientname, string status, string hold)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {

                objOracleConnection.Open();


                objOraclecommand = GetCommand("reportnew", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("adtype1", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                if (adtype == "0")
                {
                    prm1.Value = System.DBNull.Value;
                }
                else
                {
                    prm1.Value = adtype;
                }
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("adcategory", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                if (adcategory == "")
                {
                    prm2.Value = System.DBNull.Value;
                }
                else
                {
                    prm2.Value = adcategory;
                }
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("fromdate", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                if (fromdate == "")
                {
                    prm3.Value = System.DBNull.Value;
                }
                else
                {

                    if (dateformat == "dd/mm/yyyy" && fromdate != "" && fromdate != null)
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
                if (dateto == "")
                {
                    prm4.Value = System.DBNull.Value;
                }
                else
                {

                    if (dateformat == "dd/mm/yyyy" && dateto != "" && dateto != null)
                    {

                        string[] arr = dateto.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        dateto = mm + "/" + dd + "/" + yy;
                    }
                    prm4.Value = Convert.ToDateTime(dateto).ToString("dd-MMMM-yyyy"); ;
                }
                objOraclecommand.Parameters.Add(prm4);



                OracleParameter prm5 = new OracleParameter("compcode", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = compcode;
                objOraclecommand.Parameters.Add(prm5);


                OracleParameter prm6 = new OracleParameter("pub_name", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                if (pubname == "0")
                {
                    prm6.Value = System.DBNull.Value;
                }
                else
                {
                    prm6.Value = pubname;
                }
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("pub_cent", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                if (pubcent == "0")
                {
                    prm7.Value = System.DBNull.Value;
                }
                else
                {
                    prm7.Value = pubcent;
                }
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("edition", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                if (edition == "0")
                {
                    prm8.Value = System.DBNull.Value;
                }
                else
                {
                    prm8.Value = edition;
                }
                objOraclecommand.Parameters.Add(prm8);


                OracleParameter prm9 = new OracleParameter("dateformat", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = dateformat;
                objOraclecommand.Parameters.Add(prm9);


                OracleParameter prm10 = new OracleParameter("descid", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = descid;
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("ascdesc", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = ascdesc;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter temp1 = new OracleParameter("agname", OracleType.VarChar);
                temp1.Direction = ParameterDirection.Input;
                if (agname == "0" || agname == "")
                {
                    temp1.Value = System.DBNull.Value;
                }
                else
                {
                    temp1.Value = agname;
                }
                objOraclecommand.Parameters.Add(temp1);

                OracleParameter temp2 = new OracleParameter("clientname", OracleType.VarChar);
                temp2.Direction = ParameterDirection.Input;
                temp2.Value = clientname;
                objOraclecommand.Parameters.Add(temp2);

                OracleParameter temp3 = new OracleParameter("status", OracleType.VarChar);
                temp3.Direction = ParameterDirection.Input;
                temp3.Value = status;
                objOraclecommand.Parameters.Add(temp3);

                OracleParameter temp4 = new OracleParameter("hold", OracleType.VarChar);
                temp4.Direction = ParameterDirection.Input;
                temp4.Value = hold;
                objOraclecommand.Parameters.Add(temp4);

                objOraclecommand.Parameters.Add("p_reportnew", OracleType.Cursor);
                objOraclecommand.Parameters["p_reportnew"].Direction = ParameterDirection.Output;

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
        public DataSet pubrebate(string fromdate, string dateto, string compcode, string category, string product, string dateformat, string descid, string ascdesc, string temp1, string temp2, string temp3, string temp4, string temp5, string temp6)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("Bill_Reportnew", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("fromdate", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                if (fromdate == "")
                {
                    prm1.Value = System.DBNull.Value;
                }
                else
                {

                    if (dateformat == "dd/mm/yyyy" && fromdate != "" && fromdate != null)
                    {
                        string[] arr = fromdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        fromdate = mm + "/" + dd + "/" + yy;
                    }
                    prm1.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("dateto", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                if (dateto == "")
                {
                    prm2.Value = System.DBNull.Value;
                }
                else
                {

                    if (dateformat == "dd/mm/yyyy" && dateto != "" && dateto != null)
                    {

                        string[] arr = dateto.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        dateto = mm + "/" + dd + "/" + yy;
                    }
                    prm2.Value = Convert.ToDateTime(dateto).ToString("dd-MMMM-yyyy"); ;
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

                OracleParameter tmp2 = new OracleParameter("Adtype", OracleType.VarChar, 50);
                tmp2.Direction = ParameterDirection.Input;
                tmp2.Value = temp2;
                objOraclecommand.Parameters.Add(tmp2);


                OracleParameter tmp3 = new OracleParameter("pub_cent", OracleType.VarChar, 50);
                tmp3.Direction = ParameterDirection.Input;
                tmp3.Value = temp3;
                objOraclecommand.Parameters.Add(tmp3);



               
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



        public DataSet spDeviation(string cliname, string agname, string adtype, string adcategory, string fromdate, string dateto, string pubname, string pubcent, string compcode, string status, string edition, string dateformat, string hold, string descid, string ascdesc, string temp1, string temp2)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("Deviationreportnew", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("clientname", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                if (cliname == "0")
                {
                    prm1.Value = System.DBNull.Value;
                }
                else
                {
                    prm1.Value = cliname;
                }
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm01 = new OracleParameter("agname", OracleType.VarChar);
                prm01.Direction = ParameterDirection.Input;
                if (agname == "0")
                {
                    prm01.Value = System.DBNull.Value;
                }
                else
                {
                    prm01.Value = agname;
                }
                objOraclecommand.Parameters.Add(prm01);


                OracleParameter prm2 = new OracleParameter("adtype1", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                if (adtype == "0")
                {
                    prm2.Value = System.DBNull.Value;
                }
                else
                {
                    prm2.Value = adtype;
                }
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("adcategory", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                if (adcategory == "0")
                {
                    prm3.Value = System.DBNull.Value;
                }
                else
                {
                    prm3.Value = adcategory;
                }
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("fromdate", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                if (fromdate == "")
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
                if (dateto == "")
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


                OracleParameter prm8 = new OracleParameter("pub_cent", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                if (pubcent == "0")
                {
                    prm8.Value = System.DBNull.Value;
                }
                else
                {
                    prm8.Value = pubcent;
                }
                objOraclecommand.Parameters.Add(prm8);


                OracleParameter prm9 = new OracleParameter("edition", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                if (edition == "0")
                {
                    prm9.Value = System.DBNull.Value;
                }
                else
                {
                    prm9.Value = edition;
                }
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm12 = new OracleParameter("dateformat", OracleType.VarChar);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = dateformat;
                objOraclecommand.Parameters.Add(prm12);


                OracleParameter prm13 = new OracleParameter("status", OracleType.VarChar);
                prm13.Direction = ParameterDirection.Input;
                if (status == "0")
                {
                    prm13.Value = System.DBNull.Value;
                }
                else
                {
                    prm13.Value = status;
                }
                objOraclecommand.Parameters.Add(prm13);

                OracleParameter prm16 = new OracleParameter("hold", OracleType.VarChar);
                prm16.Direction = ParameterDirection.Input;
                if (hold == "0")
                {
                    prm16.Value = System.DBNull.Value;
                }
                else
                {
                    prm16.Value = hold;
                }
                objOraclecommand.Parameters.Add(prm16);


                OracleParameter prm15 = new OracleParameter("descid", OracleType.VarChar);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = descid;
                objOraclecommand.Parameters.Add(prm15);

                OracleParameter prm14 = new OracleParameter("ascdesc", OracleType.VarChar);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = ascdesc;
                objOraclecommand.Parameters.Add(prm14);

                //==============
                OracleParameter tmp1 = new OracleParameter("page", OracleType.VarChar);
                tmp1.Direction = ParameterDirection.Input;
                tmp1.Value = temp1;
                objOraclecommand.Parameters.Add(tmp1);

                OracleParameter tmp2 = new OracleParameter("position", OracleType.VarChar);
                tmp2.Direction = ParameterDirection.Input;
                tmp2.Value = temp2;
                objOraclecommand.Parameters.Add(tmp2);

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


        public DataSet bindrevenuecenter(string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {


                objOracleConnection.Open();
                objOraclecommand = GetCommand("bindrevenuecenter", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

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


        public DataSet displayonscreenreport1(string pubcent, string adtyp, string fromdate, string dateto, string compcode, string publication, string dateformat, string descid, string ascdesc, string value)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("Schedulereport.Schedulereport_p", ref objOracleConnection);
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
                if (publication == "0")
                {
                    prm7.Value = System.DBNull.Value;
                }
                else
                {
                    prm7.Value = publication;
                }
                objOraclecommand.Parameters.Add(prm7);


                OracleParameter prm18 = new OracleParameter("dateformat", OracleType.VarChar);
                prm18.Direction = ParameterDirection.Input;
                prm18.Value = dateformat;
                objOraclecommand.Parameters.Add(prm18);

                OracleParameter prm17 = new OracleParameter("adtyp", OracleType.VarChar);
                prm17.Direction = ParameterDirection.Input;
                prm17.Value = adtyp;
                objOraclecommand.Parameters.Add(prm17);

                OracleParameter prm15 = new OracleParameter("descid", OracleType.VarChar);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = descid;
                objOraclecommand.Parameters.Add(prm15);

                OracleParameter prm16 = new OracleParameter("ascdesc", OracleType.VarChar);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = ascdesc;
                objOraclecommand.Parameters.Add(prm16);

                OracleParameter prm116 = new OracleParameter("pub_cent", OracleType.VarChar);
                prm116.Direction = ParameterDirection.Input;
                if (pubcent == "0")
                {
                    prm116.Value = System.DBNull.Value;
                }
                else
                {
                    prm116.Value = pubcent;
                }
                objOraclecommand.Parameters.Add(prm116);


                OracleParameter prm161 = new OracleParameter("value", OracleType.VarChar);
                prm161.Direction = ParameterDirection.Input;
                prm161.Value = value;
                objOraclecommand.Parameters.Add(prm161);




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


        public DataSet advpub(string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {



                objOracleConnection.Open();
                objOraclecommand = GetCommand("Bind_PubName.Bind_PubName_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);


                objOraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;

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

        public DataSet adagencycli(string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("bindclientforcontract.bindclientforcontract_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm6 = new OracleParameter("compcode", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = compcode;
                objOraclecommand.Parameters.Add(prm6);

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
        public DataSet advtype(string adtype, string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("RA_bindadcategory.RA_bindadcategory_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("advtype", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = adtype;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);

                objOraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;

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


        public DataSet district(string state, string compcode)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("Websp_District", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm11 = new OracleParameter("state", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = state;
                objOraclecommand.Parameters.Add(prm11);

                objOraclecommand.Parameters.Add("get_district", OracleType.Cursor);
                objOraclecommand.Parameters["get_district"].Direction = ParameterDirection.Output;

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
        public DataSet bindexecutive(string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("get_exec", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);



                objOraclecommand.Parameters.Add("get_executive", OracleType.Cursor);
                objOraclecommand.Parameters["get_executive"].Direction = ParameterDirection.Output;

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
       



        public DataSet edition(string pubcode, string centercode, string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("edition_proc.edition_proc_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm3 = new OracleParameter("pubcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = pubcode;
                objOraclecommand.Parameters.Add(prm3);
                OracleParameter prm2 = new OracleParameter("centercode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = centercode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

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

        public DataSet pub_cent(string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {


                objOracleConnection.Open();
                objOraclecommand = GetCommand("publication_proc.publication_proc_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

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

        public DataSet adname(string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("RA_adbindcategory.RA_adbindcategory_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                objOraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;

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
                objOraclecommand = GetCommand("bill_report.bill_report_p", ref objOracleConnection);
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
                if (region != "0")
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
                objOraclecommand = GetCommand("Bill_Reportnew", ref objOracleConnection);
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

        public DataSet product(string region, string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("sp_publication.sp_publication_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("region", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = region;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm5 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = compcode;
                objOraclecommand.Parameters.Add(prm5);


                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;
               
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
                objOraclecommand = GetCommand("Bill_Reportnew", ref objOracleConnection);
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



        public DataSet retainonscreen(string fromdate, string dateto, string region, string product, string compcode, string dateformat, string descid, string ascdesc, string temp1, string temp2, string temp3, string temp4, string temp5, string temp6)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("Bill_Reportnew", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

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


                OracleParameter prm1 = new OracleParameter("fromdate", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                if (fromdate == "" || fromdate == null)
                {
                    prm1.Value = System.DBNull.Value;
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

                    prm1.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("dateto", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;


                if (dateto == "" || dateto == null)
                {
                    prm2.Value = System.DBNull.Value;
                    // prm2.Value =Convert.ToDateTime(todate).ToString("dd-MMMM-yyyy");
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
                    prm2.Value = Convert.ToDateTime(dateto).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm2);



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

                OracleParameter tmp2 = new OracleParameter("Adtype", OracleType.VarChar, 50);
                tmp2.Direction = ParameterDirection.Input;
                tmp2.Value = temp2;
                objOraclecommand.Parameters.Add(tmp2);


                OracleParameter tmp3 = new OracleParameter("pub_cent", OracleType.VarChar, 50);
                tmp3.Direction = ParameterDirection.Input;
                tmp3.Value = temp3;
                objOraclecommand.Parameters.Add(tmp3);



                OracleParameter tmp4 = new OracleParameter("category", OracleType.VarChar, 50);
                tmp4.Direction = ParameterDirection.Input;
                tmp4.Value = temp4;
                objOraclecommand.Parameters.Add(tmp4);


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
                objOraclecommand = GetCommand("Bill_Reportnew", ref objOracleConnection);
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



        public DataSet bindProductcategory(string compcode)//, string product, string value)
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
                objOraclecommand = GetCommand("websp_Product1.websp_Product1_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm6 = new OracleParameter("compcode", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = compcode;
                objOraclecommand.Parameters.Add(prm6);

                objOraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;

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

        public DataSet bindregion(string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("Sp_Region.sp_region_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
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


        public DataSet state(string compcode)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("Websp_Get_State", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);



                objOraclecommand.Parameters.Add("get_state", OracleType.Cursor);
                objOraclecommand.Parameters["get_state"].Direction = ParameterDirection.Output;

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
                objOraclecommand = GetCommand("Bill_Reportnew", ref objOracleConnection);
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
                if (dateformat == "dd/mm/yyyy" && fromdate != "" && fromdate != null && fromdate != "0")
                {
                    string[] arr = fromdate.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    fromdate = mm + "/" + dd + "/" + yy;
                }
                else
                {
                    prm9.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm4 = new OracleParameter("dateto", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                if (dateformat == "dd/mm/yyyy")
                {
                    string[] arr = dateto.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    dateto = mm + "/" + dd + "/" + yy;
                }
                else
                {
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


        public DataSet spfun123(string adtype, string adcategory, string fromdate, string dateto, string pubname, string pubcent, string compcode, string edition, string dateformat, string descid, string ascdesc, string agname, string clientname, string status, string hold)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {

                objOracleConnection.Open();


                objOraclecommand = GetCommand("report", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter temp1 = new OracleParameter("agname", OracleType.VarChar);
                temp1.Direction = ParameterDirection.Input;
                if (agname == "0" || agname == "")
                {
                    temp1.Value = System.DBNull.Value;
                }
                else
                {
                    temp1.Value = agname;
                }
                objOraclecommand.Parameters.Add(temp1);

                OracleParameter temp2 = new OracleParameter("clientname", OracleType.VarChar);
                temp2.Direction = ParameterDirection.Input;
                temp2.Value = clientname;
                objOraclecommand.Parameters.Add(temp2);


                OracleParameter prm1 = new OracleParameter("adtype", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                if (adtype == "0")
                {
                    prm1.Value = System.DBNull.Value;
                }
                else
                {
                    prm1.Value = adtype;
                }
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("adcategory", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                if (adcategory == "")
                {
                    prm2.Value = System.DBNull.Value;
                }
                else
                {
                    prm2.Value = adcategory;
                }
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("fromdate", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                if (fromdate == "")
                {
                    prm3.Value = System.DBNull.Value;
                }
                else
                {

                    if (dateformat == "dd/mm/yyyy" && fromdate != "" && fromdate != null)
                    {
                        string[] arr = fromdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        fromdate = mm + "/" + dd+ "/" + yy;
                    }
                    prm3.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("dateto", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                if (dateto == "")
                {
                    prm4.Value = System.DBNull.Value;
                }
                else
                {

                    if (dateformat == "dd/mm/yyyy" && dateto != "" && dateto != null)
                    {

                        string[] arr = dateto.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        dateto = mm + "/" + dd + "/" + yy;
                    }
                    prm4.Value = Convert.ToDateTime(dateto).ToString("dd-MMMM-yyyy"); ;
                }
                objOraclecommand.Parameters.Add(prm4);



                OracleParameter prm5 = new OracleParameter("compcode", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = compcode;
                objOraclecommand.Parameters.Add(prm5);


                OracleParameter prm6 = new OracleParameter("pub_name", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                if (pubname == "0")
                {
                    prm6.Value = System.DBNull.Value;
                }
                else
                {
                    prm6.Value = pubname;
                }
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("pub_cent", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                if (pubcent == "0")
                {
                    prm7.Value = System.DBNull.Value;
                }
                else
                {
                    prm7.Value = pubcent;
                }
                objOraclecommand.Parameters.Add(prm7);


                OracleParameter temp3 = new OracleParameter("status", OracleType.VarChar);
                temp3.Direction = ParameterDirection.Input;
                temp3.Value = status;
                objOraclecommand.Parameters.Add(temp3);


                OracleParameter prm8 = new OracleParameter("edition", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                if (edition == "0")
                {
                    prm8.Value = System.DBNull.Value;
                }
                else
                {
                    prm8.Value = edition;
                }
                objOraclecommand.Parameters.Add(prm8);


                OracleParameter prm9 = new OracleParameter("dateformat", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = dateformat;
                objOraclecommand.Parameters.Add(prm9);


                OracleParameter temp4 = new OracleParameter("hold", OracleType.VarChar);
                temp4.Direction = ParameterDirection.Input;
                temp4.Value = hold;
                objOraclecommand.Parameters.Add(temp4);

                OracleParameter prm10 = new OracleParameter("descid", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = descid;
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("ascdesc", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = ascdesc;
                objOraclecommand.Parameters.Add(prm11);

                objOraclecommand.Parameters.Add("p_report", OracleType.Cursor);
                objOraclecommand.Parameters["p_report"].Direction = ParameterDirection.Output;

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





        public DataSet spAgency123(string agname, string adtype, string adcategory, string fromdate, string dateto, string pubname, string pubcent, string compcode, string edition, string dateformat, string descid, string ascdesc, string clientname, string status, string hold)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {

                objOracleConnection.Open();
                //objOraclecommand = GetCommand("Report1.Report1_p", ref objOracleConnection);
                //objOraclecommand.CommandType = CommandType.StoredProcedure;

                objOraclecommand = GetCommand("REPORT", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter temp1 = new OracleParameter("agname", OracleType.VarChar);
                temp1.Direction = ParameterDirection.Input;
                if (agname == "0" || agname == "")
                {
                    temp1.Value = System.DBNull.Value;
                }
                else
                {
                    temp1.Value = agname;
                }
                objOraclecommand.Parameters.Add(temp1);

                OracleParameter temp2 = new OracleParameter("clientname", OracleType.VarChar);
                temp2.Direction = ParameterDirection.Input;
                temp2.Value = clientname;
                objOraclecommand.Parameters.Add(temp2);


                OracleParameter prm1 = new OracleParameter("adtype", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                if (adtype == "0")
                {
                    prm1.Value = System.DBNull.Value;
                }
                else
                {
                    prm1.Value = adtype;
                }
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("adcategory", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                if (adcategory == "")
                {
                    prm2.Value = System.DBNull.Value;
                }
                else
                {
                    prm2.Value = adcategory;
                }
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("fromdate", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                if (fromdate == "")
                {
                    prm3.Value = System.DBNull.Value;
                }
                else
                {

                    if (dateformat == "dd/mm/yyyy" && fromdate != "" && fromdate != null)
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
                if (dateto == "")
                {
                    prm4.Value = System.DBNull.Value;
                }
                else
                {

                    if (dateformat == "dd/mm/yyyy" && dateto != "" && dateto != null)
                    {

                        string[] arr = dateto.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        dateto = mm + "/" + dd + "/" + yy;
                    }
                    prm4.Value = Convert.ToDateTime(dateto).ToString("dd-MMMM-yyyy"); ;
                }
                objOraclecommand.Parameters.Add(prm4);



                OracleParameter prm5 = new OracleParameter("compcode", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = compcode;
                objOraclecommand.Parameters.Add(prm5);


                OracleParameter prm6 = new OracleParameter("pub_name", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                if (pubname == "0")
                {
                    prm6.Value = System.DBNull.Value;
                }
                else
                {
                    prm6.Value = pubname;
                }
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("pub_cent", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                if (pubcent == "0")
                {
                    prm7.Value = System.DBNull.Value;
                }
                else
                {
                    prm7.Value = pubcent;
                }
                objOraclecommand.Parameters.Add(prm7);


                OracleParameter temp3 = new OracleParameter("status", OracleType.VarChar);
                temp3.Direction = ParameterDirection.Input;
                temp3.Value = status;
                objOraclecommand.Parameters.Add(temp3);


                OracleParameter prm8 = new OracleParameter("edition", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                if (edition == "0")
                {
                    prm8.Value = System.DBNull.Value;
                }
                else
                {
                    prm8.Value = edition;
                }
                objOraclecommand.Parameters.Add(prm8);


                OracleParameter prm9 = new OracleParameter("dateformat", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = dateformat;
                objOraclecommand.Parameters.Add(prm9);


                OracleParameter temp4 = new OracleParameter("hold", OracleType.VarChar);
                temp4.Direction = ParameterDirection.Input;
                if (hold == "")
                {
                    temp4.Value = System.DBNull.Value;
                }
                else
                {
                    temp4.Value = hold;
                }
                objOraclecommand.Parameters.Add(temp4);

                OracleParameter prm10 = new OracleParameter("descid", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                if (descid == "")
                {
                    prm10.Value = System.DBNull.Value;
                }
                else
                {
                    prm10.Value = descid;
                }
               
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("ascdesc", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                if (ascdesc == "")
                {
                    prm11.Value = System.DBNull.Value;
                }
                else
                {
                    prm11.Value = ascdesc;
                }
              
                objOraclecommand.Parameters.Add(prm11);

                objOraclecommand.Parameters.Add("p_report", OracleType.Cursor);
                objOraclecommand.Parameters["p_report"].Direction = ParameterDirection.Output;

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





        public DataSet spclient123(string cliname, string adtype, string adcategory, string fromdate, string dateto, string pubname, string pubcent, string compcode, string edition, string dateformat, string descid, string ascdesc, string agname, string status, string hold)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("report", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter temp1 = new OracleParameter("agname", OracleType.VarChar);
                temp1.Direction = ParameterDirection.Input;
                if (agname == "0" || agname == "")
                {
                    temp1.Value = System.DBNull.Value;
                }
                else
                {
                    temp1.Value = agname;
                }
                objOraclecommand.Parameters.Add(temp1);



                OracleParameter temp2 = new OracleParameter("clientname", OracleType.VarChar);
                temp2.Direction = ParameterDirection.Input;
                if (cliname == "0")
                {
                    temp2.Value = System.DBNull.Value;
                }
                else
                {
                    temp2.Value = cliname;
                }
                objOraclecommand.Parameters.Add(temp2);



                //OracleParameter temp2 = new OracleParameter("clientname", OracleType.VarChar);
                //temp2.Direction = ParameterDirection.Input;
                //temp2.Value = cliname;
                //objOraclecommand.Parameters.Add(temp2);


                OracleParameter prm1 = new OracleParameter("adtype", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                if (adtype == "0")
                {
                    prm1.Value = System.DBNull.Value;
                }
                else
                {
                    prm1.Value = adtype;
                }
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("adcategory", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                if (adcategory == "")
                {
                    prm2.Value = System.DBNull.Value;
                }
                else
                {
                    prm2.Value = adcategory;
                }
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("fromdate", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                if (fromdate == "")
                {
                    prm3.Value = System.DBNull.Value;
                }
                else
                {

                    if (dateformat == "dd/mm/yyyy" && fromdate != "" && fromdate != null)
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
                if (dateto == "")
                {
                    prm4.Value = System.DBNull.Value;
                }
                else
                {

                    if (dateformat == "dd/mm/yyyy" && dateto != "" && dateto != null)
                    {

                        string[] arr = dateto.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        dateto = mm + "/" + dd + "/" + yy;
                    }
                    prm4.Value = Convert.ToDateTime(dateto).ToString("dd-MMMM-yyyy"); ;
                }
                objOraclecommand.Parameters.Add(prm4);



                OracleParameter prm5 = new OracleParameter("compcode", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = compcode;
                objOraclecommand.Parameters.Add(prm5);


                OracleParameter prm6 = new OracleParameter("pub_name", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                if (pubname == "0")
                {
                    prm6.Value = System.DBNull.Value;
                }
                else
                {
                    prm6.Value = pubname;
                }
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("pub_cent", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                if (pubcent == "0")
                {
                    prm7.Value = System.DBNull.Value;
                }
                else
                {
                    prm7.Value = pubcent;
                }
                objOraclecommand.Parameters.Add(prm7);


                OracleParameter temp3 = new OracleParameter("status", OracleType.VarChar);
                temp3.Direction = ParameterDirection.Input;
                temp3.Value = status;
                objOraclecommand.Parameters.Add(temp3);


                OracleParameter prm8 = new OracleParameter("edition", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                if (edition == "0")
                {
                    prm8.Value = System.DBNull.Value;
                }
                else
                {
                    prm8.Value = edition;
                }
                objOraclecommand.Parameters.Add(prm8);


                OracleParameter prm9 = new OracleParameter("dateformat", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = dateformat;
                objOraclecommand.Parameters.Add(prm9);


                OracleParameter temp4 = new OracleParameter("hold", OracleType.VarChar);
                temp4.Direction = ParameterDirection.Input;
                temp4.Value = hold;
                objOraclecommand.Parameters.Add(temp4);

                OracleParameter prm10 = new OracleParameter("descid", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = descid;
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("ascdesc", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = ascdesc;
                objOraclecommand.Parameters.Add(prm11);

                objOraclecommand.Parameters.Add("p_report", OracleType.Cursor);
                objOraclecommand.Parameters["p_report"].Direction = ParameterDirection.Output;

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




        //public DataSet edition(string pubcode, string centercode, string compcode)
        //{
        //    OracleConnection objOracleConnection;
        //    OracleCommand objOraclecommand;
        //    DataSet objDataSet = new DataSet();
        //    objOracleConnection = GetConnection();

        //    OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        //    try
        //    {


        //        objOracleConnection.Open();
        //        objOraclecommand = GetCommand("edition_proc.edition_proc_p", ref objOracleConnection);
        //        objOraclecommand.CommandType = CommandType.StoredProcedure;


        //        OracleParameter prm3 = new OracleParameter("pubcode", OracleType.VarChar, 50);
        //        prm3.Direction = ParameterDirection.Input;
        //        prm3.Value = pubcode;
        //        objOraclecommand.Parameters.Add(prm3);

        //        OracleParameter prm2 = new OracleParameter("centercode", OracleType.VarChar, 50);
        //        prm2.Direction = ParameterDirection.Input;
        //        prm2.Value = centercode;
        //        objOraclecommand.Parameters.Add(prm2);

        //        OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
        //        prm1.Direction = ParameterDirection.Input;
        //        prm1.Value = compcode;
        //        objOraclecommand.Parameters.Add(prm1);

        //        objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
        //        objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

        //        objorclDataAdapter.SelectCommand = objOraclecommand;
        //        objorclDataAdapter.Fill(objDataSet);
        //        return objDataSet;


        //    }
        //    catch (OracleException objException)
        //    {
        //        throw (objException);
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




       
    
    }
}