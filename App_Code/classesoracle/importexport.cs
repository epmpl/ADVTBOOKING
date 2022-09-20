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
/// Summary description for importexport
/// </summary>
/// 
namespace NewAdbooking.classesoracle
{
    public class importexport:orclconnection
    {
        public importexport()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataSet getData(string adtype, string fromdate, string todate,string dateformat,string solo,string ratecode,string pubcent,string edition,string packagecode,string adcategary,string uom)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("getData_Export", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("adtype_p", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = adtype;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("fromdate_p", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                if (dateformat == "dd/mm/yyyy")
                {
                    string[] arr = fromdate.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    fromdate = mm + "/" + dd + "/" + yy;


                }

                prm2.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("todate_p", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                if (dateformat == "dd/mm/yyyy")
                {
                    string[] arr = todate.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    todate = mm + "/" + dd + "/" + yy;


                }

                prm3.Value = Convert.ToDateTime(todate).ToString("dd-MMMM-yyyy");
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("p_solo", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = solo;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("p_ratecode", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = ratecode;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("p_pubcent", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = pubcent;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("pedtn_flag", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                if (edition == "")
                {
                    prm7.Value = System.DBNull.Value;
                }
                else
                {
                    prm7.Value = edition;
                }                
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("p_packagecode", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                if (packagecode == "")
                {
                    prm8.Value = System.DBNull.Value;
                }
                else
                {
                    prm8.Value = packagecode;
                }
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("padcatg", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                if (adcategary == "")
                {
                    prm9.Value = System.DBNull.Value;
                }
                else
                {
                    prm9.Value = adcategary;
                }
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("puom_code", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                if (uom == "")
                {
                    prm10.Value = System.DBNull.Value;
                }
                else
                {
                    prm10.Value = uom;
                }
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("pextra1", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("pextra2", OracleType.VarChar);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm12);

                OracleParameter prm13 = new OracleParameter("pextra3", OracleType.VarChar);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm13);

                OracleParameter prm14 = new OracleParameter("pextra4", OracleType.VarChar);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm14);

                OracleParameter prm15 = new OracleParameter("pextra5", OracleType.VarChar);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = System.DBNull.Value;
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
        //======================================**** Insert into Rate Detail form Excel ****=================================//
        public DataSet InsertRatedetailfrExcel(string compcode, string packagecode, string weekrate, string focusrate, string txtratecode, string drpadtype, string drpadcategory, string drpsubcategory, string drpcolor, string drpcurrency, string validfromdate1, string validtill1, string weekendrate, string decimalvalue, string uom, string adscat4, string adscat5, string adscat6, string premium, string sizefrom, string sizeto, string frominsert, string toinsert, string clientcat, string minadarea, string type, string agencycode, string dateformat, string pubcenter, string rate_sun, string rate_mon, string rate_tue, string rate_wed, string rate_thu, string rate_fri, string rate_sat, string rate_sun_extra, string rate_mon_extra, string rate_tue_extra, string rate_wed_extra, string rate_thu_extra, string rate_fri_extra, string rate_sat_extra, string extrarate, string rateid, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("rate_grid_from_detail", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm11 = new OracleParameter("weekrate", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                if (weekrate == "" || weekrate == null)
                {
                    prm11.Value = System.DBNull.Value;
                }
                else
                {
                    prm11.Value = weekrate;
                }
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("focusrate", OracleType.VarChar);
                prm12.Direction = ParameterDirection.Input;
                //if (focusrate == "" || focusrate == null)
                //{
                //    prm12.Value = System.DBNull.Value;
                //}
                //else
                //{
                prm12.Value = focusrate;
                //  }
                objOraclecommand.Parameters.Add(prm12);

                OracleParameter prm2 = new OracleParameter("packagecode", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = packagecode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("txtratecode", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = txtratecode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("drpadtype", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = drpadtype;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("drpadcategory", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = drpadcategory;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("drpsubcategory", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = drpsubcategory;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("drpcolor", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = drpcolor;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("drpcurrency", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = drpcurrency;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("validfromdate1", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                if (dateformat == "dd/mm/yyyy")
                {
                    string[] arr = validfromdate1.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    validfromdate1 = mm + "/" + dd + "/" + yy;


                }
                else
                    if (dateformat == "mm/dd/yyyy")
                    {
                        string[] arr = validfromdate1.Split('/');
                        string dd = arr[1];
                        string mm = arr[0];
                        string yy = arr[2];
                        validfromdate1 = mm + "/" + dd + "/" + yy;

                    }

                    else
                        if (dateformat == "yyyy/mm/dd")
                        {
                            string[] arr = validfromdate1.Split('/');
                            string dd = arr[2];
                            string mm = arr[1];
                            string yy = arr[0];
                            validfromdate1 = mm + "/" + dd + "/" + yy;
                        }

                prm9.Value = Convert.ToDateTime(validfromdate1).ToString("dd-MMMM-yyyy");
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("validtill1", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                if (dateformat == "dd/mm/yyyy")
                {
                    string[] arr = validtill1.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    validtill1 = mm + "/" + dd + "/" + yy;


                }
                else
                    if (dateformat == "mm/dd/yyyy")
                    {
                        string[] arr = validtill1.Split('/');
                        string dd = arr[1];
                        string mm = arr[0];
                        string yy = arr[2];
                        validtill1 = mm + "/" + dd + "/" + yy;

                    }

                    else
                        if (dateformat == "yyyy/mm/dd")
                        {
                            string[] arr = validtill1.Split('/');
                            string dd = arr[2];
                            string mm = arr[1];
                            string yy = arr[0];
                            validtill1 = mm + "/" + dd + "/" + yy;
                        }

                prm10.Value = Convert.ToDateTime(validtill1).ToString("dd-MMMM-yyyy");
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm13 = new OracleParameter("weekendrate", OracleType.VarChar);
                prm13.Direction = ParameterDirection.Input;
                //if (weekendrate == "" || weekendrate == null)
                //{
                //    prm13.Value = System.DBNull.Value;
                //}
                //else
                //{
                prm13.Value = weekendrate;
                // }
                objOraclecommand.Parameters.Add(prm13);


                OracleParameter prm14 = new OracleParameter("decimalvalue", OracleType.VarChar);
                prm14.Direction = ParameterDirection.Input;
                //if (decimalvalue == "" || decimalvalue == null)
                //{
                //    prm14.Value = System.DBNull.Value;
                //}
                //else
                //{
                prm14.Value = decimalvalue;
                // }
                objOraclecommand.Parameters.Add(prm14);



                OracleParameter prm15 = new OracleParameter("uom", OracleType.VarChar);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = uom;
                objOraclecommand.Parameters.Add(prm15);

                OracleParameter prm16 = new OracleParameter("adscat6", OracleType.VarChar);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = adscat6;
                objOraclecommand.Parameters.Add(prm16);

                OracleParameter prm17 = new OracleParameter("adscat5", OracleType.VarChar);
                prm17.Direction = ParameterDirection.Input;
                prm17.Value = adscat5;
                objOraclecommand.Parameters.Add(prm17);

                OracleParameter prm18 = new OracleParameter("adscat4", OracleType.VarChar);
                prm18.Direction = ParameterDirection.Input;
                prm18.Value = adscat4;
                objOraclecommand.Parameters.Add(prm18);

                OracleParameter prm19 = new OracleParameter("premium", OracleType.VarChar);
                prm19.Direction = ParameterDirection.Input;
                prm19.Value = premium;
                objOraclecommand.Parameters.Add(prm19);

                OracleParameter prm20 = new OracleParameter("sizefrom", OracleType.VarChar);
                prm20.Direction = ParameterDirection.Input;
                prm20.Value = sizefrom;
                objOraclecommand.Parameters.Add(prm20);

                OracleParameter prm21 = new OracleParameter("sizeto", OracleType.VarChar);
                prm21.Direction = ParameterDirection.Input;
                prm21.Value = sizeto;
                objOraclecommand.Parameters.Add(prm21);

                OracleParameter prm22 = new OracleParameter("frominsert", OracleType.VarChar);
                prm22.Direction = ParameterDirection.Input;
                prm22.Value = frominsert;
                objOraclecommand.Parameters.Add(prm22);

                OracleParameter prm23 = new OracleParameter("toinsert", OracleType.VarChar);
                prm23.Direction = ParameterDirection.Input;
                prm23.Value = toinsert;
                objOraclecommand.Parameters.Add(prm23);

                OracleParameter prm24 = new OracleParameter("clientcat", OracleType.VarChar);
                prm24.Direction = ParameterDirection.Input;
                prm24.Value = clientcat;
                objOraclecommand.Parameters.Add(prm24);

                OracleParameter prm25 = new OracleParameter("minadarea", OracleType.VarChar);
                prm25.Direction = ParameterDirection.Input;
                if (minadarea == "")
                {
                    prm25.Value = "0";
                }
                else
                {
                    prm25.Value = minadarea;
                }
                objOraclecommand.Parameters.Add(prm25);

                OracleParameter prm26 = new OracleParameter("type1", OracleType.VarChar);
                prm26.Direction = ParameterDirection.Input;
                prm26.Value = type;
                objOraclecommand.Parameters.Add(prm26);

                OracleParameter prm28 = new OracleParameter("agencycode", OracleType.VarChar);
                prm28.Direction = ParameterDirection.Input;
                prm28.Value = agencycode;
                objOraclecommand.Parameters.Add(prm28);

                OracleParameter prm29 = new OracleParameter("pubcenter", OracleType.VarChar);
                prm29.Direction = ParameterDirection.Input;
                prm29.Value = pubcenter;
                objOraclecommand.Parameters.Add(prm29);

                OracleParameter prm30 = new OracleParameter("pkg_sun_rate", OracleType.VarChar);
                prm30.Direction = ParameterDirection.Input;
                prm30.Value = rate_sun;
                objOraclecommand.Parameters.Add(prm30);

                OracleParameter prm31 = new OracleParameter("pkg_mon_rate", OracleType.VarChar);
                prm31.Direction = ParameterDirection.Input;
                prm31.Value = rate_mon;
                objOraclecommand.Parameters.Add(prm31);

                OracleParameter prm32 = new OracleParameter("pkg_tue_rate", OracleType.VarChar);
                prm32.Direction = ParameterDirection.Input;
                prm32.Value = rate_tue;
                objOraclecommand.Parameters.Add(prm32);

                OracleParameter prm33 = new OracleParameter("pkg_wed_rate", OracleType.VarChar);
                prm33.Direction = ParameterDirection.Input;
                prm33.Value = rate_wed;
                objOraclecommand.Parameters.Add(prm33);

                OracleParameter prm34 = new OracleParameter("pkg_thu_rate", OracleType.VarChar);
                prm34.Direction = ParameterDirection.Input;
                prm34.Value = rate_thu;
                objOraclecommand.Parameters.Add(prm34);

                OracleParameter prm35 = new OracleParameter("pkg_fri_rate", OracleType.VarChar);
                prm35.Direction = ParameterDirection.Input;
                prm35.Value = rate_fri;
                objOraclecommand.Parameters.Add(prm35);

                OracleParameter prm36 = new OracleParameter("pkg_sat_rate", OracleType.VarChar);
                prm36.Direction = ParameterDirection.Input;
                prm36.Value = rate_sat;
                objOraclecommand.Parameters.Add(prm36);

                /////////////////////////////////////////////////////////

                OracleParameter prm37 = new OracleParameter("pkg_sun_rate_ex", OracleType.VarChar);
                prm37.Direction = ParameterDirection.Input;
                prm37.Value = rate_sun_extra;
                objOraclecommand.Parameters.Add(prm37);

                OracleParameter prm38 = new OracleParameter("pkg_mon_rate_ex", OracleType.VarChar);
                prm38.Direction = ParameterDirection.Input;
                prm38.Value = rate_mon_extra;
                objOraclecommand.Parameters.Add(prm38);

                OracleParameter prm39 = new OracleParameter("pkg_tue_rate_ex", OracleType.VarChar);
                prm39.Direction = ParameterDirection.Input;
                prm39.Value = rate_tue_extra;
                objOraclecommand.Parameters.Add(prm39);

                OracleParameter prm40 = new OracleParameter("pkg_wed_rate_ex", OracleType.VarChar);
                prm40.Direction = ParameterDirection.Input;
                prm40.Value = rate_wed_extra;
                objOraclecommand.Parameters.Add(prm40);

                OracleParameter prm41 = new OracleParameter("pkg_thu_rate_ex", OracleType.VarChar);
                prm41.Direction = ParameterDirection.Input;
                prm41.Value = rate_thu_extra;
                objOraclecommand.Parameters.Add(prm41);

                OracleParameter prm42 = new OracleParameter("pkg_fri_rate_ex", OracleType.VarChar);
                prm42.Direction = ParameterDirection.Input;
                prm42.Value = rate_fri_extra;
                objOraclecommand.Parameters.Add(prm42);

                OracleParameter prm43 = new OracleParameter("pkg_sat_rate_ex", OracleType.VarChar);
                prm43.Direction = ParameterDirection.Input;
                prm43.Value = rate_sat_extra;
                objOraclecommand.Parameters.Add(prm43);

                OracleParameter prm44 = new OracleParameter("extrarate", OracleType.VarChar);
                prm44.Direction = ParameterDirection.Input;
                prm44.Value = extrarate;
                objOraclecommand.Parameters.Add(prm44);

                OracleParameter prm45 = new OracleParameter("ratemastid", OracleType.VarChar);
                prm45.Direction = ParameterDirection.Input;
                prm45.Value = rateid;
                objOraclecommand.Parameters.Add(prm45);

                OracleParameter prm46 = new OracleParameter("userid", OracleType.VarChar);
                prm46.Direction = ParameterDirection.Input;
                prm46.Value = userid;
                objOraclecommand.Parameters.Add(prm46);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts1"].Direction = ParameterDirection.Output;

                //objOraclecommand.Parameters.Add("p_accounts2", OracleType.Cursor);
                //objOraclecommand.Parameters["p_accounts2"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return (objDataSet);

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





        public DataSet advcategory1(string compcode, string adtype)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            NewAdbooking.classesoracle.orclconnection clscon = new NewAdbooking.classesoracle.orclconnection();
            objOracleConnection = clscon.GetConnection();
            OracleDataAdapter objOrclDataAdapter = new OracleDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = clscon.GetCommand("adcategory.adcategory_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("Adtype", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = adtype;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("company_code", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);

                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

                objOrclDataAdapter.SelectCommand = objOraclecommand;
                objOrclDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                clscon.CloseConnection(ref objOracleConnection);
            }
        }
    }
}