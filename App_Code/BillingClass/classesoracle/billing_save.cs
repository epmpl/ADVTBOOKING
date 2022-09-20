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
    /// Summary description for billing_save
    /// </summary>
    public class billing_save : orclconnection
    {
        public billing_save()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        public DataSet update_printcount(string invoice, string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("updatebill_printcount.updatebill_printcount_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm2 = new OracleParameter("invoice", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = invoice;
                objOraclecommand.Parameters.Add(prm2);




                //OracleParameter prm1 = new OracleParameter("print_count", OracleType.Number, 50);
                //prm1.Direction = ParameterDirection.Input;
                //prm1.Value = print_count;
                //objOraclecommand.Parameters.Add(prm1);



                OracleParameter prm3 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = compcode;
                objOraclecommand.Parameters.Add(prm3);

                //objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                //objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

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
        public DataSet edition(string editioncode, string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_selectedition", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm2 = new OracleParameter("editoncode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = editioncode;
                objOraclecommand.Parameters.Add(prm2);




                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);


                objOraclecommand.Parameters.Add("P_GetUserRecord", OracleType.Cursor);
                objOraclecommand.Parameters["P_GetUserRecord"].Direction = ParameterDirection.Output;

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
        public DataSet saveorderwise(string width, string height, string color, string volume, string packgerate, string package, string adcat1, string pageposition, string rono_date, string insertion, string agency, string publication, string orderno1, string packagecode, string amount, string boxch, string discount, string edition1, string Client, string agddxt1, string city, string agencycode, string invoice1, string amountforvat)
        {        

            OracleConnection con;
            OracleCommand com;
            DataSet objDataSet = new DataSet();
            con = GetConnection();           
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {
                con.Open();
                com = GetCommand("bill_insertionwise.bill_insertionwise_p", ref con);
                com.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("width", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = width;
                com.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("height", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = height;
                com.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("color", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = color;
                com.Parameters.Add(prm3);

                OracleParameter prm5 = new OracleParameter("volume", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = volume;
                com.Parameters.Add(prm5);

                OracleParameter prm4 = new OracleParameter("packgerate", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = packgerate;
                com.Parameters.Add(prm4);
               

                OracleParameter prm6 = new OracleParameter("package", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = package;
                com.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("adcat1", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = adcat1;
                com.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("pageposition", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = pageposition;
                com.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("packgerate", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = packgerate;
                com.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("rono_date", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = rono_date;
                com.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("insertion", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = Convert.ToDouble(insertion);
                com.Parameters.Add(prm11);

                ////

                OracleParameter prm12 = new OracleParameter("agency", OracleType.VarChar);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = agency;
                com.Parameters.Add(prm12);


                OracleParameter prm13 = new OracleParameter("publication", OracleType.VarChar);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = publication;
                com.Parameters.Add(prm13);


                OracleParameter prm14 = new OracleParameter("orderno1", OracleType.VarChar);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = orderno1;
                com.Parameters.Add(prm14);

                OracleParameter prm15 = new OracleParameter("packagecode", OracleType.VarChar);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = packagecode;
                com.Parameters.Add(prm15);

                OracleParameter prm16 = new OracleParameter("amount", OracleType.VarChar);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value =Convert.ToDouble(rono_date);
                com.Parameters.Add(prm16);

                OracleParameter prm17 = new OracleParameter("boxch", OracleType.VarChar);
                prm17.Direction = ParameterDirection.Input;
                prm17.Value = boxch;
                com.Parameters.Add(prm17);

                /////

                OracleParameter prm23 = new OracleParameter("discount", OracleType.VarChar);
                prm23.Direction = ParameterDirection.Input;
                prm23.Value = discount;
                com.Parameters.Add(prm23);

                OracleParameter prm24 = new OracleParameter("edition1", OracleType.VarChar);
                prm24.Direction = ParameterDirection.Input;
                prm24.Value = edition1;
                com.Parameters.Add(prm24);


                OracleParameter prm25 = new OracleParameter("Client", OracleType.VarChar);
                prm25.Direction = ParameterDirection.Input;
                prm25.Value = Client;
                com.Parameters.Add(prm25);

                OracleParameter prm18 = new OracleParameter("agddxt1", OracleType.VarChar);
                prm18.Direction = ParameterDirection.Input;
                prm18.Value = agddxt1;
                com.Parameters.Add(prm18);
                OracleParameter prm19 = new OracleParameter("city", OracleType.VarChar);
                prm19.Direction = ParameterDirection.Input;
                prm19.Value = city;
                com.Parameters.Add(prm19);
                
                /////////////////// 

                OracleParameter prm20 = new OracleParameter("agencycode", OracleType.VarChar);
                prm20.Direction = ParameterDirection.Input;
                prm20.Value = agencycode;
                com.Parameters.Add(prm20);

                OracleParameter prm21 = new OracleParameter("invoice1", OracleType.VarChar);
                prm21.Direction = ParameterDirection.Input;
                prm21.Value = invoice1;
                com.Parameters.Add(prm21);

                OracleParameter prm22 = new OracleParameter("amountforvat", OracleType.VarChar);
                prm22.Direction = ParameterDirection.Input;
                prm22.Value = Convert.ToDouble(amountforvat);
                com.Parameters.Add(prm22);


                
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



















        public DataSet pub_cent_NEW(string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {


                objOracleConnection.Open();
                objOraclecommand = GetCommand("Bind_PubCentName_bill.Bind_PubCentName_bill_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;





                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);


                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

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




        public DataSet center(string compcode)
        {
            OracleConnection con;
            OracleCommand com;
            DataSet objDataSet = new DataSet();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            con = GetConnection();
            try
            {
                con.Open();
                com = GetCommand("websp_center.websp_center_p", ref con);
                com.CommandType = CommandType.StoredProcedure;

                OracleParameter prm22 = new OracleParameter("compcode", OracleType.VarChar);
                prm22.Direction = ParameterDirection.Input;
                prm22.Value = compcode;
                com.Parameters.Add(prm22);



                com.Parameters.Add("P_Accounts", OracleType.Cursor);
                com.Parameters["P_Accounts"].Direction = ParameterDirection.Output;


                objorclDataAdapter.SelectCommand = com;
                objorclDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                CloseConnection(ref con);

            }
        }

        public DataSet websp_bindciobookingid(string dateformat, string tilldate, string fromdate, string publication, string bookingcenter, string revenuecenter, string agencytype, string package, string adtype, string agency, string client, string billstatus, string rate_audit, string billmode, string billcycle, string retainer_name, string executive_name, string branch_name, string ad_category, string district, string taluka, string comcode, string BILL_GEN_PRIOR, string PUB_CENT_HO, string billno, string centerlogin, string fmg_bills, string scheme_type)
        {
            OracleConnection con;
            OracleCommand com;
            DataSet objDataSet = new DataSet();
            con = GetConnection();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {

                con.Open();
                //com = GetCommand("websp_bindcioid.websp_bindcioid_p", ref con);
                //com.CommandType = CommandType.StoredProcedure;
                //com = GetCommand("websp_bindcioid1", ref con);
                //com.CommandType = CommandType.StoredProcedure;

                com = GetCommand("Websp_Bindcioidnew1", ref con);
                com.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("date1", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = dateformat;
                com.Parameters.Add(prm1);

                OracleParameter prm11 = new OracleParameter("todate", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                if (tilldate == "" || tilldate == null)
                {
                    prm11.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = tilldate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        tilldate = mm + "/" + dd + "/" + yy;


                    }
                    prm11.Value = Convert.ToDateTime(tilldate).ToString("dd-MMMM-yyyy");


                }
                com.Parameters.Add(prm11);


                OracleParameter prm12 = new OracleParameter("fromdate", OracleType.VarChar);
                prm12.Direction = ParameterDirection.Input;
                if (fromdate == "" || fromdate == null)
                {
                    prm12.Value = System.DBNull.Value;

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
                    prm12.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");

                }
                com.Parameters.Add(prm12);

                OracleParameter prm13 = new OracleParameter("publication", OracleType.VarChar);
                prm13.Direction = ParameterDirection.Input;
                if (publication != "0")
                {
                    prm13.Value = publication;
                }
                else
                {
                    prm13.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm13);

                OracleParameter prm14 = new OracleParameter("bookingcenter", OracleType.VarChar);
                prm14.Direction = ParameterDirection.Input;
                if (bookingcenter != "")
                {
                    prm14.Value = bookingcenter;
                }
                else
                {
                    prm14.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm14);


                OracleParameter prm15 = new OracleParameter("revenuecenter", OracleType.VarChar);
                prm15.Direction = ParameterDirection.Input;
                if (revenuecenter != "")
                {
                    prm15.Value = revenuecenter;
                }
                else
                {
                    prm15.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm15);


                OracleParameter prm16 = new OracleParameter("agencytype", OracleType.VarChar);
                prm16.Direction = ParameterDirection.Input;
                if (agencytype != "")
                {
                    prm16.Value = agencytype;
                }
                else
                {
                    prm16.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm16);

                OracleParameter prm17 = new OracleParameter("package1", OracleType.VarChar);
                prm17.Direction = ParameterDirection.Input;
                if (package != "")
                {
                    prm17.Value = package;
                }
                else
                {
                    prm17.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm17);

                OracleParameter prm18 = new OracleParameter("adtype1", OracleType.VarChar);
                prm18.Direction = ParameterDirection.Input;
                if (adtype != "")
                {
                    prm18.Value = adtype;
                }
                else
                {
                    prm18.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm18);


                OracleParameter prm19 = new OracleParameter("agency", OracleType.VarChar);
                prm19.Direction = ParameterDirection.Input;
                if (agency != "")
                {
                    prm19.Value = agency;
                }
                else
                {
                    prm19.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm19);


                OracleParameter prm21 = new OracleParameter("client", OracleType.VarChar);
                prm21.Direction = ParameterDirection.Input;
                if (client != "")
                {
                    prm21.Value = client;
                }
                else
                {
                    prm21.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm21);


                OracleParameter prm22 = new OracleParameter("billstatus", OracleType.VarChar);
                prm22.Direction = ParameterDirection.Input;
                if (billstatus != "")
                {
                    prm22.Value = billstatus;
                }
                else
                {
                    prm22.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm22);

                OracleParameter prm23 = new OracleParameter("rate_audit", OracleType.VarChar);
                prm23.Direction = ParameterDirection.Input;
                prm23.Value = rate_audit;
                com.Parameters.Add(prm23);



                OracleParameter prm24 = new OracleParameter("billmode", OracleType.VarChar);
                prm24.Direction = ParameterDirection.Input;
                prm24.Value = System.DBNull.Value;
                com.Parameters.Add(prm24);

                OracleParameter prm25 = new OracleParameter("billcycle", OracleType.VarChar);
                prm25.Direction = ParameterDirection.Input;
                //if ((billcycle == "0") || (billcycle == "1"))
                //{
                //    prm25.Value = "0" + "','" + "1";
                //}
                //else
                //{
                prm25.Value = billcycle;
                //}
                com.Parameters.Add(prm25);

                /////////

           
                OracleParameter prm123 = new OracleParameter("v_retainer_name", OracleType.VarChar);
                prm123.Direction = ParameterDirection.Input;
                if (retainer_name == "")
                {

                    prm123.Value = System.DBNull.Value;
                }
                else
                {
                    prm123.Value = retainer_name;
                }
                com.Parameters.Add(prm123);

                OracleParameter prm223 = new OracleParameter("v_executive_name", OracleType.VarChar);
                prm223.Direction = ParameterDirection.Input;
                if (executive_name=="")
                {
                    prm223.Value = System.DBNull.Value;
                }
                else
                {
                    prm223.Value = executive_name;
                }
               
                com.Parameters.Add(prm223);

               
                OracleParameter prm323 = new OracleParameter("v_branch_name", OracleType.VarChar);
                prm323.Direction = ParameterDirection.Input;
                if (branch_name == "-Select Branch-")
                {
                     prm323.Value = System .DBNull .Value ;
                }
                else
                {
                     prm323.Value = branch_name;
                }
                
                com.Parameters.Add(prm323);

                OracleParameter prm423 = new OracleParameter("v_ad_category", OracleType.VarChar);
                prm423.Direction = ParameterDirection.Input;
                 if(ad_category=="0")
                {
                      prm423.Value = System .DBNull .Value ;
                }
                else
                {
                      prm423.Value = ad_category;
                }
               
                com.Parameters.Add(prm423);

                OracleParameter prm523 = new OracleParameter("v_district", OracleType.VarChar);
                prm523.Direction = ParameterDirection.Input;
                 if(district=="0")
                {
                   prm523.Value =   System .DBNull .Value ;
                }
                else
                {
                      prm523.Value = district;
                }
               
                com.Parameters.Add(prm523);

                 OracleParameter prm623 = new OracleParameter("v_taluka", OracleType.VarChar);
                prm623.Direction = ParameterDirection.Input;
                 if(taluka=="0")
                {
                     prm623.Value =System .DBNull .Value ;
                }
                else
                {
                      prm623.Value = taluka;
                }
               
                com.Parameters.Add(prm623);



                OracleParameter prm224 = new OracleParameter("pcompcode", OracleType.VarChar);
                prm224.Direction = ParameterDirection.Input;
                prm224.Value = comcode;
                com.Parameters.Add(prm224);




                OracleParameter prm229 = new OracleParameter("P_BILLNO", OracleType.VarChar);
                prm229.Direction = ParameterDirection.Input;
                if (billno == "")
                {
                    prm229.Value = System.DBNull.Value;
                }
                else
                {
                    prm229.Value = billno;
                }
                com.Parameters.Add(prm229);



                OracleParameter prm225 = new OracleParameter("P_BILL_GEN_PRIOR", OracleType.VarChar);
                prm225.Direction = ParameterDirection.Input;
                prm225.Value = BILL_GEN_PRIOR;
                com.Parameters.Add(prm225);


                OracleParameter prm226 = new OracleParameter("P_CENTERLOGIN", OracleType.VarChar);
                prm226.Direction = ParameterDirection.Input;
                prm226.Value = centerlogin; 
                com.Parameters.Add(prm226);


                OracleParameter prm227 = new OracleParameter("P_PUB_CENT_HO", OracleType.VarChar);
                prm227.Direction = ParameterDirection.Input;
                prm227.Value = PUB_CENT_HO; 
                com.Parameters.Add(prm227);




                OracleParameter prm228 = new OracleParameter("P_FMG_BILL", OracleType.VarChar);
                prm228.Direction = ParameterDirection.Input;
                prm228.Value = fmg_bills;
                com.Parameters.Add(prm228);




                OracleParameter prm26 = new OracleParameter("P_SCHEME_TYPE", OracleType.VarChar);
                prm26.Direction = ParameterDirection.Input;
                prm26.Value = scheme_type;
                com.Parameters.Add(prm26);

                OracleParameter prm27 = new OracleParameter("PTO_BILL_NO", OracleType.VarChar);
                prm27.Direction = ParameterDirection.Input;
                prm27.Value = System.DBNull.Value;
                com.Parameters.Add(prm27);


                OracleParameter prm28 = new OracleParameter("P_UOM", OracleType.VarChar);
                prm28.Direction = ParameterDirection.Input;
                prm28.Value = System.DBNull.Value;
                com.Parameters.Add(prm28);

                OracleParameter prm29 = new OracleParameter("PEXCLUDE_RATE_CODE", OracleType.VarChar);
                prm29.Direction = ParameterDirection.Input;
                prm29.Value = System.DBNull.Value;
                com.Parameters.Add(prm29);

                ////



                com.Parameters.Add("P_RECORDSET", OracleType.Cursor);
                com.Parameters["P_RECORDSET"].Direction = ParameterDirection.Output;


                com.Parameters.Add("P_RECORDSET1", OracleType.Cursor);
                com.Parameters["P_RECORDSET1"].Direction = ParameterDirection.Output;


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





































        public DataSet websp_bindciobookingid_bill(string dateformat, string tilldate, string fromdate, string publication, string bookingcenter, string revenuecenter, string agencytype, string package, string adtype, string agency, string client, string billstatus, string rate_audit, string billmode, string billcycle)
        {
            OracleConnection con;
            OracleCommand com;
            DataSet objDataSet = new DataSet();
            con = GetConnection();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {

                con.Open();
                //com = GetCommand("websp_bindcioid.websp_bindcioid_p", ref con);
                //com.CommandType = CommandType.StoredProcedure;
                //com = GetCommand("websp_bindcioid1", ref con);
                //com.CommandType = CommandType.StoredProcedure;

                com = GetCommand("Websp_Bindcioidnew1_bill", ref con);
                com.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("date1", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = dateformat;
                com.Parameters.Add(prm1);

                OracleParameter prm11 = new OracleParameter("todate", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                if (tilldate == "" || tilldate == null)
                {
                    prm11.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = tilldate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        tilldate = mm + "/" + dd + "/" + yy;


                    }
                    prm11.Value = Convert.ToDateTime(tilldate).ToString("dd-MMMM-yyyy");


                }
                com.Parameters.Add(prm11);


                OracleParameter prm12 = new OracleParameter("fromdate", OracleType.VarChar);
                prm12.Direction = ParameterDirection.Input;
                if (fromdate == "" || fromdate == null)
                {
                    prm12.Value = System.DBNull.Value;

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
                    prm12.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");

                }
                com.Parameters.Add(prm12);

                OracleParameter prm13 = new OracleParameter("publication", OracleType.VarChar);
                prm13.Direction = ParameterDirection.Input;
                if (publication != "0")
                {
                    prm13.Value = publication;
                }
                else
                {
                    prm13.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm13);

                OracleParameter prm14 = new OracleParameter("bookingcenter", OracleType.VarChar);
                prm14.Direction = ParameterDirection.Input;
                if (bookingcenter != "")
                {
                    prm14.Value = bookingcenter;
                }
                else
                {
                    prm14.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm14);


                OracleParameter prm15 = new OracleParameter("revenuecenter", OracleType.VarChar);
                prm15.Direction = ParameterDirection.Input;
                if (revenuecenter != "")
                {
                    prm15.Value = revenuecenter;
                }
                else
                {
                    prm15.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm15);


                OracleParameter prm16 = new OracleParameter("agencytype", OracleType.VarChar);
                prm16.Direction = ParameterDirection.Input;
                if (agencytype != "")
                {
                    prm16.Value = agencytype;
                }
                else
                {
                    prm16.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm16);

                OracleParameter prm17 = new OracleParameter("package1", OracleType.VarChar);
                prm17.Direction = ParameterDirection.Input;
                if (package != "")
                {
                    prm17.Value = package;
                }
                else
                {
                    prm17.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm17);

                OracleParameter prm18 = new OracleParameter("adtype1", OracleType.VarChar);
                prm18.Direction = ParameterDirection.Input;
                if (adtype != "")
                {
                    prm18.Value = adtype;
                }
                else
                {
                    prm18.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm18);


                OracleParameter prm19 = new OracleParameter("agency", OracleType.VarChar);
                prm19.Direction = ParameterDirection.Input;
                if (agency != "")
                {
                    prm19.Value = agency;
                }
                else
                {
                    prm19.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm19);


                OracleParameter prm21 = new OracleParameter("client", OracleType.VarChar);
                prm21.Direction = ParameterDirection.Input;
                if (client != "")
                {
                    prm21.Value = client;
                }
                else
                {
                    prm21.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm21);


                OracleParameter prm22 = new OracleParameter("billstatus", OracleType.VarChar);
                prm22.Direction = ParameterDirection.Input;
                if (billstatus != "")
                {
                    prm22.Value = billstatus;
                }
                else
                {
                    prm22.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm22);

                OracleParameter prm23 = new OracleParameter("rate_audit", OracleType.VarChar);
                prm23.Direction = ParameterDirection.Input;
                prm23.Value = rate_audit;
                com.Parameters.Add(prm23);



                OracleParameter prm24 = new OracleParameter("billmode", OracleType.VarChar);
                prm24.Direction = ParameterDirection.Input;
                prm24.Value = System.DBNull.Value;
                com.Parameters.Add(prm24);

                OracleParameter prm25 = new OracleParameter("billcycle", OracleType.VarChar);
                prm25.Direction = ParameterDirection.Input;
                if ((billcycle == "0") || (billcycle == "1"))
                {
                    prm25.Value = "0" + "','" + "1";
                }
                else
                {
                    prm25.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm25);



                com.Parameters.Add("p_recordset", OracleType.Cursor);
                com.Parameters["p_recordset"].Direction = ParameterDirection.Output;



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












        public DataSet agencyxls(string compcode, string agen)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("bindagencyforxls.bindagencyforxls_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm6 = new OracleParameter("compcode", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = compcode;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm1 = new OracleParameter("agency", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = agen;
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


        public DataSet executivexls(string comcode, string usid, string tname, string ext)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("xlsBindexecnew.xlsBindexecnew_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = comcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = usid;
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("name1", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = tname;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("executive", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = ext;
                objOraclecommand.Parameters.Add(prm4);


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

        public DataSet retainerxls(string compcode, string ret)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {



                objOracleConnection.Open();
                objOraclecommand = GetCommand("xlsRetainerbind.xlsRetainerbind_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter pr1 = new OracleParameter("retainer", OracleType.VarChar, 50);
                pr1.Direction = ParameterDirection.Input;
                pr1.Value = ret;
                objOraclecommand.Parameters.Add(pr1);


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


        //public DataSet bindagencycode(string compcode, string agency)
        //{

        //    OracleConnection con;
        //    OracleCommand com;
        //    DataSet objDataSet = new DataSet();
        //    con = GetConnection();
        //    OracleDataAdapter da = new OracleDataAdapter();

        //    try
        //    {
        //        con.Open();
        //        com = GetCommand("bindagencycode11", ref con);
        //        com.CommandType = CommandType.StoredProcedure;

        //        OracleParameter prm22 = new OracleParameter("compcode", OracleType.VarChar);
        //        prm22.Direction = ParameterDirection.Input;
        //        prm22.Value = compcode;
        //        com.Parameters.Add(prm22);


        //        OracleParameter prm21 = new OracleParameter("agencyt", OracleType.VarChar);
        //        prm21.Direction = ParameterDirection.Input;
        //        prm21.Value = agency;
        //        com.Parameters.Add(prm21);


        //        com.Parameters.Add("P_Accounts", OracleType.Cursor);
        //        com.Parameters["P_Accounts"].Direction = ParameterDirection.Output;

        //        da.SelectCommand = com;
        //        da.Fill(objDataSet);
        //        return objDataSet;

        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //    finally
        //    {
        //        CloseConnection(ref con);
        //    }
        //}


       /* public DataSet GetAgencyNameAdd_agency(string client, string compcode, string value)
        {
                        OracleConnection con;
            OracleCommand com;
            DataSet objDataSet = new DataSet();
            con = GetConnection();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {
                con.Open();
                com = GetCommand("GetAgency_agencybill.GetAgency_agencybill_p", ref con);
                com.CommandType = CommandType.StoredProcedure;

                OracleParameter prm22 = new OracleParameter("compcode", OracleType.VarChar);
                prm22.Direction = ParameterDirection.Input;
                prm22.Value = compcode;
                com.Parameters.Add(prm22);


                OracleParameter prm21 = new OracleParameter("client", OracleType.VarChar);
                prm21.Direction = ParameterDirection.Input;
                prm21.Value = client;
                com.Parameters.Add(prm21);


                OracleParameter prm23 = new OracleParameter("value", OracleType.VarChar);
                prm23.Direction = ParameterDirection.Input;
                prm23.Value = value;
                com.Parameters.Add(prm23);


                com.Parameters.Add("P_Accounts", OracleType.Cursor);
                com.Parameters["P_Accounts"].Direction = ParameterDirection.Output;

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

        }*/

        public DataSet selectinvoicefmadbills(string ciobooking, string editionname, string insertion, string compcode)
        {
            OracleConnection con;
            OracleCommand com;
            DataSet objDataSet = new DataSet();
            con = GetConnection();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {
                con.Open();
                com = GetCommand("websp_selectinvoiceno.websp_selectinvoiceno_p", ref con);
                com.CommandType = CommandType.StoredProcedure;

                OracleParameter prm22 = new OracleParameter("ciobooking", OracleType.VarChar);
                prm22.Direction = ParameterDirection.Input;
                prm22.Value = ciobooking;
                com.Parameters.Add(prm22);


                OracleParameter prm21 = new OracleParameter("editionname", OracleType.VarChar);
                prm21.Direction = ParameterDirection.Input;
                prm21.Value = editionname;
                com.Parameters.Add(prm21);


                OracleParameter prm23 = new OracleParameter("compcode", OracleType.VarChar);
                prm23.Direction = ParameterDirection.Input;
                prm23.Value = compcode;
                com.Parameters.Add(prm23);

                OracleParameter prm24 = new OracleParameter("insertion", OracleType.VarChar);
                prm24.Direction = ParameterDirection.Input;
                prm24.Value = insertion;
                com.Parameters.Add(prm24);


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


        public DataSet selectinvoicefmadbills_ins(string ciobooking, string insertion)
        {
            OracleConnection con;
            OracleCommand com;
            DataSet objDataSet = new DataSet();
            con = GetConnection();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {
                con.Open();
                com = GetCommand("websp_selectinvoiceno11.websp_selectinvoiceno11_p", ref con);
                com.CommandType = CommandType.StoredProcedure;

                OracleParameter prm22 = new OracleParameter("ciobooking", OracleType.VarChar);
                prm22.Direction = ParameterDirection.Input;
                prm22.Value = ciobooking;
                com.Parameters.Add(prm22);


                OracleParameter prm24 = new OracleParameter("insertion", OracleType.VarChar);
                prm24.Direction = ParameterDirection.Input;
                prm24.Value = insertion;
                com.Parameters.Add(prm24);



                com.Parameters.Add("p_accounts", OracleType.Cursor);
                com.Parameters["p_accounts"].Direction = ParameterDirection.Output;



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

        public DataSet packagebind(string compcode, string userid)
        {
            OracleConnection con;
            OracleCommand com;
            DataSet objDataSet = new DataSet();
            con = GetConnection();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {
                con.Open();
                com = GetCommand("bindpackage1.bindpackage1_p", ref con);
                com.CommandType = CommandType.StoredProcedure;

                OracleParameter prm22 = new OracleParameter("compcode", OracleType.VarChar);
                prm22.Direction = ParameterDirection.Input;
                prm22.Value = compcode;
                com.Parameters.Add(prm22);


                OracleParameter prm24 = new OracleParameter("userid", OracleType.VarChar);
                prm24.Direction = ParameterDirection.Input;
                prm24.Value = userid;
                com.Parameters.Add(prm24);


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

        public DataSet fetchpackagename(string packagecode, string compcode)
        {
            OracleConnection con;
            OracleCommand com;
            DataSet objDataSet = new DataSet();
            con = GetConnection();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {
                con.Open();
                com = GetCommand("fetchpackagename.fetchpackagename_p", ref con);
                com.CommandType = CommandType.StoredProcedure;

                OracleParameter prm22 = new OracleParameter("packagecode", OracleType.VarChar);
                prm22.Direction = ParameterDirection.Input;
                prm22.Value = packagecode;
                com.Parameters.Add(prm22);


                OracleParameter prm24 = new OracleParameter("compcode", OracleType.VarChar);
                prm24.Direction = ParameterDirection.Input;
                prm24.Value = compcode;
                com.Parameters.Add(prm24);


                com.Parameters.Add("P_Accounts", OracleType.Cursor);
                com.Parameters["P_Accounts"].Direction = ParameterDirection.Output;



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

        ///////////vat procedure


        public DataSet websp_bookclassified(string dateformat, string tilldate, string fromdate, string publication, string bookingcenter, string revenuecenter, string agencytype, string package, string adtype, string agency, string client, string billstatus, string rate_audit, string billmode, string retainer_name, string executive_name, string branch_name, string ad_category, string district, string taluka, string orderby, string paymodetyp)
        {
            OracleConnection con;
            OracleCommand com;
            DataSet objDataSet = new DataSet();
            con = GetConnection();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {

                con.Open();
                com = GetCommand("websp_classifiedgrid1", ref con);
                com.CommandType = CommandType.StoredProcedure;


                OracleParameter prm21 = new OracleParameter("date1", OracleType.VarChar);
                prm21.Direction = ParameterDirection.Input;
                prm21.Value = dateformat;
                com.Parameters.Add(prm21);




                OracleParameter prm22 = new OracleParameter("todate", OracleType.VarChar);
                prm22.Direction = ParameterDirection.Input;

                if (tilldate == "" || tilldate == null)
                {
                    prm22.Value = System.DBNull.Value;

                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = tilldate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        tilldate = mm + "/" + dd + "/" + yy;


                    }
                    prm22.Value = Convert.ToDateTime(tilldate).ToString("dd-MMMM-yyyy");

                }
                com.Parameters.Add(prm22);

                OracleParameter prm23 = new OracleParameter("fromdate", OracleType.VarChar);
                prm23.Direction = ParameterDirection.Input;

                if (fromdate == "" || fromdate == null)
                {
                    prm23.Value = System.DBNull.Value;

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
                    prm23.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");

                }
                com.Parameters.Add(prm23);

                OracleParameter prm24 = new OracleParameter("publication", OracleType.VarChar);
                prm24.Direction = ParameterDirection.Input;
                if (publication != "0")
                {


                    prm24.Value = publication;
                }
                else
                {
                    prm24.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm24);

                OracleParameter prm25 = new OracleParameter("bookingcenter", OracleType.VarChar);
                prm25.Direction = ParameterDirection.Input;
                if (bookingcenter != "")
                {
                    prm25.Value = bookingcenter;
                }
                else
                {
                    prm25.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm25);


                OracleParameter prm26 = new OracleParameter("revenuecenter", OracleType.VarChar);
                prm26.Direction = ParameterDirection.Input;
                if (revenuecenter != "")
                {

                    prm26.Value = revenuecenter;
                }
                else
                {
                    prm26.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm26);

                OracleParameter prm27 = new OracleParameter("agencytype", OracleType.VarChar);
                prm27.Direction = ParameterDirection.Input;
                if (agencytype != "")
                {

                    prm27.Value = agencytype;
                }
                else
                {
                    prm27.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm27);

                OracleParameter prm28 = new OracleParameter("package", OracleType.VarChar);
                prm28.Direction = ParameterDirection.Input;
                if (package != "")
                {
                    prm28.Value = package;
                }
                else
                {
                    prm28.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm28);

                OracleParameter prm29 = new OracleParameter("adtype", OracleType.VarChar);
                prm29.Direction = ParameterDirection.Input;
                if (adtype != "0")
                {
                    prm29.Value = adtype;
                }
                else
                {
                    prm29.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm29);


                OracleParameter prm30 = new OracleParameter("agency", OracleType.VarChar);
                prm30.Direction = ParameterDirection.Input;
                if (agency != "")
                {
                    prm30.Value = agency;
                }
                else
                {
                    prm30.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm30);

                OracleParameter prm31 = new OracleParameter("client", OracleType.VarChar);
                prm31.Direction = ParameterDirection.Input;
                if (client != "")
                {
                    prm31.Value = client;
                }
                else
                {
                    prm31.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm31);

                OracleParameter prm32 = new OracleParameter("billstatus", OracleType.VarChar);
                prm32.Direction = ParameterDirection.Input;
                if (billstatus != "0")
                {
                    prm32.Value = billstatus;
                }
                else
                {
                    prm32.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm32);

                OracleParameter prm20 = new OracleParameter("rate_audit", OracleType.VarChar);
                prm20.Direction = ParameterDirection.Input;
                prm20.Value = rate_audit;
                com.Parameters.Add(prm20);


                OracleParameter prm42 = new OracleParameter("billmode", OracleType.VarChar);
                prm42.Direction = ParameterDirection.Input;
                prm42.Value = System.DBNull.Value;
                com.Parameters.Add(prm42);

                OracleParameter prm123 = new OracleParameter("v_retainer_name", OracleType.VarChar);
                prm123.Direction = ParameterDirection.Input;
                if (retainer_name == "")
                {

                    prm123.Value = System.DBNull.Value;
                }
                else
                {
                    prm123.Value = retainer_name;
                }
                com.Parameters.Add(prm123);

                OracleParameter prm223 = new OracleParameter("v_executive_name", OracleType.VarChar);
                prm223.Direction = ParameterDirection.Input;
                if (executive_name == "")
                {
                    prm223.Value = System.DBNull.Value;
                }
                else
                {
                    prm223.Value = executive_name;
                }

                com.Parameters.Add(prm223);


                OracleParameter prm323 = new OracleParameter("v_branch_name", OracleType.VarChar);
                prm323.Direction = ParameterDirection.Input;
                if (branch_name == "-Select Branch-")
                {
                    prm323.Value = System.DBNull.Value;
                }
                else
                {
                    prm323.Value = branch_name;
                }

                com.Parameters.Add(prm323);

                OracleParameter prm423 = new OracleParameter("v_ad_category", OracleType.VarChar);
                prm423.Direction = ParameterDirection.Input;
                if (ad_category == "0")
                {
                    prm423.Value = System.DBNull.Value;
                }
                else
                {
                    prm423.Value = ad_category;
                }

                com.Parameters.Add(prm423);

                OracleParameter prm523 = new OracleParameter("v_district", OracleType.VarChar);
                prm523.Direction = ParameterDirection.Input;
                if (district == "0")
                {
                    prm523.Value = System.DBNull.Value;
                }
                else
                {
                    prm523.Value = district;
                }

                com.Parameters.Add(prm523);

                OracleParameter prm623 = new OracleParameter("v_taluka", OracleType.VarChar);
                prm623.Direction = ParameterDirection.Input;
                if (taluka == "0")
                {
                    prm623.Value = System.DBNull.Value;
                }
                else
                {
                    prm623.Value = taluka;
                }

                com.Parameters.Add(prm623);









                com.Parameters.Add("p_recordset", OracleType.Cursor);
                com.Parameters["p_recordset"].Direction = ParameterDirection.Output;














                //com.Parameters.Add("rate_audit", OracleType.Cursor);
                //com.Parameters["rate_audit"].Direction = ParameterDirection.Output;





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



        public DataSet websp_bookclassified_bill(string dateformat, string tilldate, string fromdate, string publication, string bookingcenter, string revenuecenter, string agencytype, string package, string adtype, string agency, string client, string billstatus, string rate_audit, string billmode)
        {
            OracleConnection con;
            OracleCommand com;
            DataSet objDataSet = new DataSet();
            con = GetConnection();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {

                con.Open();
                com = GetCommand("websp_classifiedgrid1_bill", ref con);
                com.CommandType = CommandType.StoredProcedure;


                OracleParameter prm21 = new OracleParameter("date1", OracleType.VarChar);
                prm21.Direction = ParameterDirection.Input;
                prm21.Value = dateformat;
                com.Parameters.Add(prm21);




                OracleParameter prm22 = new OracleParameter("todate", OracleType.VarChar);
                prm22.Direction = ParameterDirection.Input;

                if (tilldate == "" || tilldate == null)
                {
                    prm22.Value = System.DBNull.Value;

                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = tilldate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        tilldate = mm + "/" + dd + "/" + yy;


                    }
                    prm22.Value = Convert.ToDateTime(tilldate).ToString("dd-MMMM-yyyy");

                }
                com.Parameters.Add(prm22);

                OracleParameter prm23 = new OracleParameter("fromdate", OracleType.VarChar);
                prm23.Direction = ParameterDirection.Input;

                if (fromdate == "" || fromdate == null)
                {
                    prm23.Value = System.DBNull.Value;

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
                    prm23.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");

                }
                com.Parameters.Add(prm23);

                OracleParameter prm24 = new OracleParameter("publication", OracleType.VarChar);
                prm24.Direction = ParameterDirection.Input;
                if (publication != "0")
                {


                    prm24.Value = publication;
                }
                else
                {
                    prm24.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm24);

                OracleParameter prm25 = new OracleParameter("bookingcenter", OracleType.VarChar);
                prm25.Direction = ParameterDirection.Input;
                if (bookingcenter != "")
                {
                    prm25.Value = bookingcenter;
                }
                else
                {
                    prm25.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm25);


                OracleParameter prm26 = new OracleParameter("revenuecenter", OracleType.VarChar);
                prm26.Direction = ParameterDirection.Input;
                if (revenuecenter != "")
                {

                    prm26.Value = revenuecenter;
                }
                else
                {
                    prm26.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm26);

                OracleParameter prm27 = new OracleParameter("agencytype", OracleType.VarChar);
                prm27.Direction = ParameterDirection.Input;
                if (agencytype != "")
                {

                    prm27.Value = agencytype;
                }
                else
                {
                    prm27.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm27);

                OracleParameter prm28 = new OracleParameter("package", OracleType.VarChar);
                prm28.Direction = ParameterDirection.Input;
                if (package != "")
                {
                    prm28.Value = package;
                }
                else
                {
                    prm28.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm28);

                OracleParameter prm29 = new OracleParameter("adtype", OracleType.VarChar);
                prm29.Direction = ParameterDirection.Input;
                if (adtype != "0")
                {
                    prm29.Value = adtype;
                }
                else
                {
                    prm29.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm29);


                OracleParameter prm30 = new OracleParameter("agency", OracleType.VarChar);
                prm30.Direction = ParameterDirection.Input;
                if (agency != "")
                {
                    prm30.Value = agency;
                }
                else
                {
                    prm30.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm30);

                OracleParameter prm31 = new OracleParameter("client", OracleType.VarChar);
                prm31.Direction = ParameterDirection.Input;
                if (client != "")
                {
                    prm31.Value = client;
                }
                else
                {
                    prm31.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm31);

                OracleParameter prm32 = new OracleParameter("billstatus", OracleType.VarChar);
                prm32.Direction = ParameterDirection.Input;
                if (billstatus != "0")
                {
                    prm32.Value = billstatus;
                }
                else
                {
                    prm32.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm32);

                OracleParameter prm20 = new OracleParameter("rate_audit", OracleType.VarChar);
                prm20.Direction = ParameterDirection.Input;
                prm20.Value = rate_audit;
                com.Parameters.Add(prm20);


                OracleParameter prm42 = new OracleParameter("billmode", OracleType.VarChar);
                prm42.Direction = ParameterDirection.Input;
                prm42.Value = System.DBNull.Value;
                com.Parameters.Add(prm42);





                com.Parameters.Add("p_recordset", OracleType.Cursor);
                com.Parameters["p_recordset"].Direction = ParameterDirection.Output;














                //com.Parameters.Add("rate_audit", OracleType.Cursor);
                //com.Parameters["rate_audit"].Direction = ParameterDirection.Output;





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


        public DataSet fetchstatusfororderfirst(string ciobooking, int insertion)
        {
            OracleConnection con;
            OracleCommand com;
            DataSet objDataSet = new DataSet();
            con = GetConnection();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {
                con.Open();
                com = GetCommand("fetchstatusfororderfirst", ref con);
                com.CommandType = CommandType.StoredProcedure;


                OracleParameter prm22 = new OracleParameter("bookingid", OracleType.VarChar);
                prm22.Direction = ParameterDirection.Input;
                prm22.Value = ciobooking;
                com.Parameters.Add(prm22);


                OracleParameter prm21 = new OracleParameter("insertion_no", OracleType.VarChar);
                prm21.Direction = ParameterDirection.Input;
                prm21.Value = insertion;
                com.Parameters.Add(prm21);


                com.Parameters.Add("get_executive", OracleType.Cursor);
                com.Parameters["get_executive"].Direction = ParameterDirection.Output;

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





        public DataSet fetchstatus_det(string ciobooking, int insertion)
        {
            OracleConnection con;
            OracleCommand com;
            DataSet objDataSet = new DataSet();
            con = GetConnection();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {
                con.Open();
                com = GetCommand("fetchstatus_det", ref con);
                com.CommandType = CommandType.StoredProcedure;


                OracleParameter prm22 = new OracleParameter("bookingid", OracleType.VarChar);
                prm22.Direction = ParameterDirection.Input;
                prm22.Value = ciobooking;
                com.Parameters.Add(prm22);


                OracleParameter prm21 = new OracleParameter("insertion_no", OracleType.VarChar);
                prm21.Direction = ParameterDirection.Input;
                prm21.Value = insertion;
                com.Parameters.Add(prm21);


                com.Parameters.Add("get_executive", OracleType.Cursor);
                com.Parameters["get_executive"].Direction = ParameterDirection.Output;

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




        public DataSet MAXDATE1(string dateformat, string tilldate, string fromdate, string publication, string bookingcenter, string revenuecenter, string agencytype, string package, string adtype, string agency, string client, string billstatus, string rate_audit, string billmode, string billcycle,string compcode,string userid)
        {
            OracleConnection con;
            OracleCommand com;
            DataSet objDataSet = new DataSet();
            con = GetConnection();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {

                con.Open();
                com = GetCommand("Websp_maxdate", ref con);
                com.CommandType = CommandType.StoredProcedure;


                OracleParameter prm21 = new OracleParameter("date1", OracleType.VarChar);
                prm21.Direction = ParameterDirection.Input;
                prm21.Value = dateformat;
                com.Parameters.Add(prm21);




                OracleParameter prm22 = new OracleParameter("todate", OracleType.VarChar);
                prm22.Direction = ParameterDirection.Input;

                if (tilldate == "" || tilldate == null)
                {
                    prm22.Value = System.DBNull.Value;

                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = tilldate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        tilldate = mm + "/" + dd + "/" + yy;


                    }
                    prm22.Value = Convert.ToDateTime(tilldate).ToString("dd-MMMM-yyyy");

                }
                com.Parameters.Add(prm22);

                OracleParameter prm23 = new OracleParameter("fromdate", OracleType.VarChar);
                prm23.Direction = ParameterDirection.Input;

                if (fromdate == "" || fromdate == null)
                {
                    prm23.Value = System.DBNull.Value;

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
                    prm23.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");

                }
                com.Parameters.Add(prm23);

                OracleParameter prm24 = new OracleParameter("publication", OracleType.VarChar);
                prm24.Direction = ParameterDirection.Input;
                if (publication != "0")
                {


                    prm24.Value = publication;
                }
                else
                {
                    prm24.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm24);

                OracleParameter prm25 = new OracleParameter("bookingcenter", OracleType.VarChar);
                prm25.Direction = ParameterDirection.Input;
                if (bookingcenter != "")
                {
                    prm25.Value = bookingcenter;
                }
                else
                {
                    prm25.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm25);


                OracleParameter prm26 = new OracleParameter("revenuecenter", OracleType.VarChar);
                prm26.Direction = ParameterDirection.Input;
                if (revenuecenter != "")
                {

                    prm26.Value = revenuecenter;
                }
                else
                {
                    prm26.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm26);

                OracleParameter prm27 = new OracleParameter("agencytype", OracleType.VarChar);
                prm27.Direction = ParameterDirection.Input;
                if (agencytype != "")
                {

                    prm27.Value = agencytype;
                }
                else
                {
                    prm27.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm27);

                OracleParameter prm28 = new OracleParameter("PACKAGE", OracleType.VarChar);
                prm28.Direction = ParameterDirection.Input;
                if (package != "")
                {
                    prm28.Value = package;
                }
                else
                {
                    prm28.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm28);

                OracleParameter prm29 = new OracleParameter("adtype", OracleType.VarChar);
                prm29.Direction = ParameterDirection.Input;
                if (adtype != "0")
                {
                    prm29.Value = adtype;
                }
                else
                {
                    prm29.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm29);


                OracleParameter prm30 = new OracleParameter("agency", OracleType.VarChar);
                prm30.Direction = ParameterDirection.Input;
                if (agency != "")
                {
                    prm30.Value = agency;
                }
                else
                {
                    prm30.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm30);

                OracleParameter prm31 = new OracleParameter("client", OracleType.VarChar);
                prm31.Direction = ParameterDirection.Input;
                if (client != "")
                {
                    prm31.Value = client;
                }
                else
                {
                    prm31.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm31);

                OracleParameter prm32 = new OracleParameter("billstatus", OracleType.VarChar);
                prm32.Direction = ParameterDirection.Input;
                if (billstatus != "0")
                {
                    prm32.Value = billstatus;
                }
                else
                {
                    prm32.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm32);

                OracleParameter prm20 = new OracleParameter("rate_audit", OracleType.VarChar);
                prm20.Direction = ParameterDirection.Input;
                prm20.Value = rate_audit;
                com.Parameters.Add(prm20);


                OracleParameter prm42 = new OracleParameter("billmode", OracleType.VarChar);
                prm42.Direction = ParameterDirection.Input;
                prm42.Value = System.DBNull.Value;
                com.Parameters.Add(prm42);


                OracleParameter prm43 = new OracleParameter("billcycle", OracleType.VarChar);
                prm43.Direction = ParameterDirection.Input;
                if ((billcycle == "0") || (billcycle == "1"))
                {
                    prm43.Value = "0" + "','" + "1";
                }
                else
                {
                    prm43.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm43);





                com.Parameters.Add("p_recordset", OracleType.Cursor);
                com.Parameters["p_recordset"].Direction = ParameterDirection.Output;














                //com.Parameters.Add("rate_audit", OracleType.Cursor);
                //com.Parameters["rate_audit"].Direction = ParameterDirection.Output;





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

/*
        public DataSet vatrate(string bookingdate, string compcode)
        {

            OracleConnection con;
            OracleCommand com;
            DataSet objDataSet = new DataSet();
            con = GetConnection();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {


                con.Open();
                com = GetCommand("websp_getvatrate", ref con);
                com.CommandType = CommandType.StoredProcedure;






                objSqlCommand.Parameters.Add("@bookingdate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@bookingdate"].Value = bookingdate;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;
                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);

                return objDataSet;





            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }
        }
        */




        ///////



        public DataSet saveinbilldt(string orderno, string invoice1, string amountforvat, string amt3, double boxchg1, int insnum_cou, string doctyp, string maxinsert,string edition,string no_insert)
        {
            OracleConnection con;
            OracleCommand com;
            DataSet objDataSet = new DataSet();
            con = GetConnection();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {

                con.Open();
                com = GetCommand("save_billdt", ref con);
                com.CommandType = CommandType.StoredProcedure;



                OracleParameter prm21 = new OracleParameter("orderno1", OracleType.VarChar);
                prm21.Direction = ParameterDirection.Input;
                prm21.Value = orderno;
                com.Parameters.Add(prm21);



                OracleParameter prm22 = new OracleParameter("invoice1", OracleType.VarChar);
                prm22.Direction = ParameterDirection.Input;
                prm22.Value = invoice1;
                com.Parameters.Add(prm22);


                OracleParameter prm23 = new OracleParameter("amountforvat", OracleType.VarChar);
                prm23.Direction = ParameterDirection.Input;
                prm23.Value = amountforvat;
                com.Parameters.Add(prm23);


                OracleParameter prm24 = new OracleParameter("amt3", OracleType.VarChar);
                prm24.Direction = ParameterDirection.Input;
                prm24.Value = amt3;
                com.Parameters.Add(prm24);

                OracleParameter prm25 = new OracleParameter("boxchg1", OracleType.VarChar);
                prm25.Direction = ParameterDirection.Input;
                prm25.Value = boxchg1;
                com.Parameters.Add(prm25);
                OracleParameter prm26 = new OracleParameter("insnum_cou", OracleType.Number);
                prm26.Direction = ParameterDirection.Input;
                prm26.Value = insnum_cou;
                com.Parameters.Add(prm26);

                OracleParameter prm111 = new OracleParameter("doctyp", OracleType.VarChar);
                prm111.Direction = ParameterDirection.Input;
                prm111.Value = doctyp;
                com.Parameters.Add(prm111);

                OracleParameter prm112 = new OracleParameter("maxinsert", OracleType.VarChar);
                prm112.Direction = ParameterDirection.Input;
                prm112.Value = maxinsert;
                com.Parameters.Add(prm112);


                OracleParameter prm113 = new OracleParameter("edition_v", OracleType.VarChar);
                prm113.Direction = ParameterDirection.Input;
                prm113.Value = edition ;
                com.Parameters.Add(prm113);

                OracleParameter prm114 = new OracleParameter("no_insert_v", OracleType.VarChar);
                prm114.Direction = ParameterDirection.Input;
                prm114.Value = no_insert;
                com.Parameters.Add(prm114);



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



       
        public DataSet saveinclassified(string orderno, string invoice1, string amountforvat, string amt3, double boxchg1, int insnum_cou, string doctyp, string maxinsert)
        {
            OracleConnection con;
            OracleCommand com;
            DataSet objDataSet = new DataSet();
            con = GetConnection();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {

                con.Open();
                com = GetCommand("bill_saveclassified", ref con);
                com.CommandType = CommandType.StoredProcedure;



                OracleParameter prm21 = new OracleParameter("orderno1", OracleType.VarChar);
                prm21.Direction = ParameterDirection.Input;
                prm21.Value = orderno;
                com.Parameters.Add(prm21);



                OracleParameter prm22 = new OracleParameter("invoice1", OracleType.VarChar);
                prm22.Direction = ParameterDirection.Input;
                prm22.Value = invoice1;
                com.Parameters.Add(prm22);


                OracleParameter prm23 = new OracleParameter("amountforvat", OracleType.VarChar);
                prm23.Direction = ParameterDirection.Input;
                prm23.Value = amountforvat;
                com.Parameters.Add(prm23);


                OracleParameter prm24 = new OracleParameter("amt3", OracleType.VarChar);
                prm24.Direction = ParameterDirection.Input;
                prm24.Value = amt3;
                com.Parameters.Add(prm24);

                OracleParameter prm25 = new OracleParameter("boxchg1", OracleType.VarChar);
                prm25.Direction = ParameterDirection.Input;
                prm25.Value = boxchg1;
                com.Parameters.Add(prm25);
                OracleParameter prm26 = new OracleParameter("insnum_cou", OracleType.Number);
                prm26.Direction = ParameterDirection.Input;
                prm26.Value = insnum_cou;
                com.Parameters.Add(prm26);

                OracleParameter prm111 = new OracleParameter("doctyp", OracleType.VarChar);
                prm111.Direction = ParameterDirection.Input;
                prm111.Value = doctyp;
                com.Parameters.Add(prm111);

                OracleParameter prm112 = new OracleParameter("maxinsert", OracleType.VarChar);
                prm112.Direction = ParameterDirection.Input;
                prm112.Value = maxinsert;
                com.Parameters.Add(prm112);




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


        public DataSet selectclassified(string agcode, string fromdate, string dateto, string bookingid, string Client, string dateformat)
        {
            OracleConnection con;
            OracleCommand com;
            DataSet objDataSet = new DataSet();
            con = GetConnection();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {
                con.Open();
                com = GetCommand("websp_classified", ref con);
                com.CommandType = CommandType.StoredProcedure;




                OracleParameter prm21 = new OracleParameter("agcode", OracleType.VarChar);
                prm21.Direction = ParameterDirection.Input;
                prm21.Value = agcode;
                com.Parameters.Add(prm21);

                OracleParameter prm22 = new OracleParameter("fromdate", OracleType.VarChar);
                prm22.Direction = ParameterDirection.Input;
                if (fromdate == "")
                {
                    prm22.Value = System.DBNull.Value;
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
                    prm22.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");

                }

                com.Parameters.Add(prm22);

                OracleParameter prm23 = new OracleParameter("dateto", OracleType.VarChar);
                prm23.Direction = ParameterDirection.Input;
                if (dateto == "")
                {
                    prm23.Value = System.DBNull.Value;
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
                    prm23.Value = Convert.ToDateTime(dateto).ToString("dd-MMMM-yyyy");

                }

                com.Parameters.Add(prm23);

                OracleParameter prm24 = new OracleParameter("bookingid", OracleType.VarChar);
                prm24.Direction = ParameterDirection.Input;
                prm24.Value = bookingid;
                com.Parameters.Add(prm24);


                OracleParameter prm32 = new OracleParameter("Client", OracleType.VarChar);
                prm32.Direction = ParameterDirection.Input;
                if (Client == "")
                {
                    prm32.Value = System.DBNull.Value;

                }
                else
                {
                    prm32.Value = Client;
                }
                com.Parameters.Add(prm32);

                OracleParameter prm20 = new OracleParameter("dateformat", OracleType.VarChar);
                prm20.Direction = ParameterDirection.Input;
                prm20.Value = dateformat;
                com.Parameters.Add(prm20);




                com.Parameters.Add("p_classs", OracleType.Cursor);
                com.Parameters["p_classs"].Direction = ParameterDirection.Output;

                com.Parameters.Add("p_classs1", OracleType.Cursor);
                com.Parameters["p_classs1"].Direction = ParameterDirection.Output;

                com.Parameters.Add("p_classs2", OracleType.Cursor);
                com.Parameters["p_classs2"].Direction = ParameterDirection.Output;



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
        //Websp_Invoice_Clas( procedure old)
        public DataSet selectinvoicefmclassi(string ciobooking, string insertion)
        {
            OracleConnection con;
            OracleCommand com;
            DataSet objDataSet = new DataSet();
            con = GetConnection();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {
                con.Open();
                com = GetCommand("Websp_Invoice_Clas", ref con);
                com.CommandType = CommandType.StoredProcedure;

                OracleParameter prm22 = new OracleParameter("ciobooking", OracleType.VarChar);
                prm22.Direction = ParameterDirection.Input;
                prm22.Value = ciobooking;
                com.Parameters.Add(prm22);


                OracleParameter prm24 = new OracleParameter("insertion", OracleType.VarChar);
                prm24.Direction = ParameterDirection.Input;
                prm24.Value = insertion;
                com.Parameters.Add(prm24);


                com.Parameters.Add("p_recordset1", OracleType.Cursor);
                com.Parameters["p_recordset1"].Direction = ParameterDirection.Output;



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






        public DataSet fetchlast(string ciobooking)
        {
            OracleConnection con;
            OracleCommand com;
            DataSet objDataSet = new DataSet();
            con = GetConnection();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {
                con.Open();
                com = GetCommand("Websp_last", ref con);
                com.CommandType = CommandType.StoredProcedure;

                OracleParameter prm22 = new OracleParameter("ciobooking", OracleType.VarChar);
                prm22.Direction = ParameterDirection.Input;
                prm22.Value = ciobooking;
                com.Parameters.Add(prm22);



            


                com.Parameters.Add("p_recordset1", OracleType.Cursor);
                com.Parameters["p_recordset1"].Direction = ParameterDirection.Output;



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



        public DataSet fetchlast_monthly_adbil(string ciobooking,string dateto,string dateformat)
        {
            OracleConnection con;
            OracleCommand com;
            DataSet objDataSet = new DataSet();
            con = GetConnection();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {
                con.Open();
                com = GetCommand("chklast", ref con);
                com.CommandType = CommandType.StoredProcedure;

                OracleParameter prm22 = new OracleParameter("ciobooking", OracleType.VarChar);
                prm22.Direction = ParameterDirection.Input;
                prm22.Value = ciobooking;
                com.Parameters.Add(prm22);


                OracleParameter prm23 = new OracleParameter("dateto", OracleType.VarChar);
                prm23.Direction = ParameterDirection.Input;
                if (dateto == "")
                {
                    prm23.Value = System.DBNull.Value;
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
                    prm23.Value = Convert.ToDateTime(dateto).ToString("dd-MMMM-yyyy");

                }

                com.Parameters.Add(prm23);






                com.Parameters.Add("p_recordset1", OracleType.Cursor);
                com.Parameters["p_recordset1"].Direction = ParameterDirection.Output;



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



        public DataSet fetchlast_monthly(string ciobooking,string insertion_no,string edition)
        {
            OracleConnection con;
            OracleCommand com;
            DataSet objDataSet = new DataSet();
            con = GetConnection();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {
                con.Open();
                com = GetCommand("Websp_last_monthly", ref con);
                com.CommandType = CommandType.StoredProcedure;

                OracleParameter prm22 = new OracleParameter("ciobooking", OracleType.VarChar);
                prm22.Direction = ParameterDirection.Input;
                prm22.Value = ciobooking;
                com.Parameters.Add(prm22);
                OracleParameter prm23 = new OracleParameter("insertion_no", OracleType.VarChar);
                prm23.Direction = ParameterDirection.Input;
                prm23.Value = insertion_no;
                com.Parameters.Add(prm23);
                OracleParameter prm24 = new OracleParameter("edition", OracleType.VarChar);
                prm24.Direction = ParameterDirection.Input;
                prm24.Value = edition;
                com.Parameters.Add(prm24);






                com.Parameters.Add("p_recordset1", OracleType.Cursor);
                com.Parameters["p_recordset1"].Direction = ParameterDirection.Output;



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


        public DataSet fetchstatusfororderwise(string ciobooking, int insertion)
        {
            OracleConnection con;
            OracleCommand com;
            DataSet objDataSet = new DataSet();
            con = GetConnection();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {
                con.Open();
                com = GetCommand("fetchstatusfororder", ref con);
                com.CommandType = CommandType.StoredProcedure;


                OracleParameter prm22 = new OracleParameter("bookingid", OracleType.VarChar);
                prm22.Direction = ParameterDirection.Input;
                prm22.Value = ciobooking;
                com.Parameters.Add(prm22);


                OracleParameter prm21 = new OracleParameter("insertion_no", OracleType.VarChar);
                prm21.Direction = ParameterDirection.Input;
                prm21.Value = insertion;
                com.Parameters.Add(prm21);


                com.Parameters.Add("get_executive", OracleType.Cursor);
                com.Parameters["get_executive"].Direction = ParameterDirection.Output;

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

        public DataSet updateinsert_table(string compcode)
        {
            OracleConnection con;
            OracleCommand com;
            DataSet objDataSet = new DataSet();
            con = GetConnection();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {


                con.Open();
                com = GetCommand("update_tbl_insert", ref con);
                com.CommandType = CommandType.StoredProcedure;               

                OracleParameter prm24 = new OracleParameter("compcode", OracleType.VarChar);
                prm24.Direction = ParameterDirection.Input;
                prm24.Value = compcode;
                com.Parameters.Add(prm24);           

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




        public DataSet GetAgencyNameAdd_agency(string client, string compcode, string value)
        {
            OracleConnection con;
            OracleCommand com;
            DataSet objDataSet = new DataSet();
            con = GetConnection();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {
                con.Open();
                com = GetCommand("GetAgency_agencybill.GetAgency_agencybill_p", ref con);
                com.CommandType = CommandType.StoredProcedure;

                OracleParameter prm22 = new OracleParameter("compcode", OracleType.VarChar);
                prm22.Direction = ParameterDirection.Input;
                prm22.Value = compcode;
                com.Parameters.Add(prm22);


                OracleParameter prm21 = new OracleParameter("client", OracleType.VarChar);
                prm21.Direction = ParameterDirection.Input;
                prm21.Value = client;
                com.Parameters.Add(prm21);


                OracleParameter prm23 = new OracleParameter("value", OracleType.VarChar);
                prm23.Direction = ParameterDirection.Input;
                prm23.Value = value;
                com.Parameters.Add(prm23);


                com.Parameters.Add("P_Accounts", OracleType.Cursor);
                com.Parameters["P_Accounts"].Direction = ParameterDirection.Output;

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


        public DataSet websp_updatestatus(string dateformat, string tilldate, string fromdate, string Adtype,string branch,string publication,string edition,string supplement,string booking_audit  ,string status_value,string pub_centcode ,string AD_CATEGORY,string userid/*,string district,string region*/)
        {
            OracleConnection con;
            OracleCommand com;
            DataSet objDataSet = new DataSet();
            con = GetConnection();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {

                con.Open();


                com = GetCommand("Websp_updatestatus", ref con);
                com.CommandType = CommandType.StoredProcedure;



                OracleParameter prm11 = new OracleParameter("todate", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                if (tilldate == "" || tilldate == null)
                {
                    prm11.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = tilldate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        tilldate = mm + "/" + dd + "/" + yy;


                    }
                    prm11.Value = Convert.ToDateTime(tilldate).ToString("dd-MMMM-yyyy");


                }
                com.Parameters.Add(prm11);


                OracleParameter prm12 = new OracleParameter("fromdate", OracleType.VarChar);
                prm12.Direction = ParameterDirection.Input;
                if (fromdate == "" || fromdate == null)
                {
                    prm12.Value = System.DBNull.Value;

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
                    prm12.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");

                }
                com.Parameters.Add(prm12);

                OracleParameter prm31 = new OracleParameter("Adtype", OracleType.VarChar);
                prm31.Direction = ParameterDirection.Input;
                if (Adtype != "0")
                {
                    prm31.Value = Adtype;
                }
                else
                {
                    prm31.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm31);




                OracleParameter prm32 = new OracleParameter("branch", OracleType.VarChar);
                prm32.Direction = ParameterDirection.Input;
                if (branch != "0")
                {
                    prm32.Value = branch;
                }
                else
                {
                    prm32.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm32);



                OracleParameter prm33 = new OracleParameter("publication", OracleType.VarChar);
                prm33.Direction = ParameterDirection.Input;
                if (publication != "0")
                {
                    prm33.Value = publication;
                }
                else
                {
                    prm33.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm33);




                OracleParameter prm34 = new OracleParameter("dateformat", OracleType.VarChar);
                prm34.Direction = ParameterDirection.Input;
                prm34.Value = dateformat;              
                com.Parameters.Add(prm34);




                OracleParameter prm18 = new OracleParameter("v_edition", OracleType.VarChar);
                prm18.Direction = ParameterDirection.Input;
                if (edition == "0")
                {
                    prm18.Value = System.DBNull.Value;

                }
                else
                {
                    prm18.Value = edition;
                }
                com.Parameters.Add(prm18);




                OracleParameter prm50 = new OracleParameter("v_supplement", OracleType.VarChar);
                prm50.Direction = ParameterDirection.Input;
                if (supplement == "")
                {
                    prm50.Value = System.DBNull.Value;

                }
                else
                {
                    prm50.Value = supplement;
                }
                com.Parameters.Add(prm50);






                OracleParameter prm59 = new OracleParameter("v_booking_audit", OracleType.VarChar);
                prm59.Direction = ParameterDirection.Input;
                if (booking_audit == "")
                {
                    prm59.Value = System.DBNull.Value;

                }
                else
                {
                    prm59.Value = booking_audit;
                }
                com.Parameters.Add(prm59);



                OracleParameter prm159 = new OracleParameter("v_status_value", OracleType.VarChar);
                prm159.Direction = ParameterDirection.Input;
                if (status_value == "0")
                {
                    prm159.Value = System.DBNull.Value;

                }
                else
                {
                    prm159.Value = status_value;
                }
                com.Parameters.Add(prm159);

                OracleParameter prm160 = new OracleParameter("v_pub_cent_code", OracleType.VarChar);
                  prm160.Direction = ParameterDirection.Input;
                  if (pub_centcode == "0")
                {
                    prm160.Value = System.DBNull.Value;

                }
                else
                {
                    prm160.Value = pub_centcode;
                }
                com.Parameters.Add(prm160);


                OracleParameter prm161 = new OracleParameter("V_AD_CATEGORY", OracleType.VarChar);
                prm161.Direction = ParameterDirection.Input;
                if (AD_CATEGORY == "0")
                {
                    prm161.Value = System.DBNull.Value;

                }
                else
                {
                    prm161.Value = AD_CATEGORY;
                }
                com.Parameters.Add(prm161);



                OracleParameter prm162 = new OracleParameter("v_userid", OracleType.VarChar);
                prm162.Direction = ParameterDirection.Input;
                if (userid == "0")
                {
                    prm162.Value = System.DBNull.Value;

                }
                else
                {
                    prm162.Value = userid;
                }
                com.Parameters.Add(prm162);



                com.Parameters.Add("p_recordset", OracleType.Cursor);
                com.Parameters["p_recordset"].Direction = ParameterDirection.Output;



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




        public DataSet  updatestatusnew(string bookingid, string insertion, string edition)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("updatestausnew.updatestausnew_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm4 = new OracleParameter("ciobookid", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = bookingid;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm7 = new OracleParameter("insertion", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = insertion;
                objOraclecommand.Parameters.Add(prm7);


                OracleParameter prm6 = new OracleParameter("edition", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = edition;
                objOraclecommand.Parameters.Add(prm6);

               

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
                objOracleConnection.Close();
            }

        }

        public DataSet updatestatusnew1(string bookingid, string insertion, string edition)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("updatestausnew1.updatestausnew_p1", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm4 = new OracleParameter("ciobookid", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = bookingid;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm7 = new OracleParameter("insertion", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = insertion;
                objOraclecommand.Parameters.Add(prm7);


                OracleParameter prm6 = new OracleParameter("edition", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = edition;
                objOraclecommand.Parameters.Add(prm6);



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
                objOracleConnection.Close();
            }

        }
        //public DataSet fetchstatus(string ciobooking, int insertion)
        //{
        //    OracleConnection objOracleConnection;
        //    OracleCommand objOraclecommand;
        //    DataSet objDataSet = new DataSet();
        //    objOracleConnection = GetConnection();
        //    OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        //    try
        //    {
        //        objOracleConnection.Open();
        //        objOraclecommand = GetCommand("fetchstatus", ref objOracleConnection);
        //        objOraclecommand.CommandType = CommandType.StoredProcedure;

        //        OracleParameter prm4 = new OracleParameter("bookingid", OracleType.VarChar);
        //        prm4.Direction = ParameterDirection.Input;
        //        prm4.Value = ciobooking;
        //        objOraclecommand.Parameters.Add(prm4);

        //        OracleParameter prm7 = new OracleParameter("insertion_no", OracleType.VarChar);
        //        prm7.Direction = ParameterDirection.Input;
        //        prm7.Value = insertion;
        //        objOraclecommand.Parameters.Add(prm7);

        //        com.Parameters.Add("get_executive", OracleType.Cursor);
        //        com.Parameters["get_executive"].Direction = ParameterDirection.Output;

        //        da.SelectCommand = com;
        //        da.Fill(objDataSet);
        //        return objDataSet;

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
        //        objOracleConnection.Close();
        //    }

        //}

        public DataSet fetchstatus(string ciobooking, int insertion)
        {
            OracleConnection con;
            OracleCommand com;
            DataSet objDataSet = new DataSet();
            con = GetConnection();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {
                con.Open();
                com = GetCommand("fetchstatus", ref con);
                com.CommandType = CommandType.StoredProcedure;


                OracleParameter prm22 = new OracleParameter("bookingid", OracleType.VarChar);
                prm22.Direction = ParameterDirection.Input;
                prm22.Value = ciobooking;
                com.Parameters.Add(prm22);


                OracleParameter prm21 = new OracleParameter("insertion_no", OracleType.VarChar);
                prm21.Direction = ParameterDirection.Input;
                prm21.Value = insertion;
                com.Parameters.Add(prm21);


                com.Parameters.Add("get_executive", OracleType.Cursor);
                com.Parameters["get_executive"].Direction = ParameterDirection.Output;

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


        public DataSet fetchstatus_bills(string ciobooking, int insertion)
        {
            OracleConnection con;
            OracleCommand com;
            DataSet objDataSet = new DataSet();
            con = GetConnection();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {
                con.Open();
                com = GetCommand("fetchstatus_adbills", ref con);
                com.CommandType = CommandType.StoredProcedure;


                OracleParameter prm22 = new OracleParameter("bookingid", OracleType.VarChar);
                prm22.Direction = ParameterDirection.Input;
                prm22.Value = ciobooking;
                com.Parameters.Add(prm22);


                OracleParameter prm21 = new OracleParameter("insertion_no", OracleType.VarChar);
                prm21.Direction = ParameterDirection.Input;
                prm21.Value = insertion;
                com.Parameters.Add(prm21);


                com.Parameters.Add("get_executive", OracleType.Cursor);
                com.Parameters["get_executive"].Direction = ParameterDirection.Output;

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


        public DataSet updatebillprintstatus(string invoiceno)
         {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("updatestatusprintbill", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("invoice1", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = invoiceno;
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




        //==========================

        public DataSet selectprintcount(string ciobooking, string insertion)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_selectprintcount", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("ciobooking", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = ciobooking;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("insertion", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = insertion;
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

        public DataSet packagecode(string ciobookingid, string compcode,string dateformat)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_packagecode", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm2 = new OracleParameter("ciobooking", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = ciobookingid;
                objOraclecommand.Parameters.Add(prm2);




                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm3 = new OracleParameter("dateformat", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = dateformat;
                objOraclecommand.Parameters.Add(prm3);


                objOraclecommand.Parameters.Add("p_getbookingrecord", OracleType.Cursor);
                objOraclecommand.Parameters["p_getbookingrecord"].Direction = ParameterDirection.Output;

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


        public DataSet vatrate(string bookdt, string compcode, string dateformat)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {


                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_getvatrate.websp_getvatrate_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm2 = new OracleParameter("bookingdate", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                if (bookdt == "" || bookdt == null)
                {
                    prm2.Value = System.DBNull.Value;
                }
                else
                {


                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = bookdt.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        bookdt = mm + "/" + dd + "/" + yy;


                    }
                    
                }
                prm2.Value = Convert.ToDateTime(bookdt).ToString("dd-MMMM-yyy");
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);


                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;


                objOraclecommand.Parameters.Add("p_accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts1"].Direction = ParameterDirection.Output;


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

        ////////////////

        public DataSet monthly_biling(string dateformat, string tilldate, string fromdate, string publication, string bookingcenter, string revenuecenter, string agencytype, string package, string adtype, string agency, string client, string billstatus, string rate_audit, string billmode, string billcycle)
        {
            OracleConnection con;
            OracleCommand com;
            DataSet objDataSet = new DataSet();
            con = GetConnection();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {

                con.Open();
                com = GetCommand("monthly_billing", ref con);
                com.CommandType = CommandType.StoredProcedure;


                OracleParameter prm21 = new OracleParameter("date1", OracleType.VarChar);
                prm21.Direction = ParameterDirection.Input;
                prm21.Value = dateformat;
                com.Parameters.Add(prm21);




                OracleParameter prm22 = new OracleParameter("todate", OracleType.VarChar);
                prm22.Direction = ParameterDirection.Input;

                if (tilldate == "" || tilldate == null)
                {
                    prm22.Value = System.DBNull.Value;

                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = tilldate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        tilldate = mm + "/" + dd + "/" + yy;


                    }
                    prm22.Value = Convert.ToDateTime(tilldate).ToString("dd-MMMM-yyyy");

                }
                com.Parameters.Add(prm22);

                OracleParameter prm23 = new OracleParameter("fromdate", OracleType.VarChar);
                prm23.Direction = ParameterDirection.Input;

                if (fromdate == "" || fromdate == null)
                {
                    prm23.Value = System.DBNull.Value;

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
                    prm23.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");

                }
                com.Parameters.Add(prm23);

                OracleParameter prm24 = new OracleParameter("publication", OracleType.VarChar);
                prm24.Direction = ParameterDirection.Input;
                if (publication != "0")
                {


                    prm24.Value = publication;
                }
                else
                {
                    prm24.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm24);

                OracleParameter prm25 = new OracleParameter("bookingcenter", OracleType.VarChar);
                prm25.Direction = ParameterDirection.Input;
                if (bookingcenter != "")
                {
                    prm25.Value = bookingcenter;
                }
                else
                {
                    prm25.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm25);


                OracleParameter prm26 = new OracleParameter("revenuecenter", OracleType.VarChar);
                prm26.Direction = ParameterDirection.Input;
                if (revenuecenter != "")
                {

                    prm26.Value = revenuecenter;
                }
                else
                {
                    prm26.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm26);

                OracleParameter prm27 = new OracleParameter("agencytype", OracleType.VarChar);
                prm27.Direction = ParameterDirection.Input;
                if (agencytype != "")
                {

                    prm27.Value = agencytype;
                }
                else
                {
                    prm27.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm27);

                OracleParameter prm28 = new OracleParameter("package", OracleType.VarChar);
                prm28.Direction = ParameterDirection.Input;
                if (package != "")
                {
                    prm28.Value = package;
                }
                else
                {
                    prm28.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm28);

                OracleParameter prm29 = new OracleParameter("adtype", OracleType.VarChar);
                prm29.Direction = ParameterDirection.Input;
                if (adtype != "0")
                {
                    prm29.Value = adtype;
                }
                else
                {
                    prm29.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm29);


                OracleParameter prm30 = new OracleParameter("agency", OracleType.VarChar);
                prm30.Direction = ParameterDirection.Input;
                if (agency != "")
                {
                    prm30.Value = agency;
                }
                else
                {
                    prm30.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm30);

                OracleParameter prm31 = new OracleParameter("client", OracleType.VarChar);
                prm31.Direction = ParameterDirection.Input;
                if (client != "")
                {
                    prm31.Value = client;
                }
                else
                {
                    prm31.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm31);

                OracleParameter prm32 = new OracleParameter("billstatus", OracleType.VarChar);
                prm32.Direction = ParameterDirection.Input;
                if (billstatus != "0")
                {
                    prm32.Value = billstatus;
                }
                else
                {
                    prm32.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm32);

                OracleParameter prm20 = new OracleParameter("rate_audit", OracleType.VarChar);
                prm20.Direction = ParameterDirection.Input;
                prm20.Value = rate_audit;
                com.Parameters.Add(prm20);


                OracleParameter prm42 = new OracleParameter("billmode", OracleType.VarChar);
                prm42.Direction = ParameterDirection.Input;
                prm42.Value = billmode;
                com.Parameters.Add(prm42);





                com.Parameters.Add("p_recordset", OracleType.Cursor);
                com.Parameters["p_recordset"].Direction = ParameterDirection.Output;














                //com.Parameters.Add("rate_audit", OracleType.Cursor);
                //com.Parameters["rate_audit"].Direction = ParameterDirection.Output;





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

        ////


        public DataSet selectmonthly(string agcode, string fromdate, string dateto, string bookingid, string Client, string dateformat,string booking)
        {
            OracleConnection con;
            OracleCommand com;
            DataSet objDataSet = new DataSet();
            con = GetConnection();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {
                con.Open();
                com = GetCommand("selectmonthly", ref con);
                com.CommandType = CommandType.StoredProcedure;




                OracleParameter prm21 = new OracleParameter("agcode", OracleType.VarChar);
                prm21.Direction = ParameterDirection.Input;
                prm21.Value = agcode;
                com.Parameters.Add(prm21);

                OracleParameter prm22 = new OracleParameter("fromdate", OracleType.VarChar);
                prm22.Direction = ParameterDirection.Input;
                if (fromdate == "")
                {
                    prm22.Value = System.DBNull.Value;
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
                    prm22.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");

                }

                com.Parameters.Add(prm22);

                OracleParameter prm23 = new OracleParameter("dateto", OracleType.VarChar);
                prm23.Direction = ParameterDirection.Input;
                if (dateto == "")
                {
                    prm23.Value = System.DBNull.Value;
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
                    prm23.Value = Convert.ToDateTime(dateto).ToString("dd-MMMM-yyyy");

                }

                com.Parameters.Add(prm23);

                OracleParameter prm24 = new OracleParameter("bookingid", OracleType.VarChar);
                prm24.Direction = ParameterDirection.Input;
                prm24.Value = bookingid;
                com.Parameters.Add(prm24);


                OracleParameter prm32 = new OracleParameter("Client", OracleType.VarChar);
                prm32.Direction = ParameterDirection.Input;
                if (Client == "")
                {
                    prm32.Value = System.DBNull.Value;

                }
                else
                {
                    prm32.Value = Client;
                }
                com.Parameters.Add(prm32);

                OracleParameter prm20 = new OracleParameter("dateformat", OracleType.VarChar);
                prm20.Direction = ParameterDirection.Input;
                prm20.Value = dateformat;
                com.Parameters.Add(prm20);


                OracleParameter prm45 = new OracleParameter("bookingtot", OracleType.VarChar);
                prm45.Direction = ParameterDirection.Input;
                prm45.Value = booking;
                com.Parameters.Add(prm45);




                com.Parameters.Add("p_classs", OracleType.Cursor);
                com.Parameters["p_classs"].Direction = ParameterDirection.Output;

                com.Parameters.Add("p_classs1", OracleType.Cursor);
                com.Parameters["p_classs1"].Direction = ParameterDirection.Output;


                com.Parameters.Add("p_classs2", OracleType.Cursor);
                com.Parameters["p_classs2"].Direction = ParameterDirection.Output;




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





        public DataSet selectmonthlynew_b(string agcode, string fromdate, string dateto, string bookingid, string Client, string dateformat, string bookingtot)
        {
            OracleConnection con;
            OracleCommand com;
            DataSet objDataSet = new DataSet();
            con = GetConnection();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {
                con.Open();
                com = GetCommand("selectmonthly_B", ref con);
                com.CommandType = CommandType.StoredProcedure;




                OracleParameter prm21 = new OracleParameter("agcode", OracleType.VarChar);
                prm21.Direction = ParameterDirection.Input;
                prm21.Value = agcode;
                com.Parameters.Add(prm21);

                OracleParameter prm22 = new OracleParameter("fromdate", OracleType.VarChar);
                prm22.Direction = ParameterDirection.Input;
                if (fromdate == "")
                {
                    prm22.Value = System.DBNull.Value;
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
                    prm22.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");

                }

                com.Parameters.Add(prm22);

                OracleParameter prm23 = new OracleParameter("dateto", OracleType.VarChar);
                prm23.Direction = ParameterDirection.Input;
                if (dateto == "")
                {
                    prm23.Value = System.DBNull.Value;
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
                    prm23.Value = Convert.ToDateTime(dateto).ToString("dd-MMMM-yyyy");

                }

                com.Parameters.Add(prm23);

                OracleParameter prm24 = new OracleParameter("bookingid", OracleType.VarChar);
                prm24.Direction = ParameterDirection.Input;
                prm24.Value = bookingid;
                com.Parameters.Add(prm24);


                OracleParameter prm32 = new OracleParameter("Client", OracleType.VarChar);
                prm32.Direction = ParameterDirection.Input;
                if (Client == "")
                {
                    prm32.Value = System.DBNull.Value;

                }
                else
                {
                    prm32.Value = Client;
                }
                com.Parameters.Add(prm32);

                OracleParameter prm20 = new OracleParameter("dateformat", OracleType.VarChar);
                prm20.Direction = ParameterDirection.Input;
                prm20.Value = dateformat;
                com.Parameters.Add(prm20);

                OracleParameter prm28 = new OracleParameter("bookingtot", OracleType.VarChar);
                prm28.Direction = ParameterDirection.Input;
                prm28.Value = bookingtot;
                com.Parameters.Add(prm28);



                com.Parameters.Add("p_classs", OracleType.Cursor);
                com.Parameters["p_classs"].Direction = ParameterDirection.Output;

                com.Parameters.Add("p_classs1", OracleType.Cursor);
                com.Parameters["p_classs1"].Direction = ParameterDirection.Output;


                com.Parameters.Add("p_classs2", OracleType.Cursor);
                com.Parameters["p_classs2"].Direction = ParameterDirection.Output;


                com.Parameters.Add("p_classs3", OracleType.Cursor);
                com.Parameters["p_classs3"].Direction = ParameterDirection.Output;


                com.Parameters.Add("p_classs4", OracleType.Cursor);
                com.Parameters["p_classs4"].Direction = ParameterDirection.Output;









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




        public DataSet selectmonthlynew(string agcode, string fromdate, string dateto, string bookingid, string Client, string dateformat, string bookingtot)
        {
            OracleConnection con;
            OracleCommand com;
            DataSet objDataSet = new DataSet();
            con = GetConnection();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {
                con.Open();
                com = GetCommand("selectmonthly", ref con);
                com.CommandType = CommandType.StoredProcedure;




                OracleParameter prm21 = new OracleParameter("agcode", OracleType.VarChar);
                prm21.Direction = ParameterDirection.Input;
                prm21.Value = agcode;
                com.Parameters.Add(prm21);

                OracleParameter prm22 = new OracleParameter("fromdate", OracleType.VarChar);
                prm22.Direction = ParameterDirection.Input;
                if (fromdate == "")
                {
                    prm22.Value = System.DBNull.Value;
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
                    prm22.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");

                }

                com.Parameters.Add(prm22);

                OracleParameter prm23 = new OracleParameter("dateto", OracleType.VarChar);
                prm23.Direction = ParameterDirection.Input;
                if (dateto == "")
                {
                    prm23.Value = System.DBNull.Value;
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
                    prm23.Value = Convert.ToDateTime(dateto).ToString("dd-MMMM-yyyy");

                }

                com.Parameters.Add(prm23);

                OracleParameter prm24 = new OracleParameter("bookingid", OracleType.VarChar);
                prm24.Direction = ParameterDirection.Input;
                prm24.Value = bookingid;
                com.Parameters.Add(prm24);


                OracleParameter prm32 = new OracleParameter("Client", OracleType.VarChar);
                prm32.Direction = ParameterDirection.Input;
                if (Client == "")
                {
                    prm32.Value = System.DBNull.Value;

                }
                else
                {
                    prm32.Value = Client;
                }
                com.Parameters.Add(prm32);

                OracleParameter prm20 = new OracleParameter("dateformat", OracleType.VarChar);
                prm20.Direction = ParameterDirection.Input;
                prm20.Value = dateformat;
                com.Parameters.Add(prm20);

                OracleParameter prm28 = new OracleParameter("bookingtot", OracleType.VarChar);
                prm28.Direction = ParameterDirection.Input;
                prm28.Value = bookingtot;
                com.Parameters.Add(prm28);



                com.Parameters.Add("p_classs", OracleType.Cursor);
                com.Parameters["p_classs"].Direction = ParameterDirection.Output;

                com.Parameters.Add("p_classs1", OracleType.Cursor);
                com.Parameters["p_classs1"].Direction = ParameterDirection.Output;


                com.Parameters.Add("p_classs2", OracleType.Cursor);
                com.Parameters["p_classs2"].Direction = ParameterDirection.Output;





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


        public DataSet bindbranch()
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("bind_branch.bind_branch_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;



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




        public DataSet FETACH_BILLDATE(string invoice_no, string dateformat)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("bill_fetchdate.bill_fetchdate_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm24 = new OracleParameter("v_invoice_no", OracleType.VarChar);
                prm24.Direction = ParameterDirection.Input;
                prm24.Value = invoice_no;
                objOraclecommand.Parameters.Add(prm24);




                OracleParameter prm20 = new OracleParameter("dateformat", OracleType.VarChar);
                prm20.Direction = ParameterDirection.Input;
                prm20.Value = dateformat;
                objOraclecommand.Parameters.Add(prm20);



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




        public DataSet selectlastnew(string bookingid, string dateformat,string fromdate,string dateto)
        {
            OracleConnection con;
            OracleCommand com;
            DataSet objDataSet = new DataSet();
            con = GetConnection();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {
                con.Open();
                com = GetCommand("Websp_Orderlastnew", ref con);
                com.CommandType = CommandType.StoredProcedure;





                OracleParameter prm24 = new OracleParameter("bookingid", OracleType.VarChar);
                prm24.Direction = ParameterDirection.Input;
                prm24.Value = bookingid;
                com.Parameters.Add(prm24);




                OracleParameter prm20 = new OracleParameter("dateformat", OracleType.VarChar);
                prm20.Direction = ParameterDirection.Input;
                prm20.Value = dateformat;
                com.Parameters.Add(prm20);





                OracleParameter prm22 = new OracleParameter("fromdate", OracleType.VarChar);
                prm22.Direction = ParameterDirection.Input;
                if (fromdate == "")
                {
                    prm22.Value = System.DBNull.Value;
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
                    prm22.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");

                }

                com.Parameters.Add(prm22);

                OracleParameter prm23 = new OracleParameter("dateto", OracleType.VarChar);
                prm23.Direction = ParameterDirection.Input;
                if (dateto == "")
                {
                    prm23.Value = System.DBNull.Value;
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
                    prm23.Value = Convert.ToDateTime(dateto).ToString("dd-MMMM-yyyy");

                }

                com.Parameters.Add(prm23);




                com.Parameters.Add("p_classs", OracleType.Cursor);
                com.Parameters["p_classs"].Direction = ParameterDirection.Output;

                //com.Parameters.Add("p_accounts1", OracleType.Cursor);
                //com.Parameters["p_accounts1"].Direction = ParameterDirection.Output;


                //com.Parameters.Add("p_accounts2", OracleType.Cursor);
                //com.Parameters["p_accounts2"].Direction = ParameterDirection.Output;




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





        public DataSet selectlastnew_billed(string bookingid, string dateformat, string fromdate, string dateto, string v_invoice, string compcode)
        {
            OracleConnection con;
            OracleCommand com;
            DataSet objDataSet = new DataSet();
            con = GetConnection();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {
                con.Open();
                com = GetCommand("Websp_Orderlastnew_b", ref con);
                com.CommandType = CommandType.StoredProcedure;





                OracleParameter prm24 = new OracleParameter("bookingid", OracleType.VarChar);
                prm24.Direction = ParameterDirection.Input;
                prm24.Value = bookingid;
                com.Parameters.Add(prm24);




                OracleParameter prm20 = new OracleParameter("dateformat", OracleType.VarChar);
                prm20.Direction = ParameterDirection.Input;
                prm20.Value = dateformat;
                com.Parameters.Add(prm20);




                OracleParameter prm22 = new OracleParameter("fromdate", OracleType.VarChar);
                prm22.Direction = ParameterDirection.Input;
                if (fromdate == "")
                {
                    prm22.Value = System.DBNull.Value;
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
                    prm22.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");

                }

                com.Parameters.Add(prm22);

                OracleParameter prm23 = new OracleParameter("dateto", OracleType.VarChar);
                prm23.Direction = ParameterDirection.Input;
                if (dateto == "")
                {
                    prm23.Value = System.DBNull.Value;
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
                    prm23.Value = Convert.ToDateTime(dateto).ToString("dd-MMMM-yyyy");

                }

                com.Parameters.Add(prm23);



                OracleParameter prm25 = new OracleParameter("v_invoice", OracleType.VarChar);
                prm25.Direction = ParameterDirection.Input;
                prm25.Value = v_invoice;
                com.Parameters.Add(prm25);

                OracleParameter prm26 = new OracleParameter("v_compcode", OracleType.VarChar);
                prm26.Direction = ParameterDirection.Input;
                prm26.Value = compcode;
                com.Parameters.Add(prm26);

                



                com.Parameters.Add("p_classs", OracleType.Cursor);
                com.Parameters["p_classs"].Direction = ParameterDirection.Output;

                com.Parameters.Add("p_accounts1", OracleType.Cursor);
                com.Parameters["p_accounts1"].Direction = ParameterDirection.Output;


                //com.Parameters.Add("p_accounts2", OracleType.Cursor);
                //com.Parameters["p_accounts2"].Direction = ParameterDirection.Output;




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






        public DataSet selectlast( string bookingid, string dateformat)
        {
            OracleConnection con;
            OracleCommand com;
            DataSet objDataSet = new DataSet();
            con = GetConnection();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {
                con.Open();
                com = GetCommand("Websp_orderlast", ref con);
                com.CommandType = CommandType.StoredProcedure;





                OracleParameter prm24 = new OracleParameter("bookingid", OracleType.VarChar);
                prm24.Direction = ParameterDirection.Input;
                prm24.Value = bookingid;
                com.Parameters.Add(prm24);


              

                OracleParameter prm20 = new OracleParameter("dateformat", OracleType.VarChar);
                prm20.Direction = ParameterDirection.Input;
                prm20.Value = dateformat;
                com.Parameters.Add(prm20);




                com.Parameters.Add("p_classs", OracleType.Cursor);
                com.Parameters["p_classs"].Direction = ParameterDirection.Output;

                com.Parameters.Add("p_accounts1", OracleType.Cursor);
                com.Parameters["p_accounts1"].Direction = ParameterDirection.Output;



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



        public DataSet fetchstatusmonthly(string BOOKINGID, string maxdate, string dateformat)
        {
            OracleConnection con;
            OracleCommand com;
            DataSet objDataSet = new DataSet();
            con = GetConnection();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {
                con.Open();
                com = GetCommand("fetchstatusmon", ref con);
                com.CommandType = CommandType.StoredProcedure;



                OracleParameter prm24 = new OracleParameter("BOOKINGID_v", OracleType.VarChar);
                prm24.Direction = ParameterDirection.Input;
                prm24.Value = BOOKINGID;
                com.Parameters.Add(prm24);


                OracleParameter prm23 = new OracleParameter("maxdate", OracleType.VarChar);
                prm23.Direction = ParameterDirection.Input;
                if (maxdate == "")
                {
                    prm23.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = maxdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        maxdate = mm + "/" + dd + "/" + yy;
                    }
                    prm23.Value = Convert.ToDateTime(maxdate).ToString("dd-MMMM-yyyy");

                }

                com.Parameters.Add(prm23);


               

                





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





        public DataSet fetchstatusmonthly1(string BOOKINGID, string maxdate, string dateformat, string comp_code)
        {
            OracleConnection con;
            OracleCommand com;
            DataSet objDataSet = new DataSet();
            con = GetConnection();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {
                con.Open();
                com = GetCommand("fetchstatusmon_n", ref con);
                com.CommandType = CommandType.StoredProcedure;



                OracleParameter prm24 = new OracleParameter("BOOKINGID_v", OracleType.VarChar);
                prm24.Direction = ParameterDirection.Input;
                prm24.Value = BOOKINGID;
                com.Parameters.Add(prm24);


                OracleParameter prm23 = new OracleParameter("maxdate", OracleType.VarChar);
                prm23.Direction = ParameterDirection.Input;
                if (maxdate == "")
                {
                    prm23.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = maxdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        maxdate = mm + "/" + dd + "/" + yy;
                    }
                    prm23.Value = Convert.ToDateTime(maxdate).ToString("dd-MMMM-yyyy");

                }

                com.Parameters.Add(prm23);


                OracleParameter prm22 = new OracleParameter("v_comp_code", OracleType.VarChar);
                prm22.Direction = ParameterDirection.Input;
                prm22.Value = comp_code;
                com.Parameters.Add(prm22);







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




        public DataSet save_det(string orderno, string invoice1, string grossamt, double billamt, double boxchg1, string ins_num, string edition_name)
        {
            OracleConnection con;
            OracleCommand com;
            DataSet objDataSet = new DataSet();
            con = GetConnection();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {

                con.Open();
                com = GetCommand("bill_save_det", ref con);
                com.CommandType = CommandType.StoredProcedure;



                OracleParameter prm21 = new OracleParameter("orderno1", OracleType.VarChar);
                prm21.Direction = ParameterDirection.Input;
                prm21.Value = orderno; 
                com.Parameters.Add(prm21);



                OracleParameter prm22 = new OracleParameter("invoice1", OracleType.VarChar);
                prm22.Direction = ParameterDirection.Input;
                prm22.Value = invoice1;
                com.Parameters.Add(prm22);


                OracleParameter prm23 = new OracleParameter("amountforvat", OracleType.VarChar);
                prm23.Direction = ParameterDirection.Input;
                prm23.Value = Convert.ToDecimal(grossamt);
                com.Parameters.Add(prm23);



                OracleParameter prm113 = new OracleParameter("edition_name", OracleType.VarChar);
                prm113.Direction = ParameterDirection.Input;
                prm113.Value = edition_name;
                com.Parameters.Add(prm113);


            

                OracleParameter prm25 = new OracleParameter("boxchg1", OracleType.VarChar);
                prm25.Direction = ParameterDirection.Input;
                prm25.Value = Convert.ToDecimal(boxchg1);
                com.Parameters.Add(prm25);







                OracleParameter prm114 = new OracleParameter("noofinsert", OracleType.VarChar);
                prm114.Direction = ParameterDirection.Input;
                prm114.Value = Convert.ToDecimal(ins_num);
                com.Parameters.Add(prm114);





              

                


        

            

            

               

            



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

























        public DataSet save_det_new1(string orderno, string invoice1, string grossamt, double billamt, double boxchg1, string ins_num, string edition_name, string dateto, string dateformat, string insert_id)
        {
            OracleConnection con;
            OracleCommand com;
            DataSet objDataSet = new DataSet();
            con = GetConnection();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {

                con.Open();
                com = GetCommand("bill_save_det_classi", ref con);
                com.CommandType = CommandType.StoredProcedure;



                OracleParameter prm21 = new OracleParameter("orderno1", OracleType.VarChar);
                prm21.Direction = ParameterDirection.Input;
                prm21.Value = orderno;
                com.Parameters.Add(prm21);



                OracleParameter prm22 = new OracleParameter("invoice1", OracleType.VarChar);
                prm22.Direction = ParameterDirection.Input;
                prm22.Value = invoice1;
                com.Parameters.Add(prm22);


                OracleParameter prm23 = new OracleParameter("amountforvat", OracleType.VarChar);
                prm23.Direction = ParameterDirection.Input;
                prm23.Value = Convert.ToDecimal(grossamt);
                com.Parameters.Add(prm23);



                OracleParameter prm113 = new OracleParameter("edition_name", OracleType.VarChar);
                prm113.Direction = ParameterDirection.Input;
                prm113.Value = edition_name;
                com.Parameters.Add(prm113);




                OracleParameter prm25 = new OracleParameter("boxchg1", OracleType.VarChar);
                prm25.Direction = ParameterDirection.Input;
                prm25.Value = Convert.ToDecimal(boxchg1);
                com.Parameters.Add(prm25);







                OracleParameter prm114 = new OracleParameter("noofinsert", OracleType.VarChar);
                prm114.Direction = ParameterDirection.Input;
                prm114.Value = Convert.ToDecimal(ins_num);
                com.Parameters.Add(prm114);





                OracleParameter prm123 = new OracleParameter("todate", OracleType.VarChar);
                prm123.Direction = ParameterDirection.Input;
                if (dateto == "")
                {
                    prm123.Value = System.DBNull.Value;
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
                    prm123.Value = Convert.ToDateTime(dateto).ToString("dd-MMMM-yyyy");

                }

                com.Parameters.Add(prm123);





                OracleParameter prm214 = new OracleParameter("v_insert_id", OracleType.VarChar);
                prm214.Direction = ParameterDirection.Input;
                prm214.Value = insert_id;
                com.Parameters.Add(prm214);












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










        public DataSet fetchinsertid(string insert_id)
        {
             OracleConnection con;
            OracleCommand com;
            DataSet objDataSet = new DataSet();
            con = GetConnection();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {

                con.Open();
                com = GetCommand("fetchsinsert_id", ref con);
                com.CommandType = CommandType.StoredProcedure;



                OracleParameter prm21 = new OracleParameter("insert_id_v", OracleType.VarChar);
                prm21.Direction = ParameterDirection.Input;
                prm21.Value = insert_id;
                com.Parameters.Add(prm21);





                com.Parameters.Add("get_executive", OracleType.Cursor);
                com.Parameters["get_executive"].Direction = ParameterDirection.Output;



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






        public string  save_det_monthly(string orderno, string invoice1, string grossamt, double billamt, double boxchg1, string ins_num, string edition_name, string maxdate, string dateformat, string insert_id,string fromdate)
        {
            OracleConnection con;
            OracleCommand com;
            DataSet objDataSet = new DataSet();
            con = GetConnection();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {

                con.Open();
                com = GetCommand("bill_save_det_monthly", ref con);
                com.CommandType = CommandType.StoredProcedure;



                OracleParameter prm21 = new OracleParameter("orderno1", OracleType.VarChar);
                prm21.Direction = ParameterDirection.Input;
                prm21.Value = orderno;
                com.Parameters.Add(prm21);



                OracleParameter prm22 = new OracleParameter("invoice1", OracleType.VarChar);
                prm22.Direction = ParameterDirection.Input;
                prm22.Value = invoice1;
                com.Parameters.Add(prm22);


                OracleParameter prm23 = new OracleParameter("amountforvat", OracleType.VarChar);
                prm23.Direction = ParameterDirection.Input;
                prm23.Value = Convert.ToDecimal(grossamt);
                com.Parameters.Add(prm23);



                OracleParameter prm113 = new OracleParameter("edition_name", OracleType.VarChar);
                prm113.Direction = ParameterDirection.Input;
                prm113.Value = edition_name;
                com.Parameters.Add(prm113);




                OracleParameter prm25 = new OracleParameter("boxchg1", OracleType.VarChar);
                prm25.Direction = ParameterDirection.Input;
                prm25.Value = Convert.ToDecimal(boxchg1);
                com.Parameters.Add(prm25);







                OracleParameter prm114 = new OracleParameter("noofinsert", OracleType.VarChar);
                prm114.Direction = ParameterDirection.Input;
                prm114.Value = Convert.ToDecimal(ins_num);
                com.Parameters.Add(prm114);





                OracleParameter prm24 = new OracleParameter("todate", OracleType.VarChar);
                prm24.Direction = ParameterDirection.Input;
                if (maxdate == "")
                {
                    prm24.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = maxdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        maxdate = mm + "/" + dd + "/" + yy;
                    }
                    prm24.Value = Convert.ToDateTime(maxdate).ToString("dd-MMMM-yyyy");

                }

                com.Parameters.Add(prm24);


                OracleParameter prm223 = new OracleParameter("fromdate", OracleType.VarChar);
                prm223.Direction = ParameterDirection.Input;
                if ( fromdate == "")
                {
                    prm223.Value = System.DBNull.Value;
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
                    prm223.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");

                }

                com.Parameters.Add(prm223);

                 OracleParameter prm115 = new OracleParameter("v_insert_id", OracleType.VarChar);
                prm115.Direction = ParameterDirection.Input;
                prm115.Value = insert_id;
                com.Parameters.Add(prm115);




                da.SelectCommand = com;
                com.ExecuteNonQuery();

                return "Success";
            }
            catch (Exception ex)
            {
                return "Fail";
            }
            finally
            {
                CloseConnection(ref con);
            }
        }








        public string  det_monthly_new(string orderno, string invoice1, string grossamt, double billamt, double boxchg1, string ins_num, string edition_name, string maxdate, string dateformat, string insert_id)
        {
            OracleConnection con;
            OracleCommand com;
            DataSet objDataSet = new DataSet();
            con = GetConnection();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {

                con.Open();
                com = GetCommand("det_monthly_new", ref con);
                com.CommandType = CommandType.StoredProcedure;



                OracleParameter prm21 = new OracleParameter("orderno1", OracleType.VarChar);
                prm21.Direction = ParameterDirection.Input;
                prm21.Value = orderno;
                com.Parameters.Add(prm21);



                OracleParameter prm22 = new OracleParameter("invoice1", OracleType.VarChar);
                prm22.Direction = ParameterDirection.Input;
                prm22.Value = invoice1;
                com.Parameters.Add(prm22);


                OracleParameter prm23 = new OracleParameter("amountforvat", OracleType.VarChar);
                prm23.Direction = ParameterDirection.Input;
                prm23.Value = Convert.ToDecimal(grossamt);
                com.Parameters.Add(prm23);



                OracleParameter prm113 = new OracleParameter("edition_name", OracleType.VarChar);
                prm113.Direction = ParameterDirection.Input;
                prm113.Value = edition_name;
                com.Parameters.Add(prm113);




                OracleParameter prm25 = new OracleParameter("boxchg1", OracleType.VarChar);
                prm25.Direction = ParameterDirection.Input;
                prm25.Value = Convert.ToDecimal(boxchg1);
                com.Parameters.Add(prm25);







                OracleParameter prm114 = new OracleParameter("noofinsert", OracleType.VarChar);
                prm114.Direction = ParameterDirection.Input;
                prm114.Value = Convert.ToDecimal(ins_num);
                com.Parameters.Add(prm114);





                OracleParameter prm24 = new OracleParameter("todate", OracleType.VarChar);
                prm24.Direction = ParameterDirection.Input;
                if (maxdate == "")
                {
                    prm24.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = maxdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        maxdate = mm + "/" + dd + "/" + yy;
                    }
                    prm24.Value = Convert.ToDateTime(maxdate).ToString("dd-MMMM-yyyy");

                }

                com.Parameters.Add(prm24);



                OracleParameter prm115 = new OracleParameter("v_insert_id", OracleType.VarChar);
                prm115.Direction = ParameterDirection.Input;
                prm115.Value = insert_id;
                com.Parameters.Add(prm115);






                da.SelectCommand = com;
                com.ExecuteNonQuery();

                return "Success";









               
            }
            catch (Exception ex)
            {
                return "Fail";
            }
            finally
            {
                CloseConnection(ref con);
            }
        }




        public DataSet saveinsertiowise(string orderno, string invoice1, string amountforvat, string amt3, int totinsert, double boxchg1, string noofinsertion, string edicode, double finalamount, double discountint, string doctyp, double premium)
        {
            OracleConnection con;
            OracleCommand com;
            DataSet objDataSet = new DataSet();
            con = GetConnection();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {
                con.Open();
                com = GetCommand("bill_saveinsertionwise1", ref con);
                com.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("orderno1", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = orderno;
                com.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("invoice1", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = invoice1;
                com.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("amountforvat", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = Convert.ToDouble(amountforvat);
                com.Parameters.Add(prm3);

                OracleParameter prm5 = new OracleParameter("amt3", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = Convert.ToDouble(amt3);
                com.Parameters.Add(prm5);

                OracleParameter prm4 = new OracleParameter("totinsert", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = totinsert;
                com.Parameters.Add(prm4);


                OracleParameter prm6 = new OracleParameter("boxchg1", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = boxchg1;
                com.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("noofinsertion", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = noofinsertion;
                com.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("edicode", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = edicode;
                com.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("finalamount", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = finalamount;
                com.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("discountint", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = discountint;
                com.Parameters.Add(prm10);

                OracleParameter prm111 = new OracleParameter("doctyp", OracleType.VarChar);
                prm111.Direction = ParameterDirection.Input;
                prm111.Value = doctyp;
                com.Parameters.Add(prm111);


                OracleParameter prm112 = new OracleParameter("premium_v", OracleType.VarChar);
                prm112.Direction = ParameterDirection.Input;
                prm112.Value = premium;
                com.Parameters.Add(prm112);



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


        public DataSet mothly_billingnew(string dateformat, string tilldate, string fromdate, string publication, string bookingcenter, string revenuecenter, string agencytype, string package, string adtype, string agency, string client, string billstatus, string rate_audit, string billmode, string billcycle, string comp_code, string userid, string DISP_CLSBILL)
        {
            OracleConnection con;
            OracleCommand com;
            DataSet objDataSet = new DataSet();
            con = GetConnection();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {




                con.Open();
                //com = GetCommand("websp_bindcioid.websp_bindcioid_p", ref con);
                //com.CommandType = CommandType.StoredProcedure;
                //com = GetCommand("websp_bindcioid1", ref con);
                //com.CommandType = CommandType.StoredProcedure;

                com = GetCommand("monthlynew.monthlynew_p", ref con);
                com.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pdate", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = dateformat;
                com.Parameters.Add(prm1);

                OracleParameter prm11 = new OracleParameter("ptodate", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                if (tilldate == "" || tilldate == null)
                {
                    prm11.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = tilldate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        tilldate = mm + "/" + dd + "/" + yy;


                    }
                    prm11.Value = Convert.ToDateTime(tilldate).ToString("dd-MMMM-yyyy");


                }
                com.Parameters.Add(prm11);


                OracleParameter prm12 = new OracleParameter("pfromdate", OracleType.VarChar);
                prm12.Direction = ParameterDirection.Input;
                if (fromdate == "" || fromdate == null)
                {
                    prm12.Value = System.DBNull.Value;

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
                    prm12.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");

                }
                com.Parameters.Add(prm12);

                OracleParameter prm13 = new OracleParameter("ppublication", OracleType.VarChar);
                prm13.Direction = ParameterDirection.Input;
                if (publication != "0")
                {
                    prm13.Value = publication;
                }
                else
                {
                    prm13.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm13);

                OracleParameter prm14 = new OracleParameter("pbookingcenter", OracleType.VarChar);
                prm14.Direction = ParameterDirection.Input;
                if (bookingcenter != "")
                {
                    prm14.Value = bookingcenter;
                }
                else
                {
                    prm14.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm14);


                OracleParameter prm15 = new OracleParameter("prevenuecenter", OracleType.VarChar);
                prm15.Direction = ParameterDirection.Input;
                if (revenuecenter != "")
                {
                    prm15.Value = revenuecenter;
                }
                else
                {
                    prm15.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm15);


                OracleParameter prm16 = new OracleParameter("pagencytype", OracleType.VarChar);
                prm16.Direction = ParameterDirection.Input;
                if (agencytype != "")
                {
                    prm16.Value = agencytype;
                }
                else
                {
                    prm16.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm16);

                OracleParameter prm17 = new OracleParameter("ppackage", OracleType.VarChar);
                prm17.Direction = ParameterDirection.Input;
                if (package != "")
                {
                    prm17.Value = package;
                }
                else
                {
                    prm17.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm17);

                OracleParameter prm18 = new OracleParameter("padtype", OracleType.VarChar);
                prm18.Direction = ParameterDirection.Input;
                if (adtype != "")
                {
                    prm18.Value = adtype;
                }
                else
                {
                    prm18.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm18);


                OracleParameter prm19 = new OracleParameter("pagency", OracleType.VarChar);
                prm19.Direction = ParameterDirection.Input;
                if (agency != "")
                {
                    prm19.Value = agency;
                }
                else
                {
                    prm19.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm19);


                OracleParameter prm21 = new OracleParameter("pclient", OracleType.VarChar);
                prm21.Direction = ParameterDirection.Input;
                if (client != "")
                {
                    prm21.Value = client;
                }
                else
                {
                    prm21.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm21);


                OracleParameter prm22 = new OracleParameter("pbillstatus", OracleType.VarChar);
                prm22.Direction = ParameterDirection.Input;
                if (billstatus != "")
                {
                    prm22.Value = billstatus;
                }
                else
                {
                    prm22.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm22);

                OracleParameter prm23 = new OracleParameter("prate_audit", OracleType.VarChar);
                prm23.Direction = ParameterDirection.Input;
                prm23.Value = rate_audit;
                com.Parameters.Add(prm23);



                OracleParameter prm24 = new OracleParameter("pbillmode", OracleType.VarChar);
                prm24.Direction = ParameterDirection.Input;
                prm24.Value = System.DBNull.Value;
                com.Parameters.Add(prm24);

                OracleParameter prm25 = new OracleParameter("pbillcycle", OracleType.VarChar);
                prm25.Direction = ParameterDirection.Input;
                if ((billcycle == "0") || (billcycle == "1"))
                {
                    prm25.Value = "0" + "','" + "1";
                }
                else
                {
                    prm25.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm25);

                OracleParameter prm26 = new OracleParameter("pcompcode", OracleType.VarChar);
                prm26.Direction = ParameterDirection.Input;
                prm26.Value = comp_code;
                com.Parameters.Add(prm26);

                OracleParameter prm27 = new OracleParameter("puserid", OracleType.VarChar);
                prm27.Direction = ParameterDirection.Input;
                prm27.Value = userid;
                com.Parameters.Add(prm27);

                OracleParameter prm28 = new OracleParameter("DISP_CLSBILL", OracleType.VarChar);
                prm28.Direction = ParameterDirection.Input;
                prm28.Value = DISP_CLSBILL;
                com.Parameters.Add(prm28);

                



                com.Parameters.Add("p_accounts", OracleType.Cursor);
                com.Parameters["p_accounts"].Direction = ParameterDirection.Output;



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




        public DataSet mothly_billingnew_retainer(string dateformat, string tilldate, string fromdate, string publication, string bookingcenter, string revenuecenter, string agencytype, string package, string adtype, string agency, string client, string billstatus, string rate_audit, string billmode, string billcycle, string comp_code, string userid, string DISP_CLSBILL, string exe_code, string ret_code, string ad_category, string district, string taluka, string CLA_CASHBILL, string BILL_CLA_CASHBILL,string  center, string bill_no)
        {
            OracleConnection con;
            OracleCommand com;
            DataSet objDataSet = new DataSet();
            con = GetConnection();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {




                con.Open();
                //com = GetCommand("websp_bindcioid.websp_bindcioid_p", ref con);
                //com.CommandType = CommandType.StoredProcedure;
                //com = GetCommand("websp_bindcioid1", ref con);
                //com.CommandType = CommandType.StoredProcedure;

                com = GetCommand("monthlynew_retainer1.monthlynew_retainer1_p", ref con);
                com.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pdate", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = dateformat;
                com.Parameters.Add(prm1);

                OracleParameter prm11 = new OracleParameter("ptodate", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                if (tilldate == "" || tilldate == null)
                {
                    prm11.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = tilldate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        tilldate = mm + "/" + dd + "/" + yy;


                    }
                    prm11.Value = Convert.ToDateTime(tilldate).ToString("dd-MMMM-yyyy");


                }
                com.Parameters.Add(prm11);


                OracleParameter prm12 = new OracleParameter("pfromdate", OracleType.VarChar);
                prm12.Direction = ParameterDirection.Input;
                if (fromdate == "" || fromdate == null)
                {
                    prm12.Value = System.DBNull.Value;

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
                    prm12.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");

                }
                com.Parameters.Add(prm12);

                OracleParameter prm13 = new OracleParameter("ppublication", OracleType.VarChar);
                prm13.Direction = ParameterDirection.Input;
                if (publication != "0")
                {
                    prm13.Value = publication;
                }
                else
                {
                    prm13.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm13);

                OracleParameter prm14 = new OracleParameter("pbookingcenter", OracleType.VarChar);
                prm14.Direction = ParameterDirection.Input;
                if (bookingcenter != "")
                {
                    prm14.Value = bookingcenter;
                }
                else
                {
                    prm14.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm14);


                OracleParameter prm15 = new OracleParameter("prevenuecenter", OracleType.VarChar);
                prm15.Direction = ParameterDirection.Input;
                if (revenuecenter != "")
                {
                    prm15.Value = revenuecenter;
                }
                else
                {
                    prm15.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm15);


                OracleParameter prm16 = new OracleParameter("pagencytype", OracleType.VarChar);
                prm16.Direction = ParameterDirection.Input;
                if (agencytype != "")
                {
                    prm16.Value = agencytype;
                }
                else
                {
                    prm16.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm16);

                OracleParameter prm17 = new OracleParameter("ppackage", OracleType.VarChar);
                prm17.Direction = ParameterDirection.Input;
                if (package != "")
                {
                    prm17.Value = package;
                }
                else
                {
                    prm17.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm17);

                OracleParameter prm18 = new OracleParameter("padtype", OracleType.VarChar);
                prm18.Direction = ParameterDirection.Input;
                if (adtype != "")
                {
                    prm18.Value = adtype;
                }
                else
                {
                    prm18.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm18);


                OracleParameter prm19 = new OracleParameter("pagency", OracleType.VarChar);
                prm19.Direction = ParameterDirection.Input;
                if (agency != "")
                {
                    prm19.Value = agency;
                }
                else
                {
                    prm19.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm19);


                OracleParameter prm21 = new OracleParameter("pclient", OracleType.VarChar);
                prm21.Direction = ParameterDirection.Input;
                if (client != "")
                {
                    prm21.Value = client;
                }
                else
                {
                    prm21.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm21);


                OracleParameter prm22 = new OracleParameter("pbillstatus", OracleType.VarChar);
                prm22.Direction = ParameterDirection.Input;
                if (billstatus != "")
                {
                    prm22.Value = billstatus;
                }
                else
                {
                    prm22.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm22);

                OracleParameter prm23 = new OracleParameter("prate_audit", OracleType.VarChar);
                prm23.Direction = ParameterDirection.Input;
                prm23.Value = rate_audit;
                com.Parameters.Add(prm23);



                OracleParameter prm24 = new OracleParameter("pbillmode", OracleType.VarChar);
                prm24.Direction = ParameterDirection.Input;
                prm24.Value = System.DBNull.Value;
                com.Parameters.Add(prm24);

                OracleParameter prm25 = new OracleParameter("pbillcycle", OracleType.VarChar);
                prm25.Direction = ParameterDirection.Input;
                if ((billcycle == "0") || (billcycle == "1"))
                {
                    prm25.Value = "0" + "','" + "1";
                }
                else
                {
                    prm25.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm25);

                OracleParameter prm26 = new OracleParameter("pcompcode", OracleType.VarChar);
                prm26.Direction = ParameterDirection.Input;
                prm26.Value = comp_code;
                com.Parameters.Add(prm26);

                OracleParameter prm27 = new OracleParameter("puserid", OracleType.VarChar);
                prm27.Direction = ParameterDirection.Input;
                prm27.Value = userid;
                com.Parameters.Add(prm27);

                OracleParameter prm28 = new OracleParameter("DISP_CLSBILL", OracleType.VarChar);
                prm28.Direction = ParameterDirection.Input;
                prm28.Value = DISP_CLSBILL;
                com.Parameters.Add(prm28);

                OracleParameter prm29 = new OracleParameter("pexe_code", OracleType.VarChar);
                prm29.Direction = ParameterDirection.Input;
                    if(exe_code=="0")
                    {
                         prm29.Value =System .DBNull .Value ;
                    }
                    else
                    {
                prm29.Value = exe_code;
                    }
                com.Parameters.Add(prm29);


                OracleParameter prm30 = new OracleParameter("pret_code", OracleType.VarChar);
                prm30.Direction = ParameterDirection.Input;
                if (ret_code=="0")
                {
                    prm30.Value = System.DBNull.Value;
                }
                else
                {
                prm30.Value = ret_code;
                }
                com.Parameters.Add(prm30);





                OracleParameter prm132 = new OracleParameter("v_ad_category", OracleType.VarChar);
                prm132.Direction = ParameterDirection.Input;
                if (ad_category == "0")
                {
                    prm132.Value = System.DBNull.Value;
                }
                else
                {
                    prm132.Value = ad_category;
                }
                com.Parameters.Add(prm132);



                OracleParameter prm131 = new OracleParameter("v_district", OracleType.VarChar);
                prm30.Direction = ParameterDirection.Input;
                if (district == "0")
                {
                    prm131.Value = System.DBNull.Value;
                }
                else
                {
                    prm131.Value = district;
                }
                com.Parameters.Add(prm131);



                OracleParameter prm130 = new OracleParameter("v_taluka", OracleType.VarChar);
                prm130.Direction = ParameterDirection.Input;
                if (taluka == "0")
                {
                    prm130.Value = System.DBNull.Value;
                }
                else
                {
                    prm130.Value = taluka;
                }
                com.Parameters.Add(prm130);



                OracleParameter prm151= new OracleParameter("V_CLA_CASHBILL", OracleType.VarChar);
                prm151.Direction = ParameterDirection.Input;
                prm151.Value = CLA_CASHBILL;
                com.Parameters.Add(prm151);


                OracleParameter prm152 = new OracleParameter("V_BILL_CLA_CASHBILL", OracleType.VarChar);
                prm152.Direction = ParameterDirection.Input;
                prm152.Value = BILL_CLA_CASHBILL;
                com.Parameters.Add(prm152);



                OracleParameter prm153 = new OracleParameter("V_center", OracleType.VarChar);
                prm153.Direction = ParameterDirection.Input;
                prm153.Value = center;
                com.Parameters.Add(prm153);


                OracleParameter prm154 = new OracleParameter("pbill_no", OracleType.VarChar);
                prm154.Direction = ParameterDirection.Input;
                if (bill_no=="")
                {
                    prm154.Value = System.DBNull.Value;
                }
                else
                {
                prm154.Value = bill_no;
                }
                com.Parameters.Add(prm154);










                
                








                com.Parameters.Add("p_accounts", OracleType.Cursor);
                com.Parameters["p_accounts"].Direction = ParameterDirection.Output;



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





        public DataSet updatemonthlynew(string bookingid, string ins_no, string edition, string bill_no, string billdate,string dateformat)
        {
            OracleConnection con;
            OracleCommand com;
            DataSet objDataSet = new DataSet();
            con = GetConnection();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {

                con.Open();
                com = GetCommand("websp_updatemonthly", ref con);
                com.CommandType = CommandType.StoredProcedure;           
               

                OracleParameter prm21 = new OracleParameter("bookingid_v", OracleType.VarChar);
                prm21.Direction = ParameterDirection.Input;
                prm21.Value = bookingid;
                com.Parameters.Add(prm21);

                OracleParameter prm22 = new OracleParameter("ins_no_v", OracleType.VarChar);
                prm22.Direction = ParameterDirection.Input;
                prm22.Value = ins_no;
                com.Parameters.Add(prm22);

                OracleParameter prm23 = new OracleParameter("bill_no_v", OracleType.VarChar);
                prm23.Direction = ParameterDirection.Input;
                prm23.Value = bill_no;
                com.Parameters.Add(prm23);

                OracleParameter prm113 = new OracleParameter("bill_date_v", OracleType.VarChar);
                prm113.Direction = ParameterDirection.Input;

                if (billdate == "" || billdate == null)
                {
                    prm113.Value = System.DBNull.Value;

                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = billdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        billdate = mm + "/" + dd + "/" + yy;


                    }
                    prm113.Value = Convert.ToDateTime(billdate).ToString("dd-MMMM-yyyy");

                }               

                com.Parameters.Add(prm113);

                OracleParameter prm25 = new OracleParameter("edition_new_v", OracleType.VarChar);
                prm25.Direction = ParameterDirection.Input;
                prm25.Value = edition;
                com.Parameters.Add(prm25);

            


















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










        public DataSet chkadbills(string agcode, string maxdate,string dateformat)
        {
            OracleConnection con;
            OracleCommand com;
            DataSet objDataSet = new DataSet();
            con = GetConnection();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {
                con.Open();
                com = GetCommand("websp_chk", ref con);
                com.CommandType = CommandType.StoredProcedure;



                OracleParameter prm24 = new OracleParameter("agcode_v", OracleType.VarChar);
                prm24.Direction = ParameterDirection.Input;
                prm24.Value = agcode;
                com.Parameters.Add(prm24);


                OracleParameter prm23 = new OracleParameter("maxdate", OracleType.VarChar);
                prm23.Direction = ParameterDirection.Input;
                if (maxdate == "")
                {
                    prm23.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = maxdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        maxdate = mm + "/" + dd + "/" + yy;
                    }
                    prm23.Value = Convert.ToDateTime(maxdate).ToString("dd-MMMM-yyyy");

                }

                com.Parameters.Add(prm23);



             







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




        public DataSet save_monthly(string orderno, string invoice1, string amountforvat, string amt3, double boxchg1, int total_ins_num, string maxins, string date_time, string maxdate,string dateformat)
        {
            OracleConnection con;
            OracleCommand com;
            DataSet objDataSet = new DataSet();
            con = GetConnection();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {
                con.Open();
                com = GetCommand("bill_save_monthly.bill_save_monthly_p", ref con);
                com.CommandType = CommandType.StoredProcedure;              
	
	
 


                OracleParameter prm1 = new OracleParameter("porderno1", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = orderno;
                com.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("pinvoice1", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = invoice1;
                com.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("pamountforvat", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = Convert.ToDouble(amountforvat);
                com.Parameters.Add(prm3);

                OracleParameter prm5 = new OracleParameter("pamt3", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = Convert.ToDouble(amt3);
                com.Parameters.Add(prm5);           

             


                OracleParameter prm4 = new OracleParameter("pmaxinsert", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = maxins;
                com.Parameters.Add(prm4);


                OracleParameter prm6 = new OracleParameter("pboxchg1", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = boxchg1;
                com.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("pnoofinsert", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = total_ins_num;
                com.Parameters.Add(prm7);



                OracleParameter prm24 = new OracleParameter("pdate_time", OracleType.VarChar);
                prm24.Direction = ParameterDirection.Input;
                if (date_time == "")
                {
                    prm24.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = date_time.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        maxdate = mm + "/" + dd + "/" + yy;
                    }
                    prm24.Value = Convert.ToDateTime(date_time).ToString("dd-MMMM-yyyy");

                }

                com.Parameters.Add(prm24);


                OracleParameter prm23 = new OracleParameter("pmaxdate", OracleType.VarChar);
                prm23.Direction = ParameterDirection.Input;
                if (maxdate == "")
                {
                    prm23.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = maxdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        maxdate = mm + "/" + dd + "/" + yy;
                    }
                    prm23.Value = Convert.ToDateTime(maxdate).ToString("dd-MMMM-yyyy");

                }

                com.Parameters.Add(prm23);

                //com.Parameters.Add("p_accounts", OracleType.Cursor);
                //com.Parameters["p_accounts"].Direction = ParameterDirection.Output;




          



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

        public DataSet maxdatenew(string dateformat, string tilldate, string fromdate, string publication, string bookingcenter, string revenuecenter, string agencytype, string package, string adtype, string agency, string client, string billstatus, string rate_audit, string billmode, string billcycle, string compcode, string userid, string DISP_CLSBILL)
        {
            OracleConnection con;
            OracleCommand com;
            DataSet objDataSet = new DataSet();
            con = GetConnection();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {

                con.Open();
                com = GetCommand("selectmaxnew", ref con);
                com.CommandType = CommandType.StoredProcedure;


                OracleParameter prm21 = new OracleParameter("pdateformat", OracleType.VarChar);
                prm21.Direction = ParameterDirection.Input;
                prm21.Value = dateformat;
                com.Parameters.Add(prm21);




                OracleParameter prm22 = new OracleParameter("ptodate", OracleType.VarChar);
                prm22.Direction = ParameterDirection.Input;

                if (tilldate == "" || tilldate == null)
                {
                    prm22.Value = System.DBNull.Value;

                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = tilldate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        tilldate = mm + "/" + dd + "/" + yy;


                    }
                    prm22.Value = Convert.ToDateTime(tilldate).ToString("dd-MMMM-yyyy");

                }
                com.Parameters.Add(prm22);

                OracleParameter prm23 = new OracleParameter("pfromdate", OracleType.VarChar);
                prm23.Direction = ParameterDirection.Input;

                if (fromdate == "" || fromdate == null)
                {
                    prm23.Value = System.DBNull.Value;

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
                    prm23.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");

                }
                com.Parameters.Add(prm23);

                OracleParameter prm24 = new OracleParameter("ppublication", OracleType.VarChar);
                prm24.Direction = ParameterDirection.Input;
                if (publication != "0")
                {


                    prm24.Value = publication;
                }
                else
                {
                    prm24.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm24);

                OracleParameter prm25 = new OracleParameter("pbookingcenter", OracleType.VarChar);
                prm25.Direction = ParameterDirection.Input;
                if (bookingcenter != "")
                {
                    prm25.Value = bookingcenter;
                }
                else
                {
                    prm25.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm25);


                OracleParameter prm26 = new OracleParameter("prevenuecenter", OracleType.VarChar);
                prm26.Direction = ParameterDirection.Input;
                if (revenuecenter != "")
                {

                    prm26.Value = revenuecenter;
                }
                else
                {
                    prm26.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm26);

                OracleParameter prm27 = new OracleParameter("pagencytype", OracleType.VarChar);
                prm27.Direction = ParameterDirection.Input;
                if (agencytype != "")
                {

                    prm27.Value = agencytype;
                }
                else
                {
                    prm27.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm27);

                OracleParameter prm28 = new OracleParameter("ppckage", OracleType.VarChar);
                prm28.Direction = ParameterDirection.Input;
                if (package != "")
                {
                    prm28.Value = package;
                }
                else
                {
                    prm28.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm28);

                OracleParameter prm29 = new OracleParameter("padtype", OracleType.VarChar);
                prm29.Direction = ParameterDirection.Input;
                if (adtype != "0")
                {
                    prm29.Value = adtype;
                }
                else
                {
                    prm29.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm29);


                OracleParameter prm30 = new OracleParameter("pagency", OracleType.VarChar);
                prm30.Direction = ParameterDirection.Input;
                if (agency != "")
                {
                    prm30.Value = agency;
                }
                else
                {
                    prm30.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm30);

                OracleParameter prm31 = new OracleParameter("pclient", OracleType.VarChar);
                prm31.Direction = ParameterDirection.Input;
                if (client != "")
                {
                    prm31.Value = client;
                }
                else
                {
                    prm31.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm31);

                OracleParameter prm32 = new OracleParameter("pbillstatus", OracleType.VarChar);
                prm32.Direction = ParameterDirection.Input;
                if (billstatus != "0")
                {
                    prm32.Value = billstatus;
                }
                else
                {
                    prm32.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm32);

                OracleParameter prm20 = new OracleParameter("prate_audit", OracleType.VarChar);
                prm20.Direction = ParameterDirection.Input;
                prm20.Value = rate_audit;
                com.Parameters.Add(prm20);


                OracleParameter prm42 = new OracleParameter("pbillmode", OracleType.VarChar);
                prm42.Direction = ParameterDirection.Input;
                prm42.Value = System.DBNull.Value;
                com.Parameters.Add(prm42);


                OracleParameter prm43 = new OracleParameter("pbillcycle", OracleType.VarChar);
                prm43.Direction = ParameterDirection.Input;
                if ((billcycle == "0") || (billcycle == "1"))
                {
                    prm43.Value = "0" + "','" + "1";
                }
                else
                {
                    prm43.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm43);

                OracleParameter prm44 = new OracleParameter("pcompcode", OracleType.VarChar);
                prm44.Direction = ParameterDirection.Input;
                prm44.Value = compcode;
                com.Parameters.Add(prm44);


                OracleParameter prm45 = new OracleParameter("puserid", OracleType.VarChar);
                prm45.Direction = ParameterDirection.Input;
                prm45.Value = userid;
                com.Parameters.Add(prm45);


                OracleParameter prm46 = new OracleParameter("DISP_CLSBILL", OracleType.VarChar);
                prm46.Direction = ParameterDirection.Input;
                prm46.Value = DISP_CLSBILL;
                com.Parameters.Add(prm46);

                





                com.Parameters.Add("p_recordsetmis", OracleType.Cursor);
                com.Parameters["p_recordsetmis"].Direction = ParameterDirection.Output;














                //com.Parameters.Add("rate_audit", OracleType.Cursor);
                //com.Parameters["rate_audit"].Direction = ParameterDirection.Output;





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



        public DataSet maxdatenew_summary(string dateformat, string tilldate, string fromdate, string publication, string bookingcenter, string revenuecenter, string agencytype, string package, string adtype, string agency, string client, string billstatus, string rate_audit, string billmode, string billcycle, string compcode, string userid)
        {
            OracleConnection con;
            OracleCommand com;
            DataSet objDataSet = new DataSet();
            con = GetConnection();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {

                con.Open();
                //com = GetCommand("selectmaxsummary.selectmaxsummaryP", ref con);
                //com.CommandType = CommandType.StoredProcedure;

                com = GetCommand("selectmaxsummary.selectmaxsummaryP", ref con);
               com.CommandType = CommandType.StoredProcedure;

                


                OracleParameter prm21 = new OracleParameter("pdateformat", OracleType.VarChar);
                prm21.Direction = ParameterDirection.Input;
                prm21.Value = dateformat;
                com.Parameters.Add(prm21);




                OracleParameter prm22 = new OracleParameter("ptodate", OracleType.VarChar);
                prm22.Direction = ParameterDirection.Input;

                if (tilldate == "" || tilldate == null)
                {
                    prm22.Value = System.DBNull.Value;

                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = tilldate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        tilldate = mm + "/" + dd + "/" + yy;


                    }
                    prm22.Value = Convert.ToDateTime(tilldate).ToString("dd-MMMM-yyyy");

                }
                com.Parameters.Add(prm22);

                OracleParameter prm23 = new OracleParameter("pfromdate", OracleType.VarChar);
                prm23.Direction = ParameterDirection.Input;

                if (fromdate == "" || fromdate == null)
                {
                    prm23.Value = System.DBNull.Value;

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
                    prm23.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");

                }
                com.Parameters.Add(prm23);

                OracleParameter prm24 = new OracleParameter("ppublication", OracleType.VarChar);
                prm24.Direction = ParameterDirection.Input;
                if (publication != "0")
                {


                    prm24.Value = publication;
                }
                else
                {
                    prm24.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm24);

                OracleParameter prm25 = new OracleParameter("pbookingcenter", OracleType.VarChar);
                prm25.Direction = ParameterDirection.Input;
                if (bookingcenter != "")
                {
                    prm25.Value = bookingcenter;
                }
                else
                {
                    prm25.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm25);


                OracleParameter prm26 = new OracleParameter("prevenuecenter", OracleType.VarChar);
                prm26.Direction = ParameterDirection.Input;
                if (revenuecenter != "")
                {

                    prm26.Value = revenuecenter;
                }
                else
                {
                    prm26.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm26);

                OracleParameter prm27 = new OracleParameter("pagencytype", OracleType.VarChar);
                prm27.Direction = ParameterDirection.Input;
                if (agencytype != "")
                {

                    prm27.Value = agencytype;
                }
                else
                {
                    prm27.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm27);

                OracleParameter prm28 = new OracleParameter("ppckage", OracleType.VarChar);
                prm28.Direction = ParameterDirection.Input;
                if (package != "")
                {
                    prm28.Value = package;
                }
                else
                {
                    prm28.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm28);

                OracleParameter prm29 = new OracleParameter("padtype", OracleType.VarChar);
                prm29.Direction = ParameterDirection.Input;
                if (adtype != "0")
                {
                    prm29.Value = adtype;
                }
                else
                {
                    prm29.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm29);


                OracleParameter prm30 = new OracleParameter("pagency", OracleType.VarChar);
                prm30.Direction = ParameterDirection.Input;
                if (agency != "")
                {
                    prm30.Value = agency;
                }
                else
                {
                    prm30.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm30);

                OracleParameter prm31 = new OracleParameter("pclient", OracleType.VarChar);
                prm31.Direction = ParameterDirection.Input;
                if (client != "")
                {
                    prm31.Value = client;
                }
                else
                {
                    prm31.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm31);

                OracleParameter prm32 = new OracleParameter("pbillstatus", OracleType.VarChar);
                prm32.Direction = ParameterDirection.Input;
                if (billstatus != "0")
                {
                    prm32.Value = billstatus;
                }
                else
                {
                    prm32.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm32);

                OracleParameter prm20 = new OracleParameter("prate_audit", OracleType.VarChar);
                prm20.Direction = ParameterDirection.Input;
                prm20.Value = rate_audit;
                com.Parameters.Add(prm20);


                OracleParameter prm42 = new OracleParameter("pbillmode", OracleType.VarChar);
                prm42.Direction = ParameterDirection.Input;
                prm42.Value = System.DBNull.Value;
                com.Parameters.Add(prm42);


                OracleParameter prm43 = new OracleParameter("pbillcycle", OracleType.VarChar);
                prm43.Direction = ParameterDirection.Input;
                if ((billcycle == "0") || (billcycle == "1"))
                {
                    prm43.Value = "0" + "','" + "1";
                }
                else
                {
                    prm43.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm43);

                OracleParameter prm44 = new OracleParameter("pcompcode", OracleType.VarChar);
                prm44.Direction = ParameterDirection.Input;
                prm44.Value = compcode;
                com.Parameters.Add(prm44);


                OracleParameter prm45 = new OracleParameter("puserid", OracleType.VarChar);
                prm45.Direction = ParameterDirection.Input;
                prm45.Value = userid;
                com.Parameters.Add(prm45);





                com.Parameters.Add("p_accounts", OracleType.Cursor);
                com.Parameters["p_accounts"].Direction = ParameterDirection.Output;














                //com.Parameters.Add("rate_audit", OracleType.Cursor);
                //com.Parameters["rate_audit"].Direction = ParameterDirection.Output;





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









        public DataSet save_last(string orderno, string invoice1, string amountforvat, string amt3, double boxchg1, int total_ins_num, string maxins, string date_time, string maxdate, string dateformat)
        {
            OracleConnection con;
            OracleCommand com;
            DataSet objDataSet = new DataSet();
            con = GetConnection();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {
                con.Open();
                com = GetCommand("bill_save_monthly.bill_save_monthly_p", ref con);
                com.CommandType = CommandType.StoredProcedure;





                OracleParameter prm1 = new OracleParameter("porderno1", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = orderno;
                com.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("pinvoice1", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = invoice1;
                com.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("pamountforvat", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = Convert.ToDouble(amountforvat);
                com.Parameters.Add(prm3);

                OracleParameter prm5 = new OracleParameter("pamt3", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = Convert.ToDouble(amt3);
                com.Parameters.Add(prm5);




                OracleParameter prm4 = new OracleParameter("pmaxinsert", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = maxins;
                com.Parameters.Add(prm4);


                OracleParameter prm6 = new OracleParameter("pboxchg1", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = boxchg1;
                com.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("pnoofinsert", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = total_ins_num;
                com.Parameters.Add(prm7);



                OracleParameter prm24 = new OracleParameter("pdate_time", OracleType.VarChar);
                prm24.Direction = ParameterDirection.Input;
                if (date_time == "")
                {
                    prm24.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = date_time.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        maxdate = mm + "/" + dd + "/" + yy;
                    }
                    prm24.Value = Convert.ToDateTime(date_time).ToString("dd-MMMM-yyyy");

                }

                com.Parameters.Add(prm24);


                OracleParameter prm23 = new OracleParameter("pmaxdate", OracleType.VarChar);
                prm23.Direction = ParameterDirection.Input;
                if (maxdate == "")
                {
                    prm23.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = maxdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        maxdate = mm + "/" + dd + "/" + yy;
                    }
                    prm23.Value = Convert.ToDateTime(maxdate).ToString("dd-MMMM-yyyy");

                }

                com.Parameters.Add(prm23);

                //com.Parameters.Add("p_accounts", OracleType.Cursor);
                //com.Parameters["p_accounts"].Direction = ParameterDirection.Output;








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



        public DataSet summary_insertion(string dateformat, string tilldate, string fromdate, string publication, string bookingcenter, string revenuecenter, string agencytype, string package, string adtype, string agency, string client, string billstatus, string rate_audit, string billmode, string billcycle)
        {
            OracleConnection con;
            OracleCommand com;
            DataSet objDataSet = new DataSet();
            con = GetConnection();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {

                con.Open();
             

                com = GetCommand("Websp_Bindsummary", ref con);
                com.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("date1", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = dateformat;
                com.Parameters.Add(prm1);

                OracleParameter prm11 = new OracleParameter("todate", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                if (tilldate == "" || tilldate == null)
                {
                    prm11.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = tilldate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        tilldate = mm + "/" + dd + "/" + yy;


                    }
                    prm11.Value = Convert.ToDateTime(tilldate).ToString("dd-MMMM-yyyy");


                }
                com.Parameters.Add(prm11);


                OracleParameter prm12 = new OracleParameter("fromdate", OracleType.VarChar);
                prm12.Direction = ParameterDirection.Input;
                if (fromdate == "" || fromdate == null)
                {
                    prm12.Value = System.DBNull.Value;

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
                    prm12.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");

                }
                com.Parameters.Add(prm12);

                OracleParameter prm13 = new OracleParameter("publication", OracleType.VarChar);
                prm13.Direction = ParameterDirection.Input;
                if (publication != "0")
                {
                    prm13.Value = publication;
                }
                else
                {
                    prm13.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm13);

                OracleParameter prm14 = new OracleParameter("bookingcenter", OracleType.VarChar);
                prm14.Direction = ParameterDirection.Input;
                if (bookingcenter != "")
                {
                    prm14.Value = bookingcenter;
                }
                else
                {
                    prm14.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm14);


                OracleParameter prm15 = new OracleParameter("revenuecenter", OracleType.VarChar);
                prm15.Direction = ParameterDirection.Input;
                if (revenuecenter != "")
                {
                    prm15.Value = revenuecenter;
                }
                else
                {
                    prm15.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm15);


                OracleParameter prm16 = new OracleParameter("agencytype", OracleType.VarChar);
                prm16.Direction = ParameterDirection.Input;
                if (agencytype != "")
                {
                    prm16.Value = agencytype;
                }
                else
                {
                    prm16.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm16);

                OracleParameter prm17 = new OracleParameter("package1", OracleType.VarChar);
                prm17.Direction = ParameterDirection.Input;
                if (package != "")
                {
                    prm17.Value = package;
                }
                else
                {
                    prm17.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm17);

                OracleParameter prm18 = new OracleParameter("adtype1", OracleType.VarChar);
                prm18.Direction = ParameterDirection.Input;
                if (adtype != "")
                {
                    prm18.Value = adtype;
                }
                else
                {
                    prm18.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm18);


                OracleParameter prm19 = new OracleParameter("agency", OracleType.VarChar);
                prm19.Direction = ParameterDirection.Input;
                if (agency != "")
                {
                    prm19.Value = agency;
                }
                else
                {
                    prm19.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm19);


                OracleParameter prm21 = new OracleParameter("client", OracleType.VarChar);
                prm21.Direction = ParameterDirection.Input;
                if (client != "")
                {
                    prm21.Value = client;
                }
                else
                {
                    prm21.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm21);


                OracleParameter prm22 = new OracleParameter("billstatus", OracleType.VarChar);
                prm22.Direction = ParameterDirection.Input;
                if (billstatus != "")
                {
                    prm22.Value = billstatus;
                }
                else
                {
                    prm22.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm22);

                OracleParameter prm23 = new OracleParameter("rate_audit", OracleType.VarChar);
                prm23.Direction = ParameterDirection.Input;
                prm23.Value = rate_audit;
                com.Parameters.Add(prm23);



                OracleParameter prm24 = new OracleParameter("billmode", OracleType.VarChar);
                prm24.Direction = ParameterDirection.Input;
                prm24.Value = System.DBNull.Value;
                com.Parameters.Add(prm24);

                OracleParameter prm25 = new OracleParameter("billcycle", OracleType.VarChar);
                prm25.Direction = ParameterDirection.Input;
                if ((billcycle == "0") || (billcycle == "1"))
                {
                    prm25.Value = "0" + "','" + "1";
                }
                else
                {
                    prm25.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm25);



                com.Parameters.Add("p_recordset", OracleType.Cursor);
                com.Parameters["p_recordset"].Direction = ParameterDirection.Output;



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


        public DataSet websp_first_summary(string dateformat, string tilldate, string fromdate, string publication, string bookingcenter, string revenuecenter, string agencytype, string package, string adtype, string agency, string client, string billstatus, string rate_audit, string billmode,string comp_code)
        {
            OracleConnection con;
            OracleCommand com;
            DataSet objDataSet = new DataSet();
            con = GetConnection();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {

                con.Open();
                com = GetCommand("Websp_Classifiedgrid_summary", ref con);
                com.CommandType = CommandType.StoredProcedure;


                OracleParameter prm21 = new OracleParameter("date1", OracleType.VarChar);
                prm21.Direction = ParameterDirection.Input;
                prm21.Value = dateformat;
                com.Parameters.Add(prm21);




                OracleParameter prm22 = new OracleParameter("todate", OracleType.VarChar);
                prm22.Direction = ParameterDirection.Input;

                if (tilldate == "" || tilldate == null)
                {
                    prm22.Value = System.DBNull.Value;

                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = tilldate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        tilldate = mm + "/" + dd + "/" + yy;


                    }
                    prm22.Value = Convert.ToDateTime(tilldate).ToString("dd-MMMM-yyyy");

                }
                com.Parameters.Add(prm22);

                OracleParameter prm23 = new OracleParameter("fromdate", OracleType.VarChar);
                prm23.Direction = ParameterDirection.Input;

                if (fromdate == "" || fromdate == null)
                {
                    prm23.Value = System.DBNull.Value;

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
                    prm23.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");

                }
                com.Parameters.Add(prm23);

                OracleParameter prm24 = new OracleParameter("publication", OracleType.VarChar);
                prm24.Direction = ParameterDirection.Input;
                if (publication != "0")
                {


                    prm24.Value = publication;
                }
                else
                {
                    prm24.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm24);

                OracleParameter prm25 = new OracleParameter("bookingcenter", OracleType.VarChar);
                prm25.Direction = ParameterDirection.Input;
                if (bookingcenter != "")
                {
                    prm25.Value = bookingcenter;
                }
                else
                {
                    prm25.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm25);


                OracleParameter prm26 = new OracleParameter("revenuecenter", OracleType.VarChar);
                prm26.Direction = ParameterDirection.Input;
                if (revenuecenter != "")
                {

                    prm26.Value = revenuecenter;
                }
                else
                {
                    prm26.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm26);

                OracleParameter prm27 = new OracleParameter("agencytype", OracleType.VarChar);
                prm27.Direction = ParameterDirection.Input;
                if (agencytype != "")
                {

                    prm27.Value = agencytype;
                }
                else
                {
                    prm27.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm27);

                OracleParameter prm28 = new OracleParameter("package", OracleType.VarChar);
                prm28.Direction = ParameterDirection.Input;
                if (package != "")
                {
                    prm28.Value = package;
                }
                else
                {
                    prm28.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm28);

                OracleParameter prm29 = new OracleParameter("adtype", OracleType.VarChar);
                prm29.Direction = ParameterDirection.Input;
                if (adtype != "0")
                {
                    prm29.Value = adtype;
                }
                else
                {
                    prm29.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm29);


                OracleParameter prm30 = new OracleParameter("agency", OracleType.VarChar);
                prm30.Direction = ParameterDirection.Input;
                if (agency != "")
                {
                    prm30.Value = agency;
                }
                else
                {
                    prm30.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm30);

                OracleParameter prm31 = new OracleParameter("client", OracleType.VarChar);
                prm31.Direction = ParameterDirection.Input;
                if (client != "")
                {
                    prm31.Value = client;
                }
                else
                {
                    prm31.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm31);

                OracleParameter prm32 = new OracleParameter("billstatus", OracleType.VarChar);
                prm32.Direction = ParameterDirection.Input;
                if (billstatus != "0")
                {
                    prm32.Value = billstatus;
                }
                else
                {
                    prm32.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm32);

                OracleParameter prm20 = new OracleParameter("rate_audit", OracleType.VarChar);
                prm20.Direction = ParameterDirection.Input;
                prm20.Value = rate_audit;
                com.Parameters.Add(prm20);


                OracleParameter prm42 = new OracleParameter("billmode", OracleType.VarChar);
                prm42.Direction = ParameterDirection.Input;
                prm42.Value = System.DBNull.Value;
                com.Parameters.Add(prm42);


                OracleParameter prm43 = new OracleParameter("comp_code", OracleType.VarChar);
                prm43.Direction = ParameterDirection.Input;
                prm43.Value = comp_code;
                com.Parameters.Add(prm43);








                com.Parameters.Add("p_recordset", OracleType.Cursor);
                com.Parameters["p_recordset"].Direction = ParameterDirection.Output;














                //com.Parameters.Add("rate_audit", OracleType.Cursor);
                //com.Parameters["rate_audit"].Direction = ParameterDirection.Output;





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



        public DataSet websp_LAST_summary(string dateformat, string tilldate, string fromdate, string publication, string bookingcenter, string revenuecenter, string agencytype, string package, string adtype, string agency, string client, string billstatus, string rate_audit, string billmode, string comp_code)
        {
            OracleConnection con;
            OracleCommand com;
            DataSet objDataSet = new DataSet();
            con = GetConnection();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {

                con.Open();
                com = GetCommand("Websp_LASTDATE_summary", ref con);
                com.CommandType = CommandType.StoredProcedure;


                OracleParameter prm21 = new OracleParameter("date1", OracleType.VarChar);
                prm21.Direction = ParameterDirection.Input;
                prm21.Value = dateformat;
                com.Parameters.Add(prm21);




                OracleParameter prm22 = new OracleParameter("todate", OracleType.VarChar);
                prm22.Direction = ParameterDirection.Input;

                if (tilldate == "" || tilldate == null)
                {
                    prm22.Value = System.DBNull.Value;

                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = tilldate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        tilldate = mm + "/" + dd + "/" + yy;


                    }
                    prm22.Value = Convert.ToDateTime(tilldate).ToString("dd-MMMM-yyyy");

                }
                com.Parameters.Add(prm22);

                OracleParameter prm23 = new OracleParameter("fromdate", OracleType.VarChar);
                prm23.Direction = ParameterDirection.Input;

                if (fromdate == "" || fromdate == null)
                {
                    prm23.Value = System.DBNull.Value;

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
                    prm23.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");

                }
                com.Parameters.Add(prm23);

                OracleParameter prm24 = new OracleParameter("publication", OracleType.VarChar);
                prm24.Direction = ParameterDirection.Input;
                if (publication != "0")
                {


                    prm24.Value = publication;
                }
                else
                {
                    prm24.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm24);

                OracleParameter prm25 = new OracleParameter("bookingcenter", OracleType.VarChar);
                prm25.Direction = ParameterDirection.Input;
                if (bookingcenter != "")
                {
                    prm25.Value = bookingcenter;
                }
                else
                {
                    prm25.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm25);


                OracleParameter prm26 = new OracleParameter("revenuecenter", OracleType.VarChar);
                prm26.Direction = ParameterDirection.Input;
                if (revenuecenter != "")
                {

                    prm26.Value = revenuecenter;
                }
                else
                {
                    prm26.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm26);

                OracleParameter prm27 = new OracleParameter("agencytype", OracleType.VarChar);
                prm27.Direction = ParameterDirection.Input;
                if (agencytype != "")
                {

                    prm27.Value = agencytype;
                }
                else
                {
                    prm27.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm27);

                OracleParameter prm28 = new OracleParameter("package", OracleType.VarChar);
                prm28.Direction = ParameterDirection.Input;
                if (package != "")
                {
                    prm28.Value = package;
                }
                else
                {
                    prm28.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm28);

                OracleParameter prm29 = new OracleParameter("adtype", OracleType.VarChar);
                prm29.Direction = ParameterDirection.Input;
                if (adtype != "0")
                {
                    prm29.Value = adtype;
                }
                else
                {
                    prm29.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm29);


                OracleParameter prm30 = new OracleParameter("agency", OracleType.VarChar);
                prm30.Direction = ParameterDirection.Input;
                if (agency != "")
                {
                    prm30.Value = agency;
                }
                else
                {
                    prm30.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm30);

                OracleParameter prm31 = new OracleParameter("client", OracleType.VarChar);
                prm31.Direction = ParameterDirection.Input;
                if (client != "")
                {
                    prm31.Value = client;
                }
                else
                {
                    prm31.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm31);

                OracleParameter prm32 = new OracleParameter("billstatus", OracleType.VarChar);
                prm32.Direction = ParameterDirection.Input;
                if (billstatus != "0")
                {
                    prm32.Value = billstatus;
                }
                else
                {
                    prm32.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm32);

                OracleParameter prm20 = new OracleParameter("rate_audit", OracleType.VarChar);
                prm20.Direction = ParameterDirection.Input;
                prm20.Value = rate_audit;
                com.Parameters.Add(prm20);


                OracleParameter prm42 = new OracleParameter("billmode", OracleType.VarChar);
                prm42.Direction = ParameterDirection.Input;
                prm42.Value = System.DBNull.Value;
                com.Parameters.Add(prm42);


                OracleParameter prm43 = new OracleParameter("comp_code", OracleType.VarChar);
                prm43.Direction = ParameterDirection.Input;
                prm43.Value = comp_code;
                com.Parameters.Add(prm43);








                com.Parameters.Add("p_recordset", OracleType.Cursor);
                com.Parameters["p_recordset"].Direction = ParameterDirection.Output;














                //com.Parameters.Add("rate_audit", OracleType.Cursor);
                //com.Parameters["rate_audit"].Direction = ParameterDirection.Output;





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


        public string saveinlast(string orderno, string invoice1, string amountforvat, string amt3, double boxchg1, int insnum_cou, string doctyp, string maxinsert,string dateto,string dateformat)
        {
            OracleConnection con;
            OracleCommand com;
            DataSet objDataSet = new DataSet();
            con = GetConnection();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {

                con.Open();
                com = GetCommand("Bill_Savelast", ref con);
                com.CommandType = CommandType.StoredProcedure;



                OracleParameter prm21 = new OracleParameter("orderno1", OracleType.VarChar);
                prm21.Direction = ParameterDirection.Input;
                prm21.Value = orderno;
                com.Parameters.Add(prm21);



                OracleParameter prm22 = new OracleParameter("invoice1", OracleType.VarChar);
                prm22.Direction = ParameterDirection.Input;
                prm22.Value = invoice1;
                com.Parameters.Add(prm22);


                OracleParameter prm23 = new OracleParameter("amountforvat", OracleType.Number);
                prm23.Direction = ParameterDirection.Input;
                prm23.Value = amountforvat;
                com.Parameters.Add(prm23);


                OracleParameter prm24 = new OracleParameter("amt3", OracleType.Number);
                prm24.Direction = ParameterDirection.Input;
                prm24.Value = amt3;
                com.Parameters.Add(prm24);

                OracleParameter prm25 = new OracleParameter("boxchg1", OracleType.VarChar);
                prm25.Direction = ParameterDirection.Input;
                prm25.Value = boxchg1;
                com.Parameters.Add(prm25);
                OracleParameter prm26 = new OracleParameter("insnum_cou", OracleType.Number);
                prm26.Direction = ParameterDirection.Input;
                prm26.Value = insnum_cou;
                com.Parameters.Add(prm26);

                OracleParameter prm111 = new OracleParameter("doctyp", OracleType.VarChar);
                prm111.Direction = ParameterDirection.Input;
                prm111.Value = doctyp;
                com.Parameters.Add(prm111);

                OracleParameter prm112 = new OracleParameter("maxinsert", OracleType.VarChar);
                prm112.Direction = ParameterDirection.Input;
                prm112.Value = maxinsert;
                com.Parameters.Add(prm112);


                OracleParameter prm27 = new OracleParameter("todate", OracleType.VarChar);
                prm27.Direction = ParameterDirection.Input;

                if (dateto == "" || dateto == null)
                {
                    prm27.Value = System.DBNull.Value;

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
                    prm27.Value = Convert.ToDateTime(dateto).ToString("dd-MMMM-yyyy");

                }
                com.Parameters.Add(prm27);



                da.SelectCommand = com;
                com.ExecuteNonQuery();
                    
                return "Success";
            }
            catch (Exception ex)
            {
                return "Fail";
            }
            finally
            {
                CloseConnection(ref con);
            }
        }



        
        public string  saveinmonthly(string orderno, string invoice1, string amountforvat, string amt3, double boxchg1, int insnum_cou, string doctyp, string maxinsert,string dateto,string dateformat,string userid)
        {
            OracleConnection con;
            OracleCommand com;
            DataSet objDataSet = new DataSet();
            con = GetConnection();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {

                con.Open();
                com = GetCommand("save_entries", ref con);
                com.CommandType = CommandType.StoredProcedure;



                OracleParameter prm21 = new OracleParameter("orderno1", OracleType.VarChar);
                prm21.Direction = ParameterDirection.Input;
                prm21.Value = orderno;
                com.Parameters.Add(prm21);



                OracleParameter prm22 = new OracleParameter("invoice1", OracleType.VarChar);
                prm22.Direction = ParameterDirection.Input;
                prm22.Value = invoice1;
                com.Parameters.Add(prm22);


                OracleParameter prm23 = new OracleParameter("amountforvat", OracleType.VarChar);
                prm23.Direction = ParameterDirection.Input;
                prm23.Value = amountforvat;
                com.Parameters.Add(prm23);


                OracleParameter prm24 = new OracleParameter("amt3", OracleType.VarChar);
                prm24.Direction = ParameterDirection.Input;
                prm24.Value = amt3;
                com.Parameters.Add(prm24);

                OracleParameter prm25 = new OracleParameter("boxchg1", OracleType.VarChar);
                prm25.Direction = ParameterDirection.Input;
                prm25.Value = boxchg1;
                com.Parameters.Add(prm25);
                OracleParameter prm26 = new OracleParameter("insnum_cou", OracleType.Number);
                prm26.Direction = ParameterDirection.Input;
                prm26.Value = insnum_cou;
                com.Parameters.Add(prm26);

                OracleParameter prm111 = new OracleParameter("doctyp", OracleType.VarChar);
                prm111.Direction = ParameterDirection.Input;
                prm111.Value = doctyp;
                com.Parameters.Add(prm111);

                OracleParameter prm112 = new OracleParameter("maxinsert", OracleType.VarChar);
                prm112.Direction = ParameterDirection.Input;
                prm112.Value = maxinsert;
                com.Parameters.Add(prm112);


                OracleParameter prm27 = new OracleParameter("todate", OracleType.VarChar);
                prm27.Direction = ParameterDirection.Input;

                if (dateto == "" || dateto == null)
                {
                    prm27.Value = System.DBNull.Value;

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
                    prm27.Value = Convert.ToDateTime(dateto).ToString("dd-MMMM-yyyy");

                }
                com.Parameters.Add(prm27);

                OracleParameter prm113 = new OracleParameter("userid", OracleType.VarChar);
                prm113.Direction = ParameterDirection.Input;
                prm113.Value = userid;
                com.Parameters.Add(prm113);






                da.SelectCommand = com;
                com.ExecuteNonQuery();

                return "Success";
            }
            catch (Exception ex)
            {
                return "Fail";
            }
            finally
            {
                CloseConnection(ref con);
            }
        }



        public DataSet MONTHREPORT(string dateformat, string tilldate, string fromdate, string publication, string bookingcenter, string revenuecenter, string agencytype, string package, string adtype, string agency, string client, string billstatus, string rate_audit, string billmode, string comp_code)
        {
            OracleConnection con;
            OracleCommand com;
            DataSet objDataSet = new DataSet();
            con = GetConnection();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {

                con.Open();
                com = GetCommand("MONTHLY_REPORT_NEW", ref con);
                com.CommandType = CommandType.StoredProcedure;


                OracleParameter prm21 = new OracleParameter("date1", OracleType.VarChar);
                prm21.Direction = ParameterDirection.Input;
                prm21.Value = dateformat;
                com.Parameters.Add(prm21);




                OracleParameter prm22 = new OracleParameter("todate", OracleType.VarChar);
                prm22.Direction = ParameterDirection.Input;

                if (tilldate == "" || tilldate == null)
                {
                    prm22.Value = System.DBNull.Value;

                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = tilldate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        tilldate = mm + "/" + dd + "/" + yy;


                    }
                    prm22.Value = Convert.ToDateTime(tilldate).ToString("dd-MMMM-yyyy");

                }
                com.Parameters.Add(prm22);

                OracleParameter prm23 = new OracleParameter("fromdate", OracleType.VarChar);
                prm23.Direction = ParameterDirection.Input;

                if (fromdate == "" || fromdate == null)
                {
                    prm23.Value = System.DBNull.Value;

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
                    prm23.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");

                }
                com.Parameters.Add(prm23);

                OracleParameter prm24 = new OracleParameter("publication", OracleType.VarChar);
                prm24.Direction = ParameterDirection.Input;
                if (publication != "0")
                {


                    prm24.Value = publication;
                }
                else
                {
                    prm24.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm24);

                OracleParameter prm25 = new OracleParameter("bookingcenter", OracleType.VarChar);
                prm25.Direction = ParameterDirection.Input;
                if (bookingcenter != "")
                {
                    prm25.Value = bookingcenter;
                }
                else
                {
                    prm25.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm25);


                OracleParameter prm26 = new OracleParameter("revenuecenter", OracleType.VarChar);
                prm26.Direction = ParameterDirection.Input;
                if (revenuecenter != "")
                {

                    prm26.Value = revenuecenter;
                }
                else
                {
                    prm26.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm26);

                OracleParameter prm27 = new OracleParameter("agencytype", OracleType.VarChar);
                prm27.Direction = ParameterDirection.Input;
                if (agencytype != "")
                {

                    prm27.Value = agencytype;
                }
                else
                {
                    prm27.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm27);

                OracleParameter prm28 = new OracleParameter("package", OracleType.VarChar);
                prm28.Direction = ParameterDirection.Input;
                if (package != "")
                {
                    prm28.Value = package;
                }
                else
                {
                    prm28.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm28);

                OracleParameter prm29 = new OracleParameter("adtype", OracleType.VarChar);
                prm29.Direction = ParameterDirection.Input;
                if (adtype != "0")
                {
                    prm29.Value = adtype;
                }
                else
                {
                    prm29.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm29);


                OracleParameter prm30 = new OracleParameter("agency", OracleType.VarChar);
                prm30.Direction = ParameterDirection.Input;
                if (agency != "")
                {
                    prm30.Value = agency;
                }
                else
                {
                    prm30.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm30);

                OracleParameter prm31 = new OracleParameter("client", OracleType.VarChar);
                prm31.Direction = ParameterDirection.Input;
                if (client != "")
                {
                    prm31.Value = client;
                }
                else
                {
                    prm31.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm31);

                OracleParameter prm32 = new OracleParameter("billstatus", OracleType.VarChar);
                prm32.Direction = ParameterDirection.Input;
                if (billstatus != "0")
                {
                    prm32.Value = billstatus;
                }
                else
                {
                    prm32.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm32);

                OracleParameter prm20 = new OracleParameter("rate_audit", OracleType.VarChar);
                prm20.Direction = ParameterDirection.Input;
                prm20.Value = rate_audit;
                com.Parameters.Add(prm20);


                OracleParameter prm42 = new OracleParameter("billmode", OracleType.VarChar);
                prm42.Direction = ParameterDirection.Input;
                prm42.Value = System.DBNull.Value;
                com.Parameters.Add(prm42);


                OracleParameter prm43 = new OracleParameter("comp_code", OracleType.VarChar);
                prm43.Direction = ParameterDirection.Input;
                prm43.Value = comp_code;
                com.Parameters.Add(prm43);








                com.Parameters.Add("p_recordset", OracleType.Cursor);
                com.Parameters["p_recordset"].Direction = ParameterDirection.Output;














                //com.Parameters.Add("rate_audit", OracleType.Cursor);
                //com.Parameters["rate_audit"].Direction = ParameterDirection.Output;





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




        public DataSet delete_bill_det(string invoice1)
        {
            OracleConnection con;
            OracleCommand com;
            DataSet objDataSet = new DataSet();
            con = GetConnection();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {
                con.Open();
                com = GetCommand("delete_adbills_det", ref con);
                com.CommandType = CommandType.StoredProcedure;


                OracleParameter prm22 = new OracleParameter("invoice1", OracleType.VarChar);
                prm22.Direction = ParameterDirection.Input;
                prm22.Value = invoice1;
                com.Parameters.Add(prm22);

                
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

     


        public DataSet save_det_insert(string orderno, string invoice1, string grossamt, double billamt, double boxchg1, string ins_num, string edition_name,string insertid)
        {
            OracleConnection con;
            OracleCommand com;
            DataSet objDataSet = new DataSet();
            con = GetConnection();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {

                con.Open();
                com = GetCommand("bill_save_det_insert23", ref con);
                com.CommandType = CommandType.StoredProcedure;



                OracleParameter prm21 = new OracleParameter("orderno1", OracleType.VarChar);
                prm21.Direction = ParameterDirection.Input;
                prm21.Value = orderno;
                com.Parameters.Add(prm21);



                OracleParameter prm22 = new OracleParameter("invoice1", OracleType.VarChar);
                prm22.Direction = ParameterDirection.Input;
                prm22.Value = invoice1;
                com.Parameters.Add(prm22);


                OracleParameter prm23 = new OracleParameter("amountforvat", OracleType.VarChar);
                prm23.Direction = ParameterDirection.Input;
                prm23.Value = Convert.ToDecimal(grossamt);
                com.Parameters.Add(prm23);



                OracleParameter prm113 = new OracleParameter("edition_name", OracleType.VarChar);
                prm113.Direction = ParameterDirection.Input;
                prm113.Value = edition_name;
                com.Parameters.Add(prm113);




                OracleParameter prm25 = new OracleParameter("boxchg1", OracleType.VarChar);
                prm25.Direction = ParameterDirection.Input;
                prm25.Value = Convert.ToDecimal(boxchg1);
                com.Parameters.Add(prm25);







                OracleParameter prm114 = new OracleParameter("noofinsert", OracleType.VarChar);
                prm114.Direction = ParameterDirection.Input;
                prm114.Value = Convert.ToDecimal(ins_num);
                com.Parameters.Add(prm114);





                //OracleParameter prm24 = new OracleParameter("todate", OracleType.VarChar);
                //prm24.Direction = ParameterDirection.Input;
                //if (maxdate == "")
                //{
                //    prm24.Value = System.DBNull.Value;
                //}
                //else
                //{
                //    if (dateformat == "dd/mm/yyyy")
                //    {
                //        string[] arr = maxdate.Split('/');
                //        string dd = arr[0];
                //        string mm = arr[1];
                //        string yy = arr[2];
                //        maxdate = mm + "/" + dd + "/" + yy;
                //    }
                //    prm24.Value = Convert.ToDateTime(maxdate).ToString("dd-MMMM-yyyy");

                //}

                //com.Parameters.Add(prm24);


                



                    
                OracleParameter prm125 = new OracleParameter("insertid", OracleType.VarChar);
                prm125.Direction = ParameterDirection.Input;
                prm125.Value = insertid;
                com.Parameters.Add(prm125);







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




        public DataSet saveininsertion(string orderno, string invoice1, string amountforvat, string amt3, double boxchg1, int insnum_cou, string doctyp, string maxinsert, string dateformat, string chk_billtype)
        {
            OracleConnection con;
            OracleCommand com;
            DataSet objDataSet = new DataSet();
            con = GetConnection();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {

                con.Open();
                com = GetCommand("Bill_Saveinsert", ref con);
                com.CommandType = CommandType.StoredProcedure;



                OracleParameter prm21 = new OracleParameter("orderno1", OracleType.VarChar);
                prm21.Direction = ParameterDirection.Input;
                prm21.Value = orderno;
                com.Parameters.Add(prm21);



                OracleParameter prm22 = new OracleParameter("invoice1", OracleType.VarChar);
                prm22.Direction = ParameterDirection.Input;
                prm22.Value = invoice1;
                com.Parameters.Add(prm22);


                OracleParameter prm23 = new OracleParameter("amountforvat", OracleType.VarChar);
                prm23.Direction = ParameterDirection.Input;
                prm23.Value = amountforvat;
                com.Parameters.Add(prm23);


                OracleParameter prm24 = new OracleParameter("amt3", OracleType.VarChar);
                prm24.Direction = ParameterDirection.Input;
                prm24.Value = amt3;
                com.Parameters.Add(prm24);

                OracleParameter prm25 = new OracleParameter("boxchg1", OracleType.VarChar);
                prm25.Direction = ParameterDirection.Input;
                prm25.Value = boxchg1;
                com.Parameters.Add(prm25);
                OracleParameter prm26 = new OracleParameter("insnum_cou", OracleType.Number);
                prm26.Direction = ParameterDirection.Input;
                prm26.Value = insnum_cou;
                com.Parameters.Add(prm26);

                OracleParameter prm111 = new OracleParameter("doctyp", OracleType.VarChar);
                prm111.Direction = ParameterDirection.Input;
                prm111.Value = doctyp;
                com.Parameters.Add(prm111);

                OracleParameter prm112 = new OracleParameter("maxinsert", OracleType.VarChar);
                prm112.Direction = ParameterDirection.Input;
                prm112.Value = maxinsert;
                com.Parameters.Add(prm112);


                OracleParameter prm113 = new OracleParameter("chk_billtype", OracleType.VarChar);
                prm113.Direction = ParameterDirection.Input;
                prm113.Value = chk_billtype;
                com.Parameters.Add(prm113);



                //OracleParameter prm27 = new OracleParameter("todate", OracleType.VarChar);
                //prm27.Direction = ParameterDirection.Input;

                //if (dateto == "" || dateto == null)
                //{
                //    prm27.Value = System.DBNull.Value;

                //}
                //else
                //{
                //    if (dateformat == "dd/mm/yyyy")
                //    {
                //        string[] arr = dateto.Split('/');
                //        string dd = arr[0];
                //        string mm = arr[1];
                //        string yy = arr[2];
                //        dateto = mm + "/" + dd + "/" + yy;


                //    }
                //    prm27.Value = Convert.ToDateTime(dateto).ToString("dd-MMMM-yyyy");

                //}
                //com.Parameters.Add(prm27);



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





        public DataSet maxdate_latest(string dateformat, string tilldate, string fromdate, string publication, string bookingcenter, string revenuecenter, string agencytype, string package, string adtype, string agency, string client, string billstatus, string rate_audit, string billmode, string billcycle, string compcode, string userid, string DISP_CLSBILL, string retainer_name, string executive_name, string branch_name, string ad_category, string district, string taluka, string DISP_CASHBILL, string FMG_BILL_DIS, string BILL_DISP_CASHBILL, string centername, string ROWISE_CASHBOOKING, string bill_no)
        {
            OracleConnection con;
            OracleCommand com;
            DataSet objDataSet = new DataSet();
            con = GetConnection();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {

                con.Open();
                com = GetCommand("selectmax_latest", ref con);
                com.CommandType = CommandType.StoredProcedure;


                OracleParameter prm21 = new OracleParameter("pdateformat", OracleType.VarChar);
                prm21.Direction = ParameterDirection.Input;
                prm21.Value = dateformat;
                com.Parameters.Add(prm21);




                OracleParameter prm22 = new OracleParameter("ptodate", OracleType.VarChar);
                prm22.Direction = ParameterDirection.Input;

                if (tilldate == "" || tilldate == null)
                {
                    prm22.Value = System.DBNull.Value;

                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = tilldate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        tilldate = mm + "/" + dd + "/" + yy;


                    }
                    prm22.Value = Convert.ToDateTime(tilldate).ToString("dd-MMMM-yyyy");

                }
                com.Parameters.Add(prm22);

                OracleParameter prm23 = new OracleParameter("pfromdate", OracleType.VarChar);
                prm23.Direction = ParameterDirection.Input;

                if (fromdate == "" || fromdate == null)
                {
                    prm23.Value = System.DBNull.Value;

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
                    prm23.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");

                }
                com.Parameters.Add(prm23);

                OracleParameter prm24 = new OracleParameter("ppublication", OracleType.VarChar);
                prm24.Direction = ParameterDirection.Input;
                if (publication != "0")
                {


                    prm24.Value = publication;
                }
                else
                {
                    prm24.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm24);

                OracleParameter prm25 = new OracleParameter("pbookingcenter", OracleType.VarChar);
                prm25.Direction = ParameterDirection.Input;
                if (bookingcenter != "")
                {
                    prm25.Value = bookingcenter;
                }
                else
                {
                    prm25.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm25);


                OracleParameter prm26 = new OracleParameter("prevenuecenter", OracleType.VarChar);
                prm26.Direction = ParameterDirection.Input;
                if (revenuecenter != "")
                {

                    prm26.Value = revenuecenter;
                }
                else
                {
                    prm26.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm26);

                OracleParameter prm27 = new OracleParameter("pagencytype", OracleType.VarChar);
                prm27.Direction = ParameterDirection.Input;
                if (agencytype != "")
                {

                    prm27.Value = agencytype;
                }
                else
                {
                    prm27.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm27);

                OracleParameter prm28 = new OracleParameter("ppckage", OracleType.VarChar);
                prm28.Direction = ParameterDirection.Input;
                if (package != "")
                {
                    prm28.Value = package;
                }
                else
                {
                    prm28.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm28);

                OracleParameter prm29 = new OracleParameter("padtype", OracleType.VarChar);
                prm29.Direction = ParameterDirection.Input;
                if (adtype != "0")
                {
                    prm29.Value = adtype;
                }
                else
                {
                    prm29.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm29);


                OracleParameter prm30 = new OracleParameter("pagency", OracleType.VarChar);
                prm30.Direction = ParameterDirection.Input;
                if (agency != "")
                {
                    prm30.Value = agency;
                }
                else
                {
                    prm30.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm30);

                OracleParameter prm31 = new OracleParameter("pclient", OracleType.VarChar);
                prm31.Direction = ParameterDirection.Input;
                if (client != "")
                {
                    prm31.Value = client;
                }
                else
                {
                    prm31.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm31);

                OracleParameter prm32 = new OracleParameter("pbillstatus", OracleType.VarChar);
                prm32.Direction = ParameterDirection.Input;
                if (billstatus != "0")
                {
                    prm32.Value = billstatus;
                }
                else
                {
                    prm32.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm32);

                OracleParameter prm20 = new OracleParameter("prate_audit", OracleType.VarChar);
                prm20.Direction = ParameterDirection.Input;
                prm20.Value = rate_audit;
                com.Parameters.Add(prm20);


                OracleParameter prm42 = new OracleParameter("pbillmode", OracleType.VarChar);
                prm42.Direction = ParameterDirection.Input;
                prm42.Value = System.DBNull.Value;
                com.Parameters.Add(prm42);


                OracleParameter prm43 = new OracleParameter("pbillcycle", OracleType.VarChar);
                prm43.Direction = ParameterDirection.Input;
                if ((billcycle == "0") || (billcycle == "1"))
                {
                    prm43.Value = "0" + "','" + "1";
                }
                else
                {
                    prm43.Value = System.DBNull.Value;
                }
                com.Parameters.Add(prm43);

                OracleParameter prm44 = new OracleParameter("pcompcode", OracleType.VarChar);
                prm44.Direction = ParameterDirection.Input;
                prm44.Value = compcode;
                com.Parameters.Add(prm44);


                OracleParameter prm45 = new OracleParameter("puserid", OracleType.VarChar);
                prm45.Direction = ParameterDirection.Input;
                prm45.Value = userid;
                com.Parameters.Add(prm45);


                OracleParameter prm46 = new OracleParameter("DISP_CLSBILL", OracleType.VarChar);
                prm46.Direction = ParameterDirection.Input;
                prm46.Value = DISP_CLSBILL;
                com.Parameters.Add(prm46);







                
                OracleParameter prm132 = new OracleParameter("v_retainer_name", OracleType.VarChar);
                prm132.Direction = ParameterDirection.Input;
                if (retainer_name == "0")
                {
                    prm132.Value = System.DBNull.Value;
                }
                else
                {
                    prm132.Value = retainer_name;
                }
                com.Parameters.Add(prm132);



                   OracleParameter prm133 = new OracleParameter("v_executive_name", OracleType.VarChar);
                prm133.Direction = ParameterDirection.Input;
                if (executive_name == "0")
                {
                    prm133.Value = System.DBNull.Value;
                }
                else
                {
                    prm133.Value = executive_name;
                }
                com.Parameters.Add(prm133);



                   OracleParameter prm134 = new OracleParameter("v_branch_name", OracleType.VarChar);
                prm134.Direction = ParameterDirection.Input;
                if (branch_name == "-Select Branch-")
                {
                    prm134.Value = System.DBNull.Value;
                }
                else
                {
                    prm134.Value = branch_name;
                }
                com.Parameters.Add(prm134);



                   OracleParameter prm135 = new OracleParameter("v_ad_category", OracleType.VarChar);
                prm135.Direction = ParameterDirection.Input;
                if (ad_category == "0")
                {
                    prm135.Value = System.DBNull.Value;
                }
                else
                {
                    prm135.Value = ad_category;
                }
                com.Parameters.Add(prm135);


                    OracleParameter prm136 = new OracleParameter("v_district", OracleType.VarChar);
                prm136.Direction = ParameterDirection.Input;
                if (district == "0")
                {
                    prm136.Value = System.DBNull.Value;
                }
                else
                {
                    prm136.Value = district;
                }
                com.Parameters.Add(prm136);


            OracleParameter prm137 = new OracleParameter("v_taluka", OracleType.VarChar);
                prm137.Direction = ParameterDirection.Input;
                if (taluka == "0")
                {
                    prm137.Value = System.DBNull.Value;
                }
                else
                {
                    prm137.Value = taluka;
                }
                com.Parameters.Add(prm137);


                OracleParameter prm138 = new OracleParameter("V_DISP_CASHBILL", OracleType.VarChar);
                prm138.Direction = ParameterDirection.Input;
                prm138.Value = DISP_CASHBILL;
                com.Parameters.Add(prm138);


                OracleParameter prm139 = new OracleParameter("V_FMG_BILL_DIS", OracleType.VarChar);
                prm139.Direction = ParameterDirection.Input;
                prm139.Value = FMG_BILL_DIS;
                com.Parameters.Add(prm139);



                OracleParameter prm140 = new OracleParameter("V_BILL_DISP_CASHBILL", OracleType.VarChar);
                prm140.Direction = ParameterDirection.Input;
                prm140.Value = BILL_DISP_CASHBILL;
                com.Parameters.Add(prm140);


                OracleParameter prm141 = new OracleParameter("v_centername", OracleType.VarChar);
                prm141.Direction = ParameterDirection.Input;
                prm141.Value = centername;
                com.Parameters.Add(prm141);


                OracleParameter prm142 = new OracleParameter("v_ROWISE_CASHBOOKING", OracleType.VarChar);
                prm142.Direction = ParameterDirection.Input;
                prm142.Value = ROWISE_CASHBOOKING;
                com.Parameters.Add(prm142);


                OracleParameter prm143 = new OracleParameter("pbillno", OracleType.VarChar);
                prm143.Direction = ParameterDirection.Input;
                if (bill_no == "")
                {
                    prm143.Value = System.DBNull.Value;
                }
                else
                {
                    prm143.Value = bill_no;
                }
                com.Parameters.Add(prm143);

                
                
                
                

                
                

                












                com.Parameters.Add("p_recordsetmis", OracleType.Cursor);
                com.Parameters["p_recordsetmis"].Direction = ParameterDirection.Output;














                //com.Parameters.Add("rate_audit", OracleType.Cursor);
                //com.Parameters["rate_audit"].Direction = ParameterDirection.Output;





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







        public DataSet packagebind_NEW(string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("Bindpackage_NEW.Bindpackage_NEW_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);



                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                objOraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;


                objOraclecommand.Parameters.Add("P_Accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts1"].Direction = ParameterDirection.Output;





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









        public DataSet district(string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("CityMst_District.CityMst_District_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);
                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

                objmysqlDataAdapter.SelectCommand = objOraclecommand;
                objmysqlDataAdapter.Fill(objDataSet);
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

        public DataSet talukabind(string compcode, string dist_code)
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
                objOraclecommand = GetCommand("BINDTALUKA.BINDTALUKA_P", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);



                OracleParameter prm3 = new OracleParameter("pdist_code", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                if (dist_code == "0" || dist_code == "")
                    prm3.Value = System.DBNull.Value;
                else
                    prm3.Value = dist_code;
                objOraclecommand.Parameters.Add(prm3);

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



        public DataSet receiptinsert(string compcode, string unit, string type, string recpt, string rdate, string paymodres, string receivedreg, string vouno, string amount/*,string damount*/, string agency, string inhand, string othercd, string chno, string chedate, string bank, string narration, string rep, string vdate, string userid, string ag_main_code, string ag_sub_code, string dateformat, string prorec)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("receiptsave_supp.receiptsave_supp_P", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pcompcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("puserid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("punit", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = unit;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("ptype", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = type;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("precpt", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = recpt;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("prdate", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                if (rdate == "")
                {
                    prm6.Value = System.DBNull.Value;
                }
                else
                {
                    //    if(dateformat=="dd/mm/yyyy")
                    //    {
                    //        string[] arr = rdate.Split('/');
                    //        string dd = arr[0];
                    //        string mm = arr[1];
                    //        string yy = arr[2];
                    //        rdate = mm + "/" + dd + "/" + yy;
                    //    }
                    //}
                    prm6.Value = Convert.ToDateTime(rdate).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm6);


                OracleParameter prm7 = new OracleParameter("ppaymodres", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = paymodres;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("preceivedreg", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                if ((receivedreg=="0")||(receivedreg==""))
                {
                    prm8.Value = System.DBNull.Value;
                }
                else
                {
                prm8.Value = receivedreg;
                }
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("pvouno", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = vouno;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("pamount", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                if (amount == "")
                {
                    prm10.Value = System.DBNull.Value;
                }
                else
                {
                    prm10.Value = amount;
                }
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("pagency", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = agency;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("pothercd", OracleType.VarChar, 50);
                prm12.Direction = ParameterDirection.Input;
                if (othercd == "")
                {
                    prm12.Value = System.DBNull.Value;
                }
                else
                {
                    prm12.Value = othercd;
                }
                objOraclecommand.Parameters.Add(prm12);

                OracleParameter prm13 = new OracleParameter("pchno", OracleType.VarChar, 50);
                prm13.Direction = ParameterDirection.Input;
                if (chno == "")
                {
                    prm13.Value = System.DBNull.Value;
                }
                else
                {
                    prm13.Value = chno;
                }
                objOraclecommand.Parameters.Add(prm13);


                OracleParameter prm14 = new OracleParameter("pchedate", OracleType.VarChar, 50);
                prm14.Direction = ParameterDirection.Input;
                if (chedate == "")
                {
                    prm14.Value = System.DBNull.Value;
                }
                else
                {

                    //if (dateformat == "dd/mm/yyyy")
                    //{
                    //    string[] arr = chedate.Split('/');
                    //    string dd = arr[0];
                    //    string mm = arr[1];
                    //    string yy = arr[2];
                    //    chedate = mm + "/" + dd + "/" + yy;
                    //}
                    prm14.Value = Convert.ToDateTime(chedate).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm14);

                OracleParameter prm15 = new OracleParameter("pbank", OracleType.VarChar, 50);
                prm15.Direction = ParameterDirection.Input;
                if (bank == "")
                {
                    prm15.Value = System.DBNull.Value;
                }
                else
                {
                    prm15.Value = bank;
                }
                objOraclecommand.Parameters.Add(prm15);


                OracleParameter prm16 = new OracleParameter("pnarration", OracleType.VarChar, 50);
                prm16.Direction = ParameterDirection.Input;
                if (narration == "")
                {
                    prm16.Value = System.DBNull.Value;
                }
                else
                {
                    prm16.Value = narration;
                }
                objOraclecommand.Parameters.Add(prm16);

                OracleParameter prm17 = new OracleParameter("prep", OracleType.VarChar, 50);
                prm17.Direction = ParameterDirection.Input;
                prm17.Value = rep;
                objOraclecommand.Parameters.Add(prm17);

                OracleParameter prm18 = new OracleParameter("pvdate", OracleType.VarChar, 50);
                prm18.Direction = ParameterDirection.Input;
                if (vdate == "")
                {
                    prm18.Value = System.DBNull.Value;
                }
                else
                {



                    //if (dateformat == "dd/mm/yyyy")
                    //{
                    //    string[] arr = vdate.Split('/');
                    //    string dd = arr[0];
                    //    string mm = arr[1];
                    //    string yy = arr[2];
                    //    vdate = mm + "/" + dd + "/" + yy;


                    //}
                    prm18.Value = Convert.ToDateTime(vdate).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm18);

                OracleParameter prm19 = new OracleParameter("pag_main_code", OracleType.VarChar, 50);
                prm19.Direction = ParameterDirection.Input;
                if (ag_main_code == "")
                {
                    prm19.Value = System.DBNull.Value;
                }
                else
                {
                    prm19.Value = ag_main_code;
                }
                objOraclecommand.Parameters.Add(prm19);

                OracleParameter prm20 = new OracleParameter("pag_sub_code", OracleType.VarChar, 50);
                prm20.Direction = ParameterDirection.Input;
                if (ag_sub_code == "")
                {
                    prm20.Value = System.DBNull.Value;
                }
                else
                {
                    prm20.Value = ag_sub_code;
                }
                objOraclecommand.Parameters.Add(prm20);


                OracleParameter prm201 = new OracleParameter("prov_receipt", OracleType.VarChar, 50);
                prm201.Direction = ParameterDirection.Input;
                if (prorec == "")
                {
                    prm201.Value = System.DBNull.Value;
                }
                else
                {
                    prm201.Value = prorec;
                }
                objOraclecommand.Parameters.Add(prm201);

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
        public DataSet receiptinsert1(string compcode, string unit, string type, string recpt, string rdate, string paymodres, string receivedreg, string vouno, string amount/*,string damount*/, string agency, string inhand, string othercd, string chno, string chedate, string bank, string narration, string rep, string vdate, string userid, string ag_main_code, string ag_sub_code, string dateformat)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("receiptsave1_supp.receiptsave1_supp_P", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pcompcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("puserid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("punit", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = unit;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("ptype", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = type;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("precpt", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = recpt;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("prdate", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                if (rdate == "")
                {
                    prm6.Value = System.DBNull.Value;
                }
                else
                {
                    //if (dateformat == "dd/mm/yyyy")
                    //{
                    //    string[] arr = rdate.Split('/');
                    //    string dd = arr[0];
                    //    string mm = arr[1];
                    //    string yy = arr[2];
                    //    rdate = mm + "/" + dd + "/" + yy;
                    //}

                    prm6.Value = Convert.ToDateTime(rdate).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm6);


                OracleParameter prm7 = new OracleParameter("ppaymodres", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = paymodres;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("preceivedreg", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = receivedreg;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("pvouno", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = vouno;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("pamount", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                if (amount == "")
                {
                    prm10.Value = System.DBNull.Value;
                }
                else
                {
                    prm10.Value = amount;
                }
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("pagency", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = agency;
                objOraclecommand.Parameters.Add(prm11);


                OracleParameter prm12 = new OracleParameter("pchno", OracleType.VarChar, 50);
                prm12.Direction = ParameterDirection.Input;
                if (chno == "")
                {
                    prm12.Value = System.DBNull.Value;
                }
                else
                {
                    prm12.Value = chno;
                }
                objOraclecommand.Parameters.Add(prm12);


                OracleParameter prm13 = new OracleParameter("pchedate", OracleType.VarChar, 50);
                prm13.Direction = ParameterDirection.Input;
                if (chedate == "")
                {
                    prm13.Value = System.DBNull.Value;
                }
                else
                {
                    //if (dateformat == "dd/mm/yyyy")
                    //{
                    //    string[] arr = chedate.Split('/');
                    //    string dd = arr[0];
                    //    string mm = arr[1];
                    //    string yy = arr[2];
                    //    chedate = mm + "/" + dd + "/" + yy;
                    //}
                    prm13.Value = Convert.ToDateTime(chedate).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm13);

                OracleParameter prm14 = new OracleParameter("pbank", OracleType.VarChar, 50);
                prm14.Direction = ParameterDirection.Input;
                if (bank == "")
                {
                    prm14.Value = System.DBNull.Value;
                }
                else
                {
                    prm14.Value = bank;
                }
                objOraclecommand.Parameters.Add(prm14);




                OracleParameter prm15 = new OracleParameter("pvdate", OracleType.VarChar, 50);
                prm15.Direction = ParameterDirection.Input;
                if (vdate == "")
                {
                    prm15.Value = System.DBNull.Value;
                }
                else
                {
                    //if (dateformat == "dd/mm/yyyy")
                    //{
                    //    string[] arr = vdate.Split('/');
                    //    string dd = arr[0];
                    //    string mm = arr[1];
                    //    string yy = arr[2];
                    //    vdate = mm + "/" + dd + "/" + yy;
                    //}

                    prm15.Value = Convert.ToDateTime(vdate).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm15);

                OracleParameter prm16 = new OracleParameter("pag_main_code", OracleType.VarChar, 50);
                prm16.Direction = ParameterDirection.Input;
                if (ag_main_code == "")
                {
                    prm16.Value = System.DBNull.Value;
                }
                else
                {
                    prm16.Value = ag_main_code;
                }
                objOraclecommand.Parameters.Add(prm16);

                OracleParameter prm17 = new OracleParameter("pag_sub_code", OracleType.VarChar, 50);
                prm17.Direction = ParameterDirection.Input;
                if (ag_sub_code == "")
                {
                    prm17.Value = System.DBNull.Value;
                }
                else
                {
                    prm17.Value = ag_sub_code;
                }
                objOraclecommand.Parameters.Add(prm17);


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
        public DataSet receiptinsert2(string compcode, string unit, string type, string recpt, string rdate, string paymodres, string receivedreg, string vouno, string amount/*,string damount*/, string agency, string inhand, string othercd, string chno, string chedate, string bank, string narration, string rep, string vdate, string userid, string ag_main_code, string ag_sub_code, string dateformat)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("receiptsave2_supp.receiptsave2_supp_P", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pcompcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("puserid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("punit", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = unit;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("ptype", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = type;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("precpt", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = recpt;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("prdate", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                if (rdate == "")
                {
                    prm6.Value = System.DBNull.Value;
                }
                else
                {
                    //if (dateformat == "dd/mm/yyyy")
                    //{
                    //    string[] arr = rdate.Split('/');
                    //    string dd = arr[0];
                    //    string mm = arr[1];
                    //    string yy = arr[2];
                    //    rdate = mm + "/" + dd + "/" + yy;
                    //}

                    prm6.Value = Convert.ToDateTime(rdate).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm6);


                OracleParameter prm7 = new OracleParameter("ppaymodres", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = paymodres;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("preceivedreg", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = receivedreg;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("pvouno", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = vouno;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("pamount", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                if (amount == "")
                {
                    prm10.Value = System.DBNull.Value;
                }
                else
                {
                    prm10.Value = amount;
                }
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("pagency", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = agency;
                objOraclecommand.Parameters.Add(prm11);



                OracleParameter prm12 = new OracleParameter("pvdate", OracleType.VarChar, 50);
                prm12.Direction = ParameterDirection.Input;
                if (vdate == "")
                {
                    prm12.Value = System.DBNull.Value;
                }
                else
                {
                    //if (dateformat == "dd/mm/yyyy")
                    //{
                    //    string[] arr = vdate.Split('/');
                    //    string dd = arr[0];
                    //    string mm = arr[1];
                    //    string yy = arr[2];
                    //    vdate = mm + "/" + dd + "/" + yy;
                    //}

                    prm12.Value = Convert.ToDateTime(vdate).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm12);

                OracleParameter prm13 = new OracleParameter("pag_main_code", OracleType.VarChar, 50);
                prm13.Direction = ParameterDirection.Input;
                if (ag_main_code == "")
                {
                    prm13.Value = System.DBNull.Value;
                }
                else
                {
                    prm13.Value = ag_main_code;
                }
                objOraclecommand.Parameters.Add(prm13);

                OracleParameter prm14 = new OracleParameter("pag_sub_code", OracleType.VarChar, 50);
                prm14.Direction = ParameterDirection.Input;
                if (ag_sub_code == "")
                {
                    prm14.Value = System.DBNull.Value;
                }
                else
                {
                    prm14.Value = ag_sub_code;
                }
                objOraclecommand.Parameters.Add(prm14);

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


        public DataSet bind_category(string compcode, string ad_type)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("audit_cate.audit_cate_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("v_ad_type", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = ad_type;
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
                objOracleConnection.Close();
            }

        }





        public DataSet selectmonthly_genrate(string agcode, string fromdate, string dateto, string bookingid, string Client, string dateformat, string booking)
        {
            OracleConnection con;
            OracleCommand com;
            DataSet objDataSet = new DataSet();
            con = GetConnection();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {
                con.Open();
                com = GetCommand("selectmonthly_genbill", ref con);
                com.CommandType = CommandType.StoredProcedure;




                OracleParameter prm21 = new OracleParameter("agcode", OracleType.VarChar);
                prm21.Direction = ParameterDirection.Input;
                prm21.Value = agcode;
                com.Parameters.Add(prm21);

                OracleParameter prm22 = new OracleParameter("fromdate", OracleType.VarChar);
                prm22.Direction = ParameterDirection.Input;
                if (fromdate == "")
                {
                    prm22.Value = System.DBNull.Value;
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
                    prm22.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");

                }

                com.Parameters.Add(prm22);

                OracleParameter prm23 = new OracleParameter("dateto", OracleType.VarChar);
                prm23.Direction = ParameterDirection.Input;
                if (dateto == "")
                {
                    prm23.Value = System.DBNull.Value;
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
                    prm23.Value = Convert.ToDateTime(dateto).ToString("dd-MMMM-yyyy");

                }

                com.Parameters.Add(prm23);

                OracleParameter prm24 = new OracleParameter("bookingid", OracleType.VarChar);
                prm24.Direction = ParameterDirection.Input;
                prm24.Value = bookingid;
                com.Parameters.Add(prm24);


                OracleParameter prm32 = new OracleParameter("Client", OracleType.VarChar);
                prm32.Direction = ParameterDirection.Input;
                if (Client == "")
                {
                    prm32.Value = System.DBNull.Value;

                }
                else
                {
                    prm32.Value = Client;
                }
                com.Parameters.Add(prm32);

                OracleParameter prm20 = new OracleParameter("dateformat", OracleType.VarChar);
                prm20.Direction = ParameterDirection.Input;
                prm20.Value = dateformat;
                com.Parameters.Add(prm20);


                OracleParameter prm45 = new OracleParameter("bookingtot", OracleType.VarChar);
                prm45.Direction = ParameterDirection.Input;
                prm45.Value = booking;
                com.Parameters.Add(prm45);




                com.Parameters.Add("p_classs", OracleType.Cursor);
                com.Parameters["p_classs"].Direction = ParameterDirection.Output;

                //com.Parameters.Add("p_classs1", OracleType.Cursor);
                //com.Parameters["p_classs1"].Direction = ParameterDirection.Output;


                //com.Parameters.Add("p_classs2", OracleType.Cursor);
                //com.Parameters["p_classs2"].Direction = ParameterDirection.Output;




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



        public DataSet selectlastnew_letter(string bookingid, string dateformat, string fromdate, string dateto, string v_invoice, string compcode)
        {
            OracleConnection con;
            OracleCommand com;
            DataSet objDataSet = new DataSet();
            con = GetConnection();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {
                con.Open();
                com = GetCommand("Websp_letterdate", ref con);
                com.CommandType = CommandType.StoredProcedure;





                OracleParameter prm24 = new OracleParameter("bookingid", OracleType.VarChar);
                prm24.Direction = ParameterDirection.Input;
                prm24.Value = bookingid;
                com.Parameters.Add(prm24);




                OracleParameter prm20 = new OracleParameter("dateformat", OracleType.VarChar);
                prm20.Direction = ParameterDirection.Input;
                prm20.Value = dateformat;
                com.Parameters.Add(prm20);









                OracleParameter prm22 = new OracleParameter("fromdate", OracleType.VarChar);
                prm22.Direction = ParameterDirection.Input;
                if (fromdate == "")
                {
                    prm22.Value = System.DBNull.Value;
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
                    prm22.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");

                }

                com.Parameters.Add(prm22);

                OracleParameter prm23 = new OracleParameter("dateto", OracleType.VarChar);
                prm23.Direction = ParameterDirection.Input;
                if (dateto == "")
                {
                    prm23.Value = System.DBNull.Value;
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
                    prm23.Value = Convert.ToDateTime(dateto).ToString("dd-MMMM-yyyy");

                }

                com.Parameters.Add(prm23);



                OracleParameter prm25 = new OracleParameter("v_invoice", OracleType.VarChar);
                prm25.Direction = ParameterDirection.Input;
                prm25.Value = v_invoice;
                com.Parameters.Add(prm25);

                OracleParameter prm26 = new OracleParameter("v_compcode", OracleType.VarChar);
                prm26.Direction = ParameterDirection.Input;
                prm26.Value = compcode;
                com.Parameters.Add(prm26);





                com.Parameters.Add("p_classs", OracleType.Cursor);
                com.Parameters["p_classs"].Direction = ParameterDirection.Output;

                com.Parameters.Add("p_accounts1", OracleType.Cursor);
                com.Parameters["p_accounts1"].Direction = ParameterDirection.Output;


                //com.Parameters.Add("p_accounts2", OracleType.Cursor);
                //com.Parameters["p_accounts2"].Direction = ParameterDirection.Output;




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





        public DataSet selectmonthlynew_coverletter(string agcode, string fromdate, string dateto, string bookingid, string Client, string dateformat, string bookingtot)
        {
            OracleConnection con;
            OracleCommand com;
            DataSet objDataSet = new DataSet();
            con = GetConnection();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {
                con.Open();
                com = GetCommand("selectmonthly_coverletter", ref con);
                com.CommandType = CommandType.StoredProcedure;




                OracleParameter prm21 = new OracleParameter("agcode", OracleType.VarChar);
                prm21.Direction = ParameterDirection.Input;
                prm21.Value = agcode;
                com.Parameters.Add(prm21);

                OracleParameter prm22 = new OracleParameter("fromdate", OracleType.VarChar);
                prm22.Direction = ParameterDirection.Input;
                if (fromdate == "")
                {
                    prm22.Value = System.DBNull.Value;
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
                    prm22.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");

                }

                com.Parameters.Add(prm22);

                OracleParameter prm23 = new OracleParameter("dateto", OracleType.VarChar);
                prm23.Direction = ParameterDirection.Input;
                if (dateto == "")
                {
                    prm23.Value = System.DBNull.Value;
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
                    prm23.Value = Convert.ToDateTime(dateto).ToString("dd-MMMM-yyyy");

                }

                com.Parameters.Add(prm23);

                OracleParameter prm24 = new OracleParameter("bookingid", OracleType.VarChar);
                prm24.Direction = ParameterDirection.Input;
                prm24.Value = bookingid;
                com.Parameters.Add(prm24);


                OracleParameter prm32 = new OracleParameter("Client", OracleType.VarChar);
                prm32.Direction = ParameterDirection.Input;
                if (Client == "")
                {
                    prm32.Value = System.DBNull.Value;

                }
                else
                {
                    prm32.Value = Client;
                }
                com.Parameters.Add(prm32);

                OracleParameter prm20 = new OracleParameter("dateformat", OracleType.VarChar);
                prm20.Direction = ParameterDirection.Input;
                prm20.Value = dateformat;
                com.Parameters.Add(prm20);

                OracleParameter prm28 = new OracleParameter("bookingtot", OracleType.VarChar);
                prm28.Direction = ParameterDirection.Input;
                prm28.Value = bookingtot;
                com.Parameters.Add(prm28);



                com.Parameters.Add("p_classs", OracleType.Cursor);
                com.Parameters["p_classs"].Direction = ParameterDirection.Output;

            







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