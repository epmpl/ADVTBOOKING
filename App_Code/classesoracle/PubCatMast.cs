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
    /// <summary>
    /// Summary description for PubCatMast
    /// </summary>
    public class PubCatMast : orclconnection
    {
        public PubCatMast()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataSet addpickdistname(string citycode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("fillstaedistcountry.fillstaedistcountry_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("citycode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = citycode;
                objOraclecommand.Parameters.Add(prm1);


                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;


                objOraclecommand.Parameters.Add("p_accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts1"].Direction = ParameterDirection.Output;


                objOraclecommand.Parameters.Add("p_accounts2", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts2"].Direction = ParameterDirection.Output;


                objOraclecommand.Parameters.Add("p_accounts3", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts3"].Direction = ParameterDirection.Output;


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
        public DataSet insertpcm(string compcode, string centercode, string centername, string alias, string add1, string street, string city, string dist, string country, string phone1, string phone2, string pin, string state, string fax, string email, string remarks, string userid, string region, string zone, string fax1, string boxaddress, string printval, string imgpath, string cir_imgpath, string companyname, string logofilename, string statecode, string MRV, string mes, string agcode, string dpcode, string booking_cutof_time)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("pcminsert.pcminsert_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("centercode", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = centercode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("centername", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = centername;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("alias", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = alias;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("add1", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = add1;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("street", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = street;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("city", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = city;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("dist", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;


                prm8.Value = dist;

                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("country", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = country;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("phone1", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = phone1;
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("phone2", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = phone2;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("pin", OracleType.VarChar);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = pin;
                objOraclecommand.Parameters.Add(prm12);


                OracleParameter prm13 = new OracleParameter("state", OracleType.VarChar);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = state;
                objOraclecommand.Parameters.Add(prm13);

                OracleParameter prm14 = new OracleParameter("fax", OracleType.VarChar);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = fax;
                objOraclecommand.Parameters.Add(prm14);

                OracleParameter prm15 = new OracleParameter("email", OracleType.VarChar);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = email;
                objOraclecommand.Parameters.Add(prm15);

                OracleParameter prm22 = new OracleParameter("remarks", OracleType.VarChar);
                prm22.Direction = ParameterDirection.Input;
                prm22.Value = remarks;
                objOraclecommand.Parameters.Add(prm22);

                OracleParameter prm16 = new OracleParameter("userid", OracleType.VarChar);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = userid;
                objOraclecommand.Parameters.Add(prm16);

                OracleParameter prm17 = new OracleParameter("region1", OracleType.VarChar);
                prm17.Direction = ParameterDirection.Input;




                prm17.Value = region;

                objOraclecommand.Parameters.Add(prm17);

                OracleParameter prm18 = new OracleParameter("zone", OracleType.VarChar);
                prm18.Direction = ParameterDirection.Input;




                prm18.Value = zone;

                objOraclecommand.Parameters.Add(prm18);

                OracleParameter prm19 = new OracleParameter("fax1", OracleType.VarChar);
                prm19.Direction = ParameterDirection.Input;
                prm19.Value = fax1;
                objOraclecommand.Parameters.Add(prm19);

                OracleParameter prm21 = new OracleParameter("boxaddress", OracleType.VarChar);
                prm21.Direction = ParameterDirection.Input;
                prm21.Value = boxaddress;
                objOraclecommand.Parameters.Add(prm21);

                OracleParameter prm23 = new OracleParameter("printval", OracleType.VarChar);
                prm23.Direction = ParameterDirection.Input;
                prm23.Value = printval;
                objOraclecommand.Parameters.Add(prm23);

                OracleParameter prm24 = new OracleParameter("imgpath", OracleType.VarChar);
                prm24.Direction = ParameterDirection.Input;
                prm24.Value = imgpath;
                objOraclecommand.Parameters.Add(prm24);

                OracleParameter prm25 = new OracleParameter("cir_imgpath", OracleType.VarChar);
                prm25.Direction = ParameterDirection.Input;
                prm25.Value = cir_imgpath;
                objOraclecommand.Parameters.Add(prm25);

                OracleParameter prm27 = new OracleParameter("pcompanyname", OracleType.VarChar);
                prm27.Direction = ParameterDirection.Input;
                prm27.Value = companyname;
                objOraclecommand.Parameters.Add(prm27);

                OracleParameter prm28 = new OracleParameter("plogopath", OracleType.VarChar);
                prm28.Direction = ParameterDirection.Input;
                prm28.Value = logofilename;
                objOraclecommand.Parameters.Add(prm28);


                OracleParameter prm29 = new OracleParameter("pstate", OracleType.VarChar);
                prm29.Direction = ParameterDirection.Input;
                prm29.Value = statecode;
                objOraclecommand.Parameters.Add(prm29);



                OracleParameter prm30 = new OracleParameter("pmrv", OracleType.VarChar);
                prm30.Direction = ParameterDirection.Input;
                prm30.Value = MRV;
                objOraclecommand.Parameters.Add(prm30);

                OracleParameter prm31 = new OracleParameter("pmessage", OracleType.VarChar);
                prm31.Direction = ParameterDirection.Input;
                prm31.Value = mes;
                objOraclecommand.Parameters.Add(prm31);

                OracleParameter prm32 = new OracleParameter("pcir_agcdpo_upd", OracleType.VarChar);
                prm32.Direction = ParameterDirection.Input;
                prm32.Value = agcode;
                objOraclecommand.Parameters.Add(prm32);

                OracleParameter prm33 = new OracleParameter("pcir_dpcdpo_upd", OracleType.VarChar);
                prm33.Direction = ParameterDirection.Input;
                prm33.Value = dpcode;
                objOraclecommand.Parameters.Add(prm33);

                // new column
                OracleParameter prm34 = new OracleParameter("pbooking_cutof_timep", OracleType.VarChar);
                prm34.Direction = ParameterDirection.Input;
                prm34.Value = booking_cutof_time;
                objOraclecommand.Parameters.Add(prm34);
                //ppriorty in int,
//pip2


                OracleParameter prm341 = new OracleParameter("ppriorty", OracleType.VarChar);
                prm341.Direction = ParameterDirection.Input;
                prm341.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm341);


                OracleParameter prm342 = new OracleParameter("pip2", OracleType.VarChar);
                prm342.Direction = ParameterDirection.Input;
                prm342.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm342);



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


        public DataSet updatepcm(string compcode, string centercode, string centername, string alias, string add1, string street, string city, string dist, string country, string phone1, string phone2, string pin, string state, string fax, string email, string remarks, string userid, string region, string zone, string fax1, string boxadd11, string printval, string imgpath, string cir_imgpath, string companyname, string logofilename, string statecode, string MRV, string mes, string agcode, string dpcode, string booking_cutof_time)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("pcmupdate.pcmupdate_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("centercode", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = centercode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("centername", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = centername;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("alias", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = alias;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("add1", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = add1;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("street", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = street;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("city", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = city;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("dist", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = dist;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("country", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = country;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("phone1", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = phone1;
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("phone2", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = phone2;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("pin", OracleType.VarChar);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = pin;
                objOraclecommand.Parameters.Add(prm12);


                OracleParameter prm13 = new OracleParameter("state", OracleType.VarChar);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = state;
                objOraclecommand.Parameters.Add(prm13);

                OracleParameter prm14 = new OracleParameter("fax", OracleType.VarChar);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = fax;
                objOraclecommand.Parameters.Add(prm14);

                OracleParameter prm15 = new OracleParameter("email", OracleType.VarChar);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = email;
                objOraclecommand.Parameters.Add(prm15);

                OracleParameter prm22 = new OracleParameter("remarks", OracleType.VarChar);
                prm22.Direction = ParameterDirection.Input;
                prm22.Value = remarks;
                objOraclecommand.Parameters.Add(prm22);

                OracleParameter prm17 = new OracleParameter("region1", OracleType.VarChar);
                prm17.Direction = ParameterDirection.Input;
                prm17.Value = region;
                objOraclecommand.Parameters.Add(prm17);

                OracleParameter prm18 = new OracleParameter("zone", OracleType.VarChar);
                prm18.Direction = ParameterDirection.Input;
                prm18.Value = zone;
                objOraclecommand.Parameters.Add(prm18);

                OracleParameter prm19 = new OracleParameter("fax1", OracleType.VarChar);
                prm19.Direction = ParameterDirection.Input;
                prm19.Value = fax1;
                objOraclecommand.Parameters.Add(prm19);


                OracleParameter prm27 = new OracleParameter("boxadd", OracleType.VarChar);
                prm27.Direction = ParameterDirection.Input;
                prm27.Value = boxadd11;
                objOraclecommand.Parameters.Add(prm27);

                OracleParameter prm28 = new OracleParameter("printval", OracleType.VarChar);
                prm28.Direction = ParameterDirection.Input;
                prm28.Value = printval;
                objOraclecommand.Parameters.Add(prm28);

                OracleParameter prm29 = new OracleParameter("imgpath", OracleType.VarChar);
                prm29.Direction = ParameterDirection.Input;
                prm29.Value = imgpath;
                objOraclecommand.Parameters.Add(prm29);

                OracleParameter prm30 = new OracleParameter("cir_imgpath", OracleType.VarChar);
                prm30.Direction = ParameterDirection.Input;
                prm30.Value = cir_imgpath;
                objOraclecommand.Parameters.Add(prm30);

                OracleParameter prm31 = new OracleParameter("pcompanyname", OracleType.VarChar);
                prm31.Direction = ParameterDirection.Input;
                prm31.Value = companyname;
                objOraclecommand.Parameters.Add(prm31);

                OracleParameter prm32 = new OracleParameter("plogopath", OracleType.VarChar);
                prm32.Direction = ParameterDirection.Input;
                prm32.Value = logofilename;
                objOraclecommand.Parameters.Add(prm32);

                OracleParameter prm33 = new OracleParameter("pstate", OracleType.VarChar);
                prm33.Direction = ParameterDirection.Input;
                prm33.Value = statecode;
                objOraclecommand.Parameters.Add(prm33);

                OracleParameter prm34 = new OracleParameter("pmrv", OracleType.VarChar);
                prm34.Direction = ParameterDirection.Input;
                prm34.Value = MRV;
                objOraclecommand.Parameters.Add(prm34);

                OracleParameter prm35 = new OracleParameter("pmessage", OracleType.VarChar);
                prm35.Direction = ParameterDirection.Input;
                prm35.Value = mes;
                objOraclecommand.Parameters.Add(prm35);

                OracleParameter prm36 = new OracleParameter("pcir_agcdpo_upd", OracleType.VarChar);
                prm36.Direction = ParameterDirection.Input;
                prm36.Value = agcode;
                objOraclecommand.Parameters.Add(prm36);

                OracleParameter prm37 = new OracleParameter("pcir_dpcdpo_upd", OracleType.VarChar);
                prm37.Direction = ParameterDirection.Input;
                prm37.Value = dpcode;
                objOraclecommand.Parameters.Add(prm37);

               // new column 
                OracleParameter prm38 = new OracleParameter("pbooking_cutof_timep", OracleType.VarChar);
                 prm38.Direction = ParameterDirection.Input;
                 prm38.Value = booking_cutof_time;
                 objOraclecommand.Parameters.Add(prm38);

                /*ppriorty in int,
ip2*/


                 OracleParameter prm381 = new OracleParameter("ppriorty", OracleType.VarChar);
                 prm381.Direction = ParameterDirection.Input;
                 prm381.Value = System.DBNull.Value;
                 objOraclecommand.Parameters.Add(prm381);


                 OracleParameter prm382 = new OracleParameter("ip2", OracleType.VarChar);
                 prm382.Direction = ParameterDirection.Input;
                 prm382.Value = System.DBNull.Value;
                 objOraclecommand.Parameters.Add(prm382);



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



        public DataSet pcmexe(string compcode, string centcode, string centname, string alias, string city, string  country, string companyname, string state, string MRV, string agcode, string dpcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("pcmexe.pcmexe_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("centcode", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = centcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("centname", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = centname;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("alias", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = alias;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm9 = new OracleParameter("country", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                if (country == "0")
                {
                    prm9.Value = "";
                }
                else
                {
                    prm9.Value = country;
                }
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm7 = new OracleParameter("city", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                if (city == "0")
                {
                    prm7.Value = "";
                }
                else
                {
                    prm7.Value = city;
                }
                objOraclecommand.Parameters.Add(prm7);


                OracleParameter prm19 = new OracleParameter("pcompname", OracleType.VarChar);
                prm19.Direction = ParameterDirection.Input;
                prm19.Value = companyname;
                objOraclecommand.Parameters.Add(prm19);


                OracleParameter prm20 = new OracleParameter("pstate", OracleType.VarChar);
                prm20.Direction = ParameterDirection.Input;
                if (state == "0")
                {
                    prm20.Value = "";
                }
                else
                {
                    prm20.Value = state;
                }
                objOraclecommand.Parameters.Add(prm20);



                OracleParameter prm21 = new OracleParameter("pmrv", OracleType.VarChar);
                prm21.Direction = ParameterDirection.Input;
                prm21.Value = MRV;
                objOraclecommand.Parameters.Add(prm21);

                OracleParameter prm22 = new OracleParameter("pcir_agcdpo_upd", OracleType.VarChar);
                prm22.Direction = ParameterDirection.Input;
                prm22.Value = agcode;
                objOraclecommand.Parameters.Add(prm22);

                OracleParameter prm23 = new OracleParameter("pcir_dpcdpo_upd", OracleType.VarChar);
                prm23.Direction = ParameterDirection.Input;
                prm23.Value = dpcode;
                objOraclecommand.Parameters.Add(prm23);



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


        public DataSet addregion(string regioncode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("pcmaddregion.pcmaddregion_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("regioncode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = regioncode;
                objOraclecommand.Parameters.Add(prm1);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts1"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_accounts2", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts2"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_accounts3", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts3"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_accounts4", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts4"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_accounts5", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts5"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_accounts6", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts6"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_accounts7", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts7"].Direction = ParameterDirection.Output;

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




        public DataSet checkpubcode(string compcode, string centcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("checkpubcatcode.checkpubcatcode_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("centcode", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = centcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userid;
                objOraclecommand.Parameters.Add(prm3);


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





        public DataSet getbind(string centcode, string compcode, string userid, string dateformat)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("pcmbinddata.pcmbinddata_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("centcode", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = centcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userid;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("date1", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = dateformat;
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

        public DataSet pcmfnpl(string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("pcmfnpl.pcmfnpl_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userid;
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

        public DataSet pcmdel(string compcode, string centercode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("pcmdel.pcmdel_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("centcode", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = centercode;
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





        public DataSet chkpcm(string compcode, string userid, string centcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("chkpcm.chkpcm_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("centcode", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = centcode;
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userid;
                objOraclecommand.Parameters.Add(prm3);


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

        //pankaj//

        public DataSet chkcity(string compcode, string userid, string centername, string city)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("checkcity.checkcity_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userid;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("centername", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = centername;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("city", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = city;
                objOraclecommand.Parameters.Add(prm5);


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

        // for modify saurabh agarwal

        public DataSet chkcitymodify(string compcode, string userid, string centername, string city, string code)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("checkcitymodify.checkcitymodify_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userid;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("centername", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = centername;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("city", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = city;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("code", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = code;
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


        public DataSet pcmstatuscheck(string compcode, string userid, string centcode, string status, string circular, string todate, string fromdate, string dateformat)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("pcmstatuschk.pcmstatuschk_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("centcode", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = centcode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("status", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = status;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("circular", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = circular;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("todate", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = Convert.ToDateTime(todate).ToString("dd-MMMM-yyyy");
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("fromdate", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");

                objOraclecommand.Parameters.Add(prm7);


                OracleParameter prm8 = new OracleParameter("date1", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = dateformat;
                objOraclecommand.Parameters.Add(prm8);

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

        //Code for the insert the status by clicking on link Button//
        public DataSet insertpcmstatus(string compcode, string userid, string centcode, string status, string fromdate, string todate, string circular, string dateformat)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("pcmstatusin.pcmstatusin_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("centcode", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = centcode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("status", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = status;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("circular", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = circular;
                objOraclecommand.Parameters.Add(prm5);


                OracleParameter prm6 = new OracleParameter("todate", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = Convert.ToDateTime(todate).ToString("dd-MMMM-yyyy");
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("fromdate", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");
                objOraclecommand.Parameters.Add(prm7);


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



        public DataSet pcmstatuscheck12(string compcode, string userid, string centcode, string status, string circular, string todate, string fromdate, string dateformat, string codepass)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("pcmstatuschk12.pcmstatuschk12_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userid;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("centcode", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = centcode;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("status", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = status;
                objOraclecommand.Parameters.Add(prm5);


                OracleParameter prm6 = new OracleParameter("circular", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = circular;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("todate", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = Convert.ToDateTime(todate);
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("fromdate", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = fromdate;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("date", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = dateformat;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("code", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = codepass;
                objOraclecommand.Parameters.Add(prm10);


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





        //Code for the Update the status by clicking on link Button//
        public DataSet updatepcmstatus(string compcode, string userid, string centcode, string status, string circular, string todate, string fromdate, string codepass)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("pcmstatusupdate.pcmstatusupdate_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userid;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("centcode", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = centcode;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("status", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = status;
                objOraclecommand.Parameters.Add(prm5);


                OracleParameter prm6 = new OracleParameter("circular", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = circular;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("todate", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = Convert.ToDateTime(todate).ToString("dd-MMMM-yyyy");
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("fromdate", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("code", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = codepass;
                objOraclecommand.Parameters.Add(prm9);

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




        //Code for the Delete the status by clicking on link Button//
        public DataSet deletepcmstatus(string centcode, string compcode, string userid, string codepass)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("pcmstatdel.pcmstatdel_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userid;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("centcode", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = centcode;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm9 = new OracleParameter("code", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = codepass;
                objOraclecommand.Parameters.Add(prm9);

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





        public DataSet selectpcmstatus(string centcode, string compcode, string userid, string code11, string dateformat)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("pcmselect.pcmselect_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userid;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("centcode", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = centcode;
                objOraclecommand.Parameters.Add(prm4);


                OracleParameter prm9 = new OracleParameter("code11", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = code11;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("dateformat", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = dateformat;
                objOraclecommand.Parameters.Add(prm10);


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


        //Code for the Update the Contact of person  by clicking on link Button//
        public DataSet contactupdate(string contactperson, string dob, string desi, string phone, string ext, string fax, string mail, string compcode, string userid, string centcode, string update, string dateformat)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("pcmcontactupdate.pcmcontactupdate_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("centcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = centcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userid;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("contactperson", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = contactperson;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("desi", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = desi;
                objOraclecommand.Parameters.Add(prm5);

                //if(dateformat=="dd/mm/yyyy")
                //{
                //    string[] txt1 = dob.Split('/');
                //    string dd = txt1[0];
                //    string mm = txt1[1];
                //    string yy = txt1[2];
                //    dob = mm + '/' + dd + '/' + yy;
                //}

                //else if(dateformat=="yyyy/mm/dd")
                //{
                //    string[] txt1 = dob.Split('/');
                //    string yy = txt1[0];
                //    string mm = txt1[1];
                //    string dd = txt1[2];
                //    dob=mm+'/'+dd+'/'+yy;
                //}
                OracleParameter prm6 = new OracleParameter("dob1", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = Convert.ToDateTime(dob).ToString("dd-MMMM-yyyy");
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("phone", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = phone;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("ext", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = ext;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("fax", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = fax;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("mail", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = mail;
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("compcode", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = compcode;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("update1", OracleType.VarChar);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = update;
                objOraclecommand.Parameters.Add(prm12);

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


        //Code for the Insert the Contact of person  by clicking on link Button//
        //string contactperson, string txtdob, string txtphoneno, string desi, string txtext, string txtfaxno, string mail, string centcode, string compcode, string userid
        public DataSet insertcontact(string contact, string dob, string desi, string phone, string ext, string fax, string mail, string userid, string centcode, string compcode, string dateformat)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("pcmcontactdetails.pcmcontactdetails_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("centcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = centcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm4 = new OracleParameter("contact", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = contact;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("desi", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = desi;
                objOraclecommand.Parameters.Add(prm5);


                OracleParameter prm6 = new OracleParameter("dob", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                if (dob == "" || dob == null || dob == "Undefined")
                {
                    prm6.Value = System.DBNull.Value;
                }
                else
                {
                    prm6.Value = Convert.ToDateTime(dob).ToString("dd-MMMM-yyyy");

                }
                objOraclecommand.Parameters.Add(prm6);
                /*
                objOraclecommand.Parameters.Add("dob", SqlDbType.DateTime);
                if (dob == "" || dob == null || dob == "Undefined")
                {
                    objOraclecommand.Parameters["dob"].Value = System.DBNull.Value;
                }
                else
                {
                    objOraclecommand.Parameters["dob"].Value = Convert.ToDateTime(dob);
                }
                */

                OracleParameter prm7 = new OracleParameter("phone", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = phone;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("ext", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = ext;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("fax", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = fax;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("mail", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = mail;
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("userid", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = userid;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("compcode", OracleType.VarChar);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = compcode;
                objOraclecommand.Parameters.Add(prm12);

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




        public DataSet pcmcontbind(string centcode, string compcode, string userid, string dateformat)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("pcmcontbind.pcmcontbind_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm13 = new OracleParameter("centcode", OracleType.VarChar);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = centcode;
                objOraclecommand.Parameters.Add(prm13);

                OracleParameter prm14 = new OracleParameter("date1", OracleType.VarChar);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = dateformat;
                objOraclecommand.Parameters.Add(prm14);

                OracleParameter prm11 = new OracleParameter("userid", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = userid;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("compcode", OracleType.VarChar);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = compcode;
                objOraclecommand.Parameters.Add(prm12);

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



        //Code for the Select the Contact of person  by clicking on Check boxes//
        public DataSet selpcmbind(string centcode, string userid, string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("pcmselcont.pcmselcont_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm14 = new OracleParameter("contcode", OracleType.VarChar);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = centcode;
                objOraclecommand.Parameters.Add(prm14);

                OracleParameter prm11 = new OracleParameter("userid", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = userid;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("compcode", OracleType.VarChar);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = compcode;
                objOraclecommand.Parameters.Add(prm12);

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
        //Code for the Delete the Contact of person  by clicking on Delete Button//
        public DataSet pcmcontdelete(string centcode, string compcode, string userid, string update)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("pcmcontdelete.pcmcontdelete_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm13 = new OracleParameter("centcode", OracleType.VarChar);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = centcode;
                objOraclecommand.Parameters.Add(prm13);

                OracleParameter prm11 = new OracleParameter("userid", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = userid;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("compcode", OracleType.VarChar);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = compcode;
                objOraclecommand.Parameters.Add(prm12);

                OracleParameter prm10 = new OracleParameter("update1", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = update;
                objOraclecommand.Parameters.Add(prm10);


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


        public DataSet pubcatcode(/*string cod, */string str, string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("autopubcatcode.autopubcatcode_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm10 = new OracleParameter("str", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = str;
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("cod", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;

                if (str.Length > 2)
                {
                    prm11.Value = str.Substring(0, 2);
                    objOraclecommand.Parameters.Add(prm11);
                }
                else
                {
                    prm11.Value = str;
                    objOraclecommand.Parameters.Add(prm11);
                }

                OracleParameter prm1 = new OracleParameter("company_code", OracleType.VarChar);
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
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }
        }
        public DataSet bindcontact(string compcode, string userid, string centcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("pcmbinddata.pcmbinddata_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm13 = new OracleParameter("centcode", OracleType.VarChar);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = centcode;
                objOraclecommand.Parameters.Add(prm13);

                OracleParameter prm11 = new OracleParameter("userid", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = userid;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("compcode", OracleType.VarChar);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = compcode;
                objOraclecommand.Parameters.Add(prm12);


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

        public DataSet chkcolor(string contactperson1, string centcode, string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("pub_chkname.pub_chkname_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm13 = new OracleParameter("centcode", OracleType.VarChar);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = centcode;
                objOraclecommand.Parameters.Add(prm13);

                OracleParameter prm12 = new OracleParameter("compcode", OracleType.VarChar);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = compcode;
                objOraclecommand.Parameters.Add(prm12);

                OracleParameter prm14 = new OracleParameter("contactper", OracleType.VarChar);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = contactperson1;
                objOraclecommand.Parameters.Add(prm14);

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

        //txtphoneno,txtext,txtfaxno,mail,desi,txtdob

        public DataSet chkcolormod(string contactperson1, string centcode, string compcode, string txtphoneno, string txtext, string txtfaxno, string mail, string desi, string txtdob)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("pub_chkname_mod.pub_chkname_mod_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm13 = new OracleParameter("centcode", OracleType.VarChar);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = centcode;
                objOraclecommand.Parameters.Add(prm13);

                OracleParameter prm12 = new OracleParameter("compcode", OracleType.VarChar);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = compcode;
                objOraclecommand.Parameters.Add(prm12);

                OracleParameter prm14 = new OracleParameter("contactper", OracleType.VarChar);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = contactperson1;
                objOraclecommand.Parameters.Add(prm14);

                OracleParameter prm15 = new OracleParameter("txtphoneno", OracleType.VarChar);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = txtphoneno;
                objOraclecommand.Parameters.Add(prm15);

                OracleParameter prm16 = new OracleParameter("txtext", OracleType.VarChar);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = txtext;
                objOraclecommand.Parameters.Add(prm16);

                OracleParameter prm17 = new OracleParameter("txtfaxno", OracleType.VarChar);
                prm17.Direction = ParameterDirection.Input;
                prm17.Value = txtfaxno;
                objOraclecommand.Parameters.Add(prm17);

                OracleParameter prm18 = new OracleParameter("mail", OracleType.VarChar);
                prm18.Direction = ParameterDirection.Input;
                prm18.Value = mail;
                objOraclecommand.Parameters.Add(prm18);

                OracleParameter prm19 = new OracleParameter("desi", OracleType.VarChar);
                prm19.Direction = ParameterDirection.Input;
                prm19.Value = desi;
                objOraclecommand.Parameters.Add(prm19);

                OracleParameter prm20 = new OracleParameter("txtdob", OracleType.VarChar);
                prm20.Direction = ParameterDirection.Input;
                prm20.Value = txtdob;
                objOraclecommand.Parameters.Add(prm20);


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

        public DataSet chkusercode(string compcode, string code)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("pcmusercodechk.pcmusercodechk_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("code1", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = code;
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

        public DataSet pubnamechk(string str)//, string city)
        {
            OracleConnection objOracleConnection;
            OracleCommand cmd;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                cmd = GetCommand("chkbranchname", ref objOracleConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("str", OracleType.VarChar, 20);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = str;
                cmd.Parameters.Add(prm1);

                cmd.Parameters.Add("P_ACCOUNT", OracleType.Cursor);
                cmd.Parameters["P_ACCOUNT"].Direction = ParameterDirection.Output;

                cmd.Parameters.Add("P_ACCOUNT1", OracleType.Cursor);
                cmd.Parameters["P_ACCOUNT1"].Direction = ParameterDirection.Output;

                cmd.Parameters.Add("P_ACCOUNT2", OracleType.Cursor);
                cmd.Parameters["P_ACCOUNT2"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = cmd;
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
        public DataSet pubcodechk(string str, string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("chkpubcatcode", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm10 = new OracleParameter("str", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = str;
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm1 = new OracleParameter("company_code", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                objOraclecommand.Parameters.Add("P_ACCOUNT", OracleType.Cursor);
                objOraclecommand.Parameters["P_ACCOUNT"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("P_ACCOUNT1", OracleType.Cursor);
                objOraclecommand.Parameters["P_ACCOUNT1"].Direction = ParameterDirection.Output;

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

        public DataSet bind_agency(string code, string unit, string brcode, string dateformat, string extra1, string extra2)
        {
            OracleConnection con;
            OracleCommand cmd;
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {
                con.Open();
                cmd = GetCommand("cir_agency_bind.cir_agency_bind_p", ref con);
                cmd.CommandType = CommandType.StoredProcedure;



                OracleParameter prm1 = new OracleParameter("pcompcode", OracleType.VarChar, 1000);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = code;
                cmd.Parameters.Add(prm1);

                OracleParameter prm11 = new OracleParameter("punit", OracleType.VarChar, 1000);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = unit;
                cmd.Parameters.Add(prm11);

                //OracleParameter prm18 = new OracleParameter("pbranchcode", OracleType.VarChar, 1000);
                //prm18.Direction = ParameterDirection.Input;
                //prm18.Value = "";
                //cmd.Parameters.Add(prm18);


                OracleParameter prm2 = new OracleParameter("pdateformat", OracleType.VarChar, 1000);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = dateformat;
                cmd.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("pextra1", OracleType.VarChar, 1000);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = extra1;
                cmd.Parameters.Add(prm3);


                OracleParameter prm4 = new OracleParameter("pextra2", OracleType.VarChar, 1000);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = extra2;
                cmd.Parameters.Add(prm4);

                cmd.Parameters.Add("p_accounts", OracleType.Cursor);
                cmd.Parameters["p_accounts"].Direction = ParameterDirection.Output;


                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;

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

        public DataSet get_agency_name(string comp,string unit,string agcd,string dpcd)
        {
            OracleConnection con;
            OracleCommand cmd = new OracleCommand();
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {
                string codes = "";

                codes = "select cir_get_agency('" + comp + "', '" + unit + "', '" + agcd + "', '" + dpcd + "') as AG_NAME  from dual";
                cmd.CommandText = codes;
                cmd.Connection = con;
                con.Open();
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
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





      /*  public DataSet get_agency_name(string code, string unit, string agcd, string dpcd, string dateformat, string extra1, string extra2)
        {
            OracleConnection con;
            OracleCommand cmd;
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {
                con.Open();
                cmd = GetCommand("cir_agency_bind.cir_agency_bind_p", ref con);
                cmd.CommandType = CommandType.StoredProcedure;



                OracleParameter prm1 = new OracleParameter("pcompcode", OracleType.VarChar, 1000);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = code;
                cmd.Parameters.Add(prm1);

                OracleParameter prm11 = new OracleParameter("punit", OracleType.VarChar, 1000);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = unit;
                cmd.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("pagcd", OracleType.VarChar, 1000);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = agcd;
                cmd.Parameters.Add(prm12);

                OracleParameter prm14 = new OracleParameter("pdpcd", OracleType.VarChar, 1000);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = dpcd;
                cmd.Parameters.Add(prm14);


                OracleParameter prm2 = new OracleParameter("pdateformat", OracleType.VarChar, 1000);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = dateformat;
                cmd.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("pextra1", OracleType.VarChar, 1000);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = extra1;
                cmd.Parameters.Add(prm3);


                OracleParameter prm4 = new OracleParameter("pextra2", OracleType.VarChar, 1000);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = extra2;
                cmd.Parameters.Add(prm4);

                cmd.Parameters.Add("p_accounts", OracleType.Cursor);
                cmd.Parameters["p_accounts"].Direction = ParameterDirection.Output;


                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;

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
        */
    }
}