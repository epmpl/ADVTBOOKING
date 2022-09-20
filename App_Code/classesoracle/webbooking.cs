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

    /// <summary>
    /// Summary description for webbooking
    /// </summary>
    public class webbooking : orclconnection
    {
        public webbooking()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataSet savegeo(string country, string state, string city, string edition, string cio_book_id, string noinsert, string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("geographical", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pcountry", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;


                if (country == "")
                {
                    prm1.Value = "0";
                }
                else
                {
                    prm1.Value = country;
                }
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("pstate", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                if (state == "")
                {
                    prm2.Value = "0";
                }
                else
                {
                    prm2.Value = state;
                }

               
                objOraclecommand.Parameters.Add(prm2);




                OracleParameter prm3 = new OracleParameter("pcity", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;

                if (city == "")
                {
                    prm3.Value = "0";
                }
                else
                {
                    prm3.Value = city;
                }
                
                objOraclecommand.Parameters.Add(prm3);




                OracleParameter prm4 = new OracleParameter("pedition", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = edition;
                objOraclecommand.Parameters.Add(prm4);



                OracleParameter prm5 = new OracleParameter("pciobooking_id", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = cio_book_id;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("pnoofinsert", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = noinsert;
                objOraclecommand.Parameters.Add(prm6);



                OracleParameter prm7 = new OracleParameter("pcomp_code", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = compcode;
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



        public DataSet savegeo12(string country, string state, string city, string edition, string cio_book_id, string noinsert, string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("updategeographical", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pcountry", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;


                if (country == "")
                {
                    prm1.Value = "0";
                }
                else
                {
                    prm1.Value = country;
                }
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("pstate", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                if (state == "")
                {
                    prm2.Value = "0";
                }
                else
                {
                    prm2.Value = state;
                }


                objOraclecommand.Parameters.Add(prm2);




                OracleParameter prm3 = new OracleParameter("pcity", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;

                if (city == "")
                {
                    prm3.Value = "0";
                }
                else
                {
                    prm3.Value = city;
                }

                objOraclecommand.Parameters.Add(prm3);




                OracleParameter prm4 = new OracleParameter("pedition", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = edition;
                objOraclecommand.Parameters.Add(prm4);



                OracleParameter prm5 = new OracleParameter("pciobooking_id", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = cio_book_id;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("pnoofinsert", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = noinsert;
                objOraclecommand.Parameters.Add(prm6);



                OracleParameter prm7 = new OracleParameter("pcomp_code", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = compcode;
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













        public string webmaterial(string cioid, string imagefile, string imagename, string url, string filename, string Comp_code, string NO_INSERT, string EDITION)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            //OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("webbookingmaterial", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pcioid", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = cioid;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("pimagefile", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = imagefile;
                objOraclecommand.Parameters.Add(prm2);




                OracleParameter prm3 = new OracleParameter("pimagename", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = imagename;
                objOraclecommand.Parameters.Add(prm3);




                OracleParameter prm4 = new OracleParameter("purl", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = url;
                objOraclecommand.Parameters.Add(prm4);



                OracleParameter prm5 = new OracleParameter("pfilename", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = filename;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("pComp_code", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = Comp_code;
                objOraclecommand.Parameters.Add(prm6);



                OracleParameter prm7 = new OracleParameter("pNO_INSERT", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = NO_INSERT;
                objOraclecommand.Parameters.Add(prm7);





                OracleParameter prm8 = new OracleParameter("pEDITION", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = EDITION;
                objOraclecommand.Parameters.Add(prm8);


                objOraclecommand.ExecuteNonQuery();
                return "True";
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











        public DataSet savedays(string Rotation, string Priority, string Sunday, string Sunday_From, string Sunday_To, string Monday, string Monday_From, string Monday_To, string Tuesday, string Tuesday_From, string Tuesday_To, string Wednesday, string Wednesday_From, string Wednesday_To, string Thursday, string Thursday_From, string Thursday_To, string Friday, string Friday_From, string Friday_To, string Saturday, string Saturday_From, string Saturday_To, string Demog_sex, string Demog_agegroup, string Demog_Occup, string Demog_inter, string ciobookingid, string noofinsert, string compcode, string edition, string interest)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("insertbookingdays", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pRotation", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = Rotation;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("pPriority", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = Priority;
                objOraclecommand.Parameters.Add(prm2);




                OracleParameter prm3 = new OracleParameter("pSunday", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = Sunday;
                objOraclecommand.Parameters.Add(prm3);




                OracleParameter prm4 = new OracleParameter("pSunday_From", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = Sunday_From;
                objOraclecommand.Parameters.Add(prm4);



                OracleParameter prm5 = new OracleParameter("pSunday_To", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = Sunday_To;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("pMonday", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = Monday;
                objOraclecommand.Parameters.Add(prm6);



                OracleParameter prm7 = new OracleParameter("pMonday_From", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = Monday_From;
                objOraclecommand.Parameters.Add(prm7);




                OracleParameter prm8 = new OracleParameter("pMonday_To", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = Monday_To;
                objOraclecommand.Parameters.Add(prm8);



                OracleParameter prm9 = new OracleParameter("pTuesday", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = Tuesday;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("pTuesday_From", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = Tuesday_From;
                objOraclecommand.Parameters.Add(prm10);



                OracleParameter prm11 = new OracleParameter("pTuesday_To", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = Tuesday_To;
                objOraclecommand.Parameters.Add(prm11);






                OracleParameter prm12 = new OracleParameter("pWednesday", OracleType.VarChar, 50);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = Wednesday;
                objOraclecommand.Parameters.Add(prm12);

                OracleParameter prm13 = new OracleParameter("pWednesday_From", OracleType.VarChar, 50);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = Wednesday_From;
                objOraclecommand.Parameters.Add(prm13);



                OracleParameter prm14 = new OracleParameter("pWednesday_To", OracleType.VarChar, 50);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = Wednesday_To;
                objOraclecommand.Parameters.Add(prm14);





                OracleParameter prm15 = new OracleParameter("pThursday", OracleType.VarChar, 50);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = Thursday;
                objOraclecommand.Parameters.Add(prm15);

                OracleParameter prm16 = new OracleParameter("pThursday_From", OracleType.VarChar, 50);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = Thursday_From;
                objOraclecommand.Parameters.Add(prm16);



                OracleParameter prm17 = new OracleParameter("pThursday_To", OracleType.VarChar, 50);
                prm17.Direction = ParameterDirection.Input;
                prm17.Value = Thursday_To;
                objOraclecommand.Parameters.Add(prm17);




                OracleParameter prm18 = new OracleParameter("pFriday", OracleType.VarChar, 50);
                prm18.Direction = ParameterDirection.Input;
                prm18.Value = Friday;
                objOraclecommand.Parameters.Add(prm18);

                OracleParameter prm19 = new OracleParameter("pFriday_From", OracleType.VarChar, 50);
                prm19.Direction = ParameterDirection.Input;
                prm19.Value = Friday_From;
                objOraclecommand.Parameters.Add(prm19);



                OracleParameter prm20 = new OracleParameter("pFriday_To", OracleType.VarChar, 50);
                prm20.Direction = ParameterDirection.Input;
                prm20.Value = Friday_To;
                objOraclecommand.Parameters.Add(prm20);




                OracleParameter prm21 = new OracleParameter("pSaturday", OracleType.VarChar, 50);
                prm21.Direction = ParameterDirection.Input;
                prm21.Value = Saturday;
                objOraclecommand.Parameters.Add(prm21);

                OracleParameter prm22 = new OracleParameter("pSaturday_From", OracleType.VarChar, 50);
                prm22.Direction = ParameterDirection.Input;
                prm22.Value = Saturday_From;
                objOraclecommand.Parameters.Add(prm22);



                OracleParameter prm23 = new OracleParameter("pSaturday_To", OracleType.VarChar, 50);
                prm23.Direction = ParameterDirection.Input;
                prm23.Value = Saturday_To;
                objOraclecommand.Parameters.Add(prm23);


                OracleParameter prm24 = new OracleParameter("pDemog_sex", OracleType.VarChar, 50);
                prm24.Direction = ParameterDirection.Input;
                prm24.Value = Demog_sex;
                objOraclecommand.Parameters.Add(prm24);



                OracleParameter prm25 = new OracleParameter("pDemog_agegroup", OracleType.VarChar, 50);
                prm25.Direction = ParameterDirection.Input;
                prm25.Value = Demog_agegroup;
                objOraclecommand.Parameters.Add(prm25);



                OracleParameter prm26 = new OracleParameter("pDemog_Occup", OracleType.VarChar, 50);
                prm26.Direction = ParameterDirection.Input;
                prm26.Value = Demog_Occup;
                objOraclecommand.Parameters.Add(prm26);


                OracleParameter prm27 = new OracleParameter("pDemog_inter", OracleType.VarChar, 50);
                prm27.Direction = ParameterDirection.Input;
                prm27.Value = Demog_inter;
                objOraclecommand.Parameters.Add(prm27);


                OracleParameter prm28 = new OracleParameter("pComp_code", OracleType.VarChar, 50);
                prm28.Direction = ParameterDirection.Input;
                prm28.Value = compcode;
                objOraclecommand.Parameters.Add(prm28);



                OracleParameter prm29 = new OracleParameter("pcioBookingid", OracleType.VarChar, 50);
                prm29.Direction = ParameterDirection.Input;
                prm29.Value = ciobookingid;
                objOraclecommand.Parameters.Add(prm29);


                OracleParameter prm30 = new OracleParameter("pnoofinsert", OracleType.VarChar, 50);
                prm30.Direction = ParameterDirection.Input;
                prm30.Value = noofinsert;
                objOraclecommand.Parameters.Add(prm30);




                OracleParameter prm31 = new OracleParameter("pedition", OracleType.VarChar, 50);
                prm31.Direction = ParameterDirection.Input;
                prm31.Value = edition;
                objOraclecommand.Parameters.Add(prm31);


                OracleParameter prm32 = new OracleParameter("pinterest", OracleType.VarChar, 50);
                prm32.Direction = ParameterDirection.Input;
                prm32.Value = interest;
                objOraclecommand.Parameters.Add(prm32);



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



        public DataSet executegeotemp(string cio_book_id, string compcode, string noofinsert)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("executegeographytemp", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pcio_booking_id", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = cio_book_id;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("pcompcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);




                OracleParameter prm3 = new OracleParameter("pnoofinsert", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = noofinsert;
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





        public DataSet executegeo(string cio_book_id, string compcode, string noofinsert)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("executegeography", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pcio_booking_id", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = cio_book_id;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("pcompcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);




                OracleParameter prm3 = new OracleParameter("pnoofinsert", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = noofinsert;
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





        public DataSet bindtree(string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("adcountryname.adcountryname_P", ref objOracleConnection);
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
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }
        }




        public DataSet bindsubchild(string state, string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("binddistrict.binddistrict_P", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("statecode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = state;
                objOraclecommand.Parameters.Add(prm1);



                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);




                OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userid;
                objOraclecommand.Parameters.Add(prm3);




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




        public DataSet bindchild(string country, string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("bindstate.bindstate_P", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("countrycode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = country;
                objOraclecommand.Parameters.Add(prm1);



                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);




                OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userid;
                objOraclecommand.Parameters.Add(prm3);




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





        public DataSet tempexecutedays(string cio_book_id, string compcode, string noofinsert)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("tempexecutedays", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pcio_booking_id", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = cio_book_id;
                objOraclecommand.Parameters.Add(prm1);



                OracleParameter prm2 = new OracleParameter("pcompcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);




                OracleParameter prm3 = new OracleParameter("pnoofinsert", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = noofinsert;
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





        public DataSet executedays(string cio_book_id, string compcode, string noofinsert)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("executedays", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pcio_booking_id", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = cio_book_id;
                objOraclecommand.Parameters.Add(prm1);



                OracleParameter prm2 = new OracleParameter("pcompcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);




                OracleParameter prm3 = new OracleParameter("pnoofinsert", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = noofinsert;
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





        public DataSet tempdeletegeography(string compcode, string edition, string noofinsert, string ciobokid, string country, string statecode, string City)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("tempwebgeographdelete", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pcompcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);



                OracleParameter prm2 = new OracleParameter("pedition", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = edition;
                objOraclecommand.Parameters.Add(prm2);




                OracleParameter prm3 = new OracleParameter("pnoofinsert", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = noofinsert;
                objOraclecommand.Parameters.Add(prm3);




                OracleParameter prm4 = new OracleParameter("pciobookid", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = ciobokid;
                objOraclecommand.Parameters.Add(prm4);



                OracleParameter prm5 = new OracleParameter("pcountry", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;

                if(country=="")
                {
                prm5.Value = System.DBNull.Value;
                }
                else
                {
                prm5.Value = country;

                }
                objOraclecommand.Parameters.Add(prm5);



                OracleParameter prm6 = new OracleParameter("pstatecode", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                if(statecode=="")
                {
                prm6.Value =System.DBNull.Value;
                }
                else
                {
                       prm6.Value = statecode;
                }
                objOraclecommand.Parameters.Add(prm6);



                OracleParameter prm7 = new OracleParameter("pCity", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;

                if(City=="")
                {
                prm7.Value =System.DBNull.Value;
                }
                else
                {

                    prm7.Value = City;

                }
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




        public DataSet deletegeography(string compcode, string edition, string noofinsert, string ciobokid, string country, string statecode, string City)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("webgeographdelete", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pcompcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);



                OracleParameter prm2 = new OracleParameter("pedition", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = edition;
                objOraclecommand.Parameters.Add(prm2);




                OracleParameter prm3 = new OracleParameter("pnoofinsert", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = noofinsert;
                objOraclecommand.Parameters.Add(prm3);




                OracleParameter prm4 = new OracleParameter("pciobookid", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = ciobokid;
                objOraclecommand.Parameters.Add(prm4);



                OracleParameter prm5 = new OracleParameter("pcountry", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;

                if (country == "")
                {
                    prm5.Value = System.DBNull.Value;
                }
                else
                {
                    prm5.Value = country;

                }
                objOraclecommand.Parameters.Add(prm5);



                OracleParameter prm6 = new OracleParameter("pstatecode", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                if (statecode == "")
                {
                    prm6.Value = System.DBNull.Value;
                }
                else
                {
                    prm6.Value = statecode;
                }
                objOraclecommand.Parameters.Add(prm6);



                OracleParameter prm7 = new OracleParameter("pCity", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;

                if (City == "")
                {
                    prm7.Value = System.DBNull.Value;
                }
                else
                {

                    prm7.Value = City;

                }
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




        public DataSet tempexecutewebmaterial(string cioid, string Comp_code, string NO_INSERT, string filename)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("tempexecutewebbookingmateria", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pcioid", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = cioid;
                objOraclecommand.Parameters.Add(prm1);



                OracleParameter prm2 = new OracleParameter("pComp_code", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = Comp_code;
                objOraclecommand.Parameters.Add(prm2);




                OracleParameter prm3 = new OracleParameter("pNO_INSERT", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = NO_INSERT;
                objOraclecommand.Parameters.Add(prm3);




                OracleParameter prm4 = new OracleParameter("pfilename", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = filename;
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




        public DataSet executewebmaterial(string cioid, string Comp_code, string NO_INSERT, string filename)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("executewebbookingmateria", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pcioid", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = cioid;
                objOraclecommand.Parameters.Add(prm1);



                OracleParameter prm2 = new OracleParameter("pComp_code", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = Comp_code;
                objOraclecommand.Parameters.Add(prm2);




                OracleParameter prm3 = new OracleParameter("pNO_INSERT", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = NO_INSERT;
                objOraclecommand.Parameters.Add(prm3);




                OracleParameter prm4 = new OracleParameter("pfilename", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = filename;
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


        












    }

}