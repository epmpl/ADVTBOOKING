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
    /// Summary description for bill
    /// </summary>
    public class bill:orclconnection
    {
        public bill()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataSet barter_report(string frmdt, string todate, string compcode, string region, string product, string dateformate, string descid, string ascdesc, string temp_agname, string temp_adtype, string temp_pubcent, string temp_edition, string temp_agency, string temp_category)
        {

            //SqlConnection objOracleConnection = new SqlConnection();
            //SqlCommand objOraclecommand;
            //SqlCommand = GetConnection();
            //SqlDataAdapter objorclDataAdapter = new SqlDataAdapter();
            //DataSet objDataSet = new DataSet();

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
                //prm1.Value = frmdt;                
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
                    prm2.Value =Convert.ToDateTime(todate).ToString("dd-MMMM-yyyy");
                }
                else
                {
                    prm2.Value = System.DBNull.Value;
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

                OracleParameter tmp = new OracleParameter("agname", OracleType.VarChar, 50);
                tmp.Direction = ParameterDirection.Input;
                tmp.Value = temp_agname;
                objOraclecommand.Parameters.Add(tmp);

                OracleParameter tmp2 = new OracleParameter("Adtype", OracleType.VarChar, 50);
                tmp2.Direction = ParameterDirection.Input;
                tmp2.Value = temp_adtype;
                objOraclecommand.Parameters.Add(tmp2);


                OracleParameter temp3 = new OracleParameter("pub_cent", OracleType.VarChar, 50);
                temp3.Direction = ParameterDirection.Input;
                temp3.Value = temp_pubcent;
                objOraclecommand.Parameters.Add(temp3);



                OracleParameter tmp4 = new OracleParameter("category", OracleType.VarChar, 50);
                tmp4.Direction = ParameterDirection.Input;
                tmp4.Value = temp_category;
                objOraclecommand.Parameters.Add(tmp4);


                OracleParameter tmp5 = new OracleParameter("edition", OracleType.VarChar, 50);
                tmp5.Direction = ParameterDirection.Input;
                tmp5.Value = temp_edition;
                objOraclecommand.Parameters.Add(tmp5);



                OracleParameter tmp6 = new OracleParameter("agency", OracleType.VarChar, 50);
                tmp6.Direction = ParameterDirection.Input;
                tmp6.Value = temp_agency;
                objOraclecommand.Parameters.Add(tmp6);

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


       /* public OracleDataReader barter_reportexcel(string frmdt, string todate, string compcode, string region, string product, string dateformate, string temp1, string temp2, string temp3, string temp4, string temp5, string temp6, string temp7, string temp8)
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
                if (frmdt != "")
                {
                    prm1.Value =Convert.ToDateTime(frmdt).ToString("dd-MMMM-yyyy"); 
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


                OracleParameter prm5 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = compcode;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("dateformat", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = dateformate;
                objOraclecommand.Parameters.Add(prm6);

                //-------------------
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

                OracleParameter tmp7 = new OracleParameter("descid", OracleType.VarChar, 50);
                tmp7.Direction = ParameterDirection.Input;
                tmp7.Value = temp7;
                objOraclecommand.Parameters.Add(tmp7);



                OracleParameter tmp8 = new OracleParameter("ascdesc", OracleType.VarChar, 50);
                tmp8.Direction = ParameterDirection.Input;
                tmp8.Value = temp8;
                objOraclecommand.Parameters.Add(tmp8);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                //---------------------------
                
                objorclDataAdapter.SelectCommand = objOraclecommand;
                OracleDataReader objdatareadre = objOraclecommand.ExecuteReader();
                //OracleDataReader objdatareadre = objOraclecommand.ExecuteReader();

                return objdatareadre;


            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                //CloseConnection(ref objOracleConnection);
            }


        }
        */

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


        public OracleDataReader value_pubexcel(string frmdt, string todate, string compcode, string product, string dateformate, string temp1, string temp2, string temp3, string temp4, string temp5, string temp6, string temp7, string temp8,string temp9)
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
                    prm2.Value =Convert.ToDateTime(todate).ToString("dd-MMMM-yyyy") ;
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

                OracleParameter tmp7 = new OracleParameter("descid", OracleType.VarChar, 50);
                tmp7.Direction = ParameterDirection.Input;
                tmp7.Value = temp7;
                objOraclecommand.Parameters.Add(tmp7);



                OracleParameter tmp8 = new OracleParameter("ascdesc", OracleType.VarChar, 50);
                tmp8.Direction = ParameterDirection.Input;
                tmp8.Value = temp8;
                objOraclecommand.Parameters.Add(tmp8);

                OracleParameter tmp9 = new OracleParameter("Region", OracleType.VarChar, 50);
                tmp9.Direction = ParameterDirection.Input;
                tmp9.Value = temp9;
                objOraclecommand.Parameters.Add(tmp9);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;


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
                //CloseConnection(ref objOracleConnection);
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
                objOraclecommand = GetCommand("bill_report.bill_report_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("fromdate", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                if (frmdt != "")
                {
                    prm1.Value =Convert.ToDateTime(frmdt).ToString("dd-MMMM-yyyy");
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
                    prm2.Value =Convert.ToDateTime(todate).ToString("dd-MMMM-yyyy");
                }
                else
                {
                    prm2.Value = System.DBNull.Value;
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

        public OracleDataReader valuereportexcel(string frmdt, string todate, string compcode, string region, string product, string dateformate, string temp1, string temp2, string temp3, string temp4, string temp5, string temp6, string temp7, string temp8)
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
                objOraclecommand = GetCommand("bill_report.bill_report_p", ref objOracleConnection);
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


                OracleParameter prm5 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = compcode;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("dateformat", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = dateformate;
                objOraclecommand.Parameters.Add(prm6);

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

                OracleParameter tmp7 = new OracleParameter("descid", OracleType.VarChar, 50);
                tmp7.Direction = ParameterDirection.Input;
                tmp7.Value = temp7;
                objOraclecommand.Parameters.Add(tmp7);



                OracleParameter tmp8 = new OracleParameter("ascdesc", OracleType.VarChar, 50);
                tmp8.Direction = ParameterDirection.Input;
                tmp8.Value = temp8;
                objOraclecommand.Parameters.Add(tmp8);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;


                objorclDataAdapter.SelectCommand = objOraclecommand;
                OracleDataReader objdatareadre = objOraclecommand.ExecuteReader();

                return objdatareadre;
                //objorclDataAdapter.Fill(objDataSet);

                //return objDataSet;



            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                //CloseConnection(ref objOracleConnection);
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

        public OracleDataReader regionrebateexcel(string frmdt, string todate, string compcode, string region, string product, string category, string dateformate, string temp1, string temp2, string temp3, string temp4, string temp5, string temp6, string temp7)
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



                OracleParameter tmp4 = new OracleParameter("ascdesc", OracleType.VarChar, 50);
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

                OracleParameter tmp7 = new OracleParameter("descid", OracleType.VarChar, 50);
                tmp7.Direction = ParameterDirection.Input;
                tmp7.Value = temp7;
                objOraclecommand.Parameters.Add(tmp7);



                //OracleParameter tmp8 = new OracleParameter("ascdesc", OracleType.VarChar, 50);
                //tmp8.Direction = ParameterDirection.Input;
                //tmp8.Value = temp8;
                //objOraclecommand.Parameters.Add(tmp8);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;


                objorclDataAdapter.SelectCommand = objOraclecommand;
                OracleDataReader objdatareadre = objOraclecommand.ExecuteReader();

                return objdatareadre;
                //objorclDataAdapter.Fill(objDataSet);

                //return objDataSet;



            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                //CloseConnection(ref objOracleConnection);
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
                objOraclecommand = GetCommand("bill_report.bill_report_p", ref objOracleConnection);
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



                OracleParameter tmp4 = new OracleParameter("Region", OracleType.VarChar, 50);
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

                //OracleParameter tmp7 = new OracleParameter("descid", OracleType.VarChar, 50);
                //tmp7.Direction = ParameterDirection.Input;
                //tmp7.Value = temp7;
                //objOraclecommand.Parameters.Add(tmp7);



                //OracleParameter tmp8 = new OracleParameter("ascdesc", OracleType.VarChar, 50);
                //tmp8.Direction = ParameterDirection.Input;
                //tmp8.Value = temp8;
                //objOraclecommand.Parameters.Add(tmp8);

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
        public OracleDataReader pubrebateexcel(string frmdt, string todate, string compcode, string category, string product, string dateformate, string temp1, string temp2, string temp3, string temp4, string temp5, string temp6, string temp7, string temp8)
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



                OracleParameter tmp4 = new OracleParameter("Region", OracleType.VarChar, 50);
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

                OracleParameter tmp7 = new OracleParameter("descid", OracleType.VarChar, 50);
                tmp7.Direction = ParameterDirection.Input;
                tmp7.Value = temp7;
                objOraclecommand.Parameters.Add(tmp7);



                OracleParameter tmp8 = new OracleParameter("ascdesc", OracleType.VarChar, 50);
                tmp8.Direction = ParameterDirection.Input;
                tmp8.Value = temp8;
                objOraclecommand.Parameters.Add(tmp8);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;



                objorclDataAdapter.SelectCommand = objOraclecommand;
                OracleDataReader objdatareadre = objOraclecommand.ExecuteReader();

                return objdatareadre;
                //objorclDataAdapter.Fill(objDataSet);

                //return objDataSet;



            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                //CloseConnection(ref objOracleConnection);
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
                objOraclecommand = GetCommand("bill_report.bill_report_p", ref objOracleConnection);
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





        public OracleDataReader Extra_reportexcel(string frmdt, string todate, string compcode, string region, string product, string dateformate, string category, string temp1, string temp2, string temp3, string temp4, string temp5, string temp6, string temp7)
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



                OracleParameter tmp4 = new OracleParameter("ascdesc", OracleType.VarChar, 50);
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

                OracleParameter tmp7 = new OracleParameter("descid", OracleType.VarChar, 50);
                tmp7.Direction = ParameterDirection.Input;
                tmp7.Value = temp7;
                objOraclecommand.Parameters.Add(tmp7);



                //OracleParameter tmp8 = new OracleParameter("ascdesc", OracleType.VarChar, 50);
                //tmp8.Direction = ParameterDirection.Input;
                //tmp8.Value = temp8;
                //objOraclecommand.Parameters.Add(tmp8);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;



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
                //CloseConnection(ref objOracleConnection);
            }


        }

        public DataSet bindregionname(string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("sp_region.sp_region_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm5 = new OracleParameter("Compcode", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = compcode;
                objOraclecommand.Parameters.Add(prm5);
                
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

        public DataSet bindProductcategory(string region, string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("An_publicationreport.An_publicationreport_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("Compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("regioncode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = region;
                objOraclecommand.Parameters.Add(prm2);




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


       /* public DataSet billingonscreen(string fromdate, string dateto, string region, string product, string category, string compcode, string dateformat, string descid, string ascdesc,string temp_agname, string temp_adtype, string temp_pubcent, string temp_edition, string temp_agency,string executive)
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
                if (region != "0")
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

        }*/

        public OracleDataReader Billingrepexcel(string fromdate, string dateto, string region, string product, string category, string compcode, string dateformat, string temp_agname, string temp_adtype, string temp_pubcent, string temp_category, string temp_edition, string temp_agency,string temp7,string executive)
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
                if (region != "0")
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


                OracleParameter prm33 = new OracleParameter("fromdate", OracleType.VarChar, 50);
                prm33.Direction = ParameterDirection.Input;
                if (fromdate != "0")
                {
                    prm33.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");             ;
                }
                else
                {
                    prm33.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm33);

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

                //-------------------------------
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

                OracleParameter temp4 = new OracleParameter("agency", OracleType.VarChar, 50);
                temp4.Direction = ParameterDirection.Input;
                temp4.Value = temp_category;
                objOraclecommand.Parameters.Add(temp4);

                OracleParameter temp5 = new OracleParameter("descid", OracleType.VarChar, 50);
                temp5.Direction = ParameterDirection.Input;
                temp5.Value = temp_agency;
                objOraclecommand.Parameters.Add(temp5);

                OracleParameter temp6 = new OracleParameter("ascdesc", OracleType.VarChar, 50);
                temp6.Direction = ParameterDirection.Input;
                temp6.Value = temp7;
                objOraclecommand.Parameters.Add(temp6);

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

                //------------------------------


               
                objorclDataAdapter.SelectCommand = objOraclecommand;
                OracleDataReader objdatareadre = objOraclecommand.ExecuteReader();

                return objdatareadre;
                //objorclDataAdapter.Fill(objDataSet);

                //return objDataSet;



            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                //CloseConnection(ref objOracleConnection);
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
                objOraclecommand = GetCommand("bill_report.bill_report_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("region", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                if (region != "0")
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

               
                OracleParameter prm3 = new OracleParameter("fromdate", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                if (fromdate != "0")
                {
                    prm3.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");
                }
                else
                {
                    prm3.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm3);

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

                //OracleParameter tmp7 = new OracleParameter("descid", OracleType.VarChar, 50);
                //tmp7.Direction = ParameterDirection.Input;
                //tmp7.Value = temp7;
                //objOraclecommand.Parameters.Add(tmp7);



                //OracleParameter tmp8 = new OracleParameter("ascdesc", OracleType.VarChar, 50);
                //tmp8.Direction = ParameterDirection.Input;
                //tmp8.Value = temp8;
                //objOraclecommand.Parameters.Add(tmp8);

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


        public OracleDataReader retainexcel(string fromdate, string dateto, string region, string product, string compcode, string dateformat, string temp1, string temp2, string temp3, string temp4, string temp5, string temp6, string temp7, string temp8)
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
                OracleParameter prm1 = new OracleParameter("region", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                if (region != "0")
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

                //OracleParameter prm3 = new OracleParameter("category", OracleType.VarChar, 50);
                //prm3.Direction = ParameterDirection.Input;
                //if (category != "0")
                //{
                //    prm3.Value = category;
                //}
                //else
                //{
                //    prm3.Value = System.DBNull.Value;
                //}
                //objOraclecommand.Parameters.Add(prm3);


                OracleParameter prm3 = new OracleParameter("fromdate", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                if (fromdate != "0")
                {
                    prm3.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");
                }
                else
                {
                    prm3.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm3);

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

                OracleParameter tmp7 = new OracleParameter("descid", OracleType.VarChar, 50);
                tmp7.Direction = ParameterDirection.Input;
                tmp7.Value = temp7;
                objOraclecommand.Parameters.Add(tmp7);



                OracleParameter tmp8 = new OracleParameter("ascdesc", OracleType.VarChar, 50);
                tmp8.Direction = ParameterDirection.Input;
                tmp8.Value = temp8;
                objOraclecommand.Parameters.Add(tmp8);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                
                objorclDataAdapter.SelectCommand = objOraclecommand;
                OracleDataReader objdatareadre = objOraclecommand.ExecuteReader();

                return objdatareadre;
                //objorclDataAdapter.Fill(objDataSet);

                //return objDataSet;



            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                //CloseConnection(ref objOracleConnection);
            }


        }


        public DataSet retainexcel11(string fromdate, string dateto, string region, string product, string compcode, string dateformat, string temp1, string temp2, string temp3, string temp4, string temp5, string temp6, string temp7, string temp8)
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
                OracleParameter prm1 = new OracleParameter("region", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                if (region != "0")
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

                //OracleParameter prm3 = new OracleParameter("category", OracleType.VarChar, 50);
                //prm3.Direction = ParameterDirection.Input;
                //if (category != "0")
                //{
                //    prm3.Value = category;
                //}
                //else
                //{
                //    prm3.Value = System.DBNull.Value;
                //}
                //objOraclecommand.Parameters.Add(prm3);


                OracleParameter prm3 = new OracleParameter("fromdate", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                if (fromdate != "0")
                {
                    prm3.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");
                }
                else
                {
                    prm3.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm3);

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

                OracleParameter tmp7 = new OracleParameter("descid", OracleType.VarChar, 50);
                tmp7.Direction = ParameterDirection.Input;
                tmp7.Value = temp7;
                objOraclecommand.Parameters.Add(tmp7);



                OracleParameter tmp8 = new OracleParameter("ascdesc", OracleType.VarChar, 50);
                tmp8.Direction = ParameterDirection.Input;
                tmp8.Value = temp8;
                objOraclecommand.Parameters.Add(tmp8);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;


                //objorclDataAdapter.SelectCommand = objOraclecommand;
                //OracleDataReader objdatareadre = objOraclecommand.ExecuteReader();

                //return objdatareadre;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return objDataSet;

                //objorclDataAdapter.Fill(objDataSet);

                //return objDataSet;



            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                //CloseConnection(ref objOracleConnection);
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
                //objSqlDataAdapter = new SqlDataAdapter();
                //objSqlDataAdapter = new OracleDataAdapter();
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



        public DataSet payment(string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("an_payment.an_payment_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm5 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = compcode;
                objOraclecommand.Parameters.Add(prm5);

                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

                //objSqlDataAdapter = new SqlDataAdapter();
                objorclDataAdapter = new OracleDataAdapter();
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




        public DataSet retainname(string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("an_retainname.an_retainname_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm5 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = compcode;
                objOraclecommand.Parameters.Add(prm5);


                //objSqlDataAdapter = new SqlDataAdapter();
                objorclDataAdapter = new OracleDataAdapter();
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

        public DataSet billstatus()
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("an_billstatus.an_billstatus_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                //objOraclecommandmand.Parameters.Add("@compcode", SqlDbType.VarChar);
                //objOraclecommandmand.Parameters["@compcode"].Value = compcode;
                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                //objSqlDataAdapter = new SqlDataAdapter();
                objorclDataAdapter = new OracleDataAdapter();
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
        public DataSet drillout(string fromdate, string dateto, string region, string product, string category, string compcode, string dateformat, string agency, string client, string publication, string adtype, string payment, string billstatus, string myrange, string maxrange, string descid, string ascdesc,string temp_pubname,string temp_retain)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("bill_drillout.bill_drillout_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("fromdate", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                if (fromdate != "0")
                {
                    prm1.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy"); 
                }
                else
                {
                    prm1.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("dateto", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                if (dateto != "0")
                {
                    prm2.Value = Convert.ToDateTime(dateto).ToString("dd-MMMM-yyyy");
                }
                else
                {
                    prm2.Value = System.DBNull.Value;
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




                OracleParameter prm4 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = compcode;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("dateformat", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = dateformat;
                objOraclecommand.Parameters.Add(prm5);



                OracleParameter prm6 = new OracleParameter("agency", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                if (agency != "0")
                {
                    prm6.Value = agency;
                }
                else
                {
                    prm6.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("client", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                
                if (client != "0")
                {
                    prm7.Value = client;
                }
                else
                {
                    prm7.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("pub_cent", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                if (publication != "0")
                {
                    prm8.Value = publication;
                }
                else
                {
                    prm8.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("adtype", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                if (adtype != "0")
                {
                    prm9.Value = adtype;
                }
                else
                {
                    prm9.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("payment", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                if (payment != "0")
                {
                    prm10.Value = payment;
                }
                else
                {
                    prm10.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("billstatus", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                if (billstatus != "0")
                {
                    prm11.Value = billstatus;
                }
                else
                {
                    prm11.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("myrange", OracleType.VarChar, 50);
                prm12.Direction = ParameterDirection.Input;
                if (myrange != "0")
                {
                    prm12.Value = myrange;
                }
                else
                {
                    prm12.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm12);

                OracleParameter prm13 = new OracleParameter("maxrange", OracleType.VarChar, 50);
                prm13.Direction = ParameterDirection.Input;
                if (maxrange != "0")
                {
                    prm13.Value = maxrange;
                }
                else
                {
                    prm13.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm13);

                OracleParameter prm14 = new OracleParameter("descid", OracleType.VarChar, 50);
                prm14.Direction = ParameterDirection.Input;
                if (descid != "0")
                {
                    prm14.Value = descid;
                }
                else
                {
                    prm14.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm14);

                OracleParameter prm15 = new OracleParameter("ascdesc", OracleType.VarChar, 50);
                prm15.Direction = ParameterDirection.Input;
                if (ascdesc != "0")
                {
                    prm15.Value = ascdesc;
                }
                else
                {
                    prm15.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm15);

                OracleParameter temp = new OracleParameter("retain_na", OracleType.VarChar, 50);
                temp.Direction = ParameterDirection.Input;
                temp.Value = temp_retain;
                objOraclecommand.Parameters.Add(temp);

                OracleParameter temp2 = new OracleParameter("pub_name", OracleType.VarChar, 50);
                temp2.Direction = ParameterDirection.Input;
                temp2.Value = temp_pubname;
                objOraclecommand.Parameters.Add(temp2);


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




        public OracleDataReader drillout_excelbill(string fromdate, string dateto, string region, string product, string category, string compcode, string dateformat, string agency, string client, string publication, string adtype, string payment, string billstatus, string myrange, string maxrange, string temp_adtype,string temp_agency,string temp_retain,string temp_pubname)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("bill_drillout.bill_drillout_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("fromdate", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                if (fromdate != "0")
                {
                    prm1.Value =Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");
                }
                else
                {
                    prm1.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("dateto", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                if (dateto != "0")
                {
                    prm2.Value = Convert.ToDateTime(dateto).ToString("dd-MMMM-yyyy");
                }
                else
                {
                    prm2.Value = System.DBNull.Value;
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




                OracleParameter prm4 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = compcode;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("dateformat", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = dateformat;
                objOraclecommand.Parameters.Add(prm5);



                OracleParameter prm6 = new OracleParameter("agency", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                if (agency != "0")
                {
                    prm6.Value = agency;
                }
                else
                {
                    prm6.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("client", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;

                if (client != "0")
                {
                    prm7.Value = client;
                }
                else
                {
                    prm7.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("pub_cent", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                if (publication != "0")
                {
                    prm8.Value = publication;
                }
                else
                {
                    prm8.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("adtype", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                if (adtype != "0")
                {
                    prm9.Value = adtype;
                }
                else
                {
                    prm9.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("payment", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                if (payment != "0")
                {
                    prm10.Value = payment;
                }
                else
                {
                    prm10.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("billstatus", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                if (billstatus != "0")
                {
                    prm11.Value = billstatus;
                }
                else
                {
                    prm11.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("myrange", OracleType.VarChar, 50);
                prm12.Direction = ParameterDirection.Input;
                if (myrange != "0")
                {
                    prm12.Value = myrange;
                }
                else
                {
                    prm12.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm12);

                OracleParameter prm13 = new OracleParameter("maxrange", OracleType.VarChar, 50);
                prm13.Direction = ParameterDirection.Input;
                if (maxrange != "0")
                {
                    prm13.Value = maxrange;
                }
                else
                {
                    prm13.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm13);

                OracleParameter temp = new OracleParameter("retain_na", OracleType.VarChar, 50);
                temp.Direction = ParameterDirection.Input;
                temp.Value = temp_retain;
                objOraclecommand.Parameters.Add(temp);

                OracleParameter temp2 = new OracleParameter("pub_name", OracleType.VarChar, 50);
                temp2.Direction = ParameterDirection.Input;
                temp2.Value = temp_pubname;
                objOraclecommand.Parameters.Add(temp2);

                OracleParameter temp3 = new OracleParameter("descid", OracleType.VarChar, 50);
                temp3.Direction = ParameterDirection.Input;
                temp3.Value = temp_adtype;
                objOraclecommand.Parameters.Add(temp3);

                OracleParameter temp4 = new OracleParameter("ascdesc", OracleType.VarChar, 50);
                temp4.Direction = ParameterDirection.Input;
                temp4.Value = temp_agency;
                objOraclecommand.Parameters.Add(temp4);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;


                objorclDataAdapter.SelectCommand = objOraclecommand;
                OracleDataReader objdatareadre = objOraclecommand.ExecuteReader();

                return objdatareadre;
                //objorclDataAdapter.Fill(objDataSet);

                //return objDataSet;



            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                //CloseConnection(ref objOracleConnection);
            }


        }









        public DataSet drillout_barter(string fromdate, string todate, string compcode, string region, string dateformat, string publication, string agency, string client, string billstatus, string payment, string adtype, string descid, string ascdesc, string myrange, string maxrange, string temp_retain , string temp_pubcent, string temp_prod, string temp_category)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("bill_drillout.bill_drillout_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("fromdate", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                if (fromdate != "0")
                {
                    prm1.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");
                }
                else
                {
                    prm1.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("dateto", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                if (todate != "0")
                {
                    prm2.Value = Convert.ToDateTime(todate).ToString("dd-MMMM-yyyy");
                }
                else
                {
                    prm2.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm4 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = compcode;
                objOraclecommand.Parameters.Add(prm4);

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


                OracleParameter prm5 = new OracleParameter("dateformat", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = dateformat;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm8 = new OracleParameter("pub_name", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                if (publication != "0")
                {
                    prm8.Value = publication;
                }

                else
                {
                    prm8.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm6 = new OracleParameter("agency", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                if (agency != "0")
                {
                    prm6.Value = agency;
                }
                else
                {
                    prm6.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("client", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;

                if (client != "0")
                {
                    prm7.Value = client;
                }
                else
                {
                    prm7.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm7);



                OracleParameter prm10 = new OracleParameter("payment", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                if (payment != "0")
                {
                    prm10.Value = payment;
                }
                else
                {
                    prm10.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("billstatus", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                if (billstatus != "0")
                {
                    prm11.Value = billstatus;
                }
                else
                {
                    prm11.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm11);


                OracleParameter prm9 = new OracleParameter("adtype", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                if (adtype != "0")
                {
                    prm9.Value = adtype;
                }
                else
                {
                    prm9.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm14 = new OracleParameter("descid", OracleType.VarChar, 50);
                prm14.Direction = ParameterDirection.Input;
                if (descid != "0")
                {
                    prm14.Value = descid;
                }
                else
                {
                    prm14.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm14);

                OracleParameter prm15 = new OracleParameter("ascdesc", OracleType.VarChar, 50);
                prm15.Direction = ParameterDirection.Input;
                if (ascdesc != "0")
                {
                    prm15.Value = ascdesc;
                }
                else
                {
                    prm15.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm15);

                OracleParameter prm12 = new OracleParameter("myrange", OracleType.VarChar, 50);
                prm12.Direction = ParameterDirection.Input;
                if (myrange != "0")
                {
                    prm12.Value = myrange;
                }
                else
                {
                    prm12.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm12);

                OracleParameter prm13 = new OracleParameter("maxrange", OracleType.VarChar, 50);
                prm13.Direction = ParameterDirection.Input;
                if (maxrange != "0")
                {
                    prm13.Value = maxrange;
                }
                else
                {
                    prm13.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm13);


                OracleParameter temp = new OracleParameter("retain_na", OracleType.VarChar, 50);
                temp.Direction = ParameterDirection.Input;
                temp.Value = temp_retain;
                objOraclecommand.Parameters.Add(temp);

                OracleParameter temp2 = new OracleParameter("product", OracleType.VarChar, 50);
                temp2.Direction = ParameterDirection.Input;
                temp2.Value = temp_prod;
                objOraclecommand.Parameters.Add(temp2);

                OracleParameter temp3 = new OracleParameter("category", OracleType.VarChar, 50);
                temp3.Direction = ParameterDirection.Input;
                temp3.Value = temp_category;
                objOraclecommand.Parameters.Add(temp3);

                OracleParameter temp4 = new OracleParameter("pub_cent", OracleType.VarChar, 50);
                temp4.Direction = ParameterDirection.Input;
                temp4.Value = temp_pubcent;
                objOraclecommand.Parameters.Add(temp4);


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





        public OracleDataReader drillout_excelbarter(string fromdate, string todate, string compcode, string region, string dateformat, string publication, string agency, string client, string billstatus, string payment, string adtype, string myrange, string maxrange, string temp1, string temp2, string temp3, string temp4, string temp5, string temp6)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();


            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("bill_drillout.bill_drillout_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("fromdate", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                if (fromdate != "0")
                {
                    prm1.Value =Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");
                }
                else
                {
                    prm1.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("dateto", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                if (todate != "0")
                {
                    prm2.Value = Convert.ToDateTime(todate).ToString("dd-MMMM-yyyy");
                }
                else
                {
                    prm2.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm4 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = compcode;
                objOraclecommand.Parameters.Add(prm4);

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


                OracleParameter prm5 = new OracleParameter("dateformat", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = dateformat;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm8 = new OracleParameter("pub_name", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                if (publication != "0")
                {
                    prm8.Value = publication;
                }

                else
                {
                    prm8.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm6 = new OracleParameter("agency", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                if (agency != "0")
                {
                    prm6.Value = agency;
                }
                else
                {
                    prm6.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("client", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;

                if (client != "0")
                {
                    prm7.Value = client;
                }
                else
                {
                    prm7.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm7);



                OracleParameter prm10 = new OracleParameter("payment", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                if (payment != "0")
                {
                    prm10.Value = payment;
                }
                else
                {
                    prm10.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("billstatus", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                if (billstatus != "0")
                {
                    prm11.Value = billstatus;
                }
                else
                {
                    prm11.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm11);


                OracleParameter prm9 = new OracleParameter("adtype", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                if (adtype != "0")
                {
                    prm9.Value = adtype;
                }
                else
                {
                    prm9.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm9);

                //OracleParameter prm14 = new OracleParameter("descid", OracleType.VarChar, 50);
                //prm14.Direction = ParameterDirection.Input;
                //if (descid != "0")
                //{
                //    prm14.Value = descid;
                //}
                //else
                //{
                //    prm14.Value = System.DBNull.Value;
                //}
                //objOraclecommand.Parameters.Add(prm14);

                //OracleParameter prm15 = new OracleParameter("ascdesc", OracleType.VarChar, 50);
                //prm15.Direction = ParameterDirection.Input;
                //if (ascdesc != "0")
                //{
                //    prm15.Value = ascdesc;
                //}
                //else
                //{
                //    prm15.Value = System.DBNull.Value;
                //}
                //objOraclecommand.Parameters.Add(prm15);

                OracleParameter prm12 = new OracleParameter("myrange", OracleType.VarChar, 50);
                prm12.Direction = ParameterDirection.Input;
                if (myrange != "0")
                {
                    prm12.Value = myrange;
                }
                else
                {
                    prm12.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm12);

                OracleParameter prm13 = new OracleParameter("maxrange", OracleType.VarChar, 50);
                prm13.Direction = ParameterDirection.Input;
                if (maxrange != "0")
                {
                    prm13.Value = maxrange;
                }
                else
                {
                    prm13.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm13);


                OracleParameter tmp = new OracleParameter("product", OracleType.VarChar, 50);
                tmp.Direction = ParameterDirection.Input;
                tmp.Value = temp1;
                objOraclecommand.Parameters.Add(tmp);

                OracleParameter tmp2 = new OracleParameter("retain_na", OracleType.VarChar, 50);
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


                OracleParameter tmp5 = new OracleParameter("descid", OracleType.VarChar, 50);
                tmp5.Direction = ParameterDirection.Input;
                tmp5.Value = temp5;
                objOraclecommand.Parameters.Add(tmp5);



                OracleParameter tmp6 = new OracleParameter("ascdesc", OracleType.VarChar, 50);
                tmp6.Direction = ParameterDirection.Input;
                tmp6.Value = temp6;
                objOraclecommand.Parameters.Add(tmp6);

                //OracleParameter tmp7 = new OracleParameter("descid", OracleType.VarChar, 50);
                //tmp7.Direction = ParameterDirection.Input;
                //tmp7.Value = temp7;
                //objOraclecommand.Parameters.Add(tmp7);



                //OracleParameter tmp8 = new OracleParameter("ascdesc", OracleType.VarChar, 50);
                //tmp8.Direction = ParameterDirection.Input;
                //tmp8.Value = temp8;
                //objOraclecommand.Parameters.Add(tmp8);

                

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;



                objorclDataAdapter.SelectCommand = objOraclecommand;
                OracleDataReader objdatareadre = objOraclecommand.ExecuteReader();

                return objdatareadre;
                //objorclDataAdapter.Fill(objDataSet);

                //return objDataSet;



            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                //CloseConnection(ref objOracleConnection);
            }


        }




        public OracleDataReader drillout_excelregion(string fromdate, string todate, string compcode, string region, string dateformat, string publication, string agency, string client, string billstatus, string payment, string adtype, string category, string myrange, string maxrange, string temp1, string temp2, string temp3, string temp4, string temp5)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();


            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("bill_drillout.bill_drillout_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("fromdate", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                if (fromdate != "0")
                {
                    prm1.Value =Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");
                }
                else
                {
                    prm1.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("dateto", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                if (todate != "0")
                {
                    prm2.Value = Convert.ToDateTime(todate).ToString("dd-MMMM-yyyy");
                }
                else
                {
                    prm2.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm4 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = compcode;
                objOraclecommand.Parameters.Add(prm4);

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


                OracleParameter prm5 = new OracleParameter("dateformat", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = dateformat;
                objOraclecommand.Parameters.Add(prm5);


                OracleParameter prm8 = new OracleParameter("pub_name", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                if (publication != "0")
                {
                    prm8.Value = publication;
                }

                else
                {
                    prm8.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm6 = new OracleParameter("agency", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                if (agency != "0")
                {
                    prm6.Value = agency;
                }
                else
                {
                    prm6.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("client", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;

                if (client != "0")
                {
                    prm7.Value = client;
                }
                else
                {
                    prm7.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm7);



                OracleParameter prm10 = new OracleParameter("payment", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                if (payment != "0")
                {
                    prm10.Value = payment;
                }
                else
                {
                    prm10.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("billstatus", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                if (billstatus != "0")
                {
                    prm11.Value = billstatus;
                }
                else
                {
                    prm11.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm11);


                OracleParameter prm9 = new OracleParameter("adtype", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                if (adtype != "0")
                {
                    prm9.Value = adtype;
                }
                else
                {
                    prm9.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm9);


                OracleParameter prm14 = new OracleParameter("category", OracleType.VarChar, 50);
                prm14.Direction = ParameterDirection.Input;
                if (category != "0")
                {
                    prm14.Value = category;
                }
                else
                {
                    prm14.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm14);

                OracleParameter prm12 = new OracleParameter("myrange", OracleType.VarChar, 50);
                prm12.Direction = ParameterDirection.Input;
                if (myrange != "0")
                {
                    prm12.Value = myrange;
                }
                else
                {
                    prm12.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm12);

                OracleParameter prm13 = new OracleParameter("maxrange", OracleType.VarChar, 50);
                prm13.Direction = ParameterDirection.Input;
                if (maxrange != "0")
                {
                    prm13.Value = maxrange;
                }
                else
                {
                    prm13.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm13);

                OracleParameter tmp = new OracleParameter("product", OracleType.VarChar, 50);
                tmp.Direction = ParameterDirection.Input;
                tmp.Value = temp1;
                objOraclecommand.Parameters.Add(tmp);

                OracleParameter tmp2 = new OracleParameter("retain_na", OracleType.VarChar, 50);
                tmp2.Direction = ParameterDirection.Input;
                tmp2.Value = temp2;
                objOraclecommand.Parameters.Add(tmp2);


                OracleParameter tmp3 = new OracleParameter("pub_cent", OracleType.VarChar, 50);
                tmp3.Direction = ParameterDirection.Input;
                tmp3.Value = temp3;
                objOraclecommand.Parameters.Add(tmp3);



                OracleParameter tmp4 = new OracleParameter("descid", OracleType.VarChar, 50);
                tmp4.Direction = ParameterDirection.Input;
                tmp4.Value = temp4;
                objOraclecommand.Parameters.Add(tmp4);


                OracleParameter tmp5 = new OracleParameter("ascdesc", OracleType.VarChar, 50);
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

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;



                objorclDataAdapter.SelectCommand = objOraclecommand;
                OracleDataReader objdatareadre = objOraclecommand.ExecuteReader();

                return objdatareadre;
                //objorclDataAdapter.Fill(objDataSet);

                //return objDataSet;



            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                //CloseConnection(ref objOracleConnection);
            }


        }



        public DataSet drillout_region(string fromdate, string todate, string compcode, string region, string dateformat, string publication, string agency, string client, string billstatus, string payment, string adtype, string category, string descid, string ascdesc, string myrange, string maxrange, string temp6, string temp7, string temp8)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            //SqlConnection objOracleConnection = new SqlConnection();
            //SqlCommand objOraclecommand;
            //objOracleConnection = GetConnection();
            //SqlDataAdapter objorclDataAdapter = new SqlDataAdapter();
            //DataSet objDataSet = new DataSet();

            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("bill_drillout.bill_drillout_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("fromdate", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                if (fromdate != "0")
                {
                    prm1.Value =Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");
                }
                else
                {
                    prm1.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("dateto", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                if (todate != "0")
                {
                    prm2.Value = Convert.ToDateTime(todate).ToString("dd-MMMM-yyyy");
                }
                else
                {
                    prm2.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm4 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = compcode;
                objOraclecommand.Parameters.Add(prm4);

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


                OracleParameter prm5 = new OracleParameter("dateformat", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = dateformat;
                objOraclecommand.Parameters.Add(prm5);


                OracleParameter prm8 = new OracleParameter("pub_name", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                if (publication != "0")
                {
                    prm8.Value = publication;
                }

                else
                {
                    prm8.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm6 = new OracleParameter("agency", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                if (agency != "0")
                {
                    prm6.Value = agency;
                }
                else
                {
                    prm6.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("client", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;

                if (client != "0")
                {
                    prm7.Value = client;
                }
                else
                {
                    prm7.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm7);



                OracleParameter prm10 = new OracleParameter("payment", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                if (payment != "0")
                {
                    prm10.Value = payment;
                }
                else
                {
                    prm10.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("billstatus", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                if (billstatus != "0")
                {
                    prm11.Value = billstatus;
                }
                else
                {
                    prm11.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm11);


                OracleParameter prm9 = new OracleParameter("adtype", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                if (adtype != "0")
                {
                    prm9.Value = adtype;
                }
                else
                {
                    prm9.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm9);


                OracleParameter prm14 = new OracleParameter("category", OracleType.VarChar, 50);
                prm14.Direction = ParameterDirection.Input;
                if (category != "0")
                {
                    prm14.Value = category;
                }
                else
                {
                    prm14.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm14);

                OracleParameter prm12 = new OracleParameter("myrange", OracleType.VarChar, 50);
                prm12.Direction = ParameterDirection.Input;
                if (myrange != "0")
                {
                    prm12.Value = myrange;
                }
                else
                {
                    prm12.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm12);

                OracleParameter prm13 = new OracleParameter("maxrange", OracleType.VarChar, 50);
                prm13.Direction = ParameterDirection.Input;
                if (maxrange != "0")
                {
                    prm13.Value = maxrange;
                }
                else
                {
                    prm13.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm13);


                OracleParameter prm15 = new OracleParameter("descid", OracleType.VarChar, 50);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = descid;
                objOraclecommand.Parameters.Add(prm15);

                OracleParameter prm16 = new OracleParameter("ascdesc", OracleType.VarChar, 50);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = ascdesc;
                objOraclecommand.Parameters.Add(prm16);

                OracleParameter tmp6 = new OracleParameter("product", OracleType.VarChar, 50);
                tmp6.Direction = ParameterDirection.Input;
                tmp6.Value = temp6;
                objOraclecommand.Parameters.Add(tmp6);

                OracleParameter tmp7 = new OracleParameter("pub_cent", OracleType.VarChar, 50);
                tmp7.Direction = ParameterDirection.Input;
                tmp7.Value = temp7;
                objOraclecommand.Parameters.Add(tmp7);



                OracleParameter tmp8 = new OracleParameter("retain_na", OracleType.VarChar, 50);
                tmp8.Direction = ParameterDirection.Input;
                tmp8.Value = temp8;
                objOraclecommand.Parameters.Add(tmp8);

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

        //Get_Execexec
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
                if (region != "0")
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

                //OracleParameter prm152 = new OracleParameter("grp", OracleType.VarChar, 50);
                //prm152.Direction = ParameterDirection.Input;
                //if (grp == "0")
                //{
                //    prm152.Value = System.DBNull.Value;
                //}
                //else
                //{
                //    prm152.Value = grp;
                //}
                //objOraclecommand.Parameters.Add(prm152);


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

//===========================================


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
        //////////////////////////////////////////

        public OracleDataReader barter_reportexcel(string frmdt, string todate, string compcode, string region, string product, string dateformate, string adtype, string adcategory, string client)
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


                OracleParameter prm5 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = compcode;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("dateformat", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = dateformate;
                objOraclecommand.Parameters.Add(prm6);

                //-------------------

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


                //---------------------------

                objorclDataAdapter.SelectCommand = objOraclecommand;
                OracleDataReader objdatareadre = objOraclecommand.ExecuteReader();
                //OracleDataReader objdatareadre = objOraclecommand.ExecuteReader();

                return objdatareadre;


            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                //CloseConnection(ref objOracleConnection);
            }


        }



    }
}
