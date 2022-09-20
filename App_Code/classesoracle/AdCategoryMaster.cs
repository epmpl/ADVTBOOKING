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
    /// Summary description for AdCategoryMaster
    /// </summary>
    public class AdCategoryMaster : orclconnection
    {
        public AdCategoryMaster()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataSet advcatinsert1(string compcode, string userid, string adcatcode, string catalias, string catname, string adtype, string regclient, string filename, string status, string productivity, string hrs, string min, string preodicity, string discount, string discamt, string ffdiscount, string ffdiscamt, string cashdisc, string cashamt, string ldgenday, string ldgenflag, string eddiscflag)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("advinsert.advinsert_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("adcatcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = adcatcode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("catalias", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = catalias;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("catname", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = catname;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("adtype", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = adtype;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("rclient", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = regclient;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("filename", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = filename;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("status1", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = status;
                objOraclecommand.Parameters.Add(prm9);


                OracleParameter prm10 = new OracleParameter("productivity", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = productivity;
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("hrs", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = hrs;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("min1", OracleType.VarChar, 50);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = min;
                objOraclecommand.Parameters.Add(prm12);


                OracleParameter prm13 = new OracleParameter("sapcode", OracleType.VarChar, 50);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm13);

                OracleParameter prm14 = new OracleParameter("pstate", OracleType.VarChar, 50);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm14);


                OracleParameter prm15 = new OracleParameter("preodicity", OracleType.VarChar, 50);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = preodicity;
                objOraclecommand.Parameters.Add(prm15);


                OracleParameter prm16 = new OracleParameter("pdiscount", OracleType.VarChar, 500);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = discount;
                objOraclecommand.Parameters.Add(prm16);

                OracleParameter prm18 = new OracleParameter("pdiscamt", OracleType.VarChar, 500);
                prm18.Direction = ParameterDirection.Input;
                prm18.Value = discamt;
                objOraclecommand.Parameters.Add(prm18);

                OracleParameter prm19 = new OracleParameter("pffdisctype", OracleType.VarChar, 500);
                prm19.Direction = ParameterDirection.Input;
                prm19.Value = ffdiscount;
                objOraclecommand.Parameters.Add(prm19);

                OracleParameter prm20 = new OracleParameter("pffdiscamt", OracleType.VarChar, 500);
                prm20.Direction = ParameterDirection.Input;
                prm20.Value = ffdiscamt;
                objOraclecommand.Parameters.Add(prm20);

                OracleParameter prm21 = new OracleParameter("pcashdisc", OracleType.VarChar, 500);
                prm21.Direction = ParameterDirection.Input;
                prm21.Value = cashdisc;
                objOraclecommand.Parameters.Add(prm21);

                OracleParameter prm22 = new OracleParameter("pcashamt", OracleType.VarChar, 500);
                prm22.Direction = ParameterDirection.Input;
                prm22.Value = cashamt;
                objOraclecommand.Parameters.Add(prm22);

                OracleParameter prm23 = new OracleParameter("lead_flag", OracleType.VarChar, 500);
                prm23.Direction = ParameterDirection.Input;
                prm23.Value = ldgenflag;
                objOraclecommand.Parameters.Add(prm23);

                OracleParameter prm24 = new OracleParameter("lead_days", OracleType.VarChar, 500);
                prm24.Direction = ParameterDirection.Input;
                prm24.Value = ldgenday;
                objOraclecommand.Parameters.Add(prm24);

                OracleParameter prm25 = new OracleParameter("edition_dis_flag", OracleType.VarChar, 500);
                prm25.Direction = ParameterDirection.Input;
                prm25.Value = eddiscflag;
                objOraclecommand.Parameters.Add(prm25);

               


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

        public DataSet advcatchk(string compcode, string userid, string adcatcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("advchk.advchk_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("adcatcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = adcatcode;
                objOraclecommand.Parameters.Add(prm3);

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



        //Code for the Modify the data into the data base//
        public DataSet advcatupdate1(string compcode, string userid, string adcatcode, string catalias, string catname, string adtype, string regclient, string filename, string status, string productivity, string hrs, string min, string preodicity, string discount, string discamt, string ffdiscount, string ffdiscamt, string cashdisc, string cashamt, string extra1, string extra2, string ldgenday, string ldgenflag,string eddiscflag)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("advupdate.advupdate_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 500);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("adcatcode", OracleType.VarChar, 500);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = adcatcode;
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("catalias", OracleType.VarChar, 500);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = catalias;
                objOraclecommand.Parameters.Add(prm3);


                OracleParameter prm4 = new OracleParameter("catname", OracleType.VarChar, 500);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = catname;
                objOraclecommand.Parameters.Add(prm4);


                OracleParameter prm5 = new OracleParameter("adtype", OracleType.VarChar, 500);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = adtype;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("rclient", OracleType.VarChar, 500);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = regclient;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("filename", OracleType.VarChar, 500);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = filename;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm9 = new OracleParameter("status1", OracleType.VarChar, 500);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = status;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("productivity", OracleType.VarChar, 500);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = productivity;
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("hrs", OracleType.VarChar, 500);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = hrs;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm8 = new OracleParameter("min1", OracleType.VarChar, 500);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = min;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm12 = new OracleParameter("preodicity", OracleType.VarChar, 500);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = preodicity;
                objOraclecommand.Parameters.Add(prm12);

                OracleParameter prm13 = new OracleParameter("pdiscount", OracleType.VarChar, 500);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = discount;
                objOraclecommand.Parameters.Add(prm13);

                OracleParameter prm14 = new OracleParameter("pdiscamt", OracleType.VarChar, 500);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = discamt;
                objOraclecommand.Parameters.Add(prm14);

                OracleParameter prm15 = new OracleParameter("pffdisctype", OracleType.VarChar, 500);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = ffdiscount;
                objOraclecommand.Parameters.Add(prm15);

                OracleParameter prm16 = new OracleParameter("pffdiscamt", OracleType.VarChar, 500);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = ffdiscamt;
                objOraclecommand.Parameters.Add(prm16);

                OracleParameter prm17 = new OracleParameter("pcashdisc", OracleType.VarChar, 500);
                prm17.Direction = ParameterDirection.Input;
                prm17.Value = cashdisc;
                objOraclecommand.Parameters.Add(prm17);

                OracleParameter prm18 = new OracleParameter("pcashamt", OracleType.VarChar, 500);
                prm18.Direction = ParameterDirection.Input;
                prm18.Value = cashamt;
                objOraclecommand.Parameters.Add(prm18);

                OracleParameter prm19 = new OracleParameter("psapcode", OracleType.VarChar, 500);
                prm19.Direction = ParameterDirection.Input;
                prm19.Value = extra1;
                objOraclecommand.Parameters.Add(prm19);


                OracleParameter prm20 = new OracleParameter("pstate", OracleType.VarChar, 500);
                prm20.Direction = ParameterDirection.Input;
                prm20.Value = extra2;
                objOraclecommand.Parameters.Add(prm20);

                OracleParameter prm21 = new OracleParameter("lead_days", OracleType.VarChar, 500);
                prm21.Direction = ParameterDirection.Input;
                prm21.Value = ldgenday;
                objOraclecommand.Parameters.Add(prm21);

                OracleParameter prm22 = new OracleParameter("lead_flag", OracleType.VarChar, 500);
                prm22.Direction = ParameterDirection.Input;
                prm22.Value = ldgenflag;
                objOraclecommand.Parameters.Add(prm22);

                OracleParameter prm23 = new OracleParameter("edition_dis_flag", OracleType.VarChar, 500);
                prm23.Direction = ParameterDirection.Input;
                prm23.Value = eddiscflag;
                objOraclecommand.Parameters.Add(prm23);


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

        //Code for the Execute the commande for fetch the data from the data base//
        public DataSet advcatexecute(string compcode, string userid, string adcatcode, string catalias, string catname, string adtype)//, string catediname)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("advcatexec.advcatexec_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("adcatcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = adcatcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("catalias", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = catalias;
                objOraclecommand.Parameters.Add(prm3);



                OracleParameter prm4 = new OracleParameter("adtype", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                if (adtype == "0")
                {
                    prm4.Value = System.DBNull.Value;
                    
                }
                else
                {
                    prm4.Value = adtype;
                  
                }
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("catname", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = catname;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("pstate", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = System.DBNull.Value;
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



        //public DataSet advcatexecute12(string compcode,string userid,string adcatcode,string catalias,string catname,string catediname,string focusday)
        public DataSet advcatexecute12(string compcode, string userid, string adcatcode, string catalias, string catname, string adtype)//, string catediname)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("advcatexec.advcatexec_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("adcatcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = adcatcode;
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("adtype", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                if (adtype=="0")
                {
                    prm3.Value = System.DBNull.Value;

                }
                else
                {
                prm3.Value = adtype;
                }
                objOraclecommand.Parameters.Add(prm3);




                OracleParameter prm4 = new OracleParameter("catalias", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = catalias;
                objOraclecommand.Parameters.Add(prm4);


                OracleParameter prm5 = new OracleParameter("catname", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = catname;
                objOraclecommand.Parameters.Add(prm5);


                OracleParameter prm6 = new OracleParameter("pstate", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = System.DBNull.Value;
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





        //Code for the See the first data//
        /*    public DataSet advcatfirst(string compcode, string userid)
            {
                OracleConnection objOracleConnection;
                OracleCommand objOraclecommand;
                DataSet objDataSet = new DataSet();
                objOracleConnection = GetConnection();
                OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
                try
                {
                    objOracleConnection.Open();
                    objOraclecommand = GetCommand("advcatfnpl", ref objOracleConnection);
                    objOraclecommand.CommandType = CommandType.StoredProcedure;

                    objOraclecommand.Parameters.Add("compcode", SqlDbType.VarChar);
                    objOraclecommand.Parameters["compcode"].Value = compcode;

                    //objOraclecommand.Parameters.Add("userid", SqlDbType.VarChar);
                    //objOraclecommand.Parameters["userid"].Value = userid;

                    //	objOraclecommand.Parameters.Add("flag", SqlDbType.VarChar);
                    //objOraclecommand.Parameters["flag"].Value =z;




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


        //Code for the See the Last data//
        /*     public DataSet advcatlast(string compcode, string userid)
             {
                 OracleConnection objOracleConnection;
                 OracleCommand objOraclecommand;
                 DataSet objDataSet = new DataSet();
                 objOracleConnection = GetConnection();
                 OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
                 try
                 {
                     objOracleConnection.Open();
                     objOraclecommand = GetCommand("advcatfnpl", ref objOracleConnection);
                     objOraclecommand.CommandType = CommandType.StoredProcedure;

                     objOraclecommand.Parameters.Add("compcode", SqlDbType.VarChar);
                     objOraclecommand.Parameters["compcode"].Value = compcode;

                     //objOraclecommand.Parameters.Add("userid", SqlDbType.VarChar);
                     //objOraclecommand.Parameters["userid"].Value = userid;

                     //objOraclecommand.Parameters.Add("flag", SqlDbType.VarChar);
                     //objOraclecommand.Parameters["flag"].Value =z;




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


        //Code for the See the Previous data//
        /*  public DataSet advcatpre(string compcode, string userid)
          {
              OracleConnection objOracleConnection;
              OracleCommand objOraclecommand;
              DataSet objDataSet = new DataSet();
              objOracleConnection = GetConnection();
              OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
              try
              {
                  objOracleConnection.Open();
                  objOraclecommand = GetCommand("advcatfnpl", ref objOracleConnection);
                  objOraclecommand.CommandType = CommandType.StoredProcedure;

                  objOraclecommand.Parameters.Add("compcode", SqlDbType.VarChar);
                  objOraclecommand.Parameters["compcode"].Value = compcode;

                  //objOraclecommand.Parameters.Add("userid", SqlDbType.VarChar);
                  //objOraclecommand.Parameters["userid"].Value = userid;

                  //objOraclecommand.Parameters.Add("flag", SqlDbType.VarChar);
                  //objOraclecommand.Parameters["flag"].Value =z;




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

          //Code for the See the Next data//
          public DataSet advcatnext(string compcode, string userid)
          {
              OracleConnection objOracleConnection;
              OracleCommand objOraclecommand;
              DataSet objDataSet = new DataSet();
              objOracleConnection = GetConnection();
              OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
              try
              {
                  objOracleConnection.Open();
                  objOraclecommand = GetCommand("advcatfnpl", ref objOracleConnection);
                  objOraclecommand.CommandType = CommandType.StoredProcedure;

                  objOraclecommand.Parameters.Add("compcode", SqlDbType.VarChar);
                  objOraclecommand.Parameters["compcode"].Value = compcode;

                  //objOraclecommand.Parameters.Add("userid", SqlDbType.VarChar);
                  //objOraclecommand.Parameters["userid"].Value = userid;

                  //objOraclecommand.Parameters.Add("flag", SqlDbType.VarChar);
                  //objOraclecommand.Parameters["flag"].Value =z;




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

        //Code for the Delete the data from the data base//
        public DataSet advcatdel(string compcode, string adcatcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("advcatdel.advcatdel_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("adcatcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = adcatcode;
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

        //Code for Auto Genereate-Code for the CategoryName// 
        public DataSet countadcatcode(string str,string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("chkadcatcodename.chkadcatcodename_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("str", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = str;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("cod", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                if (str.Length > 2)
                {
                    prm2.Value = str.Substring(0,2);
                    objOraclecommand.Parameters.Add(prm2);
                }
                else
                {
                    prm2.Value = str;
                    objOraclecommand.Parameters.Add(prm2);
                }

                OracleParameter prm3 = new OracleParameter("company_code", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = compcode;
                objOraclecommand.Parameters.Add(prm3);

                objOraclecommand.Parameters.Add("P_ACCOUNTS", OracleType.Cursor);
                objOraclecommand.Parameters["P_ACCOUNTS"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("P_ACCOUNTS1", OracleType.Cursor);
                objOraclecommand.Parameters["P_ACCOUNTS1"].Direction = ParameterDirection.Output;

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



        public DataSet ckkusercode(string adcatcode, string catname)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("chkadcatuser.chkadcatuser_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("adcatcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = adcatcode;
                objOraclecommand.Parameters.Add(prm1);



                OracleParameter prm2 = new OracleParameter("catname", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = catname;
                objOraclecommand.Parameters.Add(prm2);


                objOraclecommand.Parameters.Add("P_ACCOUNTS", OracleType.Cursor);
                objOraclecommand.Parameters["P_ACCOUNTS"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("P_ACCOUNTS1", OracleType.Cursor);
                objOraclecommand.Parameters["P_ACCOUNTS1"].Direction = ParameterDirection.Output;



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



        //Code for the save the select day in the data base//
        public DataSet selectaddaysave(string compcode, string adcatcode, string sun, string mon, string tue, string wed, string thu, string fri, string sat, string allday, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("slelectadcatdaysave.slelectadcatdaysave_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("adcatcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = adcatcode;
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("sun", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = sun;
                objOraclecommand.Parameters.Add(prm3);


                OracleParameter prm4 = new OracleParameter("mon", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = mon;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("tue", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = tue;
                objOraclecommand.Parameters.Add(prm5);


                OracleParameter prm6 = new OracleParameter("wed", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = wed;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("thu", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = thu;
                objOraclecommand.Parameters.Add(prm7);


                OracleParameter prm8 = new OracleParameter("fri", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = fri;
                objOraclecommand.Parameters.Add(prm8);


                OracleParameter prm9 = new OracleParameter("sat", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = sat;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("allday", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = allday;
                objOraclecommand.Parameters.Add(prm10);


                OracleParameter prm11 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = userid;
                objOraclecommand.Parameters.Add(prm11);


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

        public DataSet checkadcode(string compcode, string adcatcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("checkadcode.checkadcode_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("adcatcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = adcatcode;
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userid;
                objOraclecommand.Parameters.Add(prm3);

                objOraclecommand.Parameters.Add("P_ACCOUNTS", OracleType.Cursor);
                objOraclecommand.Parameters["P_ACCOUNTS"].Direction = ParameterDirection.Output;

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

        //Code for the modify the select day in the data base//
        public DataSet selectaddaymodify(string compcode, string adcatcode, string sun, string mon, string tue, string wed, string thu, string fri, string sat, string all, string userid)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("slelectaddaymodify.slelectaddaymodify_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("adcatcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = adcatcode;
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("sun", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = sun;
                objOraclecommand.Parameters.Add(prm3);


                OracleParameter prm4 = new OracleParameter("mon", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = mon;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("tue", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = tue;
                objOraclecommand.Parameters.Add(prm5);


                OracleParameter prm6 = new OracleParameter("wed", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = wed;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("thu", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = thu;
                objOraclecommand.Parameters.Add(prm7);


                OracleParameter prm8 = new OracleParameter("fri", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = fri;
                objOraclecommand.Parameters.Add(prm8);


                OracleParameter prm9 = new OracleParameter("allday", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = all;
                objOraclecommand.Parameters.Add(prm9);


                OracleParameter prm10 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = userid;
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("sat", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = sat;
                objOraclecommand.Parameters.Add(prm11);


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

        //Enable check boxes on select The Edition Day//
        public DataSet editionday(string drpednname)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("enableadcatday.enableadcatday_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("editionname", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = drpednname;
                objOraclecommand.Parameters.Add(prm1);

                objOraclecommand.Parameters.Add("P_ACCOUNTS", OracleType.Cursor);
                objOraclecommand.Parameters["P_ACCOUNTS"].Direction = ParameterDirection.Output;


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

        //*********************************************************************************//
        //**************************Coding For PoP Up Window*******************************//
        //*********************************************************************************//

        //Bind The Drop Down For Select Edition//
        public DataSet selectedition(string compcode, string userid)//,string edition)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("selecteditionname.selecteditionname_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                objOraclecommand.Parameters.Add("P_ACCOUNTS", OracleType.Cursor);
                objOraclecommand.Parameters["P_ACCOUNTS"].Direction = ParameterDirection.Output;


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
        //Proceduer  For Submit//
        public DataSet editionsubmit(string compcode, string userid, string adcatcode, string edition, string chk1, string chk2, string chk3, string chk4, string chk5, string chk6, string chk7, string chk8)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("editionsubmit.editionsubmit_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("adcatcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = adcatcode;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userid;
                objOraclecommand.Parameters.Add(prm3);


                OracleParameter prm4 = new OracleParameter("editioncode", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = edition;
                objOraclecommand.Parameters.Add(prm4);


                OracleParameter prm5 = new OracleParameter("sun", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = chk1;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("mon", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = chk2;
                objOraclecommand.Parameters.Add(prm6);


                OracleParameter prm7 = new OracleParameter("tue", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = chk3;
                objOraclecommand.Parameters.Add(prm7);


                OracleParameter prm8 = new OracleParameter("wed", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = chk4;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("thu", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = chk5;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("fri", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = chk6;
                objOraclecommand.Parameters.Add(prm10);


                OracleParameter prm11 = new OracleParameter("sat", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = chk7;
                objOraclecommand.Parameters.Add(prm11);


                OracleParameter prm12 = new OracleParameter("allday", OracleType.VarChar, 50);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = chk8;
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

        //Bind The Data Grid //
        public DataSet editionbindgrid(string compcode, string userid)//, string edition)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("editiondatabind.editiondatabind_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);



                OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userid;
                objOraclecommand.Parameters.Add(prm3);

                //objOraclecommand.Parameters.Add("edition", SqlDbType.VarChar);
                //objOraclecommand.Parameters["edition"].Value = edition;

                ////objOraclecommand.Parameters.Add("values", SqlDbType.VarChar);
                //objOraclecommand.Parameters["values"].Value = values;

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



        //Procedure For check The Edition code //
        public DataSet editionchk(string compcode, string userid, string edition)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("editionchk.editionchk_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userid;
                objOraclecommand.Parameters.Add(prm3);


                OracleParameter prm4 = new OracleParameter("editioncode", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = edition;
                objOraclecommand.Parameters.Add(prm4);





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

        //Procedure For Modify//
        public DataSet editionmodify(string compcode, string userid, string adcatcode, string edition, string chk1, string chk2, string chk3, string chk4, string chk5, string chk6, string chk7, string chk8, string hiddenccode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("editionmodify.editionmodify_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("adcatcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = adcatcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userid;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("editioncode", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = edition;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("sun", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = chk1;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("mon", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = chk2;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("tue", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = chk3;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8= new OracleParameter("wed", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = chk4;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9= new OracleParameter("thu", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = chk5;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("fri", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = chk6;
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("sat", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = chk7;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("allday", OracleType.VarChar, 50);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = chk8;
                objOraclecommand.Parameters.Add(prm12);

                OracleParameter prm13 = new OracleParameter("hiddenccode", OracleType.VarChar, 50);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = hiddenccode;
                objOraclecommand.Parameters.Add(prm13);
          
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

        //  Procedure For Delete//

        public DataSet editiondelete(string compcode, string userid, string edition, string hiddenccode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("editiondel.editiondel_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

               


                OracleParameter prm3 = new OracleParameter("edition", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = edition;
                objOraclecommand.Parameters.Add(prm3);



                OracleParameter prm4 = new OracleParameter("hiddenccode", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = hiddenccode;
                objOraclecommand.Parameters.Add(prm4);

          


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
        //My//
        ////Procedure for the select the Row From the Data Grid//
        public DataSet seledition(string adcatcode, string userid, string compcode, string code10)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("editiondaysel.editiondaysel_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("adcatcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = adcatcode;
                objOraclecommand.Parameters.Add(prm3);


                OracleParameter prm4 = new OracleParameter("code10", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = code10;
                objOraclecommand.Parameters.Add(prm4);

                objOraclecommand.Parameters.Add("P_ACCOUNTS", OracleType.Cursor);
                objOraclecommand.Parameters["P_ACCOUNTS"].Direction = ParameterDirection.Output;

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


        //public DataSet selectpublication()
        //{
        //    SqlConnection objOracleConnection;
        //    SqlCommand objOraclecommand;
        //    objOracleConnection = GetConnection();
        //    SqlDataAdapter objorclDataAdapter = new SqlDataAdapter();
        //    DataSet objDataSet = new DataSet();
        //    try
        //    {
        //        objOracleConnection.Open();
        //        objOraclecommand = GetCommand("selectadcategory", ref objOracleConnection);
        //        objOraclecommand.CommandType = CommandType.StoredProcedure;

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
                objOraclecommand = GetCommand("adv_bindcategory.adv_bindcategory_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

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


        public DataSet catwiesedition(string adcatcode, string userid, string compcode)//, string dateformat)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("catwiesedition.catwiesedition_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("centcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = adcatcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = compcode;
                objOraclecommand.Parameters.Add(prm3);

                objOraclecommand.Parameters.Add("P_ACCOUNTS", OracleType.Cursor);
                objOraclecommand.Parameters["P_ACCOUNTS"].Direction = ParameterDirection.Output;


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



      public DataSet chkedit(string edition, string adcatcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("chkcategoryedition.chkcategoryedition_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("edition", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = edition;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("adcatcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = adcatcode;
                objOraclecommand.Parameters.Add(prm2);


                objOraclecommand.Parameters.Add("P_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["P_accounts"].Direction = ParameterDirection.Output;

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


        public DataSet editionchk_b(string compcode, string adcatcode, string edition)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("editionchk_b.editionchk_b_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("adcatcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = adcatcode;
                objOraclecommand.Parameters.Add(prm3);


                OracleParameter prm4 = new OracleParameter("editioncode", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = edition;
                objOraclecommand.Parameters.Add(prm4);


                objOraclecommand.Parameters.Add("P_ACCOUNTS", OracleType.Cursor);
                objOraclecommand.Parameters["P_ACCOUNTS"].Direction = ParameterDirection.Output;


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

        public DataSet selectadtxtsave(string compcode, string adcatcode, string txtsun, string txtmon, string txttue, string txtwed, string txtthu, string txtfri, string txtsat, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("slelectadcattxtsave.slelectadcattxtsave_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm2 = new OracleParameter("padcatcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = adcatcode;
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("pcompcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = compcode;
                objOraclecommand.Parameters.Add(prm3);


                OracleParameter prm4 = new OracleParameter("puserid", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = userid;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("ptxtsun", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = txtsun;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("ptxtmon", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = txtmon;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("ptxttue", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = txttue;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("ptxtwed", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = txtwed;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("ptxtthu", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = txtthu;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("ptxtfri", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = txtfri;
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("ptxtsat", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = txtsat;
                objOraclecommand.Parameters.Add(prm11);

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


        public DataSet slelectadtxtmodify(string compcode, string adcatcode, string txtsun, string txtmon, string txttue, string txtwed, string txtthu, string txtfri, string txtsat, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("slelectadcattxtsave.slelectadtxtmodify", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm2 = new OracleParameter("padcatcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = adcatcode;
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("pcompcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = compcode;
                objOraclecommand.Parameters.Add(prm3);


                OracleParameter prm4 = new OracleParameter("puserid", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = userid;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("ptxtsun", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = txtsun;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("ptxtmon", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = txtmon;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("ptxttue", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = txttue;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("ptxtwed", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = txtwed;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("ptxtthu", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = txtthu;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("ptxtfri", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = txtfri;
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("ptxtsat", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = txtsat;
                objOraclecommand.Parameters.Add(prm11);

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


        public DataSet checkadtxt(string compcode, string adcatcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("slelectadcattxtsave.checkadtxt", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm2 = new OracleParameter("pcompcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("padcatcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = adcatcode;
                objOraclecommand.Parameters.Add(prm3);


                OracleParameter prm4 = new OracleParameter("puserid", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = userid;
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