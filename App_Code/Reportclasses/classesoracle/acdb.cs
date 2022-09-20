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
    /// Summary description for acdb
    /// </summary>
    public class acdb : orclconnection
    {
        public acdb()
        {
            //
            // TODO: Add constructor logic here
            //
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
                objOraclecommand = GetCommand("Sp_Regionac.Sp_Regionac_p", ref objOracleConnection);
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


        public DataSet bindplace(string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("Spcityac.Spcityac_p", ref objOracleConnection);
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


        public DataSet database(string value, string region, string compcode, string place,string ascdesc,string descid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("agenclientdata", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm16 = new OracleParameter("value", OracleType.VarChar);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = value;
                objOraclecommand.Parameters.Add(prm16);

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

                OracleParameter prm8 = new OracleParameter("place", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                if (place == "0")
                {
                    prm8.Value = System.DBNull.Value;
                }
                else
                {
                    prm8.Value = place;
                }
                objOraclecommand.Parameters.Add(prm8);

                
                //=========================

                OracleParameter prm11 = new OracleParameter("descid", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = descid;
                objOraclecommand.Parameters.Add(prm11);



                OracleParameter prm12 = new OracleParameter("ascdesc", OracleType.VarChar);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = ascdesc;
                objOraclecommand.Parameters.Add(prm12);

                //=================================

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
            // spregionexcel

        }

        public OracleDataReader databasee(string value, string region, string compcode, string place, string ascdesc, string descid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("agenclientdata", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm16 = new OracleParameter("value", OracleType.VarChar);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = value;
                objOraclecommand.Parameters.Add(prm16);

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

                OracleParameter prm8 = new OracleParameter("place", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                if (place == "0")
                {
                    prm8.Value = System.DBNull.Value;
                }
                else
                {
                    prm8.Value = place;
                }
                objOraclecommand.Parameters.Add(prm8);


                //=========================

                OracleParameter prm11 = new OracleParameter("descid", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = descid;
                objOraclecommand.Parameters.Add(prm11);



                OracleParameter prm12 = new OracleParameter("ascdesc", OracleType.VarChar);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = ascdesc;
                objOraclecommand.Parameters.Add(prm12);

                //=================================

                objOraclecommand.Parameters.Add("p_recordset1", OracleType.Cursor);
                objOraclecommand.Parameters["p_recordset1"].Direction = ParameterDirection.Output;

                //objorclDataAdapter.SelectCommand = objOraclecommand;
                //objorclDataAdapter.Fill(objDataSet);

                //return objDataSet;

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
               // CloseConnection(ref objOracleConnection);
            }
            // spregionexcel

        }

        public DataSet displayonscreenreport1(string pubcent, string adtyp, string frmdt, string todate, string compcode, string publication, string dateformate, string descid, string ascdesc, string value, string execut , string team, string bill)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("billregister.billregister_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm4 = new OracleParameter("fromdate", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                if (frmdt == "0" || frmdt == "")
                {
                    prm4.Value = System.DBNull.Value;
                }
                else
                {
                    prm4.Value = Convert.ToDateTime(frmdt).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("dateto", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                if (todate == "0" || todate == "")
                {
                    prm5.Value = System.DBNull.Value;
                }
                else
                {
                    prm5.Value = Convert.ToDateTime(todate).ToString("dd-MMMM-yyyy");
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
                prm18.Value = dateformate;
                objOraclecommand.Parameters.Add(prm18);

                OracleParameter prm17 = new OracleParameter("adtyp", OracleType.VarChar);
                prm17.Direction = ParameterDirection.Input;
                if (adtyp == "0" || adtyp == "")
                {
                    prm17.Value = System.DBNull.Value;
                }
                else
                {
                    prm17.Value = adtyp;
                }
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

                OracleParameter prm1117 = new OracleParameter("team", OracleType.VarChar);
                prm1117.Direction = ParameterDirection.Input;
                if (team == "0" || team == "")
                {
                    prm1117.Value = System.DBNull.Value;
                }
                else
                {
                    prm1117.Value = team;
                }
                objOraclecommand.Parameters.Add(prm1117);



                OracleParameter prm11115 = new OracleParameter("execut", OracleType.VarChar);
                prm11115.Direction = ParameterDirection.Input;
                if (execut == "0" || execut == "")
                {
                    prm11115.Value = System.DBNull.Value;
                }
                else
                {
                    prm11115.Value = execut;
                }

                objOraclecommand.Parameters.Add(prm11115);

                OracleParameter prm111151 = new OracleParameter("bill", OracleType.VarChar);
                prm111151.Direction = ParameterDirection.Input;
                if (bill == "0" || bill == "")
                {
                    prm111151.Value = System.DBNull.Value;
                }
                else
                {
                    prm111151.Value = bill;
                }

                objOraclecommand.Parameters.Add(prm111151);

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

        //=====================
        public DataSet billreginfo(string pubcent, string adtyp, string frmdt, string todate, string compcode, string publication, string dateformate, string descid, string ascdesc, string value, string execut, string team, string bill)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("Billregisterinfo.Billregisterinfo_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm4 = new OracleParameter("fromdate", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                if (frmdt == "0" || frmdt =="")
                {
                    prm4.Value = System.DBNull.Value;
                }
                else
                {
                    prm4.Value = Convert.ToDateTime(frmdt).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("dateto", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                if (todate == "0" || todate == "")
                {
                    prm5.Value = System.DBNull.Value;
                }
                else
                {
                    prm5.Value = Convert.ToDateTime(todate).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("compcode", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = compcode;
                objOraclecommand.Parameters.Add(prm6);


                OracleParameter prm7 = new OracleParameter("pub_name", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                if (publication == "0" || publication == "")
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
                
                prm18.Value = dateformate;
                objOraclecommand.Parameters.Add(prm18);

                OracleParameter prm17 = new OracleParameter("adtyp", OracleType.VarChar);
                prm17.Direction = ParameterDirection.Input;
                if (adtyp == "0" || adtyp == "")
                {
                    prm17.Value = System.DBNull.Value;
                }
                else
                {
                    prm17.Value = adtyp;
                }
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

                OracleParameter prm1117 = new OracleParameter("team", OracleType.VarChar);
                prm1117.Direction = ParameterDirection.Input;
                if (team == "0" || team == "")
                {
                    prm1117.Value = System.DBNull.Value;
                }
                else
                {
                    prm1117.Value = team;
                }
                objOraclecommand.Parameters.Add(prm1117);



                OracleParameter prm11115 = new OracleParameter("execut", OracleType.VarChar);
                prm11115.Direction = ParameterDirection.Input;
                if (execut == "0" || execut == "")
                {
                    prm11115.Value = System.DBNull.Value;
                }
                else
                {
                    prm11115.Value = execut;
                }

                objOraclecommand.Parameters.Add(prm11115);


                OracleParameter prm111151 = new OracleParameter("bill", OracleType.VarChar);
                prm111151.Direction = ParameterDirection.Input;
                if (bill == "0" || bill == "")
                {
                    prm111151.Value = System.DBNull.Value;
                }
                else
                {
                    prm111151.Value = bill;
                }

                objOraclecommand.Parameters.Add(prm111151);

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
        //=================

        //=========================
        public DataSet representative(string pubcent, string adtyp, string frmdt, string todate, string compcode, string publication, string dateformate, string descid, string ascdesc, string value, string execut, string team, string bill,string cl,string ag)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("Representative.Representative_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm4 = new OracleParameter("fromdate", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                if (frmdt == "0" || frmdt == "")
                {
                    prm4.Value = System.DBNull.Value;
                }
                else
                {
                    prm4.Value = Convert.ToDateTime(frmdt).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("dateto", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                if (todate == "0" || todate == "")
                {
                    prm5.Value = System.DBNull.Value;
                }
                else
                {
                    prm5.Value = Convert.ToDateTime(todate).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("compcode", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = compcode;
                objOraclecommand.Parameters.Add(prm6);


                OracleParameter prm7 = new OracleParameter("pub_name", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                if (publication == "0" || publication == "")
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

                prm18.Value = dateformate;
                objOraclecommand.Parameters.Add(prm18);

                OracleParameter prm17 = new OracleParameter("adtyp", OracleType.VarChar);
                prm17.Direction = ParameterDirection.Input;
                if (adtyp == "0" || adtyp == "")
                {
                    prm17.Value = System.DBNull.Value;
                }
                else
                {
                    prm17.Value = adtyp;
                }
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

                OracleParameter prm1117 = new OracleParameter("team", OracleType.VarChar);
                prm1117.Direction = ParameterDirection.Input;
                if (team == "0" || team == "")
                {
                    prm1117.Value = System.DBNull.Value;
                }
                else
                {
                    prm1117.Value = team;
                }
                objOraclecommand.Parameters.Add(prm1117);



                OracleParameter prm11115 = new OracleParameter("execut", OracleType.VarChar);
                prm11115.Direction = ParameterDirection.Input;
                if (execut == "0" || execut == "")
                {
                    prm11115.Value = System.DBNull.Value;
                }
                else
                {
                    prm11115.Value = execut;
                }

                objOraclecommand.Parameters.Add(prm11115);


                OracleParameter prm111151 = new OracleParameter("bill", OracleType.VarChar);
                prm111151.Direction = ParameterDirection.Input;
                if (bill == "0" || bill == "")
                {
                    prm111151.Value = System.DBNull.Value;
                }
                else
                {
                    prm111151.Value = bill;
                }

                objOraclecommand.Parameters.Add(prm111151);

                OracleParameter prm11111 = new OracleParameter("cl", OracleType.VarChar);
                prm11111.Direction = ParameterDirection.Input;
                if (cl == "0" || cl == "")
                {
                    prm11111.Value = System.DBNull.Value;
                }
                else
                {
                    prm11111.Value = cl;
                }

                objOraclecommand.Parameters.Add(prm11111);

                OracleParameter prm1111511 = new OracleParameter("ag", OracleType.VarChar);
                prm1111511.Direction = ParameterDirection.Input;
                if (ag == "0" || ag == "")
                {
                    prm1111511.Value = System.DBNull.Value;
                }
                else
                {
                    prm1111511.Value = ag;
                }

                objOraclecommand.Parameters.Add(prm1111511);

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
        //=================

        public DataSet ageana(string pubcent, string adtyp, string frmdt, string todate, string compcode, string rev, string dateformate, string descid, string ascdesc, string value, string execut, string place, string bill, string publication1, string edition1, string noofrows, string check11, string useid, string chk_acc,string branch)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("Agencyana.agencyana_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter top1 = new OracleParameter("puserid", OracleType.VarChar);
                top1.Direction = ParameterDirection.Input;
                top1.Value = useid;
                objOraclecommand.Parameters.Add(top1);

                OracleParameter top2 = new OracleParameter("chk_access", OracleType.VarChar);
                top2.Direction = ParameterDirection.Input;
                top2.Value = chk_acc;
                objOraclecommand.Parameters.Add(top2);

                OracleParameter prm4 = new OracleParameter("fromdate", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                if (frmdt == "" || frmdt == null)
                {
                    prm4.Value = System.DBNull.Value;
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
                    prm4.Value = Convert.ToDateTime(frmdt).ToString("dd-MMMM-yyyy");

                }
                objOraclecommand.Parameters.Add(prm4);







                OracleParameter prm5 = new OracleParameter("dateto", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                if (todate == "" || todate == null)
                {
                    prm5.Value = System.DBNull.Value;
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
                    prm5.Value = Convert.ToDateTime(todate).ToString("dd-MMMM-yyyy");

                }
                objOraclecommand.Parameters.Add(prm5);


                //OracleParameter prm4 = new OracleParameter("fromdate", OracleType.VarChar);
                //prm4.Direction = ParameterDirection.Input;
                //if (frmdt == "0" || frmdt == "")
                //{
                //    prm4.Value = System.DBNull.Value;
                //}
                //else
                //{
                //    prm4.Value = Convert.ToDateTime(frmdt).ToString("dd-MMMM-yyyy");
                //}
                //objOraclecommand.Parameters.Add(prm4);

                //OracleParameter prm5 = new OracleParameter("dateto", OracleType.VarChar);
                //prm5.Direction = ParameterDirection.Input;
                //if (todate == "0" || todate == "")
                //{
                //    prm5.Value = System.DBNull.Value;
                //}
                //else
                //{
                //    prm5.Value = Convert.ToDateTime(todate).ToString("dd-MMMM-yyyy");
                //}
                //objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("compcode", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = compcode;
                objOraclecommand.Parameters.Add(prm6);


                OracleParameter prm7 = new OracleParameter("rev_name", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                if (rev == "0" || rev == "")
                {
                    prm7.Value = System.DBNull.Value;
                }
                else
                {
                    prm7.Value = rev;
                }
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prmu7 = new OracleParameter("executive", OracleType.VarChar);
                prmu7.Direction = ParameterDirection.Input;
                if (execut == "0" || execut == "")
                {
                    prmu7.Value = System.DBNull.Value;
                }
                else
                {
                    prmu7.Value = execut;
                }
                objOraclecommand.Parameters.Add(prmu7);


                OracleParameter prm18 = new OracleParameter("dateformat", OracleType.VarChar);
                prm18.Direction = ParameterDirection.Input;

                prm18.Value = dateformate;
                objOraclecommand.Parameters.Add(prm18);

                OracleParameter prm17 = new OracleParameter("adtyp", OracleType.VarChar);
                prm17.Direction = ParameterDirection.Input;
                if (adtyp == "0" || adtyp == "")
                {
                    prm17.Value = System.DBNull.Value;
                }
                else
                {
                    prm17.Value = adtyp;
                }
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

               

                //OracleParameter prm11111 = new OracleParameter("cl", OracleType.VarChar);
                //prm11111.Direction = ParameterDirection.Input;
                //if (cl == "0" || cl == "")
                //{
                //    prm11111.Value = System.DBNull.Value;
                //}
                //else
                //{
                //    prm11111.Value = cl;
                //}

                //objOraclecommand.Parameters.Add(prm11111);

                //OracleParameter prm1111511 = new OracleParameter("ag", OracleType.VarChar);
                //prm1111511.Direction = ParameterDirection.Input;
                //if (ag == "0" || ag == "")
                //{
                //    prm1111511.Value = System.DBNull.Value;
                //}
                //else
                //{
                //    prm1111511.Value = ag;
                //}

                //objOraclecommand.Parameters.Add(prm1111511);

                OracleParameter prm1611 = new OracleParameter("place", OracleType.VarChar);
                prm1611.Direction = ParameterDirection.Input;
                if (place == "0" || place == "")
                {
                    prm1611.Value = System.DBNull.Value;
                }
                else
                {
                    prm1611.Value = place;
                }
                objOraclecommand.Parameters.Add(prm1611);

                OracleParameter prm161101 = new OracleParameter("publication1", OracleType.VarChar);
                prm161101.Direction = ParameterDirection.Input;
                if (publication1 == "0" || publication1 == "")
                {
                    prm161101.Value = System.DBNull.Value;
                }
                else
                {
                    prm161101.Value = publication1;
                }
                objOraclecommand.Parameters.Add(prm161101);

                OracleParameter prm161102 = new OracleParameter("Edition1", OracleType.VarChar);
                prm161102.Direction = ParameterDirection.Input;
                if (edition1 == "0" || edition1 == "")
                {
                    prm161102.Value = System.DBNull.Value;
                }
                else
                {
                    prm161102.Value = edition1;
                }
                objOraclecommand.Parameters.Add(prm161102);

                OracleParameter prm161103 = new OracleParameter("check11", OracleType.VarChar);
                prm161103.Direction = ParameterDirection.Input;
                if (check11 == "0" || check11 == "")
                {
                    prm161103.Value = System.DBNull.Value;
                }
                else
                {
                    prm161103.Value = check11;
                }
                objOraclecommand.Parameters.Add(prm161103);

                OracleParameter prm16104 = new OracleParameter("totalrows", OracleType.VarChar);
                prm16104.Direction = ParameterDirection.Input;
                prm16104.Value = noofrows;
                objOraclecommand.Parameters.Add(prm16104);


                OracleParameter prm16121 = new OracleParameter("agency_code", OracleType.VarChar);
                prm16121.Direction = ParameterDirection.Input;
                prm16121.Value = System.DBNull.Value;


                OracleParameter prm16122 = new OracleParameter("agency_sub_code", OracleType.VarChar);
                prm16122.Direction = ParameterDirection.Input;
                prm16122.Value = System.DBNull.Value;

                OracleParameter prm16123 = new OracleParameter("branch", OracleType.VarChar);
                prm16123.Direction = ParameterDirection.Input;
                prm16123.Value = branch;
                objOraclecommand.Parameters.Add(prm16123);
                

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                //objOraclecommand.Parameters.Add("p_accounts1", OracleType.Cursor);
                //objOraclecommand.Parameters["p_accounts1"].Direction = ParameterDirection.Output;


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
        //==============================

        public OracleDataReader displayexcelfile1(string pubcent, string adtyp, string frmdt, string todate, string compcode, string publication, string dateformate, string temp, string temp2, string value)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("billregister.billregister_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm4 = new OracleParameter("fromdate", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                if (frmdt == "0")
                {
                    prm4.Value = System.DBNull.Value;
                }
                else
                {
                    prm4.Value = Convert.ToDateTime(frmdt).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("dateto", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                if (todate == "0")
                {
                    prm5.Value = System.DBNull.Value;
                }
                else
                {
                    prm5.Value = Convert.ToDateTime(todate).ToString("dd-MMMM-yyyy");
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

                OracleParameter prm321 = new OracleParameter("adtyp", OracleType.VarChar);
                prm321.Direction = ParameterDirection.Input;
                prm321.Value = adtyp;
                objOraclecommand.Parameters.Add(prm321);

                OracleParameter prm14 = new OracleParameter("dateformat", OracleType.VarChar);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = dateformate;
                objOraclecommand.Parameters.Add(prm14);


                OracleParameter prm15 = new OracleParameter("descid", OracleType.VarChar);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = temp2;
                objOraclecommand.Parameters.Add(prm15);

                OracleParameter prm16 = new OracleParameter("ascdesc", OracleType.VarChar);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = temp;
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



    }
}